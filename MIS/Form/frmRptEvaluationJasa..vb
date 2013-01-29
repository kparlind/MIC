Public Class frmRptEvaluationJasa
    Public Category As String
    Public Type As String
    Public Supp_ID As String
    Public DateFrom As String
    Public DateTo As String
    Private Sub frmRptEvaluationJasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.dtReportQuestionnaire' table. You can move, or remove it, as needed.
        Me.dtReportQuestionnaireTableAdapter.Fill(Me.dsReport.dtReportQuestionnaire, Category, Type, Supp_ID, DateFrom, DateTo)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class