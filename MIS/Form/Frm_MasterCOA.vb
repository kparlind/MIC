Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterCOA
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_MasterCOA_LOad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()
        loadCbsearch()

    End Sub
    Private Sub InitField()
        'cbxCC.SelectedItem = ""
        txtAccID.Text = String.Empty
        txtAccName.Text = String.Empty
        txtLvl.Text = String.Empty
        chkPostEdit.Checked = False
        cbxPayAcc.SelectedItem = ""
        rbLaba.Checked = True
        'If lv_click <> "Y" Then
        '    GridCOA.DataSource = Nothing
        'End If
        rbYes.Checked = True
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        'cbxCC.Enabled = Flag
        txtAccID.Enabled = Flag
        txtAccName.Enabled = Flag
        txtLvl.Enabled = Flag
        cbxPayAcc.Enabled = Flag
        chkPostEdit.Enabled = Flag
        rbLaba.Enabled = Flag
        rbNeraca.Enabled = Flag
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
            Cmd.CommandText = "exec sp_Retrieve_Master_COA"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridCOA.DataSource = dtTemp
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub SetGrid()
        GridCOA.Columns(0).Width = 50
        GridCOA.Columns(1).Width = 100
        GridCOA.Columns(2).Width = 50
        GridCOA.Columns(3).Width = 50
        GridCOA.Columns(4).Width = 50
        GridCOA.Columns(5).Width = 100
    End Sub

    Private Sub GridCOA_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCOA.CellDoubleClick
        Dim i As Integer
        i = GridCOA.CurrentRow.Index
        'cbxCC.SelectedItem = GridCOA.Item(0, i).Value
        txtAccID.Text = GridCOA.Item(0, i).Value
        txtAccName.Text = GridCOA.Item(1, i).Value
        txtLvl.Text = GridCOA.Item(2, i).Value
        If GridCOA.Item(3, i).Value = "Y" Then
            chkPostEdit.Checked = True
        Else
            chkPostEdit.Checked = False
        End If
        If GridCOA.Item(4, i).Value = "L" Then
            rbLaba.Checked = True
        Else
            rbNeraca.Checked = True
        End If
        cbxPayAcc.SelectedItem = GridCOA.Item(5, i).Value
        If GridCOA.Item(6, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtAccID.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)

        StatusTrans = "EDIT"
        SetToolTip()
        'cbxCC.Enabled = False
        txtAccID.Enabled = False
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
        Frm_MasterCOA_LOad(sender, e)
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_COA'"

            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtTemp
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_COA'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                GridCOA.DataSource = dtTemp
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lvPostEdit As String
        Dim chkLaba As String
        Dim lvActive As String = ""
        Dim dtCOA As New DataTable
        If txtAccName.Text = "" Or txtAccName.Text = String.Empty Then
            MessageBox.Show("Account name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'userlog.UserName = "hhadiant"
        If chkPostEdit.Checked Then
            lvPostEdit = "Y"
        Else
            lvPostEdit = "N"
        End If
        If rbLaba.Checked Then
            chkLaba = "L"
        Else
            chkLaba = "N"
        End If
        If rbYes.Checked Then
            lvActive = "Y"
        Else
            lvActive = "N"
        End If


        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_COA  '" & txtAccID.Text.Trim & "', '" & txtAccName.Text.Trim & "', '" _
                                & txtLvl.Text.ToString.Trim & "' ,'" & lvPostEdit & "', '" & chkLaba & "', '" & cbxPayAcc.SelectedItem.ToString.Trim & "' ,'" _
                               & userlog.UserName & "',  '" & lvActive & "'"

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
                dtCOA.Clear()
                Cmd.CommandText = "EXEC sp_Retrieve_Master_COA_ByPK '" & txtAccID.Text.Trim & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dtCOA)
                If dtCOA.Rows.Count > 0 Then
                    MessageBox.Show("COA is already exist! Please add another key", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Conn.Close()
                    Exit Sub
                End If

                'txtAccID.Text = Generate_MasterNo(Me.Name)
                'LastSerial = CInt(Microsoft.VisualBasic.Right(txtAccID.Text, 3))


                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_COA '" & txtAccID.Text & "', '" & txtAccName.Text.Trim & "', '" _
                                & txtLvl.Text.ToString.Trim & "' ,'" & lvPostEdit & "', '" & chkLaba & "', '" & cbxPayAcc.SelectedItem.ToString.Trim & "' ,'" _
                             & userlog.UserName & "',  '" & lvActive & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridCOA.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtAccID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If lv_click = "Y" Then
            Try

                Conn.ConnectionString = ConnectStr
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_COA '" & txtAccID.Text & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridCOA.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub

    Private Sub txtLvl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLvl.KeyDown
        If (e.KeyCode >= Asc("1") AndAlso e.KeyCode <= Asc("9")) OrElse e.KeyCode = Asc("-") OrElse e.KeyCode = Asc(".") OrElse e.KeyCode = 8 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtLvl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLvl.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class
