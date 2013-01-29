Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmBuktiSerahTerima
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt_OP As New DataTable
    Dim dt_item As New DataTable
    Dim dr_item As DataRow
    Dim dt_ST As New DataTable        
    Dim id_login As String
    Dim Status_Proses As String
#Region "INTERFACE"
    Private Sub frmTerimaBrg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        Clear_Wa()

        If txt_TransNo.Text.ToString.Trim <> "" Then 'Jika dipanggil dari View Penerimaan Barang
            Load_ST()
            Load_Grid()
            Refresh_Grid()
            ts_Edit.Enabled = True
            btn_insert.Enabled = False
            gv_STB.Enabled = False
            lbl_status.Text = GetStatus(id_status)
            Enable_Wa(False)
            EnableInput(False)
            DisableButton(False)
            Enable_Button_Wa(False)
        Else
            ts_New.Enabled = True            
            Load_Grid() 'untuk membentuk kerangka Datatable yang digunakan di GridView            
        End If

        SetBackColor_Wa("READ")

    End Sub

    Private Sub ts_FindPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_FindPO.Click
        Dim frm As New FrmViewStockMovement
        frm.ShowDialog()
    End Sub

    Private Sub txt_OPNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_OPNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select OP_no,OP_Date,SPK_No,Due_Date,PIC from Trans_OrderPabrikasi where Status_ID = 'WRGW'", "OP_No", "OP_Date", "SPK_NO", "Due_Date", "PIC")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_OPNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                    Load_OPDetail()
                    gv_STB.Focus()                
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_OPNo.Text.Trim <> "" Then
                Try                    
                    Load_OPDetail()
                    gv_STB.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
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
        txt_OPNo.Clear()
        txt_PICGudang.Clear()
        txt_Remarks.Clear()
        txt_WarehouseID.Clear()
        txt_WarehouseName.Clear()        
        gv_STB.DataSource = ""
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        dt_STBDate.Enabled = boo
        txt_PICGudang.Enabled = boo
        txt_WarehouseID.Enabled = boo
        txt_Remarks.Enabled = boo
        txt_OPNo.Enabled = boo
        gv_STB.Enabled = boo
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo
        ts_FindPO.Enabled = Not boo
    End Sub

#End Region

