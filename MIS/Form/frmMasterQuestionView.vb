Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmMasterQuestionView

#Region "Variable Declaration"
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim StatusTrans As String
#End Region

#Region "Function & Procedure"

    Sub RetrieveQuestionSet()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
            dgView.Columns(2).Width = 500
            dgView.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveQuestionSetByKey()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet_ByKey '" & cbCategory.SelectedItem.ToString & "', '" & txtKeyword.Text.Trim & "', '" & txtKeyword.Text.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmMasterQuestionView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Call RetrieveQuestionSet()
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim frmChild As New frmMasterQuestionSet
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestionSet" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.MdiParent = MDIFrm
        frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.EnableDisableInput(True)
        frmChild.GeneratePK()
        frmChild.GroupBox2.Enabled = False
        frmChild.GroupBox3.Enabled = False
        frmChild.txtSetID.Enabled = False
        frmChild.SetToolTip()
        frmChild.RetrieveDataGrid()
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgView.DoubleClick
        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        Dim frmChild As New frmMasterQuestionSet
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.MdiParent = MDIFrm
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.txtSetID.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value
        frmChild.cbCategory.SelectedItem = dgView.CurrentRow.DataGridView(1, dgView.CurrentRow.Index).Value
        frmChild.txtDescription.Text = dgView.CurrentRow.DataGridView(2, dgView.CurrentRow.Index).Value
        frmChild.cbTTLSection.SelectedItem = dgView.CurrentRow.DataGridView(3, dgView.CurrentRow.Index).Value.ToString
        StatusTrans = TransStatus.NoStatus
        frmChild.SetToolTip()
        frmChild.EnableDisableInput(False)
        frmChild.RetrieveDataGrid()
        frmChild.RetrieveDataGridQuestion()
        frmChild.Show()
        Me.Close()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cbCategory.SelectedItem = Nothing Then
            MsgBox("Please select Category", MsgBoxStyle.Information, "Information")
            cbCategory.Focus()
            Exit Sub
        End If

        If txtKeyword.Text.Trim = "" Then
            MsgBox("Please fill Keyword", MsgBoxStyle.Information, "Information")
            txtKeyword.Focus()
            Exit Sub
        End If

        Call RetrieveQuestionSetByKey()
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Call RetrieveQuestionSet()
    End Sub

#End Region
   
End Class