Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class Frm_PencairanGiro
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private Sub btn_insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Status_Proses = "Insert"
        Enable_Wa(True)
        Clear_Wa()
        SetBackColor_Wa("INSERT")
        ' btn_insert.Enabled = False
        btn_edit.Enabled = False
        ' btn_delete.Enabled = False
        txt_nogiro.Focus()
    End Sub

    Private Sub Clear_Wa()
        txt_bank.Clear()
        txt_jatuhtempo.Clear()
        txt_NamaBank.Clear()
        txt_nilaigiro.Clear()
        txt_nogiro.Clear()
        txt_pelunasan.Clear()
        txt_tglBayar.Clear()
        txt_tglCair.Clear()
    End Sub

    Private Sub Enable_Wa(ByVal boo As Boolean)
        txt_bank.Enabled = boo
        txt_NamaBank.Enabled = boo
        'txt_nogiro.Enabled = boo
        cmb_status.Enabled = boo
    End Sub

    Private Sub SetBackColor_Wa(ByVal proses As String)
        If proses = "READ" Then
            txt_bank.BackColor = Color.DarkGray
            txt_jatuhtempo.BackColor = Color.DarkGray
            txt_NamaBank.BackColor = Color.DarkGray
            txt_nilaigiro.BackColor = Color.DarkGray
            txt_nogiro.BackColor = Color.DarkGray
            txt_pelunasan.BackColor = Color.DarkGray
            txt_tglBayar.BackColor = Color.DarkGray
            txt_tglCair.BackColor = Color.DarkGray
        ElseIf proses = "UPDATE" Then
            txt_NamaBank.BackColor = Color.LemonChiffon
            cmb_status.BackColor = Color.LemonChiffon
            txt_bank.BackColor = Color.LemonChiffon
        ElseIf proses = "INSERT" Then
            txt_NamaBank.BackColor = Color.LemonChiffon
            cmb_status.BackColor = Color.LemonChiffon
            txt_bank.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DisableButton(ByVal boo As Boolean)
        ts_New.Enabled = boo
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_delete.Enabled = boo
        ts_cancel.Enabled = boo
    End Sub

    Private Sub Enable_Button_Wa(ByVal boo As Boolean)
        ' btn_insert.Enabled = boo
        btn_edit.Enabled = boo
        btn_save.Enabled = boo
        ' btn_delete.Enabled = boo
        Btn_cancel.Enabled = boo
    End Sub

    Private Sub LoadPencairanGiro(ByVal No As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC sp_Retreive_Trans_PencairanGiro '" + No + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvGiro.DataSource = dt_hdr
            gvGiro.Enabled = dt_hdr.Rows.Count > 0

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Frm_PencairanGiro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        gvGiro.AllowUserToAddRows = False

        If txt_nogiro.Text.Trim <> "" Then
            Dim dt As New DataTable

            LoadPencairanGiro(txt_nogiro.Text)
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt.Clear()

                Cmd.CommandText = "EXEC sp_Retreive_Trans_PencairanGiro '" + txt_nogiro.Text + "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            txt_nogiro.Text = dt.Rows(0).Item("giro_no")
            txt_pelunasan.Text = dt.Rows(0).Item("PH_No")
            txt_jatuhtempo.Text = dt.Rows(0).Item("jatuh_tempo")
            txt_nilaigiro.Text = dt.Rows(0).Item("nilai_giro")
            txt_NamaBank.Text = dt.Rows(0).Item("nama_bank")
            txt_tglBayar.Text = dt.Rows(0).Item("tgl_bayar")
            txt_tglCair.Text = dt.Rows(0).Item("tgl_cair")
            cmb_status.Text = dt.Rows(0).Item("Status")

            Enable_Button_Wa(True)
            gvGiro.Enabled = True
            gvGiro.ReadOnly = False
            Enable_Wa(True)

            'txt_nogiro.Enabled = False


            If cmb_status.Text.Trim = "Cair" Or cmb_status.Text.Trim = "Tolak" Then
                btn_edit.Enabled = False
                Enable_Wa(False)
                Enable_Button_Wa(False)
            End If

        Else
            Clear_Wa()
            Enable_Button_Wa(True)
            DisableButton(False)
            ts_save.Enabled = True
            ts_cancel.Enabled = True
            LoadPencairanGiro(txt_nogiro.Text)
        End If
    End Sub

    Private Sub ts_New_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
    End Sub

    Private Sub txt_nogiro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nogiro.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("exec sp_GetNoGiro", "No_Giro", "PH_No", "Jatuh_Tempo", "jumlah_Bayar", "Account", "tgl_pelunasan")
            txt_nogiro.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_pelunasan.Text = frmSearch.txtResult2.Text.ToString.Trim
            txt_jatuhtempo.Text = frmSearch.txtResult3.Text.ToString.Trim
            txt_nilaigiro.Text = frmSearch.txtResult4.Text.ToString.Trim
            txt_NamaBank.Text = frmSearch.txtResult5.Text.ToString.Trim
            txt_tglBayar.Text = frmSearch.txtResult6.Text.ToString.Trim
            txt_tglCair.Text = Now
        End If
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Giro_NO")
        dt_hdr.PrimaryKey = dc

        ' Validation
        If txt_nogiro.Text = String.Empty Then
            MessageBox.Show("No Giro harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
       

        If Status_Proses = "Insert" Then
            Dim dr As DataRow
            da = dt_hdr.Rows.Find(txt_nogiro.Text)
            If da IsNot Nothing Then
                MessageBox.Show("No Giro sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                dr = dt_hdr.NewRow
                dr("Giro_No") = txt_nogiro.Text
                dr("Nama_Bank") = txt_NamaBank.Text
                dr("Tgl_Bayar") = txt_tglBayar.Text
                dr("Jatuh_Tempo") = txt_jatuhtempo.Text
                dr("Nilai_Giro") = txt_nilaigiro.Text
                dr("PH_No") = txt_pelunasan.Text
                dr("Status") = cmb_status.SelectedItem
                dr("Tgl_Cair") = txt_tglCair.Text
                dr("Bank") = txt_bank.Text
                dt_hdr.Rows.Add(dr)
            End If
        ElseIf Status_Proses = "Update" Then
            da = dt_hdr.Rows.Find(txt_nogiro.Text)
            If da IsNot Nothing Then
                da("Giro_No") = txt_nogiro.Text
                da("Nama_Bank") = txt_NamaBank.Text
                da("Tgl_Bayar") = txt_tglBayar.Text
                da("Jatuh_Tempo") = txt_jatuhtempo.Text
                da("Nilai_Giro") = txt_nilaigiro.Text
                da("PH_No") = txt_pelunasan.Text
                da("Status") = cmb_status.SelectedItem
                da("Tgl_Cair") = txt_tglCair.Text
                da("Bank") = txt_bank.Text
            End If
        End If
        gvGiro.DataSource = dt_hdr
        Status_Proses = "" 'reset
        Btn_cancel_Click(Nothing, Nothing)
    End Sub

    Private Sub Btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_cancel.Click
        Enable_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        'btn_insert.Enabled = True
        btn_edit.Enabled = True
        ' btn_delete.Enabled = True
        gvGiro.Enabled = dt_hdr.Rows.Count > 0
    End Sub

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans
        Dim dt As New DataTable
        Dim LastSerial As Integer
        Dim JournalNo As String
        Dim GiroNo As String

        GiroNo = gvGiro.Rows(0).Cells(0).Value


        'Dim LastSerial As Integer
        'Dim remarks_Stok As String


        Try
            ' txt_DocNo.Text = Generate_TranNo(Me.Name)

            'LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))
            'remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


            'Cmd.CommandText = "EXEC sp_Insert_Trans_PelunasanViaBankHdr '" & txt_DocNo.Text.Trim & "','" & _
            '                             dt_JatuhTempo.Value.ToString("yyyy-MM-dd") & "','" & _
            '                             txt_kdSupplier.Text.Trim & "','" & _
            '                             txt_keterangan.Text.Trim & "','" & _
            '                             userlog.UserName & "'"
            'Cmd.ExecuteNonQuery()
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
                dt.Clear()

                Cmd.CommandText = "select giro_no from trans_pencairangiro where giro_no = '" + GiroNo + "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                'Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If dt.Rows.Count > 0 Then
                For Each item As DataRow In dt_hdr.Rows

                    Cmd.CommandText = "EXEC sp_Update_transPencairanGiroHutang '" & item("Giro_NO") & "','" & _
                                             item("Nama_Bank") & "','" & _
                                             item("Tgl_Bayar") & "','" & _
                                             item("Jatuh_Tempo") & "','" & _
                                             item("Nilai_Giro") & "','" & _
                                             item("PH_No") & "','" & _
                                             item("Status") & "','" & _
                                             item("Tgl_Cair") & "','" & _
                                             item("Bank") & "','" & _
                                             userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()

                    JournalNo = Generate_TranNo("Journal")
                    LastSerial = CInt(Microsoft.VisualBasic.Right(JournalNo, 3))


                    If item("Status") = "Cair" Then
                        Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                        userlog.EmployeeID & "','" & _
                                       "Finance" & "','" & "" & "','" & txt_nogiro.Text & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                                 "Hutang Giro" & "'," & item("Nilai_Giro") & "," & "0" & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                          item("Bank") & "'," & "0" & "," & item("Nilai_Giro") & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        
                        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                    ElseIf item("Status") = "Tolak" Then
                        Cmd.CommandText = "EXEC sp_Insert_Journal '" & JournalNo & "','" & _
                                        userlog.EmployeeID & "','" & _
                                       "Finance" & "','" & "" & "','" & txt_nogiro.Text & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        "" & "','" & _
                                        userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                                                 item("Bank") & "'," & item("Nilai_Giro") & "," & "0" & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()


                        Cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JournalNo + "','" & _
                                          "320" & "'," & "0" & "," & item("Nilai_Giro") & ",'" & "" & "','" & userlog.UserName & "'"
                        Cmd.ExecuteNonQuery()

                        

                        UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                    End If
                Next
            Else


                For Each item As DataRow In dt_hdr.Rows
                    Cmd.CommandText = "EXEC sp_Insert_PencairanGiro '" & item("Giro_NO") & "','" & _
                                             item("Nama_Bank") & "','" & _
                                             item("Tgl_Bayar") & "','" & _
                                             item("Jatuh_Tempo") & "','" & _
                                             item("Nilai_Giro") & "','" & _
                                             item("PH_No") & "','" & _
                                             item("Status") & "','" & _
                                             item("Tgl_Cair") & "','" & _
                                             item("Bank") & "','" & _
                                             userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()
                Next
            End If









            'For Each item As DataRow In dt_hdr.Rows
            '    Cmd.CommandText = "EXEC sp_Insert_PencairanGiro '" & item("Giro_NO") & "','" & _
            '                             item("Nama_Bank") & "','" & _
            '                             item("Tgl_Bayar") & "','" & _
            '                             item("Jatuh_Tempo") & "','" & _
            '                             item("Nilai_Giro") & "','" & _
            '                             item("PH_No") & "','" & _
            '                             item("Status") & "','" & _
            '                             item("Tgl_Cair") & "','" & _
            '                             item("Bank") & "','" & _
            '                             userlog.UserName & "'"
            '    Cmd.ExecuteNonQuery()
            'Next

            'For Each item As DataRow In dt_dtl.Rows
            '    Cmd.CommandText = "EXEC sp_INSERT_Trans_OrderPabrikasi_Dtl '" & txt_TransNo.Text.Trim + "','" & _
            '                      item("Item_ID") & "','" & item("ItemDetail_ID") & "'," & item("Qty_STDR") & "," & _
            '                      item("Qty_Order")
            '    Cmd.ExecuteNonQuery()
            'Next
            ObjTrans.Commit()
            Conn.Close()
            MsgBox("No Pencairan Giro Has been Saved")
            Frm_PencairanGiro_Load(Nothing, Nothing)
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If txt_nogiro.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Status_Proses = "Update"
        Enable_Wa(True)
        SetBackColor_Wa("UPDATE")
        'btn_insert.Enabled = False
        btn_edit.Enabled = False
        'btn_delete.Enabled = False
        txt_nogiro.Focus()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("Giro_No")
        dt_hdr.PrimaryKey = dc

        If txt_nogiro.Text = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(txt_nogiro.Text)
            If da IsNot Nothing Then
                da.Delete()
                'btn_insert.Enabled = True
                btn_edit.Enabled = True
                'btn_delete.Enabled = True
                gvGiro.Focus()
            End If
        End If
    End Sub

    Private Sub gvGiro_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvGiro.CellMouseClick
        If String.IsNullOrEmpty(gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Giro_No").Value) = False Then
            txt_nogiro.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Giro_No").Value.ToString.Trim
            txt_NamaBank.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Nama_Bank").Value.ToString.Trim
            txt_tglBayar.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Tgl_Bayar").Value.ToString.Trim
            txt_jatuhtempo.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Jatuh_Tempo").Value.ToString.Trim
            txt_nilaigiro.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Nilai_Giro").Value.ToString.Trim
            txt_pelunasan.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("PH_No").Value.ToString.Trim
            cmb_status.SelectedItem = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Status").Value.ToString.Trim
            txt_tglCair.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Tgl_Cair").Value.ToString.Trim
            txt_bank.Text = gvGiro.Rows(gvGiro.CurrentCell.RowIndex).Cells("Bank").Value.ToString.Trim
        End If
    End Sub

    Private Sub txt_bank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bank.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Account_id,account_name from Master_COA where Group_PayAccount = 'Bank'", "Account_ID", "Account_Name", "", "", "")
            txt_bank.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        DisableButton(False)
        Enable_Button_Wa(False)
        Clear_Wa()
        SetBackColor_Wa("READ")
        ts_New.Enabled = True
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        Enable_Button_Wa(True)
        DisableButton(False)
        ts_save.Enabled = True
        ts_cancel.Enabled = True
    End Sub

    Private Sub txt_NamaBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_NamaBank.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Bank_Name from Master_Bank", "Bank_Name", "", "", "", "")
            txt_NamaBank.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub
End Class