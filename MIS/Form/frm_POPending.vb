Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frm_POPending

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_PO As New DataTable
    Dim dt_Status As New DataTable
    Public callDialog As Boolean = False
    Public ViewFormName As String

    Public Sub InitFindData(ByVal CallMode As Boolean)
        callDialog = CallMode
        gv.Focus()
    End Sub

    Private Sub frm_POPending_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        PoDate_Fr.Value = "01/01/" + CStr(Year(Now))

        'SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        'LoadPONo()
        LoadStatus()
        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_RetreivePOPending '" + PoDate_Fr.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              PODate_To.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              txt_SuppName.Text.Trim + "','" & _
                                                              txt_PONo.Text + "','" & _
                                                              cb_status.Text.Trim + "','" & _
                                                              Txt_Notes.Text.Trim + "'"

            DA.SelectCommand = Cmd
            DA.Fill(dt)

            'gv_PO.DataSource = dt

            gv.DataSource = dt
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
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

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New frmPO
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPO" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If dt.Rows.Count > 0 Then
            Dim frmChild As New frmPO
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmPO" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            id_status = gv.CurrentRow.DataGridView(5, gv.CurrentRow.Index).Value.ToString.Trim
            With frmChild
                .MdiParent = MDIFrm
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
                .Show()
            End With

            Me.Close()
        End If
    End Sub

    Private Sub SetGrid()
        gv.Columns(0).Width = 80
        gv.Columns(1).Width = 100
        gv.Columns(2).Width = 150
        gv.Columns(3).Width = 100
        gv.Columns(4).Width = 250
        gv.Columns(5).Width = 250
    End Sub

    'Private Sub LoadPONo()
    '    Try
    '        dt_PO.Clear()
    '        If Conn.State = ConnectionState.Closed Then
    '            Conn.Open()
    '        End If

    '        Cmd.CommandText = "Select PO_NO from Trans_PO_Hdr where PO_No not in (Select PO_NO from Trans_TerimaBrg_HDr)"
    '        DA.SelectCommand = Cmd
    '        DA.Fill(dt_PO)
    '        Conn.Close()

    '        cb_PONo.Items.Insert(0, "")
    '        For i As Integer = 0 To dt_PO.Rows.Count - 1
    '            cb_PONo.Items.Insert(i + 1, dt_PO.Rows(i).Item(GlobalVar.Fields.PO_No))
    '        Next
    '        cb_PONo.SelectedItem = ""
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Conn.Close()
    '    End Try
    'End Sub

End Class