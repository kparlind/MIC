Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmTransFinance
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt_item As New DataTable
    Dim dr_item As DataRow
    Dim id_login As String
    Dim Status_Proses As String
    Dim CurrDate As String
    Dim period As String = ""
    Dim dtFinance As String

#Region "Interface"
    Private Sub FrmTransFinance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
       
        ClearInput()
        Clear_Wa()
        Enable_WaAuto(False)
        btnsave.Enabled = False
        btnedit.Enabled = False


        cmbFinance.Enabled = False
        gv_finance.AllowUserToAddRows = False
        rdBiasa.Checked = True

        txtPeriod.Enabled = False
        Load_Detail()
        CalculateDebitCredit()
        SetBackColor_Wa("READ")
        SetGrid_item()

        If txt_TransNo.Text.ToString.Trim <> "" Then 'Jika dipanggil dari View Penerimaan Barang
            Load_Finance()

            'id_status = txt_StatusID.Text.Trim

            If True Then
                Enable_Wa(False)
                EnableInput(False)
                DisableButton(False)
                Enable_Button_Wa(False)
                gv_finance.Enabled = True
                rdBiasa.Enabled = False
                rdOtomatis.Enabled = True
                Enable_WaAuto(False)
                cmbFinance.Enabled = False
                SetBackColor_WaAuto("READ")
                btnsave.Enabled = False
                btnedit.Enabled = False

                ts_Edit.Enabled = True
                btn_insert.Enabled = False
                gv_finance.Enabled = True
            Else
                Enable_Wa(False)
                EnableInput(False)
                DisableButton(False)
                Enable_Button_Wa(False)
                gv_finance.Enabled = True
                ' txt_KodeCoa.Enabled = False

            End If
            CurrDate = GetCurrDate.ToString.Substring(0, 10)
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                Enable_Wa(False)
                EnableInput(False)
                DisableButton(False)
                Enable_Button_Wa(False)
                rdBiasa.Enabled = False
                rdOtomatis.Enabled = True
                Enable_WaAuto(False)
                cmbFinance.Enabled = False
                SetBackColor_WaAuto("READ")
                btnsave.Enabled = False
                btnedit.Enabled = False
                ts_Edit.Enabled = False
                btn_insert.Enabled = False
                gv_finance.Enabled = False
                gv_finance.ReadOnly = True
            End If
        Else
            txtPeriod.Text = GetPeriod()
            ts_Edit.Enabled = False
        End If
    End Sub


    Private Sub SetGrid_item()
        If gv_finance.Rows.Count > 0 Then
            gv_finance.Columns(2).DefaultCellStyle.Format = "#,##0.#0"
            gv_finance.Columns(3).DefaultCellStyle.Format = "#,##0.#0"
        End If
    End Sub

    Private Sub Enable_Button_Wa(ByVal boo As Boolean)
        btn_insert.Enabled = boo
        btn_edit.Enabled = boo
        btn_save.Enabled = boo
        btn_delete.Enabled = boo
        Btn_cancel.Enabled = boo
    End Sub

    Private Sub ClearInput()
        'txt_TransNo.Clear()
        txt_remarks.Clear()
        txtNamaBank.Clear()
        txtNoGiro.Clear()
        gv_finance.DataSource = ""
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        dt_finance.Enabled = boo
        txt_remarks.Enabled = boo
        gv_finance.Enabled = boo
        txtNamaBank.Enabled = boo
        txtNoGiro.Enabled = boo
        'txtPeriod.Enabled = boo
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo
        ts_FindPO.Enabled = Not boo
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_KodeCoa.Enabled = boo
        txt_Harga.Enabled = boo
        txt_Ket.Enabled = boo
        cb_DebitKredit.Enabled = boo

    End Sub
    Private Sub Enable_WaAuto(ByVal boo As Boolean)
        txtkdCOA.Enabled = boo
        txtHarga.Enabled = boo
        txtket.Enabled = boo
        cmbTipe.Enabled = boo

    End Sub
    Private Sub Clear_Wa()
        txt_KodeCoa.Clear()
        txt_NamaCoa.Clear()
        txt_Harga.Clear()
        txt_Ket.Clear()
        cb_DebitKredit.Text = ""
    End Sub
    Private Sub Clear_WaAuto()
        txtkdCOA.Clear()
        txtNamaCOA.Clear()
        txtHarga.Clear()
        txtket.Clear()
        cmbTipe.Text = ""


    End Sub
