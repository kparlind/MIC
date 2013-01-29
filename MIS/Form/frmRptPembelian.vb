Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptPembelian
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptPembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub


    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim kdsupp1 As String = String.Empty
        Dim kdsupp2 As String = String.Empty
        Dim gudang1 As String = String.Empty
        Dim gudang2 As String = String.Empty
        Dim item1 As String = String.Empty
        Dim item2 As String = String.Empty
        Dim dtPembelian As New DataTable


        If txtKdSupp1.Text = "" And txtKdSupp2.Text = "" Then
            txtKdSupp1.Text = "all"
        End If
        If txtGudang1.Text = "" And txtGudang2.Text = "" Then
            txtGudang1.Text = "all"
        End If
        If txtitem1.Text = "" And txtitem2.Text = "" Then
            txtitem1.Text = "all"
        End If

        kdsupp1 = txtKdSupp1.Text
        kdsupp2 = txtKdSupp2.Text
        gudang1 = txtGudang1.Text
        gudang2 = txtGudang2.Text
        item1 = txtitem1.Text
        item2 = txtitem2.Text

        txtKdSupp1.Clear()
        txtKdSupp2.Clear()
        txtGudang1.Clear()
        txtGudang2.Clear()
        txtitem1.Clear()
        txtitem2.Clear()



        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getPembelianItem '" & kdsupp1 & "','" & kdsupp2 & "','" & dtPO1.Value & "','" & dtPo2.Value & "', '" & dtTB1.Value & "','" & dtTB2.Value & "','" & item1 & "','" & item2 & "','" & gudang1 & "','" & gudang2 & "' "

            DA.SelectCommand = Cmd
            DA.Fill(dtPembelian)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Dim frmchild As New frmPrint
        frmchild.ReportName = "Report Pembelian"
        frmchild.dtPembelian = dtPembelian
        frmchild.Show()
    End Sub

    Private Sub txtKdSupp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKdSupp1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Supp_ID,Nama from Master_Supplier where active_flag = 'Y'", "Supp_ID", "Nama", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim

            txtKdSupp1.Text = frmSearch.txtResult1.Text.ToString.Trim
            If txtKdSupp2.Text = "" Then
                txtKdSupp2.Text = frmSearch.txtResult1.Text.ToString.Trim
            End If

        End If
    End Sub

    Private Sub txtKdSupp2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKdSupp2.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Supp_ID,Nama from Master_Supplier where active_flag = 'Y'", "Supp_ID", "Nama", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Tri
            txtKdSupp2.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub


    Private Sub txtitem1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtitem1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Item_ID,Item_Name from Master_Item_Hdr where active_flag = 'Y'", "Item_ID", "Item_Name", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Tri
            txtitem1.Text = frmSearch.txtResult1.Text.ToString.Trim
            If txtitem2.Text = "" Then
                txtitem2.Text = frmSearch.txtResult1.Text.ToString.Trim
            End If
        End If
    End Sub

    Private Sub txtitem2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtitem2.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Item_ID,Item_Name from Master_Item_Hdr where active_flag = 'Y'", "Item_ID", "Item_Name", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Tri
            txtitem2.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub txtGudang1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGudang1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Warehouse_ID,Warehouse_Name from Master_Warehouse where active_flag = 'Y'", "Warehouse_ID", "Warehouse_Name", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Tri
            txtGudang1.Text = frmSearch.txtResult1.Text.ToString.Trim
            If txtGudang2.Text = "" Then
                txtGudang2.Text = frmSearch.txtResult1.Text.ToString.Trim
            End If
        End If
    End Sub

    Private Sub txtGudang2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGudang2.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Warehouse_ID,Warehouse_Name from Master_Warehouse where active_flag = 'Y'", "Warehouse_ID", "Warehouse_Name", "", "", "", "")
            txtGudang2.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub
End Class