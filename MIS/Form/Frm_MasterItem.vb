Imports MIS.GlobalVar
Imports System.Data.SqlClient
Imports MIS.mdlCommon
Public Class Frm_MasterItem
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
    Dim Stat_pros As String
    Dim dtTemp As New DataTable
    Dim lv_filename As String = ""
    Dim fullPath As String = ""

   
#Region "INTERFACE"
    Private Sub frm_MasterItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        Clear_Wa()
        Enable_Wa(False)
        EnableInput(False)
        DisableButton(False)
        Enable_Button_Wa(False)

        'If txt_TransNo.Text.ToString.Trim <> "" Then 'Jika dipanggil dari View Penerimaan Barang
        '    'Load_ST()
        '    Load_Grid()
        '    'Refresh_Grid()
        '    ts_Edit.Enabled = True
        '    If Status_Proses = "UPDATE" Then
        '        Load_Grid_Header("Item_ID", txt_TransNo.Text.Trim)
        '    End If
        'Else
        '    ts_New.Enabled = True
        '    Load_Grid() 'untuk membentuk kerangka Datatable yang digunakan di GridView
        '    ' txt_TransNo.Text = Generate_TranNo(Me.Name)
        '    'gv_item.DataSource = dt_item
        '    Load_Grid_Header("Item_ID", txt_TransNo.Text.Trim)
        '    cbxPabrikasi.Checked = False
        'End If

        Load_Grid()
        Load_Grid_Header("Item_ID", txt_TransNo.Text.Trim)

        SetBackColor_Wa("READ")
        loadCbsearch()

        ts_New.Enabled = True


    End Sub
    'Private Sub SetToolTip()
    '    Select Case UCase(StatusTrans)
    '        Case "NEW"
    '            ts_Edit.Enabled = False
    '            ts_New.Enabled = False
    '            ts_delete.Enabled = False

    '            ts_save.Enabled = True


    '        Case "EDIT"
    '            ts_Edit.Enabled = False
    '            ts_New.Enabled = False
    '            ts_delete.Enabled = False

    '            ts_save.Enabled = True

    '            SetEnabled(True)
    '        Case Else
    '            btnNew.Enabled = True
    '            btnEdit.Enabled = True
    '            btnDelete.Enabled = True

    '            btnSave.Enabled = False


    '    End Select
    'End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Item_Hdr'"

            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtTemp
            Conn.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Enable_Button_Wa(ByVal boo As Boolean)
        btn_insert.Enabled = boo
        btn_edit.Enabled = boo
        btn_save.Enabled = boo
        btn_delete.Enabled = boo
        Btn_cancel.Enabled = boo
    End Sub

    Private Sub ClearInput()
        txt_TransNo.Clear()
        txtItemName.Clear()
        cbxItemType.Text = ""

        txtWarehouseID.Clear()
        txtItemSize.Clear()
        txtUoM.Clear()
        txtMinStock.Clear()
        txtMaxStock.Clear()
        gv_item.DataSource = ""
        cbxBallValve.Checked = False
        cbxManifold.Checked = False
        cbxPabrikasi.Checked = False
        cbxPipeToTheKitchen.Checked = False
        cbxSelang.Checked = False
        cbxSupportingMaterial.Checked = False
        cbxTitikApi.Checked = False
        lblWarehouseName.Text = ""
        lblSupplierName.Text = ""
        PictureBox.Image = Nothing

        txtPict.Clear()
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        txtItemName.Enabled = boo
        cbxItemType.Enabled = boo
        txtWarehouseID.Enabled = boo
        txtMinStock.Enabled = boo
        txtItemSize.Enabled = boo
        txtUoM.Enabled = boo
        txtMaxStock.Enabled = boo
        cbxBallValve.Enabled = boo
        cbxManifold.Enabled = boo
        cbxPabrikasi.Enabled = boo
        cbxPipeToTheKitchen.Enabled = boo
        cbxSelang.Enabled = boo
        cbxSupportingMaterial.Enabled = boo
        cbxTitikApi.Enabled = boo
        rbYes.Enabled = boo
        rbNo.Enabled = boo
        txtPict.Enabled = boo
        btnBrowse.Enabled = boo
        PictureBox.Enabled = boo
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo

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

        Stat_pros = ""

        'txt_TransNo.Text = Generate_TranNo(Me.Name)
        txtItemName.Focus()
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        If cbxPabrikasi.Checked Then
            Enable_Button_Wa(True)
        Else
            Enable_Button_Wa(False)
        End If

        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        ts_delete.Enabled = True
        Stat_pros = "UPDATE"
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

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        Dim pathPict As String = ""
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'userlog.UserName = "hhadiant"
        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            Stat_pros = "DELETE"


            Cmd.CommandText = "exec sp_Delete_Master_ItemHdr '" & txt_TransNo.Text & "'"
            Cmd.ExecuteNonQuery()

            'dt_hdr.Clear()
            'Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_List  'Item_ID','" & txt_TransNo.Text.Trim & "'"
            'DA.SelectCommand = Cmd
            'DA.Fill(dt_hdr)
            'If dt_hdr.Rows.Count > 0 Then
            '    If dt_hdr.Rows(0).Item("Picture").ToString.Trim <> "" Then
            '        pathPict = dt_hdr.Rows(0).Item("Picture").ToString.Trim
            '        If System.IO.File.Exists(pathPict) Then
            '            System.IO.File.Delete(pathPict)
            '        End If
            '    End If
            'End If

            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Master Item : " & txt_TransNo.Text.Trim & " Has been Deleted")
            txt_TransNo.Text = ""
            frm_MasterItem_Load(Nothing, Nothing)
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region