#End Region

#Region "Main Button"
    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        'DisableButton(False)
        'Enable_Button_Wa(False)
        Clear_Wa()
        Clear_WaAuto()
        SetBackColor_Wa("READ")

        ' ts_New.Enabled = True
        ClearInput()
        'EnableInput(False)
        'Enable_WaAuto(False)
        SetBackColor_WaAuto("READ")
        lbldebit.Text = 0
        lblkredit.Text = 0
        rdBiasa.Enabled = True
        rdOtomatis.Enabled = True

        rdBiasa.Checked = True

        gv_finance.DataSource = ""
        dt_item.Clear()



        'cmbFinance.Enabled = False

        'btnsave.Enabled = False
        'btnedit.Enabled = False
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        rdBiasa.Enabled = True
        rdOtomatis.Enabled = True
        cmbFinance.Enabled = True

        gv_finance.Enabled = True
        If txt_TransNo.Text = "" Then
            ts_cancel.Enabled = True
        Else
            ts_cancel.Enabled = False
        End If
    End Sub
#End Region

#Region "Proses"
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
    Private Sub Load_Finance()

        'Dim perioddate As Date

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            'Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retreive_trans_Finance_Hdr '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            If dt_hdr.Rows.Count > 0 Then
                dt_finance.Value = dt_hdr.Rows(0).Item("Finance_Date")
                txt_remarks.Text = dt_hdr.Rows(0).Item("Remarks").ToString.Trim
                txtPeriod.Text = dt_hdr.Rows(0).Item("Period").ToString
                'perioddate = period.Substring(4, 2) + "/" + "01" + "/" + period.Substring(0, 4)
                'dtPeriod.Value = perioddate
                txtNamaBank.Text = dt_hdr.Rows(0).Item("NamaBank").ToString
                txtNoGiro.Text = dt_hdr.Rows(0).Item("NoGiro").ToString
                cmbFinance.SelectedItem = dt_hdr.Rows(0).Item("finance_tipe").ToString.Trim
                If dt_hdr.Rows(0).Item("jurnal_tipe").ToString.Trim = "Biasa" Then
                    rdBiasa.Checked = True
                Else
                    rdOtomatis.Checked = True
                End If

              

            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CalculateDebitCredit()
        Dim debit As Double
        Dim kredit As Double
        Dim i As Integer = 0

        If gv_finance.Rows.Count > 0 Then
            While i < gv_finance.Rows.Count
                debit = debit + CDbl(gv_finance.Rows(i).Cells(2).Value)
                kredit = kredit + CDbl(gv_finance.Rows(i).Cells(3).Value)
                i = i + 1
            End While
        End If

        lbldebit.Text = debit
        lblkredit.Text = kredit
        lbldebit.Text = FormatAngka(lbldebit.Text)
        lblkredit.Text = FormatAngka(lblkredit.Text)
    End Sub

    Private Sub Load_Detail()
        Cmd.CommandText = "EXEC sp_Retreive_Trans_Finance_dtl '" + txt_TransNo.Text + "'"
        dt_item.Clear()

        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        If dt_item.Rows.Count > 0 Then
            gv_finance.DataSource = dt_item
            gv_finance.Enabled = True
            SetGrid()
        Else
            ' gv_finance.Enabled = False
        End If
    End Sub

    Private Sub SetGrid()
        gv_finance.Columns(0).Width = 60
        gv_finance.Columns(1).Width = 160
        gv_finance.Columns(2).Width = 80
        gv_finance.Columns(3).Width = 120
        gv_finance.Columns(4).Width = 200
    End Sub

    Private Function GetJournalID(ByVal refno As String) As String
        Dim dt As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "EXEC [sp_Get_JournalID]	 '" + refno + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            Return dt.Rows(0).Item("journalID").ToString


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return String.Empty
    End Function
#End Region

