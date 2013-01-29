Public Class frmDlgReportPenjualan

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.ReportName = "Report Penjualan"
        frmChild.BeginDate = dtp_DateFrom.Value
        frmChild.EndDate = dtp_DateTo.Value
        frmChild.FakturType = cb_TipeFaktur.SelectedItem
        frmChild.TipeAnalisa = cb_TipeAnalisa.SelectedItem
        frmChild.TipeWaktu = cb_TipeWaktu.SelectedItem
        frmChild.TipePenjualan = cb_TipePenjualan.SelectedItem

        Select Case cb_IncludeRetur.Checked
            Case True
                frmChild.IncludeRetur = "Y"
            Case Else
                frmChild.IncludeRetur = ""
        End Select

        Select Case cb_TipePenjualan.SelectedItem
            Case "Toko"
                If cb_TipeAnalisa.SelectedItem = "Barang" And cb_TipeWaktu.SelectedItem = "Harian" Then
                    frmChild.ReportType = "PenjualanTokoPerBarangDaily"
                ElseIf cb_TipeAnalisa.SelectedItem = "Barang" And cb_TipeWaktu.SelectedItem = "Bulanan" Then
                    frmChild.ReportType = "PenjualanTokoPerBarangMonthly"
                ElseIf cb_TipeAnalisa.SelectedItem = "Customer" And cb_TipeWaktu.SelectedItem = "Harian" Then
                    frmChild.ReportType = "PenjualanTokoPerCustomerDaily"
                ElseIf cb_TipeAnalisa.SelectedItem = "Customer" And cb_TipeWaktu.SelectedItem = "Bulanan" Then
                    frmChild.ReportType = "PenjualanTokoPerCustomerMonthly"
                End If
            Case Else
                If cb_TipeFaktur.SelectedItem = "ALL" Then
                    If cb_TipeWaktu.SelectedItem = "Harian" Then
                        frmChild.ReportType = "PenjualanInstalasiDaily"
                    Else
                        frmChild.ReportType = "PenjualanInstalasiMonthly"
                    End If
                Else
                    If cb_TipeWaktu.SelectedItem = "Harian" Then
                        frmChild.ReportType = "PenjualanInstalasiDailyByFakturType"
                    Else
                        frmChild.ReportType = "PenjualanInstalasiMonthlyByFakturType"
                    End If
                End If
        End Select

        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub frmDlgReportPenjualan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtp_DateFrom.Value = "01/01/" & CStr(Year(Now))
        cb_TipeAnalisa.SelectedItem = "Customer"
        cb_TipeFaktur.SelectedItem = "ALL"
        cb_TipePenjualan.SelectedItem = "Toko"
        cb_TipeWaktu.SelectedItem = "Harian"
    End Sub

    Private Sub cb_TipePenjualan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_TipePenjualan.SelectedIndexChanged
  
        Select Case cb_TipePenjualan.SelectedItem
            Case "Instalasi"
                cb_TipeAnalisa.SelectedItem = "Customer"
                cb_TipeAnalisa.Enabled = False
                cb_TipeFaktur.Enabled = True
                cb_IncludeRetur.Enabled = False
                cb_IncludeRetur.Checked = False
            Case Else
                cb_TipeAnalisa.Enabled = True
                cb_TipeFaktur.Enabled = False
                cb_IncludeRetur.Enabled = True
        End Select
    End Sub
End Class