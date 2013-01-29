Public Class frmOptProspekOrderCustomer
    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport

        frmChild.ReportName = "Prospek Order"
        frmChild.BeginDate = dtpDateFrom.Value
        frmChild.EndDate = dtpDateTo.Value

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub
End Class