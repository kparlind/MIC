Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmViewSPK
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_SPK As New DataTable
    Public callDialog As Boolean = False

    Private Sub frmViewSPK_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        dt_from.Value = "01/01/" + CStr(Year(Now))

        txt_SPKNo.Clear()
        txt_ProjectNo.Clear()
        Load_Customer()

        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub Load_Customer()
        Try

            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            cb_Customer.Items.Add("")
            For Each item As DataRow In dt.Rows
                cb_Customer.Items.Add(item("Nama").ToString.Trim)
            Next
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub SetGrid()
        With gv.Columns(0)
            .Width = 80
            .HeaderText = "SPK No."
        End With
        With gv.Columns(1)
            .Width = 90
            .HeaderText = "SPK Date"
            .DefaultCellStyle.Format = "dd-MMM-yyyy"
        End With
        With gv.Columns(2)
            .Width = 90
            .HeaderText = "SPK Type"
        End With
        With gv.Columns(3)
            .Width = 90
            .HeaderText = "Project No"
        End With
        With gv.Columns(4)
            .Width = 150
            .HeaderText = "Project Name"
        End With
        With gv.Columns(5)
            .Width = 150
            .HeaderText = "Customer"
        End With
        With gv.Columns(6)
            .Width = 220
            .HeaderText = "Remarks"
        End With
        With gv.Columns(7)
            .Width = 200
            .HeaderText = "Status Name"
        End With
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        dt_SPK.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retrieve_View_SPK '" & dt_from.Value.ToString("MM-dd-yyyy") & "','" & dt_To.Value.ToString("MM-dd-yyyy") + "','" & _
                           txt_SPKNo.Text.Trim & "','" & txt_ProjectNo.Text.Trim & "','" & cb_Customer.SelectedText & "', '" & txt_ProjectName.Text & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_SPK)

        gv.DataSource = dt_SPK
        SetGrid()
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New frmSPK

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmSPK" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If dt_SPK.Rows.Count > 0 Then
            Dim frmChild As New frmSPK
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmSPK" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            id_status = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            With frmChild
                .MdiParent = MDIFrm
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
                .Show()
            End With
            Me.Close()
        End If
    End Sub
End Class