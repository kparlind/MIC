Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmOrderPabrikasi

#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtHeader As New DataTable
    Dim dtDetail1 As New DataTable
    Dim dtDetail2 As New DataTable
    Dim StatusTransDetail As String
    Dim StatusTrans As String
    Dim dr As DataRow
    Dim StatusID As String
    Dim frmReason As New Frm_Reason
    Dim RejectReason As String = ""

    Public CallerForm As String
#End Region

#Region "Procedure & Function"

    Private Sub EnableDisableInput(ByVal boo As Boolean)
        Select Case boo
            Case True
                dt_OrderDate.Enabled = True
                dt_TargetDate.Enabled = True
                txt_SPKNo.ReadOnly = False
                txt_SPKNo.ForeColor = Color.Black
                txt_SPKNo.BackColor = Color.White
                txt_PIC.ReadOnly = False
                txt_PIC.ForeColor = Color.Black
                txt_PIC.BackColor = Color.White
                txt_remarks.ReadOnly = False
                txt_remarks.ForeColor = Color.Black
                txt_remarks.BackColor = Color.White
            Case False
                dt_OrderDate.Enabled = False
                dt_TargetDate.Enabled = False
                txt_SPKNo.ReadOnly = True
                txt_SPKNo.ForeColor = Color.Gray
                txt_SPKNo.BackColor = Color.LightGray
                txt_PIC.ReadOnly = True
                txt_PIC.ForeColor = Color.Gray
                txt_PIC.BackColor = Color.LightGray
                txt_remarks.ReadOnly = True
                txt_remarks.ForeColor = Color.Gray
                txt_remarks.BackColor = Color.LightGray
        End Select
    End Sub

    Private Sub EnableDisableInputDetail()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_ItemID.Enabled = True
                txt_Qty.Enabled = True
                txt_ItemID.BackColor = Color.LemonChiffon
                txt_Qty.BackColor = Color.LemonChiffon
            Case "UPDATE"
                txt_ItemID.Enabled = False
                txt_Qty.Enabled = True
                txt_ItemID.BackColor = Color.DarkGray
                txt_Qty.BackColor = Color.LemonChiffon
            Case Else
                txt_ItemID.Enabled = False
                txt_Qty.Enabled = False
                txt_ItemID.BackColor = Color.DarkGray
                txt_Qty.BackColor = Color.DarkGray
        End Select

    End Sub

    Private Sub GetItemData(ByVal ItemId As String, ByVal dtTable As DataTable)
        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()

            Conn.Close()
            Cmd.CommandText = "Select Item_id,Item_Name,UoM from Master_Item_Hdr where isPabrikasi = 'Y' and Active_Flag = 'Y' AND Item_ID = '" & ItemId & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadInsert_OPItem_Detail(ByVal ItemID As String)
        Dim qty As Integer
        Dim dtTable As New DataTable
        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            If txt_Qty.Text.Trim = "" Then
                qty = 0
            Else
                qty = CInt(txt_Qty.Text)
            End If

            Cmd.CommandText = "EXEC sp_Retreive_PabrikasiMasterItem_dtl_ByItemID '" & ItemID & "'," & qty
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)

            For Each item As DataRow In dtTable.Rows
                Dim dtNewRow As DataRow
                dtNewRow = dtDetail2.NewRow()

                dtNewRow.Item("Item_Id") = item("Item_Id")
                dtNewRow.Item("itemDetail_ID") = item("item_id_dtl")
                dtNewRow.Item("ItemDetail_name") = item("ItemDetail_name")
                dtNewRow.Item("UoM") = item("UoM")
                dtNewRow.Item("Qty_Stdr") = CInt(item("Qty_Stdr"))
                dtNewRow.Item("Qty_Order") = CInt(item("Qty_Order"))
                dtDetail2.Rows.Add(dtNewRow)

            Next
            gv_item.DataSource = dtDetail2
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RetrieveData()
        Try
            dtHeader.Clear()
            dtDetail1.Clear()
            dtDetail2.Clear()

            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Cmd.CommandText = "EXEC sp_Retreive_Trans_OrderPabrikasi '" & txt_TransNo.Text & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtHeader)

            If dtHeader.Rows.Count = 0 Then Exit Sub

            dt_OrderDate.Value = dtHeader.Rows(0).Item("OP_Date").ToString
            dt_TargetDate.Value = dtHeader.Rows(0).Item("Due_Date").ToString
            txt_SPKNo.Text = dtHeader.Rows(0).Item("SPK_No").ToString
            txt_PIC.Text = dtHeader.Rows(0).Item("PIC").ToString
            txt_remarks.Text = dtHeader.Rows(0).Item("Remarks").ToString
            txt_Reason.Text = dtHeader.Rows(0).Item("Reject_Reason").ToString
            RejectReason = dtHeader.Rows(0).Item("Reject_Reason").ToString
            lbl_status.Text = GetStatus(dtHeader.Rows(0).Item("Status_ID").ToString.Trim)
            StatusID = dtHeader.Rows(0).Item("Status_ID").ToString.Trim

            Cmd.CommandText = "EXEC sp_Retreive_Trans_OrderPabrikasi_Hdr '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail1)

            gv_Hdr.DataSource = dtDetail1


            Cmd.CommandText = "EXEC sp_Retreive_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail2)

            gv_item.DataSource = dtDetail2

            Conn.Close()
        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertData()
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()
        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim LastSerial As Integer
        Dim remarks_Stok As String

        txt_TransNo.Text = Generate_TranNo(Me.Name)
        LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
        remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

        StatusID = "WAFP" 'Waiting approval from Purchasing

        Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi '" & txt_TransNo.Text.Trim & "','" & _
                                     dt_OrderDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                     txt_SPKNo.Text.Trim & "','" & _
                                     dt_TargetDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                     txt_PIC.Text.Trim & "','" & _
                                     txt_remarks.Text.Trim & "','" & _
                                     StatusID & "','" & _
                                     RejectReason & "','" & _
                                     userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
        For Each item As DataRow In dtDetail1.Rows
            Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Hdr '" & txt_TransNo.Text.Trim + "','" & _
                              item("Item_ID") & "'," & item("Qty")
            Cmd.ExecuteNonQuery()
        Next

        For Each item As DataRow In dtDetail2.Rows
            Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim + "','" & _
                              item("Item_ID") & "','" & item("ItemDetail_ID") & "'," & item("Qty_STDR") & "," & _
                              item("Qty_Order")
            Cmd.ExecuteNonQuery()
        Next
        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri
        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC("WAFP"), "W", "Y", StatusID) 'Insert to INBOX Purchasing
        UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

        ObjTrans.Commit()
        Conn.Close()
        MsgBox("Bon Order Pabrikasi: " & txt_TransNo.Text.Trim & " has been Submitted")
    End Sub

    Private Sub Updatedata()

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        If StatusTrans = "REJECT" Then
            Select Case StatusID.Trim
                Case "WAFP"
                    StatusID = "RBPA"
            End Select
        Else
            Select Case StatusID.Trim
                Case "WAFP"             'Waiting approval  from Purchasing
                    StatusID = "WRGW"   'Waiting Receive Goods to Warehouse
                Case "RBPA"
                    StatusID = "WAFP"
                Case "WRGW"
                    StatusID = "CMP"    'Completed
            End Select
        End If

        Cmd.CommandText = "EXEC sp_Update_Trans_OrderPabrikasi '" & txt_TransNo.Text & "','" & dt_OrderDate.Value.ToString("yyyy-MM-dd") + "','" & _
                           txt_SPKNo.Text.Trim & "','" & dt_TargetDate.Value.ToString("yyyy-MM-dd") & "','" & txt_PIC.Text.Trim & "','" & _
                           txt_remarks.Text & "','" & StatusID & "','" & RejectReason & "','" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()

        For Each item As DataRow In dtDetail1.Rows
            If item.RowState = DataRowState.Added Then
                Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Hdr '" & txt_TransNo.Text.Trim + "','" & _
                                  item("Item_ID") & "'," & item("Qty")
                Cmd.ExecuteNonQuery()

            ElseIf item.RowState = DataRowState.Deleted Then
                Cmd.CommandText = "EXEC sp_Delete_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text + "','" & _
                                   item("Item_ID", DataRowVersion.Original).ToString & "'"
                Cmd.ExecuteNonQuery()
            Else
                Cmd.CommandText = "EXEC sp_Update_Trans_OrderPabrikasi_Hdr '" & txt_TransNo.Text.Trim + "','" & _
                                  item("Item_ID") & "'," & item("Qty")
                Cmd.ExecuteNonQuery()
            End If
        Next

        For Each item As DataRow In dtDetail2.Rows
            If item.RowState = DataRowState.Added Then
                Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim + "','" & _
                                  item("Item_ID") & "','" & item("ItemDetail_ID") & "'," & item("Qty_STDR") & "," & _
                                  item("Qty_Order")
                Cmd.ExecuteNonQuery()

            ElseIf item.RowState = DataRowState.Deleted Then
                Cmd.CommandText = "EXEC sp_Delete_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text + "','" & _
                                   item("Item_ID") & "'"
                Cmd.ExecuteNonQuery()
            Else
                Cmd.CommandText = "EXEC sp_Update_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim + "','" & _
                                  item("Item_ID") & "','" & item("ItemDetail_ID") & "'," & item("Qty_STDR") & "," & _
                                  item("Qty_Order")
                Cmd.ExecuteNonQuery()
            End If
        Next
      
        UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
        UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
        If StatusID <> "CMP" Then
            If StatusTrans = "REJECT" Then
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
            Else
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
            End If

        End If
        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

        ObjTrans.Commit()
        Conn.Close()

        If StatusTrans = "REJECT" Then
            MsgBox("Bon Order Pabrikasi: " & txt_TransNo.Text.Trim & " has been Rejected")
        Else
            If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                Select Case StatusID
                    Case "CMP"
                        MsgBox("Bon Order Pabrikasi.: " & txt_TransNo.Text.Trim & " has been Confirmed")
                    Case Else
                        MsgBox("Bon Order Pabrikasi.: " & txt_TransNo.Text.Trim & " has been Submitted")
                End Select

            Else
                MsgBox("Bon Order Pabrikasi.: " & txt_TransNo.Text.Trim & " has been Approved")
            End If
        End If

    End Sub

    Private Sub DeleteData()
        Try

            Dim ObjTrans As SqlTransaction
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ObjTrans = Conn.BeginTransaction("Trans")
            Cmd.Transaction = ObjTrans

            Try
                StatusID = "CAP" 'cancelled by applicant

                Cmd.CommandText = "EXEC sp_Update_Trans_OrderPabrikasi '" & txt_TransNo.Text & "','" & dt_OrderDate.Value.ToString("yyyy-MM-dd") + "','" & _
                                 txt_SPKNo.Text.Trim & "','" & dt_TargetDate.Value.ToString("yyyy-MM-dd") & "','" & txt_PIC.Text.Trim & "','" & _
                                 txt_remarks.Text & "','" & StatusID & "','" & RejectReason & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                Conn.Close()
                MsgBox("Bon Order Pabrikasi : " & txt_TransNo.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
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
                ts_delete.Visible = False
                ts_cancel.Visible = True

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                    ts_save.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                ElseIf StatusID = "WRGW" Then
                    ts_save.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                Else
                    ts_save.Visible = False
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
                ts_Edit.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName And StatusID.Trim <> "WRGW" Then
                    ts_delete.Visible = True
                Else
                    ts_delete.Visible = False
                End If

        End Select
    End Sub

    Private Sub SetColumn()
        dtDetail1.Columns.Add("Item_ID")
        dtDetail1.Columns.Add("Item_Name")
        dtDetail1.Columns.Add("UoM")
        dtDetail1.Columns.Add("Qty")

        dtDetail2.Columns.Add("Item_ID")
        dtDetail2.Columns.Add("ItemDetail_ID")
        dtDetail2.Columns.Add("Item_Name")
        dtDetail2.Columns.Add("ItemDetail_Name")
        dtDetail2.Columns.Add("UoM")
        dtDetail2.Columns.Add("Qty_Stdr")
        dtDetail2.Columns.Add("Qty_Order")
    End Sub

    Private Function Validation() As Boolean
        Validation = True

        If txt_SPKNo.Text.Trim = "" Then
            MsgBox("SPK Number must be filled. Process cancelled")
            Validation = False
            txt_SPKNo.Focus()
            Exit Function
        End If

        If txt_PIC.Text.Trim = "" Then
            MsgBox("PIC must be filled. Process cancelled")
            Validation = False
            txt_PIC.Focus()
            Exit Function
        End If

        If dtDetail1.Rows.Count = 0 Then
            MsgBox("Detail Item must be filled. Process cancelledn")
            Validation = False
            Exit Function
        End If
    End Function

#End Region

#Region "Event Handler"

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
        Dim dtTable As New DataTable
        Dim dc(1) As DataColumn

        dc(0) = dtDetail1.Columns("Item_ID")
        dtDetail1.PrimaryKey = dc

        ' Validation
        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Item ID must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_ItemID.Focus()
            Exit Sub
        End If
        If txt_Qty.Text.Trim = "" Then
            MessageBox.Show("Qty must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_Qty.Focus()
            Exit Sub
        End If

        Call GetItemData(txt_ItemID.Text.Trim, dtTable)
        If dtTable.Rows.Count = 0 Then
            MessageBox.Show("Invalida Item ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txt_ItemID.Focus()
            Exit Sub
        End If

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail1.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                MessageBox.Show("Item ID has been exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                dr = dtDetail1.NewRow
                dr("Item_ID") = txt_ItemID.Text
                dr("Item_Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = txt_Qty.Text
                dtDetail1.Rows.Add(dr)
            End If
            LoadInsert_OPItem_Detail(txt_ItemID.Text.Trim)
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dtDetail1.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                dr("Qty") = txt_Qty.Text
            End If

            For Each item As DataRow In dtDetail2.Rows
                If item("Item_ID") = txt_ItemID.Text.Trim Then
                    item("Qty_Order") = item("Qty_STDR") * txt_Qty.Text
                End If
            Next
        End If

        gv_Hdr.DataSource = dtDetail1
        StatusTransDetail = "SAVE"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow

        dc(0) = dtDetail1.Columns("Item_ID")
        dtDetail1.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            da = dtDetail1.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da.Delete()
                StatusTransDetail = "DELETE"
                Call SetButton()
                Call EnableDisableInputDetail()
                gv_item.Focus()
            End If

        End If

    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = TransStatus.EditStatus

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
                        Call Updatedata()
                End Select

                Call FrmOrderPabrikasi_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call Deletedata()
            End If
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            FrmOrderPabrikasi_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "APPROVE"
            If Validation() = False Then Exit Sub

            Call Updatedata()
            Call FrmOrderPabrikasi_Load(False, e)
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
                    Call Updatedata()
                    Call FrmOrderPabrikasi_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If
    End Sub

    Private Sub txt_SPKNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SPKNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("EXEC sp_Retrieve_Trans_SPK_ALL", "SPK No", "SPK Date", "Project No", "Project Name", "Remarks")

            If frmSearch.txtResult1.Text.Trim <> "" Then
                txt_SPKNo.Text = frmSearch.txtResult1.Text.Trim
            End If

        ElseIf e.KeyCode = Keys.Enter Then
            If txt_SPKNo.Text.Trim = "" Then
                MsgBox("Please fill SPK No", MsgBoxStyle.Information, "Information")
                txt_SPKNo.Focus()
                Exit Sub
            End If

            Dim dtTable As New DataTable
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            Cmd.CommandText = "EXEC sp_Retrieve_Trans_SPK_ByKey '" & txt_SPKNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)

            If dtTable.Rows.Count <> 0 Then Exit Sub

            MsgBox("SPK No: " & txt_SPKNo.Text.Trim & " isn't exist in database", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub txt_PIC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PIC.KeyDown
        Dim dtTable As New DataTable

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Username, Name, Employee_ID, b.Access_Desc FROM Master_Employee a LEFT JOIN Master_Access b ON a.access_id = b.access_id where a.Active_Flag = 'Y'", "UserName", "Name", "Employee_ID", "Access_desc", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_PIC.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_PICName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_remarks.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_PIC.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_retreiveEmployee_ByUserName '" & txt_PIC.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_PIC.Text = dtTable.Rows(0).Item("UserName").ToString
                        txt_PICName.Text = dtTable.Rows(0).Item("Name").ToString
                        txt_remarks.Focus()
                    Else
                        MessageBox.Show("PIC ini tidak ditemukan. Pastikan User Name yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim dtTable As New DataTable

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Item_id,Item_Name,UoM from Master_Item_Hdr where isPabrikasi = 'Y' and Active_Flag = 'Y'", "Item_ID", "Item_Name", "UoM", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim, dtTable)
                    If dtTable.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dtTable.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item("UoM").ToString
                        txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_ItemName.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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

    Private Sub txt_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Qty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub gv_Hdr_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_Hdr.MouseClick, DataGridView1.MouseClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If gv_Hdr.RowCount = 0 Then Exit Sub
        txt_ItemID.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
        txt_ItemName.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
        Txt_UoM.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
        txt_Qty.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty).Value.ToString.Trim
    End Sub

    Private Sub FrmOrderPabrikasi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                Dim frmChild As New frmViewOrderPabrikasi
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormViewOrderPabrikasi" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select
    End Sub

    Private Sub FrmOrderPabrikasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

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
            Call SetColumn()
        End If

    End Sub

#End Region

End Class