#Region "Main Button"
    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        ClearInput()
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        ts_FindPO.Enabled = True
        Status_Proses = ""
        lbl_status.Text = GlobalVar.TransStatus.NewStatus                
        txt_OPNo.Focus()
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        ts_FindPO.Enabled = True
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        DisableButton(False)
        Enable_Button_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        ts_New.Enabled = True
        ClearInput()
        EnableInput(False)
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If dt_item.Rows.Count = 0 Then
            MsgBox("Data detail PO belum terisi. Proses Save dibatalkan")
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

                id_status = "WAFP" 'Waiting approval from Purchasing
                Cmd.CommandText = "EXEC sp_Insert_Trans_SerahTerima_HDr '" & txt_TransNo.Text.Trim & "','" & _
                                             dt_STBDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                             txt_OPNo.Text & "','" & _
                                             txt_PICGudang.Text.Trim & "'," & _
                                             txt_WarehouseID.SelectedText & "," & _
                                             txt_Remarks.Text.Trim & "," & _
                                             id_status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                For Each item As DataRow In dt_item.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_SerahTerima_Dtl '" & item("ST_NO") + "','" & _
                                      item("Item_ID") & "','" & item("Qty_Order") & "," & item("Qty_Jadi") & "'"
                    Cmd.ExecuteNonQuery()

                    'Insert untuk proses bagian Stok
                    Insert_StokMovement(item("Item_ID"), txt_WarehouseID.Text.Trim, txt_TransNo.Text.Trim, "IN", item("Qty_Jadi"), remarks_Stok)
                Next
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to INBOX Purchasing
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
            ElseIf id_status.Trim = "WAFP" Then 'Waiting approval  from Purchasing
                Status_Proses = "CMP" 'COMPLETE
                'update Terima Barang Header
                Cmd.CommandText = "EXEC sp_Update_Trans_SerahTerima_Hdr '" & txt_TransNo.Text & "','" & dt_STBDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                   txt_OPNo.Text.Trim & "','" & txt_PICGudang.Text.Trim & "','" & txt_WarehouseID.Text & _
                                   "','" & txt_Remarks.Text.Trim & "','" & id_status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                'update Terima Barang Detail
                For Each item As DataRow In dt_item.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Trans_SerahTerima_Dtl '" & item("ST_NO") + "','" & _
                                      item("Item_ID") & "','" & "'," & item("Qty_Order") & "," & item("Qty_Jadi") & "'"
                        Cmd.ExecuteNonQuery()

                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_SerahTerima_Dtl '" & txt_TransNo.Text + "','" & _
                                           item("Item_ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_SerahTerima_Dtl '" & txt_TransNo.Text & "'," & item("Item_ID") & "," & _
                                           item("Qty_Jadi") & ""
                        Cmd.ExecuteNonQuery()
                    End If
                Next

                UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                If id_status <> "CMP" Then
                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to NEXT APPROVAL
                End If
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
            End If

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Bon Serah Terima Barang : " & txt_TransNo.Text.Trim & " Has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                frmTerimaBrg_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click

    End Sub

#End Region

#Region "Proses"
    Private Sub Load_ST()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            'Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retreive_trans_SerahTerima_bySTNo '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_ST)

            If dt_ST.Rows.Count > 0 Then
                dt_STBDate.Value = dt_ST.Rows(0).Item("ST_Date")
                txt_OPNo.Text = dt_ST.Rows(0).Item("PO_No").ToString.Trim
                txt_PICGudang.Text = dt_ST.Rows(0).Item("PIC_Warehouse")
                txt_PICName.Text = dt_ST.Rows(0).Item("PIC_Name")
                txt_WarehouseID.Text = dt_ST.Rows(0).Item("Warehouse_ID")
                txt_WarehouseName.Text = dt_ST.Rows(0).Item("Warehouse_Name")
                txt_Remarks.Text = dt_ST.Rows(0).Item("Remarks").ToString.Trim
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Load_OPDetail()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            If dt_item.Rows.Count = 0 Then
                'Pindahin dr datatable PO ke datatable TrmBrg                            
                Cmd.CommandText = "EXEC sp_Retreive_Trans_OrderPabrikasi_Hdr '" + txt_OPNo.Text.Trim + "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_OP)
                For Each item As DataRow In dt_OP.Rows
                    Dim dtNewRow As DataRow
                    dtNewRow = dt_item.NewRow()
                    'dtNewRow.Item("ST_No") = txt_TransNo.Text.Trim
                    dtNewRow.Item("Item_ID") = item("Item_Id")
                    dtNewRow.Item("Item_name") = item("Item_name")
                    dtNewRow.Item("UoM") = item("UoM")
                    dtNewRow.Item("Qty_Order") = item("Qty")
                    dtNewRow.Item("Qty_Jadi") = 0
                    dt_item.Rows.Add(dtNewRow)
                Next
            End If
            gv_STB.DataSource = dt_item
            gv_STB.Enabled = dt_item.Rows.Count > 0
            SetGrid()
            'Refresh_Grid()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Refresh_Grid()
        'gv_STB.DataSource = dt_item
        Dim i As Integer = 0
        For Each dr_item As DataRow In dt_item.Rows
            gv_STB.Rows.Item(i).Cells(0).Value = dr_item(GlobalVar.Fields.Item_ID).ToString
            gv_STB.Rows.Item(i).Cells(1).Value = dr_item(GlobalVar.Fields.Item_Name).ToString
            gv_STB.Rows.Item(i).Cells(2).Value = dr_item(GlobalVar.Fields.Item_UOM).ToString
            gv_STB.Rows.Item(i).Cells(3).Value = dr_item(GlobalVar.Fields.Qty_Order).ToString
            gv_STB.Rows.Item(i).Cells(4).Value = dr_item(GlobalVar.Fields.Qty_Jadi).ToString
            i += 1
        Next
    End Sub

    Private Sub SetGrid()
        gv_STB.Columns(0).Width = 90
        gv_STB.Columns(1).Width = 250
        gv_STB.Columns(2).Width = 50
        gv_STB.Columns(3).Width = 100
        gv_STB.Columns(4).Width = 100
    End Sub

    Private Sub Load_Grid()
        Cmd.CommandText = "EXEC sp_Retreive_Trans_SerahTerima_Dtl '" + txt_TransNo.Text + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        gv_STB.Enabled = dt_item.Rows.Count > 0
        gv_STB.DataSource = dt_item
        SetGrid()
    End Sub

    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_Retreive_Item_byItemID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_dtl)

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub txt_WarehouseID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_WarehouseID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Warehouse_ID,Warehouse_Name,Location from Master_Warehouse where Active_Flag = 'Y'", "Warehouse_ID", "Warehouse_Name", "Location", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_WarehouseID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_WarehouseName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_Remarks.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_WarehouseID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retreive_Master_Warehouse_ByWarehouseID '" & txt_WarehouseID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        txt_WarehouseID.Text = dt_item.Rows(0).Item("Warehouse_ID").ToString
                        txt_WarehouseName.Text = dt_item.Rows(0).Item("Warehouse_Name").ToString
                        txt_Remarks.Focus()
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

    Private Sub txt_PICGudang_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PICGudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select UserName,Name,Employee_ID,Email, sex from Employee where Active_Flag = 'Y'", "UserName", "Employee_ID", "Name", "Email", "sex")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_PICGudang.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_PICName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_Remarks.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_WarehouseID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_retreiveEmployee_ByUserName '" & txt_PICGudang.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        txt_PICGudang.Text = dt_item.Rows(0).Item("UserName").ToString
                        txt_PICName.Text = dt_item.Rows(0).Item("Name").ToString
                        txt_Remarks.Focus()
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

