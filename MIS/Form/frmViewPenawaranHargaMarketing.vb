Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmViewPenawaranHargaMarketing
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_PO As New DataTable
    Dim dt_Status As New DataTable
    Public callDialog As Boolean = False
    Dim Status_Proses As String

    Private Sub frmViewPenawaranHargaMarketing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        dt_from.Value = "01/01/" + CStr(Year(Now))
        txt_PHMNo.Clear()

        Load_Customer()
        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub Load_Customer()
        Dim dt_department As New DataTable

        Try
            dt_department.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer "
            DA.SelectCommand = Cmd
            DA.Fill(dt_department)

            cb_Customer.Items.Add("")
            For Each item As DataRow In dt_department.Rows
                cb_Customer.Items.Add(item("Nama").ToString.Trim)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub SetGrid()
        gv.Columns(0).Width = 75
        gv.Columns(0).HeaderText = "HPM#"

        gv.Columns(1).Width = 80
        gv.Columns(1).HeaderText = "HP Date"
        gv.Columns(1).DefaultCellStyle.Format = "dd MMM yyyy"

        gv.Columns(2).Width = 100
        gv.Columns(2).HeaderText = "HP Project#"

        gv.Columns(3).Width = 170
        gv.Columns(3).HeaderText = "Customer Name"

        gv.Columns(4).Width = 90
        gv.Columns(4).HeaderText = "Total"
        gv.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv.Columns(4).DefaultCellStyle.Format = "#,##0"
        gv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        gv.Columns(5).Width = 230
        gv.Columns(5).HeaderText = "Remarks"

        gv.Columns(6).Width = 90
        gv.Columns(6).HeaderText = "Status ID"

        gv.Columns(7).Width = 200
        gv.Columns(7).HeaderText = "Status Desc"
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_View_PenawaranHargaMarketing '" & Format(dt_from.Value, "yyyyMMdd") & "','" & _
                                                                                Format(dt_To.Value, "yyyyMMdd") & "','" & _
                                                                                txt_PHMNo.Text.Trim & "','" & _
                                                                                txt_SurveyNo.Text.Trim & "','" & _
                                                                                cb_Customer.Text.Trim & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dt)
            gv.DataSource = dt
            gv.Refresh()

            SetGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New frmPenawaranHargaMarketing

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPenawaranHargaMarketing" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        id_status = Status.Draft

        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.Show()
        Me.Hide()
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If dt.Rows.Count > 0 Then
            Dim frmChild As New frmPenawaranHargaMarketing
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmPenawaranHargaMarketing" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            id_status = gv.CurrentRow.DataGridView(6, gv.CurrentRow.Index).Value
            With frmChild
                .MdiParent = MDIFrm
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
                .Show()
            End With

            Me.Hide()
        End If
    End Sub
End Class