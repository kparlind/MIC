Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmOrderMaintance

#Region "Variable Declaration"
    Private conn As New SqlConnection
    Private cmd As New SqlCommand
    Private DA As New SqlDataAdapter
    Private StatusTrans As String
    Private StatusID As String
    Private dtCustomer As New DataTable
    Private dc(0) As DataColumn
    Private dr As DataRow
    Private RejectReason As String = ""
    Private frmReason As New Frm_Reason

    Public CallerForm As String
    Public ViewFormName As String
#End Region

#Region "Function & Procedure"

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
                ts_delete.Visible = False

                If GetDocCreator(txt_transno.Text.Trim) = userlog.UserName Then
                    ts_save.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                Else
                    ts_save.Visible = False
                    ts_reject.Visible = True
                    ts_approve.Visible = True
                End If

            Case "READ"
                ts_edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False

            Case Else
                If GetDocCreator(txt_transno.Text.Trim) = userlog.UserName Then
                    ts_delete.Visible = True
                Else
                    ts_delete.Visible = False
                End If

                ts_edit.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
        End Select
    End Sub

    Private Sub RetrieveCustomer()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            dtCustomer.Clear()

            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Master_Customer"
            DA.SelectCommand = cmd
            DA.Fill(dtCustomer)
            conn.Close()

            dc(0) = dtCustomer.Columns("Cust_ID")
            dtCustomer.PrimaryKey = dc


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EnableDisableInput(ByVal boo As Boolean)

        Select Case boo
            Case True
                dtp_OrderDate.Enabled = True
                txt_Location.ReadOnly = False
                txt_Location.ForeColor = Color.Black
                txt_Location.BackColor = Color.White
                txt_PIC.ReadOnly = False
                txt_PIC.ForeColor = Color.Black
                txt_PIC.BackColor = Color.White
                txt_Remark.ReadOnly = False
                txt_Remark.ForeColor = Color.Black
                txt_Remark.BackColor = Color.White
                txt_Telephone.ReadOnly = False
                txt_Telephone.ForeColor = Color.Black
                txt_Telephone.BackColor = Color.White
                txt_CustomerID.ReadOnly = False
                txt_CustomerID.ForeColor = Color.Black
                txt_CustomerID.BackColor = Color.White
                txt_ProjectNo.ReadOnly = False
                txt_ProjectNo.ForeColor = Color.Black
                txt_ProjectNo.BackColor = Color.White
            Case False
                dtp_OrderDate.Enabled = False
                txt_Location.ReadOnly = True
                txt_Location.ForeColor = Color.Gray
                txt_Location.BackColor = Color.LightGray
                txt_PIC.ReadOnly = True
                txt_PIC.ForeColor = Color.Gray
                txt_PIC.BackColor = Color.LightGray
                txt_Remark.ReadOnly = True
                txt_Remark.ForeColor = Color.Gray
                txt_Remark.BackColor = Color.LightGray
                txt_Telephone.ReadOnly = True
                txt_Telephone.ForeColor = Color.Gray
                txt_Telephone.BackColor = Color.LightGray
                txt_CustomerID.ReadOnly = True
                txt_CustomerID.ForeColor = Color.Gray
                txt_CustomerID.BackColor = Color.LightGray
                txt_ProjectNo.ReadOnly = True
                txt_ProjectNo.ForeColor = Color.Gray
                txt_ProjectNo.BackColor = Color.LightGray
        End Select
    End Sub

    Private Sub InsertData()
        Dim LastSerial As Integer
        txt_transno.Text = Generate_TranNo(Me.Name)
        LastSerial = CInt(Microsoft.VisualBasic.Right(txt_transno.Text, 3))

        StatusID = "WAFS"

        Try
            If conn.State = ConnectionState.Open Then conn.Close()

            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Insert_Trans_OrderMaint '" & txt_transno.Text & "', " & _
                                                           "'" & Format(dtp_OrderDate.Value, "MM-dd-yyyy") & "', " & _
                                                           "'" & txt_CustomerID.Text.Trim & "', " & _
                                                           "'" & txt_ProjectNo.Text.Trim & "', " & _
                                                           "'" & txt_Location.Text.Trim & "', " & _
                                                           "'" & txt_PIC.Text.Trim & "', " & _
                                                           "'" & txt_Telephone.Text.Trim & "', " & _
                                                           "'" & txt_Remark.Text.Trim & "', " & _
                                                           "'" & StatusID & "', " & _
                                                           "'" & RejectReason & "', " & _
                                                           "'Y', " & _
                                                           "'" & userlog.UserName & "', " & _
                                                           "'" & userlog.UserName & "'"

            cmd.ExecuteNonQuery()
            conn.Close()

            InserttoInbox(txt_transno.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri
            InserttoInbox(txt_transno.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to INBOX Purchasing
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txt_transno.Text.Trim, Me.Name, "INSERT") 'Insert History transaction     

            MessageBox.Show("Transaction No. : " & txt_transno.Text.Trim & " has been Submitted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateData()
        Try

            Select Case StatusTrans
                Case "REJECT"
                    StatusID = "RBS"
                Case Else
                    If StatusID = "WAFS" Then
                        StatusID = "CMP"
                    Else
                        StatusID = "WAFS"
                    End If
            End Select

            If conn.State = ConnectionState.Open Then conn.Close()

            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Update_Trans_OrderMaint  '" & txt_transno.Text & "', " & _
                                                       "'" & Format(dtp_OrderDate.Value, "MM-dd-yyyy") & "', " & _
                                                       "'" & txt_CustomerID.Text.Trim & "', " & _
                                                       "'" & txt_ProjectNo.Text.Trim & "', " & _
                                                       "'" & txt_Location.Text.Trim & "', " & _
                                                       "'" & txt_PIC.Text.Trim & "', " & _
                                                       "'" & txt_Telephone.Text.Trim & "', " & _
                                                       "'" & txt_Remark.Text.Trim & "', " & _
                                                       "'" & StatusID & "', " & _
                                                       "'" & RejectReason & "', " & _
                                                       "'Y', " & _
                                                       "'" & userlog.UserName & "'"


            cmd.ExecuteNonQuery()
            conn.Close()
            UpdatetoInbox(txt_transno.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_transno.Text.Trim, StatusID, GetDocCreator(txt_transno.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT"
                        'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        InserttoInbox(txt_transno.Text.Trim, userlog.UserName, GetDocCreator(txt_transno.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                    Case Else
                        If GetDocCreator(txt_transno.Text.Trim) = userlog.UserName Then
                            InserttoInbox(txt_transno.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        Else
                            InserttoInbox(txt_transno.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        End If
                End Select
            End If
            Insert_Trans_History(txt_transno.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

            conn.Close()
            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("Transaction : " & txt_transno.Text.Trim & " has been Rejected")
                Case Else
                    If GetDocCreator(txt_transno.Text.Trim) = userlog.UserName Then
                        MsgBox("Transaction : " & txt_transno.Text.Trim & " has been Submitted")
                    Else
                        MsgBox("Transaction : " & txt_transno.Text.Trim & " has been Approved")
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteData()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            StatusID = "CAP"
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Update_Trans_OrderMaint  '" & txt_transno.Text & "', " & _
                                               "'" & Format(dtp_OrderDate.Value, "MM-dd-yyyy") & "', " & _
                                               "'" & txt_CustomerID.Text.Trim & "', " & _
                                               "'" & txt_ProjectNo.Text.Trim & "', " & _
                                               "'" & txt_Location.Text.Trim & "', " & _
                                               "'" & txt_PIC.Text.Trim & "', " & _
                                               "'" & txt_Telephone.Text.Trim & "', " & _
                                               "'" & txt_Remark.Text.Trim & "', " & _
                                               "'" & StatusID & "', " & _
                                               "'" & RejectReason & "', " & _
                                               "'Y', " & _
                                               "'" & userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            UpdatetoInbox(txt_transno.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_transno.Text.Trim, StatusID, GetDocCreator(txt_transno.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            Insert_Trans_History(txt_transno.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

            MsgBox("Transaction No : " & txt_transno.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RetrieveData()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Trans_OrderMaintance_ByKey 'By Order No', '" & txt_transno.Text.Trim & "', '', '01-01-9999', '01-01-9999'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Sub
            txt_CustomerID.Text = dtTable.Rows(0).Item("Customer ID")
            txt_CustomerName.Text = dtTable.Rows(0).Item("Customer Name")
            txt_ProjectNo.Text = dtTable.Rows(0).Item("Project No")
            dtp_OrderDate.Value = dtTable.Rows(0).Item("Order Date")
            txt_Location.Text = dtTable.Rows(0).Item("Location")
            txt_PIC.Text = dtTable.Rows(0).Item("PIC")
            txt_Remark.Text = dtTable.Rows(0).Item("Remarks")
            txt_Telephone.Text = dtTable.Rows(0).Item("Telepon")
            txt_Reason.Text = dtTable.Rows(0).Item("Reject Reason")
            lbl_Status.Text = GetStatus(dtTable.Rows(0).Item("Status ID")).Trim
            StatusID = dtTable.Rows(0).Item("Status ID").ToString.Trim
            RejectReason = dtTable.Rows(0).Item("Reject Reason")
        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try
    End Sub

    Private Function ValidationInput() As Boolean
        Dim dtTable As New DataTable

        ValidationInput = True
        If dtp_OrderDate.ToString.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Date!", MsgBoxStyle.Information, "Information")
            dtp_OrderDate.Focus()
            Exit Function
        End If

        If txt_CustomerID.Text.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Customer ID!", MsgBoxStyle.Information, "Information")
            txt_CustomerID.Focus()
            Exit Function
        Else
            dr = dtCustomer.Rows.Find(txt_CustomerID.Text.Trim)
            If dr Is Nothing Then
                ValidationInput = False
                MsgBox("Invalid Customer ID", MsgBoxStyle.Information, "Information")
                txt_CustomerID.Focus()
                Exit Function
            End If
        End If

        If txt_ProjectNo.Text.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Project ID!", MsgBoxStyle.Information, "Information")
            txt_CustomerID.Focus()
            Exit Function
        Else
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Trans_Projects_BasedOnCustomerID '" & txt_CustomerID.Text.Trim & "', '" & txt_ProjectNo.Text.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            If dtTable.Rows.Count = 0 Then
                ValidationInput = False
                MsgBox("Invalid Project ID", MsgBoxStyle.Information, "Information")
                txt_CustomerID.Focus()
                Exit Function
            End If
        End If

        If txt_Location.Text.ToString.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Location!", MsgBoxStyle.Information, "Information")
            txt_Location.Focus()
            Exit Function
        End If

        If txt_PIC.Text.ToString.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Contact Person!", MsgBoxStyle.Information, "Information")
            txt_PIC.Focus()
            Exit Function
        End If

        If txt_Telephone.Text.ToString.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Telephone!", MsgBoxStyle.Information, "Information")
            txt_Telephone.Focus()
            Exit Function
        End If
    End Function

#End Region

#Region "Event Handler"

    Private Sub frmOrderMaintance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            Case "BINGKAI"
                Dim frmChild As New frmBingkai
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FrmBIngkai" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Case Else
                Dim frmChild As New frmOrderMaintanceView
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormOrderMaintanceView" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()

        End Select
    End Sub

    Private Sub frmOrderMaintance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Call RetrieveCustomer()

        If txt_transno.Text <> "" Then

            Call RetrieveData()

            If CheckAuthorisasi(txt_transno.Text.ToString.Trim, userlog.UserName) = True Then
                StatusTrans = TransStatus.NoStatus
            Else
                StatusTrans = "READ"
            End If

            Call EnableDisableInput(False)
            Call SetToolTip()
        Else
            StatusTrans = TransStatus.NewStatus
            StatusID = "DRAFT"
            lbl_Status.Text = "DRAFT"
            Call SetToolTip()
            Call EnableDisableInput(True)
        End If

    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If ValidationInput() = False Then Exit Sub

            Select Case StatusTrans
                Case TransStatus.NewStatus
                    Call InsertData()
                Case TransStatus.EditStatus
                    Call UpdateData()
            End Select

            StatusTrans = TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
            Call frmOrderMaintance_Load(False, e)

        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            Call SetToolTip()
            Call EnableDisableInput(True)
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call DeleteData()
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            Call frmOrderMaintance_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If ValidationInput() = False Then Exit Sub

            StatusTrans = "APPROVE"
            Call UpdateData()
            Call frmOrderMaintance_Load(False, e)
        End If
    End Sub

    Private Sub ts_reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_reject.Click
        If MessageBox.Show("Are you sure to Reject this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
       frmReason.StartPosition = FormStartPosition.CenterScreen
            frmReason.ShowDialog()
            If frmReason.Flag = "OK" Then
                If frmReason.txtReason.Text.ToString.Trim <> "" Then
                    If ValidationInput() = False Then Exit Sub

                    RejectReason = frmReason.txtReason.Text.ToString.Trim
                    StatusTrans = "REJECT"
                    Call UpdateData()
                    Call frmOrderMaintance_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If
    End Sub

    Private Sub txt_Telephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Telephone.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_CustomerID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CustomerID.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("EXEC sp_Retrieve_Master_Customer", "Cust_ID", "Nama", "", "", "")
            txt_CustomerID.Text = frmSearch.txtResult1.Text.Trim
            txt_CustomerName.Text = frmSearch.txtResult2.Text.Trim
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_CustomerID.Text.Trim = "" Then
                MsgBox("Please fill Customer ID")
                txt_CustomerID.Focus()
                Exit Sub
            End If

            dr = dtCustomer.Rows.Find(txt_CustomerID.Text.Trim)
            If dr IsNot Nothing Then
                txt_CustomerID.Text = dr("Cust_ID")
                txt_CustomerName.Text = dr("Nama")
            Else
                MsgBox("Invalid Customer ID")
                txt_CustomerID.Focus()
            End If
        End If
    End Sub

    Private Sub txt_ProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ProjectNo.KeyDown
        If e.KeyCode = Keys.F1 Then

            If txt_CustomerID.Text.Trim = "" Then
                MsgBox("Please fill Customer ID", MsgBoxStyle.Information, "Information")
                txt_CustomerID.Focus()
                Exit Sub
            End If
            CallandGetSearchData("EXEC sp_Retrieve_Trans_Projects_BasedOnCustomerID '" & txt_CustomerID.Text.Trim & "', ''", "Project_No", "PHM_No", "Go Live", "Garansi (Bulan)", "Sisa Masa Garansi (Hari)")
            txt_ProjectNo.Text = frmSearch.txtResult1.Text.Trim
        End If
    End Sub

#End Region

End Class