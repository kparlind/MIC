Imports System.Data.SqlClient
Imports MIS.GlobalVar
Imports MIS.mdlCommon
Public Class Frm_MasterUtangBB
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim Status_Proses As String
    Dim dt_utang As New DataTable
    Dim DA As New SqlDataAdapter
    Dim dtSearch As New DataTable
    Dim lv_click As String
    Private Sub Frm_MasterUtangBB_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        'cbxPeriod.Items.Clear()
        txtSuppID.Text = String.Empty
        txtNamaSupp.Text = String.Empty
        TxtValue.Text = String.Empty
        rbDebet.Checked = True
        rbYes.Checked = True
        'If lv_click <> "Y" Then
        '    GridCOA.DataSource = Nothing
        'End If

    End Sub
    Private Sub Clear_Field()
        txtSuppID.Clear()
        txtNamaSupp.Clear()
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

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Utang_BB'"

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
            Cmd.CommandText = "exec sp_Retrieve_Master_Utang_BB"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridUtangBB.DataSource = dtTemp

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
            txtSuppID.BackColor = Color.LemonChiffon
            txtNamaSupp.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon

        ElseIf proses = "UPDATE" Then
            txtSuppID.BackColor = Color.DarkGray
            txtNamaSupp.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon
        ElseIf proses = "NEW" Then
            txtSuppID.BackColor = Color.LemonChiffon
            txtNamaSupp.BackColor = Color.DarkGray
            TxtValue.BackColor = Color.LemonChiffon

        Else
            txtSuppID.BackColor = Color.DarkGray
            txtNamaSupp.BackColor = Color.DarkGray
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


    Private Sub txtSuppID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSuppID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select supp_id,nama,contact_person,alamat from Master_Supplier", "Supp_ID", "Nama", "Contact_person", "Alamat", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_utang.Clear()
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dt_utang.Rows.Count > 0 Then
                        txtSuppID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txtNamaSupp.Text = dt_utang.Rows(0).Item("Nama").ToString
                        TxtValue.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtSuppID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_utang.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_SupplierBySuppID '" & txtSuppID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_utang)

                    If dt_utang.Rows.Count > 0 Then
                        txtNamaSupp.Text = dt_utang.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString

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
    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_Retrieve_Master_SupplierBySuppID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_utang)

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        cbxPeriod.Enabled = Flag
        txtSuppID.Enabled = Flag
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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Utang_BB'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridUtangBB.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub GridUtangBB_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridUtangBB.CellClick
        Dim i As Integer
        Dim Month As String
        Dim Year As String
        i = GridUtangBB.CurrentRow.Index

        Year = Microsoft.VisualBasic.Left(GridUtangBB.Item(0, i).Value, 4)
        Month = Microsoft.VisualBasic.Right(GridUtangBB.Item(0, i).Value, 2)
        cbxPeriod.SelectedItem = Year & "-" & Month
        txtSuppID.Text = GridUtangBB.Item(1, i).Value
        If GridUtangBB.Item(2, i).Value = 0 Then
            TxtValue.Text = GridUtangBB.Item(3, i).Value
            rbCredit.Checked = True
        Else
            TxtValue.Text = GridUtangBB.Item(2, i).Value
            rbDebet.Checked = True
        End If
        If txtSuppID.Text.Trim <> "" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt_utang.Clear()
                Cmd.CommandText = "EXEC sp_Retrieve_Master_SupplierBySuppID '" & txtSuppID.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_utang)

                If dt_utang.Rows.Count > 0 Then
                    txtNamaSupp.Text = dt_utang.Rows(0).Item(GlobalVar.Fields.Supp_Name).ToString

                End If
                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        If GridUtangBB.Item(4, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtSuppID.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)
        SetBackColor_Field("UPDATE")
        Status_Proses = "EDIT"
        SetToolTip()
        txtSuppID.Enabled = False
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
        If txtSuppID.Text.Trim = "" Then
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

                Cmd.CommandText = "exec sp_Delete_Master_Utang_BB '" & Period & "' ,'" & txtSuppID.Text.Trim & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtSuppID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridUtangBB.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String = ""
        Dim lv_debet As String = ""
        Dim lv_credit As String = ""
        Dim dtTemp As New DataTable
        If txtNamaSupp.Text = "" Or txtNamaSupp.Text = String.Empty Then
            MessageBox.Show("Nama Supplier Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If TxtValue.Text = "" Or TxtValue.Text = String.Empty Then
            MessageBox.Show("Debit/Credit Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbxPeriod.Text = "" Or cbxPeriod.SelectedItem = String.Empty Then
            MessageBox.Show("Period Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtSuppID.Text = "" Or txtSuppID.Text = String.Empty Then
            MessageBox.Show("Supp ID Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If rbDebet.Checked Then
            lv_debet = Replace(TxtValue.Text, ",", ".")
        Else
            lv_credit = Replace(TxtValue.Text, ",", ".")
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

                Cmd.CommandText = "exec sp_Update_Master_Utang_BB '" & Period & "', '" & txtSuppID.Text.Trim & "', '" _
                                & lv_debet & "' ,'" & lv_credit & "' ,'" _
                               & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtSuppID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

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

                Cmd.CommandText = "exec sp_Retrieve_Master_Utang_BB_ByPK '" & Period & "', '" & txtSuppID.Text.Trim & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dtTemp)
                If dtTemp.Rows.Count > 0 Then
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Update_Master_Utang_BB '" & Period & "', '" & txtSuppID.Text.Trim & "', '" _
                                        & lv_debet & "' ,'" & lv_credit & "' ,'" _
                                       & userlog.UserName & "',  '" & lv_active & "'"

                    Cmd.ExecuteNonQuery()
                    Insert_Trans_History(txtSuppID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                Else
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text

                    Cmd.CommandText = "exec sp_Insert_Master_Utang_BB '" & Period & "', '" & txtSuppID.Text.Trim & "', '" _
                                    & lv_debet & "' ,'" & lv_credit & "' ,'" _
                                 & userlog.UserName & "',  '" & lv_active & "'"

                    Cmd.ExecuteNonQuery()

                    'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    Insert_Trans_History(txtSuppID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
                End If


                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridUtangBB.DataSource = Nothing
        InitField()
        SetEnabled(False)
        Status_Proses = String.Empty
        SetToolTip()
        LoadGrid()
        SetBackColor_Field("SAVE")
    End Sub

    Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class