#Region "Proses"
    Private Sub Load_ST()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_ST.Clear()

            'Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_ST)

            If dt_ST.Rows.Count > 0 Then
                txt_TransNo.Text = dt_ST.Rows(0).Item("Item_ID")
                txtItemName.Text = dt_ST.Rows(0).Item("Item_name")
                cbxItemType.SelectedItem = dt_ST.Rows(0).Item("item_type")
                txtWarehouseID.Text = dt_ST.Rows(0).Item("warehouse_id")
                txtMinStock.Text = dt_ST.Rows(0).Item("min_stock")
                txtItemSize.Text = dt_ST.Rows(0).Item("item_size")
                txtUoM.Text = dt_ST.Rows(0).Item("uom")
                txtMaxStock.Text = dt_ST.Rows(0).Item("max_stock")
                If dt_ST.Rows(0).Item("ispabrikasi") = "Y" Then
                    cbxPabrikasi.Checked = True
                Else
                    cbxPabrikasi.Checked = False
                End If
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Refresh_Grid()
        'gv_Item.DataSource = dt_item
        'Dim i As Integer = 0
        'For Each dr_item As DataRow In dt_item.Rows
        '    gv_item.Rows.Item(i).Cells(0).Value = dr_item(GlobalVar.Fields.Item_ID).ToString
        '    gv_item.Rows.Item(i).Cells(1).Value = dr_item(GlobalVar.Fields.SeqNum).ToString
        '    gv_item.Rows.Item(i).Cells(2).Value = dr_item(GlobalVar.Fields.Item_ID_Dtl).ToString

        '    gv_item.Rows.Item(i).Cells(3).Value = dr_item(GlobalVar.Fields.Item_Name).ToString
        '    gv_item.Rows.Item(i).Cells(4).Value = dr_item(GlobalVar.Fields.Item_UOM).ToString
        '    gv_item.Rows.Item(i).Cells(5).Value = dr_item(GlobalVar.Fields.Qty).ToString

        '    gv_item.Rows.Item(i).Cells(6).Value = dr_item(GlobalVar.Fields.Item_Remark).ToString
        '    i += 1
        'Next
    End Sub

    Private Sub SetGrid()
        gv_item.Columns(0).Width = 90
        gv_item.Columns(1).Width = 250
        gv_item.Columns(2).Width = 50
        gv_item.Columns(3).Width = 100
        gv_item.Columns(4).Width = 100
    End Sub

    Private Sub Load_Grid()
        dt_item.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Cmd.CommandText = "EXEC sp_Retrieve_Master_ItemDtl '" + txt_TransNo.Text.Trim + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        gv_item.DataSource = dt_item
        'SetGrid()
        'gv_PODtl.DataSource = dt_item
        'Dim dv As New Data.DataView(dt_item)
        'MessageBox.Show(dv.Item(0).Item("TB_No"))
        Conn.Close()
    End Sub
    Private Sub Load_Grid_Header(ByVal Field As String, ByVal keyword As String)
        dt_hdr.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_List  '" & Field & "','" & keyword & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_hdr)

        gv_Hdr.DataSource = dt_hdr

        Conn.Close()
        'SetGrid()
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
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
        End Try
    End Sub


#End Region

