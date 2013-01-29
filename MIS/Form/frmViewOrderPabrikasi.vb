Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmViewOrderPabrikasi

#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_OP As New DataTable
    Public callDialog As Boolean = False
#End Region

#Region "Event Handler"

    Private Sub frmViewOrderPabrikasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        dt_from.Value = "01/01/" + CStr(Year(Now))

        txt_OPNo.Clear()
        txt_SPK.Clear()

        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        dt_OP.Clear()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retrieve_View_OrderPabrikasi '" & dt_from.Value & "','" & dt_To.Value + "','" & _
                           txt_OPNo.Text.Trim & "','" & txt_SPK.Text.Trim & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_OP)

        gv.DataSource = dt_OP
        Call SetColumn()
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If dt_OP.Rows.Count > 0 Then
            Dim frmChild As New FrmOrderPabrikasi
            For Each f As Form In Me.MdiChildren
                If f.Name = "FrmOrderPabrikasi" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            With frmChild
                .MdiParent = MDIFrm
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
                .Show()
            End With

            Me.Close()

        End If
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New FrmOrderPabrikasi

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmOrderPabrikasi" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        frmChild.CallerForm = "frmOrderPabrikasi"
        Me.Close()
    End Sub

    Private Sub SetColumn()
        gv.Columns(0).Width = 100
        gv.Columns(1).Width = 100
        gv.Columns(2).Width = 100
        gv.Columns(3).Width = 100
        gv.Columns(4).Width = 100
        gv.Columns(5).Width = 300
    End Sub

#End Region

End Class