Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterCompanyProfile
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String
    Dim lv_filename As String
    Dim fullpath As String

    Private Sub Frm_MasterCompanyProfile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadData()
        ' loadCbsearch()
    End Sub
    Private Sub InitField()
        txtCompanyID.Text = String.Empty
        txtCompanyName.Text = String.Empty
        txtNotes.Text = String.Empty
        txtOwner.Text = String.Empty
        txtCountry.Text = String.Empty
        txtProvince.Text = String.Empty
        txtCity.Text = String.Empty
        txtAddress.Text = String.Empty
        txtPhone.Text = String.Empty
        txtFax.Text = String.Empty
        txtMobile.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPostCode.Text = String.Empty
        txtLogo.Text = String.Empty
        txtTaxName.Text = String.Empty
        txtTaxNo.Text = String.Empty
        txtInvNotes.Text = String.Empty
        chkStorePrice.Checked = False
        chkProtectQty.Checked = False
        chkAutoJournal.Checked = False
        txtEmail1.Text = String.Empty
        txtEmail2.Text = String.Empty
        chkPurchase.Checked = False
        txtQuot.Text = String.Empty
        PbxLogo.ImageLocation = String.Empty
        PbxLogo.Refresh()

        rbYes.Checked = True
        rbNo.Checked = False
        'If lv_click <> "Y" Then
        '    GridCompProf.DataSource = Nothing
        'End If
        dtpTaxdt.CustomFormat = "dd-MM-yyyy"
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        ' txtCompanyID.Enabled = Flag
        txtCompanyName.Enabled = Flag
        txtNotes.Enabled = Flag
        txtOwner.Enabled = Flag
        txtCountry.Enabled = Flag
        txtProvince.Enabled = Flag
        txtCity.Enabled = Flag
        txtAddress.Enabled = Flag
        txtPhone.Enabled = Flag
        txtFax.Enabled = Flag
        txtMobile.Enabled = Flag
        txtEmail.Enabled = Flag
        txtPostCode.Enabled = Flag
        txtLogo.Enabled = Flag
        txtTaxName.Enabled = Flag
        txtTaxNo.Enabled = Flag
        txtInvNotes.Enabled = Flag
        chkStorePrice.Enabled = Flag
        chkProtectQty.Enabled = Flag
        chkAutoJournal.Enabled = Flag
        txtEmail1.Enabled = Flag
        txtEmail2.Enabled = Flag
        chkPurchase.Enabled = Flag
        dtpTaxdt.Enabled = Flag
        txtQuot.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        btn_browse.Enabled = Flag
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
                btnNew.Enabled = False
                btnEdit.Enabled = True
                btnDelete.Enabled = True

                btnSave.Enabled = False

        End Select
    End Sub
    'Private Sub LoadGrid()
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dtTemp As New DataTable

    '    Try
    '        Conn.ConnectionString = ConnString
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.CommandText = "exec sp_Retrieve_Master_CompanyProfile"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)

    '        GridCompProf.DataSource = dtTemp

    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End Try
    'End Sub
    Private Sub LoadData()
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
            Cmd.CommandText = "exec sp_Retrieve_Master_CompanyProfile"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count > 0 Then
                btnNew.Enabled = False
                txtCompanyID.Text = dtTemp.Rows(0).Item(0).ToString.Trim
                txtCompanyName.Text = dtTemp.Rows(0).Item(1).ToString.Trim
                txtNotes.Text = dtTemp.Rows(0).Item(2).ToString.Trim
                txtOwner.Text = dtTemp.Rows(0).Item(3).ToString.Trim
                txtCountry.Text = dtTemp.Rows(0).Item(4).ToString.Trim
                txtProvince.Text = dtTemp.Rows(0).Item(5).ToString.Trim
                txtCity.Text = dtTemp.Rows(0).Item(6).ToString.Trim
                txtAddress.Text = dtTemp.Rows(0).Item(7).ToString.Trim
                txtPhone.Text = dtTemp.Rows(0).Item(8).ToString.Trim
                txtFax.Text = dtTemp.Rows(0).Item(9).ToString.Trim
                txtMobile.Text = dtTemp.Rows(0).Item(10).ToString.Trim
                txtEmail.Text = dtTemp.Rows(0).Item(11).ToString.Trim
                txtPostCode.Text = dtTemp.Rows(0).Item(12).ToString.Trim
                txtLogo.Text = dtTemp.Rows(0).Item(13).ToString.Trim
                If txtLogo.Text <> "" Then
                    fullpath = txtLogo.Text
                    PbxLogo.ImageLocation = txtLogo.Text
                    PbxLogo.SizeMode = PictureBoxSizeMode.StretchImage
                    PbxLogo.Load()
                Else
                    PbxLogo.ImageLocation = ""
                End If
                txtTaxName.Text = dtTemp.Rows(0).Item(14).ToString.Trim
                txtTaxNo.Text = dtTemp.Rows(0).Item(15).ToString.Trim
                dtpTaxdt.Text = dtTemp.Rows(0).Item(16).ToString.Trim
                txtInvNotes.Text = dtTemp.Rows(0).Item(17).ToString.Trim
                If dtTemp.Rows(0).Item(18).ToString.Trim = True Then
                    chkStorePrice.Checked = True
                Else
                    chkStorePrice.Checked = False
                End If
                If dtTemp.Rows(0).Item(19).ToString.Trim = True Then
                    chkProtectQty.Checked = True
                Else
                    chkProtectQty.Checked = False
                End If
                If dtTemp.Rows(0).Item(20).ToString.Trim = True Then
                    chkAutoJournal.Checked = True
                Else
                    chkAutoJournal.Checked = False
                End If

                txtEmail1.Text = dtTemp.Rows(0).Item(21).ToString.Trim
                txtEmail2.Text = dtTemp.Rows(0).Item(22).ToString.Trim
                If dtTemp.Rows(0).Item(23).ToString.Trim = True Then
                    chkPurchase.Checked = True
                Else
                    chkPurchase.Checked = False
                End If

                txtQuot.Text = dtTemp.Rows(0).Item(24).ToString.Trim
                If dtTemp.Rows(0).Item(25).ToString.Trim = "Y" Then
                    rbYes.Checked = True
                Else
                    rbNo.Checked = True
                End If
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtCompanyID.Text.Trim = "" Then
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
        'txtCompanyID.Text = Generate_MasterNo(Me.Name)
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
        Frm_MasterCompanyProfile_Load(sender, e)
    End Sub
    'Private Sub loadCbsearch()
    '    Try
    '        Conn.ConnectionString = GlobalVar.ConnString
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text

    '        Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_CompanyProfile'"

    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)


    '        cb_searchBaseon.ValueMember = "Column_name"
    '        cb_searchBaseon.DisplayMember = "Column_name"
    '        cb_searchBaseon.DataSource = dtTemp
    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End Try
    'End Sub
    'Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dtTemp As New DataTable

    '    Try
    '        Conn.ConnectionString = GlobalVar.ConnString
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.CommandText = "exec Search_Master_CompanyProfile '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_CompanyProfile'"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dtTemp)

    '        GridCompProf.DataSource = dtTemp

    '        Conn.Close()
    '    Catch ex As Exception
    '        Conn.Close()
    '        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lv_active As String
        'If txtObjDesc.Text = "" Or txtObjDesc.Text = String.Empty Then
        '    MessageBox.Show("Description Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        Dim lv_chkstoreprice As Integer
        Dim lv_chkProtect As Integer
        Dim lv_chkAuto As Integer
        Dim lv_chkPurchase As Integer
        Dim lastSerial As Integer
        'Call Upload Images Or File        
        Dim sFileToUpload1 As String = ""
        Dim sFileToUpload2 As String = ""
        sFileToUpload1 = LTrim(RTrim(txtLogo.Text))

        Dim Extension1 As String = System.IO.Path.GetExtension(sFileToUpload1)

        Dim path As String
        path = Application.StartupPath

        'If txtLogo.Text.Trim = "" Then
        '    fullpath = path & "\UploadedImages\" & lv_filename
        'Else
        '    fullpath = txtLogo.Text.Trim
        'End If
        'userlog.UserName = "hhadiant"

        If rbYes.Checked Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If
        If chkStorePrice.Checked = True Then
            lv_chkstoreprice = 1
        End If
        If chkProtectQty.Checked = True Then
            lv_chkstoreprice = 1
        End If
        If chkAutoJournal.Checked = True Then
            lv_chkAuto = 1
        End If
        If chkPurchase.Checked = True Then
            lv_chkPurchase = 1
        End If
        dtpTaxdt.Format = DateTimePickerFormat.Custom
        dtpTaxdt.CustomFormat = "MM/dd/yyyy"
        If txtCompanyID.Text.Trim <> "" Then
            Try
                If txtLogo.Text.Trim = "" Then
                    fullpath = ""
                Else
                    fullpath = path & "\UploadedImages\" & lv_filename
                End If

                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_CompanyProfile '" & txtCompanyID.Text.Trim & "', '" & txtCompanyName.Text.Trim & "', '" _
                            & txtNotes.Text & "', '" & txtOwner.Text & "', '" & txtCountry.Text & "', '" _
                            & txtProvince.Text & "', '" & txtCity.Text & "', '" & txtAddress.Text & "', '" _
                            & txtPhone.Text & "', '" & txtFax.Text & "', '" & txtMobile.Text & "', '" _
                            & txtEmail.Text & "', '" & txtPostCode.Text & "', '" & fullpath & "', '" _
                            & txtTaxName.Text & "', '" & txtTaxNo.Text & "','" & dtpTaxdt.Text & "', '" _
                            & txtInvNotes.Text.Trim & "', '" & lv_chkstoreprice & "', '" _
                            & lv_chkProtect & "', '" & lv_chkAuto & "', '" & txtEmail1.Text & "', '" _
                            & txtEmail2.Text & "', '" & lv_chkPurchase & "', '" & txtQuot.Text.Replace(",", ".") & "', '" _
                            & lv_active & "', '" & userlog.UserName & "'"


                Cmd.ExecuteNonQuery()

                Insert_Trans_History(txtCompanyID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        Else
            Try
                fullpath = txtLogo.Text.Trim

                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                txtCompanyID.Text = Generate_MasterNo(Me.Name)
                lastSerial = CInt(Microsoft.VisualBasic.Right(txtCompanyID.Text, 3))
                If txtQuot.Text = "" Then
                    txtQuot.Text = "0"
                End If
                Cmd.CommandText = "exec sp_Insert_Master_CompanyProfile '" & txtCompanyID.Text & "', '" & txtCompanyName.Text & "', '" _
                            & txtNotes.Text & "', '" & txtOwner.Text & "', '" & txtCountry.Text & "', '" _
                            & txtProvince.Text & "', '" & txtCity.Text & "', '" & txtAddress.Text & "', '" _
                            & txtPhone.Text & "', '" & txtFax.Text & "', '" & txtMobile.Text & "', '" _
                            & txtEmail.Text & "', '" & txtPostCode.Text & "', '" & fullpath & "', '" _
                            & txtTaxName.Text & "', '" & txtTaxNo.Text & "', '" & dtpTaxdt.Text & "', '" _
                            & txtInvNotes.Text.Trim & "', '" & lv_chkstoreprice & "', '" _
                            & lv_chkProtect & "', '" & lv_chkAuto & "', '" & txtEmail1.Text & "', '" _
                            & txtEmail2.Text & "', '" & lv_chkPurchase & "', '" & txtQuot.Text & "', '" _
                            & lv_active & "', '" & userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, lastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtCompanyID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        'Call the Upload method based on the type of file        
        If StrComp(Extension1, ".bmp", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".jpg", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".jpeg", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".png", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".gif", CompareMethod.Text) = 0 Then
            If System.IO.Directory.Exists(path & "\UploadedImages\") Then
                If sFileToUpload1 <> fullpath Then
                    FileCopy(sFileToUpload1, fullpath)
                End If

            Else
                System.IO.Directory.CreateDirectory(path & "\UploadedImages\")
                FileCopy(sFileToUpload1, fullpath)

            End If
            'Else
            '    'Pass the extension            
            '    upLoadImageOrFile(sFileToUpload, Extension)
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dtpTaxdt.CustomFormat = "dd-MM-yyyy"
        ' GridCompProf.DataSource = Nothing
        'InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtCompanyID.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !")
            Exit Sub
        End If
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = ConnectStr
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_CompanyProfile '" & txtCompanyID.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        ' GridCompProf.DataSource = Nothing
        'LoadGrid()
        SetToolTip()
        InitField()
    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        lv_filename = ""
        txtLogo.Text = OpenFileDialog1.FileName
        'lv_filename = OpenFileDialog1.SafeFileName
        PbxLogo.ImageLocation = txtLogo.Text
        PbxLogo.SizeMode = PictureBoxSizeMode.StretchImage
        PbxLogo.Load()
    End Sub

    'Private Sub GridCompProf_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim i As Integer
    '    i = GridCompProf.CurrentRow.Index
    '    txtCompanyID.Text = GridCompProf.Item(0, i).Value
    '    txtCompanyName.Text = GridCompProf.Item(1, i).Value
    '    txtNotes.Text = GridCompProf.Item(2, i).Value
    '    txtOwner.Text = GridCompProf.Item(3, i).Value
    '    txtCountry.Text = GridCompProf.Item(4, i).Value
    '    txtProvince.Text = GridCompProf.Item(5, i).Value
    '    txtCity.Text = GridCompProf.Item(6, i).Value
    '    txtAddress.Text = GridCompProf.Item(7, i).Value
    '    txtPhone.Text = GridCompProf.Item(8, i).Value
    '    txtFax.Text = GridCompProf.Item(9, i).Value
    '    txtMobile.Text = GridCompProf.Item(10, i).Value
    '    txtEmail.Text = GridCompProf.Item(11, i).Value
    '    txtPostCode.Text = GridCompProf.Item(12, i).Value
    '    txtLogo.Text = GridCompProf.Item(13, i).Value

    '    If txtLogo.Text <> "" Then
    '        fullpath = txtLogo.Text
    '        PbxLogo.ImageLocation = txtLogo.Text
    '        PbxLogo.SizeMode = PictureBoxSizeMode.StretchImage
    '        PbxLogo.Load()
    '    End If

    '    txtTaxName.Text = GridCompProf.Item(14, i).Value
    '    txtTaxNo.Text = GridCompProf.Item(15, i).Value
    '    dtpTaxdt.Value = GridCompProf.Item(16, i).Value
    '    txtInvNotes.Text = GridCompProf.Item(17, i).Value
    '    If GridCompProf.Item(18, i).Value = False Then
    '        chkStorePrice.Checked = False
    '    Else
    '        chkStorePrice.Checked = True
    '    End If
    '    If GridCompProf.Item(19, i).Value = False Then
    '        chkProtectQty.Checked = False
    '    Else
    '        chkProtectQty.Checked = True
    '    End If
    '    If GridCompProf.Item(20, i).Value = False Then
    '        chkAutoJournal.Checked = False
    '    Else
    '        chkAutoJournal.Checked = True
    '    End If
    '    'chkStorePrice.Text = GridCompProf.Item(18, i).Value
    '    'chkProtectQty.Text = GridCompProf.Item(19, i).Value
    '    'chkAutoJournal.Text = GridCompProf.Item(20, i).Value
    '    txtEmail1.Text = GridCompProf.Item(21, i).Value
    '    txtEmail2.Text = GridCompProf.Item(22, i).Value
    '    If GridCompProf.Item(23, i).Value = False Then
    '        chkPurchase.Checked = False
    '    Else
    '        chkPurchase.Checked = True
    '    End If
    '    'chkPurchase.Text = GridCompProf.Item(23, i).Value
    '    txtQuot.Text = GridCompProf.Item(24, i).Value.ToString
    '    If GridCompProf.Item(25, i).Value.ToString = "Y" Then
    '        rbYes.Checked = True
    '    Else
    '        rbNo.Checked = True
    '    End If
    '    lv_click = "Y"

    'End Sub

    Private Sub txtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtMobile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobile.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPostCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPostCode.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtTaxNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxNo.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtQuot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuot.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

End Class