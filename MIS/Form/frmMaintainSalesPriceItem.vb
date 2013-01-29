Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmMaintainSalesPriceItem

#Region "Variable Declaration"
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dc(1) As DataColumn
    Dim dtTable As New DataTable
    Dim dtTableOld As New DataTable
    Dim StatusTrans As String
    Public ViewFormName As String
#End Region

#Region "Function & Procedure"

    Sub CalculateMarkup()
        If txt_markup.Text = "" Then
            txt_markup.Text = dtTable.Rows(0).Item("Markup")
        End If
        For Each item As DataRow In dtTable.Rows
            item("Markup") = txt_markup.Text
            item("Sales Price") = Math.Round(item("Purchase Price") + (item("Purchase Price") * item("Markup") / 100), 2)
        Next
        dgv_data.DataSource = dtTable
    End Sub

    Private Sub GetWarehouse()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.CommandText = "EXEC sp_retreive_Master_Warehouse"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            cb_warehouse.DataSource = dtTable
            cb_warehouse.DisplayMember = GlobalVar.Fields.Warehouse_Name
            cb_warehouse.ValueMember = GlobalVar.Fields.Warehouse_ID
            cb_warehouse.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("GetWarehouse: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Sub RetrieveData()
        dtTableOld.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item '" & cb_warehouse.SelectedValue & "','" & cb_pricetype.SelectedItem.ToString & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableOld)
            conn.Close()

            dc(0) = dtTableOld.Columns("Warehouse ID")
            dc(0) = dtTableOld.Columns("Item ID")
            dc(1) = dtTableOld.Columns("Price Type")
            dtTableOld.PrimaryKey = dc

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RefreshPrice()
        Dim dtTableTB As New DataTable  'Check Trans_TerimaBrg_Dtl
        Dim dtTablePO As New DataTable  'Check Trans_PO_Dtl
        Dim dtTableBB As New DataTable  'Check Master_Stock_BB
        Dim dr As DataRow
        dtTable.Clear()

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item_Update_BasedOnTerimaBrg '" & cb_warehouse.SelectedValue & "','" & cb_pricetype.SelectedItem.ToString & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableTB)
            conn.Close()

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item_Update_BasedOnPO '" & cb_warehouse.SelectedValue & "','" & cb_pricetype.SelectedItem.ToString & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTablePO)
            conn.Close()

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item_Update_BasedOnStockBB '" & cb_warehouse.SelectedValue & "','" & cb_pricetype.SelectedItem.ToString & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableBB)
            conn.Close()

            dtTable = dtTableTB

            If dtTablePO.Rows.Count <> 0 Then
                For Each item As DataRow In dtTablePO.Rows
                    dr = dtTable.NewRow
                    dr("Warehouse ID") = item("Warehouse ID").ToString
                    dr("Item ID") = item("Item ID").ToString
                    dr("Name") = item("Name").ToString
                    dr("Purchase Price") = item("Purchase Price").ToString
                    dr("Markup") = item("Markup").ToString
                    dr("Sales Price") = item("Sales Price").ToString
                    dr("Price Type") = cb_pricetype.SelectedItem
                    dtTable.Rows.Add(dr)
                Next
            End If

            If dtTableBB.Rows.Count <> 0 Then
                For Each item As DataRow In dtTableBB.Rows
                    dr = dtTable.NewRow
                    dr("Warehouse ID") = item("Warehouse ID").ToString
                    dr("Item ID") = item("Item ID").ToString
                    dr("Name") = item("Name").ToString
                    dr("Purchase Price") = item("Purchase Price").ToString
                    dr("Markup") = item("Markup").ToString
                    dr("Sales Price") = item("Sales Price").ToString
                    dr("Price Type") = cb_pricetype.SelectedItem
                    dtTable.Rows.Add(dr)
                Next
            End If

            dgv_data.DataSource = dtTable
            dgv_data.ReadOnly = True

            dgv_data.Columns("Warehouse ID").Width = 100
            dgv_data.Columns("Item ID").Width = 100
            dgv_data.Columns("Name").Width = 200
            dgv_data.Columns("Purchase Price").Width = 150
            dgv_data.Columns("Markup").Width = 50
            dgv_data.Columns("Sales Price").Width = 150
            'dgv_data.Columns("Price Type").Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub SaveData()
        If txt_markup.Text = "" Then
            MsgBox("Please fill Mark Up", MsgBoxStyle.Information, "Information")
            txt_markup.Focus()
            Exit Sub
        End If

        Call CalculateMarkup()
        dgv_data.DataSource = dtTable


        Dim ObjTrans As SqlTransaction
        Dim dr As DataRow
        Dim key(2) As String

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            ObjTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = ObjTrans

            For Each item As DataRow In dtTable.Rows
                key(0) = item("Warehouse ID")
                key(1) = item("Item ID")
                key(2) = cb_pricetype.SelectedItem.ToString
                dr = dtTableOld.Rows.Find(key)

                If dr Is Nothing Then
                    cmd.CommandText = "EXEC sp_Insert_Maintain_SalesPrice_Item '" & _
                                        item("Warehouse ID") & "', '" & _
                                        item("Item ID") & "', '" & _
                                        cb_pricetype.SelectedItem.ToString & "', '" & _
                                        Replace(CStr(item("Purchase Price")), ",", ".") & "', '" & _
                                        item("Markup") & "', '" & _
                                        Replace(CStr(item("Sales Price")), ",", ".") & "', '" & _
                                        userlog.UserName & "'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "EXEC sp_Insert_History_SalesPrice_Item '" & _
                                        item("Warehouse ID") & "', '" & _
                                        item("Item ID") & "', '" & _
                                        cb_pricetype.SelectedItem.ToString & "', '" & _
                                        Replace(CStr(item("Purchase Price")), ",", ".") & "', '" & _
                                        item("Markup") & "', '" & _
                                        Replace(CStr(item("Purchase Price")), ",", ".") & "', '" & _
                                        item("Markup") & "', '" & _
                                        userlog.UserName & "'"
                    cmd.ExecuteNonQuery()

                Else
                    If dr("Purchase Price") <> item("Purchase Price") Or _
                       dr("Markup").ToString <> item("Markup") Then
                        cmd.CommandText = "EXEC sp_Update_Maintain_SalesPrice_Item '" & _
                                      item("Warehouse ID") & "', '" & _
                                      item("Item ID") & "', '" & _
                                      cb_pricetype.SelectedItem.ToString & "', '" & _
                                      Replace(CStr(item("Purchase Price")), ",", ".") & "', '" & _
                                      item("Markup") & "', '" & _
                                      Replace(CStr(item("Sales Price")), ",", ".") & "', '" & _
                                      userlog.UserName & "'"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "EXEC sp_Insert_History_SalesPrice_Item '" & _
                            item("Warehouse ID") & "', '" & _
                            item("Item ID") & "', '" & _
                            cb_pricetype.SelectedItem.ToString & "', '" & _
                            Replace(CStr(dr("Purchase Price")), ",", ".") & "', '" & _
                            dr("Markup") & "', '" & _
                            Replace(CStr(item("Purchase Price")), ",", ".") & "', '" & _
                            item("Markup") & "', '" & _
                            userlog.UserName & "'"
                        cmd.ExecuteNonQuery()
                    End If


                End If
            Next

            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item '" & cb_warehouse.SelectedValue & "','" & cb_pricetype.SelectedItem.ToString & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTableOld)
            dc(0) = dtTableOld.Columns("Item ID")
            dc(1) = dtTableOld.Columns("Price Type")
            dtTableOld.PrimaryKey = dc

            ObjTrans.Commit()
            conn.Close()
            Call RetrieveData()
            MsgBox("Sales Price Item(s) have been Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region

#Region "Event Handler"

    Private Sub btn_refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh.Click
        If txt_markup.Text.Trim = "" Then
            MsgBox("Please fill MARKUP first", MsgBoxStyle.Information, "Information")
            txt_markup.Focus()
            Exit Sub
        End If
        Call RefreshPrice()
        Call CalculateMarkup()
    End Sub

    Private Sub cb_pricetype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_pricetype.SelectedIndexChanged
        txt_markup.Clear()
        Call RefreshPrice()
        Call CalculateMarkup()
    End Sub

    Private Sub frmMaintainSalesPriceItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        SetAccess(Me, userlog.AccessID, Me.Name, ts_save)
        Call GetWarehouse()
        txt_markup.BackColor = Color.LemonChiffon
        If cb_pricetype.SelectedItem = Nothing Then cb_pricetype.SelectedIndex = 0

        Call RetrieveData()
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Call SaveData()
    End Sub

    Private Sub txt_markup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_markup.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalculateMarkup()
        End If
    End Sub

    Private Sub txt_markup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_markup.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_markup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_markup.Leave
        If txt_markup.Text.Trim = "" Then Exit Sub
        Call CalculateMarkup()
    End Sub

#End Region
  
End Class