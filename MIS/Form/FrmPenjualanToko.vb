Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmPenjualanToko

#Region "Variable Declaration"

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private StatusTransDetail As String
    Private StatusTrans As String
    Private dtHeader As New DataTable
    Private dtDetail As New DataTable
    Private dtDetailOriginal As New DataTable
    Private dr As DataRow

    Public CallerForm As String
    Public ViewFormName As String
#End Region

#Region "Function & Procedure"

    Private Sub CheckDetail()
        If txt_CustName.Text.ToUpper.Trim <> "CASH" Then Exit Sub
        Dim count As Integer
        For Each item As DataRow In dtDetail.Rows
            If item.RowState <> DataRowState.Deleted Then
                count += 1
            End If
        Next

        If count = 0 Then
            cb_CustGroupPrice.Enabled = True
            dtDetail.PrimaryKey = Nothing
            dtDetail.Columns.Clear()
            Call SetColumn()
        End If
    End Sub

    Private Sub CountSubTotal()
        Dim count As Double

        For i As Integer = 0 To gv_Toko.Rows.Count - 1
            count += gv_Toko.Rows(i).Cells(GlobalVar.Fields.SubTotal).Value
        Next

        txt_SubTotal.Text = FormatAngka(CDbl(count))
    End Sub

    Private Sub CountGrandTotal()
        Dim GT, ST, PN, KRM, DP As Double

        GT = ST = PN = KRM = 0
        If txt_SubTotal.Text.Trim <> "" Then
            ST = CDbl(txt_SubTotal.Text)
        End If
        If txt_PPN.Text.Trim <> "" Then
            PN = (CDbl(txt_PPN.Text) * ST) / 100
        End If
        If txt_SubDiskon.Text.Trim <> "" Then
            KRM = CDbl(txt_SubDiskon.Text)
        End If
        If txt_UangMuka.Text.Trim <> "" Then
            DP = CDbl(txt_UangMuka.Text)
        End If
        GT = ST + PN - KRM - DP
        txt_GrandTotal.Text = FormatAngka(CDbl(GT))
    End Sub

    Private Sub CountQty()
        Dim qty As Integer = 0

        For i As Integer = 0 To gv_Toko.Rows.Count - 1
            qty += gv_Toko.Rows(i).Cells(GlobalVar.Fields.Qty).Value
        Next

        txt_TotalQty.Text = CStr(qty)
    End Sub

    Private Sub ClearInput()
        txt_Remark.Clear()
        txt_PPN.Clear()
        txt_CustID.Clear()
        txt_CustName.Clear()
        txt_PPN.Clear()
        txt_TotalQty.Clear()
        txt_SubDiskon.Clear()
        txt_UangMuka.Clear()
        txt_Remark.Clear()
        gv_Toko.DataSource = ""
    End Sub

    Private Sub EnableInput(ByVal boo As Boolean)
        dt_InvoiceDate.Enabled = boo
        txt_Remark.Enabled = boo
        gv_Toko.Enabled = boo
        txt_PPN.Enabled = boo
        txt_SubDiskon.Enabled = boo
        txt_UangMuka.Enabled = boo
        dt_PayType.Enabled = boo
        txt_Remark.Enabled = boo
        txt_CustID.Enabled = boo
    End Sub

    Private Sub InsertData()
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim remarks_Stok As String

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try

            txt_TransNo.Text = Generate_TranNo(Me.Name)
            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))

            remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & " - [ Item has been INSERTED ] "


            Cmd.CommandText = "EXEC sp_Insert_PenjualanToko_Hdr '" & txt_TransNo.Text.Trim & "', '" & _
                                         dt_InvoiceDate.Value.ToString("yyyy-MM-dd") & "', '" & _
                                         txt_CustID.Text & "','" & _
                                         CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_PPN.Text)).Replace(",", ".") & "','" & _
                                         CStr(CDec(txt_SubDiskon.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_GrandTotal.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_UangMuka.Text)).Replace(",", ".") & "', '" & _
                                         dt_PayType.Value.ToString("yyyy-MM-dd") & "', '" & _
                                         txt_Remark.Text & "', '" & _
                                         "','" & _
                                         userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            For Each item As DataRow In dtDetail.Rows
                If item.RowState <> DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Insert_PenjualanToko_Dtl '" & _
                                        txt_TransNo.Text & "', '" & _
                                        item("Item ID") & "', '" & _
                                        item("Qty") & "', '" & _
                                        Replace(CStr(CDec(item("Price"))), ",", ".") & "', '" & _
                                        Replace(CStr(CDec(item("Discount"))), ",", ".") & "', '" & _
                                        Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "'"
                    Cmd.ExecuteNonQuery()

                    Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "OUT", item("Qty"), remarks_Stok)
                End If

            Next

            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "INSERT")
            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

            ObjTrans.Commit()
            Conn.Close()

            MsgBox("Invoice No.: " & txt_TransNo.Text.Trim & " Has been Saved")
        Catch ex As Exception
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateData()
        Dim ObjTrans As SqlTransaction
        Dim remarks_Stok As String
        Dim dc(0) As DataColumn
        Dim RowOriginal As DataRow

        dc(0) = dtDetailOriginal.Columns("Item ID")
        dtDetailOriginal.PrimaryKey = dc

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            txt_PPN.Text = 0

            Cmd.CommandText = "EXEC sp_Delete_Trans_PenjualanToko_DFD '" & txt_TransNo.Text.Trim & "'"
            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "EXEC sp_Insert_PenjualanToko_Hdr '" & txt_TransNo.Text.Trim & "','" & _
                                         dt_InvoiceDate.Value.ToString("yyyy-MM-dd") & "','" & _
                                         txt_CustID.Text & "','" & _
                                         CStr(CDec(txt_SubTotal.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_PPN.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_SubDiskon.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_GrandTotal.Text)).Replace(",", ".") & "', '" & _
                                         CStr(CDec(txt_UangMuka.Text)).Replace(",", ".") & "', '" & _
                                         dt_PayType.Value.ToString("yyyy-MM-dd") & "', '" & _
                                         txt_Remark.Text & "', '" & _
                                         "', '" & _
                                         userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            For Each item As DataRow In dtDetail.Rows
                If item.RowState <> DataRowState.Deleted Then
                    Cmd.CommandText = "EXEC sp_Insert_PenjualanToko_Dtl '" & _
                                           txt_TransNo.Text & "', '" & _
                                           item("Item ID") & "', '" & _
                                           item("Qty") & "', '" & _
                                           Replace(CStr(CDec(item("Price"))), ",", ".") & "', '" & _
                                           Replace(CStr(CDec(item("Discount"))), ",", ".") & "', '" & _
                                           Replace(CStr(CDec(item("SubTotal"))), ",", ".") & "'"
                    Cmd.ExecuteNonQuery()

                    RowOriginal = dtDetailOriginal.Rows.Find(item("Item ID"))
                    If RowOriginal IsNot Nothing Then
                        'Case Item sudah pernah di-insert lalu di-revisi
                        If RowOriginal("Qty") <> item("Qty") Then
                            remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & _
                                           " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                           " - [ QTY Item has been UPDATED from " & CStr(RowOriginal("Qty")) & " to " & CStr(item("Qty")) & " ]"
                            Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "OUT", item("Qty"), remarks_Stok)
                            Insert_StokMovement_Toko(RowOriginal("Item ID"), txt_TransNo.Text.Trim, "IN", RowOriginal("Qty"), remarks_Stok)
                        End If
                    Else
                        'Case Item belum pernah di-insert
                        remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                       " - [ Item has been INSERTED ] "
                        Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "OUT", item("Qty"), remarks_Stok)
                    End If
                Else
                    RowOriginal = dtDetailOriginal.Rows.Find(item("Item ID", DataRowVersion.Original))
                    'Case Item sudah pernah di-insert lalu di-delete
                    If RowOriginal IsNot Nothing Then
                        remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                                       " - [ Item has been DELETED ] "
                        Insert_StokMovement_Toko(RowOriginal("Item ID"), txt_TransNo.Text.Trim, "IN", RowOriginal("Qty"), remarks_Stok)
                    End If
                End If

            Next

            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "UDPATE")

            ObjTrans.Commit()
            Conn.Close()

            MsgBox("Invoice No.: " & txt_TransNo.Text.Trim & " Has been Saved")
        Catch ex As Exception
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteData()
        Dim ObjTrans As SqlTransaction
        Dim remarks_Stok As String

        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.Open()

        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            remarks_Stok = "Transaction : " & txt_TransNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now()) & _
                           " - [ Item has been DELETED ] "
            Cmd.CommandText = "EXEC sp_Delete_Trans_PenjualanToko '" & txt_TransNo.Text.Trim & "', '" & userlog.UserName & "'"
            Cmd.ExecuteNonQuery()

            For Each item As DataRow In dtDetailOriginal.Rows
                Insert_StokMovement_Toko(item("Item ID"), txt_TransNo.Text.Trim, "IN", item("Qty"), remarks_Stok)
            Next

            Insert_Trans_History(txt_TransNo.Text.Trim, Me.Name, "DELETE")

            ObjTrans.Commit()
            Conn.Close()
            MsgBox("Invoice No.: " & txt_TransNo.Text.Trim & " Has been Deleted")
            Me.Close()

        Catch ex As Exception
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RetrieveData()
        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()

            dtHeader.Clear()
            dtDetail.Clear()
            dtDetailOriginal.Clear()

            'Get Header Data
            Cmd.CommandText = "sp_Retreive_Trans_PenjualanToko_Hdr '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtHeader)

            If dtHeader.Rows.Count = 0 Then Exit Sub

            dt_InvoiceDate.Value = dtHeader.Rows(0).Item("PT_Date")
            txt_CustID.Text = dtHeader.Rows(0).Item("Cust_ID")
            txt_CustName.Text = dtHeader.Rows(0).Item("Nama")
            txt_SubTotal.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("SubTotal")))
            txt_PPN.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("PPN")))
            txt_SubDiskon.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("Diskon")))
            txt_GrandTotal.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("Grand_Total")))
            txt_UangMuka.Text = FormatAngka(CDbl(dtHeader.Rows(0).Item("DP")))
            dt_PayType.Value = dtHeader.Rows(0).Item("dt_duedtPayment")
            txt_Remark.Text = dtHeader.Rows(0).Item("Remarks").ToString.Trim
            cb_CustGroupPrice.SelectedItem = dtHeader.Rows(0).Item("Cust_Group_Price").ToString.Trim

            'Get Detail Data
            Cmd.CommandText = "sp_Retreive_Trans_PenjualanToko_Dtl '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetail)

            Cmd.CommandText = "sp_Retreive_Trans_PenjualanToko_Dtl '" & txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtDetailOriginal)

            If dtDetail.Rows.Count = 0 Then Exit Sub
            gv_Toko.DataSource = ""
            gv_Toko.DataSource = dtDetail

            Conn.Close()
        Catch ex As Exception
            MsgBox("RetrieveData: " & ex.Message)
        End Try

    End Sub

    Private Sub SetGrid()
        gv_Toko.Columns(0).Width = 60
        gv_Toko.Columns(1).Width = 300
        gv_Toko.Columns(2).Width = 50
        gv_Toko.Columns(3).Width = 50
        gv_Toko.Columns(4).Width = 100
        gv_Toko.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Toko.Columns(4).DefaultCellStyle.Format = "#,##0.#0"
        gv_Toko.Columns(5).Width = 100
        gv_Toko.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Toko.Columns(5).DefaultCellStyle.Format = "#,##0.#0"
        gv_Toko.Columns(6).Width = 100
        gv_Toko.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv_Toko.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
    End Sub

    Private Sub SetColumn()
        dtDetail.Columns.Add("Item ID")
        dtDetail.Columns.Add("Item Name")
        dtDetail.Columns.Add("UoM")
        dtDetail.Columns.Add("Qty")
        dtDetail.Columns.Add("Price")
        dtDetail.Columns.Add("Discount")
        dtDetail.Columns.Add("SubTotal")
    End Sub

    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                ts_Edit.Visible = False
                ts_save.Visible = True
                ts_cancel.Visible = True
                ts_delete.Visible = False
            Case TransStatus.EditStatus
                ts_Edit.Visible = False
                ts_cancel.Visible = True
                ts_save.Visible = True
                ts_delete.Visible = False
            Case Else
                ts_Edit.Visible = True
                ts_delete.Visible = True
                ts_save.Visible = False
                ts_cancel.Visible = False
        End Select
    End Sub

    Private Function Validation() As Boolean
        Dim dtTable As New DataTable
        Validation = True

        If gv_Toko.Rows.Count = 0 Then
            Validation = False
            MsgBox("Detail ITEM hasn't filled. Process Cancelled")
            Exit Function
        End If

        If txt_CustID.Text.Trim = "" Then
            Validation = False
            MsgBox("Please fill Customer ID", MsgBoxStyle.Information, "Information")
            txt_CustID.Focus()
            Exit Function
        Else
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey '" & txt_CustID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                Validation = False
                MsgBox("Invalid Customer ID", MsgBoxStyle.Information, "Information")
                txt_CustID.Focus()
                Exit Function
            End If
        End If

        If txt_SubTotal.Text = "" Then
            txt_SubTotal.Text = 0
        End If

        If txt_UangMuka.Text = "" Then
            txt_UangMuka.Text = 0
        End If

        If txt_SubDiskon.Text = "" Then
            txt_SubDiskon.Text = 0
        End If

        If txt_PPN.Text = "" Then
            txt_PPN.Text = 0
        End If
    End Function

    Private Sub Insert_StokMovement_Toko(ByVal ItemId As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from Trans_Stock_Movement_toko where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        maxSeq = dt.Rows(0).Item("MaxSeq")
        maxSeq += 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement_Toko '" & _
                            Generate_Period() & "', '" & _
                            ItemId & "', '" & _
                            TransNo_Ref & "', '" & _
                            maxSeq & "', '" & _
                            Sts_Proses & "', '" & _
                            Qty & "','" & _
                            Remarks & "', '" & _
                            userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
    End Sub

#End Region

#Region "Event Handler"

    Private Sub FrmPenjualanToko_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            Case Else
                Dim frmChild As New frmViewPenjualanToko
                For Each f As Form In Me.MdiChildren
                    If f.Name = "FormViewPenjualanToko" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next
                frmChild.MdiParent = MDIFrm
                frmChild.Show()
        End Select

    End Sub

    Private Sub FrmPenjualanToko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Conn.State = ConnectionState.Open Then Conn.Close()

        SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_Edit, ts_delete, ts_save, ts_cancel, Nothing, Nothing, Nothing)

        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        If txt_TransNo.Text.ToString.Trim <> "" Then
            Call RetrieveData()
            StatusTrans = TransStatus.NoStatus
            StatusTransDetail = ""
            Call EnableInput(False)
            Call EnableDetail()
            Call SetToolTip()
            Call SetButton()
            Call SetGrid()
            Call CountQty()
        Else
            StatusTrans = TransStatus.NewStatus
            StatusTransDetail = "CANCEL"
            Call EnableInput(True)
            Call EnableDetail()
            Call SetToolTip()
            Call SetButton()
            Call SetColumn()

            gv_Toko.DataSource = dtDetail
            Call SetGrid()
        End If

    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            Call FrmPenjualanToko_Load(False, e)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            StatusTransDetail = "CANCEL"
            EnableInput(True)
            EnableDetail()
            SetButton()
            SetToolTip()
        End If
    End Sub

    Private Sub ts_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_delete.Click
        If StatusTrans = TransStatus.NoStatus Then
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
            End If
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If MessageBox.Show("Are you sure to SAVE this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Validation() = False Then Exit Sub
                Select Case StatusTrans
                    Case TransStatus.NewStatus
                        Call InsertData()
                    Case TransStatus.EditStatus
                        Call UpdateData()
                End Select
                FrmPenjualanToko_Load(False, e)
            End If
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub txt_CustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CustID.KeyDown

        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("EXEC sp_Retrieve_Master_Customer", "Cust_ID", "Nama", "Cust_Group_Price", "", "")
            txt_CustID.Text = frmSearch.txtResult1.Text.Trim
            txt_CustName.Text = frmSearch.txtResult2.Text.Trim
            cb_CustGroupPrice.SelectedItem = frmSearch.txtResult3.Text.Trim

            If txt_CustName.Text.ToUpper.Trim = "CASH" Then
                cb_CustGroupPrice.Enabled = True
            Else
                cb_CustGroupPrice.Enabled = False
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_CustID.Text.Trim = "" Then
                MsgBox("Please fill Customer ID")
                txt_CustID.Focus()
                Exit Sub
            End If

            Dim dtTable As New DataTable
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Cmd.CommandText = "SELECT * FROM Master_Customer WHERE Active_Flag = 'Y' AND Cust_ID = '" & txt_CustID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                MsgBox("Invalid Customer ID")
                txt_CustID.Focus()
                Exit Sub
            End If

            txt_CustID.Text = dtTable.Rows(0).Item("Cust_ID")
            txt_CustName.Text = dtTable.Rows(0).Item("Nama")
            cb_CustGroupPrice.SelectedItem = dtTable.Rows(0).Item("Cust_Group_Price")

            If txt_CustName.Text.ToUpper.Trim = "CASH" Then
                cb_CustGroupPrice.Enabled = True
            Else
                cb_CustGroupPrice.Enabled = False
            End If
        ElseIf e.KeyCode = Keys.Back Then
            txt_CustName.Clear()
            cb_CustGroupPrice.SelectedItem = ""
            cb_CustGroupPrice.Enabled = False
        End If
    End Sub

    Private Sub txt_PPN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PPN.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_UangMuka_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_UangMuka.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_PPN_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_PPN.LostFocus
        If txt_PPN.Text = "" Then txt_PPN.Text = 0
        txt_PPN.Text = FormatAngka(CDbl(txt_PPN.Text))
        Call CountGrandTotal()
    End Sub

    Private Sub txt_SubDiskon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_SubDiskon.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_SubDiskon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SubDiskon.LostFocus
        If txt_SubDiskon.Text = "" Then txt_SubDiskon.Text = 0
        txt_SubDiskon.Text = FormatAngka(CDbl(txt_SubDiskon.Text))
        Call CountGrandTotal()
    End Sub

#End Region

#Region "Event Handler - Detail"

    Private Function ValidationDetail() As Boolean
        Dim dc(0) As DataColumn
        Dim dtTable As New DataTable

        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc
        ValidationDetail = True

        If txt_ItemID.Text.Trim = "" Then
            ValidationDetail = False
            MsgBox("Item ID must be filled", MsgBoxStyle.Information, "Information")
            txt_ItemID.Focus()
            Exit Function
        End If

        If StatusTransDetail = "INSERT" Then
            dr = dtDetail.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                ValidationDetail = False
                MsgBox("Item ID has been exist", MsgBoxStyle.Information, "Inforamtion")
                Exit Function
            End If
        End If

        Try
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Conn.Open()
            Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr_ByItemID '" & txt_ItemID.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then
                ValidationDetail = False
                MsgBox("Item ID isn't exist in Master Data", MsgBoxStyle.Information, "Information")
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        
        If Txt_Qty.Text.Trim = "" Or Txt_Qty.Text.Trim = 0 Then
            ValidationDetail = False
            MsgBox("Qty must be filled", MsgBoxStyle.Information, "Information")
            Txt_Qty.Focus()
            Exit Function
        End If

        If txt_Harga.Text.Trim = "" Or txt_Harga.Text.Trim = 0 Then
            ValidationDetail = False
            MsgBox("Price must be filled", MsgBoxStyle.Information, "Information")
            txt_Harga.Focus()
            Exit Function
        End If

       
    End Function

    Private Sub SetButton()
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

    Private Sub EnableDetail()
        Select Case StatusTransDetail.ToUpper
            Case "INSERT"
                txt_ItemID.Enabled = True
                Txt_Qty.Enabled = True
                txt_Diskon.Enabled = True

                txt_ItemID.BackColor = Color.LemonChiffon
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Diskon.BackColor = Color.LemonChiffon
            Case "UPDATE"
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = True
                txt_Diskon.Enabled = True

                txt_ItemID.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.LemonChiffon
                txt_Diskon.BackColor = Color.LemonChiffon
            Case Else
                txt_ItemID.Enabled = False
                Txt_Qty.Enabled = False
                txt_Diskon.Enabled = False

                txt_ItemID.Clear()
                txt_ItemName.Clear()
                Txt_UoM.Clear()
                Txt_Qty.Clear()
                txt_Harga.Clear()
                txt_Diskon.Clear()
                txt_SubTotalTemp.Clear()

                txt_ItemID.BackColor = Color.DarkGray
                Txt_Qty.BackColor = Color.DarkGray
                txt_Diskon.BackColor = Color.DarkGray
        End Select

    End Sub

    Private Sub ClearDetail()
        txt_ItemID.Clear()
        txt_ItemName.Clear()
        Txt_UoM.Clear()
        Txt_Qty.Clear()
        txt_Harga.Clear()
        txt_Diskon.Clear()
        txt_SubTotalTemp.Clear()
    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        Dim dtTable As New DataTable

        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("SELECT a.Item_id AS [Item ID], Item_Name AS [Item Name], UoM, Sales_Price AS Price FROM Master_Item_Hdr a INNER JOIN Maintain_SalesPrice_Item b ON a.Item_ID = b.Item_ID AND Price_Type = '" & cb_CustGroupPrice.SelectedItem & "'", "Item ID", "Item Name", "UoM", "Price", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txt_ItemID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txt_ItemName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    Txt_UoM.Text = frmSearch.txtResult3.Text.ToString.Trim
                    txt_Harga.Text = FormatAngka(CDbl(frmSearch.txtResult4.Text.Trim))
                    Txt_Qty.Focus()
                End If
            Catch ex As Exception
                MsgBox("txt_ItemID_KeyDown: " & ex.Message)
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_ItemID.Text.Trim <> "" Then
                Try
                    If Conn.State = ConnectionState.Open Then Conn.Close()

                    Conn.Open()
                    Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr '" & txt_ItemID.Text.Trim & "'"
                    DA.SelectCommand = Cmd
                    DA.Fill(dtTable)
                    Conn.Close()

                    If dtTable.Rows.Count > 0 Then
                        txt_ItemName.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_Name).ToString
                        Txt_UoM.Text = dtTable.Rows(0).Item(GlobalVar.Fields.Item_UOM).ToString
                        Txt_Qty.Focus()
                    Else
                        MessageBox.Show("Item ID can't be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("txt_ItemID_KeyDown: " & ex.Message)
                    Conn.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        StatusTransDetail = "CANCEL"
        Call SetButton()
        Call EnableDetail()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(0) As DataColumn
        Dim dr As Data.DataRow
        dc(0) = dtDetail.Columns("Item ID")
        dtDetail.PrimaryKey = dc

        If txt_ItemID.Text.Trim = "" Then
            MessageBox.Show("Please choose one to deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure to delete this row ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then

            dr = dtDetail.Rows.Find(txt_ItemID.Text)
            If dr IsNot Nothing Then
                dr.Delete()
                StatusTransDetail = "DELETE"
                Call SetButton()
                Call EnableDetail()
                Call CountQty()
                Call CountSubTotal()
                Call CountGrandTotal()
                Call CheckDetail()
                gv_Toko.Focus()
            End If
        End If
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Please choose one to edited", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        StatusTransDetail = "UPDATE"
        Call SetButton()
        Call EnableDetail()
    End Sub

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insert.Click
        StatusTransDetail = "INSERT"
        Call SetButton()
        Call EnableDetail()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dr As Data.DataRow

        If ValidationDetail() = False Then Exit Sub

        Select Case StatusTransDetail
            Case "INSERT"
                dr = dtDetail.NewRow
                dr("Item ID") = txt_ItemID.Text.Trim
                dr("Item Name") = txt_ItemName.Text
                dr("UoM") = Txt_UoM.Text
                dr("Qty") = Txt_Qty.Text
                dr("Price") = FormatAngka(CDbl(txt_Harga.Text))
                dr("SubTotal") = FormatAngka(CDbl(txt_SubTotalTemp.Text))
                dr("Discount") = FormatAngka(CDbl(txt_Diskon.Text))

                dtDetail.Rows.Add(dr)

            Case "UPDATE"
                dr = dtDetail.Rows.Find(txt_ItemID.Text)

                If dr IsNot Nothing Then

                    dr("Qty") = Txt_Qty.Text
                    dr("Price") = FormatAngka(CDbl(txt_Harga.Text))
                    dr("SubTotal") = FormatAngka(CDbl(txt_SubTotalTemp.Text))
                    dr("Discount") = FormatAngka(CDbl(txt_Diskon.Text))
                End If
        End Select
        gv_Toko.DataSource = dtDetail
        StatusTransDetail = "SAVE"
        cb_CustGroupPrice.Enabled = False

        Call CountQty()
        Call CountSubTotal()
        Call CountGrandTotal()
        Call SetButton()
        Call EnableDetail()

    End Sub

    Private Sub txt_Harga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Harga.KeyDown
        If e.KeyCode = Keys.F1 Then
            Try
                If txt_ItemID.Text.Trim = "" Then Exit Sub
                CallandGetSearchData("SELECT Item_ID AS [Item ID], Price_Type AS [Price Type], Sales_Price AS [Price] FROM Maintain_SalesPrice_Item WHERE Item_ID ='" & txt_ItemID.Text.Trim & "'", "Item ID", "Price Type", "Price", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txt_Harga.Text = FormatAngka(CDbl(frmSearch.txtResult3.Text.ToString.Trim))
                    txt_Diskon.Focus()
                End If
            Catch ex As Exception
                MsgBox("txt_ItemID_KeyDown: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub txt_Harga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Harga.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Harga_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Harga.LostFocus
        If txt_Harga.Text = "" Then txt_Harga.Text = 0
        If txt_Diskon.Text = "" Then txt_Diskon.Text = 0
        If Txt_Qty.Text = "" Then Txt_Qty.Text = 0

        txt_SubTotalTemp.Text = FormatAngka(CDbl(txt_Harga.Text) * CDbl(Txt_Qty.Text) - CDbl(txt_Diskon.Text))
        txt_Harga.Text = FormatAngka(CDbl(txt_Harga.Text))
    End Sub

    Private Sub txt_Diskon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Diskon.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Diskon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Diskon.LostFocus
        If txt_Harga.Text = "" Then txt_Harga.Text = 0
        If txt_Diskon.Text = "" Then txt_Diskon.Text = 0
        If Txt_Qty.Text = "" Then Txt_Qty.Text = 0

        txt_SubTotalTemp.Text = FormatAngka(CDbl(txt_Harga.Text) * CDbl(Txt_Qty.Text) - CDbl(txt_Diskon.Text))
        txt_Diskon.Text = FormatAngka(CDbl(txt_Diskon.Text))
    End Sub

    Private Sub txt_UangMuka_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_UangMuka.LostFocus
        If txt_UangMuka.Text = "" Then txt_UangMuka.Text = 0
        txt_UangMuka.Text = FormatAngka(CDbl(txt_UangMuka.Text))
        Call CountGrandTotal()
    End Sub

    Private Sub Txt_Qty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Qty.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Txt_Qty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Qty.LostFocus
        If txt_Harga.Text = "" Then txt_Harga.Text = 0
        If txt_Diskon.Text = "" Then txt_Diskon.Text = 0
        If Txt_Qty.Text = "" Then Txt_Qty.Text = 0

        txt_SubTotalTemp.Text = FormatAngka(CDbl(txt_Harga.Text) * CDbl(Txt_Qty.Text) - CDbl(txt_Diskon.Text))
    End Sub
    
    Private Sub gv_Toko_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv_Toko.CellClick
        If StatusTransDetail = "INSERT" Then Exit Sub
        If dtDetail.Rows.Count = 0 Then Exit Sub
        Btn_cancel_Click(Nothing, Nothing)

        txt_ItemID.Text = gv_Toko.CurrentRow.DataGridView(0, gv_Toko.CurrentRow.Index).Value.ToString
        txt_ItemName.Text = gv_Toko.CurrentRow.DataGridView(1, gv_Toko.CurrentRow.Index).Value.ToString
        Txt_UoM.Text = gv_Toko.CurrentRow.DataGridView(2, gv_Toko.CurrentRow.Index).Value.ToString
        Txt_Qty.Text = gv_Toko.CurrentRow.DataGridView(3, gv_Toko.CurrentRow.Index).Value.ToString
        txt_Harga.Text = gv_Toko.CurrentRow.DataGridView(4, gv_Toko.CurrentRow.Index).Value.ToString
        txt_Diskon.Text = gv_Toko.CurrentRow.DataGridView(5, gv_Toko.CurrentRow.Index).Value.ToString
        txt_SubTotalTemp.Text = gv_Toko.CurrentRow.DataGridView(6, gv_Toko.CurrentRow.Index).Value.ToString
    End Sub
 
#End Region

End Class