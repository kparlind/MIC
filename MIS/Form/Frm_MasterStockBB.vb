Imports System.Data.SqlClient
Imports MIS.GlobalVar
Imports MIS.mdlCommon
Public Class Frm_MasterStockBB
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim Status_Proses As String
    Dim dt_stock As New DataTable
    Dim DA As New SqlDataAdapter
    Dim dtSearch As New DataTable
    Dim lv_click As String
    Private Sub Frm_MasterStockBB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()
        Status_Proses = ""
        SetToolTip()
        SetEnabled(False)
        LoadCbxPeriod()
        loadCbsearch()
        LoadGrid("Item_ID", txtKodeBrg.Text.Trim)

    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Status_Proses = "NEW"
        SetEnabled(True)
        Clear_Field()
        SetBackColor_Field("NEW")
        lv_click = ""
        SetToolTip()
        InitField()
        lv_click = ""
    End Sub
    Private Sub InitField()
        cbxPeriod.Refresh()
        'cbxPeriod.Items.Clear()
        txtKodeBrg.Text = String.Empty
        txtNamaBrg.Text = String.Empty
        TxtUoM.Text = String.Empty
        txtAvgCost.Text = String.Empty
        TxtQty.Text = String.Empty
        'If lv_click <> "Y" Then
        '    GridCOA.DataSource = Nothing
        'End If

    End Sub
    Private Sub Clear_Field()
        txtKodeBrg.Clear()
        txtNamaBrg.Clear()
        TxtUoM.Clear()
        TxtQty.Clear()
        txtAvgCost.Clear()
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Stock_BB'"

            DA.SelectCommand = Cmd
            DA.Fill(dtSearch)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtSearch
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub LoadGrid(ByVal Field As String, ByVal keyword As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_StockBB 'a." & Field & "','" & keyword & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridStockBB.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub SetToolTip()
        Select Case UCase(Status_Proses)
            Case "NEW"
                btnEdit.Enabled = False
                btnNew.Enabled = False
                btnDelete.Enabled = False

                btnSave.Enabled = True


            Case "EDIT"
                btnEdit.Enabled = False
                btnNew.Enabled = False
                btnDelete.Enabled = False

                btnSave.Enabled = True

                SetEnabled(True)
            Case Else
                btnNew.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True

                btnSave.Enabled = False

        End Select
    End Sub
    Private Sub SetBackColor_Field(ByVal proses As String)
        If proses = "READ" Then
            txtKodeBrg.BackColor = Color.LemonChiffon
            txtNamaBrg.BackColor = Color.DarkGray
            TxtQty.BackColor = Color.LemonChiffon
            TxtUoM.BackColor = Color.DarkGray
            txtAvgCost.BackColor = Color.LemonChiffon
        ElseIf proses = "UPDATE" Then
            txtKodeBrg.BackColor = Color.DarkGray
            txtNamaBrg.BackColor = Color.DarkGray
            TxtUoM.BackColor = Color.DarkGray
            TxtQty.BackColor = Color.LemonChiffon
            txtAvgCost.BackColor = Color.LemonChiffon
        ElseIf proses = "NEW" Then
            txtKodeBrg.BackColor = Color.LemonChiffon
            txtNamaBrg.BackColor = Color.DarkGray
            TxtUoM.BackColor = Color.DarkGray
            TxtQty.BackColor = Color.LemonChiffon
            txtAvgCost.BackColor = Color.LemonChiffon
        Else
            txtKodeBrg.BackColor = Color.DarkGray
            txtNamaBrg.BackColor = Color.DarkGray
            TxtUoM.BackColor = Color.DarkGray
            TxtQty.BackColor = Color.DarkGray
            txtAvgCost.BackColor = Color.DarkGray
        End If
    End Sub
    Private Sub LoadCbxPeriod()
        Dim Month As Integer
        Dim Year As Integer
        Dim MonthBefore As Integer
        Dim YearBefore As Integer
        Dim MonthAfter As Integer
        Dim YearAfter As Integer
        Dim i As Integer
        Dim dtPeriod As New DataTable

        'Month = Now.Month
        'Year = Now.Year
        'MonthBefore = Month - 2
        'selisih = Month - MonthBefore

        'i = 2
        'While i > 0
        '    MonthBefore = Month - i
        '    cbxPeriod.Items.Add(MonthBefore.ToString & "-" & Year.ToString)
        '    i -= 1
        'End While
        'i = 0
        'cbxPeriod.Items.Add(Month.ToString & "-" & Year.ToString)
        'For i = 1 To 2
        '    MonthAfter = Month + i
        '    cbxPeriod.Items.Add(MonthAfter.ToString & "-" & Year.ToString)

        'Next
        'Month = Now.ToString("MM-yyyy")
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec GetCurrMonthandYear"
            DA.SelectCommand = Cmd
            DA.Fill(dtPeriod)

            Conn.Close()

            If dtPeriod.Rows.Count > 0 Then
                Month = dtPeriod.Rows(0).Item("Bulan")
                Year = dtPeriod.Rows(0).Item("Tahun")

                MonthBefore = Month
                MonthAfter = Month
                YearBefore = Year
                YearAfter = Year
                For i = 1 To 2
                    MonthBefore = MonthBefore - 1
                    If MonthBefore <= 0 Then
                        MonthBefore = 12
                        YearBefore = YearBefore - 1
                    End If
                    If MonthBefore < 10 Then
                        cbxPeriod.Items.Add(YearBefore.ToString & "-" & "0" & MonthBefore.ToString)
                    Else
                        cbxPeriod.Items.Add(YearBefore.ToString & "-" & MonthBefore.ToString)
                    End If

                Next

                'i = 0
                'If Month < 10 Then
                '    cbxPeriod.Items.Add("0" & Month.ToString & "-" & Year.ToString)
                'Else
                '    cbxPeriod.Items.Add(Month.ToString & "-" & Year.ToString)
                'End If

                'For i = 1 To 2
                '    MonthAfter = Month + i
                '    If MonthAfter < 10 Then
                '        cbxPeriod.Items.Add("0" & MonthAfter.ToString & "-" & Year.ToString)
                '    Else
                '        cbxPeriod.Items.Add(MonthAfter.ToString & "-" & Year.ToString)
                '    End If

                'Next
                If Month < 10 Then
                    cbxPeriod.Items.Add(Year.ToString & "-" & "0" & Month.ToString)
                Else
                    cbxPeriod.Items.Add(Year.ToString & "-" & Month.ToString)
                End If

                For i = 1 To 2
                    MonthAfter = MonthAfter + 1
                    If MonthAfter > 12 Then
                        MonthAfter = 1
                        YearAfter = YearAfter + 1
                    End If
                    If MonthAfter < 10 Then
                        cbxPeriod.Items.Add(YearAfter.ToString & "-" & "0" & MonthAfter.ToString)
                    Else
                        cbxPeriod.Items.Add(YearAfter.ToString & "-" & MonthAfter.ToString)
                    End If

                Next
            End If
            cbxPeriod.Sorted = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub FillDateDropDownList(ByVal StartDate As Date, ByVal EndDate As Date)
        While StartDate <= EndDate
            cbxPeriod.Items.Add(StartDate.Year.ToString() & "-" & StartDate.Month.ToString().PadLeft(2, "0"))
            StartDate = StartDate.AddMonths(1)
        End While
    End Sub

    Private Sub txtKodeBrg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKodeBrg.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Item_id,Item_Name,UoM from Master_Item_Hdr where active_flag = 'Y'", "Item_ID", "Item_Name", "UoM", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_stock.Clear()
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dt_stock.Rows.Count > 0 Then
                        txtKodeBrg.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txtNamaBrg.Text = dt_stock.Rows(0).Item("Item_name").ToString
                        TxtUoM.Text = dt_stock.Rows(0).Item("UoM").ToString
                        TxtQty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtKodeBrg.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_stock.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txtKodeBrg.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_stock)

                    If dt_stock.Rows.Count > 0 Then
                        txtNamaBrg.Text = dt_stock.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        TxtUoM.Text = dt_stock.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        TxtQty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Conn.Close()
                    Exit Sub
                End Try
            End If

        End If
        Conn.Close()
    End Sub
    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_Retreive_Item_byItemID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_stock)

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        cbxPeriod.Enabled = Flag
        txtKodeBrg.Enabled = Flag
        TxtQty.Enabled = Flag
        txtAvgCost.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Stock_BB'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            'GridStockBB.DataSource = dtTemp
            If dtTemp.Rows.Count > 0 Then
                LoadGrid(cb_searchBaseon.SelectedValue.ToString, txt_SearchData.Text.ToString)
            Else
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try

    End Sub

    Private Sub GridStockBB_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridStockBB.CellClick
        Dim i As Integer
        Dim Month As String
        Dim Year As String
        i = GridStockBB.CurrentRow.Index

        Year = Microsoft.VisualBasic.Left(GridStockBB.Item(0, i).Value, 4)
        Month = Microsoft.VisualBasic.Right(GridStockBB.Item(0, i).Value, 2)
        cbxPeriod.SelectedItem = Year & "-" & Month
        txtKodeBrg.Text = GridStockBB.Item(1, i).Value
        TxtQty.Text = GridStockBB.Item(3, i).Value
        txtAvgCost.Text = GridStockBB.Item(4, i).Value
        If txtKodeBrg.Text.Trim <> "" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt_stock.Clear()
                Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txtKodeBrg.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_stock)

                If dt_stock.Rows.Count > 0 Then
                    txtNamaBrg.Text = dt_stock.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                    TxtUoM.Text = dt_stock.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                End If
                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        If GridStockBB.Item(5, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtKodeBrg.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)
        SetBackColor_Field("UPDATE")
        Status_Proses = "EDIT"
        SetToolTip()
        txtKodeBrg.Enabled = False
        cbxPeriod.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        InitField()
        If Status_Proses = "NEW" OrElse Status_Proses = "EDIT" Then
            SetEnabled(False)
            Status_Proses = String.Empty
        Else
            'MoveLast()
            SetEnabled(False)
            Status_Proses = String.Empty
        End If
        SetToolTip()
        SetBackColor_Field("CANCEL")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtKodeBrg.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lv_click = "Y" Then
            Try
                Dim Month As String
                Dim Year As String
                Dim Period As String
                Period = cbxPeriod.SelectedItem
                Year = Microsoft.VisualBasic.Left(Period, 4)
                Month = Microsoft.VisualBasic.Right(Period, 2)
                Period = Year & Month

                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_StockBB '" & Period & "' ,'" & txtKodeBrg.Text.Trim & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtKodeBrg.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridStockBB.DataSource = Nothing
        LoadGrid("Item_ID", txtKodeBrg.Text.Trim)
        SetToolTip()
        InitField()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String = ""
        Dim dtTemp As New DataTable
        If txtNamaBrg.Text = "" Or txtNamaBrg.Text = String.Empty Then
            MessageBox.Show("Nama barang Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbxPeriod.Text = "" Or cbxPeriod.SelectedItem = String.Empty Then
            MessageBox.Show("Period Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TxtUoM.Text = "" Or TxtUoM.Text = String.Empty Then
            MessageBox.Show("UoM Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TxtQty.Text = "" Or TxtQty.Text = String.Empty Then
            MessageBox.Show("Qty Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAvgCost.Text = "" Or txtAvgCost.Text = String.Empty Then
            MessageBox.Show("Average Cost Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If rbYes.Checked Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If
        'userlog.UserName = "hhadiant"
        Dim Month As String
        Dim Year As String
        Dim Period As String
        Period = cbxPeriod.SelectedItem
        Year = Microsoft.VisualBasic.Left(Period, 4)
        Month = Microsoft.VisualBasic.Right(Period, 2)
        Period = Year & Month
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_StockBB '" & Period & "', '" & txtKodeBrg.Text.Trim & "', '" _
                                & Replace(TxtQty.Text, ",", ".") & "' ,'" & Replace(txtAvgCost.Text, ",", ".") & "' ,'" _
                               & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtKodeBrg.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        Else
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                'Check existing data
                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Retrieve_Master_StockBB_ByPK '" & Period & "', '" & txtKodeBrg.Text.Trim & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dtTemp)
                If dtTemp.Rows.Count > 0 Then
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Update_Master_StockBB '" & Period & "', '" & txtKodeBrg.Text.Trim & "', '" _
                                & Replace(TxtQty.Text, ",", ".") & "' ,'" & Replace(txtAvgCost.Text, ",", ".") & "' ,'" _
                               & userlog.UserName & "',  '" & lv_active & "'"

                    Cmd.ExecuteNonQuery()
                    Insert_Trans_History(txtKodeBrg.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                Else
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Insert_Master_StockBB '" & Period & "', '" & txtKodeBrg.Text.Trim & "', '" _
                                    & Replace(TxtQty.Text, ",", ".") & "' ,'" & Replace(txtAvgCost.Text, ",", ".") & "' ,'" _
                                 & userlog.UserName & "',  '" & lv_active & "'"

                    Cmd.ExecuteNonQuery()

                    'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    Insert_Trans_History(txtKodeBrg.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
                End If


                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridStockBB.DataSource = Nothing
        InitField()
        SetEnabled(False)
        Status_Proses = String.Empty
        SetToolTip()
        LoadGrid("Item_ID", txtKodeBrg.Text.Trim)
        SetBackColor_Field("SAVE")
    End Sub
End Class