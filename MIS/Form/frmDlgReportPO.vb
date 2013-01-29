Public Class frmDlgReportPO

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReport" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm

        frmChild.PODateFr = dtpPODateFrom.Value
        frmChild.PODateTo = dtpPODateTo.Value
        frmChild.TBDateFr = dtpPODateFrom.Value
        frmChild.TBDateto = dtpPODateTo.Value
        'frmChild.PONoFr = txtPONoFr.Text.Trim
        'frmChild.ItemIDFr = txtItemIDFr.Text.Trim
        'frmChild.WarehouseIDFr = txtWarehouseIDFr.Text.Trim
        'frmChild.SuppIDFr = txt_SuppIDFr.Text.Trim
        'frmChild.TBNoFr = txt_TBNoFr.Text.Trim

        'If txtPONoTo.Text.Trim = "" Then
        '    frmChild.PONoTo = txtPONoFr.Text.Trim
        'Else
        '    frmChild.PONoTo = txtPONoTo.Text.Trim
        'End If

        'If txtItemIDTo.Text.Trim = "" Then
        '    frmChild.ItemIDTo = txtItemIDFr.Text.Trim
        'Else
        '    frmChild.ItemIDTo = txtItemIDTo.Text.Trim
        'End If

        'If txtWarehouseIDTo.Text.Trim = "" Then
        '    frmChild.WarehouseIDto = txtWarehouseIDFr.Text.Trim
        'Else
        '    frmChild.WarehouseIDto = txtWarehouseIDTo.Text.Trim
        'End If

        'If txt_SuppIDTo.Text.Trim = "" Then
        '    frmChild.SuppIDTo = txt_SuppIDFr.Text.Trim
        'Else
        '    frmChild.SuppIDTo = txt_SuppIDTo.Text.Trim
        'End If

        'If txt_TBNoTo.Text.Trim = "" Then
        '    frmChild.TBNoTo = txt_TBNoFr.Text.Trim
        'Else
        '    frmChild.TBNoTo = txt_TBNoTo.Text.Trim
        'End If

        frmChild.ReportName = "Report PO"

        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub frmDlgReportPO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpPODateFrom.Value = "01/01/" & CStr(Year(Now))
        dtpPODateFrom.Value = "01/01/" & CStr(Year(Now))
    End Sub

    Private Sub txtItemIDFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemIDFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Item_ID AS [Item ID], Item_Name AS Name FROM Master_Item_Hdr WHERE active_flag = 'Y'", "Item ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtItemIDFr.Text = frmSearch.txtResult1.Text
                txtItemIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txtItemIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemIDTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Item_ID AS [Item ID], Item_Name AS Name FROM Master_Item_Hdr WHERE active_flag = 'Y'", "Item ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtItemIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txtPONoFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONoFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT PO_No AS [PO No] FROM Trans_PO_Hdr WHERE PO_No IN (SELECT PO_NO FROM Trans_TerimaBrg_Hdr)", "PO No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtPONoFr.Text = frmSearch.txtResult1.Text
                txtPONoTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txtPONoTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPONoTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT PO_No AS [PO No] FROM Trans_PO_Hdr WHERE PO_No IN (SELECT PO_NO FROM Trans_TerimaBrg_Hdr)", "PO No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtPONoTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txtWarehouseIDFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWarehouseIDFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Warehouse_ID AS [Warehouse ID], Warehouse_Name AS Name FROM Master_Warehouse WHERE active_flag = 'Y'", "Warehouse ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtWarehouseIDFr.Text = frmSearch.txtResult1.Text
                txtWarehouseIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub
    
    Private Sub txtWarehouseIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWarehouseIDTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Warehouse_ID AS [Warehouse ID], Warehouse_Name AS Name FROM Master_Warehouse WHERE active_flag = 'Y'", "Warehouse ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txtWarehouseIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txt_SuppIDFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SuppIDFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Supp_ID AS [Supplier ID], Nama AS Name FROM Master_Supplier WHERE active_flag = 'Y'", "Supplier ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_SuppIDFr.Text = frmSearch.txtResult1.Text
                txt_SuppIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txt_SuppIDTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_SuppIDTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT Supp_ID AS [Supplier ID], Nama AS Name FROM Master_Supplier WHERE active_flag = 'Y'", "Supplier ID", "Name", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_SuppIDTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txt_TBNoFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TBNoFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT TB_No AS [TB No] FROM Trans_TerimaBrg_Hdr WHERE Status_ID <> 'CAP'", "TB No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_TBNoFr.Text = frmSearch.txtResult1.Text
                txt_TBNoTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txt_TBNoTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TBNoTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT TB_No AS [TB No] FROM Trans_TerimaBrg_Hdr WHERE Status_ID <> 'CAP'", "TB No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_TBNoTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub
End Class