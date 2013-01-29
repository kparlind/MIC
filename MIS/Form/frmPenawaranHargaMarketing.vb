'(21 Des 2012) Tambah confirmation pada saat delete, bug button pada saat create new.
'(28 Jan 2013) Fixing bug reset serial

Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmPenawaranHargaMarketing
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

    Dim dt_Survey As New DataTable
    Dim id_login As String
    Dim ttl_Item_Project As Decimal
    Dim ttl_Item_Marketing As Decimal
    Dim ttl_JasaOngkos_Project As Decimal
    Dim ttl_JasaOngkos_Marketing As Decimal
    Dim ttl_JasaAdmin_Project As Decimal
    Dim ttl_JasaAdmin_Marketing As Decimal
    Dim GrandTtl_Project, GrandTtl_Marketing As Decimal
    Dim Status_Proses_Item, Status_Proses_JasaOngkos As String
    Dim status_trans As String
    Dim BP_TransNo As String = String.Empty
    Public ViewFormName As String
    Public fromPHP As Boolean

#Region "Interface"
    Private Sub txtMarkUp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarkUp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtMICEMaterialTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMICEMaterialTotal.TextChanged
        If txtTechnicianFeeTotal.Text = String.Empty Then txtTechnicianFeeTotal.Text = FormatAngka(0)
        If txtAdminQCFee.Text = String.Empty Then txtAdminQCFee.Text = FormatAngka(0)

        txtTotalBefDisc.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
        txtTotalMarketing.Text = FormatAngka(CDbl(txtTotalBefDisc.Text) - CDbl(txtDiscAmt.Text))
    End Sub

    Private Sub txtTechnicianFeeTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTechnicianFeeTotal.TextChanged
        If txtMICEMaterialTotal.Text = String.Empty Then txtMICEMaterialTotal.Text = FormatAngka(0)
        If txtAdminQCFee.Text = String.Empty Then txtAdminQCFee.Text = FormatAngka(0)

        txtTotalBefDisc.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
        txtTotalMarketing.Text = FormatAngka(CDbl(txtTotalBefDisc.Text) - CDbl(txtDiscAmt.Text))
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
        If txtDiscAmt.Text.Trim = String.Empty Then txtDiscAmt.Text = FormatAngka(0)

        txtTotalBefDisc.Text = FormatAngka(CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text) + CDbl(txtAdminQCFee.Text))
        txtTotalMarketing.Text = FormatAngka(CDbl(txtTotalBefDisc.Text) - CDbl(txtDiscAmt.Text))
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

    Private Sub btn_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print.Click
        'Dim frmChild As New FrmMoU

        'For Each f As Form In Me.MdiChildren
        '    If f.Name = "FrmMoU" Then
        '        f.BringToFront()
        '        Exit Sub
        '    End If
        'Next

        'frmChild.MdiParent = Me
        'frmChild.PHMNo = txt_TransNo.Text.Trim
        'frmChild.GrandTotal = txtTotalMarketing.Text
        'frmChild.Project = txtProjectName.Text.Trim
        'frmChild.MdiParent = MDIFrm
        'frmChild.Show()

        FrmMoU.PHMNo = txt_TransNo.Text.Trim
        FrmMoU.GrandTotal = txtTotalMarketing.Text
        FrmMoU.Project = txtProjectName.Text.Trim
        FrmMoU.Show()

        'Dim dt_project As New DataTable
        'Dim MoU_number As String = String.Empty

        'dt_project.Clear()
        'Cmd.CommandText = "Select Project_No from Trans_Projects where PHM_No = '" + txt_TransNo.Text + "'"
        'DA.SelectCommand = Cmd
        'DA.Fill(dt_project)

        'If dt_project.Rows.Count > 0 Then
        '    MessageBox.Show("This Penawaran has been generated for a project numbered :" + dt_project.Rows(0).Item("Project_No").ToString.Trim, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'Print MoU
        '    Exit Sub
        'Else
        '    'Set Transaction
        '    If Conn.State = ConnectionState.Closed Then
        '        Conn.Open()
        '    End If

        '    Dim ObjTrans As SqlTransaction
        '    Dim Project_Number As String
        '    ObjTrans = Conn.BeginTransaction("Trans")
        '    Cmd.Transaction = ObjTrans

        '    Try
        '        ' Proses Insert ke table Projects
        '        Project_Number = Generate_TranNo("FormProject")
        '        dt_project.Clear()
        '        Cmd.CommandText = "EXEC sp_Insert_Trans_Project  '" & Project_Number & "','" & Now & "','" & MoU_number & "','" & _
        '                          txt_TransNo.Text.Trim & "','" & txt_SurveyNo.Text.Trim & "'," & GrandTtl_Marketing & ",'" & _
        '                          txt_RemarkMarketing.Text.Trim & "','PRST','" & userlog.UserName & "'"
        '        DA.SelectCommand = Cmd
        '        DA.Fill(dt_project)

        '        ObjTrans.Commit()
        '        MessageBox.Show("Project numbered : " + Project_Number, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    Catch ex As Exception
        '        ObjTrans.Rollback()
        '        Conn.Close()
        '        MessageBox.Show(ex.Message)
        '    End Try
        'End If
    End Sub

    Private Sub frmPenawaranHargaMarketing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If status_trans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Dim frmChild As New frmViewPenawaranHargaMarketing

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
    End Sub

    Private Sub frmPenawaranHargaMarketing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        'SetAccess(Me, userlog.AccessID, ViewFormName, ts_New, ts_Edit, ts_delete, ts_save, ts_cancel, ts_print, Nothing, Nothing, Nothing, ts_Generate, )

        ts_New.Visible = False
        btnBP.Visible = False   'sementara

        If txt_TransNo.Text.ToString.Trim <> String.Empty Then 'Jika dipanggil dari View Penerimaan Barang
            ClearInput()
            status_trans = "a"   'sementara
            LoadComboRevision()

            status_trans = TransStatus.NoStatus
            'Load_HM()
            id_status = id_status.ToString.Trim

            lbl_status.Text = GetStatus(id_status)
            If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) OrElse userlog.AccessID = Role.SuperAdmin Then
                If id_status = Status.PHMarketing_Completed Then
                    ts_Edit.Enabled = False
                Else
                    ts_Edit.Enabled = True
                End If

                P_Item.Enabled = False
                p_jasa.Enabled = False
            End If

            P_Item.Enabled = False
            p_jasa.Enabled = False

            Load_PHMarketing_Item_Dtl()
            Load_PHMarketing_JasaOngkos_Dtl()

            CountTotalInitial()
            Load_HM()
            txtMICEMaterialTotal_TextChanged(Nothing, Nothing)
            txtMarkUp_LostFocus(Nothing, Nothing)
            txtAdminQCFee_TextChanged(Nothing, Nothing)

            EnableInput(False)
            DisableButton()

            Dim dtTemp As New DataTable
            Dim TD As New TransData

            TD.Retrieve_PakaiBahan_ByID_fromPHM(dtTemp, txt_TransNo.Text.Trim)
            If dtTemp.Rows.Count <> 0 Then
                BP_TransNo = dtTemp.Rows(0).Item(Fields.PB_TransNo).ToString.Trim
                btnBP.Text = "Edit Bahan Terpasang"
            Else
                BP_TransNo = String.Empty
                btnBP.Text = "Create Bahan Terpasang"
            End If
        Else
            ts_New_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub ClearInput()
        txt_PHPNo.Text = String.Empty
        txt_CustID.Text = String.Empty
        txt_CustomerName.Text = String.Empty
        txt_SurveyNo.Text = String.Empty
        txt_RemarkMarketing.Text = String.Empty
        txtProjectName.Text = String.Empty
        chkOutsource.Checked = False

        txtTotalMarketing.Text = FormatAngka(0)
        txtTotalBefDisc.Text = FormatAngka(0)
        txtDiscAmt.Text = FormatAngka(0)
        txtTotalProject.Text = FormatAngka(0)
        txt_ttlItem_Marketing.Text = FormatAngka(0)
        txt_ttlItem_Project.Text = FormatAngka(0)
        txt_ttlJasaOngkos.Text = FormatAngka(0)
        txtMarkUp_AdminFee.Text = FormatAngka(0)
        txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        txtMarkUp_QCFee.Text = FormatAngka(0)

        txtMICEMain.Text = FormatAngka(0)
        txtMICEMaterialTotal.Text = FormatAngka(0)
        txtMarkUp.Text = FormatAngka(0)
        txtMarkUpAmt.Text = FormatAngka(0)
        txtTechnicianFeeTotal.Text = FormatAngka(0)
        txtAdminFee.Text = FormatAngka(0)
        txtAdminQCFee.Text = FormatAngka(0)
        txtQCFee.Text = FormatAngka(0)
        txtSubTotalMain.Text = FormatAngka(0)
        txtSupportingTotal.Text = FormatAngka(0)

        cboRevisi.Items.Clear()
        gv_item.DataSource = ""
        gv_jasaOngkos.DataSource = ""
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        dt_PenawaranDt.Enabled = boo
        txt_RemarkMarketing.ReadOnly = Not boo
        chkOutsource.Enabled = boo
        txtProjectName.ReadOnly = Not boo
        txtMarkUp.ReadOnly = Not boo
        txtDiscAmt.ReadOnly = Not boo
        txtMarkUp_AdminQCFee.ReadOnly = Not boo
        txtMarkUp_AdminFee.ReadOnly = Not boo
        cboRevisi.Enabled = Not boo

        If txtProjectNo.Text.Trim <> String.Empty Then
            txt_PHPNo.ReadOnly = True
        Else
            txt_PHPNo.ReadOnly = Not boo
        End If
    End Sub

    Private Sub DisableButton()
        If id_status = Status.Draft Then
            If userlog.AccessID = Role.MarketingAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
                If status_trans <> TransStatus.NoStatus Then
                    ts_New.Enabled = False
                    ts_Edit.Enabled = False
                    ts_save.Enabled = True
                    ts_delete.Enabled = False
                    ts_cancel.Enabled = True
                Else
                    ts_New.Enabled = False
                    ts_Edit.Enabled = True
                    ts_save.Enabled = False
                    ts_delete.Enabled = True
                    ts_cancel.Enabled = True
                End If

                btnRevision.Enabled = False
                btnPrintPenawaran.Enabled = False
                ts_Generate.Enabled = False
                btnBP.Enabled = False
                ts_print.Enabled = False
            Else
                ts_New.Enabled = False
                ts_Edit.Enabled = False
                ts_save.Enabled = False
                ts_delete.Enabled = False
                ts_cancel.Enabled = False

                btnRevision.Enabled = False
                btnPrintPenawaran.Enabled = False
                ts_Generate.Enabled = False
                btnBP.Enabled = False
                ts_print.Enabled = False
            End If
        ElseIf id_status = Status.PHMarketing_Saved Then
            If userlog.AccessID = Role.MarketingAdmin Then
                ts_New.Enabled = False
                ts_Edit.Enabled = False
                ts_save.Enabled = False
                ts_delete.Enabled = False
                ts_cancel.Enabled = False

                btnRevision.Enabled = False
                btnPrintPenawaran.Enabled = False
                ts_Generate.Enabled = False
                btnBP.Enabled = False
                ts_print.Enabled = False
            ElseIf userlog.AccessID = Role.MarketingHead OrElse userlog.AccessID = Role.SuperAdmin Then
                If status_trans <> TransStatus.NoStatus Then
                    ts_New.Enabled = False
                    ts_Edit.Enabled = False
                    ts_save.Enabled = True
                    ts_delete.Enabled = False
                    ts_cancel.Enabled = True
                Else
                    ts_New.Enabled = False
                    ts_Edit.Enabled = True
                    ts_save.Enabled = False
                    ts_delete.Enabled = False
                    ts_cancel.Enabled = False
                End If

                btnRevision.Enabled = False
                btnPrintPenawaran.Enabled = False
                ts_Generate.Enabled = False
                btnBP.Enabled = False
                ts_print.Enabled = False
            End If
        ElseIf id_status = Status.PHMarketing_Completed Then
            If status_trans = TransStatus.RevisionStatus Then
                ts_New.Enabled = False
                ts_Edit.Enabled = False
                ts_save.Enabled = True
                ts_delete.Enabled = False
                ts_cancel.Enabled = True

                btnRevision.Enabled = False
                btnPrintPenawaran.Enabled = False
                ts_Generate.Enabled = False
                btnBP.Enabled = False
                ts_print.Enabled = False
            Else
                ts_New.Enabled = False
                ts_Edit.Enabled = False
                ts_save.Enabled = False
                ts_delete.Enabled = False
                ts_cancel.Enabled = False

                btnRevision.Enabled = True
                btnPrintPenawaran.Enabled = True
                ts_Generate.Enabled = True
                btnBP.Enabled = True
                ts_print.Enabled = True
            End If

            If txtProjectNo.Text.Trim <> String.Empty Then
                'Kalau dia sudah ada project, button ini sudah pasti akan disable.
                ts_Generate.Enabled = False
                btnBP.Enabled = True
            Else
                If status_trans <> TransStatus.NoStatus Then
                    ts_Generate.Enabled = False
                    btnBP.Enabled = False
                Else
                    ts_Generate.Enabled = True
                    btnBP.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub LoadComboRevision()
        Dim dtTemp As New DataTable
        Dim TD As New TransData
        Dim i As Integer

        cboRevisi.Items.Clear()
        TD.RetrieveSeq_TransPHMarketingHdr(dtTemp, txt_TransNo.Text.Trim)
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

    Private Sub Load_HM()
        Dim tmp As String

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()
            Cmd.CommandText = "EXEC sp_Retrive_Trans_PHMarketing_Hdr_byKey '" + txt_TransNo.Text.Trim + "'," & cboRevisi.SelectedItem.ToString
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            If dt_hdr.Rows.Count > 0 Then
                With dt_hdr.Rows(0)
                    dt_PenawaranDt.Value = .Item("PHM_Date")
                    txt_PHPNo.Text = .Item("PHP_No").ToString.Trim
                    txt_CustID.Text = .Item("Cust_ID").ToString.Trim
                    txt_CustomerName.Text = .Item("Cust_Name").ToString.Trim
                    txt_SurveyNo.Text = .Item("Survey_No").ToString.Trim
                    txt_RemarkMarketing.Text = .Item("Remarks").ToString.Trim
                    txtProjectName.Text = .Item("Project_Name").ToString.Trim

                    tmp = .Item("isOutsource").ToString.Trim
                    If tmp = "Y" Then
                        chkOutsource.Checked = True
                    Else
                        chkOutsource.Checked = False
                    End If

                    txtMarkUp.Text = FormatAngka(.Item("MarkUp_Pct"))
                    txtAdminQCFee.Text = FormatAngka(.Item("AdminQC_Amt"))
                    txtAdminFee.Text = FormatAngka(.Item("Admin_Amt"))
                    txtQCFee.Text = FormatAngka(.Item("QC_Amt"))

                    txtMarkUp_AdminQCFee.Text = FormatAngka(.Item("AdminQC_Persen"))
                    txtMarkUp_AdminFee.Text = FormatAngka(.Item("Admin_Persen"))
                    txtMarkUp_QCFee.Text = FormatAngka(.Item("QC_Persen"))

                    txtDiscAmt.Text = FormatAngka(.Item("DiscAmt"))
                    Try
                        cboRevisi.SelectedValue = .Item("Seq").ToString.Trim
                    Catch ex As Exception
                        cboRevisi.SelectedIndex = 0
                    End Try
                End With

                LoadHargaPenawaranProject()
                RetrieveProject()
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadPHP_fromOutside()
        Load_PHProject_Hdr()
        Load_PHProject_Item_Dtl()
        Load_PHProject_JasaOngkos_Dtl()
        CountTotal()
        LoadHargaPenawaranProject()
    End Sub

    Private Sub Load_PHProject_Hdr()
        Dim TD As New TransData
        Dim MD As New MasterData
        Dim dtTemp As New DataTable
        Dim dtSurvey As New DataTable
        Dim dtCust As New DataTable

        TD.Retrieve_PHProject_Hdr_forPHMarketing(dtTemp, txt_PHPNo.Text.Trim)
        If dtTemp.Rows.Count <> 0 Then
            With dtTemp.Rows(0)
                txt_SurveyNo.Text = .Item("Survey_No").ToString.Trim

                TD.RetrieveSurveyHeaderByKey(dtSurvey, txt_SurveyNo.Text.Trim)
                If dtSurvey.Rows.Count <> 0 Then
                    txt_CustID.Text = dtSurvey.Rows(0).Item(Fields.Cust_ID).ToString.Trim

                    MD.RetrieveCustomerByKey(dtCust, txt_CustID.Text.Trim)
                    If dtCust.Rows.Count <> 0 Then
                        txt_CustomerName.Text = dtCust.Rows(0).Item(Fields.Cust_Name).ToString.Trim
                    End If
                Else
                    txt_CustID.Text = String.Empty
                    txt_CustomerName.Text = String.Empty
                End If

                txt_CustomerName.Text = frmSearch.txtResult5.Text.ToString.Trim
            End With
        End If
    End Sub

    Private Sub txt_PHPNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PHPNo.KeyDown
        Dim sql As String
        sql = "Select PHP_No,PHP_Date,a.Survey_No, isnull(b.Cust_ID, '') Cust_ID, isnull(c.Nama, '') as Cust_Name,Remarks from Trans_PHProject_Hdr a " & _
              "Left Join " & _
              "Trans_Survey_HDr b on a.Survey_No = B.Survey_No " & _
              "Left Join " & _
              "Master_Customer c " & _
              "on b.cust_id = c.Cust_Id " & _
              "where (a.status_id = 'WAMA' OR a.status_id = 'CMP') and PHP_No not in (Select PHP_No from Trans_PHMarketing_Hdr h where h.Active_Flag <> 'N')"

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData(sql, "PHP_No", "PHP_Date", "Survey_No", "Cust_ID", "Cust_Name", "Remarks")
                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_PHPNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_SurveyNo.Text = frmSearch.txtResult3.Text.ToString.Trim
                    txt_CustID.Text = frmSearch.txtResult4.Text.Trim
                    txt_CustomerName.Text = frmSearch.txtResult5.Text.ToString.Trim

                    Load_PHProject_Item_Dtl()
                    Load_PHProject_JasaOngkos_Dtl()
                    CountTotal()
                    LoadHargaPenawaranProject()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_PHPNo.Text.Trim <> String.Empty Then
                Try
                    Load_PHProject_Item_Dtl()
                    Load_PHProject_JasaOngkos_Dtl()
                    CountTotal()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Conn.Close()
                End Try
            End If

        End If
        Conn.Close()
    End Sub

    Private Sub txt_BiayaMarketing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_JasaAdmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_JasaOngkos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_BiayaMarketing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            CountTotal()
        End If
    End Sub

    Private Sub Txt_JasaAdmin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            CountTotal()
        End If
    End Sub

    Private Sub Txt_JasaOngkos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            CountTotal()
        End If
    End Sub

    Private Sub chkOutsource_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOutsource.CheckedChanged
        Dim StrMsg As String

        If status_trans <> TransStatus.NoStatus Then
            If chkOutsource.Checked Then
                StrMsg = "By checking this, these data will be changed." & vbCrLf & _
                         "1. Supporting Type Material will be removed." & vbCrLf & _
                         "2. Services will be reset to 'Ongkos' Service only." & vbCrLf & _
                         "Are you sure to continue ?"

                If MessageBox.Show(StrMsg, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    RemoveSupportingTypeMaterial()
                    ResetServiceToOngkos()
                    CountTotal()

                    Enable_Button_JasaOngkos_Wa(True)
                Else
                    chkOutsource.Checked = False
                End If
            Else
                StrMsg = "By unchecked this, transaction will be cancelled to initial status." & vbCrLf & _
                         "Are you sure to continue ?"

                If MessageBox.Show(StrMsg, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    ts_cancel_Click(Nothing, Nothing)
                Else
                    chkOutsource.Checked = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "Main Button"
    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim TD As New TransData

        status_trans = TransStatus.NewStatus
        If Not (id_status = Status.Draft AndAlso fromPHP) Then
            ClearInput()
        End If

        EnableInput(True)
        DisableButton()
        lbl_status.Text = GlobalVar.TransStatus.NewStatus

        P_Item.Enabled = True
        p_jasa.Enabled = True
        Enable_Button_Item_Wa(True)
        Enable_Button_JasaOngkos_Wa(True)

        cboRevisi.Items.Add(0)
        cboRevisi.SelectedIndex = 0

        ts_Generate.Enabled = False
        ts_print.Enabled = False
        btn_JasaOngkosEdit.Enabled = False
        dt_PenawaranDt.Focus()

        If id_status = Status.Draft AndAlso fromPHP Then
            txtMarkUp_AdminQCFee_LostFocus(Nothing, Nothing)
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        Dim i As Integer
        Dim TD As New TransData

        i = TD.RetrieveMaxSeq_TransPHMarketingHdr(txt_TransNo.Text.Trim)
        If cboRevisi.SelectedItem = i AndAlso status_trans = TransStatus.NoStatus Then
            status_trans = TransStatus.EditStatus
            EnableInput(True)

            P_Item.Enabled = True
            p_jasa.Enabled = True

            DisableButton()
            Enable_Button_Item_Wa(True)
            Enable_Button_JasaOngkos_Wa(True)

            If Not chkOutsource.Checked Then
                btn_JasaOngkosEdit.Enabled = False
            End If
        Else
            If cboRevisi.SelectedItem <> i Then
                MessageBox.Show("Please choose the lastest revision number to edit this document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ts_Generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Generate.Click
        'Cek apakah sudah ada project untuk PHM ini
        Dim TD As New TransData
        Dim dtData As New DataTable
        Dim i As Integer

        i = TD.RetrieveMaxSeq_TransPHMarketingHdr(txt_TransNo.Text.Trim)
        If status_trans = TransStatus.NoStatus AndAlso txt_TransNo.Text.Trim <> String.Empty AndAlso CInt(cboRevisi.SelectedItem) = i Then
            TD.Retrieve_Projects_ByPHMNo(dtData, txt_TransNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                MessageBox.Show("A project for this transaction has been existed," & vbCrLf & "therefore cannot create another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If MessageBox.Show("A new project for this transaction will be made." & vbCrLf & "Continue process ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    If CheckAndGet_MoUDoc() <> "" Then
                        CreateNewProject(CheckAndGet_MoUDoc)
                    Else
                        Exit Sub
                    End If
                End If
            End If
        Else
            If status_trans <> TransStatus.NoStatus Then
                MessageBox.Show("Please save this transaction first to retrieve this Penawaran Number, before you can generate a project from this transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf i <> CInt(cboRevisi.SelectedItem) Then
                MessageBox.Show("Please choose the lastest revision number to generate new project for this document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Function CheckAndGet_MoUDoc() As String
        Dim Dt_Mou As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retreive_Trans_Mou_By_PHMNo '" & txt_TransNo.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(Dt_Mou)

        If Dt_Mou.Rows.Count > 0 Then
            CheckAndGet_MoUDoc = Dt_Mou.Rows(0).Item("MoU_ID").ToString.Trim
        Else
            MessageBox.Show("MoU document Not Found. MoU document must be created before Generate Project.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckAndGet_MoUDoc = ""
            Exit Function
        End If
    End Function


    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If status_trans <> TransStatus.NewStatus Then
            Dim trans As String

            trans = txt_TransNo.Text.Trim
            status_trans = TransStatus.NoStatus

            P_Item.Enabled = False
            p_jasa.Enabled = False

            SetBackColor_Item_Wa("READ")
            EnableInput(False)
            ClearInput()
            Clear_Item_Wa()
            Clear_JasaOngkos_Wa()

            txt_TransNo.Text = trans
            LoadComboRevision()

            Load_HM()
            Load_PHMarketing_Item_Dtl()
            Load_PHMarketing_JasaOngkos_Dtl()
            CountTotal()

            DisableButton()
        Else
            Dim frmChild As New frmViewPenawaranHargaMarketing

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmViewPenawaranHargaMarketing" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        Dim i As Integer
        Dim TD As New TransData

        i = TD.RetrieveMaxSeq_TransPHMarketingHdr(txt_TransNo.Text.Trim)
        If i = CInt(cboRevisi.SelectedItem) AndAlso status_trans = TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this transaction #" & txt_TransNo.Text.Trim & " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Dim ObjTrans As SqlTransaction
                ObjTrans = Conn.BeginTransaction("Trans")
                Cmd.Transaction = ObjTrans

                Try
                    'id_status = Status.PHMarketing_Cancelled  'cancelled by applicant
                    'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                    'UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

                    Cmd.CommandText = "EXEC sp_Delete_Trans_PHMarketing_Hdr '" & txt_TransNo.Text & "'," & CInt(cboRevisi.SelectedItem) & ",'" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Delete) 'Insert History transaction
                    ObjTrans.Commit()
                    Conn.Close()
                    MsgBox("Penawaran Harga Marketing : " & txt_TransNo.Text.Trim & " Has been Deleted")

                    Me.Close()
                Catch ex As Exception
                    ObjTrans.Rollback()
                    Conn.Close()
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            If cboRevisi.SelectedItem <> i Then
                MessageBox.Show("Please choose the lastest revision number to delete this document.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If status_trans <> TransStatus.NoStatus Then
            If dt_item.Rows.Count = 0 Then
                MessageBox.Show("This transaction has not been properly filled (Material)." & vbCrLf & "Saving Process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If dt_JasaOngkos.Rows.Count = 0 Then
                MessageBox.Show("This transaction has not been properly filled (Service/Other)." & vbCrLf & "Saving Process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txt_PHPNo.Text.Trim = String.Empty Then
                MessageBox.Show("Penawaran Harga Project Number has not been filled. Saving process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_PHPNo.Focus()
                Exit Sub
            End If
            If txtTechnicianFeeTotal.Text.Trim = String.Empty Then
                MessageBox.Show("Technician Fee is empty. Saving process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTechnicianFeeTotal.Focus()
                Exit Sub
            End If
            If txtProjectName.Text.Trim = String.Empty Then
                MessageBox.Show("Project name must be fill. Saving process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTechnicianFeeTotal.Focus()
                Exit Sub
            End If
            'If CDbl(txtMarkUp_AdminQCFee.Text) < CDbl(txtMarkUp_AdminFee.Text) Then
            '    MessageBox.Show("Admin & QC Fee's markup must be higher or equal with admin fee's markup.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtMarkUp_AdminFee.Focus()
            '    Exit Sub
            'End If
            'If CDbl(txtTotalMarketing.Text.Trim) < CDbl(txtTotalProject.Text.Trim) Then
            '    MessageBox.Show("Penawaran Marketing Total is lower than Penawaran Project Total. Saving process is cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            If txt_RemarkMarketing.Text.Trim = String.Empty Then
                MessageBox.Show("Please fill Remarks for this transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Set Transaction
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Dim ObjTrans As SqlTransaction
            ObjTrans = Conn.BeginTransaction("Trans")
            Cmd.Transaction = ObjTrans

            Dim LastSerial As Integer
            Dim remarks_Stok As String
            Dim currRev As Integer = cboRevisi.SelectedItem.ToString

            '----Save Penawaran Harga Marketing Header   
            Try
                If status_trans = TransStatus.NewStatus OrElse status_trans = TransStatus.RevisionStatus Then
                    CountTotal() 'Calculate ulang

                    If status_trans <> TransStatus.RevisionStatus Then
                        txt_TransNo.Text = Generate_TranNo(Me.Name)
                        LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
                    End If

                    remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
                    id_status = Status.PHMarketing_Saved  'Waiting approval from Marketing Head   

                    If status_trans = TransStatus.RevisionStatus Then
                        Cmd.CommandText = "exec sp_Delete_Trans_PHMarketing_Hdr_Exclude '" & txt_TransNo.Text.Trim & "'," & cboRevisi.SelectedItem & ", '" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                    End If

                    Cmd.CommandText = "EXEC sp_Insert_Trans_PHMarketing_Hdr '" & txt_TransNo.Text.Trim & "'," & currRev & ",'" & _
                                                 dt_PenawaranDt.Value & "','" & _
                                                 txt_PHPNo.Text.Trim & "','" & _
                                                 txt_RemarkMarketing.Text.Trim & "','" & _
                                                 IIf(chkOutsource.Checked, "Y", "N") & "', '" & _
                                                 txtProjectName.Text.Trim & "', " & _
                                                 CDec(txtMarkUp.Text) & ", " & _
                                                 CDec(txtAdminQCFee.Text) & "," & _
                                                 CDec(txtAdminFee.Text) & "," & _
                                                 CDec(txtQCFee.Text) & "," & _
                                                 CDec(txtMarkUp_AdminQCFee.Text) & "," & _
                                                 CDec(txtMarkUp_AdminFee.Text) & "," & _
                                                 CDec(txtMarkUp_QCFee.Text) & "," & _
                                                 CDec(txtTotalBefDisc.Text) & "," & _
                                                 CDec(txtDiscAmt.Text) & "," & _
                                                 CDec(txtTotalMarketing.Text) & ",'" & _
                                                 id_status & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    For Each item As DataRow In dt_item.Rows
                        'Khusus new transaction, added dan modified diinsert ke table marketing
                        If item.RowState = DataRowState.Added OrElse item.RowState = DataRowState.Modified OrElse item.RowState = DataRowState.Unchanged Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHMarketing_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Item_ID").ToString.Trim & "','" & item("UoM").ToString.Trim & "'," & item("Qty") & "," & _
                                              item("MarkUp_Pct") & ", " & item("Item_Price_M") & ", " & _
                                              item("Price_marketing") & "," & item("SubTotal") & ",'" & item("Item_Category") & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next


                    For Each item As DataRow In dt_JasaOngkos.Rows
                        If item.RowState = DataRowState.Added OrElse item.RowState = DataRowState.Modified OrElse item.RowState = DataRowState.Unchanged Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHMarketing_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Jasa_ID").ToString.Trim & "'," & item("Jlh_Hari") & "," & item("Ongkos") & "," & _
                                              item("SubTotal") & ", '" & item("Remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    'add by kparlind 05-jan-2013: Update status dokumen PH Project menjadi Completed karna sudah di proses oleh ADMIN Marketing
                    Cmd.CommandText = "Update Trans_PHProject_Hdr set Status_ID = 'CMP' where PHP_No = '" & txt_PHPNo.Text.Trim & "'"
                    Cmd.ExecuteNonQuery()

                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to INBOX Purchasing

                    If status_trans <> TransStatus.RevisionStatus Then
                        UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                    End If
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction
                Else
                    If id_status.Trim = Status.PHMarketing_Saved Then 'Waiting approval  from Marketing Head                             
                        id_status = Status.PHMarketing_Completed   'Completed
                    End If
                    'update Penawaran harga project Header
                    Cmd.CommandText = "EXEC sp_Update_Trans_PHMarketing_Hdr '" & txt_TransNo.Text & "'," & currRev & ",'" & dt_PenawaranDt.Value & "','" & _
                                                 txt_PHPNo.Text.Trim & "','" & _
                                                 txt_RemarkMarketing.Text.Trim & "', '" & _
                                                 IIf(chkOutsource.Checked, "Y", "N") & "', '" & _
                                                 txtProjectName.Text.Trim & "', " & _
                                                 CDec(txtMarkUp.Text) & ", " & _
                                                 CDec(txtAdminQCFee.Text) & "," & _
                                                 CDec(txtAdminFee.Text) & "," & _
                                                 CDec(txtQCFee.Text) & "," & _
                                                 CDec(txtMarkUp_AdminQCFee.Text) & "," & _
                                                 CDec(txtMarkUp_AdminFee.Text) & "," & _
                                                 CDec(txtMarkUp_QCFee.Text) & "," & _
                                                 CDec(txtTotalBefDisc.Text) & "," & _
                                                 CDec(txtDiscAmt.Text) & "," & _
                                                 CDec(txtTotalMarketing.Text) & ",'" & _
                                                 id_status & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    'update Penawaran harga marketing Item
                    For Each item As DataRow In dt_item.Rows
                        If item.RowState = DataRowState.Added Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHMarketing_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Item_ID").ToString.Trim & "','" & item("UoM").ToString.Trim & "'," & item("Qty") & "," & _
                                              item("MarkUp_Pct") & ", " & item("Item_Price_M") & ", " & _
                                              item("Price_marketing") & "," & item("SubTotal") & ",'" & item("Item_Category") & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHMarketing_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Item_ID", DataRowVersion.Original).ToString.Trim & "', '" & item("Item_Category", DataRowVersion.Original) & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHMarketing_Item_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Item_ID").ToString.Trim & "','" & item("UoM").ToString.Trim & "'," & item("Qty") & "," & _
                                              item("MarkUp_Pct") & ", " & item("Item_Price_M") & ", " & _
                                              item("Price_marketing") & "," & item("SubTotal") & ",'" & item("Item_Category") & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    'update Penawaran harga project Jasa Ongkos
                    For Each item As DataRow In dt_JasaOngkos.Rows
                        If item.RowState = DataRowState.Added Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_PHMarketing_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Jasa_ID").ToString.Trim & "'," & item("Jlh_Hari") & "," & item("Ongkos") & "," & _
                                              item("SubTotal") & ", '" & item("Remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_PHMarketing_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                               item("Jasa_ID", DataRowVersion.Original).ToString & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd.CommandText = "EXEC sp_Update_Trans_PHMarketing_JasaOngkos_Dtl '" & txt_TransNo.Text + "'," & currRev & ",'" & _
                                              item("Jasa_ID").ToString.Trim & "'," & item("Jlh_Hari") & "," & item("Ongkos") & "," & _
                                              item("SubTotal") & ", '" & item("Remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), String.Empty) 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                    If id_status <> Status.PHMarketing_Completed Then
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(id_status), "W", "Y", id_status) 'Insert to NEXT APPROVAL
                    Else
                        UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "3") 'Close state
                    End If
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction
                End If

                ObjTrans.Commit()
                Conn.Close()

                If status_trans = TransStatus.NewStatus Or status_trans = TransStatus.RevisionStatus Then
                    MessageBox.Show("Form Penawaran Harga Marketing : " & txt_TransNo.Text.Trim & " (Rev. " & cboRevisi.SelectedItem.ToString & ") has been submitted to " & Hirarki.PHM_Saved & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf status_trans = TransStatus.EditStatus Then
                    MessageBox.Show("Form Penawaran Harga Marketing : " & txt_TransNo.Text.Trim & " (Rev. " & cboRevisi.SelectedItem.ToString & ") has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                If status_trans = TransStatus.NewStatus Then 'jika form ini dipanggil dari View
                    'Dim frmChild As New frmViewPenawaranHargaMarketing

                    'For Each f As Form In Me.MdiChildren
                    '    If f.Name = "frmViewPenawaranHargaMarketing" Then
                    '        f.BringToFront()
                    '        Exit Sub
                    '    End If
                    'Next

                    'frmChild.MdiParent = MDIFrm
                    'frmChild.Show()
                    'Me.Hide()

                    status_trans = TransStatus.NoStatus
                    Me.Close()
                Else
                    status_trans = TransStatus.NoStatus
                    DisableButton()
                    frmPenawaranHargaMarketing_Load(Nothing, Nothing)
                End If
            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    'Private Sub btnBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBP.Click
    '    'If status_trans = TransStatus.NoStatus AndAlso txtProjectNo.Text.Trim <> String.Empty Then
    '    '    Dim frmChild As New frmPemakaianBahan
    '    '    Dim TD As New TransData
    '    '    Dim dtTemp As New DataTable

    '    '    frmChild.PHMNo = txt_TransNo.Text.Trim
    '    '    frmChild.fromInbox = False
    '    '    frmChild.TransNo = BP_TransNo
    '    '    frmChild.ShowDialog()

    '    '    TD.Retrieve_PakaiBahan_ByID_fromPHM(dtTemp, txt_TransNo.Text.Trim)
    '    '    If dtTemp.Rows.Count <> 0 Then
    '    '        BP_TransNo = dtTemp.Rows(0).Item(Fields.PB_TransNo).ToString.Trim
    '    '        btnBP.Text = "Edit Bahan Terpasang"
    '    '    Else
    '    '        btnBP.Text = "Create Bahan Terpasang"
    '    '    End If
    '    'End If
    'End Sub
#End Region

#Region "Item"
    Private Sub SetGrid_item()
        gv_item.Columns(0).Width = 80
        gv_item.Columns(0).HeaderText = "Item ID"

        gv_item.Columns(1).Width = 230
        gv_item.Columns(1).HeaderText = "Item Name"
        gv_item.Columns(1).Frozen = True

        gv_item.Columns(2).Width = 120
        gv_item.Columns(2).HeaderText = "Category"

        gv_item.Columns(3).Width = 100
        gv_item.Columns(3).HeaderText = "Type"

        gv_item.Columns(4).Width = 50
        gv_item.Columns(4).HeaderText = "UoM"

        gv_item.Columns(5).Width = 80
        gv_item.Columns(5).HeaderText = "Qty"
        gv_item.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(5).DefaultCellStyle.Format = "#,##0"
        gv_item.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(6).Width = 100
        gv_item.Columns(6).HeaderText = "Item Price"
        gv_item.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(7).Width = 120
        gv_item.Columns(7).HeaderText = "Sub Total"
        gv_item.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(8).Width = 80
        gv_item.Columns(8).HeaderText = "MarkUp"
        gv_item.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(8).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(9).Width = 120
        gv_item.Columns(9).HeaderText = "Item Price (M)"
        gv_item.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(9).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(10).Width = 140
        gv_item.Columns(10).HeaderText = "Item Price Marketing"
        gv_item.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(10).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv_item.Columns(11).Width = 140
        gv_item.Columns(11).HeaderText = "Sub Total Marketing"
        gv_item.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_item.Columns(11).DefaultCellStyle.Format = "#,##0.#0"
        gv_item.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Enable_Item_Wa(ByVal boo As Boolean)
        txtItem_MarkUp.ReadOnly = Not boo
        txtItemPriceMarketing.ReadOnly = Not boo
    End Sub

    Private Sub Clear_Item_Wa()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_ItemQty.Clear()
        txt_ItemCategory.Clear()
        txt_ItemHarga.Clear()
        txt_ItemSubTotal.Clear()
        txtItem_MarkUp.Clear()
        txtItemPriceMarkUp.Clear()
        txtItemPriceMarketing.Clear()
        txtSubTotalMarketing.Clear()
    End Sub

    Private Sub SetBackColor_Item_Wa(ByVal proses As String)
        If proses = "READ" Then
            txtItem_MarkUp.BackColor = Color.LightGray
            txtItemPriceMarketing.BackColor = Color.LightGray
        ElseIf proses = "UPDATE" Then
            txtItem_MarkUp.BackColor = Color.LightGoldenrodYellow
            txtItemPriceMarketing.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub Enable_Button_Item_Wa(ByVal boo As Boolean)
        btn_Itemedit.Enabled = boo
        btn_Itemsave.Enabled = Not boo
        btn_Itemdelete.Enabled = boo
        Btn_Itemcancel.Enabled = Not boo
    End Sub

    Private Sub txtItem_MarkUp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem_MarkUp.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtItem_MarkUp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItem_MarkUp.LostFocus
        If txtItem_MarkUp.Text.Trim = String.Empty Then
            txtItem_MarkUp.Text = FormatAngka(0)
        Else
            txtItem_MarkUp.Text = FormatAngka(CDbl(txtItem_MarkUp.Text))
        End If

        txtItemPriceMarkUp.Text = FormatAngka(((100 + CDbl(txtItem_MarkUp.Text)) / 100) * txt_ItemHarga.Text)
        txtItemPriceMarketing.Text = txtItemPriceMarkUp.Text
        txtItemPriceMarketing_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub txtItemPriceMarketing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemPriceMarketing.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtItemPriceMarketing_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemPriceMarketing.LostFocus
        If txtItemPriceMarketing.Text.Trim = String.Empty Then
            txtItemPriceMarketing.Text = FormatAngka(0)
        Else
            txtItemPriceMarketing.Text = FormatAngka(CDbl(txtItemPriceMarketing.Text))
        End If

        txtSubTotalMarketing.Text = FormatAngka(CDbl(Txt_ItemQty.Text) * CDbl(txtItemPriceMarketing.Text))
    End Sub

    Private Sub Load_PHMarketing_Item_Dtl()
        Dim I As Integer = cboRevisi.SelectedItem.ToString

        dt_item.Clear()
        Cmd.CommandText = "EXEC sp_Retrive_Trans_PHMarketing_Item_Dtl_byKey '" & txt_TransNo.Text.Trim & "', " & I
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        If dt_item.Rows.Count > 0 Then
            gv_item.DataSource = dt_item
            SetGrid_item()
        End If
        gv_item.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub Load_PHProject_Item_Dtl()
        Dim TD As New TransData

        dt_item.Clear()
        TD.Retrieve_PHProject_ItemDtl_forPHMarketing(dt_item, txt_PHPNo.Text.Trim)

        If dt_item.Rows.Count > 0 Then
            gv_item.DataSource = dt_item
            SetGrid_item()
        End If
        gv_item.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_Itemedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemedit.Click
        If txt_ItemID.Text = String.Empty Then
            MessageBox.Show("Please choose 1 data to be edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Status_Proses_Item = "Update"
        Enable_Item_Wa(True)
        Enable_Button_Item_Wa(False)
        SetBackColor_Item_Wa("UPDATE")

        txt_ItemID.BackColor = Color.LightGray
        Txt_ItemQty.Focus()
    End Sub

    Private Sub Btn_Itemcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Itemcancel.Click
        Enable_Item_Wa(False)
        Clear_Item_Wa()
        SetBackColor_Item_Wa("READ")
        Enable_Button_Item_Wa(True)
        gv_item.Enabled = dt_item.Rows.Count > 0
    End Sub

    Private Sub btn_Itemdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemdelete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID")
        dt_item.PrimaryKey = dc

        If txt_ItemID.Text.Trim = String.Empty Then
            MessageBox.Show("Please choose 1 data to be deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses_Item = "Delete"

            da = dt_item.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da.Delete()
                btn_Itemedit.Enabled = True
                btn_Itemdelete.Enabled = True
                gv_item.Focus()
            End If
        End If
    End Sub

    Private Sub btn_Itemsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Itemsave.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        Dim dtView As New DataView(dt_item)
        dc(0) = dt_item.Columns("Item_ID")
        dc(1) = dt_item.Columns("Item_Category")
        dt_item.PrimaryKey = dc

        ' Validation
        If Status_Proses_Item = "Update" Then
            dtView.RowFilter = "Item_ID = '" & txt_ItemID.Text.Trim & "' and Item_Category = '" & txt_ItemCategory.Text.Trim & "'"
            If dtView.Count <> 0 Then
                Dim i As Integer
                For i = 0 To dt_item.Rows.Count - 1
                    If dt_item.Rows(i).RowState <> DataRowState.Deleted Then
                        If dt_item.Rows(i).Item("Item_ID").ToString.Trim = txt_ItemID.Text.Trim AndAlso dt_item.Rows(i).Item("Item_Category").ToString.Trim = txt_ItemCategory.Text.Trim Then
                            da = dt_item.Rows(i)
                            da("MarkUp_Pct") = CDbl(txtItem_MarkUp.Text)
                            da("Item_Price_M") = CDbl(txtItemPriceMarkUp.Text)
                            da("Price_Marketing") = CDbl(txtItemPriceMarketing.Text)
                            da("SubTotal") = CDbl(txtItemPriceMarketing.Text) * CDbl(Txt_ItemQty.Text)
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        CountTotal()
        gv_item.DataSource = dt_item
        'Refresh_Grid()
        Status_Proses_Item = String.Empty  'reset
        Btn_Itemcancel_Click(Nothing, Nothing)
    End Sub

    Private Sub gv_Item_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_item.MouseClick
        Try
            If Not gv_item Is Nothing Then
                If String.IsNullOrEmpty(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value) = False Then
                    txt_ItemID.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
                    txt_ItemName.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
                    txt_ItemCategory.Text = gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Category).Value.ToString.Trim
                    Txt_ItemQty.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Qty).Value.ToString.Trim), 0)
                    txt_ItemHarga.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Item_Price).Value.ToString.Trim))

                    If gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("SubTotalProject").Value.ToString.Trim = String.Empty Then
                        txt_ItemSubTotal.Text = FormatAngka(0)
                    Else
                        txt_ItemSubTotal.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("SubTotalProject").Value))
                    End If

                    If gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("MarkUp_Pct").Value.ToString.Trim = String.Empty Then
                        txtItem_MarkUp.Text = FormatAngka(0)
                    Else
                        txtItem_MarkUp.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("MarkUp_Pct").Value))
                    End If

                    If gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("Item_Price_M").Value.ToString.Trim = String.Empty Then
                        txtItemPriceMarkUp.Text = FormatAngka(0)
                    Else
                        txtItemPriceMarkUp.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("Item_Price_M").Value))
                    End If

                    If gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("Price_Marketing").Value.ToString.Trim = String.Empty Then
                        txtItemPriceMarketing.Text = FormatAngka(0)
                    Else
                        txtItemPriceMarketing.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells("Price_Marketing").Value))
                    End If

                    If gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.SubTotal).Value IsNot Nothing Then
                        txtSubTotalMarketing.Text = FormatAngka(CDbl(gv_item.Rows(gv_item.CurrentCell.RowIndex).Cells(GlobalVar.Fields.SubTotal).Value.ToString.Trim))
                    Else
                        txtSubTotalMarketing.Text = FormatAngka(0)
                    End If
                End If
            End If
        Finally
        End Try
    End Sub
#End Region

#Region "Jasa"
    Private Sub Enable_JasaOngkos_Wa(ByVal boo As Boolean)
        If chkOutsource.Checked Then
            txt_JasaOngkosLama.ReadOnly = Not boo
            txt_JasaOngkosKet.ReadOnly = Not boo
        End If
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
            If chkOutsource.Checked Then
                txt_JasaOngkosLama.BackColor = Color.LightGoldenrodYellow
                txt_JasaOngkosKet.BackColor = Color.LightGoldenrodYellow
            End If
        End If
    End Sub

    Private Sub Enable_Button_JasaOngkos_Wa(ByVal boo As Boolean)
        btn_JasaOngkosEdit.Enabled = boo
        btn_JasaOngkosSave.Enabled = Not boo
        btn_JasaOngkosCancel.Enabled = Not boo
    End Sub

    Private Sub Load_PHMarketing_JasaOngkos_Dtl()
        dt_JasaOngkos.Clear()
        Cmd.CommandText = "EXEC sp_Retrive_Trans_PHMarketing_JasaOngkos_Dtl_byKey '" & txt_TransNo.Text & "', " & cboRevisi.SelectedItem.ToString
        DA.SelectCommand = Cmd
        DA.Fill(dt_JasaOngkos)

        If dt_JasaOngkos.Rows.Count > 0 Then
            gv_jasaOngkos.DataSource = dt_JasaOngkos
            SetGrid_JasaOngkos()
        End If
        gv_jasaOngkos.Enabled = gv_jasaOngkos.Rows.Count > 0
    End Sub

    Private Sub Load_PHProject_JasaOngkos_Dtl()
        Dim TD As New TransData

        dt_JasaOngkos.Clear()
        TD.Retrieve_PHProject_JasaOngkos_forPHMarketing(dt_JasaOngkos, txt_PHPNo.Text.Trim)

        If dt_JasaOngkos.Rows.Count > 0 Then
            gv_jasaOngkos.DataSource = dt_JasaOngkos
            SetGrid_JasaOngkos()
        End If
        gv_jasaOngkos.Enabled = gv_jasaOngkos.Rows.Count > 0
    End Sub

    Private Sub txt_JasaOngkosLama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_JasaOngkosLama.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
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

    Private Sub btn_JasaOngkosEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosEdit.Click
        If chkOutsource.Checked Then
            If txt_JasaOngkosID.Text.Trim = String.Empty Then
                MessageBox.Show("Please choose 1 data to be edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Status_Proses_JasaOngkos = "Update"
            Enable_JasaOngkos_Wa(True)
            SetBackColor_JasaOngkos_Wa("UPDATE")

            Enable_Button_JasaOngkos_Wa(False)
            txt_JasaOngkosID.ReadOnly = True 'karna primary Key
            txt_JasaOngkosID.BackColor = Color.LightGray
            txt_JasaOngkosLama.Focus()
        End If
    End Sub

    Private Sub btn_JasaOngkosCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosCancel.Click
        If chkOutsource.Checked Then
            Enable_JasaOngkos_Wa(False)
            Clear_JasaOngkos_Wa()
            SetBackColor_JasaOngkos_Wa("READ")

            Enable_Button_JasaOngkos_Wa(True)
            gv_jasaOngkos.Enabled = dt_JasaOngkos.Rows.Count > 0
        End If
    End Sub

    Private Sub btn_JasaOngkosSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_JasaOngkosSave.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        'Dim i As Integer

        dc(0) = dt_JasaOngkos.Columns(0)
        dt_JasaOngkos.PrimaryKey = dc

        ' Validation
        If txt_JasaOngkosLama.Text.Trim = String.Empty Then
            MessageBox.Show("Work days range must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses_JasaOngkos = "Update" Then
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
        CountTotal()
        gv_jasaOngkos.DataSource = dt_JasaOngkos
        SetGrid_JasaOngkos()
        Status_Proses_JasaOngkos = String.Empty  'reset
        btn_JasaOngkosCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub gv_Jasaongkos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_jasaOngkos.MouseClick
        If String.IsNullOrEmpty(gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value) = False Then
            txt_JasaOngkosID.Text = gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_ID).Value.ToString.Trim
            txt_JasaOngkosName.Text = gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jasa_Name).Value.ToString.Trim
            txt_JasaOngkosLama.Text = gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.Jlh_Hari).Value.ToString.Trim
            txt_JasaOngkosOngkos.Text = FormatAngka(CDbl(gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaOngkos).Value.ToString.Trim))
            txt_JasaOngkosHarga.Text = FormatAngka(CDbl(gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaSubTotal).Value.ToString.Trim))
            txt_JasaOngkosKet.Text = gv_jasaOngkos.Rows(gv_jasaOngkos.CurrentCell.RowIndex).Cells(GlobalVar.Fields.JasaRemarks).Value.ToString.Trim
        End If
    End Sub

    Private Sub SetGrid_JasaOngkos()
        gv_jasaOngkos.Columns(0).Width = 80
        gv_jasaOngkos.Columns(0).HeaderText = "Service ID"
        gv_jasaOngkos.Columns(1).Width = 220
        gv_jasaOngkos.Columns(1).HeaderText = "Service Name"
        gv_jasaOngkos.Columns(2).Width = 60
        gv_jasaOngkos.Columns(2).HeaderText = "Days"
        gv_jasaOngkos.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(2).DefaultCellStyle.Format = "#,##0.#0"
        gv_jasaOngkos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(3).Width = 80
        gv_jasaOngkos.Columns(3).HeaderText = "Fee/Day"
        gv_jasaOngkos.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(3).DefaultCellStyle.Format = "#,##0.#0"
        gv_jasaOngkos.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(4).Width = 100
        gv_jasaOngkos.Columns(4).HeaderText = "Total Fee"
        gv_jasaOngkos.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(4).DefaultCellStyle.Format = "#,##0.#0"
        gv_jasaOngkos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_jasaOngkos.Columns(5).Width = 270
        gv_jasaOngkos.Columns(5).HeaderText = "Remark"
    End Sub
