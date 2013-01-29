Imports System.Data.SqlClient
Imports MIS.GlobalVar
Imports MIS.mdlCommon
Public Class Frm_MasterCOABB
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim Status_Proses As String
    Dim dt_coabb As New DataTable
    Dim DA As New SqlDataAdapter
    Dim dtSearch As New DataTable
    Dim lv_click As String
    Private Sub Frm_MasterCoaBB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()
        Status_Proses = ""
        SetToolTip()
        SetEnabled(False)
        LoadCbxPeriod()
        loadCbsearch()
        LoadGrid()

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
        'txtCostCenter.Text = String.Empty
        txtAccID.Text = String.Empty
        txtNamaCOA.Text = String.Empty
        TxtValue.Text = String.Empty
        rbDebet.Checked = True
        rbYes.Checked = True

        'If lv_click <> "Y" Then
        '    GridCOA.DataSource = Nothing
        'End If

    End Sub
    Private Sub Clear_Field()
        'txtCostCenter.Clear()
        txtAccID.Clear()
        txtNamaCOA.Clear()
        TxtValue.Clear()
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_COA_BB'"

            DA.SelectCommand = Cmd
            DA.Fill(dtSearch)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtSearch
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub LoadGrid()
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
            Cmd.CommandText = "exec sp_Retrieve_Master_COA_BB"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridCOABB.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            'txtCostCenter.BackColor = Color.LemonChiffon
            txtAccID.BackColor = Color.DarkGray
            txtNamaCOA.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon
        ElseIf proses = "UPDATE" Then
            'txtCostCenter.BackColor = Color.DarkGray
            txtAccID.BackColor = Color.DarkGray
            txtNamaCOA.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon
        ElseIf proses = "NEW" Then
            'txtCostCenter.BackColor = Color.LemonChiffon
            txtAccID.BackColor = Color.LemonChiffon
            txtNamaCOA.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon
        Else
            'txtCostCenter.BackColor = Color.DarkGray
            txtAccID.BackColor = Color.DarkGray
            txtNamaCOA.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.DarkGray

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
        cbxPeriod.Items.Clear()
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
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub


    'Private Sub txtCostCenter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F1 Then
    '        Try
    '            CallandGetSearchData("Select cost_center,account_Id,account_name,level,group_payaccount from Master_COA where active_flag = 'Y' and PostEdit = 'Y'", "Cost_Center", "account_Id", "Account_Name", "Level", "Group_Payaccount")

    '            If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
    '                'If Conn.State = ConnectionState.Closed Then
    '                '    Conn.Open()
    '                'End If
    '                'dt_coabb.Clear()
    '                'GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
    '                'If dt_coabb.Rows.Count > 0 The
    '                'txtCostCenter.Text = frmSearch.txtResult1.Text.ToString.Trim
    '                txtAccID.Text = frmSearch.txtResult1.Text.ToString.Trim
    '                txtNamaCOA.Text = frmSearch.txtResult2.Text.ToString.Trim
    '                TxtValue.Focus()
    '                'Else
    '                '    MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                '    Exit Sub
    '                'End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Conn.Close()
    '        End Try
    '    ElseIf e.KeyCode = Keys.Enter Then
    '        If txtAccID.Text.Trim <> "" Then
    '            Try
    '                If Conn.State = ConnectionState.Closed Then
    '                    Conn.Open()
    '                End If
    '                dt_coabb.Clear()
    '                Cmd.CommandText = "EXEC sp_Retrieve_Master_COA_ByPK '" & txtAccID.Text.Trim & "'"
    '                DA.SelectCommand = Cmd
    '                DA.Fill(dt_coabb)

    '                If dt_coabb.Rows.Count > 0 Then
    '                    txtNamaCOA.Text = dt_coabb.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString

    '                    TxtValue.Focus()
    '                Else
    '                    MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '                Conn.Close()
    '            End Try
    '        End If

    '    End If
    '    Conn.Close()
    'End Sub
    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_Retrieve_Master_COA_ByPK '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_coabb)

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        cbxPeriod.Enabled = Flag
        'txtCostCenter.Enabled = Flag
        txtAccID.Enabled = Flag
        TxtValue.Enabled = Flag
        rbDebet.Enabled = Flag
        rbCredit.Enabled = Flag
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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_COA_BB'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                GridCOABB.DataSource = dtTemp
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub GridCOABB_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCOABB.CellClick
        Dim i As Integer
        Dim Month As String
        Dim Year As String
        i = GridCOABB.CurrentRow.Index

        Year = Microsoft.VisualBasic.Left(GridCOABB.Item(0, i).Value, 4)
        Month = Microsoft.VisualBasic.Right(GridCOABB.Item(0, i).Value, 2)
        cbxPeriod.SelectedItem = Year & "-" & Month
        'txtCostCenter.Text = GridCOABB.Item(1, i).Value
        txtAccID.Text = GridCOABB.Item(1, i).Value
        If GridCOABB.Item(2, i).Value = 0 Then
            TxtValue.Text = Replace(GridCOABB.Item(3, i).Value, ".", ",")
            rbCredit.Checked = True
        Else
            TxtValue.Text = Replace(GridCOABB.Item(2, i).Value, ".", ",")
            rbDebet.Checked = True
        End If
        If GridCOABB.Item(4, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If

        If txtAccID.Text.Trim <> "" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt_coabb.Clear()
                Cmd.CommandText = "EXEC sp_Retrieve_Master_COA_ByPK '" & txtAccID.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_coabb)

                If dt_coabb.Rows.Count > 0 Then
                    txtNamaCOA.Text = dt_coabb.Rows(0).Item(GlobalVar.Fields.Account_Name).ToString
                End If
                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        lv_click = "Y"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtAccID.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)
        SetBackColor_Field("UPDATE")
        Status_Proses = "EDIT"
        SetToolTip()
        'txtCostCenter.Enabled = False
        txtAccID.Enabled = False
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
        Frm_MasterCoaBB_Load(sender, e)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtAccID.Text.Trim = "" Then
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

                Cmd.CommandText = "exec sp_Delete_Master_COA_BB '" & Period & "'  , '" & txtAccID.Text.Trim & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridCOABB.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        Dim lv_debet As String = ""
        Dim lv_credit As String = ""
        Dim dtTemp As New DataTable
        If cbxPeriod.SelectedItem = "" Or cbxPeriod.Text = "" Then
            MessageBox.Show("Period Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNamaCOA.Text = "" Or txtNamaCOA.Text = String.Empty Then
            MessageBox.Show("Nama COA Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtCostCenter.Text = "" Or txtCostCenter.Text = String.Empty Then
        '    MessageBox.Show("Cost Center Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If txtAccID.Text = "" Or txtAccID.Text = String.Empty Then
            MessageBox.Show("Account ID Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TxtValue.Text = "" Or TxtValue.Text = String.Empty Then
            MessageBox.Show("Debit/Credit Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If rbYes.Checked = True Then
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

        If rbDebet.Checked Then
            lv_debet = Replace(CStr(TxtValue.Text.Trim), ",", ".")
        Else
            lv_credit = Replace(CStr(TxtValue.Text.Trim), ",", ".")
        End If
        If lv_debet = "" Then
            lv_debet = "0"
        End If
        If lv_credit = "" Then
            lv_credit = "0"
        End If
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_COA_BB '" & Period & "', '" & txtAccID.Text.Trim & "', '" _
                                & lv_debet & "' ," & lv_credit & " ,'" _
                               & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

                Cmd.CommandText = "exec sp_Retrieve_Master_COA_BB_ByPK '" & Period & "', '" & txtAccID.Text.Trim & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dtTemp)
                If dtTemp.Rows.Count > 0 Then
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Update_Master_COA_BB '" & Period & "', '" & txtAccID.Text.Trim & "', '" _
                                    & lv_debet & "' ,'" & lv_credit & "' ,'" _
                                   & userlog.UserName & "',  '" & lv_active & "'"

                    Cmd.ExecuteNonQuery()
                    Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                Else
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Insert_Master_COA_BB '" & Period & "', '" & txtAccID.Text.Trim & "', '" _
                                      & lv_debet & "' ,'" & lv_credit & "' ,'" _
                                 & userlog.UserName & "',  '" & lv_active & "'"



                    'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    Cmd.ExecuteNonQuery()
                    Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
                End If

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridCOABB.DataSource = Nothing
        InitField()
        SetEnabled(False)
        Status_Proses = String.Empty
        SetToolTip()
        LoadGrid()
        SetBackColor_Field("SAVE")
    End Sub

    Private Sub txtAccID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select account_Id,account_name,level,group_payaccount from Master_COA where active_flag = 'Y' and PostEdit = 'Y'", "account_Id", "Account_Name", "Level", "Group_Payaccount", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    'If Conn.State = ConnectionState.Closed Then
                    '    Conn.Open()
                    'End If
                    'dt_coabb.Clear()
                    'GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    'If dt_coabb.Rows.Count > 0 The
                    'txtCostCenter.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtAccID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtNamaCOA.Text = frmSearch.txtResult2.Text.ToString.Trim
                    TxtValue.Focus()
                    'Else
                    '    MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    '    Exit Sub
                    'End If
                End If
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtAccID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_coabb.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_COA_ByPK  '" & txtAccID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_coabb)

                    If dt_coabb.Rows.Count > 0 Then
                        txtNamaCOA.Text = dt_coabb.Rows(0).Item(GlobalVar.Fields.Account_Name).ToString
                        TxtValue.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    Conn.Close()
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End Try
            End If

        End If
        Conn.Close()
    End Sub
End Class