Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRecommededSupplier

#Region "Variable Declaration"
    Private conn As New SqlConnection
    Private cmd As New SqlCommand
    Private DA As New SqlDataAdapter
#End Region

#Region "Procedure & Function"

    Sub RetrieveData()
        Dim dtTable As New DataTable

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()

        Select Case rb_barang.Checked
            Case True
                cmd.CommandText = "sp_Get_RecommendedSupplier_ByKey 'BARANG', '" & _
                                txt_ItemID.Text.Trim & "', '" & _
                                cb_price.SelectedItem & "', '" & _
                                cb_ontime.SelectedItem & "', '" & _
                                cb_quality.SelectedItem & "'"
            Case Else
                cmd.CommandText = "sp_Get_RecommendedSupplier_ByKey 'JASA', '" & _
                                txt_ItemID.Text.Trim & "', '" & _
                                cb_price.SelectedItem & "', '" & _
                                cb_ontime.SelectedItem & "', '" & _
                                cb_quality.SelectedItem & "'"
        End Select

        DA.SelectCommand = cmd
        DA.Fill(dtTable)
        conn.Close()

        dgv_data.DataSource = dtTable
    End Sub

    Sub SetGrid()
        dgv_data.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv_data.Columns(7).DefaultCellStyle.Format = "#,##0.#0"
        dgv_data.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

#End Region

#Region "Event Handler"
    Private Sub frmRecommededSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        cb_price.SelectedItem = "1"
        cb_ontime.SelectedItem = "2"
        cb_quality.SelectedItem = "3"

        txtSupplierID.Text = String.Empty
        txtSupplierName.Text = String.Empty

        Call RetrieveData()
        Call SetGrid()

    End Sub

    Private Sub txt_ItemID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ItemID.KeyDown
        If e.KeyCode = Keys.F1 Then

            Select Case rb_barang.Checked
                Case True
                    CallandGetSearchData("SELECT Item_id AS [Item ID], Item_Name AS [Item Name], UoM from Master_Item_Hdr WHERE Active_Flag = 'Y'", "Item ID", "Item Name", "UoM", "", "")
                Case Else
                    CallandGetSearchData("SELECT Jasa_id AS [Jasa ID], Jasa_Name AS [Jasa Name] from Master_Jasa WHERE Active_Flag = 'Y'", "Jasa ID", "Jasa Name", "", "", "")
            End Select

            txt_ItemID.Text = frmSearch.txtResult1.Text.Trim

            If txt_ItemID.Text.Trim = "" Then Exit Sub

            Call RetrieveData()
        ElseIf e.KeyCode = Keys.Enter Then
            Call RetrieveData()
        End If
    End Sub

    Private Sub dgv_data_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_data.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtSupplierID.Text = dgv_data.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
            txtSupplierName.Text = dgv_data.Rows(e.RowIndex).Cells(2).Value.ToString.Trim

            Me.Close()
        End If
    End Sub

    Private Sub cb_ontime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_ontime.SelectedIndexChanged
        Call RetrieveData()
    End Sub

    Private Sub cb_price_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_price.SelectedIndexChanged
        Call RetrieveData()
    End Sub

    Private Sub cb_quality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_quality.SelectedIndexChanged
        Call RetrieveData()
    End Sub

#End Region

 
End Class