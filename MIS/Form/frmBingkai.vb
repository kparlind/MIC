Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmBingkai
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt As New DataTable

    Private Sub frmBingkai_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadGrid_Inbox()
        LoadGrid_FollowUp()
        LoadGrid_Oustanding()
    End Sub

    Private Sub LoadGrid_Inbox()
        Dim query As String

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_dtl.Clear()

        query = "'','','',''"
        Cmd.CommandText = "EXEC sp_Retreive_INBOX 'W','Y','" & userlog.UserName & "'," & query

        'MessageBox.Show(Cmd.CommandText)
        DA.SelectCommand = Cmd
        DA.Fill(dt_dtl)


        gv_inbox.DataSource = dt_dtl
        gv_inbox.Columns.Item(0).Width = "100"
        gv_inbox.Columns.Item(1).Width = "100"
        gv_inbox.Columns.Item(2).Width = "480"

    End Sub

    Private Sub LoadGrid_FollowUp()        
        If userlog.Insert_Price = "Y" Then
            gv_FollowUp.DataSource = FollowUp_Purchasing()
        ElseIf userlog.Department_ID = "DT007" Then 'Department Gudang
            gv_FollowUp.DataSource = FollowUp_Gudang()
        ElseIf userlog.Department_ID = "DT007" Then 'Department Marketing
            'gv_FollowUp.DataSource = FollowUp_Gudang()
        ElseIf userlog.Department_ID = "DT007" Then 'Department Project
            'gv_FollowUp.DataSource = FollowUp_Gudang()

        End If

        'gv_FollowUp.Columns.Item(0).Width = "80"
        'gv_FollowUp.Columns.Item(1).Width = "200"
        'gv_FollowUp.Columns.Item(2).Width = "70"
        'gv_FollowUp.Columns.Item(3).Width = "70"
        'gv_FollowUp.Columns.Item(4).Width = "100"
    End Sub

    Function FollowUp_Purchasing() As DataTable
        Dim dt_followUp As New DataTable
        'Dim query As String

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_followUp.Clear()

        Cmd.CommandText = "Select PR_No,Item_Name, Qty_Request, Qty_PO, (Qty_Request - Qty_PO) as Outstanding from " & vbCrLf & _
                          "(" & vbCrLf & _
                       "    Select a.PR_No,b.Requester,a.Item_ID,d.item_name,isnull(a.qty,0) as Qty_Request,isnull(c.Qty,0) as Qty_PO from Trans_PR_Item_Dtl a " & vbCrLf & _
                          "  Left Join " & vbCrLf & _
                          "    Trans_PR_Hdr b " & vbCrLf & _
                          "  on a.PR_No = b.PR_no  " & vbCrLf & _
                          "  Left Join " & vbCrLf & _
                          "    Trans_PO_Dtl c " & vbCrLf & _
                          "  on a.PR_No = c.PR_no and a.Item_ID = c.Item_ID " & vbCrLf & _
                          "  Left Join " & vbCrLf & _
                          "    Master_Item_Hdr d " & vbCrLf & _
                          "   on a.Item_Id = d.Item_Id " & vbCrLf & _
                          ") a " & vbCrLf & _
                          "where (Qty_Request - Qty_PO) > 0 " & vbCrLf & _
                          " and Requester = '" & userlog.UserName & "' "

        DA.SelectCommand = Cmd
        DA.Fill(dt_followUp)
        FollowUp_Purchasing = dt_followUp
    End Function

    Function FollowUp_Gudang() As DataTable
        Dim dt_followUp As New DataTable
        'Dim query As String

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_followUp.Clear()

        Cmd.CommandText = "Select Period,Warehouse_name,Item_Name," & _
                          "(Case when Current_Stock >= Max_Stock then 'Over Stock' else 'Less Stock' end) as status, " & _
                          "Current_Stock,Min_Stock as MinimumStock, Max_Stock as MaximumStock from " & _
                          "( " & _
                          "	Select V.Period,V.Warehouse_ID,W.Warehouse_name,v.Item_Id,v.Item_name,Min_Stock,Max_Stock, IsNull((TTl_IN - TTL_OUT),0) as Current_Stock from " & _
                          "	( " & _
                          "		Select '" & Generate_Period() & "' as period,Item_ID,Item_Name,Warehouse_ID,Min_Stock,Max_Stock from Master_Item_Hdr where Active_Flag = 'Y' " & _
                          "	)as V " & _
                          "        Left Join " & _
                          "	( " & _
                          "		Select x.Period,x.Warehouse_ID,x.Item_id, TTl_IN, (Case when TTL_OUT is null then 0 else TTL_Out end) as ttl_out from " & _
                          "		( " & _
                          "			Select Period,Warehouse_ID,item_id,SUM(QTY) as Ttl_IN from Trans_Stock_Movement " & _
                          "			where type_proses = 'IN' and period = '" & Generate_Period() & "' " & _
                          "			group by Period,Warehouse_ID,item_id " & _
                          "		) as x " & _
                          "        Left Join " & _
                          "		( " & _
                          "			Select Period,Warehouse_ID,item_id,SUM(QTY) as Ttl_OUT from Trans_Stock_Movement " & _
                          "			where type_proses = 'OUT' and period = '" & Generate_Period() & "' " & _
                          "			group by Period,Warehouse_ID,item_id " & _
                          "		) as y " & _
                          "	  on x.Period = y.Period and x.Warehouse_ID = y.Warehouse_ID and x.item_id = y.item_id " & _
                          "	) Z " & _
                          "	on Z.Item_ID = V.Item_ID  " & _
                          "        Left Join " & _
                          "		Master_Warehouse as W " & _
                          "	on V.Warehouse_ID = W.Warehouse_ID " & _
                          "	where V.period = '" & Generate_Period() & "' " & _
                          ") xx " & _
                          "Where Current_Stock >= Max_Stock or Current_Stock <= Min_Stock " & _
                          "order by Warehouse_Name "
        DA.SelectCommand = Cmd
        DA.Fill(dt_followUp)
        FollowUp_Gudang = dt_followUp
    End Function

    Private Sub LoadGrid_Oustanding()
        If userlog.Insert_Price = "Y" Then
            gv_outstanding.DataSource = Outs_Purchasing()
        ElseIf userlog.Department_ID = "DT001" Then
            gv_outstanding.DataSource = Outs_Marketing()
        End If
    End Sub

    Function Outs_Purchasing() As DataTable
        Dim dt_Outs As New DataTable
        'Dim query As String

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_Outs.Clear()

        'query = ""
        'If userlog.Insert_Price = "N" Then ' jika bukan Purchasing
        '    query = " and Requester = '" & userlog.UserName & "' "
        'End If

        Cmd.CommandText = "Select PR_No,PR_Date,Qty_Request,a.Status_ID,('Item Name : ' + Item_Name) as Keterangan, Qty_PO, (Qty_Request - Qty_PO) as Outstanding from " & vbCrLf & _
                          "(" & vbCrLf & _
                          "	Select a.PR_No,b.PR_Date,b.Requester,b.Status_ID,a.Item_ID,d.Item_Name,isnull(a.qty,0) as Qty_Request,isnull(c.Qty,0) as Qty_PO from Trans_PR_Item_Dtl a " & vbCrLf & _
                          "        Left Join" & vbCrLf & _
                          "        Trans_PR_Hdr b " & vbCrLf & _
                          "   on a.PR_No = b.PR_no " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Trans_PO_Dtl c " & vbCrLf & _
                          "   on a.PR_No = c.PR_no and a.Item_ID = c.Item_ID   " & vbCrLf & _
                          "        Left Join  " & vbCrLf & _
                          "        Master_Item_Hdr d  " & vbCrLf & _
                          "   on a.Item_Id = d.Item_Id   " & vbCrLf & _
                          ") a " & vbCrLf & _
                          "where (Qty_Request - Qty_PO) > 0  " & vbCrLf & _
                          "        UNION " & vbCrLf & _
                          "------Purchasing yg blom ada TerimaBrg nya  " & vbCrLf & _
                          "Select *, (Qty_PO - Qty_TB) as Outstanding from " & vbCrLf & _
                          "( " & vbCrLf & _
                          "	Select a.PO_NO,aa.RecGood_Date,a.Qty as Qty_PO,aa.Status_ID,('Supplier Name : ' + d.Nama) as Keterangan, " & vbCrLf & _
                          "    isNUll(c.Qty_Rec,0) as Qty_TB from Trans_PO_Dtl a " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Trans_PO_Hdr aa " & vbCrLf & _
                          "On a.PO_No = aa.Po_No " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Trans_TerimaBrg_Hdr b " & vbCrLf & _
                          "on a.PO_No = b.PO_No " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Trans_TerimaBrg_Dtl c  " & vbCrLf & _
                          "on b.TB_No = c.TB_No and a.Item_id = c.Item_Id " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Master_Supplier d " & vbCrLf & _
                          "on aa.Supplier_ID = d.Supp_ID " & vbCrLf & _
                          "where aa.Status_ID <> 'CMP'  " & vbCrLf & _
                          ") x " & vbCrLf & _
                          "where (Qty_PO - Qty_TB) > 0 " & vbCrLf & _
                          "        UNION " & vbCrLf & _
                          "-----Terima Brg yg belum di proses " & vbCrLf & _
                          "Select TB_NO,TB_Date,'',Status_ID,('PO No  = ' + PO_NO + '; Due date Payment : ' + Convert(varchar(10),dt_duedtPayment)) as Keterangan,'','' from Trans_TerimaBrg_Hdr a " & vbCrLf & _
                          "        Left Join " & vbCrLf & _
                          "        Master_Warehouse b " & vbCrLf & _
                          "on a.warehouse_Id = b.warehouse_Id " & vbCrLf & _
                          "where Status_ID = 'WAFP'  "

        DA.SelectCommand = Cmd
        DA.Fill(dt_Outs)

        Outs_Purchasing = dt_Outs

    End Function

    Function Outs_Marketing() As DataTable
        Dim dt_Outs As New DataTable
        'Dim query As String

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_Outs.Clear()

        Cmd.CommandText = "Select * from " & vbCrLf & _
                          "( " & vbCrLf & _
                          "Select PHP_No, PHP_Date, Convert(varchar(20),Total_PHP) as Total_PHProject,Status_ID,('Survey No : ' + Survey_No) as Keterangan,dt_lastupdated from Trans_PHProject_Hdr " & vbCrLf & _
                          "where Status_ID = 'WAMA' and " & vbCrLf & _
                          "PHP_No not in (Select PHP_No from Trans_PHMarketing_Hdr) " & vbCrLf & _
                          "UNION " & vbCrLf & _
                          "   Select Survey_no,Survey_Date,isNull(Nama,'-') as CustomerName,a.Status_ID,Survey_Remark as Keterangan,a.dt_lastupdated  from Trans_Survey_Hdr a  " & vbCrLf & _
                          "Left Join " & vbCrLf & _
                          "   Master_Customer b " & vbCrLf & _
                          "on a.Cust_ID = b.Cust_ID " & vbCrLf & _
                          "where a.Status_ID <> 'CMP' " & vbCrLf & _
                          "UNION " & vbCrLf & _
                          "   Select PHM_No,PHM_Date,Convert(varchar(20),Total_PHM) as Total_PHMarketing, a.status_id,('Status : ' + Status_Name ) as keterangan,a.dt_lastupdated from Trans_PHMarketing_Hdr a " & vbCrLf & _
                          "Left Join " & vbCrLf & _
                          "   master_status b " & vbCrLf & _
                          "on a.status_id = b.status_id " & vbCrLf & _
                          "where PHM_No not in (Select PHM_No from Trans_Projects) " & vbCrLf & _
                          ") g " & vbCrLf & _
                          "order by g.dt_lastupdated ASC "

        DA.SelectCommand = Cmd
        DA.Fill(dt_Outs)
        Outs_Marketing = dt_Outs
    End Function

    'Private Sub OpenForm(ByVal Prefix As String)
    '    Dim dt_form As New DataTable
    '    If Conn.State = ConnectionState.Closed Then
    '        Conn.Open()
    '    End If

    '    Cmd.CommandText = "EXEC sp_Retreive_Serial_ByPrefix '" + Prefix + "'"
    '    DA.SelectCommand = Cmd
    '    DA.Fill(dt_form)

    '    If dt_form.Rows.Count > 0 Then
    '        If dt_form.Rows(0).Item("Serial_ID") = "FrmTerimaBrg" Then
    '            Dim form As New frmTerimaBrg
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmPO" Then
    '            Dim form As New frmPO
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmUpdateStok" Then
    '            Dim form As New FrmUpdateStok
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            form.ShowDialog()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmRequestPembelianBrg" Then
    '            Dim form As New frmRequestPembelianBrg
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmPenawaranHargaProject" Then
    '            Dim form As New FrmPenawaranHargaProject
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.ShowDialog()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmPenawaranHargaMarketing" Then
    '            Dim form As New frmPenawaranHargaMarketing
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.ShowDialog()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmSurvey" Then
    '            Dim form As New frmSurvey
    '            form.txtSurveyNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            form.FromInbox = True
    '            form.NewFromView = False
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.ShowDialog()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "frmRequestPembelianBrg" Then
    '            Dim form As New frmRequestPembelianBrg
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "frmInputStockFisik" Then
    '            Dim form As New FrmInputStockFisik
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmOrderMaintance" Then
    '            Dim form As New frmOrderMaintance
    '            form.txt_transno.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmPermintaanPengeluaranBahan" Then
    '            Dim form As New frmPermintaanPengeluaranBahan
    '            form.txtBPBNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "frmPengembalianBarang" Then
    '            Dim form As New frmPengembalianBarang
    '            form.TransNo = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            'form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            'Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmOrderPabrikasi" Then
    '            Dim form As New FrmOrderPabrikasi
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "FrmSPK" Then
    '            Dim form As New FrmOrderPabrikasi
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            'form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            'Me.Close()
    '        ElseIf dt_form.Rows(0).Item("Serial_ID") = "frmTransferStockToko" Then
    '            Dim form As New frmTransferStockToko
    '            form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
    '            id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
    '            form.CallerForm = "INBOX"
    '            form.MdiParent = MDIFrm
    '            form.Show()
    '            Me.Close()
    '        Else
    '            MessageBox.Show("This Form Has not been Maintained", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '            Exit Sub
    '        End If
    '    Else
    '        MessageBox.Show("System can found Prefix : " + Prefix + " on table Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub OpenForm_1(ByRef GridObject As Object, ByVal Prefix As String)
        Dim dt_form As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retreive_Serial_ByPrefix '" + Prefix + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_form)

        If dt_form.Rows.Count > 0 Then
            If dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMTERIMABRG" Then
                Dim form As New frmTerimaBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPO" Then
                Dim form As New frmPO
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMUPDATESTOK" Then
                Dim form As New FrmUpdateStok
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMREQUESTPEMBELIANBRG" Then
                Dim form As New frmRequestPembelianBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENAWARANHARGAPROJECT" Then
                Dim form As New FrmPenawaranHargaProject
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENAWARANHARGAMARKETING" Then
                Dim form As New frmPenawaranHargaMarketing
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMSURVEY" Then
                Dim form As New frmSurvey
                form.txtSurveyNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                form.FromInbox = True
                form.NewFromView = False
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMREQUESTPEMBELIANBRG" Then
                Dim form As New frmRequestPembelianBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMINPUTSTOCKFISIK" Then
                Dim form As New FrmInputStockFisik
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMORDERMAINTANCE" Then
                Dim form As New frmOrderMaintance
                form.txt_transno.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPERMINTAANPENGELUARANBAHAN" Then
                Dim form As New frmPermintaanPengeluaranBahan
                form.txtBPBNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENGEMBALIANBARANG" Then
                Dim form As New frmPengembalianBarang
                form.TransNo = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                'Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMORDERPABRIKASI" Then
                Dim form As New FrmOrderPabrikasi
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMSPK" Then
                Dim form As New FrmOrderPabrikasi
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                'Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMTRANSFERSTOCKTOKO" Then
                Dim form As New frmTransferStockToko
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPEMAKAIANBAHAN" Then
                Dim form As New frmPemakaianBahan
                form.TransNo = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            Else
                MessageBox.Show("This Form Has not been Maintained", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        Else
            MessageBox.Show("System can found Prefix : " + Prefix + " on table Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
    End Sub


    Private Sub gv_inbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_inbox.DoubleClick
        If gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        OpenForm_1(gv_inbox, Microsoft.VisualBasic.Left(gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value, 2))
    End Sub

    Private Sub gv_outstanding_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_outstanding.DoubleClick
        If gv_outstanding.CurrentRow.DataGridView(0, gv_outstanding.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        OpenForm_1(gv_outstanding, Microsoft.VisualBasic.Left(gv_outstanding.CurrentRow.DataGridView(0, gv_outstanding.CurrentRow.Index).Value, 2))
    End Sub
End Class