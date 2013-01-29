Public Class frmRptProspekOrder
    Public BeginDate As DateTime
    Public EndDate As DateTime

    Private Sub frmRptProspekOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.dtRetrieve_Report_ProspekOrder' table. You can move, or remove it, as needed.
        Me.dtRetrieve_Report_ProspekOrderTableAdapter.Fill(Me.dsReport.dtRetrieve_Report_ProspekOrder, BeginDate, EndDate)
        Me.rptViewer.RefreshReport()
    End Sub
End Class