#Region "Working Area"
    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_KodeCoa.BackColor = Color.DarkGray
            txt_NamaCoa.BackColor = Color.DarkGray
            txt_Harga.BackColor = Color.DarkGray
            txt_Ket.BackColor = Color.DarkGray
            cb_DebitKredit.BackColor = Color.DarkGray


        ElseIf proses = "UPDATE" Then
            txt_KodeCoa.BackColor = Color.DarkGray
            txt_NamaCoa.BackColor = Color.DarkGray
            txt_Harga.BackColor = Color.LemonChiffon
            txt_Ket.BackColor = Color.LemonChiffon
            cb_DebitKredit.BackColor = Color.LemonChiffon

        ElseIf proses = "INSERT" Then
            txt_KodeCoa.BackColor = Color.LemonChiffon
            txt_NamaCoa.BackColor = Color.DarkGray
            txt_Harga.BackColor = Color.LemonChiffon
            txt_Ket.BackColor = Color.LemonChiffon
            cb_DebitKredit.BackColor = Color.LemonChiffon

        End If
    End Sub

    Private Sub SetBackColor_WaAuto(ByVal proses As String)
        If proses = "READ" Then
            txtkdCOA.BackColor = Color.DarkGray
            txtNamaCOA.BackColor = Color.DarkGray
            txtHarga.BackColor = Color.DarkGray
            txtket.BackColor = Color.DarkGray
            cmbTipe.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            txtkdCOA.BackColor = Color.DarkGray
            txtNamaCOA.BackColor = Color.DarkGray
            txtHarga.BackColor = Color.LemonChiffon
            txtket.BackColor = Color.LemonChiffon
            cmbTipe.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txtkdCOA.BackColor = Color.LemonChiffon
            txtNamaCOA.BackColor = Color.DarkGray
            txtHarga.BackColor = Color.LemonChiffon
            txtket.BackColor = Color.LemonChiffon
            cmbTipe.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        txt_KodeCoa.Clear()
        txt_NamaCoa.Clear()
        txt_Harga.Clear()
        txt_Ket.Clear()
        Clear_WaAuto()
        SetBackColor_Wa("READ")
        If Status_Proses = "" Then
            btn_insert.Enabled = True
            btn_edit.Enabled = True
            btn_delete.Enabled = True
        Else
            btn_insert.Enabled = True
            btn_edit.Enabled = True
            btn_delete.Enabled = True
        End If
        gv_finance.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Account_ID")
        dt_item.PrimaryKey = dc

        If txt_KodeCoa.Text.Trim = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_item.Rows.Find(txt_KodeCoa.Text)
            If da IsNot Nothing Then
                da.Delete()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gv_finance.Focus()
            End If
        End If
        CalculateDebitCredit()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_KodeCoa.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")


        If rdOtomatis.Checked = True Then
            cb_DebitKredit.Enabled = False
            cb_DebitKredit.BackColor = Color.DarkGray
        End If
        txt_KodeCoa.Enabled = False 'karna primary Key
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_KodeCoa.BackColor = Color.DarkGray
        cb_DebitKredit.Focus()
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"
        Enable_Wa(True)
        '  Clear_Wa()
        txt_KodeCoa.Clear()
        txt_NamaCoa.Clear()
        txt_Harga.Clear()
        txt_Ket.Clear()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_KodeCoa.Focus()

        If rdOtomatis.Checked = True Then
            cb_DebitKredit.Enabled = False
            If gv_finance.Rows.Count > 0 Then
                If CInt(gv_finance.Rows(0).Cells(2).Value) = 0 Then
                    cb_DebitKredit.Text = "Debet"
                Else
                    cb_DebitKredit.Text = "Kredit"
                End If
            End If
        End If

    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Account_id")
        dt_item.PrimaryKey = dc

        ' Validation

        If txt_KodeCoa.Text.Trim = "" Then
            MessageBox.Show("Kode COA harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txt_Harga.Text.Trim = "" Then
            MessageBox.Show("Harga harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If CInt(txt_Harga.Text) = 0 Then
            MessageBox.Show("Harga tidak boleh 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            dr_item = dt_item.Rows.Find(txt_KodeCoa.Text)
            If dr_item IsNot Nothing Then
                MessageBox.Show("Account ID ini sudah ada sebelumnya.Silahkan masukan item ID yang lain", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_KodeCoa.Focus()
                Exit Sub
            Else
                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Account_ID") = txt_KodeCoa.Text
                dr("Account_Name") = txt_NamaCoa.Text
                If cb_DebitKredit.Text = "Debet" Then
                    dr("Debet") = txt_Harga.Text
                    dr("Credit") = "0.00"
                Else
                    dr("Credit") = txt_Harga.Text
                    dr("Debet") = "0.00"
                End If
                dr("Remarks") = txt_Ket.Text
                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_item.Rows.Find(txt_KodeCoa.Text)
            If da IsNot Nothing Then
                If cb_DebitKredit.Text = "Debet" Then
                    da("Debet") = txt_Harga.Text
                    da("Credit") = "0.00"
                Else
                    da("Credit") = txt_Harga.Text
                    da("Debet") = "0.00"
                End If
                da("Remarks") = txt_Ket.Text
                'da.AcceptChanges()
            End If
        End If
        gv_finance.DataSource = dt_item
        SetGrid_item()
        'Refresh_Grid()
        ' cmbJurnal.Enabled = False
        rdBiasa.Enabled = False
        rdOtomatis.Enabled = False
        Status_Proses = "" 'reset
        CalculateDebitCredit()
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub txt_KodeCoa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_KodeCoa.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Account_ID,Account_Name from Master_CoA where Active_Flag = 'Y' and PostEdit = 'Y'", "Account_ID", "Account_Name", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_KodeCoa.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_NamaCoa.Text = frmSearch.txtResult2.Text.ToString.Trim
                    cb_DebitKredit.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_KodeCoa.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "Select Account_ID,Account_Name from Master_CoA where Active_Flag = 'Y' and PostEdit = 'Y' and Account_ID =  '" & txt_KodeCoa.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txt_KodeCoa.Text = dt_dtl.Rows(0).Item("Account_ID").ToString
                        txt_NamaCoa.Text = dt_dtl.Rows(0).Item("Account_Name").ToString
                        cb_DebitKredit.Focus()
                    Else
                        MessageBox.Show("Kode CoA tidak ditemukan. Pastikan Kode CoA yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub
#End Region
    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim i As Integer = 0
        Dim debit As Integer = 0
        Dim kredit As Integer = 0
        Dim selisih As Integer = 0
        Dim defaultPeriod As String
        dtFinance = dt_finance.Value.ToString("yyyyMM")
        Dim JournalNo As String

        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        'If dtFinance <> defaultPeriod Then
        '    If dtFinance < defaultPeriod Then
        '        MessageBox.Show("Tanggal Finance harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Exit Sub
        '    End If
        '    period = dtFinance
        'End If

        If rdBiasa.Checked = False And rdOtomatis.Checked = False Then
            MessageBox.Show("Tipe Jurnal harus dipilih.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If gv_finance.Rows.Count = 0 Then
            MessageBox.Show("Data detail PO belum terisi.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        While i < gv_finance.Rows.Count
            debit = debit + CInt(gv_finance.Rows(i).Cells(2).Value)
            kredit = kredit + CInt(gv_finance.Rows(i).Cells(3).Value)
            i = i + 1
        End While

        If debit <> kredit Then
            selisih = debit - kredit
            selisih = Math.Abs(selisih)
            MessageBox.Show("Journal tidak balance, selisih : " & selisih & ". Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim LastSerial As Integer
        Dim remarks_Stok As String
        Dim JurnalTipe As String

        If rdBiasa.Checked Then
            JurnalTipe = "Biasa"
        Else
            JurnalTipe = "Otomatis"
        End If


        '----Save LPB Header   
        Try
            'Cause this form is for insert Terim Barang, so next status is Waiting for Purchasing (WAFP)
            If txt_TransNo.Text = "" Then
                txt_TransNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))

                JournalNo = Generate_TranNo("Journal")
                LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))



                remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

                id_status = "WAFH" 'Waiting approval from Finance Head
                Cmd.CommandText = "EXEC sp_Insert_Finance_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                             dt_finance.Value.ToString("yyyy-MM-dd") & "','" & period & "','" & JurnalTipe & "','" & cmbFinance.SelectedItem & "','" & txtNamaBank.Text & "','" & txtNoGiro.Text & "','" & _
                                             txt_remarks.Text & "','" & id_status & "','" & userlog.UserName & "'"


                '       @JournalID nvarchar(50),
                '@EmployeeID nvarchar(50),
                '@JournalType nvarchar(50),
                '@Notes nvarchar(300),
                '@refno nvarchar(50),
                '@transpost bit,
                '@paymentref nvarchar(200),
                '@includetax bit,
                '@Journalidtax nvarchar(50),
                '@userlog varchar(10)

                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                             userlog.EmployeeID & "','" & _
                                            "Finance" & "','" & txt_remarks.Text & "','" & txt_TransNo.Text & "','" & _
                                             "" & "','" & _
                                             "" & "','" & _
                                             "" & "','" & _
                                             "" & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()



                For Each item As DataRow In dt_item.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                      item("Account_ID") & "'," & item("Debet") & "," & item("Credit") & ",'" & "" & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                Next


                For Each item As DataRow In dt_item.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Finance_Dtl '" & txt_TransNo.Text + "','" & _
                                      item("Account_ID") & "'," & item("Debet") & "," & item("Credit") & ",'" & item("remarks") & "'"
                    Cmd.ExecuteNonQuery()

                Next
                'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to INBOX Purchasing
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
            Else
                'If id_status.Trim = "WAFH" Then 'Waiting approval  from Finance Head
                '    id_status = "CMP" 'Completed
                'End If
                'update Terima Barang Header

                Cmd.CommandText = "EXEC sp_Update_Finance_Hdr '" & txt_TransNo.Text & "','" & dt_finance.Value.ToString("yyyy-MM-dd") & "','" & period & "','" & JurnalTipe & "','" & cmbFinance.SelectedItem & "','" & txtNamaBank.Text & "','" & txtNoGiro.Text & "','" & _
                                   txt_remarks.Text.Trim & "','" & id_status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                'update Terima Barang Detail
                For Each item As DataRow In dt_item.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Finance_Dtl '" & txt_TransNo.Text + "','" & _
                                           item("Account_ID") & "','" & item("Debet") & "','" & item("Credit") & "','" & item("remarks") & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & GetJournalID(txt_TransNo.Text) + "','" & _
                                     item("Account_ID") & "'," & item("Debet") & "," & item("Credit") & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                    ElseIf item.RowState = DataRowState.Deleted Then



                        Cmd.CommandText = "EXEC sp_Delete_Trans_Finance_Dtl '" & txt_TransNo.Text + "','" & _
                                           item("Account_ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Delete_JournalItem '" & GetJournalID(txt_TransNo.Text) + "','" & _
                                           item("Account_ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()

                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_Finance_Dtl '" & txt_TransNo.Text & "','" & item("Account_ID") & "'," & _
                                          item("Debet") & "," & item("Credit") & ",'" & item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Update_Journal_Item '" & txt_TransNo.Text + "','" & _
                                      item("Account_ID") & "'," & item("Debet") & "," & item("Credit") & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next

                'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                '  If id_status <> "CMP" Then
                'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(id_status), "W", "Y", id_status) 'Insert to NEXT APPROVAL
                'End If
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
            End If

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Form Transaksi Finance : " & txt_TransNo.Text.Trim & " Has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                FrmTransFinance_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        ClearInput()
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        ts_FindPO.Enabled = True
        Status_Proses = ""

        txt_remarks.Focus()
    End Sub

    Private Sub gv_finance_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_finance.DoubleClick
        If gv_finance.Rows(0).Selected And rdOtomatis.Checked = True Then
            Enable_Button_Wa(False)
            btnedit.Enabled = True

            txtkdCOA.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Account_ID").Value.ToString.Trim
            txtNamaCOA.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Account_Name").Value.ToString.Trim
            cmbTipe.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim
            If gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim <> "0.00" Then
                cmbTipe.Text = "Debet"
                txtHarga.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim
            Else
                cmbTipe.Text = "Kredit"
                txtHarga.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Credit").Value.ToString.Trim
            End If
            txtket.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Remarks").Value.ToString.Trim
        Else
            If txtkdCOA.Text <> "" Then
                Exit Sub
            End If
            If String.IsNullOrEmpty(gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Account_ID").Value) = False Then
                txt_KodeCoa.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Account_ID").Value.ToString.Trim
                txt_NamaCoa.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Account_Name").Value.ToString.Trim
                cb_DebitKredit.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim



                If gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim <> "0.00" Then
                    cb_DebitKredit.Text = "Debet"
                    txt_Harga.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Debet").Value.ToString.Trim
                Else
                    cb_DebitKredit.Text = "Kredit"
                    txt_Harga.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Credit").Value.ToString.Trim
                End If


                txt_Ket.Text = gv_finance.Rows(gv_finance.CurrentCell.RowIndex).Cells("Remarks").Value.ToString.Trim

            End If
        End If
    End Sub

   

    'Private Sub cmbJurnal_SelectedIndexChanged(sender As Object, e As System.EventArgs)
    '    If cmbJurnal.SelectedItem = "Biasa" Then
    '        Enable_WaAuto(False)
    '        btnsave.Enabled = False
    '        cmbFinance.Enabled = False
    '        SetBackColor_WaAuto("READ")
    '        Status_Proses = ""
    '        Clear_Wa()
    '        Clear_WaAuto()
    '        Enable_Button_Wa(True)
    '    Else
    '        btnsave.Enabled = True
    '        cmbFinance.Enabled = True
    '        Status_Proses = "Insert"
    '        Enable_WaAuto(True)
    '        Clear_Wa()
    '        SetBackColor_WaAuto("INSERT")
    '        txtkdCOA.Focus()
    '        Clear_WaAuto()
    '        Enable_Button_Wa(False)
    '        Enable_Wa(False)
    '        SetBackColor_Wa("READ")
    '    End If
    'End Sub
    Private Sub txtkdCOA_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtkdCOA.KeyDown
        If cmbFinance.SelectedItem = "" Then
            MessageBox.Show("Please Choose Tipe Finance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Account_ID,Account_Name from Master_CoA where Active_Flag = 'Y' and PostEdit = 'Y' and left(Group_PayAccount,4) = '" & cmbFinance.SelectedItem & "'", "Account_ID", "Account_Name", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txtkdCOA.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtNamaCOA.Text = frmSearch.txtResult2.Text.ToString.Trim
                    cmbTipe.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtkdCOA.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "Select Account_ID,Account_Name from Master_CoA where Active_Flag = 'Y' and left(Group_PayAccount,4) = '" & cmbFinance.SelectedItem & "' and Account_ID = '" & txtkdCOA.Text & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txtkdCOA.Text = dt_dtl.Rows(0).Item("Account_ID").ToString
                        txtNamaCOA.Text = dt_dtl.Rows(0).Item("Account_Name").ToString
                        cmbTipe.Focus()
                    Else
                        MessageBox.Show("Kode CoA tidak ditemukan. Pastikan Kode CoA yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As System.EventArgs) Handles btnsave.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Account_id")
        dt_item.PrimaryKey = dc

        ' Validation
        If txtkdCOA.Text.Trim = "" Then
            MessageBox.Show("Kode COA harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtHarga.Text.Trim = "" Then
            MessageBox.Show("Harga harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If CInt(txtHarga.Text) = 0 Then
            MessageBox.Show("Harga tidak boleh 0.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            If gv_finance.Rows.Count > 0 Then
                MessageBox.Show("Journal Otomatis harus di baris paling pertama", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            dr_item = dt_item.Rows.Find(txtkdCOA.Text)
            If dr_item IsNot Nothing Then
                MessageBox.Show("Item ID ini sudah ada sebelumnya.Silahkan masukan item ID yang lain", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txtkdCOA.Focus()
                Exit Sub
            Else
                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Account_ID") = txtkdCOA.Text
                dr("Account_Name") = txtNamaCOA.Text
                If cmbTipe.SelectedItem = "Debet" Then
                    dr("Debet") = txtHarga.Text
                    dr("Credit") = 0
                Else
                    dr("Credit") = txtHarga.Text
                    dr("Debet") = 0
                End If
                dr("Remarks") = txtket.Text
                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_item.Rows.Find(txtkdCOA.Text)
            If da IsNot Nothing Then
                If cmbTipe.SelectedItem = "Debet" Then
                    da("Debet") = txtHarga.Text
                    da("Credit") = 0
                Else
                    da("Credit") = txtHarga.Text
                    da("Debet") = 0
                End If
                da("Remarks") = txtket.Text
                'da.AcceptChanges()
            End If
        End If
        gv_finance.DataSource = dt_item
        'Refresh_Grid()
        Status_Proses = "" 'reset
        Enable_WaAuto(False)
        SetBackColor_WaAuto("READ")
        btnsave.Enabled = False
        btnedit.Enabled = False
        cmbFinance.Enabled = False
        'cmbJurnal.Enabled = False
        rdBiasa.Enabled = False
        rdOtomatis.Enabled = False
        Enable_Button_Wa(True)
        If cmbTipe.SelectedItem = "Kredit" Then
            cb_DebitKredit.SelectedItem = "Debit"
        Else
            cb_DebitKredit.SelectedItem = "Kredit"
        End If
        Clear_WaAuto()
        gv_finance.Enabled = True
        CalculateDebitCredit()
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Harga_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Harga.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub rdBiasa_CheckedChanged(sender As Object, e As System.EventArgs) Handles rdBiasa.CheckedChanged
        Enable_WaAuto(False)
        btnsave.Enabled = False
        cmbFinance.Enabled = False
        SetBackColor_WaAuto("READ")
        Status_Proses = ""
        Clear_Wa()
        Clear_WaAuto()
        Enable_Button_Wa(True)
    End Sub

    Private Sub rdOtomatis_CheckedChanged(sender As Object, e As System.EventArgs) Handles rdOtomatis.CheckedChanged
        btnsave.Enabled = True
        cmbFinance.Enabled = True
        Status_Proses = "Insert"
        Enable_WaAuto(True)
        Clear_Wa()
        SetBackColor_WaAuto("INSERT")
        txtkdCOA.Focus()
        Clear_WaAuto()
        Enable_Button_Wa(False)
        Enable_Wa(False)
        SetBackColor_Wa("READ")
    End Sub

    Private Sub btnedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If txtkdCOA.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_WaAuto(True)
        SetBackColor_WaAuto("UPDATE")

        cmbTipe.Enabled = False
        cmbTipe.BackColor = Color.DarkGray
        txtkdCOA.Enabled = False 'karna primary Key
        Enable_Button_Wa(False)
        btnedit.Enabled = False
        btnsave.Enabled = True

        txtkdCOA.BackColor = Color.DarkGray
        cmbTipe.Focus()
    End Sub

    Private Sub cb_DebitKredit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_DebitKredit.SelectedIndexChanged
        If cmbTipe.Text <> "" Then
            If cmbTipe.SelectedItem = "Debet" Then
                cb_DebitKredit.Text = "Kredit"
            Else
                cb_DebitKredit.Text = "Debet"
            End If
        End If        
    End Sub

    Private Sub cmbFinance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFinance.SelectedIndexChanged
        If cmbFinance.SelectedItem = "Cash In" Then
            txtNamaBank.Enabled = False
            txtNoGiro.Enabled = False
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 0
        ElseIf cmbFinance.SelectedItem = "Cash Out" Then
            txtNamaBank.Enabled = False
            txtNoGiro.Enabled = False
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 1
        ElseIf cmbFinance.SelectedItem = "Giro In" Then
            txtNamaBank.Enabled = True
            txtNoGiro.Enabled = True
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 0
        ElseIf cmbFinance.SelectedItem = "Giro Out" Then
            txtNamaBank.Enabled = True
            txtNoGiro.Enabled = True
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 1
        ElseIf cmbFinance.SelectedItem = "Bank In" Then
            txtNamaBank.Enabled = True
            txtNoGiro.Enabled = False
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 0
        ElseIf cmbFinance.SelectedItem = "Bank Out" Then
            txtNamaBank.Enabled = True
            txtNoGiro.Enabled = False
            txtNamaBank.Clear()
            txtNoGiro.Clear()
            cmbTipe.SelectedIndex = 1
        End If
    End Sub



End Class