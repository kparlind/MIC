Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmPelunasanHutangSupplier

    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim period As String = ""
    Dim CurrDate As String
    Private Sub FrmPelunasanHutangSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            gvPembayaran.Enabled = False
            gvPembayaran.ReadOnly = True
            btn_insert.Enabled = False
            EnableInput(False)
            Enable_Button_Wa(False)

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
            EnableInput(True)
            Enable_Button_Wa(True)
            DisableButton(False)
            ts_save.Enabled = True
            ts_cancel.Enabled = True
            gvPembayaran.Enabled = True
            gvPembayaran.ReadOnly = False
        End If
        SetGrid_item()
        txt_account.BackColor = Color.DarkGray
    End Sub

    Private Sub ClearInput()
        'txt_TransNo.Clear()
        'txt_NmSupplier.Clear()

        dt_Pelunasan.Value = Now
        txt_Ket.Clear()
        gvPembayaran.DataSource = ""

    End Sub

    Private Sub SetGrid_item()
        If gvPembayaran.Rows.Count > 0 Then
            gvPembayaran.Columns(9).DefaultCellStyle.Format = "#,##0.#0"
            gvPembayaran.Columns(10).DefaultCellStyle.Format = "#,##0.#0"
        End If
    End Sub

    Private Sub LoadPembayaranViaBank(ByVal No As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC sp_Retreive_Trans_PelunasanViaBank '" + No + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvPembayaran.DataSource = dt_hdr
            gvPembayaran.Enabled = dt_hdr.Rows.Count > 0

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub EnableInput(ByVal boo As Boolean)
        txt_kdSupplier.Enabled = boo
        dt_Pelunasan.Enabled = boo
        txt_NmSupplier.Enabled = boo
        txt_Ket.Enabled = boo
        txtDPHNo.Enabled = boo
    End Sub
    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            list_pembayaran.BackColor = Color.DarkGray
            txt_nogiro.BackColor = Color.DarkGray
            txt_jumlahbayar.BackColor = Color.DarkGray
            txt_keterangan.BackColor = Color.DarkGray
            dt_JatuhTempo.BackColor = Color.DarkGray
            txt_noPO.BackColor = Color.DarkGray
            txt_account.BackColor = Color.DarkGray
            txtaccountpot.BackColor = Color.DarkGray
            txtpot.BackColor = Color.DarkGray
            txtNoRetur.BackColor = Color.DarkGray

        ElseIf proses = "UPDATE" Then
            list_pembayaran.BackColor = Color.LemonChiffon
            txt_nogiro.BackColor = Color.LemonChiffon
            txt_jumlahbayar.BackColor = Color.LemonChiffon
            txt_keterangan.BackColor = Color.LemonChiffon
            dt_JatuhTempo.BackColor = Color.LemonChiffon
            txt_noPO.BackColor = Color.LemonChiffon
            txt_account.BackColor = Color.LemonChiffon
            txtaccountpot.BackColor = Color.LemonChiffon
            txtpot.BackColor = Color.LemonChiffon
            txtNoRetur.BackColor = Color.White
            If chk_UangMuka.Checked = True Then
                txtaccountpot.BackColor = Color.DarkGray
                txtpot.BackColor = Color.DarkGray
            End If
        ElseIf proses = "INSERT" Then
            list_pembayaran.BackColor = Color.LemonChiffon
            txt_jumlahbayar.BackColor = Color.LemonChiffon
            txt_keterangan.BackColor = Color.LemonChiffon
            dt_JatuhTempo.BackColor = Color.LemonChiffon
            txt_noPO.BackColor = Color.LemonChiffon
            txt_account.BackColor = Color.LemonChiffon
            txtaccountpot.BackColor = Color.LemonChiffon
            txtpot.BackColor = Color.LemonChiffon
            txtNoRetur.BackColor = Color.White
            If chk_UangMuka.Checked = True Then
                txtaccountpot.BackColor = Color.DarkGray
                txtpot.BackColor = Color.DarkGray
            End If
        End If
    End Sub

    Private Sub txt_kdSupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_kdSupplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Supp_ID, Nama , Contact_Person from Master_Supplier", "Supp_ID", "Nama", "Contact_Person", "", "")
            txt_kdSupplier.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_NmSupplier.Text = frmSearch.txtResult2.Text.ToString.Trim
            txt_Ket.Text = frmSearch.txtResult3.Text.ToString.Trim
        End If
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        list_pembayaran.Enabled = boo
        txt_jumlahbayar.Enabled = boo
        txt_keterangan.Enabled = boo
        dt_JatuhTempo.Enabled = boo
        txt_account.Enabled = boo
        txt_noPO.Enabled = boo
        txt_account.Enabled = boo
        txtNoRetur.Enabled = boo
        txtNoRetur.Enabled = boo
        txtaccountpot.Enabled = boo
        txtpot.Enabled = boo

        If chk_UangMuka.Checked = True Then
            txtaccountpot.Enabled = False
            txtpot.Enabled = False
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
        txt_totalretur.Clear()
        txt_sj.Clear()
        txt_noPO.Clear()
        chk_UangMuka.Checked = False
        dt_JatuhTempo.Value = Now
        txtaccountpot.Clear()
        dtTransfer.Value = Now
        txtpot.Clear()
        txtNamaBank.Clear()
        txtNoRetur.Clear()
        txt_totalretur.Clear()
    End Sub

   

    Private Sub ts_New_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_New.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
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

    Private Sub gvPembayaran_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvPembayaran.CellMouseClick
        If String.IsNullOrEmpty(gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Doc_No").Value) = False Then
            list_pembayaran.SelectedItem = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Tipe_Pembayaran").Value.ToString.Trim
            txt_nogiro.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("No_Giro").Value.ToString.Trim

            If gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jatuh_Tempo").Value.ToString.Trim = "" Then
                dt_JatuhTempo.Value = Now
            Else
                dt_JatuhTempo.Value = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jatuh_Tempo").Value.ToString.Trim()
            End If

            txt_jumlahbayar.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Jumlah_Bayar").Value.ToString.Trim
            txt_keterangan.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Keterangan").Value.ToString.Trim
            txt_account.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Account").Value.ToString.Trim
            chk_UangMuka.Checked = IIf(gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Uang_Muka").Value.ToString.Trim = "Y", True, False)
            txtNoRetur.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Retur_No").Value.ToString.Trim
            ' txt_totalretur.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Nilai_Retur").Value.ToString.Trim
            txtaccountpot.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Account_Potongan").Value.ToString.Trim
            txtpot.Text = gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Potongan").Value.ToString.Trim
            Try
                dt.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                If gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Doc_No").Value.ToString.Substring(0, 2) = "PO" Then
                    Cmd.CommandText = "exec sp_GetPOPelunasanHutangByPONo '" + gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Doc_No").Value.ToString.Trim + "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt)
                    txt_noPO.Text = dt.Rows(0).Item("PO_NO")
                    txt_NilaiPO.Text = dt.Rows(0).Item("Grand_Total")
                    txt_Outstanding.Text = dt.Rows(0).Item("Grand_Total")
                Else
                    Cmd.CommandText = "exec sp_GetTBPelunasanHutangByTBNo '" + gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Doc_No").Value.ToString.Trim + "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt)

                    txt_noPO.Text = dt.Rows(0).Item("TB_NO")
                    txt_NilaiPO.Text = dt.Rows(0).Item("Grand_Total")
                    txt_sj.Text = dt.Rows(0).Item("SuratJalan_No")
                    txt_invoice.Text = dt.Rows(0).Item("Faktur_No")

                    txt_Outstanding.Text = dt.Rows(0).Item("Outstanding")
                End If

                txt_account.BackColor = Color.DarkGray
                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try

        End If
    End Sub
    Private Function GetUangMuka(ByVal tbno As String) As Double
        Dim dt As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "Select dp from trans_terimabrg_hdr where tb_no = '" + tbno + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("dp")
            Else
                Return 0
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GetNilaiRetur(ByVal returno As String) As Double
        Dim dt As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "select SUM(amount) as nilai_retur from trans_retur_dtl where retur_no =  '" + returno + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("nilai_retur")
            Else
                Return 0
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_save.Click
        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        Dim JournalNo As String
        Dim LastSerial As Integer
        Dim remarks_Stok As String
        Dim jumlahbayar As Double
        Dim uangmuka As Double
        Dim nilairetur As Double

        Dim dtHutang As String
        Dim defaultPeriod As String

        dtHutang = dt_Pelunasan.Value.ToString("yyyyMM")
        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans
      

        If dtHutang <> defaultPeriod Then
            If dtHutang < defaultPeriod Then
                MessageBox.Show("Tanggal Pelunasan harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            period = dtHutang
        End If

        Try
            If txt_DocNo.Text = "" Then

                JournalNo = Generate_TranNo("Journal")
                LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))

                txt_DocNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))
                remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


                Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanViaBankHdr '" & txt_DocNo.Text.Trim & "','" & _
                                             txtDPHNo.Text & "','" & _
                                             dt_JatuhTempo.Value.ToString("yyyy-MM-dd") & "','" & _
                                             txt_kdSupplier.Text.Trim & "','" & _
                                             txt_Ket.Text.Trim & "','" & _
                                             period & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                For Each item As DataRow In dt_hdr.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanViaBank '" & txt_DocNo.Text.Trim & "','" & _
                                             item("Doc_NO") & "','" & _
                                             item("Retur_NO") & "','" & _
                                             item("Uang_Muka") & "','" & _
                                             item("Tipe_Pembayaran") & "','" & _
                                             item("Bank") & "','" & _
                                             item("Tgl_Transfer") & "','" & _
                                             item("Account") & "','" & _
                                             item("No_Giro") & "','" & _
                                             item("Jatuh_Tempo") & "','" & _
                                             item("Jumlah_Bayar") & "','" & _
                                             item("Potongan") & "','" & _
                                             item("Account_Potongan") & "','" & _
                                             item("Keterangan") & "','" & _
                                             userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    If item("Tipe_Pembayaran") = "Giro" Then
                        Cmd.CommandText = "EXEC sp_Insert_PencairanGiro '" & item("no_giro") & "','" & _
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



                    Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                    userlog.EmployeeID & "','" & _
                                   "Hutang" & "','" & txt_Ket.Text & "','" & item("Doc_No") & "','" & _
                                    "" & "','" & _
                                    "" & "','" & _
                                    "" & "','" & _
                                    "" & "','" & _
                                    userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    If item("Uang_Muka") = "N" Then
                        uangmuka = GetUangMuka(item("Doc_NO"))
                        jumlahbayar = CDbl(item("Jumlah_Bayar")) + uangmuka
                        If item("Retur_No") <> "" Then
                            nilairetur = GetNilaiRetur(item("retur_no"))
                            jumlahbayar = jumlahbayar + nilairetur
                        End If
                        jumlahbayar = jumlahbayar + CDbl(item("Potongan"))


                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                            "320" & "'," & jumlahbayar & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()


                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                                              item("Account_Potongan") & "'," & "0" & ",'" & item("Potongan") & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                     

                        If item("Retur_No") <> "" Then
                            Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                                    "135" & "'," & "0" & ",'" & nilairetur & "','" & "" & "','" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                      

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                        "150" & "'," & "0" & ",'" & uangmuka & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()



                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                        item("account") & "'," & "0" & ",'" & item("jumlah_bayar") & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        jumlahbayar = CDbl(item("Jumlah_Bayar"))

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                                                   "150" & "'," & jumlahbayar & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                             item("account") & "'," & "0" & ",'" & jumlahbayar & "','" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next

                'For Each item As DataRow In dt_dtl.Rows
                '    Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim + "','" & _
                '                      item("Item_ID") & "','" & item("ItemDetail_ID") & "'," & item("Qty_STDR") & "," & _
                '                      item("Qty_Order")
                '    Cmd.ExecuteNonQuery()
                'Next
                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                ObjTrans.Commit()
                Conn.Close()

                MsgBox("No Dokumen Pelunasan  " & txt_DocNo.Text.Trim & " Has been Saved")
                FrmPelunasanHutangSupplier_Load(Nothing, Nothing)
            Else

                Cmd.CommandText = "EXEC sp_Update_Trans_PelunasanHutang_Hdr '" & txt_DocNo.Text.Trim & "','" & _
                                          txtDPHNo.Text & "','" & _
                                          dt_JatuhTempo.Value.ToString("yyyy-MM-dd") & "','" & _
                                          txt_kdSupplier.Text.Trim & "','" & _
                                          txt_keterangan.Text.Trim & "','" & _
                                          period & "','" & _
                                          userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                For Each item As DataRow In dt_hdr.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanViaBank '" & txt_DocNo.Text.Trim & "','" & _
                                                     item("Doc_NO") & "','" & _
                                                     item("Retur_NO") & "','" & _
                                                     item("Uang_Muka") & "','" & _
                                                     item("Tipe_Pembayaran") & "','" & _
                                                     item("Bank") & "','" & _
                                                     item("Tgl_Transfer") & "','" & _
                                                     item("Account") & "','" & _
                                                     item("No_Giro") & "','" & _
                                                     item("Jatuh_Tempo") & "','" & _
                                                     item("Jumlah_Bayar") & "','" & _
                                                     item("Potongan") & "','" & _
                                                     item("Account_Potongan") & "','" & _
                                                     item("Keterangan") & "','" & _
                                                     userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PelunasanHutang_Dtl '" & txt_DocNo.Text + "','" & _
                                       item("Doc_NO", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PelunasanHutang_Dtl '" & txt_DocNo.Text.Trim & "','" & _
                                             item("Doc_NO") & "','" & _
                                             item("Retur_NO") & "','" & _
                                             item("Uang_Muka") & "','" & _
                                             item("Tipe_Pembayaran") & "','" & _
                                             item("Bank") & "','" & _
                                             item("Tgl_Transfer") & "','" & _
                                             item("Account") & "','" & _
                                             item("No_Giro") & "','" & _
                                             item("Jatuh_Tempo") & "','" & _
                                             item("Jumlah_Bayar") & "','" & _
                                             item("Potongan") & "','" & _
                                             item("Account_Potongan") & "','" & _
                                             item("Keterangan") & "','" & _
                                             userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                    End If

                Next
                ObjTrans.Commit()
                Conn.Close()
                MsgBox("No Dokumen Pelunasan  " & txt_DocNo.Text.Trim & " Has been Saved")
                'FrmPelunasanHutangSupplier_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txt_noPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_noPO.KeyDown
        If e.KeyCode = Keys.F1 Then
            If txt_kdSupplier.Text = "" Then
                MsgBox("Kode Supplier tidak boleh kosong")
                Exit Sub
            End If
            If chk_UangMuka.Checked Then
                CallandGetSearchData("exec sp_GetPOPelunasanUangMuka '" + txt_kdSupplier.Text + "'", "PO_NO", "Grand_Total", "", "", "")
                txt_noPO.Text = frmSearch.txtResult1.Text.ToString.Trim
                txt_NilaiPO.Text = frmSearch.txtResult2.Text.ToString.Trim
                txt_Outstanding.Text = frmSearch.txtResult2.Text.ToString.Trim
            Else
                CallandGetSearchData("exec sp_GetPOPelunasanHutang '" + txt_kdSupplier.Text + "'", "TB_NO", "Grand_Total", "SuratJalan_No", "Faktur_No", "Outstanding")
                txt_noPO.Text = frmSearch.txtResult1.Text.ToString.Trim
                txt_NilaiPO.Text = frmSearch.txtResult2.Text.ToString.Trim
                txt_sj.Text = frmSearch.txtResult3.Text.ToString.Trim
                txt_invoice.Text = frmSearch.txtResult4.Text.ToString.Trim
                txt_totalretur.Text = 0
                txt_Outstanding.Text = frmSearch.txtResult5.Text.ToString.Trim
            End If
        End If
    End Sub

    Private Sub btn_insert_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"
        Enable_Wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_noPO.Focus()
    End Sub

    Private Sub list_pembayaran_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles list_pembayaran.SelectedIndexChanged
        If list_pembayaran.SelectedIndex = 3 And Status_Proses <> "" Then
            txt_nogiro.Enabled = True
            txt_nogiro.BackColor = Color.LemonChiffon
            dt_JatuhTempo.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
            txt_account.Clear()
            txt_account.Enabled = True
            txt_account.BackColor = Color.LemonChiffon
        ElseIf list_pembayaran.SelectedIndex = 2 And Status_Proses <> "" Then
            dtTransfer.Enabled = True
            txtNamaBank.Enabled = True
            txtNamaBank.BackColor = Color.LemonChiffon
            txt_account.Clear()
            txt_account.Enabled = True
            txt_account.BackColor = Color.LemonChiffon
            txt_nogiro.Enabled = False
            txt_nogiro.BackColor = Color.DarkGray
        Else
            txt_nogiro.Clear()
            txt_nogiro.Enabled = False
            txt_nogiro.BackColor = Color.DarkGray
            dt_JatuhTempo.Enabled = False
            dtTransfer.Enabled = False
            txtNamaBank.Enabled = False
            txtNamaBank.BackColor = Color.DarkGray
            txt_account.Clear()
            txt_account.Enabled = True
            txt_account.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub btn_edit_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_noPO.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        txt_DocNo.Enabled = False 'karna primary Key
        txt_noPO.Enabled = False
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False

        If gvPembayaran.Rows(gvPembayaran.CurrentCell.RowIndex).Cells("Tipe_Pembayaran").Value = "BG" Then
            txt_nogiro.Enabled = True
            txt_nogiro.BackColor = Color.LemonChiffon
            dt_JatuhTempo.Enabled = True

        Else
            txt_nogiro.Enabled = False
            txt_nogiro.BackColor = Color.DarkGray
            dt_JatuhTempo.Enabled = False
        End If

        list_pembayaran.Focus()
    End Sub

    Private Sub btn_save_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Doc_NO")
        dt_hdr.PrimaryKey = dc
        Dim jumlahbayar As Double


        ' Validation
        If list_pembayaran.SelectedIndex = 0 Then
            MessageBox.Show("Tipe Pembayaran harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txt_Outstanding.Text = "" Then
            MessageBox.Show("Nilai Outstanding harus ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        jumlahbayar = txt_jumlahbayar.Text

        If txt_totalretur.Text <> "" Then
            jumlahbayar = jumlahbayar + CDbl(txt_totalretur.Text) + txtpot.Text
        End If


        If CInt(txt_jumlahbayar.Text) > CInt(txt_Outstanding.Text) Then
            MessageBox.Show("Jumlah bayar tidak boleh lebih besar dari outstanding", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txt_account.Text = String.Empty Then
            MessageBox.Show("Account harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If chk_UangMuka.Checked = False Then
        '    If txtaccountpot.Text = String.Empty Then
        '        MessageBox.Show("Account Potongan harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '        Exit Sub
        '    End If

        '    If txtpot.Text = String.Empty Then
        '        MessageBox.Show("Potongan harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '        Exit Sub
        '    End If
        'End If


        If list_pembayaran.SelectedIndex = 3 Then
            If txt_nogiro.Text = String.Empty Then
                MessageBox.Show("Nomor Giro harus diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If



        If Status_Proses = "Insert" Then
            Dim dr As DataRow
            da = dt_hdr.Rows.Find(txt_noPO.Text)
            If da IsNot Nothing Then
                MessageBox.Show("No PO sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                dr = dt_hdr.NewRow
                dr("Doc_No") = txt_noPO.Text
                If chk_UangMuka.Checked Then
                    dr("Uang_Muka") = "Y"
                Else
                    dr("Uang_Muka") = "N"
                End If
                dr("Tipe_Pembayaran") = list_pembayaran.SelectedItem
                dr("Retur_No") = txtNoRetur.Text
                dr("Account_Potongan") = txtaccountpot.Text
                dr("Potongan") = IIf(txtpot.Text = "", 0, txtpot.Text)
                dr("Bank") = txtNamaBank.Text
                dr("Tgl_Transfer") = dtTransfer.Value.ToString("yyyy-MM-dd")
                dr("Account") = txt_account.Text
                dr("No_Giro") = txt_nogiro.Text
                dr("Jatuh_Tempo") = dt_JatuhTempo.Value.ToString("yyyy-MM-dd")
                dr("Jumlah_bayar") = txt_jumlahbayar.Text
                dr("Keterangan") = txt_keterangan.Text
                dt_hdr.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txt_noPO.Text)

            If da IsNot Nothing Then
                da("Doc_No") = txt_noPO.Text
                If chk_UangMuka.Checked Then
                    da("Uang_Muka") = "Y"
                Else
                    da("Uang_Muka") = "N"
                End If
                da("Tipe_Pembayaran") = list_pembayaran.SelectedItem
                da("Retur_No") = txtNoRetur.Text
                da("Account_Potongan") = txtaccountpot.Text
                da("Potongan") = IIf(txtpot.Text = "", 0, txtpot.Text)
                da("Bank") = txtNamaBank.Text
                da("Tgl_Transfer") = dtTransfer.Value.ToString("yyyy-MM-dd")
                da("Account") = txt_account.Text
                da("No_Giro") = txt_nogiro.Text
                da("Jatuh_Tempo") = dt_JatuhTempo.Value.ToString("yyyy-MM-dd")
                da("Jumlah_bayar") = txt_jumlahbayar.Text
                da("Keterangan") = txt_keterangan.Text
            End If
        End If
        gvPembayaran.DataSource = dt_hdr
        SetGrid_item()
        Status_Proses = "" 'reset
        Btn_cancel_Click1(Nothing, Nothing)
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_jumlahbayar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_jumlahbayar.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Doc_No")
        dt_hdr.PrimaryKey = dc

        If list_pembayaran.SelectedIndex = 0 Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txt_noPO.Text)
            If da IsNot Nothing Then
                da.Delete()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gvPembayaran.Focus()
            End If
        End If
    End Sub

    Private Sub Btn_cancel_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_insert.Enabled = True
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gvPembayaran.Enabled = dt_hdr.Rows.Count > 0
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        'DisableButton(False)
        'Enable_Button_Wa(False)
        'Clear_Wa()
        'SetBackColor_Wa("READ")
        'ts_New.Enabled = True
        'ClearInput()
        'txt_DocNo.Clear()
        'txt_kdSupplier.Clear()
        'txt_NmSupplier.Clear()
        'txt_Ket.Clear()
        'txt_noPO.Clear()
        'EnableInput(False)

        DisableButton(False)
        Enable_Button_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        ts_New.Enabled = True
        ClearInput()
        txt_DocNo.Clear()

        txt_Ket.Clear()
        txt_noPO.Clear()
        EnableInput(False)
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        gvPembayaran.Enabled = True
        gvPembayaran.ReadOnly = False
    End Sub


    Private Sub txt_account_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_account.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            If list_pembayaran.Text.ToUpper.Trim = "GIRO" Or list_pembayaran.Text.ToUpper.Trim = "BANK" Then
                sql = "select account_id,account_name from master_COA where Group_PayAccount = 'Bank' and Active_Flag = 'Y'"
            Else
                sql = "select account_id,account_name from master_COA where Group_PayAccount = 'Cash' and Active_Flag = 'Y'"
            End If

            CallandGetSearchData(sql, "Account_id", "Account_name", "", "", "")
            txt_account.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub txtDPHNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDPHNo.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select DPH_NO from trans_daftarpembayaranhutang_hdr", "DPH_No", "", "", "", "")
            txtDPHNo.Text = frmSearch.txtResult1.Text.ToString.Trim

            If txtDPHNo.Text <> String.Empty Then
                Try
                    dt.Clear()
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    Cmd.CommandText = "select * from trans_daftarpembayaranhutang_dtl where DPH_NO = '" & txtDPHNo.Text & "'"

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
                    .Add("Doc_No")
                    .Add("Retur_No")
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
                        .Item("Doc_no") = dt.Rows(i).Item("BST_No")
                        .Item("Retur_No") = ""
                        .Item("Uang_Muka") = "N"
                        .Item("Tipe_Pembayaran") = ""
                        .Item("Bank") = ""
                        .Item("Tgl_Transfer") = ""
                        .Item("Account") = ""
                        .Item("No_Giro") = ""
                        .Item("Jatuh_Tempo") = ""
                        .Item("Jumlah_Bayar") = ""
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
        End If
    End Sub


    Private Sub txtaccountpot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtaccountpot.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select account_id,account_name from master_COA", "Account_id", "Account_name", "", "", "")
            txtaccountpot.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub txtNoRetur_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoRetur.KeyDown
        If e.KeyCode = Keys.F1 Then

            CallandGetSearchData("select Retur_No,sum(Amount) as NilaiRetur from trans_retur_dtl group by retur_no", "Retur_No", "NilaiRetur", "", "", "")
            txtNoRetur.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_totalretur.Text = frmSearch.txtResult2.Text.ToString.Trim
        End If
    End Sub

    Private Sub chk_UangMuka_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_UangMuka.CheckedChanged
        If chk_UangMuka.Checked = True Then
            If txt_noPO.Text <> "" Then

            End If
        End If
    End Sub

    Private Sub txtpot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpot.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class