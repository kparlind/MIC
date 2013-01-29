Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmViewStockMovementToko
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_stock As New DataTable
    Dim dt_dtl As New DataTable
    Dim dr_PR As DataRow

    Private Sub frmViewStockMovementToko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Load_Item()
        btn_cari_Click(Nothing, Nothing)
    End Sub

    Private Sub Load_Item()
        Dim dt_item As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'Pindahin dr datatable PO ke datatable TrmBrg                            
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Item_Hdr "
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        Dim i As Integer = 0
        cb_Item.Items.Insert(i, "")
        For Each item As DataRow In dt_item.Rows
            i += 1
            cb_Item.Items.Insert(i, item("item_name").ToString.Trim)
        Next
    End Sub

    Private Sub Load_SummaryStock()
        Dim bulan, tahun, gabung As String
        Dim tmp As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        tmp = Month(dt_from.Value)
        If tmp < 10 Then
            bulan = "0" + CStr(tmp)
        Else
            bulan = CStr(tmp)
        End If
        tahun = Year(dt_from.Value)
        gabung = tahun + bulan

        dt_stock.Clear()
        Cmd.CommandText = "EXEC sp_Retreive_TotalStock_Toko_byPeriodItem '" & gabung & "','" & cb_Item.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_stock)

        gv_Stock.DataSource = dt_stock
    End Sub

    Private Sub Load_StockDetail(ByVal Period As String, ByVal ItemId As String)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_dtl.Clear()
        Cmd.CommandText = "EXEC sp_Retreive_Trans_StockMovement_Toko_byKey '" & Period & "','" & ItemId & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_dtl)

        gv_detail.DataSource = dt_dtl
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Load_SummaryStock()
        If dt_stock.Rows.Count > 0 Then
            Load_StockDetail(gv_Stock.Rows(gv_Stock.CurrentCell.RowIndex).Cells("Period").Value.ToString.Trim, gv_Stock.Rows(gv_Stock.CurrentCell.RowIndex).Cells("Item_name").Value.ToString.Trim)
        Else
            Load_StockDetail("", "")
        End If
    End Sub


    Private Sub gv_Stock_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gv_Stock.MouseClick
        Load_StockDetail(gv_Stock.Rows(gv_Stock.CurrentCell.RowIndex).Cells("Period").Value.ToString.Trim, gv_Stock.Rows(gv_Stock.CurrentCell.RowIndex).Cells("Item_name").Value.ToString.Trim)
    End Sub
End Class