Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmViewInsertStockFisik
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_Stock As New DataTable
    Public callDialog As Boolean = False

    Private Sub FrmViewInsertStockFisik_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        dt_from.Value = Now

        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New FrmInputStockFisik

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmInputStockFisik" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        dt_Stock.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retrieve_View_InsertStockFisik '" & dt_from.Value.ToString("yyyyMM") & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_Stock)

        gv.DataSource = dt_Stock
        SetGrid()
    End Sub

    Private Sub SetGrid()
        gv.Columns(0).Width = 90
        gv.Columns(1).Width = 200
        gv.Columns(2).Width = 50
        gv.Columns(3).Width = 300
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        If dt_Stock.Rows.Count > 0 Then
            Dim frmChild As New FrmInputStockFisik
            For Each f As Form In Me.MdiChildren
                If f.Name = "FrmInputStockFisik" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            id_status = GetStatusID_byStatusName(gv.CurrentRow.DataGridView(3, gv.CurrentRow.Index).Value)
            With frmChild
                .MdiParent = MDIFrm
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
                .Show()
            End With
            Me.Close()
        End If
    End Sub
End Class