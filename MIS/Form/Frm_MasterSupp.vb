Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterSupp
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String

    Private Sub Frm_MasterSupp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid("Supp_ID", txtNoSupp.Text.Trim)
        loadCbsearch()
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        'txtNoSupp.Enabled = Flag
        txtNama.Enabled = Flag
        txtContactPerson.Enabled = Flag
        txtAlamat.Enabled = Flag
        txtNoTelp.Enabled = Flag
        txtFax.Enabled = Flag
        txtEmail.Enabled = Flag
        txtWeb.Enabled = Flag
        txtPaymentTerm.Enabled = Flag
        txtCreditLimit.Enabled = Flag
        txtJenisBarang.Enabled = Flag
        txtLamaPengiriman.Enabled = Flag
        txtNPWP.Enabled = Flag
        txtAlias.Enabled = Flag
        txtNamaBank.Enabled = Flag
        txtNamaPemilikBank.Enabled = Flag
        txtNoAkunBank.Enabled = Flag
        rbYes.Enabled = Flag
        rbNo.Enabled = Flag
        rbActive.Enabled = Flag
        rbNotActive.Enabled = Flag

    End Sub
    Private Sub loadCbsearch()
        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retreive_FieldList 'Master_Supplier'"

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim LastSerial As Integer
        Dim lv_active As String = ""
        'Email validation
        Dim Expression As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S+")

        If txtEmail.Text <> String.Empty Then
            If Expression.IsMatch(txtEmail.Text) = False Then
                MessageBox.Show("The email address is NOT valid.", "Invalid Mail", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmail.Focus()
                Exit Sub
            End If
        End If
        'Validation
        If txtNama.Text = "" Or txtNama.Text = String.Empty Then
            MessageBox.Show("Name Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtContactPerson.Text = "" Or txtContactPerson.Text = String.Empty Then
            MessageBox.Show("Contact Person Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAlamat.Text = "" Or txtAlamat.Text = String.Empty Then
            MessageBox.Show("Alamat Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNoTelp.Text = "" Or txtNoTelp.Text = String.Empty Then
            MessageBox.Show("No Telp Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtFax.Text = "" Or txtFax.Text = String.Empty Then
            MessageBox.Show("Fax Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtWeb.Text = "" Or txtWeb.Text = String.Empty Then
            MessageBox.Show("Web Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtPaymentTerm.Text = "" Or txtPaymentTerm.Text = String.Empty Then
            MessageBox.Show("Payment Term Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtCreditLimit.Text = "" Or txtCreditLimit.Text = String.Empty Then
            MessageBox.Show("Credit limit Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtJenisBarang.Text = "" Or txtJenisBarang.Text = String.Empty Then
            MessageBox.Show("Jenis barang Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtLamaPengiriman.Text = "" Or txtLamaPengiriman.Text = String.Empty Then
            MessageBox.Show("Lama pengiriman Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNPWP.Text = "" Or txtNPWP.Text = String.Empty Then
            MessageBox.Show("NPWP Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtAlias.Text = "" Or txtAlias.Text = String.Empty Then
            MessageBox.Show("Alias Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNamaBank.Text = "" Or txtNamaBank.Text = String.Empty Then
            MessageBox.Show("Nama Bank Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNamaPemilikBank.Text = "" Or txtNamaPemilikBank.Text = String.Empty Then
            MessageBox.Show("Nama Pemilik Bank Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNoAkunBank.Text = "" Or txtNoAkunBank.Text = String.Empty Then
            MessageBox.Show("No Akun Bank Can not be Empty !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If rbYes.Checked = True Then
            lvRb = "Y"
        Else
            lvRb = "N"
        End If
        If rbActive.Checked = True Then
            lv_active = "Y"
        Else
            lv_active = "N"
        End If
        ' userlog.UserName = "hhadiant"
        If txtNoSupp.Text.Trim <> String.Empty Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text


                Cmd.CommandText = "exec sp_Update_Master_Supplier '" & txtNoSupp.Text.Trim & "', '" & txtNama.Text.Trim & "', '" _
                            & txtContactPerson.Text.Trim & "', '" & txtAlamat.Text.Trim & "', '" & txtNoTelp.Text.Trim & "', '" _
                            & txtFax.Text.Trim & "', '" & txtEmail.Text.Trim & "', '" & txtWeb.Text.Trim & "', '" _
                            & txtPaymentTerm.Text.Trim & "', '" & txtCreditLimit.Text.Trim & "', '" & txtJenisBarang.Text.Trim & "', '" _
                            & txtLamaPengiriman.Text.Trim & "', '" & txtNamaBank.Text.Trim & "', '" & txtNamaPemilikBank.Text.Trim & "', '" _
                            & txtNoAkunBank.Text.Trim & "', '" & lvRb & "', '" & txtNPWP.Text.Trim & "','" & txtAlias.Text.Trim & "', '" & lv_active & "', '" & userlog.UserName & "' "

                Cmd.ExecuteNonQuery()

                Insert_Trans_History(txtNoSupp.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

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

                txtNoSupp.Text = Generate_MasterNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtNoSupp.Text, 3))

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Supplier '" & txtNoSupp.Text.Trim & "', '" & txtNama.Text.Trim & "', '" _
                            & txtContactPerson.Text.Trim & "', '" & txtAlamat.Text.Trim & "', '" & txtNoTelp.Text.Trim & "', '" _
                            & txtFax.Text.Trim & "', '" & txtEmail.Text.Trim & "', '" & txtWeb.Text.Trim & "', '" _
                            & txtPaymentTerm.Text.Trim & "', '" & txtCreditLimit.Text.Trim & "', '" & txtJenisBarang.Text.Trim & "', '" _
                            & txtLamaPengiriman.Text.Trim & "', '" & txtNamaBank.Text.Trim & "', '" & txtNamaPemilikBank.Text.Trim & "', '" _
                            & txtNoAkunBank.Text.Trim & "', '" & lvRb & "', '" & txtNPWP.Text.Trim & "','" & txtAlias.Text.Trim & "', '" & lv_active & "', '" & userlog.UserName & "' "

                Cmd.ExecuteNonQuery()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtNoSupp.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GridSupp.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid("Supp_ID", txtNoSupp.Text.Trim)
    End Sub
    Private Sub InitField()
        txtNoSupp.Text = String.Empty
        txtNama.Text = String.Empty
        txtContactPerson.Text = String.Empty
        txtAlamat.Text = String.Empty
        txtNoTelp.Text = String.Empty
        txtFax.Text = String.Empty
        txtEmail.Text = String.Empty
        txtWeb.Text = String.Empty
        txtPaymentTerm.Text = String.Empty
        txtCreditLimit.Text = String.Empty
        txtJenisBarang.Text = String.Empty
        txtLamaPengiriman.Text = String.Empty
        txtNPWP.Text = String.Empty
        txtAlias.Text = String.Empty

        txtNamaBank.Text = String.Empty
        txtNamaPemilikBank.Text = String.Empty
        txtNoAkunBank.Text = String.Empty
        ' rbYes.Checked = True
        'If lv_click <> "Y" Then
        '    GridSupp.DataSource = Nothing
        'End If
        'rbActive.Checked = True

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
        If txtNoSupp.Text.Trim = "" Then
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
        txtNoSupp.Enabled = False
        InitField()
        'lv_click = ""
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
        LoadGrid("Supp_ID", txtNoSupp.Text.Trim)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtNoSupp.Text.Trim = "" Then
            MessageBox.Show("Please select one data to Delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txtNoSupp.Text.Trim <> String.Empty Then
            Try
                Conn.ConnectionString = ConnectStr
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Supplier '" & txtNoSupp.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                Conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridSupp.DataSource = Nothing
        btnCancel_Click(sender, e)
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
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Supplier  '" & Field & "','" & keyword & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridSupp.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub GridSupp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridSupp.CellDoubleClick
        Dim i As Integer
        i = GridSupp.CurrentRow.Index
        txtNoSupp.Text = GridSupp.Item(0, i).Value
        txtNama.Text = GridSupp.Item(1, i).Value
        txtContactPerson.Text = GridSupp.Item(2, i).Value
        txtAlamat.Text = GridSupp.Item(3, i).Value
        txtNoTelp.Text = GridSupp.Item(4, i).Value
        txtFax.Text = GridSupp.Item(5, i).Value
        txtEmail.Text = GridSupp.Item(6, i).Value
        txtWeb.Text = GridSupp.Item(7, i).Value
        txtPaymentTerm.Text = GridSupp.Item(8, i).Value
        txtCreditLimit.Text = GridSupp.Item(9, i).Value
        txtJenisBarang.Text = GridSupp.Item(10, i).Value
        txtLamaPengiriman.Text = GridSupp.Item(11, i).Value
        txtNamaBank.Text = GridSupp.Item(12, i).Value
        txtNamaPemilikBank.Text = GridSupp.Item(13, i).Value
        txtNoAkunBank.Text = GridSupp.Item(14, i).Value
        If GridSupp.Item(15, i).Value.ToString = "Y" Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
        txtNPWP.Text = GridSupp.Item(16, i).Value
        txtAlias.Text = GridSupp.Item(17, i).Value
        If GridSupp.Item(18, i).Value.ToString = "Y" Then
            rbActive.Checked = True
        Else
            rbNotActive.Checked = True
        End If
        'lv_click = "Y"
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
            Cmd.CommandText = "exec Search_Master_List '" & cb_searchBaseon.SelectedValue.ToString & "', '" & txt_SearchData.Text.ToString.Trim & "', 'Master_Supplier'"
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
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub txtNoTelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoTelp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCreditLimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCreditLimit.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtLamaPengiriman_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLamaPengiriman.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtNPWP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNPWP.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPaymentTerm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaymentTerm.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class