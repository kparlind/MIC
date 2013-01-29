Public Class TESTING

    Private Sub TESTING_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iTotalTabs = Me.TabControl1.TabCount()
        Dim X As Integer
        For X = 0 To iTotalTabs - 1
            With Me.TabControl1.TabPages(X)
                .Enabled = False
                If .Name = "TabPage2" Then
                    .Enabled = True
                End If
            End With
        Next


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MessageBox.Show(TabControl1.SelectedIndex)
        Panel2.Visible = False
        Panel1.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MessageBox.Show(TabControl1.SelectedTab.Text)
        Panel1.Visible = False
        Panel2.Visible = True
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    End Sub
End Class