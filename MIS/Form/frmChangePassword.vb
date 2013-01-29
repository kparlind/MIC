Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmChangePassword
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_Login As New DataTable    
    Dim PrintQty As Integer
    Dim id_login As String
    Dim StatusID As String

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        If txt_oldpass.Text.Trim = "" Then
            MessageBox.Show("Please input your Old Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_oldpass.Focus()
            Exit Sub
        End If

        If txt_newpass.Text.Trim = "" Then
            MessageBox.Show("Please input your New Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_oldpass.Focus()
            Exit Sub
        End If

        If txt_confirmPass.Text.Trim = "" Then
            MessageBox.Show("Please input your Confirm Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_oldpass.Focus()
            Exit Sub
        End If

        If txt_newpass.Text.Trim <> txt_confirmPass.Text.Trim Then
            MessageBox.Show("New password was not similiar with Confirm password. Please check again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_newpass.Focus()
            Exit Sub
        End If

        dt_Login.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_CheckLogin '" & userlog.UserName & "','" & txt_oldpass.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_Login)

        If dt_Login.Rows.Count = 0 Then
            MessageBox.Show("Old password is invalid. Please check again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt_oldpass.Focus()
            Exit Sub
        End If

        Try
            Cmd.CommandText = "EXEC sp_Update_Trans_ChangePassword '" & userlog.UserName & "','" & txt_newpass.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            MessageBox.Show("Password has been changes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Process Change password error." & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub
End Class