Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterObject
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String
    Private Sub Frm_MasterObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()
        loadCbsearch()
        LoadCbGrpID()
    End Sub
    Private Sub InitField()
        txtObjID.Text = String.Empty
        txtObjDesc.Text = String.Empty
        rbYes.Checked = True
        rbNo.Checked = False
        txtMenuName.Text = String.Empty
        'If lv_click <> "Y" Then
        '    GridObj.DataSource = Nothing
        'End If

    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        'txtObjID.Enabled = Flag
        txtObjDesc.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        cbObjGrpID.Enabled = Flag
        txtMenuName.Enabled = Flag
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
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Object"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridObj.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub GridObj_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridObj.CellDoubleClick
        Dim i As Integer
        i = GridObj.CurrentRow.Index
        txtObjID.Text = GridObj.Item(0, i).Value
        cbObjGrpID.SelectedValue = GridObj.Item(1, i).Value
        txtObjDesc.Text = GridObj.Item(2, i).Value
        txtMenuName.Text = GridObj.Item(3, i).Value.ToString.Trim
        If GridObj.Item(4, i).Value.ToString = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtObjID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Edit !")
            Exit Sub
        End If
        SetEnabled(True)
        StatusTrans = "EDIT"
        SetToolTip()
        txtObjID.Enabled = False
        cbObjGrpID.Enabled = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        SetEnabled(True)
        StatusTrans = "NEW"
        SetToolTip()
        InitField()
        lv_click = ""
        'txtObjID.Text = setFuncID()
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
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Object'"

            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)


            cb_searchBaseon.ValueMember = "Column_name"
            cb_searchBaseon.DisplayMember = "Column_name"
            cb_searchBaseon.DataSource = dtTemp
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
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
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Object'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                GridObj.DataSource = dtTemp
            End If

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
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
        sql = "select count(*) from Master_Object"
        Dim ocmd As New Data.SqlClient.SqlCommand(sql, Conn)
        totRec = ocmd.ExecuteScalar
        totRec += 1
        tmpCount = "000000" + totRec.ToString
        strMix = "OB" & tmpCount.Substring(tmpCount.Length - 3)
        Conn.Close()
        txtObjID.Text = strMix
        Return strMix
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        Dim LastSerial As Integer
        If txtObjDesc.Text = "" Or txtObjDesc.Text = String.Empty Then
            MessageBox.Show("Description Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'userlog.UserName = "hhadiant"
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
                Cmd.CommandText = "exec sp_Update_Master_Object '" & txtObjID.Text.Trim & "', '" & cbObjGrpID.SelectedValue.ToString.Trim & "', '" & txtObjDesc.Text.Trim & "', '" & txtMenuName.Text & "', '" _
                              & userlog.UserName & "', '" & lv_active & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtObjID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
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

                txtObjID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtObjID.Text, 3))

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Object '" & txtObjID.Text & "', '" & cbObjGrpID.SelectedValue.ToString.Trim & "' ,'" & txtObjDesc.Text & "', '" & txtMenuName.Text & "', '" _
                             & "Y', '" & userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtObjID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridObj.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtObjID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !")
            Exit Sub
        End If
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Object '" & txtObjID.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridObj.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub
    Private Sub LoadCbGrpID()
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
            Cmd.CommandText = "exec sp_Retrieve_Master_ObjectGroup_Cb"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            cbObjGrpID.ValueMember = "ObjGrp_ID"
            cbObjGrpID.DisplayMember = "Object Group List"
            cbObjGrpID.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub
End Class