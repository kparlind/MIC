Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class FrmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable


    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim File_Name As String = "C:\MIC\Global.txt"
            Dim File_Name As String = Application.StartupPath & "\Global.txt"
            Dim Obj As New System.IO.StreamReader(File_Name)
            ConnectStr = Obj.ReadToEnd
            Obj.Close()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
            Me.Close()
        End Try

        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        'Clear input field
        txt_Username.Clear()
        txt_Password.Clear()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Validate Input
        If txt_Username.Text.Trim = "" Then
            MsgBox("Username kosong. Masukan Username dan Password untuk melakukan proses Login")
            Exit Sub
        End If
        If txt_Password.Text.Trim = "" Then
            MsgBox("Password kosong. Masukan Username dan Password untuk melakukan proses Login")
            Exit Sub
        End If
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()
            Cmd.CommandText = "EXEC sp_CheckLogin '" & txt_Username.Text.Trim & "','" & _
                              txt_Password.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            Conn.Close()

            If dt.Rows.Count = 0 Then
                MsgBox("Proses Login Gagal. Pastikan anda memasukan Username dan Password yang benar")
                Exit Sub
            Else
                If dt.Rows(0).Item("active_flag") = "N" Then
                    MsgBox("Proses Login Gagal. Username ini sudah tidak aktif lagi.")
                    Exit Sub
                End If

                'Retreive profile user Login to Object "UserLogin"

                With userlog
                    .UserName = dt.Rows(0).Item("UserName").ToString.Trim
                    .EmployeeID = dt.Rows(0).Item("Employee_ID").ToString.Trim
                    .EmployeeName = dt.Rows(0).Item("Name").ToString.Trim
                    .AccessID = dt.Rows(0).Item("Access_ID").ToString.Trim
                    .Address1 = dt.Rows(0).Item("Address1").ToString.Trim
                    .Address2 = dt.Rows(0).Item("Address2").ToString.Trim
                    .Phone1 = dt.Rows(0).Item("Phone1").ToString.Trim
                    .Phone2 = dt.Rows(0).Item("Phone2").ToString.Trim
                    .Mobile = dt.Rows(0).Item("mobile").ToString.Trim
                    .Sex = dt.Rows(0).Item("sex").ToString.Trim
                    .IsUser = dt.Rows(0).Item("IsUser")
                    .HireDate = dt.Rows(0).Item("HireDate")
                    .Active_Flag = dt.Rows(0).Item("Active_Flag")
                    .Show_Supplier = dt.Rows(0).Item("Show_Supplier")
                    .Insert_Price = dt.Rows(0).Item("Insert_Price")
                    .Access_Desc = dt.Rows(0).Item("Access_Desc")
                    .Department_ID = dt.Rows(0).Item("Department_ID")
                End With
            End If
            Me.Hide()
            'Dim oForm As MDIFrm
            'oForm = New MDIFrm
            'oForm.Show()
            MDIFrm.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
