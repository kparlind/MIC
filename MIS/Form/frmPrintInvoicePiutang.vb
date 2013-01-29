Imports System.Environment
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmPrintInvoicePiutang
    Public fakturno As String
    Public alamat As String
    Public terbilang As String
    Public jumlahuang As String
    Public namacust As String

    Private Sub frmPrintInvoicePiutang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.dtInvoicePiutang' table. You can move, or remove it, as needed.
        Dim param As New List(Of ReportParameter)
        Dim paramAlamat As ReportParameter
        Dim paramJumlahUang As ReportParameter
        Dim paramNamaCust As ReportParameter
        Dim paramTerbilang As ReportParameter

        paramTerbilang = New ReportParameter("terbilang", terbilang)
        paramNamaCust = New ReportParameter("namacust", namacust)
        paramJumlahUang = New ReportParameter("jumlahuang", jumlahuang)
        paramalamat = New ReportParameter("alamat", alamat)
        param.Add(paramAlamat)
        param.Add(paramNamaCust)
        param.Add(paramJumlahUang)
        param.Add(paramTerbilang)

        Me.dtInvoicePiutangTableAdapter.Fill(Me.dsReport.dtInvoicePiutang, fakturno)
        Me.ReportViewer1.LocalReport.SetParameters(param)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class