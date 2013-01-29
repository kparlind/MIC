Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmMasterQuestionSet

#Region "Variable Declaration"
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTrans As String
#End Region

#Region "Function & Procedure"

    Public Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = True
                btn_cancel.Enabled = True
            Case TransStatus.EditStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = True
                btn_cancel.Enabled = True
            Case TransStatus.FindStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = False
                btn_cancel.Enabled = True
            Case Else
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                btn_save.Enabled = False
                btn_cancel.Enabled = False
        End Select
    End Sub

    Public Sub GeneratePK()
        Dim dtTable As New DataTable
        Dim PK, lenPK, i As Integer

        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet_PK"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            Select Case dtTable.Rows.Count
                Case 0
                    txtSetID.Text = "QG001"
                Case Else
                    PK = dtTable.Rows(0).Item("Set_ID").ToString
                    PK += 1
                    txtSetID.Text = CStr(PK)
                    lenPK = Len(txtSetID.Text) + 1
                    For i = lenPK To 3
                        txtSetID.Text = "0" & txtSetID.Text
                    Next
                    txtSetID.Text = "QG" + txtSetID.Text

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub EnableDisableInput(ByVal boo As Boolean)
        txtSetID.Enabled = False
        dgViewSet.ReadOnly = True
        dgViewQuestion.ReadOnly = True
        cbCategory.Enabled = boo
        txtDescription.Enabled = boo
        cbTTLSection.Enabled = boo
    End Sub

    Public Sub InsertData()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Insert_Master_QuestionSet '" & txtSetID.Text & "', '" & txtDescription.Text.Trim & "', '" & cbCategory.SelectedItem.ToString & "', '" & _
                              cbTTLSection.SelectedItem.ToString & "', 'Y', '" & userlog.UserName & "', '" & userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            MsgBox("Data has been saved", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            If MessageBox.Show("Are you sure to save this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_QuestionSet '" & txtSetID.Text & "', '" & txtDescription.Text.Trim & "', '" & cbCategory.SelectedItem.ToString & "', '" & _
                                  cbTTLSection.SelectedItem.ToString & "', 'Y', '" & userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                MsgBox("Data has been updated", MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DeleteData()
        Try
            If MessageBox.Show("Are you sure to save this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_QuestionSet '" & txtSetID.Text & "', '" & txtDescription.Text.Trim & "', '" & cbCategory.SelectedItem.ToString & "', '" & _
                                  cbTTLSection.SelectedItem.ToString & "', 'N', '" & userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                If conn.State = ConnectionState.Open Then conn.Close()

                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_QuestionSection_BySetID '" & _
                                    txtSetID.Text & "', 'N', '" & userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                If conn.State = ConnectionState.Open Then conn.Close()

                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_Question_BySetID '" & _
                                    txtSetID.Text & "', 'N', '" & userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()



                MsgBox("Data has been delete", MsgBoxStyle.Information, "Information")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function ValidationInput() As Boolean
        ValidationInput = True
        If txtDescription.Text.Trim = "" Then
            txtDescription.Focus()
            ValidationInput = False
            Exit Function
        End If

        If cbTTLSection.SelectedItem = Nothing Then
            cbTTLSection.Focus()
            ValidationInput = False
            Exit Function
        End If

        If cbCategory.SelectedItem = Nothing Then
            cbCategory.Focus()
            ValidationInput = False
            Exit Function
        End If
    End Function

    Public Sub RetrieveDataGrid()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Master_QuestionSection '" & txtSetID.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgViewSet.DataSource = dtTable
            dgViewSet.Columns(1).Width = 300
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub RetrieveDataGridQuestion()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Master_Question_BySetID '" & txtSetID.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgViewQuestion.DataSource = dtTable
            dgViewQuestion.Columns(2).Width = 300
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmMasterQuestionSet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If ValidationInput() = False Then
                MsgBox("Please fill data completely!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            Select Case StatusTrans
                Case TransStatus.NewStatus
                    Call InsertData()
                Case TransStatus.EditStatus
                    Call UpdateData()
            End Select

            StatusTrans = TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            Call SetToolTip()
            Call EnableDisableInput(True)
        End If
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            Call DeleteData()
        End If
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            StatusTrans = GlobalVar.TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub frmMasterQuestionSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim frmChild As New frmMasterQuestionView
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestionView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
    End Sub

    Private Sub dgViewSet_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewSet.CellDoubleClick
        If dgViewSet.CurrentRow.DataGridView(0, dgViewSet.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        Dim frmChild As New frmMasterQuestionSection

        frmChild.MdiParent = MDIFrm
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.txtSetID.Text = txtSetID.Text
        frmChild.txtSectionID.Text = dgViewSet.CurrentRow.DataGridView(0, dgViewSet.CurrentRow.Index).Value
        frmChild.txtDescription.Text = dgViewSet.CurrentRow.DataGridView(1, dgViewSet.CurrentRow.Index).Value
        frmChild.cbTTLQuest.SelectedItem = dgViewSet.CurrentRow.DataGridView(2, dgViewSet.CurrentRow.Index).Value.ToString
        StatusTrans = TransStatus.NoStatus
        frmChild.SetToolTip()
        frmChild.EnableDisableInput(False)
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub btn_newsection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newsection.Click
        Dim frmChild As New frmMasterQuestionSection
        Dim dtTable As New DataTable

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSection '" & txtSetID.Text & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)
        conn.Close()

        If dtTable.Rows.Count >= CInt(cbTTLSection.SelectedItem.ToString) Then
            MsgBox("Can't add new SECTION", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestionSection" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.cmd.Connection = conn
        frmChild.txtSetID.Text = txtSetID.Text
        frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.GeneratePK()
        frmChild.EnableDisableInput(True)
        frmChild.SetToolTip()
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub btn_newquestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newquestion.Click
        If dgViewSet.CurrentRow.DataGridView(0, dgViewSet.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        Dim frmChild As New frmMasterQuestion
        Dim dtTable As New DataTable


        If conn.State = ConnectionState.Open Then conn.Close()
        dtTable.Clear()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & txtSetID.Text & "', '" & dgViewSet.CurrentRow.DataGridView(0, dgViewSet.CurrentRow.Index).Value.ToString & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)
        conn.Close()

        If dtTable.Rows.Count >= CInt(cbTTLSection.SelectedItem.ToString) Then
            MsgBox("Can't add new QUESTION", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestionSection" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestion" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.FormName = "frmMasterQuestionSet"
        frmChild.txtSetID.Text = txtSetID.Text
        frmChild.txtSectionID.Text = dgViewSet.CurrentRow.DataGridView(0, dgViewSet.CurrentRow.Index).Value.ToString.Trim
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.cmd.Connection = conn
        frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.GeneratePK()
        frmChild.EnableDisableInput(True)
        frmChild.SetToolTip()
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub dgViewQuestion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgViewQuestion.CellDoubleClick

        If dgViewQuestion.CurrentRow.DataGridView(0, dgViewQuestion.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        Dim frmChild As New frmMasterQuestion

        frmChild.FormName = "frmMasterQuestionSet"
        frmChild.MdiParent = MDIFrm
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.txtSetID.Text = txtSetID.Text
        frmChild.txtSectionID.Text = dgViewQuestion.CurrentRow.DataGridView(0, dgViewQuestion.CurrentRow.Index).Value
        frmChild.txtQuestID.Text = dgViewQuestion.CurrentRow.DataGridView(1, dgViewQuestion.CurrentRow.Index).Value
        frmChild.txtQuestion.Text = dgViewQuestion.CurrentRow.DataGridView(2, dgViewQuestion.CurrentRow.Index).Value
        StatusTrans = TransStatus.NoStatus
        frmChild.SetToolTip()
        frmChild.EnableDisableInput(False)
        frmChild.Show()
        Me.Hide()
    End Sub

#End Region

End Class