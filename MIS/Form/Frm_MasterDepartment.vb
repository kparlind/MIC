Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterDepartment
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_MasterWarehouse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()
        loadCbsearch()
    End Sub
    Private Sub InitField()
        txtDeptID.Text = String.Empty
        txtDeptName.Text = String.Empty
        'If lv_click <> "Y" Then
        '    GridDept.DataSource = Nothing
        'End If
        rbYes.Checked = True
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        'txtWarehouseID.Enabled = Flag
        txtDeptName.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag

    End Sub
    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
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
    Private Sub LoadGrid()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Department_List"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridDept.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GridDept_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDept.CellDoubleClick
        Dim i As Integer
        i = GridDept.CurrentRow.Index
        txtDeptID.Text = GridDept.Item(0, i).Value.ToString.Trim
        txtDeptName.Text = GridDept.Item(1, i).Value.ToString.Trim
        If GridDept.Item(2, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtDeptID.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)

        StatusTrans = "EDIT"
        SetToolTip()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        SetEnabled(True)
        StatusTrans = "NEW"
        SetToolTip()
        InitField()
        lv_click = ""
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        InitField()
        If StatusTrans = "NEW" OrElse StatusTrans = "EDIT" Then
            SetEnabled(False)
            StatusTrans = String.Empty
        Else
            'MoveLast()
            SetEnabled(False)
            StatusTrans = String.Empty
        End If
        SetToolTip()
        LoadGrid()
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Department'"

            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtTemp
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Department'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                GridDept.DataSource = dtTemp
            End If


            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        Dim LastSerial As Integer
        If txtDeptName.Text = "" Or txtDeptName.Text = String.Empty Then
            MessageBox.Show("Department name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If rbYes.Checked Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If
        'userlog.UserName = "hhadiant"
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_Department '" & txtDeptID.Text.Trim & "', '" & txtDeptName.Text.Trim & "', '" _
                        & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtDeptID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        Else
            Try
                Conn.ConnectionString = ConnectStr
                Conn.Open()

                txtDeptID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtDeptID.Text, 3))


                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Department '" & txtDeptID.Text.Trim & "', '" & txtDeptName.Text.Trim & "', '" _
                             & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtDeptID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridDept.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtDeptID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !")
            Exit Sub
        End If
        If lv_click = "Y" Then
            Try

                Conn.ConnectionString = ConnectStr
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Department '" & txtDeptID.Text & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtDeptID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridDept.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub




End Class