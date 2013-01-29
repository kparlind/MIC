Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmPermintaanPengeluaranBahan

#Region "Variable Declaration"

    Private conn As New SqlConnection
    Private cmd As New SqlCommand
    Private DA As New SqlDataAdapter
    Private StatusTrans As String
    Private StatusTransDetail As String
    Private Remarks_Stok As String
    Private dtDetail As New DataTable
    Private dtDetailOriginal As New DataTable
    Private dtBuffer As New DataTable
    Private StatusID As String
    Private StatusIDOld As String
    Private Price As Double
    Private frmReason As New Frm_Reason
    Private RejectReason As String = ""
    Private dtCurrentStock As New DataTable
    Public CallerForm As String
    Public ViewFormName As String
    Private AveragePrice As Double

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

                If GetDocCreator(txtBPBNo.Text.Trim) = userlog.UserName Then
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

                If GetDocCreator(txtBPBNo.Text.Trim) = userlog.UserName And StatusID.Trim <> "WCFR" Then
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
        Select Case boo
            Case True
                dtpRequiredDate.Enabled = True
                cb_warehouse.Enabled = True
                cb_accountcode.Enabled = True
                GroupBox2.Enabled = True
                txtRemark.ReadOnly = False
                txtRemark.ForeColor = Color.Black
                txtRemark.BackColor = Color.White
            Case False
                dtpRequiredDate.Enabled = False
                cb_warehouse.Enabled = False
                cb_accountcode.Enabled = False
                GroupBox2.Enabled = False
                txtRemark.ReadOnly = True
                txtRemark.ForeColor = Color.Gray
                txtRemark.BackColor = Color.LightGray
        End Select

        Select Case StatusTrans
            Case TransStatus.NewStatus
                txtRefNo.ReadOnly = False
                txtRefNo.ForeColor = Color.Black
                txtRefNo.BackColor = Color.White
                cb_category.Enabled = True
            Case Else
                txtRefNo.ReadOnly = True
                txtRefNo.ForeColor = Color.Gray
                txtRefNo.BackColor = Color.LightGray
                cb_category.Enabled = False
                If Not (cb_category.SelectedItem = "Division" Or cb_category.SelectedItem = "Order Maintenance") Then
                    cb_accountcode.Enabled = False
                End If
        End Select

        If StatusID.Trim = "WAWA" Then  'karena perubahan Warehouse Impact ke Current STOCK
            cb_warehouse.Enabled = False
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

                If StatusID.Trim = "WAWA" Or StatusID.Trim = "WAWH" Then
                    'NOTE: 1. WAWA = Waiting Approval from Warehouse Admin
                    '      2. WAWH = Waiting Approval from Warehouse Head
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

                If StatusID.Trim = "WAWA" Or StatusID.Trim = "WAWH" Then
                    'NOTE: 1. WAWA = Waiting Approval from Warehouse Admin
                    '      2. WAWH = Waiting Approval from Warehouse Head
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

    Private Sub GetBuffer()
        Try
            Dim dr As DataRow
            Dim NewRow As DataRow
            Dim dc(0) As DataColumn

            dtDetail.Clear()
            dtDetailOriginal.Clear()
            dtBuffer.Clear()

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_BPB_Buffer '" & cb_category.SelectedItem & "', '" & txtRefNo.Text.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtBuffer)

            If dtBuffer.Rows.Count = 0 Then Exit Sub
            dc(0) = dtBuffer.Columns("Item ID")
            dtBuffer.PrimaryKey = dc

            'NOTE: dtBuffer terdiri dari: 1)Qty Ref 2)Qty Buffer 3)Qty Approved Gudang

            Select Case cb_category.SelectedItem
                Case "SPK"
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_PHMarketing_Item_Dtl_BySPKNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
                Case "Order Pabrikasi"
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
            End Select

            If dtDetailOriginal.Rows.Count = 0 Then Exit Sub
            For Each item As DataRow In dtDetailOriginal.Rows
                dr = dtBuffer.Rows.Find(item("Item ID"))
                If dr IsNot Nothing Then
                    'NOTE: Jika Qty Buffer > Qty Ref maka ambil Qty Buffer sebagai pegangan
                    '      Jika Qty Buffer < Qty Ref maka ambil Qty Ref sebagai pegangan
                    If item("Qty Required") < dr("Qty Buffer") Then
                        item("Qty Required") = dr("Qty Buffer")
                    End If

                    'Sisa yang pending masih boleh di-request
                    item("Qty Required") = item("Qty Required") - dr("Qty Approved Gudang") - dr("Qty Pending")

                    If item("Qty Required") > 0 Then
                        NewRow = dtDetail.NewRow

                        NewRow("Item ID") = item("Item ID")
                        NewRow("Item Name") = item("Item Name")
                        NewRow("UoM") = item("UoM")
                        NewRow("Qty Required") = item("Qty Required")
                        NewRow("Qty Approved") = item("Qty Approved")
                        NewRow("Remark") = item("Remark")
                        dtDetail.Rows.Add(NewRow)
                    End If

                End If
            Next

            conn.Close()
        Catch ex As Exception
            MsgBox("GetBuffer: " & ex.Message)
        End Try
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

    Private Sub GetAccountCode()
        Dim dtTable As New DataTable
        Dim dr As DataRow
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.CommandText = "sp_Retrieve_Master_Account_Biaya"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            If dtTable.Rows.Count = 0 Then Exit Sub

            cb_accountcode.DataSource = dtTable
            cb_accountcode.DisplayMember = "Account_name"
            cb_accountcode.ValueMember = "Account_id"

            dr = dtTable.NewRow
            dr("Account_id") = " "
            dr("Account_name") = " "
            dtTable.Rows.Add(dr)

        Catch ex As Exception
            MsgBox("GetAccountCode: " & ex.Message)
        End Try
    End Sub

    Private Sub GetCurrentStock()
        Dim Period As String
        Dim dc(0) As DataColumn

        Period = CStr(dtpBPBDate.Value.Year) + IIf(CStr(dtpBPBDate.Value.Month).Length = 1, "0" + CStr(dtpBPBDate.Value.Month), CStr(dtpBPBDate.Value.Month))
      
        dtCurrentStock.Clear()
        cmd.CommandText = "EXEC sp_Retrieve_CurrentStock_ByKey '" & Period & "', '" & cb_warehouse.SelectedValue & "', '" & txt_ItemID.Text.Trim & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtCurrentStock)

        dc(0) = dtCurrentStock.Columns("Item_ID")
        dtCurrentStock.PrimaryKey = dc
    End Sub

    Private Sub InsertData()
        Dim objTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim dc(0) As DataColumn
        Dim dr As DataRow

        dc(0) = dtDetailOriginal.Columns("Item ID")
        dtDetailOriginal.PrimaryKey = dc

        txtBPBNo.Text = Generate_TranNo(Me.Name)
        LastSerial = CInt(Microsoft.VisualBasic.Right(txtBPBNo.Text, 3))

        Remarks_Stok = "Transaction : " & txtBPBNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        objTrans = conn.BeginTransaction("Trans")
        cmd.Transaction = objTrans

        Select Case cb_category.SelectedItem
            Case "Division"
                StatusID = "WAFS"
            Case "Order Maintenance"
                StatusID = "WAFS"
            Case Else
                StatusID = "WAWA"
        End Select

        Try
            For Each item As DataRow In dtDetail.Rows
                If Not item.RowState = DataRowState.Deleted Then
                    AveragePrice = 0
                    AveragePrice = GetAverageValue((CStr(GetCurrYear()) & IIf(CStr(GetCurrMonth()).Length = 1, "0" & CStr(GetCurrMonth()), CStr(GetCurrMonth()))), item("Item ID"))
                    cmd.CommandText = "EXEC sp_Insert_Trans_BPB_Dtl '" & _
                                      txtBPBNo.Text & "', '" & _
                                      item("Item ID") & "', '" & _
                                      item("Qty Required") & "', '" & _
                                      item("Qty Approved") & "', '" & _
                                      Replace(CStr(AveragePrice), ",", ".") & "', '" & _
                                      item("Remark") & "'"
                    cmd.ExecuteNonQuery()

                    If StatusID.Trim = "WAWA" And Not (cb_category.SelectedItem = "Division" Or _
                    cb_category.SelectedItem = "Order Maintenance") Then
                        dr = dtDetailOriginal.Rows.Find(item("Item ID"))
                        If dr Is Nothing Then
                            StatusID = "WAFS"
                        Else
                            If dr("Qty Required") < item("Qty Required") Then
                                StatusID = "WAFS"
                            End If
                        End If
                    End If
                End If
            Next

            cmd.CommandText = "EXEC sp_Insert_Trans_BPB_Hdr '" & _
                              txtBPBNo.Text & "', '" & _
                              cb_category.SelectedItem & "', '" & _
                              txtRefNo.Text.Trim & "', '" & _
                              cb_accountcode.SelectedValue & "', '" & _
                              Format(Today, "MM-dd-yyy") & "', '" & _
                              Format(dtpRequiredDate.Value, "MM-dd-yyyy") & "', '" & _
                              StatusID & "', '" & _
                              cb_warehouse.SelectedValue & "', '" & _
                              txtRemark.Text.Trim & "', '" & _
                              RejectReason & "', '" & _
                              userlog.UserName & "'"
            cmd.ExecuteNonQuery()

            InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri

            Select Case StatusID
                Case "WAFS"
                    InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to INBOX Purchasing
                Case Else
                    InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to INBOX Purchasing
            End Select

            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txtBPBNo.Text.Trim, Me.Name, "SUBMIT") 'Insert History transaction
            objTrans.Commit()
            conn.Close()

            MsgBox("BPB No : " & txtBPBNo.Text.Trim & " has been Submitted")
        Catch ex As Exception
            MsgBox("InsertData: " & ex.Message)
        End Try

    End Sub

    Private Sub UpdateData()
        Dim objTrans As SqlTransaction
        Dim dc(0) As DataColumn
        Dim dr As DataRow

        dc(0) = dtDetailOriginal.Columns("Item ID")
        dtDetailOriginal.PrimaryKey = dc
        Remarks_Stok = "Transaction : " & txtBPBNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
        Price = 0

        'NOTE: Tidak ada approval ke Warehouse Head kecuali PR (Permintaan Pembelian
        If StatusTrans = "REJECT" Then
            Select Case StatusID.Trim
                Case "WAFS"
                    StatusID = "RBS"
                Case "WAWA"
                    StatusID = "RBWA"
            End Select
        Else
            Select Case StatusID.Trim
                Case "WAFS"
                    StatusID = "WAWA"
                Case "WAWA"
                    StatusID = "WCFR"
                Case "WCFR"
                    StatusID = "CMP"
                Case Else
                    If (cb_category.SelectedItem = "Division" Or cb_category.SelectedItem = "Order Maintenance") _
                        And (StatusID.Trim = "RBS" Or StatusID.Trim = "RBWA" Or StatusID.Trim = "RBWH") Then
                        StatusID = "WAFS"
                    ElseIf Not (cb_category.SelectedItem = "Division" Or cb_category.SelectedItem = "Order Maintenance") _
                        And (StatusID.Trim = "RBS" Or StatusID.Trim = "RBWA" Or StatusID.Trim = "RBWH") Then
                        StatusID = "WAWA"
                    End If
            End Select
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()

            conn.Open()
            objTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = objTrans

            For Each item As DataRow In dtDetail.Rows
                AveragePrice = 0
                AveragePrice = GetAverageValue((CStr(GetCurrYear()) & IIf(CStr(GetCurrMonth()).Length = 1, "0" & CStr(GetCurrMonth()), CStr(GetCurrMonth()))), item("Item ID"))

                Select Case item.RowState
                    Case DataRowState.Added
                        cmd.CommandText = "EXEC sp_Insert_Trans_BPB_Dtl '" & _
                                          txtBPBNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          Replace(CStr(AveragePrice), ",", ".") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                        'Jika status sudah approved by warehouse admin maka update stok
                        If StatusID.Trim = "WCFR" And item("Qty Approved") > 0 Then
                            Price = Price + (item("Qty Approved") * (GetAverageValue((CStr(GetCurrYear()) & IIf(CStr(GetCurrMonth()).Length = 1, "0" & CStr(GetCurrMonth()), CStr(GetCurrMonth()))), item("Item ID"))))
                            Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txtBPBNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                        ElseIf (StatusIDOld.Trim = "RBS" Or StatusIDOld.Trim = "RBWA") And _
                           StatusID.Trim = "WAWA" And Not (cb_category.SelectedItem = "Division" Or _
                           cb_category.SelectedItem = "Order Maintenance") Then

                            dr = dtDetailOriginal.Rows.Find(item("Item ID"))
                            If dr Is Nothing Then
                                StatusID = "WAFS"
                            Else
                                If dr("Qty Required") < item("Qty Required") Then
                                    StatusID = "WAFS"
                                End If
                            End If
                        End If
                    Case DataRowState.Modified
                        cmd.CommandText = "EXEC sp_Update_Trans_BPB_Dtl '" & _
                                          txtBPBNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          Replace(CStr(AveragePrice), ",", ".") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                        'Jika status sudah approved by warehouse admin maka update stok
                        If StatusID.Trim = "WCFR" And item("Qty Approved") > 0 Then
                            Price = Price + (item("Qty Approved") * (GetAverageValue((CStr(GetCurrYear()) & IIf(CStr(GetCurrMonth()).Length = 1, "0" & CStr(GetCurrMonth()), CStr(GetCurrMonth()))), item("Item ID"))))
                            Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txtBPBNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                        ElseIf (StatusIDOld.Trim = "RBS" Or StatusIDOld.Trim = "RBWA") And _
                           StatusID.Trim = "WAWA" And Not (cb_category.SelectedItem = "Division" Or _
                           cb_category.SelectedItem = "Order Maintenance") Then

                            dr = dtDetailOriginal.Rows.Find(item("Item ID"))
                            If dr Is Nothing Then
                                StatusID = "WAFS"
                            Else
                                If dr("Qty Required") < item("Qty Required") Then
                                    StatusID = "WAFS"
                                End If
                            End If
                        End If
                    Case DataRowState.Deleted
                        cmd.CommandText = "EXEC sp_Delete_Trans_BPB_Dtl '" & _
                                          txtBPBNo.Text & "', '" & _
                                          item(0, DataRowVersion.Original).ToString & "'"
                        cmd.ExecuteNonQuery()
                    Case Else
                        cmd.CommandText = "EXEC sp_Update_Trans_BPB_Dtl '" & _
                                          txtBPBNo.Text & "', '" & _
                                          item("Item ID") & "', '" & _
                                          item("Qty Required") & "', '" & _
                                          item("Qty Approved") & "', '" & _
                                          Replace(CStr(AveragePrice), ",", ".") & "', '" & _
                                          item("Remark") & "'"
                        cmd.ExecuteNonQuery()

                        'Jika status sudah approved by warehouse admin maka update stok
                        If StatusID.Trim = "WCFR" And item("Qty Approved") > 0 Then
                            Price = Price + (item("Qty Approved") * (GetAverageValue((CStr(GetCurrYear()) & IIf(CStr(GetCurrMonth()).Length = 1, "0" & CStr(GetCurrMonth()), CStr(GetCurrMonth()))), item("Item ID"))))
                            Insert_StokMovement(item("Item ID"), cb_warehouse.SelectedValue, txtBPBNo.Text.Trim, "OUT", item("Qty Approved"), Remarks_Stok)
                        ElseIf (StatusIDOld.Trim = "RBS" Or StatusIDOld.Trim = "RBWA") And _
                           StatusID.Trim = "WAWA" And Not (cb_category.SelectedItem = "Division" Or _
                           cb_category.SelectedItem = "Order Maintenance") Then

                            dr = dtDetailOriginal.Rows.Find(item("Item ID"))
                            If dr Is Nothing Then
                                StatusID = "WAFS"
                            Else
                                If dr("Qty Required") < item("Qty Required") Then
                                    StatusID = "WAFS"
                                End If
                            End If
                        End If
                End Select
            Next

            cmd.CommandText = "EXEC sp_Update_Trans_BPB_Hdr '" & _
                              txtBPBNo.Text & "', '" & _
                              cb_accountcode.SelectedValue & "', '" & _
                              Format(dtpRequiredDate.Value, "MM-dd-yyyy") & "', '" & _
                              StatusID & "', '" & _
                              cb_warehouse.SelectedValue & "', '" & _
                              txtRemark.Text.Trim & "', '" & _
                              RejectReason & "', '" & _
                              userlog.UserName & "'"
            cmd.ExecuteNonQuery()

            UpdatetoInbox(txtBPBNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txtBPBNo.Text.Trim, StatusID, GetDocCreator(txtBPBNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT" 'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetDocCreator(txtBPBNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                    Case Else
                        If GetDocCreator(txtBPBNo.Text.Trim) = userlog.UserName And StatusID.Trim = "WAFS" Then
                            InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        ElseIf StatusID.Trim = "WCFR" Then 'Authotisasi kembali ke si pembuat (requester)
                            Call InsertJurnal()
                            InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetDocCreator(txtBPBNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        Else
                            InserttoInbox(txtBPBNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        End If
                End Select
            Else
                'Call InsertJurnal()
            End If

            Select Case StatusTrans
                Case "REJECT"
                    Insert_Trans_History(txtBPBNo.Text.Trim, Me.Name, "REJECT") 'Insert History transaction
                Case Else
                    If GetDocCreator(txtBPBNo.Text.Trim) = userlog.UserName Then
                        Insert_Trans_History(txtBPBNo.Text.Trim, Me.Name, "RE-SUBMIT") 'Insert History transaction
                    Else
                        Insert_Trans_History(txtBPBNo.Text.Trim, Me.Name, "APPROVE") 'Insert History transaction
                    End If
            End Select

            lbl_status.Text = GetStatus(StatusID) 'Get Status Description
            objTrans.Commit()
            conn.Close()

            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("BPB No : " & txtBPBNo.Text.Trim & " has been Rejected")
                Case Else
                    If GetDocCreator(txtBPBNo.Text.Trim) = userlog.UserName Then
                        If StatusID.Trim <> "CMP" Then
                            MsgBox("BPB No : " & txtBPBNo.Text.Trim & " has been Submitted")
                        Else
                            MsgBox("BPB No : " & txtBPBNo.Text.Trim & " has been Confirmed")
                        End If
                    Else
                        MsgBox("BPB No : " & txtBPBNo.Text.Trim & " has been Approved")
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

                cmd.CommandText = "EXEC sp_Update_Trans_BPB_Hdr '" & _
                                  txtBPBNo.Text & "', '" & _
                                  cb_accountcode.SelectedValue & "', '" & _
                                  Format(dtpRequiredDate.Value, "MM-dd-yyyy") & "', '" & _
                                  StatusID & "', '" & _
                                  cb_warehouse.SelectedValue & "', '" & _
                                  txtRemark.Text.Trim & "', '" & _
                                  RejectReason & "', '" & _
                                  userlog.UserName & "'"

                cmd.ExecuteNonQuery()
                UpdatetoInbox(txtBPBNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txtBPBNo.Text.Trim, StatusID, GetDocCreator(txtBPBNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txtBPBNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                conn.Close()
                MsgBox("BPB No : " & txtBPBNo.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
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

    Private Sub RetrieveData(ByVal IsWHAdmin As Boolean)
        Dim dtTableHdr As New DataTable
        Dim dtTableDtl As New DataTable
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Trans_BPB_Hdr_ByKey 'By BPB No', '" & txtBPBNo.Text & "', '01-01-1999', '01-01-1999'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableHdr)

            If dtTableHdr.Rows.Count = 0 Then Exit Sub

            txtRefNo.Text = dtTableHdr.Rows(0).Item("Ref No")
            dtpBPBDate.Value = dtTableHdr.Rows(0).Item("Date")
            dtpRequiredDate.Value = dtTableHdr.Rows(0).Item("Required Date")
            txtRemark.Text = dtTableHdr.Rows(0).Item("Information")
            cb_category.SelectedItem = dtTableHdr.Rows(0).Item("Category")
            txt_Reason.Text = dtTableHdr.Rows(0).Item("Reject Reason")
            StatusID = dtTableHdr.Rows(0).Item("Status ID").ToString.Trim
            StatusIDOld = dtTableHdr.Rows(0).Item("Status ID").ToString.Trim
            RejectReason = dtTableHdr.Rows(0).Item("Reject Reason")
            lbl_status.Text = GetStatus(StatusID)

            If StatusID.Trim = "WCFR" Then
                ts_save.Text = "Confirm"
            End If

            cmd.CommandText = "EXEC sp_Retrieve_Trans_BPB_Dtl_ByBPBNo '" & txtBPBNo.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableDtl)
            conn.Close()

            dgvDetail.DataSource = dtTableDtl

            If dtTableDtl.Rows.Count = 0 Then Exit Sub
            dtDetail = dtTableDtl

            txt_ItemID.Text = dtTableDtl.Rows(0).Item("Item ID").ToString
            txt_ItemName.Text = dtTableDtl.Rows(0).Item("Item Name").ToString
            Txt_UoM.Text = dtTableDtl.Rows(0).Item("UoM").ToString
            Txt_Qty.Text = dtTableDtl.Rows(0).Item("Qty Required").ToString
            Txt_QtyRec.Text = dtTableDtl.Rows(0).Item("Qty Approved").ToString
            txt_ket.Text = dtTableDtl.Rows(0).Item("Remark").ToString

            dtDetailOriginal.Clear()
            Select Case cb_category.SelectedItem
                Case "SPK"
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_PHMarketing_Item_Dtl_BySPKNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
                    conn.Close()
                Case "Order Pabrikasi"
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
                    conn.Close()
            End Select

            'If (StatusTrans = TransStatus.NoStatus And StatusTrans = TransStatus.NoStatus) And _
            '    StatusID = "WAWA" Then
            If IsWHAdmin And StatusID = "WAWA" Then
                dgvDetail.Columns("Current Stock").Visible = True
                dgvDetail.Columns("Minimal Stock").Visible = True
            Else
                dgvDetail.Columns("Current Stock").Visible = False
                dgvDetail.Columns("Minimal Stock").Visible = False
            End If

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
                    txtBPBNo.Text & "', '" & _
                    "False', '" & _
                    "', '" & _
                    "False', '" & _
                    "', '" & _
                    userlog.UserName & "'"
        cmd.ExecuteNonQuery()

        Select Case cb_category.SelectedItem

            Case "SPK"
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "162', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "161', '" & _
                                    "0', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
            Case "Order Pabrikasi"
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "163', '" & _
                                     Replace(CStr(Price), ",", ".") & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "161', '" & _
                                    "0', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
            Case "Division"
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    cb_accountcode.SelectedValue & "', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "161', '" & _
                                    "0', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
            Case "Order Maintenance"
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    cb_accountcode.SelectedValue & "', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "161', '" & _
                                    "0', '" & _
                                    Replace(CStr(Price), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
        End Select
        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
    End Sub

    Function Validation() As Boolean
        Validation = True

        If cb_category.SelectedItem = "" Then
            MsgBox("Please Order Category", MsgBoxStyle.Information, "Information")
            cb_category.Focus()
            Validation = False
            Exit Function
        End If

        If txtRefNo.Text.Trim = "" And cb_category.SelectedItem = "SPK" Then
            MsgBox("Please fill SPK No. on Reference No.", MsgBoxStyle.Information, "Information")
            txtRefNo.Focus()
            Validation = False
            Exit Function
        End If

        If txtRefNo.Text.Trim = "" And cb_category.SelectedItem = "Order Pabrikasi" Then
            MsgBox("Please fill Order Pabrikasi No. on Reference No", MsgBoxStyle.Information, "Information")
            txtRefNo.Focus()
            Validation = False
            Exit Function
        End If

        If txtRefNo.Text.Trim = "" And cb_category.SelectedItem = "Order Maintenance" Then
            MsgBox("Please fill Order Maintenance No. on Reference No", MsgBoxStyle.Information, "Information")
            txtRefNo.Focus()
            Validation = False
            Exit Function
        End If

        If cb_accountcode.SelectedValue = "" And (cb_category.SelectedItem = "Division" Or _
           cb_category.SelectedItem = "Order Maintenance ") Then
            MsgBox("Please choose Account Code", MsgBoxStyle.Information, "Information")
            cb_accountcode.Focus()
            Validation = False
            Exit Function
        End If

        If dtDetail.Rows.Count = 0 Then
            MsgBox("Please input Detail Item", MsgBoxStyle.Information, "Information")
            txtRefNo.Focus()
            Validation = False
            Exit Function
        End If
    End Function

#End Region

#Region "Event Handler"

    Private Sub dgvDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetail.CellClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If dtDetail.Rows.Count = 0 Then Exit Sub

        If dgvDetail.CurrentRow.DataGridView(0, dgvDetail.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Btn_cancel_Click(Nothing, Nothing)
        txt_ItemID.Text = dgvDetail.CurrentRow.DataGridView("Item ID", dgvDetail.CurrentRow.Index).Value.ToString
        txt_ItemName.Text = dgvDetail.CurrentRow.DataGridView("Item Name", dgvDetail.CurrentRow.Index).Value.ToString
        Txt_UoM.Text = dgvDetail.CurrentRow.DataGridView("UoM", dgvDetail.CurrentRow.Index).Value.ToString
        Txt_Qty.Text = dgvDetail.CurrentRow.DataGridView("Qty Required", dgvDetail.CurrentRow.Index).Value.ToString
        Txt_QtyRec.Text = dgvDetail.CurrentRow.DataGridView("Qty Approved", dgvDetail.CurrentRow.Index).Value.ToString
        txt_ket.Text = dgvDetail.CurrentRow.DataGridView("Remark", dgvDetail.CurrentRow.Index).Value.ToString
    End Sub

    Private Sub cb_category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_category.SelectedIndexChanged
        If cb_category.SelectedItem = "Division" Then
            txtRefNo.Enabled = False
            cb_accountcode.Enabled = True
            txtRefNo.Clear()
        ElseIf cb_category.SelectedItem = "Order Maintenance" Then
            txtRefNo.Enabled = True
            cb_accountcode.Enabled = True
        Else
            txtRefNo.Enabled = True
            cb_accountcode.Enabled = False
            cb_accountcode.SelectedValue = ""
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
                dgvDetail.Focus()
            End If
        End If
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

                If (Txt_Qty.Text.Trim = "" Or Txt_Qty.Text.Trim = "0") And StatusID <> "WAWA" Then
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

                If StatusID.Trim = "WAWA" Then
                    Call GetCurrentStock()
                    If dtCurrentStock.Rows.Count <> 0 Then
                        If CDbl(Txt_QtyRec.Text) > dtCurrentStock.Rows(0).Item("Current_Stock") Then
                            MsgBox("Stock in Warehouse isn't enough [Current Stock = " & dtCurrentStock.Rows(0).Item("Current_Stock") & "]", MsgBoxStyle.Information, "Information")
                            Exit Sub
                        End If

                        dr("Current Stock") = dtCurrentStock.Rows(0).Item("Current_Stock")
                        dr("Minimal Stock") = dtCurrentStock.Rows(0).Item("Min_Stock")
                    End If
                End If


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

                    If StatusID.Trim = "WAWA" Then
                        If CDbl(Txt_QtyRec.Text) > dr("Current Stock") Then
                            MsgBox("Stock in Warehouse isn't enough [Current Stock = " & dr("Current Stock") & "]", MsgBoxStyle.Information, "Information")
                            Exit Sub
                        End If
                    End If

                    If Txt_QtyRec.Text.Trim = "" Then Txt_QtyRec.Text = 0

                    dr("Qty Required") = Txt_Qty.Text
                    dr("Qty Approved") = Txt_QtyRec.Text
                    dr("Remark") = txt_ket.Text
                End If
        End Select
        dgvDetail.DataSource = dtDetail
        StatusTransDetail = "SAVE"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDisableInputDetail()
    End Sub

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

                Call frmPermintaanPengeluaranBahan_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            frmPermintaanPengeluaranBahan_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "APPROVE"
            If Validation() = False Then Exit Sub

            Call UpdateData()
            Call frmPermintaanPengeluaranBahan_Load(False, e)
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
                    Call frmPermintaanPengeluaranBahan_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

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

    Private Sub frmPermintaanPengeluaranBahan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                Dim frmChild As New frmPermintaanPengeluaranBahanView
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormPermintaanPengeluaranBahanView" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select


    End Sub

    Private Sub frmPermintaanPengeluaranBahan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Call GetWarehouse()
        Call GetAccountCode()
        Call SetColumnDetail()

        If txtBPBNo.Text.ToString.Trim <> "" Then 'Dipanggil dari View

            Select Case CheckAuthorisasi(txtBPBNo.Text.ToString.Trim, userlog.UserName)
                Case True
                    StatusTrans = TransStatus.NoStatus
                Case Else
                    StatusTrans = "READ"
            End Select

            Call RetrieveData(CheckAuthorisasi(txtBPBNo.Text.ToString.Trim, userlog.UserName))

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

    Private Sub txtRefNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefNo.KeyDown
        Dim dtTable As New DataTable
        If e.KeyCode = Keys.F1 Then
            dtDetail.Clear()
            dtDetailOriginal.Clear()
            Select Case cb_category.SelectedItem
                Case "SPK"
                    Try
                        CallandGetSearchData("EXEC sp_Retrieve_Trans_SPK_ALL", "SPK No", "SPK Date", "Project No", "Project Name", "Remarks")

                        txtRefNo.Text = frmSearch.txtResult1.Text.Trim

                        If txtRefNo.Text.Trim = "" Then
                            MsgBox("Please select SPK No", MsgBoxStyle.Information, "Information")
                            txtRefNo.Focus()
                            Exit Sub
                        End If

                        Call GetBuffer()

                        dgvDetail.DataSource = dtDetail

                        GroupBox2.Enabled = True

                        If dgvDetail.RowCount > 0 Then
                            txt_ItemID.Text = dgvDetail.CurrentRow.DataGridView(0, dgvDetail.CurrentRow.Index).Value.ToString
                            txt_ItemName.Text = dgvDetail.CurrentRow.DataGridView(1, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_UoM.Text = dgvDetail.CurrentRow.DataGridView(2, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_Qty.Text = dgvDetail.CurrentRow.DataGridView(3, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_QtyRec.Text = dgvDetail.CurrentRow.DataGridView(4, dgvDetail.CurrentRow.Index).Value.ToString
                        End If
         
                        SetButton()
                        EnableDisableInputDetail()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Case "Order Pabrikasi"
                    Try
                        CallandGetSearchData("EXEC sp_Retrieve_Trans_OrderPabrikasi_ALL", "OP No.", "Order Date", "Remarks", "", "")

                        txtRefNo.Text = frmSearch.txtResult1.Text.Trim

                        If txtRefNo.Text.Trim = "" Then
                            MsgBox("Please Select Order Pabrikasi No.", MsgBoxStyle.Information, "Information")
                            txtRefNo.Focus()
                            Exit Sub
                        End If

                        'If conn.State = ConnectionState.Open Then conn.Close()
                        'conn.Open()
                        'cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                        'DA.SelectCommand = cmd
                        'DA.Fill(dtTable)
                        'conn.Close()

                        'If dtTable.Rows.Count = 0 Then
                        '    MsgBox("Data with Order No : " & txtRefNo.Text.Trim & " isn't exist / has been created", MsgBoxStyle.Information, "Information")
                        '    Exit Sub
                        'End If
                        'dgvDetail.DataSource = dtTable
                        'dtDetail = dtTable

                        'If conn.State = ConnectionState.Open Then conn.Close()
                        'conn.Open()
                        'cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                        'DA.SelectCommand = cmd
                        'DA.Fill(dtDetailOriginal)
                        'conn.Close()


                        Call GetBuffer()
                        dgvDetail.DataSource = dtDetail

                        GroupBox2.Enabled = True

                        If dgvDetail.RowCount > 0 Then
                            txt_ItemID.Text = dgvDetail.CurrentRow.DataGridView(0, dgvDetail.CurrentRow.Index).Value.ToString
                            txt_ItemName.Text = dgvDetail.CurrentRow.DataGridView(1, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_UoM.Text = dgvDetail.CurrentRow.DataGridView(2, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_Qty.Text = dgvDetail.CurrentRow.DataGridView(3, dgvDetail.CurrentRow.Index).Value.ToString
                            Txt_QtyRec.Text = dgvDetail.CurrentRow.DataGridView(4, dgvDetail.CurrentRow.Index).Value.ToString
                        End If
                        SetButton()
                        EnableDisableInputDetail()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Case "Order Maintenance"
                    Try
                        CallandGetSearchData("SELECT * FROM Trans_OrderMaintance WHERE Status_ID = 'CMP'", "OrderMaint_No", "OrderMaint_dt", "Remarks", "", "")

                        txtRefNo.Text = frmSearch.txtResult1.Text.Trim

                        If txtRefNo.Text.Trim = "" Then
                            MsgBox("Please Select Order Order Maintenance No.", MsgBoxStyle.Information, "Information")
                            txtRefNo.Focus()
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
            End Select
        ElseIf e.KeyCode = Keys.Enter Then
            dtDetail.Clear()
            dtDetailOriginal.Clear()
            Select Case cb_category.SelectedItem
                Case "SPK"
                    dtDetail.Clear()
                    If txtRefNo.Text.Trim = "" Then
                        MsgBox("Please Enter SPK No", MsgBoxStyle.Information, "Information")
                        txtRefNo.Focus()
                        Exit Sub
                    End If
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_PHMarketing_Item_Dtl_BySPKNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtTable)
                    conn.Close()

                    If dtTable.Rows.Count = 0 Then
                        MsgBox("Data with SPK : " & txtRefNo.Text.Trim & " isn't exist / has been created", MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                    dgvDetail.DataSource = dtTable
                    dtDetail = dtTable

                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
                    conn.Close()

                    GroupBox2.Enabled = True

                    txt_ItemID.Text = dgvDetail.CurrentRow.DataGridView(0, dgvDetail.CurrentRow.Index).Value.ToString
                    txt_ItemName.Text = dgvDetail.CurrentRow.DataGridView(1, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_UoM.Text = dgvDetail.CurrentRow.DataGridView(2, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_Qty.Text = dgvDetail.CurrentRow.DataGridView(3, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_QtyRec.Text = dgvDetail.CurrentRow.DataGridView(4, dgvDetail.CurrentRow.Index).Value.ToString

                    SetButton()
                    EnableDisableInputDetail()
                Case "Order Pabrikasi"
                    dtDetail.Clear()
                    If txtRefNo.Text.Trim = "" Then
                        MsgBox("Please Enter Order Pabrikasi No.", MsgBoxStyle.Information, "Information")
                        txtRefNo.Focus()
                        Exit Sub
                    End If
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtTable)
                    conn.Close()

                    If dtTable.Rows.Count = 0 Then
                        MsgBox("Data with Order No : " & txtRefNo.Text.Trim & " isn't exist / has been created", MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                    dgvDetail.DataSource = dtTable
                    dtDetail = dtTable

                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderPabrikasi_Dtl_ByOPNo '" & txtRefNo.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtDetailOriginal)
                    conn.Close()

                    GroupBox2.Enabled = True

                    txt_ItemID.Text = dgvDetail.CurrentRow.DataGridView(0, dgvDetail.CurrentRow.Index).Value.ToString
                    txt_ItemName.Text = dgvDetail.CurrentRow.DataGridView(1, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_UoM.Text = dgvDetail.CurrentRow.DataGridView(2, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_Qty.Text = dgvDetail.CurrentRow.DataGridView(3, dgvDetail.CurrentRow.Index).Value.ToString
                    Txt_QtyRec.Text = dgvDetail.CurrentRow.DataGridView(4, dgvDetail.CurrentRow.Index).Value.ToString

                    SetButton()
                    EnableDisableInputDetail()
            End Select
        End If
    End Sub

#End Region

End Class