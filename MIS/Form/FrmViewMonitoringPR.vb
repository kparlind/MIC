Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class FrmViewMonitoringPR
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_PR As New DataTable
    Dim dt_PO As New DataTable
    Dim dr_PR As DataRow

    Private Sub FrmViewMonitoringPR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt_from.Value = "01/01/" + CStr(Year(Now))

        If Conn.State = ConnectionState.Open Then Conn.Close()

        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        SetAccess(Me, userlog.AccessID, Me.Name)
        Load_Department()
        Load_Item()
    End Sub

    Private Sub Load_Department()
        Dim dt_supp As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'Pindahin dr datatable PO ke datatable TrmBrg                            
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Department "
        DA.SelectCommand = Cmd
        DA.Fill(dt_supp)

        cb_Requesterdepart.ValueMember = "Department_ID"
        cb_Requesterdepart.DisplayMember = "Department_Name"
        cb_Requesterdepart.DataSource = dt_supp
    End Sub

    Private Sub Load_Item()
        Dim dt_Item As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'Pindahin dr datatable PO ke datatable TrmBrg                            
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr "
        DA.SelectCommand = Cmd
        DA.Fill(dt_Item)

        'cb_item.Items.Insert(0, "All")
        cb_item.Items.Add("")
        cb_item.ValueMember = "item_ID"
        cb_item.DisplayMember = "item_Name"
        cb_item.DataSource = dt_Item

    End Sub

    Private Sub Search_MonitorPR()
        Dim sql As String
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_PR.Clear()
        sql = "Select * from ( " & Chr(13) & _
              "Select b.PR_No,b.PR_Date,f.item_id,f.Item_Name,a.UoM,a.Qty as Qty_PR,e.Department_id,a.Remarks,IsNull(d.qty_PO,0) as qty_PO," & Chr(13) & _
              "Case when (a.Qty > IsNull(d.qty_PO,0)) then 'Belum Lunas' else 'Lunas' end  as status " & Chr(13) & _
              "from Trans_PR_item_Dtl a " & Chr(13) & _
              "left join Trans_PR_Hdr b on a.PR_No = b.PR_No " & Chr(13) & _
              "Left Join " & Chr(13) & _
              "( " & Chr(13) & _
              "   Select PR_No,Item_Id,SUM(Qty) as qty_PO from Trans_PO_dtl a " & Chr(13) & _
              "  Left Join " & Chr(13) & _
              "   Trans_PO_Hdr b on a.PO_No = b.PO_No " & Chr(13) & _
              "   GROUP by PR_NO,Item_ID " & Chr(13) & _
              ") d " & Chr(13) & _
              "on a.PR_No = d.PR_No and a.Item_ID = d.Item_ID " & Chr(13) & Chr(13) & _
              "left join " & Chr(13) & Chr(13) & _
              "master_employee e on e.username = b.requester " & Chr(13) & _
              "left join " & Chr(13) & _
              "Master_Item_Hdr f on a.item_ID = f.Item_ID " & Chr(13) & _
              ") x " & Chr(13) & _
              "Where PR_Date between '" & dt_from.Value & "' and '" & dt_to.Value & "'"

        If cb_Requesterdepart.SelectedValue <> "" Then
            sql += " And x.Department_ID = '" & cb_Requesterdepart.SelectedValue.ToString.Trim & "'"
        End If
        If cb_item.SelectedValue <> "" Then
            sql += " And x.Item_ID = '" & cb_item.SelectedValue.ToString.Trim & "'"
        End If
        If cb_Status.SelectedValue <> "" Then
            sql += " And x.Status = '" & cb_Status.SelectedText & "'"
        End If

        Cmd.CommandText = sql
        DA.SelectCommand = Cmd
        DA.Fill(dt_PR)
        gv_MonitorPR.DataSource = dt_PR
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Search_MonitorPR()
    End Sub

    
End Class