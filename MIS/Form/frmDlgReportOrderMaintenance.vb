Public Class frmDlgReportOrderMaintenance

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm

        frmChild.BeginDate = dtpDateFrom.Value
        frmChild.EndDate = dtpDateTo.Value
        frmChild.ReportName = "Report Order Maintenance"

        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub frmDlgReportOrderMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDateFrom.Value = "01/01/" & CStr(Year(Now))
    End Sub
End Class