#Region "Working Area"
    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_ItemID.BackColor = Color.DarkGray
            txt_ItemName.BackColor = Color.DarkGray
            Txt_Qty.BackColor = Color.DarkGray
            txtRemark.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            txt_ItemID.BackColor = Color.DarkGray
            txt_ItemName.BackColor = Color.DarkGray
            Txt_Qty.BackColor = Color.LemonChiffon
            txtRemark.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txt_ItemID.BackColor = Color.LemonChiffon
            txt_ItemName.BackColor = Color.DarkGray
            Txt_Qty.BackColor = Color.LemonChiffon
            txtRemark.BackColor = Color.LemonChiffon

        End If
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_ItemID.Enabled = boo
        txtRemark.Enabled = boo
        Txt_Qty.Enabled = boo
    End Sub

    Private Sub Clear_Wa()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_Qty.Clear()
        txtRemark.Clear()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Item_id,Item_Name,UoM from Master_Item_Hdr", "Item_ID", "Item_Name", "UoM", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_dtl.Clear()
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dt_dtl.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dt_dtl.Rows(0).Item("UoM").ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_dtl.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemName.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        Txt_Qty.Focus()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID_Dtl")
        dt_item.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_item.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da.Delete()
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gv_item.Focus()
                Btn_cancel_Click(sender, e)
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
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click

        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID_Dtl")
        dt_item.PrimaryKey = dc

        ' Validation
        If Txt_Qty.Text.Trim = "" Then
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
                dr("Item_ID_Dtl") = txt_ItemID.Text
                dr("Item_Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = Txt_Qty.Text
                dr("Remark") = txtRemark.Text
                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_item.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da("Qty") = Txt_Qty.Text
                da("Remark") = txtRemark.Text

            End If
        End If
        gv_item.DataSource = dt_item
        Status_Proses = "" 'reset
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub txt_ItemID_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Txt_Qty.Focus()
    End Sub

    Private Sub Txt_Qty_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_save.Focus()
    End Sub

    Private Sub txt_Harga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode >= Asc("0") AndAlso e.KeyCode <= Asc("9")) OrElse e.KeyCode = Asc("-") OrElse e.KeyCode = Asc(".") OrElse e.KeyCode = 8 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub gv_item_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_item.CellDoubleClick
        Dim i As Integer
        Dim dt_itemdt As New DataTable
        If gv_item.RowCount > 0 Then
            i = gv_item.CurrentRow.Index
            txt_ItemID.Text = gv_item.Item(0, i).Value
            txt_ItemName.Text = gv_item.Item(1, i).Value
            Txt_UoM.Text = gv_item.Item(2, i).Value
            Txt_Qty.Text = gv_item.Item(3, i).Value
            txtRemark.Text = gv_item.Item(4, i).Value
        End If

    End Sub

    Private Sub gv_item_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_item.MouseClick
        'If String.IsNullOrEmpty(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID_Dtl).Value) = False Then
        '    txt_ItemID.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID_Dtl).Value.ToString.Trim
        '    txt_ItemName.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
        '    Txt_UoM.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
        '    Txt_Qty.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty).Value.ToString.Trim
        '    txtRemark.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Remark).Value.ToString.Trim

        'End If
    End Sub
