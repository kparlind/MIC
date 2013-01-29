Imports System.Data
Imports MIS.GlobalVar
Imports MIS.MasterData
Imports MIS.TransData

Public Class frmOptRekapPakaiBahanProject
    Dim TD As New TransData

    Private Sub OptRekapPakaiBahanProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboFilter.SelectedIndex = 0

        dtpBeginDate.Value = DateSerial(Year(Now), Month(Now), 1)
        dtpEndDate.Value = CDate(Format(Now, "MM/dd/yyyy"))
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        If cboFilter.SelectedIndex = 0 Then
            txtProjectNo.Enabled = False
            txtProjectNo.BackColor = Color.Empty

            dtpBeginDate.Enabled = True
            dtpEndDate.Enabled = True
        Else
            txtProjectNo.Enabled = True
            txtProjectNo.BackColor = Color.LightGoldenrodYellow

            dtpBeginDate.Enabled = False
            dtpEndDate.Enabled = False
        End If
    End Sub

    Private Function CekAdaData() As Boolean
        Dim dtData As New DataTable
        Dim TD As New TransData

        CekAdaData = False
        TD.Retrieve_ReportRekapPemakaianBahanPerProject(dtData, txtProjectNo.Text.Trim, dtpBeginDate.Value, dtpEndDate.Value)
        If dtData.Rows.Count <> 0 Then
            CekAdaData = True
        End If
    End Function

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport

        If cboFilter.SelectedIndex = 0 Then
            If CekAdaData() Then
                frmChild.ReportName = "Rekap Pakai Bahan Project"
                frmChild.ProjectNo = String.Empty
                frmChild.BeginDate = dtpBeginDate.Value
                frmChild.EndDate = dtpEndDate.Value
                For Each f As Form In Me.MdiChildren
                    If f.Name = "frmReport" Then
                        f.BringToFront()
                        Exit Sub
                    End If
                Next

                frmChild.MdiParent = MDIFrm
                frmChild.Show()
                Me.Close()
            Else
                MessageBox.Show("Cannot retrieve any data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            If txtProjectNo.Text.Trim = String.Empty Then
                MessageBox.Show("Please input the Project No. first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If CekAdaData() Then
                    frmChild.ReportName = "Rekap Pakai Bahan Project"
                    frmChild.ProjectNo = txtProjectNo.Text.Trim
                    For Each f As Form In Me.MdiChildren
                        If f.Name = "frmReport" Then
                            f.BringToFront()
                            Exit Sub
                        End If
                    Next

                    frmChild.MdiParent = MDIFrm
                    frmChild.Show()
                    Me.Close()
                Else
                    MessageBox.Show("Cannot retrieve any data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub txtProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProjectNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            Call frmSearch.InitFindData(":: Find Project ::", "exec sp_Retrieve_Trans_Projects_List_forOptionReport")

            Call frmSearch.AddFindColumn(1, "Project_No", "Project ID", DataType.TypeString, 90)
            Call frmSearch.AddFindColumn(2, "Project_Name", "Project Name", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(3, "Project_Date", "Project Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(4, "Cust_Name", "Customer", DataType.TypeString, 200)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtProjectNo.Text = frmSearch.txtResult1.Text.Trim
                txtProjectNo_LostFocus(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtProjectNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectNo.LostFocus
        If txtProjectNo.Text.Trim = String.Empty Then
            txtProjectName.Text = String.Empty
        Else
            Dim dtData As New DataTable
            TD.Retrieve_Projects_ByID_forOptionReport(dtData, txtProjectNo.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                txtProjectName.Text = dtData.Rows(0).Item("Project_Name").ToString.Trim
            Else
                txtProjectName.Text = String.Empty
            End If
        End If
    End Sub
End Class