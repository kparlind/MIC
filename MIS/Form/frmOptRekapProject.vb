Imports MIS.GlobalVar

Public Class frmOptRekapProject
    Private Sub txtCustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustID.KeyDown
        If e.KeyCode = Keys.F1 Then
            Call frmSearch.InitFindData(":: Find SPK ::", "exec sp_Retrieve_Master_Customer_ForSearch")

            Call frmSearch.AddFindColumn(1, "Cust_ID", "Customer#", DataType.TypeString, 90)
            Call frmSearch.AddFindColumn(2, "Nama", "Customer Name", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(3, "Alamat", "Address", DataType.TypeString, 250)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtCustID.Text = frmSearch.txtResult1.Text.Trim
                txtCustID_LostFocus(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub frmOptRekapProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDateFrom.Value = DateSerial(Year(Now), Month(Now), 1)
        dtpDateTo.Value = Now
        txtCustID.Text = String.Empty
        cboEfficiency.SelectedIndex = 0
        cboStatus.SelectedIndex = 0

        txtCustID.BackColor = Color.LightGoldenrodYellow
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport
        Dim dtTemp As New DataTable
        Dim TD As New TransData

        TD.Retrieve_Report_RekapProject(dtTemp, Format(dtpDateFrom.Value, "yyyyMMdd"), Format(dtpDateTo.Value, "yyyyMMdd"), txtCustID.Text.Trim, cboEfficiency.SelectedIndex, cboStatus.SelectedIndex)
        If dtTemp.Rows.Count <> 0 Then
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmReport" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.ReportName = "Rekap Project"
            frmChild.BeginDate = dtpDateFrom.Value
            frmChild.EndDate = dtpDateTo.Value
            frmChild.CustID = txtCustID.Text.Trim
            frmChild.isEfficient = cboEfficiency.SelectedIndex
            frmChild.isComplete = cboStatus.SelectedIndex
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Close()
        Else
            MessageBox.Show("Nothing is retrieved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtCustID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustID.LostFocus
        If txtCustID.Text.Trim = String.Empty Then
            txtCustName.Text = String.Empty
        Else
            Dim dtData As New DataTable
            Dim MD As New MasterData

            MD.RetrieveCustomerByKey(dtData, txtCustID.Text.Trim)
            If dtData.Rows.Count <> 0 Then
                txtCustName.Text = dtData.Rows(0).Item(Fields.Cust_Name).ToString.Trim
            Else
                txtCustName.Text = String.Empty
            End If
        End If
    End Sub
End Class