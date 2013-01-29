Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Math
Imports System.Data.SqlClient

Public Class FrmMemoRetur
#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter


    Public CallerForm As String
    Public StatusTrans As String
    Private StatusTransDetail As String
    Private dtDetail As New DataTable
    Private dtHeader As New DataTable
    Private dtItem As New DataTable '--> digunakan untuk pencarian data Item 
    Private StatusID As String

#End Region

#Region "Event Handler - Main"
    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            FrmMemoRetur_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            SetToolTip()
            EnableInput(True)
        End If
    End Sub

    Private Sub SetGrid()
        gv_Memo.Columns(0).Width = 100
        gv_Memo.Columns(1).Width = 60
        gv_Memo.Columns(2).Width = 300
        gv_Memo.Columns(3).Width = 50
        gv_Memo.Columns(4).Width = 100
        gv_Memo.Columns(5).Width = 100
        gv_Memo.Columns(6).Width = 100
        gv_Memo.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv_Memo.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

                If StatusID = "RBWH" Then
                    'Warehouse Admin 
                    ts_save.Visible = True
                    ts_delete.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                ElseIf StatusID = "RBPH" Or StatusID = "WAFA" Or StatusID = "WAFP" Then
                    'Purchasing Admin, Accounting Admin hanya bisa submit
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
            Case ""
                ts_Edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
            Case Else
                ts_Edit.Visible = True
                ts_delete.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
        End Select

    End Sub

    Private Sub SetButton()

        Select Case StatusTransDetail
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
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
        End Select

    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        'NOTE: Read/Write Mode
        Select Case StatusTrans
            Case TransStatus.NewStatus
                txt_Remark.Enabled = True
            Case Else
                txt_Remark.Enabled = False
        End Select

        dt_MemoDate.Enabled = boo
        txt_Remark.Enabled = boo
        gv_Memo.Enabled = boo

    End Sub

    Private Sub DeleteData()
        Dim ObjTrans As SqlTransaction
        Dim dtTable As New DataTable

        If Conn.State = ConnectionState.Closed Then Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            StatusID = "CAP" 'cancelled by applicant

            Cmd.CommandText = "EXEC GetCurrDate"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)

            Cmd.CommandText = "UPDATE Trans_MemoRetur_Hdr SET Status_ID = 'CAP', dt_lastupdated = '" & _
                        dtTable.Rows(0).Item("date") & "', id_lastupdated = '" & userlog.UserName & "'"
            Cmd.ExecuteNonQuery()
            'UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            'UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Memo Retur : " & txt_TransNo.Text.Trim & " Has been Deleted")
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearInput()
        'NOTE: Clear HEADER Area        
        txt_Remark.Clear()
        txt_TransNo.Clear()
        gv_Memo.DataSource = ""
    End Sub