#End Region


    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim sFileToUpload As String = ""

        sFileToUpload = LTrim(RTrim(txtPict.Text))
        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
        Dim path As String
        path = Application.StartupPath

        fullPath = path & "\UploadedImages\" & lv_filename

        If dt_item.Rows.Count = 0 Then
            If cbxPabrikasi.Checked Then
                MsgBox("Data detail Item belum terisi. Proses Save dibatalkan")
                Exit Sub
            End If
        End If

        'Validation
        If txtItemName.Text.Trim = "" Then
            MsgBox("Data Item Name belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If cbxItemType.SelectedItem.Trim = "" Then
            MsgBox("Data Item Type belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If txtWarehouseID.Text.Trim = "" Then
            MsgBox("Data Warehouse belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If txtMinStock.Text.Trim = "" Then
            MsgBox("Data Min Stock belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If txtItemSize.Text.Trim = "" Then
            MsgBox("Data Item Size belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If txtUoM.Text.Trim = "" Then
            MsgBox("Data UoM belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If txtMaxStock.Text.Trim = "" Then
            MsgBox("Data sales price belum terisi. Proses Save dibatalkan")
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
        Dim lvPabrikasi As String = ""

        Dim lvBallValve As String = ""
        Dim lvSelang As String = ""
        Dim lvManifold As String = ""
        Dim lvPipeToTheKitchen As String = ""
        Dim lvTitikApi As String = ""
        Dim lvSupportingMat As String = ""
        Dim lvActive As String = ""
        '----Save LPB Header   
        Try
            If cbxPabrikasi.Checked Then
                lvPabrikasi = "Y"
            Else
                lvPabrikasi = "N"
            End If
            If cbxBallValve.Checked Then
                lvBallValve = "Y"
            Else
                lvBallValve = "N"
            End If
            If cbxBallValve.Checked Then
                lvBallValve = "Y"
            Else
                lvBallValve = "N"
            End If
            If cbxSelang.Checked Then
                lvSelang = "Y"
            Else
                lvSelang = "N"
            End If
            If cbxBallValve.Checked Then
                lvManifold = "Y"
            Else
                lvManifold = "N"
            End If
            If cbxPipeToTheKitchen.Checked Then
                lvPipeToTheKitchen = "Y"
            Else
                lvPipeToTheKitchen = "N"
            End If
            If cbxTitikApi.Checked Then
                lvTitikApi = "Y"
            Else
                lvTitikApi = "N"
            End If
            If cbxSupportingMaterial.Checked Then
                lvSupportingMat = "Y"
            Else
                lvSupportingMat = "N"
            End If
            If rbYes.Checked Then
                lvActive = "Y"
            Else
                lvActive = "N"
            End If
            'Insert Data
            'userlog.UserName = "hhadiant"
            If Stat_pros = "" Then
                txt_TransNo.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
                remarks_Stok = "Master Item : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

                Cmd.CommandText = "EXEC sp_Insert_Master_Item_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                             txtItemName.Text.Trim & "','" & _
                                             cbxItemType.SelectedItem.Trim & "','" & _
                                             txtWarehouseID.Text.Trim & "'," & _
                                             Replace(txtMinStock.Text, ",", ".") & ",'" & _
                                             txtItemSize.Text.Trim & "','" & _
                                             txtUoM.Text.Trim & "','" & _
                                             lvPabrikasi & "','" & _
                                             lvBallValve & "','" & _
                                             lvSelang & "','" & _
                                             lvManifold & "','" & _
                                             lvPipeToTheKitchen & "','" & _
                                             lvTitikApi & "','" & _
                                             lvSupportingMat & "'," & _
                                             Replace(txtMaxStock.Text, ",", ".") & ",'" & _
                                             fullPath & "','" & _
                                             lvActive & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                For Each item As DataRow In dt_item.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Master_Item_Dtl '" & txt_TransNo.Text + "','" & _
                                      item("Item_ID_Dtl") & "'," & item("Qty") & ",'" & item("UoM") & "','" & _
                                      item("Remark") & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                Next

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

            Else

                'update Terima Barang Header
                Cmd.CommandText = "EXEC sp_Update_Master_ItemHdr '" & txt_TransNo.Text & "','" & txtItemName.Text.Trim & "', '" & cbxItemType.SelectedItem.Trim & "','" & _
                                   txtWarehouseID.Text.Trim & "','" & Replace(txtMinStock.Text, ",", ".") & "'," & Replace(txtItemSize.Text, ",", ".") & _
                                   ",'" & txtUoM.Text.Trim & "','" & lvPabrikasi & "','" & _
                                   lvBallValve & "','" & _
                                   lvSelang & "','" & _
                                   lvManifold & "','" & _
                                   lvPipeToTheKitchen & "','" & _
                                   lvTitikApi & "','" & _
                                   lvSupportingMat & "'," & _
                                   Replace(txtMaxStock.Text, ",", ".") & ",'" & _
                                   fullPath & "','" & _
                                   lvActive & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                'update Item Detail
                For Each item As DataRow In dt_item.Rows
                    If item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Master_Item_Dtl '" & txt_TransNo.Text.Trim & "', '" & _
                                            item("Item_ID_Dtl", DataRowVersion.Original).ToString.Trim() & "' "
                        'Cmd.CommandText = "DELETE FROM Master_Item_Dtl where Item_ID = '" & txt_TransNo.Text.Trim & "' AND Item_ID_Dtl = '" & _
                        '                    item("Item_ID_Dtl", DataRowVersion.Original).ToString.Trim() & "' "
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Master_Item_Dtl '" & txt_TransNo.Text + "','" & _
                                       item("Item_ID_Dtl") & "'," & item("Qty") & ",'" & item("UoM") & "','" & _
                                       item("Remark") & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Modified Then
                        Cmd.CommandText = "EXEC sp_Update_Master_ItemDtl '" & txt_TransNo.Text & "','" & item("Item_ID_Dtl") & "'," & _
                                                 Replace(item("Qty"), ",", ".") & ",'" & _
                                                 item("UoM") & "', '" & item("Remark") & "','" & userlog.UserName & "'"

                        Cmd.ExecuteNonQuery()
                    End If

                Next

                dt_item.AcceptChanges()
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
            End If
            'Call the Upload method based on the type of file        
            If StrComp(Extension, ".bmp", CompareMethod.Text) = 0 Or _
            StrComp(Extension, ".jpg", CompareMethod.Text) = 0 Or _
            StrComp(Extension, ".jpeg", CompareMethod.Text) = 0 Or _
            StrComp(Extension, ".png", CompareMethod.Text) = 0 Or _
            StrComp(Extension, ".gif", CompareMethod.Text) = 0 Then
                If System.IO.Directory.Exists(path & "\UploadedImages\") Then
                    If sFileToUpload <> fullPath Then
                        FileCopy(sFileToUpload, fullPath)
                    End If

                Else
                    System.IO.Directory.CreateDirectory(path & "\UploadedImages\")
                    FileCopy(sFileToUpload, fullPath)

                End If
                'Else
                '    'Pass the extension            
                '    upLoadImageOrFile(sFileToUpload, Extension)
            End If

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Master Item : " & txt_TransNo.Text.Trim & " Has been Saved")
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                frm_MasterItem_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    'Private Sub txtSuppID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F1 Then
    '        Try
    '            CallandGetSearchData("Select Supp_ID,Nama,Contact_Person, Alamat from Master_Supplier where Active_Flag = 'Y'", "Supp_ID", "Nama", "Contact_Person", "Alamat", "")

    '            If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
    '                If Conn.State = ConnectionState.Closed Then
    '                    Conn.Open()
    '                End If

    '                txtSuppID.Text = frmSearch.txtResult1.Text.ToString.Trim
    '                lblSupplierName.Text = frmSearch.txtResult2.Text.ToString.Trim
    '                txtItemSize.Focus()
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Conn.Close()
    '        End Try
    '    ElseIf e.KeyCode = Keys.Enter Then
    '        If txtSuppID.Text.Trim <> "" Then
    '            Try
    '                If Conn.State = ConnectionState.Closed Then
    '                    Conn.Open()
    '                End If
    '                Cmd.CommandText = "EXEC sp_Retreive_Master_SupplierBySuppID '" & txtSuppID.Text.Trim & "'"
    '                DA.SelectCommand = Cmd
    '                DA.Fill(dt_item)

    '                If dt_item.Rows.Count > 0 Then
    '                    txtSuppID.Text = dt_item.Rows(0).Item("Supplier_ID").ToString
    '                    lblSupplierName.Text = dt_item.Rows(0).Item("Nama").ToString
    '                    txtItemSize.Focus()
    '                Else
    '                    MessageBox.Show("Supplier ini tidak ditemukan. Pastikan User Name yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                Conn.Close()
    '            End Try
    '        End If
    '    End If
    '    Conn.Close()
    'End Sub

    'Private Sub gvHdr_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If String.IsNullOrEmpty(gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value) = False Then
    '        txt_TransNo.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
    '        frm_MasterItem_Load(Nothing, Nothing)
    '    End If

    'End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Item_Hdr'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count > 0 Then
                Load_Grid_Header(cb_searchBaseon.SelectedValue.ToString, txt_SearchData.Text.ToString)
            Else
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            'GridEmployee.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub gv_Hdr_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_Hdr.CellDoubleClick
        'If String.IsNullOrEmpty(gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value) = False Then
        '    txt_TransNo.Text = gv_Hdr.Rows(gv_Hdr.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
        '    frm_MasterItem_Load(sender, e)
        'End If
        Dim i As Integer
        Dim dt_itemwh As New DataTable
        Dim dt_itemsp As New DataTable
        i = gv_Hdr.CurrentRow.Index
        dt_itemwh.Clear()
        dt_itemsp.Clear()
        txt_TransNo.Text = gv_Hdr.Item(0, i).Value
        txtItemName.Text = gv_Hdr.Item(1, i).Value
        cbxItemType.SelectedItem = gv_Hdr.Item(2, i).Value
        'cbxItemType.SelectedText = gv_Hdr.Item(2, i).Value
        txtWarehouseID.Text = gv_Hdr.Item(3, i).Value
        txtMinStock.Text = gv_Hdr.Item(4, i).Value
        txtItemSize.Text = gv_Hdr.Item(5, i).Value
        txtUoM.Text = gv_Hdr.Item(6, i).Value

        If gv_Hdr.Item(7, i).Value = "Y" Then
            cbxPabrikasi.Checked = True
        Else
            cbxPabrikasi.Checked = False
        End If
        If gv_Hdr.Item(8, i).Value = "Y" Then
            cbxBallValve.Checked = True
        Else
            cbxBallValve.Checked = False
        End If
        If gv_Hdr.Item(9, i).Value = "Y" Then
            cbxSelang.Checked = True
        Else
            cbxSelang.Checked = False
        End If
        If gv_Hdr.Item(10, i).Value = "Y" Then
            cbxManifold.Checked = True
        Else
            cbxManifold.Checked = False
        End If
        If gv_Hdr.Item(11, i).Value = "Y" Then
            cbxPipeToTheKitchen.Checked = True
        Else
            cbxPipeToTheKitchen.Checked = False
        End If
        If gv_Hdr.Item(12, i).Value = "Y" Then
            cbxTitikApi.Checked = True
        Else
            cbxTitikApi.Checked = False
        End If
        If gv_Hdr.Item(13, i).Value = "Y" Then
            cbxSupportingMaterial.Checked = True
        Else
            cbxSupportingMaterial.Checked = False
        End If
        If txtWarehouseID.Text.Trim <> "" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                Cmd.CommandText = "EXEC sp_Retreive_Master_Warehouse_ByWarehouseID '" & txtWarehouseID.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_itemwh)

                If dt_itemwh.Rows.Count > 0 Then
                    txtWarehouseID.Text = dt_itemwh.Rows(0).Item("Warehouse_ID").ToString
                    lblWarehouseName.Text = dt_itemwh.Rows(0).Item("Warehouse_Name").ToString
                    txtMinStock.Focus()
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
        'If txtMinStock.Text.Trim <> "" Then
        '    Try
        '        If Conn.State = ConnectionState.Closed Then
        '            Conn.Open()
        '        End If
        '        Cmd.CommandText = "EXEC sp_Retrieve_Master_SupplierBySuppID '" & txtSuppID.Text.Trim & "'"
        '        DA.SelectCommand = Cmd
        '        DA.Fill(dt_itemsp)

        '        If dt_itemsp.Rows.Count > 0 Then
        '            txtSuppID.Text = dt_itemsp.Rows(0).Item("Supp_ID").ToString
        '            lblSupplierName.Text = dt_itemsp.Rows(0).Item("Nama").ToString
        '            txtItemSize.Focus()
        '        End If
        '    Catch ex As Exception
        '        'MsgBox(ex.Message)
        '        Conn.Close()
        '    End Try
        'End If

        txtMaxStock.Text = gv_Hdr.Item(14, i).Value

        txtPict.Text = gv_Hdr.Item(15, i).Value
        If txtPict.Text <> "" Then
            fullPath = txtPict.Text
            PictureBox.ImageLocation = txtPict.Text
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            If System.IO.File.Exists(fullPath) Then
                PictureBox.Load()
            End If
        Else
            PictureBox.ImageLocation = ""
        End If

        If gv_Hdr.Item(16, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If

        Load_Grid()
        DisableButton(True)
        Enable_Button_Wa(False)
    End Sub

    Private Sub txtWarehouseID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWarehouseID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Warehouse_ID,Warehouse_Name,Location from Master_Warehouse where Active_Flag = 'Y'", "Warehouse_ID", "Warehouse_Name", "Location", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txtWarehouseID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    lblWarehouseName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txtItemSize.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtWarehouseID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retreive_Master_Warehouse_ByWarehouseID '" & txtWarehouseID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        txtWarehouseID.Text = dt_item.Rows(0).Item("Warehouse_ID").ToString
                        lblWarehouseName.Text = dt_item.Rows(0).Item("Warehouse_name").ToString
                        txtItemSize.Focus()
                    Else
                        MessageBox.Show("PIC ini tidak ditemukan. Pastikan User Name yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Conn.Close()
                End Try
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub cbxPabrikasi_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxPabrikasi.CheckedChanged
        If cbxPabrikasi.Checked Then
            Enable_Button_Wa(True)
        Else
            Enable_Button_Wa(False)
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtPict.Text = OpenFileDialog1.FileName
        lv_filename = OpenFileDialog1.SafeFileName
        PictureBox.ImageLocation = txtPict.Text
        PictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox.Load()
    End Sub
End Class