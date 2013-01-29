'(20 Des 2012) Modify save process and flow.
'(21 Des 2012) Check error.

Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmSPK
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt_OP As New DataTable
    Dim dt_item As New DataTable
    Dim dr_item As DataRow
    Dim dt_ST As New DataTable
    Dim id_login As String
    Dim Status_Proses As String
    Dim Status_Trans As String

    Public ViewFormName As String

#Region "Interface"
    Private Sub frmSPK_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Status_Trans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Dim frmChild As New frmViewSPK

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmViewSPK" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
    End Sub

    Private Sub FrmSPK_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_Edit, ts_delete, ts_save, ts_cancel, ts_Print, Nothing, Nothing)

        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        ClearInput()
        Clear_Wa()

        ts_New.Visible = False
        SetAccess(Me, userlog.AccessID, ViewFormName)

        If txt_TransNo.Text.ToString.Trim <> String.Empty Then 'Jika dipanggil dari View Penerimaan Barang
            Load_SPK()
            Load_Grid()
            lbl_status.Text = GetStatus(id_status)
            'lbl_status.Text = String.Empty

            EnableInput(False)
            EnableButton(True)
            Enable_Button_Wa(True)
            Enable_Wa(False)

            btn_edit.Enabled = False
            btn_delete.Enabled = False
            btn_insert.Enabled = False

            If id_status = Status.SPK_Completed Then
                ts_Edit.Enabled = False
                ts_delete.Enabled = False
            End If
        Else
            'ts_New.Enabled = True
            ts_New_Click(Nothing, Nothing)
            Load_Grid() 'untuk membentuk kerangka Datatable yang digunakan di GridView            
        End If

        SetBackColor_Wa("READ")
    End Sub

    Private Sub ClearInput()
        'txt_TransNo.Clear()
        txt_ProjectNo.Clear()
        txt_Remarks.Clear()
        txt_CustomerID.Clear()
        txt_CustomerName.Clear()
        txt_PIC.Clear()
        cboType.SelectedIndex = 0

        gv_SPK.DataSource = ""
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        txt_ProjectNo.ReadOnly = Not boo
        dt_SPKDate.Enabled = boo
        txt_Remarks.ReadOnly = Not boo
        txt_CustomerID.ReadOnly = Not boo
        txt_CustomerName.ReadOnly = Not boo
        txt_PIC.ReadOnly = Not boo
        cboType.Enabled = boo

        Select Case Not boo
            Case True
                txt_ProjectNo.BackColor = Color.Empty
                txt_Remarks.BackColor = Color.Empty
            Case False
                txt_ProjectNo.BackColor = Color.LightGoldenrodYellow
                txt_Remarks.BackColor = Color.LightGoldenrodYellow
        End Select
    End Sub

    Private Sub EnableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = Not boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = Not boo

        If txt_TransNo.Text.Trim <> String.Empty Then
            ts_Print.Enabled = boo
        Else
            ts_Print.Enabled = False
        End If

        If id_status = Status.Draft OrElse id_status = String.Empty Then
            If Not (userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin) Then
                ts_Edit.Enabled = False
                ts_delete.Enabled = False
            End If
        ElseIf id_status = Status.SPK_Saved Then
            If Not (userlog.AccessID = Role.ProjectHead OrElse userlog.AccessID = Role.SuperAdmin) Then
                ts_Edit.Enabled = False
                ts_delete.Enabled = False
            End If
        ElseIf id_status = Status.SPK_Completed Then
            ts_Edit.Enabled = False
            ts_delete.Enabled = False
        End If
    End Sub

    Private Sub txt_ProjectNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ProjectNo.LostFocus
        Dim sqlConn As New SqlConnection
        Dim sqlCom As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable
        Dim sql As String

        sqlConn.ConnectionString = ConnectStr
        sqlConn.Open()

        sqlCom.Connection = sqlConn
        sqlCom.CommandType = CommandType.Text

        If cboType.SelectedIndex = 0 Then
            sql = "Select Project_No,Project_Date, a.PHM_No as Pnawaran_Marketing,a.Survey_No,c.Cust_Id,isnull(d.Nama, '') as Nama, isnull(c.Penanggung_Project, '') PIC from " & Chr(13) & _
                  "Trans_Projects a " & Chr(13) & _
                  "Left join Trans_PHMarketing_Hdr b on a.PHM_No = b.PHM_No " & Chr(13) & _
                  "Left join Trans_Survey_Hdr c on c.Survey_No = a.Survey_No " & Chr(13) & _
                  "Left join Master_Customer d on c.Cust_ID = d.Cust_ID " & Chr(13) & _
                  "where a.Status_ID = 'CMP' and b.Active_Flag = 'Y' and Project_No = '" & txt_ProjectNo.Text.Trim & "'"
            sqlCom.CommandText = sql
            DA.SelectCommand = sqlCom
            DA.Fill(dtData)
        Else
            sql = "Select OrderMaint_No,OrderMaint_dt, a.Cust_Id,isnull(d.Nama, '') as Nama, PIC from " & Chr(13) & _
                  "Trans_OrderMaintance a " & Chr(13) & _
                  "Left join Master_Customer d on d.Cust_ID = a.Cust_ID " & Chr(13) & _
                  "where a.Status_ID = 'CMP' and OrderMaint_No = '" & txt_ProjectNo.Text.Trim & "'"
            sqlCom.CommandText = sql
            DA.SelectCommand = sqlCom
            DA.Fill(dtData)
        End If


        If dtData.Rows.Count <> 0 Then
            With dtData.Rows(0)
                txt_CustomerID.Text = .Item(Fields.Cust_ID).ToString.Trim
                txt_CustomerName.Text = .Item(Fields.Cust_Name).ToString.Trim
                txt_PIC.Text = .Item("PIC").ToString.Trim
            End With
        Else
            txt_CustomerID.Text = String.Empty
            txt_CustomerName.Text = String.Empty
            txt_PIC.Text = String.Empty
        End If
    End Sub

    Private Sub txt_ProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ProjectNo.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            Try
                If cboType.SelectedIndex = 0 Then
                    sql = "Select Project_No, isnull(Project_Name, '') Project_Name, Project_Date, a.PHM_No as Pnawaran_Marketing,a.Survey_No,c.Cust_Id,isnull(d.Nama, '') as Cust_Name, isnull(d.Nama_Operator, '') Nama_Operator from " & Chr(13) & _
                          "Trans_Projects a " & Chr(13) & _
                          "Left join Trans_PHMarketing_Hdr b on a.PHM_No = b.PHM_No " & Chr(13) & _
                          "Left join Trans_Survey_Hdr c on c.Survey_No = a.Survey_No " & Chr(13) & _
                          "Left join Master_Customer d on c.Cust_ID = d.Cust_ID where b.Active_Flag = 'Y' "
                    '& Chr(13) & _
                    '"where a.Status_ID = 'CMP'"
                    Cmd.CommandText = sql

                    CallandGetSearchData(sql, "Project_No", "Project_Name", "Project_Date", "Pnawaran_Marketing", "Survey_No", "Cust_Name")
                    If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                        If Conn.State = ConnectionState.Closed Then
                            Conn.Open()
                        End If

                        txt_ProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_Remarks.Focus()
                    End If
                ElseIf cboType.SelectedIndex = 1 Then
                    sql = "exec sp_Retrieve_Trans_OrderMaintenance_ForSearchSPK"
                    Cmd.CommandText = sql
                    CallandGetSearchData(sql, "OrderMaint_No", "Project_No", "Project_Name", "CustName", "PIC")
                    If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                        If Conn.State = ConnectionState.Closed Then
                            Conn.Open()
                        End If

                        txt_ProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_Remarks.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
        Conn.Close()
    End Sub

