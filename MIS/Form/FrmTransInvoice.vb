Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Strings
Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.Text
Imports System.Collections


Public Class FrmTransInvoice
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim EmployeeID As String
    Dim NamaEmployee As String
    Dim NamaCustomer As String
    Dim CurrDate As String
    Dim period As String = ""
    Private Sub FrmTransInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtjatuhtempo As DateTime
        Dim CurrDate As DateTime
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadInvoice(txt_DocNo.Text)
        enable_wa(False)
        SetBackColor_Wa("READ")
        DisableButton(False)
        Enable_Button_Wa(False)
        gvInvoice.AllowUserToAddRows = False
        If txt_DocNo.Text.Trim <> "" Then
            LoadInvoice(txt_DocNo.Text)
            LoadInvoiceAll(txt_DocNo.Text)
            btn_print.Enabled = True
            ts_Edit.Enabled = True
            CurrDate = GetCurrDate()
            CurrDate = CurrDate.ToString("MM/dd/yyyy")


            ts_cancel.Enabled = False
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                enable_wa(False)
                DisableButton(False)
                Enable_Button_Wa(False)
                dt_Invoice.BackColor = Color.DarkGray
                cb_FakturType.BackColor = Color.DarkGray
                txtkdCustomer.BackColor = Color.DarkGray
                dt_Invoice.Enabled = False
                cb_FakturType.Enabled = False
                txtkdCustomer.Enabled = False
            End If
        Else
            txtPeriod.Text = GetPeriod()
            Enable_Button_Wa(True)
            'SetBackColor_Wa("INSERT")   ' added by kparlind         
            ts_save.Enabled = True ' added by kparlind
            'ts_Edit.Enabled = False ' added by kparlind
            ts_cancel.Enabled = True
            btn_print.Enabled = False
            enable_wa(False)

            dt_Invoice.BackColor = Color.LemonChiffon
            cb_FakturType.BackColor = Color.LemonChiffon 'added by kparlind
            txtkdCustomer.BackColor = Color.LemonChiffon
            dt_Invoice.Enabled = True
            cb_FakturType.Enabled = True
            txtkdCustomer.Enabled = True
        End If
        SetGrid_item()
        dtjatuhtempo = CalculateJatuhTempo()
        txtjatuhtempo.Text = dtjatuhtempo.ToString("dd-MM-yyyy")

        txtDPP.Text = FormatAngka(txtDPP.Text)
        txtppn.Text = FormatAngka(txtppn.Text)
        txttotal.Text = FormatAngka(txttotal.Text)
    End Sub

    Function CheckStatusPeriodClosing(ByVal Period As String, ByVal Today As String) As Boolean
        Dim dt_period As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from Trans_Closing where Period = '" & Period & "' and start_date <= '" & Today & "' and end_date >= '" & Today & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_period)

        CheckStatusPeriodClosing = dt_period.Rows.Count > 0

    End Function

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

    Private Sub Clear_Wa()
        dt_Invoice.Value = Now
        'chkUangMuka.Checked = False
        txtkdCustomer.Clear()
        txtNmCustomer.Clear()
        txtSalesman.Clear()
        txtProjectNo.Clear()
        txtJumlahUang.Clear()
        txtKet.Clear()
    End Sub


    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            dt_Invoice.BackColor = Color.DarkGray
            'chkUangMuka.BackColor = Color.DarkGray
            cb_FakturType.BackColor = Color.DarkGray 'added by kparlind
            txtkdCustomer.BackColor = Color.DarkGray
            ' txtNmCustomer.BackColor = Color.DarkGray
            txtSalesman.BackColor = Color.DarkGray
            txtProjectNo.BackColor = Color.DarkGray
            txtJumlahUang.BackColor = Color.DarkGray
            txtKet.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            dt_Invoice.BackColor = Color.LemonChiffon
            'chkUangMuka.BackColor = Color.LemonChiffon
            cb_FakturType.BackColor = Color.LemonChiffon 'added by kparlind
            txtkdCustomer.BackColor = Color.LemonChiffon
            'txtNmCustomer.BackColor = Color.LemonChiffon
            txtSalesman.BackColor = Color.LemonChiffon
            txtProjectNo.BackColor = Color.LemonChiffon
            txtJumlahUang.BackColor = Color.LemonChiffon
            txtKet.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            'txtNmCustomer.BackColor = Color.LemonChiffon
            txtSalesman.BackColor = Color.LemonChiffon
            txtProjectNo.BackColor = Color.LemonChiffon
            txtJumlahUang.BackColor = Color.LemonChiffon
            txtKet.BackColor = Color.LemonChiffon
        End If
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
        ts_cancel.Enabled = boo
    End Sub

    Private Sub enable_wa(ByVal bool As Boolean)
        'txtNmCustomer.Enabled = bool
        txtSalesman.Enabled = bool
        txtProjectNo.Enabled = bool
        txtJumlahUang.Enabled = bool
        txtKet.Enabled = bool
    End Sub
    Private Sub LoadInvoiceAll(ByVal doc As String)
        Dim dttempo As Date
        Dim fakturtipe As String

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "EXEC [sp_Retreive_Trans_Invoice_PiutangAll]	 '" + doc + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            txtkdCustomer.Text = dt.Rows(0).Item("cust_id").ToString
            txtNmCustomer.Text = dt.Rows(0).Item("nama").ToString
            txtJumlahUang.Text = dt.Rows(0).Item("jumlah_uang").ToString
            txtProjectNo.Text = dt.Rows(0).Item("project_no").ToString
            txtjatuhtempo.Text = dt.Rows(0).Item("tgl_jatuhtempo").ToString
            txtPeriod.Text = dt.Rows(0).Item("Period").ToString
            dttempo = txtjatuhtempo.Text
            txtjatuhtempo.Text = Format(dttempo, "dd-MM-yyyy")
            txtPaymentDay.Text = dt.Rows(0).Item("payment_day").ToString
            txtTOP.Text = dt.Rows(0).Item("term_of_payment").ToString

            txtKet.Text = dt.Rows(0).Item("keterangan").ToString
            txtSalesman.Text = dt.Rows(0).Item("name").ToString
            fakturtipe = dt.Rows(0).Item("Faktur_Tipe").ToString



            If fakturtipe = "Instalasi" Then
                cb_FakturType.Text = "Cicilan Instalasi"
            Else
                cb_FakturType.Text = dt.Rows(0).Item("Faktur_Tipe").ToString
            End If
            'txtDPP.Text = txtJumlahUang.Text
            'txtppn.Text = 10 / 100 * CInt(txtJumlahUang.Text)
            'txttotal.Text = CInt(DPP.Text) + CInt(txtppn.Text)
            ' txttotal.Text = txtJumlahUang.Text


            txtDPP.Text = dt.Rows(0).Item("DPP").ToString
            txtppn.Text = 10 / 100 * CInt(txtDPP.Text)
            txtpph.Text = 2 / 100 * CInt(txtDPP.Text)

            txttotal.Text = CInt(txtDPP.Text) + CInt(txtppn.Text) + CInt(txtpph.Text)

            txtDPP.Text = FormatAngka(CInt(txtDPP.Text))
            txtppn.Text = FormatAngka(CInt(txtppn.Text))
            txtpph.Text = FormatAngka(CInt(txtpph.Text))

            txttotal.Text = FormatAngka(txttotal.Text)


            EmployeeID = dt.Rows(0).Item("Employee_ID").ToString
            dt_Invoice.Value = dt.Rows(0).Item("tgl_faktur").ToString

            NamaEmployee = txtSalesman.Text
            NamaCustomer = txtNmCustomer.Text
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadInvoice(ByVal doc As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC [sp_Retreive_Trans_Invoice_Piutang]	 '" + doc + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvInvoice.DataSource = dt_hdr
            gvInvoice.Enabled = dt_hdr.Rows.Count > 0

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtkdCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkdCustomer.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select * from master_customer where active_flag = 'Y'", "Cust_ID", "Nama", "Term_Of_Payment", "Payment_Day", "")
            txtkdCustomer.Text = frmSearch.txtResult1.Text.ToString.Trim
            txtNmCustomer.Text = frmSearch.txtResult2.Text.ToString.Trim
            txtTOP.Text = frmSearch.txtResult3.Text.ToString.Trim
            txtPaymentDay.Text = frmSearch.txtResult4.Text.ToString.Trim
            NamaCustomer = frmSearch.txtResult2.Text.ToString.Trim
        End If
    End Sub

    Private Sub txtSalesman_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalesman.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select * from master_employee where active_flag = 'Y'", "Employee_ID", "Name", "", "", "")
            txtSalesman.Text = frmSearch.txtResult2.Text.ToString.Trim
            NamaEmployee = frmSearch.txtResult2.Text.ToString.Trim
            EmployeeID = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub txtProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If txtkdCustomer.Text = String.Empty Then
            MsgBox("Please fill Kode Customer")
            Exit Sub
        End If
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select * from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no where cust_id = '" & txtkdCustomer.Text & "'", "Project_NO", "", "", "", "")
            txtProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Status_Proses = "Insert"
        enable_wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txtkdCustomer.Focus()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        enable_wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_insert.Enabled = True
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gvInvoice.Enabled = dt_hdr.Rows.Count > 0
    End Sub

    Private Sub btn_save_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        Dim dtjatuhtempo As DateTime
        Dim FakturTipe As String

        dc(0) = dt_hdr.Columns("Project_No")
        dt_hdr.PrimaryKey = dc

        If txtkdCustomer.Text = "" Then
            MessageBox.Show("Please Fill Kode Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtSalesman.Text = "" Then
            MessageBox.Show("Please Fill Salesman.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtProjectNo.Text = String.Empty Then
            MessageBox.Show("Please Fill Project No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtJumlahUang.Text = String.Empty Then
            MessageBox.Show("Please Fill Jumlah Uang.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtKet.Text = String.Empty Then
            MessageBox.Show("Please Fill Keterangan.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


        dtjatuhtempo = CalculateJatuhTempo()

        ' ba : added by kparlind
        If cb_FakturType.SelectedText = "Cicilan Instalasi" Then
            FakturTipe = "Instalasi"
        Else
            FakturTipe = cb_FakturType.SelectedText.Trim
        End If
        ' ea : added by kparlind
        If Status_Proses = "Insert" Then
            Dim dr As DataRow

            If gvInvoice.Rows.Count >= 1 Then
                MessageBox.Show("Cannot have more than one project for invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            da = dt_hdr.Rows.Find(txtProjectNo.Text)

            If da IsNot Nothing Then
                MessageBox.Show("No Project sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                dr = dt_hdr.NewRow
                dr("tgl_faktur") = dt_Invoice.Value.ToString("yyyy-MM-dd")

                'ba : remarked by kparlind 24-dec-2012, karna ada tambahan retention
                'dr("Faktur_Tipe") = IIf(chkUangMuka.Checked, "Uang Muka", "Instalasi")
                dr("Faktur_Tipe") = FakturTipe
                'ea : remarked by kparlind 24-dec-2012, karna ada tambahan retention
                dr("tgl_jatuhTempo") = dtjatuhtempo.ToString("yyyy-MM-dd")
                dr("Cust_ID") = txtkdCustomer.Text
                dr("Salesman_ID") = EmployeeID
                dr("Project_No") = txtProjectNo.Text
                dr("Jumlah_Uang") = txtJumlahUang.Text
                dr("Keterangan") = txtKet.Text
                dt_hdr.Rows.Add(dr)
            End If

        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txtProjectNo.Text)

            If da IsNot Nothing Then
                da("tgl_faktur") = dt_Invoice.Value.ToString("yyyy-MM-dd")
                'ba : remarked by kparlind 24-dec-2012, karna ada tambahan retention
                'dr("Faktur_Tipe") = IIf(chkUangMuka.Checked, "Uang Muka", "Instalasi")
                da("Faktur_Tipe") = FakturTipe
                'ea : remarked by kparlind 24-dec-2012, karna ada tambahan retention
                da("tgl_jatuhTempo") = dtjatuhtempo.ToString("yyyy-MM-dd")
                da("Cust_ID") = txtkdCustomer.Text
                da("Salesman_ID") = EmployeeID
                da("Project_No") = txtProjectNo.Text
                da("Jumlah_Uang") = txtJumlahUang.Text
                da("Keterangan") = txtKet.Text
            End If
        End If
        gvInvoice.DataSource = dt_hdr
        Status_Proses = "" 'reset

        txtDPP.Text = txtJumlahUang.Text
        txtppn.Text = 10 / 100 * CInt(txtJumlahUang.Text)
        txtpph.Text = 2 / 100 * CInt(txtJumlahUang.Text)
        txttotal.Text = CInt(DPP.Text) + CInt(txtppn.Text) + CInt(txtpph.Text)
        ts_save.Enabled = True
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub InsertJournalItem(ByVal fakturTipe As String, ByVal JournalNo As String)
        ' Dim LastSerial As Integer
        Dim dtAccount As New DataTable
        Dim debit As Double = 0
        Dim credit As Double = 0
        Dim accountID As String
        Dim type As String

        Dim i As Integer = 0

        Cmd.CommandText = "select account_id,type from mapping_objectjurnal where form_name = '" + Me.Name + "'"

        DA.SelectCommand = Cmd
        DA.Fill(dtAccount)

        While i < dtAccount.Rows.Count

            accountID = dtAccount.Rows(i).Item("account_id")
            type = dtAccount.Rows(i).Item("type")

            If fakturTipe = "Uang Muka" Then
                If accountID = "136" Then
                    debit = txttotal.Text
                    credit = "0"
                ElseIf accountID = "341" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            ElseIf fakturTipe = "Instalasi" Then
                If accountID = "136" Then
                    debit = CInt(txttotal.Text)
                    credit = "0"
                ElseIf accountID = "511" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            ElseIf fakturTipe = "Retention" Then
                If accountID = "137" Then
                    debit = CInt(txttotal.Text)
                    credit = "0"
                ElseIf accountID = "511" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            End If

            Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                            accountID & "'," & debit & ",'" & credit & "','" & "" & "','" & userlog.UserName & "'"


            Cmd.ExecuteNonQuery()


            i = i + 1
        End While


    End Sub

    Private Sub InsertJournalInvoice(ByVal FakturTipe As String)
        Dim JournalNo As String
        Dim LastSerial As Integer
        Dim dtAccount As New DataTable
        Dim debit As Double = 0
        Dim credit As Double = 0
        Dim accountID As String
        Dim type As String

        Dim i As Integer = 0



        JournalNo = Generate_TranNo("Journal")
        LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))


        Cmd.CommandText = "select account_id,type from mapping_objectjurnal where form_name = '" + Me.Name + "'"

        DA.SelectCommand = Cmd
        DA.Fill(dtAccount)


        Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                  userlog.EmployeeID & "','" & _
                                 "Invoice Piutang" & "','" & txtKet.Text & "','" & txt_DocNo.Text & "','" & _
                                  "" & "','" & _
                                  "" & "','" & _
                                  "" & "','" & _
                                  "" & "','" & _
                                  userlog.UserName & "'"
        Cmd.ExecuteNonQuery()


        While i < dtAccount.Rows.Count

            accountID = dtAccount.Rows(i).Item("account_id")
            type = dtAccount.Rows(i).Item("type")

            If FakturTipe = "Uang Muka" Then
                If accountID = "136" Then
                    debit = txttotal.Text
                    credit = "0"
                ElseIf accountID = "341" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            ElseIf FakturTipe = "Instalasi" Then
                If accountID = "136" Then
                    debit = CInt(txttotal.Text)
                    credit = "0"
                ElseIf accountID = "511" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            ElseIf FakturTipe = "Retention" Then
                If accountID = "137" Then
                    debit = CInt(txttotal.Text)
                    credit = "0"
                ElseIf accountID = "511" Then
                    debit = "0"
                    credit = CInt(txtDPP.Text)
                ElseIf accountID = "353" Then
                    debit = "0"
                    credit = CInt(txtpph.Text)
                ElseIf accountID = "351" Then
                    debit = "0"
                    credit = CInt(txtppn.Text)
                Else
                    debit = "0"
                    credit = "0"
                End If
            End If

            Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                            accountID & "'," & debit & ",'" & credit & "','" & "" & "','" & userlog.UserName & "'"


            Cmd.ExecuteNonQuery()


            i = i + 1
        End While

        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
    End Sub


    Private Function CalculateJatuhTempo() As DateTime
        Dim dtJatuhTempo As DateTime
        Dim PaymentDay As String
        Dim JatuhTempoDay As String

        dt.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "select term_of_payment,payment_day from master_customer where cust_id = '" & txtkdCustomer.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count > 0 Then
            PaymentDay = dt.Rows(0).Item("payment_day").ToString
            dtJatuhTempo = dt_Invoice.Value.AddDays(dt.Rows(0).Item("term_of_payment"))
            JatuhTempoDay = dtJatuhTempo.ToString("dddd")


            While StrComp(JatuhTempoDay.Trim, PaymentDay.Trim) = -1
                dtJatuhTempo = dtJatuhTempo.AddDays(1)
                JatuhTempoDay = dtJatuhTempo.ToString("dddd")
            End While
           
        Else
            dtJatuhTempo = dt_Invoice.Value
        End If

        Return dtJatuhTempo
    End Function

    Public Function GetJournalID()
        Dim dtJournal As New DataTable
        Cmd.CommandText = "select journalid from journal where refno = '" & txt_DocNo.Text & "'"

        DA.SelectCommand = Cmd
        DA.Fill(dtJournal)
        Return dtJournal.Rows(0).Item("JournalID").ToString
    End Function

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim dtJatuhTempo As DateTime
        Dim dtInvoice As String
        Dim defaultPeriod As String
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim LastSerial As Integer
        Dim remarks_Stok As String

        dtJatuhTempo = CalculateJatuhTempo()

        dtInvoice = dt_Invoice.Value.ToString("yyyyMM")
        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        If dtInvoice <> defaultPeriod Then
            If dtInvoice < defaultPeriod Then
                MessageBox.Show("Tanggal Invoice harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Conn.Close()
                Exit Sub
            End If
            period = dtInvoice
        End If

        If gvInvoice.Rows.Count = 0 Then
            MessageBox.Show("Invoice tidak boleh kosong.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn.Close()
            Exit Sub
        End If

        Try
            If txt_DocNo.Text = "" Then
                txt_DocNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))
                remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


                Cmd.CommandText = "EXEC sp_Insert_Trans_Invoice_Piutang '" & txt_DocNo.Text.Trim & "','" & _
                                             dt_hdr.Rows(0).Item("Tgl_Faktur") & "','" & _
                                             dt_hdr.Rows(0).Item("Tgl_JatuhTempo") & "','" & _
                                             dt_hdr.Rows(0).Item("Faktur_Tipe") & "','" & _
                                             dt_hdr.Rows(0).Item("Cust_ID") & "','" & _
                                             dt_hdr.Rows(0).Item("Salesman_ID") & "','" & _
                                             dt_hdr.Rows(0).Item("Project_No") & "','" & _
                                             CDbl(txtDPP.Text) & "','" & _
                                             CDbl(txttotal.Text) & "','" & _
                                             dt_hdr.Rows(0).Item("Keterangan") & "','" & _
                                              period & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                InsertJournalInvoice(dt_hdr.Rows(0).Item("Faktur_Tipe").ToString)


                ObjTrans.Commit()
                Conn.Close()

                MsgBox("No Invoice  " & txt_DocNo.Text.Trim & " Has been Saved")
                FrmTransInvoice_Load(Nothing, Nothing)
            Else

                For Each item As DataRow In dt_hdr.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_Invoice_Piutang '" & txt_DocNo.Text.Trim & "','" & _
                                              dt_hdr.Rows(0).Item("Tgl_Faktur") & "','" & _
                                              dt_hdr.Rows(0).Item("Tgl_JatuhTempo") & "','" & _
                                               dt_hdr.Rows(0).Item("Faktur_Tipe") & "','" & _
                                               dt_hdr.Rows(0).Item("Cust_ID") & "','" & _
                                               dt_hdr.Rows(0).Item("Salesman_ID") & "','" & _
                                               dt_hdr.Rows(0).Item("Project_No") & "','" & _
                                               txtDPP.Text & "','" & _
                                               txttotal.Text & "','" & _
                                               dt_hdr.Rows(0).Item("Keterangan") & "','" & _
                                               period & "','" & _
                                               userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                        'Cmd.CommandText = "EXEC sp_Insert_Trans_Invoice_Piutang'" & txt_DocNo.Text.Trim & "','" & _
                        '                        dt_Invoice.Value.ToString("yyyy-MM-dd") & "','" & _
                        '                        dtJatuhTempo.ToString("yyyy-MM-dd") & "','" & _
                        '                        dt_hdr.Rows(0).Item("Faktur_Tipe") & "','" & _
                        '                        dt_hdr.Rows(0).Item("Cust_ID") & "','" & _
                        '                        dt_hdr.Rows(0).Item("Employee_ID") & "','" & _
                        '                        dt_hdr.Rows(0).Item("Project_No") & "','" & _
                        '                        lbltotal.Text & "','" & _
                        '                        dt_hdr.Rows(0).Item("Keterangan") & "','" & _
                        '                        userlog.UserName & "'"
                        'Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_Invoice_Piutang '" & txt_DocNo.Text.Trim & "'"

                        Cmd.ExecuteNonQuery()

                    Else
                        Dim JournalID As String


                        Cmd.CommandText = "EXEC sp_Update_Trans_Invoice_Piutang '" & txt_DocNo.Text.Trim & "','" & _
                                                 dt_hdr.Rows(0).Item("Tgl_Faktur") & "','" & _
                                                  dt_hdr.Rows(0).Item("Tgl_JatuhTempo") & "','" & _
                                                  dt_hdr.Rows(0).Item("Faktur_Tipe") & "','" & _
                                                  dt_hdr.Rows(0).Item("Cust_ID") & "','" & _
                                                  dt_hdr.Rows(0).Item("Salesman_ID") & "','" & _
                                                  dt_hdr.Rows(0).Item("Project_No") & "','" & _
                                                  CDbl(txtDPP.Text) & "','" & _
                                                  CDbl(txttotal.Text) & "','" & _
                                                  dt_hdr.Rows(0).Item("Keterangan") & "','" & _
                                                  period & "','" & _
                                                  userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        JournalID = GetJournalID()
                        Cmd.CommandText = "Delete from JournalItem where journalid = '" & JournalID & "'"


                        Cmd.ExecuteNonQuery()

                        InsertJournalItem(dt_hdr.Rows(0).Item("Faktur_Tipe").ToString, JournalID)

                    End If
                Next

                'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                '  If id_status <> "CMP" Then
                'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(id_status), "W", "Y", id_status) 'Insert to NEXT APPROVAL
                'End If
                Insert_Trans_History(txt_DocNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                ObjTrans.Commit()
                Conn.Close()
                ts_Edit.Enabled = True
                btn_print.Enabled = True ' added by kparlind
                MsgBox("No Invoice  " & txt_DocNo.Text.Trim & " Has been Saved")
                FrmTransInvoice_Load(Nothing, Nothing)
            End If

        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtProjectNo.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        enable_wa(True)
        SetBackColor_Wa("UPDATE")
        txtProjectNo.Enabled = False 'karna primary Key
        txtkdCustomer.Enabled = False
        txtNmCustomer.Enabled = False

        txtProjectNo.BackColor = Color.DarkGray 'karna primary Key
        txtkdCustomer.BackColor = Color.DarkGray
        txtNmCustomer.BackColor = Color.DarkGray

        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txtJumlahUang.Focus()
    End Sub

    Private Sub gvInvoice_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvInvoice.CellMouseClick
        If String.IsNullOrEmpty(gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Project_No").Value) = False Then
            txtProjectNo.Text = gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Project_No").Value.ToString.Trim
            'chkUangMuka.Checked = IIf(gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Faktur_Tipe").Value.ToString.Trim = "Y", True, False)
            cb_FakturType.SelectedText = IIf(gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Faktur_Tipe").Value.ToString.Trim = "Y", True, False) ' added by kparlind
            txtkdCustomer.Text = gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Cust_ID").Value.ToString.Trim
            txtJumlahUang.Text = gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("DPP").Value.ToString.Trim
            txtKet.Text = gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("Keterangan").Value.ToString.Trim
            dt_Invoice.Value = gvInvoice.Rows(gvInvoice.CurrentCell.RowIndex).Cells("tgl_faktur").Value.ToString.Trim
            txtSalesman.Text = NamaEmployee
            txtNmCustomer.Text = NamaCustomer
        End If

    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Project_No")
        dt_hdr.PrimaryKey = dc

        If txtProjectNo.Text = String.Empty Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txtProjectNo.Text)
            If da IsNot Nothing Then
                da.Delete()

                'Dim i As Integer
                '' Do While Not i = dt_hdr.Rows.Count
                '' If dt_hdr.Rows(i).Item("Project_No") = txtProjectNo.Text Then
                'dt_hdr.Rows.RemoveAt(0)
                '' Else
                '' i += 1
                '' End If

                ''Loop
                dt_hdr.AcceptChanges()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gvInvoice.Focus()
            End If
        End If
    End Sub

    Private Sub ts_cancel_Click(sender As Object, e As System.EventArgs) Handles ts_cancel.Click
        DisableButton(False)
        ts_cancel.Enabled = True
        'Enable_Button_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")

        gvInvoice.DataSource = ""
        gvInvoice.Refresh()
        dt_hdr.Clear()

        txt_DocNo.Clear()
        txtDPP.Clear()
        txttotal.Clear()
        txtppn.Clear()
    End Sub

    Private Sub txtJumlahUang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
   
    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        Dim frmChild As New frmPrint
        Dim dt As New DataTable

        frmChild.fakturno = txt_DocNo.Text

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "select nama,alamat,group_corporate,cust_group from trans_invoice_piutang a left join master_customer b on a.cust_id = b.cust_id where faktur_no	= '" + txt_DocNo.Text + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
           
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("group_corporate") = "Y" Then
                frmChild.alamat = dt.Rows(0).Item("alamat").ToString.Trim
                frmChild.namacust = dt.Rows(0).Item("nama").ToString.Trim
                frmChild.jumlahuang = lbltotal.Text
                frmChild.terbilang = Terbilang(lbltotal.Text)

            Else
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_hdr.Clear()

                    Cmd.CommandText = "select nama,alamat,group_corporate,cust_group from master_customer where cust_id	 = '" + dt.Rows(0).Item("cust_group").ToString + "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt)

                    Conn.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                frmChild.alamat = dt.Rows(0).Item("alamat").ToString.Trim
                frmChild.namacust = dt.Rows(0).Item("nama").ToString.Trim
                frmChild.jumlahuang = lbltotal.Text
                frmChild.terbilang = Terbilang(txttotal.Text)
                frmChild.ReportName = "Invoice Piutang"
            End If
        End If

        frmChild.Show()

    End Sub

    Private Sub ts_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        Enable_Button_Wa(True)
        'enable_wa(True)
        DisableButton(True)
        ts_Edit.Enabled = False
        ts_cancel.Enabled = True
        ts_save.Enabled = True
        txtkdCustomer.BackColor = Color.LemonChiffon
        'txtProjectNo.BackColor = Color.LemonChiffon
        'txtJumlahUang.BackColor = Color.LemonChiffon
    End Sub

    Private Sub btn_delete_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Project_No")
        dt_hdr.PrimaryKey = dc

        If txtProjectNo.Text = String.Empty Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txtProjectNo.Text)
            If da IsNot Nothing Then
                da.Delete()

                'Dim i As Integer
                '' Do While Not i = dt_hdr.Rows.Count
                '' If dt_hdr.Rows(i).Item("Project_No") = txtProjectNo.Text Then
                'dt_hdr.Rows.RemoveAt(0)
                '' Else
                '' i += 1
                '' End If

                ''Loop
                dt_hdr.AcceptChanges()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                txtDPP.Clear()
                txttotal.Clear()
                txtppn.Clear()
                gvInvoice.Focus()
            End If
        End If
    End Sub

    Private Sub btn_edit_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txtProjectNo.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        enable_wa(True)
        SetBackColor_Wa("UPDATE")
        txtProjectNo.Enabled = False 'karna primary Key
        txtkdCustomer.Enabled = False
        txtNmCustomer.Enabled = False

        txtProjectNo.BackColor = Color.DarkGray 'karna primary Key
        txtkdCustomer.BackColor = Color.DarkGray
        txtNmCustomer.BackColor = Color.DarkGray

        ts_save.Enabled = False
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txtJumlahUang.Focus()
    End Sub

    Private Sub SetGrid_item()
        If gvInvoice.Rows.Count > 0 Then
            gvInvoice.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
            gvInvoice.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        Dim dtjatuhtempo As DateTime
        Dim FakturTipe As String

        dc(0) = dt_hdr.Columns("Project_No")
        dt_hdr.PrimaryKey = dc

        If txtkdCustomer.Text = "" Then
            MessageBox.Show("Please Fill Kode Customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtSalesman.Text = "" Then
            MessageBox.Show("Please Fill Salesman.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtProjectNo.Text = String.Empty Then
            MessageBox.Show("Please Fill Project No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtJumlahUang.Text = String.Empty Then
            MessageBox.Show("Please Fill Jumlah Uang.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtKet.Text = String.Empty Then
            MessageBox.Show("Please Fill Keterangan.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        txtDPP.Text = txtJumlahUang.Text
        txtppn.Text = 10 / 100 * CInt(txtJumlahUang.Text)
        txtpph.Text = 2 / 100 * CInt(txtJumlahUang.Text)

        txttotal.Text = CInt(txtDPP.Text) + CInt(txtppn.Text) + CInt(txtpph.Text)

        txtDPP.Text = FormatAngka(CInt(txtDPP.Text))
        txtppn.Text = FormatAngka(CInt(txtppn.Text))
        txtpph.Text = FormatAngka(CInt(txtpph.Text))

        txttotal.Text = FormatAngka(txttotal.Text)
        dtjatuhtempo = CalculateJatuhTempo()
        ' ba : added by kparlind
        If cb_FakturType.Text = "Cicilan Instalasi" Then
            FakturTipe = "Instalasi"
        Else
            FakturTipe = cb_FakturType.Text

        End If
        ' ea : added by kparlind
        If Status_Proses = "Insert" Then
            Dim dr As DataRow

            If gvInvoice.Rows.Count >= 1 Then
                MessageBox.Show("Cannot have more than one project for invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            da = dt_hdr.Rows.Find(txtProjectNo.Text)

            If da IsNot Nothing Then
                MessageBox.Show("No Project sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                dr = dt_hdr.NewRow
                dr("tgl_faktur") = dt_Invoice.Value.ToString("yyyy-MM-dd")
                'dr("Faktur_Tipe") = IIf(chkUangMuka.Checked, "Uang Muka", "Instalasi")
                dr("Faktur_Tipe") = FakturTipe
                dr("tgl_jatuhTempo") = dtjatuhtempo.ToString("yyyy-MM-dd")
                dr("Cust_ID") = txtkdCustomer.Text
                dr("Salesman_ID") = EmployeeID
                dr("Project_No") = txtProjectNo.Text
                dr("DPP") = txtDPP.Text
                dr("Jumlah_Uang") = txttotal.Text
                dr("Keterangan") = txtKet.Text
                dt_hdr.Rows.Add(dr)
            End If

        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txtProjectNo.Text)

            If da IsNot Nothing Then
                da("tgl_faktur") = dt_Invoice.Value.ToString("yyyy-MM-dd")
                'da("Faktur_Tipe") = IIf(chkUangMuka.Checked, "Uang Muka", "Instalasi")
                da("Faktur_Tipe") = FakturTipe
                da("tgl_jatuhTempo") = dtjatuhtempo.ToString("yyyy-MM-dd")
                da("Cust_ID") = txtkdCustomer.Text
                da("Salesman_ID") = EmployeeID
                da("Project_No") = txtProjectNo.Text
                da("DPP") = txtDPP.Text
                da("Jumlah_Uang") = txttotal.Text
                da("Keterangan") = txtKet.Text
            End If
        End If
        gvInvoice.DataSource = dt_hdr
        Status_Proses = "" 'reset
        ts_save.Enabled = True
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_cancel_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        enable_wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_insert.Enabled = True
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gvInvoice.Enabled = dt_hdr.Rows.Count > 0
    End Sub

    Private Sub btn_insert_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"
        enable_wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txtkdCustomer.Focus()
    End Sub

    Private Sub txtProjectNo_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProjectNo.KeyDown
        If txtkdCustomer.Text = String.Empty Then
            MsgBox("Please fill Kode Customer")
            Exit Sub
        End If
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select * from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no where cust_id = '" & txtkdCustomer.Text & "'", "Project_NO", "", "", "", "")
            txtProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If

    End Sub

    Private Sub dt_Invoice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dt_Invoice.TextChanged
        Dim dtjatuhtempo As DateTime
        dtjatuhtempo = CalculateJatuhTempo()
        txtjatuhtempo.Text = dtjatuhtempo.ToString("dd-MM-yyyy")
    End Sub

    Private Sub txtSalesman_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesman.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtJumlahUang_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJumlahUang.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".") OrElse Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtProjectNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProjectNo.KeyPress
        e.KeyChar = Chr(0)
    End Sub
End Class