#End Region

#Region "Proses"
    Private Sub LoadHargaPenawaranProject()
        Dim TD As New TransData
        Dim dtData As New DataTable

        TD.Retrieve_PHProject_Hdr_forPHMarketing(dtData, txt_PHPNo.Text.Trim)
        If dtData.Rows.Count <> 0 Then
            txtTotalProject.Text = FormatAngka(CDbl(dtData.Rows(0).Item("Total_PHP")))
        Else
            txtTotalProject.Text = FormatAngka(0)
        End If
    End Sub

    Private Sub RetrieveProject()
        Dim dtdata As New DataTable
        Dim TD As New TransData

        TD.Retrieve_Projects_ByPHMNo(dtdata, txt_TransNo.Text.Trim)
        If dtdata.Rows.Count <> 0 Then
            txtProjectNo.Text = dtdata.Rows(0).Item(0).ToString.Trim
            'ts_Generate.Enabled = False
        Else
            txtProjectNo.Text = String.Empty
            'ts_Generate.Enabled = True
        End If
    End Sub

    Private Sub CreateNewProject(ByVal MoUDoc As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim sqlParam As String = String.Empty
        Dim sql As String = String.Empty
        Dim NewProjectNo As String
        Dim lastSerial As String
        Dim GrandTotalProject As String

        Try
            NewProjectNo = Generate_TranNo("FormProject")
            lastSerial = CInt(Microsoft.VisualBasic.Right(NewProjectNo, 3))

            GrandTotalProject = Replace(txtTotalMarketing.Text, ",", "") 'memganti tanda koma dengan tanda titik agar gak error di query

            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            'Get nomor MoU

            sql = "exec sp_Insert_Trans_Project "
            sqlParam = "'" & NewProjectNo & "','" & Now.ToString("MM-dd-yyyy") & "','" & MoUDoc & "','" & txt_TransNo.Text.Trim & "','" & txt_SurveyNo.Text.Trim & "'," & GrandTotalProject & ",'" & txt_RemarkMarketing.Text.Trim & "','','" & userlog.UserName & "' "
            Cmd.CommandText = sql & sqlParam
            Cmd.ExecuteNonQuery()

            UpdateSerial("FormProject", Month(Now), Year(Now), lastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction

            txtProjectNo.Text = NewProjectNo
            MessageBox.Show("Creating new project succeed." & vbCrLf & "Project number for this transaction is '" & NewProjectNo & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ts_Generate.Enabled = False
            txt_PHPNo.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub ResetServiceToOngkos()
        Dim i As Integer
        Dim gRow As DataGridViewRow
        Dim MD As New MasterData
        Dim dc(0) As DataColumn
        'Dim da As Data.DataRow

        i = gv_jasaOngkos.RowCount - 1
        While i >= 0
            If gv_jasaOngkos.Rows(i).Cells("Jasa_ID").Value <> ServiceOngkos Then
                gRow = gv_jasaOngkos.Rows(i)
                gv_jasaOngkos.Rows.Remove(gRow)
            End If

            i -= 1
        End While

        If gv_jasaOngkos.RowCount = 0 Then
            dt_JasaOngkos.Columns.Clear()
            dt_JasaOngkos.Columns.Add("Jasa_ID", System.Type.GetType("System.String"))
            dt_JasaOngkos.Columns.Add("Jasa_Name", System.Type.GetType("System.String"))
            dt_JasaOngkos.Columns.Add("Jlh_Hari", System.Type.GetType("System.Int32"))
            dt_JasaOngkos.Columns.Add("Ongkos", System.Type.GetType("System.Double"))
            dt_JasaOngkos.Columns.Add("SubTotal", System.Type.GetType("System.Double"))
            dt_JasaOngkos.Columns.Add("Remarks", System.Type.GetType("System.String"))

            dc(0) = dt_JasaOngkos.Columns("Jasa_ID")
            dt_JasaOngkos.PrimaryKey = dc

            dr_JasaOngkos = dt_JasaOngkos.NewRow
            With dr_JasaOngkos
                .Item("Jasa_ID") = ServiceOngkos
                .Item("Jasa_Name") = MD.RetrieveJasaName_ByID(.Item("Jasa_ID"))
                .Item("Jlh_Hari") = 0
                .Item("Ongkos") = FormatAngka(MD.RetrieveJasaPrice(ServiceOngkos))
                .Item("SubTotal") = FormatAngka(.Item("Jlh_Hari") * .Item("Ongkos"))
                .Item("Remarks") = txt_JasaOngkosKet.Text
            End With
            dt_JasaOngkos.Rows.Add(dr_JasaOngkos)

            gv_jasaOngkos.DataSource = dt_JasaOngkos
            SetGrid_JasaOngkos()
        End If
    End Sub

    Private Sub RemoveSupportingTypeMaterial()
        Dim i As Integer
        Dim gRow As DataGridViewRow

        i = gv_item.RowCount - 1
        While i >= 0
            If gv_item.Rows(i).Cells("Item_Type").Value.ToString.Trim = "Pendukung" Then
                gRow = gv_item.Rows(i)
                gv_item.Rows().Remove(gRow)
            End If
            i -= 1
        End While
    End Sub

    Private Sub CountSubTotal()
        Dim totalSupporting As Double = 0
        Dim totalMain As Double = 0

        'Hitung Item
        ttl_Item_Project = 0
        ttl_Item_Marketing = 0
        For Each item As DataRow In dt_item.Rows
            If item.RowState <> DataRowState.Deleted Then
                If item("Item_Type") = "Pendukung" Then
                    totalSupporting += item("SubTotal")
                Else
                    totalMain += item("SubTotal")
                End If

                ttl_Item_Project = ttl_Item_Project + item("SubTotalProject")
                ttl_Item_Marketing = ttl_Item_Marketing + item("SubTotal")
            End If
        Next
        txt_ttlItem_Project.Text = FormatAngka(CDbl(ttl_Item_Project))
        txt_ttlItem_Marketing.Text = FormatAngka(CDbl(ttl_Item_Marketing))
        txtMICEMain.Text = FormatAngka(CDbl(totalMain))
        txtSupportingTotal.Text = FormatAngka(CDbl(totalSupporting))

        'Hitung Jasa Ongkos
        ttl_JasaOngkos_Project = 0
        For Each item As DataRow In dt_JasaOngkos.Rows
            If item.RowState <> DataRowState.Deleted Then
                ttl_JasaOngkos_Project = ttl_JasaOngkos_Project + item("SubTotal")
            End If
        Next
        txt_ttlJasaOngkos.Text = FormatAngka(CDbl(ttl_JasaOngkos_Project))
        txtTechnicianFeeTotal.Text = txt_ttlJasaOngkos.Text
    End Sub

    Private Sub CountTotalInitial()
        CountSubTotal()

        txtSubTotalMain.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtMarkUpAmt.Text))
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtSupportingTotal.Text))

        txtMarkUp_AdminQCFee.Text = FormatAngka((CDbl(txtAdminQCFee.Text) / (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))) * 100)
        txtMarkUp_AdminFee.Text = FormatAngka((CDbl(txtAdminFee.Text) / CDbl(txtAdminQCFee.Text)) * CDbl(txtMarkUp_AdminQCFee.Text))
        txtMarkUp_QCFee.Text = FormatAngka((CDbl(txtQCFee.Text) / CDbl(txtAdminQCFee.Text)) * CDbl(txtMarkUp_AdminQCFee.Text))
        txtDiscAmt_LostFocus(Nothing, Nothing)
    End Sub

    Private Sub CountTotal()
        CountSubTotal()

        txtMarkUp_LostFocus(Nothing, Nothing)
        txtSubTotalMain.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtMarkUpAmt.Text))
        txtMICEMaterialTotal.Text = FormatAngka(CDbl(txtMICEMain.Text) + CDbl(txtSupportingTotal.Text) + CDbl(txtMarkUpAmt.Text))

        '--started : Added by kparlind
        If txtMarkUp_AdminQCFee.Text = String.Empty Then txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        If txtMarkUp_AdminFee.Text = String.Empty Then txtMarkUp_AdminFee.Text = FormatAngka(0)
        If txtMarkUp_QCFee.Text = String.Empty Then txtMarkUp_QCFee.Text = FormatAngka(0)
        '--ended : Added by kparlind

        txtAdminQCFee.Text = FormatAngka((CDbl(txtMarkUp_AdminQCFee.Text) * (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))) / 100)
        'txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)
        'txtQCFee.Text = FormatAngka((CDbl(txtMarkUp_QCFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)

        'txtAdminQCFee.Text = FormatAngka((8 * (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))) / 100)
        'txtAdminFee.Text = FormatAngka((60 * CDbl(txtAdminQCFee.Text)) / 100)
        'txtQCFee.Text = FormatAngka((40 * CDbl(txtAdminQCFee.Text)) / 100)
    End Sub
