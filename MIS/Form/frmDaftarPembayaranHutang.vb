Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmDaftarPembayaranHutang
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private BSTNO As String
    Dim period As String = ""
    Dim dtPelunasan As String
    Dim CurrDate As String
    Private Sub frmDaftarPembayaranHutang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadCBSuppID()
        If txt_DocNo.Text = "" Then
            cb_suppID.SelectedItem = "All"
            LoadDaftarPelunasan(cb_suppID.SelectedItem)
            ManageDataGrid()
            btnSave.Enabled = True
            txtPeriod.Text = GetPeriod()
        Else
            LoadDaftarPelunasanByNo(txt_DocNo.Text)
            'ManageDataGrid()
            'gvPelunasan.Columns("chk").ReadOnly = True
            enableWa(False)
            dt_Pelunasan.Enabled = False
            cb_suppID.Enabled = False

            btn_save.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnSearch.Enabled = False
            CurrDate = GetCurrDate.ToString.Substring(0, 10)
            If Not CheckStatusPeriodClosing(txtPeriod.Text, CurrDate) = True Then
                ts_Edit.Enabled = False
            End If

        End If
        gvPelunasan.AllowUserToAddRows = False

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

        txt_NmSupplier.Clear()
        txt_DocNo.Clear()
        dt_Pelunasan.Value = Now
        ' cb_suppID.SelectedIndex = 0

    End Sub

    Private Sub enableWa(ByVal boo As Boolean)
        txt_NmSupplier.Enabled = boo
        cb_suppID.Enabled = boo
        dt_Pelunasan.Enabled = boo

    End Sub
    Private Sub ManageDataGrid()
        Dim chk As New DataGridViewCheckBoxColumn()
        Dim txt1 As New DataGridViewTextBoxColumn()
        Dim txt2 As New DataGridViewTextBoxColumn()


        chk.HeaderText = "Check Data"
        chk.Name = "chk"


        gvPelunasan.Columns.Add(chk)
        gvPelunasan.Columns("chk").ReadOnly = False

        'gvPelunasan.Columns(0).ReadOnly = True
        'gvPelunasan.Columns(1).ReadOnly = True
        'gvPelunasan.Columns(2).ReadOnly = True
        'gvPelunasan.Columns(3).ReadOnly = True
        'gvPelunasan.Columns(4).ReadOnly = True
        'gvPelunasan.Columns(5).ReadOnly = True


    End Sub

    Private Sub LoadDaftarPelunasan(ByVal no As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC sp_GetDaftarPelunasanHutang '" & dtFrom.Value & "','" & dtTo.Value & "','" + no + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvPelunasan.DataSource = dt_hdr
            gvPelunasan.Enabled = dt_hdr.Rows.Count > 0


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadDaftarPelunasanByNo(ByVal no As String)
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            dt_hdr.Clear()

            Cmd.CommandText = "EXEC sp_GetDaftarPelunasanHutangByNo '" + no + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_hdr)

            gvPelunasan.DataSource = dt_hdr
            gvPelunasan.Enabled = dt_hdr.Rows.Count > 0


            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadCBSuppID()
        Dim dt_TB As New DataTable
        Dim i As Integer = 0
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select Supp_ID, Nama , Contact_Person from Master_Supplier"
            DA.SelectCommand = Cmd
            DA.Fill(dt_TB)
            Conn.Close()

            'Dim dr As DataRow
            'dr = dt_TB.NewRow
            'dr(0) = ""
            'dt_TB.Rows.Add(dr)

            'cb_TBNo.DataSource = dt_TB
            'cb_TBNo.DisplayMember = GlobalVar.Fields.TB_No
            'cb_TBNo.ValueMember = GlobalVar.Fields.TB_No

            'dt_TB.Rows.Add("0", "All")


            cb_suppID.Items.Insert(0, "All")
            cb_suppID.Items.Item(0) = "All"
            While i < dt_TB.Rows.Count
                cb_suppID.Items.Insert(i + 1, dt_TB.Rows(i).Item("Supp_ID"))
                cb_suppID.Items.Item(i + 1) = dt_TB.Rows(i).Item("Supp_ID")
                i = i + 1
            End While

            LoadDaftarPelunasan(cb_suppID.SelectedItem)
            ' ManageDataGrid()
            'cb_PH.ValueMember = "PH_NO"
            'cb_PH.DisplayMember = "PH_NO"
            'cb_PH.DataSource = dView


        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim frmchild As frmPrint
        Dim i As Integer = 0
        Dim insert As Integer = 0
        Dim dtHutang As New DataTable
        Dim drHutang As DataRow

        With dtHutang.Columns
            .Add("DPH_No")
            .Add("Supp_ID")
            .Add("Nama")
            .Add("Tgl_Terima_Barang")
            .Add("Faktur_No")
            .Add("SuratJalan_no")
            .Add("No_BST")
            .Add("Jatuh_Tempo")
            .Add("Outstanding")
            .Add("NilaiPO")
        End With



        While i < gvPelunasan.Rows.Count
            If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                drHutang = dtHutang.NewRow
                With gvPelunasan.Rows(i)
                    drHutang.Item("Supp_ID") = .Cells("Supplier_ID").Value
                    drHutang.Item("Nama") = .Cells("Supplier_Name").Value
                    drHutang.Item("Tgl_Terima_Barang") = .Cells("Tgl_Terima_Barang").Value
                    drHutang.Item("Faktur_No") = .Cells("Faktur_No").Value
                    drHutang.Item("SuratJalan_no") = .Cells("SuratJalan_no").Value
                    drHutang.Item("No_BST") = .Cells("No_BST").Value
                    drHutang.Item("Jatuh_Tempo") = .Cells("Jatuh_Tempo").Value.ToString
                    drHutang.Item("NilaiPO") = .Cells("NilaiPO").Value
                    drHutang.Item("Outstanding") = .Cells("Outstanding").Value
                    dtHutang.Rows.Add(drHutang)
                    ' MsgBox(dtHutang.Rows(i).Item("Jatuh_Tempo"))

                End With
                insert = 1
            End If
            i = i + 1
        End While



        If insert = 1 Then
            frmchild = frmPrint
            frmchild.dtDaftarHutang = dtHutang
            frmchild.dph = txt_DocNo.Text
            frmchild.ReportName = "Daftar Hutang"
            frmchild.Show()
        Else
            MessageBox.Show("Please Choose Data for Print", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn.Close()
            Exit Sub
        End If
       
    End Sub
    Private Sub cb_suppID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_suppID.SelectedIndexChanged
        Dim dt_TB As New DataTable

        'LoadDaftarPelunasan(cb_suppID.SelectedItem)

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select Nama from Master_Supplier where Supp_ID ='" & cb_suppID.SelectedItem & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dt_TB)
            Conn.Close()

            If dt_TB.Rows.Count > 0 Then
                txt_NmSupplier.Text = dt_TB.Rows(0).Item("Nama")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
        'ManageDataGrid()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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
        'Dim JournalNo As String

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
                txt_DocNo.Text = Generate_TranNo(Me.Name)
                'txt_DocNo.Text = "DH1208001"
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_DocNo.Text, 3))
                remarks_Stok = "Transaction : " & txt_DocNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())


                Cmd.CommandText = "EXEC sp_Insert_DaftarPembayaranHutang_Hdr '" & txt_DocNo.Text.Trim & "','" & _
                                             dt_Pelunasan.Value.ToString("yyyy-MM-dd") & "','" & _
                                             period & "','" & _
                                             userlog.UserName & "'"
                Cmd.ExecuteNonQuery()

                'While i < gvPelunasan.Rows.Count
                '    If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                '        With gvPelunasan.Rows(i)
                '            If .Cells("NoBST").Value Is Nothing Or .Cells("NoTTF").Value Is Nothing Then
                '                valid = 0
                '            End If
                '        End With
                '    End If
                '    i = i + 1
                'End While

                'If valid = 0 Then
                '    MessageBox.Show("No TTF dan No BST Harus diisi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Conn.Close()
                '    Exit Sub
                'End If

                i = 0

                While i < gvPelunasan.Rows.Count
                    If gvPelunasan.Rows(i).Cells("chk").Value = True Then
                        With gvPelunasan.Rows(i)
                            Cmd.CommandText = "EXEC sp_Insert_DaftarPembayaranHutang_Dtl '" & txt_DocNo.Text.Trim & "','" & _
                                                 .Cells("Supplier_ID").Value & "','" & _
                                                 .Cells("Tgl_Terima_Barang").Value & "','" & _
                                                 .Cells("Faktur_No").Value & "','" & _
                                                 .Cells("SuratJalan_no").Value & "','" & _
                                                 .Cells("No_BST").Value & "','" & _
                                                 .Cells("Jatuh_Tempo").Value & "','" & _
                                                 .Cells("NilaiPO").Value & "','" & _
                                                .Cells("Outstanding").Value & "','" & _
                                                 userlog.UserName & "'"
                            Cmd.ExecuteNonQuery()
                        End With
                        insert = 1
                    End If
                    i = i + 1
                End While

                If insert = 1 Then
                    MsgBox("No Daftar Pembayaran Hutang  " & txt_DocNo.Text.Trim & " Has been Saved")
                Else
                    MsgBox("Pilih data yang ingin disave")
                    Conn.Close()
                    Exit Sub
                End If

                ObjTrans.Commit()
                Conn.Close()

                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
                ' ClearData()
                btnSave.Enabled = False

                btn_save.Enabled = True
            Catch ex As Exception
                ObjTrans.Rollback()
                Conn.Close()
                MsgBox(ex.Message)
            End Try
        Else
            For Each item As DataRow In dt_hdr.Rows
                If item.RowState = DataRowState.Deleted Then
                    Cmd.CommandText = "Delete From Trans_DaftarPembayaranHutang_Dtl where DPH_No =  '" & txt_DocNo.Text + "' and BST_No = '" & item("No_BST", DataRowVersion.Original).ToString & "'"
                    Cmd.ExecuteNonQuery()
                Else

                End If
            Next
        End If


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadDaftarPelunasan(cb_suppID.SelectedItem)
    End Sub

    Private Sub gvPelunasan_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvPelunasan.CellMouseClick
        If String.IsNullOrEmpty(gvPelunasan.Rows(gvPelunasan.CurrentCell.RowIndex).Cells("No_BST").Value) = False Then
            BSTNO = gvPelunasan.Rows(gvPelunasan.CurrentCell.RowIndex).Cells("No_BST").Value
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dc(1) As DataColumn
        Dim da As Data.DataRow
        dc(0) = dt_hdr.Columns("No_BST")
        dt_hdr.PrimaryKey = dc

        If BSTNO = "" Then
            MessageBox.Show("Pilih 1 data terlebih dahulu untuk di delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("Yakin ingin menghapus baris ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False) = Windows.Forms.DialogResult.Yes Then
            Status_Proses = "Delete"

            da = dt_hdr.Rows.Find(BSTNO)
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

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        dt_Pelunasan.Enabled = True
        btn_save.Enabled = True
        btnSave.Enabled = True
        btnSearch.Enabled = False
        btnDelete.Enabled = True
        
        enableWa(True)
        dtFrom.Enabled = False
        dtTo.Enabled = False
        txt_NmSupplier.Enabled = False
        cb_suppID.Enabled = False
    End Sub

    Private Sub ts_save_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class