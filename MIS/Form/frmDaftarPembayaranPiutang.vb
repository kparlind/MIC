Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmDaftarPembayaranPiutang
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Private FakturNo As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim period As String = ""
    Dim dtPelunasan As String
    Dim CurrDate As String
    Private Sub frmDaftarPembayaranPiutang_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        If txt_DocNo.Text = "" Then
            ' LoadCBSuppID()
            '  cb_suppID.SelectedItem = "All"
            ts_Edit.Enabled = False

            ' ManageDataGrid()
            txtPeriod.Text = GetPeriod()
        Else
            LoadDaftarPelunasanByID(txt_DocNo.Text)
          
            ManageDataGridID()
            CalculateOverdueID()
            'gvPelunasan.Columns("chk").ReadOnly = True
            dt_Pelunasan.Enabled = False
            enableWa(False)
            btn_save.Enabled = True
            btnsave.Enabled = False
            btnDelete.Enabled = False
            btnSearch.Enabled = False
            CurrDate = GetCurrDate.ToString.Substring(0, 10)
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                ts_Edit.Enabled = False
                ts_Save.Enabled = False
            End If
        End If

    End Sub
    Private Sub ManageDataGridID()
        Dim chk As New DataGridViewCheckBoxColumn()
        Dim txt1 As New DataGridViewTextBoxColumn()
        Dim txt2 As New DataGridViewTextBoxColumn()




        chk.HeaderText = "Check Data"
        chk.Name = "chk"
        txt1.HeaderText = "Overdue"
        txt1.Name = "Overdue"


        gvPelunasan.Columns.Add(txt1)
        'gvPelunasan.Columns("Overdue").ReadOnly = True

        gvPelunasan.Columns.Add(chk)
        gvPelunasan.Columns("chk").ReadOnly = False

        gvPelunasan.Columns(8).Visible = False
        gvPelunasan.Columns(9).Visible = False
        gvPelunasan.Columns(10).Visible = False
        gvPelunasan.AllowUserToAddRows = False

    End Sub
    Private Sub CalculateOverdueID()
        Dim i As Integer = 0
        If gvPelunasan.Rows.Count > 0 Then
            While i < gvPelunasan.Rows.Count
                gvPelunasan.Item(11, i).Value = DateDiff(DateInterval.Day, gvPelunasan.Item(3, i).Value, Now)
                i = i + 1
            End While
        End If
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
    Private Sub ClearData()

        txt_NmKolektor.Clear()
        txt_DocNo.Clear()
        dt_Pelunasan.Value = Now
        ' cb_suppID.SelectedIndex = 0

    End Sub

    Private Sub enableWa(ByVal boo As Boolean)
        txt_NmKolektor.Enabled = boo
        ' cb_suppID.Enabled = boo
        dt_Pelunasan.Enabled = boo
        txt_emp.Enabled = boo
        'txtProjectNo.Enabled = boo
        txtCustomer.Enabled = boo
        dtFrom.Enabled = boo
        dtTo.Enabled = boo
        gvPelunasan.ReadOnly = boo
        txtInvoice.Enabled = boo
    End Sub
    Private Sub ManageDataGrid()
        Dim chk As New DataGridViewCheckBoxColumn()
        Dim txt1 As New DataGridViewTextBoxColumn()
        Dim txt2 As New DataGridViewTextBoxColumn()




        chk.HeaderText = "Check Data"
        chk.Name = "chk"
        txt1.HeaderText = "Overdue"
        txt1.Name = "Overdue"


        gvPelunasan.Columns.Add(txt1)
        'gvPelunasan.Columns("Overdue").ReadOnly = True
        gvPelunasan.Columns.Add(chk)
        If txt_DocNo.Text = "" Then
            gvPelunasan.Columns("chk").ReadOnly = False
        Else
            gvPelunasan.Columns("chk").ReadOnly = True
        End If

        'gvPelunasan.Columns(10).Visible = False


        'gvPelunasan.Columns(11).Visible = False
        'gvPelunasan.Columns(12).Visible = False
        gvPelunasan.AllowUserToAddRows = False

    End Sub
    Private Sub LoadDaftarPelunasanByID(ByVal id As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()
            Cmd.CommandText = "EXEC sp_retrieve_DPPbyID '" & id & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvPelunasan.DataSource = dt_hdr
            gvPelunasan.Enabled = dt_hdr.Rows.Count > 0
         

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadDaftarPelunasan()
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()
            Cmd.CommandText = "EXEC sp_GetDaftarPenagihanPiutang '" & dtFrom.Value & "','" & dtTo.Value & "','" & IIf(txtCustomer.Text = "", "all", txtCustomer.Text) & "','" & "all" & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvPelunasan.DataSource = dt_hdr
            gvPelunasan.Enabled = dt_hdr.Rows.Count > 0


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_save_Click(sender As Object, e As System.EventArgs) Handles btn_save.Click
        Dim frmchild As frmPrint
        Dim i As Integer = 0
        Dim insert As Integer = 0
        Dim dtPiutang As New DataTable
        Dim drPiutang As DataRow

        Dim clTglFaktur As New DataColumn("tgl_faktur")
        clTglFaktur.DataType = System.Type.GetType("System.DateTime")

        Dim clTglJT As New DataColumn("tgl_jatuhtempo")
        clTglJT.DataType = System.Type.GetType("System.DateTime")

        Dim clJmlUang As New DataColumn("jumlah_uang")
        clJmlUang.DataType = System.Type.GetType("System.Int32")




        With dtPiutang.Columns
            .Add("DPP_No")
            .Add("faktur_no")
            .Add(clTglFaktur)
            .Add(clTglJT)
            .Add("project_no")
            .Add("Customer_name")
            .Add("salesman")
            .Add(clJmlUang)
            .Add("Outstanding")
            .Add("cust_id")
            .Add("employee_id")
        End With


        While i < gvPelunasan.Rows.Count
            If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                With gvPelunasan.Rows(i)
                    drPiutang = dtPiutang.NewRow
                    drPiutang.Item("DPP_no") = txt_DocNo.Text
                    drPiutang.Item("faktur_no") = .Cells("faktur_no").Value
                    drPiutang.Item(clTglFaktur) = .Cells("tgl_faktur").Value
                    drPiutang.Item(clTglJT) = .Cells("tgl_jatuhtempo").Value
                    drPiutang.Item("project_no") = .Cells("project_no").Value
                    drPiutang.Item("customer_name") = ""
                    drPiutang.Item("salesman") = txt_NmKolektor.Text
                    drPiutang.Item(clJmlUang) = CInt(.Cells("outstanding_invoice").Value)
                    drPiutang.Item("outstanding") = ""
                    drPiutang.Item("cust_id") = ""
                    drPiutang.Item("employee_id") = ""
                    dtPiutang.Rows.Add(drPiutang)
                    insert = 1
                End With
            End If
            i = i + 1
        End While

        If insert = 1 Then
            gvPelunasan.DataSource = dt_hdr

            frmchild = frmPrint
            frmchild.dpp = txt_DocNo.Text
            frmchild.dtDaftarPiutang = dtPiutang
            frmchild.ReportName = "Daftar Piutang"
            frmchild.Show()
        Else
            MessageBox.Show("Please Choose Data for Print", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn.Close()
            Exit Sub
        End If

      
    End Sub

    Private Sub txt_emp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_emp.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Employee_ID,name from master_employee a left join master_department b on a.Department_id = b.Department_id", "Employee_ID", "Name", "", "", "")
            txt_emp.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_NmKolektor.Text = frmSearch.txtResult2.Text.ToString.Trim
        End If
    End Sub

    'Private Sub txtProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If txtCustomer.Text = String.Empty Then
    '        MsgBox("Please fill Kode Customer")
    '        Exit Sub
    '    End If
    '    If e.KeyCode = Keys.F1 Then
    '        CallandGetSearchData("select * from trans_projects a left join trans_survey_hdr b on a.survey_no = b.survey_no where cust_id = '" & txtCustomer.Text & "'", "Project_NO", "", "", "", "")
    '        ' txtProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
    '    End If
    'End Sub

    Private Sub txtCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("select * from master_customer", "Cust_ID", "Nama", "", "", "")
            txtCustomer.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadDaftarPelunasan()
        If gvPelunasan.ColumnCount < 14 Then
            ManageDataGrid()
        End If
        CalculateOverdue()
    End Sub

    Private Sub CalculateOverdue()
        Dim i As Integer = 0
        If gvPelunasan.Rows.Count > 0 Then
            While i < dt_hdr.Rows.Count
                gvPelunasan.Item(13, i).Value = DateDiff(DateInterval.Day, gvPelunasan.Item(2, i).Value, Now)
                i = i + 1
            End While
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Dim LastSerial As Integer
        Dim remarks_Stok As String
        Dim i As Integer = 0
        Dim valid As Integer = 1
        Dim insert As Integer = 0

        Dim defaultPeriod As String
        dtPelunasan = dt_Pelunasan.Value.ToString("yyyyMM")

        defaultPeriod = txtPeriod.Text
        period = defaultPeriod

        If dtPelunasan <> defaultPeriod Then
            If dtPelunasan < defaultPeriod Then
                MessageBox.Show("Tanggal Pelunasan harus lebih besar dari period.Proses Save dibatalkan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            period = dtPelunasan
        End If

        If txt_DocNo.Text = "" Then

            Try

                While i < gvPelunasan.Rows.Count
                    If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                        insert = 1
                    End If
                    i = i + 1
                End While


                If insert = 0 Then
                    MsgBox("Pilih data yang ingin disave")
                    Conn.Close()
                    Exit Sub
                End If



                txt_DocNo.Text = Generate_TranNo(Me.Name)
                'txt_DocNo.Text = "DP1208001"
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))
                remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


                Cmd.CommandText = "EXEC sp_Insert_DaftarPembayaranPiutang_Hdr '" & txt_DocNo.Text.Trim & "','" & _
                                             dt_Pelunasan.Value.ToString("yyyy-MM-dd") & "','" & _
                                             period & "','" & _
                                             txt_emp.Text & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()



                i = 0

                While i < gvPelunasan.Rows.Count
                    If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                        With gvPelunasan.Rows(i)
                            Cmd.CommandText = "EXEC sp_Insert_DaftarPembayaranPiutang_Dtl '" & txt_DocNo.Text.Trim & "','" & _
                                                 .Cells("faktur_no").Value & "','" & _
                                                  .Cells("faktur_tipe").Value & "','" & _
                                                  .Cells("cust_id").Value & "','" & _
                                                    .Cells("project_no").Value & "','" & _
                                                 .Cells("employee_id").Value & "','" & _
                                                .Cells("tgl_faktur").Value & "','" & _
                                                .Cells("tgl_jatuhtempo").Value & "','" & _
                                                 .Cells("overdue").Value & "'," & _
                                                 .Cells("outstanding_invoice").Value & "," & _
                                                .Cells("Outstanding_piutang").Value & ",'" & _
                                                 userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End With
                        insert = 1
                    End If
                    i = i + 1
                End While

            
                MsgBox("No Daftar Pembayaran Piutang  " & txt_DocNo.Text.Trim & " Has been Saved")
                ObjTrans.Commit()
                Conn.Close()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                ' ClearData()

            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MsgBox(ex.Message)
            End Try
        Else
            Try

                Cmd.CommandText = "EXEC sp_Update_DaftarPembayaranPiutang_Hdr '" & txt_DocNo.Text.Trim & "','" & _
                                                            dt_Pelunasan.Value.ToString("yyyy-MM-dd") & "','" & _
                                                            period & "','" & _
                                                            txt_emp.Text & "','" & _
                                                            userlog.UserName & "'"
                Cmd.ExecuteNonQuery()


                For Each item As DataRow In dt_hdr.Rows
                    If item.RowState = DataRowState.Deleted Then
                        Cmd.CommandText = "Delete From Trans_DaftarPembayaranPiutang_Dtl where DPP_No =  '" & txt_DocNo.Text + "' and Faktur_No = '" & item("Faktur_no", DataRowVersion.Original).ToString & "'"

                        Cmd.ExecuteNonQuery()
                        'ObjTrans.Commit()
                        'Conn.Close()

                        'MsgBox("No Daftar Pembayaran Piutang  " & txt_DocNo.Text.Trim & " Has been Saved")


                    End If
                Next
                MsgBox("No Daftar Pembayaran Piutang  " & txt_DocNo.Text.Trim & " Has been Saved")
                ObjTrans.Commit()
                Conn.Close()
            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MsgBox(ex.Message)
            End Try
        End If

        enableWa(False)
        ts_Edit.Enabled = True

        btn_save.Enabled = True
        btnsave.Enabled = False
        btnSearch.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("faktur_no")
        dt_hdr.PrimaryKey = dc

        If FakturNo = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(FakturNo)
            If da IsNot Nothing Then
                da.Delete()

                'Dim i As Integer
                'Do While Not i = dt_hdr.Rows.Count
                '    If dt_hdr.Rows(i).Item("No_BST") = BSTNO Then
                '        dt_hdr.Rows.RemoveAt(i)
                '    Else
                '        i += 1
                '    End If

                'Loop
                ' dt_hdr.AcceptChanges()
                'btn_insert.Enabled = True
                'btn_edit.Enabled = True
                'btn_delete.Enabled = True
                'gvPembayaran.Focus()
            End If
        End If
    End Sub

    Private Sub gvPelunasan_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvPelunasan.CellMouseClick
        If String.IsNullOrEmpty(gvPelunasan.Rows(gvPelunasan.CurrentCell.RowIndex).Cells("Faktur_No").Value) = False Then
            FakturNo = gvPelunasan.Rows(gvPelunasan.CurrentCell.RowIndex).Cells("Faktur_No").Value
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        btn_save.Enabled = True
        btnsave.Enabled = True
        btnSearch.Enabled = False
        btnDelete.Enabled = True
        enableWa(False)
        dt_Pelunasan.Enabled = True
        txt_emp.Enabled = True
    End Sub

    Private Sub txtInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoice.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Faktur_No,Tgl_Faktur,Tgl_JatuhTempo,Nama as Nama_Customer,Jumlah_Uang from trans_invoice_piutang a left join master_customer b on a.cust_id = b.cust_id", "Faktur_No", "Tgl_Faktur", "Tgl_JatuhTempo", "Nama_Customer", "Jumlah_Uang")
            txtInvoice.Text = frmSearch.txtResult1.Text.ToString.Trim
            btnInvoice.Enabled = True
        End If
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim dr_hdr As DataRow
        Dim dt_inv As New DataTable
        Dim dt_Outstanding As New DataTable
        Dim dt_Employee As New DataTable
        Dim dt_Customer As New DataTable


        dr_hdr = dt_hdr.NewRow

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retreive_Trans_Invoice_Piutang '" & txtInvoice.Text & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_inv)

            Cmd.CommandText = "EXEC  sp_GetPRPelunasanPiutangByPRNo '" & dt_inv.Rows(0).Item("Project_No") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Outstanding)

            Cmd.CommandText = "select name from master_employee where employee_id = '" & dt_inv.Rows(0).Item("Salesman_ID") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Employee)

            Cmd.CommandText = "select nama from master_customer where cust_id = '" & dt_inv.Rows(0).Item("Cust_ID") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Customer)

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        '        [Tgl_Faktur]()
        '      ,[Tgl_JatuhTempo]
        '      ,[Faktur_Tipe]
        '      ,[Cust_ID]
        '      ,[Employee_ID] as Salesman_ID
        '      ,[Project_No]
        '      ,[DPP]
        '      ,[Jumlah_Uang]
        '      ,[Keterangan]


        'e.faktur_no,Faktur_Tipe,tgl_faktur,tgl_jatuhtempo,e.project_no,f.nama as customer_name,name as salesman,
        '        jumlah_uang, outstanding, f.cust_id, g.employee_id


        dr_hdr.Item("faktur_no") = txtInvoice.Text
        dr_hdr.Item("faktur_tipe") = dt_inv.Rows(0).Item("Faktur_Tipe")
        dr_hdr.Item("tgl_faktur") = dt_inv.Rows(0).Item("Tgl_Faktur")
        dr_hdr.Item("tgl_jatuhtempo") = dt_inv.Rows(0).Item("Tgl_JatuhTempo")
        dr_hdr.Item("project_no") = dt_inv.Rows(0).Item("project_no")
        dr_hdr.Item("customer_name") = dt_Customer.Rows(0).Item("Nama").ToString
        If dt_Employee.Rows.Count > 0 Then
            dr_hdr.Item("salesman") = dt_Employee.Rows(0).Item("Name").ToString
        Else
            dr_hdr.Item("salesman") = ""
        End If

        If dt_Customer.Rows.Count > 0 Then
            dr_hdr.Item("cust_id") = dt_Customer.Rows(0).Item("Nama")
        Else
            dr_hdr.Item("cust_id") = ""
        End If

        dr_hdr.Item("jumlah_uang") = dt_inv.Rows(0).Item("jumlah_uang")
        dr_hdr.Item("Outstanding") = dt_Outstanding.Rows(0).Item("Outstanding")
        dr_hdr.Item("cust_id") = dt_inv.Rows(0).Item("Cust_ID")
        dr_hdr.Item("employee_id") = dt_inv.Rows(0).Item("Salesman_ID")
        dt_hdr.Rows.Add(dr_hdr)


        gvPelunasan.DataSource = dt_hdr
        CalculateOverdue()
    End Sub

    Private Sub ts_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Save.Click
        btnsave_Click(sender, e)
    End Sub
End Class