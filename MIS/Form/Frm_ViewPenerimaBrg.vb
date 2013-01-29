Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class Frm_ViewPenerimaBrg

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_PO As New DataTable
    Dim dt_Status As New DataTable
    Public callDialog As Boolean = False
    Dim Status_Proses As String


    Private Sub Frm_ViewPenerimaBrg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)

        TBDate_Fr.Value = "01/01/" + CStr(Year(Now))
        LoadTB()
        LoadPO()
        LoadStatus()

        'If userlog.Insert_Price = "Y" Then
        '    cb_status.SelectedValue = "WAFP"
        '    cb_status.Enabled = False
        'End If

        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub LoadStatus()
        Try
            dt_Status.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retreive_Status"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Status)
            Conn.Close()

            cb_status.Items.Insert(0, "")
            For i As Integer = 0 To dt_Status.Rows.Count - 1
                cb_status.Items.Insert(i, dt_Status.Rows(i).Item(GlobalVar.Fields.Status_Name))
            Next
            cb_status.SelectedItem = ""

        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadPO()
        Dim dt_PO As New DataTable

        Try
            dt_Status.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Cmd.CommandText = "Select PO_No from Trans_TerimaBrg_HDr where TB_Date between '" & TBDate_Fr.Value.ToString("MM/dd/yyyy") & "' and '" & TBDate_To.Value.ToString("MM/dd/yyyy") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_PO)
            Conn.Close()

            cb_PONo.Items.Insert(0, "")
            For i As Integer = 0 To dt_PO.Rows.Count - 1
                cb_PONo.Items.Insert(i, dt_PO.Rows(i).Item("PO_No"))
            Next
            cb_PONo.SelectedItem = ""

        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadTB()
        Dim dt_TB As New DataTable
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select TB_No from Trans_TerimaBrg_HDr where TB_Date between '" & TBDate_Fr.Value.ToString("MM/dd/yyyy") & "' and '" & TBDate_To.Value.ToString("MM/dd/yyyy") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_TB)
            Conn.Close()

            cb_TBNo.Items.Insert(0, "")
            For i As Integer = 0 To dt_TB.Rows.Count - 1
                cb_TBNo.Items.Insert(i, dt_TB.Rows(i).Item("TB_No"))
            Next
            cb_TBNo.SelectedItem = ""


        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New frmTerimaBrg
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTerimaBrg" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.StatusTrans = GlobalVar.TransStatus.NewStatus
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retreive_view_TerimaBrg '" + TBDate_Fr.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              TBDate_To.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              cb_TBNo.Text.Trim + "','" & _
                                                              cb_PONo.Text.Trim + "','" & _
                                                              cb_status.Text.Trim + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            gv.DataSource = dt
            gv.Refresh()
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        If dt.Rows.Count > 0 Then
            Dim frmChild As New frmTerimaBrg
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmTerimaBrg" Then
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
                .dt_LPBDate.Value = gv.CurrentRow.DataGridView(1, gv.CurrentRow.Index).Value
                .txt_PONo.Text = gv.CurrentRow.DataGridView(2, gv.CurrentRow.Index).Value
                .cb_Gudang.SelectedValue = gv.CurrentRow.DataGridView(3, gv.CurrentRow.Index).Value
                .Show()
            End With
            Me.Close()
        End If

    End Sub

    Private Sub SetGrid()
        gv.Columns(0).Width = 80
        gv.Columns(1).Width = 100
        gv.Columns(2).Width = 80
        gv.Columns(3).Width = 100
        gv.Columns(4).Width = 100
        gv.Columns(5).Width = 250
        gv.Columns(6).Width = 250
        gv.Columns(7).Width = 100
    End Sub

End Class