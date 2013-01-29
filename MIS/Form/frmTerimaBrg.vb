Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Math
Imports System.Data.SqlClient

Public Class frmTerimaBrg

#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter


    Public CallerForm As String
    Public StatusTrans As String
    Private StatusTransDetail As String
    Private dtDetail As New DataTable
    Private dtHeader As New DataTable
    Private dtItem As New DataTable '--> digunakan untuk pencarian data Item 
    Private StatusID As String
    Private frmReason As New Frm_Reason
    Private RejectReason As String = ""
    Public ViewFormName As String

#End Region

#Region "Function & Procedure - Main"

    Private Function Validation() As Boolean
        Validation = True

        'NOTE: Validasi Detail PO
        If gv_PODtl.Rows.Count = 0 Then
            MsgBox("Detail PO haven't filled. Process cancelled", MsgBoxStyle.Information, "Information")
            Validation = False
            Exit Function
        End If

        If txt_SubTotal.Text.Trim = "" Then
            MsgBox("Detail PO haven't filled. Process cancelled")
            Validation = False
            Exit Function
        End If

        If txt_SJalan.Text.Trim = "" And txt_SJalan.Visible = True Then
            MsgBox("Please fill Surat Jalan", MsgBoxStyle.Information, "Information")
            txt_SJalan.Focus()
            Validation = False
            Exit Function
        End If

        If txt_Invoice.Text.Trim = "" And txt_Invoice.Visible = True Then
            MsgBox("Please fill Invoice", MsgBoxStyle.Information, "Information")
            txt_Invoice.Focus()
            Validation = False
            Exit Function
        End If
    End Function

    Private Sub ClearInput()
        'NOTE: Clear HEADER Area
        txt_PONo.Clear()
        txt_Remark.Clear()
        txt_PPN.Clear()
        txt_SupplierID.Clear()
        txt_SupplierName.Clear()
        txt_TotalQty.Clear()
        txt_pengiriman.Clear()
        txt_UangMuka.Clear()
        txt_SJalan.Clear()
        txt_Invoice.Clear()
        txt_SubTotal.Clear()
        txt_TotalQtyRec.Clear()
        gv_PODtl.DataSource = ""
    End Sub

    Private Sub CountGrandTotal()
        'NOTE: Grand Total Calculation
        Dim GT, ST, PN, KRM As Integer

        GT = ST = PN = KRM = 0
        If txt_SubTotal.Text.Trim <> "" Then
            ST = CInt(txt_SubTotal.Text)
        End If
        If txt_PPN.Text.Trim <> "" Then
            PN = (CInt(txt_PPN.Text) * ST) / 100
        End If
        If txt_pengiriman.Text.Trim <> "" Then
            KRM = CInt(txt_pengiriman.Text)
        End If
        GT = ST + PN + KRM
        txt_GrandTotal.Text = FormatAngka(CDbl(CStr(GT)))
    End Sub

    Private Sub CountQty()
        'NOTE: Qty & Qty Receipt Calculation
        Dim qty As Integer = 0
        Dim qtyRec As Integer = 0

        For i As Integer = 0 To gv_PODtl.Rows.Count - 1
            qty += gv_PODtl.Rows(i).Cells("Qty Order").Value
            qtyRec += gv_PODtl.Rows(i).Cells("Qty Receipt").Value
        Next

        txt_TotalQty.Text = CStr(qty)
        txt_TotalQtyRec.Text = CStr(qtyRec)
    End Sub

    Private Sub CountSubTotal()
        'NOTE: Sub Total Calculation
        Dim count As Double
        For i As Integer = 0 To gv_PODtl.Rows.Count - 1
            count += gv_PODtl.Rows(i).Cells(GlobalVar.Fields.SubTotal).Value
        Next
        txt_SubTotal.Text = FormatAngka(CDbl(CStr(count)))

        CountGrandTotal()
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        txt_pengiriman.ReadOnly = True
        txt_pengiriman.ForeColor = Color.Gray
        txt_pengiriman.BackColor = Color.LightGray
        dt_PayType.Enabled = False

        Select Case StatusTrans
            Case TransStatus.NewStatus
                txt_PONo.ReadOnly = False
                txt_PONo.ForeColor = Color.Black
                txt_PONo.BackColor = Color.White
            Case Else
                txt_PONo.ReadOnly = True
                txt_PONo.ForeColor = Color.Gray
                txt_PONo.BackColor = Color.LightGray
        End Select

        Select Case boo
            Case True
                cb_Gudang.Enabled = True
                txt_Remark.ReadOnly = False
                txt_SJalan.ReadOnly = False
                txt_Invoice.ReadOnly = False

                txt_Remark.ForeColor = Color.Black
                txt_Remark.BackColor = Color.White
                txt_SJalan.ForeColor = Color.Black
                txt_SJalan.BackColor = Color.White
                txt_Invoice.ForeColor = Color.Black
                txt_Invoice.BackColor = Color.White
            Case False
                cb_Gudang.Enabled = False
                txt_Remark.ReadOnly = True
                txt_SJalan.ReadOnly = True
                txt_Invoice.ReadOnly = True

                txt_Remark.ForeColor = Color.Gray
                txt_Remark.BackColor = Color.LightGray
                txt_SJalan.ForeColor = Color.Gray
                txt_SJalan.BackColor = Color.LightGray
                txt_Invoice.ForeColor = Color.Gray
                txt_Invoice.BackColor = Color.LightGray
        End Select

        If CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName) = False Then Exit Sub
        Select Case userlog.Insert_Price
            Case "Y"
                dt_PayType.Enabled = True
                txt_pengiriman.ReadOnly = False
                txt_pengiriman.ForeColor = Color.Black
                txt_pengiriman.BackColor = Color.White
            Case Else
                txt_pengiriman.Enabled = False
                dt_PayType.Enabled = False
                txt_pengiriman.ReadOnly = True
                txt_pengiriman.ForeColor = Color.Gray
                txt_pengiriman.BackColor = Color.LightGray
        End Select
    End Sub

    Private Sub VisibleSupplier(ByVal Boo As Boolean)
        'NOTE: Hanya orang2 tertentu yang bisa melihat area ini
        lbl_Supplier.Visible = Boo
        lbl_SuppName.Visible = Boo
        lbl_SJalan.Visible = Boo
        lbl_Invoice.Visible = Boo
        txt_SupplierID.Visible = Boo
        txt_SupplierName.Visible = Boo
        txt_SJalan.Visible = Boo
        txt_Invoice.Visible = Boo
    End Sub

    Private Sub GetItemData(ByVal ItemId As String)
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            Cmd.CommandText = "EXEC sp_Retreive_Item_byItemID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtItem)

        Catch ex As Exception
            MsgBox("GetItemData: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub GetWarehouse()
        Dim dtTable As New DataTable
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_retreive_Master_Warehouse"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)

            cb_Gudang.DataSource = dtTable
            cb_Gudang.DisplayMember = GlobalVar.Fields.Warehouse_Name
            cb_Gudang.ValueMember = GlobalVar.Fields.Warehouse_ID

        Catch ex As Exception
            MsgBox("GetWarehouse: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub InsertData()
        'NOTE: Variable Declaration
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim Remark_Stok As String

        'NOTE: Set Transaction
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            txt_TransNo.Text = Generate_TranNo(Me.Name)
            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
            Remark_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

            StatusID = "WAFP" 'Waiting Approval from Purchasing
            txt_PPN.Text = 0

            'NOTE: Header AREA
            Cmd.CommandText = "EXEC sp_Insert_TerimaBrg_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                         dt_LPBDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                         cb_Gudang.SelectedValue & "','" & _
                                         txt_PONo.Text.Trim & "','" & _
                                         txt_SJalan.Text.Trim & "','" & _
                                         txt_Invoice.Text.Trim & "','" & _
                                         CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "','" & _
                                         Replace(CStr(CDec(0)), ",", ".") & "','" & _
                                         Replace(CStr(CDec(0)), ",", ".") & "','" & _
                                         Replace(CStr(CDec(0)), ",", ".") & "','" & _
                                         CStr(CDec(txt_UangMuka.Text)).Replace(",", ".") & "','" & _
                                         dt_PayType.Value.ToString("yyyy-MM-dd") & "','" & _
                                         txt_Remark.Text & "','" & _
                                         StatusID & "','" & _
                                         RejectReason & "','" & _
                                         userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'NOTE: Detail AREA
            For Each item As DataRow In dtDetail.Rows
                If item.RowState <> DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Insert_TerimaBrg_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No") & "','" & _
                                        item("Item ID") & "','" & _
                                        item("UoM") & "','" & _
                                        Replace(CStr(item("Qty Order")), ",", ".") & "','" & _
                                        Replace(CStr(item("Qty Receipt")), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("Discount"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "','" & _
                                        item("Remark") & "','" & _
                                        item("Quality") & "'"
                    Cmd.ExecuteNonQuery()

                    Insert_StokMovement(item("Item ID"), cb_Gudang.SelectedValue, txt_TransNo.Text.Trim, "IN", item("Qty Receipt"), Remark_Stok)
                End If
            Next

            'NOTE: Insert INBOX (Approval Process Purpose)
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID)
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID)

            'NOTE: Update Serial Sequence
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

            'NOTE: Insert Transaction History
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "SUBMIT")

            InsertJournal()
            UpdatePO()
            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Good Receipt : " & txt_TransNo.Text.Trim & " has been Submitted")

        Catch ex As Exception
            ObjTrans.Rollback()
            MsgBox("InsertData: " & ex.Message)
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub UpdateData()
        'NOTE: Variable Declartion
        Dim ObjTrans As SqlTransaction
        'Dim LastSerial As Integer
        Dim Remark_Stok As String

        'NOTE: Set Transaction
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        'NOTE: Get Approval Status
        Select Case StatusID.Trim
            Case "WAFP" 'Waiting Approval for Purchasing 
                StatusID = "WAFA"
            Case "WAFA" 'Waiting Approval for Accounting
                StatusID = "CMP"
        End Select

        Try
            Remark_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
            txt_PPN.Text = 0

            'NOTE: Header AREA
            Cmd.CommandText = "EXEC sp_Update_Trans_TerimaBrg_Hdr '" & _
                                     txt_TransNo.Text & "','" & _
                                     dt_LPBDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                     cb_Gudang.SelectedValue & "','" & _
                                     txt_PONo.Text.Trim & "','" & _
                                     txt_SJalan.Text.Trim & "','" & _
                                     txt_Invoice.Text.Trim & "','" & _
                                     StatusID & "','" & _
                                     CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "','" & _
                                     txt_PPN.Text.Replace(",", ".") & "','" & _
                                     CStr(CDec(txt_pengiriman.Text)).Replace(",", ".") & "','" & _
                                     CStr(CDec(txt_GrandTotal.Text)).Replace(",", ".") & "','" & _
                                     CStr(CDec(txt_UangMuka.Text)).Replace(",", ".") & "','" & _
                                     dt_PayType.Value & "','" & _
                                     txt_Remark.Text & "','" & _
                                     RejectReason & "','" & _
                                     userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'NOTE: Detail AREA
            For Each item As DataRow In dtDetail.Rows
                If item.RowState = DataRowState.Added Then
                    Cmd.CommandText = "EXEC sp_Insert_TerimaBrg_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No") & "','" & _
                                        item("Item ID") & "','" & _
                                        item("UoM") & "'," & _
                                        Replace(CStr(item("Qty Order")), ",", ".") & "," & _
                                        Replace(CStr(item("Qty Receipt")), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Discount"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & ",'" & _
                                        item("Remark") & "','" & _
                                        item("Quality") & "'"
                    Cmd.ExecuteNonQuery()
                    If StatusID = "WAFP" Then
                        'NOTE: Update Stock Movement when Warehouse Head has been approved document
                        Insert_StokMovement(item("Item ID"), cb_Gudang.SelectedValue, txt_TransNo.Text.Trim, "IN", item("Qty Receipt"), Remark_Stok)
                    End If

                ElseIf item.RowState = DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Delete_TerimaBrg_Dtl '" & _
                                        txt_TransNo.Text + "','" & _
                                        item("PR No") & "','" & _
                                        item("Item ID", DataRowVersion.Original).ToString & "'"
                    Cmd.ExecuteNonQuery()
                Else
                    Cmd.CommandText = "EXEC sp_Update_Trans_TerimaBrg_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No") & "','" & _
                                        item("Item ID") & "'," & _
                                        Replace(CStr(item("Qty Receipt")), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("Discount"))), ",", ".") & "," & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & ",'" & _
                                        item("Remark") & "','" & _
                                        item("Quality") & "'"
                    Cmd.ExecuteNonQuery()
                    If StatusID = "WAFP" Then
                        'NOTE: Update Stock Movement when Warehouse Head has been approved document
                        Insert_StokMovement(item("Item ID"), cb_Gudang.SelectedValue, txt_TransNo.Text.Trim, "IN", item("Qty Receipt"), Remark_Stok)
                    End If
                End If
            Next

            'NOTE: Insert INBOX (Approval Process Purpose)
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            If StatusID <> "CMP" Then
                InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetNextPIC(StatusID), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
            End If

            Select Case StatusTrans
                Case "REJECT"
                    Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "REJECT") 'Insert History transaction
                Case Else
                    If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "RE-SUBMIT") 'Insert History transaction
                    Else
                        Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "APPROVE") 'Insert History transaction
                    End If
            End Select
            InsertJournal()

            ObjTrans.Commit()
            Conn.Close()

            MessageBox.Show("Good Receipt : " & txt_TransNo.Text.Trim & " Has been Submitted")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try

    End Sub

    Private Sub DeleteData()
        Dim ObjTrans As SqlTransaction
        Dim dtTable As New DataTable

        If Conn.State = ConnectionState.Closed Then Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            StatusID = "CAP" 'cancelled by applicant

            Cmd.CommandText = "EXEC GetCurrDate"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)

            Cmd.CommandText = "EXEC sp_Update_Trans_TerimaBrg_Hdr '" & _
                                    txt_TransNo.Text & "','" & _
                                    dt_LPBDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                    cb_Gudang.SelectedValue & "','" & _
                                    txt_PONo.Text.Trim & "','" & _
                                    txt_SJalan.Text.Trim & "','" & _
                                    txt_Invoice.Text.Trim & "','" & _
                                    StatusID & "','" & _
                                    CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "','" & _
                                    txt_PPN.Text.Replace(",", ".") & "','" & _
                                    CStr(CDec(txt_pengiriman.Text)).Replace(",", ".") & "','" & _
                                    CStr(CDec(txt_GrandTotal.Text)).Replace(",", ".") & "','" & _
                                    CStr(CDec(txt_UangMuka.Text)).Replace(",", ".") & "','" & _
                                    dt_PayType.Value & "','" & _
                                    txt_Remark.Text & "','" & _
                                    RejectReason & "','" & _
                                    userlog.UserName & "'"
            Cmd.ExecuteNonQuery()
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Good Receipt : " & txt_TransNo.Text.Trim & " Has been Deleted")
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Load_POtoGetSupplier()
        Dim dtTable As New DataTable
        'NOTE: Get Supplier Data
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "EXEC sp_Retreive_POHeaderBy_PONo '" & txt_PONo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            If dtTable.Rows.Count > 0 Then
                txt_SupplierID.Text = dtTable.Rows(0).Item("Supplier_ID").ToString
                txt_SupplierName.Text = dtTable.Rows(0).Item("Nama").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub SetGrid()
        gv_PODtl.Columns(0).Width = 100
        gv_PODtl.Columns(1).Width = 60
        gv_PODtl.Columns(2).Width = 200
        gv_PODtl.Columns(3).Width = 50
        gv_PODtl.Columns(4).Width = 100
        gv_PODtl.Columns(5).Width = 100
        gv_PODtl.Columns(6).Width = 100
        gv_PODtl.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(7).Width = 100
        gv_PODtl.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(8).Width = 100
        gv_PODtl.Columns(8).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(9).Width = 100
        gv_PODtl.Columns(9).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(10).Width = 200
    End Sub

    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                ts_Edit.Visible = False
                ts_save.Visible = True
                ts_cancel.Visible = True
                ts_delete.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False

            Case TransStatus.EditStatus
                ts_Edit.Visible = False
                ts_cancel.Visible = True

                If StatusID = "RBWH" Then
                    'Warehouse Admin 
                    ts_save.Visible = True
                    ts_delete.Visible = True
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                ElseIf StatusID = "RBPH" Or StatusID = "WAFA" Or StatusID = "WAFP" Then
                    'Purchasing Admin, Accounting Admin hanya bisa submit
                    ts_save.Visible = True
                    ts_delete.Visible = False
                    ts_reject.Visible = False
                    ts_approve.Visible = False
                Else
                    ts_save.Visible = False
                    ts_delete.Visible = False
                    ts_reject.Visible = True
                    ts_approve.Visible = True
                End If

            Case "READ"
                ts_Edit.Visible = False
                ts_delete.Visible = False
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False

            Case Else
                ts_Edit.Visible = True
                ts_delete.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
        End Select

    End Sub

    Private Sub SetButton()

        Select Case StatusTransDetail
            Case "INSERT"
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = True
                btn_delete.Enabled = False
                Btn_cancel.Enabled = True
            Case "UPDATE"
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = True
                btn_delete.Enabled = False
                Btn_cancel.Enabled = True
            Case "SAVE"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
            Case "DELETE"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
            Case "CANCEL"
                btn_insert.Enabled = True
                btn_edit.Enabled = True
                btn_save.Enabled = False
                btn_delete.Enabled = True
                Btn_cancel.Enabled = True
            Case Else
                btn_insert.Enabled = False
                btn_edit.Enabled = False
                btn_save.Enabled = False
                btn_delete.Enabled = False
                Btn_cancel.Enabled = False
        End Select

    End Sub

    Private Sub InsertJournal()
        If Not (StatusID = "WAFP" Or StatusID = "WAFA" Or StatusID = "CMP") Then Exit Sub
        Dim JournalID As String
        Dim LastSerial As String
        Dim Persediaan As Double
        Dim PPN As Double
        Dim UangMuka As Double
        Dim HutangSementara As Double
        Dim NilaiInvoice As Double
        Dim SelisihInvoice As Double
        Dim PPNInvoice As Double

        Dim dtPO As New DataTable
        Dim dtPH As New DataTable
        Dim dtTB As New DataTable
        Dim dtJournal As New DataTable

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Cmd.CommandText = "EXEC sp_Retreive_POHeaderBy_PONo '" & txt_PONo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtPO)

        Cmd.CommandText = "EXEC sp_Retrieve_Trans_PelunasanHutangSupplier_Dtl_ByDocNo '" & txt_PONo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtPH)

        Cmd.CommandText = "EXEC sp_Retreive_Trans_TerimaBrgby_TBNo '" & txt_TransNo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtTB)

        Cmd.CommandText = "EXEC sp_Retrieve_Journal_Hdr_ByRefNo '" & txt_TransNo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtJournal)

        Select Case dtPO.Rows.Count
            Case 0
                Persediaan = 0
                PPN = 0
            Case Else
                Persediaan = dtPO.Rows(0).Item("SubTotal")
                PPN = Persediaan * 0.1
        End Select

        Select Case dtPH.Rows.Count
            Case 0
                UangMuka = 0
            Case Else
                UangMuka = dtPH.Rows(0).Item("Jumlah_Bayar")
        End Select

        Select Case dtTB.Rows.Count
            Case 0
                NilaiInvoice = 0
            Case Else
                NilaiInvoice = dtTB.Rows(0).Item("SubTotal")
        End Select

        HutangSementara = Persediaan + PPN - UangMuka

        Select Case StatusID
            Case "WAFP"
                JournalID = Generate_TranNo("Journal")
                LastSerial = CInt(Microsoft.VisualBasic.Right(JournalID, 3))

                'NOTE: Insert Header Data
                Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalID & "', '" & _
                                    userlog.EmployeeID & "', '" & _
                                    "Terima Barang', '" & _
                                    "', '" & _
                                    txt_TransNo.Text & "', '" & _
                                    "False', '" & _
                                    "', '" & _
                                    "False', '" & _
                                    "', '" & _
                                    userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                'NOTE: Insert Detail Data
                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                    "161', '" & _
                                    Persediaan & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                    "181', '" & _
                                    PPN & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                    "151', '" & _
                                    "0', '" & _
                                    UangMuka & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                    "323', '" & _
                                    "0', '" & _
                                    HutangSementara & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"

                Cmd.ExecuteNonQuery()
                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
            Case "WAFA"
                JournalID = dtJournal.Rows(0).Item("JournalID").ToString
                SelisihInvoice = Abs(NilaiInvoice - Persediaan) + CDbl(txt_pengiriman.Text)
                PPNInvoice = NilaiInvoice * 0.1
                HutangSementara = SelisihInvoice + PPNInvoice
                If NilaiInvoice > Persediaan Then
                    'NOTE: Insert Detail Data

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                        "161', '" & _
                                        SelisihInvoice & "', '" & _
                                        "0', '" & _
                                        "False', '" & _
                                        userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                        "181', '" & _
                                        PPNInvoice & "', '" & _
                                        "0', '" & _
                                        "False', '" & _
                                        userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                        "323', '" & _
                                        "0', '" & _
                                        HutangSementara & "', '" & _
                                        "False', '" & _
                                        userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()

                ElseIf NilaiInvoice < Persediaan Then
                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                  "323', '" & _
                                  HutangSementara & "', '" & _
                                  "0', '" & _
                                  "False', '" & _
                                  userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                        "161', '" & _
                                        "0', '" & _
                                        SelisihInvoice & "', '" & _
                                        "False', '" & _
                                        userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                        "181', '" & _
                                        "0', '" & _
                                        PPNInvoice & "', '" & _
                                        "False', '" & _
                                        userlog.UserName & "'"

                    Cmd.ExecuteNonQuery()
                End If
            Case "CMP"
                JournalID = dtJournal.Rows(0).Item("JournalID").ToString
                PPNInvoice = NilaiInvoice * 0.1
                HutangSementara = NilaiInvoice + PPNInvoice + CDbl(txt_pengiriman.Text) - UangMuka

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                "323', '" & _
                                HutangSementara & "', '" & _
                                "0', '" & _
                                "False', '" & _
                                userlog.UserName & "'"

                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalID & "', '" & _
                                    "320', '" & _
                                    "0', '" & _
                                    HutangSementara & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"

                Cmd.ExecuteNonQuery()
        End Select

    End Sub

    Private Sub Load_DetailTB()
        'NOTE: Get Detail of Good Receipt Transaction
        Try
            dtDetail.Clear()
            If Conn.State = ConnectionState.Open Then Conn.Open()
            Cmd.CommandText = "EXEC sp_Retreive_Trans_TerimaBrg_Dtl '" + txt_TransNo.Text + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail)

            If dtDetail.Rows.Count > 0 Then
                gv_PODtl.DataSource = dtDetail

                Call SetGrid()
                Call CountQty()
                Call CountSubTotal()
                Call CountGrandTotal()
            Else
                gv_PODtl.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Load_Grid: " & ex.Message)
        Finally
            Conn.Close()
        End Try

    End Sub

    Private Sub Load_HeaderTB()
        'NOTE: Get Header of Good Receipt Transaction based on TB No.
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            dtHeader.Clear()

            'NOTE: Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retreive_trans_TerimaBrgby_TBNo '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtHeader)

            If dtHeader.Rows.Count > 0 Then
                dt_LPBDate.Value = dtHeader.Rows(0).Item("TB_Date")
                txt_SupplierID.Text = dtHeader.Rows(0).Item("Supplier ID")
                txt_SupplierName.Text = dtHeader.Rows(0).Item("Supplier Name")
                txt_PONo.Text = dtHeader.Rows(0).Item("PO_No").ToString.Trim
                txt_SubTotal.Text = FormatAngka(CDbl((dtHeader.Rows(0).Item("SubTotal"))))
                txt_PPN.Text = 10
                txt_pengiriman.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("Deliver_fee")))
                txt_GrandTotal.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("Grand_Total")))
                txt_UangMuka.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("DP")))
                dt_PayType.Value = dtHeader.Rows(0).Item("dt_duedtPayment")
                txt_Remark.Text = dtHeader.Rows(0).Item("Remarks").ToString.Trim
                txt_SJalan.Text = dtHeader.Rows(0).Item("SuratJalan_No").ToString.Trim
                txt_Invoice.Text = dtHeader.Rows(0).Item("Faktur_No").ToString.Trim
                txt_Reason.Text = dtHeader.Rows(0).Item("Reject_Reason").ToString.Trim
                StatusID = dtHeader.Rows(0).Item("Status_ID").ToString.Trim
                RejectReason = dtHeader.Rows(0).Item("Reject_Reason").ToString.Trim
                lbl_status.Text = GetStatus(StatusID)
            End If
        Catch ex As Exception
            MsgBox("Load_TB: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Load_PODetail()
        'NOTE: Get PO Detail
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
            dtDetail.Clear()

            Cmd.CommandText = "EXEC sp_Retrieve_Trans_PODtl_ByPONo_ForTB '" & txt_PONo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail)

            If dtDetail.Rows.Count = 0 Then
                StatusTransDetail = ""
                Call SetButton()
                Call EnableDetail()
                MsgBox("PO No doesn't exist in database", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
            gv_PODtl.DataSource = dtDetail
            StatusTransDetail = "CANCEL"

            Call EnableDetail()
            Call SetButton()
            Call SetGrid()
            Call CountSubTotal()
            Call CountQty()

            Conn.Close()

        Catch ex As Exception
            MsgBox("Load_PODetail: " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub GetDP()
        Dim dtPH As New DataTable

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Cmd.CommandText = "EXEC sp_Retrieve_Trans_PelunasanHutangSupplier_Dtl_ByDocNo '" & txt_PONo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtPH)

        Select Case dtPH.Rows.Count
            Case 0
                txt_UangMuka.Text = 0
            Case Else
                txt_UangMuka.Text = FormatAngka(CDbl(dtPH.Rows(0).Item("Jumlah_Bayar")))
        End Select
    End Sub

    Private Sub UpdatePO()
        Dim dtTable As New DataTable
        Dim flag As Boolean
        flag = True

        Cmd.CommandText = "EXEC sp_Retrieve_Trans_PO_Dtl_ForClosingByPONo '" & txt_PONo.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtTable)

        If dtTable.Rows.Count = 0 Then Exit Sub
        For Each item As DataRow In dtTable.Rows
            If item("Qty_Rec") < item("Qty") Then
                flag = False
                Exit For
            End If
        Next

        If flag = False Then Exit Sub

        Cmd.CommandText = "EXEC sp_Update_Trans_PO_Hdr_Automatically '" & txt_PONo.Text.Trim & "', '" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()

        UpdatetoInbox(txt_PONo.Text.Trim, "CMP", userlog.UserName, "4") 'Update Status utk Flow Teakhir
        UpdatetoInbox(txt_PONo.Text.Trim, "CMP", GetDocCreator(txt_PONo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                

    End Sub

#End Region

#Region "Event Handler - Main"

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            frmTerimaBrg_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            StatusTransDetail = "CANCEL"

            Call EnableInput(True)
            Call EnableDetail()
            Call SetBackColorDetail()
            Call SetToolTip()
            Call SetButton()

        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        'NOTE: All STATUS in Good Receive
        '1. WAWH -- Waiting approval from Warehouse Head
        '2. WAFP -- Waiting approval from Purchasing
        '3. WAPH -- Waiting approval from Purchasing HEAD
        '4. CMP  -- Completed

        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to submit this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Validation() = False Then Exit Sub
                Select Case StatusTrans
                    Case TransStatus.NewStatus
                        Call InsertData()
                    Case TransStatus.EditStatus
                        Call UpdateData()
                End Select

                Call frmTerimaBrg_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If

    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            StatusTrans = "APPROVE"
            If Validation() = False Then Exit Sub

            Call UpdateData()
            Call frmTerimaBrg_Load(False, e)
        End If
    End Sub

    Private Sub ts_reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_reject.Click
        If MessageBox.Show("Are you sure to Reject this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            frmReason.StartPosition = FormStartPosition.CenterScreen
            frmReason.ShowDialog()
            If frmReason.Flag = "OK" Then
                If frmReason.txtReason.Text.ToString.Trim <> "" Then
                    If Validation() = False Then Exit Sub

                    RejectReason = frmReason.txtReason.Text.ToString.Trim
                    StatusTrans = "REJECT"
                    Call UpdateData()
                    Call frmTerimaBrg_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If
    End Sub

    Private Sub dt_PayType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dt_PayType.Leave
        txt_Remark.Focus()
    End Sub

    Private Sub txt_pengiriman_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pengiriman.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_pengiriman_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pengiriman.Leave
        CountGrandTotal()
        If txt_pengiriman.Text = "" Then
            txt_pengiriman.Text = 0
        End If
        txt_pengiriman.Text = FormatAngka(txt_pengiriman.Text)
    End Sub

    Private Sub txt_PONo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PONo.KeyDown
        Dim dtTable As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT PO_No, PO_date, Supplier_ID, RecGood_Date AS Tgl_TerimaBrg FROM Trans_PO_Hdr WHERE Status_ID = 'WCFR'", "PO_No", "PO_Date", "Tgl_TerimaBrg", "", "")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then Conn.Close()

                    dtTable.Clear()
                    Cmd.CommandText = "EXEC sp_Retreive_POHeaderBy_PONo '" & frmSearch.txtResult1.Text.ToString.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_PONo.Text = dtTable.Rows(0).Item("PO_No").ToString
                        Call Load_POtoGetSupplier()
                        Call Load_PODetail()
                        Call GetDP()
                        gv_PODtl.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_PONo.Text.Trim <> "" Then
                Try
                    Call Load_POtoGetSupplier()
                    Call Load_PODetail()
                    Call GetDP()
                    gv_PODtl.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Conn.Close()
                End Try
            Else
                dtDetail.Clear()
                gv_PODtl.DataSource = dtDetail
                MsgBox("Please fill PO No", MsgBoxStyle.Information, "Information")
                txt_PONo.Focus()
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub txt_PPN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PPN.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_PPN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_PPN.Leave
        txt_pengiriman.Focus()
    End Sub

    Private Sub txt_UangMuka_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_UangMuka.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_UangMuka_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UangMuka.Leave
        dt_PayType.Focus()
    End Sub

    Private Sub frmTerimaBrg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Select Case CallerForm
            Case "INBOX"
                Dim frmChild As New FrmInbox
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormInbox" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Case "BINGKAI"
                Dim frmChild As New frmBingkai
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FrmBIngkai" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
            Case Else
                Dim frmChild As New Frm_ViewPenerimaBrg
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormViewPenerimaanBarang" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select

    End Sub

    Private Sub frmTerimaBrg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Call ClearInput()
        Call ClearDetail()
        Call GetWarehouse()

        If txt_TransNo.Text.ToString.Trim <> "" Then 'NOTE: Jika dipanggil dari View Penerimaan Barang
            Call Load_HeaderTB()
            Call Load_DetailTB()
            Call Load_POtoGetSupplier()

            Select Case CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName)
                Case True
                    StatusTrans = TransStatus.NoStatus
                Case Else
                    StatusTrans = "READ"
            End Select

            StatusTransDetail = ""
            Call EnableInput(False)
            Call EnableDetail()
            Call SetBackColorDetail()
            Call SetToolTip()
            Call SetButton()

        Else
            lbl_status.Text = GetStatus("DRAFT")
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = ""
            Call EnableDetail()
            Call EnableInput(True)
            Call SetToolTip()
            Call SetButton()
        End If

        'NOTE: if user login's access is Purchasing then show Supplier Data
        Select Case userlog.Show_Supplier
            Case "Y"
                VisibleSupplier(True)
            Case Else
                VisibleSupplier(False)
        End Select


    End Sub

#End Region

#Region "Detail"

    Private Function ValidationDetail() As Boolean
        ValidationDetail = True

        If Txt_QtyRec.Text.Trim = "" Then
            MessageBox.Show("Qty Receipt must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Txt_QtyRec.Focus()
            ValidationDetail = False
            Exit Function
        End If

        If cb_quality.SelectedItem = "" Then
            MessageBox.Show("Quality Receipt must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            cb_quality.Focus()
            ValidationDetail = False
            Exit Function
        End If

        If userlog.Insert_Price = "Y" Then
            If txt_Harga.Text.Trim = "" Then
                MessageBox.Show("Item Price must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_Harga.Focus()
                ValidationDetail = False
                Exit Function
            End If
        End If

    End Function

    Private Sub SetBackColorDetail()
        Select Case StatusTransDetail
            Case "INSERT"
                txt_PRNo.BackColor = Color.LemonChiffon
                txt_ItemID.BackColor = Color.LemonChiffon
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                txt_SubTotal.BackColor = Color.DarkGray
                txt_Ket.BackColor = Color.LemonChiffon

                If userlog.Insert_Price = "Y" Then
                    Txt_QtyRec.BackColor = Color.LemonChiffon
                    txt_Harga.BackColor = Color.LemonChiffon
                    txt_Diskon.BackColor = Color.LemonChiffon
                Else
                    Txt_QtyRec.BackColor = Color.LemonChiffon
                    txt_Harga.BackColor = Color.DarkGray
                    txt_Diskon.BackColor = Color.DarkGray
                End If
            Case "UPDATE"
                txt_PRNo.BackColor = Color.DarkGray
                txt_ItemID.BackColor = Color.DarkGray
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                txt_SubTotal.BackColor = Color.DarkGray
                txt_Ket.BackColor = Color.LemonChiffon

                If userlog.Insert_Price = "Y" Then
                    Txt_QtyRec.BackColor = Color.DarkGray
                    txt_Harga.BackColor = Color.LemonChiffon
                    txt_Diskon.BackColor = Color.LemonChiffon
                Else
                    Txt_QtyRec.BackColor = Color.LemonChiffon
                    txt_Harga.BackColor = Color.DarkGray
                    txt_Diskon.BackColor = Color.DarkGray
                End If

            Case Else
                txt_PRNo.BackColor = Color.DarkGray
                txt_ItemID.BackColor = Color.DarkGray
                txt_ItemName.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                Txt_QtyRec.BackColor = Color.DarkGray
                txt_Harga.BackColor = Color.DarkGray
                txt_Diskon.BackColor = Color.DarkGray
                txt_Ket.BackColor = Color.DarkGray
                txt_SubTotal.BackColor = Color.DarkGray
        End Select
    End Sub

    Private Sub EnableDetail()

        Select Case StatusTransDetail
            Case "INSERT"
                txt_PRNo.Enabled = True
                txt_ItemID.Enabled = True
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = False
                txt_Ket.Enabled = True

                If userlog.Insert_Price = "Y" Then
                    Txt_QtyRec.Enabled = True
                    txt_Harga.Enabled = True
                    txt_Diskon.Enabled = True
                    txt_SubTotalTemp.Visible = True
                    Label18.Visible = True
                    Label19.Visible = True
                    Label20.Visible = True

                    Gb_PaymentType.Visible = True
                    txt_SubTotal.Visible = True
                    txt_PPN.Visible = True
                    txt_pengiriman.Visible = True
                    txt_UangMuka.Visible = True
                    txt_GrandTotal.Visible = True
                    Label9.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True
                    Label15.Visible = True
                    Label16.Visible = True

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = True
                    gv_PODtl.Columns("PO Price").Visible = True
                    gv_PODtl.Columns("Discount").Visible = True
                    gv_PODtl.Columns("SubTotal").Visible = True
                Else
                    Txt_QtyRec.Enabled = True
                    txt_Harga.Enabled = False
                    txt_Diskon.Enabled = False
                    txt_SubTotalTemp.Visible = False
                    Label18.Visible = False
                    Label19.Visible = False
                    Label20.Visible = False

                    Gb_PaymentType.Visible = False
                    txt_SubTotal.Visible = False
                    txt_PPN.Visible = False
                    txt_pengiriman.Visible = False
                    txt_UangMuka.Visible = False
                    txt_GrandTotal.Visible = False
                    Label9.Visible = False
                    Label10.Visible = False
                    Label11.Visible = False
                    Label15.Visible = False
                    Label16.Visible = False

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = False
                    gv_PODtl.Columns("PO Price").Visible = False
                    gv_PODtl.Columns("Discount").Visible = False
                    gv_PODtl.Columns("SubTotal").Visible = False

                End If

                If StatusTrans = TransStatus.NewStatus Then
                    cb_quality.Enabled = True
                End If
            Case "UPDATE"
                txt_PRNo.Enabled = False
                txt_ItemID.Enabled = False
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = False
                txt_Ket.Enabled = True

                If userlog.Insert_Price = "Y" Then
                    Txt_QtyRec.Enabled = False
                    txt_Harga.Enabled = True
                    txt_Diskon.Enabled = True
                    txt_SubTotalTemp.Visible = True
                    Label18.Visible = True
                    Label19.Visible = True
                    Label20.Visible = True

                    Gb_PaymentType.Visible = True
                    txt_SubTotal.Visible = True
                    txt_PPN.Visible = True
                    txt_pengiriman.Visible = True
                    txt_UangMuka.Visible = True
                    txt_GrandTotal.Visible = True
                    Label9.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True
                    Label15.Visible = True
                    Label16.Visible = True

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = True
                    gv_PODtl.Columns("PO Price").Visible = True
                    gv_PODtl.Columns("Discount").Visible = True
                    gv_PODtl.Columns("SubTotal").Visible = True
                Else
                    Txt_QtyRec.Enabled = True
                    txt_Harga.Enabled = False
                    txt_Diskon.Enabled = False
                    txt_SubTotalTemp.Visible = False
                    Label18.Visible = False
                    Label19.Visible = False
                    Label20.Visible = False

                    Gb_PaymentType.Visible = False
                    txt_SubTotal.Visible = False
                    txt_PPN.Visible = False
                    txt_pengiriman.Visible = False
                    txt_UangMuka.Visible = False
                    txt_GrandTotal.Visible = False
                    Label9.Visible = False
                    Label10.Visible = False
                    Label11.Visible = False
                    Label15.Visible = False
                    Label16.Visible = False

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = False
                    gv_PODtl.Columns("PO Price").Visible = False
                    gv_PODtl.Columns("Discount").Visible = False
                    gv_PODtl.Columns("SubTotal").Visible = False
                End If

                If StatusTrans = TransStatus.NewStatus Then
                    cb_quality.Enabled = True
                End If

            Case Else
                txt_PRNo.Enabled = False
                txt_ItemID.Enabled = False
                txt_ItemName.Enabled = False
                Txt_Qty.Enabled = False
                Txt_QtyRec.Enabled = False
                txt_Harga.Enabled = False
                txt_Diskon.Enabled = False
                txt_Ket.Enabled = False
                cb_quality.Enabled = False

                If userlog.Insert_Price = "Y" Then
                    txt_Harga.Visible = True
                    txt_Diskon.Visible = True
                    txt_SubTotalTemp.Visible = True
                    Label18.Visible = True
                    Label19.Visible = True
                    Label20.Visible = True

                    Gb_PaymentType.Visible = True
                    txt_SubTotal.Visible = True
                    txt_PPN.Visible = True
                    txt_pengiriman.Visible = True
                    txt_UangMuka.Visible = True
                    txt_GrandTotal.Visible = True
                    Label9.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True
                    Label15.Visible = True
                    Label16.Visible = True

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = True
                    gv_PODtl.Columns("PO Price").Visible = True
                    gv_PODtl.Columns("Discount").Visible = True
                    gv_PODtl.Columns("SubTotal").Visible = True
                Else

                    txt_Harga.Visible = False
                    txt_Diskon.Visible = False
                    txt_SubTotalTemp.Visible = False
                    Label18.Visible = False
                    Label19.Visible = False
                    Label20.Visible = False

                    Gb_PaymentType.Visible = False
                    txt_SubTotal.Visible = False
                    txt_PPN.Visible = False
                    txt_pengiriman.Visible = False
                    txt_UangMuka.Visible = False
                    txt_GrandTotal.Visible = False
                    Label9.Visible = False
                    Label10.Visible = False
                    Label11.Visible = False
                    Label15.Visible = False
                    Label16.Visible = False

                    If gv_PODtl.RowCount = 0 Then Exit Sub
                    gv_PODtl.Columns("Price").Visible = False
                    gv_PODtl.Columns("PO Price").Visible = False
                    gv_PODtl.Columns("Discount").Visible = False
                    gv_PODtl.Columns("SubTotal").Visible = False
                End If

        End Select

    End Sub

    Private Sub ClearDetail()
        txt_PRNo.Clear()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_Qty.Clear()
        Txt_QtyRec.Clear()
        txt_Harga.Clear()
        txt_Diskon.Clear()
        txt_SubTotalTemp.Clear()
        txt_Ket.Clear()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim dtTable As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Item_id,Item_Name,UoM as Harga from Master_Item_Hdr", "Item_ID", "Item_Name", "UoM", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then Conn.Close()
                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dtTable.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dtTable.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item("UoM").ToString
                        Txt_QtyRec.Focus()
                    Else
                        MessageBox.Show("Item can't be found. Please choose ITEM ID correctly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)

                    If dtTable.Rows.Count > 0 Then
                        txt_ItemName.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_QtyRec.Focus()
                    Else
                        MessageBox.Show("Item can't be found. Please choose ITEM ID correctly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow
        Dim arr(1)

        dc(0) = dtDetail.Columns("PR No")
        dc(1) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        arr(0) = txt_PRNo.Text.Trim
        arr(1) = txt_ItemID.Text.Trim

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose 1 data to deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure to delete this data?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            dr = dtDetail.Rows.Find(arr)
            If DA IsNot Nothing Then
                dr.Delete()
                gv_PODtl.Focus()
            End If
        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Please choose 1 data to edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        StatusTransDetail = "UPDATE"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If ValidationDetail() = False Then Exit Sub
        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow
        Dim arr(1)

        dc(0) = dtDetail.Columns("PR No")
        dc(1) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        arr(0) = txt_PRNo.Text.Trim
        arr(1) = txt_ItemID.Text.Trim

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail.Rows.Find(arr)
            If dr IsNot Nothing Then
                MessageBox.Show("Item " & txt_ItemID.Text.Trim & " with PR No " & txt_PRNo.Text.Trim & "is existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                dr = dtDetail.NewRow
                dr("PR No") = txt_PRNo.Text
                dr("Item ID") = txt_ItemID.Text
                dr("Item Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty Order") = 0
                dr("Qty Receipt") = Txt_QtyRec.Text
                dr("Quality") = cb_quality.SelectedItem

                If txt_Harga.Text = "" Then
                    dr("Price") = 0
                Else
                    dr("Price") = txt_Harga.Text
                End If

                If txt_Diskon.Text = "" Then
                    dr("Discount") = 0
                Else
                    dr("Discount") = txt_Diskon.Text
                End If

                If txt_SubTotalTemp.Text = "" Then
                    dr("SubTotal") = 0
                Else
                    dr("SubTotal") = (dr("Price") * dr("Qty Receipt")) - dr("Discount")
                End If

                dr("Remark") = txt_Ket.Text
                dtDetail.Rows.Add(dr)
            End If
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dtDetail.Rows.Find(arr)
            If dr IsNot Nothing Then
                dr("Qty Receipt") = Txt_QtyRec.Text
                If txt_Harga.Text = "" Then
                    dr("Price") = 0
                Else
                    dr("Price") = txt_Harga.Text
                End If

                If txt_Diskon.Text = "" Then
                    dr("Discount") = 0
                Else
                    dr("Discount") = txt_Diskon.Text
                End If

                If txt_SubTotalTemp.Text = "" Then
                    dr("SubTotal") = 0
                Else
                    dr("SubTotal") = (dr("Price") * dr("Qty Receipt")) - dr("Discount")
                End If
                dr("Remark") = txt_Ket.Text.Trim
                dr("Quality") = cb_quality.SelectedItem
            End If
        End If

        gv_PODtl.DataSource = dtDetail
        StatusTransDetail = "SAVE"

        Call CountQty()
        Call CountSubTotal()
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDetail()
        Call SetBackColorDetail()
    End Sub

    Private Sub txt_ItemID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ItemID.Leave
        Txt_QtyRec.Focus()
    End Sub

    Private Sub Txt_QtyRec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_QtyRec.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_QtyRec_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_QtyRec.Leave
        If StatusTransDetail = "" Then 'NOTE: New Document
            btn_save.Focus()
        Else
            txt_Harga.Focus()
        End If
    End Sub

    Private Sub txt_Harga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Harga.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Harga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Harga.Leave
        If txt_Harga.Text.Trim <> "" And Txt_QtyRec.Text.Trim <> "" Then
            txt_SubTotalTemp.Text = FormatAngka(CDec(txt_Harga.Text.Trim) * CDec(Txt_QtyRec.Text.Trim) - CDec(txt_Diskon.Text.Trim))
        Else
            txt_Harga.Text = 0
        End If
        txt_Harga.Text = FormatAngka(CDbl(txt_Harga.Text.Trim))
        txt_Diskon.Focus()
    End Sub

    Private Sub txt_Diskon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Diskon.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Diskon_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Diskon.Leave
        If txt_Diskon.Text.Trim <> "" Then
            txt_SubTotalTemp.Text = FormatAngka(CDec(txt_Harga.Text.Trim) * CDec(Txt_QtyRec.Text.Trim) - CDec(txt_Diskon.Text.Trim))
        Else
            txt_Diskon.Text = 0
        End If
        txt_Diskon.Text = FormatAngka(CDbl(txt_Diskon.Text))
        txt_Ket.Focus()
    End Sub

    Private Sub txt_Ket_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Ket.Leave
        btn_save.Focus()
    End Sub

    Private Sub gv_PODtl_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_PODtl.MouseClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If gv_PODtl.RowCount = 0 Then Exit Sub
        If gv_PODtl.CurrentRow.DataGridView(0, gv_PODtl.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        If String.IsNullOrEmpty(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Item ID").Value) = False Then
            txt_PRNo.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("PR No").Value.ToString.Trim
            txt_ItemID.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Item ID").Value.ToString.Trim
            txt_ItemName.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Item Name").Value.ToString.Trim
            Txt_UoM.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("UOM").Value.ToString.Trim
            Txt_Qty.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Qty Order").Value.ToString.Trim
            txt_Harga.Text = FormatAngka(CDbl(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Price").Value.ToString.Trim))
            txt_Diskon.Text = FormatAngka(CDbl(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Discount").Value.ToString.Trim))
            txt_Ket.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Remark").Value.ToString.Trim
            cb_quality.SelectedItem = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Quality").Value.ToString.Trim
            If gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Qty Receipt").Value IsNot Nothing Then
                Txt_QtyRec.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Qty Receipt").Value.ToString.Trim
            Else
                Txt_QtyRec.Text = 0
            End If
            If gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Subtotal").Value IsNot Nothing Then
                txt_SubTotalTemp.Text = FormatAngka(CDbl(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Subtotal").Value.ToString.Trim))
            Else
                txt_SubTotalTemp.Text = 0
            End If
        End If
    End Sub

#End Region

End Class

