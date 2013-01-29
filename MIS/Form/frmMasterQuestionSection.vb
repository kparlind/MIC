Imports System.Data.SqlClient
Imports MIS.GlobalVar
Imports MIS.mdlCommon

<System.Serializable()> Public Class frmMasterQuestionSection

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
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSection_PK '" & txtSetID.Text & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            Select Case dtTable.Rows.Count
                Case 0
                    txtSectionID.Text = "QT001"
                Case Else
                    PK = dtTable.Rows(0).Item("Section_ID").ToString
                    PK += 1
                    txtSectionID.Text = CStr(PK)
                    lenPK = Len(txtSectionID.Text) + 1
                    For i = lenPK To 3
                        txtSectionID.Text = "0" & txtSectionID.Text
                    Next
                    txtSectionID.Text = "QT" + txtSectionID.Text
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub EnableDisableInput(ByVal boo As Boolean)
        txtSetID.Enabled = False
        txtSectionID.Enabled = False
        txtDescription.Enabled = boo
        cbTTLQuest.Enabled = boo
    End Sub

    Sub InsertData()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Insert_Master_QuestionSection '" & _
                                txtSetID.Text & "', '" & _
                                txtSectionID.Text & "', '" & _
                                txtDescription.Text & "', '" & _
                                cbTTLQuest.SelectedItem.ToString & "', 'Y', '" & userlog.UserName & "', '" & _
                                userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("Data has been saved", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub UpdateData()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Update_Master_QuestionSection '" & _
                                txtSetID.Text & "', '" & _
                                txtSectionID.Text & "', '" & _
                                txtDescription.Text & "', '" & _
                                cbTTLQuest.SelectedItem.ToString & "', 'Y', '" & userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Data has been updated", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteData()
        Try

            If MessageBox.Show("Are you sure to save this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_QuestionSection '" & _
                                    txtSetID.Text & "', '" & _
                                    txtSectionID.Text & "', '', '', 'N', '" & userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Master_Question_BySectionID '" & _
                                    txtSetID.Text & "', '" & _
                                    txtSectionID.Text & "', 'N', '" & userlog.UserName & "'"
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

        If cbTTLQuest.SelectedItem = Nothing Then
            cbTTLQuest.Focus()
            ValidationInput = False
            Exit Function
        End If
    End Function

#End Region

#Region "Event Handler"

    Private Sub frmMasterQuestionSection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
    End Sub

    Private Sub frmMasterQuestionSection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim frmChild As New frmMasterQuestionSet
        Dim dtTable As New DataTable

        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestionSet" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet_ByKey 'By Set ID', '" & txtSetID.Text.Trim & "', '" & txtSetID.Text.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count > 0 Then
                StatusTrans = GlobalVar.TransStatus.NoStatus
                frmChild.MdiParent = MDIFrm
                frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
                frmChild.conn.ConnectionString = ConnectStr
                frmChild.cmd.Connection = conn
                frmChild.cmd.CommandType = CommandType.Text
                frmChild.txtSetID.Text = dtTable.Rows(0).Item(0).ToString
                frmChild.cbCategory.SelectedItem = dtTable.Rows(0).Item(1).ToString
                frmChild.txtDescription.Text = dtTable.Rows(0).Item(2).ToString
                frmChild.cbTTLSection.SelectedItem = dtTable.Rows(0).Item(3).ToString
                frmChild.EnableDisableInput(False)
                frmChild.SetToolTip()
                frmChild.RetrieveDataGrid()
                frmChild.RetrieveDataGridQuestion()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
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

    Private Sub btn_newquestion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New frmMasterQuestion
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormMasterQuestion" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.FormName = "frmMasterQuestionSection"
        frmChild.MdiParent = MDIFrm
        frmChild.txtSetID.Text = txtSetID.Text
        frmChild.txtSectionID.Text = txtSectionID.Text
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

#End Region

End Class