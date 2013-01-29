Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Math
Imports System.Data.SqlClient

Public Class Frm_MasterEmployee
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String
    Private Sub Frm_MasterEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitField()
        Conn.ConnectionString = ConnectStr        
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid("Employee_ID", txtEmployeeID.Text.Trim)
        loadCbsearch()
    End Sub
    Private Sub InitField()

        txtEmployeeID.Text = String.Empty
        txtName.Text = String.Empty
        txtAccessID.Text = String.Empty
        chkIsUser.Checked = False
        txtUserName.Text = String.Empty

        txtDeptID.Text = String.Empty
        txtAddress1.Text = String.Empty
        txtAddress2.Text = String.Empty
        txtPhone1.Text = String.Empty
        txtPhone2.Text = String.Empty
        txtMobile.Text = String.Empty
        txtEmail.Text = String.Empty
        dtpHireDt.Refresh()
        rbMale.Checked = True
        rbYes.Checked = True
        'If lv_click <> "Y" Then
        '    GridEmployee.DataSource = Nothing
        'End If
        lblAccDesc.Text = String.Empty
        lblDeptDesc.Text = String.Empty
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)

        txtName.Enabled = Flag
        txtAccessID.Enabled = Flag
        chkIsUser.Enabled = Flag
        txtUserName.Enabled = Flag

        'txtDeptID.Enabled = Flag
        txtAddress1.Enabled = Flag
        txtAddress2.Enabled = Flag
        txtPhone1.Enabled = Flag
        txtPhone2.Enabled = Flag
        txtMobile.Enabled = Flag
        txtEmail.Enabled = Flag
        dtpHireDt.Enabled = Flag
        rbMale.Enabled = Flag
        rbFemale.Enabled = Flag
        chkIsUser.Enabled = Flag
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
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try

            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_Retrieve_Master_EmployeeAll '" & Field & "','" & keyword & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridEmployee.DataSource = dtTemp
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub SetGrid()
        GridEmployee.Columns(0).Width = 50
        GridEmployee.Columns(1).Width = 100
        GridEmployee.Columns(2).Width = 50
        GridEmployee.Columns(3).Width = 150
        GridEmployee.Columns(4).Width = 50
        GridEmployee.Columns(5).Width = 100
        GridEmployee.Columns(6).Width = 50
        GridEmployee.Columns(7).Width = 150
        GridEmployee.Columns(8).Width = 150
        GridEmployee.Columns(9).Width = 150
        'GridEmployee.Columns(2).Visible = False
        'GridEmployee.Columns(6).Visible = False
    End Sub
    Private Sub GridEmployee_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridEmployee.CellDoubleClick
        Dim i As Integer
        i = GridEmployee.CurrentRow.Index
        txtEmployeeID.Text = GridEmployee.Item(0, i).Value
        txtName.Text = GridEmployee.Item(1, i).Value
        txtAccessID.Text = GridEmployee.Item(2, i).Value
        lblAccDesc.Text = GridEmployee.Item(3, i).Value
        If GridEmployee.Item(4, i).Value.ToString = "Y" Then
            chkIsUser.Checked = True
        Else
            chkIsUser.Checked = False
        End If
        txtUserName.Text = GridEmployee.Item(4, i).Value
        'txtPassword.Text = GridEmployee.Item(5, i).Value
        txtDeptID.Text = GridEmployee.Item(6, i).Value
        lblDeptDesc.Text = GridEmployee.Item(7, i).Value
        txtAddress1.Text = GridEmployee.Item(8, i).Value
        txtAddress2.Text = GridEmployee.Item(9, i).Value
        txtPhone1.Text = GridEmployee.Item(10, i).Value
        txtPhone2.Text = GridEmployee.Item(11, i).Value
        txtMobile.Text = GridEmployee.Item(12, i).Value
        txtEmail.Text = GridEmployee.Item(13, i).Value
        dtpHireDt.Value = GridEmployee.Item(14, i).Value
        If GridEmployee.Item(15, i).Value.ToString = "M" Then
            rbMale.Checked = True
        Else
            rbFemale.Checked = True
        End If
        If GridEmployee.Item(16, i).Value.ToString = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        lv_click = "Y"
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtEmployeeID.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SetEnabled(True)

        StatusTrans = "EDIT"
        SetToolTip()

        txtEmployeeID.Enabled = False
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
        LoadGrid("Employee_ID", txtEmployeeID.Text.Trim)
    End Sub
    Private Sub loadCbsearch()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Employee'"
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
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Employee'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count > 0 Then
                LoadGrid(cb_searchBaseon.SelectedValue.ToString, txt_SearchData.Text.ToString)
            Else
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            'GridEmployee.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_IsUser As String = ""
        Dim lv_Sex As String = ""
        Dim lv_date As String
        Dim lv_active As String = ""
        Dim LastSerial As Integer
        Dim password As String
        Dim dtTmp As New DataTable
        'Validation
        If txtName.Text = "" Or txtName.Text = String.Empty Then
            MessageBox.Show("Name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAccessID.Text = "" Or txtAccessID.Text = String.Empty Then
            MessageBox.Show("Access ID Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtUserName.Text = "" Or txtUserName.Text = String.Empty Then
            MessageBox.Show("User name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtDeptID.Text = "" Or txtDeptID.Text = String.Empty Then
            MessageBox.Show("Dept ID Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAddress1.Text = "" Or txtAddress1.Text = String.Empty Then
            MessageBox.Show("Address 1 Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtAddress2.Text = "" Or txtAddress2.Text = String.Empty Then
        '    MessageBox.Show("Address 2 Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If txtPhone1.Text = "" Or txtPhone1.Text = String.Empty Then
            MessageBox.Show("Phone 1 Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtPhone2.Text = "" Or txtPhone2.Text = String.Empty Then
        '    MessageBox.Show("Phone 2 Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtMobile.Text = "" Or txtMobile.Text = String.Empty Then
        '    MessageBox.Show("Mobile Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If txtEmail.Text = "" Or txtEmail.Text = String.Empty Then
            MessageBox.Show("Email Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        lv_IsUser = ""
        lv_Sex = ""
        If chkIsUser.Checked Then
            lv_IsUser = "Y"
        Else
            lv_IsUser = "N"
        End If
        If rbMale.Checked Then
            lv_Sex = "M"
        Else
            lv_Sex = "F"
        End If
        If rbYes.Checked Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If
        dtpHireDt.Format = DateTimePickerFormat.Custom
        dtpHireDt.CustomFormat = "MM/dd/yyyy"
        lv_date = dtpHireDt.Value.Month & "/" & dtpHireDt.Value.Day & "/" & dtpHireDt.Value.Year

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "exec sp_Retrieve_Master_Employee_ByUserName '" & txtUserName.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtTmp)
        If dtTmp.Rows.Count > 0 Then
            MessageBox.Show("User Name Exist ! Please use another user name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If lv_click = "Y" Then
            Try
                'txtEmployeeID.Text = Generate_MasterNo(Me.Name)
                Cmd.CommandText = "exec sp_Update_Master_Employee '" & txtEmployeeID.Text.ToString.Trim & "', '" & txtName.Text.Trim & "', '" & txtAccessID.Text.Trim & "', '" & lv_IsUser & "', '" _
                                & txtUserName.Text.ToString.Trim & "' ,'', '" & txtDeptID.Text.Trim & "', '" & txtAddress1.Text.Trim & "' ,'" _
                                & txtAddress2.Text.ToString.Trim & "' ,'" & txtPhone1.Text.Trim & "', '" & txtPhone2.Text.Trim & "', '" & txtMobile.Text.Trim & "' ,'" _
                                & txtEmail.Text.ToString.Trim & "' ,'" & lv_date & "', '" & lv_Sex & "' ,'" _
                               & userlog.UserName & "',  '" & lv_active & "'"

                Cmd.ExecuteNonQuery()

                'UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtEmployeeID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            Try
                'txtAccID.Text = Generate_TranNo(Me.Name)
                'LastSerial = CInt(Microsoft.VisualBasic.Right(txtAccID.Text, 3))
                txtEmployeeID.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtEmployeeID.Text, 3))
                If Conn.State = Data.ConnectionState.Closed Then
                    Conn.Open()
                End If
                password = txtUserName.Text.Trim ' password awal adalah sama dengan UserName

                Cmd.CommandText = "exec sp_Insert_Master_Employee '" & txtEmployeeID.Text.ToString.Trim & "', '" & txtName.Text.Trim & "', '" & txtAccessID.Text.Trim & "', '" & lv_IsUser & "', '" _
                             & txtUserName.Text.ToString.Trim & "' ,'" & password & "', '" & txtDeptID.Text.Trim & "', '" & txtAddress1.Text.Trim & "' ,'" _
                             & txtAddress2.Text.ToString.Trim & "' ,'" & txtPhone1.Text.Trim & "', '" & txtPhone2.Text.Trim & "', '" & txtMobile.Text.Trim & "' ,'" _
                             & txtEmail.Text.ToString.Trim & "' ,'" & lv_date & "', '" & lv_Sex & "' ,'" _
                            & userlog.UserName & "',  'Y'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtEmployeeID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("New Employee has been created. " & vbCrLf & "System create new password similiar with username of this employee. " & vbCrLf & " Change this password immediately using menu Tools-> Change Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridEmployee.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        btnCancel_Click(sender, e)
    End Sub

    Private Function setEmployeeID() As String 'Untuk auto generate Func ID
        Dim strMix As String = ""
        Dim sql As String
        Dim totRec As Integer = 0
        If Conn.State = Data.ConnectionState.Closed Then
            Conn.Open()
        End If
        Dim tmpCount As String
        sql = "select count(*) from master_employee"
        Dim ocmd As New Data.SqlClient.SqlCommand(sql, Conn)
        totRec = ocmd.ExecuteScalar
        totRec += 1
        tmpCount = "000000" + totRec.ToString
        strMix = tmpCount.Substring(tmpCount.Length - 5)
        Conn.Close()
        'txtEmployeeID.Text = strMix
        Return strMix
    End Function
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtEmployeeID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If lv_click = "Y" Then
            Try


                If Conn.State = Data.ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_Delete_Master_Employee '" & txtEmployeeID.Text & "'"

                Cmd.ExecuteNonQuery()
                Insert_Trans_History(txtEmployeeID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction
                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        MessageBox.Show("Data has been deleted !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridEmployee.DataSource = Nothing
        SetToolTip()
        InitField()
        btnCancel_Click(sender, e)
    End Sub

    Private Sub txtPhone1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone1.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPhone2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone2.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtMobile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobile.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtAccessID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccessID.KeyDown
        Dim dt_item As New DataTable
        lblDeptDesc.Text = ""
        lblAccDesc.Text = ""
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Access_ID,Access_Desc,Show_Supplier,Insert_Price from Master_Access where Active_Flag = 'Y'", "Access_ID", "Access_Desc", "Show_Supplier", "Insert_Price", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    txtAccessID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    lblAccDesc.Text = frmSearch.txtResult2.Text.ToString.Trim

                    Cmd.CommandText = "EXEC sp_Retrieve_Master_MappingByAccID '" & txtAccessID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)
                    If dt_item.Rows.Count > 0 Then
                        txtDeptID.Text = dt_item.Rows(0).Item("Dept_ID").ToString.Trim
                        dt_item.Clear()
                        Cmd.CommandText = "EXEC sp_Retrieve_Master_DepartmentByPK '" & txtDeptID.Text.Trim & "'"
                        DA.SelectCommand = Cmd
                        DA.Fill(dt_item)

                        If dt_item.Rows.Count > 0 Then
                            lblDeptDesc.Text = dt_item.Rows(0).Item("Department_Name").ToString
                        End If
                    End If

                    txtUserName.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtAccessID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_AccessByPK '" & txtAccessID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        lblAccDesc.Text = dt_item.Rows(0).Item("Access_Desc").ToString

                        txtUserName.Focus()
                    Else
                        MessageBox.Show("Access ID not found. Please check again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Cmd.CommandText = "EXEC sp_Retrieve_Master_MappingByAccID '" & txtAccessID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)
                    If dt_item.Rows.Count > 0 Then
                        txtDeptID.Text = dt_item.Rows(0).Item("Dept_ID").ToString.Trim
                        dt_item.Clear()
                        Cmd.CommandText = "EXEC sp_Retrieve_Master_DepartmentByPK '" & txtDeptID.Text.Trim & "'"
                        DA.SelectCommand = Cmd
                        DA.Fill(dt_item)

                        If dt_item.Rows.Count > 0 Then
                            lblDeptDesc.Text = dt_item.Rows(0).Item("Department_Name").ToString
                        End If
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub txtDeptID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeptID.KeyDown
        Dim dt_item As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Department_ID,Department_Name from Master_Department where Active_Flag = 'Y'", "Department_ID", "Department_Name", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    txtDeptID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    lblDeptDesc.Text = frmSearch.txtResult2.Text.ToString.Trim

                    txtAddress1.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtAccessID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_DepartmentByPK '" & txtDeptID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        lblDeptDesc.Text = dt_item.Rows(0).Item("Department_Name").ToString

                        txtAddress1.Focus()
                    Else
                        MessageBox.Show("Department ID not found. Please check again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub btnresetpassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnresetpassword.Click
        Dim dt_reset As New DataTable

        If txtEmployeeID.Text.Trim = "" Then
            MessageBox.Show("Please Choose 1 employee that need to be reset password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_update_Employee_ResetPassword '" & txtEmployeeID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_reset)
            Insert_Trans_History(txtEmployeeID.Text.Trim, Me.Name, "RESET PASSWORD") 'Insert History transaction

            MessageBox.Show("Password has been Reset. System create new password similiar with username of this employee. " & vbCrLf & " Change this password immediately using menu Tools-> Change Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GridEmployee.DataSource = Nothing
            InitField()
            SetEnabled(False)
            StatusTrans = String.Empty
            SetToolTip()
            btnCancel_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub
End Class