Public Class frmPemakaianBahan_View
    Dim TD As New TransData
    Dim MD As New MasterData
    Dim dtGrid As New DataTable

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        dtGrid.Clear()

        TD.Retrieve_BahanTerpasang_ForView(dtGrid, dtpBeginDate.Value, dtpEndDate.Value, txtTransNo.Text.Trim, txtPHMNo.Text.Trim, txtProjectName.Text.Trim, cboCustomer.SelectedText)

        gView.DataSource = dtGrid
        SetGrid()
    End Sub

    Private Sub SetGrid()
        With gView.Columns(0)
            .HeaderText = "Trans No."
            .Width = 90
        End With
        With gView.Columns(1)
            .HeaderText = "Trans Date"
            .DefaultCellStyle.Format = "dd-MMM-yyyy"
            .Width = 100
        End With
        With gView.Columns(2)
            .HeaderText = "PHM No."
            .Width = 90
        End With
        With gView.Columns(3)
            .HeaderText = "Project Name"
            .Width = 200
        End With
        With gView.Columns(4)
            .HeaderText = "Customer"
            .Width = 200
        End With
        With gView.Columns(5)
            .HeaderText = "Status"
            .Width = 200
        End With
    End Sub

    Private Sub frmPemakaianBahan_View_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpBeginDate.Value = DateSerial(Year(Now), Month(Now), 1)
        dtpEndDate.Value = Now

        LoadCombo()
        btnFind_Click(Nothing, Nothing)
    End Sub

    Private Sub LoadCombo()
        Dim dtData As New DataTable

        cboCustomer.Items.Add("")
        MD.RetrieveCustomer(dtData)
        For Each item As DataRow In dtData.Rows
            cboCustomer.Items.Add(item("Nama").ToString.Trim)
        Next
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim frmChild As New frmPemakaianBahan

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPemakaianBahan" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.fromInbox = False
        frmChild.TransNo = String.Empty
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub gView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gView.DoubleClick
        If dtGrid.Rows.Count > 0 Then
            Dim frmChild As New frmPemakaianBahan
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmPemakaianBahan" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            id_status = gView.CurrentRow.DataGridView(4, gView.CurrentRow.Index).Value
            With frmChild
                .MdiParent = MDIFrm
                .fromInbox = False
                .txtTransNo.Text = gView.CurrentRow.DataGridView(0, gView.CurrentRow.Index).Value
                .TransNo = .txtTransNo.Text.Trim
                .Show()
            End With
            Me.Close()
        End If
    End Sub

End Class