Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class FrmInbox
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt As New DataTable
    Private Sub FrmInbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        tc_personal.SelectedTab.Text = "Inbox"
        lbl_judul.Text = tc_personal.SelectedTab.Text
        txt_search.Clear()
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Dim query As String

        If cb_col.Text = "Transaction No" Then
            query = "'" + txt_search.Text.Trim + "','','','" + tc_personal.SelectedTab.Text + "'"
        ElseIf cb_col.Text = "Transaction Name" Then
            query = "'','" + txt_search.Text.Trim + "','','" + tc_personal.SelectedTab.Text + "'"
        Else
            query = "'','','" + txt_search.Text.Trim + "','" + tc_personal.SelectedTab.Text + "'"
        End If

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        dt_dtl.Clear()
        If tc_personal.SelectedTab.Text = "Inbox" Then
            Cmd.CommandText = "EXEC sp_Retreive_INBOX 'W','Y','" & userlog.UserName & "'," & query
        ElseIf tc_personal.SelectedTab.Text = "OutBox" Then
            Cmd.CommandText = "EXEC sp_Retreive_INBOX 'R','N','" & userlog.UserName & "'," & query
        Else
            Cmd.CommandText = "EXEC sp_Retreive_INBOX '','','" & userlog.UserName & "'," & query
        End If
        'MessageBox.Show(Cmd.CommandText)
        DA.SelectCommand = Cmd
        DA.Fill(dt_dtl)

        If tc_personal.SelectedTab.Text = "Inbox" Then
            gv_inbox.DataSource = dt_dtl
            gv_inbox.Columns.Item(0).Width = "100"
            gv_inbox.Columns.Item(1).Width = "100"
            gv_inbox.Columns.Item(2).Width = "480"
        ElseIf tc_personal.SelectedTab.Text = "OutBox" Then
            gv_outbox.DataSource = dt_dtl
            gv_outbox.Columns.Item(0).Width = "100"
            gv_outbox.Columns.Item(1).Width = "100"
            gv_outbox.Columns.Item(2).Width = "480"
        Else
            gv_all.DataSource = dt_dtl
            gv_all.Columns.Item(0).Width = "100"
            gv_all.Columns.Item(1).Width = "100"
            gv_all.Columns.Item(2).Width = "480"
        End If
    End Sub

    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Search.Click
        If txt_search.Text.Trim = "" Then
            MessageBox.Show("Masukan data yang ingin di cari.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        LoadGrid()
    End Sub

    Private Sub tc_personal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc_personal.SelectedIndexChanged
        lbl_judul.Text = tc_personal.SelectedTab.Text
        LoadGrid()
    End Sub

    Private Sub OpenForm(ByVal Prefix As String)
        Dim dt_form As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retreive_Serial_ByPrefix '" + Prefix + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_form)

        If dt_form.Rows.Count > 0 Then
            If dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMTERIMABRG" Then
                Dim form As New frmTerimaBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPO" Then
                Dim form As New frmPO
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMUPDATESTOK" Then
                Dim form As New FrmUpdateStok
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMREQUESTPEMBELIANBRG" Then
                Dim form As New frmRequestPembelianBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENAWARANHARGAPROJECT" Then
                Dim form As New FrmPenawaranHargaProject
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENAWARANHARGAMARKETING" Then
                Dim form As New frmPenawaranHargaMarketing
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMSURVEY" Then
                Dim form As New frmSurvey
                form.txtSurveyNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                form.FromInbox = True
                form.NewFromView = False
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.ShowDialog()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMREQUESTPEMBELIANBRG" Then
                Dim form As New frmRequestPembelianBrg
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMINPUTSTOCKFISIK" Then
                Dim form As New FrmInputStockFisik
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMORDERMAINTANCE" Then
                Dim form As New frmOrderMaintance
                form.txt_transno.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPERMINTAANPENGELUARANBAHAN" Then
                Dim form As New frmPermintaanPengeluaranBahan
                form.txtBPBNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPENGEMBALIANBARANG" Then
                Dim form As New frmPengembalianBarang
                form.TransNo = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                'Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMORDERPABRIKASI" Then
                Dim form As New FrmOrderPabrikasi
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMSPK" Then
                Dim form As New FrmOrderPabrikasi
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                'Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMTRANSFERSTOCKTOKO" Then
                Dim form As New frmTransferStockToko
                form.txt_TransNo.Text = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            ElseIf dt_form.Rows(0).Item("Serial_ID").ToString.ToUpper = "FRMPEMAKAIANBAHAN" Then
                Dim form As New frmPemakaianBahan
                form.TransNo = gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value
                id_status = gv_inbox.CurrentRow.DataGridView(3, gv_inbox.CurrentRow.Index).Value
                'form.CallerForm = "INBOX"
                form.MdiParent = MDIFrm
                form.Show()
                Me.Close()
            Else
                MessageBox.Show("This Form Has not been Maintained", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        Else
            MessageBox.Show("System can found Prefix : " + Prefix + " on table Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
    End Sub

    Private Sub gv_inbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_inbox.DoubleClick
        If gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value.ToString.Trim = "" Then Exit Sub
        OpenForm(Microsoft.VisualBasic.Left(gv_inbox.CurrentRow.DataGridView(0, gv_inbox.CurrentRow.Index).Value, 2))
    End Sub

    Private Sub gv_outbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_outbox.DoubleClick
        OpenForm(Microsoft.VisualBasic.Left(gv_outbox.CurrentRow.DataGridView(0, gv_outbox.CurrentRow.Index).Value, 2))
    End Sub

    Private Sub gv_all_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv_all.DoubleClick
        OpenForm(Microsoft.VisualBasic.Left(gv_all.CurrentRow.DataGridView(0, gv_all.CurrentRow.Index).Value, 2))
    End Sub
End Class