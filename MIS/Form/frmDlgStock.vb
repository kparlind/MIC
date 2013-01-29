Imports System.Data.SqlClient

Public Class frmDlgStock
    Dim DA As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim conn As New SqlConnection

    Sub RetrieveWarehouse()
        Dim dtTable As New DataTable
        Dim dr As DataRow

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        cmd.CommandText = "EXEC sp_retreive_Master_Warehouse"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)

        If dtTable.Rows.Count = 0 Then Exit Sub
        dr = dtTable.NewRow
        dr("Warehouse_ID") = "ALL"
        dr("Warehouse_Name") = "ALL"
        dtTable.Rows.Add(dr)

        cb_warehouse.DataSource = dtTable
        cb_warehouse.DisplayMember = GlobalVar.Fields.Warehouse_Name
        cb_warehouse.ValueMember = GlobalVar.Fields.Warehouse_ID
        cb_warehouse.SelectedValue = "ALL"
    End Sub

    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm
        frmChild.valPeriod = CStr(Year(dtp_date.Value)) + IIf(CStr(Month(dtp_date.Value)).Length = 2, CStr(Month(dtp_date.Value)), "0" + CStr(Month(dtp_date.Value)))
        frmChild.valWarehouseID = cb_warehouse.SelectedValue
        frmChild.ReportName = "Persediaan Barang"
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub frmDlgStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim File_Name As String = Application.StartupPath & "\Global.txt"
        Dim Obj As New System.IO.StreamReader(File_Name)
        ConnectStr = Obj.ReadToEnd
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        RetrieveWarehouse()
    End Sub
End Class