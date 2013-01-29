'(20 Des 2012) Modified by ifebrian (designer form also)
'(08 Jan 2013) Remark insert inbox for confirmed data, and reject reason.
'(28 Jan 2013) Fixing bug reset serial, and bug on status

Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmPenawaranHargaProject
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt As New DataTable
    '----S : Datatable utk Working area
    Dim dt_item As New DataTable
    Dim dr_item As DataRow
    Dim dt_JasaOngkos As New DataTable
    Dim dr_JasaOngkos As DataRow
    Dim dt_JasaAdmin As New DataTable
    Dim dr_JasaAdmin As DataRow
    '----E : Datatable utk Working area

    'Dim dt_TB As New DataTable
    'Dim dt_po As New DataTable
    Dim dt_Survey As New DataTable
    Dim dt_Category As DataTable
    Dim id_login As String
    Dim Status_Proses_item As String
    Dim Status_Proses_JasaOngkos As String
    Dim Status_Proses_JasaAdmin As String
    Dim ttl_item, ttl_JasaOngkos, ttl_JasaAdmin, GrandTotal As Decimal
    Dim ttl_itemutama, ttl_itempendukung As Decimal
    Dim Status_Trans As String
    Dim alasanReject As String
    Dim frmReason As New Frm_Reason

    Public ViewFormName As String
    Public createPHM As Boolean