#End Region

#Region "Working Area"
    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_ItemID.BackColor = Color.DarkGray
            txt_ItemName.BackColor = Color.DarkGray
            Txt_QtyOrder.BackColor = Color.DarkGray
            Txt_QtyJadi.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            txt_ItemID.BackColor = Color.DarkGray
            txt_ItemName.BackColor = Color.DarkGray
            Txt_QtyOrder.BackColor = Color.DarkGray                    
            Txt_QtyJadi.BackColor = Color.LemonChiffon        
        ElseIf proses = "INSERT" Then
            txt_ItemID.BackColor = Color.LemonChiffon
            txt_ItemName.BackColor = Color.DarkGray
            Txt_QtyOrder.BackColor = Color.DarkGray
            If userlog.Insert_Price = "Y" Then
                Txt_QtyJadi.BackColor = Color.LemonChiffon                
            End If
        End If
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_ItemID.Enabled = boo
        Txt_QtyJadi.Enabled = boo
    End Sub

    Private Sub Clear_Wa()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_QtyOrder.Clear()
        Txt_QtyJadi.Clear()        
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Item_id,Item_Name,UoM,Sales_Price as Harga from Master_Item_Hdr where isPabrikasi ='Y'", "Item_ID", "Item_Name", "UoM", "Harga", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dt_dtl.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dt_dtl.Rows(0).Item("UoM").ToString
                        Txt_QtyJadi.Focus()
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
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr '" & txt_OPNo.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemName.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_QtyJadi.Focus()
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

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"
        Enable_Wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_ItemID.Focus()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        txt_ItemID.Enabled = False 'karna primary Key
        btn_insert.Enabled = False
        btn_edit.Enabled = False
        btn_delete.Enabled = False
        txt_ItemID.BackColor = Color.DarkGray
        Txt_QtyJadi.Focus()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID")
        dt_item.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            DA = dt_item.Rows.Find(txt_ItemID.Text)
            If DA IsNot Nothing Then
                da.Delete()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gv_STB.Focus()
            End If
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_insert.Enabled = True
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gv_STB.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID")
        dt_item.PrimaryKey = dc

        ' Validation
        If Txt_QtyJadi.Text.Trim = "" Then
            MessageBox.Show("Qty Receive harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            dr_item = dt_item.Rows.Find(txt_ItemID.Text)
            If dr_item IsNot Nothing Then
                MessageBox.Show("Item ID ini sudah ada sebelumnya.Silahkan masukan item ID yang lain", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Item_ID") = txt_ItemID.Text
                dr("Item_Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty_Order") = 0
                dr("Qty_Jadi") = Txt_QtyJadi.Text
                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_item.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da("Qty_Jadi") = Txt_QtyJadi.Text
            End If
        End If
        gv_STB.DataSource = dt_item
        Status_Proses = "" 'reset
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub txt_ItemID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ItemID.Leave
        Txt_QtyJadi.Focus()
    End Sub

    Private Sub Txt_QtyJadi_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_QtyJadi.Leave        
        btn_save.Focus()
    End Sub

    Private Sub txt_Harga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode >= Asc("0") AndAlso e.KeyCode <= Asc("9")) OrElse e.KeyCode = Asc("-") OrElse e.KeyCode = Asc(".") OrElse e.KeyCode = 8 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub gv_STB_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_STB.MouseClick
        If String.IsNullOrEmpty(gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value) = False Then
            txt_ItemID.Text = gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
            txt_ItemName.Text = gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
            Txt_UoM.Text = gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
            Txt_QtyOrder.Text = gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty_Order).Value.ToString.Trim
            Txt_QtyJadi.Text = gv_STB.Rows(gv_STB.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty_Jadi).Value.ToString.Trim

        End If
    End Sub
#End Region

    
End Class

