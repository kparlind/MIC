Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmTransferStockToko

#Region "Variable Declaration"

    Private conn As New SqlConnection
    Private cmd As New SqlCommand
    Private DA As New SqlDataAdapter
    Private StatusTrans As String
    Private StatusTransDetail As String
    Private Remarks_Stok As String
    Private dtDetail As New DataTable
    Private StatusID As String
    Private RejectReason As String = ""
    Private frmReason As New Frm_Reason
    Public CallerForm As String

#End Region

#Region "Function & Procedure"

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

    Private Sub SetColumnDetail()
        If dtDetail.Columns.Count <> 0 Then Exit Sub
        dtDetail.Columns.Add("Item ID")
        dtDetail.Columns.Add("Item Name")
        dtDetail.Columns.Add("UoM")
        dtDetail.Columns.Add("Qty Required")
        dtDetail.Columns.Add("Qty Approved")
        dtDetail.Columns.Add("Remark")
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
                ts_edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case Else

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName And StatusID.Trim <> "WCFR" Then
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

    Private Sub EnableDisableInput(ByVal boo As Boolean)
        dtp_TSDate.Enabled = False

        Select Case boo
            Case True
                txt_Remark.ReadOnly = False
                txt_Remark.ForeColor = Color.Black
                txt_Remark.BackColor = Color.White
                GroupBox2.Enabled = True
                cb_warehouse.Enabled = True
            Case False
                txt_Remark.ReadOnly = True
                txt_Remark.ForeColor = Color.Gray
                txt_Remark.BackColor = Color.LightGray
                GroupBox2.Enabled = False
                cb_warehouse.Enabled = False
        End Select

        If StatusTrans = TransStatus.NewStatus Then
            cb_category.Enabled = True
        Else
            cb_category.Enabled = False
        End If

    End Sub

    Private Sub EnableDisableInputDetail()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"

                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                Txt_QtyRec.Clear()
                txt_ket.Clear()

                txt_ItemID.Enabled = True
                txt_ket.Enabled = True

                txt_ItemID.BackColor = Color.LemonChiffon
                txt_ket.BackColor = Color.LemonChiffon

                If StatusID.Trim = "WAWA" Or StatusID.Trim = "WAAT" Then
                    'NOTE: 1. WAWA = Waiting Approval from Warehouse Admin
                    '      2. WAWH = Waiting Approval from Admin Toko
                    Txt_Qty.Enabled = False
                    Txt_QtyRec.Enabled = True
                    Txt_Qty.BackColor = Color.DarkGray
                    Txt_QtyRec.BackColor = Color.LemonChiffon
                Else
                    Txt_Qty.Enabled = True
                    Txt_QtyRec.Enabled = False
                    Txt_Qty.BackColor = Color.LemonChiffon
                    Txt_QtyRec.BackColor = Color.DarkGray
                End If

            Case "UPDATE"
                txt_ItemID.Enabled = False
                txt_ket.Enabled = True

                txt_ItemID.BackColor = Color.DarkGray
                txt_ket.BackColor = Color.LemonChiffon

                If StatusID.Trim = "WAWA" Or StatusID.Trim = "WAAT" Then
                    'NOTE: 1. WAWA = Waiting Approval from Warehouse Admin
                    '      2. WAWH = Waiting Approval from Admin Toko
                    Txt_Qty.Enabled = False
                    Txt_QtyRec.Enabled = True
                    Txt_Qty.BackColor = Color.DarkGray
                    Txt_QtyRec.BackColor = Color.LemonChiffon
                Else
                    Txt_Qty.Enabled = True
                    Txt_QtyRec.Enabled = False
                    Txt_Qty.BackColor = Color.LemonChiffon
                    Txt_QtyRec.BackColor = Color.DarkGray
                End If

            Case Else
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = False
                Txt_QtyRec.Enabled = False
                txt_ket.Enabled = False

                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                Txt_QtyRec.Clear()
                txt_ket.Clear()

                txt_ItemID.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                Txt_QtyRec.BackColor = Color.DarkGray
                txt_ket.BackColor = Color.DarkGray
        End Select

    End Sub

    Private Sub GetWarehouse()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.CommandText = "EXEC sp_retreive_Master_Warehouse"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            cb_warehouse.DataSource = dtTable
            cb_warehouse.DisplayMember = GlobalVar.Fields.Warehouse_Name
            cb_warehouse.ValueMember = GlobalVar.Fields.Warehouse_ID
            cb_warehouse.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("GetWarehouse: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub InsertData()
        Dim objTrans As SqlTransaction
        Dim LastSerial As Integer

        txt_TransNo.Text = Generate_TranNo(Me.Name)
        LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))

        Remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        objTrans = conn.BeginTransaction("Trans")
        cmd.Transaction = objTrans

        Select Case cb_category.SelectedItem
            Case "Request From Toko"
                StatusID = "WAWA"
            Case Else
                StatusID = "WAAT"
        End Select

        Try
            cmd.CommandText = "EXEC sp_Insert_Trans_TransferStockToko_Hdr '" & _
                              txt_TransNo.Text & "', '" & _
                              Format(dtp_TSDate.Value, "MM-dd-yyyy") & "', '" & _
                              cb_category.SelectedItem & "', '" & _
                              cb_warehouse.SelectedValue & "', '" & _
                              txt_Remark.Text.Trim & "', '" & _
                              StatusID & "', '" & _
                              userlog.UserName & "'"
            cmd.ExecuteNonQuery()

            For Each item As DataRow In dtDetail.Rows
                If Not item.RowState = DataRowState.Deleted Then
                    cmd.CommandText = "EXEC sp_Insert_Trans_TransferStockToko_Dtl '" & _
                                      txt_TransNo.Text & "', '" & _
                                      item("Item ID") & "', '" & _
                                      item("Qty Required") & "', '" & _
                                      item("Qty Approved") & "', '" & _
                                      item("Remark") & "'"
                    cmd.ExecuteNonQuery()
                End If
            Next

            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to INBOX Purchasing

            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "SUBMIT") 'Insert History transaction
            objTrans.Commit()
            conn.Close()

            MsgBox("Transaction No : " & txt_TransNo.Text.Trim & " has been Submitted")
        Catch ex As Exception
            MsgBox("InsertData: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateData()
        Dim objTrans As SqlTransaction
        Remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

        'NOTE: Tidak ada approval ke Warehouse Head kecuali PR (Permintaan Pembelian
        If StatusTrans = "REJECT" Then
            Select Case StatusID.Trim
                Case "WAWA"
                    StatusID = "RBWA"
                Case "WAAT"
                    StatusID = "RBAT"
            End Select
        Else
            Select Case StatusID.Trim
                Case "WAWA"
                    StatusID = "WCFR"
                Case "WAAT"
                    StatusID = "WCFR"
                Case "RBWA"
                    StatusID = "WAWA"
                Case "RBAT"
                    StatusID = "WAAT"
                Case "WCFR"
                    StatusID = "CMP"
            End Select
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            If txt_Reason.Text.Trim <> "" Then
                RejectReason = txt_Reason.Text.Trim
            End If

            objTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = objTrans

            cmd.CommandText = "EXEC sp_Update_Trans_TransferStockToko_Hdr '" & _
                  txt_TransNo.Text & "', '" & _
                  Format(dtp_TSDate.Value, "MM-dd-yyyy") & "', '" & _
                  cb_category.SelectedItem & "', '" & _
                  cb_warehouse.SelectedValue & "', '" & _
                  txt_Remark.Text.Trim & "', '" & _
                  RejectReason.Trim & "', 'Y', '" & _
                  StatusID & "', '" & _
                  userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            For Each item As DataRow In dtDetail.Rows
                Select Case item.RowState
                    Case DataRowState.Added
                        cmd.CommandText = "EXEC sp_Insert_Trans_TransferStockToko_Dtl '" & _
                                          txt_TransNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                    Case DataRowState.Modified
                        cmd.CommandText = "EXEC sp_Update_Trans_TransferStockToko_Dtl '" & _
                                          txt_TransNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                        'Jika status sudah approved makan update stok
                        If StatusID.Trim = "WCFR" Then
                            Select Case cb_category.SelectedItem.ToString.ToUpper
                                Case "REQUEST FROM TOKO"
                                    Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txt_TransNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                                    Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "IN", item("Qty Approved"), Remarks_Stok)
                                Case Else
                                    Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txt_TransNo.Text.Trim, "IN", item("Qty Approved"), Remarks_Stok)
                                    Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                            End Select
                        End If
                    Case DataRowState.Deleted
                        cmd.CommandText = "EXEC sp_Delete_Trans_TransferStockToko_Dtl '" & _
                                          txt_TransNo.Text & "', '" & _
                                          item(0, DataRowVersion.Original).ToString & "'"
                        cmd.ExecuteNonQuery()
                    Case Else
                        cmd.CommandText = "EXEC sp_Update_Trans_TransferStockToko_Dtl '" & _
                                          txt_TransNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                        'Jika status sudah approved makan update stok
                        If StatusID.Trim = "WCFR" Then
                            Select Case cb_category.SelectedItem.ToString.ToUpper
                                Case "REQUEST FROM TOKO"
                                    Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txt_TransNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                                    Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "IN", item("Qty Approved"), Remarks_Stok)
                                Case Else
                                    Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txt_TransNo.Text.Trim, "IN", item("Qty Approved"), Remarks_Stok)
                                    Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                            End Select
                        End If
                End Select
            Next

            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT" 'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                    Case Else
                        If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName And StatusID.Trim = "WAFS" Then
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        ElseIf StatusID.Trim = "WCFR" Then 'Authotisasi kembali ke si pembuat (requester)
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

            objTrans.Commit()
            conn.Close()

            RejectReason = ""
            lbl_status.Text = GetStatus(StatusID) 'Get Status Description

            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("Transaction No : " & txt_TransNo.Text.Trim & " has been Rejected")
                Case Else
                    If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                        If StatusID.Trim <> "CMP" Then
                            MsgBox("Transaction No : " & txt_TransNo.Text.Trim & " has been Submitted")
                        Else
                            MsgBox("Transaction No : " & txt_TransNo.Text.Trim & " has been Confirmed")
                        End If

                    Else
                        MsgBox("Transaction No : " & txt_TransNo.Text.Trim & " has been Approved")
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

                cmd.CommandText = "EXEC sp_Update_Trans_TransferStockToko_Hdr '" & _
                      txt_TransNo.Text & "', '" & _
                      Format(dtp_TSDate.Value, "MM-dd-yyyy") & "', '" & _
                      cb_category.SelectedItem & "', '" & _
                      cb_warehouse.SelectedValue & "', '" & _
                      txt_Remark.Text.Trim & "', '" & _
                      RejectReason.Trim & "', 'Y', '" & _
                      StatusID & "', '" & _
                      userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.ExecuteNonQuery()
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                conn.Close()
                MsgBox("Transaction No : " & txt_TransNo.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
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
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_TransferStockToko_Hdr_ByTSNo '" & txt_TransNo.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableHdr)

            If dtTableHdr.Rows.Count = 0 Then Exit Sub

            dtp_TSDate.Value = dtTableHdr.Rows(0).Item("Date")
            txt_Remark.Text = dtTableHdr.Rows(0).Item("Remark")
            cb_category.SelectedItem = dtTableHdr.Rows(0).Item("Category")
            cb_warehouse.SelectedValue = dtTableHdr.Rows(0).Item("Warehouse ID")
            txt_Reason.Text = dtTableHdr.Rows(0).Item("Reject Reason")
            StatusID = dtTableHdr.Rows(0).Item("Status ID").ToString.Trim
            lbl_status.Text = GetStatus(StatusID)
            RejectReason = dtTableHdr.Rows(0).Item("Reject Reason")

            If StatusID.Trim = "WCFR" Then
                ts_save.Text = "Confirm"
            End If

            cmd.CommandText = "EXEC sp_Retrieve_Trans_TransferStockToko_Dtl '" & txt_TransNo.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableDtl)
            conn.Close()

            dgv_Detail.DataSource = dtTableDtl

            If dtTableDtl.Rows.Count = 0 Then Exit Sub
            dtDetail = dtTableDtl

            txt_ItemID.Text = dtTableDtl.Rows(0).Item("Item ID").ToString
            txt_ItemName.Text = dtTableDtl.Rows(0).Item("Item Name").ToString
            Txt_UoM.Text = dtTableDtl.Rows(0).Item("UoM").ToString
            Txt_Qty.Text = dtTableDtl.Rows(0).Item("Qty Required").ToString
            Txt_QtyRec.Text = dtTableDtl.Rows(0).Item("Qty Approved").ToString
            txt_ket.Text = dtTableDtl.Rows(0).Item("Remark").ToString
        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try
    End Sub

    Private Sub Insert_StokMovement_Toko(ByVal ItemId As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from Trans_Stock_Movement_toko where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        maxSeq = dt.Rows(0).Item("MaxSeq")
        maxSeq += 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement_Toko '" & _
                            Generate_Period() & "', '" & _
                            ItemId & "', '" & _
                            TransNo_Ref & "', '" & _
                            maxSeq & "', '" & _
                            Sts_Proses & "', '" & _
                            Qty & "','" & _
                            Remarks & "', '" & _
                            userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
    End Sub

    Private Function Validation() As Boolean
        Validation = True

        If dgv_Detail.RowCount = 0 Then
            MsgBox("Please input Detail Item", MsgBoxStyle.Information, "Information")
            Validation = False
            Exit Function
        End If
    End Function


#End Region

#Region "Event Handler"

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = TransStatus.EditStatus
            Call EnableDisableInput(True)

            Select Case StatusID
                Case "WCFR"
                    StatusTransDetail = ""
                    Call EnableDisableInput(False)
                Case Else
                    StatusTransDetail = "CANCEL"
                    Call EnableDisableInput(True)
            End Select

            Call EnableDisableInputDetail()
            Call SetToolTip()
            Call SetButton()
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

                Call frmTransferStockToko_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            frmTransferStockToko_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Validation() = False Then Exit Sub

            StatusTrans = "APPROVE"
            Call UpdateData()
            Call frmTransferStockToko_Load(False, e)
        End If

    End Sub

    Private Sub ts_reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_reject.Click
        If MessageBox.Show("Are you sure to Reject this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            frmReason.StartPosition = FormStartPosition.CenterScreen
            frmReason.ShowDialog()
            If frmReason.Flag = "OK" Then
                If frmReason.txtReason.Text.ToString.Trim <> "" Then
                    If Validation() = False Then Exit Sub

                    RejectReason = frmReason.txtReason.Text.ToString.Trim
                    StatusTrans = "REJECT"
                    Call UpdateData()
                    Call frmTransferStockToko_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text.Trim = "" Then Exit Sub
        StatusTransDetail = "UPDATE"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(0) As DataColumn
        Dim dr As Data.DataRow
        Dim dtTable As New DataTable

        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        Select Case StatusTransDetail
            Case "INSERT"
                If txt_ItemID.Text.Trim = "" Then
                    MsgBox("Item ID must be filled", MsgBoxStyle.Information, "Information")
                    txt_ItemID.Focus()
                    Exit Sub
                End If

                If (Txt_Qty.Text.Trim = "" Or Txt_Qty.Text.Trim = "0") And _
                    Not (StatusID = "WAWA" Or StatusID = "WAAT") Then
                    MsgBox("Qty must be filled", MsgBoxStyle.Information, "Information")
                    Txt_Qty.Focus()
                    Exit Sub
                End If

                dr = dtDetail.Rows.Find(txt_ItemID.Text)
                If dr IsNot Nothing Then
                    MsgBox("Item ID has been exist", MsgBoxStyle.Information, "Inforamtion")
                    Exit Sub
                End If

                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtTable)
                    conn.Close()

                    If dtTable.Rows.Count = 0 Then
                        MsgBox("Item ID isn't exist in Master Data", MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                '-----Add new row
                If Txt_Qty.Text.Trim = "" Then Txt_Qty.Text = 0
                If Txt_QtyRec.Text.Trim = "" Then Txt_QtyRec.Text = 0

                dr = dtDetail.NewRow
                dr("Item ID") = txt_ItemID.Text.Trim
                dr("Item Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty Required") = Txt_Qty.Text
                dr("Qty Approved") = Txt_QtyRec.Text
                dr("Remark") = txt_ket.Text.Trim
                dtDetail.Rows.Add(dr)

            Case "UPDATE"
                dr = dtDetail.Rows.Find(txt_ItemID.Text)
                If dr IsNot Nothing Then
                    If Txt_Qty.Text.Trim = "" Or Txt_Qty.Text.Trim = "0" Then
                        MsgBox("Qty must be filled", MsgBoxStyle.Information, "Information")
                        Txt_Qty.Focus()
                        Exit Sub
                    End If

                    If Txt_QtyRec.Text.Trim = "" Then Txt_QtyRec.Text = 0

                    dr("Qty Required") = Txt_Qty.Text
                    dr("Qty Approved") = Txt_QtyRec.Text
                    dr("Remark") = txt_ket.Text
                End If
        End Select
        dgv_Detail.DataSource = dtDetail
        StatusTransDetail = "SAVE"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(0) As DataColumn
        Dim da As Data.DataRow

        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose one for deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then

            da = dtDetail.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da.Delete()
                StatusTransDetail = "DELETE"
                Call SetButton()
                Call EnableDisableInputDetail()
                dgv_Detail.Focus()
            End If
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("EXEC sp_Retrieve_Master_Item_Hdr_List 'active_flag', 'Y'", "Item_ID", "Item_Name", "UOM", "", "")
            txt_ItemID.Text = frmSearch.txtResult1.Text.Trim
            If txt_ItemID.Text.Trim <> "" Then
                txt_ItemName.Text = frmSearch.txtResult2.Text.Trim
                Txt_UoM.Text = frmSearch.txtResult3.Text.Trim
                Txt_Qty.Text = "0"
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim = "" Then Exit Sub

            Dim dtTable As New DataTable

            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.CommandText = "sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            Select Case dtTable.Rows.Count
                Case 0
                    MsgBox("Item ID isn't exist")
                    txt_ItemID.Focus()
                Case Else
                    txt_ItemID.Text = txt_ItemID.Text.ToString.ToUpper
                    txt_ItemName.Text = dtTable.Rows(0).Item("Item_Name")
                    Txt_UoM.Text = dtTable.Rows(0).Item("UoM")
                    Txt_Qty.Text = "0"
            End Select
        End If

    End Sub

    Private Sub Txt_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Qty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_QtyRec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_QtyRec.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub frmTransferStockToko_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                Dim frmChild As New frmTransferStockTokoView
                For Each f As Form In Me.MdiChildren
                    If f.Name = "From Transfer Stock Toko View" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select
    End Sub

    Private Sub frmTransferStockToko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cb_category.SelectedIndex = 0

        Call GetWarehouse()
        Call SetColumnDetail()

        If txt_TransNo.Text.ToString.Trim <> "" Then 'Dipanggil dari View

            Call RetrieveData()
            Select Case CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName)
                Case True
                    StatusTrans = TransStatus.NoStatus
                Case Else
                    StatusTrans = "READ"
            End Select

            StatusTransDetail = ""
            Call EnableDisableInput(False)
            Call EnableDisableInputDetail()
            Call SetToolTip()
            Call SetButton()

        Else
            lbl_status.Text = GetStatus("DRAFT")
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = "CANCEL"
            Call EnableDisableInput(True)
            Call EnableDisableInputDetail()
            Call SetToolTip()
            Call SetButton()

        End If
    End Sub

    Private Sub dgv_Detail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_Detail.CellClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If dtDetail.Rows.Count = 0 Then Exit Sub

        If dgv_Detail.CurrentRow.DataGridView(0, dgv_Detail.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Btn_cancel_Click(Nothing, Nothing)
        txt_ItemID.Text = dgv_Detail.CurrentRow.DataGridView(0, dgv_Detail.CurrentRow.Index).Value.ToString
        txt_ItemName.Text = dgv_Detail.CurrentRow.DataGridView(1, dgv_Detail.CurrentRow.Index).Value.ToString
        Txt_UoM.Text = dgv_Detail.CurrentRow.DataGridView(2, dgv_Detail.CurrentRow.Index).Value.ToString
        Txt_Qty.Text = dgv_Detail.CurrentRow.DataGridView(3, dgv_Detail.CurrentRow.Index).Value.ToString
        Txt_QtyRec.Text = dgv_Detail.CurrentRow.DataGridView(4, dgv_Detail.CurrentRow.Index).Value.ToString
        txt_ket.Text = dgv_Detail.CurrentRow.DataGridView(5, dgv_Detail.CurrentRow.Index).Value.ToString
    End Sub

#End Region
    
End Class