#End Region

    Private Sub txtMarkUp_AdminQCFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarkUp_AdminQCFee.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    '------started : Added by kparlind 21-nov-2012
    Private Sub txtMarkUp_AdminQCFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_AdminQCFee.LostFocus
        Try
            txtMarkUp_AdminQCFee.Text = FormatAngka(CDbl(txtMarkUp_AdminQCFee.Text))
        Catch ex As Exception
            txtMarkUp_AdminQCFee.Text = FormatAngka(0)
        End Try

        txtAdminQCFee.Text = FormatAngka((CDbl(txtMarkUp_AdminQCFee.Text) * (CDbl(txtMICEMaterialTotal.Text) + CDbl(txtTechnicianFeeTotal.Text))) / 100)
        txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) * CDbl(txtMarkUp_AdminQCFee.Text)) / CDbl(txtAdminQCFee.Text))
        txtMarkUp_AdminFee_LostFocus(Nothing, Nothing)

        'txtQCFee.Text = FormatAngka((CDbl(txtMarkUp_QCFee.Text) / CDbl(txtMarkUp_AdminQCFee.Text)) * CDbl(txtAdminQCFee.Text))
        txtQCFee.Text = FormatAngka((CDbl(txtMarkUp_QCFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)
    End Sub

    Private Sub txtMarkUp_AdminFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarkUp_AdminFee.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtMarkUp_AdminFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_AdminFee.LostFocus
        Try
            txtMarkUp_AdminFee.Text = FormatAngka(CDbl(txtMarkUp_AdminFee.Text))
        Catch ex As Exception
            txtMarkUp_AdminFee.Text = FormatAngka(0)
        End Try

        'If CDbl(txtMarkUp_AdminFee.Text.Trim) > CDbl(txtMarkUp_AdminQCFee.Text.Trim) Then
        '    txtMarkUp_QCFee.Text = FormatAngka(0)
        '    txtMarkUp_QCFee_LostFocus(Nothing, Nothing)
        'Else
        'txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) / IIf(CDbl(txtMarkUp_AdminQCFee.Text) = 0, 1, CDbl(txtMarkUp_AdminQCFee.Text))) * CDbl(txtAdminQCFee.Text))
        txtAdminFee.Text = FormatAngka((CDbl(txtMarkUp_AdminFee.Text) * CDbl(txtAdminQCFee.Text)) / 100)

        'txtMarkUp_QCFee.Text = FormatAngka(CDbl(txtMarkUp_AdminQCFee.Text) - CDbl(txtMarkUp_AdminFee.Text))
        txtMarkUp_QCFee.Text = FormatAngka(CDbl(100) - CDbl(txtMarkUp_AdminFee.Text))
        txtMarkUp_QCFee_LostFocus(Nothing, Nothing)
        'End If
    End Sub

    Private Sub txtMarkUp_QCFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarkUp_QCFee.LostFocus
        Dim markupQC, AdminQCFee As Double
        'Dim markupAdminQC As Double

        Try
            txtMarkUp_QCFee.Text = FormatAngka(CDbl(txtMarkUp_QCFee.Text))
        Catch ex As Exception
            txtMarkUp_QCFee.Text = FormatAngka(0)
        End Try

        'Dim t As Double = (CDbl(txtMarkUp_QCFee.Text) / IIf(CDbl(txtMarkUp_AdminQCFee.Text) = 0, 1, CDbl(txtMarkUp_AdminQCFee.Text))) * CDbl(txtAdminQCFee.Text)
        'txtQCFee.Text = FormatAngka(t)
        'Added bykparlind at anyer
        markupQC = CDbl(txtMarkUp_QCFee.Text)
        AdminQCFee = CDbl(txtAdminQCFee.Text)

        txtQCFee.Text = FormatAngka((markupQC * AdminQCFee) / 100)
    End Sub

    Private Sub txtDiscAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscAmt.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtDiscAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscAmt.LostFocus
        Try
            txtDiscAmt.Text = FormatAngka(CDbl(txtDiscAmt.Text))
        Catch ex As Exception
            txtDiscAmt.Text = FormatAngka(0)
        End Try

        txtTotalMarketing.Text = FormatAngka(CDbl(txtTotalBefDisc.Text) - CDbl(txtDiscAmt.Text))
    End Sub

    Private Sub cboRevisi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRevisi.SelectedIndexChanged
        If status_trans = TransStatus.NoStatus Then
            Dim dtTemp As New DataTable
            Dim TD As New TransData

            TD.RetrievePHMHdr_ByKey(dtTemp, txt_TransNo.Text.Trim, cboRevisi.SelectedItem.ToString)
            If dtTemp.Rows.Count <> 0 Then
                Load_HM()
                Load_PHMarketing_Item_Dtl()
                Load_PHMarketing_JasaOngkos_Dtl()
                CountTotalInitial()
            End If
        End If
    End Sub

    Private Sub btnRevision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevision.Click
        If status_trans = TransStatus.NoStatus Then
            If id_status = Status.PHMarketing_Completed Then
                Dim TD As New TransData
                Dim i As Integer

                i = TD.RetrieveMaxSeq_TransPHMarketingHdr(txt_TransNo.Text.Trim)
                cboRevisi.Items.Add(i + 1)
                cboRevisi.SelectedIndex = cboRevisi.Items.Count - 1

                status_trans = TransStatus.RevisionStatus
                EnableInput(True)

                P_Item.Enabled = True
                p_jasa.Enabled = True

                DisableButton()
                Enable_Button_Item_Wa(True)
                Enable_Button_JasaOngkos_Wa(True)


                lbl_status.Text = Status.Draft

                If Not chkOutsource.Checked Then
                    btn_JasaOngkosEdit.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub btnPrintPenawaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPenawaran.Click
        Dim frmChild As New frmReport
        Dim dtData As New DataTable
        Dim TD As New TransData

        If status_trans = TransStatus.NoStatus Then
            If TD.RetrieveMaxSeq_TransPHMarketingHdr(txt_TransNo.Text.Trim) = cboRevisi.SelectedItem Then
                TD.Retrieve_FormPenawaranMarketing_Hdr(dtData, txt_TransNo.Text.Trim, cboRevisi.SelectedItem)

                If dtData.Rows.Count <> 0 Then
                    frmChild.ReportName = "PHM Form"
                    frmChild.PHMNo = txt_TransNo.Text.Trim
                    frmChild.Seq = cboRevisi.SelectedItem.ToString
                    For Each f As Form In Me.MdiChildren
                        If f.Name = "frmReport" Then
                            f.BringToFront()
                            Exit Sub
                        End If
                    Next

                    frmChild.MdiParent = MDIFrm
                    frmChild.Show()
                Else
                    MessageBox.Show("This transaction's print out cannot be printed." & vbCrLf & "Please make sure that the transaction has been in completed status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please choose the lastest revision number to print this transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub Txt_ItemQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ItemQty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class