'(22 Des 2012) Add insert ability to detail, and tahap 3 modification.
'(28 Des 2012) Fix bug on search.
'(29 Des 2012) Adding delete routine
'(08 Jan 2013) adding reject reason
'(28 Jan 2013) Change the way automatic journal based on config retrieval and creation

Imports MIS.GlobalVar
Imports MIS.MasterData
Imports MIS.TransData
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPemakaianBahan
    Public TransNo As String
    Public fromInbox As Boolean

    Dim MD As New MasterData
    Dim TD As New TransData
    Dim StatusTrans As String
    Dim StatusTransDtl As String
    Dim IDStatus As String
    Dim dtDetail As DataTable
    Dim PHMNo As String
    Dim alasanReject As String
    Dim frmReason As New Frm_Reason

    Public ViewFormName As String
    'Dipanggil dari Form Penawaran Harga Marketing yang sudah berstatus closed/ sudah dibuatkan project.
    'Sebagai modal dialog.

    Private Sub frmPemakaianBahan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If StatusTrans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            If Not fromInbox Then
                Dim frmChild As New frmPemakaianBahan_View

                For Each f As Form In Me.MdiChildren
                    If f.Name = "frmPemakaianBahan_View" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Else
                Dim frmChild As New FrmInbox

                For Each f As Form In Me.MdiChildren
                    If f.Name = "FrmInbox" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            End If
        End If
    End Sub

    Private Sub frmPemakaianBahan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SetAccess(Me, userlog.AccessID, ViewFormName, btnNew, btnEdit, btnDelete, btnSave, btnCancel, Nothing, btnApprove, btnReject)
        StatusTransDtl = TransStatus.NoStatus
        btnNew.Visible = False
        btnEdit.Visible = False
        btnDelete.Visible = False

        If TransNo.Trim <> String.Empty Then
            txtTransNo.Text = TransNo.Trim
            LoadDataEdit()

            SetInputDetail()
            SetInputHeader()
            SetColorDetail()
            SetColorHeader()
            SetDetailButton()
            SetToolStrip()
        Else
            NewState()
        End If
    End Sub

    Private Sub NewState()
        lblStatus.Text = "NEW"
        IDStatus = Status.Draft

        StatusTrans = TransStatus.NewStatus

        ClearInput()
        ClearDetailInput()
        SetDetailButton()
        SetColorHeader()
        SetColorDetail()
        SetInputHeader()
        SetInputDetail()
        SetToolStrip()

        dtpTransDate.Focus()
        'LoadDataNew()
    End Sub

    'Private Sub EditState()
    '    StatusTrans = TransStatus.EditStatus

    '    ClearDetailInput()
    '    SetDetailButton()
    '    SetColorHeader()
    '    SetColorDetail()
    '    SetInputHeader()
    '    SetInputDetail()
    '    SetToolStrip()
    'End Sub

    Private Sub SetToolStrip()
        If IDStatus = Status.Draft OrElse IDStatus = Status.PB_Rejected Then
            If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = True
                btnCancel.Visible = True

                btnSave.Enabled = True
                btnCancel.Enabled = True
            ElseIf userlog.AccessID = Role.ProjectHead Then
                btnApprove.Visible = True
                btnReject.Visible = True
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnApprove.Enabled = False
                btnReject.Enabled = False
            ElseIf userlog.AccessID = Role.MarketingHead Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = True
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnConfirmed.Enabled = False
            End If
        ElseIf IDStatus = Status.PB_Saved Then
            If userlog.AccessID = Role.ProjectAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = True
                btnCancel.Visible = True

                btnSave.Enabled = False
                btnCancel.Enabled = False
            ElseIf userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                btnApprove.Visible = True
                btnReject.Visible = True
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnApprove.Enabled = True
                btnReject.Enabled = True
            ElseIf userlog.AccessID = Role.MarketingHead Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = True
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnConfirmed.Enabled = False
            End If
        ElseIf IDStatus = Status.PB_Approved Then
            If userlog.AccessID = Role.ProjectAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = True
                btnCancel.Visible = True

                btnSave.Enabled = False
                btnCancel.Enabled = False
            ElseIf userlog.AccessID = Role.ProjectHead Then
                btnApprove.Visible = True
                btnReject.Visible = True
                btnConfirmed.Visible = False
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnApprove.Enabled = False
                btnReject.Enabled = False
            ElseIf userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = True
                sep_Approver.Visible = False

                btnSave.Visible = False
                btnCancel.Visible = False

                btnConfirmed.Enabled = True
            End If
        Else
            If userlog.AccessID = Role.ProjectAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = False
                sep_Approver.Visible = False
                btnSave.Visible = True
                btnCancel.Visible = True

                btnSave.Enabled = False
                btnCancel.Enabled = False
            ElseIf userlog.AccessID = Role.ProjectHead Then
                btnApprove.Visible = True
                btnReject.Visible = True
                btnConfirmed.Visible = False
                sep_Approver.Visible = False
                btnSave.Visible = False
                btnCancel.Visible = False

                btnApprove.Enabled = False
                btnReject.Enabled = False
            ElseIf userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin Then
                btnApprove.Visible = False
                btnReject.Visible = False
                btnConfirmed.Visible = True
                sep_Approver.Visible = False
                btnSave.Visible = False
                btnCancel.Visible = False

                btnConfirmed.Enabled = False
            End If
        End If
    End Sub

    Private Sub SetInputHeader()
        Select Case StatusTrans
            Case TransStatus.NoStatus
                dtpTransDate.Enabled = False
                txtRemarks.ReadOnly = True
                txtPHMNo.ReadOnly = True
            Case TransStatus.NewStatus, TransStatus.EditStatus
                dtpTransDate.Enabled = True
                txtRemarks.ReadOnly = False
                txtPHMNo.ReadOnly = False
        End Select
    End Sub

    Private Sub SetInputDetail()
        Select Case StatusTransDtl
            Case TransStatus.NoStatus
                txtItemID.ReadOnly = True
                txtItemQtyUsed.ReadOnly = True
                dtpItemDate.Enabled = False
            Case TransStatus.NewStatus
                txtItemID.ReadOnly = False
                txtItemQtyUsed.ReadOnly = False
                dtpItemDate.Enabled = True
            Case TransStatus.EditStatus
                dtpItemDate.Enabled = True
                txtItemID.ReadOnly = True
                txtItemQtyUsed.ReadOnly = False
        End Select
    End Sub

    Private Sub SetColorDetail()
        Select Case StatusTransDtl
            Case TransStatus.NoStatus
                txtItemID.BackColor = Color.LightGray
                txtItemQtyUsed.BackColor = Color.LightGray
            Case TransStatus.NewStatus
                txtItemID.BackColor = Color.LightGoldenrodYellow
                txtItemQtyUsed.BackColor = Color.LightGoldenrodYellow
            Case TransStatus.EditStatus
                txtItemID.BackColor = Color.LightGray
                txtItemQtyUsed.BackColor = Color.LightGoldenrodYellow
        End Select
    End Sub

    Private Sub SetColorHeader()
        Select Case StatusTrans
            Case TransStatus.NoStatus
                txtRemarks.BackColor = Color.Empty
                txtPHMNo.BackColor = Color.Empty
            Case TransStatus.NewStatus, TransStatus.EditStatus
                txtRemarks.BackColor = Color.LightGoldenrodYellow
                txtPHMNo.BackColor = Color.LightGoldenrodYellow
        End Select
    End Sub

    Private Sub ClearInput()
        txtTransNo.Text = String.Empty
        txtSPKNo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtCustID.Text = String.Empty
        txtCustName.Text = String.Empty
        txtPHMNo.Text = String.Empty

        txtPHMTotal.Text = FormatAngka(0)
        txtActualTotal.Text = FormatAngka(0)

        dtpTransDate.Value = Now
    End Sub

    Private Sub ClearDetailInput()
        txtItemID.Text = String.Empty
        txtItemName.Text = String.Empty
        txtItemUOM.Text = String.Empty
        txtItemCategory.Text = String.Empty

        dtpItemDate.Value = Now
        txtItemQty.Text = FormatAngka(0, 0)
        txtItemQtyUsed.Text = FormatAngka(0, 0)
        txtisPHM.Text = String.Empty
    End Sub

    Private Sub SetDetailButton()
        If IDStatus = Status.Draft OrElse IDStatus = Status.PB_Rejected Then
            Select Case StatusTransDtl
                Case TransStatus.NoStatus
                    btnInsertDtl.Enabled = True
                    btnEditDtl.Enabled = True
                    btnDeleteDtl.Enabled = True

                    btnSaveDtl.Enabled = False
                    btnCancelDtl.Enabled = False
                Case TransStatus.NewStatus, TransStatus.EditStatus
                    btnInsertDtl.Enabled = False
                    btnEditDtl.Enabled = False
                    btnDeleteDtl.Enabled = False

                    btnSaveDtl.Enabled = True
                    btnCancelDtl.Enabled = True
            End Select
        Else
            btnInsertDtl.Enabled = False
            btnEditDtl.Enabled = False
            btnDeleteDtl.Enabled = False
            btnSaveDtl.Enabled = False
            btnCancelDtl.Enabled = False
        End If
    End Sub

    'Private Sub LoadDataNew()
    '    Dim dtData As New DataTable
    '    Dim dtCust As New DataTable

    '    If StatusTrans = TransStatus.NewStatus Then
    '        TD.Retrieve_PHM_Hdr_forPB(dtData, PHMNo)
    '        If dtData.Rows.Count <> 0 Then
    '            With dtData.Rows(0)
    '                dtpTransDate.Value = .Item(Fields.PB_TransDate)
    '                txtRemarks.Text = .Item(Fields.PB_Remarks).ToString.Trim
    '                txtSPKNo.Text = .Item(Fields.PB_SPK).ToString.Trim
    '                txtPHMNo.Text = .Item(Fields.PB_PHM).ToString.Trim
    '                txtCustID.Text = .Item(Fields.Cust_ID).ToString.Trim
    '                txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim

    '                IDStatus = Status.Draft
    '            End With

    '            LoadDetailNew()
    '        End If
    '    End If
    'End Sub

    'Private Sub LoadDetailNew()
    '    dtDetail = New DataTable
    '    TD.Retrieve_PHM_ItemDtl_forPB(dtDetail, PHMNo)
    '    gDetail.DataSource = dtDetail
    '    SetGrid()
    'End Sub

    Private Sub LoadDetailEdit()
        dtDetail = New DataTable
        TD.Retrieve_PakaiBahan_Dtl(dtDetail, txtTransNo.Text.Trim)
        gDetail.DataSource = dtDetail
        SetGrid()

        HitungDetailActual()
        HitungDetailPHM()
    End Sub

    Private Sub LoadDataEdit()
        Dim dtData As New DataTable
        Dim dtCust As New DataTable

        If fromInbox Then
            TD.Retrieve_PakaiBahan_ByID_fromInbox(dtData, txtTransNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                With dtData.Rows(0)
                    dtpTransDate.Value = .Item(Fields.PB_TransDate)
                    txtRemarks.Text = .Item(Fields.PB_Remarks).ToString.Trim
                    txtSPKNo.Text = .Item(Fields.PB_SPK).ToString.Trim
                    txtCustID.Text = .Item(Fields.Cust_ID).ToString.Trim
                    txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
                    txtProjectNo.Text = .Item("Project_No").ToString.Trim

                    PHMNo = .Item(Fields.PB_PHM).ToString.Trim
                    txtPHMNo.Text = PHMNo

                    IDStatus = .Item(Fields.PB_Status).ToString.Trim
                    lblStatus.Text = GetStatus(IDStatus)
                End With

                LoadDetailEdit()
            End If
        Else
            '    TD.Retrieve_PakaiBahan_ByID_fromPHM(dtData, PHMNo)
            '    If dtData.Rows.Count <> 0 Then
            '        With dtData.Rows(0)
            '            dtpTransDate.Value = .Item(Fields.PB_TransDate)
            '            txtRemarks.Text = .Item(Fields.PB_Remarks).ToString.Trim
            '            txtSPKNo.Text = .Item(Fields.PB_SPK).ToString.Trim
            '            txtCustID.Text = .Item(Fields.Cust_ID).ToString.Trim
            '            txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
            '            txtPHMNo.Text = .Item(Fields.PB_PHM).ToString.Trim

            '            IDStatus = .Item(Fields.PB_Status).ToString.Trim
            '            lblStatus.Text = GetStatus(IDStatus)
            '        End With

            '        LoadDetailEdit()
            '    End If

            TD.Retrieve_PakaiBahan_ByID_forPB(dtData, txtTransNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                With dtData.Rows(0)
                    dtpTransDate.Value = .Item(Fields.PB_TransDate)
                    txtRemarks.Text = .Item(Fields.PB_Remarks).ToString.Trim
                    txtSPKNo.Text = .Item(Fields.PB_SPK).ToString.Trim
                    txtCustID.Text = .Item(Fields.Cust_ID).ToString.Trim
                    txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
                    txtProjectNo.Text = .Item("Project_No").ToString.Trim

                    PHMNo = .Item(Fields.PB_PHM).ToString.Trim
                    txtPHMNo.Text = .Item(Fields.PB_PHM).ToString.Trim

                    IDStatus = .Item(Fields.PB_Status).ToString.Trim
                    lblStatus.Text = GetStatus(IDStatus)
                End With

                LoadDetailEdit()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        StatusTrans = TransStatus.NoStatus
        Me.Close()
    End Sub

    Private Sub btnEditDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditDtl.Click
        If StatusTransDtl = TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.EditStatus

            SetColorDetail()
            SetInputDetail()
            SetDetailButton()

            dtpItemDate.Focus()
        End If
    End Sub

    Private Sub btnCancelDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelDtl.Click
        If StatusTransDtl <> TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.NoStatus

            ClearDetailInput()
            SetColorDetail()
            SetInputDetail()
            SetDetailButton()
        End If
    End Sub

    Private Sub gDetail_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gDetail.MouseClick
        If StatusTransDtl = TransStatus.NoStatus Then
            If Not gDetail Is Nothing Then
                With gDetail.Rows(gDetail.CurrentCell.RowIndex)
                    If String.IsNullOrEmpty(.Cells(GlobalVar.Fields.Item_ID).Value) = False Then
                        txtItemID.Text = .Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
                        txtItemName.Text = .Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
                        txtItemUOM.Text = .Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
                        txtItemCategory.Text = .Cells(GlobalVar.Fields.Item_Category).Value.ToString.Trim
                        txtItemQty.Text = FormatAngka(CDbl(.Cells(GlobalVar.Fields.Qty).Value.ToString.Trim), 0)
                        dtpItemDate.Value = .Cells(Fields.PBD_ItemDate).Value
                        txtItemQtyUsed.Text = FormatAngka(CDbl(.Cells(Fields.PBD_ItemQtyPakai).Value.ToString.Trim), 0)
                        txtisPHM.Text = .Cells(Fields.PBD_isPHM).Value
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Trans As SqlTransaction
        Dim nextStatus As String
        Dim NewNumber As String = String.Empty
        Dim LastSerial As Integer
        Dim query As String = String.Empty
        Dim queryParam As String = String.Empty

        If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
            Conn.ConnectionString = ConnectStr
            Conn.Open()
            Trans = Conn.BeginTransaction

            Try
                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Trans
                nextStatus = Status.PB_Saved

                If StatusTrans = TransStatus.NewStatus Then
                    NewNumber = Generate_TranNo("frmPemakaianBahan")
                    LastSerial = CInt(NewNumber.Substring(NewNumber.Length - 3, 3))

                    query = "exec sp_Insert_Trans_PakaiBahan_Hdr "
                    queryParam = "'" & NewNumber & "', '" & dtpTransDate.Value & "', '" & txtSPKNo.Text.Trim & "', " & _
                                 "'" & txtRemarks.Text.Trim & "','" & txtPHMNo.Text.Trim & "','" & nextStatus & "','" & userlog.UserName & "'"
                    query &= queryParam & " "
                    Cmd.CommandText = query
                    Cmd.ExecuteNonQuery()

                    For Each item As DataRow In dtDetail.Rows
                        'Khusus new transaction, added dan modified diinsert ke table marketing
                        If item.RowState <> DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PakaiBahan_Dtl '" & NewNumber & "','" & item(Fields.Item_ID).ToString.Trim & "', '" & item(Fields.Item_Category) & "', '" & item(Fields.PBD_ItemDate) & "', " & _
                                              FormatAngka(CDbl(item(Fields.PBD_ItemQtyPakai)), 0) & ", " & item(Fields.PBD_isPHM) & ", " & item(Fields.PBD_ItemPrice) & ", '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)
                ElseIf IDStatus = Status.PB_Rejected Then
                    query = "exec sp_Update_Trans_PakaiBahan_Hdr "
                    queryParam = "'" & txtTransNo.Text.Trim & "', '" & dtpTransDate.Value & "', '" & txtSPKNo.Text.Trim & "', " & _
                                 "'" & txtRemarks.Text.Trim & "','" & txtPHMNo.Text.Trim & "','" & nextStatus & "','" & userlog.UserName & "'"
                    query &= queryParam
                    Cmd.CommandText = query
                    Cmd.ExecuteNonQuery()

                    For Each item As DataRow In dtDetail.Rows
                        'Khusus new transaction, added dan modified diinsert ke table marketing
                        If item.RowState = DataRowState.Added OrElse item.RowState = DataRowState.Modified OrElse item.RowState = DataRowState.Unchanged Then
                            Cmd.CommandText = "EXEC sp_Update_Trans_PakaiBahan_Dtl '" & txtTransNo.Text.Trim & "','" & item(Fields.Item_ID).ToString.Trim & "', '" & item(Fields.Item_Category) & "', '" & item(Fields.PBD_ItemDate) & "', " & _
                                              FormatAngka(CDbl(item(Fields.PBD_ItemQtyPakai)), 0) & ", " & item(Fields.PBD_isPHM) & ", " & item(Fields.PBD_ItemPrice) & ", '" & userlog.UserName & "' "
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PakaiBahan_Dtl '" & txtTransNo.Text.Trim & "','" & item(Fields.Item_ID).ToString.Trim & "', '" & item(Fields.Item_Category) & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next
                End If

                If IDStatus = Status.PB_Rejected Then
                    Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

                    UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Saved, userlog.UserName, "3") 'Update Status utk Flow Teakhir
                    UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Saved, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir       
                Else
                    Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction

                    InserttoInbox(NewNumber, userlog.UserName, userlog.UserName, "R", "N", Status.PB_Saved) 'Insert to creator
                End If
                InserttoInbox(IIf(StatusTrans = TransStatus.NewStatus, NewNumber, txtTransNo.Text.Trim), userlog.UserName, GetApprover, "W", "Y", Status.PB_Saved) 'Insert to NEXT APPROVAL

                Trans.Commit()

                MessageBox.Show("This transaction has been submitted to " & Hirarki.PB_Saved & "." & vbCrLf & "(Transaction No. '" & IIf(StatusTrans = TransStatus.NewStatus, NewNumber, txtTransNo.Text.Trim) & "')", "Information", MessageBoxButtons.OK)
                btnCancel_Click(Nothing, Nothing)
            Catch ex As Exception
                Trans.Rollback()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
            Finally
                If Conn.State = ConnectionState.Open Then Conn.Close()
            End Try
        Else
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If IDStatus = Status.PB_Saved AndAlso StatusTrans = TransStatus.NoStatus Then
            If userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to approve this Transaction# " & txtTransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ApproveData()
                    Me.Close()
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        If StatusTrans = TransStatus.NoStatus AndAlso IDStatus = Status.PB_Saved Then
            If userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
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

    Private Sub ApproveData()
        If ApproveTrans() Then
            MessageBox.Show("Data (Transaction# " & txtTransNo.Text.Trim & ") has been approved and sent to " & Hirarki.PB_Approved & ", a journal for this transaction has been made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RejectData()
        If RejectTrans() Then
            MessageBox.Show("Data (Transaction# " & txtTransNo.Text.Trim & ") has been rejected and sent to " & Hirarki.PB_Rejected & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

            Query = "exec sp_Update_Trans_PakaiBahan_Hdr_TM "
            queryParam = "'" & txtTransNo.Text.Trim & "', '" & alasanReject & "', '" & Status.PB_Rejected & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Rejected, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Rejected, userlog.UserName, "3")
            InserttoInbox(txtTransNo.Text.Trim, userlog.UserName, GetDocCreator(txtTransNo.Text.Trim), "W", "Y", Status.PB_Rejected) 'Insert to NEXT APPROVAL
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

    Private Function getTotalWIP(ByVal MappingName As String) As Double
        Dim dtWIP As New DataTable
        Dim Total As Double
        Dim i As Integer

        TD.Retrieve_ListAccountWIP_ByProject_ForPB(dtWIP, txtProjectNo.Text.Trim, MappingName)
        Total = 0

        If dtWIP.Rows.Count <> 0 Then
            For i = 0 To dtWIP.Rows.Count - 1
                With dtWIP.Rows(i)
                    Total += CDbl(.Item("Amount").ToString.Trim)
                End With
            Next
        End If

        Return Total
    End Function

    Private Function getTotalDP(ByVal MappingName As String) As Double
        Dim dtDP As New DataTable
        Dim Total As Double
        Dim i As Integer

        TD.Retrieve_ListAccountDP_ByProject_ForPB(dtDP, txtProjectNo.Text.Trim, MappingName)
        Total = 0

        If dtDP.Rows.Count <> 0 Then
            For i = 0 To dtDP.Rows.Count - 1
                With dtDP.Rows(i)
                    Total += CDbl(.Item("Amount").ToString.Trim)
                End With
            Next
        End If

        Return Total
    End Function

    Private Function ApproveTrans() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction
        Dim TransNo As String = String.Empty
        Dim RemarkJurnal As String
        Dim LastSerial As Integer
        Dim i, j As Integer
        Dim dtJD, dtMAP, dtGrp As New DataTable
        Dim Total, Amt As Double

        ApproveTrans = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_PakaiBahan_Hdr_TM "
            queryParam = "'" & txtTransNo.Text.Trim & "', '', '" & Status.PB_Approved & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Approved, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Approved, userlog.UserName, "3") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            InserttoInbox(txtTransNo.Text.Trim, userlog.UserName, GetNextPIC(Status.PB_Approved), "W", "Y", Status.PB_Approved) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Approved) 'Insert History transaction

            'Saving Jurnal
            'Create first journal (WIP)


            'WOverhead = TD.Retrieve_WIPAmt_forPB(txtPHMNo.Text.Trim, AccGL.Acc_WIPOverhead)
            'WLabour = TD.Retrieve_WIPAmt_forPB(txtPHMNo.Text.Trim, AccGL.Acc_WIPLabour)
            'TD.Retrieve_SisaQty_Project(dtItem, txtPHMNo.Text.Trim)
            'If dtItem.Rows.Count <> 0 Then
            '    WProject = 0
            '    TD.Retrieve_Trans_Closing_ByDate(dtClosing, dtpTransDate.Value)
            '    If dtClosing.Rows.Count <> 0 Then
            '        Periode = dtClosing.Rows(0).Item("Period").ToString.Trim

            '        For i = 0 To dtItem.Rows.Count - 1
            '            With dtItem.Rows(i)
            '                WProject += ((CDbl(.Item("QtyDiminta")) - CDbl(.Item("QtyKembali"))) * GetAverageValue(Periode, .Item(Fields.Item_ID).ToString.Trim))
            '            End With
            '        Next
            '    Else
            '        Trans.Rollback()
            '        MessageBox.Show("Cannot found closing period for this Transaction Date." & vbCrLf & "Please recheck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        If Conn.State = ConnectionState.Open Then Conn.Close()
            '        Exit Function
            '    End If
            'End If

            Dim dtTemp As New DataTable
            Dim totalWIP As Double = getTotalWIP(MappingName.PB_WIP)
            Dim totalDP As Double = getTotalDP(MappingName.PB_DP)
            MD.RetrieveGroupMappingJournal_ByForm(dtGrp, Me.Name)
            If dtGrp.Rows.Count <> 0 Then
                dtJD = New DataTable
                For i = 0 To dtGrp.Rows.Count - 1
                    If dtGrp.Rows(i).Item("Form_Name").ToString.Trim = MappingName.PB_WIP Then
                        'ambil sisi debet
                        TD.Retrieve_ListAccountWIP_ByProject_ForPB(dtJD, txtProjectNo.Text.Trim, MappingName.PB_WIP)
                    ElseIf dtGrp.Rows(i).Item("Form_Name").ToString.Trim = MappingName.PB_DP Then
                        'ambil sisi credit
                        TD.Retrieve_ListAccountDP_ByProject_ForPB(dtJD, txtProjectNo.Text.Trim, MappingName.PB_DP)
                    End If
                Next

                Dim lastMAP As String = String.Empty
                For i = 0 To dtJD.Rows.Count - 1
                    With dtJD.Rows(i)
                        If lastMAP.Trim <> .Item("Form_Name").ToString.Trim Then
                            If lastMAP.Trim <> String.Empty Then
                                dtTemp = New DataTable


                                If lastMAP = MappingName.PB_WIP Then
                                    MD.RetrieveGroupMappingJournal_ByForm_DEBETOnly(dtTemp, lastMAP)
                                    If dtTemp.Rows.Count <> 0 Then
                                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total < 0, IIf(dtTemp.Rows(0).Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), dtTemp.Rows(0).Item("sisiGL").ToString.Trim), dtTemp.Rows(0).Item("Account_ID").ToString.Trim, Math.Abs(totalWIP))
                                    End If
                                ElseIf lastMAP = MappingName.PB_DP Then
                                    'Jurnal pendahulunya ada di sisi debet)
                                    MD.RetrieveGroupMappingJournal_ByForm_CREDITOnly(dtTemp, lastMAP)
                                    If dtTemp.Rows.Count <> 0 Then
                                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total > 0, IIf(dtTemp.Rows(0).Item("sisiGL").ToString.Trim = "DR", "CR", "DR"), dtTemp.Rows(0).Item("sisiGL").ToString.Trim), dtTemp.Rows(0).Item("Account_ID").ToString.Trim, Math.Abs(totalDP))
                                    End If
                                End If

                                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                            End If

                            lastMAP = .Item("Form_Name").ToString.Trim

                            TransNo = Generate_TranNo("Journal")
                            LastSerial = CInt(TransNo.Substring(TransNo.Length - 3, 3))
                            RemarkJurnal = "Jurnal Input Bahan Terpasang [" & .Item("Form_Name").ToString.Trim & "] #" & txtTransNo.Text.Trim & "."
                            TD.SaveJurnalHeader(Cmd, TransNo, "Pakai Bahan", RemarkJurnal, txtTransNo.Text.Trim)

                            dtMAP = New DataTable
                            MD.RetrieveAccountMappingJournal_ByAccountID(dtMAP, .Item("Form_Name").ToString.Trim, .Item("AccountID").ToString.Trim)
                            If dtMAP.Rows.Count <> 0 Then
                                If .Item("Form_Name").ToString.Trim = MappingName.PB_WIP Then
                                    TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(.Item("Amount").ToString.Trim) < 0, IIf(dtMAP.Rows(0).Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), dtMAP.Rows(0).Item("sisiGL").ToString.Trim), .Item("AccountID").ToString.Trim, Math.Abs(CDbl(.Item("Amount").ToString.Trim)))
                                ElseIf .Item("Form_Name").ToString.Trim = MappingName.PB_DP Then
                                    TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(.Item("Amount").ToString.Trim) > 0, IIf(dtMAP.Rows(0).Item("sisiGL").ToString.Trim = "DR", "CR", "DR"), dtMAP.Rows(0).Item("sisiGL").ToString.Trim), .Item("AccountID").ToString.Trim, Math.Abs(CDbl(.Item("Amount").ToString.Trim)))
                                End If
                            End If
                        Else
                            dtMAP = New DataTable
                            MD.RetrieveAccountMappingJournal_ByAccountID(dtMAP, .Item("Form_Name").ToString.Trim, .Item("AccountID").ToString.Trim)
                            If .Item("Form_Name").ToString.Trim = MappingName.PB_WIP Then
                                TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(.Item("Amount").ToString.Trim) < 0, IIf(dtMAP.Rows(0).Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), dtMAP.Rows(0).Item("sisiGL").ToString.Trim), .Item("AccountID").ToString.Trim, Math.Abs(CDbl(.Item("Amount").ToString.Trim)))
                            ElseIf .Item("Form_Name").ToString.Trim = MappingName.PB_DP Then
                                TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(.Item("Amount").ToString.Trim) > 0, IIf(dtMAP.Rows(0).Item("sisiGL").ToString.Trim = "DR", "CR", "DR"), dtMAP.Rows(0).Item("sisiGL").ToString.Trim), .Item("AccountID").ToString.Trim, Math.Abs(CDbl(.Item("Amount").ToString.Trim)))
                            End If
                        End If
                    End With
                Next

                dtTemp = New DataTable

                If lastMAP = MappingName.PB_WIP Then
                    MD.RetrieveGroupMappingJournal_ByForm_DEBETOnly(dtTemp, lastMAP)
                    If dtTemp.Rows.Count <> 0 Then
                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total < 0, IIf(dtTemp.Rows(0).Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), dtTemp.Rows(0).Item("sisiGL").ToString.Trim), dtTemp.Rows(0).Item("Account_ID").ToString.Trim, Math.Abs(totalWIP))
                    End If
                ElseIf lastMAP = MappingName.PB_DP Then
                    'Jurnal pendahulunya ada di sisi debet)
                    MD.RetrieveGroupMappingJournal_ByForm_CREDITOnly(dtTemp, lastMAP)
                    If dtTemp.Rows.Count <> 0 Then
                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total > 0, IIf(dtTemp.Rows(0).Item("sisiGL").ToString.Trim = "DR", "CR", "DR"), dtTemp.Rows(0).Item("sisiGL").ToString.Trim), dtTemp.Rows(0).Item("Account_ID").ToString.Trim, Math.Abs(totalDP))
                    End If
                End If

                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

                'Select Case dtGrp.Rows(i).Item("Form_Name").ToString.Trim
                '    Case MappingName.PB_WIP
                '        If dtMAP.Rows.Count <> 0 Then
                '            Total = getTotalWIP(dtGrp.Rows(i).Item("Form_Name").ToString.Trim)

                '            TransNo = Generate_TranNo("Journal")
                '            LastSerial = CInt(TransNo.Substring(TransNo.Length - 3, 3))
                '            RemarkJurnal = "Jurnal Input Bahan Terpasang [" & dtGrp.Rows(i).Item("Form_Name").ToString.Trim & "] #" & txtTransNo.Text.Trim & "."
                '            TD.SaveJurnalHeader(Cmd, TransNo, "Pakai Bahan", RemarkJurnal, txtTransNo.Text.Trim)

                '            For j = 0 To dtMAP.Rows.Count - 1
                '                dtJD = New DataTable
                '                With dtMAP.Rows(j)
                '                    TD.Retrieve_ListAccountWIP_ByProject_ForPB_ByAccountID(dtJD, txtProjectNo.Text.Trim, .Item("Account_ID").ToString.Trim, dtGrp.Rows(i).Item("Form_Name").ToString.Trim)
                '                    If dtJD.Rows.Count <> 0 Then
                '                        'Detail WIP (Credit Part) -- karena normalnya, nilai amount > 0 (maka ditambahkan pengecekan sisi GL
                '                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(dtJD.Rows(0).Item("Amount").ToString.Trim) < 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), .Item("Account_ID").ToString.Trim, Math.Abs(CDbl(dtJD.Rows(0).Item("Amount").ToString.Trim)))
                '                    Else
                '                        '(Debet Part)
                '                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total < 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), .Item("Account_ID").ToString.Trim, Math.Abs(Total))
                '                    End If
                '                End With
                '            Next

                '            UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                '        End If
                '    Case MappingName.PB_DP
                '        If dtMAP.Rows.Count <> 0 Then
                '            Total = getTotalDP(dtGrp.Rows(i).Item("Form_Name").ToString.Trim)

                '            TransNo = Generate_TranNo("Journal")
                '            LastSerial = CInt(TransNo.Substring(TransNo.Length - 3, 3))
                '            RemarkJurnal = "Jurnal Input Bahan Terpasang [" & dtGrp.Rows(i).Item("Form_Name").ToString.Trim & "] #" & txtTransNo.Text.Trim & "."
                '            TD.SaveJurnalHeader(Cmd, TransNo, "Pakai Bahan", RemarkJurnal, txtTransNo.Text.Trim)

                '            For j = 0 To dtMAP.Rows.Count - 1
                '                dtJD = New DataTable
                '                With dtMAP.Rows(j)
                '                    TD.Retrieve_ListAccountDP_ByProject_ForPB_ByAccountID(dtJD, txtProjectNo.Text.Trim, .Item("Account_ID").ToString.Trim, dtGrp.Rows(i).Item("Form_Name").ToString.Trim)
                '                    If dtJD.Rows.Count <> 0 Then
                '                        'Debet (nomor gl harus ada di jurnal pendahulunya)
                '                        'Karena nilai normalnya < 0 (jurnal pendahulu, di debet), maka jika lebih baru diubah sisi GLnya.
                '                        Amt = CDbl(dtJD.Rows(0).Item("Amount").ToString.Trim)
                '                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Amt > 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), .Item("Account_ID").ToString.Trim, Math.Abs(Amt))
                '                    Else
                '                        'Credit (tidak ada di jurnal pendahulunya)
                '                        TD.SaveJurnalDetail(Cmd, TransNo, IIf(Total > 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), .Item("Account_ID").ToString.Trim, Math.Abs(Total))
                '                    End If
                '                End With
                '            Next

                '            UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                '        End If
                'End Select
                'Next
            End If

            Cmd.CommandText = "Update Trans_Projects set Status_ID = 'CMP' where Project_No = '" & txtProjectNo.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            Trans.Commit()
            ApproveTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnSaveDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDtl.Click
        Dim dc(1) As DataColumn
        Dim i As Integer
        Dim dtView As New DataView(dtDetail)
        Dim dr As DataRow

        dc(0) = dtDetail.Columns(Fields.Item_ID)
        dc(1) = dtDetail.Columns(Fields.Item_Category)
        dtDetail.PrimaryKey = dc

        ' Validation
        dtView.RowFilter = "Item_ID = '" & txtItemID.Text.Trim & "' and Item_Category = '" & txtItemCategory.Text.Trim & "'"
        If StatusTransDtl = TransStatus.NewStatus Then
            If dtView.Count = 0 Then
                dr = dtDetail.NewRow
                With dr
                    .Item(Fields.Item_ID) = txtItemID.Text.Trim
                    .Item(Fields.Item_Name) = txtItemName.Text.Trim
                    .Item(Fields.Item_UOM) = txtItemUOM.Text.Trim
                    .Item(Fields.Item_Category) = txtItemCategory.Text.Trim
                    .Item(Fields.Qty) = CDbl(txtItemQty.Text.Trim)
                    .Item(Fields.PBD_ItemDate) = dtpItemDate.Value
                    .Item(Fields.PBD_ItemQtyPakai) = CDbl(txtItemQtyUsed.Text.Trim)
                    .Item(Fields.PBD_isPHM) = 0
                    .Item(Fields.PBD_ItemPrice) = GetAveragePrice(txtItemID.Text.Trim, False)
                End With
                dtDetail.Rows.Add(dr)
            Else
                MessageBox.Show("Item id '" & txtItemID.Text.Trim & "' and with category '" & txtItemCategory.Text.Trim & "' has been existed in list.", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If
        ElseIf StatusTransDtl = TransStatus.EditStatus Then
            If dtView.Count <> 0 Then
                For i = 0 To dtDetail.Rows.Count - 1
                    If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                        If dtDetail.Rows(i).Item(Fields.Item_ID).ToString.Trim = txtItemID.Text.Trim AndAlso dtDetail.Rows(i).Item(Fields.Item_Category).ToString.Trim = txtItemCategory.Text.Trim Then
                            dr = dtDetail.Rows(i)
                            dr(Fields.PBD_ItemDate) = dtpItemDate.Value
                            dr(Fields.PBD_ItemQtyPakai) = CDbl(txtItemQtyUsed.Text)
                            Exit For
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Cannot find item id '" & txtItemID.Text.Trim & "' and with category '" & txtItemCategory.Text.Trim & "'", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If
        End If

        gDetail.DataSource = dtDetail
        SetGrid()
        HitungDetailActual()
        btnCancelDtl_Click(Nothing, Nothing)
    End Sub

    Private Sub HitungDetailPHM()
        Dim i As Integer
        Dim Total As Double

        Total = 0
        For i = 0 To dtDetail.Rows.Count - 1
            With dtDetail.Rows(i)
                Total += (.Item(Fields.Qty) * .Item(Fields.PBD_ItemPrice))
            End With
        Next
        txtPHMTotal.Text = FormatAngka(Total, 2)
    End Sub

    Private Sub HitungDetailActual()
        Dim i As Integer
        Dim Total As Double

        Total = 0
        For i = 0 To dtDetail.Rows.Count - 1
            With dtDetail.Rows(i)
                Total += (.Item(Fields.PBD_ItemQtyPakai) * .Item(Fields.PBD_ItemPrice))
            End With
        Next
        txtActualTotal.Text = FormatAngka(Total, 2)
    End Sub

    Private Sub txtItemQtyUsed_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemQtyUsed.LostFocus
        If txtItemQtyUsed.Text.Trim = String.Empty Then txtItemQtyUsed.Text = 0
        txtItemQtyUsed.Text = FormatAngka(CDbl(txtItemQtyUsed.Text), 0)
    End Sub

    Private Sub SetGrid()
        gDetail.Columns(0).Width = 70
        gDetail.Columns(0).HeaderText = "Item ID"

        gDetail.Columns(1).Width = 140
        gDetail.Columns(1).HeaderText = "Item Name"
        gDetail.Columns(1).Frozen = True

        gDetail.Columns(2).Width = 60
        gDetail.Columns(2).HeaderText = "UOM"

        gDetail.Columns(3).Width = 140
        gDetail.Columns(3).HeaderText = "Item Category"

        gDetail.Columns(4).Width = 100
        gDetail.Columns(4).HeaderText = "Qty Planned"
        gDetail.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(4).DefaultCellStyle.Format = "#,##0"

        gDetail.Columns(5).Width = 100
        gDetail.Columns(5).HeaderText = "Date Used"
        gDetail.Columns(5).DefaultCellStyle.Format = "dd-MMM-yyyy"

        gDetail.Columns(6).Width = 100
        gDetail.Columns(6).HeaderText = "Qty Planned"
        gDetail.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(6).DefaultCellStyle.Format = "#,##0"

        gDetail.Columns(7).Visible = False

        gDetail.Columns(8).Width = 100
        gDetail.Columns(8).HeaderText = "Item Price"
        gDetail.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(8).DefaultCellStyle.Format = "#,##0.#0"
    End Sub

    Private Sub txtPHMNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPHMNo.KeyDown
        If e.KeyCode = Keys.F1 AndAlso StatusTransDtl = TransStatus.NoStatus Then
            If StatusTrans <> TransStatus.NoStatus Then
                Call frmSearch.InitFindData(":: Find PHM ::", "exec sp_Retrieve_Trans_PHM_forSearch_forPB '" & txtTransNo.Text.Trim & "'")
                Call frmSearch.AddFindColumn(1, "PHM_No", "PHM#", DataType.TypeString, 90)
                Call frmSearch.AddFindColumn(2, "Project_Name", "Project Name", DataType.TypeString, 200)
                Call frmSearch.AddFindColumn(3, "Nama", "Customer", DataType.TypeString, 200)
                Call frmSearch.AddFindColumn(4, "Project_No", "Project#", DataType.TypeString, 120)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    txtPHMNo.Text = frmSearch.txtResult1.Text.Trim
                    txtProjectNo.Text = frmSearch.txtResult4.Text.Trim
                    txtRemarks.Focus()
                End If
            End If
        End If
    End Sub

    'Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
    '    If StatusTrans <> TransStatus.NoStatus Then
    '        If MessageBox.Show("Are you sure to reload this PHM's detail?" & vbCrLf & "Detail will be reset to initial value.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '            dtDetail = New DataTable
    '            TD.Retrieve_PHM_ItemDtl_forPB(dtDetail, txtPHMNo.Text.Trim)
    '            gDetail.DataSource = dtDetail
    '            SetGrid()
    '        End If
    '    End If
    'End Sub

    Private Sub txtPHMNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPHMNo.LostFocus
        Dim dtData As New DataTable

        If StatusTrans <> TransStatus.NoStatus Then
            If txtPHMNo.Text.Trim <> String.Empty Then
                TD.Retrieve_PHM_Hdr_forPB(dtData, txtPHMNo.Text.Trim)
                If dtData.Rows.Count <> 0 Then
                    With dtData.Rows(0)
                        txtSPKNo.Text = .Item(Fields.PB_SPK).ToString.Trim
                        txtCustID.Text = .Item(Fields.Cust_ID).ToString.Trim
                        txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
                    End With
                Else
                    txtSPKNo.Text = String.Empty
                    txtCustID.Text = String.Empty
                    txtCustName.Text = String.Empty
                End If
            Else
                txtSPKNo.Text = String.Empty
                txtCustID.Text = String.Empty
                txtCustName.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub txtPHMNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPHMNo.TextChanged
        If StatusTransDtl <> TransStatus.NoStatus Then
            If txtPHMNo.Text.Trim <> PHMNo Then
                txtPHMNo.Text = PHMNo
                MessageBox.Show("Please cancel the detail modification process first, for this may change the list it has.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If txtPHMNo.Text.Trim <> PHMNo Then
                If MessageBox.Show("All referenced data (SPK#, Remarks, all Detail) from last PHM# will be reset." & vbCrLf & "Do you want to continue ?" & vbCrLf & "Yes : All data will be reset" & vbCrLf & "No : PHM# changes will be ignored", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    PHMNo = txtPHMNo.Text.Trim

                    dtDetail = New DataTable
                    TD.Retrieve_PHM_ItemDtl_forPB(dtDetail, txtPHMNo.Text.Trim)
                    gDetail.DataSource = dtDetail
                    SetGrid()
                    HitungDetailPHM()
                Else
                    txtPHMNo.Text = PHMNo
                End If
            End If
        End If
    End Sub

    Private Sub btnConfirmed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmed.Click
        If IDStatus = Status.PB_Approved AndAlso StatusTrans = TransStatus.NoStatus Then
            If userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to confirmed this Transaction# " & txtTransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If ConfirmData() Then
                        Me.Close()
                    End If
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Function ConfirmData() As Boolean
        Dim dtData As New DataTable

        TD.Retrieve_Projects_ByPHMNo(dtData, txtPHMNo.Text.Trim)
        If dtData.Rows.Count <> 0 Then
            If ConfirmTrans(dtData.Rows(0).Item("Project_No").ToString.Trim) Then
                MessageBox.Show("Data (Transaction# " & txtTransNo.Text.Trim & ") has been confirmed and closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ConfirmData = True
            End If
        Else
            MessageBox.Show("Cannot found any projects with this PHM#.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ConfirmData = False
        End If
    End Function

    Private Function ConfirmTrans(ByVal ProjectNo As String) As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction

        ConfirmTrans = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_PakaiBahan_Hdr_TM "
            queryParam = "'" & txtTransNo.Text.Trim & "', '" & Status.PB_Confirmed & "', '" & userlog.UserName & "'"
            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            'Karena status pb_confirmed sama dengan project completed, maka untuk status pakai status.pb_confirmed saja
            Query = "exec sp_Update_Trans_Projects_TM "
            queryParam = "'" & ProjectNo & "', '" & Status.PB_Confirmed & "', '" & userlog.UserName & "'"
            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Confirmed, GetDocCreator(txtTransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            UpdatetoInbox(txtTransNo.Text.Trim, Status.PB_Confirmed, userlog.UserName, "3")
            Insert_Trans_History(txtTransNo.Text.Trim, Me.Name, Status.HISTORY_Confirmed) 'Insert History transaction

            Trans.Commit()
            ConfirmTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnInsertDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertDtl.Click
        If Not StatusTrans = TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.NewStatus

            ClearDetailInput()
            SetDetailButton()
            SetInputDetail()
            SetColorDetail()

            txtItemID.Focus()
        End If
    End Sub

    Private Sub txtItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            If StatusTrans <> TransStatus.NoStatus Then
                Call frmSearch.InitFindData(":: Find Item ::", "exec sp_Retrieve_Master_Item_ForSearch")
                Call frmSearch.AddFindColumn(1, "Item_ID", "Item#", DataType.TypeString, 80)
                Call frmSearch.AddFindColumn(2, "Item_Name", "Item Name", DataType.TypeString, 200)
                Call frmSearch.AddFindColumn(3, "UOM", "UOM", DataType.TypeString, 60)
                Call frmSearch.AddFindColumn(4, "Item_Category", "Item Category", DataType.TypeString, 130)
                Call frmSearch.AddFindColumn(5, "Item_Type", "Type", DataType.TypeString, 100)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    txtItemID.Text = frmSearch.txtResult1.Text.Trim
                    txtItemName.Text = frmSearch.txtResult2.Text.Trim
                    txtItemUOM.Text = frmSearch.txtResult3.Text.Trim
                    txtItemCategory.Text = frmSearch.txtResult4.Text.Trim
                    dtpItemDate.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDtl.Click
        If StatusTrans <> TransStatus.NoStatus AndAlso IDStatus = Status.Draft Then
            If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If StatusTransDtl = TransStatus.NoStatus Then
                    If txtisPHM.Text = 0 Then
                        If MessageBox.Show("Are you sure to delete item# " & txtItemID.Text.Trim & " with category '" & txtItemCategory.Text.Trim & "' ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim dc(1) As DataColumn
                            Dim i As Integer
                            Dim dtView As New DataView(dtDetail)

                            dc(0) = dtDetail.Columns(Fields.Item_ID)
                            dc(1) = dtDetail.Columns(Fields.Item_Category)
                            dtDetail.PrimaryKey = dc

                            ' Validation
                            dtView.RowFilter = "Item_ID = '" & txtItemID.Text.Trim & "' and Item_Category = '" & txtItemCategory.Text.Trim & "'"
                            If dtView.Count <> 0 Then
                                For i = 0 To dtDetail.Rows.Count - 1
                                    If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                                        If dtDetail.Rows(i).Item(Fields.Item_ID).ToString.Trim = txtItemID.Text.Trim AndAlso dtDetail.Rows(i).Item(Fields.Item_Category).ToString.Trim = txtItemCategory.Text.Trim Then
                                            dtDetail.Rows(i).Delete()
                                            HitungDetailActual()
                                            Exit Sub
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Else
                        MessageBox.Show("This item is owned by PHM referenced." & vbCrLf & "Therefore cannot be deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If StatusTrans = TransStatus.NoStatus AndAlso txtTransNo.Text.Trim <> String.Empty AndAlso (StatusTrans = Status.PB_Rejected OrElse StatusTrans = Status.Draft) AndAlso (userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
            If MessageBox.Show("Are you sure to delete Transaction# " & txtTransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If DeletePB() Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Invalid process")
        End If
    End Sub

    Private Function DeletePB() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Trans As SqlTransaction

        DeletePB = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()
        Trans = Conn.BeginTransaction

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Cmd.CommandText = "exec sp_Delete_Trans_PakaiBahan_Hdr '" & txtTransNo.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            Trans.Commit()
            DeletePB = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function
End Class