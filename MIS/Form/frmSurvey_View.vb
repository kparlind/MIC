Imports MIS.TransData
Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data
Imports System.Data.SqlClient

Public Class frmSurvey_View
    Dim TD As New TransData
    Dim MD As New MasterData

    Private Sub frmSurvey_View_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, btnNew)

        'Khusus untuk form ini, hanya ada new
        btnEdit.Visible = False
        btnSave.Visible = False
        btnCancel.Visible = False
        btnDelete.Visible = False

        InitState()
        btnCari_Click(Nothing, Nothing)

        If (userlog.AccessID <> Role.MarketingAdmin AndAlso userlog.AccessID <> Role.SuperAdmin) Then
            btnNew.Enabled = False
        End If
    End Sub

    Private Sub InitState()
        dtpBeginDate.Value = DateSerial(Year(Now), 1, 1)
        dtpEndDate.Value = Now

        dtpBeginOnSite.Value = DateSerial(Year(Now), Month(Now), 1)
        dtpEndOnSite.Value = Now

        txtSurveyNo.Text = String.Empty

        LoadCombo()
    End Sub

    Private Sub LoadCombo()
        Dim dtTemp As New DataTable
        Dim drTemp As DataRow
        Dim dtTemp2 As New DataTable
        Dim drTemp2 As DataRow

        TD.RetrieveStatusSurvey_ForView(dtTemp)
        cboStatus.Items.Clear()

        drTemp = dtTemp.NewRow
        With drTemp
            .Item(0) = "ALL"
            .Item(1) = "All Status"
        End With
        dtTemp.Rows.InsertAt(drTemp, 0)

        If dtTemp.Rows.Count <> 0 Then
            cboStatus.DataSource = dtTemp
            cboStatus.ValueMember = Fields.Status_ID
            cboStatus.DisplayMember = Fields.Status_Name
        End If


        MD.RetrieveSurveyor(dtTemp2)
        cboSurveyor.Items.Clear()

        drTemp2 = dtTemp2.NewRow
        With drTemp2
            .Item(0) = "ALL"
            .Item(1) = "All Surveyor"
        End With
        dtTemp2.Rows.InsertAt(drTemp2, 0)

        If dtTemp2.Rows.Count <> 0 Then
            cboSurveyor.DataSource = dtTemp2
            cboSurveyor.ValueMember = Fields.EmployeeID
            cboSurveyor.DisplayMember = Fields.EmployeeName
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If MessageBox.Show("Create New Survey Form will generate new number for Survey Transaction." & vbCrLf & "Please use view function from Grid below to edit this transaction data." & vbCrLf & "Are you sure to print and generate new number for this Survey ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Dim frmChild As New frmReport

            frmChild.ReportName = "Form Survey"
            frmChild.SurveyNo = Generate_TranNo("frmSurvey")

            If InsertNewSurvey(frmChild.SurveyNo) Then
                For Each f As Form In Me.MdiChildren
                    If f.Name = "Form Survey" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
                btnCari_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub gView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gView.CellDoubleClick
        Dim frmChild As New frmSurvey

        If gView.CurrentRow.DataGridView(0, gView.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmSurvey" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.ViewFormName = Me.Name
        frmChild.NewFromView = False
        frmChild.FromInbox = False
        frmChild.txtSurveyNo.Text = gView.CurrentRow.Cells(0).Value.ToString.Trim
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub txtSurveyNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSurveyNo.KeyDown
        Dim dtData As New DataTable

        If e.KeyCode = Keys.F1 Then
            If userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                Call frmSearch.InitFindData(":: Find Survey ::", "exec sp_Retrieve_Trans_Survey_Hdr_ForSearch")
            Else
                MessageBox.Show("Unauthorized process", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

            Call frmSearch.AddFindColumn(1, "Survey_No", "Survey#", DataType.TypeString, 100)
            Call frmSearch.AddFindColumn(2, "Survey_Date", "Print Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(3, "Nama", "Customer Name", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(4, "EmployeeName", "Surveyor", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(5, "Survey_Site_Date", "On Site Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(6, "SPK_No", "SPK#", DataType.TypeString, 100)
            Call frmSearch.AddFindColumn(7, "Survey_Remark", "Remark", DataType.TypeString, 300)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtSurveyNo.Text = frmSearch.txtResult1.Text.Trim
                cboStatus.Focus()
            End If
        End If
    End Sub

    Private Sub btnCari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Dim dtData As New DataTable

        RetrieveViewData(dtData)
        gView.DataSource = Nothing
        If dtData.Rows.Count <> 0 Then
            gView.DataSource = dtData
        End If
    End Sub

    Private Sub gView_ColumnAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles gView.ColumnAdded
        Select Case e.Column.Index
            Case 0  'SurveyNo
                gView.Columns.Item(0).Width = 80
                gView.Columns.Item(0).HeaderText = "Survey#"
            Case 1  'SurveyDate
                gView.Columns.Item(1).Width = 80
                gView.Columns.Item(1).HeaderText = "Print Date"
            Case 2  'Survey On Site
                gView.Columns.Item(2).Width = 90
                gView.Columns.Item(2).HeaderText = "On Site Date"
            Case 3  'Cust Name
                gView.Columns.Item(3).Width = 150
                gView.Columns.Item(3).HeaderText = "Customer"
            Case 4  'Surveyor Name
                gView.Columns.Item(4).Width = 150
                gView.Columns.Item(4).HeaderText = "Surveyor"
            Case 5  'Survey Remark
                gView.Columns.Item(5).Width = 250
                gView.Columns.Item(5).HeaderText = "Remarks"
            Case 6  'Status Name
                gView.Columns.Item(6).Width = 200
                gView.Columns.Item(6).HeaderText = "Status"
        End Select
    End Sub

#Region "Database Access"
    Private Sub RetrieveViewData(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Query As String, QueryParam As String

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            'Delete seluruh data awal
            Query = "exec sp_Retrieve_Trans_Survey_Hdr_ForView "
            QueryParam = "'" & Format(dtpBeginDate.Value, "yyyyMMdd") & "', '" & Format(dtpEndDate.Value, "yyyyMMdd") & "', " & _
                "'" & Format(dtpBeginOnSite.Value, "yyyyMMdd") & "', '" & Format(dtpEndOnSite.Value, "yyyyMMdd") & "', " & _
                "'" & txtSurveyNo.Text.Trim & "', '" & cboSurveyor.SelectedValue & "', '" & cboStatus.SelectedValue & "'"

            Cmd.CommandText = Query & QueryParam
            DA.SelectCommand = Cmd
            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Function InsertNewSurvey(ByVal NewNumber As String) As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Query As String, QueryParam As String
        Dim Trans As SqlTransaction

        InsertNewSurvey = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()
        Trans = Conn.BeginTransaction

        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        Cmd.Transaction = Trans

        Try
            Query = "exec sp_Insert_Trans_Survey_Hdr "
            QueryParam = "'" & NewNumber & "', '" & Format(Now, "MM/dd/yyyy") & "', '', '', '', '', '', '" & Format(Now, "MM/dd/yyyy") & "', '', ''," & _
                         "'', '', 'N', 'N', 'N', 'N', '" & GlobalVar.Status.Draft & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & QueryParam
            Cmd.ExecuteNonQuery()

            UpdateSerial("FrmSurvey", GetCurrMonth, GetCurrYear, CInt(NewNumber.Substring(NewNumber.Length - 3, 3)), userlog.UserName) 'Update Serial
            InserttoInbox(NewNumber, userlog.UserName, userlog.UserName, "W", "Y", GlobalVar.Status.Draft) 'Insert to NEXT APPROVAL
            Insert_Trans_History(NewNumber.Trim, Me.Name, GlobalVar.Status.HISTORY_Insert) 'Insert History transaction

            InsertNewSurvey = True
            Trans.Commit()
        Catch ex As Exception
            Trans.Rollback()
        End Try
    End Function
#End Region

    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub
End Class