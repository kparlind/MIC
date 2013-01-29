Imports MIS.GlobalVar
Imports System.Data.SqlClient
Imports MIS.mdlCommon
Public Class Frm_Komponen_Group
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

    Private Sub Frm_Komponen_Group_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        Clear_Wa()
        Enable_Wa(False)
        EnableInput(False)
        DisableButton(False)
        Enable_Button_Wa(False)

        Load_Grid()
        Load_Grid_Header("Komponen_Grp_ID", txtKompGrpID.Text.Trim)

        SetBackColor_Wa("READ")
        loadCbsearch()

        ts_New.Enabled = True
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Komponen_GroupHdr'"

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
        txtKompGrpID.Clear()
        txtNamaKompGrp.Clear()
        'cbxCategory.Items.Clear()
        gv_item.DataSource = ""
        dt_item.Clear()
    End Sub
    Private Sub EnableInput(ByVal boo As Boolean)
        txtNamaKompGrp.Enabled = boo
        cbxCategory.Enabled = boo
        rbYes.Enabled = boo
        rbNo.Enabled = boo

    End Sub
    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo

    End Sub
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
        txtNamaKompGrp.Focus()

    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        Enable_Button_Wa(True)
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


            Cmd.CommandText = "exec sp_Delete_Master_Komponen_GroupHdr '" & txtKompGrpID.Text & "'"
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

            Insert_Trans_History(txtKompGrpID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Master Komponen Group : " & txtKompGrpID.Text.Trim & " Has been Deleted")
            txtKompGrpID.Text = ""
            Frm_Komponen_Group_Load(Nothing, Nothing)
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
            Cmd.CommandText = "EXEC sp_Retrieve_Master_Komponen_GroupHdr_ByKomponenGrpID '" + txtKompGrpID.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_ST)

            If dt_ST.Rows.Count > 0 Then
                txtKompGrpID.Text = dt_ST.Rows(0).Item("Komponen_Grp_ID")
                txtNamaKompGrp.Text = dt_ST.Rows(0).Item("Nama_Komponen_Grp")
                cbxCategory.SelectedItem = dt_ST.Rows(0).Item("")
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
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Komponen_GroupDtl '" + txtKompGrpID.Text.Trim + "'"
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
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Komponen_GroupHdr  '" & Field & "','" & keyword & "'"
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
        ElseIf proses = "UPDATE" Then
            txt_ItemID.BackColor = Color.DarkGray
            txt_ItemName.BackColor = Color.DarkGray
            Txt_Qty.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txt_ItemID.BackColor = Color.LemonChiffon
            txt_ItemName.BackColor = Color.DarkGray
            Txt_Qty.BackColor = Color.LemonChiffon

        End If
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_ItemID.Enabled = boo
        Txt_Qty.Enabled = boo
    End Sub

    Private Sub Clear_Wa()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_Qty.Clear()

    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            Try
                sql = "Select Item_id,Item_Name,Item_Type,UoM from Master_Item_Hdr Where active_flag = 'Y' "
                If cbxCategory.Text = "Manifold" Then
                    sql += " and Manifold = 'Y' "
                ElseIf cbxCategory.Text = "Pipe To Kitchen" Then
                    sql += " and PipeToKitchen = 'Y' "
                ElseIf cbxCategory.Text = "Titik Api" Then
                    sql += " and TitikApi = 'Y' "
                ElseIf cbxCategory.Text = "Supporting Material" Then
                    sql += " and SupportingMaterial = 'Y' "
                End If

                CallandGetSearchData(sql, "Item_ID", "Item_Name", "Item_Type", "UoM")

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
        dc(0) = dt_item.Columns("Item_ID")
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
        dc(0) = dt_item.Columns("Item_ID")
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
                dr("Item_ID") = txt_ItemID.Text
                dr("Item_Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = Txt_Qty.Text
                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_item.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da("Qty") = Txt_Qty.Text

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


        'Validation
        If txtNamaKompGrp.Text.Trim = "" Then
            MsgBox("Data Item Name belum terisi. Proses Save dibatalkan")
            Exit Sub
        End If
        If gv_item.Rows.Count = 0 Then
            MsgBox("Data Item belum ada. Proses Save dibatalkan")
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
          
            If rbYes.Checked Then
                lvActive = "Y"
            Else
                lvActive = "N"
            End If
            'Insert Data
            'userlog.UserName = "hhadiant"
            If Stat_pros = "" Then
                txtKompGrpID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtKompGrpID.Text, 3))
                remarks_Stok = "Master Komponen Group : " & txtKompGrpID.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

                Cmd.CommandText = "EXEC sp_Insert_Master_Komponen_GroupHdr '" & txtKompGrpID.Text.Trim & "','" & _
                                             txtNamaKompGrp.Text.Trim & "','" & cbxCategory.SelectedItem & "','" & _
                                             lvActive & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                For Each item As DataRow In dt_item.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Master_Komponen_GroupDtl '" & txtKompGrpID.Text & "','" & _
                                      item("Item_ID") & "'," & item("UoM") & ",'" & item("Qty") & "','" & _
                                       userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                Next

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtKompGrpID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

            Else

                'update Terima Barang Header
                Cmd.CommandText = "EXEC sp_Update_Master_Komponen_GroupHdr '" & txtKompGrpID.Text & "','" & txtNamaKompGrp.Text.Trim & "', '" & cbxCategory.SelectedItem & "','" & _
                                   lvActive & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                'update Item Detail
                For Each item As DataRow In dt_item.Rows
                    If item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Master_Komponen_GroupDtl '" & txtKompGrpID.Text.Trim & "', '" & _
                                            item("Item_ID", DataRowVersion.Original).ToString.Trim() & "' "
                        'Cmd.CommandText = "DELETE FROM Master_Item_Dtl where Item_ID = '" & txt_TransNo.Text.Trim & "' AND Item_ID_Dtl = '" & _
                        '                    item("Item_ID_Dtl", DataRowVersion.Original).ToString.Trim() & "' "
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_Master_Komponen_GroupDtl '" & txtKompGrpID.Text + "','" & _
                                       item("Item_ID") & "'," & item("UoM") & ",'" & item("Qty") & "','" & _
                                       userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Modified Then
                        Cmd.CommandText = "EXEC sp_Update_Master_Komponen_GroupDtl '" & txtKompGrpID.Text & "','" & item("Item_ID") & "'," & _
                                                 item("UoM") & ",'" & _
                                                 Replace(item("Qty"), ",", ".") & "','" & userlog.UserName & "'"

                        Cmd.ExecuteNonQuery()
                    End If

                Next

                dt_item.AcceptChanges()
                Insert_Trans_History(txtKompGrpID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
            End If
           

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Master Item : " & txtKompGrpID.Text.Trim & " Has been Saved")
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                Frm_Komponen_Group_Load(Nothing, Nothing)
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
        txtKompGrpID.Text = gv_Hdr.Item(0, i).Value
        txtNamaKompGrp.Text = gv_Hdr.Item(1, i).Value
        cbxCategory.SelectedItem = gv_Hdr.Item(2, i).Value

        If gv_Hdr.Item(3, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If

        Load_Grid()
        DisableButton(True)
        Enable_Button_Wa(False)
    End Sub
End Class