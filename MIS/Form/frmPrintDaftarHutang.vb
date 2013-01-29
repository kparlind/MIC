Public Class frmPrintDaftarHutang
    Public dph As String
    Private Sub frmPrintDaftarHutang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.dtDaftarPelunasanHutang' table. You can move, or remove it, as needed.
        Me.dtDaftarPelunasanHutangTableAdapter.Fill(Me.dsReport.dtDaftarPelunasanHutang, dph)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class