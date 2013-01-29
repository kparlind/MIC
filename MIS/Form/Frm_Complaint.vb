'(16 Jan 2012) Fix bug

Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class Frm_Complaint
#Region "Variable Declaration"

    Private conn As New SqlConnection
    Private cmd As New SqlCommand
    Private DA As New SqlDataAdapter
    Private StatusTrans As String
    Private StatusTransDetail As String
    Private Remarks_Stok As String
    Private dtDetail As New DataTable
    Private dtDetailOriginal As New DataTable
    Private StatusID As String
    Private Price As Double
    Public CallerForm As String
    Public Reject_Reason As String = ""
    Public ViewFormName As String

#End Region

#Region "Procedure & Function"

    Private Sub SetButton()
        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = True
                btn_delete.Enabled = False
                Btn_cancel.Enabled = True
            Case "UPDATE"
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = True
                btn_delete.Enabled = False
                Btn_cancel.Enabled = True
            Case "SAVE"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
                If StatusTrans.Trim = "EDIT" And (StatusID.Trim = "WAMA" Or StatusID.Trim = "WCFP" Or StatusID.Trim = "WCFM" Or StatusID.Trim = "RBMA") Then
                    btn_insert.Enabled = False
                    btn_delete.Enabled = False
                End If
            Case "DELETE"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
            Case "CANCEL"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
                If StatusTrans.Trim = "EDIT" And (StatusID.Trim = "WAMA" Or StatusID.Trim = "WCFP" Or StatusID.Trim = "WCFM" Or StatusID.Trim = "RBMA") Then
                    btn_insert.Enabled = False
                    btn_delete.Enabled = False
                ElseIf StatusTrans.Trim = "" Then
                    btn_insert.Enabled = False
                    btn_edit.Enabled = False
                    btn_save.Enabled = False
                    btn_delete.Enabled = False
                    Btn_cancel.Enabled = False
                End If
            Case Else
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = False
                btn_delete.Enabled = False
                Btn_cancel.Enabled = False
        End Select
    End Sub

    Private Sub SetColumnDetail()
        dtDetail.Columns.Add("Type ID")
        dtDetail.Columns.Add("Type")
        dtDetail.Columns.Add("Tgl_Keluhan")
        dtDetail.Columns.Add("Uraian_Keluhan")
        dtDetail.Columns.Add("Tgl_Marketing")
        dtDetail.Columns.Add("PIC")
        dtDetail.Columns.Add("Note_Marketing")
        dtDetail.Columns.Add("Tgl_Analisa")
        dtDetail.Columns.Add("Analisa")
        dtDetail.Columns.Add("Tgl_Penanganan")
        dtDetail.Columns.Add("Tindak_Lanjut")
        dtDetail.Columns.Add("Target")
        dtDetail.Columns.Add("Tgl_Hasil")
        dtDetail.Columns.Add("Uraian_Hasil")
        dtDetail.Columns.Add("Tgl_Verifikasi")
        dtDetail.Columns.Add("Verifikasi_Awal")
        dtDetail.Columns.Add("Note_Awal")
        dtDetail.Columns.Add("Verifikasi_Akhir")
        dtDetail.Columns.Add("Note_Akhir")
        dtDetail.Columns.Add("Dept_ID")
    End Sub

    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                ts_edit.Visible = False
                ts_save.Visible = True
                ts_cancel.Visible = True
                ts_delete.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case TransStatus.EditStatus
                ts_edit.Visible = False
                ts_cancel.Visible = True

                If GetDocCreator(txtNoUrut.Text.Trim) = userlog.UserName Then
                    ts_save.Visible = True
                    ts_delete.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                ElseIf StatusID.Trim = "WCFP" Or StatusID.Trim = "WAMA" Then
                    ts_save.Visible = False
                    ts_delete.Visible = False
                    ts_reject.Visible = False
                    ts_approve.Visible = True

                Else
                    ts_save.Visible = False
                    ts_delete.Visible = False
                    ts_reject.Visible = True
                    ts_approve.Visible = True
                End If
            Case ""
                ts_edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case Else
                ts_edit.Visible = True
                ts_delete.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
        End Select
    End Sub

    Private Sub EnableDisableInput(ByVal boo As Boolean)
        gvDetail.ReadOnly = True
        txtNoUrut.Enabled = False
        dtp_complaint.Enabled = boo
        txtNamaProj.Enabled = boo
        txtCustID.Enabled = boo
        txtAlamat.Enabled = boo
        txtNamaDiterima.Enabled = boo
        txtBagian.Enabled = boo
        Select Case StatusTrans
            Case TransStatus.EditStatus
                txtNamaProj.Enabled = False
                txtCustID.Enabled = False
                txtAlamat.Enabled = False
                txtNamaDiterima.Enabled = False
                txtBagian.Enabled = False
                dtp_complaint.Enabled = False
                txtCustID.BackColor = Color.DarkGray
                If StatusID.Trim = "WCFP" Then
                    lblRejectReason.Visible = True
                    txtRejectReason.Visible = True
                End If
            Case Else
    

        End Select
        'If StatusID.Trim = "WCFP" Then
        '    lblRejectReason.Visible = True
        '    txtRejectReason.Visible = True
        'End If
    End Sub
    Private Sub SetDate()
        Select Case StatusTrans.ToUpper
            Case "NEW"
                dtpAnalisa.Value = "01-01-1900"
                dtpMarketing.Value = "01-01-1900"
                dtpPenanganan.Value = "01-01-1900"
                dtpTarget.Value = "01-01-1900"
                dtpHasilPenanganan.Value = "01-01-1900"
                dtpHasilVerifikasi.Value = "01-01-1900"
                'Case "EDIT"
                '    dtpAnalisa.Value = "01-01-1900"
                '    dtpPenanganan.Value = "01-01-1900"
                '    dtpTarget.Value = "01-01-1900"
                '    dtpHasilPenanganan.Value = "01-01-1900"
                '    dtpHasilVerifikasi.Value = "01-01-1900"
        End Select
    End Sub
    Private Sub SetColumnVisible()
        gvDetail.Columns("Dept_ID").Visible = False
    End Sub

    Private Sub EnableDisableInputDetail()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"

                txtUraianKeluhan.Clear()
                txtNotesMarketing.Clear()
                txtAnalisa.Clear()
                txtTindakLanjut.Clear()
                txtUraianHasilPenanganan.Clear()

                txtUraianKeluhan.Enabled = True
                dtpInfoKeluhan.Enabled = True
                cbxTypeKeluhan.Enabled = True

                txtUraianKeluhan.BackColor = Color.LemonChiffon
                cbxTypeKeluhan.BackColor = Color.LemonChiffon

                If StatusID.Trim = "WAWA" Or StatusID.Trim = "WAWH" Then
                    'NOTE: 1. WAWA = Waiting Approval from Warehouse Admin
                    '      2. WAWH = Waiting Approval from Warehouse Head
                    'Txt_Qty.Enabled = False
                    'Txt_QtyRec.Enabled = True
                    'Txt_Qty.BackColor = Color.DarkGray
                    'Txt_QtyRec.BackColor = Color.LemonChiffon
                Else
                    'Txt_Qty.Enabled = True
                    'Txt_QtyRec.Enabled = False
                    'Txt_Qty.BackColor = Color.LemonChiffon
                    'Txt_QtyRec.BackColor = Color.DarkGray
                End If

            Case "UPDATE"
                'txtNotesMarketing.Enabled = True
                'dtpMarketing.Enabled = True
                'txtPIC.Enabled = True

                'txtNotesMarketing.BackColor = Color.LemonChiffon
                'dtpMarketing.BackColor = Color.LemonChiffon
                'txtPIC.BackColor = Color.LemonChiffon

                If StatusID.Trim = "WAMA" Then
                    'NOTE: 1. WAMA = Waiting Approval from marketing Admin
                    txtNotesMarketing.Enabled = True
                    dtpMarketing.Enabled = True
                    'txtPIC.Enabled = True

                    txtNotesMarketing.BackColor = Color.LemonChiffon
                    dtpMarketing.BackColor = Color.LemonChiffon
                    ' txtPIC.BackColor = Color.LemonChiffon
                ElseIf StatusID.Trim = "WCFP" Then
                    dtpAnalisa.Enabled = True
                    txtAnalisa.Enabled = True
                    dtpPenanganan.Enabled = True
                    txtTindakLanjut.Enabled = True
                    dtpTarget.Enabled = True
                    dtpHasilPenanganan.Enabled = True
                    txtUraianHasilPenanganan.Enabled = True

                    dtpAnalisa.BackColor = Color.LemonChiffon
                    txtAnalisa.BackColor = Color.LemonChiffon
                    dtpPenanganan.BackColor = Color.LemonChiffon
                    txtTindakLanjut.BackColor = Color.LemonChiffon
                    dtpTarget.BackColor = Color.LemonChiffon
                    dtpHasilPenanganan.BackColor = Color.LemonChiffon
                    txtUraianHasilPenanganan.BackColor = Color.LemonChiffon
                ElseIf StatusID.Trim = "WCFM" Then
                    dtpHasilVerifikasi.Enabled = True
                    rbAwalSdh.Enabled = True
                    rbAwalBlm.Enabled = True
                    rbAkhirSdh.Enabled = True
                    rbAkhirBlm.Enabled = True
                    txtAwalNotes.Enabled = True
                    txtAkhirNotes.Enabled = True

                    dtpHasilVerifikasi.BackColor = Color.LemonChiffon
                    txtAwalNotes.BackColor = Color.LemonChiffon
                    txtAkhirNotes.BackColor = Color.LemonChiffon

                ElseIf StatusID.Trim = "RBMA" Then
                    txtUraianKeluhan.Enabled = True
                    dtpInfoKeluhan.Enabled = True
                    cbxTypeKeluhan.Enabled = True

                    txtUraianKeluhan.BackColor = Color.LemonChiffon
                    cbxTypeKeluhan.BackColor = Color.LemonChiffon

                    lblRejectReason.Visible = True
                    txtRejectReason.Visible = True
                End If

            Case Else

                dtpInfoKeluhan.Enabled = False
                cbxTypeKeluhan.Enabled = False
                txtUraianKeluhan.Enabled = False

                dtpMarketing.Enabled = False
                txtNotesMarketing.Enabled = False
                txtPIC.Enabled = False

                dtpAnalisa.Enabled = False
                txtAnalisa.Enabled = False

                dtpPenanganan.Enabled = False
                txtTindakLanjut.Enabled = False
                dtpTarget.Enabled = False

                dtpHasilPenanganan.Enabled = False
                txtUraianHasilPenanganan.Enabled = False

                dtpHasilVerifikasi.Enabled = False
                rbAwalSdh.Enabled = False
                rbAwalBlm.Enabled = False
                txtAwalNotes.Enabled = False
                rbAkhirSdh.Enabled = False
                rbAkhirBlm.Enabled = False
                txtAkhirNotes.Enabled = False

                txtUraianKeluhan.Clear()
                txtNotesMarketing.Clear()
                txtAnalisa.Clear()
                txtTindakLanjut.Clear()
                txtUraianHasilPenanganan.Clear()
                txtAwalNotes.Clear()
                txtAkhirNotes.Clear()
                rbAwalSdh.Checked = True
                rbAwalBlm.Checked = False
                rbAkhirSdh.Checked = True
                rbAkhirBlm.Checked = False

                txtUraianKeluhan.BackColor = Color.DarkGray
                cbxTypeKeluhan.BackColor = Color.DarkGray
                dtpInfoKeluhan.BackColor = Color.DarkGray

                dtpMarketing.BackColor = Color.DarkGray
                txtNotesMarketing.BackColor = Color.DarkGray
                txtPIC.BackColor = Color.DarkGray

                dtpAnalisa.BackColor = Color.DarkGray
                txtAnalisa.BackColor = Color.DarkGray
                dtpPenanganan.BackColor = Color.DarkGray
                txtTindakLanjut.BackColor = Color.DarkGray
                dtpTarget.BackColor = Color.DarkGray
                dtpHasilPenanganan.BackColor = Color.DarkGray
                txtUraianHasilPenanganan.BackColor = Color.DarkGray

                dtpHasilVerifikasi.BackColor = Color.DarkGray
                txtAwalNotes.BackColor = Color.DarkGray
                txtAkhirNotes.BackColor = Color.DarkGray
        End Select

    End Sub

    Private Sub InsertData()
        Dim objTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim dc(0) As DataColumn
        Dim dr As DataRow

        'dc(0) = dtDetailOriginal.Columns("Item ID")
        'dtDetailOriginal.PrimaryKey = dc

        'txtNoUrut.Text = Generate_TranNo(Me.Name)
        'LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoUrut.Text, 3))

        Remarks_Stok = "Transaction : " & txtNoUrut.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        objTrans = conn.BeginTransaction("Trans")
        cmd.Transaction = objTrans

        'Select Case cb_category.SelectedItem
        '    Case "Division"
        '        StatusID = "WAFS"
        '    Case Else
        '        StatusID = "WAWA"
        'End Select
        StatusID = "WAMA"
        Dim lastDeptID As String = ""
        Dim i As Integer = 0
        Dim totRow As Integer
        Try
            Call SortTable(dtDetail, "Dept_ID")

            'txtNoUrut.Text = Generate_TranNo(Me.Name)
            'LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoUrut.Text, 3))
            totRow = dtDetail.Rows.Count
            For Each item As DataRow In dtDetail.Rows

                If Not item.RowState = DataRowState.Deleted Then
                    If i = 0 Then
                        txtNoUrut.Text = Generate_TranNo(Me.Name)
                        LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoUrut.Text, 3))
                        UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)

                        cmd.CommandText = "EXEC sp_Insert_Trans_Complaint_Hdr '" & _
                            txtNoUrut.Text.Trim & "', '" & _
                            txtNamaProj.Text.Trim & "', '" & _
                            dtp_complaint.Value & "', '" & _
                            txtCustID.Text.Trim & "', '" & _
                            txtAlamat.Text.Trim & "', '" & _
                            txtNamaDiterima.Text.Trim & "', '" & _
                            txtBagian.Text.Trim & "', '" & _
                            StatusID.Trim & "', '" & _
                            "Y" & "', '" & _
                            userlog.UserName & "'"

                        cmd.ExecuteNonQuery()
                    ElseIf i <> 0 And lastDeptID <> item("Dept_ID") Then

                        txtNoUrut.Text = Generate_TranNo(Me.Name)
                        LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoUrut.Text, 3))
                        UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)

                        cmd.CommandText = "EXEC sp_Insert_Trans_Complaint_Hdr '" & _
                              txtNoUrut.Text.Trim & "', '" & _
                              txtNamaProj.Text.Trim & "', '" & _
                              dtp_complaint.Value & "', '" & _
                              txtCustID.Text.Trim & "', '" & _
                              txtAlamat.Text.Trim & "', '" & _
                              txtNamaDiterima.Text.Trim & "', '" & _
                              txtBagian.Text.Trim & "', '" & _
                              StatusID.Trim & "', '" & _
                              "Y" & "', '" & _
                              userlog.UserName & "'"
                        cmd.ExecuteNonQuery()

                    End If

                    'If lastDeptID = item("Dept_ID") Or i = 0 Then
                    cmd.CommandText = "EXEC sp_Insert_Trans_Complaint_Dtl '" & _
                                                         txtNoUrut.Text & "', '" & _
                                                         item("Type ID") & "', '" & _
                                                         item("Tgl_Keluhan") & "', '" & _
                                                         item("Uraian_Keluhan") & "', '" & _
                                                         item("Tgl_Marketing") & "', '" & _
                                                         item("PIC") & "', '" & _
                                                         item("Note_Marketing") & "', '" & _
                                                         item("Tgl_Analisa") & "', '" & _
                                                         item("Analisa") & "', '" & _
                                                         item("Tgl_Penanganan") & "', '" & _
                                                         item("Tindak_Lanjut") & "', '" & _
                                                         item("Target") & "', '" & _
                                                         item("Tgl_Hasil") & "', '" & _
                                                         item("Uraian_Hasil") & "', '" & _
                                                         item("Tgl_Verifikasi") & "', '" & _
                                                         item("Verifikasi_Awal") & "', '" & _
                                                         item("Note_Awal") & "', '" & _
                                                         item("Verifikasi_Akhir") & "', '" & _
                                                         item("Note_Akhir") & "'"
                    cmd.ExecuteNonQuery()
                    'Else


                    'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    'Insert_Trans_History(txtEmployeeID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
                    ' End If

                    lastDeptID = item("Dept_ID").ToString.Trim
                    i += 1
                    MsgBox("No Urut : " & txtNoUrut.Text.Trim & " has been submitted")

                    StatusID = "WAMA"
                    InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri


                    InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to INBOX Purchasing

                    Insert_Trans_History(txtNoUrut.Text.Trim, Me.Name, "INSERT") 'Insert History transaction


                End If
            Next

            objTrans.Commit()
            conn.Close()

            'MsgBox("No Urut : " & txtNoUrut.Text.Trim & " has been submitted")
        Catch ex As Exception
            MsgBox("InsertData: " & ex.Message)
            conn.Close()
        End Try

    End Sub
    Public Function SortTable(ByRef mytable As DataTable, ByVal column As String)
        'Sorting a table for reals! By SiLentThReaD, AKA Numbchucks.

        'create a blank table. tablecopy is the name
        Dim tablecopy As New DataTable
        'make an exact copy of the table you passed in by reference, and
        'store it in your tablecopy table
        tablecopy = mytable.Copy()
        'clear the contents of the table you just passed in, because
        'you will soon fill it with newly sorted rows
        mytable.Clear()
        'create a rows array
        Dim foundRows() As DataRow
        'assign the foundrows array the values returned
        'from the select. In this case, I left the
        'filterexpression blank, because I want to get
        'everything. I all I need to change is the sort
        'order.
        foundRows = tablecopy.Select("", column + " asc")

        'iterate through each row and import them into
        'the table that you passed in by reference
        Dim dbrow As DataRow
        For Each dbrow In foundRows
            mytable.ImportRow(dbrow)
        Next

        'finally clear the contents of the tablecopy you created.
        tablecopy.Clear()

    End Function

    Private Sub UpdateData()
        Dim objTrans As SqlTransaction
        Dim dc(0) As DataColumn
        'Dim dr As DataRow

        'dc(0) = dtDetailOriginal.Columns("Item ID")
        'dtDetailOriginal.PrimaryKey = dc
        Remarks_Stok = "Transaction : " & txtNoUrut.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
        Price = 0

        If StatusTrans = "REJECT" Then
            Select Case StatusID.Trim
                Case "WAMA"
                    StatusID = "RBMA"
                Case "WCFM"
                    StatusID = "WCFP"
            End Select
        Else
            Select Case StatusID.Trim
                Case "WAMA"
                    StatusID = "WCFP"
                Case "WCFP"
                    StatusID = "WCFM"
                Case "WCFM"
                    StatusID = "CMP"
                Case "RBMA"
                    StatusID = "WAMA"
                Case Else
                    'If cb_category.SelectedItem = "Division" And (StatusID.Trim = "RBS" Or StatusID.Trim = "RBWA" Or StatusID.Trim = "RBWH") Then
                    '    StatusID = "WAFS"
                    'ElseIf cb_category.SelectedItem <> "Division" And (StatusID.Trim = "RBS" Or StatusID.Trim = "RBWA" Or StatusID.Trim = "RBWH") Then
                    '    StatusID = "WAWA"
                    'End If
            End Select
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()

            conn.Open()

            objTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = objTrans

            For Each item As DataRow In dtDetail.Rows
                Select Case item.RowState
                    Case DataRowState.Modified
                        cmd.CommandText = "EXEC sp_Update_Trans_Complaint_Dtl '" & _
                                          txtNoUrut.Text.Trim & "', '" & _
                                          item("Type ID") & "', '" & _
                                          item("Tgl_Keluhan") & "', '" & _
                                          item("Uraian_Keluhan") & "', '" & _
                                          item("Tgl_Marketing") & "', '" & _
                                          item("PIC") & "', '" & _
                                          item("Note_Marketing") & "', '" & _
                                          item("Tgl_Analisa") & "', '" & _
                                          item("Analisa") & "', '" & _
                                          item("Tgl_Penanganan") & "', '" & _
                                          item("Tindak_Lanjut") & "', '" & _
                                          item("Target") & "', '" & _
                                          item("Tgl_Hasil") & "', '" & _
                                          item("Uraian_Hasil") & "', '" & _
                                          item("Tgl_Verifikasi") & "', '" & _
                                          item("Verifikasi_Awal") & "', '" & _
                                          item("Note_Awal") & "', '" & _
                                          item("Verifikasi_Akhir") & "', '" & _
                                          item("Note_Akhir") & "'"
                        cmd.ExecuteNonQuery()
                    Case DataRowState.Added
                        cmd.CommandText = "EXEC sp_Insert_Trans_Complaint_Dtl '" & _
                                            txtNoUrut.Text & "', '" & _
                                            item("Type ID") & "', '" & _
                                            item("Tgl_Keluhan") & "', '" & _
                                            item("Uraian_Keluhan") & "', '" & _
                                            item("Tgl_Marketing") & "', '" & _
                                            item("PIC") & "', '" & _
                                            item("Note_Marketing") & "', '" & _
                                            item("Tgl_Analisa") & "', '" & _
                                            item("Analisa") & "', '" & _
                                            item("Tgl_Penanganan") & "', '" & _
                                            item("Tindak_Lanjut") & "', '" & _
                                            item("Target") & "', '" & _
                                            item("Tgl_Hasil") & "', '" & _
                                            item("Uraian_Hasil") & "', '" & _
                                            item("Tgl_Verifikasi") & "', '" & _
                                            item("Verifikasi_Awal") & "', '" & _
                                            item("Note_Awal") & "', '" & _
                                            item("Verifikasi_Akhir") & "', '" & _
                                            item("Note_Akhir") & "'"
                    Case DataRowState.Deleted
                        cmd.CommandText = "EXEC sp_Delete_Trans_Complaint_Dtl '" & _
                                                txtNoUrut.Text.Trim & "', '" & _
                                                item("Type") & "'"
                        cmd.ExecuteNonQuery()
                    Case Else
                        cmd.CommandText = "EXEC sp_Update_Trans_Complaint_Dtl '" & _
                                        txtNoUrut.Text.Trim & "', '" & _
                                        item("Type ID") & "', '" & _
                                        item("Tgl_Keluhan") & "', '" & _
                                        item("Uraian_Keluhan") & "', '" & _
                                        item("Tgl_Marketing") & "', '" & _
                                        item("PIC") & "', '" & _
                                        item("Note_Marketing") & "', '" & _
                                        item("Tgl_Analisa") & "', '" & _
                                        item("Analisa") & "', '" & _
                                        item("Tgl_Penanganan") & "', '" & _
                                        item("Tindak_Lanjut") & "', '" & _
                                        item("Target") & "', '" & _
                                        item("Tgl_Hasil") & "', '" & _
                                        item("Uraian_Hasil") & "', '" & _
                                        item("Tgl_Verifikasi") & "', '" & _
                                        item("Verifikasi_Awal") & "', '" & _
                                        item("Note_Awal") & "', '" & _
                                        item("Verifikasi_Akhir") & "', '" & _
                                        item("Note_Akhir") & "'"
                        cmd.ExecuteNonQuery()
                End Select
            Next
            If Reject_Reason = "" Then
                Reject_Reason = txtRejectReason.Text.Trim
            End If
            cmd.CommandText = "EXEC sp_Update_Trans_Complaint_Hdr '" & _
                              txtNoUrut.Text.Trim & "', '" & _
                              txtNamaProj.Text.Trim & "', '" & _
                              dtp_complaint.Value & "', '" & _
                              txtCustID.Text.Trim & "', '" & _
                              txtAlamat.Text.Trim & "', '" & _
                              txtNamaDiterima.Text.Trim & "', '" & _
                              txtBagian.Text.Trim & "', '" & _
                              Reject_Reason & "', '" & _
                              StatusID.Trim & "', '" & _
                              userlog.UserName & "'"
            cmd.ExecuteNonQuery()

            UpdatetoInbox(txtNoUrut.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txtNoUrut.Text.Trim, StatusID, GetDocCreator(txtNoUrut.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT"
                        'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        If StatusID.Trim = "WCFP" Then
                            InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, txtPIC.Text.Trim, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        Else
                            InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, GetDocCreator(txtNoUrut.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        End If

                    Case Else
                        'If GetDocCreator(txtNoUrut.Text.Trim) = userlog.UserName And StatusID.Trim = "WAMA" Then
                        '    InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        'Else
                        If StatusID.Trim = "WCFP" Then
                            InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, txtPIC.Text.Trim, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        ElseIf StatusID.Trim = "WAMA" Or StatusID.Trim = "WCFM" Then
                            InserttoInbox(txtNoUrut.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to NEXT APPROVAL


                        End If

                        'End If
                End Select
            End If


            Insert_Trans_History(txtNoUrut.Text.Trim, Me.Name, "UDPATE") 'Insert History transaction
            lbl_status.Text = GetStatus(StatusID) 'Get Status Description
            objTrans.Commit()
            conn.Close()

            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("No Urut: " & txtNoUrut.Text.Trim & " has been rejected")
                Case Else
                    If GetDocCreator(txtNoUrut.Text.Trim) = userlog.UserName Then
                        MsgBox("No Urut: " & txtNoUrut.Text.Trim & " has been submitted")
                    Else
                        MsgBox("No Urut: " & txtNoUrut.Text.Trim & " has been approved")
                    End If
            End Select

        Catch ex As Exception
            MsgBox("UpdateData: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteData()
        Try

            Dim ObjTrans As SqlTransaction
            If conn.State = ConnectionState.Closed Then conn.Open()

            ObjTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = ObjTrans

            Try
                StatusID = "CAP" 'cancelled by applicant

                cmd.CommandText = "EXEC sp_Update_Trans_Complaint_Hdr '" & _
                          txtNoUrut.Text & "', '" & _
                          txtNamaProj.Text.Trim & "', '" & _
                          dtp_complaint.Value & "', '" & _
                          txtCustID.Text.Trim & "', '" & _
                          txtAlamat.Text.Trim & "', '" & _
                          txtNamaDiterima.Text.Trim & "', '" & _
                          txtBagian.Text.Trim & "', '" & _
                          Reject_Reason & "', '" & _
                          StatusID & "', '" & _
                          userlog.UserName & "'"

                cmd.ExecuteNonQuery()

                UpdatetoInbox(txtNoUrut.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txtNoUrut.Text.Trim, StatusID, GetDocCreator(txtNoUrut.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txtNoUrut.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                conn.Close()
                MsgBox("No Urut : " & txtNoUrut.Text & " has been deleted", MsgBoxStyle.Information, "Information")
                Me.Close()
            Catch ex As Exception
                conn.Close()
                MsgBox(ex.Message)
            End Try

            Me.Close()
        Catch ex As Exception
            MsgBox("DeleteData: " & ex.Message)
        End Try
    End Sub

    Private Sub RetrieveData()
        Dim dtTableHdr As New DataTable
        Dim dtTableDtl As New DataTable
        Dim dt_cust As New DataTable
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Trans_Complaint_Hdr_ByKey '" & txtNoUrut.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableHdr)

            If dtTableHdr.Rows.Count = 0 Then Exit Sub

            txtNamaProj.Text = dtTableHdr.Rows(0).Item("Nama_Project")
            txtCustID.Text = dtTableHdr.Rows(0).Item("Cust_ID")
            'Get Customer Name
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                dt_cust.Clear()
                cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey  '" & txtCustID.Text.Trim & "'"
                DA.SelectCommand = cmd
                DA.Fill(dt_cust)

                If dt_cust.Rows.Count > 0 Then
                    txtCustName.Text = dt_cust.Rows(0).Item(GlobalVar.Fields.Cust_Name).ToString
                Else
                    txtCustName.Text = ""
                End If
            Catch ex As Exception
                conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
            dtp_complaint.Value = dtTableHdr.Rows(0).Item("Tanggal")
            txtAlamat.Text = dtTableHdr.Rows(0).Item("Alamat")
            txtNamaDiterima.Text = dtTableHdr.Rows(0).Item("Diterima_Nama")
            txtBagian.Text = dtTableHdr.Rows(0).Item("Diterima_Bagian")

            If Not IsDBNull(dtTableHdr.Rows(0).Item("Reason")) Then
                txtRejectReason.Text = dtTableHdr.Rows(0).Item("Reason")
            End If

            StatusID = dtTableHdr.Rows(0).Item("Status_ID")
            lbl_status.Text = GetStatus(StatusID)

            cmd.CommandText = "EXEC sp_Retrieve_Trans_Complaint_Dtl_ByPK '" & txtNoUrut.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableDtl)
            conn.Close()

            gvDetail.DataSource = dtTableDtl

            If dtTableDtl.Rows.Count = 0 Then Exit Sub
            dtDetail = dtTableDtl

            txtUraianKeluhan.Text = dtTableDtl.Rows(0).Item("Uraian_Keluhan").ToString
            cbxTypeKeluhan.SelectedValue = dtTableDtl.Rows(0).Item("Type ID").ToString
            dtpInfoKeluhan.Value = dtTableDtl.Rows(0).Item("Tgl_Keluhan").ToString

            'Select Case cb_category.SelectedItem
            '    Case "SPK"
            '        If conn.State = ConnectionState.Open Then conn.Close()
            '        conn.Open()
            '        cmd.CommandText = "EXEC sp_Retrieve_Trans_PHMarketing_Item_Dtl_BySPKNo '" & txtRefNo.Text.Trim & "'"
            '        DA.SelectCommand = cmd
            '        DA.Fill(dtDetailOriginal)
            '        conn.Close()
            '    Case "Order Pabrikasi"
            '        If conn.State = ConnectionState.Open Then conn.Close()
            '        conn.Open()
            '        cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
            '        DA.SelectCommand = cmd
            '        DA.Fill(dtDetailOriginal)
            '        conn.Close()
            'End Select

        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertJurnal()
        Dim JurnalID As String
        Dim LastSerial As Integer
        JurnalID = Generate_TranNo("Journal")
        LastSerial = CInt(Microsoft.VisualBasic.Right(JurnalID, 3))

        'Jurnal Header
        cmd.CommandText = "EXEC sp_Insert_Journal '" & JurnalID & "', '" & _
                    userlog.EmployeeID & "', '" & _
                    "Permintaan Bahan', '" & _
                    "', '" & _
                    txtNoUrut.Text & "', '" & _
                    "False', '" & _
                    "', '" & _
                    "False', '" & _
                    "', '" & _
                    userlog.UserName & "'"
        cmd.ExecuteNonQuery()

        'Select Case cb_category.SelectedItem

        '    Case "SPK"
        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            "162', '" & _
        '                            Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "0', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()

        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            "161', '" & _
        '                            "0', '" & _
        '                            Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()
        '    Case "Order Pabrikasi"
        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            "163', '" & _
        '                             Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "0', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()

        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            "161', '" & _
        '                            "0', '" & _
        '                            Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()
        '    Case "Division"
        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            cb_accountcode.SelectedValue & "', '" & _
        '                            Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "0', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()

        '        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
        '                            "161', '" & _
        '                            "0', '" & _
        '                            Replace(CStr(Price), ",", ".") & "', '" & _
        '                            "False', '" & _
        '                            userlog.UserName & "'"
        '        cmd.ExecuteNonQuery()
        'End Select
        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
    End Sub

    Function Validation() As Boolean
        Validation = True

        If txtNamaProj.Text.Trim = "" Then
            MsgBox("Please fill Nama Project", MsgBoxStyle.Information, "Information")
            txtNamaProj.Focus()
            Validation = False
            Exit Function
        End If

        If txtCustID.Text.Trim = "" And txtCustName.Text.Trim = "" Then
            MsgBox("Please fill Cust ID", MsgBoxStyle.Information, "Information")
            txtCustID.Focus()
            Validation = False
            Exit Function
        End If

        If txtAlamat.Text.Trim = "" Then
            MsgBox("Please fill Alamat", MsgBoxStyle.Information, "Information")
            txtCustID.Focus()
            Validation = False
            Exit Function
        End If

        If dtDetail.Rows.Count = 0 Then
            MsgBox("Please input Detail Item", MsgBoxStyle.Information, "Information")
            txtNoUrut.Focus()
            Validation = False
            Exit Function
        End If
    End Function

    Private Sub GetTypeComplaint()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.CommandText = "EXEC sp_Retrieve_Master_ComplainType"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            cbxTypeKeluhan.DataSource = dtTable
            cbxTypeKeluhan.DisplayMember = "ComplainType_Desc"
            cbxTypeKeluhan.ValueMember = "ComplainType_ID"
            If dtTable.Rows.Count <> 0 Then
                cbxTypeKeluhan.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox("GetComplainType: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub GetPIC()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.CommandText = "EXEC sp_Retrieve_Master_Employee_ByDeptID '" & cbxTypeKeluhan.SelectedValue & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            If dtTable.Rows.Count > 0 Then
                txtPIC.Text = dtTable.Rows(0).Item("Name")
            End If

        Catch ex As Exception
            MsgBox("Get PIC: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
#End Region

#Region "Event Handler"

    Private Sub gvDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDetail.CellClick
        If dtDetail.Rows.Count = 0 Then Exit Sub

        If gvDetail.CurrentRow.DataGridView(0, gvDetail.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Btn_cancel_Click(Nothing, Nothing)


        cbxTypeKeluhan.SelectedValue = gvDetail.CurrentRow.DataGridView(0, gvDetail.CurrentRow.Index).Value.ToString
        dtpInfoKeluhan.Value = gvDetail.CurrentRow.DataGridView(2, gvDetail.CurrentRow.Index).Value.ToString
        txtUraianKeluhan.Text = gvDetail.CurrentRow.DataGridView(3, gvDetail.CurrentRow.Index).Value.ToString

        'dtpMarketing.Value = gvDetail.CurrentRow.DataGridView(4, gvDetail.CurrentRow.Index).Value.ToString
        'txtPIC.Text = gvDetail.CurrentRow.DataGridView(5, gvDetail.CurrentRow.Index).Value.ToString
        If gvDetail.CurrentRow.DataGridView(5, gvDetail.CurrentRow.Index).Value.ToString <> "" Then
            txtPIC.Text = gvDetail.CurrentRow.DataGridView(5, gvDetail.CurrentRow.Index).Value.ToString
        End If
        If gvDetail.CurrentRow.DataGridView(6, gvDetail.CurrentRow.Index).Value.ToString <> "" Then
            txtNotesMarketing.Text = gvDetail.CurrentRow.DataGridView(6, gvDetail.CurrentRow.Index).Value.ToString
        End If
        If gvDetail.CurrentRow.DataGridView(4, gvDetail.CurrentRow.Index).Value <> "1/1/1900 12:00:00 AM" Then
            dtpMarketing.Value = gvDetail.CurrentRow.DataGridView(4, gvDetail.CurrentRow.Index).Value.ToString
        End If

        dtpAnalisa.Value = gvDetail.CurrentRow.DataGridView(7, gvDetail.CurrentRow.Index).Value.ToString
        txtAnalisa.Text = gvDetail.CurrentRow.DataGridView(8, gvDetail.CurrentRow.Index).Value.ToString
        dtpPenanganan.Value = gvDetail.CurrentRow.DataGridView(9, gvDetail.CurrentRow.Index).Value.ToString
        txtTindakLanjut.Text = gvDetail.CurrentRow.DataGridView(10, gvDetail.CurrentRow.Index).Value.ToString
        dtpTarget.Value = gvDetail.CurrentRow.DataGridView(11, gvDetail.CurrentRow.Index).Value.ToString
        dtpHasilPenanganan.Value = gvDetail.CurrentRow.DataGridView(12, gvDetail.CurrentRow.Index).Value.ToString
        txtUraianHasilPenanganan.Text = gvDetail.CurrentRow.DataGridView(13, gvDetail.CurrentRow.Index).Value.ToString
        dtpHasilVerifikasi.Value = gvDetail.CurrentRow.DataGridView(14, gvDetail.CurrentRow.Index).Value.ToString

        If gvDetail.CurrentRow.DataGridView(15, gvDetail.CurrentRow.Index).Value.ToString = "Y" Then
            rbAwalSdh.Checked = True
        Else
            rbAwalBlm.Checked = True
        End If
        txtAwalNotes.Text = gvDetail.CurrentRow.DataGridView(16, gvDetail.CurrentRow.Index).Value.ToString
        If gvDetail.CurrentRow.DataGridView(17, gvDetail.CurrentRow.Index).Value.ToString = "Y" Then
            rbAkhirSdh.Checked = True
        Else
            rbAkhirBlm.Checked = True
        End If
        txtAkhirNotes.Text = gvDetail.CurrentRow.DataGridView(18, gvDetail.CurrentRow.Index).Value.ToString

        txtIndexDetail.Text = gvDetail.CurrentRow.Index
        'If StatusID.Trim = "WAMA" Then
        '    StatusTransDetail = "UPDATE"
        '    Call SetButton()
        '    Call EnableDisableInputDetail()
        'End If
        'Txt_Qty.Text = gvDetail.CurrentRow.DataGridView(3, gvDetail.CurrentRow.Index).Value.ToString
        'Txt_QtyRec.Text = gvDetail.CurrentRow.DataGridView(4, gvDetail.CurrentRow.Index).Value.ToString
        'txt_ket.Text = gvDetail.CurrentRow.DataGridView(5, gvDetail.CurrentRow.Index).Value.ToString
    End Sub

    'Private Sub cb_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_category.SelectedIndexChanged
    '    If cb_category.SelectedItem = "Division" Then
    '        txtRefNo.Enabled = False
    '        cb_accountcode.Enabled = True
    '        txtRefNo.Clear()
    '    Else
    '        txtRefNo.Enabled = True
    '        cb_accountcode.Enabled = False
    '        cb_accountcode.SelectedValue = ""
    '    End If
    'End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txtUraianKeluhan.Text.Trim = "" Then Exit Sub
        StatusTransDetail = "UPDATE"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(0) As DataColumn
        'Dim da As Data.DataRow

        'dc(0) = dtDetail.Columns("Item ID")
        'dtDetail.PrimaryKey = dc

        If txtUraianKeluhan.Text.Trim = "" Then
            MessageBox.Show("Please choose one for deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If MessageBox.Show("Are you sure to delete this data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then

        '    da = dtDetail.Rows.Find(txtUraianKeluhan.Text)
        '    If da IsNot Nothing Then
        '        da.Delete()
        '        StatusTransDetail = "DELETE"
        '        Call SetButton()
        '        Call EnableDisableInputDetail()
        '        gvDetail.Focus()
        '    End If
        'End If
        If MessageBox.Show("Are you sure want to delete this detail ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            dtDetail.Rows(txtIndexDetail.Text).Delete()
            StatusTransDetail = "DELETE"
            Call SetButton()
            Call EnableDisableInputDetail()
            gvDetail.Focus()
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(0) As DataColumn
        Dim dr As Data.DataRow
        Dim dtTable As New DataTable

        dc(0) = dtDetail.Columns("Type ID")
        'dc(1) = dtDetail.Columns("Type")
        dtDetail.PrimaryKey = dc

        Select Case StatusTransDetail
            Case "INSERT"
                If txtUraianKeluhan.Text.Trim = "" Then
                    MsgBox("Uraian keluhan must be filled", MsgBoxStyle.Information, "Information")
                    txtUraianKeluhan.Focus()
                    Exit Sub
                End If

                dr = dtDetail.Rows.Find(cbxTypeKeluhan.SelectedValue)
                If dr IsNot Nothing Then
                    MsgBox("Please select another complaint type", MsgBoxStyle.Information, "Information")
                    Exit Sub
                End If

                'Try
                '    If conn.State = ConnectionState.Open Then conn.Close()
                '    conn.Open()
                '    cmd.CommandText = "EXEC sp_Retrieve_Trans_Complaint_Hdr_ByNo_Urut '" & txtNoUrut.Text.Trim & "'"
                '    DA.SelectCommand = cmd
                '    DA.Fill(dtTable)
                '    conn.Close()

                '    If dtTable.Rows.Count = 0 Then
                '        MsgBox("No Urut isn't exist in Master Data", MsgBoxStyle.Information, "Information")
                '        Exit Sub
                '    End If
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try

                '-----Add new row

                dr = dtDetail.NewRow

                'dr("No_Urut") = txtNoUrut.Text.Trim
                dr("Type ID") = cbxTypeKeluhan.SelectedValue
                dr("Type") = cbxTypeKeluhan.Text
                dr("Tgl_Keluhan") = dtpInfoKeluhan.Value
                dr("Uraian_Keluhan") = txtUraianKeluhan.Text.Trim
                dr("Tgl_Marketing") = dtpMarketing.Value
                dr("PIC") = txtPIC.Text.Trim
                dr("Note_Marketing") = txtNotesMarketing.Text.Trim
                dr("Tgl_Analisa") = dtpAnalisa.Value
                dr("Analisa") = txtAnalisa.Text.Trim
                dr("Tgl_Penanganan") = dtpPenanganan.Value
                dr("Tindak_Lanjut") = txtTindakLanjut.Text.Trim
                dr("Target") = dtpTarget.Value
                dr("Tgl_Hasil") = dtpHasilPenanganan.Value
                dr("Uraian_Hasil") = txtUraianHasilPenanganan.Text.Trim
                dr("Tgl_Verifikasi") = dtpHasilVerifikasi.Value

                'Get Department ID from Type Complain
                Dim dtDept As New DataTable
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                cmd.CommandText = "EXEC sp_Retrieve_Mapping_ComplainPIC '" & cbxTypeKeluhan.SelectedValue & "'"
                DA.SelectCommand = cmd
                DA.Fill(dtDept)
                If dtDept.Rows.Count > 0 Then
                    dr("Dept_ID") = dtDept.Rows(0).Item("Department_ID").ToString.Trim
                End If

                If rbAwalSdh.Checked Then
                    dr("Verifikasi_Awal") = "Y"
                Else
                    dr("Verifikasi_Awal") = "N"
                End If

                dr("Note_Awal") = txtAwalNotes.Text.Trim
                If rbAwalSdh.Checked Then
                    dr("Verifikasi_Akhir") = "Y"
                Else
                    dr("Verifikasi_Akhir") = "N"
                End If
                dr("Note_Akhir") = txtAkhirNotes.Text.Trim

                dtDetail.Rows.Add(dr)

            Case "UPDATE"

                If txtUraianKeluhan.Text.Trim = "" Then
                    MsgBox("Uraian keluhan must be filled", MsgBoxStyle.Information, "Information")
                    txtUraianKeluhan.Focus()
                    Exit Sub
                End If
                dr = dtDetail.Rows(txtIndexDetail.Text.Trim)
                dr("Type ID") = cbxTypeKeluhan.SelectedValue
                dr("Type") = cbxTypeKeluhan.Text
                dr("Tgl_Keluhan") = dtpInfoKeluhan.Value
                dr("Uraian_Keluhan") = txtUraianKeluhan.Text.Trim
                dr("Tgl_Marketing") = dtpMarketing.Value
                dr("PIC") = txtPIC.Text
                dr("Note_Marketing") = txtNotesMarketing.Text.Trim
                dr("Tgl_Analisa") = dtpAnalisa.Value
                dr("Analisa") = txtAnalisa.Text.Trim
                dr("Tgl_Penanganan") = dtpPenanganan.Value
                dr("Tindak_Lanjut") = txtTindakLanjut.Text.Trim
                dr("Target") = dtpTarget.Value
                dr("Tgl_Hasil") = dtpHasilPenanganan.Value
                dr("Uraian_Hasil") = txtUraianHasilPenanganan.Text.Trim
                dr("Tgl_Verifikasi") = dtpHasilVerifikasi.Value

                If rbAwalSdh.Checked Then
                    dr("Verifikasi_Awal") = "Y"
                Else
                    dr("Verifikasi_Awal") = "N"
                End If
                dr("Note_Awal") = txtAwalNotes.Text.Trim

                If rbAkhirSdh.Checked Then
                    dr("Verifikasi_Akhir") = "Y"
                Else
                    dr("Verifikasi_Akhir") = "N"
                End If
                dr("Note_Akhir") = txtAkhirNotes.Text.Trim

                'Get Department ID from Type Complain
                Dim dtDept As New DataTable
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                cmd.CommandText = "EXEC sp_Retrieve_Mapping_ComplainPIC '" & dr("Type ID") & "'"
                DA.SelectCommand = cmd
                DA.Fill(dtDept)
                If dtDept.Rows.Count > 0 Then
                    dr("Dept_ID") = dtDept.Rows(0).Item("Department_ID").ToString.Trim
                End If

        End Select
        gvDetail.DataSource = dtDetail
        StatusTransDetail = "SAVE"
        Call SetButton()
        Call EnableDisableInputDetail()
        Call SetColumnVisible()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            SetToolTip()
            EnableDisableInput(True)
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to submit this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Validation() = False Then Exit Sub

                Select Case StatusTrans
                    Case TransStatus.NewStatus
                        Call InsertData()
                    Case TransStatus.EditStatus
                        Call UpdateData()
                End Select

                Me.Close()
                Frm_ViewComplaint.Show()
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            Frm_Complaint_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "APPROVE"
            If Validation() = False Then Exit Sub

            Call UpdateData()
            Call Frm_Complaint_Load(False, e)
        End If
    End Sub

    Private Sub ts_reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_reject.Click

        Dim frmReason As New Frm_Reason
        If MessageBox.Show("Are you sure to Reject this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "REJECT"
            If Validation() = False Then Exit Sub
            'Reject_Reason = InputBox("Test Input Box", "Reject Reason")
            frmReason.ShowDialog()
            If frmReason.Flag = "OK" Then
                If frmReason.txtReason.Text.ToString.Trim <> "" Then
                    Reject_Reason = frmReason.txtReason.Text.ToString.Trim
                    Call UpdateData()
                    Call Frm_Complaint_Load(False, e)
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                Call Frm_Complaint_Load(False, e)
            End If
        End If
    End Sub


    Private Sub Frm_Complaint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case CallerForm
            Case "INBOX"
                Dim frmChild As New FrmInbox
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormInbox" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Case Else
                Dim frmChild As New Frm_ViewComplaint
                For Each f As Form In Me.MdiChildren
                    If f.Name = "Form_ViewComplaint" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select


    End Sub

    Private Sub Frm_Complaint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_edit, ts_delete, ts_save, ts_cancel, Nothing, ts_approve, ts_reject)
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Call GetTypeComplaint()

        If txtNoUrut.Text.ToString.Trim <> "" Then 'Dipanggil dari View

            Call RetrieveData()

            If CheckAuthorisasi(txtNoUrut.Text.ToString.Trim, userlog.UserName) = True Then
                StatusTrans = TransStatus.EditStatus
                StatusTransDetail = "CANCEL"
                Call GetPIC()
                Call EnableDisableInput(True)
                Call EnableDisableInputDetail()
                Call SetToolTip()
                Call SetButton()
                Call SetDate()
                Call SetColumnVisible()
            Else
                StatusTransDetail = ""
                StatusTrans = ""
                Call EnableDisableInput(False)
                Call EnableDisableInputDetail()
                Call SetToolTip()
                Call SetButton()
                ' Call SetColumnVisible()
            End If

        Else
            lbl_status.Text = GetStatus("DRAFT")
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = "CANCEL"
            Call EnableDisableInput(True)
            Call EnableDisableInputDetail()
            Call SetToolTip()
            Call SetButton()
            Call SetColumnDetail()
            Call SetDate()
            'Call SetColumnVisible()
        End If
    End Sub

    Private Sub txtCustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustID.KeyDown
        Dim dt_Cust As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Cust_Id,Nama,Alamat,Deskripsi,Telp,Contact_Person from Master_Customer where active_flag = 'Y' ", "Cust_Id", "Nama", "Alamat", "Deskripsi", "Telp", "Contact_Person")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txtCustID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtCustName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txtAlamat.Focus()
                End If
            Catch ex As Exception
                conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtCustID.Text.Trim <> "" Then
                Try
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    dt_Cust.Clear()
                    cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey  '" & txtCustID.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dt_Cust)

                    If dt_Cust.Rows.Count > 0 Then
                        txtCustName.Text = dt_Cust.Rows(0).Item(GlobalVar.Fields.Cust_Name).ToString
                        txtAlamat.Focus()
                    Else
                        MessageBox.Show("Customer ini tidak ditemukan. Pastikan ID Customer yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    conn.Close()
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End Try
            End If

        End If
        conn.Close()
    End Sub
#End Region

    Private Sub txtNamaDiterima_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNamaDiterima.KeyDown
        Dim sql As String
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                sql = "EXEC [sp_Retrieve_Master_Employee]"
                cmd.CommandText = sql

                CallandGetSearchData(sql, "Employee_ID", "Employee_Info", "Name", "Department_Name")

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtNamaDiterima.Text = frmSearch.txtResult1.Text.Trim
                    txtBagian.Text = frmSearch.txtResult4.Text.Trim
                End If
            End If
        End If
    End Sub
End Class