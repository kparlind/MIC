Public Class frmPrintDaftarPiutang

    Private Sub printDaftarPenagihanPiutang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsReport.sp_retrieve_DPPbyID' table. You can move, or remove it, as needed.
        Me.sp_retrieve_DPPbyIDTableAdapter.Fill(Me.dsReport.sp_retrieve_DPPbyID, "DP1210010")

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class