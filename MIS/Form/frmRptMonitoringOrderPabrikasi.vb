Public Class frmRptMonitoringOrderPabrikasi
    Public Report_Type As String
    Public OP_No As String
    Public DateFrom As String
    Public DateTo As String
    Private Sub frmRptMonitoringOrderPabrikasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.dtReportOrderPabrikasi' table. You can move, or remove it, as needed.
        'Me.dtReportOrderPabrikasiTableAdapter.Fill(Me.dsReport.dtReportOrderPabrikasi, Report_Type, OP_No, DateFrom, DateTo)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class