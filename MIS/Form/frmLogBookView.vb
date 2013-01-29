Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmLogBookView

#Region "Variable Declaration"
    Public conn As New SqlConnection
    Public DA As New SqlDataAdapter
    Public cmd As New SqlCommand
    Public dt As New DataTable
    Public StatusTrans As String
#End Region

#Region "Function & Procedure"

    Sub RetrieveTransLogBook()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_LogBook"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable

            dgView.Columns("Labor Price").Visible = False
            dgView.Columns("Overhead Price").Visible = False
            dgView.Columns("Process Cost").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub RetrieveTransLogBookByKey()
        Dim dtTable As New DataTable

        If cbCategory.SelectedItem = Nothing Then
            MsgBox("Please Select Category", MsgBoxStyle.Information, "Information")
            cbCategory.Focus()
            Exit Sub
        End If

        If (cbCategory.SelectedItem.ToString = "By Log Date" Or _
            cbCategory.SelectedItem.ToString = "By Start Time" Or _
            cbCategory.SelectedItem.ToString = "By End Time") Then
        Else
            If txtKeyword.Text.Trim = "" Then
                MsgBox("Please Fill Keyword", MsgBoxStyle.Information, "Information")
                txtKeyword.Focus()
                Exit Sub
            End If
        End If

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_LogBook_ByKey '" & cbCategory.SelectedItem.ToString & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              Format(dtpDateFrom.Value, "MM-dd-yyyy") & "', '" & _
                              Format(dtpDateTo.Value, "MM-dd-yyyy") & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()
            dgView.DataSource = dtTable
            dgView.Columns("Labor Price").Visible = False
            dgView.Columns("Overhead Price").Visible = False
            dgView.Columns("Process Cost").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmLogBookView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgView.ReadOnly = True
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cbCategory.SelectedIndex = 0
        Call RetrieveTransLogBook()
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Call RetrieveTransLogBook()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call RetrieveTransLogBookByKey()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmChild As New frmLogBook
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormLogBook" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub

        Dim frmChild As New frmLogBook
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormLogBook" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.txtLogNo.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

#End Region

End Class