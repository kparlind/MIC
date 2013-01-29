Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmViewRequestPembelianBrg

#Region "Variable Declaration"
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_PO As New DataTable
    Dim dt_Status As New DataTable
    Public callDialog As Boolean = False
    Dim Status_Proses As String
#End Region

#Region "Function & Procedure"

    Private Sub Load_Department()
        Dim dt_department As New DataTable

        Try
            dt_department.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_Master_Department "
            DA.SelectCommand = Cmd
            DA.Fill(dt_department)

            cb_department.Items.Add("")
            For Each item As DataRow In dt_department.Rows
                cb_department.Items.Add(item("Department_Name").ToString.Trim)
            Next

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub
    
#End Region

#Region "Event Handler"

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            Select Case userlog.Insert_Price.ToUpper.Trim
                Case "Y"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_PR '" & dt_from.Value.ToString("MM-dd-yyyy") & "','" & _
                                                               dt_To.Value.ToString("MM-dd-yyyy") & "','" & _
                                                               txt_PRNo.Text.Trim & "','" & _
                                                               cb_department.Text & "','" & _
                                                               cb_type.Text & "'"
                Case Else
                    Cmd.CommandText = "EXEC sp_Retrieve_View_RequestPembelian '" & dt_from.Value.ToString("MM-dd-yyyy") & "','" & _
                                                               dt_To.Value.ToString("MM-dd-yyyy") & "','" & _
                                                               txt_PRNo.Text.Trim & "','" & _
                                                               cb_department.Text & "','" & _
                                                               cb_type.Text & "','" & _
                                                               userlog.UserName & "'"
            End Select

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

    Private Sub FrmViewRequestPembelianBrg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        dt_from.Value = "01/01/" + CStr(Year(Now))
        txt_PRNo.Clear()

        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)

        Load_Department()
        btn_cari_Click(Me, Nothing)
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New frmRequestPembelianBrg

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmRequestPembelianBrg" Then
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
            Dim frmChild As New frmRequestPembelianBrg
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmRequestPembelianBrg" Then
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

    Private Sub SetGrid()
        gv.Columns(0).Width = 80
        gv.Columns(1).Width = 100
        gv.Columns(2).Width = 200
        gv.Columns(3).Width = 150
        gv.Columns(4).Width = 100
        gv.Columns(5).Width = 250
        gv.Columns(4).Visible = False
    End Sub

#End Region

End Class