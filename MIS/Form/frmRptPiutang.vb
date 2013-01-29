Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmRptPiutang
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private Sub frmRptPiutang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub

    Private Sub txtkdSupplier1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkdSupplier1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Cust_ID,Nama from Master_Customer where active_flag = 'Y'", "Cust_ID", "Nama", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim

            txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim
            If txtkdSupplier2.Text = "" Then
                txtkdSupplier2.Text = frmSearch.txtResult1.Text.ToString.Trim
            End If

        End If
    End Sub

    Private Sub CalculateGLRangeCOA(ByVal kd1 As String, ByVal kd2 As String, ByVal dt1 As DateTime, ByVal dt2 As DateTime)
        Dim dtSaldo As New DataTable
        Dim dtHutang As New DataTable

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim counter As Integer = 0
        Dim tempSaldoAkhir As Double
        'Dim tempSaldoAwal As Double

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetLastSaldoPembayaranPiutang '" & kd1 & "','" & kd2 & "','" & dt1 & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dtSaldo)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getPembayaranKartuPiutang '" & kd1 & "','" & kd2 & "','" & dt1 & "','" & dt2 & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dtHutang)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'While j < dtSaldo.Rows.Count
        '    MsgBox(dtSaldo.Rows(j).Item("tb_no"))
        '    j = j + 1
        'End While
        'j = 0

        While j < dtSaldo.Rows.Count
            While i < dtHutang.Rows.Count

                If dtSaldo.Rows(j).Item("project_no") = dtHutang.Rows(i).Item("project_no") Then
                    If counter = 0 Then
                        tempSaldoAkhir = dtSaldo.Rows(j).Item("saldoawal")
                        dtHutang.Rows(i).Item("saldoawal") = tempSaldoAkhir
                        counter = counter + 1
                    Else
                        dtHutang.Rows(i).Item("saldoawal") = dtHutang.Rows(i - 1).Item("saldoakhir")
                    End If
                    tempSaldoAkhir = tempSaldoAkhir - CDbl(dtHutang.Rows(i).Item("jumlah_bayar")) - CDbl(dtHutang.Rows(i).Item("potongan"))
                    dtHutang.Rows(i).Item("saldoakhir") = tempSaldoAkhir
                Else
                    counter = 0
                End If
                i = i + 1
            End While
            j = j + 1
            i = 0
        End While

        ' DataGridView1.DataSource = dtHutang

        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report Piutang"
        frmChild.dtPiutang = dtHutang
        frmChild.Show()

        'Dim frmChild As New frmPrint
        'frmChild.ReportName = "Report GL"
        'frmChild.dtGL = dtJournal
        'frmChild.period = cmbPeriod.SelectedValue
        'frmChild.Show()
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim Supp1 As String = ""
        Dim Supp2 As String = ""

        If txtkdSupplier1.Text = "" And txtkdSupplier2.Text = "" Then
            MessageBox.Show("Kode Customer must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtkdSupplier1.Text = "" Or txtkdSupplier2.Text = "" Then
            MessageBox.Show("Kode Customer must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
            'CalculateGLSingleCOA(COA1)
        Else
            Supp1 = txtkdSupplier1.Text
            Supp2 = txtkdSupplier2.Text
            CalculateGLRangeCOA(txtkdSupplier1.Text, txtkdSupplier2.Text, dtfrom.Value.ToString("yyyy-MM-dd"), dtto.Value.ToString("yyyy-MM-dd"))
        End If

    End Sub
End Class