#Region "Interface"
    Private Sub txtMarkUp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarkUp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtMICEMaterialTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMICEMaterialTotal.TextChanged
        If txtTechnicianFeeTotal.Text = String.Empty Then txtTechnicianFeeTotal.Text = FormatAngka(0)
        If txtAdminQCFee.Text = String.Empty Then txtAdminQCFee.Text = FormatAngka(0)

        lbl_GrandTotalProject.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
    End Sub

    Private Sub txtTechnicianFeeTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTechnicianFeeTotal.TextChanged
        If txtMICEMaterialTotal.Text = String.Empty Then txtMICEMaterialTotal.Text = FormatAngka(0)
        If txtAdminQCFee.Text = String.Empty Then txtAdminQCFee.Text = FormatAngka(0)

        lbl_GrandTotalProject.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
    End Sub

    Private Sub txtMarkUpAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUpAmt.TextChanged
        If txtMICEMain.Text = String.Empty Then txtMICEMain.Text = FormatAngka(0)
        If txtSupportingTotal.Text = String.Empty Then txtSupportingTotal.Text = FormatAngka(0)

        txtSubTotalMain.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtMarkUpAmt.Text))
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtSubTotalMain.Text) + CDbl(txtSupportingTotal.Text))
    End Sub

    Private Sub txtSupportingTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupportingTotal.TextChanged
        If txtSubTotalMain.Text = String.Empty Then txtSubTotalMain.Text = FormatAngka(0)
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtSubTotalMain.Text) + CDbl(txtSupportingTotal.Text))
    End Sub

    Private Sub txtAdminQCFee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdminQCFee.TextChanged
        If txtTechnicianFeeTotal.Text = String.Empty Then txtTechnicianFeeTotal.Text = FormatAngka(0)
        If txtMICEMaterialTotal.Text = String.Empty Then txtMICEMaterialTotal.Text = FormatAngka(0)

        lbl_GrandTotalProject.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
    End Sub

    Private Sub txtMICEMain_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMICEMain.TextChanged
        If txtMarkUp.Text = String.Empty Then txtMarkUp.Text = FormatAngka(0)
        txtMarkUp_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub txtMarkUp_LostFocus(ByVal sender As Object, ByVal ByValue As System.EventArgs) Handles txtMarkUp.LostFocus
        Try
            txtMarkUp.Text = FormatAngka(CDbl(txtMarkUp.Text))
        Catch ex As Exception
            txtMarkUp.Text = FormatAngka(0)
        End Try

        txtMarkUpAmt.Text = FormatAngka((CDbl(txtMarkUp.Text) * CDbl(txtMICEMain.Text)) / 100)
    End Sub

    Private Sub FrmPenawaranHargaProject_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Status_Trans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            If Not createPHM Then
                Dim frmChild As New FrmViewPenawaranHargaProject

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            End If
        End If
    End Sub

    Private Sub FrmPenawaranHargaProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        'SetAccess(Me, userlog.AccessID, ViewFormName, btnNew, btnEdit, btnDelete, btnSave, btnCancel, Nothing, Nothing, Nothing)

        If txt_TransNo.Text.ToString.Trim <> String.Empty Then 'Jika dipanggil dari View Penerimaan Barang
            'LoadComboRevision()
            ClearInput()
            EnableInput(False)
            Clear_Item_Wa()
            Clear_JasaOngkos_Wa()
            LoadComboWA()

            Enable_Item_Wa(False)
            Enable_JasaOngkos_Wa(False)

            Enable_Button_Item_Wa(False)
            Enable_Button_JasaOngkos_Wa(False)

            Status_Trans = TransStatus.NoStatus
            'Load_HP()
            LoadComboRevision()
            id_status = id_status.ToString.Trim
            lbl_status.Text = GetStatus(id_status)
            If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) OrElse userlog.AccessID = Role.SuperAdmin Then
                If id_status = Status.PHProject_Completed Then
                    btnEdit.Enabled = False
                Else
                    btnEdit.Enabled = True
                End If

                P_Item.Enabled = False
                p_jasa.Enabled = False
            End If

            Load_PHProject_Item_Dtl()
            Load_PHProject_JasaOngkos_Dtl()
            CountTotalInitial()
            Load_HP()

            EnableButton()
        Else
            'Status_Trans = TransStatus.NoStatus
            'id_status = String.Empty
            'lbl_status.Text = String.Empty
            'btnNew.Enabled = True
            'Load_PHProject_Item_Dtl()

            btnNew_Click(Nothing, Nothing)
        End If
        SetItemCategory()
        SetBackColor_Item_Wa("READ")
        SetBackColor_JasaOngkos_Wa("READ")
    End Sub

    Private Sub InitComboWA()
        Dim drCat As DataRow

        dt_Category = New DataTable
        dt_Category.Columns.Add("category", System.Type.GetType("System.String"))

        dt_Category.Rows.Clear()

        drCat = dt_Category.NewRow
        drCat.Item(0) = String.Empty
        dt_Category.Rows.Add(drCat)

        drCat = dt_Category.NewRow
        drCat.Item(0) = "Manifold"
        dt_Category.Rows.Add(drCat)

        drCat = dt_Category.NewRow
        drCat.Item(0) = "Pipe To Kitchen"
        dt_Category.Rows.Add(drCat)

        drCat = dt_Category.NewRow
        drCat.Item(0) = "Titik Api"
        dt_Category.Rows.Add(drCat)

        drCat = dt_Category.NewRow
        drCat.Item(0) = "Supporting Material"
        dt_Category.Rows.Add(drCat)
    End Sub

    Private Sub SetItemCategory()
        Dim ItemID As String = txt_ItemID.Text
        Dim MD As New MasterData
        Dim dtCategory As New DataTable
        Dim drCategory As DataRow

        MD.RetrieveItemCategory_ByItemID(dtCategory, ItemID)

        If dtCategory.Rows.Count = 0 Then
            drCategory = dtCategory.NewRow
            drCategory.Item(0) = String.Empty
            dtCategory.Rows.Add(drCategory)
        End If

        cboItemCategory.DataSource = Nothing
        cboItemCategory.Items.Clear()
        cboItemCategory.DataSource = dtCategory
        cboItemCategory.DisplayMember = "Item_Category"
        cboItemCategory.ValueMember = "Item_Category"
        cboItemCategory.SelectedIndex = 0
    End Sub

    Private Sub LoadComboWA()
        InitComboWA()

        cboItemCategory.DataSource = dt_Category
        cboItemCategory.ValueMember = "category"
        cboItemCategory.DisplayMember = "category"
        cboItemCategory.SelectedIndex = 0
    End Sub

    Private Sub ClearInput()
        txt_CustomerName.Text = String.Empty
        txt_SurveyNo.Text = String.Empty
        txt_RemarkProject.Text = String.Empty
        txtCustID.Text = String.Empty

        gv_Item.DataSource = ""
        gv_Jasaongkos.DataSource = ""

        lbl_GrandTotalProject.Text = FormatAngka(0)
        txt_JasaOngkosTotal.Text = FormatAngka(0)
        txt_ItemTotal.Text = FormatAngka(0)

        txtMICEMain.Text = FormatAngka(0)
        txtMarkUp.Text = FormatAngka(0)
        txtMarkUpAmt.Text = FormatAngka(0)
        txtSubTotalMain.Text = FormatAngka(0)
        txtSupportingTotal.Text = FormatAngka(0)
        txtMarkUp_AdminFee.Text = FormatAngka(0)
        txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        txtMarkUp_QCFee.Text = FormatAngka(100)
        txtAdminQCFee.Text = FormatAngka(0)
        txtAdminFee.Text = FormatAngka(0)
        txtQCFee.Text = FormatAngka(0)
        txtMICEMaterialTotal.Text = FormatAngka(0)
        txtTechnicianFeeTotal.Text = FormatAngka(0)
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        dt_PenawaranDt.Enabled = boo
        txt_SurveyNo.ReadOnly = Not boo
        txt_CustomerName.ReadOnly = Not boo
        txt_RemarkProject.ReadOnly = Not boo
        txtMarkUp.ReadOnly = Not boo
        txtMarkUp_AdminFee.ReadOnly = Not boo
        txtMarkUp_AdminQCFee.ReadOnly = Not boo

        P_Item.Enabled = boo
        p_jasa.Enabled = boo

        cboRevisi.Enabled = Not boo
    End Sub

    Private Sub EnableButton()
        btnNew.Visible = False

        If id_status = Status.Draft OrElse id_status = String.Empty OrElse Status_Trans = TransStatus.RevisionStatus Then
            btnApprove.Visible = False
            btnReject.Visible = False
            btnRevision.Visible = False
            btnGenerate.Visible = False

            If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If Status_Trans = TransStatus.NewStatus OrElse Status_Trans = TransStatus.EditStatus OrElse Status_Trans = TransStatus.RevisionStatus Then
                    btnCancel.Enabled = True
                    btnSave.Enabled = True

                    btnEdit.Enabled = False
                    btnDelete.Enabled = False
                Else
                    btnCancel.Enabled = False
                    btnSave.Enabled = False

                    btnEdit.Enabled = True
                    btnDelete.Enabled = True
                End If
            Else
                btnCancel.Enabled = False
                btnSave.Enabled = False

                btnEdit.Enabled = False
                btnDelete.Enabled = False
            End If
        ElseIf id_status = Status.PHProject_Saved Then
            btnApprove.Visible = False
            btnReject.Visible = False
            btnRevision.Visible = False
            btnGenerate.Visible = False

            If userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin Then
                If Status_Trans = TransStatus.EditStatus Then
                    btnEdit.Enabled = False
                    btnDelete.Enabled = False

                    btnCancel.Enabled = False
                    btnSave.Enabled = False
                Else
                    btnEdit.Enabled = True
                    btnDelete.Enabled = True

                    btnCancel.Enabled = False
                    btnSave.Enabled = False
                End If
            Else
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnCancel.Enabled = False
                btnSave.Enabled = False
            End If
        ElseIf id_status = Status.PHProject_ReadyToProcessed Then
            btnCancel.Visible = False
            btnSave.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False

            btnApprove.Visible = True
            btnReject.Visible = True
            btnRevision.Visible = False
            btnGenerate.Visible = False

            If userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnApprove.Enabled = True
                btnReject.Enabled = True
            Else
                btnApprove.Enabled = False
                btnReject.Enabled = False
            End If
        ElseIf id_status = Status.PHProject_Completed Then
            btnGenerate.Visible = False

            If userlog.AccessID = Role.ProjectAdmin Then
                btnCancel.Enabled = False
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnRevision.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False
            ElseIf userlog.AccessID = Role.ProjectHead Then
                btnCancel.Enabled = False
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnRevision.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False
            ElseIf userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnCancel.Visible = False
                btnSave.Visible = False
                btnEdit.Visible = False
                btnDelete.Visible = False
                btnRevision.Visible = False
                btnApprove.Enabled = False
                btnReject.Enabled = False
                btnGenerate.Enabled = True

                btnApprove.Visible = True
                btnReject.Visible = True
                btnGenerate.Visible = True
            End If
        ElseIf id_status = Status.PHProject_Rejected Then
            btnGenerate.Visible = False

            If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                btnCancel.Enabled = False
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnRevision.Visible = True
                btnRevision.Enabled = True

                btnApprove.Visible = False
                btnReject.Visible = False
            ElseIf userlog.AccessID = Role.ProjectHead Then
                btnCancel.Enabled = False
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnRevision.Visible = False
                btnApprove.Visible = False
                btnReject.Visible = False
            ElseIf userlog.AccessID = Role.MarketingAdmin Then
                btnCancel.Visible = False
                btnSave.Visible = False
                btnEdit.Visible = False
                btnDelete.Visible = False
                btnRevision.Visible = False
                btnApprove.Enabled = False
                btnReject.Enabled = False

                btnApprove.Visible = True
                btnReject.Visible = True
            End If
        End If
    End Sub

    Private Sub txt_SurveyNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SurveyNo.KeyDown
        Dim sql As String

        If e.KeyCode = Keys.F1 Then
            Try
                sql = "Select Survey_No,Survey_date, a.Cust_ID, isnull(b.nama, '') as Cust_name,a.Survey_Remark from Trans_Survey_Hdr a " & _
                      "Left join Master_Customer b on a.Cust_ID = B.Cust_ID " & _
                      "where a.Active_Flag = 'Y' " & _
                      "and Survey_No not in(Select Survey_No from Trans_Projects h) and a.status_id = 'PPA'"

                CallandGetSearchData(sql, "Survey_No", "Survey_Date", "Cust_ID", "Cust_Name", "Survey_Remark")
                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    txt_SurveyNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtCustID.Text = frmSearch.txtResult3.Text.ToString.Trim
                    txt_CustomerName.Text = frmSearch.txtResult4.Text.ToString.Trim
                    Load_PHProject_Item_Dtl()
                    Load_PHProject_JasaOngkos_Dtl()
                    CountSubTotal()
                    HitungTotal()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_SurveyNo.Text.Trim <> String.Empty Then
                Try
                    Load_PHProject_Item_Dtl()
                    Load_PHProject_JasaOngkos_Dtl()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub Load_HP()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            'Pindahin dr datatable PO ke datatable TrmBrg                            
            dt_hdr = New DataTable
            Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_Hdr_byKey '" + txt_TransNo.Text.Trim + "'," & cboRevisi.SelectedItem
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            If dt_hdr.Rows.Count > 0 Then
                With dt_hdr.Rows(0)
                    dt_PenawaranDt.Value = .Item("PHP_Date")
                    txtCustID.Text = .Item("Cust_ID").ToString.Trim
                    txt_CustomerName.Text = .Item("Nama").ToString.Trim
                    txt_SurveyNo.Text = .Item("Survey_No").ToString.Trim
                    txt_RemarkProject.Text = .Item("Remarks").ToString.Trim
                    txtMarkUp.Text = FormatAngka(CDbl(.Item("MarkUp_Pct").ToString.Trim))

                    txtMarkUp.Text = FormatAngka(.Item("MarkUp_Pct"))
                    txtAdminQCFee.Text = FormatAngka(.Item("AdminQC_Amt"))
                    txtAdminFee.Text = FormatAngka(.Item("Admin_Amt"))
                    txtQCFee.Text = FormatAngka(.Item("QC_Amt"))

                    id_status = .Item("status_id").ToString.Trim

                    Dim test As String = txt_RemarkProject.Text.Trim

                    If .Item("AdminQC_Persen").ToString = "" Then
                        txtMarkUp_AdminQCFee.Text = 0
                    Else
                        txtMarkUp_AdminQCFee.Text = FormatAngka(.Item("AdminQC_Persen"))
                    End If

                    If .Item("Admin_Persen").ToString = "" Then
                        txtMarkUp_AdminFee.Text = 0
                    Else
                        txtMarkUp_AdminFee.Text = FormatAngka(.Item("Admin_Persen"))
                    End If

                    If .Item("QC_Persen").ToString = "" Then
                        txtMarkUp_QCFee.Text = 0
                    Else
                        txtMarkUp_QCFee.Text = FormatAngka(.Item("QC_Persen"))
                    End If
                End With
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Main Button"
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Status_Trans = TransStatus.NewStatus
        id_status = Status.Draft

        ClearInput()
        EnableInput(True)
        Enable_Button_Item_Wa(True)
        EnableButton()
        btnSave.Enabled = True
        btnCancel.Enabled = True
        Status_Proses_item = String.Empty
        Status_Proses_JasaOngkos = String.Empty
        lbl_status.Text = GetStatus(id_status)

        P_Item.Enabled = True
        p_jasa.Enabled = True

        cboRevisi.Items.Add(0)
        cboRevisi.SelectedIndex = 0

        txt_SurveyNo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim i As Integer
        Dim TD As New TransData

        i = TD.RetrieveMaxSeq_TransPHProjectHdr(txt_TransNo.Text.Trim)
        If cboRevisi.SelectedItem = i AndAlso Status_Trans = TransStatus.NoStatus Then
            Status_Trans = TransStatus.EditStatus
            EnableInput(True)

            P_Item.Enabled = True
            p_jasa.Enabled = True

            EnableButton()
            btnSave.Enabled = True
            btnCancel.Enabled = True
        Else
            If cboRevisi.SelectedItem <> i Then
                MessageBox.Show("Please choose the lastest revision number to edit this document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Status_Trans = TransStatus.NewStatus Then
            Dim frmChild As New FrmViewPenawaranHargaProject

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmViewPenawaranHargaProject" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Hide()
        Else
            'Karena dipanggil dari View, maka kalau cancel, harusnya balik ke data sebelumnya
            Status_Trans = TransStatus.NoStatus
            Load_HP()
            EnableButton()

            lbl_status.Text = GetStatus(id_status)
            If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) OrElse userlog.AccessID = Role.SuperAdmin Then
                If id_status = Status.PHProject_Completed OrElse id_status = Status.PHProject_Rejected Then
                    btnEdit.Enabled = False
                Else
                    btnEdit.Enabled = True
                End If

                P_Item.Enabled = False
                p_jasa.Enabled = False
            End If

            LoadComboRevision()
            Load_PHProject_Item_Dtl()
            Load_PHProject_JasaOngkos_Dtl()
            CountSubTotal()
            HitungTotal()

            SetBackColor_Item_Wa("READ")
            Clear_Item_Wa()
            EnableInput(False)
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim i As Integer
        Dim TD As New TransData

        i = TD.RetrieveMaxSeq_TransPHProjectHdr(txt_TransNo.Text.Trim)
        If i = CInt(cboRevisi.SelectedItem) AndAlso Status_Trans = TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this transaction #" & txt_TransNo.Text.Trim & " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Dim ObjTrans As SqlTransaction
                ObjTrans = Conn.BeginTransaction("Trans")
                Cmd.Transaction = ObjTrans

                Try
                    'id_status = Status.PHProject_Cancelled  'cancelled by applicant
                    'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                    'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

                    Cmd.CommandText = "EXEC sp_Delete_Trans_PHProject_Hdr '" & txt_TransNo.Text.Trim & "'," & cboRevisi.SelectedItem & ",'" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Delete) 'Insert History transaction

                    ObjTrans.Commit()
                    Conn.Close()
                    MessageBox.Show("Penawaran Harga Project : " & txt_TransNo.Text.Trim & " Has been Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Close()
                Catch ex As Exception
                    ObjTrans.Rollback()
                    Conn.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Else
            If cboRevisi.SelectedItem <> i Then
                MessageBox.Show("Please choose the lastest revision number to delete this document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Status_Trans <> TransStatus.NoStatus Then
            If gv_Item.Rows.Count = 0 Then
                MessageBox.Show("This transaction has not been properly filled (Material)." & vbCrLf & "Saving Process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If gv_Jasaongkos.Rows.Count = 0 Then
                MessageBox.Show("This transaction has not been properly filled (Service/Other)." & vbCrLf & "Saving Process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'If CDbl(txtMarkUp_AdminQCFee.Text) < CDbl(txtMarkUp_AdminFee.Text) Then
            '    MessageBox.Show("Admin & QC Fee's markup must be higher or equal with admin fee's markup.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtMarkUp_AdminFee.Focus()
            '    Exit Sub
            'End If

            'Set Transaction
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Dim ObjTrans As SqlTransaction
            ObjTrans = Conn.BeginTransaction("Trans")
            Cmd.Transaction = ObjTrans

            Dim LastSerial As Integer
            Dim currRev As Integer = cboRevisi.SelectedItem.ToString
            Dim remarks_Stok As String

            '----Save Penawaran Harga Project Header   
            Try
                'Cause this form is for insert Terim Barang, so next status is Waiting for Purchasing (WAFP)
                If Status_Trans = TransStatus.NewStatus OrElse Status_Trans = TransStatus.RevisionStatus Then
                    If Status_Trans = TransStatus.NewStatus Then
                        txt_TransNo.Text = Generate_TranNo(Me.Name)
                        LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
                    End If

                    If Status_Trans = TransStatus.RevisionStatus Then
                        Cmd.CommandText = "exec sp_Delete_Trans_PHProject_Hdr_Exclude '" & txt_TransNo.Text.Trim & "'," & currRev & ", '" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If

                    remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
                    id_status = Status.PHProject_Saved  'Waiting approval from Technical Head                
                    Cmd.CommandText = "EXEC sp_Insert_Trans_PHProject_Hdr '" & txt_TransNo.Text.Trim & "'," & currRev & ",'" & _
                                                 dt_PenawaranDt.Value & "','" & _
                                                 txt_SurveyNo.Text.Trim & "','" & _
                                                 txt_RemarkProject.Text.Trim & "'," & _
                                                 CDbl(txtMarkUp.Text) & "," & _
                                                 CDbl(txtAdminQCFee.Text) & "," & _
                                                 CDbl(txtAdminFee.Text) & "," & _
                                                 CDbl(txtQCFee.Text) & "," & _
                                                 CDbl(txtMarkUp_AdminQCFee.Text) & "," & _
                                                 CDbl(txtMarkUp_AdminFee.Text) & "," & _
                                                 CDbl(txtMarkUp_QCFee.Text) & "," & _
                                                 CDbl(lbl_GrandTotalProject.Text) & ",'" & _
                                                 id_status & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    'Save Detail Item
                    For Each item As DataRow In dt_item.Rows
                        If item.RowState = DataRowState.Added OrElse ((item.RowState = DataRowState.Unchanged OrElse item.RowState = DataRowState.Modified) AndAlso Status_Trans = TransStatus.RevisionStatus) Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Item_ID").ToString.Trim & "','" & item("UoM").ToString.Trim & "'," & item("Qty") & "," & _
                                              item("Price") & "," & item("SubTotal") & ",'" & item(Fields.Item_Category).ToString.Trim & "','" & item(Fields.Item_Type).ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Modified Then
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text & "'," & currRev & ",'" & item("Item_ID").ToString.Trim & "'," & _
                                              item("UoM") & "," & item("Qty") & "," & item("Price") & "," & item("SubTotal") & ",'" & item(Fields.Item_Category) & "','" & item(Fields.Item_Type) & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Item_ID", DataRowVersion.Original).ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next


                    'Save Detail Jasa Ongkos
                    For Each item As DataRow In dt_JasaOngkos.Rows
                        If item.RowState = DataRowState.Added OrElse ((item.RowState = DataRowState.Unchanged OrElse item.RowState = DataRowState.Modified) AndAlso Status_Trans = TransStatus.RevisionStatus) Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Jasa_ID").ToString.Trim & "'," & item("Jlh_Hari") & "," & item("Ongkos") & "," & _
                                              item("SubTotal") & ",'" & item("remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Modified Then
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text & "'," & currRev & ",'" & item("Jasa_ID").ToString.Trim & "'," & _
                                              item("Jlh_Hari") & "," & item("Ongkos") & "," & item("SubTotal") & ",'" & item("Remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Jasa_ID", DataRowVersion.Original).ToString & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    'add by kparlind 05-jan-2013: Update status dokumen PH Project menjadi Completed karna sudah di proses oleh ADMIN Marketing
                    Cmd.CommandText = "Update Trans_Survey_Hdr set Status_ID = 'CMP' where Survey_No = '" & txt_SurveyNo.Text.Trim & "'"
                    Cmd.ExecuteNonQuery()

                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to INBOX Purchasing

                    If Status_Trans <> TransStatus.RevisionStatus Then
                        UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    End If
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction

                    MessageBox.Show("Form Penawaran Harga Project : " & txt_TransNo.Text.Trim & " has been submitted to " & Hirarki.PHProject_Saved & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Status_Trans = TransStatus.EditStatus AndAlso id_status.Trim = Status.PHProject_Saved Then
                    If id_status.Trim = Status.PHProject_Saved Then 'Waiting approval  from Technical Head                             
                        id_status = Status.PHProject_ReadyToProcessed  'Completed
                    End If
                    'update Penawaran harga project Header
                    Cmd.CommandText = "EXEC sp_Update_Trans_PHProject_Hdr '" & txt_TransNo.Text & "'," & currRev & ",'" & dt_PenawaranDt.Value.ToString("yyyy-MM-dd") & "','" & _
                                       txt_SurveyNo.Text.Trim & "','" & txt_RemarkProject.Text & "'," & _
                                       CDbl(txtMarkUp.Text) & "," & CDbl(txtAdminQCFee.Text) & "," & CDbl(txtAdminFee.Text) & "," & _
                                       CDbl(txtQCFee.Text) & "," & CDbl(lbl_GrandTotalProject.Text) & ",'" & _
                                       id_status + "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    'update Penawaran harga project Item
                    For Each item As DataRow In dt_item.Rows
                        If item.RowState = DataRowState.Added Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Item_ID").ToString.Trim & "','" & item("UoM").ToString.Trim & "'," & item("Qty") & "," & _
                                              item("Price") & "," & item("SubTotal") & ",'" & item(Fields.Item_Category).ToString.Trim & "','" & item(Fields.Item_Type).ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Item_ID", DataRowVersion.Original).ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHProject_Item_Dtl '" & txt_TransNo.Text & "'," & currRev & ",'" & item("Item_ID").ToString.Trim & "'," & _
                                              item("UoM") & "," & item("Qty") & "," & item("Price") & "," & item("SubTotal") & ",'" & item(Fields.Item_Category) & "','" & item(Fields.Item_Type) & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    'update Penawaran harga project Jasa Ongkos
                    For Each item As DataRow In dt_JasaOngkos.Rows
                        If item.RowState = DataRowState.Added Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Jasa_ID").ToString.Trim & "'," & item("Jlh_Hari") & "," & item("Ongkos") & "," & _
                                              item("SubTotal") & ",'" & item("remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()

                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Jasa_ID", DataRowVersion.Original).ToString & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHProject_JasaOngkos_Dtl '" & txt_TransNo.Text & "'," & currRev & ",'" & item("Jasa_ID").ToString.Trim & "'," & _
                                              item("Jlh_Hari") & "," & item("Ongkos") & "," & item("SubTotal") & ",'" & item("Remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                    If id_status <> Status.PHProject_Completed Then
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to NEXT APPROVAL
                    End If
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction

                    MessageBox.Show("Form Penawaran Harga Project : " & txt_TransNo.Text.Trim & " has been submitted to " & Hirarki.PHProject_ReadyToProcessed & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ObjTrans.Commit()
                Conn.Close()

                If Status_Trans = TransStatus.NewStatus Then 'jika form ini dipanggil dari View
                    Status_Trans = TransStatus.NoStatus
                    Me.Close()
                Else
                    Status_Trans = TransStatus.NoStatus
                    FrmPenawaranHargaProject_Load(Nothing, Nothing)
                End If
            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "Proses"
    Private Sub HitungTotal()
        txtSubTotalMain.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtMarkUpAmt.Text))
        txtSupportingTotal.Text = FormatAngka(ttl_itempendukung)
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtSubTotalMain.Text) + CDbl(txtSupportingTotal.Text))

        '--started : Added by kparlind
        If (txtMarkUp_AdminQCFee.Text = String.Empty OrElse txtMarkUp_AdminQCFee.Text = "NaN") Then txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        If (txtMarkUp_AdminFee.Text = String.Empty OrElse txtMarkUp_AdminFee.Text = "NaN") Then txtMarkUp_AdminFee.Text = FormatAngka(0)
        If (txtMarkUp_QCFee.Text = String.Empty OrElse txtMarkUp_QCFee.Text = "NaN") Then txtMarkUp_QCFee.Text = FormatAngka(0)
        '--ended : Added by kparlind
        txtAdminQCFee.Text = FormatAngka((CDbl(txtMarkUp_AdminQCFee.Text) * (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))) / 100)
        'txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)
        'txtQCFee.Text = FormatAngka((CDbl(txtMarkUp_QCFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)
    End Sub

    Private Sub CountTotalInitial()
        Dim ctr As Double
        CountSubTotal()

        txtSubTotalMain.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtMarkUpAmt.Text))
        'Remarked by kparlind, rumus yg diremarked berbeda dengan di txtMarkUpAmt_LostFocus
        'txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtSupportingTotal.Text))
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtSubTotalMain.Text) + CDbl(txtSupportingTotal.Text))

        ctr = (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))
        txtMarkUp_AdminQCFee.Text = FormatAngka((CDbl(txtAdminQCFee.Text) / IIf(ctr = 0, 1, ctr)) * 100)
        txtMarkUp_AdminFee.Text = FormatAngka((CDbl(txtAdminFee.Text) / IIf(CDbl(txtAdminQCFee.Text) = 0, 1, CDbl(txtAdminQCFee.Text))) * 100)
        'Remarked by kparlind di anyer
        'txtMarkUp_QCFee.Text = FormatAngka((CDbl(txtQCFee.Text) / CDbl(txtAdminQCFee.Text)) * CDbl(txtMarkUp_AdminQCFee.Text))
        txtMarkUp_QCFee.Text = FormatAngka(100 - CDbl(txtMarkUp_AdminFee.Text))
    End Sub

    Private Sub CountSubTotal()
        'Hitung Item
        ttl_item = 0
        ttl_itemutama = 0
        ttl_itempendukung = 0

        For Each item As DataRow In dt_item.Rows
            If item("Item_Type") = ITEM_TYPE.UTAMA Then
                ttl_itemutama += item("SubTotal")
            Else
                ttl_itempendukung += item("SubTotal")
            End If
            ttl_item = ttl_item + item("SubTotal")
        Next
        txt_ItemTotal.Text = FormatAngka(ttl_item)
        txtMICEMain.Text = FormatAngka(ttl_itemutama)
        txtMarkUpAmt.Text = FormatAngka((CDbl(txtMarkUp.Text) * CDbl(txtMICEMain.Text)) / 100) 'add by kparlin 22-dec-2012                
        txtSupportingTotal.Text = FormatAngka(ttl_itempendukung)

        Dim a As Double = CDbl(txtAdminQCFee.Text)

        'Hitung Jasa Ongkos
        ttl_JasaOngkos = 0
        For Each item As DataRow In dt_JasaOngkos.Rows
            ttl_JasaOngkos = ttl_JasaOngkos + item("SubTotal")
        Next
        txt_JasaOngkosTotal.Text = FormatAngka(ttl_JasaOngkos)
        txtTechnicianFeeTotal.Text = FormatAngka(ttl_JasaOngkos)

        Dim b As Double = CDbl(txtAdminQCFee.Text)
    End Sub
