Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class FrmInputStockFisik
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_period As New DataTable
    Dim dt_SF As New DataTable
    Dim dt_item As New DataTable
    Dim dr_item As DataRow
    Dim dt_ST As New DataTable
    Dim id_login As String
    Dim Status_Proses As String
    Dim today As String

    Public CallerForm As String

#Region "Interface"

    Private Sub FrmInputStockFisik_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        dt_TransDate.Value = Now
        txt_Period.Text = GetOpeningPeriod_ByStatus()
        GetWarehouse()

        'SetAccess(Me, userlog.AccessID, Me.Name)
        If txt_TransNo.Text.ToString.Trim <> "" Then 'Jika dipanggil dari View Penerimaan Barang
            Load_SF()
            Load_Grid()
            lbl_Status.Text = GetStatus(id_status)

            If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) = True Then
                DisableButton(False)
                gv.Enabled = False
                If id_status = "WAFA" Then
                    ts_Verify.Enabled = True
                    ts_reject.Enabled = True
                    ts_Edit.Enabled = False
                Else
                    ts_Edit.Enabled = True
                    ts_Verify.Enabled = False
                    ts_reject.Enabled = False
                End If

                btn_LoadItem.Enabled = False
                txt_Period.Enabled = False
                cb_Gudang.Enabled = False
                Exit Sub
            Else
                DisableButton(False)
                gv.Enabled = True
                ts_Verify.Visible = False
                ts_reject.Visible = False
                btn_LoadItem.Enabled = True
                txt_Period.Enabled = True
            End If
        Else
            'Check Status Period
            today = Now.ToString("yyyy-MM-dd")
            'txt_Period.Text = GetOpeningPeriod(today) 'Get Last Period from table Trans_Closing
            Load_Grid()
            'RetreiveItem() 'untuk membentuk kerangka Datatable yang digunakan di GridView            
            lbl_Status.Text = "NEW"
            id_status = ""
            ts_Verify.Visible = False
            ts_reject.Visible = False
            ts_Edit_Click(Nothing, Nothing)
        End If
    End Sub

    Function MonthAlreadyInsert(ByVal Period As String, ByVal WH As String) As Boolean
        Dim dt_check As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from Trans_InsertStockFisik_Hdr where Period ='" & Period & "' and Warehouse_ID = '" & WH & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_check)

        Return dt_check.Rows.Count > 0
        Conn.Close()
    End Function


    Private Sub FrmInputStockFisik_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                Dim frmChild As New FrmViewInsertStockFisik
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FrmViewInsertStockFisik" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select
    End Sub

    Private Sub GetWarehouse()
        Dim dt As New DataTable
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "Select * from Master_Warehouse where InputStockFisik = 'Y'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            cb_Gudang.DataSource = dt
            cb_Gudang.DisplayMember = GlobalVar.Fields.Warehouse_Name
            cb_Gudang.ValueMember = GlobalVar.Fields.Warehouse_ID

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Load_SF()
        Dim dt_header As New DataTable
        Cmd.CommandText = "EXEC sp_Retreive_Trans_InsertStockFisik_Hdr '" + txt_TransNo.Text + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_header)

        If dt_header.Rows.Count > 0 Then
            txt_Period.Text = dt_header.Rows(0).Item("Period").ToString.Trim
            id_status = dt_header.Rows(0).Item("Status_ID").ToString.Trim
        End If
    End Sub

    Private Sub Load_Grid()
        dt_item.Clear()
        Cmd.CommandText = "EXEC sp_Retreive_Trans_InsertStockFisik_Dtl '" + txt_TransNo.Text + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        'gv.Enabled = dt_item.Rows.Count > 0
        gv.DataSource = dt_item
        SetGrid()
    End Sub

    Private Sub SetGrid()
        'Set Read Only
        gv.Columns(0).ReadOnly = True ' item
        gv.Columns(1).ReadOnly = True ' item name
        gv.Columns(2).ReadOnly = True ' uom 
        gv.Columns(4).ReadOnly = True ' qty system

        gv.Columns(0).Width = 90
        gv.Columns(1).Width = 250
        gv.Columns(2).Width = 50
        gv.Columns(3).Width = 70
        gv.Columns(4).Width = 70
        gv.Columns(5).Width = 70
        If userlog.Insert_Price = "Y" Then
            gv.Columns(4).Visible = True
            gv.Columns(5).Visible = True
            gv.Columns(3).ReadOnly = True
        Else
            gv.Columns(4).Visible = False
            gv.Columns(5).Visible = False
            gv.Columns(3).ReadOnly = False
        End If
    End Sub

    Private Sub ClearInput()
        'txt_TransNo.Clear()
        txt_Period.Clear()
    End Sub

    Private Sub RetreiveItem()
        Try
            dt_item.Clear()
            dt_ST.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            'Cek apakah ini Gudang utama atau reject
            If cb_Gudang.SelectedValue = "WH001" Then 'Gudang Utama
                Cmd.CommandText = "EXEC sp_Mapping_MasterItem_StockMovement '" & txt_Period.Text & "','" & cb_Gudang.SelectedValue & "'"
            Else 'Gudang Toko
                Cmd.CommandText = "EXEC sp_Mapping_MasterItem_StockMovement_Toko '" & txt_Period.Text & "'"
            End If

            DA.SelectCommand = Cmd
            DA.Fill(dt_ST)

            If dt_ST.Rows.Count = 0 Then
                MessageBox.Show("There is no Data at this Warehouse. Please choose other Warehouse.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each item As DataRow In dt_ST.Rows
                Dim dtNewRow As DataRow
                dtNewRow = dt_item.NewRow()
                dtNewRow.Item("Item_ID") = item("Item_Id")
                dtNewRow.Item("Item_name") = item("Item_name")
                dtNewRow.Item("UoM") = item("UoM")
                dtNewRow.Item("Qty_Fisik") = 0
                dtNewRow.Item("Qty_System") = item("Current_Stock")
                dtNewRow.Item("Qty_Verify") = 0
                dt_item.Rows.Add(dtNewRow)
            Next
            gv.DataSource = dt_item
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_cancel.Enabled = boo
    End Sub
#End Region

#Region "Main Button"
    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        ts_New.Enabled = True
        dt_item.Clear()
        Button1_Click(Nothing, Nothing)
        ClearInput()
    End Sub
    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        gv.Enabled = True
    End Sub
#End Region

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim dt_currstock As New DataTable

        If Not CheckStatusPeriodClosing(txt_Period.Text.Trim, today) Then
            MessageBox.Show("This Period has been Closed. Please call Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If dt_item.Rows.Count = 0 Then
            MessageBox.Show("There is no Data to be Saved. Process Aborted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        '----Save LPB Header   
        Try
            'Cause this form is for insert Terim Barang, so next status is Waiting for Purchasing (WAFP)
            If id_status.Trim = "" Then
                txt_TransNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
                remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

                id_status = "WAFA" 'Waiting approval from Accounting
                Cmd.CommandText = "EXEC sp_Insert_Trans_InsertStockFisik_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                             dt_TransDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                             txt_Period.Text & "','" & cb_Gudang.SelectedValue & "','" & _
                                             id_status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                'Save detail===========================================================================================================
                For i As Integer = 0 To gv.RowCount - 1
                    Cmd.CommandText = "EXEC sp_Insert_Trans_InsertStockFisik_Dtl '" & txt_TransNo.Text.Trim & "','" & gv.Rows(i).Cells("Item_ID").Value & "'," & _
                                     gv.Rows(i).Cells("Qty_Fisik").Value & "," & gv.Rows(i).Cells("Qty_System").Value & "," & gv.Rows(i).Cells("Qty_Fisik").Value
                    Cmd.ExecuteNonQuery()
                Next
                'Save detail===========================================================================================================

                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(id_status), "W", "Y", id_status) 'Insert to INBOX Accounting
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
            Else 'Revisi karna di reject
                id_status = "WAFA"
                remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " has been revised and processes by " & userlog.UserName & " at " & CStr(Now())
                'update Insert Stock Fisik Header
                Cmd.CommandText = "EXEC sp_Update_Trans_InsertStockFisik_Hdr '" & txt_TransNo.Text & "','" & _
                                   id_status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                'update Terima Barang Detail
                For i As Integer = 0 To gv.RowCount - 1
                    Cmd.CommandText = "EXEC sp_Update_Trans_InsertStockFisik_Dtl '" & txt_TransNo.Text.Trim & "','" & gv.Rows(i).Cells("Item_ID").Value & "'," & _
                                     gv.Rows(i).Cells("Qty_Fisik").Value & "," & gv.Rows(i).Cells("Qty_System").Value & "," & gv.Rows(i).Cells("Qty_Fisik").Value
                    Cmd.ExecuteNonQuery()
                Next
                UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(id_status), "W", "Y", id_status) 'Insert to NEXT APPROVAL
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "RE-SUBMIT") 'Insert History transaction
            End If

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Form Insert Stock Fisik : " & txt_TransNo.Text.Trim & " Has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                FrmInputStockFisik_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LoadItem.Click
        If txt_Period.Text.Trim = "" Then
            MessageBox.Show("Period must be Filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not CheckStatusPeriodClosing(txt_Period.Text.Trim, today) Then
            MessageBox.Show("This Period has been Closed. Please call Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MonthAlreadyInsert(txt_Period.Text.Trim, cb_Gudang.SelectedValue) Then
            MessageBox.Show("Insert Stok Fisik Already Done in this Period. " & vbCrLf & "InsertStockFisik can only Insert once in a period.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
            Me.Close()
        End If

        RetreiveItem() 'untuk membentuk kerangka Datatable yang digunakan di GridView    
    End Sub

    Private Sub ts_Verify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Verify.Click
        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim tmp_selisih As Integer

        '----Save LPB Header   
        Try
            id_status = "CMP" 'COMPLETE
            'update Insert Stock Fisik Header
            Cmd.CommandText = "EXEC sp_Update_Trans_InsertStockFisik_Hdr '" & txt_TransNo.Text & "','" & _
                               id_status & "','" & userlog.UserName & "'"
            Cmd.ExecuteNonQuery()
            'update Terima Barang Detail
            For i As Integer = 0 To gv.RowCount - 1
                tmp_selisih = 0 'reset
                'cek apakah ada adjustment stock dgn cara meng Compare Stock System dengan stock verify
                If gv.Rows(i).Cells("Qty_Fisik").Value < gv.Rows(i).Cells("Qty_System").Value Then
                    tmp_selisih = gv.Rows(i).Cells("Qty_System").Value - gv.Rows(i).Cells("Qty_Fisik").Value
                    Insert_StokMovement_UsingPeriod(txt_Period.Text.Trim, gv.Rows(i).Cells("Item_ID").Value, cb_Gudang.SelectedValue, txt_TransNo.Text.Trim, "OUT", tmp_selisih, "Adjustment stock")
                ElseIf gv.Rows(i).Cells("Qty_Fisik").Value > gv.Rows(i).Cells("Qty_System").Value Then
                    tmp_selisih = gv.Rows(i).Cells("Qty_Fisik").Value - gv.Rows(i).Cells("Qty_System").Value
                    Insert_StokMovement_UsingPeriod(txt_Period.Text.Trim, gv.Rows(i).Cells("Item_ID").Value, cb_Gudang.SelectedValue, txt_TransNo.Text.Trim, "IN", tmp_selisih, "Adjustment stock ")
                End If
                Cmd.CommandText = "EXEC sp_Update_Trans_InsertStockFisik_Dtl '" & txt_TransNo.Text.Trim & "'," & gv.Rows(i).Cells("Item_ID").Value & "," & _
                                   gv.Rows(i).Cells("Qty_Fisik").Value & "," & gv.Rows(i).Cells("Qty_System").Value & "," & gv.Rows(i).Cells("Qty_Verify").Value
                Cmd.ExecuteNonQuery()
            Next

            UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History 

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Form Insert Stock Fisik : " & txt_TransNo.Text.Trim & " Has been Verified", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                FrmInputStockFisik_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Insert_StokMovement_UsingPeriod(ByVal Period As String, ByVal ItemId As String, ByVal Warehouse_ID As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from trans_Stock_Movement where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        maxSeq = dt.Rows(0).Item("MaxSeq")
        maxSeq += 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement '" & Period & "','" & Warehouse_ID & "','" & ItemId & "','" & TransNo_Ref & "'," & maxSeq & ",'" & Sts_Proses & "'," & Qty & ",'" & Remarks & "','" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
    End Sub

    Private Sub ts_reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_reject.Click
        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        '----Save LPB Header   
        Try
            id_status = "RBA" 'Rejected by Accounting
            'update Insert Stock Fisik Header
            Cmd.CommandText = "EXEC sp_Update_Trans_InsertStockFisik_Hdr '" & _
                                          txt_TransNo.Text & "', '" & _
                                          id_status & "', '" & _
                                          userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", id_status) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "REJECTED") 'Insert History 

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Form Insert Stock Fisik : " & txt_TransNo.Text.Trim & " Has been Rejected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                FrmInputStockFisik_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    
End Class