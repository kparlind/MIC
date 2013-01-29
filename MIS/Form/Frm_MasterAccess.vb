Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterAccess
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_MasterAccess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()
        loadCbsearch()
    End Sub
    Private Sub InitField()
        txtAccDesc.Text = String.Empty
        txtAccID.Text = String.Empty
        rbYes.Checked = True
        rbNo.Checked = False
        chkShowSupp.Checked = False
        chkInsPrc.Checked = False
        'If lv_click <> "Y" Then
        '    GridAccess.DataSource = Nothing
        'End If

    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        txtAccDesc.Enabled = Flag
        txtAccID.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        chkShowSupp.Enabled = Flag
        chkInsPrc.Enabled = Flag
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
            If Conn.State = ConnectionState.Closed Then
                Conn.ConnectionString = ConnectStr
                Conn.Open()
            End If


            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Access"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridAccess.DataSource = dtTemp
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub SetGrid()
        GridAccess.Columns(0).Width = 50
        GridAccess.Columns(1).Width = 150
        GridAccess.Columns(2).Width = 100
        GridAccess.Columns(3).Width = 100
        GridAccess.Columns(4).Width = 100

    End Sub
    Private Sub GridAccess_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridAccess.CellDoubleClick
        Dim i As Integer
        i = GridAccess.CurrentRow.Index
        txtAccID.Text = GridAccess.Item(0, i).Value
        txtAccDesc.Text = GridAccess.Item(1, i).Value
        If GridAccess.Item(2, i).Value.ToString = "Y" Then
            chkShowSupp.Checked = True
        Else
            chkShowSupp.Checked = False
        End If
        If GridAccess.Item(3, i).Value.ToString = "Y" Then
            chkInsPrc.Checked = True
        Else
            chkInsPrc.Checked = False
        End If
        If GridAccess.Item(4, i).Value.ToString = "Y" Then
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
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        InitField()
        lv_click = ""

        SetEnabled(True)
        StatusTrans = "NEW"
        SetToolTip()
        lv_click = String.Empty
        'txtAccID.Text = setFuncID()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If StatusTrans = "NEW" OrElse StatusTrans = "EDIT" Then
            SetEnabled(False)
            StatusTrans = String.Empty
        Else
            'MoveLast()
            SetEnabled(False)
            StatusTrans = String.Empty
        End If
        SetToolTip()
        InitField()
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

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Access'"

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
            If Conn.State = ConnectionState.Closed Then
                Conn.ConnectionString = ConnectStr
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Access'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                GridAccess.DataSource = dtTemp
            End If


            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Function setFuncID() As String 'Untuk auto generate Func ID
        Dim strMix As String = ""
        Dim sql As String
        Dim totRec As Integer = 0
        If Conn.State = Data.ConnectionState.Closed Then
            Conn.Open()
        End If
        Dim tmpCount As String
        sql = "select count(*) from master_access"
        Dim ocmd As New Data.SqlClient.SqlCommand(sql, Conn)
        totRec = ocmd.ExecuteScalar
        totRec += 1
        tmpCount = "000000" + totRec.ToString
        strMix = "AC" & tmpCount.Substring(tmpCount.Length - 3)
        Conn.Close()
        txtAccID.Text = strMix
        Return strMix
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        Dim LastSerial As Integer
        Dim lvChkShowSupp As String
        Dim lvChkInsPrc As String

        If txtAccDesc.Text = "" Or txtAccDesc.Text = String.Empty Then
            MessageBox.Show("Description Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'userlog.UserName = "hhadiant"
        If chkShowSupp.Checked Then
            lvChkShowSupp = "Y"
        Else
            lvChkShowSupp = "N"
        End If
        If chkInsPrc.Checked Then
            lvChkInsPrc = "Y"
        Else
            lvChkInsPrc = "N"
        End If
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text
                If rbYes.Checked Then
                    lv_active = "Y"
                Else
                    lv_active = "N"
                End If
                Cmd.CommandText = "exec sp_Update_Master_Access '" & txtAccID.Text.Trim & "', '" & txtAccDesc.Text.Trim & "', '" _
                              & lvChkShowSupp & "','" & lvChkInsPrc & "','" & userlog.UserName & " ', '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

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

                txtAccID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtAccID.Text, 3))

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Access '" & txtAccID.Text & "', '" & txtAccDesc.Text & "', '" _
                             & lvChkShowSupp & "','" & lvChkInsPrc & "','Y', '" & userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridAccess.DataSource = Nothing
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
                If Conn.State = ConnectionState.Closed Then
                    Conn.ConnectionString = ConnectStr
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Access '" & txtAccID.Text & "'"

                Cmd.ExecuteNonQuery()

                Insert_Trans_History(txtAccID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridAccess.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub
End Class