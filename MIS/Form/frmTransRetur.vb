Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmTransRetur
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim period As String = ""
    Dim CurrDate As String
    Public ViewFormName As String
    Private Sub frmTransRetur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, ts_Edit, Nothing, ts_save, ts_cancel, Nothing, Nothing, Nothing)

        Clear_Wa()
        Enable_Wa(False)
        EnableInput(False)
        txtPeriod.Enabled = False
        gvRetur.AllowUserToAddRows = False


        If txtReturNo.Text.Trim <> "" Then
            EnableInput(False)
            EnableButton(False)
            ts_save.Enabled = False
            ts_Edit.Enabled = True
            btn_edit.Enabled = False

            LoadReturDetail(txtReturNo.Text)
            CurrDate = GetCurrDate.ToString.Substring(0, 10)
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                Enable_Wa(False)
                EnableInput(False)
                EnableButton(False)
            End If
        Else
            txtPeriod.Text = GetPeriod()
            txtnoTB.Focus()
            EnableInput(True)
            ts_Edit.Enabled = False
        End If
        SetGrid_item()
    End Sub
    Private Sub EnableButton(ByVal bool As Boolean)
        Btn_cancel.Enabled = bool
        btn_delete.Enabled = bool
        btn_edit.Enabled = bool
        btn_save.Enabled = bool
    End Sub

    Function CheckStatusPeriodClosing(ByVal Period As String, ByVal Today As String) As Boolean
        Dim dt_period As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from Trans_Closing where Period = '" & Period & "' and start_date <= '" & Today & "' and end_date >= '" & Today & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_period)

        CheckStatusPeriodClosing = dt_period.Rows.Count > 0

    End Function

    Private Sub EnableInput(ByVal boo As Boolean)
        txtnoTB.Enabled = boo
        txtSupplierID.Enabled = boo
        dt_Retur.Enabled = boo
        cbReturTipe.Enabled = boo
        txtKet.Enabled = boo
    End Sub

    Private Function GetPeriod() As String
        Dim dt As New DataTable


        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt.Clear()

            Cmd.CommandText = "select period from trans_closing order by period desc"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            Return dt.Rows(0).Item("period").ToString


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return String.Empty
    End Function

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txtQuantity.Enabled = boo
        txtReason.Enabled = boo
    End Sub

    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txtQuantity.BackColor = Color.DarkGray
            txtReason.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            txtQuantity.BackColor = Color.LemonChiffon
            txtReason.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txtQuantity.BackColor = Color.LemonChiffon
            txtReason.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub Clear_Wa()
        txtQuantity.Clear()
        txtReason.Clear()
        txt_ItemName.Clear()
        txtAmount.Clear()
        txtUnitP.Clear()
        txtUOM.Clear()
        txt_ItemID.Clear()
    End Sub
    Private Sub LoadReturDetail(ByVal docretur As String)
        Try
            dt_hdr.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_Retreive_Retur_DtlAll '" & docretur & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvRetur.DataSource = dt_hdr

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub
   
    Private Sub txtnoTB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnoTB.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("exec sp_GetPOPelunasanHutangRetur", "TB_No", "Supplier_ID", "Nama", "", "")
            txtnoTB.Text = frmSearch.txtResult1.Text.ToString.Trim
            txtSupplierID.Text = frmSearch.txtResult2.Text.ToString.Trim
            txtSupplierNm.Text = frmSearch.txtResult3.Text.ToString.Trim

            Try
                dt_hdr.Clear()
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "select a.item_id, Item_Name, a.UoM ,qty as quantity ,price, (qty * price) as Amount,'' as Reason from Trans_TerimaBrg_Dtl a left join Master_Item_Hdr b on a.Item_ID = b.Item_ID  where a.TB_No = '" & txtnoTB.Text & "'"

                DA.SelectCommand = Cmd
                DA.Fill(dt_hdr)

                gvRetur.DataSource = dt_hdr

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try

        End If
    End Sub

    
    Private Sub gvRetur_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvRetur.CellMouseClick
        If String.IsNullOrEmpty(gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("Item_ID").Value) = False Then
            txt_ItemID.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("Item_ID").Value.ToString.Trim
            txt_ItemName.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("Item_Name").Value.ToString.Trim
            txtUOM.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("UoM").Value.ToString.Trim
            txtQuantity.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("Quantity").Value.ToString.Trim
            txtUnitP.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("Price").Value.ToString.Trim
            txtAmount.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("amount").Value.ToString.Trim
            txtReason.Text = gvRetur.Rows(gvRetur.CurrentCell.RowIndex).Cells("reason").Value.ToString.Trim
        End If
    End Sub

    Private Sub btn_insert_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Status_Proses = "Insert"
        Enable_Wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        btn_edit.Enabled = False
        btn_delete.Enabled = False
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Item_ID")
        dt_hdr.PrimaryKey = dc

        ' Validation
        If txtQuantity.Text = "" Then
            MessageBox.Show("Quantity cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtReason.Text = "" Then
            MessageBox.Show("Reason cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Status_Proses = "Insert" Then
            'Dim dr As DataRow
            'da = dt_hdr.Rows.Find(txt_ItemID.Text)
            'If da IsNot Nothing Then
            '    MessageBox.Show("No Project sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'Else
            '    dr = dt_hdr.NewRow
            '    dr("Project_No") = txt_noPR.Text
            '    If chk_UangMuka.Checked Then
            '        dr("Uang_Muka") = "Y"
            '    Else
            '        dr("Uang_Muka") = "N"
            '    End If
            '    dr("Cust_ID") = txt_cusID.Text
            '    dr("Tipe_Pembayaran") = list_pembayaran.SelectedItem
            '    dr("Account") = txt_account.Text
            '    dr("No_Giro") = txt_nogiro.Text
            '    dr("Jatuh_Tempo") = dt_JatuhTempo.Value.ToString("yyyy-MM-dd")
            '    dr("Jumlah_bayar") = txt_jumlahbayar.Text
            '    dr("Faktur_No") = txt_invoice.Text
            '    dr("Faktur_Tipe") = txt_fakturtipe.Text
            '    dr("Potongan") = txt_potongan.Text
            '    dr("Account_Potongan") = txt_accountpot.Text
            '    dr("Keterangan") = txt_keterangan.Text
            '    dt_hdr.Rows.Add(dr)
            'End If
        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txt_ItemID.Text)

            If da IsNot Nothing Then
                da("Item_ID") = txt_ItemID.Text
                da("Item_name") = txt_ItemName.Text
                da("UoM") = txtUOM.Text
                da("quantity") = txtQuantity.Text
                da("Price") = txtUnitP.Text
                da("Amount") = txtAmount.Text
                da("Reason") = txtReason.Text
            End If
        End If
        gvRetur.DataSource = dt_hdr
        SetGrid_item()
        Status_Proses = "" 'reset
        btn_save.Enabled = True
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_ItemID.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        btn_save.Enabled = True

    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        btn_edit.Enabled = True
        btn_delete.Enabled = True
        gvRetur.Enabled = dt_hdr.Rows.Count > 0
        btn_save.Enabled = False
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("item_id")
        dt_hdr.PrimaryKey = dc

        If txt_ItemID.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txt_ItemID.Text)
            If da IsNot Nothing Then
                da.Delete()

                'Dim i As Integer
                'Do While Not i = dt_hdr.Rows.Count
                '    If dt_hdr.Rows(i).Item("item_id") = txt_ItemID.Text Then
                '        dt_hdr.Rows.RemoveAt(i)
                '    Else
                '        i += 1
                '    End If

                'Loop
                dt_hdr.AcceptChanges()
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                gvRetur.Focus()
            End If
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        If txtUnitP.Text <> "" And txtQuantity.Text <> "" Then
            txtAmount.Text = CInt(txtQuantity.Text) * CInt(txtUnitP.Text)
        End If
    End Sub

    Private Sub SetGrid_item()
        If gvRetur.Rows.Count > 0 Then
            gvRetur.Columns(4).DefaultCellStyle.Format = "#,##0.#0"
            gvRetur.Columns(5).DefaultCellStyle.Format = "#,##0.#0"
        End If
    End Sub

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim JournalNo As String
        Dim LastSerial As Integer
        Dim jumlahRetur As Double
        Dim dtRetur As String
        Dim defaultPeriod As String

        dtRetur = dt_Retur.Value.ToString("yyyyMM")
        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        If dtRetur <> defaultPeriod Then
            If dtRetur < defaultPeriod Then
                MessageBox.Show("Tanggal Retur harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            period = dtRetur
        End If
        If cbReturTipe.SelectedIndex = 0 Then
            MessageBox.Show("Retur Tipe harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtnoTB.Text = String.Empty Then
            MessageBox.Show("No TB harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtSupplierID.Text = String.Empty Then
            MessageBox.Show("Supplier ID harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If



        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            If txtReturNo.Text = "" Then
                txtReturNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtReturNo.Text, 3))

                Cmd.CommandText = "EXEC sp_Insert_Trans_Retur_Hdr '" & txtReturNo.Text.Trim & "','" & _
                                            dt_Retur.Value.ToString("yyyy-MM-dd") & "','" & _
                                            txtnoTB.Text.Trim & "','" & _
                                            txtSupplierID.Text.Trim & "','" & _
                                            cbReturTipe.SelectedItem & "','" & _
                                            txtKet.Text & "','" & _
                                            period & "','" & _
                                            userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                JournalNo = Generate_TranNo("Journal")
                LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))

                Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                     userlog.EmployeeID & "','" & _
                                    "Retur" & "','" & txtKet.Text & "','" & txtReturNo.Text & "','" & _
                                     "" & "','" & _
                                     "" & "','" & _
                                     "" & "','" & _
                                     "" & "','" & _
                                     userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                For Each item As DataRow In dt_hdr.Rows
                    Cmd.CommandText = "EXEC sp_Insert_Trans_Retur_dtl '" & txtReturNo.Text.Trim & "','" & _
                                                               item("item_ID") & "','" & _
                                                               item("quantity") & "','" & _
                                                               item("price") & "','" & _
                                                               item("amount") & "','" & _
                                                               item("reason") & "','" & _
                                                               userlog.UserName & "'"

                    jumlahRetur = jumlahRetur + CDbl(item("amount"))

                    Cmd.ExecuteNonQuery()
                Next

                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                               "135" & "'," & jumlahRetur & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()


                Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                              "161" & "'," & "0" & ",'" & jumlahRetur & "','" & "" & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()


                UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)

                ObjTrans.Commit()
                Conn.Close()

                MsgBox("No Dokumen Pelunasan  " & txtReturNo.Text.Trim & " Has been Saved")
                frmTransRetur_Load(Nothing, Nothing)
            Else
                Cmd.CommandText = "EXEC sp_Update_Trans_Retur_Hdr '" & txtReturNo.Text.Trim & "','" & _
                                                          dt_Retur.Value.ToString("yyyy-MM-dd") & "','" & _
                                                          txtnoTB.Text.Trim & "','" & _
                                                          txtSupplierID.Text.Trim & "','" & _
                                                          cbReturTipe.SelectedItem & "','" & _
                                                          txtKet.Text & "','" & _
                                                          period & "','" & _
                                                          userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                For Each item As DataRow In dt_hdr.Rows
                    If item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "EXEC sp_Delete_Trans_Retur_Dtl '" & txtReturNo.Text + "','" & _
                                       item("Item_ID") & "'"
                        Cmd.ExecuteNonQuery()
                    Else
                        Cmd.CommandText = "EXEC sp_Update_Trans_Retur_dtl '" & txtReturNo.Text.Trim & "','" & _
                                                                   item("item_ID") & "','" & _
                                                                   item("quantity") & "','" & _
                                                                   item("price") & "','" & _
                                                                   item("amount") & "','" & _
                                                                   item("reason") & "','" & _
                                                                   userlog.UserName & "'"
                        jumlahRetur = jumlahRetur + CDbl(item("amount"))

                        Cmd.ExecuteNonQuery()
                    End If
                Next

                Cmd.CommandText = "EXEC sp_Update_Journal_Item '" & txtReturNo.Text + "','" & _
                            "135" & "'," & jumlahRetur & ",'" & "0" & "','" & "" & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "EXEC sp_Update_Journal_Item '" & txtReturNo.Text + "','" & _
                       "161" & "'," & "0" & ",'" & jumlahRetur & "','" & "" & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()


                ObjTrans.Commit()
                Conn.Close()
                MsgBox("No Dokumen Pelunasan  " & txtReturNo.Text.Trim & " Has been Saved")
                frmTransRetur_Load(Nothing, Nothing)

            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        EnableInput(True)
        EnableButton(True)
        btn_save.Enabled = False
        ts_save.Enabled = True
        ts_cancel.Enabled = True
        txtnoTB.Enabled = False
        txtSupplierID.Enabled = False
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        EnableButton(False)
        ts_save.Enabled = False
        Clear_Wa()
        EnableInput(False)
        SetBackColor_Wa("READ")
    End Sub
End Class