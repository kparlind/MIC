Imports System.Windows.Forms
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class Dlg_SearchCustomer
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dlg_SearchCustomer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetDataCustomer()
    End Sub

    Private Sub GetDataCustomer()
        Try
            Conn.Open()
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            'Cmd.CommandText = "EXEC GetSOHeader '" & SONo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
        Catch ex As Exception

        End Try
    End Sub
End Class
