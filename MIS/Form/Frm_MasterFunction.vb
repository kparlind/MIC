Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterFunction
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_MasterFunction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid("Function_ID", txtFuncID.Text.Trim)
        loadCbsearch()
    End Sub
    Private Sub InitField()
        txtFuncDesc.Text = String.Empty
        txtFuncID.Text = String.Empty
        rbYes.Checked = True
        rbNo.Checked = False
        If lv_click <> "Y" Then
            GridFunc.DataSource = Nothing
        End If

    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        txtFuncDesc.Enabled = Flag
        'txtFuncID.Enabled = Flag
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
            Cmd.CommandText = "exec sp_Retrieve_Master_Function '" & Field & "','" & keyword & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridFunc.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Conn.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub GridFunc_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridFunc.CellDoubleClick
        Dim i As Integer
        i = GridFunc.CurrentRow.Index
        txtFuncID.Text = GridFunc.Item(0, i).Value
        txtFuncDesc.Text = GridFunc.Item(1, i).Value
        If GridFunc.Item(2, i).Value.ToString = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtFuncID.Text.Trim = "" Then
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
        lv_click = ""
        ' txtFuncID.Text = setFuncID()
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
        Frm_MasterFunction_Load(sender, e)
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Function'"

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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Function'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count = 0 Then
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                LoadGrid(cb_searchBaseon.SelectedValue.ToString, txt_SearchData.Text.ToString)
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
        sql = "select count(*) from master_function"
        Dim ocmd As New Data.SqlClient.SqlCommand(sql, Conn)
        totRec = ocmd.ExecuteScalar
        totRec += 1
        tmpCount = "000000" + totRec.ToString
        strMix = "FN" & tmpCount.Substring(tmpCount.Length - 3)
        Conn.Close()
        txtFuncID.Text = strMix
        Return strMix
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String = ""
        Dim LastSerial As Integer
        If txtFuncDesc.Text = "" Or txtFuncDesc.Text = String.Empty Then
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
                Cmd.CommandText = "exec sp_Update_Master_Function '" & txtFuncID.Text.Trim & "', '" & txtFuncDesc.Text.Trim & "', '" _
                              & userlog.UserName & "', '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                Insert_Trans_History(txtFuncID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

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

                txtFuncID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtFuncID.Text, 3))


                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Function '" & txtFuncID.Text & "', '" & txtFuncDesc.Text & "', '" _
                             & lv_active & "', '" & userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtFuncID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridFunc.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid("Function_ID", txtFuncID.Text.Trim)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtFuncID.Text.Trim = "" Then
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

                Cmd.CommandText = "exec sp_Delete_Master_Function '" & txtFuncID.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridFunc.DataSource = Nothing
        LoadGrid("Function_ID", txtFuncID.Text.Trim)
        SetToolTip()
        InitField()
    End Sub
End Class
