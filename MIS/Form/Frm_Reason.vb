Public Class Frm_Reason
    Public Reason As String = ""
    Public Flag As String = ""

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Reason = txtReason.Text.Trim
        Flag = "OK"
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Flag = "CANCEL"
        Me.Close()
    End Sub
End Class