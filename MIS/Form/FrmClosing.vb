Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmClosing
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_Closing As New DataTable
    Dim dt_dtl As New DataTable
    Dim dr_PR As DataRow
    Dim LastSerial As Integer
    Dim remarks_Stok As String
    Dim ClosingId_BySelectedPeriod As String

    Dim year As String
    Dim month As String
    Dim NEW_PERIOD As String

    Private Sub FrmClosing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        LoadPeriod()
    End Sub

    Private Sub btn_proses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_proses.Click
        ' cek tanggal Endate dari period dengan Current date
        Dim today As DateTime
        today = GetCurrDate()

        'lakukan pegecekan in case user nya melakukan closing 2 kali di period yang sama
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Cmd.CommandText = "sp_Retreive_Trans_Closing_ByPeriod '" + cb_period.SelectedValue.ToString.Trim + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_Closing)

        If dt_Closing.Rows.Count = 0 Then
            MessageBox.Show("This period already be processed. Please check again the period.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            ClosingId_BySelectedPeriod = dt_Closing.Rows(0).Item("Closing_No")
            year = dt_Closing.Rows(0).Item("Tahun").ToString
            month = dt_Closing.Rows(0).Item("Bulan").ToString            
        End If

        If month = 12 Then
            year = CStr(CInt(year) + 1)
            month = "01"            
        Else
            month = CStr(CInt(month) + 1)
        End If
        NEW_PERIOD = year + month

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            'txt_TransNo.Text = Generate_TranNo(Me.Name)
            UpdateTranClosing()
            StockOpname()
            Closing_CoaBB()
            Closing_HutangBB()
            Closing_PiutangBB()

            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("this Period : " & cb_period.Text.Trim & " Has been Closed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If LoadFromView Then 'jika form ini dipanggil dari View
                Me.Close()
            Else
                FrmClosing_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateTranClosing()

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Try
            Cmd.CommandText = "Update Trans_Closing set Status_ID = 'CLCL',id_lastupdated = '" & userlog.UserName & "', dt_lastupdated = getdate() " & _
                              "where Period = '" & cb_period.SelectedValue.ToString.Trim & "'"
            Cmd.ExecuteNonQuery()

            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Insert_Trans_History(ClosingId_BySelectedPeriod, Me.Name, "CLOSING") 'Insert History transaction
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StockOpname()
        'Proses ini adalah untuk men generate data awal untuk bulan berikut nya
        Dim dt_stock As New DataTable        
        
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try
            Cmd.CommandText = "EXEC sp_Retreive_InsertStockFisik_ByPeriod '" & cb_period.SelectedValue.ToString.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_stock)

            If dt_stock.Rows.Count > 0 Then
                For Each item As DataRow In dt_stock.Rows
                    Insert_StokMovement_Nextmonth(NEW_PERIOD, item("item_id").ToString.Trim, item("Warehouse_ID").ToString.Trim, ClosingId_BySelectedPeriod, "IN", item("Qty_Verify"), remarks_Stok)
                    Insert_MasterStockBB(item("Warehouse_ID").ToString.Trim, NEW_PERIOD, item("item_id").ToString.Trim, item("Qty_Verify"))
                Next
            End If

        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Insert_StokMovement_Nextmonth(ByVal period As String, ByVal ItemId As String, ByVal Warehouse_ID As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        maxSeq = 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement '" & period & "','" & Warehouse_ID & "','" & ItemId & "','" & TransNo_Ref & "'," & GetMaxSeq(period, Warehouse_ID, ItemId) & ",'" & Sts_Proses & "'," & Qty & ",'" & Remarks & "','" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
        'Conn.Close()
    End Sub

    Private Sub Insert_MasterStockBB(ByVal WH_ID As String, ByVal period As String, ByVal ItemId As String, ByVal Qty As Integer)
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "exec sp_Insert_Master_StockBB '" & period & "', '" & ItemId & "', '" _
                & Replace(Qty, ",", ".") & "' ," & (Replace(Qty, ",", ".") * Replace(GetAveragePrice(WH_ID, ItemId), ",", ".")) & " ,'" _
                & userlog.UserName & "',  'Y'"
        Cmd.ExecuteNonQuery()
        'Conn.Close()
    End Sub


    Private Sub Closing_CoaBB()
        'Proses ini adalah untuk men generate data awal untuk bulan berikut nya
        Dim dt_CoA As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try
            Cmd.CommandText = "Select b.Period, b.AccountID, ABS(Debet_BB) as Debet_BB, ABS(Credit_BB) as Credit_BB,isnull(Debet,0) as Debet,isnull(ABS(Kredit),0) as kredit, isnull((Debet_BB - Debet),0) as Debet_Awal, ABS(isnull((Credit_BB - Kredit),0)) as Kredit_Awal from " & _
                              "(Select period,account_ID as AccountID,isnull(Debet,0) as Debet_BB,isnull(Credit,0) as Credit_BB from Master_COA_BB where period = '" & cb_period.SelectedValue & "') b " & _
                              "Left Join " & _
                              "  ( " & _
                              "      Select period,AccountID, isnull(SUM(AmountDR),0) as Debet, isnull(SUM(AmountCR),0) as Kredit from " & _
                              "      ( " & _
                              "             Select CAST(year(b.JournalDate) as varchar)+CAST(month(b.JournalDate) as varchar) as period,a.JournalID,AccountID,AmountDR,AmountCR from JournalItem a " & _
                              "          Left Join " & _
                              "              Journal b " & _
                              "           on a.JournalID = b.JournalID " & _
                              "           where CAST(year(b.JournalDate) as varchar)+CAST(month(b.JournalDate) as varchar) = '" & cb_period.SelectedValue & "' " & _
                              "       ) a " & _
                              "      group by period,AccountID " & _
                              "   )aa " & _
                              " on b.AccountID = aa.AccountID "
            DA.SelectCommand = Cmd
            DA.Fill(dt_CoA)

            If dt_CoA.Rows.Count > 0 Then
                For Each item As DataRow In dt_CoA.Rows
                    Insert_CoABBNextmonth_Closing(NEW_PERIOD, item("Accountid").ToString.Trim, item("Debet_Awal"), item("Kredit_Awal"))
                Next
            Else
                MessageBox.Show("Closing CoABB get no data. Please Make sure the Closing Period")
            End If

        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Insert_CoABBNextmonth_Closing(ByVal period As String, ByVal Account_ID As String, ByVal Debet As Decimal, ByVal Credit As Decimal)
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try
            Cmd.CommandText = "EXEC sp_Insert_Master_COA_BB '" & period & "','" & Account_ID & "'," & Debet & "," & Credit & ",'" & userlog.UserName & "','Y'"
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Conn.Close()
        End Try

    End Sub

    Private Sub Closing_HutangBB()
        Dim dt_Hutang As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        
        Try
            'Cmd.CommandText = "select supplier_id,TB_NO,z.Grand_Total as Outstanding,z.Grand_Total,SuratJalan_no,faktur_no,z.PO_No  from trans_terimabrg_hdr z " & vbCrLf & _
            '                  "left join Trans_PO_Hdr x " & vbCrLf & _
            '                  "on z.PO_No = x.PO_No " & vbCrLf & _
            '                  "            where TB_No not in " & vbCrLf & _
            '                  "(  " & vbCrLf & _
            '                  " select Doc_NO from Trans_PelunasanHutangSupplier_Dtl " & vbCrLf & _
            '                  ") " & vbCrLf & _
            '                  "            union " & vbCrLf & _
            '                  "select supplier_id,TB_NO,Outstanding,c.Grand_Total,SuratJalan_no,faktur_no,c.PO_No from ( " & vbCrLf & _
            '                  " Select a.TB_NO,(ttl_Hutang - isnull(ttl_Bayar,0) - isnull(potongan,0) - isnull(retur,0)) as Outstanding, Grand_Total ,SuratJalan_no,faktur_no,PO_No from " & vbCrLf & _
            '                  " ( " & vbCrLf & _
            '                  "        select TB_NO, " & vbCrLf & _
            '                  "        Grand_Total as ttl_Hutang, " & vbCrLf & _
            '                  "            suratjalan_no, faktur_no, Grand_Total, PO_No " & vbCrLf & _
            '                  "            from Trans_TerimaBrg_Hdr " & vbCrLf & _
            '                  " ) as a " & vbCrLf & _
            '                  "            Left Join " & vbCrLf & _
            '                  " ( " & vbCrLf & _
            '                  "        select Doc_NO as TB_No,SUM(Jumlah_Bayar) as ttl_Bayar,isnull(sum(potongan),0) as potongan from Trans_PelunasanHutangSupplier_Dtl " & vbCrLf & _
            '                  "        where tipe_pembayaran = 'Cash' or tipe_pembayaran = 'Bank' " & vbCrLf & _
            '                  "        or PH_No in  " & vbCrLf & _
            '                  "        (select PH_No from trans_pencairangiro where status = 'Cair')  " & vbCrLf & _
            '                  "        group by Doc_NO  " & vbCrLf & _
            '                  " ) as b on a.TB_NO = b.Tb_NO " & vbCrLf & _
            '                  "            Left Join " & vbCrLf & _
            '                  " (  " & vbCrLf & _
            '                  "    select Doc_No as TB_no,isnull(sum(amount),0) as retur from trans_pelunasanhutangsupplier_dtl a " & vbCrLf & _
            '                  "    left join trans_pelunasanhutangsupplier_hdr b " & vbCrLf & _
            '                  "    on a.PH_no = b.ph_no " & vbCrLf & _
            '                  "    left join trans_retur_dtl c " & vbCrLf & _
            '                  "    on a.retur_no = c.retur_no  " & vbCrLf & _
            '                  "    left join master_supplier d " & vbCrLf & _
            '                  "    on b.supp_ID = d.supp_ID " & vbCrLf & _
            '                  "            where  " & vbCrLf & _
            '                  "    a.retur_no <> '' " & vbCrLf & _
            '                  "    group by doc_no " & vbCrLf & _
            '                  " )  as f on a.TB_no = f.TB_no " & vbCrLf & _
            '                  ") as c " & vbCrLf & _
            '                  "left join Trans_PO_Hdr d " & vbCrLf & _
            '                  "on d.PO_No = c.PO_No " & vbCrLf & _
            '                  "where Outstanding <> 0 "

            Cmd.CommandText = "Select supp_id,SUM(Debet) as Debet,SUM(Credit) as Credit from " & vbCrLf & _
                              "( " & vbCrLf & _
                              "Select supp_id,Debet,Credit from Master_Utang_BB " & vbCrLf & _
                              "where period = '" & cb_period.SelectedValue.ToString & "' " & vbCrLf & _
                              "UNION " & vbCrLf & _
                              "  Select b.SUpplier_ID,SUM(AmountDR) as Debet ,SUM(AmountCR) as kredit from trans_TerimaBrg_Hdr a " & vbCrLf & _
                              "Left Join  " & vbCrLf & _
                              "  Trans_PO_Hdr b " & vbCrLf & _
                              "on a.Po_No = b.Po_No " & vbCrLf & _
                              "Left Join  " & vbCrLf & _
                              "  Journal c " & vbCrLf & _
                              "on a.TB_No = c.RefNo " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  JournalItem d " & vbCrLf & _
                              "on c.JournalID = d.JournalID " & vbCrLf & _
                              "where(Year(Journaldate) = '" & year & "' And Month(JournalDate) = '" & month & "') " & vbCrLf & _
                              "Group by Supplier_ID " & vbCrLf & _
                              "UNION  " & vbCrLf & _
                              "Select Supp_ID,SUM(AmountDR) as Debet ,SUM(AmountCR) as kredit from Trans_PelunasanHutangSupplier_Hdr a " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  Journal c " & vbCrLf & _
                              "on a.PH_No = c.RefNo " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  JournalItem d " & vbCrLf & _
                              "on c.JournalID = d.JournalID " & vbCrLf & _
                              "where(Year(Journaldate) = '" & year & "' And Month(JournalDate) = '" & month & "') " & vbCrLf & _
                              "Group by Supp_ID " & vbCrLf & _
                              ") as al " & vbCrLf & _
                              "group by Supp_ID "
            DA.SelectCommand = Cmd
            DA.Fill(dt_Hutang)

            If dt_Hutang.Rows.Count > 0 Then
                For Each item As DataRow In dt_Hutang.Rows
                    Insert_HutangBB_Nextmonth(NEW_PERIOD, item("Supp_ID").ToString.Trim, item("Debet"), item("Credit"))
                Next
            Else
                MessageBox.Show("Closing Hutang BB get no data. Please Make sure the Closing Period")
            End If
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Insert_HutangBB_Nextmonth(ByVal period As String, ByVal SupplierID As String, ByVal debet As Decimal, ByVal kredit As Decimal)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Insert_Master_Utang_BB '" & period & "','" & SupplierID & "'," & debet & "," & kredit & ",'" & userlog.UserName & "','Y'"
        Cmd.ExecuteNonQuery()
        'Conn.Close()
    End Sub

    Private Sub Closing_PiutangBB()
        Dim dt_Piutang As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Try
            Cmd.CommandText = "Select Cust_ID,SUM(Debet) as Debet,SUM(Credit) as Credit from " & vbCrLf & _
                              "( " & vbCrLf & _
                              "Select Cust_ID,Debet,Credit from Master_Piutang_BB " & vbCrLf & _
                              "where period = '" & cb_period.SelectedValue.ToString & "' " & vbCrLf & _
                              "UNION " & vbCrLf & _
                              "  Select a.Cust_ID,SUM(AmountDR) as Debet ,SUM(AmountCR) as kredit from trans_Invoice_Piutang a " & vbCrLf & _
                              "Left Join  " & vbCrLf & _
                              "  Journal c " & vbCrLf & _
                              "on a.Faktur_No = c.RefNo " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  JournalItem d " & vbCrLf & _
                              "on c.JournalID = d.JournalID " & vbCrLf & _
                              "where(Year(Journaldate) = '" & year & "' And Month(JournalDate) = '" & month & "') " & vbCrLf & _
                              "Group by Cust_ID " & vbCrLf & _
                              "UNION  " & vbCrLf & _
                              "Select Cust_ID,SUM(AmountDR) as Debet ,SUM(AmountCR) as kredit from Trans_PelunasanPiutang_Dtl a " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  Journal c " & vbCrLf & _
                              "on a.PP_No = c.RefNo " & vbCrLf & _
                              "Left Join " & vbCrLf & _
                              "  JournalItem d " & vbCrLf & _
                              "on c.JournalID = d.JournalID " & vbCrLf & _
                              "where(Year(Journaldate) = '" & year & "' And Month(JournalDate) = '" & month & "') " & vbCrLf & _
                              "Group by Cust_ID " & vbCrLf & _
                              ") as al " & vbCrLf & _
                              "group by Cust_ID "
            DA.SelectCommand = Cmd
            DA.Fill(dt_Piutang)

            If dt_Piutang.Rows.Count > 0 Then
                For Each item As DataRow In dt_Piutang.Rows
                    Insert_PiutangBB_Nextmonth(NEW_PERIOD, item("Cust_ID").ToString.Trim, item("Debet"), item("Credit"))
                Next
            Else
                MessageBox.Show("Closing Piutang BB get no data. Please Make sure the Closing Period")
            End If
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show("Error : " & ex.Message.Trim, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Insert_PiutangBB_Nextmonth(ByVal period As String, ByVal CustID As String, ByVal debet As Decimal, ByVal kredit As Decimal)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Insert_Master_Piutang_BB '" & period & "','" & CustID & "'," & debet & "," & kredit & ",'" & userlog.UserName & "','Y'"
        Cmd.ExecuteNonQuery()
        'Conn.Close()
    End Sub

    Private Sub LoadPeriod()
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select Period from Trans_Closing where Status_ID <> 'CLCL'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count > 0 Then
            cb_period.DataSource = dt
            cb_period.DisplayMember = "Period"
            cb_period.ValueMember = "Period"
        Else
            MessageBox.Show("Weird, there are no Period Open now. Please contact IT Staff for check the Closing data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub
End Class