#End Region

#Region "MAIN BUTTON"
    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If Status_Trans = TransStatus.NewStatus Then
            Status_Trans = String.Empty
            Me.Close()
        Else
            Status_Trans = String.Empty

            EnableButton(True)
            Enable_Button_Wa(False)

            Btn_cancel.Enabled = False
            btn_save.Enabled = False

            SetBackColor_Wa("READ")
            EnableInput(False)

            Load_SPK()
            Load_Grid()
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        Status_Trans = TransStatus.EditStatus
        EnableInput(True)
        Enable_Button_Wa(True)
        EnableButton(False)
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Status_Trans = TransStatus.NewStatus
        id_status = Status.Draft
        ClearInput()

        EnableInput(True)
        Enable_Wa(False)

        Enable_Button_Wa(True)
        EnableButton(False)

        Status_Proses = String.Empty
        lbl_status.Text = GetStatus(id_status)
        txt_ProjectNo.Focus()
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim dtTemp As New DataTable
        Dim TD As New TransData

        If dt_item.Rows.Count = 0 Then
            MsgBox("Detail SPK has not been set." & vbCrLf & "Saving process is cancelled.")
            Exit Sub
        End If

        If cboType.SelectedIndex = 0 Then
            TD.Retrieve_Projects_ByID(dtTemp, txt_ProjectNo.Text.Trim)
        ElseIf cboType.SelectedIndex = 1 Then
            TD.Retrieve_OrderMaintenance_ByID(dtTemp, txt_ProjectNo.Text.Trim)
        End If

        If dtTemp.Rows.Count = 0 Then
            MsgBox("The reference# '" & txt_ProjectNo.Text.Trim & "' is not valid." & vbCrLf & "Saving process is cancelled.")
            Exit Sub
        End If


        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim remarks_Stok As String
        Dim NewSerialNo As String

        ObjTrans = Conn.BeginTransaction
        Cmd.Transaction = ObjTrans

        '----Save LPB Header   
        If Status_Trans = TransStatus.NewStatus OrElse Status_Trans = TransStatus.EditStatus Then
            Try
                'Cause this form is for insert Terim Barang, so next status is Waiting for Purchasing (WAFP)
                '(20 Des 2012) Flow changed, Project Admin -> Project Head -> Closed.
                '(20 Des 2012) Super admin bisa mencreate transaksi, namun without inbox.
                If id_status = "" OrElse id_status = Status.Draft Then
                    id_status = Status.SPK_Saved  'Waiting approval from head

                    If Status_Trans = TransStatus.NewStatus Then
                        NewSerialNo = Generate_TranNo(Me.Name)
                        LastSerial = CInt(Microsoft.VisualBasic.Right(NewSerialNo, 3))
                        remarks_Stok = "Transaction : " & NewSerialNo & " processes by " & userlog.UserName & " at " & CStr(Now())
                        'id_status = ""
                        Cmd.CommandText = "EXEC sp_Insert_Trans_SPK_HDr '" & NewSerialNo & "','" & _
                                                     dt_SPKDate.Value.ToString("yyyy-MM-dd") & "'," & cboType.SelectedIndex & ",'" & _
                                                     txt_ProjectNo.Text & "','" & _
                                                     txt_Remarks.Text.Trim & "','" & _
                                                     id_status.Trim & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()
                        For Each item As DataRow In dt_item.Rows
                            Cmd.CommandText = "EXEC sp_Insert_Trans_SPK_Dtl '" & NewSerialNo & "','" & _
                                              item("Teknisi_ID").ToString.Trim & "','" & item("Jasa_ID").ToString.Trim & "','" & item("Start_Dt") & "','" & _
                                              item("TotalMinute") & "','" & item("remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()

                            'Insert untuk proses bagian Stok
                            'Insert_StokMovement(item("Item_ID"), txt_TransNo.Text.Trim, "IN", item("Qty_Jadi"), remarks_Stok)
                        Next
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", id_status) 'Insert to INBOX utk diri sendiri
                        UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                        Insert_Trans_History(NewSerialNo, Me.Name, "INSERT") 'Insert History transaction

                        txt_TransNo.Text = NewSerialNo
                    Else
                        'update Terima Barang Header
                        Cmd.CommandText = "EXEC sp_Update_Trans_SPK_Hdr '" & txt_TransNo.Text & "','" & dt_SPKDate.Value & "'," & cboType.SelectedIndex & ",'" & _
                                           txt_ProjectNo.Text.Trim & "','" & txt_Remarks.Text.Trim & "','" & id_status.Trim & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        'update Terima Barang Detail
                        For Each item As DataRow In dt_item.Rows
                            If item.RowState = DataRowState.Added Then
                                Cmd.CommandText = "EXEC sp_Insert_Trans_SPK_Dtl '" & item("SPK_NO") + "','" & _
                                                  item("Teknisi_ID").ToString.Trim & "','" & item("Jasa_ID").ToString.Trim & "','" & item("Start_Dt") & "','" & _
                                                  item("TotalMinute") & "','" & item("remarks").ToString.Trim & "'"
                                Cmd.ExecuteNonQuery()

                            ElseIf item.RowState = DataRowState.Deleted Then
                                Cmd.CommandText = "EXEC sp_Delete_Trans_SPK_Dtl '" & txt_TransNo.Text + "','" & _
                                                   item("Teknisi_ID", DataRowVersion.Original).ToString & "'"
                                Cmd.ExecuteNonQuery()
                            Else
                                Cmd.CommandText = "EXEC sp_Update_Trans_SPK_Dtl '" & txt_TransNo.Text & "','" & item("Teknisi_ID") & "','" & _
                                                   item("Jasa_ID") & "','" & item("Start_dt") & "','" & item("TotalMinute") & "','" & item("remarks").ToString.Trim & "'"
                                Cmd.ExecuteNonQuery()
                            End If
                        Next

                        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                        UpdatetoInbox(txt_TransNo.Text, id_status, userlog.UserName, "1")
                    End If

                    InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", id_status) 'Insert to INBOX Purchasing

                    MessageBox.Show("Form SPK : " & txt_TransNo.Text.Trim & " has been saved and posted to " & Hirarki.SPK_Saved & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf id_status.Trim = Status.SPK_Saved Then
                    id_status = Status.SPK_Completed  'COMPLETE

                    'update Terima Barang Header
                    Cmd.CommandText = "EXEC sp_Update_Trans_SPK_Hdr '" & txt_TransNo.Text & "','" & dt_SPKDate.Value & "'," & cboType.SelectedIndex & ",'" & _
                                       txt_ProjectNo.Text.Trim & "','" & txt_Ket.Text.Trim & "','" & id_status & "','" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()
                    'update Terima Barang Detail
                    For Each item As DataRow In dt_item.Rows
                        If item.RowState = DataRowState.Added Then
                            Cmd.CommandText = "EXEC sp_Insert_Trans_SPK_Dtl '" & item("SPK_NO") + "','" & _
                                              item("Teknisi_ID").ToString.Trim & "','" & item("Jasa_ID").ToString.Trim & "','" & item("Start_Dt") & "','" & _
                                              item("TotalMinute") & "','" & item("remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()

                        ElseIf item.RowState = DataRowState.Deleted Then
                            Cmd.CommandText = "EXEC sp_Delete_Trans_SPK_Dtl '" & txt_TransNo.Text + "','" & _
                                               item("Teknisi_ID", DataRowVersion.Original).ToString & "'"
                            Cmd.ExecuteNonQuery()
                        Else
                            Cmd.CommandText = "EXEC sp_Update_Trans_SPK_Dtl '" & txt_TransNo.Text & "','" & item("Teknisi_ID") & "','" & _
                                               item("Jasa_ID") & "','" & item("Start_dt") & "','" & item("TotalMinute") & "','" & item("remarks").ToString.Trim & "'"
                            Cmd.ExecuteNonQuery()
                        End If
                    Next

                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, userlog.UserName, "1") 'Update Status utk Flow Teakhir
                    UpdatetoInbox(txt_TransNo.Text.Trim, id_status, GetDocCreator(txt_TransNo.Text.Trim), "") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                    MessageBox.Show("Form SPK : " & txt_TransNo.Text.Trim & " has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ObjTrans.Commit()
                Conn.Close()

                If Status_Trans = TransStatus.NewStatus Then 'jika form ini dipanggil dari View
                    Status_Trans = TransStatus.NoStatus
                    Me.Close()
                Else
                    Status_Trans = TransStatus.NoStatus
                    FrmSPK_Load(Nothing, Nothing)
                End If
            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "Proses"
    Private Sub Enable_Button_Wa(ByVal boo As Boolean)
        btn_insert.Enabled = boo
        btn_edit.Enabled = boo
        btn_save.Enabled = Not boo
        btn_delete.Enabled = boo
        Btn_cancel.Enabled = Not boo
    End Sub

    Private Sub SetGrid()
        With gv_SPK.Columns(0)
            .Width = 90
            .HeaderText = "Tech. ID"
        End With
        With gv_SPK.Columns(1)
            .Width = 180
            .HeaderText = "Technician Name"
        End With
        With gv_SPK.Columns(2)
            .Width = 50
            .HeaderText = "Process ID"
        End With
        With gv_SPK.Columns(3)
            .Width = 180
            .HeaderText = "Process Description"
        End With
        With gv_SPK.Columns(4)
            .Width = 90
            .HeaderText = "Begin Date"
            .DefaultCellStyle.Format = "dd-MMM-yyyy"
        End With
        With gv_SPK.Columns(5)
            .Width = 90
            .HeaderText = "Ttl Minute"
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .DefaultCellStyle.Format = "#,##0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With gv_SPK.Columns(6)
            .Width = 200
            .HeaderText = "Remarks"
        End With
    End Sub

    Private Sub Load_Grid()
        dt_item.Clear()
        Cmd.CommandText = "EXEC sp_Retreive_Trans_SPK_Dtl '" + txt_TransNo.Text + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        'gv_SPK.Enabled = dt_item.Rows.Count > 0
        gv_SPK.DataSource = dt_item
        SetGrid()
    End Sub

    Private Sub Load_SPK()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            'Pindahin dr datatable PO ke datatable TrmBrg   
            dt_ST.Clear()
            Cmd.CommandText = "EXEC sp_Retreive_trans_SPK_Hdr '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_ST)

            If dt_ST.Rows.Count > 0 Then
                With dt_ST.Rows(0)
                    dt_SPKDate.Value = .Item("SPK_Date")
                    txt_ProjectNo.Text = .Item("Project_No").ToString.Trim
                    txt_CustomerID.Text = .Item("Cust_ID").ToString.Trim
                    txt_CustomerName.Text = .Item("Nama").ToString.Trim
                    txt_PIC.Text = .Item("PIC").ToString.Trim
                    txt_Remarks.Text = .Item("remarks").ToString.Trim

                    Try
                        cboType.SelectedIndex = .Item("isOrder")
                    Catch ex As Exception
                        cboType.SelectedIndex = 0
                    End Try

                    id_status = .Item("Status_Id").ToString.Trim
                End With
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Working Area"
    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_TeknisiID.BackColor = Color.LightGray
            Txt_KdProses.BackColor = Color.LightGray
            dt_from.BackColor = Color.LightGray
            txtTotalMinute.BackColor = Color.LightGray
            txt_Ket.BackColor = Color.LightGray
        ElseIf proses = "UPDATE" Then
            txt_TeknisiID.BackColor = Color.LightGray
            Txt_KdProses.BackColor = Color.LightGoldenrodYellow
            dt_from.BackColor = Color.LightGoldenrodYellow
            txtTotalMinute.BackColor = Color.LightGoldenrodYellow
            txt_Ket.BackColor = Color.LightGoldenrodYellow
        ElseIf proses = "INSERT" Then
            txt_TeknisiID.BackColor = Color.LightGoldenrodYellow
            Txt_KdProses.BackColor = Color.LightGoldenrodYellow
            dt_from.BackColor = Color.LightGoldenrodYellow
            txtTotalMinute.BackColor = Color.LightGoldenrodYellow
            txt_Ket.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_TeknisiID.ReadOnly = Not boo
        Txt_KdProses.ReadOnly = Not boo
        dt_from.Enabled = boo
        txtTotalMinute.ReadOnly = Not boo
        txt_Ket.ReadOnly = Not boo
    End Sub

    Private Sub Clear_Wa()
        txt_TeknisiID.Clear()
        txt_TeknisiName.Clear()
        Txt_KdProses.Clear()
        txt_NamaProses.Clear()
        txt_Ket.Clear()
    End Sub



    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        Status_Proses = "Insert"

        Enable_Wa(True)
        Clear_Wa()
        Enable_Button_Wa(False)

        SetBackColor_Wa("INSERT")
        txt_TeknisiID.Focus()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_TeknisiID.Text = "" Then
            MessageBox.Show("Please choose 1 data to be edited.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        Enable_Button_Wa(False)

        txt_TeknisiID.BackColor = Color.LightGray
        Txt_KdProses.BackColor = Color.LightGray
        dt_from.Enabled = False
        txt_TeknisiID.ReadOnly = True 'karna primary Key
        Txt_KdProses.ReadOnly = True

        txtTotalMinute.Focus()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Status_Proses = String.Empty

        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        Enable_Button_Wa(True)
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Item_ID")
        dt_item.PrimaryKey = dc

        If txt_TeknisiID.Text.Trim = "" Then
            MessageBox.Show("Please choose 1 data to be deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_item.Rows.Find(txt_TeknisiID.Text)
            If da IsNot Nothing Then
                da.Delete()
                gv_SPK.Focus()
            End If
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(2) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_item.Columns("Teknisi_ID")
        dc(1) = dt_item.Columns("Jasa_ID")
        dc(2) = dt_item.Columns("Start_Dt")
        dt_item.PrimaryKey = dc
        Dim dtView As New DataView(dt_item)
        Dim SaveSuccess As Boolean = False

        ' Validation
        If txt_TeknisiID.Text.Trim = String.Empty Then
            MessageBox.Show("Technician ID must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Txt_KdProses.Text.Trim = String.Empty Then
            MessageBox.Show("Process ID must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            dtView.RowFilter = "Teknisi_ID = '" & txt_TeknisiID.Text.Trim & "' and Jasa_ID = '" & Txt_KdProses.Text.Trim & "'"
            If dtView.Count <> 0 Then
                Dim x As Integer
                Dim row As DataRow

                For x = 0 To dtView.Count - 1
                    row = dtView.Item(x).Row
                    If CDate(Format(row.Item("Start_dt"), "MM/dd/yyyy")) = CDate(Format(dt_from.Value, "MM/dd/yyyy")) Then
                        MessageBox.Show("This data has been existed. Please input another one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        txt_TeknisiID.Focus()
                        Exit Sub
                    End If
                Next

                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Teknisi_ID") = txt_TeknisiID.Text.Trim
                dr("Name") = txt_TeknisiName.Text.Trim
                dr("Jasa_ID") = Txt_KdProses.Text.Trim
                dr("Jasa_Name") = txt_NamaProses.Text.Trim
                dr("Start_Dt") = CDate(Format(dt_from.Value, "MM/dd/yyyy"))
                dr("TotalMinute") = CInt(txtTotalMinute.Text)
                dr("Remarks") = txt_Ket.Text.Trim
                dt_item.Rows.Add(dr)

                SaveSuccess = True
            Else
                Dim dr As DataRow
                dr = dt_item.NewRow
                dr("Teknisi_ID") = txt_TeknisiID.Text.Trim
                dr("Name") = txt_TeknisiName.Text.Trim
                dr("Jasa_ID") = Txt_KdProses.Text.Trim
                dr("Jasa_Name") = txt_NamaProses.Text.Trim
                dr("Start_Dt") = CDate(Format(dt_from.Value, "MM/dd/yyyy"))
                dr("TotalMinute") = CInt(txtTotalMinute.Text)
                dr("Remarks") = txt_Ket.Text.Trim
                dt_item.Rows.Add(dr)

                SaveSuccess = True
            End If
        ElseIf Status_Proses = "Update" Then
            dtView.RowFilter = "Teknisi_ID = '" & txt_TeknisiID.Text.Trim & "' and Jasa_ID = '" & Txt_KdProses.Text.Trim & "'"
            If dtView.Count <> 0 Then
                Dim x As Integer
                Dim row As DataRow
                Dim bl As Boolean = False

                For x = 0 To dtView.Count - 1
                    row = dtView.Item(x).Row
                    If CDate(Format(row.Item("Start_dt"), "MM/dd/yyyy")) = CDate(Format(dt_from.Value, "MM/dd/yyyy")) Then
                        bl = True
                        Exit For
                    End If
                Next

                If Not bl Then
                    MessageBox.Show("This data has not been existed in the list." & vbCrLf & "Please cancel this editing process, and to add this data, do the insert process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    txt_TeknisiID.Focus()
                    Exit Sub
                End If

                Dim i As Integer
                For i = 0 To dt_item.Rows.Count - 1
                    With dt_item.Rows(i)
                        If .Item("Teknisi_ID") = txt_TeknisiID.Text.Trim AndAlso .Item("Jasa_ID") = Txt_KdProses.Text.Trim AndAlso CDate(Format(.Item("Start_Dt"), "MM/dd/yyyy")) = CDate(Format(dt_from.Value, "MM/dd/yyyy")) Then
                            da = dt_item.Rows(i)
                            If da IsNot Nothing Then
                                da("TotalMinute") = CInt(txtTotalMinute.Text)
                                da("Remarks") = txt_Ket.Text.Trim
                            End If

                            SaveSuccess = True
                            Exit For
                        End If
                    End With
                Next
            Else
                MessageBox.Show("This data has not been existed in the list." & vbCrLf & "Please cancel this editing process, and to add this data, do the insert process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_TeknisiID.Focus()
                Exit Sub
            End If
        End If

        If SaveSuccess Then
            gv_SPK.DataSource = dt_item
            Status_Proses = String.Empty   'reset
            Btn_cancel_Click(Nothing, Nothing)
        Else
            MessageBox.Show("This data cannot be saved. Please recheck the details.", "Information", MessageBoxButtons.OK)
            txt_TeknisiID.Focus()
        End If
    End Sub

    Private Sub txt_TeknisiID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TeknisiID.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt_dtl.Clear()
                'query utk mendapat employee dibagian Project
                sql = "exec sp_Retrieve_Master_Employee_Technician_List"
                CallandGetSearchData(sql, "employee_id", "Name", "Department_Name", "phone", "email")
                If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                    txt_TeknisiID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_TeknisiName.Text = frmSearch.txtResult2.Text.ToString.Trim

                    Txt_KdProses.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
    End Sub

    Private Sub txt_TeknisiID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_TeknisiID.LostFocus
        If txt_TeknisiID.Text.Trim <> String.Empty Then
            Dim MD As New MasterData
            txt_TeknisiName.Text = MD.RetrieveTechnician_ByID(txt_TeknisiID.Text.Trim)
        End If
    End Sub

    Private Sub Txt_KdProses_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_KdProses.KeyDown
        Dim sql As String
        If e.KeyCode = Keys.F1 Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt_dtl.Clear()
                'query utk mendapat Jasa dibagian Project
                sql = "Select Jasa_ID,Jasa_Name from " & Chr(13) & _
                      "Master_Jasa " & Chr(13) & _
                      "where Active_Flag = 'Y'"
                CallandGetSearchData(sql, "Jasa_ID", "Jasa_Name", "", "", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    Txt_KdProses.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_NamaProses.Text = frmSearch.txtResult2.Text.ToString.Trim

                    dt_from.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            Finally
                If Conn.State = ConnectionState.Open Then Conn.Close()
            End Try
        End If
    End Sub

    Private Sub Txt_KdProses_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_KdProses.LostFocus
        If Status_Proses = "Insert" OrElse Status_Proses = "Update" Then
            Dim MD As New MasterData
            txt_NamaProses.Text = MD.RetrieveJasaName_ByID(Txt_KdProses.Text.Trim)
        End If
    End Sub

    Private Sub txt_Ket_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Ket.Leave
        btn_save.Focus()
    End Sub

    Private Sub ts_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Print.Click
        Dim frmChild As New frmReport
        Dim dtData As New DataTable
        Dim TD As New TransData

        If Status_Trans = TransStatus.NoStatus Then
            TD.RetrieveReportSPKForm(dtdata, txt_TransNo.Text.Trim)

            If dtData.Rows.Count <> 0 Then
                frmChild.ReportName = "SPK Form"
                frmChild.SPKNo = txt_TransNo.Text.Trim
                For Each f As Form In Me.MdiChildren
                    If f.Name = "frmReport" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Else
                MessageBox.Show("Nothing can be retrieved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
#End Region

    Private Sub txtTotalMinute_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalMinute.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub gv_spk_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_spk.MouseClick
        If Not (Status_Proses = "Update" OrElse Status_Proses = "Insert") Then
            If Not gv_spk Is Nothing Then
                With gv_spk.Rows(gv_spk.CurrentCell.RowIndex)
                    If String.IsNullOrEmpty(.Cells("Teknisi_ID").Value) = False Then
                        txt_TeknisiID.Text = .Cells("Teknisi_ID").Value.ToString.Trim
                        txt_TeknisiName.Text = .Cells("Name").Value.ToString.Trim
                        Txt_KdProses.Text = .Cells("Jasa_ID").Value.ToString.Trim
                        txt_NamaProses.Text = .Cells("Jasa_Name").Value.ToString.Trim
                        dt_from.Value = .Cells("Start_Dt").Value
                        txtTotalMinute.Text = .Cells("TotalMinute").Value
                        txt_Ket.Text = .Cells("Remarks").Value.ToString.Trim
                    End If
                End With
            End If
        End If
    End Sub
End Class