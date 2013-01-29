Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient


Public Class FrmPelunasanPiutang
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim period As String = ""
    Dim CurrDate As String
    Private Sub FrmPelunasanPiutang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        Clear_Wa()
        Enable_Wa(False)
        EnableInput(False)
        DisableButton(False)
        Enable_Button_Wa(False)
        gvPembayaran.AllowUserToAddRows = False
        LoadPembayaranViaBank(txt_DocNo.Text)

        If txt_DocNo.Text.Trim <> "" Then
            LoadPembayaranViaBank(txt_DocNo.Text)
            'If CheckAuthorisasi(txt_DocNo.Text.ToString.Trim, userlog.UserName) = True Then
            ts_Edit.Enabled = True
            gvPembayaran.Enabled = True
            btn_insert.Enabled = False
            txtnoDPP.Enabled = False
            'End If
            CurrDate = GetCurrDate.ToString.Substring(0, 10)
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                Enable_Wa(False)
                EnableInput(False)
                DisableButton(False)
                Enable_Button_Wa(False)
                gvPembayaran.Enabled = False
                ts_Edit.Enabled = False
                btn_insert.Enabled = False
            End If
        Else
            txtPeriod.Text = GetPeriod()
            EnableInput(True)
            Enable_Button_Wa(True)
            DisableButton(False)
            ts_save.Enabled = True
            ts_cancel.Enabled = True
            txtnoDPP.Focus()
            gvPembayaran.Enabled = True
        End If
        SetGrid_item()

    End Sub

    Private Function GetPeriod() As String
        Dim dt As New DataTable


        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "select period from trans_closing order by period desc"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            Return dt.Rows(0).Item("period").ToString


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return String.Empty
    End Function

    Private Sub LoadPembayaranViaBank(ByVal No As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC sp_Retreive_Trans_PelunasanPiutangDtl '" + No + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)


            gvPembayaran.DataSource = dt_hdr
            gvPembayaran.Enabled = dt_hdr.Rows.Count > 0

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearInput()
        'txt_TransNo.Clear()
        'txt_NmSupplier.Clear()

        dt_Pelunasan.Value = Now
        txt_Ket.Clear()
        gvPembayaran.DataSource = ""

    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        list_pembayaran.Enabled = boo
        txt_jumlahbayar.Enabled = boo
        txt_keterangan.Enabled = boo
        dt_JatuhTempo.Enabled = boo
        txt_account.Enabled = boo
        txt_noPR.Enabled = boo
        txt_account.Enabled = boo
        txt_accountpot.Enabled = boo
        txt_invoice.Enabled = boo

    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        txt_NmKolektor.Enabled = boo
        dt_Pelunasan.Enabled = boo
        txt_NmKolektor.Enabled = boo
        txt_Ket.Enabled = boo
    End Sub

    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            list_pembayaran.BackColor = Color.DarkGray
            txt_nogiro.BackColor = Color.DarkGray
            txt_jumlahbayar.BackColor = Color.DarkGray
            txt_keterangan.BackColor = Color.DarkGray
            dt_JatuhTempo.BackColor = Color.DarkGray
            txt_noPR.BackColor = Color.DarkGray
            txt_account.BackColor = Color.DarkGray
            txt_potongan.BackColor = Color.DarkGray
            txt_accountpot.BackColor = Color.DarkGray
            txt_invoice.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            list_pembayaran.BackColor = Color.LemonChiffon
            txt_nogiro.BackColor = Color.LemonChiffon
            txt_jumlahbayar.BackColor = Color.LemonChiffon
            txt_keterangan.BackColor = Color.LemonChiffon
            dt_JatuhTempo.BackColor = Color.LemonChiffon
            txt_noPR.BackColor = Color.DarkGray
            txt_account.BackColor = Color.LemonChiffon
            txt_accountpot.BackColor = Color.LemonChiffon
            txt_potongan.BackColor = Color.LemonChiffon
            txt_invoice.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txt_emp.BackColor = Color.LemonChiffon
            list_pembayaran.BackColor = Color.LemonChiffon
            txt_jumlahbayar.BackColor = Color.LemonChiffon
            txt_keterangan.BackColor = Color.LemonChiffon
            dt_JatuhTempo.BackColor = Color.LemonChiffon
            txt_noPR.BackColor = Color.LemonChiffon
            txt_account.BackColor = Color.LemonChiffon
            txt_accountpot.BackColor = Color.LemonChiffon
            txt_potongan.BackColor = Color.LemonChiffon
            txt_invoice.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub Clear_Wa()
        list_pembayaran.SelectedIndex = 0
        txt_nogiro.Clear()
        txt_jumlahbayar.Clear()
        txt_keterangan.Clear()
        txt_account.Clear()
        txt_invoice.Clear()
        txt_NilaiPO.Clear()
        txt_account.Clear()
        txt_keterangan.Clear()
        txt_nogiro.Clear()
        txt_Outstanding.Clear()
        txt_cusID.Clear()
        txt_nmCus.Clear()
        txt_nmCus.Clear()
        txt_noPR.Clear()
        txt_potongan.Clear()
        txt_fakturtipe.Clear()
        chk_UangMuka.Checked = False
        dt_JatuhTempo.Value = Now
        txt_accountpot.Clear()
        txtNamaBank.Clear()
        txtOutstandingInv.Clear()
    End Sub

    Private Sub Enable_Button_Wa(ByVal boo As Boolean)
        btn_insert.Enabled = boo
        btn_edit.Enabled = boo
        btn_save.Enabled = boo
        btn_delete.Enabled = boo
        Btn_cancel.Enabled = boo
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo
    End Sub

    Private Sub txt_noPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_noPR.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("exec sp_GetPRPelunasanPiutang", "Project_No", "Nilai_Project", "Outstanding", "", "")
            txt_noPR.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_NilaiPO.Text = frmSearch.txtResult2.Text.ToString.Trim
            txt_Outstanding.Text = frmSearch.txtResult3.Text.ToString.Trim

            Try
                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "select c.cust_ID,c.nama from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no left join master_customer c on b.cust_id = c.cust_id where project_no = '" & txt_noPR.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)

                txt_cusID.Text = dt.Rows(0).Item("Cust_ID")
                txt_nmCus.Text = dt.Rows(0).Item("Nama")

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try

        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"
        Enable_Wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_invoice.Focus()
        txt_noPR.ReadOnly = True
        txt_noPR.BackColor = Color.DarkGray
    End Sub

    Private Sub ts_New_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_New.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
    End Sub

    Private Sub list_pembayaran_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles list_pembayaran.SelectedIndexChanged
        If list_pembayaran.SelectedIndex = 3 And Status_Proses <> "" Then
            txt_nogiro.Enabled = True
            txt_nogiro.BackColor = Color.LemonChiffon
            dt_JatuhTempo.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
        ElseIf list_pembayaran.SelectedIndex = 2 And Status_Proses <> "" Then
            dtTransfer.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
            txt_account.Clear()
            txt_account.Enabled = True
            txt_account.BackColor = Color.LemonChiffon
        Else
            txt_nogiro.Clear()
            txt_nogiro.Enabled = False
            txt_nogiro.BackColor = Color.DarkGray
            dt_JatuhTempo.Enabled = False
            dtTransfer.Enabled = False
            txtNamaBank.Enabled = False
            txtNamaBank.BackColor = Color.DarkGray
        End If
    End Sub

    Private Sub SetGrid_item()
        'If gvPembayaran.Rows.Count > 0 Then
        '    gvPembayaran.Columns(12).DefaultCellStyle.Format = "#,##0.#0"
        '    gvPembayaran.Columns(13).DefaultCellStyle.Format = "#,##0.#0"
        'End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Faktur_NO")
        dt_hdr.PrimaryKey = dc

        ' Validation
        If (txt_jumlahbayar.Text <> txtOutstandingInv.Text) And chkInvoice.Checked = False Then
            MessageBox.Show("Jumlah Bayar dan Outstanding Invoice tidak sama, Invoice Dikembalikan harus di check.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If list_pembayaran.SelectedIndex = 0 Then
            MessageBox.Show("Tipe Pembayaran harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txt_Outstanding.Text = "" Then
            MessageBox.Show("Nilai Outstanding harus ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txt_jumlahbayar.Text = "" Then
            MessageBox.Show("Jumlah Bayar harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If CInt(txt_jumlahbayar.Text) > CInt(txtOutstandingInv.Text) Then
            MessageBox.Show("Jumlah bayar tidak boleh lebih besar dari outstanding invoice", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If CInt(txt_jumlahbayar.Text) > CInt(txt_Outstanding.Text) Then
            MessageBox.Show("Jumlah bayar tidak boleh lebih besar dari outstanding", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txt_account.Text = String.Empty Then
            MessageBox.Show("Account harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If list_pembayaran.SelectedIndex = 3 Then
            If txt_nogiro.Text = String.Empty Then
                MessageBox.Show("Nomor Giro harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        'If txt_potongan.Text = "" Then
        '    MessageBox.Show("Potongan harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        If txt_invoice.Text = "" Then
            MessageBox.Show("Invoice harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            Dim dr As DataRow
            da = dt_hdr.Rows.Find(txt_invoice.Text)
            If da IsNot Nothing Then
                MessageBox.Show("No Faktur sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                dr = dt_hdr.NewRow
                dr("Project_No") = txt_noPR.Text
                If chk_UangMuka.Checked Then
                    dr("Uang_Muka") = "Y"
                Else
                    dr("Uang_Muka") = "N"
                End If
                dr("Cust_ID") = txt_cusID.Text
                dr("Tipe_Pembayaran") = list_pembayaran.SelectedItem
                dr("Bank") = txtNamaBank.Text
                dr("Tgl_Transfer") = dtTransfer.Value
                dr("Account") = txt_account.Text
                dr("No_Giro") = txt_nogiro.Text
                dr("Jatuh_Tempo") = dt_JatuhTempo.Value.ToString("yyyy-MM-dd")
                dr("Jumlah_bayar") = txt_jumlahbayar.Text
                dr("Faktur_No") = txt_invoice.Text
                dr("Faktur_Tipe") = txt_fakturtipe.Text
                dr("Faktur_Kembali") = IIf(chkInvoice.Checked = True, "Y", "N")
                If txt_potongan.Text.Trim = "" Then
                    dr("Potongan") = 0
                Else
                    dr("Potongan") = txt_potongan.Text
                End If

                dr("Account_Potongan") = txt_accountpot.Text
                dr("Keterangan") = txt_keterangan.Text
                dt_hdr.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txt_invoice.Text)

            If da IsNot Nothing Then
                da("Project_No") = txt_noPR.Text
                If chk_UangMuka.Checked Then
                    da("Uang_Muka") = "Y"
                Else
                    da("Uang_Muka") = "N"
                End If
                da("Cust_ID") = txt_cusID.Text
                da("Tipe_Pembayaran") = list_pembayaran.SelectedItem
                da("Bank") = txtNamaBank.Text
                da("Tgl_Transfer") = dtTransfer.Value
                da("Account") = txt_account.Text
                da("No_Giro") = txt_nogiro.Text
                da("Jatuh_Tempo") = dt_JatuhTempo.Value.ToString("yyyy-MM-dd")
                da("Jumlah_bayar") = txt_jumlahbayar.Text
                da("Faktur_No") = txt_invoice.Text
                da("Faktur_Tipe") = txt_fakturtipe.Text
                da("Faktur_Kembali") = IIf(chkInvoice.Checked = True, "Y", "N")
                If txt_potongan.Text.Trim = "" Then
                    da("Potongan") = 0
                Else
                    da("Potongan") = txt_potongan.Text
                End If
                da("Account_Potongan") = txt_accountpot.Text
                da("Keterangan") = txt_keterangan.Text
            End If
        End If
        gvPembayaran.DataSource = dt_hdr
        SetGrid_item()
        Status_Proses = "" 'reset
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_insert.Enabled = True
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gvPembayaran.Enabled = dt_hdr.Rows.Count > 0
    End Sub

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim JournalNo As String
        Dim JumlahPiutang As Integer = 0
        Dim dtPiutang As String
        Dim defaultPeriod As String

        dtPiutang = dt_Pelunasan.Value.ToString("yyyyMM")
        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        If dtPiutang <> defaultPeriod Then
            If dtPiutang < defaultPeriod Then
                MessageBox.Show("Tanggal Pelunasan harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            period = dtPiutang
        End If
      
        If txt_NmKolektor.Text = String.Empty Then
            MsgBox("Nama Kolektor belum diisi. Proses Save dibatalkan")
            Exit Sub
        End If

        For Each item As DataRow In dt_hdr.Rows

            If item("Tipe_Pembayaran").ToString = String.Empty Then
                MsgBox("Tipe Pembayaran pada grid belum diisi. Proses Save dibatalkan")
                Exit Sub
            ElseIf item("Account").ToString = String.Empty Then
                MsgBox("Account pada grid belum diisi. Proses Save dibatalkan")
                Exit Sub
            ElseIf item("Uang_Muka").ToString = String.Empty Then
                MsgBox("Uang Muka pada grid belum diisi. Proses Save dibatalkan")
                Exit Sub
            ElseIf item("Tipe_Pembayaran").ToString = "Giro" Then
                If item("no_giro") = "" Then
                    MsgBox("No Giro pada grid belum diisi. Proses Save dibatalkan")
                    Exit Sub
                ElseIf item("jatuh_tempo").ToString = String.Empty Then
                    MsgBox("Jatuh Tempo pada grid belum diisi. Proses Save dibatalkan")
                    Exit Sub
                End If
            ElseIf item("potongan").ToString = String.Empty Then
                MsgBox("Potongan pada grid belum diisi. Proses Save dibatalkan")
                Exit Sub
            ElseIf item("account_potongan").ToString = String.Empty Then
                MsgBox("Account Potongan pada grid belum diisi. Proses Save dibatalkan")
                Exit Sub
            End If

        Next
        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim LastSerial As Integer
        Dim remarks_Stok As String
        Dim COAfaktur As String

        Try

            If txt_DocNo.Text = "" Then

                'For Each item As DataRow In dt_hdr.Rows
                '    Try
                '        dt.Clear()
                '        If Conn.State = ConnectionState.Closed Then
                '            Conn.Open()
                '        End If

                '        Cmd.CommandText = "select faktur_no from trans_pelunasanpiutang_dtl where faktur_no = '" & item("faktur_no") & "'"

                '        DA.SelectCommand = Cmd
                '        DA.Fill(dt)

                '        If dt.Rows.Count > 0 Then
                '            MsgBox("Faktur No  '" & item("faktur_no") & "' Sudah Ada. Proses Save dibatalkan")
                '            Exit Sub
                '        End If


                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '        Conn.Close()
                '    End Try
                'Next

                'If Conn.State = ConnectionState.Closed Then
                '    Conn.Open()
                'End If

                txt_DocNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))



                remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


                Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanPiutangHdr '" & txt_DocNo.Text.Trim & "','" & _
                                             dt_Pelunasan.Value.ToString("yyyy-MM-dd") & "','" & _
                                             txt_emp.Text.Trim & "','" & _
                                             txt_Ket.Text.Trim & "','" & _
                                             period & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                For Each item As DataRow In dt_hdr.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanPiutangDtl '" & txt_DocNo.Text.Trim & "','" & _
                                             item("Project_NO").ToString.Trim & "','" & _
                                             item("Cust_ID").ToString.Trim & "','" & _
                                             item("Uang_Muka").ToString.Trim & "','" & _
                                             item("Tipe_Pembayaran").ToString.Trim & "','" & _
                                             item("Bank").ToString.Trim & "','" & _
                                             item("Tgl_Transfer").ToString.Trim & "','" & _
                                             item("Account").ToString.Trim & "','" & _
                                             item("No_Giro").ToString.Trim & "','" & _
                                             item("Jatuh_Tempo").ToString.Trim & "','" & _
                                             item("Jumlah_Bayar").ToString.Trim & "','" & _
                                             item("Faktur_No").ToString.Trim & "','" & _
                                             item("Faktur_Tipe").ToString.Trim & "','" & _
                                             item("Faktur_Kembali").ToString.Trim & "','" & _
                                             item("Potongan").ToString.Trim & "','" & _
                                             item("Account_Potongan").ToString.Trim & "','" & _
                                             item("Keterangan").ToString.Trim & "','" & _
                                             userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()


                    If item("Tipe_Pembayaran") = "Giro" Then
                        Cmd.CommandText = "EXEC sp_Insert_PencairanGiroPiutang '" & item("no_giro") & "','" & _
                                               "" & "','" & _
                                               dt_Pelunasan.Value.ToString("yyyy-MM-dd") & "','" & _
                                               item("Jatuh_Tempo") & "','" & _
                                               item("Jumlah_Bayar") & "','" & _
                                               txt_DocNo.Text & "','" & _
                                               "Open" & "','" & _
                                               "" & "','" & _
                                               "" & "','" & _
                                               userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If

                Next

                For Each item As DataRow In dt_hdr.Rows
                    JournalNo = Generate_TranNo("Journal")
                    LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))

                    Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                         userlog.EmployeeID & "','" & _
                                        "Piutang" & "','" & txt_Ket.Text & "','" & item("Faktur_No") & "','" & _
                                         "" & "','" & _
                                         "" & "','" & _
                                         "" & "','" & _
                                         "" & "','" & _
                                         userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()



                    JumlahPiutang = CInt(item("jumlah_bayar")) + CInt(item("potongan"))

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                      item("Account") & "'," & item("jumlah_bayar") & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                  item("Account_Potongan") & "'," & item("potongan") & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    If item("faktur_tipe") = "Instalasi" Then
                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                "132" & "'," & "0" & ",'" & JumlahPiutang & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item("faktur_tipe") = "Uang Muka" Then
                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                "131" & "'," & "0" & ",'" & JumlahPiutang & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                "133" & "'," & "0" & ",'" & JumlahPiutang & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If

                    UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                Next
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

                ObjTrans.Commit()
                Conn.Close()

                MsgBox("No Dokumen Pelunasan  " & txt_DocNo.Text.Trim & " Has been Saved")
                FrmPelunasanPiutang_Load(Nothing, Nothing)
            Else

                Cmd.CommandText = "EXEC sp_Update_Trans_PelunasanPiutang_Hdr '" & txt_DocNo.Text.Trim & "','" & _
                                               dt_JatuhTempo.Value.ToString("yyyy-MM-dd") & "','" & _
                                               txt_emp.Text.Trim & "','" & _
                                               txt_Ket.Text.Trim & "','" & _
                                               period & "','" & _
                                               userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                For Each item As DataRow In dt_hdr.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanPiutangDtl '" & txt_DocNo.Text.Trim & "','" & _
                                            item("Project_NO").ToString.Trim & "','" & _
                                            item("Cust_ID").ToString.Trim & "','" & _
                                            item("Uang_Muka").ToString.Trim & "','" & _
                                            item("Tipe_Pembayaran").ToString.Trim & "','" & _
                                            item("Bank").ToString.Trim & "','" & _
                                            item("Tgl_Transfer").ToString.Trim & "','" & _
                                            item("Account").ToString.Trim & "','" & _
                                            item("No_Giro").ToString.Trim & "','" & _
                                            item("Jatuh_Tempo").ToString.Trim & "','" & _
                                            item("Jumlah_Bayar").ToString.Trim & "','" & _
                                            item("Faktur_No").ToString.Trim & "','" & _
                                            item("Faktur_Tipe").ToString.Trim & "','" & _
                                            item("Faktur_Kembali").ToString.Trim & "','" & _
                                            item("Potongan").ToString.Trim & "','" & _
                                            item("Account_Potongan").ToString.Trim & "','" & _
                                            item("Keterangan").ToString.Trim & "','" & _
                                            userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PelunasanHutang_Dtl '" & txt_DocNo.Text + "','" & _
                                       item("TB_NO") & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PelunasanPiutang_Dtl '" & txt_DocNo.Text.Trim & "','" & _
                                             item("Project_NO") & "','" & _
                                             item("Cust_ID") & "','" & _
                                             item("Uang_Muka") & "','" & _
                                             item("Tipe_Pembayaran") & "','" & _
                                              item("Bank") & "','" & _
                                             item("Tgl_Transfer") & "','" & _
                                             item("Account") & "','" & _
                                             item("No_Giro") & "','" & _
                                             item("Jatuh_Tempo") & "','" & _
                                             item("Jumlah_Bayar") & "','" & _
                                             item("Faktur_No") & "','" & _
                                             item("Faktur_Tipe") & "','" & _
                                             item("Faktur_Kembali").ToString.Trim & "','" & _
                                             item("Potongan") & "','" & _
                                             item("Account_Potongan") & "','" & _
                                             item("Keterangan") & "','" & _
                                             userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Update_Journal_Item '" & item("faktur_no") + "','" & _
                                 item("Account_Potongan") & "'," & item("potongan") & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        If item("faktur_tipe") = "Instalasi" Then
                            COAfaktur = "132"
                        ElseIf item("faktur_tipe") = "Uang Muka" Then
                            COAfaktur = "131"
                        Else
                            COAfaktur = "133"
                        End If

                        JumlahPiutang = CInt(item("jumlah_bayar")) + CInt(item("potongan"))

                        Cmd.CommandText = "EXEC sp_Update_Journal_Item '" & item("faktur_no") + "','" & _
                              COAfaktur & "'," & "0" & ",'" & JumlahPiutang & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next
                ObjTrans.Commit()
                Conn.Close()
                MsgBox("No Dokumen Pelunasan  " & txt_DocNo.Text.Trim & " Has been Saved")
                FrmPelunasanPiutang_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txt_emp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_emp.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Employee_ID,name from master_employee a left join master_department b on a.Department_id = b.Department_id", "Employee_ID", "Name", "", "", "")
            txt_emp.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_NmKolektor.Text = frmSearch.txtResult2.Text.ToString.Trim
        ElseIf e.KeyCode = Keys.Enter Then
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "Select Employee_ID,name from master_employee a left join master_department b on a.Department_id = b.Department_id where employee_id = '" & txt_emp.Text & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            If dt.Rows.Count > 0 Then
                txt_emp.Text = dt.Rows(0).Item("employee_id").ToString.Trim
                txt_NmKolektor.Text = dt.Rows(0).Item("name").ToString.Trim
            Else
                MessageBox.Show("Employee ID tidak ditemukan. Pastikan Employee ID yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
           
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_invoice.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        txt_DocNo.Enabled = False 'karna primary Key
        txt_noPR.Enabled = False
        txt_invoice.Enabled = False
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False

        If txt_DocNo.Text <> "" Then
            txt_account.Enabled = False
            txt_accountpot.Enabled = False
            list_pembayaran.Enabled = False
            txt_account.BackColor = Color.DarkGray
            txt_accountpot.BackColor = Color.DarkGray
            list_pembayaran.BackColor = Color.DarkGray
        End If


        If gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Tipe_Pembayaran").Value = "Giro" Then
            txt_nogiro.Enabled = True
            txt_nogiro.BackColor = Color.LemonChiffon
            dt_JatuhTempo.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
        ElseIf gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Tipe_Pembayaran").Value = "Bank" Then
            dtTransfer.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
            txt_account.Clear()
            txt_account.Enabled = True
            txt_account.BackColor = Color.LemonChiffon
            txt_nogiro.BackColor = Color.DarkGray
        Else
            txt_nogiro.Enabled = False
            txt_nogiro.BackColor = Color.DarkGray
            dt_JatuhTempo.Enabled = False
            dtTransfer.Enabled = False
            txtNamaBank.Enabled = False
            txtNamaBank.BackColor = Color.DarkGray
        End If
       
        list_pembayaran.Focus()
    End Sub

    Private Sub gvPembayaran_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvPembayaran.CellMouseClick
        If String.IsNullOrEmpty(gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Faktur_No").Value) = False Then
            list_pembayaran.SelectedItem = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Tipe_Pembayaran").Value.ToString.Trim
            txt_nogiro.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("No_Giro").Value.ToString.Trim
            dt_JatuhTempo.Value = IIf(gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jatuh_Tempo").Value.ToString.Trim = "", Now, gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jatuh_Tempo").Value.ToString.Trim)
            txt_jumlahbayar.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jumlah_Bayar").Value.ToString.Trim
            txt_keterangan.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Keterangan").Value.ToString.Trim
            txt_account.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Account").Value.ToString.Trim
            txt_cusID.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Cust_ID").Value.ToString.Trim
            txt_potongan.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("potongan").Value.ToString.Trim
            txt_invoice.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("faktur_no").Value.ToString.Trim
            txt_fakturtipe.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("faktur_tipe").Value.ToString.Trim
            txt_accountpot.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("account_potongan").Value.ToString.Trim
            txtNamaBank.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("bank").Value.ToString.Trim
            chkInvoice.Checked = IIf(gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Faktur_Kembali").Value.ToString.Trim = "Y", True, False)

            If gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("tgl_transfer").Value.ToString.Trim = "" Then
                dtTransfer.Value = Now
            Else
                dtTransfer.Value = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("tgl_transfer").Value.ToString.Trim
            End If

            Try
                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_GetInvoicePiutangByNo  '" + txt_invoice.Text + "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                txtOutstandingInv.Text = dt.Rows(0).Item("outstanding")


                dt.Clear()
                Cmd.CommandText = "exec sp_GetPRPelunasanPiutangByPRNo  '" + gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Project_No").Value.ToString.Trim + "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                If dt.Rows.Count = 0 Then
                    Dim PRNO As String
                    PRNO = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Project_No").Value.ToString.Trim
                    Cmd.CommandText = "select Project_NO,Nilai_Project as Outstanding,Nilai_Project  from trans_projects where Project_No = '" & PRNO & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt)
                End If

                txt_noPR.Text = dt.Rows(0).Item("Project_NO")
                txt_NilaiPO.Text = dt.Rows(0).Item("Nilai_Project")
                'txt_invoice.Text = dt.Rows(0).Item("Faktur_No")
                txt_Outstanding.Text = dt.Rows(0).Item("Outstanding")

                dt.Clear()
                Cmd.CommandText = "select nama from master_customer where cust_id = '" & txt_cusID.Text & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)
                txt_nmCus.Text = dt.Rows(0).Item("nama")

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try

        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        DisableButton(False)
        Enable_Button_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        ts_New.Enabled = True
        ClearInput()
        txt_DocNo.Clear()

        txt_Ket.Clear()
        txt_noPR.Clear()
        EnableInput(False)
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Faktur_No")
        dt_hdr.PrimaryKey = dc

        If list_pembayaran.SelectedIndex = 0 Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txt_invoice.Text)
            If da IsNot Nothing Then
                da.Delete()

                Dim i As Integer
                Do While Not i = dt_hdr.Rows.Count
                    If dt_hdr.Rows(i).Item("Faktur_No") = txt_invoice.Text Then
                        dt_hdr.Rows.RemoveAt(i)
                    Else
                        i += 1
                    End If

                Loop
                dt_hdr.AcceptChanges()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gvPembayaran.Focus()
            End If
        End If
    End Sub

    Private Sub txt_account_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_account.KeyDown
        If list_pembayaran.SelectedIndex = 0 Then
            MessageBox.Show("Please Choose Tipe Pembayaran", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select account_id,account_name from master_COA where Group_PayAccount = '" & list_pembayaran.SelectedItem & "'", "Account_ID", "Account_Name", "", "", "")
            txt_account.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub ts_Edit_Click(sender As Object, e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
    End Sub

    Private Sub txt_invoice_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_invoice.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("exec sp_GetInvoicePiutangOutstanding", "faktur_no", "jumlah_uang", "faktur_tipe", "jumlah_bayar", "Outstanding")
            txt_invoice.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_jumlahbayar.Text = frmSearch.txtResult2.Text.ToString.Trim
            txt_fakturtipe.Text = frmSearch.txtResult3.Text.ToString.Trim
            txtOutstandingInv.Text = frmSearch.txtResult5.Text.ToString.Trim
            Try
                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_GetPRPelunasanPiutang '" & txt_invoice.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)


                txt_noPR.Text = dt.Rows(0).Item("Project_no")
                txt_NilaiPO.Text = dt.Rows(0).Item("Nilai_Project")
                txt_Outstanding.Text = dt.Rows(0).Item("Outstanding")

                dt.Clear()
              
                Cmd.CommandText = "select c.cust_ID,c.nama from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no left join master_customer c on b.cust_id = c.cust_id where project_no = '" & txt_noPR.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)

                txt_cusID.Text = dt.Rows(0).Item("Cust_ID")
                txt_nmCus.Text = dt.Rows(0).Item("Nama")


                Conn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                Cmd.CommandText = "select faktur_no,faktur_tipe,jumlah_uang from trans_invoice_piutang where faktur_no not in (select isnull(faktur_no,'') from trans_pelunasanpiutang_dtl) and faktur_no =  '" & txt_invoice.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                If dt.Rows.Count > 0 Then
                    txt_invoice.Text = dt.Rows(0).Item("faktur_no").ToString.Trim
                    txt_jumlahbayar.Text = dt.Rows(0).Item("jumlah_uang").ToString.Trim
                    txt_fakturtipe.Text = dt.Rows(0).Item("faktur_tipe").ToString.Trim
                Else
                    MessageBox.Show("No Invoice tidak ditemukan. Pastikan Invoice yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_GetPRPelunasanPiutang '" & txt_invoice.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)


                txt_noPR.Text = dt.Rows(0).Item("Project_no")
                txt_NilaiPO.Text = dt.Rows(0).Item("Nilai_Project")
                txt_Outstanding.Text = dt.Rows(0).Item("Outstanding")

                dt.Clear()

                Cmd.CommandText = "select c.cust_ID,c.nama from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no left join master_customer c on b.cust_id = c.cust_id where project_no = '" & txt_noPR.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)

                txt_cusID.Text = dt.Rows(0).Item("Cust_ID")
                txt_nmCus.Text = dt.Rows(0).Item("Nama")


                Conn.Close()
               
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
    End Sub

    Private Sub txt_jumlahbayar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_jumlahbayar.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_potongan_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_potongan.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_accountpot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_accountpot.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select account_id,account_name from master_COA where Group_PayAccount = 'Biaya'", "Account_ID", "Account_Name", "", "", "")
            txt_accountpot.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub
    Private Sub SetDetailPiutang()
      
    End Sub
    Private Sub txtnoDPP_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtnoDPP.KeyDown
        Dim i As Integer = 0

        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select DPP_NO from trans_daftarpembayaranpiutang_hdr", "DPP_No", "", "", "", "")
            txtnoDPP.Text = frmSearch.txtResult1.Text.ToString.Trim
        ElseIf e.KeyCode = Keys.Enter Then
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "select DPP_NO from trans_daftarpembayaranpiutang_hdr where DPP_NO =  '" & txtnoDPP.Text & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            If dt.Rows.Count > 0 Then
                txtnoDPP.Text = dt.Rows(0).Item("dpp_no")
            Else
                MessageBox.Show("No DPP tidak ditemukan. Pastikan DPP yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If


        If txtnoDPP.Text <> String.Empty Then
            Try
                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "select * from trans_daftarpembayaranpiutang_dtl where DPP_NO = '" & txtnoDPP.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt)

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try

            Dim dtP As New DataTable
            Dim drP As DataRow

            With dtP.Columns
                .Add("Faktur_No")
                .Add("Faktur_Tipe")
                .Add("Project_No")
                .Add("Cust_ID")
                .Add("Uang_Muka")
                .Add("Tipe_Pembayaran")
                .Add("Bank")
                .Add("Tgl_Transfer")
                .Add("Account")
                .Add("No_Giro")
                .Add("Jatuh_Tempo")
                .Add("Jumlah_Bayar")
                .Add("Potongan")
                .Add("Account_Potongan")
                .Add("Keterangan")
            End With

            While i < dt.Rows.Count
                drP = dtP.NewRow
                With drP
                    .Item("Faktur_No") = dt.Rows(i).Item("Faktur_No")
                    .Item("Faktur_Tipe") = dt.Rows(i).Item("Faktur_Tipe")
                    .Item("Project_No") = dt.Rows(i).Item("Project_No")
                    .Item("Cust_ID") = dt.Rows(i).Item("Cust_ID")
                    .Item("Uang_Muka") = ""
                    .Item("Tipe_Pembayaran") = ""
                    .Item("Bank") = ""
                    .Item("Tgl_Transfer") = ""
                    .Item("Account") = ""
                    .Item("No_Giro") = ""
                    .Item("Jatuh_Tempo") = ""
                    .Item("Jumlah_Bayar") = dt.Rows(i).Item("Jumlah_Nominal")
                    .Item("Potongan") = ""
                    .Item("Account_Potongan") = ""
                    .Item("Keterangan") = ""
                End With
                dtP.Rows.Add(drP)
                i = i + 1
            End While
            dt_hdr = dtP
            gvPembayaran.DataSource = dt_hdr
        End If
    End Sub
End Class