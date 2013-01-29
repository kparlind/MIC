Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_AccessObject
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_AccessObject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        'loadCbsearch()
        'LoadCbObj()
        'LoadCbFunc()
        StatusTrans = "FIRST"
        LoadcbAccess()
        LoadCbObjectGroup()
        LoadGrid()
    End Sub
    Private Sub InitField()
     
        'cb_searchBaseon.SelectedValue = String.Empty
        'cb_searchBaseon.SelectedText = String.Empty
        rbYes.Checked = True
        rbNo.Checked = False
        If lv_click <> "Y" Then
            GridAccObj.DataSource = Nothing
        End If

    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
      
        cbAccID.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        GridAccObj.Enabled = Flag
        cbObjGrp.Enabled = Flag
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
        Dim dtTempObj As New DataTable
        Dim dtTempMix As New DataTable
        Dim dtFunc As New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            GridAccObj.Rows.Clear()
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            If cbObjGrp.SelectedValue.ToString.Trim <> "-1" Then
                Cmd.CommandText = "exec sp_Retrieve_Master_Object_Cb_ID '" & cbObjGrp.SelectedValue.ToString.Trim & "'"
            Else
                Cmd.CommandText = "exec sp_Retrieve_Master_Object_Cb_ID '' "
            End If
            DA.SelectCommand = Cmd
            DA.Fill(dtTempObj)

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Function 'Function_ID',''"
            DA.SelectCommand = Cmd
            DA.Fill(dtFunc)


            Dim objcol As New DataGridViewTextBoxColumn


            Dim i As Integer = 1


            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            If cbAccID.SelectedValue.ToString.Trim = "-1" Then
                Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByAccID ''"
            Else
                Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByAccID '" & cbAccID.SelectedValue.ToString.Trim & "'"
                'Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByAccID '" & cbAccID.SelectedValue.ToString.Trim & "','" & cbObjGrp.SelectedValue.ToString.Trim & "'"
            End If

         

            DA.SelectCommand = Cmd
            DA.Fill(dtTempMix)

            If dtTempMix.Rows.Count > 0 Then
                For Each row As DataRow In dtTempObj.Rows
                    Dim lvInsert As Boolean
                    Dim lvEdit As Boolean
                    'Dim lvSave As Boolean
                    Dim lvDelete As Boolean, lvView As Boolean, lvPrint As Boolean, lvExport As Boolean


                    Dim dv As New Data.DataView(dtTempMix)


                    dv.RowFilter = "Object_ID = '" & row("Object_ID").ToString.Trim & "'"
                    If dv.Count > 0 Then
                        For Each item As DataRowView In dv

                            If item("Function_Desc").ToString.Trim = "INSERT" Then
                                lvInsert = True
                            ElseIf item("Function_Desc").ToString.Trim = "EDIT" Then
                                lvEdit = True
                                'ElseIf item("Function_Desc").ToString.Trim = "SAVE" Then
                                '    lvSave = True
                            ElseIf item("Function_Desc").ToString.Trim = "DELETE" Then
                                lvDelete = True
                            ElseIf item("Function_Desc").ToString.Trim = "VIEW" Then
                                lvView = True
                            ElseIf item("Function_Desc").ToString.Trim = "PRINT" Then
                                lvPrint = True
                            ElseIf item("Function_Desc").ToString.Trim = "EXPORT" Then
                                lvExport = True
                            End If

                        Next

                    End If
                    'GridAccObj.Rows.Add(row("Object_Desc").ToString.Trim, lvInsert, lvEdit, lvSave, lvDelete, lvView, lvPrint, lvExport, row("Object_ID").ToString.Trim)
                    GridAccObj.Rows.Add(row("Object_Desc").ToString.Trim, lvInsert, lvEdit, lvDelete, lvView, lvPrint, lvExport, row("Object_ID").ToString.Trim)
                    lvInsert = False
                    lvEdit = False
                    ' lvSave = False
                    lvDelete = False
                    lvView = False
                    lvPrint = False
                    lvExport = False
                Next
            End If

            Conn.Close()
            dtTemp.Clear()
            dtFunc.Clear()
            dtTempMix.Clear()
            dtTempObj.Clear()
            StatusTrans = ""
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    'Private Sub LoadCbObj()
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dtTemp As New DataTable

    '    Try
    '        Conn.ConnectionString = ConnectStr
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.CommandText = "exec sp_Retrieve_Master_Object_Cb"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)


    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub
    'Private Sub LoadCbFunc()
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dtTemp As New DataTable

    '    Try
    '        Conn.ConnectionString = ConnectStr
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.CommandText = "exec sp_Retrieve_Master_Function_Cb"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)


    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    Private Sub LoadCbAccess()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable
        Dim dView As DataView

        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Access_Cb"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            dtTemp.Rows.Add("-1", "Please Choose Access ID")
            dView = New DataView(dtTemp)
            dView.Sort = "Access_ID ASC"
            cbAccID.ValueMember = "Access_ID"
            cbAccID.DisplayMember = "Acc List"
            cbAccID.DataSource = dView

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LoadCbObjectGroup()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp2 As New DataTable
        Dim dView2 As DataView

        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_ObjectGroup_Cb"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp2)

            dtTemp2.Rows.Add("-1", "Please Choose Object Group")
            dView2 = New DataView(dtTemp2)
            dView2.Sort = "ObjGrp_ID ASC"
            cbObjGrp.ValueMember = "ObjGrp_ID"
            cbObjGrp.DisplayMember = "ObjGrp_Desc"
            cbObjGrp.DataSource = dView2

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub GridAccObj_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim i As Integer
        If GridAccObj.RowCount > 0 Then
            i = GridAccObj.CurrentRow.Index

            'If GridAccObj.Item(4, i).Value.ToString = "Y" Then
            '    rbYes.Checked = True
            'Else
            '    rbNo.Checked = True
            'End If
            lv_click = "Y"
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'If cbAccID.SelectedValue = "-1" Then
        '    MessageBox.Show("Please choose at least one access ID !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
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
        Frm_AccessObject_Load(sender, e)
    End Sub
    'Private Sub loadCbsearch()
    '    Try
    '        Conn.ConnectionString = ConnectStr
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text

    '        Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_AccessObject'"

    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)


    '        cb_searchBaseon.ValueMember = "Column_name"
    '        cb_searchBaseon.DisplayMember = "Column_name"
    '        cb_searchBaseon.DataSource = dtTemp
    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    'Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dtTemp As New DataTable

    '    Try
    '        Conn.ConnectionString = GlobalVar.ConnectStr
    '        Conn.Open()

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'AccessObject'"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)

    '        GridAccObj.DataSource = dtTemp

    '        Conn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Function setFuncID() As String 'Untuk auto generate Func ID
        Dim strMix As String = ""
        Dim sql As String
        Dim totRec As Integer = 0
        If Conn.State = Data.ConnectionState.Closed Then
            Conn.Open()
        End If
        Dim tmpCount As String
        sql = "select count(*) from Master_AccessObject"
        Dim ocmd As New Data.SqlClient.SqlCommand(sql, Conn)
        totRec = ocmd.ExecuteScalar
        totRec += 1
        tmpCount = "000000" + totRec.ToString
        strMix = "AC" & tmpCount.Substring(tmpCount.Length - 3)
        Conn.Close()

        Return strMix
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        Dim i As Integer = 1
        Dim lvInsert As String, lvEdit As String, lvDelete As String, lvView As String, lvPrint As String, lvExport As String
        Dim lvCount As Integer
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
            'Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & cbObjID.SelectedValue.ToString.Trim & "', '" & cbFuncID.SelectedValue.ToString.Trim & "' , '" _
            '              & "hhadiant', '" & lv_active & "'"

            'Cmd.ExecuteNonQuery()
            If GridAccObj.Rows.Count > 0 Then
                cbAccID.Focus()
                For Each row As DataGridViewRow In GridAccObj.Rows
                    'MessageBox.Show(row.Cells.Item(0).Value.ToString)
                    If row.Cells.Item(1).Value Then
                        lvInsert = "FN001"
                        'MessageBox.Show("INSERT")

                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvInsert & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvInsert & "' ," _
                            & "'Y', '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvInsert & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        lvInsert = "FN001"
                        'Cek data
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvInsert & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvInsert & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    End If

                    If row.Cells.Item(2).Value Then
                        lvEdit = "FN002"
                        'MessageBox.Show("EDIT")

                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvEdit & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvEdit & "' ," _
                            & "'Y', '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvEdit & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        'Cek data
                        lvEdit = "FN002"
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvEdit & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvEdit & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                        'Jika ada datanya maka update
                    End If

                    'If row.Cells.Item(3).Value Then
                    '    lvSave = "FN003"
                    '    'MessageBox.Show("SAVE")
                    '    Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(8).Value.ToString & "', '" & lvSave & "' "

                    '    lvCount = Cmd.ExecuteScalar
                    '    If lvCount = 0 Then
                    '        'Insert Data
                    '        Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(8).Value.ToString & "', '" & lvSave & "' ," _
                    '        & "'Y', '" & userlog.UserName & "' "
                    '        Cmd.ExecuteNonQuery()
                    '    Else
                    '        'Update Data
                    '        Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(8).Value.ToString & "', '" & lvSave & "' , " _
                    '                   & "'Y' , '" & userlog.UserName & "'"
                    '        Cmd.ExecuteNonQuery()
                    '    End If
                    'Else
                    '    'Cek data
                    '    lvSave = "FN003"
                    '    Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(8).Value.ToString & "', '" & lvSave & "' "

                    '    lvCount = Cmd.ExecuteScalar
                    '    'Jika ada datanya maka update
                    '    If lvCount > 0 Then
                    '        'Update Data With Active Flag = N
                    '        Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(8).Value.ToString & "', '" & lvSave & "' , " _
                    '            & "'N' , '" & userlog.UserName & "'"
                    '        Cmd.ExecuteNonQuery()
                    '    End If
                    '    'Jika ada datanya maka update
                    'End If

                    If row.Cells.Item(3).Value Then
                        lvDelete = "FN003"
                        'MessageBox.Show("DELETE")
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvDelete & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvDelete & "' ," _
                            & "'Y', '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvDelete & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        'Cek data
                        lvDelete = "FN003"
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvDelete & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvDelete & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                        'Jika ada datanya maka update

                    End If

                    If row.Cells.Item(4).Value Then
                        lvView = "FN004"
                        'MessageBox.Show("VIEW")
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvView & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvView & "' ," _
                            & "'Y', '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvView & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        'Cek data
                        lvView = "FN004"
                        'Jika ada datanya maka update
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvView & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvView & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    End If

                    If row.Cells.Item(5).Value Then
                        lvPrint = "FN005"
                        'MessageBox.Show("PRINT")
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvPrint & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvPrint & "' ," _
                            & "'Y', '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvPrint & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        'Cek data
                        lvPrint = "FN005"
                        'Jika ada datanya maka update
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvPrint & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvPrint & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                        'Jika ada datanya maka update
                    End If

                    If row.Cells.Item(6).Value Then
                        lvExport = "FN006"
                        'MessageBox.Show("EXPORT")
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvExport & "' "

                        lvCount = Cmd.ExecuteScalar
                        If lvCount = 0 Then
                            'Insert Data
                            Cmd.CommandText = "sp_Insert_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvExport & "' ," _
                            & "'Y', '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        Else
                            'Update Data
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvExport & "' , " _
                                       & "'Y' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Else
                        'Cek data
                        lvExport = "FN006"
                        Cmd.CommandText = "exec sp_Retrieve_Master_AccessObjectByPK '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvExport & "' "

                        lvCount = Cmd.ExecuteScalar
                        'Jika ada datanya maka update
                        If lvCount > 0 Then
                            'Update Data With Active Flag = N
                            Cmd.CommandText = "exec sp_Update_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & row.Cells.Item(7).Value.ToString & "', '" & lvExport & "' , " _
                                & "'N' , '" & userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                        'Jika ada datanya maka update
                    End If

                Next
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridAccObj.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
        'cbAccID.SelectedValue = "-1"
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                'Cmd.CommandText = "exec sp_Delete_Master_AccessObject '" & cbAccID.SelectedValue.ToString.Trim & "', '" & cbObjID.SelectedValue & "', '" & cbFuncID.SelectedValue & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridAccObj.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DataGridView1.ColumnCount = 3
    '    DataGridView1.Columns(0).Name = "Product ID"
    '    DataGridView1.Columns(1).Name = "Product Name"
    '    DataGridView1.Columns(2).Name = "Product_Price"

    '    Dim row As String() = New String() {"1", "Product 1", "1000"}
    '    DataGridView1.Rows.Add(row)
    '    row = New String() {"2", "Product 2", "2000"}
    '    DataGridView1.Rows.Add(row)
    '    row = New String() {"3", "Product 3", "3000"}
    '    DataGridView1.Rows.Add(row)
    '    row = New String() {"4", "Product 4", "4000"}
    '    DataGridView1.Rows.Add(row)

    '    Dim chk As New DataGridViewCheckBoxColumn()
    '    DataGridView1.Columns.Add(chk)
    '    chk.HeaderText = "Check Data"
    '    chk.Name = "chk"
    '    DataGridView1.Rows(2).Cells(3).Value = True


    'End Sub

    Private Sub cbAccID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAccID.SelectedIndexChanged
        GridAccObj.DataSource = Nothing
        If StatusTrans <> "FIRST" Then
            LoadGrid()
        End If
    End Sub

    Private Sub cbObjGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbObjGrp.SelectedIndexChanged
        GridAccObj.DataSource = Nothing
        If StatusTrans <> "FIRST" Then
            If cbAccID.SelectedValue.ToString.Trim = "-1" Then
                MessageBox.Show("Please choose Access ID First !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cbObjGrp.SelectedValue = "-1"
                Exit Sub
            End If
            LoadGrid()
        End If
  
    End Sub
End Class