#End Region

    Private Sub FrmMemoRetur_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Call ClearInput()
        Call ClearDetail()

        If txt_TransNo.Text.ToString.Trim <> "" Then 'NOTE: Jika dipanggil dari View Penerimaan Barang
            Call Load_HeaderMemoRetur()
            Call Load_DetailMemoRetur()

            If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) = True Then
                StatusTrans = TransStatus.EditStatus
                StatusTransDetail = "CANCEL"

                Call EnableInput(True)
                Call EnableDetail()
                Call SetBackColorDetail()
                Call SetToolTip()
                Call SetButton()
            Else
                StatusTrans = ""
                StatusTransDetail = ""
                Call EnableInput(False)
                Call EnableDetail()
                Call SetBackColorDetail()
                Call SetToolTip()
                Call SetButton()
            End If
        Else
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = ""
            Call Load_DetailMemoRetur()
            Call EnableDetail()
            Call EnableInput(True)
            Call SetToolTip()
            Call SetButton()
        End If
    End Sub

    Private Sub Load_HeaderMemoRetur()
        'NOTE: Get Header of Good Receipt Transaction based on TB No.
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            dtHeader.Clear()

            'NOTE: Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retreive_trans_MemoRetur_Hdr '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtHeader)

            If dtHeader.Rows.Count > 0 Then
                dt_MemoDate.Value = dtHeader.Rows(0).Item("MemoRetur_Date")
                txt_Remark.Text = dtHeader.Rows(0).Item("Remarks").ToString.Trim
                StatusID = dtHeader.Rows(0).Item("Status_ID").ToString.Trim
                'lbl_status.Text = GetStatus(StatusID)
            End If
        Catch ex As Exception
            MsgBox("Load_TB: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Load_DetailMemoRetur()
        'NOTE: Get Detail of Good Receipt Transaction
        Try
            dtDetail.Clear()
            If Conn.State = ConnectionState.Open Then Conn.Open()
            Cmd.CommandText = "EXEC sp_Retreive_Trans_MemoRetur_Dtl '" + txt_TransNo.Text + "','" + txt_ItemID.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail)

            If dtDetail.Rows.Count > 0 Then
                gv_Memo.DataSource = dtDetail
                Call SetGrid()
            Else
                gv_Memo.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Load_Grid: " & ex.Message)
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub SetBackColorDetail()
        Select Case StatusTransDetail
            Case "INSERT"
                txt_ItemID.BackColor = Color.LemonChiffon
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Keterangan.BackColor = Color.LemonChiffon
            Case "UPDATE"
                txt_ItemID.BackColor = Color.DarkGray
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Keterangan.BackColor = Color.LemonChiffon
            Case Else
                txt_ItemID.BackColor = Color.DarkGray
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
        End Select
    End Sub

    Private Sub EnableDetail()
        Select Case StatusTransDetail
            Case "INSERT"
                txt_ItemID.Enabled = True
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = True
                txt_Keterangan.Enabled = True
            Case "UPDATE"
                txt_ItemID.Enabled = False
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = True
                txt_Keterangan.Enabled = True
            Case Else
                txt_ItemID.Enabled = False
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = False
                txt_Keterangan.Enabled = False
        End Select
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
        Call ClearDetail()
    End Sub

    Private Sub ClearDetail()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_Qty.Clear()
        txt_Keterangan.Clear()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Please choose 1 data to edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        StatusTransDetail = "UPDATE"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(0) As DataColumn
        Dim dr As Data.DataRow

        dc(0) = dtDetail.Columns("Item_ID")
        dtDetail.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose 1 data to deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure to delete this data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            dr = dtDetail.Rows.Find(txt_ItemID.Text.Trim)
            If DA IsNot Nothing Then
                dr.Delete()
                gv_Memo.Focus()
            End If
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click        
        Dim dc(0) As DataColumn
        Dim dr As Data.DataRow        

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail.NewRow
            dr("Item_ID") = txt_ItemID.Text
            dr("Item_Name") = txt_ItemName.Text
            dr("UoM") = Txt_UoM.Text
            dr("Qty") = Txt_Qty.Text
            dr("Remarks") = txt_Keterangan.Text.Trim
            dtDetail.Rows.Add(dr)
            'End If
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dtDetail.Rows.Find(txt_ItemID.Text.Trim)
            If dr IsNot Nothing Then
                dr("Qty") = Txt_Qty.Text
                dr("Remarks") = txt_Keterangan.Text.Trim

            End If
        End If

        gv_Memo.DataSource = dtDetail
        StatusTransDetail = "SAVE"

        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
        Call ClearDetail()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim dtTable As New DataTable
        Dim SQL As String

        SQL = "Select a.item_id,item_name,uom,item_type from " & _
              "(" & _
              "   Select distinct Item_ID from Trans_Stock_Movement a " & _
              "   where a.Warehouse_ID = 'WH003' and a.period = '" & Generate_Period() & "' " & _
              ") a " & _
              "Left Join " & _
              "   Master_Item_Hdr b " & _
              "on a.item_id = b.item_id"

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData(SQL, "Item_ID", "Item_Name", "UoM", "Item_Type", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then Conn.Close()
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dtItem.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dtItem.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dtItem.Rows(0).Item("UoM").ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item can't be found. Please choose ITEM ID correctly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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
                    Cmd.CommandText = SQL & " Where Item_ID = '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_ItemName.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item can't be found. Please choose ITEM ID correctly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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

    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            Cmd.CommandText = "EXEC sp_Retreive_Item_byItemID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtItem)

        Catch ex As Exception
            MsgBox("GetItemData: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Function Validation() As Boolean
        Validation = True

        'NOTE: Validasi Detail PO
        If gv_Memo.Rows.Count = 0 Then
            MsgBox("Detail PO haven't filled. Process cancelled")
            Validation = False
            Exit Function
        End If
    End Function

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

                Call FrmMemoRetur_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub InsertData()
        'NOTE: Variable Declaration
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim Remark_Stok As String

        'NOTE: Set Transaction
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            txt_TransNo.Text = Generate_TranNo(Me.Name)
            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
            Remark_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

            'NOTE: Header AREA
            Cmd.CommandText = "EXEC sp_Insert_Trans_MemoRetur_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                         dt_MemoDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                         txt_Remark.Text & "','" & _
                                         StatusID & "','" & _
                                         userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'NOTE: Detail AREA
            For Each item As DataRow In dtDetail.Rows
                If item.RowState <> DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Insert_Trans_MemoRetur_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("Item_ID") & "','" & _
                                        item("UoM") & "','" & _
                                        Replace(CStr(item("Qty")), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                    Cmd.ExecuteNonQuery()
                End If
            Next

            'NOTE: Insert INBOX (Approval Process Purpose)
            'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID)
            'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID)

            'NOTE: Update Serial Sequence
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

            'NOTE: Insert Transaction History
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT")

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Good Receipt : " & txt_TransNo.Text.Trim & " has been submitted")

        Catch ex As Exception
            ObjTrans.Rollback()
            MsgBox("InsertData: " & ex.Message)
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub UpdateData()
        'NOTE: Variable Declartion
        Dim ObjTrans As SqlTransaction
        'Dim LastSerial As Integer
        Dim Remark_Stok As String

        'NOTE: Set Transaction
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        'NOTE: Get Approval Status
        'If StatusTrans.Trim = "REJECT" Then
        '    Select Case StatusID.Trim
        '        Case "WAWH" 'Waiting Approval Warehouse Head
        '            StatusID = "RBWH" 'Flow to WAWA (Warehouse Admin)
        '        Case "WAPH" 'Waiting Approval for Purchasing Head
        '            StatusID = "RBPH" 'Flow to WAFP (Purchasing Admin)
        '    End Select
        'Else
        '    Select Case StatusID.Trim
        '        Case "WAWH" 'Waiting Approval Warehouse Head
        '            StatusID = "WAFP"
        '        Case "WAFP" 'Waiting Approval for Purchasing
        '            StatusID = "WAPH"
        '        Case "WAPH" 'Waiting Approval for Purchasing Head
        '            StatusID = "WAFA"
        '        Case "WAFA" 'Waiting Approval for Accounting
        '            StatusID = "CMP"
        '        Case Else
        '            If StatusID = "RBWH" Then
        '                StatusID = "WAWH"
        '            ElseIf StatusID = "RBPH" Then
        '                StatusID = "WAPH"
        '            End If
        '    End Select

        'End If

        StatusID = "CMP"
        Try
            Remark_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

            'NOTE: Header AREA
            Cmd.CommandText = "EXEC sp_Update_Trans_TerimaBrg_Hdr '" & _
                                     txt_TransNo.Text & "','" & _
                                     dt_MemoDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                     txt_Remark.Text & "','" & _
                                     StatusID & "','" & _
                                     userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'NOTE: Detail AREA
            For Each item As DataRow In dtDetail.Rows
                If item.RowState = DataRowState.Added Then
                    Cmd.CommandText = "EXEC sp_Insert_Trans_MemoRetur_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("Item_ID") & "','" & _
                                        item("UoM") & "','" & _
                                        Replace(CStr(item("Qty")), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                    Cmd.ExecuteNonQuery()                   

                ElseIf item.RowState = DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Delete_MemoRetur_Dtl '" & _
                                        txt_TransNo.Text + "','" & _
                                        item("MemoRetur_No") & ") ','" & _
                                        item("Item ID", DataRowVersion.Original).ToString & "'"
                    Cmd.ExecuteNonQuery()
                Else
                    Cmd.CommandText = "EXEC sp_Update_Trans_MemoRetur_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No") & "','" & _
                                        item("Item ID") & "'," & _
                                        Replace(CStr(item("Qty Receipt")), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Discount"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & ",'" & _
                                        item("Remark") & "'"
                    Cmd.ExecuteNonQuery()
                    
                End If
            Next

            'NOTE: Insert INBOX (Approval Process Purpose)
            'UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            'UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
           

            'NOTE: Insert Transaction History
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

            ObjTrans.Commit()
            Conn.Close()

            
            MessageBox.Show("Memo Retur : " & txt_TransNo.Text.Trim & " Has been submitted")
                   
        Catch ex As Exception
            'ObjTrans.Rollback()
            MsgBox(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try

    End Sub
End Class