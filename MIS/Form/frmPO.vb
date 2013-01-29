Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmPO

#Region "Variabel Declaration"

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dr_dtl As DataRow
    Dim dt As New DataTable
    Dim dt_item As New DataTable
    Dim dt_GetPR As New DataTable
    Dim dtTable As New DataTable
    Dim RequestType As String
    Dim StatusTrans As String
    Dim StatusTransDetail As String
    Dim StatusID As String
    Dim frmReason As New Frm_Reason
    Dim RejectReason As String = ""
    Public CallerForm As String
    Public ViewFormName As String

#End Region

#Region "Function & Procedure"

    Private Sub CountGrandTotal()
        Dim GT, ST, PN As Integer

        GT = ST = PN = 0
        If txt_SubTotal.Text.Trim <> "" Then
            ST = CInt(txt_SubTotal.Text)
        End If

        PN = ST * 0.1
        GT = ST + PN
        txt_GrandTotal.Text = FormatAngka(CDbl(GT))
    End Sub

    Private Sub CountQty()
        Dim qty As Integer = 0

        If RequestType = "Pembelian Barang" Then
            'If gv_PODtl.Rows.Count = 0 Then
            'qty = qty + CDec(Txt_Qty.Text.Trim)
            'Else
            For i As Integer = 0 To gv_PODtl.Rows.Count - 1
                qty += gv_PODtl.Rows(i).Cells("Qty").Value
            Next
            'End If
            txt_TotalQty.Text = CStr(qty)
        End If


    End Sub

    Private Sub CountSubTotal()
        Dim count As Double = 0

        Select Case RequestType
            Case "Pembelian Barang"
                'If gv_PODtl.Rows.Count = 0 Then
                'count = count + CDec(txt_SubTotalTemp.Text.Trim)
                'Else
                For i As Integer = 0 To gv_PODtl.Rows.Count - 1
                    count += gv_PODtl.Rows(i).Cells("SubTotal").Value
                Next
                'End If

            Case "Pembelian Jasa"
                'If gv_PODtl.Rows.Count = 0 Then
                'count = count + CDec(txt_JasaHarga.Text.Trim)
                'Else
                For i As Integer = 0 To gv_PODtl.Rows.Count - 1
                    count += gv_PODtl.Rows(i).Cells("Price").Value
                Next
                'End If

        End Select
 
        txt_SubTotal.Text = FormatAngka(CDbl(count))

        CountGrandTotal()
    End Sub

    Private Function GetSupplier() As Boolean
        Dim dt_Supp As New DataTable
        GetSupplier = True
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "SELECT Supp_id, Nama, alamat, Telp, Fax FROM Master_Supplier WHERE active_flag = 'Y' AND Supp_ID = '" & txt_SupplierID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Supp)

            If dt_Supp.Rows.Count > 0 Then
                txt_SupplierID.Text = dt_Supp.Rows(0).Item(GlobalVar.Fields.Supp_ID).ToString
                txt_SupplierName.Text = dt_Supp.Rows(0).Item(GlobalVar.Fields.Supp_Name).ToString
            Else
                MsgBox("Supplier ID isn't valid")
                GetSupplier = False
                txt_SupplierID.Focus()
                Exit Function
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox("GetSupplier: " & ex.Message)
        End Try
    End Function

    Private Sub GetItemData(ByVal ItemId As String)
        Try
            dt_item.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retreive_Item_byItemID '" + ItemId + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_item)

            Conn.Close()
        Catch ex As Exception
            MsgBox("GetItemData: " & ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub Load_POHeader()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()
            Cmd.CommandText = "EXEC sp_Retreive_POHeaderBy_PONo '" + txt_TransNo.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)
            If dt_hdr.Rows.Count > 0 Then
                txt_TransNo.Text = dt_hdr.Rows(0).Item("PO_No").ToString.Trim
                dt_PODate.Value = dt_hdr.Rows(0).Item("PO_Date")
                dt_TerimaBrg.Value = dt_hdr.Rows(0).Item("RecGood_Date")
                RequestType = dt_hdr.Rows(0).Item("Type_Request")
                txt_SupplierID.Text = dt_hdr.Rows(0).Item("Supplier_ID")
                txt_SupplierName.Text = dt_hdr.Rows(0).Item("Nama")
                txt_SubTotal.Text = FormatAngka(dt_hdr.Rows(0).Item("SubTotal"))
                txt_GrandTotal.Text = FormatAngka(dt_hdr.Rows(0).Item("Grand_Total"))
                txt_Remark.Text = dt_hdr.Rows(0).Item("Remarks").ToString.Trim
                txt_Reason.Text = dt_hdr.Rows(0).Item("Reject_Reason").ToString.Trim
                txt_InvAmt.Text = dt_hdr.Rows(0).Item("Invoice_Amount").ToString.Trim
                StatusID = dt_hdr.Rows(0).Item("Status_ID").ToString.Trim
                RejectReason = dt_hdr.Rows(0).Item("Reject_Reason").ToString.Trim
                lbl_status.Text = GetStatus(StatusID)

                If StatusID.Trim = "WCFR" Then
                    ts_save.Text = "Confirm"
                End If

                Select Case dt_hdr.Rows(0).Item("Type_Request").ToString.Trim
                    Case "Pembelian Jasa"
                        rb_jasa.Checked = True

                    Case Else
                        rb_item.Checked = True
                End Select

                Call GetDP()
            Else
                MessageBox.Show("Data PO has not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Conn.Close()

        Catch ex As Exception
            MsgBox("Load_POHeader: " & ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub Load_PODetail()
        Try
            dt_dtl.Clear() 'Hapus dan Bersihin data
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retreive_PODetailBy_PONo '" + txt_TransNo.Text + "','" + RequestType + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_dtl)

            If dt_dtl.Rows.Count > 0 Then
                gv_PODtl.DataSource = dt_dtl
                gv_PODtl.Enabled = True

                Select Case RequestType.Trim
                    Case "Pembelian Jasa"
                        SetGrid_Jasa()
                        CountSubTotal()
                        CountGrandTotal()
                    Case Else
                        SetGrid_Item()
                        CountQty()
                        CountSubTotal()
                        CountGrandTotal()
                End Select
            Else
                gv_PODtl.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Load_PODetail: " & ex.Message)
        End Try
    End Sub

    Private Sub SetGrid_Item()
        gv_PODtl.Columns(0).Width = 100
        gv_PODtl.Columns(1).Width = 60
        gv_PODtl.Columns(2).Width = 300
        gv_PODtl.Columns(3).Width = 50
        gv_PODtl.Columns(4).Width = 50
        gv_PODtl.Columns(5).Width = 100
        gv_PODtl.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(5).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(6).Width = 100
        gv_PODtl.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(7).Width = 100
        gv_PODtl.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(8).Width = 210
    End Sub

    Private Sub SetGrid_Jasa()
        gv_PODtl.Columns(0).Width = 100
        gv_PODtl.Columns(1).Width = 60
        gv_PODtl.Columns(2).Width = 300
        gv_PODtl.Columns(3).Width = 100
        gv_PODtl.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(3).DefaultCellStyle.Format = "#,##0.#0"
        gv_PODtl.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_PODtl.Columns(4).Width = 300
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)

        Select Case boo
            Case True
                dt_PODate.Enabled = True
                dt_TerimaBrg.Enabled = True
                txt_Remark.ReadOnly = False
                txt_SupplierID.ReadOnly = False
                btn_RecommendedSupp.Enabled = True

                txt_Remark.ForeColor = Color.Black
                txt_Remark.BackColor = Color.White
                txt_SupplierID.ForeColor = Color.Black
                txt_SupplierID.BackColor = Color.White

            Case False
                dt_PODate.Enabled = False
                dt_TerimaBrg.Enabled = False
                txt_Remark.ReadOnly = True
                txt_SupplierID.ReadOnly = True
                btn_RecommendedSupp.Enabled = False

                txt_Remark.ForeColor = Color.Gray
                txt_Remark.BackColor = Color.LightGray
                txt_SupplierID.ForeColor = Color.Gray
                txt_SupplierID.BackColor = Color.LightGray
        End Select

        Select Case StatusTrans
            Case TransStatus.NewStatus
                GroupBox1.Enabled = True
            Case Else
                GroupBox1.Enabled = False
        End Select

        If rb_jasa.Checked = True Then
            txt_InvAmt.Visible = True
            lbl_InvAmt.Visible = True

            If boo = True Then
                txt_InvAmt.ReadOnly = False
                txt_InvAmt.ForeColor = Color.Black
                txt_InvAmt.BackColor = Color.White
            Else
                txt_InvAmt.ReadOnly = True
                txt_InvAmt.ForeColor = Color.Gray
                txt_InvAmt.BackColor = Color.LightGray
            End If
        Else
            txt_InvAmt.Visible = False
            lbl_InvAmt.Visible = False
        End If

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
                ts_print.Visible = False
            Case TransStatus.EditStatus
                ts_Edit.Visible = False
                ts_cancel.Visible = True
                ts_print.Visible = True

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
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
                ts_print.Visible = True
            Case Else

                If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName And StatusID.Trim <> "WCFR" Then
                    ts_delete.Visible = True
                Else
                    ts_delete.Visible = False
                End If

                ts_Edit.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
                ts_approve.Visible = False
                ts_reject.Visible = False
                ts_print.Visible = True
        End Select
    End Sub

    Private Sub SetButtonItem()
        Select Case StatusTransDetail.ToUpper
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

    Private Sub SetButtonJasa()
        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = True
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = True
            Case "UPDATE"
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = True
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = True
            Case "SAVE"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case "DELETE"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case "CANCEL"
                btn_InsertJasa.Enabled = True
                btn_editJasa.Enabled = True
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = True
                btn_cancelJasa.Enabled = True
            Case Else
                btn_InsertJasa.Enabled = False
                btn_editJasa.Enabled = False
                btn_SaveJasa.Enabled = False
                btn_deleteJasa.Enabled = False
                btn_cancelJasa.Enabled = False
        End Select
    End Sub

    Private Sub SetColumnDetail()
        dt_dtl.Reset()
        Select Case RequestType
            Case "Pembelian Jasa"
                dt_dtl.Columns.Add("PR No")
                dt_dtl.Columns.Add("Jasa ID")
                dt_dtl.Columns.Add("Jasa Name")
                dt_dtl.Columns.Add("Price")
                dt_dtl.Columns.Add("Remarks")
            Case Else
                dt_dtl.Columns.Add("PR No")
                dt_dtl.Columns.Add("Item ID")
                dt_dtl.Columns.Add("Item Name")
                dt_dtl.Columns.Add("UoM")
                dt_dtl.Columns.Add("Qty")
                dt_dtl.Columns.Add("Price")
                dt_dtl.Columns.Add("Subtotal")
                dt_dtl.Columns.Add("Diskon")
                dt_dtl.Columns.Add("Remarks")
        End Select

    End Sub

    Private Sub ShowSupplier(ByVal boo As Boolean)
        lbl_SupplierID.Visible = boo
        lbl_SupplierName.Visible = boo
        txt_SupplierID.Visible = boo
        txt_SupplierName.Visible = boo
    End Sub

    Private Sub EnableDisableInputDetailItem()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_PRNoItem.Clear()
                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                txt_Harga.Clear()
                txt_Diskon.Clear()
                txt_SubTotalTemp.Clear()
                txt_Ket.Clear()

                txt_PRNoItem.Enabled = True
                txt_ItemID.Enabled = True
                Txt_Qty.Enabled = True
                txt_Harga.Enabled = True
                txt_Diskon.Enabled = True
                txt_Ket.Enabled = True

                txt_PRNoItem.BackColor = Color.LemonChiffon
                txt_ItemID.BackColor = Color.LemonChiffon
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Harga.BackColor = Color.LemonChiffon
                txt_Diskon.BackColor = Color.LemonChiffon
                txt_Ket.BackColor = Color.LemonChiffon

            Case "UPDATE"
                txt_PRNoItem.Enabled = False
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = True
                txt_Harga.Enabled = True
                txt_Diskon.Enabled = True
                txt_Ket.Enabled = True

                txt_PRNoItem.BackColor = Color.DarkGray
                txt_ItemID.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Harga.BackColor = Color.LemonChiffon
                txt_Diskon.BackColor = Color.LemonChiffon
                txt_Ket.BackColor = Color.LemonChiffon

            Case Else
                txt_PRNoItem.Clear()
                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                txt_Harga.Clear()
                txt_Diskon.Clear()
                txt_SubTotalTemp.Clear()
                txt_Ket.Clear()

                txt_PRNoItem.Enabled = False
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = False
                txt_Harga.Enabled = False
                txt_Diskon.Enabled = False
                txt_Ket.Enabled = False

                txt_PRNoItem.BackColor = Color.DarkGray
                txt_ItemID.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                txt_Harga.BackColor = Color.DarkGray
                txt_Diskon.BackColor = Color.DarkGray
                txt_Ket.BackColor = Color.DarkGray

        End Select

    End Sub

    Private Sub EnableDisableInputDetailJasa()

        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_PRNoJasa.Clear()
                txt_JasaID.Clear()
                txt_JasaName.Clear()
                txt_JasaHarga.Clear()
                txt_JasaKet.Clear()

                txt_PRNoJasa.Enabled = True
                txt_JasaID.Enabled = True
                txt_JasaHarga.Enabled = True
                txt_JasaKet.Enabled = True

                txt_PRNoJasa.BackColor = Color.LemonChiffon
                txt_JasaID.BackColor = Color.LemonChiffon
                txt_JasaHarga.BackColor = Color.LemonChiffon
                txt_JasaKet.BackColor = Color.LemonChiffon

            Case "UPDATE"
                txt_PRNoJasa.Enabled = False
                txt_JasaID.Enabled = False
                txt_JasaHarga.Enabled = True
                txt_JasaKet.Enabled = True

                txt_PRNoJasa.BackColor = Color.DarkGray
                txt_JasaID.BackColor = Color.DarkGray
                txt_JasaHarga.BackColor = Color.LemonChiffon
                txt_JasaKet.BackColor = Color.LemonChiffon

            Case Else
                txt_PRNoJasa.Clear()
                txt_JasaID.Clear()
                txt_JasaName.Clear()
                txt_JasaHarga.Clear()
                txt_JasaKet.Clear()

                txt_PRNoJasa.Enabled = False
                txt_JasaID.Enabled = False
                txt_JasaHarga.Enabled = False
                txt_JasaKet.Enabled = False

                txt_PRNoJasa.BackColor = Color.DarkGray
                txt_JasaID.BackColor = Color.DarkGray
                txt_JasaHarga.BackColor = Color.DarkGray
                txt_JasaKet.BackColor = Color.DarkGray
        End Select

    End Sub

    Private Sub InsertData()
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer

        dtTable.Clear()

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        '--Header Data     
        Try
            txt_TransNo.Text = Generate_TranNo(Me.Name)
            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))

            StatusID = "WAPH" 'Waiting approval from Purchasing Head   
            Cmd.CommandText = "EXEC sp_Insert_POHdr '" & txt_TransNo.Text.Trim & "', '" & _
                              dt_PODate.Value.ToString("yyyy-MM-dd") & "', '" & _
                              txt_SupplierID.Text & "', '" & _
                              dt_TerimaBrg.Value.ToString("yyyy-MM-dd") & "', '" & _
                              txt_Remark.Text & "', '" & _
                              CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "', '" & _
                              CStr(CDec(txt_GrandTotal.Text)).Replace(",", ".") & "', '0', '" & _
                              StatusID & "', '" & _
                              RejectReason & "', '" & _
                              userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'Detail Data
            If RequestType.Trim = "Pembelian Barang" Then
                For Each item As DataRow In dt_dtl.Rows
                    If Not item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Insert_PODtl '" & _
                                        txt_TransNo.Text.Trim & "', '" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Item ID").ToString.Trim & "', '" & _
                                        Replace(CStr(item("Qty")), ",", ".") & "', '" & _
                                        item("UoM").ToString.Trim & "', '" & _
                                        Replace(CStr(CDec(item("Diskon"))), ",", ".") & "', '" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "', '" & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "', '" & _
                                        item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next
            ElseIf RequestType.Trim = "Pembelian Jasa" Then
                For Each item As DataRow In dt_dtl.Rows
                    If Not item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Insert_PO_Jasa_Dtl '" & txt_TransNo.Text.Trim + "','" & _
                                      item("PR No").ToString.Trim & "','" & _
                                      item("Jasa ID").ToString.Trim & "','" & _
                                      Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                      item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, userlog.UserName, "R", "N", StatusID) 'Insert to INBOX utk diri sendiri
            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to INBOX Purchasing
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "SUBMIT") 'Insert History transaction     

            If txt_TransNo.Text = "" Then
                ObjTrans.Rollback()
                MsgBox("Failed Save")
                Exit Sub
            End If

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Transaction No. : " & txt_TransNo.Text.Trim & " has been Submitted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("ts_save_Click: " & ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub Updatedata()
        Dim ObjTrans As SqlTransaction
        Dim remarks_Stok As String

        dtTable.Clear()

        If StatusTrans = "REJECT" Then
            If StatusID = "WAPH" Then
                StatusID = "RBPH"
            End If
        Else
            If StatusID = "WAPH" Then
                StatusID = "WCFR"
            ElseIf StatusID = "RBPH" Then
                StatusID = "WAPH"
            ElseIf StatusID = "WCFR" Then
                StatusID = "CMP"
            End If

        End If

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        'Header Data      
        Try

            remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())

            If Not (StatusID = "CMP" And rb_jasa.Checked = True) Then
                txt_InvAmt.Text = "0"
            End If

            'update PO Header
            Cmd.CommandText = "EXEC sp_Update_Trans_PO_Hdr '" & _
                                txt_TransNo.Text & "', '" & _
                                dt_PODate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                txt_SupplierID.Text.Trim & "', '" & _
                                dt_TerimaBrg.Value.ToString("yyyy-MM-dd") & "', '" & _
                                txt_Remark.Text & "', '" & _
                                CStr(CDec(txt_SubTotal.Text.Trim)).Replace(",", ".") & "', '" & _
                                CStr(CDec(txt_GrandTotal.Text.Trim)).Replace(",", ".") & "', '" & _
                                CStr(CDec(txt_InvAmt.Text.Trim)).Replace(",", ".") & "', '" & _
                                StatusID & "', '" & _
                                RejectReason & "', '" & _
                                userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            'update PO Detail
            If RequestType.Trim = "Pembelian Barang" Then
                For Each item As DataRow In dt_dtl.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_PODtl '" & _
                                        txt_TransNo.Text.Trim + "','" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Item ID").ToString.Trim & "','" & _
                                        Replace(CStr(item("Qty")), ",", ".") & "','" & _
                                        item("UoM").ToString.Trim & "','" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("Diskon"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()

                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PO_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Item_ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PO_Dtl '" & _
                                        txt_TransNo.Text.Trim & "','" & _
                                        item("PR No").ToString.Trim & "','" & _
                                        item("Item ID").ToString.Trim & "','" & _
                                        Replace(CStr(item("Qty")), ",", ".") & "','" & _
                                        item("UOM").ToString.Trim & "','" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("Diskon"))), ",", ".") & "','" & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next

            ElseIf RequestType.Trim = "Pembelian Jasa" Then
                For Each item As DataRow In dt_dtl.Rows
                    If item.RowState = DataRowState.Added Then
                        Cmd.CommandText = "EXEC sp_Insert_PO_Jasa_Dtl '" & _
                                        txt_TransNo.Text.Trim & "','" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Jasa ID").ToString.Trim & "','" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()
                    ElseIf item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_PO_Jasa_Dtl '" & _
                                        txt_TransNo.Text & "','" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Jasa ID", DataRowVersion.Original).ToString & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_PO_Jasa_Dtl '" & _
                                        txt_TransNo.Text.Trim + "','" & _
                                        item("PR No").ToString.Trim & "', '" & _
                                        item("Jasa ID").ToString.Trim & "','" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "','" & _
                                        item("Remarks") & "'"
                        Cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
            UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
            If StatusID <> "CMP" Then
                Select Case StatusTrans
                    Case "REJECT"
                        'NOTE: Jika Reject Maka Document Flow akan kembali ke Creator
                        InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                    Case Else
                        If StatusID.Trim = "WCFR" Then 'Authotisasi kembali ke si pembuat (requester)
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetDocCreator(txt_TransNo.Text.Trim), "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        Else
                            InserttoInbox(txt_TransNo.Text.Trim, userlog.UserName, GetApprover, "W", "Y", StatusID) 'Insert to NEXT APPROVAL
                        End If
                End Select
            End If

            If StatusID = "CMP" And rb_jasa.Checked = True Then
                Call InsertJurnal()
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

            ObjTrans.Commit()
            Conn.Close()
            Select Case StatusTrans
                Case "REJECT"
                    MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Rejected")
                Case Else
                    If GetDocCreator(txt_TransNo.Text.Trim) = userlog.UserName Then
                        If StatusID = "CMP" Then
                            MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Confirmed")
                        Else
                            MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Submitted")
                        End If
                    Else
                        MsgBox("Transaction : " & txt_TransNo.Text.Trim & " has been Approved")
                    End If
            End Select

        Catch ex As Exception
            MsgBox("ts_save_Click: " & ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub DeleteData()
        Try

            Dim ObjTrans As SqlTransaction
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            ObjTrans = Conn.BeginTransaction("Trans")
            Cmd.Transaction = ObjTrans

            Try
                StatusID = "CAP" 'cancelled by applicant

                Cmd.CommandText = "EXEC sp_Update_Trans_PO_Hdr '" & _
                                    txt_TransNo.Text & "', '" & _
                                    dt_PODate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                    txt_SupplierID.Text.Trim & "', '" & _
                                    dt_TerimaBrg.Value.ToString("yyyy-MM-dd") & "', '" & _
                                    txt_Remark.Text & "', '" & _
                                    CStr(CDec(txt_SubTotal.Text.Trim)).Replace(",", ".") & "', '" & _
                                    CStr(CDec(txt_GrandTotal.Text.Trim)).Replace(",", ".") & "', '0', '" & _
                                    StatusID & "', '" & _
                                    RejectReason & "', '" & _
                                    userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, userlog.UserName, "") 'Update Status utk Flow Teakhir
                UpdatetoInbox(txt_TransNo.Text.Trim, StatusID, GetDocCreator(txt_TransNo.Text.Trim), "1") 'Update Status utk Pemilik Document. utk mndpat status terakhir                
                Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                Conn.Close()
                MsgBox("Transaction No : " & txt_TransNo.Text & " has been Deleted", MsgBoxStyle.Information, "Information")
                Me.Close()
            Catch ex As Exception
                Conn.Close()
                MsgBox(ex.Message)
            End Try

            Me.Close()
        Catch ex As Exception
            MsgBox("DeleteData: " & ex.Message)
        End Try
    End Sub

    Private Function Validation() As Boolean
        Validation = True

        If dt_dtl.Rows.Count = 0 Then
            MsgBox("PO detail hasn't filled. Process has been cancelled")
            Validation = False
            Exit Function
        End If

        If txt_SupplierID.Text.Trim = "" Then
            MsgBox("Please fill Supplier ID")
            Validation = False
            txt_SupplierID.Focus()
            Exit Function
        End If

        If GetSupplier() = False Then
            Validation = False
        End If

        If StatusID = "WCFR" And rb_jasa.Checked = True And txt_InvAmt.Text.Trim = "" Then
            MsgBox("Please fill Invoice Amount")
            Validation = False
            txt_InvAmt.Focus()
            Exit Function
        End If

    End Function

    Private Function ValidationItem() As Boolean
        ValidationItem = True
        Try
            'PR No. must be filled
            If txt_PRNoItem.Text.Trim = "" Then
                MessageBox.Show("Please fill PR No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_PRNoItem.Focus()
                ValidationItem = False
                Exit Function
            End If

            'Validity PR No.
            If Conn.State = ConnectionState.Open Then Conn.Close()
            dtTable.Clear()

            Conn.Open()
            Cmd.CommandText = "SELECT PR_No FROM Trans_PR_Hdr WHERE PR_No = '" & txt_PRNoItem.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                MessageBox.Show("PR No. isn't valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_PRNoItem.Focus()
                ValidationItem = False
                Exit Function
            End If

            'Item ID must be filled
            If txt_ItemID.Text.Trim = "" Then
                MessageBox.Show("Please fill ITEM ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                ValidationItem = False
                Exit Function
            End If

            'Validity Item ID
            dt_item.Clear()
            GetItemData(txt_ItemID.Text.Trim)
            If dt_item.Rows.Count = 0 Then
                MessageBox.Show("ITEM ID isn't valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                ValidationItem = False
                Exit Function
            End If

            'QTY must be filled
            If Txt_Qty.Text.Trim = "" Or Txt_Qty.Text.Trim = "0" Then
                MessageBox.Show("Please fill QTY", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Txt_Qty.Focus()
                ValidationItem = False
                Exit Function
            End If

            If userlog.Insert_Price = "Y" Then
                If txt_Harga.Text.Trim = "" Or txt_Harga.Text.Trim = "0" Or txt_Harga.Text.Trim = "0,00" Then
                    MessageBox.Show("Please fill PRICE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    txt_Harga.Focus()
                    ValidationItem = False
                    Exit Function
                End If
            End If
        Catch ex As Exception
            MsgBox("ValidationItem " & ex.Message)
        End Try
    End Function

    Private Function ValidationJasa() As Boolean
        ValidationJasa = True
        Try
            '--PR must be filled
            If txt_PRNoJasa.Text.Trim = "" Then
                MessageBox.Show("Please fill PR No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_PRNoJasa.Focus()
                ValidationJasa = False
                Exit Function
            End If

            '--Validity PR No.
            If Conn.State = ConnectionState.Open Then Conn.Close()
            dtTable.Clear()

            Conn.Open()
            Cmd.CommandText = "SELECT PR_No FROM Trans_PR_HDr WHERE PR_No = '" & txt_PRNoJasa.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                MessageBox.Show("PR No. isn't valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_PRNoJasa.Focus()
                ValidationJasa = False
                Exit Function
            End If

            '--Jasa ID must be filled
            If txt_JasaID.Text.Trim = "" Then
                MessageBox.Show("Please fill JASA ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_JasaID.Focus()
                ValidationJasa = False
                Exit Function
            End If


            '--Validity Jasa ID
            If Conn.State = ConnectionState.Open Then Conn.Close()
            dtTable.Clear()

            Conn.Open()
            Cmd.CommandText = "SELECT Jasa_ID FROM Master_Jasa WHERE Jasa_ID = '" & txt_JasaID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                MessageBox.Show("JASA ID isn't valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_JasaID.Focus()
                ValidationJasa = False
                Exit Function
            End If

            If userlog.Insert_Price = "Y" Then
                If txt_JasaHarga.Text.Trim = "" Or txt_JasaHarga.Text.Trim = "0" Then
                    MessageBox.Show("Please fill PRICE", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    txt_JasaHarga.Focus()
                    ValidationJasa = False
                    Exit Function
                End If
            End If

        Catch ex As Exception
            MsgBox("ValdiationJasa: " & ex.Message)
        End Try

    End Function

    Private Sub CheckDetail()
        Dim count As Integer
        For Each item As DataRow In dt_dtl.Rows
            If item.RowState <> DataRowState.Deleted Then
                count += 1
            End If
        Next

        If count = 0 Then
            GroupBox1.Enabled = True
            dt_dtl.PrimaryKey = Nothing
            dt_dtl.Columns.Clear()
            Call SetColumnDetail()
        End If
    End Sub

    Private Sub GetDP()
        Dim dtPH As New DataTable

        If Conn.State = ConnectionState.Closed Then Conn.Open()
        Cmd.CommandText = "EXEC sp_Retrieve_Trans_PelunasanHutangSupplier_Dtl_ByDocNo '" & txt_TransNo.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dtPH)

        Select Case dtPH.Rows.Count
            Case 0
                txt_UangMuka.Text = 0
            Case Else
                txt_UangMuka.Text = FormatAngka(CDbl(dtPH.Rows(0).Item("Jumlah_Bayar")))
        End Select
    End Sub

    Private Sub InsertJurnal()
        Dim JurnalID As String
        Dim LastSerial As Integer

        If Conn.State = ConnectionState.Closed Then Conn.Open()

        JurnalID = Generate_TranNo("Journal")
        LastSerial = CInt(Microsoft.VisualBasic.Right(JurnalID, 3))

        'Jurnal Header
        Cmd.CommandText = "EXEC sp_Insert_Journal '" & JurnalID & "', '" & _
                    userlog.EmployeeID & "', '" & _
                    "PO', '" & _
                    "', '" & _
                    txt_TransNo.Text & "', '" & _
                    "False', '" & _
                    "', '" & _
                    "False', '" & _
                    "', '" & _
                    userlog.UserName & "'"
        Cmd.ExecuteNonQuery()

        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                  "663', '" & _
                                  CStr(CDec(txt_InvAmt.Text.Trim)).Replace(",", ".") & "', '" & _
                                  "0', '" & _
                                  "False', '" & _
                                  userlog.UserName & "'"
        Cmd.ExecuteNonQuery()

        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                            "323', '" & _
                            "0', '" & _
                            CStr(CDec(txt_InvAmt.Text.Trim)).Replace(",", ".") & "', '" & _
                            "False', '" & _
                            userlog.UserName & "'"
        Cmd.ExecuteNonQuery()

        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

    End Sub

#End Region

#Region "Event Handler - Header"

    Private Sub frmPO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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
                Dim frmChild As New frm_POPending
                For Each f As Form In Me.MdiChildren
                    If f.Name = "frm_POPending" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select
    End Sub

    Private Sub frmPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Conn.State = ConnectionState.Open Then Conn.Close()

        'SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_Edit, ts_delete, ts_save, ts_cancel, ts_print, ts_approve, ts_reject)

        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        If txt_TransNo.Text.ToString.Trim <> "" Then
            Call Load_POHeader()
            Call Load_PODetail()

            Select Case CheckAuthorisasi(txt_TransNo.Text.ToString.Trim, userlog.UserName)
                Case True
                    StatusTrans = TransStatus.NoStatus
                Case Else
                    StatusTrans = "READ"
            End Select

            StatusTransDetail = ""
            Call EnableInput(False)
            Call SetToolTip()

            Select Case RequestType
                Case "Pembelian Jasa"
                    Call EnableDisableInputDetailJasa()
                    Call SetButtonJasa()
                Case Else
                    Call EnableDisableInputDetailItem()
                    Call SetButtonItem()
            End Select
        Else
            lbl_status.Text = GetStatus("DRAFT")
            StatusID = "DRAFT"
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = "CANCEL"
            Call EnableInput(True)
            Call EnableDisableInputDetailItem()
            Call SetToolTip()
            Call SetButtonItem()
        End If
    End Sub

    Private Sub gv_PODtl_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_PODtl.CellClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If gv_PODtl.RowCount = 0 Then Exit Sub
        If RequestType = "Pembelian Barang" Then
            txt_PRNoItem.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("PR No").Value.ToString.Trim
            txt_ItemID.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Item ID").Value.ToString.Trim
            txt_ItemName.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Item Name").Value.ToString.Trim
            Txt_UoM.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("UOM").Value.ToString.Trim
            txt_Harga.Text = FormatAngka(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Price").Value.ToString.Trim)
            Txt_Qty.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Qty").Value.ToString.Trim
            txt_Ket.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Remarks").Value.ToString.Trim
            txt_Diskon.Text = FormatAngka(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Diskon").Value.ToString.Trim)
            txt_SubTotalTemp.Text = FormatAngka(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Subtotal").Value.ToString.Trim)

        ElseIf RequestType = "Pembelian Jasa" Then
            txt_PRNoJasa.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("PR No").Value.ToString.Trim
            txt_JasaID.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Jasa ID").Value.ToString.Trim
            txt_JasaName.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Jasa Name").Value.ToString.Trim
            txt_JasaHarga.Text = FormatAngka(gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Price").Value.ToString.Trim)
            txt_JasaKet.Text = gv_PODtl.Rows(gv_PODtl.CurrentCell.RowIndex).Cells("Remarks").Value.ToString.Trim

        End If
    End Sub

    Private Sub rb_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_item.CheckedChanged
        If rb_item.Checked = True Then
            RequestType = "Pembelian Barang"
            P_waItem.Visible = True
            P_waJasa.Visible = False
            txt_TotalQty.Visible = True
            lbl_TotalQty.Visible = True
        Else
            RequestType = "Pembelian Jasa"
            P_waItem.Visible = False
            P_waJasa.Visible = True
            txt_TotalQty.Visible = False
            lbl_TotalQty.Visible = False
        End If
        Call SetColumnDetail()
    End Sub

    Private Sub rb_jasa_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rb_item.Checked = True Then
            RequestType = "Pembelian Barang"
            P_waItem.Visible = True
            P_waJasa.Visible = False
            txt_TotalQty.Visible = True
            lbl_TotalQty.Visible = True
        Else
            RequestType = "Pembelian Jasa"
            P_waItem.Visible = False
            P_waJasa.Visible = True
            txt_TotalQty.Visible = False
            lbl_TotalQty.Visible = False
        End If
        Call SetColumnDetail()
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            frmPO_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus

            Select Case StatusID
                Case "WCFR"
                    StatusTransDetail = ""
                    Call EnableInput(False)

                    txt_InvAmt.ReadOnly = False
                    txt_InvAmt.ForeColor = Color.Black
                    txt_InvAmt.BackColor = Color.White
                Case Else
                    StatusTransDetail = "CANCEL"
                    Call EnableInput(True)
            End Select

            Select Case RequestType
                Case "Pembelian Jasa"
                    Call EnableDisableInputDetailJasa()
                    Call SetButtonJasa()
                Case Else
                    Call EnableDisableInputDetailItem()
                    Call SetButtonItem()
            End Select

            Call SetToolTip()
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to submit this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Validation() = False Then Exit Sub
                Select Case StatusTrans
                    Case TransStatus.NewStatus
                        Call InsertData()
                    Case TransStatus.EditStatus
                        Call Updatedata()
                End Select
                frmPO_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_approve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_approve.Click
        If MessageBox.Show("Are you sure to Approve this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Validation() = False Then Exit Sub

            StatusTrans = "APPROVE"
            Call Updatedata()
            Call frmPO_Load(False, e)
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
                    Call Updatedata()
                    Call frmPO_Load(False, e)
                    RejectReason = ""
                Else
                    MessageBox.Show("Pleasee fill reject reason !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        End If
    End Sub

    Private Sub ts_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_print.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm

        frmChild.PONo = txt_TransNo.Text

        If rb_item.Checked = True Then
            frmChild.ReportName = "Print PO Item"
        Else
            frmChild.ReportName = "Print PO Jasa"
        End If


        frmChild.Show()
    End Sub

    Private Sub txt_SupplierID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SupplierID.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Supp_id AS supplier_id, Nama as nama_Supplier,alamat,Telp,Fax FROM Master_Supplier WHERE active_flag = 'Y'", "Supplier_ID", "Nama_Supplier", "Alamat", "Telp", "Fax")

            txt_SupplierID.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_SupplierName.Text = frmSearch.txtResult2.Text.ToString.Trim
            gv_PODtl.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_SupplierID.Text.Trim <> "" Then
                GetSupplier()
                gv_PODtl.Focus()
            End If
        End If
    End Sub

    Private Sub btn_RecommendedSupp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RecommendedSupp.Click
        frmRecommededSupplier.ShowDialog()
        txt_SupplierID.Text = frmRecommededSupplier.txtSupplierID.Text
        txt_SupplierName.Text = frmRecommededSupplier.txtSupplierName.Text
    End Sub
#End Region

#Region "Detail - Item"

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim da As Data.DataRow
        Dim dc(1) As Data.DataColumn
        Dim arr(1)

        dc(0) = dt_dtl.Columns("PR No")
        dc(1) = dt_dtl.Columns("Item ID")
        dt_dtl.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose one for deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            arr(0) = txt_PRNoItem.Text.Trim
            arr(1) = txt_ItemID.Text.Trim
            da = dt_dtl.Rows.Find(arr)

            If da IsNot Nothing Then
                da.Delete()
                StatusTransDetail = "DELETE"
                Call SetButtonItem()
                Call EnableDisableInputDetailItem()
                gv_PODtl.Focus()

                Call CountQty()
                Call CountSubTotal()
                Call CountGrandTotal()

            End If
        End If

        If StatusID = "" Then Exit Sub
        Call CheckDetail()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Please choose one data to edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        StatusTransDetail = "UPDATE"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click

        If ValidationItem() = False Then Exit Sub
        Dim dc(1) As DataColumn
        Dim arr(1)
        Dim dr As DataRow

        dc(0) = dt_dtl.Columns("PR No")
        dc(1) = dt_dtl.Columns("Item ID")
        dt_dtl.PrimaryKey = dc

        If StatusTransDetail = "INSERT" Then
            arr(0) = txt_PRNoItem.Text
            arr(1) = txt_ItemID.Text
            dr_dtl = dt_dtl.Rows.Find(arr)
            If dr_dtl IsNot Nothing Then
                MessageBox.Show("Item: " & txt_ItemID.Text.Trim & " with PR No: " & txt_PRNoItem.Text.Trim & " is exist on Table, Please choose other Item ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else

                dr = dt_dtl.NewRow
                dr("PR No") = txt_PRNoItem.Text
                dr("Item ID") = txt_ItemID.Text
                dr("Item Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = Txt_Qty.Text

                If txt_Harga.Text = "" Then
                    dr("Price") = 0
                Else
                    dr("Price") = FormatAngka(CDbl(txt_Harga.Text))
                End If

                If txt_Diskon.Text = "" Then
                    dr("Diskon") = 0
                Else
                    dr("Diskon") = txt_Diskon.Text
                End If

                If txt_SubTotalTemp.Text = "" Then
                    dr("SubTotal") = 0
                Else
                    dr("SubTotal") = FormatAngka(CDbl(dr("Qty") * dr("Price")) - dr("Diskon"))
                End If

                dr("Remarks") = txt_Ket.Text
                dt_dtl.Rows.Add(dr)
            End If
        ElseIf StatusTransDetail = "UPDATE" Then
            arr(0) = txt_PRNoItem.Text
            arr(1) = txt_ItemID.Text
            dr = dt_dtl.Rows.Find(arr)

            If DA IsNot Nothing Then

                dr("Qty") = Txt_Qty.Text
                If txt_Harga.Text = "" Then
                    dr("Price") = 0
                Else
                    dr("Price") = FormatAngka(CDbl(txt_Harga.Text))
                End If

                If txt_Diskon.Text = "" Then
                    dr("Diskon") = 0
                Else
                    dr("Diskon") = FormatAngka(CDbl(txt_Diskon.Text))
                End If

                If txt_SubTotalTemp.Text = "" Then
                    dr("SubTotal") = 0
                Else
                    dr("SubTotal") = FormatAngka(CDbl((dr("Qty") * dr("Price")) - dr("Diskon")))
                End If
                dr("remarks") = txt_Ket.Text.Trim
            End If
        End If

        gv_PODtl.DataSource = dt_dtl

        'Untuk Refresh Grid
        gv_PODtl.Sort(gv_PODtl.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        gv_PODtl.Sort(gv_PODtl.Columns(0), System.ComponentModel.ListSortDirection.Ascending)


        Call CountQty()
        Call CountSubTotal()
        Call CountGrandTotal()

        GroupBox1.Enabled = False
        StatusTransDetail = "SAVE"

        Call SetButtonItem()
        Call EnableDisableInputDetailItem()
    End Sub

    Private Sub txt_Diskon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Diskon.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Diskon_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Diskon.Leave
        If txt_Diskon.Text.Trim = "" Then
            txt_Diskon.Text = 0
        End If

        If txt_SubTotalTemp.Text.Trim = "" Then
            txt_SubTotalTemp.Text = 0
        End If
        txt_Diskon.Text = FormatAngka(CDbl(txt_Diskon.Text))
        txt_SubTotalTemp.Text = FormatAngka(CDbl(CDec(txt_SubTotalTemp.Text) - CDec(txt_Diskon.Text)))
        txt_Ket.Focus()
    End Sub

    Private Sub txt_Harga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Harga.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Harga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Harga.Leave
        If txt_Harga.Text.Trim = "" Then
            txt_Harga.Text = 0
        End If
        txt_SubTotalTemp.Text = FormatAngka(CDbl((CInt(Txt_Qty.Text) * CDec(txt_Harga.Text))))
        txt_Harga.Text = FormatAngka(CDbl(txt_Harga.Text.Trim))
        txt_Diskon.Focus()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Item_id, Item_Name, UoM FROM Master_Item_Hdr WHERE active_flag = 'Y'", "Item_ID", "Item_Name", "UoM", "Harga", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    GetItemData(frmSearch.txtResult1.Text.ToString.Trim)
                    If dt_item.Rows.Count > 0 Then
                        txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                        txt_ItemName.Text = dt_item.Rows(0).Item("Item_name").ToString
                        Txt_UoM.Text = dt_item.Rows(0).Item("UoM").ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ID can't be found ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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
                    dt_dtl.Clear()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dt_dtl)

                    If dt_dtl.Rows.Count > 0 Then
                        txt_ItemName.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dt_dtl.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ini tidak ditemukan. Pastikan nomor Item yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
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

    Private Sub txt_Ket_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Ket.Leave
        btn_save.Focus()
    End Sub

    Private Sub txt_PRNoItem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PRNoItem.KeyDown
        If e.KeyCode = Keys.F1 And txt_PRNoItem.Enabled = True Then
            Try
                CallandGetSearchData("sp_Retrieve_Trans_PR_ByTypeRequest '" & RequestType & "'", "PR No", "Item ID", "Item Name", "UoM", "Qty")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Open Then Conn.Close()

                    txt_PRNoItem.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_ItemID.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_ItemName.Text = frmSearch.txtResult3.Text.ToString.Trim
                    Txt_UoM.Text = frmSearch.txtResult4.Text.ToString.Trim
                    Txt_Qty.Text = frmSearch.txtResult5.Text.ToString.Trim
                    txt_Harga.Text = 0
                    txt_Diskon.Text = 0
                    txt_SubTotalTemp.Text = 0

                End If
            Catch ex As Exception
                MsgBox("txt_PRNoItem_KeyDown: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Txt_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Qty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_Qty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Qty.Leave
        If Txt_Qty.Text.Trim = "" Then
            Txt_Qty.Text = 0
        End If
    End Sub

    Private Sub txt_SubTotalTemp_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SubTotalTemp.Leave
        If txt_SubTotalTemp.Text.Trim = "" Then
            txt_SubTotalTemp.Text = 0
        End If
    End Sub

    Private Sub txt_InvAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_InvAmt.Leave
        FormatAngka(CDbl(txt_InvAmt.Text))
    End Sub

#End Region

#Region "Detail Jasa"

    Private Sub txt_InvAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_InvAmt.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub btn_cancelJasa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelJasa.Click
        StatusTransDetail = "CANCEL"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_deleteJasa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_deleteJasa.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        Dim arr(1)

        arr(0) = txt_PRNoJasa.Text.Trim
        arr(1) = txt_JasaID.Text.Trim
        dc(0) = dt_dtl.Columns("PR No")
        dc(1) = dt_dtl.Columns("Jasa ID")
        dt_dtl.PrimaryKey = dc

        If txt_JasaID.Text.Trim = "" Then
            MessageBox.Show("Please choose one data to deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            da = dt_dtl.Rows.Find(arr)
            If da IsNot Nothing Then
                da.Delete()
                StatusTransDetail = "DELETE"
                Call SetButtonItem()
                Call EnableDisableInputDetailJasa()
                gv_PODtl.Focus()

                Call CountQty()
                Call CountSubTotal()
                Call CountGrandTotal()

            End If
        End If

        If StatusID = "" Then Exit Sub
        Call CheckDetail()
    End Sub

    Private Sub btn_editJasa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_editJasa.Click
        If txt_JasaID.Text.Trim = "" Then Exit Sub
        StatusTransDetail = "UPDATE"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_InsertJasa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_InsertJasa.Click
        StatusTransDetail = "INSERT"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub btn_SaveJasa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_SaveJasa.Click
        If ValidationJasa() = False Then Exit Sub

        Dim dc(1) As DataColumn
        Dim dr As Data.DataRow
        Dim arr(1)

        arr(0) = txt_PRNoJasa.Text.Trim
        arr(1) = txt_JasaID.Text.Trim
        dc(0) = dt_dtl.Columns("PR No")
        dc(1) = dt_dtl.Columns("Jasa ID")
        dt_dtl.PrimaryKey = dc

        If StatusTransDetail = "INSERT" Then
            dr_dtl = dt_dtl.Rows.Find(arr)
            If dr_dtl IsNot Nothing Then
                MessageBox.Show("Item: " & txt_JasaID.Text.Trim & " with PR No: " & txt_PRNoJasa.Text.Trim & " is exist on Table, Please choose other Item ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                txt_ItemID.Focus()
                Exit Sub
            Else
                dr = dt_dtl.NewRow
                dr("PR No") = txt_PRNoJasa.Text
                dr("Jasa ID") = txt_JasaID.Text
                dr("Jasa Name") = txt_JasaName.Text

                If txt_JasaHarga.Text = "" Then
                    dr("Price") = 0
                Else
                    dr("Price") = FormatAngka(CDbl(txt_JasaHarga.Text))
                End If

                dr("Remarks") = txt_JasaKet.Text
                dt_dtl.Rows.Add(dr)
            End If
        ElseIf StatusTransDetail = "UPDATE" Then
            dr = dt_dtl.Rows.Find(arr)
            If dr IsNot Nothing Then
                dr("Price") = FormatAngka(CDbl(txt_JasaHarga.Text))
                dr("remarks") = txt_JasaKet.Text.Trim
            End If
        End If

        gv_PODtl.DataSource = dt_dtl

        'Untuk Refresh Grid
        gv_PODtl.Sort(gv_PODtl.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        gv_PODtl.Sort(gv_PODtl.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        Call CountSubTotal()

        GroupBox1.Enabled = False
        StatusTransDetail = "SAVE"
        Call SetButtonJasa()
        Call EnableDisableInputDetailJasa()
    End Sub

    Private Sub txt_JasaHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_JasaHarga.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_JasaHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_JasaHarga.Leave
        If txt_JasaHarga.Text.Trim = "" Then
            txt_JasaHarga.Text = 0
        End If

        txt_JasaHarga.Text = FormatAngka(CDbl(txt_JasaHarga.Text))
        txt_JasaKet.Focus()
    End Sub

    Private Sub txt_JasaID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_JasaID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT Jasa_id,Jasa_Name FROM Master_Jasa WHERE active_flag = 'Y'", "Jasa_ID", "Jasa_Name", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Closed Then
                        Conn.Open()
                    End If

                    txt_JasaID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_JasaName.Text = frmSearch.txtResult2.Text.ToString.Trim
                Else
                    MessageBox.Show("Jasa ID can't be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        End If
        Conn.Close()
    End Sub

    Private Sub txt_PRNoJasa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PRNoJasa.KeyDown
        If e.KeyCode = Keys.F1 And txt_PRNoJasa.Enabled = True Then
            Try
                CallandGetSearchData("sp_Retrieve_Trans_PR_ByTypeRequest '" & RequestType & "'", "PR No", "Jasa ID", "Jasa Name", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    If Conn.State = ConnectionState.Open Then Conn.Close()

                    txt_PRNoJasa.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_JasaID.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txt_JasaName.Text = frmSearch.txtResult3.Text.ToString.Trim
                    txt_JasaHarga.Text = 0

                End If
            Catch ex As Exception
                MsgBox("txt_PRNoJasa_KeyDown: " & ex.Message)
            End Try
        End If
    End Sub

#End Region
End Class

