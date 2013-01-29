Imports System.Data.SqlClient
Imports MIS.GlobalVar

Public Class Frm_MasterCust
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Private Sub Frm_MasterCust_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid("Cust_ID", txtNoCust.Text.Trim)
        loadCbsearch()
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        'txtNoCust.Enabled = Flag
        txtNama.Enabled = Flag
        txtAlamat.Enabled = Flag
        txtDeskripsi.Enabled = Flag
        txtNoTelp.Enabled = Flag
        txtContactPerson.Enabled = Flag
        txtJabatan.Enabled = Flag
        txtZona.Enabled = Flag
        'txtGroupCorporate.Enabled = Flag
        txtStatusCustomer.Enabled = Flag
        txtNamaOperator.Enabled = Flag
        txtSpecialRequest.Enabled = Flag
        txtKontrakNo.Enabled = Flag
        txtReferensi.Enabled = Flag
        txtEmail.Enabled = Flag
        rbGCYes.Enabled = Flag
        rbGCNo.Enabled = Flag
        txtNPWP.Enabled = Flag
        txtCustGrp.Enabled = Flag
        cbxCustGrpPrc.Enabled = Flag
        rbBillYes.Enabled = Flag
        rbBillNo.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        cbxPayment.Enabled = Flag
        cbxCaraBayar.Enabled = Flag
        cbxPaymentDay.Enabled = Flag
        txtAlamatPenagihan.Enabled = Flag
        txtTOP.Enabled = Flag
        txtPenanggungJawab.Enabled = Flag
        txtPNama.Enabled = Flag
        txtPTelp.Enabled = Flag
        txtPEmail.Enabled = Flag
        txtENama.Enabled = Flag
        txtETelp.Enabled = Flag
        txtEEmail.Enabled = Flag
    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Customer'"

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim LastSerial As Integer
        'userlog.UserName = "hhadiant"
        Dim lv_grpcorp As String = ""
        Dim lv_billing As String = ""
        Dim lv_active As String = ""

        Dim Expression As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S+")
        'Validation
        If txtEmail.Text <> String.Empty Then
            If Expression.IsMatch(txtEmail.Text) = False Then
                MessageBox.Show("The email address is NOT valid.", "Invalid Mail", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmail.Focus()
                Exit Sub
            End If
        End If
        'If txtPEmail.Text <> String.Empty Then
        '    If Expression.IsMatch(txtPEmail.Text) = False Then
        '        MessageBox.Show("The email address is NOT valid.", "Invalid Mail", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtPEmail.Focus()
        '        Exit Sub
        '    End If
        'End If
        'If txtEEmail.Text <> String.Empty Then
        '    If Expression.IsMatch(txtEEmail.Text) = False Then
        '        MessageBox.Show("The email address is NOT valid.", "Invalid Mail", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        txtEEmail.Focus()
        '        Exit Sub
        '    End If
        'End If
        If txtNama.Text = "" Or txtNama.Text = String.Empty Then
            MessageBox.Show("Name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAlamat.Text = "" Or txtAlamat.Text = String.Empty Then
            MessageBox.Show("Alamat Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtDeskripsi.Text = "" Or txtDeskripsi.Text = String.Empty Then
        '    MessageBox.Show("Description Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtNoTelp.Text = "" Or txtNoTelp.Text = String.Empty Then
        '    MessageBox.Show("No Telp Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtContactPerson.Text = "" Or txtContactPerson.Text = String.Empty Then
        '    MessageBox.Show("Contact Person Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtJabatan.Text = "" Or txtJabatan.Text = String.Empty Then
        '    MessageBox.Show("Jabatan Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtZona.Text = "" Or txtZona.Text = String.Empty Then
        '    MessageBox.Show("Zona Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtStatusCustomer.Text = "" Or txtStatusCustomer.Text = String.Empty Then
        '    MessageBox.Show("Status Customer Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtNamaOperator.Text = "" Or txtNamaOperator.Text = String.Empty Then
        '    MessageBox.Show("Nama Operator Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtSpecialRequest.Text = "" Or txtSpecialRequest.Text = String.Empty Then
        '    MessageBox.Show("Special Request Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtKontrakNo.Text = "" Or txtKontrakNo.Text = String.Empty Then
        '    MessageBox.Show("Contract No Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtReferensi.Text = "" Or txtReferensi.Text = String.Empty Then
        '    MessageBox.Show("Referensi Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtEmail.Text = "" Or txtEmail.Text = String.Empty Then
        '    MessageBox.Show("Email Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If txtNPWP.Text = "" Or txtNPWP.Text = String.Empty Then
        '    MessageBox.Show("NPWP Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If cbxCustGrpPrc.SelectedItem = "" Or cbxCustGrpPrc.SelectedItem = String.Empty Then
            MessageBox.Show("Cust Group Price Can not be Empty, Please choose one !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbxPayment.SelectedItem = "" Or cbxPayment.SelectedItem = String.Empty Then
            MessageBox.Show("Payment Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbxCaraBayar.SelectedItem = "" Or cbxCaraBayar.SelectedItem = String.Empty Then
            MessageBox.Show("Payment Method Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbxPaymentDay.Text = "" Or cbxPaymentDay.Text = String.Empty Then
            MessageBox.Show("Payment Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtAlamatPenagihan.Text = "" Or txtAlamatPenagihan.Text = String.Empty Then
        '    MessageBox.Show("Alamat Penagihan Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        If txtTOP.Text = "" Or txtTOP.Text = String.Empty Then
            MessageBox.Show("TOP Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'If txtPenanggungJawab.Text = "" Or txtPenanggungJawab.Text = String.Empty Then
        '    MessageBox.Show("Penanggung Jawab Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If


        If rbGCYes.Checked = True Then
            lv_grpcorp = "Y"
        Else
            lv_grpcorp = "N"
            If txtCustGrp.Text.Trim = "" Or txtCustGrp.Text.Trim = String.Empty Then
                MessageBox.Show("Cust Group must filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If rbBillYes.Checked = True Then
            lv_billing = "Y"
        Else
            lv_billing = "N"
        End If
        If rbYes.Checked = True Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If

        If txtNoCust.Text.Trim <> String.Empty Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If


                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_Customer '" & txtNoCust.Text.Trim & "', '" & txtNama.Text.Trim & "', '" _
                            & txtAlamat.Text.Trim & "', '" & txtDeskripsi.Text.Trim & "', '" & txtNoTelp.Text.Trim & "', '" _
                            & txtContactPerson.Text.Trim & "', '" & txtJabatan.Text.Trim & "', '" & txtZona.Text.Trim & "', '" _
                            & lv_grpcorp & "', '" & txtStatusCustomer.Text.Trim & "', '" & txtNamaOperator.Text.Trim & "', '" _
                            & txtSpecialRequest.Text.Trim & "', '" & txtKontrakNo.Text.Trim & "', '" & txtReferensi.Text.Trim & "', '" _
                            & txtEmail.Text.Trim & "', '" & txtNPWP.Text.Trim & "', '" & txtCustGrp.Text.Trim & "','" & cbxCustGrpPrc.SelectedItem.Trim & "', '" & lv_billing & "', '" & cbxPayment.Text.Trim & "', '" & cbxCaraBayar.Text.Trim & "', '" _
                            & cbxPaymentDay.SelectedItem.Trim & "', '" & txtAlamatPenagihan.Text.Trim & "', '" _
                            & txtTOP.Text.Trim & "', '" & txtPenanggungJawab.Text.Trim & "', '" _
                            & txtPNama.Text.Trim & "', '" & txtPTelp.Text.Trim & "', '" _
                            & txtPEmail.Text.Trim & "', '" & txtENama.Text.Trim & "', '" _
                            & txtETelp.Text.Trim & "', '" & txtEEmail.Text.Trim & "', '" & userlog.UserName & "' , '" & lv_active & "' "

                Cmd.ExecuteNonQuery()

                Insert_Trans_History(txtNoCust.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
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

                txtNoCust.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoCust.Text, 3))

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Customer '" & txtNoCust.Text.Trim & "', '" & txtNama.Text.Trim & "', '" _
                            & txtAlamat.Text.Trim & "', '" & txtDeskripsi.Text.Trim & "', '" & txtNoTelp.Text.Trim & "', '" _
                            & txtContactPerson.Text.Trim & "', '" & txtJabatan.Text.Trim & "', '" & txtZona.Text.Trim & "', '" _
                            & lv_grpcorp & "', '" & txtStatusCustomer.Text.Trim & "', '" & txtNamaOperator.Text.Trim & "', '" _
                            & txtSpecialRequest.Text.Trim & "', '" & txtKontrakNo.Text.Trim & "', '" & txtReferensi.Text.Trim & "', '" _
                            & txtEmail.Text.Trim & "', '" & txtNPWP.Text.Trim & "', '" & txtCustGrp.Text.Trim & "','" & cbxCustGrpPrc.SelectedItem.Trim & "', '" & lv_billing & "', '" & cbxPayment.Text.Trim & "', '" & cbxCaraBayar.Text.Trim & "', '" _
                            & cbxPaymentDay.SelectedItem.Trim & "', '" & txtAlamatPenagihan.Text.Trim & "', '" _
                            & txtTOP.Text.Trim & "', '" & txtPenanggungJawab.Text.Trim & "', '" _
                            & txtPNama.Text.Trim & "', '" & txtPTelp.Text.Trim & "', '" _
                            & txtPEmail.Text.Trim & "', '" & txtENama.Text.Trim & "', '" _
                            & txtETelp.Text.Trim & "', '" & txtEEmail.Text.Trim & "',  '" & lv_active & "', '" & userlog.UserName & "' "

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtNoCust.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridCust.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid("Cust_ID", txtNoCust.Text.Trim)
    End Sub
    Private Sub InitField()
        txtNoCust.Text = String.Empty
        txtNama.Text = String.Empty
        txtAlamat.Text = String.Empty
        txtDeskripsi.Text = String.Empty
        txtNoTelp.Text = String.Empty
        txtContactPerson.Text = String.Empty
        txtJabatan.Text = String.Empty
        txtZona.Text = String.Empty

        txtStatusCustomer.Text = String.Empty
        txtNamaOperator.Text = String.Empty
        txtSpecialRequest.Text = String.Empty
        txtKontrakNo.Text = String.Empty
        txtReferensi.Text = String.Empty
        txtEmail.Text = String.Empty

        cbxPayment.Text = String.Empty
        cbxCaraBayar.Text = String.Empty
        cbxPaymentDay.Text = String.Empty
        txtAlamatPenagihan.Text = String.Empty
        txtTOP.Text = String.Empty
        txtPenanggungJawab.Text = String.Empty
        txtPNama.Text = String.Empty
        txtPTelp.Text = String.Empty
        txtPEmail.Text = String.Empty
        txtENama.Text = String.Empty
        txtETelp.Text = String.Empty
        txtEEmail.Text = String.Empty
        'If lv_click <> "Y" Then
        '    GridCust.DataSource = Nothing
        'End If
        rbGCYes.Checked = True
        rbBillYes.Checked = True
        rbYes.Checked = True
        txtCustGrp.Text = String.Empty
        cbxCustGrpPrc.Text = String.Empty
        txtNPWP.Text = String.Empty
        lblCustGrpName.Text = ""

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

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtNoCust.Text.Trim = "" Then
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
        txtCustGrp.Enabled = False
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
        LoadGrid("Cust_ID", txtNoCust.Text.Trim)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtNoCust.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNoCust.Text.Trim <> String.Empty Then
            Try
                Conn.ConnectionString = ConnectStr
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Customer '" & txtNoCust.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridCust.DataSource = Nothing
        LoadGrid("Cust_ID", txtNoCust.Text.Trim)
        SetToolTip()
        InitField()
    End Sub

    Private Sub LoadGrid(ByVal Field As String, ByVal keyword As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Customer_list  '" & Field & "','" & keyword & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridCust.DataSource = dtTemp

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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Customer'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            'GridCust.DataSource = dtTemp
            If dtTemp.Rows.Count > 0 Then
                LoadGrid(cb_searchBaseon.SelectedValue.ToString, txt_SearchData.Text.ToString)
            Else
                MessageBox.Show("Data not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub GridCust_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridCust.CellDoubleClick
        Dim i As Integer
        Dim dt_item As New DataTable
        i = GridCust.CurrentRow.Index
        txtNoCust.Text = GridCust.Item(0, i).Value
        txtNama.Text = GridCust.Item(1, i).Value
        txtAlamat.Text = GridCust.Item(2, i).Value
        txtDeskripsi.Text = GridCust.Item(3, i).Value
        txtNoTelp.Text = GridCust.Item(4, i).Value
        txtContactPerson.Text = GridCust.Item(5, i).Value
        txtJabatan.Text = GridCust.Item(6, i).Value
        txtZona.Text = GridCust.Item(7, i).Value
        If GridCust.Item(8, i).Value = "Y" Then
            rbGCYes.Checked = True
        Else
            rbGCNo.Checked = True
        End If
        txtStatusCustomer.Text = GridCust.Item(9, i).Value
        txtNamaOperator.Text = GridCust.Item(10, i).Value
        txtSpecialRequest.Text = GridCust.Item(11, i).Value
        txtKontrakNo.Text = GridCust.Item(12, i).Value
        txtReferensi.Text = GridCust.Item(13, i).Value
        txtEmail.Text = GridCust.Item(14, i).Value
        'New
        txtNPWP.Text = GridCust.Item(15, i).Value
        txtCustGrp.Text = GridCust.Item(16, i).Value
        If txtCustGrp.Text.Trim <> "" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey '" & txtCustGrp.Text & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_item)

                If dt_item.Rows.Count > 0 Then
                    lblCustGrpName.Text = dt_item.Rows(0).Item("Nama").ToString

                End If
                Conn.Close()
            Catch ex As Exception
                Conn.Close()
            End Try
        End If
        cbxCustGrpPrc.SelectedItem = GridCust.Item(17, i).Value.ToString.Trim
        If GridCust.Item(18, i).Value = "Y" Then
            rbBillYes.Checked = True
        Else
            rbBillNo.Checked = True
        End If

        cbxPayment.Text = GridCust.Item(19, i).Value
        cbxCaraBayar.Text = GridCust.Item(20, i).Value
        cbxPaymentDay.SelectedItem = GridCust.Item(21, i).Value
        txtAlamatPenagihan.Text = GridCust.Item(22, i).Value
        txtTOP.Text = GridCust.Item(23, i).Value
        txtPenanggungJawab.Text = GridCust.Item(24, i).Value
        txtPNama.Text = GridCust.Item(25, i).Value
        txtPTelp.Text = GridCust.Item(26, i).Value
        txtPEmail.Text = GridCust.Item(27, i).Value
        txtENama.Text = GridCust.Item(28, i).Value
        txtETelp.Text = GridCust.Item(29, i).Value
        txtEEmail.Text = GridCust.Item(30, i).Value

        If GridCust.Item(31, i).Value = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = False
        End If
        'lv_click = "Y"
    End Sub

    Private Sub txtCustGrp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustGrp.KeyDown
        Dim dt_item As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Cust_ID,Nama,Deskripsi,Alamat,Telp from Master_Customer where Active_Flag = 'Y' and Group_Corporate = 'Y' ", "Cust_ID", "Nama", "Deskripsi", "Alamat", "Telp")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txtCustGrp.Text = frmSearch.txtResult1.Text.ToString.Trim
                    lblCustGrpName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    cbxCustGrpPrc.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Conn.Close()
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtCustGrp.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey '" & txtCustGrp.Text & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_item)

                    If dt_item.Rows.Count > 0 Then
                        txtCustGrp.Text = dt_item.Rows(0).Item("Cust_ID").ToString
                        lblCustGrpName.Text = dt_item.Rows(0).Item("Nama").ToString
                        cbxCustGrpPrc.Focus()
                    Else
                        MessageBox.Show("Cust Group not found. Please check again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Conn.Close()
                    Exit Sub
                End Try
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub txtNoTelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoTelp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtNPWP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNPWP.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPTelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPTelp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtETelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtETelp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub rbGCYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbGCYes.Click
        txtCustGrp.Text = ""
        txtCustGrp.Enabled = False
    End Sub

    Private Sub rbGCNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbGCNo.Click
        txtCustGrp.Enabled = True
    End Sub

    Private Sub txtTOP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTOP.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class