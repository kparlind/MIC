Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmViewMonitoringPO
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_PR As New DataTable
    Dim dt_PO As New DataTable
    Dim dr_PR As DataRow


    Private Sub frmViewMonitoringPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt_from.Value = "01/01/" + CStr(Year(Now))
        SetAccess(Me, userlog.AccessID, Me.Name)
        If Conn.State = ConnectionState.Open Then Conn.Close()
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Load_Supplier()
    End Sub

    Private Sub Load_Supplier()
        Dim dt_supp As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "SELECT Supp_ID , Nama FROM Master_Supplier WHERE Active_Flag = 'Y' "
        DA.SelectCommand = Cmd
        DA.Fill(dt_supp)

        cb_Supplier.ValueMember = "Supp_ID"
        cb_Supplier.DisplayMember = "Nama"
        cb_Supplier.DataSource = dt_supp
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim sql As String
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_PR.Clear()
        sql = "Select *,(case when (DateDiff(day,RecGood_Date,TB_Date) < 0) then 'Telat' else 'Ontime' end) as status from " & Chr(13) & _
              "(" & Chr(13) & _
              "Select a.PO_No,b.PO_Date,b.supplier_id,c.nama as Supplier_name,d.item_name,a.uom,b.RecGood_Date from Trans_PO_Dtl a" & Chr(13) & _
              "Left Join " & Chr(13) & _
              "Trans_PO_Hdr b on a.PO_No = b.PO_No " & Chr(13) & _
              "Left Join " & Chr(13) & _
              "master_supplier c on b.supplier_id = c.supp_id " & Chr(13) & _
              "Left Join " & Chr(13) & _
              "master_item_hdr d on a.Item_id = d.Item_id " & Chr(13) & _
              ") x " & Chr(13) & _
              "Left Join " & Chr(13) & _
              "(" & Chr(13) & _
              "Select b.TB_No,b.TB_Date,b.PO_NO,Qty as Qty_Pesan,Qty_rec as Qty_Terima, (qty_rec - qty) as selisih from Trans_TerimaBrg_Dtl a" & Chr(13) & _
              "left join" & Chr(13) & _
              "Trans_TerimaBrg_Hdr b" & Chr(13) & _
              "on a.TB_No = b.TB_No" & Chr(13) & _
              ") y" & Chr(13) & _
              "on x.PO_NO = y.PO_NO" & Chr(13) & _
              "Where PO_Date between '" & dt_from.Value & "' and '" & dt_to.Value & "'"

        If cb_Supplier.SelectedValue <> "" Then
            sql += " And x.Supplier_ID = '" & cb_Supplier.SelectedValue.ToString.Trim & "'"
        End If

        Cmd.CommandText = sql
        DA.SelectCommand = Cmd
        DA.Fill(dt_PR)
        gv_MonitorPO.DataSource = dt_PR
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmViewMonitoringPO_Load(Nothing, Nothing)
    End Sub
End Class