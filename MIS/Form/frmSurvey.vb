'(08 Jan 2013) Remarked insert inbox for approved data, and added reject remark.
'(22 Jan 2013) Modified auto delete when component is unchecked

Imports System.Data
Imports System.Data.SqlClient
Imports MIS.mdlCommon
Imports MIS.GlobalVar

Public Class frmSurvey
#Region "Description"
    Public StatusTrans As String
    Public NewFromView As Boolean
    Public FromInbox As Boolean
    Public aEdit As Boolean
    Public aDelete As Boolean
    Public ViewFormName As String

    Dim StatusID_Trans As String
    Dim StatusDetail As String
    Dim MD As New MasterData
    Dim TD As New TransData
    Dim dtDetail As DataTable
    Dim frmReason As New Frm_Reason
    Dim alasanReject As String
    Dim dtComponent As DataTable
    Dim fl As Boolean

    'Dim ViewFormName As String = "FrmSurvey_View"
    Private CallerForm As String
#End Region

#Region "UI"
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso Not StatusDetail = TransStatus.NoStatus Then
            Dim drDetail As DataRow

            If StatusDetail = TransStatus.EditStatus Then
                drDetail = dtDetail.Rows(txtSeqNum.Text)
                With drDetail
                    .Item(Fields.SURD_ItemID) = txtItemID.Text.Trim
                    .Item(Fields.Item_Name) = txtItemName.Text.Trim
                    .Item(Fields.SURD_ItemUOM) = txtUOM.Text.Trim
                    .Item(Fields.SURD_ItemQty) = txtQty.Text
                    .Item(Fields.SURD_ItemRemark) = txtRemarkD.Text.Trim
                    .Item(Fields.Item_Type) = txtType.Text.Trim
                    .Item(Fields.Item_Category) = txtCategory.Text.Trim
                    .Item(Fields.SURD_ItemComponent) = txtItemComponent.Text.Trim
                End With
            ElseIf StatusDetail = TransStatus.NewStatus Then
                drDetail = dtDetail.NewRow
                With drDetail
                    .Item(Fields.SURD_ItemID) = txtItemID.Text.Trim
                    .Item(Fields.Item_Name) = txtItemName.Text.Trim
                    .Item(Fields.SURD_ItemUOM) = txtUOM.Text.Trim
                    .Item(Fields.SURD_ItemQty) = txtQty.Text
                    .Item(Fields.SURD_ItemRemark) = txtRemarkD.Text.Trim
                    .Item(Fields.Item_Type) = txtType.Text.Trim
                    .Item(Fields.Item_Category) = txtCategory.Text.Trim
                    .Item(Fields.SURD_ItemComponent) = txtItemComponent.Text.Trim
                End With
                dtDetail.Rows.Add(drDetail)
            End If

            StatusDetail = String.Empty
            InitDetailInput()
            SetDetailButton()
            ReloadGridDetail()
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso StatusDetail <> TransStatus.NoStatus Then
            StatusDetail = String.Empty
            InitDetailInput()
            SetDetailInput()
            SetDetailButton()
        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso StatusDetail = TransStatus.NoStatus Then
            StatusDetail = TransStatus.NewStatus
            InitDetailInput()
            SetDetailInput(True)
            SetDetailButton()
            txtItemID.Focus()
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso StatusDetail = TransStatus.NoStatus Then
            If txtSeqNum.Text <> String.Empty Then
                StatusDetail = TransStatus.EditStatus
                SetDetailInput(True)
                SetDetailButton()
                txtQty.Focus()
            End If
        End If
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso StatusDetail = TransStatus.NoStatus Then
            If txtSeqNum.Text <> String.Empty Then
                If MessageBox.Show("Are you sure want to delete this detail ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    dtDetail.Rows(txtSeqNum.Text).Delete()
                    ReloadGridDetail()
                    SetDetailInput()
                    InitDetailInput()
                End If
            End If
        End If
    End Sub

    Private Sub frmSurvey_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If StatusTrans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            If Not FromInbox Then
                Dim frmChild As New frmSurvey_View

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            End If
        End If
    End Sub

    Private Sub frmSurvey_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dtHeader As New DataTable

        SetAccess(Me, userlog.AccessID, ViewFormName)
        If Not NewFromView OrElse FromInbox Then
            StatusTrans = TransStatus.NoStatus

            TD.RetrieveSurveyHeaderByKey(dtHeader, txtSurveyNo.Text.Trim)
            FillDataToUI(dtHeader)
            EnableInput(False)
        Else
            EnableInput(True)
        End If

        StatusDetail = TransStatus.NoStatus
        SetToolbox()
        SetDetailButton()

        'Khusus untuk form ini, New button tidak digunakan
        btnNew.Visible = False

        If Not (StatusID_Trans = Status.SURVEY_Saved AndAlso (userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin)) Then
            btnReject.Enabled = False
            btnApprove.Enabled = False
        ElseIf Not (StatusID_Trans = Status.SURVEY_Rejected AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin)) Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub gvDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvDetail.CellClick
        If StatusDetail = TransStatus.NoStatus Then
            If e.RowIndex >= 0 Then
                With gvDetail.Rows(e.RowIndex)
                    txtItemID.Text = .Cells(0).Value.ToString
                    txtItemName.Text = .Cells(1).Value.ToString
                    txtUOM.Text = .Cells(2).Value.ToString
                    txtQty.Text = .Cells(3).Value.ToString
                    txtRemarkD.Text = .Cells(4).Value.ToString
                    txtCategory.Text = .Cells(5).Value.ToString
                    txtItemComponent.Text = .Cells(6).Value.ToString
                    txtType.Text = .Cells(7).Value.ToString
                    txtSeqNum.Text = e.RowIndex
                End With
            End If
        End If
    End Sub

    Private Sub ReinsertDetail(ByVal category As String, ByVal component As String)
        Dim dtTemp As New DataTable
        Dim j, i As Integer
        Dim drDetail As DataRow

        MD.RetrieveDetailItemKomponent_ByCategoryAndComponentID(dtTemp, category, component)
        If dtTemp.Rows.Count <> 0 Then
            For j = 0 To dtTemp.Rows.Count - 1
                drDetail = dtDetail.NewRow
                With drDetail
                    .Item(Fields.SURD_ItemID) = dtTemp.Rows(j).Item(Fields.SURD_ItemID).ToString.Trim
                    .Item(Fields.Item_Name) = dtTemp.Rows(j).Item(Fields.Item_Name).ToString.Trim
                    .Item(Fields.SURD_ItemUOM) = dtTemp.Rows(j).Item(Fields.Item_UOM).ToString.Trim
                    .Item(Fields.SURD_ItemQty) = dtTemp.Rows(j).Item(Fields.Qty).ToString.Trim
                    .Item(Fields.SURD_ItemRemark) = String.Empty
                    .Item(Fields.Item_Type) = dtTemp.Rows(j).Item(Fields.Item_Type).ToString.Trim
                    .Item(Fields.Item_Category) = category
                    .Item(Fields.SURD_ItemComponent) = component
                End With
                dtDetail.Rows.Add(drDetail)
            Next
        End If

        ReloadGridDetail()
    End Sub

    Private Sub initComponent()
        dtComponent = New DataTable

        dtComponent.Columns.Clear()
        dtComponent.Columns.Add("Category", System.Type.GetType("System.String"))
        dtComponent.Columns.Add("Component", System.Type.GetType("System.String"))
    End Sub

    Private Sub txtSurveyorID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSurveyorID.KeyDown
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                Call frmSearch.InitFindData(":: Find Surveyor ::", "exec sp_Retrieve_Master_Employee_Surveyor")
                Call frmSearch.AddFindColumn(1, "Employee_ID", "Surveyor ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Name", "Surveyor Name", DataType.TypeString, 250)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtSurveyorID.Text = frmSearch.txtResult1.Text.Trim
                    txtSurveyorID_LostFocus(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub txtItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso StatusDetail <> TransStatus.NoStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                Call frmSearch.InitFindData(":: Find Item ::", "exec sp_Retrieve_Master_Item_ForSearch")
                Call frmSearch.AddFindColumn(1, "Item_ID", "Item ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Item_Name", "Item Name", DataType.TypeString, 250)
                Call frmSearch.AddFindColumn(3, "UOM", "UOM", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(3, "Item_Category", "Category", DataType.TypeString, 120)
                Call frmSearch.AddFindColumn(3, "Item_Type", "Type", DataType.TypeString, 100)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtItemID.Text = frmSearch.txtResult1.Text.Trim
                    txtQty.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtMarketingID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarketingID.KeyDown
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                Call frmSearch.InitFindData(":: Find Marketing ::", "exec sp_Retrieve_Master_Employee_Marketing")
                Call frmSearch.AddFindColumn(1, "Employee_ID", "Marketing ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Name", "Marketing Name", DataType.TypeString, 250)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtMarketingID.Text = frmSearch.txtResult1.Text.Trim
                    txtMarketingID_LostFocus(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub txtMarketingID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarketingID.LostFocus
        If txtMarketingID.Text.Trim <> String.Empty Then
            FillMarketingData()
        Else
            txtMarketingName.Text = String.Empty
        End If
    End Sub

    Private Sub txtCust_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCust.KeyDown
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                Call frmSearch.InitFindData(":: Find Customer ::", "exec sp_Retrieve_Master_Customer_ForSearch")
                Call frmSearch.AddFindColumn(1, "Cust_ID", "Customer ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Nama", "Customer Name", DataType.TypeString, 250)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtCust.Text = frmSearch.txtResult1.Text.Trim
                    txtCust_LostFocus(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub txtSurveyNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSurveyNo.KeyDown
        If StatusTrans = TransStatus.FindStatus Then
            Dim dtData As New DataTable

            If e.KeyCode = Keys.F1 Then
                Call frmSearch.InitFindData(":: Find Survey Data ::", "exec sp_Retrieve_Trans_Survey_Hdr_ForSearch")
                Call frmSearch.AddFindColumn(1, "Survey_No", "Survey#", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Survey_Date", "Survey_Date", DataType.TypeDateTime, 100)
                Call frmSearch.AddFindColumn(3, "Survey_Site_Date", "On Site Date", DataType.TypeDateTime, 100)
                Call frmSearch.AddFindColumn(4, "Nama", "Customer", DataType.TypeString, 150)
                Call frmSearch.AddFindColumn(5, "EmployeeName", "Surveyor", DataType.TypeString, 150)
                Call frmSearch.AddFindColumn(6, "SPK_No", "SPK#", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(7, "Survey_Remark", "Survey Remark", DataType.TypeString, 300)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                    txtSurveyNo.Text = frmSearch.txtResult1.Text.Trim
                    txtSurveyNo_LostFocus("str", Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub txtSurveyNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurveyNo.LostFocus
        If StatusTrans = TransStatus.FindStatus AndAlso sender.ToString = "str" Then
            Dim dtData As New DataTable

            TD.RetrieveSurveyHeaderByKey(dtData, txtSurveyNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                FillDataToUI(dtData)

                txtSurveyNo.ReadOnly = True
                txtSurveyNo.BackColor = Color.LightGray
                StatusTrans = TransStatus.NoStatus
                SetToolbox()
            Else
                MessageBox.Show("There's no data with this Survey# in database." & vbCrLf & "Please input other Survey#.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtPIC_HP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIC_HP.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCustHP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustHP.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtCust_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCust.LostFocus
        If txtCust.Text.Trim <> String.Empty Then
            FillCustomerData()
        Else
            txtCustName.Text = String.Empty
        End If
    End Sub

    Private Sub txtSurveyorID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurveyorID.LostFocus
        If txtSurveyorID.Text.Trim <> String.Empty Then
            FillSurveyorData()
        Else
            txtSurveyorName.Text = String.Empty
        End If
    End Sub

    Private Sub txtItemID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemID.LostFocus
        If txtItemID.Text.Trim <> String.Empty Then
            FillItemData()
        Else
            txtItemID.Text = String.Empty
            txtItemName.Text = String.Empty
            txtUOM.Text = String.Empty
            txtQty.Text = String.Empty
            txtRemark.Text = String.Empty
        End If
    End Sub
#End Region
#Region "Main Button"
    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        If StatusTrans = TransStatus.NoStatus AndAlso StatusID_Trans = Status.SURVEY_Saved AndAlso (userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin) Then
            If MessageBox.Show("Are you sure to reject this Survey# " & txtSurveyNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                alasanReject = String.Empty
                frmReason.ShowDialog()

                If frmReason.Flag = "OK" Then
                    alasanReject = frmReason.txtReason.Text.Trim

                    RejectData()
                    Me.Close()
                    'ShowView()
                End If
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If StatusTrans = TransStatus.NoStatus AndAlso StatusID_Trans = Status.SURVEY_Saved AndAlso (userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin) Then
            If MessageBox.Show("Are you sure to approve this Survey# " & txtSurveyNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ApproveData()
                ShowView()
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If StatusTrans = TransStatus.NoStatus AndAlso txtSurveyNo.Text.Trim <> String.Empty AndAlso (StatusID_Trans = Status.SURVEY_Rejected OrElse StatusID_Trans = Status.Draft) AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            If MessageBox.Show("Are you sure to delete Survey# " & txtSurveyNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DeleteSurvey()
                ShowView()
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If StatusTrans = TransStatus.NoStatus AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            StatusTrans = TransStatus.NewStatus
            StatusDetail = TransStatus.NoStatus
            NewState()
            SetToolbox()
            SetDetailButton()
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtSurveyNo.Text.Trim <> String.Empty AndAlso StatusTrans = TransStatus.NoStatus AndAlso (StatusID_Trans = Status.SURVEY_Rejected OrElse StatusID_Trans = Status.Draft) AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            StatusTrans = TransStatus.EditStatus
            StatusDetail = TransStatus.NoStatus
            EditState()
            SetToolbox()
            SetDetailButton()
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus) AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            If StatusTrans = TransStatus.NewStatus Then
                If MessageBox.Show("Cancelling this process will close this form." & vbCrLf & "Are you sure to continue ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    StatusTrans = TransStatus.NoStatus
                    StatusDetail = TransStatus.NoStatus
                    Me.Close()
                End If
            Else
                Dim dtData As New DataTable

                StatusTrans = TransStatus.NoStatus
                StatusDetail = TransStatus.NoStatus

                TD.RetrieveSurveyHeaderByKey(dtData, txtSurveyNo.Text.Trim)
                FillDataToUI(dtData)
                EnableInput(False)
                SetDetailInput(False)
                SetToolbox()
                SetDetailButton()

                txtSurveyNo.BackColor = Color.LightGray
                txtSurveyNo.ReadOnly = True
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (StatusTrans = TransStatus.EditStatus AndAlso (StatusID_Trans = Status.SURVEY_Rejected OrElse StatusID_Trans = Status.Draft)) AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            If CekSave(False) Then
                If UpdateData() Then
                    StatusTrans = TransStatus.NoStatus
                    ShowView()
                End If
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If StatusTrans = TransStatus.NoStatus AndAlso (userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            StatusTrans = TransStatus.FindStatus
            SetToolbox()

            ClearInput()
            EnableInput(False)
            txtSurveyNo.ReadOnly = False
            txtSurveyNo.BackColor = Color.Empty
            txtSurveyNo.Focus()
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub
#End Region
#Region "UI Supporting Logic"
    Private Sub ShowView()
        If Not FromInbox Then
            Dim frmChild As New frmSurvey_View

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmSurvey_View" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
        Me.Close()
    End Sub

    Private Sub ReloadGridDetail()
        gvDetail.Rows.Clear()
        If dtDetail.Rows.Count > 0 Then
            Dim i As Integer

            For i = 0 To dtDetail.Rows.Count - 1
                gvDetail.Rows.Add()
                With gvDetail.Rows(i)
                    .Cells(0).Value = dtDetail.Rows(i).Item(Fields.SURD_ItemID)
                    .Cells(1).Value = MD.RetrieveItemNameByKey(.Cells(0).Value)
                    .Cells(2).Value = dtDetail.Rows(i).Item(Fields.SURD_ItemUOM)
                    .Cells(3).Value = dtDetail.Rows(i).Item(Fields.SURD_ItemQty)
                    .Cells(4).Value = dtDetail.Rows(i).Item(Fields.SURD_ItemRemark)
                    .Cells(5).Value = dtDetail.Rows(i).Item(Fields.Item_Category)
                    .Cells(6).Value = dtDetail.Rows(i).Item(Fields.SURD_ItemComponent)
                    .Cells(7).Value = dtDetail.Rows(i).Item(Fields.Item_Type)
                End With
            Next
        End If

        gvDetail.Columns(Fields.SURD_ItemQty).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gvDetail.Columns(Fields.SURD_ItemQty).DefaultCellStyle.Format = "#,##0.#0"
    End Sub

    Private Sub SetDetailColumn()
        dtDetail = New DataTable

        dtDetail.Columns.Clear()
        dtDetail.Columns.Add(Fields.SURD_ItemID, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.Item_Name, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.SURD_ItemUOM, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.SURD_ItemQty, System.Type.GetType("System.Double"))
        dtDetail.Columns.Add(Fields.SURD_ItemRemark, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.Item_Category, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.SURD_ItemComponent, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.Item_Type, System.Type.GetType("System.String"))
    End Sub

    Private Sub SetDetailButton()
        If StatusTrans = TransStatus.NoStatus Then
            btn_save.Enabled = False
            Btn_cancel.Enabled = False
            btn_insert.Enabled = False
            btn_edit.Enabled = False
            btn_delete.Enabled = False
        Else
            Select Case StatusDetail
                Case TransStatus.NewStatus, TransStatus.EditStatus
                    btn_save.Enabled = True
                    Btn_cancel.Enabled = True

                    btn_insert.Enabled = False
                    btn_edit.Enabled = False
                    btn_delete.Enabled = False
                Case Else
                    btn_save.Enabled = False
                    Btn_cancel.Enabled = False

                    btn_insert.Enabled = True
                    btn_edit.Enabled = True
                    btn_delete.Enabled = True
            End Select
        End If
    End Sub

    Private Sub SetToolbox()
        If userlog.AccessID = Role.MarketingAdmin Then
            sep_Approver.Visible = False
            btnApprove.Visible = False
            btnReject.Visible = False

            'btnNew.Visible = True
            'btnFind.Visible = True
            btnNew.Visible = False
            btnFind.Visible = False
            btnList.Visible = False
            ToolStripSeparator1.Visible = False

            Select Case StatusTrans
                Case TransStatus.NewStatus, TransStatus.EditStatus, TransStatus.FindStatus
                    btnCancel.Enabled = True
                    btnSave.Enabled = True
                    btnNew.Enabled = False
                    btnEdit.Enabled = False
                    btnDelete.Enabled = False
                    btnFind.Enabled = False
                Case Else
                    btnCancel.Enabled = False
                    btnSave.Enabled = False
                    btnNew.Enabled = True
                    btnEdit.Enabled = True
                    btnDelete.Enabled = True
                    btnFind.Enabled = True
            End Select

            If Not (StatusID_Trans = Status.Draft OrElse StatusID_Trans = Status.SURVEY_Rejected) Then
                btnEdit.Enabled = False
                btnDelete.Enabled = False
            End If
        ElseIf userlog.AccessID = Role.MarketingHead Then
            sep_Approver.Visible = False
            btnCancel.Visible = False
            btnNew.Visible = False
            btnSave.Visible = False
            btnDelete.Visible = False
            btnEdit.Visible = False
            btnFind.Visible = False
            btnList.Visible = False
            ToolStripSeparator1.Visible = False

            btnApprove.Visible = True
            btnReject.Visible = True

            If Not StatusID_Trans = Status.SURVEY_Saved Then
                btnApprove.Enabled = False
                btnReject.Enabled = False
            End If
        ElseIf userlog.AccessID = Role.SuperAdmin Then
            If StatusID_Trans = Status.SURVEY_Saved OrElse StatusID_Trans = Status.SURVEY_Approved Then
                sep_Approver.Visible = False
                btnCancel.Visible = False
                btnNew.Visible = False
                btnSave.Visible = False
                btnDelete.Visible = False
                btnEdit.Visible = False
                btnFind.Visible = False
                btnList.Visible = False
                ToolStripSeparator1.Visible = False

                btnApprove.Visible = True
                btnReject.Visible = True
            ElseIf StatusID_Trans = Status.SURVEY_Rejected OrElse StatusID_Trans = Status.Draft OrElse StatusTrans = TransStatus.NewStatus Then
                sep_Approver.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False

                'btnNew.Visible = True
                'btnFind.Visible = True
                btnNew.Visible = False
                btnFind.Visible = False
                btnList.Visible = False
                ToolStripSeparator1.Visible = False

                btnCancel.Visible = True
                btnSave.Visible = True
                btnDelete.Visible = True
                btnEdit.Visible = True

                Select Case StatusTrans
                    Case TransStatus.NewStatus, TransStatus.EditStatus, TransStatus.FindStatus
                        btnCancel.Enabled = True
                        btnSave.Enabled = True
                        btnNew.Enabled = False
                        btnEdit.Enabled = False
                        btnDelete.Enabled = False
                        btnFind.Enabled = False
                    Case Else
                        btnCancel.Enabled = False
                        btnSave.Enabled = False
                        btnNew.Enabled = True
                        btnEdit.Enabled = True
                        btnDelete.Enabled = True
                        btnFind.Enabled = True
                End Select
            End If
        Else
            sep_Approver.Visible = False
            btnCancel.Visible = False
            btnNew.Visible = False
            btnSave.Visible = False
            btnDelete.Visible = False
            btnEdit.Visible = False
            btnFind.Visible = False
            btnList.Visible = False
            ToolStripSeparator1.Visible = False
            btnApprove.Visible = False
            btnReject.Visible = False
        End If
    End Sub

    Public Sub FillDataToUI(ByVal dtDataLoaded As DataTable)
        If dtDataLoaded.Rows.Count > 0 Then
            With dtDataLoaded.Rows(0)
                StatusID_Trans = .Item(Fields.SURH_Status).ToString.Trim

                txtSurveyNo.Text = .Item(Fields.SURH_SurveyNo).ToString.Trim
                dtpSurveyDate.Value = .Item(Fields.SURH_SurveyDate)
                dtpOnSite.Value = .Item(Fields.SURH_SurveySiteDate)
                txtCust.Text = .Item(Fields.SURH_CustID).ToString.Trim
                FillCustomerData()
                txtCustHP.Text = .Item(Fields.SURH_CustHP).ToString.Trim
                txtMeetWith.Text = .Item(Fields.SURH_MeetWith).ToString.Trim
                txtSurveyorID.Text = .Item(Fields.SURH_SurveyorID).ToString.Trim
                FillSurveyorData()
                txtMarketingID.Text = .Item(Fields.SURH_MarketingID).ToString.Trim
                FillMarketingData()
                txtSPK.Text = .Item(Fields.SURH_SPKNo).ToString.Trim
                txtPICName.Text = .Item(Fields.SURH_PenanggungProject).ToString.Trim
                txtPIC_HP.Text = .Item(Fields.SURH_PenanggungProjectHP).ToString.Trim
                txtRemark.Text = .Item(Fields.SURH_Remark).ToString.Trim
                lbl_status.Text = GetStatus(StatusID_Trans)

                FillDetailData()
            End With
        End If
    End Sub

    Private Sub FillDetailData()
        Dim dtData As New DataTable
        Dim drDetail As DataRow
        Dim i As Integer

        SetDetailColumn()
        RetrieveDetailData(dtData)

        For i = 0 To dtData.Rows.Count - 1
            With dtData.Rows(i)
                drDetail = dtDetail.NewRow
                drDetail.Item(Fields.SURD_ItemID) = .Item(Fields.SURD_ItemID).ToString.Trim
                drDetail.Item(Fields.SURD_ItemQty) = .Item(Fields.SURD_ItemQty)
                drDetail.Item(Fields.SURD_ItemRemark) = .Item(Fields.SURD_ItemRemark).ToString.Trim
                drDetail.Item(Fields.SURD_ItemUOM) = .Item(Fields.SURD_ItemUOM).ToString.Trim
                drDetail.Item(Fields.Item_Type) = .Item(Fields.Item_Type).ToString.Trim
                drDetail.Item(Fields.Item_Category) = .Item(Fields.Item_Category).ToString.Trim
                drDetail.Item(Fields.SURD_ItemComponent) = .Item(Fields.SURD_ItemComponent).ToString.Trim
                dtDetail.Rows.Add(drDetail)
            End With
        Next

        RetrieveComponentCategoryExists(dtComponent)
        ReloadGridDetail()
    End Sub

    Private Sub FillItemData()
        Dim dtItem As New DataTable

        MD.RetrieveItemByKey(dtItem, txtItemID.Text.Trim)
        If dtItem.Rows.Count > 0 Then
            With dtItem.Rows(0)
                txtItemName.Text = .Item(Fields.Item_Name)
                txtUOM.Text = .Item(Fields.Item_UOM)
                txtType.Text = .Item(Fields.Item_Type)

                If .Item(Fields.SURH_Manifold) = "Y" Then
                    txtCategory.Text = "Manifold"
                ElseIf .Item(Fields.SURH_Pipe) = "Y" Then
                    txtCategory.Text = "Pipe of Kitchen"
                ElseIf .Item(Fields.SURH_TitikApi) = "Y" Then
                    txtCategory.Text = "Titik Api"
                ElseIf .Item(Fields.SURH_Supporting) = "Y" Then
                    txtCategory.Text = "Supporting Material"
                End If
            End With
        Else
            txtItemName.Text = String.Empty
            txtUOM.Text = String.Empty
            txtCategory.Text = String.Empty
            txtType.Text = String.Empty
        End If
    End Sub

    Private Sub FillMarketingData()
        Dim dtMar As New DataTable

        MD.RetrieveEmployeeMarketing_ByID(dtMar, txtMarketingID.Text.Trim)
        If dtMar.Rows.Count > 0 Then
            With dtMar.Rows(0)
                txtMarketingName.Text = .Item(Fields.EmployeeName).ToString.Trim
            End With
        Else
            txtMarketingName.Text = String.Empty
        End If
    End Sub

    Private Sub FillSurveyorData()
        Dim dtSurv As New DataTable

        MD.RetrieveEmployeeSurveyor_ByID(dtSurv, txtSurveyorID.Text.Trim)
        If dtSurv.Rows.Count > 0 Then
            With dtSurv.Rows(0)
                txtSurveyorName.Text = .Item(Fields.EmployeeName).ToString.Trim
            End With
        Else
            txtSurveyorName.Text = String.Empty
        End If
    End Sub

    Private Sub FillCustomerData()
        Dim dtCust As New DataTable
        Dim CustID As String

        If txtCust.Text.Trim = String.Empty Then
            CustID = "-"
        Else
            CustID = txtCust.Text.Trim
        End If
        MD.RetrieveCustomerByKey(dtCust, CustID)
        If dtCust.Rows.Count > 0 Then
            With dtCust.Rows(0)
                txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
            End With
        Else
            txtCustName.Text = String.Empty
        End If
    End Sub

    Public Sub NewState()
        ClearInput()
        EnableInput()
        SetDetailInput(False)
        SetToolbox()

        txtSurveyNo.Text = "NEW"
        lbl_status.Text = Status.Draft
    End Sub

    Private Sub EditState()
        EnableInput()
        SetDetailInput(False)
        SetToolbox()
    End Sub

    Private Sub EnableInput(Optional ByVal Boo As Boolean = True)
        dtpSurveyDate.Enabled = Boo
        dtpOnSite.Enabled = Boo
        txtSurveyorID.ReadOnly = Not Boo
        txtMarketingID.ReadOnly = Not Boo
        txtCust.ReadOnly = Not Boo
        txtCustHP.ReadOnly = Not Boo
        txtRemark.ReadOnly = Not Boo
        txtMeetWith.ReadOnly = Not Boo
        txtPICName.ReadOnly = Not Boo
        txtPIC_HP.ReadOnly = Not Boo
        txtSPK.ReadOnly = Not Boo
        btnmanifold.Enabled = Boo
        btnPipeToKitchen.Enabled = Boo
        btnSupporting.Enabled = Boo
        btnTitikApi.Enabled = Boo

        If Boo Then
            txtCust.BackColor = Color.Empty
            txtCustHP.BackColor = Color.Empty
            txtRemark.BackColor = Color.Empty
            txtPICName.BackColor = Color.Empty
            txtPIC_HP.BackColor = Color.Empty
            txtSPK.BackColor = Color.Empty
            txtMeetWith.BackColor = Color.Empty
            txtSurveyorID.BackColor = Color.Empty
            txtMarketingID.BackColor = Color.Empty
        Else
            txtCust.BackColor = Color.LightGray
            txtCustHP.BackColor = Color.LightGray
            txtRemark.BackColor = Color.LightGray
            txtPICName.BackColor = Color.LightGray
            txtPIC_HP.BackColor = Color.LightGray
            txtSPK.BackColor = Color.LightGray
            txtMeetWith.BackColor = Color.LightGray
            txtSurveyorID.BackColor = Color.LightGray
            txtMarketingID.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub InitHeader()
        txtSurveyNo.Text = String.Empty
        dtpSurveyDate.Value = Now
        txtCust.Text = String.Empty
        txtCustName.Text = String.Empty
        txtRemark.Text = String.Empty
        txtSPK.Text = String.Empty
        txtSurveyorID.Text = String.Empty
        txtSurveyorName.Text = String.Empty
        txtMarketingID.Text = String.Empty
        txtMarketingName.Text = String.Empty
        txtMeetWith.Text = String.Empty
        txtPICName.Text = String.Empty
        txtPIC_HP.Text = String.Empty
        txtCustHP.Text = String.Empty
    End Sub

    Private Sub InitDetailInput()
        txtItemID.Text = String.Empty
        txtItemName.Text = String.Empty
        txtUOM.Text = String.Empty
        txtQty.Text = String.Empty
        txtRemarkD.Text = String.Empty
        txtSeqNum.Text = String.Empty
        txtCategory.Text = String.Empty
        txtItemComponent.Text = String.Empty
        txtType.Text = String.Empty

        txtItemID.BackColor = Color.LightGray
        txtItemName.BackColor = Color.LightGray
        txtUOM.BackColor = Color.LightGray
        txtQty.BackColor = Color.LightGray
        txtRemarkD.BackColor = Color.LightGray
        txtCategory.BackColor = Color.LightGray
        txtItemComponent.BackColor = Color.LightGray
        txtType.BackColor = Color.LightGray

        initComponent()
    End Sub

    Private Sub ClearInput()
        InitHeader()
        InitDetailInput()
        SetDetailColumn()
        gvDetail.Rows.Clear()
    End Sub

    Private Sub LoadFirstData()
        Dim dtData As New DataTable

        ClearInput()
        RetrieveFirstData(dtData)
        FillDataToUI(dtData)
        EnableInput(False)
        SetDetailInput()
    End Sub

    Private Sub LoadLastData()
        Dim dtData As New DataTable

        ClearInput()
        RetrieveLastData(dtData)
        FillDataToUI(dtData)
        EnableInput(False)
        SetDetailInput()
    End Sub

    Private Sub SetDetailInput(Optional ByVal EnableInput As Boolean = False)
        txtItemID.ReadOnly = Not EnableInput
        txtQty.ReadOnly = Not EnableInput
        txtRemarkD.ReadOnly = Not EnableInput

        txtItemName.ReadOnly = True
        txtUOM.ReadOnly = True
        txtCategory.ReadOnly = True
        txtType.ReadOnly = True
        txtItemName.BackColor = Color.LightGray
        txtUOM.BackColor = Color.LightGray
        txtCategory.BackColor = Color.LightGray
        txtType.BackColor = Color.LightGray

        If Not EnableInput Then
            txtItemID.BackColor = Color.LightGray
            txtRemarkD.BackColor = Color.LightGray
            txtQty.BackColor = Color.LightGray
        Else
            txtItemID.BackColor = Color.Empty
            txtRemarkD.BackColor = Color.Empty
            txtQty.BackColor = Color.Empty
        End If
    End Sub

    Private Function CekSave(Optional ByVal isNew As Boolean = True) As Boolean
        Dim hasil As Boolean

        hasil = True
        hasil = CekHeader(isNew)
        If hasil Then
            hasil = CekDetail()
        End If

        Return hasil
    End Function

    Private Function CekDetail() As Boolean
        Dim ctr As Integer = 0
        Dim i As Integer
        Dim str As String = String.Empty
        Dim strTemp As String = String.Empty
        Dim dtTemp As New DataTable

        If dtDetail.Rows.Count = 0 Then
            MessageBox.Show("Item Survey is empty.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CekDetail = False
            Return False
        End If
        'Cek masing-masing detail untuk hal-hal berikut
        If gvDetail.Rows.Count > 0 Then
            For i = 0 To gvDetail.Rows.Count - 1
                'Cek ItemID
                strTemp = gvDetail.Rows(i).Cells(0).Value
                MD.RetrieveItemByKey(dtTemp, strTemp)
                If dtTemp.Rows.Count = 0 Then
                    ctr += 1
                    str &= ctr.ToString & ") Item ID '" & strTemp & "' cannot be found in database." & vbCrLf
                End If

                'Cek Qty
                strTemp = gvDetail.Rows(i).Cells(3).Value
                If strTemp = String.Empty OrElse Not IsNumeric(strTemp) Then
                    ctr += 1
                    str &= ctr.ToString & ") Please input a valid value of quantity for Item '" & gvDetail.Rows(i).Cells(0).Value & "'." & vbCrLf
                End If
            Next
        End If

        If ctr > 0 Then
            MessageBox.Show("Please check for these error(s) : " & vbCrLf & str, "Validating Data")
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CekHeader(Optional ByVal isNew As Boolean = True) As Boolean
        Dim ctr As Integer = 0
        Dim dtTemp As New DataTable
        Dim str As String = String.Empty

        TD.RetrieveSurveyHeaderByKey(dtTemp, txtSurveyNo.Text.Trim)
        If Not isNew Then
            'Cek apakah nomor tersebut ada dan aktif di database
            If dtTemp.Rows.Count = 0 Then
                ctr += 1
                str &= ctr.ToString & ") This Survey# is not exists in database." & vbCrLf
            End If
        Else
            If dtTemp.Rows.Count > 0 Then
                ctr += 1
                str &= ctr.ToString & ") This Survey# has been exists in database." & vbCrLf
            End If
        End If

        'Cek Customer
        MD.RetrieveCustomerByKey(dtTemp, txtCust.Text.Trim)
        If dtTemp.Rows.Count = 0 Then
            ctr += 1
            str &= ctr.ToString & ") Customer ID '" & txtCust.Text.Trim & "' cannot be found in database." & vbCrLf
        End If

        'Cek Surveyor
        dtTemp = New DataTable
        MD.RetrieveSurveyorByKey(dtTemp, txtSurveyorID.Text.Trim)
        If dtTemp.Rows.Count = 0 Then
            ctr += 1
            str &= ctr.ToString & ") Employee ID '" & txtSurveyorID.Text.Trim & "' cannot be found in database or is not a surveyor." & vbCrLf
        End If

        'Cek Marketing
        dtTemp = New DataTable
        MD.RetrieveEmployeeMarketing_ByID(dtTemp, txtMarketingID.Text.Trim)
        If dtTemp.Rows.Count = 0 Then
            ctr += 1
            str &= ctr.ToString & ") Employee ID '" & txtMarketingID.Text.Trim & "' cannot be found in database or is not a Marketing." & vbCrLf
        End If

        If ctr > 0 Then
            MessageBox.Show("Please check for these error(s) : " & vbCrLf & str, "Validating Data")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub RejectData()
        If RejectSurveyData() Then
            MessageBox.Show("Data (Survey# " & txtSurveyNo.Text.Trim & ") has been rejected and sent to " & Hirarki.SURVEY_Rejected & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ApproveData()
        If ApproveSurveyData() Then
            MessageBox.Show("Data (Survey# " & txtSurveyNo.Text.Trim & ") has been approved and sent to " & Hirarki.SURVEY_Approved & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function UpdateData() As Boolean
        UpdateData = UpdateSurveyHeader()

        If UpdateData Then
            MessageBox.Show("Survey# " & txtSurveyNo.Text.Trim & " has been submitted to " & Hirarki.SURVEY_Saved & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function
#End Region
#Region "Database Access"
    Private Function DeleteSurvey() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Trans As SqlTransaction

        DeleteSurvey = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()
        Trans = Conn.BeginTransaction

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            'Delete seluruh data awal
            Cmd.CommandText = "exec sp_Delete_Trans_Survey_Dtl_BySurveyNo_AF '" & txtSurveyNo.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "exec sp_Delete_Trans_Survey_Hdr '" & txtSurveyNo.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            Trans.Commit()
            DeleteSurvey = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function InsertSurveyDetail(ByRef strQuery As String) As Boolean
        Dim Query As String = String.Empty
        Dim queryParam As String = String.Empty
        Dim i As Integer

        InsertSurveyDetail = False
        Try
            'Delete seluruh data awal
            strQuery = "exec sp_Delete_Trans_Survey_Dtl_BySurveyNo '" & txtSurveyNo.Text.Trim & "' "

            'Insert seluruh data baru
            For i = 0 To gvDetail.Rows.Count - 1
                Query &= "exec sp_Insert_Trans_Survey_Dtl "
                With gvDetail.Rows(i)
                    queryParam = "'" & txtSurveyNo.Text.Trim & "', " & i & ", '" & .Cells(0).Value & "', " & _
                                 "'" & .Cells(2).Value & "', " & .Cells(3).Value & ", '" & .Cells(4).Value & "', '" & .Cells(5).Value & "', '" & .Cells(6).Value & "', '" & .Cells(7).Value & "', '" & userlog.UserName & "' "
                End With

                strQuery &= Query & queryParam
                Query = ""
            Next

            InsertSurveyDetail = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function UpdateSurveyHeader() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction
        Dim detQuery As String = String.Empty

        UpdateSurveyHeader = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            If InsertSurveyDetail(detQuery) Then
                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Trans

                Query = "exec sp_Update_Trans_Survey_Hdr "
                queryParam = "'" & txtSurveyNo.Text.Trim & "', '" & Format(dtpSurveyDate.Value, "MM/dd/yyyy") & "', '" & txtCust.Text.Trim & "', '" & txtCustHP.Text.Trim & "', " & _
                             "'" & txtRemark.Text.Trim & "', '" & txtSurveyorID.Text.Trim & "', '" & txtMarketingID.Text.Trim & "', '" & Format(dtpOnSite.Value, "MM/dd/yyyy") & "', '" & txtSPK.Text.Trim & "', " & _
                             "'" & txtMeetWith.Text.Trim & "', '" & txtPICName.Text.Trim & "', '" & txtPIC_HP.Text.Trim & "', " & _
                             "'" & IIf(chkManifold.Checked, "Y", "N") & "', '" & IIf(chkPipe.Checked, "Y", "N") & "', '" & IIf(chkTitik.Checked, "Y", "N") & "', '" & IIf(chkSupporting.Checked, "Y", "N") & "', " & _
                             "'" & Status.SURVEY_Saved & "', '" & userlog.UserName & "'"

                Cmd.CommandText = detQuery & Query & queryParam
                Cmd.ExecuteNonQuery()

                UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Saved, userlog.UserName, "3") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Saved, GetDocCreator(txtSurveyNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir       
                InserttoInbox(txtSurveyNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", Status.SURVEY_Saved) 'Insert to NEXT APPROVAL

                Insert_Trans_History(txtSurveyNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

                Trans.Commit()
                UpdateSurveyHeader = True
            Else
                Trans.Rollback()
            End If
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function RejectSurveyData() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction

        RejectSurveyData = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_Survey_Hdr_TM "
            queryParam = "'" & txtSurveyNo.Text.Trim & "', '" & alasanReject & "', '" & Status.SURVEY_Rejected & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Rejected, GetDocCreator(txtSurveyNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Rejected, userlog.UserName, "3")
            InserttoInbox(txtSurveyNo.Text.Trim, userlog.UserName, GetDocCreator(txtSurveyNo.Text.Trim), "W", "Y", Status.SURVEY_Rejected) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txtSurveyNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

            Trans.Commit()
            RejectSurveyData = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function ApproveSurveyData() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction

        ApproveSurveyData = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_Survey_Hdr_TM "
            queryParam = "'" & txtSurveyNo.Text.Trim & "', '', '" & Status.SURVEY_Approved & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Approved, GetDocCreator(txtSurveyNo.Text.Trim), "2") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txtSurveyNo.Text.Trim, Status.SURVEY_Approved, userlog.UserName, "3") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            'InserttoInbox(txtSurveyNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", Status.SURVEY_Approved) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txtSurveyNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

            Trans.Commit()
            ApproveSurveyData = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub RetrieveFirstData(ByRef dtDataForUI As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Hdr_First"
            DA.SelectCommand = Cmd

            DA.Fill(dtDataForUI)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub RetrieveLastData(ByRef dtDataForUI As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Hdr_Last"
            DA.SelectCommand = Cmd

            DA.Fill(dtDataForUI)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub RetrieveDetailData(ByRef dtDataForUI As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Dtl_BySurveyNo_Active '" & txtSurveyNo.Text.Trim & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtTemp)
            dtDataForUI = dtTemp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub RetrieveComponentCategoryExists(ByRef dtDataComponent As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Dtl_CategoryComponent '" & txtSurveyNo.Text.Trim & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtTemp)
            dtDataComponent = dtTemp
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
#End Region

    Private Sub btnManifold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManifold.Click
        Dim frmFind As New dlgSurveyItem
        Dim dtData As New DataTable
        Dim i, z As Integer
        Dim ind As Integer
        Dim ID As String
        Dim Str As String = ""
        Dim x As Boolean = False
        Dim xAdd As Boolean = False

        'If chkManifold.Checked AndAlso StatusTrans = TransStatus.EditStatus Then
        If StatusTrans = TransStatus.EditStatus Then
            frmFind.Init("Manifold", dtComponent)
            frmFind.ShowDialog()

            chkManifold.Checked = False
            'Delete dulu seluruh internal table Component dengan category manifold.
            i = dtComponent.Rows.Count - 1
            While i >= 0
                If dtComponent.Rows(i).Item(0).ToString.Trim = "Manifold" Then
                    dtComponent.Rows(i).Delete()
                End If

                i -= 1
            End While

            If frmFind.clstComponent.CheckedItems.Count <> 0 Then
                'Cek apakah ok, category dan Item Component sesuai.
                For z = 0 To frmFind.clstComponent.Items.Count - 1
                    x = False
                    ind = InStr(frmFind.clstComponent.Items.Item(z).ToString, "-")
                    ID = Mid(frmFind.clstComponent.Items.Item(z).ToString, ind + 2, Len(frmFind.clstComponent.Items.Item(z).ToString) - ind)

                    For i = 0 To frmFind.clstComponent.CheckedItems.Count - 1
                        If Mid(frmFind.clstComponent.CheckedItems.Item(i).ToString, ind + 2, Len(frmFind.clstComponent.CheckedItems.Item(i).ToString) - ind) = ID Then
                            x = True
                            Exit For
                        End If
                    Next

                    If x Then
                        MD.RetrieveItemKomponent_ByCategoryAndID(dtData, "Manifold", ID)
                        If dtData.Rows.Count <> 0 Then
                            chkManifold.Checked = True
                            xAdd = True

                            'Cek dulu, apakah di dalam grid sudah ada yang ber-category yang sama, jika sudah ada maka tidak boleh nambah.
                            For i = 0 To gvDetail.RowCount - 1
                                If gvDetail.Rows(i).Cells(5).Value = "Manifold" AndAlso gvDetail.Rows(i).Cells(6).Value = ID Then
                                    xAdd = False
                                    Exit For
                                End If
                            Next


                            'Tambahkan ke internal table Component
                            Dim drComponent As DataRow
                            drComponent = dtComponent.NewRow
                            With drComponent
                                .Item(0) = "Manifold"
                                .Item(1) = ID
                            End With
                            dtComponent.Rows.Add(drComponent)

                            If xAdd Then
                                ReinsertDetail("Manifold", ID)
                            End If
                        Else
                            If Str.Trim <> String.Empty Then Str &= ", "
                            Str &= ID
                        End If
                    Else
                        Dim drDetail As DataRow

                        i = dtDetail.Rows.Count - 1
                        While i >= 0
                            drDetail = dtDetail.Rows(i)

                            With drDetail
                                If .Item(Fields.Item_Category) = "Manifold" AndAlso .Item(Fields.SURD_ItemComponent).ToString.Trim = ID Then
                                    drDetail.Delete()
                                End If
                            End With

                            i -= 1
                        End While
                    End If
                Next

                If Str.Trim <> String.Empty Then
                    MessageBox.Show("These Component ID [" & Str & "] is not alocated for Category Manifold.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ReloadGridDetail()
                End If
            Else
                i = dtDetail.Rows.Count - 1
                While i >= 0
                    With dtDetail.Rows(i)
                        If .Item(Fields.Item_Category) = "Manifold" Then
                            dtDetail.Rows(i).Delete()
                        End If
                    End With

                    i -= 1
                End While

                ReloadGridDetail()
            End If
        End If
    End Sub

    Private Sub btnPipeToKitchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPipeToKitchen.Click
        Dim frmFind As New dlgSurveyItem
        Dim dtData As New DataTable
        Dim i, z As Integer
        Dim ind As Integer
        Dim ID As String
        Dim Str As String = ""
        Dim x As Boolean = False
        Dim xAdd As Boolean = False

        'If chkManifold.Checked AndAlso StatusTrans = TransStatus.EditStatus Then
        If StatusTrans = TransStatus.EditStatus Then
            frmFind.Init("Pipe To Kitchen", dtComponent)
            frmFind.ShowDialog()

            chkPipe.Checked = False
            'Delete dulu seluruh internal table Component dengan category manifold.
            i = dtComponent.Rows.Count - 1
            While i >= 0
                If dtComponent.Rows(i).Item(0).ToString.Trim = "Pipe To Kitchen" Then
                    dtComponent.Rows(i).Delete()
                End If

                i -= 1
            End While

            If frmFind.clstComponent.CheckedItems.Count <> 0 Then
                'Cek apakah ok, category dan Item Component sesuai.
                For z = 0 To frmFind.clstComponent.Items.Count - 1
                    x = False
                    ind = InStr(frmFind.clstComponent.Items.Item(z).ToString, "-")
                    ID = Mid(frmFind.clstComponent.Items.Item(z).ToString, ind + 2, Len(frmFind.clstComponent.Items.Item(z).ToString) - ind)

                    For i = 0 To frmFind.clstComponent.CheckedItems.Count - 1
                        If Mid(frmFind.clstComponent.CheckedItems.Item(i).ToString, ind + 2, Len(frmFind.clstComponent.CheckedItems.Item(i).ToString) - ind) = ID Then
                            x = True
                            Exit For
                        End If
                    Next

                    If x Then
                        MD.RetrieveItemKomponent_ByCategoryAndID(dtData, "Pipe To Kitchen", ID)
                        If dtData.Rows.Count <> 0 Then
                            chkPipe.Checked = True
                            xAdd = True

                            'Cek dulu, apakah di dalam grid sudah ada yang ber-category yang sama, jika sudah ada maka tidak boleh nambah.
                            For i = 0 To gvDetail.RowCount - 1
                                If gvDetail.Rows(i).Cells(5).Value = "Pipe To Kitchen" AndAlso gvDetail.Rows(i).Cells(6).Value = ID Then
                                    xAdd = False
                                    Exit For
                                End If
                            Next


                            'Tambahkan ke internal table Component
                            Dim drComponent As DataRow
                            drComponent = dtComponent.NewRow
                            With drComponent
                                .Item(0) = "Pipe To Kitchen"
                                .Item(1) = ID
                            End With
                            dtComponent.Rows.Add(drComponent)

                            If xAdd Then
                                ReinsertDetail("Pipe To Kitchen", ID)
                            End If
                        Else
                            If Str.Trim <> String.Empty Then Str &= ", "
                            Str &= ID
                        End If
                    Else
                        Dim drDetail As DataRow

                        i = dtDetail.Rows.Count - 1
                        While i >= 0
                            drDetail = dtDetail.Rows(i)

                            With drDetail
                                If .Item(Fields.Item_Category) = "Pipe To Kitchen" AndAlso .Item(Fields.SURD_ItemComponent).ToString.Trim = ID Then
                                    drDetail.Delete()
                                End If
                            End With

                            i -= 1
                        End While
                    End If
                Next

                If Str.Trim <> String.Empty Then
                    MessageBox.Show("These Component ID [" & Str & "] is not alocated for Category Pipe To Kitchen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ReloadGridDetail()
                End If
            Else
                i = dtDetail.Rows.Count - 1
                While i >= 0
                    With dtDetail.Rows(i)
                        If .Item(Fields.Item_Category) = "Manifold" Then
                            dtDetail.Rows(i).Delete()
                        End If
                    End With

                    i -= 1
                End While

                ReloadGridDetail()
            End If
        End If
    End Sub

    Private Sub btnTitikApi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTitikApi.Click
        Dim frmFind As New dlgSurveyItem
        Dim dtData As New DataTable
        Dim i, z As Integer
        Dim ind As Integer
        Dim ID As String
        Dim Str As String = ""
        Dim x As Boolean = False
        Dim xAdd As Boolean = False

        'If chkManifold.Checked AndAlso StatusTrans = TransStatus.EditStatus Then
        If StatusTrans = TransStatus.EditStatus Then
            frmFind.Init("Titik Api", dtComponent)
            frmFind.ShowDialog()

            chkTitik.Checked = False
            'Delete dulu seluruh internal table Component dengan category manifold.
            i = dtComponent.Rows.Count - 1
            While i >= 0
                If dtComponent.Rows(i).Item(0).ToString.Trim = "Titik Api" Then
                    dtComponent.Rows(i).Delete()
                End If

                i -= 1
            End While

            If frmFind.clstComponent.CheckedItems.Count <> 0 Then
                'Cek apakah ok, category dan Item Component sesuai.
                For z = 0 To frmFind.clstComponent.Items.Count - 1
                    x = False
                    ind = InStr(frmFind.clstComponent.Items.Item(z).ToString, "-")
                    ID = Mid(frmFind.clstComponent.Items.Item(z).ToString, ind + 2, Len(frmFind.clstComponent.Items.Item(z).ToString) - ind)

                    For i = 0 To frmFind.clstComponent.CheckedItems.Count - 1
                        If Mid(frmFind.clstComponent.CheckedItems.Item(i).ToString, ind + 2, Len(frmFind.clstComponent.CheckedItems.Item(i).ToString) - ind) = ID Then
                            x = True
                            Exit For
                        End If
                    Next

                    If x Then
                        MD.RetrieveItemKomponent_ByCategoryAndID(dtData, "Titik Api", ID)
                        If dtData.Rows.Count <> 0 Then
                            chkTitik.Checked = True
                            xAdd = True

                            'Cek dulu, apakah di dalam grid sudah ada yang ber-category yang sama, jika sudah ada maka tidak boleh nambah.
                            For i = 0 To gvDetail.RowCount - 1
                                If gvDetail.Rows(i).Cells(5).Value = "Titik Api" AndAlso gvDetail.Rows(i).Cells(6).Value = ID Then
                                    xAdd = False
                                    Exit For
                                End If
                            Next


                            'Tambahkan ke internal table Component
                            Dim drComponent As DataRow
                            drComponent = dtComponent.NewRow
                            With drComponent
                                .Item(0) = "Titik Api"
                                .Item(1) = ID
                            End With
                            dtComponent.Rows.Add(drComponent)

                            If xAdd Then
                                ReinsertDetail("Titik Api", ID)
                            End If
                        Else
                            If Str.Trim <> String.Empty Then Str &= ", "
                            Str &= ID
                        End If
                    Else
                        Dim drDetail As DataRow

                        i = dtDetail.Rows.Count - 1
                        While i >= 0
                            drDetail = dtDetail.Rows(i)

                            With drDetail
                                If .Item(Fields.Item_Category) = "Titik Api" AndAlso .Item(Fields.SURD_ItemComponent).ToString.Trim = ID Then
                                    drDetail.Delete()
                                End If
                            End With

                            i -= 1
                        End While
                    End If
                Next

                If Str.Trim <> String.Empty Then
                    MessageBox.Show("These Component ID [" & Str & "] is not alocated for Category Titik Api.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ReloadGridDetail()
                End If
            Else
                i = dtDetail.Rows.Count - 1
                While i >= 0
                    With dtDetail.Rows(i)
                        If .Item(Fields.Item_Category) = "Titik Api" Then
                            dtDetail.Rows(i).Delete()
                        End If
                    End With

                    i -= 1
                End While

                ReloadGridDetail()
            End If
        End If
    End Sub

    Private Sub btnSupporting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupporting.Click
        Dim frmFind As New dlgSurveyItem
        Dim dtData As New DataTable
        Dim i, z As Integer
        Dim ind As Integer
        Dim ID As String
        Dim Str As String = ""
        Dim x As Boolean = False
        Dim xAdd As Boolean = False

        'If chkManifold.Checked AndAlso StatusTrans = TransStatus.EditStatus Then
        If StatusTrans = TransStatus.EditStatus Then
            frmFind.Init("Supporting Material", dtComponent)
            frmFind.ShowDialog()

            chkSupporting.Checked = False
            'Delete dulu seluruh internal table Component dengan category manifold.
            i = dtComponent.Rows.Count - 1
            While i >= 0
                If dtComponent.Rows(i).Item(0).ToString.Trim = "Supporting Material" Then
                    dtComponent.Rows(i).Delete()
                End If

                i -= 1
            End While

            If frmFind.clstComponent.CheckedItems.Count <> 0 Then
                'Cek apakah ok, category dan Item Component sesuai.
                For z = 0 To frmFind.clstComponent.Items.Count - 1
                    x = False
                    ind = InStr(frmFind.clstComponent.Items.Item(z).ToString, "-")
                    ID = Mid(frmFind.clstComponent.Items.Item(z).ToString, ind + 2, Len(frmFind.clstComponent.Items.Item(z).ToString) - ind)

                    For i = 0 To frmFind.clstComponent.CheckedItems.Count - 1
                        If Mid(frmFind.clstComponent.CheckedItems.Item(i).ToString, ind + 2, Len(frmFind.clstComponent.CheckedItems.Item(i).ToString) - ind) = ID Then
                            x = True
                            Exit For
                        End If
                    Next

                    If x Then
                        MD.RetrieveItemKomponent_ByCategoryAndID(dtData, "Supporting Material", ID)
                        If dtData.Rows.Count <> 0 Then
                            chkSupporting.Checked = True
                            xAdd = True

                            'Cek dulu, apakah di dalam grid sudah ada yang ber-category yang sama, jika sudah ada maka tidak boleh nambah.
                            For i = 0 To gvDetail.RowCount - 1
                                If gvDetail.Rows(i).Cells(5).Value = "Supporting Material" AndAlso gvDetail.Rows(i).Cells(6).Value = ID Then
                                    xAdd = False
                                    Exit For
                                End If
                            Next


                            'Tambahkan ke internal table Component
                            Dim drComponent As DataRow
                            drComponent = dtComponent.NewRow
                            With drComponent
                                .Item(0) = "Supporting Material"
                                .Item(1) = ID
                            End With
                            dtComponent.Rows.Add(drComponent)

                            If xAdd Then
                                ReinsertDetail("Supporting Material", ID)
                            End If
                        Else
                            If Str.Trim <> String.Empty Then Str &= ", "
                            Str &= ID
                        End If
                    Else
                        Dim drDetail As DataRow

                        i = dtDetail.Rows.Count - 1
                        While i >= 0
                            drDetail = dtDetail.Rows(i)

                            With drDetail
                                If .Item(Fields.Item_Category) = "Supporting Material" AndAlso .Item(Fields.SURD_ItemComponent).ToString.Trim = ID Then
                                    drDetail.Delete()
                                End If
                            End With

                            i -= 1
                        End While
                    End If
                Next

                If Str.Trim <> String.Empty Then
                    MessageBox.Show("These Component ID [" & Str & "] is not alocated for Category Supporting Material.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ReloadGridDetail()
                End If
            Else
                i = dtDetail.Rows.Count - 1
                While i >= 0
                    With dtDetail.Rows(i)
                        If .Item(Fields.Item_Category) = "Supporting Material" Then
                            dtDetail.Rows(i).Delete()
                        End If
                    End With

                    i -= 1
                End While

                ReloadGridDetail()
            End If
        End If
    End Sub
End Class