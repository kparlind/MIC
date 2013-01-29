Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptPelunasanHutang
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private Sub frmRptPelunasanHutang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub

    Private Sub txtkdSupplier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkdSupplier1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Supp_ID,Nama from Master_Supplier where active_flag = 'Y'", "Supp_ID", "Nama", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim
            txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim frmChild As New frmPrint
        Dim dtPHutang As New DataTable
        Dim supplierID As String

        If txtkdSupplier1.Text = "" Then
            supplierID = "all"
        Else
            supplierID = txtkdSupplier1.Text
        End If

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetRptPelunasanHutang '" & dtfrom.Value.ToString("yyyyMMdd") & "','" & dtto.Value.ToString("yyyyMMdd") & "','" & supplierID & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtPHutang)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        frmChild.ReportName = "Report Pelunasan Hutang"
        frmChild.dtPHutang = dtPHutang
        frmChild.Show()
    End Sub
End Class