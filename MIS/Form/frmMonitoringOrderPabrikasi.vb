Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmMonitoringOrderPabrikasi

#Region "Event Handler"

    Private Sub frmMonitoringOrderPabrikasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDateFrom.Value = "01/01/" & CStr(Year(Now))
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport
        For Each f As Form In Me.MdiChildren
            If f.Name = "Form Report" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm
        frmChild.BeginDate = dtpDateFrom.Value
        frmChild.EndDate = dtpDateTo.Value
        frmChild.ReportName = "Form Monitoring Order Pabrikasi"
        frmChild.Show()
        Me.Close()
    End Sub

#End Region

End Class