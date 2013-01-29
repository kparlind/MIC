Imports MIS.TransData
Imports MIS.MasterData
Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Public Class frmTransReturToko
    Dim TD As New TransData
    Dim MD As New MasterData
    Dim StatusTrans, StatusTransDtl As String
    Dim dtDetail As New DataTable
    Dim dtDetailOri As New DataTable

    Public LoadTransNo As String

    Private Sub frmTransReturToko_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If StatusTrans <> TransStatus.NoStatus Then
            MessageBox.Show("Please cancel this active process first before you close this form.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Dim frmChild As New frmTransReturToko_View

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmTransReturToko_View" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
    End Sub

    Private Sub frmTransReturToko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StatusTrans = TransStatus.NoStatus
        StatusTransDtl = TransStatus.NoStatus
        btnNew.Visible = False

        If LoadTransNo.ToString.Trim <> String.Empty Then
            InitHeader()
            InitDetail()

            SetColorHeader()
            SetColorDetail()
            SetHeaderButton()
            SetDetailButton()
            EnableInputDetail()
            EnableInputHeader()

            txtReturNo.Text = LoadTransNo
            LoadHeader()
        Else
            btnNew_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub EnableInputHeader()
        If StatusTrans = TransStatus.NoStatus Then
            dtpReturDate.Enabled = False
            cboType.Enabled = False

            txtPTNo.ReadOnly = True
            txtKeterangan.ReadOnly = True
        Else
            dtpReturDate.Enabled = True
            cboType.Enabled = True

            txtPTNo.ReadOnly = False
            txtKeterangan.ReadOnly = False
        End If
    End Sub

    Private Sub EnableInputDetail()
        If StatusTrans = TransStatus.NoStatus OrElse StatusTransDtl = TransStatus.NoStatus Then
            txtItemID.ReadOnly = True
            txtItemQty.ReadOnly = True
            txtItemReason.ReadOnly = True
        Else
            If StatusTransDtl = TransStatus.NewStatus Then
                txtItemID.ReadOnly = False
                txtItemQty.ReadOnly = False
                txtItemReason.ReadOnly = False
            ElseIf StatusTransDtl = TransStatus.EditStatus Then
                txtItemID.ReadOnly = True
                txtItemQty.ReadOnly = False
                txtItemReason.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub LoadHeader()
        Dim dtHdr As New DataTable

        TD.Retrieve_ReturToko_Hdr_ForLoad(dtHdr, txtReturNo.Text.Trim)
        If dtHdr.Rows.Count <> 0 Then
            With dtHdr.Rows(0)
                dtpReturDate.Value = .Item("ReturToko_Date")

                txtPTNo.Text = .Item("PT_No").ToString.Trim
                txtCust.Text = .Item(Fields.Cust_ID).ToString.Trim
                txtCustName.Text = .Item(Fields.Cust_Name).ToString.Trim
                txtKeterangan.Text = .Item("Remarks").ToString.Trim

                cboType.SelectedItem = .Item("Retur_Type").ToString.Trim

                LoadDetail()
            End With
        End If
    End Sub

    Private Sub LoadDetail()
        dtDetail = New DataTable

        TD.Retrieve_ReturToko_Dtl_ForGrid(dtDetail, txtReturNo.Text.Trim)
        gDetail.DataSource = dtDetail
        SetGrid()
        HitungTotalDetail()
    End Sub

    Private Sub SetDetailButton()
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans = TransStatus.NoStatus Then
                btnEditDtl.Enabled = False
                btnDeleteDtl.Enabled = False
                btnInsertDtl.Enabled = False
                btnSaveDtl.Enabled = False
                btnCancelDtl.Enabled = False
            Else
                If StatusTransDtl = TransStatus.NoStatus Then
                    btnEditDtl.Enabled = True
                    btnDeleteDtl.Enabled = True
                    btnInsertDtl.Enabled = True

                    btnSaveDtl.Enabled = False
                    btnCancelDtl.Enabled = False
                Else
                    btnEditDtl.Enabled = False
                    btnDeleteDtl.Enabled = False
                    btnInsertDtl.Enabled = False

                    btnSaveDtl.Enabled = True
                    btnCancelDtl.Enabled = True
                End If
            End If
        Else
            btnEditDtl.Enabled = False
            btnDeleteDtl.Enabled = False
            btnInsertDtl.Enabled = False
            btnSaveDtl.Enabled = False
            btnCancelDtl.Enabled = False
        End If
    End Sub

    Private Sub SetHeaderButton()
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans = TransStatus.NoStatus Then
                btnNew.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True

                btnSave.Enabled = False
                btnCancel.Enabled = False
            Else
                btnNew.Enabled = False
                btnEdit.Enabled = False
                btnDelete.Enabled = False

                btnSave.Enabled = True
                btnCancel.Enabled = True
            End If
        Else
            btnNew.Enabled = False
            btnEdit.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub SetGrid()
        gDetail.Columns(0).Width = 60
        gDetail.Columns(0).HeaderText = "Item ID"

        gDetail.Columns(1).Width = 180
        gDetail.Columns(1).HeaderText = "Item Name"
        gDetail.Columns(1).Frozen = True

        gDetail.Columns(2).Width = 50
        gDetail.Columns(2).HeaderText = "UOM"

        gDetail.Columns(3).Width = 100
        gDetail.Columns(3).HeaderText = "Kemasan"


        gDetail.Columns(4).Width = 70
        gDetail.Columns(4).HeaderText = "Qty"
        gDetail.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(4).DefaultCellStyle.Format = "#,##0"

        gDetail.Columns(5).Width = 110
        gDetail.Columns(5).HeaderText = "Unit Price"
        gDetail.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(5).DefaultCellStyle.Format = "#,##0.#0"

        gDetail.Columns(6).Width = 110
        gDetail.Columns(6).HeaderText = "Amount"
        gDetail.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gDetail.Columns(6).DefaultCellStyle.Format = "#,##0.#0"

        gDetail.Columns(7).Width = 200
        gDetail.Columns(7).HeaderText = "Reason"
    End Sub

    Private Sub InitHeader()
        txtReturNo.Text = String.Empty
        txtCust.Text = String.Empty
        txtCustName.Text = String.Empty
        txtPTNo.Text = String.Empty
        txtKeterangan.Text = String.Empty
        txtTotalRetur.Text = FormatAngka(0)

        dtpReturDate.Value = Format(Now, "MM/dd/yyyy")
        'cboType.SelectedIndex = 0

        gDetail.DataSource = Nothing
    End Sub

    Private Sub InitDetail()
        txtItemID.Text = String.Empty
        txtItemName.Text = String.Empty
        txtItemKemasan.Text = String.Empty
        txtItemUOM.Text = String.Empty
        txtItemReason.Text = String.Empty

        txtItemQty.Text = FormatAngka(0, 0)
        txtItemUnitPrice.Text = FormatAngka(0)
        txtItemAmount.Text = FormatAngka(0)
    End Sub

    Private Sub InitGrid()
        dtDetail = New DataTable

        dtDetail.Columns.Clear()
        dtDetail.Columns.Add("Item_ID", System.Type.GetType(DataType.TypeString))
        dtDetail.Columns.Add("Item_Name", System.Type.GetType(DataType.TypeString))
        dtDetail.Columns.Add("Size", System.Type.GetType(DataType.TypeString))
        dtDetail.Columns.Add("UOM", System.Type.GetType(DataType.TypeString))
        dtDetail.Columns.Add("Qty", System.Type.GetType(DataType.TypeDecimal))
        dtDetail.Columns.Add("UnitPrice", System.Type.GetType(DataType.TypeDecimal))
        dtDetail.Columns.Add("SubTotal", System.Type.GetType(DataType.TypeDecimal))
        dtDetail.Columns.Add("Remarks", System.Type.GetType(DataType.TypeString))
    End Sub

    Private Sub SetColorHeader()
        If StatusTrans = TransStatus.NoStatus Then
            txtPTNo.BackColor = Color.LightGray
            txtKeterangan.BackColor = Color.LightGray
        Else
            txtPTNo.BackColor = Color.LightGoldenrodYellow
            txtKeterangan.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub SetColorDetail()
        If StatusTransDtl = TransStatus.NoStatus Then
            txtItemID.BackColor = Color.LightGray
            txtItemQty.BackColor = Color.LightGray
            txtItemReason.BackColor = Color.LightGray
        ElseIf StatusTransDtl = TransStatus.NewStatus Then
            txtItemID.BackColor = Color.LightGoldenrodYellow
            txtItemQty.BackColor = Color.LightGoldenrodYellow
            txtItemReason.BackColor = Color.LightGoldenrodYellow
        ElseIf StatusTransDtl = TransStatus.EditStatus Then
            txtItemQty.BackColor = Color.LightGoldenrodYellow
            txtItemReason.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans = TransStatus.NoStatus Then
                StatusTrans = TransStatus.NewStatus
                InitHeader()
                SetColorHeader()
                InitDetail()
                InitGrid()
                SetDetailButton()
                SetHeaderButton()
                EnableInputHeader()
                EnableInputDetail()

                dtpReturDate.Focus()
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans = TransStatus.NoStatus Then
                StatusTrans = TransStatus.EditStatus
                dtDetailOri = dtDetail

                SetColorHeader()
                SetDetailButton()
                SetHeaderButton()
                EnableInputHeader()
                EnableInputDetail()

                dtpReturDate.Focus()
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnInsertDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsertDtl.Click
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans <> TransStatus.NoStatus AndAlso StatusTransDtl = TransStatus.NoStatus Then
                StatusTransDtl = TransStatus.NewStatus

                InitDetail()
                SetColorDetail()
                SetDetailButton()
                EnableInputDetail()

                txtItemID.Focus()
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnEditDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditDtl.Click
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans <> TransStatus.NoStatus AndAlso StatusTransDtl = TransStatus.NoStatus Then
                If txtItemID.Text.Trim <> String.Empty Then
                    StatusTransDtl = TransStatus.EditStatus

                    SetColorDetail()
                    SetDetailButton()
                    EnableInputDetail()

                    txtItemQty.Focus()
                Else
                    MessageBox.Show("Please choose one detail to be processed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub txtItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemID.KeyDown
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If e.KeyCode = Keys.F1 Then
                If StatusTrans <> TransStatus.NoStatus Then
                    Call frmSearch.InitFindData(":: Find Item ::", "exec sp_Retrieve_Master_Item_ForSearchReturToko '" & txtPTNo.Text.Trim & "'")
                    Call frmSearch.AddFindColumn(1, "Item_ID", "Item#", DataType.TypeString, 80)
                    Call frmSearch.AddFindColumn(2, "Item_Name", "Item Name", DataType.TypeString, 200)
                    Call frmSearch.AddFindColumn(3, "UOM", "UOM", DataType.TypeString, 60)
                    Call frmSearch.AddFindColumn(4, "Item_Size", "Kemasan", DataType.TypeString, 100)
                    Call frmSearch.AddFindColumn(5, "Price2", "Unit Price", DataType.TypeDecimal, 150)
                    frmSearch.ShowDialog()

                    If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                        txtItemID.Text = frmSearch.txtResult1.Text.Trim
                        txtItemName.Text = frmSearch.txtResult2.Text.Trim
                        txtItemUOM.Text = frmSearch.txtResult3.Text.Trim
                        txtItemKemasan.Text = frmSearch.txtResult4.Text.Trim
                        txtItemUnitPrice.Text = FormatAngka(CDbl(frmSearch.txtResult5.Text.Trim))
                        txtItemQty.Focus()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub txtItemQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemQty.LostFocus
        If StatusTransDtl <> TransStatus.NoStatus Then
            If txtItemQty.Text.Trim = String.Empty Then
                txtItemQty.Text = FormatAngka(0, 0)
            End If

            txtItemAmount.Text = FormatAngka(CDbl(txtItemQty.Text) * CDbl(txtItemUnitPrice.Text))
        End If
    End Sub

    Private Sub btnCancelDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelDtl.Click
        If StatusTransDtl <> TransStatus.NoStatus Then
            StatusTransDtl = TransStatus.NoStatus

            InitDetail()
            SetColorDetail()
            SetDetailButton()
            EnableInputDetail()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If StatusTrans = TransStatus.NewStatus Then
            StatusTrans = TransStatus.NoStatus
            Me.Close()
        Else
            StatusTrans = TransStatus.NoStatus
            frmTransReturToko_Load(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPTNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPTNo.KeyDown
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If e.KeyCode = Keys.F1 Then
                If StatusTrans <> TransStatus.NoStatus Then
                    Call frmSearch.InitFindData(":: Find Invoice ::", "exec sp_Retrieve_Trans_PenjualanToko_Hdr_ForSearch")
                    Call frmSearch.AddFindColumn(1, "PT_No", "Invoice#", DataType.TypeString, 100)
                    Call frmSearch.AddFindColumn(2, "PT_Date", "Invoice Date", DataType.TypeDateTime, 100)
                    Call frmSearch.AddFindColumn(3, "Cust_ID", "Cust#", DataType.TypeString, 60)
                    Call frmSearch.AddFindColumn(4, "Nama", "Customer Name", DataType.TypeString, 200)
                    frmSearch.ShowDialog()

                    If frmSearch.txtResult1.Text.ToString.Trim <> String.Empty Then
                        txtPTNo.Text = frmSearch.txtResult1.Text.Trim
                        txtCust.Text = frmSearch.txtResult3.Text.Trim
                        txtCustName.Text = frmSearch.txtResult4.Text.Trim
                        cboType.Focus()
                    End If
                End If
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDeleteDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteDtl.Click
        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If StatusTrans <> TransStatus.NoStatus AndAlso StatusTransDtl = TransStatus.NoStatus Then
                If txtItemID.Text.Trim <> String.Empty Then
                    Dim dc(0) As DataColumn
                    Dim i As Integer
                    Dim dtView As New DataView(dtDetail)

                    dc(0) = dtDetail.Columns(Fields.Item_ID)
                    dtDetail.PrimaryKey = dc

                    ' Validation
                    dtView.RowFilter = "Item_ID = '" & txtItemID.Text.Trim & "'"
                    If dtView.Count <> 0 Then
                        For i = 0 To dtDetail.Rows.Count - 1
                            If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                                If dtDetail.Rows(i).Item(Fields.Item_ID).ToString.Trim = txtItemID.Text.Trim Then
                                    dtDetail.Rows(i).Delete()
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If
                Else
                    MessageBox.Show("Please choose one detail to be processed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("Unauthorized user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnSaveDtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveDtl.Click
        Dim dc(0) As DataColumn
        Dim i As Integer
        Dim dtView As New DataView(dtDetail)
        Dim dr As DataRow

        dc(0) = dtDetail.Columns(Fields.Item_ID)
        dtDetail.PrimaryKey = dc

        ' Validation
        dtView.RowFilter = "Item_ID = '" & txtItemID.Text.Trim & "'"
        If StatusTransDtl = TransStatus.NewStatus Then
            If dtView.Count = 0 Then
                dr = dtDetail.NewRow
                With dr
                    .Item(Fields.Item_ID) = txtItemID.Text.Trim
                    .Item(Fields.Item_Name) = txtItemName.Text.Trim
                    .Item(Fields.Item_UOM) = txtItemUOM.Text.Trim
                    .Item(Fields.Item_Size) = txtItemKemasan.Text.Trim
                    .Item(Fields.Qty) = CDbl(txtItemQty.Text.Trim)
                    .Item("UnitPrice") = CDbl(txtItemUnitPrice.Text.Trim)
                    .Item("SubTotal") = CDbl(txtItemAmount.Text.Trim)
                    .Item("Remarks") = txtItemReason.Text.Trim
                End With
                dtDetail.Rows.Add(dr)
            Else
                MessageBox.Show("Item id '" & txtItemID.Text.Trim & "' has been existed in list.", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If
        ElseIf StatusTransDtl = TransStatus.EditStatus Then
            If dtView.Count <> 0 Then
                For i = 0 To dtDetail.Rows.Count - 1
                    If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                        If dtDetail.Rows(i).Item(Fields.Item_ID).ToString.Trim = txtItemID.Text.Trim Then
                            dr = dtDetail.Rows(i)
                            dr(Fields.Qty) = CDbl(txtItemQty.Text.Trim)
                            dr("SubTotal") = CDbl(txtItemAmount.Text.Trim)
                            dr("Remarks") = txtItemReason.Text.Trim
                            Exit For
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Cannot find item id '" & txtItemID.Text.Trim & "'", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If
        End If

        gDetail.DataSource = dtDetail
        SetGrid()
        HitungTotalDetail()
        btnCancelDtl_Click(Nothing, Nothing)
    End Sub

    Private Sub HitungTotalDetail()
        Dim i As Integer
        Dim Total As Double

        Total = 0
        For i = 0 To dtDetail.Rows.Count - 1
            With dtDetail.Rows(i)
                Total += (.Item("SubTotal"))
            End With
        Next
        txtTotalRetur.Text = FormatAngka(Total, 2)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If StatusTrans = TransStatus.NoStatus AndAlso txtReturNo.Text.Trim <> String.Empty AndAlso (userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin) Then
            If MessageBox.Show("Are you sure to delete Retur Toko# " & txtReturNo.Text.Trim & " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If DeleteRetur() Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Unauthorized process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Function DeleteRetur() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim Trans As SqlTransaction
        Dim JournalID As String = String.Empty

        DeleteRetur = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()
        Trans = Conn.BeginTransaction

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Trans

            TD.RetrieveJournalID_ByTransNo(JournalID, txtReturNo.Text.Trim)

            If JournalID.Trim <> String.Empty Then
                'Delete Journal Retur
                Cmd.CommandText = "exec sp_Delete_JournalItem_ByJournalID '" & JournalID & "'"
                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "exec sp_Delete_Journal '" & JournalID & "'"
                Cmd.ExecuteNonQuery()
            End If

            'Delete Retur
            Cmd.CommandText = "exec sp_Delete_Trans_ReturToko_Hdr '" & txtReturNo.Text.Trim & "', '" & userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            Trans.Commit()
            DeleteRetur = True
        Catch ex As Exception
            Trans.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function CekSaveOK() As Boolean
        Dim i As Integer = 0
        Dim x As Integer
        Dim str As String = String.Empty
        Dim dtTemp As New DataTable
        Dim Sisa As Double

        CekSaveOK = False

        'Cek apakah invoice exists
        TD.Retrieve_PenjualanToko_ByID(dtTemp, txtPTNo.Text.Trim)
        If dtTemp.Rows.Count = 0 Then
            i += 1
            str &= i.ToString & ") Invoice# " & txtPTNo.Text.Trim & " cannot be found in database." & vbCrLf
        End If

        'Cek apakah jumlah qty yang diretur masih <= qty dari invoice
        If dtDetail.Rows.Count <> 0 Then
            For x = 0 To dtDetail.Rows.Count - 1
                With dtDetail.Rows(i)
                    If dtDetail.Rows(i).RowState <> DataRowState.Deleted Then
                        dtTemp = New DataTable
                        TD.Retrieve_SisaQty_ForReturToko(dtTemp, txtReturNo.Text.Trim, .Item(Fields.Item_ID).ToString.Trim)
                        If dtTemp.Rows.Count <> 0 Then
                            Sisa = CDbl(dtTemp.Rows(0).Item("QtyInvoice")) - CDbl(dtTemp.Rows(0).Item("QtyRetur"))
                            If Sisa - CDbl(.Item(Fields.Qty).ToString.Trim) < 0 Then
                                i += 1
                                str &= i.ToString & ") Item# " & .Item(Fields.Item_ID).ToString.Trim & " only has " & Sisa & " left [ requested for this transaction is " & CDbl(.Item(Fields.Qty).ToString.Trim) & " ]." & vbCrLf
                            End If
                        Else
                            i += 1
                            str &= i.ToString & ") Item# " & .Item(Fields.Item_ID).ToString.Trim & " cannot be found in detail Invoice# " & txtPTNo.Text.Trim & "." & vbCrLf
                        End If
                    End If
                End With
            Next
        End If

        If i = 0 Then
            CekSaveOK = True
        Else
            MessageBox.Show("Please check these errors below." & vbCrLf & str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim Trans As SqlTransaction
        Dim NewNumber As String = String.Empty
        Dim LastSerial As Integer
        Dim query As String = String.Empty
        Dim queryParam As String = String.Empty
        Dim TransNo, RemarkJurnal As String
        Dim dtGrp, dtMAP As New DataTable
        Dim remarks_stok, JournalID As String
        Dim rowOriginal As DataRow
        Dim i, j As Integer
        Dim dc(0) As DataColumn

        dc(0) = dtDetailOri.Columns(Fields.Item_ID)
        dtDetailOri.PrimaryKey = dc

        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            If CekSaveOK Then
                JournalID = String.Empty

                Conn.ConnectionString = ConnectStr
                Conn.Open()
                Trans = Conn.BeginTransaction

                Try
                    Cmd.Connection = Conn
                    Cmd.CommandType = CommandType.Text
                    Cmd.Transaction = Trans

                    If StatusTrans = TransStatus.NewStatus Then
                        NewNumber = Generate_TranNo(Me.Name)
                        LastSerial = CInt(NewNumber.Substring(NewNumber.Length - 3, 3))

                        query = "exec sp_Insert_Trans_ReturToko_Hdr "
                        queryParam = "'" & NewNumber & "', '" & dtpReturDate.Value & "', '" & txtPTNo.Text.Trim & "', " & _
                                     "'" & cboType.SelectedItem.ToString.Trim & "','" & txtKeterangan.Text.Trim & "','" & userlog.UserName & "'"
                        query &= queryParam & " "
                        Cmd.CommandText = query
                        Cmd.ExecuteNonQuery()


                        remarks_stok = "Transaction : " & txtReturNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & " - [ Item has been INSERTED ] "
                        For Each item As DataRow In dtDetail.Rows
                            'Khusus new transaction, added dan modified diinsert ke table marketing
                            If item.RowState <> DataRowState.Deleted Then
                                Cmd.CommandText = "EXEC sp_Insert_Trans_ReturToko_Dtl '" & NewNumber & "','" & item(Fields.Item_ID).ToString.Trim & "', " & CDbl(FormatAngka(CDbl(item(Fields.Qty)), 0)) & ", " & _
                                                  CDbl(FormatAngka(CDbl(item("SubTotal")))) & ", '" & item("Remarks").ToString.Trim & "', '" & userlog.UserName & "' "
                                Cmd.ExecuteNonQuery()

                                Insert_StokMovement_Toko(Cmd, item(Fields.Item_ID), txtReturNo.Text.Trim, "IN", item("Qty"), remarks_stok)
                            End If
                        Next

                        UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)


                        'Create Journal
                        MD.RetrieveGroupMappingJournal_ByForm(dtGrp, Me.Name)
                        If dtGrp.Rows.Count <> 0 Then
                            For i = 0 To dtGrp.Rows.Count - 1
                                MD.RetrieveAccountMappingJournal(dtMAP, dtGrp.Rows(i).Item("Form_Name").ToString.Trim)

                                Select Case dtGrp.Rows(i).Item("Form_Name").ToString.Trim
                                    Case "Retur Toko"
                                        TransNo = Generate_TranNo("Journal")
                                        LastSerial = CInt(TransNo.Substring(TransNo.Length - 3, 3))
                                        RemarkJurnal = "Jurnal Retur Toko #" & NewNumber & "."

                                        TD.SaveJurnalHeader(Cmd, TransNo, "Pakai Bahan", RemarkJurnal, NewNumber)
                                        For j = 0 To dtMAP.Rows.Count - 1
                                            With dtMAP.Rows(i)
                                                TD.SaveJurnalDetail(Cmd, TransNo, IIf(CDbl(txtTotalRetur.Text.Trim) < 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), .Item("Account_ID").ToString.Trim, Abs(CDbl(txtTotalRetur.Text.Trim)))
                                            End With
                                        Next

                                        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                                End Select
                            Next
                        End If

                        Insert_Trans_History(txtReturNo.Text.Trim, Me.Name, Status.HISTORY_Insert) 'Insert History transaction
                    ElseIf StatusTrans = TransStatus.EditStatus Then
                        query = "exec sp_Update_Trans_ReturToko_Hdr "
                        queryParam = "'" & txtReturNo.Text.Trim & "', '" & dtpReturDate.Value & "', '" & txtPTNo.Text.Trim & "', " & _
                                     "'" & cboType.SelectedItem.ToString.Trim & "','" & txtKeterangan.Text.Trim & "','" & userlog.UserName & "'"
                        query &= queryParam
                        Cmd.CommandText = query
                        Cmd.ExecuteNonQuery()

                        For Each item As DataRow In dtDetail.Rows
                            'Khusus new transaction, added dan modified diinsert ke table marketing
                            If item.RowState = DataRowState.Added OrElse item.RowState = DataRowState.Modified OrElse item.RowState = DataRowState.Unchanged Then
                                If item.RowState = DataRowState.Added Then
                                    Cmd.CommandText = "EXEC sp_Insert_Trans_ReturToko_Dtl '" & txtReturNo.Text.Trim & "','" & item(Fields.Item_ID).ToString.Trim & "', " & CDbl(FormatAngka(CDbl(item(Fields.Qty)), 0)) & ", " & _
                                                      CDbl(FormatAngka(CDbl(item("SubTotal")))) & ", '" & item("Remarks").ToString.Trim & "', '" & userlog.UserName & "' "
                                    Cmd.ExecuteNonQuery()

                                    Insert_StokMovement_Toko(Cmd, item(Fields.Item_ID), txtReturNo.Text.Trim, "IN", item("Qty"), remarks_stok)

                                Else
                                    Cmd.CommandText = "EXEC sp_Update_Trans_ReturToko_Dtl '" & txtReturNo.Text.Trim & "','" & item(Fields.Item_ID).ToString.Trim & "', " & CDbl(FormatAngka(CDbl(item(Fields.Qty)), 0)) & ", " & _
                                                      CDbl(FormatAngka(CDbl(item("SubTotal")))) & ", '" & item("Remarks").ToString.Trim & "', '" & userlog.UserName & "' "
                                    Cmd.ExecuteNonQuery()

                                    rowOriginal = dtDetailOri.Rows.Find(item(Fields.Item_ID))
                                    If rowOriginal IsNot Nothing Then
                                        'Case Item sudah pernah di-insert lalu di-revisi
                                        If rowOriginal("Qty") <> item("Qty") Then
                                            remarks_stok = "Transaction : " & txtReturNo.Text.Trim & _
                                                           " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                                           " - [ QTY Item has been UPDATED from " & CStr(rowOriginal("Qty")) & " to " & CStr(item("Qty")) & " ]"
                                            Insert_StokMovement_Toko(Cmd, item(Fields.Item_ID), txtReturNo.Text.Trim, "IN", item("Qty"), remarks_stok)
                                            Insert_StokMovement_Toko(Cmd, rowOriginal(Fields.Item_ID), txtReturNo.Text.Trim, "OUT", rowOriginal("Qty"), remarks_stok)
                                        End If
                                    Else
                                        'Case Item belum pernah di-insert
                                        remarks_stok = "Transaction : " & txtReturNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                                       " - [ Item has been INSERTED ] "
                                        Insert_StokMovement_Toko(Cmd, item(Fields.Item_ID), txtReturNo.Text.Trim, "IN", item("Qty"), remarks_stok)
                                    End If
                                End If
                            ElseIf item.RowState = DataRowState.Deleted Then
                                Cmd.CommandText = "EXEC sp_Delete_Trans_ReturToko_Dtl '" & txtReturNo.Text.Trim & "','" & item(Fields.Item_ID, DataRowVersion.Original).ToString.Trim & "'"
                                Cmd.ExecuteNonQuery()

                                rowOriginal = dtDetailOri.Rows.Find(item(Fields.Item_ID, DataRowVersion.Original))
                                'Case Item sudah pernah di-insert lalu di-delete
                                If rowOriginal IsNot Nothing Then
                                    remarks_stok = "Transaction : " & txtReturNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                                   " - [ Item has been DELETED ] "
                                    Insert_StokMovement_Toko(Cmd, rowOriginal(Fields.Item_ID), txtReturNo.Text.Trim, "OUT", rowOriginal("Qty"), remarks_stok)
                                End If
                            End If
                        Next

                        'Update Journal
                        MD.RetrieveGroupMappingJournal_ByForm(dtGrp, Me.Name)
                        If dtGrp.Rows.Count <> 0 Then
                            For i = 0 To dtGrp.Rows.Count - 1
                                MD.RetrieveAccountMappingJournal(dtMAP, dtGrp.Rows(i).Item("Form_Name").ToString.Trim)

                                Select Case dtGrp.Rows(i).Item("Form_Name").ToString.Trim
                                    Case "Retur Toko"
                                        For j = 0 To dtMAP.Rows.Count - 1
                                            With dtMAP.Rows(i)
                                                TD.UpdateJurnalDetail(Cmd, txtReturNo.Text.Trim, .Item("Account_ID").ToString.Trim, IIf(CDbl(txtTotalRetur.Text.Trim) < 0, IIf(.Item("sisiGL").ToString.Trim = "CR", "DR", "CR"), .Item("sisiGL").ToString.Trim), Abs(CDbl(txtTotalRetur.Text.Trim)))
                                            End With
                                        Next
                                End Select
                            Next
                        End If

                        Insert_Trans_History(txtReturNo.Text.Trim, Me.Name, Status.HISTORY_Update) 'Insert History transaction
                    End If

                    Trans.Commit()

                    MessageBox.Show("This transaction has been saved." & vbCrLf & "(Transaction No. '" & IIf(StatusTrans = TransStatus.NewStatus, NewNumber, txtReturNo.Text.Trim) & "')", "Information", MessageBoxButtons.OK)
                    btnCancel_Click(Nothing, Nothing)
                Catch ex As Exception
                    Trans.Rollback()
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK)
                Finally
                    If Conn.State = ConnectionState.Open Then Conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Insert_StokMovement_Toko(ByRef cmd As SqlCommand, ByVal ItemId As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim DA As New SqlDataAdapter
        Dim maxSeq As Integer

        cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from Trans_Stock_Movement_toko where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = cmd
        DA.Fill(dt)

        maxSeq = dt.Rows(0).Item("MaxSeq")
        maxSeq += 1

        cmd.CommandText = "EXEC sp_Insert_StokMovement_Toko '" & _
                            Generate_Period() & "', '" & _
                            ItemId & "', '" & _
                            TransNo_Ref & "', '" & _
                            maxSeq & "', '" & _
                            Sts_Proses & "', '" & _
                            Qty & "','" & _
                            Remarks & "', '" & _
                            userlog.UserName & "'"
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub gDetail_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gDetail.MouseClick
        If StatusTransDtl = TransStatus.NoStatus Then
            If Not gDetail Is Nothing Then
                With gDetail.Rows(gDetail.CurrentCell.RowIndex)
                    If String.IsNullOrEmpty(.Cells(GlobalVar.Fields.Item_ID).Value) = False Then
                        txtItemID.Text = .Cells(GlobalVar.Fields.Item_ID).Value.ToString.Trim
                        txtItemName.Text = .Cells(GlobalVar.Fields.Item_Name).Value.ToString.Trim
                        txtItemUOM.Text = .Cells(GlobalVar.Fields.Item_UOM).Value.ToString.Trim
                        txtItemKemasan.Text = .Cells(GlobalVar.Fields.Item_Size).Value.ToString.Trim
                        txtItemQty.Text = FormatAngka(CDbl(.Cells(GlobalVar.Fields.Qty).Value.ToString.Trim), 0)
                        txtItemUnitPrice.Text = FormatAngka(CDbl(.Cells("UnitPrice").Value.ToString.Trim), 2)
                        txtItemAmount.Text = FormatAngka(CDbl(.Cells("SubTotal").Value.ToString.Trim), 2)
                        txtItemReason.Text = .Cells("Remarks").Value.ToString.Trim
                    End If
                End With
            End If
        End If
    End Sub
End Class