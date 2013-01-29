'(29 Des 2012) remodified create journal

Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPengembalianBarang
    Public TransNo As String

    Dim StatusTrans As String
    Dim StatusTransDtl As String
    Dim dtDetail As DataTable
    Dim TD As New TransData
    Dim MD As New MasterData
    Dim BackToView As Boolean
    Dim IDStatus As String
    Dim RefNo As String
    Dim frmReason As New frm_reason
    Dim alasanReject As String

    Private Sub frmPengembalianBarang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If StatusTrans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Dim frmChild As New frmPengembalianBarang_View

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmPengembalianBarang_View" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
    End Sub

    Private Sub frmPengembalianBarang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnNew.Visible = False
        StatusTransDtl = TransStatus.NoStatus
        BackToView = False
        RefNo = String.Empty

        If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
            If TransNo.Trim = String.Empty Then
                IDStatus = Status.Draft
                NewState()
            Else
                StatusTrans = TransStatus.NoStatus
                txtTransNo.Text = TransNo

                LoadData()
                SetInputHeader()
                SetInputDetail()
                SetToolTip()
                SetButtonDetail()
            End If
        Else
            StatusTrans = TransStatus.NoStatus
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            ClearHeaderInput()
            ClearDetailInput()
            SetToolTip()

            btnEdit.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub SetGridLayout()
        With gDetail
            .Columns(0).Width = 80
            .Columns(1).Width = 180
            .Columns(2).Width = 60
            .Columns(3).Width = 80
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Format = "#,##0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Width = 80
            .Columns(5).Width = 120
            .Columns(6).Width = 100
            .Columns(7).Width = 220
        End With
    End Sub

    Private Sub NewState()
        StatusTrans = TransStatus.NewStatus
        lblStatus.Text = "NEW"

        ClearHeaderInput()
        ClearDetailInput()
        SetColorHeader()
        SetInputHeader()
        SetInputDetail()
        SetToolTip()
        SetButtonDetail()
        SetDetailStructure()
        SetGridLayout()

        dtpTransDate.Focus()
    End Sub

    Private Sub SetDetailStructure()
        dtDetail = New DataTable

        dtDetail.Columns.Clear()
        dtDetail.Columns.Add(Fields.KBD_ItemID, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.Item_Name, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.Item_UOM, System.Type.GetType("System.String"))
        dtDetail.Columns.Add(Fields.KBD_ItemQty, System.Type.GetType("System.Double"))
        dtDetail.Columns.Add(Fields.KBD_Good, System.Type.GetType("System.Int32"))
        dtDetail.Columns.Add(Fields.KBD_RSupplier, System.Type.GetType("System.Int32"))
        dtDetail.Columns.Add(Fields.KBD_RPakai, System.Type.GetType("System.Int32"))
        dtDetail.Columns.Add(Fields.KBD_Remarks, System.Type.GetType("System.String"))
    End Sub

    Private Sub EditState()
        If StatusTrans = TransStatus.NoStatus Then
            StatusTrans = TransStatus.EditStatus

            SetColorHeader()
            SetButtonDetail()
            SetInputHeader()
            SetInputDetail()
            SetToolTip()

            dtpTransDate.Focus()
        End If
    End Sub

    Private Sub ClearHeaderInput()
        txtTransNo.Text = String.Empty
        dtpTransDate.Value = Now
        cboType.SelectedIndex = 0
        txtRefNo.Text = String.Empty
        txtRemarks.Text = String.Empty
    End Sub

    Private Sub ClearDetailInput()
        txtItemID.Text = String.Empty
        txtItemName.Text = String.Empty
        txtItemUOM.Text = String.Empty
        txtItemQty.Text = FormatAngka(0, 0)
        cboItemCondition.SelectedIndex = 0
        txtItemRemarks.Text = String.Empty
    End Sub

    Private Sub SetInputHeader()
        Select Case StatusTrans
            Case TransStatus.NoStatus
                dtpTransDate.Enabled = False
                cboType.Enabled = False
                txtRefNo.ReadOnly = True
                txtRemarks.ReadOnly = True
            Case TransStatus.NewStatus, TransStatus.EditStatus
                dtpTransDate.Enabled = True
                cboType.Enabled = True
                txtRefNo.ReadOnly = False
                txtRemarks.ReadOnly = False
        End Select
    End Sub

    Private Sub SetInputDetail()
        Select Case StatusTransDtl
            Case TransStatus.NoStatus
                txtItemID.ReadOnly = True
                txtItemQty.ReadOnly = True
                cboItemCondition.Enabled = False
                txtItemRemarks.ReadOnly = True
            Case TransStatus.NewStatus
                txtItemID.ReadOnly = False
                txtItemQty.ReadOnly = False
                cboItemCondition.Enabled = True
                txtItemRemarks.ReadOnly = False
            Case TransStatus.EditStatus
                txtItemID.ReadOnly = True
                txtItemQty.ReadOnly = False
                cboItemCondition.Enabled = True
                txtItemRemarks.ReadOnly = False
        End Select
    End Sub

    Private Sub SetColorHeader()
        Select Case StatusTrans
            Case TransStatus.NoStatus
                txtRefNo.BackColor = Color.Empty
                txtRemarks.BackColor = Color.Empty
            Case TransStatus.NewStatus, TransStatus.EditStatus
                txtRefNo.BackColor = Color.LightGoldenrodYellow
                txtRemarks.BackColor = Color.LightGoldenrodYellow
        End Select
    End Sub

    Private Sub SetColorDetail()
        Select Case StatusTransDtl
            Case TransStatus.NoStatus
                txtItemID.BackColor = Color.LightGray
                txtItemQty.BackColor = Color.LightGray
                txtItemRemarks.BackColor = Color.LightGray
            Case TransStatus.NewStatus
                txtItemID.BackColor = Color.LightGoldenrodYellow
                txtItemQty.BackColor = Color.LightGoldenrodYellow
                txtItemRemarks.BackColor = Color.LightGoldenrodYellow
            Case TransStatus.EditStatus
                txtItemID.BackColor = Color.LightGray
                txtItemQty.BackColor = Color.LightGoldenrodYellow
                txtItemRemarks.BackColor = Color.LightGoldenrodYellow
        End Select
    End Sub

    Private Sub SetToolTip()
        If IDStatus = Status.Draft OrElse IDStatus = Status.BK_Rejected Then
            If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                sep_Approver.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False

                btnEdit.Visible = True
                btnSave.Visible = True
                btnDelete.Visible = True
                btnCancel.Visible = True

                Select Case StatusTrans
                    Case TransStatus.NoStatus
                        btnSave.Enabled = False
                        btnCancel.Enabled = False

                        btnEdit.Enabled = True
                        btnDelete.Enabled = True
                    Case TransStatus.NewStatus, TransStatus.EditStatus
                        btnSave.Enabled = True
                        btnCancel.Enabled = True

                        btnEdit.Enabled = False
                        btnDelete.Enabled = False
                End Select
            ElseIf userlog.AccessID = Role.GudangAdmin Then
                sep_Approver.Visible = False
                btnSave.Visible = False
                btnCancel.Visible = False
                btnEdit.Visible = False
                btnDelete.Visible = False

                btnApprove.Visible = True
                btnReject.Visible = True

                btnApprove.Enabled = False
                btnReject.Enabled = False
            Else
                btnSave.Visible = False
                btnEdit.Visible = False
                btnApprove.Visible = False
                btnDelete.Visible = False
                btnCancel.Visible = False
                btnReject.Visible = False
                sep_Approver.Visible = False
            End If
        ElseIf IDStatus = Status.BK_Saved Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnSave.Visible = False
                btnEdit.Visible = False
                btnCancel.Visible = False
                btnDelete.Visible = False
                sep_Approver.Visible = False

                btnApprove.Visible = True
                btnReject.Visible = True

                If StatusTrans = TransStatus.NoStatus Then
                    btnApprove.Enabled = True
                    btnReject.Enabled = True
                Else
                    btnApprove.Enabled = False
                    btnReject.Enabled = False
                End If
            ElseIf userlog.AccessID = Role.ProjectAdmin Then
                btnSave.Visible = True
                btnEdit.Visible = True
                btnCancel.Visible = True
                btnSave.Visible = True

                sep_Approver.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False

                btnDelete.Enabled = False
                btnEdit.Enabled = False
                btnSave.Enabled = False
                btnCancel.Enabled = False
            Else
                btnSave.Visible = False
                btnEdit.Visible = False
                btnApprove.Visible = False
                btnDelete.Visible = False
                btnCancel.Visible = False
                btnReject.Visible = False
                sep_Approver.Visible = False
            End If
        ElseIf IDStatus = Status.BK_Approved Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnSave.Visible = False
                btnEdit.Visible = False
                btnCancel.Visible = False
                btnDelete.Visible = False
                sep_Approver.Visible = False

                btnApprove.Visible = True
                btnReject.Visible = True
                btnApprove.Enabled = False
                btnReject.Enabled = False
            ElseIf userlog.AccessID = Role.ProjectAdmin Then
                btnSave.Visible = True
                btnEdit.Visible = True
                btnCancel.Visible = True
                btnSave.Visible = True

                sep_Approver.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False

                btnDelete.Enabled = False
                btnEdit.Enabled = False
                btnSave.Enabled = False
                btnCancel.Enabled = False
            Else
                btnSave.Visible = False
                btnEdit.Visible = False
                btnApprove.Visible = False
                btnDelete.Visible = False
                btnCancel.Visible = False
                btnReject.Visible = False
                sep_Approver.Visible = False
            End If
        End If
    End Sub

    Private Sub SetButtonDetail()
        Select Case StatusTransDtl
            Case TransStatus.NoStatus
                If StatusTrans = TransStatus.NoStatus Then
                    btnEditDtl.Enabled = False
                    btnDeleteDtl.Enabled = False
                Else
                    btnEditDtl.Enabled = True
                    btnDeleteDtl.Enabled = True
                End If

                btnSaveDtl.Enabled = False
                btnCancelDtl.Enabled = False
            Case TransStatus.NewStatus, TransStatus.EditStatus
                btnEditDtl.Enabled = False
                btnDeleteDtl.Enabled = False

                btnSaveDtl.Enabled = True
                btnCancelDtl.Enabled = True
        End Select
    End Sub

    Private Sub LoadDetailToGrid()
        Dim dtItem As New DataTable
        Dim gDetailRow As DataGridViewRow
        Dim i As Integer

        gDetail.Rows.Clear()
        If dtDetail.Rows.Count <> 0 Then
            For i = 0 To dtDetail.Rows.Count - 1
                With dtDetail.Rows(i)
                    If .RowState <> DataRowState.Deleted Then
                        gDetail.Rows.Insert(gDetail.Rows.Count, 1)
                        gDetailRow = gDetail.Rows(gDetail.Rows.Count - 1)
                        gDetailRow.Cells(0).Value = .Item(Fields.KBD_ItemID).ToString.Trim
                        gDetailRow.Cells(3).Value = .Item(Fields.KBD_ItemQty)
                        gDetailRow.Cells(4).Value = .Item(Fields.KBD_Good)
                        gDetailRow.Cells(5).Value = .Item(Fields.KBD_RSupplier)
                        gDetailRow.Cells(6).Value = .Item(Fields.KBD_RPakai)
                        gDetailRow.Cells(7).Value = .Item(Fields.KBD_Remarks).ToString.Trim

                        MD.RetrieveItemByKey_RegardlessActive(dtItem, .Item(Fields.KBD_ItemID).ToString.Trim)
                        If dtItem.Rows.Count <> 0 Then
                            gDetailRow.Cells(1).Value = dtItem.Rows(0).Item(Fields.Item_Name).ToString.Trim
                            gDetailRow.Cells(2).Value = dtItem.Rows(0).Item(Fields.Item_UOM).ToString.Trim
                        Else
                            gDetailRow.Cells(1).Value = String.Empty
                            gDetailRow.Cells(2).Value = String.Empty
                        End If
                    End If
                    dtItem.Rows.Clear()
                End With
            Next
        End If

        SetGridLayout()
    End Sub

    Private Sub LoadDetail()
        gDetail.Rows.Clear()
        dtDetail = New DataTable
        TD.Retrieve_KembaliBarang_Dtl_ByID(dtDetail, txtTransNo.Text.Trim)
        LoadDetailToGrid()
    End Sub

    Private Sub LoadData()
        Dim dtData As New DataTable

        TD.Retrieve_KembaliBarang_Hdr_ByID(dtData, txtTransNo.Text.Trim)
        If dtData.Rows.Count <> 0 Then
            With dtData.Rows(0)
                dtpTransDate.Value = .Item(Fields.KBH_TransDate)
                txtRemarks.Text = .Item(Fields.KBH_Remarks).ToString.Trim
                txtRefNo.Text = .Item(Fields.KBH_ReferNo).ToString.Trim
                RefNo = txtRefNo.Text
                'Select Case .Item(Fields.KBH_TransType).ToString.Trim
                '    Case "SPK"
                '        cboType.SelectedIndex = 1
                '    Case "Fabrikasi"
                '        cboType.SelectedIndex = 2
                '    Case Else
                '        cboType.SelectedIndex = 0
                'End Select

                'If cboType.SelectedIndex <> 0 Then
                '    txtRefNo.Text = .Item(Fields.KBH_ReferNo).ToString.Trim
                'Else
                '    txtRefNo.Text = String.Empty
                'End If

                IDStatus = .Item(Fields.KBH_Status).ToString.Trim
                lblStatus.Text = GetStatus(IDStatus)
            End With

            LoadDetail()
        Else
            ClearHeaderInput()
            ClearDetailInput()

            MessageBox.Show("Cannot found data Pengembalian Barang with Transaction No. '" & txtTransNo.Text.Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans = TransStatus.NoStatus Then
                EditState()
            End If
        Else
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If StatusTrans = TransStatus.NewStatus Then
            StatusTrans = TransStatus.NoStatus

            BackToView = True
            Me.Close()
        Else
            StatusTrans = TransStatus.NoStatus
            StatusTransDtl = TransStatus.NoStatus

            LoadData()
            SetButtonDetail()
            SetInputHeader()
            SetInputDetail()
            ClearDetailInput()
            SetColorHeader()
            SetColorDetail()
            SetToolTip()
        End If
    End Sub

    Private Sub btnInsertDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If StatusTransDtl = TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.NewStatus

            ClearDetailInput()
            SetColorDetail()
            SetInputDetail()
            SetButtonDetail()

            txtItemID.Focus()
        End If
    End Sub

    Private Sub btnEditDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditDtl.Click
        If StatusTransDtl = TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.EditStatus

            SetColorDetail()
            SetInputDetail()
            SetButtonDetail()
            txtItemQty.Focus()
        End If
    End Sub

    Private Sub btnCancelDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelDtl.Click
        If StatusTransDtl <> TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.NoStatus

            ClearDetailInput()
            SetColorDetail()
            SetInputDetail()
            SetButtonDetail()

            txtIndex.Text = String.Empty
        End If
    End Sub

    Private Sub btnDeleteDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteDtl.Click
        Dim i As Integer

        If StatusTransDtl = TransStatus.NoStatus Then
            If txtItemID.Text.Trim <> String.Empty Then
                If MessageBox.Show("Are you sure to delete this detail (Item ID : '" & txtItemID.Text.Trim & "') ?", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
                    For i = 0 To dtDetail.Rows.Count - 1
                        With dtDetail.Rows(i)
                            If .Item(Fields.KBD_ItemID).ToString.Trim = txtItemID.Text.Trim Then
                                .Delete()
                                Exit For
                            End If
                        End With
                    Next

                    ClearDetailInput()
                    LoadDetailToGrid()
                End If
            Else
                MessageBox.Show("Please choose 1 detail to be deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub txtItemQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemQty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtItemQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemQty.LostFocus
        If txtItemQty.Text.Trim = String.Empty Then txtItemQty.Text = 0
        txtItemQty.Text = FormatAngka(CDbl(txtItemQty.Text), 0)
    End Sub

    Private Sub txtItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
        Dim dtData As New DataTable

        If StatusTransDtl = TransStatus.NewStatus OrElse StatusTransDtl = TransStatus.EditStatus Then
            If e.KeyCode = Keys.F1 Then
                If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                    Call frmSearch.InitFindData(":: Find Item ::", "exec sp_Retrieve_Trans_BPB_Dtl_ForSearchKB '" & txtRefNo.Text.Trim & "'")

                    Call frmSearch.AddFindColumn(1, "Item ID", "Item ID", DataType.TypeString, 90)
                    Call frmSearch.AddFindColumn(2, "Item Name", "Item Name", DataType.TypeString, 200)
                    Call frmSearch.AddFindColumn(3, "UOM", "UOM", DataType.TypeString, 80)
                    frmSearch.ShowDialog()

                    If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                        txtItemID.Text = frmSearch.txtResult1.Text.Trim
                        txtItemQty.Focus()
                    End If
                Else
                    MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub

    Private Sub txtItemID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemID.LostFocus
        Dim dtItem As New DataTable

        If txtItemID.Text.Trim <> String.Empty Then
            MD.RetrieveItemByKey_RegardlessActive(dtItem, txtItemID.Text.Trim)
            If dtItem.Rows.Count <> 0 Then
                With dtItem.Rows(0)
                    txtItemName.Text = .Item(Fields.Item_Name).ToString.Trim
                    txtItemUOM.Text = .Item(Fields.Item_UOM).ToString.Trim
                End With
            Else
                txtItemName.Text = String.Empty
                txtItemUOM.Text = String.Empty
            End If
        Else
            txtItemName.Text = String.Empty
            txtItemUOM.Text = String.Empty
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        txtRefNo.Text = String.Empty
    End Sub

    Private Sub txtRefNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefNo.KeyDown
        Dim dtData As New DataTable

        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If e.KeyCode = Keys.F1 Then
                If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                    'If cboType.SelectedIndex = 1 Then
                    '    Call frmSearch.InitFindData(":: Find SPK ::", "exec sp_Retrieve_Trans_SPK_Hdr_ForSearch")

                    '    Call frmSearch.AddFindColumn(1, "SPK_No", "SPK No", DataType.TypeString, 90)
                    '    Call frmSearch.AddFindColumn(2, "SPK_Date", "SPK Date", DataType.TypeDateTime, 90)
                    '    Call frmSearch.AddFindColumn(3, "Project_No", "Project No.", DataType.TypeString, 80)
                    '    Call frmSearch.AddFindColumn(4, "Remarks", "Remarks", DataType.TypeString, 250)
                    '    frmSearch.ShowDialog()
                    'ElseIf cboType.SelectedIndex = 2 Then
                    '    Call frmSearch.InitFindData(":: Find Fabrikasi ::", "exec sp_Retrieve_Trans_OrderPabrikasi_forKembaliBarang")

                    '    Call frmSearch.AddFindColumn(1, "OP_No", "OP No.", DataType.TypeString, 90)
                    '    Call frmSearch.AddFindColumn(2, "OP_Date", "OP Date", DataType.TypeDateTime, 90)
                    '    Call frmSearch.AddFindColumn(3, "SPK_No", "SPK No.", DataType.TypeString, 80)
                    '    Call frmSearch.AddFindColumn(4, "Remarks", "Remarks", DataType.TypeString, 250)
                    '    frmSearch.ShowDialog()
                    'End If

                    Call frmSearch.InitFindData(":: Find BPB ::", "exec sp_Retrieve_Trans_BPB_Hdr_ForSearch")

                    Call frmSearch.AddFindColumn(1, "BPB_No", "BPB No", DataType.TypeString, 90)
                    Call frmSearch.AddFindColumn(2, "BPB_Date", "BPB Date", DataType.TypeDateTime, 100)
                    Call frmSearch.AddFindColumn(3, "Required_Date", "Required Date", DataType.TypeDateTime, 100)
                    Call frmSearch.AddFindColumn(4, "Category", "Category", DataType.TypeString, 100)
                    Call frmSearch.AddFindColumn(5, "Ref_No", "Reference", DataType.TypeString, 100)
                    Call frmSearch.AddFindColumn(6, "Remarks", "Remarks", DataType.TypeString, 250)
                    frmSearch.ShowDialog()

                    If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                        txtRefNo.Text = frmSearch.txtResult1.Text.Trim
                        txtRemarks.Focus()
                    End If
                Else
                    MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub

    Private Function CekDetailSave() As Boolean
        Dim i As Integer = 0
        Dim Str As String = String.Empty

        CekDetailSave = False

        If txtItemID.Text.Trim = String.Empty Then
            i += 1
            Str &= i.ToString & ") Please input Item ID first." & vbCrLf
        Else
            txtItemID_LostFocus(Nothing, Nothing)
            If txtItemName.Text.Trim = String.Empty Then
                i += 1
                Str &= i.ToString & ") This item cannot be found in database." & vbCrLf
            End If
        End If

        If cboItemCondition.SelectedIndex = 0 Then
            i += 1
            Str &= i.ToString & ") Please choose item's condition first." & vbCrLf
        End If

        If i = 0 Then
            CekDetailSave = True
        Else
            MessageBox.Show("Please check this/these error below." & vbCrLf & Str & "Saving process is canceled.", "Error", MessageBoxButtons.OK)
        End If
    End Function

    Private Sub gDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gDetail.CellClick
        If StatusTransDtl = TransStatus.NoStatus Then
            If e.RowIndex >= 0 Then
                With gDetail.Rows(e.RowIndex)
                    txtItemID.Text = .Cells(0).Value.ToString
                    txtItemName.Text = .Cells(1).Value.ToString
                    txtItemUOM.Text = .Cells(2).Value.ToString
                    txtItemQty.Text = FormatAngka(.Cells(3).Value, 0)

                    If .Cells(4).Value = 1 Then
                        cboItemCondition.SelectedIndex = 1
                    ElseIf .Cells(5).Value = 1 Then
                        cboItemCondition.SelectedIndex = 2
                    ElseIf .Cells(6).Value = 1 Then
                        cboItemCondition.SelectedIndex = 3
                    Else
                        cboItemCondition.SelectedIndex = 0
                    End If

                    txtItemRemarks.Text = .Cells(7).Value.ToString
                    txtIndex.Text = e.RowIndex
                End With
            End If
        End If
    End Sub

    Private Sub btnSaveDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDtl.Click
        Dim i As Integer
        Dim bl As Boolean = False
        Dim proBL As Boolean = False
        Dim drDetail As DataRow
        Dim dtItem As New DataTable

        If Not StatusTransDtl = TransStatus.NoStatus Then
            If CekDetailSave() Then
                For i = 0 To dtDetail.Rows.Count - 1
                    If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                        If dtDetail.Rows(i).Item(Fields.KBD_ItemID).ToString.Trim = txtItemID.Text.Trim Then
                            bl = True
                            Exit For
                        End If
                    End If
                Next

                If StatusTransDtl = TransStatus.NewStatus Then
                    If bl Then
                        MessageBox.Show("This item ('" & txtItemID.Text.Trim & "') has been exists in list." & vbCrLf & "Please choose edit to change this item detail.", "Information", MessageBoxButtons.OK)
                    Else
                        drDetail = dtDetail.NewRow
                        With drDetail
                            .Item(Fields.KBD_ItemID) = txtItemID.Text.Trim

                            MD.RetrieveItemByKey(dtItem, txtItemID.Text.Trim)
                            If dtItem.Rows.Count <> 0 Then
                                With dtItem.Rows(0)
                                    .Item(Fields.Item_Name) = .Item(Fields.Item_Name).ToString.Trim
                                    .Item(Fields.Item_UOM) = .Item(Fields.Item_UOM).ToString.Trim
                                End With
                            End If

                            .Item(Fields.KBD_ItemQty) = CDbl(txtItemQty.Text)
                            .Item(Fields.KBD_Good) = IIf(cboItemCondition.SelectedIndex = 1, 1, 0)
                            .Item(Fields.KBD_RSupplier) = IIf(cboItemCondition.SelectedIndex = 2, 1, 0)
                            .Item(Fields.KBD_RPakai) = IIf(cboItemCondition.SelectedIndex = 3, 1, 0)
                            .Item(Fields.KBD_Remarks) = txtItemRemarks.Text.Trim
                        End With
                        dtDetail.Rows.Add(drDetail)
                        proBL = True
                    End If
                Else
                    If Not bl Then
                        MessageBox.Show("This item ('" & txtItemID.Text.Trim & "') has not been exists in list." & vbCrLf & "Please choose insert to add this item detail.", "Information", MessageBoxButtons.OK)
                    Else
                        drDetail = dtDetail.Rows(i)
                        With drDetail
                            .Item(Fields.KBD_ItemQty) = CDbl(txtItemQty.Text)
                            .Item(Fields.KBD_Good) = IIf(cboItemCondition.SelectedIndex = 1, 1, 0)
                            .Item(Fields.KBD_RSupplier) = IIf(cboItemCondition.SelectedIndex = 2, 1, 0)
                            .Item(Fields.KBD_RPakai) = IIf(cboItemCondition.SelectedIndex = 3, 1, 0)
                            .Item(Fields.KBD_Remarks) = txtItemRemarks.Text.Trim
                        End With
                        proBL = True
                    End If
                End If

                If proBL Then
                    StatusTransDtl = TransStatus.NoStatus
                    LoadDetailToGrid()
                    ClearDetailInput()
                    SetInputDetail()
                    SetButtonDetail()
                    SetColorDetail()
                End If
            End If
        End If
    End Sub

    Private Function CekSave() As Boolean
        Dim i As Integer = 0
        Dim str As String = String.Empty
        Dim dtData As New DataTable

        CekSave = False

        'Cek apakah nomor transaksi valid
        If StatusTrans = TransStatus.NewStatus Then
            If txtTransNo.Text.Trim <> String.Empty Then
                MessageBox.Show("This transaction number has been filled and in 'New' status." & vbCrLf & "Please cancel this process.", "Error")
                Exit Function
            End If
        ElseIf StatusTrans = TransStatus.EditStatus Then
            If txtTransNo.Text.Trim = String.Empty Then
                MessageBox.Show("This transaction number has not been filled and in 'Edit' status." & vbCrLf & "Please cancel this process.", "Error")
                Exit Function
            End If
        End If


        If StatusTrans = TransStatus.EditStatus Then
            TD.Retrieve_KembaliBarang_Hdr_ByID(dtData, txtTransNo.Text.Trim)
            If dtData.Rows.Count = 0 Then
                i += 1
                str &= i.ToString & ") This transaction no. '" & txtTransNo.Text.Trim & "' cannot be found in database." & vbCrLf
            End If
        End If

        'Cek apakah nomor referensi valid
        'If cboType.SelectedIndex = 1 Then
        '    TD.Retrieve_SPK_ByID(dtData, txtRefNo.Text.Trim)
        '    If dtData.Rows.Count = 0 Then
        '        i += 1
        '        str &= i.ToString & ") This SPK No. '" & txtRefNo.Text.Trim & "' cannot be found in database." & vbCrLf
        '    Else
        '        dtData = New DataTable
        '        TD.Retrieve_SPK_ByID_ProjectNotClosed(dtData, txtRefNo.Text.Trim)
        '        If dtData.Rows.Count = 0 Then
        '            i += 1
        '            str &= i.ToString & ") This SPK's Project has been closed, therefore cannot use this SPK for this Transaction's reference." & vbCrLf
        '        End If
        '    End If
        'ElseIf cboType.SelectedIndex = 2 Then
        '    TD.Retrieve_OrderFabrikasi_ByID(dtData, txtRefNo.Text.Trim)
        '    If dtData.Rows.Count = 0 Then
        '        i += 1
        '        str &= i.ToString & ") This Order Fabrikasi No. '" & txtRefNo.Text.Trim & "' cannot be found in database." & vbCrLf
        '    Else
        '        dtData = New DataTable
        '        TD.Retrieve_OrderFabrikasi_ByID_ProjectNotClosed(dtData, txtRefNo.Text.Trim)
        '        If dtData.Rows.Count = 0 Then
        '            i += 1
        '            str &= i.ToString & ") This Order Fabrikasi's Project has been closed, therefore cannot use this Order Fabrikasi for this Transaction's reference." & vbCrLf
        '        End If
        '    End If
        'End If
        If txtRefNo.Text.Trim <> String.Empty Then
            TD.RetrieveBPB_ByID(dtData, txtRefNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                With dtData.Rows(0)
                    If .Item("Active_Flag").ToString.Trim <> "Y" Then
                        i += 1
                        str &= i.ToString & ") This BPB No. '" & txtRefNo.Text.Trim & "' is a non-active transaction." & vbCrLf
                    End If
                End With
            Else
                i += 1
                str &= i.ToString & ") This BPB No. '" & txtRefNo.Text.Trim & "' cannot be found in database." & vbCrLf
            End If
        Else
            i += 1
            str &= i.ToString & ") Please fill BPB No. first." & vbCrLf
        End If

        If i > 0 Then
            MessageBox.Show("Please check this/these following error first." & vbCrLf & str & "Save process is cancelled.", "Error", MessageBoxButtons.OK)
        Else
            CekSave = True
        End If
    End Function

    Private Function CekSaveDetail() As Boolean
        Dim dtDet As New DataTable
        Dim i As Integer = 0
        Dim j As Integer
        Dim str As String = String.Empty

        'Cek apakah semua item masih ada di BPB.
        CekSaveDetail = False
        TD.RetrieveBPBDetail_ByID(dtDet, txtRefNo.Text.Trim)

        If dtDet.Rows.Count <> 0 Then
            If dtDet.Rows.Count <> dtDetail.Rows.Count Then
                i += 0
                str &= i.ToString & ") Item Detail is not in synchronize with BPB Detail." & vbCrLf
            Else
                For j = 0 To dtDet.Rows.Count - 1
                    With dtDet.Rows(j)
                        If .Item(Fields.Item_ID).ToString.Trim <> dtDetail.Rows(j).Item(Fields.Item_ID).ToString.Trim Then
                            i += 0
                            str &= i.ToString & ") Item Detail is not in synchronize with BPB Detail." & vbCrLf
                            Exit For
                        End If
                    End With
                Next
            End If
        Else
            If dtDetail.Rows.Count <> 0 Then
                i += 0
                str &= i.ToString & ") Item Detail is not in synchronize with BPB Detail." & vbCrLf
            End If
        End If

        If i > 0 Then
            MessageBox.Show("Please check this/these following error first." & vbCrLf & str & "Save process is cancelled.", "Error", MessageBoxButtons.OK)
        Else
            CekSaveDetail = True
        End If
    End Function

    Private Function SaveDetail(ByRef Query As String, Optional ByVal NewTransNo As String = "") As Boolean
        Dim queryParam As String
        Dim i As Integer
        Dim dtData As New DataTable
        Dim bl As Boolean

        SaveDetail = False

        'Cek detail yang disave, apakah quantitynya masih lebih kecil atau sama dengan jumlah quantity yang diminta.
        If CekSaveDetail Then
            If dtDetail.Rows.Count <> 0 Then
                For i = 0 To dtDetail.Rows.Count - 1
                    With dtDetail.Rows(i)
                        If .RowState <> DataRowState.Deleted Then
                            dtData = New DataTable
                            bl = False

                            TD.Retrieve_SisaQty_AmbilBahan_ByRefNo(dtData, txtRefNo.Text.Trim, .Item(Fields.Item_ID).ToString.Trim, txtTransNo.Text.Trim)
                            If dtData.Rows.Count <> 0 Then
                                If dtData.Rows(0).Item("Qty_Approved") - dtData.Rows(0).Item("TotalKembali") >= 0 Then
                                    If dtData.Rows(0).Item("Qty_Approved") - .Item(Fields.KBD_ItemQty) >= 0 Then
                                        bl = True
                                    End If
                                End If
                            End If

                            If Not bl Then
                                If dtData.Rows.Count <> 0 Then
                                    MessageBox.Show("Quantity Returned for Item '" & dtData.Rows(0).Item(Fields.Item_Name).ToString.Trim & "' will exceeding Quantity Taken. (Quantity Taken : " & Format(CDbl(dtData.Rows(0).Item("Qty_Approved")), "#,##0.#0") & "; Quantity Returned : " & Format(CDbl(dtData.Rows(0).Item("TotalKembali")), "#,##0.#0") & ")", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Function
                                Else
                                    MessageBox.Show("Item '" & .Item(Fields.Item_ID).ToString.Trim & "' cannot be found in Pengeluaran Bahan Transaction for this Reference#.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Function
                                End If
                            End If
                        End If
                    End With
                Next
            End If

            Query = "exec sp_Delete_Trans_KembaliBarang_Dtl_byID '" & IIf(NewTransNo.Trim = String.Empty, txtTransNo.Text.Trim, NewTransNo) & "' "
            For i = 0 To dtDetail.Rows.Count - 1
                queryParam = String.Empty

                With dtDetail.Rows(i)
                    If .RowState <> DataRowState.Deleted Then
                        Query &= "exec sp_Insert_Trans_KembaliBarang_Dtl "
                        queryParam = "'" & IIf(NewTransNo.Trim = String.Empty, txtTransNo.Text.Trim, NewTransNo) & "', '" & .Item(Fields.KBD_ItemID).ToString.Trim & "'," & .Item(Fields.KBD_ItemQty) & ", " & _
                                     .Item(Fields.KBD_Good) & "," & .Item(Fields.KBD_RSupplier) & ", " & .Item(Fields.KBD_RPakai) & ", " & _
                                     "'" & .Item(Fields.KBD_Remarks).ToString.Trim & "', '" & userlog.UserName & "' "
                        Query &= queryParam
                    End If
                End With
            Next

            SaveDetail = True
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Trans As SqlTransaction
        Dim nextStatus As String = String.Empty
        Dim NewNumber As String = String.Empty
        Dim LastSerial As Integer
        Dim Query As String = String.Empty
        Dim queryParam As String = String.Empty
        Dim bl As Boolean = False

        If StatusTrans <> TransStatus.NoStatus Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                Conn.ConnectionString = ConnectStr
                Conn.Open()
                Trans = Conn.BeginTransaction

                Try
                    If CekSave() Then
                        Cmd.Connection = Conn
                        Cmd.CommandType = CommandType.Text
                        Cmd.Transaction = Trans
                        nextStatus = Status.BK_Saved

                        If StatusTrans = TransStatus.NewStatus Then
                            NewNumber = Generate_TranNo("frmPengembalianBarang")
                            LastSerial = CInt(NewNumber.Substring(NewNumber.Length - 3, 3))

                            If SaveDetail(Query, NewNumber) Then
                                Query &= "exec sp_Insert_Trans_KembaliBarang_Hdr "
                                queryParam = "'" & NewNumber & "', '" & dtpTransDate.Value & "', '" & IIf(cboType.SelectedIndex = 1, "SPK", "Fabrikasi") & "', " & _
                                             "'" & txtRefNo.Text.Trim & "','" & txtRemarks.Text.Trim & "','" & nextStatus & "','" & userlog.UserName & "'"
                                Query &= queryParam

                                Cmd.CommandText = Query
                                Cmd.ExecuteNonQuery()
                                UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)

                                bl = True
                            End If

                        ElseIf StatusTrans = TransStatus.EditStatus Then
                            If SaveDetail(Query) Then
                                Query &= "exec sp_Update_Trans_KembaliBarang_Hdr "
                                queryParam = "'" & txtTransNo.Text.Trim & "', '" & dtpTransDate.Value & "', '" & IIf(cboType.SelectedIndex = 1, "SPK", "Fabrikasi") & "', " & _
                                             "'" & txtRefNo.Text.Trim & "','" & txtRemarks.Text.Trim & "','" & nextStatus & "','" & userlog.UserName & "'"
                                Query &= queryParam

                                Cmd.CommandText = Query
                                Cmd.ExecuteNonQuery()

                                bl = True
                            End If
                        End If

                        If bl Then
                            If StatusTrans = TransStatus.EditStatus AndAlso IDStatus = Status.BK_Rejected Then
                                Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

                                UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Saved, userlog.UserName, "3") 'Update Status utk Flow Teakhir
                                UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Saved, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir       
                            Else
                                Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction
                                InserttoInbox(NewNumber, userlog.UserName, userlog.UserName, "R", "N", Status.BK_Saved) 'Insert to NEXT APPROVAL
                            End If
                            InserttoInbox(IIf(StatusTrans = TransStatus.NewStatus, NewNumber, txtTransNo.Text.Trim), userlog.UserName, GetNextPIC(Status.BK_Saved), "W", "Y", Status.BK_Saved) 'Insert to NEXT APPROVAL

                            Trans.Commit()

                            MessageBox.Show("This transaction has been submitted to " & Hirarki.BK_Saved & "." & vbCrLf & "(Transaction No. '" & IIf(StatusTrans = TransStatus.NewStatus, NewNumber, txtTransNo.Text.Trim) & "')", "Information", MessageBoxButtons.OK)
                            btnCancel_Click(Nothing, Nothing)
                        Else
                            Trans.Rollback()
                        End If
                    End If
                Catch ex As Exception
                    Trans.Rollback()
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
                Finally
                    If Conn.State = ConnectionState.Open Then Conn.Close()
                End Try
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Trans As SqlTransaction
        Dim Query As String = String.Empty
        Dim queryParam As String = String.Empty
        Dim success As Boolean = False

        If StatusTrans = TransStatus.NoStatus AndAlso txtTransNo.Text.Trim <> String.Empty AndAlso IDStatus = Status.BK_Rejected Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.GudangHead OrElse userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to delete this transaction data ?", "Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Conn.ConnectionString = ConnectStr
                    Conn.Open()
                    Trans = Conn.BeginTransaction

                    Try
                        Query = "exec sp_Delete_Trans_KembaliBarang_Hdr '" & txtTransNo.Text.Trim & "', '" & userlog.UserName & "'"
                        Cmd.CommandText = Query
                        Cmd.ExecuteNonQuery()
                        Trans.Commit()

                        success = True
                        MessageBox.Show("Transaction No. '" & txtTransNo.Text.Trim & "' is successfully deleted.", "Information", MessageBoxButtons.OK)
                    Catch ex As Exception
                        Trans.Rollback()
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
                    Finally
                        If Conn.State = ConnectionState.Open Then Conn.Close()
                        'Perlakuan seperti cancel pada save new data, kembali ke view.
                        If success Then
                            BackToView = True
                            Me.Close()
                        End If
                    End Try
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If IDStatus = Status.BK_Saved AndAlso StatusTrans = TransStatus.NoStatus Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to approve this Transaction# " & txtTransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ApproveData()
                    Me.Close()
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub ApproveData()
        If ApproveTrans() Then
            MessageBox.Show("Data (Transaction# " & txtTransNo.Text.Trim & ") has been closed, all details item has been added to stock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RejectData()
        If RejectTrans() Then
            MessageBox.Show("Data (Transaction# " & txtTransNo.Text.Trim & ") has been rejected and sent to " & Hirarki.BK_Rejected & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function RejectTrans() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction

        RejectTrans = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_KembaliBarang_Hdr_Gudang "
            queryParam = "'" & txtTransNo.Text.Trim & "', '" & alasanReject & "', '" & Status.BK_Rejected & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Rejected, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Rejected, userlog.UserName, "3")
            InserttoInbox(txtTransNo.Text.Trim, userlog.UserName, GetDocCreator(txtTransNo.Text.Trim), "W", "Y", Status.BK_Rejected) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Rejected) 'Insert History transaction

            Trans.Commit()
            RejectTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function ApproveTrans() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction
        Dim i As Integer
        Dim dtData As New DataTable
        Dim dtHarga As New DataTable
        Dim Persediaan As Double
        Dim TransNo As String = String.Empty
        Dim RemarkJurnal As String
        Dim LastSerial As Integer

        ApproveTrans = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            'Update stock to database
            'Adding stock
            Persediaan = 0
            TD.RetrieveBPB_ByID(dtData, txtRefNo.Text.Trim)

            For i = 0 To dtDetail.Rows.Count - 1
                If dtData.Rows.Count <> 0 Then
                    If dtData.Rows(0).Item("Active_Flag").ToString.Trim = "Y" Then
                        With dtDetail.Rows(i)
                            If .Item(Fields.KBD_Good) = 1 Then
                                Persediaan += MD.RetrieveHargaSatuan(GetWarehouse_byBPB, .Item(Fields.KBD_ItemID).ToString.Trim)
                                Insert_StokMovement(.Item(Fields.KBD_ItemID), dtData.Rows(0).Item(Fields.Item_Warehouse).ToString.Trim, txtTransNo.Text.Trim, "IN", .Item(Fields.KBD_ItemQty), "Good")
                            Else
                                Persediaan += MD.RetrieveHargaSatuan(GetWarehouse_byBPB, .Item(Fields.KBD_ItemID).ToString.Trim)
                                Insert_StokMovement(.Item(Fields.KBD_ItemID), WarehouseReject, txtTransNo.Text.Trim, "IN", .Item(Fields.KBD_ItemQty), IIf(.Item(Fields.KBD_RPakai) = 1, "Reject Pakai", "Reject Supplier"))
                            End If
                        End With
                    End If
                End If
            Next

            Query = "exec sp_Update_Trans_KembaliBarang_Hdr_Gudang "
            queryParam = "'" & txtTransNo.Text.Trim & "', '', '" & Status.BK_Approved & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Approved, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txtTransNo.Text.Trim, Status.BK_Approved, userlog.UserName, "3") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Approved) 'Insert History transaction

            'Saving Jurnal
            TransNo = Generate_TranNo("Journal")
            LastSerial = CInt(TransNo.Substring(TransNo.Length - 3, 3))
            RemarkJurnal = "Jurnal Pengembalian Barang #" & txtTransNo.Text.Trim & "."
            TD.SaveJurnalHeader(Cmd, TransNo, "Kembali Barang", RemarkJurnal, txtTransNo.Text.Trim)
            TD.SaveJurnalDetail(Cmd, TransNo, "DR", AccGL.Acc_PersediaanSparepart, Persediaan)
            If cboType.SelectedIndex = 1 Then
                TD.SaveJurnalDetail(Cmd, TransNo, "CR", AccGL.Acc_WIPProject, Persediaan)
            Else
                TD.SaveJurnalDetail(Cmd, TransNo, "CR", AccGL.Acc_WIPPabrikasi, Persediaan)
            End If
            UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

            Trans.Commit()
            ApproveTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Function GetWarehouse_byBPB() As String
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtdata As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select Warehouse_ID from Trans_BPB_Hdr '" & txtRefNo.Text.Trim & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtdata)

            GetWarehouse_byBPB = dtdata.Rows(0).Item("Warehouse_ID").ToString.Trim

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        If StatusTrans = TransStatus.NoStatus AndAlso IDStatus = Status.BK_Saved Then
            If userlog.AccessID = Role.GudangAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to reject this Transaction# " & txtTransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    alasanReject = String.Empty
                    frmReason.ShowDialog()

                    If frmReason.Flag = "OK" Then
                        alasanReject = frmReason.txtReason.Text.Trim
                        RejectData()
                        Me.Close()
                    End If
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub txtRefNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRefNo.LostFocus
        If RefNo <> txtRefNo.Text.Trim Then
            If MessageBox.Show("Detail data will be reset." & vbCrLf & "Are you sure to continue ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                RefNo = txtRefNo.Text.Trim
                LoadDetailByRef()
            Else
                txtRefNo.Text = RefNo
            End If
        End If
    End Sub

    Private Sub LoadDetailByRef()
        dtDetail = New DataTable
        TD.RetrieveBPBDetail_ByID_ForKB(dtDetail, txtRefNo.Text.Trim)
        LoadDetailToGrid()
    End Sub
End Class