#End Region

#Region "Item Material"
    Private Sub Enable_Item_Wa(ByVal boo As Boolean)
        txt_ItemID.ReadOnly = Not boo
        Txt_ItemQty.ReadOnly = Not boo
        cboItemCategory.Enabled = boo
    End Sub

    Private Sub Clear_Item_Wa()
        txt_ItemID.Text = String.Empty
        txt_ItemName.Text = String.Empty
        Txt_ItemQty.Text = String.Empty
        Txt_ItemUoM.Text = String.Empty
        txt_ItemHarga.Text = String.Empty
        txt_ItemSubTotal.Text = String.Empty
        txt_ItemType.Text = String.Empty
    End Sub

    Private Sub SetBackColor_Item_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_ItemID.BackColor = Color.LightGray
            Txt_ItemQty.BackColor = Color.LightGray
            cboItemCategory.BackColor = Color.LightGray
        ElseIf proses = "UPDATE" Then
            txt_ItemID.BackColor = Color.LightGray
            Txt_ItemQty.BackColor = Color.LightGoldenrodYellow
            cboItemCategory.BackColor = Color.LightGoldenrodYellow
        ElseIf proses = "INSERT" Then
            txt_ItemID.BackColor = Color.LightGoldenrodYellow
            Txt_ItemQty.BackColor = Color.LightGoldenrodYellow
            cboItemCategory.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub Enable_Button_Item_Wa(ByVal boo As Boolean)
        btn_Iteminsert.Enabled = boo
        btn_Itemedit.Enabled = boo
        btn_Itemsave.Enabled = Not boo
        btn_Itemdelete.Enabled = boo
        Btn_Itemcancel.Enabled = Not boo
    End Sub

    Private Sub SetGrid_item()
        gv_Item.Columns(0).Width = 80
        gv_Item.Columns(0).HeaderText = "Item ID"

        gv_Item.Columns(1).Width = 230
        gv_Item.Columns(1).HeaderText = "Item Name"

        gv_Item.Columns(2).Width = 120
        gv_Item.Columns(2).HeaderText = "Category"

        gv_Item.Columns(3).Width = 100
        gv_Item.Columns(3).HeaderText = "Type"

        gv_Item.Columns(4).Width = 50
        gv_Item.Columns(4).HeaderText = "UoM"

        gv_Item.Columns(5).Width = 80
        gv_Item.Columns(5).HeaderText = "Qty"
        gv_Item.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Item.Columns(5).DefaultCellStyle.Format = "#,##0"
        gv_Item.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_Item.Columns(6).Width = 100
        gv_Item.Columns(6).HeaderText = "Item Price"
        gv_Item.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Item.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv_Item.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_Item.Columns(7).Width = 120
        gv_Item.Columns(7).HeaderText = "Sub Total"
        gv_Item.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Item.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        gv_Item.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                'CallandGetSearchData("Select Item_id,Item_Name,Item_Type,UoM,Sales_Price as Harga from Master_Item_Hdr", "Item_ID", "Item_Name", "Item_type", "UoM", "Harga")

                Call frmSearch.InitFindData("Find Item", "Select Item_id,Item_Name,Item_Type,a.Warehouse_ID,b.Warehouse_Name,UoM from Master_Item_Hdr a Left join Master_Warehouse b on a.warehouse_id = b.warehouse_id")
                Call frmSearch.AddFindColumn(1, "Item_ID", "Item ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(2, "Item_Name", "Item Name", DataType.TypeString, 200)
                Call frmSearch.AddFindColumn(3, "Item_Type", "Item Type", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(4, "Warehouse_ID", "Warehouse ID", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(5, "Warehouse_Name", "Warehouse Name", DataType.TypeString, 100)
                Call frmSearch.AddFindColumn(6, "UoM", "UoM", DataType.TypeDouble, 120)
                frmSearch.ShowDialog()

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    'If Conn.State = ConnectionState.Closed Then
                    '    Conn.Open()
                    'End If

                    'If dt_dtl.Rows.Count > 0 Then
                    txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_ItemName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_ItemType.Text = frmSearch.txtResult3.Text.ToString.Trim
                    Txt_ItemUoM.Text = frmSearch.txtresult6.Text.ToString.Trim
                    Txt_ItemQty.Text = FormatAngka(0, 0)

                    Dim harga As Double
                    Dim MD As New MasterData

                    harga = MD.RetrieveHargaSatuan(frmSearch.txtResult4.Text.ToString.Trim, txt_ItemID.Text.Trim)
                    txt_ItemHarga.Text = FormatAngka(harga)
                    txt_ItemSubTotal.Text = FormatAngka(CDbl(txt_ItemHarga.Text) * CDbl(Txt_ItemQty.Text))

                    SetItemCategory()

                    Txt_ItemQty.Focus()
                    'Else
                    '    MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    '    Exit Sub
                    'End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            dim MD as New MasterData 

            If txt_ItemID.Text.Trim <> String.Empty Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemName.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_ItemUoM.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        txt_ItemType.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_Type).ToString
                        txt_ItemHarga.Text = FormatAngka(MD.RetrieveHargaSatuan(dt_dtl.Rows(0).Item(GlobalVar.Fields.Warehouse_ID).ToString, txt_ItemID.Text.Trim))
                        Txt_ItemQty.Focus()
                    Else
                        MessageBox.Show("Item cannot be found. Please make sure the Item Number inputted is valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub Txt_ItemQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ItemQty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_ItemQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ItemQty.LostFocus
        If Txt_ItemQty.Text.Trim = String.Empty Then
            Txt_ItemQty.Text = FormatAngka(0, 0)
        Else
            Txt_ItemQty.Text = FormatAngka(CDbl(Txt_ItemQty.Text.Trim), 0)
        End If

        If txt_ItemHarga.Text.Trim = String.Empty Then
            txt_ItemHarga.Text = FormatAngka(0)
        End If

        txt_ItemSubTotal.Text = FormatAngka(CDbl(Txt_ItemQty.Text.Trim) * CDbl(txt_ItemHarga.Text))
    End Sub

    'Private Sub txt_ItemHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ItemHarga.Leave
    '    If txt_ItemHarga.Text.Trim <> "" AndAlso Txt_ItemQty.Text.Trim <> "" Then
    '        txt_ItemSubTotal.Text = txt_ItemHarga.Text.Trim * Txt_ItemQty.Text.Trim
    '    Else
    '        txt_ItemSubTotal.Text = 0
    '    End If

    '    If txt_ItemHarga.Text.Trim = String.Empty Then
    '        txt_ItemHarga.Text = 0
    '    End If

    '    txt_ItemHarga.Text = Format(CDbl(txt_ItemHarga.Text), "#,##0.#0")

    '    btn_Itemsave.Focus()
    'End Sub

    Private Sub gv_Item_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_Item.MouseClick
        If Not (Status_Proses_item = "Update" OrElse Status_Proses_item = "Insert") Then
            If String.IsNullOrEmpty(gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value) = False Then
                txt_ItemID.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
                txt_ItemName.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim

                SetItemCategory()
                Try
                    cboItemCategory.SelectedValue = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Category).Value.ToString.Trim
                Catch ex As Exception
                    cboItemCategory.SelectedIndex = 0
                End Try

                cboItemCategory.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Category).Value.ToString.Trim
                txt_ItemType.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Type).Value.ToString.Trim
                Txt_ItemUoM.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
                Txt_ItemQty.Text = FormatAngka(CDbl(gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty).Value.ToString.Trim), 0)
                txt_ItemHarga.Text = FormatAngka(CDbl(gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Price).Value.ToString.Trim))
                If gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.SubTotal).Value IsNot Nothing Then
                    txt_ItemSubTotal.Text = FormatAngka(CDbl(gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.SubTotal).Value.ToString.Trim))
                Else
                    txt_ItemSubTotal.Text = FormatAngka(0)
                End If

                txtIndex.Text = gv_Item.CurrentCell.RowIndex
                txtItemCategoryOld.Text = gv_Item.Rows(gv_Item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Category).Value.ToString.Trim
            End If
        End If
    End Sub

    Private Sub Load_PHProject_Item_Dtl()
        dt_item.Clear()
        Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_Item_Dtl_byKey '" + txt_TransNo.Text + "'," & cboRevisi.SelectedItem
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        If dt_item.Rows.Count > 0 Then
            gv_Item.DataSource = dt_item
            SetGrid_item()
        Else
            'apabila masih data baru, maka data yang ditarik adalah dari table survey sebgaia patokan data awal
            dt_Survey.Clear()
            Cmd.CommandText = "EXEC sp_Retrieve_Trans_Survey_Dtl_BySurveyNo_ForProject '" + txt_SurveyNo.Text + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Survey)
            If dt_Survey.Rows.Count > 0 Then
                For Each item As DataRow In dt_Survey.Rows
                    Dim dr As DataRow
                    dr = dt_item.NewRow
                    dr("Item_ID") = item("Item_ID").ToString.Trim
                    dr("Item_Name") = item("Item_Name").ToString.Trim
                    dr("Item_Category") = item("Item_Category").ToString.Trim
                    dr("Item_Type") = item("Item_Type").ToString.Trim
                    dr("UoM") = item("Item_UOM").ToString.Trim
                    dr("Qty") = item("Item_Qty")
                    dr("Price") = GetMaintainPrice("Instalasi", item("Item_ID"), "Sales_Price")
                    dr("SubTotal") = dr("Qty") * dr("Price")
                    dt_item.Rows.Add(dr)
                Next
                gv_Item.DataSource = dt_item
                SetGrid_item()
            End If
        End If
        Enable_Button_Item_Wa(True)
        Enable_Item_Wa(False)
        gv_Item.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_Iteminsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Iteminsert.Click
        Status_Proses_item = "Insert"
        Enable_Item_Wa(True)
        Clear_Item_Wa()
        SetBackColor_Item_Wa("INSERT")

        Enable_Button_Item_Wa(False)

        txt_ItemID.Focus()
    End Sub

    Private Sub btn_Itemedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemedit.Click
        If txt_ItemID.Text = String.Empty Then
            MessageBox.Show("Please choose 1 data to be edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Status_Proses_item = "Update"
        Enable_Item_Wa(True)
        SetBackColor_Item_Wa("UPDATE")
        txt_ItemID.ReadOnly = True 'karna primary Key

        Enable_Button_Item_Wa(False)

        cboItemCategory.Enabled = False
        txt_ItemID.BackColor = Color.LightGray
        Txt_ItemQty.Focus()
    End Sub

    Private Sub Btn_Itemcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Itemcancel.Click
        Status_Proses_item = String.Empty

        Enable_Item_Wa(False)
        Clear_Item_Wa()
        SetBackColor_Item_Wa("READ")

        Enable_Button_Item_Wa(True)
        gv_Item.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_Itemdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemdelete.Click
        Dim dc(1) As DataColumn
        Dim pk(1) As String
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID")
        dc(1) = dt_item.Columns("Item_Category")
        dt_item.PrimaryKey = dc

        If txt_ItemID.Text.Trim = String.Empty Then
            MessageBox.Show("Please choose 1 data to be deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses_item = "Delete"

            pk(0) = txt_ItemID.Text.ToString.Trim
            pk(1) = cboItemCategory.SelectedValue.trim
            da = dt_item.Rows.Find(pk)
            If da IsNot Nothing Then
                da.Delete()
                Enable_Button_Item_Wa(True)
                gv_Item.Focus()
            End If
        End If
    End Sub

    Private Sub btn_Itemsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemsave.Click
        'Dim dc(1) As DataColumn
        Dim dtView As New DataView(dt_item)
        Dim da As Data.DataRow
        Dim i As Integer

        'dc(0) = dt_item.Columns("Item_ID")
        'dc(1) = dt_item.Columns("Item_Category")
        'dt_item.PrimaryKey = dc

        ' Validation
        If Txt_ItemQty.Text.Trim = String.Empty Then
            MessageBox.Show("Quantity must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txt_ItemHarga.Text.Trim = String.Empty Then
            MessageBox.Show("Item price must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses_item = "Insert" Then
            dtView.RowFilter = "Item_ID = '" & txt_ItemID.Text.Trim & "' and Item_Category = '" & cboItemCategory.SelectedValue.ToString.Trim & "'"
            If dtView.Count <> 0 Then
                MessageBox.Show("This Item has been existed before. Please insert other Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Item_ID") = txt_ItemID.Text
                dr("Item_Name") = txt_ItemName.Text
                dr("Item_Category") = cboItemCategory.Text
                dr("Item_Type") = txt_ItemType.Text
                dr("UoM") = Txt_ItemUoM.Text
                dr("Qty") = CInt(Txt_ItemQty.Text)
                If txt_ItemHarga.Text.Trim = String.Empty Then
                    dr("Price") = 0
                Else
                    dr("Price") = txt_ItemHarga.Text
                End If

                If txt_ItemSubTotal.Text.Trim = String.Empty Then
                    dr("SubTotal") = 0
                Else
                    dr("SubTotal") = dr("Qty") * dr("Price")
                End If

                dt_item.Rows.Add(dr)
            End If
        ElseIf Status_Proses_item = "Update" Then
            dtView.RowFilter = "Item_ID = '" & txt_ItemID.Text.Trim & "' and Item_Category = '" & txtItemCategoryOld.Text.Trim & "'"
            If dtView.Count = 0 Then
                MessageBox.Show("This item cannot be found in existed list. Please cancel editing first then insert this new item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                For i = 0 To dt_item.Rows.Count - 1
                    If dt_item.Rows(i).Item("Item_ID").ToString.Trim = txt_ItemID.Text.Trim AndAlso dt_item.Rows(i).Item("Item_Category").ToString.Trim = txtItemCategoryOld.Text.Trim Then
                        If i = CInt(txtIndex.Text) Then
                            da = dt_item.Rows(i)
                            da("UoM") = Txt_ItemUoM.Text
                            da("Item_Category") = cboItemCategory.Text
                            da("Qty") = CInt(Txt_ItemQty.Text)
                            If txt_ItemHarga.Text.Trim = String.Empty Then
                                da("Price") = 0
                            Else
                                da("Price") = txt_ItemHarga.Text
                            End If

                            If txt_ItemSubTotal.Text.Trim = String.Empty Then
                                da("SubTotal") = 0
                            Else
                                da("SubTotal") = da("Qty") * da("Price")
                            End If

                            Exit For
                        Else
                            MessageBox.Show("This item has been in list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            txt_ItemID.Focus()
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If

        CountSubTotal()
        HitungTotal()

        txtMarkUp_AdminFee_LostFocus(Nothing, Nothing)

        gv_Item.DataSource = dt_item
        'Refresh_Grid()
        Status_Proses_item = String.Empty  'reset

        Enable_Button_Item_Wa(True)
        Btn_Itemcancel_Click(Nothing, Nothing)
    End Sub

    'Private Sub CountItemTotal()
    '    Dim count As Double
    '    For i As Integer = 0 To gv_Item.Rows.Count - 1
    '        count += gv_Item.Rows(i).Cells(GlobalVar.Fields.SubTotal).Value
    '    Next
    '    txt_ItemTotal.Text = CStr(count)
    'End Sub

#End Region

#Region "Jasa Ongkos"
    Private Sub Enable_JasaOngkos_Wa(ByVal boo As Boolean)
        txt_JasaOngkosID.ReadOnly = Not boo
        txt_JasaOngkosLama.ReadOnly = Not boo
        txt_JasaOngkosKet.ReadOnly = Not boo
    End Sub

    Private Sub Clear_JasaOngkos_Wa()
        txt_JasaOngkosID.Clear()
        txt_JasaOngkosName.Clear()
        txt_JasaOngkosLama.Clear()
        txt_JasaOngkosOngkos.Clear()
        txt_JasaOngkosHarga.Clear()
        txt_JasaOngkosKet.Clear()
    End Sub

    Private Sub SetBackColor_JasaOngkos_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_JasaOngkosID.BackColor = Color.LightGray
            txt_JasaOngkosLama.BackColor = Color.LightGray
            txt_JasaOngkosKet.BackColor = Color.LightGray
        ElseIf proses = "UPDATE" Then
            txt_JasaOngkosID.BackColor = Color.LightGray
            txt_JasaOngkosLama.BackColor = Color.LightGoldenrodYellow
            txt_JasaOngkosKet.BackColor = Color.LightGoldenrodYellow
        ElseIf proses = "INSERT" Then
            txt_JasaOngkosID.BackColor = Color.LightGoldenrodYellow
            txt_JasaOngkosLama.BackColor = Color.LightGoldenrodYellow
            txt_JasaOngkosKet.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub Enable_Button_JasaOngkos_Wa(ByVal boo As Boolean)
        btn_JasaOngkosInsert.Enabled = boo
        btn_JasaOngkosEdit.Enabled = boo
        btn_JasaOngkosSave.Enabled = Not boo
        btn_JasaOngkosDelete.Enabled = boo
        btn_JasaOngkosCancel.Enabled = Not boo
    End Sub

    Private Sub SetGrid_JasaOngkos()
        gv_Jasaongkos.Columns(0).Width = 80
        gv_Jasaongkos.Columns(0).HeaderText = "Service ID"
        gv_Jasaongkos.Columns(1).Width = 220
        gv_Jasaongkos.Columns(1).HeaderText = "Service Name"
        gv_Jasaongkos.Columns(2).Width = 60
        gv_Jasaongkos.Columns(2).HeaderText = "Days"
        gv_Jasaongkos.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(2).DefaultCellStyle.Format = "#,##0.#0"
        gv_Jasaongkos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(3).Width = 80
        gv_Jasaongkos.Columns(3).HeaderText = "Fee/Day"
        gv_Jasaongkos.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(3).DefaultCellStyle.Format = "#,##0.#0"
        gv_Jasaongkos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(4).Width = 100
        gv_Jasaongkos.Columns(4).HeaderText = "Total Fee"
        gv_Jasaongkos.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(4).DefaultCellStyle.Format = "#,##0.#0"
        gv_Jasaongkos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Jasaongkos.Columns(5).Width = 270
        gv_Jasaongkos.Columns(5).HeaderText = "Remark"
    End Sub

    Private Sub txt_JasaOngkosLama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_JasaOngkosLama.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_JasaOngkosLama_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_JasaOngkosLama.Leave
        Dim lamaHari As Integer
        Dim Ongkos As Integer
        If txt_JasaOngkosLama.Text.Trim = String.Empty Then
            lamaHari = 0
        Else
            lamaHari = CInt(txt_JasaOngkosLama.Text)
        End If

        If txt_JasaOngkosOngkos.Text.Trim = String.Empty Then
            Ongkos = 0
        Else
            Ongkos = CDbl(txt_JasaOngkosOngkos.Text)
        End If

        txt_JasaOngkosHarga.Text = FormatAngka(lamaHari * Ongkos)
        txt_JasaOngkosKet.Focus()
    End Sub

    Private Sub txt_JasaOngkosKet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_JasaOngkosKet.Leave
        btn_JasaOngkosSave.Focus()
    End Sub

    Private Sub txt_JasaOngkosID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_JasaOngkosID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select a.Jasa_id,Jasa_Name, isnull(Labor_Price, 0) as Harga from Master_Jasa a left join Maintain_SalesPrice_Jasa b on a.jasa_id = b.Jasa_ID where a.active_Flag = 'Y'", "Jasa_id", "Jasa_Name", "Harga")

                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_JasaOngkosID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_JasaOngkosName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_JasaOngkosLama.Text = 0
                    txt_JasaOngkosOngkos.Text = FormatAngka(CDbl(frmSearch.txtResult3.Text.ToString.Trim))
                    txt_JasaOngkosHarga.Text = FormatAngka(CDbl(txt_JasaOngkosLama.Text) * CDbl(txt_JasaOngkosOngkos.Text))
                    txt_JasaOngkosLama.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> String.Empty Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    dt_JasaOngkos.Clear()
                    Cmd.CommandText = "EXEC sp_Retreive_Master_Jasa_byJasaID '" & txt_JasaOngkosID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_JasaOngkos)

                    If dt_JasaOngkos.Rows.Count > 0 Then
                        txt_JasaOngkosName.Text = dt_JasaOngkos.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        txt_JasaOngkosHarga.Text = dt_JasaOngkos.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        txt_JasaOngkosLama.Focus()
                    Else
                        MessageBox.Show("This service cannot be found. Please make sure that the service id is valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub btn_JasaOngkosInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosInsert.Click
        Status_Proses_JasaOngkos = "Insert"
        Enable_JasaOngkos_Wa(True)
        Clear_JasaOngkos_Wa()
        SetBackColor_JasaOngkos_Wa("INSERT")
        Enable_Button_JasaOngkos_Wa(False)
        txt_JasaOngkosID.Focus()
    End Sub

    Private Sub btn_JasaOngkosEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosEdit.Click
        If txt_JasaOngkosID.Text = "" Then
            MessageBox.Show("Please choose 1 data to be edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses_JasaOngkos = "Update"
        Enable_JasaOngkos_Wa(True)
        SetBackColor_JasaOngkos_Wa("UPDATE")
        Enable_Button_JasaOngkos_Wa(False)
        txt_JasaOngkosID.ReadOnly = False 'karna primary Key
        txt_JasaOngkosID.BackColor = Color.LightGray
        txt_JasaOngkosLama.Focus()
    End Sub

    Private Sub btn_JasaOngkosCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosCancel.Click
        Enable_JasaOngkos_Wa(False)
        Clear_JasaOngkos_Wa()
        SetBackColor_JasaOngkos_Wa("READ")
        Enable_Button_JasaOngkos_Wa(True)
        gv_Jasaongkos.Enabled = dt_JasaOngkos.Rows.Count > 0
    End Sub

    Private Sub btn_JasaOngkosDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosDelete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_JasaOngkos.Columns("Jasa_ID")
        dt_JasaOngkos.PrimaryKey = dc

        If txt_JasaOngkosID.Text.Trim = String.Empty Then
            MessageBox.Show("Please choose 1 data to be deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses_JasaOngkos = "Delete"

            da = dt_JasaOngkos.Rows.Find(txt_JasaOngkosID.Text)
            If da IsNot Nothing Then
                da.Delete()
                gv_Jasaongkos.Focus()
            End If
        End If
    End Sub

    Private Sub btn_JasaOngkosSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosSave.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_JasaOngkos.Columns("Jasa_ID")
        dt_JasaOngkos.PrimaryKey = dc

        ' Validation
        If txt_JasaOngkosLama.Text.Trim = String.Empty Then
            MessageBox.Show("Work days range must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses_JasaOngkos = "Insert" Then
            dr_JasaOngkos = dt_JasaOngkos.Rows.Find(txt_JasaOngkosID.Text)
            If dr_JasaOngkos IsNot Nothing Then
                MessageBox.Show("This service has been existed before. Please insert other service.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_JasaOngkosID.Focus()
                Exit Sub
            Else
                Dim dr As DataRow
                dr = dt_JasaOngkos.NewRow
                dr("Jasa_ID") = txt_JasaOngkosID.Text
                dr("Jasa_Name") = txt_JasaOngkosName.Text
                dr("Jlh_Hari") = txt_JasaOngkosLama.Text

                If txt_JasaOngkosOngkos.Text.Trim = String.Empty Then
                    dr("Ongkos") = FormatAngka(0)
                Else
                    dr("Ongkos") = FormatAngka(CDbl(txt_JasaOngkosOngkos.Text))
                End If

                If txt_JasaOngkosHarga.Text.Trim = String.Empty Then
                    dr("SubTotal") = FormatAngka(0)
                Else
                    dr("SubTotal") = FormatAngka(dr("Jlh_Hari") * dr("Ongkos"))
                End If
                dr("Remarks") = txt_JasaOngkosKet.Text
                dt_JasaOngkos.Rows.Add(dr)
            End If
        ElseIf Status_Proses_JasaOngkos = "Update" Then
            da = dt_JasaOngkos.Rows.Find(txt_JasaOngkosID.Text)
            If da IsNot Nothing Then
                da("Jlh_Hari") = txt_JasaOngkosLama.Text

                If txt_JasaOngkosOngkos.Text.Trim = String.Empty Then
                    da("Ongkos") = FormatAngka(0)
                Else
                    da("Ongkos") = FormatAngka(CDbl(txt_JasaOngkosOngkos.Text))
                End If

                If txt_JasaOngkosHarga.Text.Trim = String.Empty Then
                    da("SubTotal") = FormatAngka(0)
                Else
                    da("SubTotal") = FormatAngka(da("Jlh_Hari") * da("Ongkos"))
                End If
                da("Remarks") = txt_JasaOngkosKet.Text
            End If
        End If
        CountSubTotal()
        HitungTotal()
        gv_Jasaongkos.DataSource = dt_JasaOngkos
        SetGrid_JasaOngkos()
        Status_Proses_JasaOngkos = String.Empty  'reset
        Enable_Button_JasaOngkos_Wa(True)
        btn_JasaOngkosCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Load_PHProject_JasaOngkos_Dtl()
        Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_JasaOngkos_Dtl_byKey '" + txt_TransNo.Text + "'," & cboRevisi.SelectedItem
        dt_JasaOngkos.Clear()
        DA.SelectCommand = Cmd
        DA.Fill(dt_JasaOngkos)

        If dt_JasaOngkos.Rows.Count > 0 Then
            gv_Jasaongkos.DataSource = dt_JasaOngkos
            SetGrid_JasaOngkos()
        End If
        Enable_Button_JasaOngkos_Wa(True)
        Enable_JasaOngkos_Wa(False)
        gv_Jasaongkos.Enabled = dt_JasaOngkos.Rows.Count > 0
    End Sub

    Private Sub gv_Jasaongkos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_Jasaongkos.MouseClick
        If String.IsNullOrEmpty(gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value) = False Then
            txt_JasaOngkosID.Text = gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value.ToString.Trim
            txt_JasaOngkosName.Text = gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_Name).Value.ToString.Trim
            txt_JasaOngkosLama.Text = gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jlh_Hari).Value.ToString.Trim
            txt_JasaOngkosOngkos.Text = FormatAngka(CDbl(gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaOngkos).Value.ToString.Trim))
            txt_JasaOngkosHarga.Text = FormatAngka(CDbl(gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaSubTotal).Value.ToString.Trim))
            txt_JasaOngkosKet.Text = gv_Jasaongkos.Rows(gv_Jasaongkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaRemarks).Value.ToString.Trim
        End If
    End Sub

    'Private Sub CountJasaOngkosTotal()
    '    Dim count As Double
    '    For i As Integer = 0 To gv_Jasaongkos.Rows.Count - 1
    '        count += gv_Jasaongkos.Rows(i).Cells(GlobalVar.Fields.JasaSubTotal).Value
    '    Next
    '    txt_JasaOngkosTotal.Text = CStr(count)
    'End Sub
#End Region

    '#Region "Jasa Admin"
    '    Private Sub Enable_Button_JasaAdmin_Wa(ByVal boo As Boolean)
    '        btn_JasaAdminInsert.Enabled = boo
    '        btn_JasaAdminEdit.Enabled = boo
    '        btn_JasaAdminSave.Enabled = boo
    '        btn_JasaAdminDelete.Enabled = boo
    '        btn_JasaAdminCancel.Enabled = boo
    '    End Sub

    '    Private Sub SetGrid_JasaAdmin()
    '        gv_JasaAdmin.Columns(0).Width = 60
    '        gv_JasaAdmin.Columns(1).Width = 300
    '        gv_JasaAdmin.Columns(2).Width = 50
    '        gv_JasaAdmin.Columns(3).Width = 50
    '        gv_JasaAdmin.Columns(4).Width = 70
    '    End Sub

    '    Private Sub txt_JasaAdminID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '        If e.KeyCode = Keys.F1 Then
    '            Try
    '                CallandGetSearchData("Select Jasa_id,Jasa_Name,Start_dt as Start_Period,End_Dt as End_Period,Price_Project as Harga from Master_Jasa a left join Maintain_SalesPrice b on a.jasa_id = b.ID where a.active_Flag = 'Y' and a.category = 'ADMINITRASI' and Start_dt <= '" & dt_PenawaranDt.Value & "' and End_Dt >= '" & dt_PenawaranDt.Value & "' ", "Jasa_id", "Jasa_Name", "Start_Period", "End_Period", "Harga")

    '                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
    '                    If Conn.State = ConnectionState.Closed Then
    '                        Conn.Open()
    '                    End If
    '                    txt_JasaAdminID.Text = frmSearch.txtResult1.Text.ToString.Trim
    '                    txt_JasaAdminName.Text = frmSearch.txtResult2.Text.ToString.Trim
    '                    txt_JasaAdminLama.Text = 0
    '                    txt_JasaAdminOngkos.Text = frmSearch.txtResult5.Text.ToString.Trim
    '                    txt_JasaAdminHarga.Text = CInt(txt_JasaAdminLama.Text) * CInt(txt_JasaAdminOngkos.Text)
    '                    txt_JasaAdminLama.Focus()
    '                End If
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '                Conn.Close()
    '            End Try
    '        ElseIf e.KeyCode = Keys.Enter Then
    '            If txt_ItemID.Text.Trim <> "" Then
    '                Try
    '                    If Conn.State = ConnectionState.Closed Then
    '                        Conn.Open()
    '                    End If
    '                    dt_JasaAdmin.Clear()
    '                    Cmd.CommandText = "EXEC sp_Retreive_Master_Jasa_byJasaID '" & txt_JasaOngkosID.Text.Trim & "'"
    '                    DA.SelectCommand = Cmd
    '                    DA.Fill(dt_JasaAdmin)

    '                    If dt_JasaAdmin.Rows.Count > 0 Then
    '                        txt_JasaAdminName.Text = dt_JasaAdmin.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
    '                        txt_JasaAdminHarga.Text = dt_JasaAdmin.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
    '                        txt_JasaAdminLama.Focus()
    '                    Else
    '                        MessageBox.Show("Jasa ini tidak ditemukan. Pastikan Jasa ID yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                        Exit Sub
    '                    End If
    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                    Conn.Close()
    '                End Try
    '            End If

    '        End If
    '        Conn.Close()
    '    End Sub

    '    Private Sub Load_PHProject_JasaAdmin_Dtl()
    '        dt_JasaAdmin.Clear()
    '        Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_JasaAdmin_Dtl_byKey '" + txt_TransNo.Text + "'"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dt_JasaAdmin)

    '        If dt_JasaAdmin.Rows.Count > 0 Then
    '            gv_JasaAdmin.DataSource = dt_JasaAdmin
    '            SetGrid_JasaAdmin()
    '        End If
    '        Enable_Button_JasaAdmin_Wa(True)
    '        Enable_JasaAdmin_Wa(False)
    '        gv_JasaAdmin.Enabled = dt_JasaAdmin.Rows.Count > 0
    '    End Sub

    '    Private Sub btn_JasaAdminInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Status_Proses_JasaAdmin = "Insert"
    '        Enable_JasaAdmin_Wa(True)
    '        Clear_JasaAdmin_Wa()
    '        SetBackColor_JasaAdmin_Wa("INSERT")
    '        btn_JasaAdminInsert.Enabled = False
    '        btn_JasaAdminEdit.Enabled = False
    '        btn_JasaAdminDelete.Enabled = False
    '        txt_JasaAdminID.Focus()
    '    End Sub

    '    Private Sub btn_JasaAdminEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        If txt_JasaAdminID.Text = "" Then
    '            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End If
    '        Status_Proses_JasaAdmin = "Update"
    '        Enable_JasaAdmin_Wa(True)
    '        SetBackColor_JasaOngkos_Wa("UPDATE")
    '        txt_JasaAdminID.Enabled = False 'karna primary Key
    '        btn_JasaAdminInsert.Enabled = False
    '        btn_JasaAdminEdit.Enabled = False
    '        btn_JasaAdminDelete.Enabled = False
    '        txt_JasaAdminID.BackColor = Color.DarkGray
    '        txt_JasaAdminLama.Focus()
    '    End Sub

    '    Private Sub btn_JasaAdminCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Enable_JasaAdmin_Wa(False)
    '        Clear_JasaAdmin_Wa()
    '        SetBackColor_JasaAdmin_Wa("READ")
    '        If id_status = "" Then
    '            btn_JasaAdminInsert.Enabled = True
    '            btn_JasaAdminEdit.Enabled = True
    '            btn_JasaAdminDelete.Enabled = True
    '        Else
    '            btn_JasaAdminInsert.Enabled = False
    '            btn_JasaAdminEdit.Enabled = True
    '            btn_JasaAdminDelete.Enabled = False
    '        End If
    '        gv_JasaAdmin.Enabled = dt_JasaAdmin.Rows.Count > 0
    '    End Sub

    '    Private Sub btn_JasaAdminDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim dc(1) As DataColumn
    '        Dim da As Data.DataRow
    '        dc(0) = dt_JasaAdmin.Columns("Jasa_ID")
    '        dt_JasaAdmin.PrimaryKey = dc

    '        If txt_JasaAdminID.Text.Trim = "" Then
    '            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End If
    '        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
    '            Status_Proses_JasaOngkos = "Delete"

    '            da = dt_JasaAdmin.Rows.Find(txt_JasaAdminID.Text)
    '            If da IsNot Nothing Then
    '                da.Delete()
    '                btn_JasaAdminInsert.Enabled = True
    '                btn_JasaAdminEdit.Enabled = True
    '                btn_JasaAdminDelete.Enabled = True
    '                gv_JasaAdmin.Focus()
    '            End If
    '        End If
    '    End Sub

    '    Private Sub btn_JasaAdminSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Dim dc(1) As DataColumn
    '        Dim da As Data.DataRow
    '        dc(0) = dt_JasaAdmin.Columns("Jasa_ID")
    '        dt_JasaAdmin.PrimaryKey = dc

    '        ' Validation
    '        If txt_JasaAdminLama.Text.Trim = "" Then
    '            MessageBox.Show("Lama Kerja harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '            Exit Sub
    '        End If

    '        If Status_Proses_JasaAdmin = "Insert" Then
    '            dr_JasaAdmin = dt_JasaAdmin.Rows.Find(txt_JasaAdminID.Text)
    '            If dr_JasaAdmin IsNot Nothing Then
    '                MessageBox.Show("Jasa ID ini sudah ada sebelumnya.Silahkan masukan Jasa ID yang lain", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                txt_JasaOngkosID.Focus()
    '                Exit Sub
    '            Else
    '                Dim dr As DataRow
    '                dr = dt_JasaAdmin.NewRow
    '                dr("Jasa_ID") = txt_JasaAdminID.Text
    '                dr("Jasa_Name") = txt_JasaAdminName.Text
    '                dr("Jlh_Hari") = txt_JasaAdminLama.Text

    '                If txt_JasaAdminOngkos.Text = "" Then
    '                    dr("Ongkos") = 0
    '                Else
    '                    dr("Ongkos") = txt_JasaAdminOngkos.Text
    '                End If

    '                If txt_JasaAdminHarga.Text = "" Then
    '                    dr("SubTotal") = 0
    '                Else
    '                    dr("SubTotal") = dr("Jlh_Hari") * dr("Ongkos")
    '                End If
    '                dr("Remarks") = txt_JasaAdminKet.Text
    '                dt_JasaAdmin.Rows.Add(dr)
    '            End If
    '        ElseIf Status_Proses_JasaAdmin = "Update" Then
    '            da = dt_JasaAdmin.Rows.Find(txt_JasaAdminID.Text)
    '            If da IsNot Nothing Then
    '                da("Jlh_Hari") = txt_JasaAdminLama.Text

    '                If txt_JasaAdminOngkos.Text = "" Then
    '                    da("Ongkos") = 0
    '                Else
    '                    da("Ongkos") = txt_JasaAdminOngkos.Text
    '                End If

    '                If txt_JasaAdminHarga.Text = "" Then
    '                    da("SubTotal") = 0
    '                Else
    '                    da("SubTotal") = da("Jlh_Hari") * da("Ongkos")
    '                End If
    '                da("Remarks") = txt_JasaAdminKet.Text
    '            End If
    '        End If
    '        CountSubTotal()
    '        gv_JasaAdmin.DataSource = dt_JasaAdmin
    '        Status_Proses_JasaAdmin = "" 'reset
    '        btn_JasaAdminCancel_Click(Nothing, Nothing)
    '    End Sub

    '    Private Sub gv_JasaAdmin_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '        If String.IsNullOrEmpty(gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value) = False Then
    '            txt_JasaAdminID.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value.ToString.Trim
    '            txt_JasaAdminName.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_Name).Value.ToString.Trim
    '            txt_JasaAdminLama.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jlh_Hari).Value.ToString.Trim
    '            txt_JasaAdminOngkos.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaOngkos).Value.ToString.Trim
    '            txt_JasaAdminHarga.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaSubTotal).Value.ToString.Trim
    '            txt_JasaAdminKet.Text = gv_JasaAdmin.Rows(gv_JasaAdmin.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaRemarks).Value.ToString.Trim
    '        End If
    '    End Sub

    '    Private Sub txt_JasaAdminLama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
    '            e.KeyChar = Chr(0)
    '        End If
    '    End Sub

    '    Private Sub txt_JasaAdminLama_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim lamaHari As Integer
    '        Dim Ongkos As Integer
    '        If txt_JasaAdminLama.Text = "" Then
    '            lamaHari = 0
    '        Else
    '            lamaHari = CInt(txt_JasaAdminLama.Text)
    '        End If

    '        If txt_JasaAdminOngkos.Text = "" Then
    '            Ongkos = 0
    '        Else
    '            Ongkos = CInt(txt_JasaAdminOngkos.Text)
    '        End If

    '        txt_JasaAdminHarga.Text = lamaHari * Ongkos
    '        txt_JasaAdminKet.Focus()
    '    End Sub

    '    'Private Sub CountJasaAdminTotal()
    '    '    Dim count As Double
    '    '    For i As Integer = 0 To gv_JasaAdmin.Rows.Count - 1
    '    '        count += gv_JasaAdmin.Rows(i).Cells(GlobalVar.Fields.JasaSubTotal).Value
    '    '    Next
    '    '    txt_JasaAdminTotal.Text = CStr(count)
    '    'End Sub

    '#End Region

    '------started : Added by kparlind 21-nov-2012
    'Private Sub txtAdminFee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdminFee.TextChanged
    '    If txtTechnicianFeeTotal.Text = String.Empty Then txtTechnicianFeeTotal.Text = FormatAngka(0)
    '    If txtAdminQCFee.Text = String.Empty Then txtAdminQCFee.Text = FormatAngka(0)

    '    lbl_GrandTotalProject.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
    'End Sub

    Private Sub txtMarkUp_AdminQCFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_AdminQCFee.LostFocus
        Try
            txtMarkUp_AdminQCFee.Text = FormatAngka(CDbl(txtMarkUp_AdminQCFee.Text))
        Catch ex As Exception
            txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        End Try

        HitungTotal()
        txtMarkUp_AdminFee_LostFocus(Nothing, Nothing)
        txtMarkUp_QCFee_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub txtMarkUp_AdminFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_AdminFee.LostFocus
        Try
            txtMarkUp_AdminFee.Text = FormatAngka(CDbl(txtMarkUp_AdminFee.Text))
        Catch ex As Exception
            txtMarkUp_AdminFee.Text = FormatAngka(0)
        End Try

        'Remarked by kparlind di anyer
        'If CDbl(txtMarkUp_AdminFee.Text.Trim) > CDbl(txtMarkUp_AdminQCFee.Text.Trim) Then
        '    txtMarkUp_QCFee.Text = FormatAngka(0)
        '    txtMarkUp_QCFee_LostFocus(Nothing, Nothing)
        'Else
        'Remarked by kparlind di anyer
        'txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) / IIf(CDbl(txtMarkUp_AdminQCFee.Text) = 0, 1, CDbl(txtMarkUp_AdminQCFee.Text))) * CDbl(txtAdminQCFee.Text))
        txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)

        'txtMarkUp_QCFee.Text = FormatAngka(CDbl(txtMarkUp_AdminQCFee.Text.Trim) - CDbl(txtMarkUp_AdminFee.Text))
        txtMarkUp_QCFee.Text = FormatAngka(CDbl(100) - CDbl(txtMarkUp_AdminFee.Text))
        txtMarkUp_QCFee_LostFocus(Nothing, Nothing)
        'HitungTotal()
        'End If
    End Sub

    Private Sub txtMarkUp_QCFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_QCFee.LostFocus
        Dim markupQC, AdminQCFee As Double
        Dim markupAdminQC As Double

        Try
            txtMarkUp_QCFee.Text = FormatAngka(CDbl(txtMarkUp_QCFee.Text))
        Catch ex As Exception
            txtMarkUp_QCFee.Text = FormatAngka(0)
        End Try

        markupQC = CDbl(txtMarkUp_QCFee.Text)
        AdminQCFee = CDbl(txtAdminQCFee.Text)
        markupAdminQC = CDbl(txtMarkUp_AdminQCFee.Text)
        txtQCFee.Text = FormatAngka((markupQC / IIf(markupAdminQC = 0, 1, CDbl(markupAdminQC))) * AdminQCFee)

        'Added bykparlind at anyer
        txtQCFee.Text = FormatAngka((markupQC * AdminQCFee) / 100)
        'HitungTotal()
    End Sub
    '------Ended : Added by kparlind 21-nov-2012

    Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
        If Status_Trans = TransStatus.NoStatus AndAlso id_status = Status.PHProject_ReadyToProcessed Then
            If userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to reject this transaction ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    alasanReject = String.Empty
                    frmReason.ShowDialog()

                    If frmReason.Flag = "OK" Then
                        alasanReject = frmReason.txtReason.Text.Trim
                        RejectData()
                        Me.Close()
                    End If
                End If
            Else
                MessageBox.Show("Unauthorized process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Unauthorized process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub RejectData()
        If RejectTrans() Then
            MessageBox.Show("Data (Transaction# " & txt_TransNo.Text.Trim & ") has been rejected and sent to " & Hirarki.BK_Rejected & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function RejectTrans()
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

            Query = "exec sp_Update_Trans_PHProject_Hdr_Marketing "
            queryParam = "'" & txt_TransNo.Text.Trim & "'," & CInt(cboRevisi.SelectedItem.ToString) & ", '" & alasanReject & "', '" & Status.PHProject_Rejected & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txt_TransNo.Text.Trim, Status.PHProject_Rejected, GetDocCreator(txt_TransNo.Text.Trim), "2") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            UpdatetoInbox(txt_TransNo.Text.Trim, Status.PHProject_Rejected, userlog.UserName, "3")
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", Status.PHProject_Rejected) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Rejected) 'Insert History transaction

            Trans.Commit()
            RejectTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If id_status = Status.PHProject_ReadyToProcessed AndAlso Status_Trans = TransStatus.NoStatus Then
            If userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If MessageBox.Show("Are you sure to approve this Transaction# " & txt_TransNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ApproveData()
                    Me.Close()
                End If
            Else
                MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            MessageBox.Show("Unauthorized process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ApproveData()
        If ApproveTrans() Then
            If MessageBox.Show("Are you want to create a transaction (Penawaran Harga Marketing) from this PH Project ?", "Need Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim frmChild As New frmPenawaranHargaMarketing

                For Each f As Form In Me.MdiChildren
                    If f.Name = "frmPenawaranHargaMarketing" Then
                        f.BringToFront()

                        MessageBox.Show("Penawaran Harga Marketing form is opened." & vbCrLf & "Creating new transaction is cancelled.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                Next

                id_status = Status.Draft
                createPHM = True

                frmChild.MdiParent = MDIFrm
                frmChild.fromPHP = True
                frmChild.txt_PHPNo.Text = txt_TransNo.Text.Trim
                frmChild.LoadPHP_fromOutside()
                frmChild.Show()
                Me.Close()
            Else
                MessageBox.Show("You choose not to create PH Marketing right now." & vbCrLf & "You can use button Generate in this form to do that later, or manually creating a new transaction in you PH Marketing View." & vbCrLf & "This transaction has been closed.", "Information", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Function ApproveTrans() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Query As String
        Dim queryParam As String
        Dim Trans As SqlTransaction
        Dim TransNo As String = String.Empty
        Dim dtItem, dtClosing, dtPHM As New DataTable

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Trans = Conn.BeginTransaction
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            Query = "exec sp_Update_Trans_PHProject_Hdr_Marketing "
            queryParam = "'" & txt_TransNo.Text.Trim & "'," & CInt(cboRevisi.SelectedItem.ToString) & ", '', '" & Status.PHProject_Completed & "', '" & userlog.UserName & "'"

            Cmd.CommandText = Query & queryParam
            Cmd.ExecuteNonQuery()

            UpdatetoInbox(txt_TransNo.Text.Trim, Status.PHProject_Completed, GetDocCreator(txt_TransNo.Text.Trim), "2") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, Status.PHProject_Completed, userlog.UserName, "3") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            'InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(Status.PHProject_Completed), "W", "Y", Status.PHProject_Completed) 'Insert to NEXT APPROVAL
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Approved) 'Insert History transaction

            Trans.Commit()
            ApproveTrans = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnRevision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevision.Click
        If status_trans = TransStatus.NoStatus Then
            If id_status = Status.PHProject_Rejected Then
                Dim TD As New TransData
                Dim i As Integer

                i = TD.RetrieveMaxSeq_TransPHProjectHdr(txt_TransNo.Text.Trim)
                cboRevisi.Items.Add(i + 1)
                cboRevisi.SelectedIndex = cboRevisi.Items.Count - 1

                Status_Trans = TransStatus.RevisionStatus
                EnableInput(True)

                P_Item.Enabled = True
                p_jasa.Enabled = True

                EnableButton()
                Enable_Button_Item_Wa(True)
                Enable_Button_JasaOngkos_Wa(True)

                lbl_status.Text = GetStatus(Status.Draft)
            End If
        End If
    End Sub

    Private Sub cboRevisi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRevisi.SelectedIndexChanged
        If status_trans = TransStatus.NoStatus Then
            Dim dtTemp As New DataTable
            Dim TD As New TransData

            TD.RetrievePHPHdr_ByKey(dtTemp, txt_TransNo.Text.Trim, cboRevisi.SelectedItem.ToString)
            If dtTemp.Rows.Count <> 0 Then
                Load_HP()
                Load_PHProject_Item_Dtl()
                Load_PHProject_JasaOngkos_Dtl()
                CountTotalInitial()
            End If
        End If
    End Sub

    Private Sub LoadComboRevision()
        Dim dtTemp As New DataTable
        Dim TD As New TransData
        Dim i As Integer

        cboRevisi.Items.Clear()
        TD.RetrieveSeq_TransPHProjectHdr(dtTemp, txt_TransNo.Text.Trim)
        If dtTemp.Rows.Count <> 0 Then
            For i = 0 To dtTemp.Rows.Count - 1
                With dtTemp.Rows(i)
                    cboRevisi.Items.Add(.Item("Seq"))
                End With
            Next
        Else
            cboRevisi.Items.Add(0)
        End If

        cboRevisi.SelectedIndex = cboRevisi.Items.Count - 1
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim frmChild As New frmPenawaranHargaMarketing

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPenawaranHargaMarketing" Then
                f.BringToFront()

                MessageBox.Show("Penawaran Harga Marketing form is opened." & vbCrLf & "Creating new transaction is cancelled.", "Information", MessageBoxButtons.OK)
                Exit Sub
            End If
        Next

        id_status = Status.Draft
        createPHM = True

        frmChild.MdiParent = MDIFrm
        frmChild.fromPHP = True
        frmChild.txt_PHPNo.Text = txt_TransNo.Text.Trim
        frmChild.LoadPHP_fromOutside()
        frmChild.Show()
        Me.Close()
    End Sub

End Class