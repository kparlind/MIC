Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRequestPembelianBrg

#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Public CallerForm As String
    Private StatusTrans As String
    Private RequestType As String
    Private StatusTransDetail As String
    Private dtDetail As New DataTable
    Private StatusID As String
    Private dtDepartment As New DataTable
    Private dtItem As New DataTable
    Private dtOverStock As New DataTable
    Private RejectReason As String = ""
    Private frmReason As New Frm_Reason
    Public ViewFormName As String
#End Region

#Region "Function & Procedure - Main"

    Private Sub RetrieveDepartment()
        Dim dc(0) As DataColumn

        If Conn.State = ConnectionState.Open Then Conn.Close()
        dtDepartment.Clear()

        Conn.Open()
        Cmd.CommandText = "SELECT Department_ID, Department_Name FROM Master_Department WHERE Active_Flag = 'Y'"
        DA.SelectCommand = Cmd
        DA.Fill(dtDepartment)
        Conn.Close()

        dc(0) = dtDepartment.Columns("Department_ID")
        dtDepartment.PrimaryKey = dc
    End Sub

    Private Sub RetrieveOverlimit()
        Dim strOverLimit As String
        Dim i As Integer

        Try
            dtOverStock.Clear()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Cmd.CommandText = "EXEC sp_Retrieve_Trans_PR_Dtl_Overlimit '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtOverStock)
            Conn.Close()

            If dtOverStock.Rows.Count = 0 Then Exit Sub

            i = 0
            strOverLimit = ""
            For Each dtl As DataRow In dtOverStock.Rows
                If CDbl(dtl("Max_Stock")) < (CDbl(dtl("Qty_Request")) + CDbl(dtl("Qty_Current"))) Then
                    i += 1
                    strOverLimit = strOverLimit & CStr(i) & ". " & Trim(CStr(dtl("Item_ID"))) & " = " & _
                                CStr(CDbl(dtl("Qty_Request")) + CDbl(dtl("Qty_Current")) - CDbl(dtl("Max_Stock"))) & " " & dtl("UoM")
                End If
            Next

            If strOverLimit.Trim = "" Then Exit Sub

            lbl_OverLimit.Text = "Stock OVERLIMIT: " & strOverLimit
        Catch ex As Exception
            MsgBox("RetrieveOverlimit: " & ex.Message)
        End Try
    End Sub

    Private Sub GetRequesterDept()
        Dim dtTable As New DataTable

        Cmd.CommandText = "EXEC sp_retreiveEmployee_ByUserName '" & txt_Requester.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtTable)

        txt_department.Text = dtTable.Rows(0).Item("Department_Name").ToString
    End Sub

    Private Sub GetItemData(ByVal ItemId As String)
        dtItem.Clear()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dtItem.Clear()
            Cmd.CommandText = "EXEC sp_Retrieve_MasterItem_Hdr_ByItemID '" & ItemId & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtItem)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        Select Case boo
            Case False
                dt_PRDate.Enabled = False
                txt_remarks.ReadOnly = True
                txt_ProjectNo.ReadOnly = True

                txt_remarks.ForeColor = Color.Gray
                txt_ProjectNo.ForeColor = Color.Gray
                txt_remarks.BackColor = Color.LightGray
                txt_ProjectNo.BackColor = Color.LightGray
            Case True
                dt_PRDate.Enabled = True
                txt_remarks.ReadOnly = False
                txt_ProjectNo.ReadOnly = False

                txt_remarks.ForeColor = Color.Black
                txt_ProjectNo.ForeColor = Color.Black
                txt_remarks.BackColor = Color.White
                txt_ProjectNo.BackColor = Color.White
        End Select

        Select Case StatusTrans
            Case TransStatus.NewStatus
                GroupBox1.Enabled = True
            Case Else
                GroupBox1.Enabled = False
        End Select
    End Sub

    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                ts_Edit.Visible = False
                ts_save.Visible = True
                ts_cancel.Visible = True
                ts_delete.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case TransStatus.EditStatus
                ts_Edit.Visible = False
                ts_cancel.Visible = True

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                    ts_save.Visible = True
                    ts_delete.Visible = False
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                Else
                    ts_save.Visible = False
                    ts_delete.Visible = False
                    ts_reject.Visible = True
                    ts_approve.Visible = True
                End If
            Case "READ"
                ts_Edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case Else

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName And StatusID.Trim <> "WFPP" Then
                    ts_delete.Visible = True
                Else
                    ts_delete.Visible = False
                End If

                ts_Edit.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
        End Select
    End Sub

    Private Sub SetGrid_Item()
        gv_PRDtl.Columns(0).Width = 80
        gv_PRDtl.Columns(1).Width = 300
        gv_PRDtl.Columns(2).Width = 50
        gv_PRDtl.Columns(3).Width = 50
        gv_PRDtl.Columns(4).Width = 300
    End Sub

    Private Sub SetGrid_Jasa()
        gv_PRDtl.Columns(0).Width = 60
        gv_PRDtl.Columns(1).Width = 300
        gv_PRDtl.Columns(2).Width = 300
    End Sub

    Private Sub SetButtonItem()
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
            Case Else
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = False
                btn_delete.Enabled = False
                Btn_cancel.Enabled = False
        End Select
    End Sub

    Private Sub SetButtonJasa()
        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = True
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = True
            Case "UPDATE"
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = True
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = True
            Case "SAVE"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case "DELETE"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case "CANCEL"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case Else
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = False
        End Select
    End Sub

    Private Sub SetColumnDetail()
        dtDetail.Reset()
        Select Case RequestType
            Case "Pembelian Jasa"
                dtDetail.Columns.Add("Jasa ID")
                dtDetail.Columns.Add("Jasa Name")
                dtDetail.Columns.Add("Information")
            Case Else
                dtDetail.Columns.Add("Item ID")
                dtDetail.Columns.Add("Item Name")
                dtDetail.Columns.Add("UoM")
                dtDetail.Columns.Add("Qty")
                dtDetail.Columns.Add("Information")
        End Select

    End Sub

    Private Sub SetColumnOverStock()
        dtOverStock.Columns.Add("Item_ID")
        dtOverStock.Columns.Add("Max_Stock")
        dtOverStock.Columns.Add("Qty_Current")
        dtOverStock.Columns.Add("UoM")
        dtOverStock.Columns.Add("Qty_Request")
    End Sub

    Private Sub EnableDisableInputDetailItem()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                txt_remarksItem.Clear()

                txt_ItemID.Enabled = True
                Txt_Qty.Enabled = True
                txt_remarksItem.Enabled = True

                txt_ItemID.BackColor = Color.LemonChiffon
                txt_remarksItem.BackColor = Color.LemonChiffon
                Txt_Qty.BackColor = Color.LemonChiffon
            Case "UPDATE"
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = True
                txt_remarksItem.Enabled = True

                txt_ItemID.BackColor = Color.DarkGray
                txt_remarksItem.BackColor = Color.LemonChiffon
                Txt_Qty.BackColor = Color.LemonChiffon

            Case Else
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = False
                txt_remarksItem.Enabled = False

                txt_ItemID.BackColor = Color.DarkGray
                txt_remarksItem.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray

                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                txt_remarksItem.Clear()
        End Select

    End Sub

    Private Sub EnableDisableInputDetailJasa()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_JasaID.Clear()
                txt_JasaName.Clear()
                txt_RemarksJasa.Clear()

                txt_JasaID.Enabled = True
                txt_RemarksJasa.Enabled = True

                txt_JasaID.BackColor = Color.LemonChiffon
                txt_RemarksJasa.BackColor = Color.LemonChiffon
            Case "UPDATE"
                txt_JasaID.Enabled = False
                txt_RemarksJasa.Enabled = True

                txt_JasaID.BackColor = Color.DarkGray
                txt_RemarksJasa.BackColor = Color.LemonChiffon

            Case Else
                txt_JasaID.Enabled = False
                txt_RemarksJasa.Enabled = False

                txt_JasaID.BackColor = Color.DarkGray
                txt_RemarksJasa.BackColor = Color.DarkGray

                txt_JasaID.Clear()
                txt_JasaName.Clear()
                txt_RemarksJasa.Clear()
        End Select

    End Sub

    Private Sub RetrieveData()
        Dim dtTableHdr As New DataTable
        Dim dtTableDtl As New DataTable

        Try
            dtDetail.Clear()
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Cmd.CommandText = "EXEC sp_Retreive_trans_PR_by_PRNo '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTableHdr)

            If dtTableHdr.Rows.Count = 0 Then Exit Sub

            dt_PRDate.Value = dtTableHdr.Rows(0).Item("PR_Date")
            txt_Requester.Text = dtTableHdr.Rows(0).Item("Requester").ToString.Trim
            txt_department.Text = dtTableHdr.Rows(0).Item("Department_Name")
            txt_remarks.Text = dtTableHdr.Rows(0).Item("Remarks").ToString.Trim
            txt_ProjectNo.Text = dtTableHdr.Rows(0).Item("DocRef").ToString.Trim
            StatusID = dtTableHdr.Rows(0).Item("Status_ID").ToString.Trim
            RejectReason = dtTableHdr.Rows(0).Item("Reject_Reason").ToString.Trim
            lbl_status.Text = GetStatus(StatusID)
            txt_Reason.Text = dtTableHdr.Rows(0).Item("Reject_Reason").ToString.Trim

            If StatusID.Trim = "WFPP" Then
                ts_save.Text = "Confirm"
            End If

            Select Case dtTableHdr.Rows(0).Item("Type_Request").ToString.Trim
                Case "Pembelian Jasa"
                    rb_jasa.Checked = True
                    P_waPembelianBrg.Visible = False
                    P_waPembelianJasa.Visible = True

                    Cmd.CommandText = "EXEC sp_Retreive_Trans_PR_Jasa_Dtl  '" + txt_TransNo.Text + "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTableDtl)

                    gv_PRDtl.DataSource = dtTableDtl
                    gv_PRDtl.Enabled = True
                    SetGrid_Jasa()
                Case Else
                    rb_item.Checked = True
                    P_waPembelianBrg.Visible = True
                    P_waPembelianJasa.Visible = False

                    Cmd.CommandText = "EXEC sp_Retreive_Trans_PR_Item_Dtl '" + txt_TransNo.Text + "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTableDtl)

                    gv_PRDtl.DataSource = dtTableDtl
                    gv_PRDtl.Enabled = True
                    SetGrid_Item()
            End Select
            dtDetail = dtTableDtl

        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try

    End Sub

    Private Sub InsertData()
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim remarks_Stok As String

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            txt_TransNo.Text = Generate_TranNo(Me.Name)

            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
            remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

            '----Save PR Header   

            StatusID = "WAFS" 'Waiting approval from Supervisor

            Cmd.CommandText = "EXEC sp_Insert_Trans_PR_Hdr '" & txt_TransNo.Text.Trim & "', '" & _
                                             dt_PRDate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                             txt_Requester.Text.Trim & "', '" & _
                                             RequestType & "', '" & _
                                             txt_ProjectNo.Text & "', '" & _
                                             txt_remarks.Text.Trim & "', '" & _
                                             StatusID & "', '" & _
                                             RejectReason & "', '" & _
                                             userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            If rb_item.Checked Then
                For Each item As DataRow In dtDetail.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_PR_Item_Dtl '" & _
                                        txt_TransNo.Text & "', '" & _
                                        item("Item ID") & "', '" & _
                                        item("UoM") & "', '" & _
                                        item("Qty") & "', '" & _
                                        item("Information") & "'"
                    Cmd.ExecuteNonQuery()
                Next
            Else
                For Each item As DataRow In dtDetail.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_PR_Jasa_Dtl '" & _
                                        txt_TransNo.Text & "', '" & _
                                        item("Jasa ID") & "', '" & _
                                        item("Information") & "'"
                    Cmd.ExecuteNonQuery()
                Next
            End If

            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to INBOX Purchasing
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "SUBMIT") 'Insert History transaction

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Submitted")

        Catch ex As Exception
            Conn.Close()
            MsgBox("InsertData: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateData()
        Dim ObjTrans As SqlTransaction

        If Conn.State = ConnectionState.Closed Then Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try

            If StatusTrans = "REJECT" Then
                If StatusID = "WAFS" Then
                    StatusID = "RBS"
                End If
            Else
                If StatusID = "WAFS" Then
                    StatusID = "WFPP"
                ElseIf StatusID = "RBS" Then
                    StatusID = "WAFS"
                ElseIf StatusID = "WFPP" Then
                    StatusID = "CMP"
                End If

            End If

            'Header
            Cmd.CommandText = "EXEC sp_Update_Trans_PR_Hdr '" & _
                                txt_TransNo.Text & "', '" & _
                                dt_PRDate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                txt_Requester.Text.Trim & "', '" & _
                                RequestType & "', '" & _
                                txt_ProjectNo.Text.Trim & "', '" & _
                                txt_remarks.Text.Trim & "', '" & _
                                StatusID & "', '" & _
                                RejectReason & "', '" & _
                                userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'Detail
            If rb_item.Checked Then
                For Each item As DataRow In dtDetail.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_PR_Item_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Item ID") & "', '" & _
                                            item("UoM") & "', '" & _
                                            item("Qty") & "', '" & _
                                            item("Information") & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PR_Item_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Item ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PR_Item_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Item ID") & "', '" & _
                                            item("Qty") & "', '" & _
                                            item("Information") & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                For Each item As DataRow In dtDetail.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_PR_Jasa_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Jasa ID") & "', '" & _
                                            item("Information") & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PR_Jasa_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Jasa ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PR_Jasa_Dtl '" & _
                                            txt_TransNo.Text & "', '" & _
                                            item("Jasa ID") & "', '" & _
                                            item("Information") & "'"
                        Cmd.ExecuteNonQuery()
                    End If

                Next
            End If

            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT"
                        'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                    Case Else
                        If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        ElseIf StatusID.Trim = "WFPP" Then 'Authotisasi kembali ke si pembuat (requester)
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        Else
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        End If
                End Select
            End If

            Select Case StatusTrans
                Case "REJECT"
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "REJECT") 'Insert History transaction
                Case Else
                    If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "RE-SUBMIT") 'Insert History transaction
                    Else
                        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "APPROVE") 'Insert History transaction
                    End If
            End Select

            ObjTrans.Commit()
            Conn.Close()

            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Rejected")
                Case Else
                    If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                        If StatusID = "CMP" Then
                            MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Confirmed")
                        Else
                            MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Submitted")
                        End If
                    Else
                        MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Approved")
                    End If
            End Select
        Catch ex As Exception

            Conn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DeleteData()
        Try

            Dim ObjTrans As SqlTransaction
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ObjTrans = Conn.BeginTransaction("Trans")
            Cmd.Transaction = ObjTrans

            Try
                StatusID = "CAP" 'cancelled by applicant

                Cmd.CommandText = "EXEC sp_Update_Trans_PR_Hdr '" & _
                                    txt_TransNo.Text & "', '" & _
                                    dt_PRDate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                    txt_Requester.Text.Trim & "', '" & _
                                    RequestType & "', '" & _
                                    txt_ProjectNo.Text.Trim & "', '" & _
                                    txt_remarks.Text.Trim & "', '" & _
                                    StatusID & "', '" & _
                                    RejectReason & "', '" & _
                                    userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                Conn.Close()
                MsgBox("Transaction No : " & txt_TransNo.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
                Me.Close()
            Catch ex As Exception
                Conn.Close()
                MsgBox(ex.Message)
            End Try

            Me.Close()
        Catch ex As Exception
            MsgBox("DeleteData: " & ex.Message)
        End Try
    End Sub

    Private Sub CheckDetail()
        Dim count As Integer
        For Each item As DataRow In dtDetail.Rows
            If item.RowState <> DataRowState.Deleted Then
                count += 1
            End If
        Next

        If count = 0 Then
            GroupBox1.Enabled = True
            dtDetail.PrimaryKey = Nothing
            dtDetail.Columns.Clear()
            Call SetColumnDetail()
        End If
    End Sub

    Private Function Validation() As Boolean
        Dim strOverLimit As String
        Dim i As Integer
        Validation = True

        If gv_PRDtl.RowCount = 0 Then
            MsgBox("PR detail hasn't filled. Process has been cancelled")
            Validation = False
            Exit Function
        End If

        If rb_jasa.Checked = True Then Exit Function

        If dtOverStock.Rows.Count = 0 Then Exit Function
        i = 0
        strOverLimit = ""
        For Each dtl As DataRow In dtOverStock.Rows
            If CDbl(dtl("Max_Stock")) < (CDbl(dtl("Qty_Request")) + CDbl(dtl("Qty_Current"))) Then
                i += 1
                strOverLimit = strOverLimit & CStr(i) & ". " & Trim(dtl("Item_ID")) & " = " & _
                            CStr(CDbl(dtl("Qty_Request")) + CDbl(dtl("Qty_Current")) - CDbl(dtl("Max_Stock"))) & " " & dtl("UoM")
            End If
        Next

        If strOverLimit.Trim = "" Then Exit Function
        strOverLimit = "Stock OVERLIMIT: " & strOverLimit

        MsgBox(strOverLimit, MsgBoxStyle.Information, "Information")

        If strOverLimit <> "" And Trim(txt_ProjectNo.Text) = "" Then
            MsgBox("Please fill Project No", MsgBoxStyle.Information, "Information")
            txt_ProjectNo.Focus()
            Validation = False
            Exit Function
        End If
    End Function

#End Region

#Region "Event Handler - Main"

    Private Sub gv_PRDtl_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_PRDtl.MouseClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If gv_PRDtl.RowCount = 0 Then Exit Sub
        If gv_PRDtl.CurrentRow.DataGridView(0, gv_PRDtl.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        If rb_item.Checked Then
            If String.IsNullOrEmpty(gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Item ID").Value) = False Then
                txt_ItemID.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Item ID").Value.ToString.Trim
                txt_ItemName.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Item Name").Value.ToString.Trim
                Txt_UoM.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("UoM").Value.ToString.Trim
                Txt_Qty.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Qty").Value.ToString.Trim
                txt_remarksItem.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Information").Value.ToString.Trim
            End If
        Else
            If String.IsNullOrEmpty(gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Jasa ID").Value) = False Then
                txt_JasaID.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Jasa ID").Value.ToString.Trim
                txt_JasaName.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Jasa Name").Value.ToString.Trim
                txt_RemarksJasa.Text = gv_PRDtl.Rows(gv_PRDtl.CurrentCell.RowIndex).Cells("Information").Value.ToString.Trim
            End If

        End If
    End Sub

    Private Sub rb_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_item.CheckedChanged

        If rb_item.Checked = True Then
            RequestType = "Pembelian Barang"
            P_waPembelianBrg.Visible = True
            P_waPembelianJasa.Visible = False
        Else
            RequestType = "Pembelian Jasa"
            P_waPembelianBrg.Visible = False
            P_waPembelianJasa.Visible = True
        End If
        Call SetColumnDetail()
    End Sub

    Private Sub rb_jasa_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_jasa.CheckedChanged
        If rb_item.Checked = True Then
            RequestType = "Pembelian Barang"
            P_waPembelianBrg.Visible = True
            P_waPembelianJasa.Visible = False
        Else
            RequestType = "Pembelian Jasa"
            P_waPembelianBrg.Visible = False
            P_waPembelianJasa.Visible = True
        End If
        Call SetColumnDetail()
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus

            Select Case StatusID
                Case "WFPP"
                    StatusTransDetail = ""
                    Call EnableInput(False)
                Case Else
                    StatusTransDetail = "CANCEL"
                    Call EnableInput(True)
            End Select

            Select Case RequestType
                Case "Pembelian Jasa"
                    Call EnableDisableInputDetailJasa()
                    Call SetButtonJasa()
                Case Else
                    Call EnableDisableInputDetailItem()
                    Call SetButtonItem()
            End Select

            Call SetToolTip()
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            frmRequestPembelianBrg_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
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

                frmRequestPembelianBrg_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If

    End Sub

    Private Sub ts_approve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "APPROVE"
            If Validation() = False Then Exit Sub

            Call UpdateData()
            Call frmRequestPembelianBrg_Load(False, e)
        End If
    End Sub

    Private Sub ts_reject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_reject.Click
        If MessageBox.Show("Are you sure to Reject this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            frmReason.StartPosition = FormStartPosition.CenterScreen
            frmReason.ShowDialog()
            If frmReason.Flag = "OK" Then
                If frmReason.txtReason.Text.ToString.Trim <> "" Then
                    If Validation() = False Then Exit Sub

                    RejectReason = frmReason.txtReason.Text.ToString.Trim
                    StatusTrans = "REJECT"
                    Call UpdateData()
                    Call frmRequestPembelianBrg_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub txt_department_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_department.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Department_ID, Department_Name FROM Master_Department WHERE Active_Flag = 'Y'", "Department_ID", "Department_Name", "", "", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    txt_department.Text = frmSearch.txtResult1.Text.ToString.Trim
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            Dim dr As DataRow
            dr = dtDepartment.Rows.Find(txt_department.Text.Trim)
            If dr Is Nothing Then
                MsgBox("Department ID can't found in Database.")
                txt_department.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txt_Requester_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Requester.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Username,Name,employee_ID,b.department_name from Master_Employee a left join Master_Department b on a.department_id = b.department_id where a.active_Flag = 'Y'", "UserName", "Name", "Employee_ID", "Department_Name", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    txt_Requester.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_department.Text = frmSearch.txtResult4.Text.ToString.Trim
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            Dim dtTable As New DataTable
            If txt_Requester.Text.Trim <> "" Then
                Try
                    dtTable.Clear()
                    Cmd.CommandText = "EXEC sp_retreiveEmployee_ByUserName '" & txt_Requester.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    txt_department.Text = dtTable.Rows(0).Item("Department_Name").ToString

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub frmRequestPembelianBrg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                Dim frmChild As New FrmViewRequestPembelianBrg
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormViewRequestPemberlianBarang" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select
    End Sub

    Private Sub frmRequestPembelianBrg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_Edit, ts_delete, ts_save, ts_cancel, Nothing, ts_approve, ts_reject)
        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        lbl_OverLimit.Text = ""
        If txt_TransNo.Text.ToString.Trim <> "" Then 'Jika dipanggil dari View Penerimaan Barang

            Call RetrieveData()

            If rb_item.Checked = True And StatusID = "WAFS" Then
                Call RetrieveOverlimit()
            End If

            Select Case CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName)
                Case True
                    StatusTrans = TransStatus.NoStatus
                Case Else
                    StatusTrans = "READ"
            End Select
      
            StatusTransDetail = ""
            Call EnableInput(False)
            Call SetToolTip()

            Select Case RequestType
                Case "Pembelian Jasa"
                    Call EnableDisableInputDetailJasa()
                    Call SetButtonJasa()
                Case Else
                    Call EnableDisableInputDetailItem()
                    Call SetButtonItem()
            End Select

        Else
            lbl_status.Text = GetStatus("DRAFT")
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = "CANCEL"
            txt_Requester.Text = userlog.UserName

            Call SetColumnOverStock()
            Call GetRequesterDept()
            Call EnableInput(True)
            Call EnableDisableInputDetailItem()
            Call SetToolTip()
            Call SetButtonItem()

        End If
    End Sub

#End Region

#Region "Detail"

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text.Trim = "" Then Exit Sub
        StatusTransDetail = "UPDATE"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow

        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose one for deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then

            dr = dtDetail.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                dr.Delete()
                StatusTransDetail = "DELETE"
                Call SetButtonItem()
                Call EnableDisableInputDetailItem()
                gv_PRDtl.Focus()
            End If
        End If

        If StatusID = "" Then Exit Sub
        Call CheckDetail()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow
        Dim drNew As Data.DataRow

        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        If Txt_Qty.Text.Trim = "" Then
            MessageBox.Show("Qty must be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Txt_Qty.Focus()
            Exit Sub
        End If

        GetItemData(txt_ItemID.Text.Trim)
        If dtItem.Rows.Count = 0 Then
            MessageBox.Show("Invalid Item ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_ItemID.Focus()
            Exit Sub
        End If

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                MessageBox.Show("Item ID has been exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                dr = dtDetail.NewRow
                dr("Item ID") = txt_ItemID.Text
                dr("Item Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = Txt_Qty.Text
                dr("Information") = txt_remarksItem.Text.Trim
                dtDetail.Rows.Add(dr)
            End If
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dtDetail.Rows.Find(txt_ItemID.Text)
            If DA IsNot Nothing Then
                dr("Qty") = Txt_Qty.Text
                dr("Information") = txt_remarksItem.Text.Trim
            End If
        End If

        If dtItem.Rows(0).Item("Max_Stock") < (CDbl(Txt_Qty.Text.Trim) + dtItem.Rows(0).Item("Qty_Current")) Then
            drNew = dtOverStock.NewRow
            drNew("Item_ID") = txt_ItemID.Text.Trim
            drNew("Max_Stock") = dtItem.Rows(0).Item("Max_Stock")
            drNew("Qty_Current") = dtItem.Rows(0).Item("Qty_Current")
            drNew("UoM") = dtItem.Rows(0).Item("UoM")
            drNew("Qty_Request") = CInt(Txt_Qty.Text)
            dtOverStock.Rows.Add(drNew)
        End If

        gv_PRDtl.DataSource = dtDetail

        'Untuk Refresh Grid
        gv_PRDtl.Sort(gv_PRDtl.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        gv_PRDtl.Sort(gv_PRDtl.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        GroupBox1.Enabled = False
        StatusTransDetail = "SAVE"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_InsertJasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_InsertJasa.Click
        StatusTransDetail = "INSERT"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_editJasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editJasa.Click
        If txt_JasaID.Text.Trim = "" Then Exit Sub
        StatusTransDetail = "UPDATE"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_deleteJasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deleteJasa.Click
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow

        dc(0) = dtDetail.Columns("Jasa ID")
        dtDetail.PrimaryKey = dc

        If txt_JasaID.Text.Trim = "" Then
            MessageBox.Show("Please choose one for deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then

            dr = dtDetail.Rows.Find(txt_JasaID.Text)
            If dr IsNot Nothing Then
                dr.Delete()
                StatusTransDetail = "DELETE"
                Call SetButtonItem()
                Call EnableDisableInputDetailJasa()
                gv_PRDtl.Focus()
            End If
        End If

        If StatusID = "" Then Exit Sub
        Call CheckDetail()
    End Sub

    Private Sub btn_cancelJasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelJasa.Click
        StatusTransDetail = "CANCEL"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_SaveJasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveJasa.Click
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow
        Dim dtTable As New DataTable

        dc(0) = dtDetail.Columns("Jasa ID")
        dtDetail.PrimaryKey = dc

        If txt_JasaID.Text.Trim = "" Then
            MessageBox.Show("Please fill Jasa ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_JasaID.Focus()
            Exit Sub
        End If

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Cmd.CommandText = "SELECT * FROM Master_Jasa WHERE Jasa_ID = '" & txt_JasaID.Text.Trim & "' AND Active_Flag = 'Y'"
        DA.SelectCommand = Cmd
        DA.Fill(dtTable)
        Conn.Close()

        If dtTable.Rows.Count = 0 Then
            MessageBox.Show("Invalid Jasa ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_JasaID.Focus()
            Exit Sub
        End If

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail.Rows.Find(txt_JasaID.Text)
            If dr IsNot Nothing Then
                MessageBox.Show("Jasa ID has been exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_JasaID.Focus()
                Exit Sub
            Else
                dr = dtDetail.NewRow
                dr("Jasa ID") = txt_JasaID.Text
                dr("Jasa Name") = txt_JasaName.Text
                dr("Information") = txt_RemarksJasa.Text.Trim
                dtDetail.Rows.Add(dr)
            End If
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dtDetail.Rows.Find(txt_JasaID.Text)
            If dr IsNot Nothing Then
                dr("Information") = txt_RemarksJasa.Text.Trim
            End If
        End If

        gv_PRDtl.DataSource = dtDetail
        gv_PRDtl.Sort(gv_PRDtl.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        gv_PRDtl.Sort(gv_PRDtl.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        GroupBox1.Enabled = False
        StatusTransDetail = "SAVE"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim dtTable As New DataTable

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Item_id AS [Item ID], Item_Name AS [Item Name], UoM from Master_Item_Hdr WHERE Active_Flag = 'Y'", "Item ID", "Item Name", "UoM", "", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then

                    If Conn.State = ConnectionState.Closed Then Conn.Open()

                    txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_ItemName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    Txt_UoM.Text = frmSearch.txtResult3.Text.ToString.Trim
                    Txt_Qty.Focus()


                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then Conn.Open()

                    dtTable.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_ItemName.Text = dtTable.Rows(0).Item("Item_Name").ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item("UoM").ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ID can't be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("txt_ItemID_KeyDown: " & ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub txt_JasaID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_JasaID.KeyDown
        Dim dtTable As New DataTable

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Jasa_id AS [Jasa ID], Jasa_Name AS [Jasa Name] from Master_Jasa WHERE Active_Flag = 'Y'", "Jasa ID", "Jasa Name", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_JasaID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_JasaName.Text = frmSearch.txtResult2.Text.ToString.Trim

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_JasaID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retreive_Master_Jasa_byJasaID '" & txt_JasaID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_JasaName.Text = dtTable.Rows(0).Item("Jasa_Name").ToString
                    Else
                        MessageBox.Show("Jasa ID can't be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("txt_JasaID_KeyDown: " & ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub Txt_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Qty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_Qty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Qty.Leave
        txt_remarksItem.Focus()
    End Sub

    Private Sub txt_remarksItem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_remarksItem.Leave
        btn_save.Focus()
    End Sub

    Private Sub txt_JasaQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

#End Region

    Private Sub txt_ProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ProjectNo.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            Try

                sql = "Select Project_No, isnull(Project_Name, '') Project_Name, Project_Date, a.PHM_No as Pnawaran_Marketing,a.Survey_No from " & Chr(13) & _
                      "Trans_Projects a " & Chr(13) & _
                      "left join Trans_PHMarketing_Hdr b " & Chr(13) & _
                      "on a.PHM_No = B.PHM_No " & Chr(13) & _
                      "where a.PHM_No not in (Select PHM_No from Trans_PakaiBahan_Hdr) "
                Cmd.CommandText = sql

                CallandGetSearchData(sql, "Project_No", "Project_Name", "Project_Date", "Pnawaran_Marketing", "Survey_No", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_ProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_remarks.Focus()
                End If                
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
        Conn.Close()
    End Sub
End Class