Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmQuestionnaireView

#Region "Variable Declaration"
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTRans As String
#End Region

#Region "Function & Procedure"

    Sub RetrieveDataGrid()
        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_Questionnaire"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
            dgView.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveCbQuestionSet()
        Dim dtTable As New DataTable
        cbQuestionSet.ResetText()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet_ForComboBox"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Sub

            cbQuestionSet.DataSource = dtTable
            cbQuestionSet.DisplayMember = "Set_Desc"
            cbQuestionSet.ValueMember = "Set_ID"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveQuestionnaireByKey()
        If cbCategory.SelectedItem.ToString = "By Questionnaire Date" Then
        Else
            If txtKeyword.Text.Trim = "" Then
                MsgBox("Please Fill Keyword", MsgBoxStyle.Information, "Information")
                txtKeyword.Focus()
                Exit Sub
            End If
        End If

        Dim dtTable As New DataTable
        dtTable.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_Questionnaire_ByKey '" & cbCategory.SelectedItem.ToString & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              Format(dtpDateFrom.Value, "MM-dd-yyyy") & "', '" & _
                              Format(dtpDateTo.Value, "MM-dd-yyyy") & "'"
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

    Private Sub frmQuestionnaireView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        SetAccess(Me, userlog.AccessID, Me.Name, btn_new)

        cbCategory.SelectedIndex = 0
        Call RetrieveDataGrid()
        Call RetrieveCbQuestionSet()

    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        If cbQuestionSet.Items.Count = 0 Then Exit Sub

        Dim dtQuestSection As New DataTable
        Dim dtQuestion As New DataTable
        Dim dtSet As New DataTable
        Dim Category As String

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSection '" & cbQuestionSet.SelectedValue.ToString.Trim & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtQuestSection)
        conn.Close()

        If dtQuestSection.Rows.Count = 0 Then Exit Sub
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSet_ByKey 'By Set ID', '" & cbQuestionSet.SelectedValue.ToString.Trim & "', ''"
        DA.SelectCommand = cmd
        DA.Fill(dtSet)
        conn.Close()

        Dim frmChild As New frmQuestionnaire
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormQuestionnaire" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        If dtQuestSection.Rows.Count <> 0 Then
            Category = dtSet.Rows(0).Item("Category").ToString.Trim
            Select Case Category
                Case "Supplier"
                    frmChild.Prefix = "SQ"
                    frmChild.cbCustomer.Enabled = False
                Case "Customer"
                    frmChild.Prefix = "CQ"
                    frmChild.cbSupplier.Enabled = False
                Case "Outsourcing"
                    frmChild.Prefix = "OQ"
            End Select
        End If
        frmChild.lblSection1.Visible = False
        frmChild.lblSection2.Visible = False
        frmChild.lblSection3.Visible = False
        frmChild.lblSection4.Visible = False
        frmChild.lblSection5.Visible = False

        frmChild.lblSection1.Visible = False
        frmChild.lblSection2.Visible = False
        frmChild.lblSection3.Visible = False
        frmChild.lblSection4.Visible = False
        frmChild.lblSection5.Visible = False

        frmChild.gbQuest1_1.Visible = False
        frmChild.gbQuest1_2.Visible = False
        frmChild.gbQuest1_3.Visible = False
        frmChild.gbQuest1_4.Visible = False
        frmChild.gbQuest1_5.Visible = False

        frmChild.gbQuest2_1.Visible = False
        frmChild.gbQuest2_2.Visible = False
        frmChild.gbQuest2_3.Visible = False
        frmChild.gbQuest2_4.Visible = False
        frmChild.gbQuest2_5.Visible = False

        frmChild.gbQuest3_1.Visible = False
        frmChild.gbQuest3_2.Visible = False
        frmChild.gbQuest3_3.Visible = False
        frmChild.gbQuest3_4.Visible = False
        frmChild.gbQuest3_5.Visible = False

        frmChild.gbQuest4_1.Visible = False
        frmChild.gbQuest4_2.Visible = False
        frmChild.gbQuest4_3.Visible = False
        frmChild.gbQuest4_4.Visible = False
        frmChild.gbQuest4_5.Visible = False

        frmChild.gbQuest5_1.Visible = False
        frmChild.gbQuest5_2.Visible = False
        frmChild.gbQuest5_3.Visible = False
        frmChild.gbQuest5_4.Visible = False
        frmChild.gbQuest5_5.Visible = False
        StatusTRans = GlobalVar.TransStatus.NewStatus
        frmChild.MdiParent = MDIFrm
        frmChild.StatusTRans = GlobalVar.TransStatus.NewStatus
        frmChild.conn.ConnectionString = ConnectStr
        frmChild.SetToolTip()
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.txtSetID.Text = cbQuestionSet.SelectedValue.ToString
        frmChild.RetrieveCbSupplier()
        frmChild.RetrieveCbCustomer()

        frmChild.EnableDisableInput(True)
        'frmChild.GeneratePK()

        frmChild.txtSetID.ReadOnly = True
        frmChild.txtQuestID.ReadOnly = True

        If dtQuestSection.Rows.Count >= 1 Then
            frmChild.lblSection1.Text = dtQuestSection.Rows(0).Item("Description").ToString.Trim
            frmChild.lblSection1.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & cbQuestionSet.SelectedValue.ToString.Trim & "', '" & dtQuestSection.Rows(0).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest1_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest1_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest1_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest1_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest1_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest1_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest1_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest1_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest1_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest1_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 2 Then
            frmChild.lblSection2.Text = dtQuestSection.Rows(1).Item("Description").ToString.Trim
            frmChild.lblSection2.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & cbQuestionSet.SelectedValue.ToString.Trim & "', '" & dtQuestSection.Rows(1).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest2_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest2_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest2_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest2_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest2_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest2_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest2_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest2_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest2_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest2_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 3 Then
            frmChild.lblSection3.Text = dtQuestSection.Rows(2).Item("Description").ToString.Trim
            frmChild.lblSection3.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & cbQuestionSet.SelectedValue.ToString.Trim & "', '" & dtQuestSection.Rows(2).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest3_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest3_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest3_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest3_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest3_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest3_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest3_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest3_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest3_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest3_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 4 Then
            frmChild.lblSection4.Text = dtQuestSection.Rows(3).Item("Description").ToString.Trim
            frmChild.lblSection4.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & cbQuestionSet.SelectedValue.ToString.Trim & "', '" & dtQuestSection.Rows(3).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest4_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest4_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest4_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest4_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest4_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest4_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest4_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest4_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest4_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest4_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 5 Then
            frmChild.lblSection5.Text = dtQuestSection.Rows(4).Item("Description").ToString.Trim
            frmChild.lblSection5.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & cbQuestionSet.SelectedValue.ToString.Trim & "', '" & dtQuestSection.Rows(4).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest5_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest5_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest5_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest5_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest5_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest5_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest5_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest5_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest5_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest5_5.Visible = True
            End If
        End If
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub

        Dim dtQuestSection As New DataTable
        Dim dtQuestion As New DataTable
        Dim dtQuestionnaire As New DataTable
        Dim frmChild As New frmQuestionnaire

        frmChild.lblSection1.Visible = False
        frmChild.lblSection2.Visible = False
        frmChild.lblSection3.Visible = False
        frmChild.lblSection4.Visible = False
        frmChild.lblSection5.Visible = False

        frmChild.gbQuest1_1.Visible = False
        frmChild.gbQuest1_2.Visible = False
        frmChild.gbQuest1_3.Visible = False
        frmChild.gbQuest1_4.Visible = False
        frmChild.gbQuest1_5.Visible = False

        frmChild.gbQuest2_1.Visible = False
        frmChild.gbQuest2_2.Visible = False
        frmChild.gbQuest2_3.Visible = False
        frmChild.gbQuest2_4.Visible = False
        frmChild.gbQuest2_5.Visible = False

        frmChild.gbQuest3_1.Visible = False
        frmChild.gbQuest3_2.Visible = False
        frmChild.gbQuest3_3.Visible = False
        frmChild.gbQuest3_4.Visible = False
        frmChild.gbQuest3_5.Visible = False

        frmChild.gbQuest4_1.Visible = False
        frmChild.gbQuest4_2.Visible = False
        frmChild.gbQuest4_3.Visible = False
        frmChild.gbQuest4_4.Visible = False
        frmChild.gbQuest4_5.Visible = False

        frmChild.gbQuest5_1.Visible = False
        frmChild.gbQuest5_2.Visible = False
        frmChild.gbQuest5_3.Visible = False
        frmChild.gbQuest5_4.Visible = False
        frmChild.gbQuest5_5.Visible = False

        frmChild.conn.ConnectionString = ConnectStr
        frmChild.MdiParent = MDIFrm
        frmChild.cmd.Connection = conn
        frmChild.cmd.CommandType = CommandType.Text
        frmChild.RetrieveCbSupplier()
        frmChild.RetrieveCbCustomer()

        If conn.State = ConnectionState.Open Then conn.Close()
        dtQuestionnaire.Clear()

        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Trans_Questionnaire_ByQuestID '" & dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtQuestionnaire)
        conn.Close()

        frmChild.txtQuestID.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value
        frmChild.txtSetID.Text = dtQuestionnaire.Rows(0).Item(1).ToString.Trim

        frmChild.cbCustomer.SelectedValue = dtQuestionnaire.Rows(0).Item(2).ToString
        frmChild.cbSupplier.SelectedValue = dtQuestionnaire.Rows(0).Item(3).ToString
        frmChild.txtProject1.Text = dtQuestionnaire.Rows(0).Item(4).ToString.Trim
        frmChild.txtProject2.Text = dtQuestionnaire.Rows(0).Item(5).ToString.Trim
        frmChild.txtProject3.Text = dtQuestionnaire.Rows(0).Item(6).ToString.Trim
        frmChild.txtRespondentName.Text = dtQuestionnaire.Rows(0).Item(7).ToString.Trim
        frmChild.txtJabatan.Text = dtQuestionnaire.Rows(0).Item(8).ToString.Trim
        frmChild.dtpQuest.Value = dtQuestionnaire.Rows(0).Item(9)


        If dtQuestionnaire.Rows(0).Item(10) = 1 Then
            frmChild.rbQuest1_1_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(10) = 2 Then
            frmChild.rbQuest1_1_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(10) = 3 Then
            frmChild.rbQuest1_1_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(10) = 4 Then
            frmChild.rbQuest1_1_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(11) = 1 Then
            frmChild.rbQuest1_2_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(11) = 2 Then
            frmChild.rbQuest1_2_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(11) = 3 Then
            frmChild.rbQuest1_2_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(11) = 4 Then
            frmChild.rbQuest1_2_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(12) = 1 Then
            frmChild.rbQuest1_3_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(12) = 2 Then
            frmChild.rbQuest1_3_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(12) = 3 Then
            frmChild.rbQuest1_3_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(12) = 4 Then
            frmChild.rbQuest1_3_4.Checked = True
        End If


        If dtQuestionnaire.Rows(0).Item(13) = 1 Then
            frmChild.rbQuest1_4_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(13) = 2 Then
            frmChild.rbQuest1_4_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(13) = 3 Then
            frmChild.rbQuest1_4_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(13) = 4 Then
            frmChild.rbQuest1_4_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(14) = 1 Then
            frmChild.rbQuest1_5_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(14) = 2 Then
            frmChild.rbQuest1_5_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(14) = 3 Then
            frmChild.rbQuest1_5_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(14) = 4 Then
            frmChild.rbQuest1_5_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(15) = 1 Then
            frmChild.rbQuest2_1_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(15) = 2 Then
            frmChild.rbQuest2_1_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(15) = 3 Then
            frmChild.rbQuest2_1_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(15) = 4 Then
            frmChild.rbQuest2_1_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(16) = 1 Then
            frmChild.rbQuest2_2_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(16) = 2 Then
            frmChild.rbQuest2_2_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(16) = 3 Then
            frmChild.rbQuest2_2_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(16) = 4 Then
            frmChild.rbQuest2_2_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(17) = 1 Then
            frmChild.rbQuest2_3_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(17) = 2 Then
            frmChild.rbQuest2_3_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(17) = 3 Then
            frmChild.rbQuest2_3_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(17) = 4 Then
            frmChild.rbQuest2_3_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(18) = 1 Then
            frmChild.rbQuest2_4_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(18) = 2 Then
            frmChild.rbQuest2_4_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(18) = 3 Then
            frmChild.rbQuest2_4_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(18) = 4 Then
            frmChild.rbQuest2_4_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(19) = 1 Then
            frmChild.rbQuest2_5_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(19) = 2 Then
            frmChild.rbQuest2_5_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(19) = 3 Then
            frmChild.rbQuest2_5_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(19) = 4 Then
            frmChild.rbQuest2_5_4.Checked = True
        End If


        If dtQuestionnaire.Rows(0).Item(20) = 1 Then
            frmChild.rbQuest3_1_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(20) = 2 Then
            frmChild.rbQuest3_1_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(20) = 3 Then
            frmChild.rbQuest3_1_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(20) = 4 Then
            frmChild.rbQuest3_1_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(21) = 1 Then
            frmChild.rbQuest3_2_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(21) = 2 Then
            frmChild.rbQuest3_2_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(21) = 3 Then
            frmChild.rbQuest3_2_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(21) = 4 Then
            frmChild.rbQuest3_2_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(22) = 1 Then
            frmChild.rbQuest3_3_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(22) = 2 Then
            frmChild.rbQuest3_3_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(22) = 3 Then
            frmChild.rbQuest3_3_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(22) = 4 Then
            frmChild.rbQuest3_3_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(23) = 1 Then
            frmChild.rbQuest3_4_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(23) = 2 Then
            frmChild.rbQuest3_4_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(23) = 3 Then
            frmChild.rbQuest3_4_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(23) = 4 Then
            frmChild.rbQuest3_4_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(24) = 1 Then
            frmChild.rbQuest3_5_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(24) = 2 Then
            frmChild.rbQuest3_5_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(24) = 3 Then
            frmChild.rbQuest3_5_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(24) = 4 Then
            frmChild.rbQuest3_5_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(25) = 1 Then
            frmChild.rbQuest4_1_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(25) = 2 Then
            frmChild.rbQuest4_1_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(25) = 3 Then
            frmChild.rbQuest4_1_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(25) = 4 Then
            frmChild.rbQuest4_1_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(26) = 1 Then
            frmChild.rbQuest4_2_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(26) = 2 Then
            frmChild.rbQuest4_2_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(26) = 3 Then
            frmChild.rbQuest4_2_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(26) = 4 Then
            frmChild.rbQuest4_2_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(27) = 1 Then
            frmChild.rbQuest4_3_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(27) = 2 Then
            frmChild.rbQuest4_3_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(27) = 3 Then
            frmChild.rbQuest4_3_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(27) = 4 Then
            frmChild.rbQuest4_3_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(28) = 1 Then
            frmChild.rbQuest4_4_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(28) = 2 Then
            frmChild.rbQuest4_4_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(28) = 3 Then
            frmChild.rbQuest4_4_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(28) = 4 Then
            frmChild.rbQuest4_4_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(29) = 1 Then
            frmChild.rbQuest4_5_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(29) = 2 Then
            frmChild.rbQuest4_5_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(29) = 3 Then
            frmChild.rbQuest4_5_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(29) = 4 Then
            frmChild.rbQuest4_5_4.Checked = True
        End If


        If dtQuestionnaire.Rows(0).Item(30) = 1 Then
            frmChild.rbQuest5_1_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(30) = 2 Then
            frmChild.rbQuest5_1_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(30) = 3 Then
            frmChild.rbQuest5_1_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(30) = 4 Then
            frmChild.rbQuest5_1_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(31) = 1 Then
            frmChild.rbQuest5_2_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(31) = 2 Then
            frmChild.rbQuest5_2_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(31) = 3 Then
            frmChild.rbQuest5_2_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(31) = 4 Then
            frmChild.rbQuest5_2_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(32) = 1 Then
            frmChild.rbQuest5_3_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(32) = 2 Then
            frmChild.rbQuest5_3_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(32) = 3 Then
            frmChild.rbQuest5_3_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(32) = 4 Then
            frmChild.rbQuest5_3_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(33) = 1 Then
            frmChild.rbQuest5_4_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(33) = 2 Then
            frmChild.rbQuest5_4_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(33) = 3 Then
            frmChild.rbQuest5_4_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(33) = 4 Then
            frmChild.rbQuest5_4_4.Checked = True
        End If

        If dtQuestionnaire.Rows(0).Item(34) = 1 Then
            frmChild.rbQuest5_5_1.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(34) = 2 Then
            frmChild.rbQuest5_5_2.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(34) = 3 Then
            frmChild.rbQuest5_5_3.Checked = True
        ElseIf dtQuestionnaire.Rows(0).Item(34) = 4 Then
            frmChild.rbQuest5_5_4.Checked = True
        End If

        frmChild.txtRemark1_1.Text = dtQuestionnaire.Rows(0).Item(35)
        frmChild.txtRemark1_2.Text = dtQuestionnaire.Rows(0).Item(36)
        frmChild.txtRemark1_3.Text = dtQuestionnaire.Rows(0).Item(37)
        frmChild.txtRemark1_4.Text = dtQuestionnaire.Rows(0).Item(38)
        frmChild.txtRemark1_5.Text = dtQuestionnaire.Rows(0).Item(39)

        frmChild.txtRemark2_1.Text = dtQuestionnaire.Rows(0).Item(40)
        frmChild.txtRemark2_2.Text = dtQuestionnaire.Rows(0).Item(41)
        frmChild.txtRemark2_3.Text = dtQuestionnaire.Rows(0).Item(42)
        frmChild.txtRemark2_4.Text = dtQuestionnaire.Rows(0).Item(43)
        frmChild.txtRemark2_5.Text = dtQuestionnaire.Rows(0).Item(44)

        frmChild.txtRemark3_1.Text = dtQuestionnaire.Rows(0).Item(45)
        frmChild.txtRemark3_2.Text = dtQuestionnaire.Rows(0).Item(46)
        frmChild.txtRemark3_3.Text = dtQuestionnaire.Rows(0).Item(47)
        frmChild.txtRemark3_4.Text = dtQuestionnaire.Rows(0).Item(48)
        frmChild.txtRemark3_5.Text = dtQuestionnaire.Rows(0).Item(49)

        frmChild.txtRemark4_1.Text = dtQuestionnaire.Rows(0).Item(50)
        frmChild.txtRemark4_2.Text = dtQuestionnaire.Rows(0).Item(51)
        frmChild.txtRemark4_3.Text = dtQuestionnaire.Rows(0).Item(52)
        frmChild.txtRemark4_4.Text = dtQuestionnaire.Rows(0).Item(53)
        frmChild.txtRemark4_5.Text = dtQuestionnaire.Rows(0).Item(54)

        frmChild.txtRemark5_1.Text = dtQuestionnaire.Rows(0).Item(55)
        frmChild.txtRemark5_2.Text = dtQuestionnaire.Rows(0).Item(56)
        frmChild.txtRemark5_3.Text = dtQuestionnaire.Rows(0).Item(57)
        frmChild.txtRemark5_4.Text = dtQuestionnaire.Rows(0).Item(58)
        frmChild.txtRemark5_5.Text = dtQuestionnaire.Rows(0).Item(59)

        frmChild.txtRemark.Text = dtQuestionnaire.Rows(0).Item(60)
        frmChild.SetToolTip()

        If conn.State = ConnectionState.Open Then conn.Close()
        dtQuestSection.Clear()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Master_QuestionSection '" & dtQuestionnaire.Rows(0).Item(1) & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtQuestSection)
        conn.Close()

        If dtQuestSection.Rows.Count >= 1 Then
            frmChild.lblSection1.Text = dtQuestSection.Rows(0).Item("Description").ToString.Trim
            frmChild.lblSection1.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & dtQuestionnaire.Rows(0).Item(1) & "', '" & dtQuestSection.Rows(0).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest1_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest1_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest1_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest1_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest1_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest1_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest1_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest1_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest1_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest1_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 2 Then
            frmChild.lblSection2.Text = dtQuestSection.Rows(1).Item("Description").ToString.Trim
            frmChild.lblSection2.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & dtQuestionnaire.Rows(0).Item(1) & "', '" & dtQuestSection.Rows(1).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest2_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest2_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest2_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest2_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest2_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest2_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest2_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest2_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest2_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest2_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 3 Then
            frmChild.lblSection3.Text = dtQuestSection.Rows(2).Item("Description").ToString.Trim
            frmChild.lblSection3.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & dtQuestionnaire.Rows(0).Item(1) & "', '" & dtQuestSection.Rows(2).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest3_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest3_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest3_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest3_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest3_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest3_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest3_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest3_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest3_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest3_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 4 Then
            frmChild.lblSection4.Text = dtQuestSection.Rows(3).Item("Description").ToString.Trim
            frmChild.lblSection4.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & dtQuestionnaire.Rows(0).Item(1) & "', '" & dtQuestSection.Rows(3).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest4_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest4_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest4_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest4_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest4_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest4_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest4_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest4_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest4_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest4_5.Visible = True
            End If
        End If

        If dtQuestSection.Rows.Count >= 5 Then
            frmChild.lblSection5.Text = dtQuestSection.Rows(4).Item("Description").ToString.Trim
            frmChild.lblSection5.Visible = True

            If conn.State = ConnectionState.Open Then conn.Close()
            dtQuestion.Clear()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Master_Question '" & dtQuestionnaire.Rows(0).Item(1) & "', '" & dtQuestSection.Rows(4).Item("Section ID").ToString.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtQuestion)
            conn.Close()

            If dtQuestion.Rows.Count >= 1 Then
                frmChild.lblQuest5_1.Text = dtQuestion.Rows(0).Item("Question").ToString.Trim
                frmChild.gbQuest5_1.Visible = True
            End If

            If dtQuestion.Rows.Count >= 2 Then
                frmChild.lblQuest5_2.Text = dtQuestion.Rows(1).Item("Question").ToString.Trim
                frmChild.gbQuest5_2.Visible = True
            End If

            If dtQuestion.Rows.Count >= 3 Then
                frmChild.lblQuest5_3.Text = dtQuestion.Rows(2).Item("Question").ToString.Trim
                frmChild.gbQuest5_3.Visible = True
            End If

            If dtQuestion.Rows.Count >= 4 Then
                frmChild.lblQuest5_4.Text = dtQuestion.Rows(3).Item("Question").ToString.Trim
                frmChild.gbQuest5_4.Visible = True
            End If

            If dtQuestion.Rows.Count >= 5 Then
                frmChild.lblQuest5_5.Text = dtQuestion.Rows(4).Item("Question").ToString.Trim
                frmChild.gbQuest5_5.Visible = True
            End If
        End If

        frmChild.EnableDisableInput(False)
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Call RetrieveQuestionnaireByKey()
    End Sub

    Private Sub btn_ShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ShowAll.Click
        Call RetrieveDataGrid()
    End Sub

#End Region

End Class