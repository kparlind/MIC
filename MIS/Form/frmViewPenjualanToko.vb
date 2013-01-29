Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmViewPenjualanToko

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

#Region "Procedure & Function"

    Private Sub SetGrid()
        gv.Columns(0).Width = 100
        gv.Columns(1).Width = 100
        gv.Columns(2).Width = 70
        gv.Columns(3).Width = 250
        gv.Columns(4).Width = 100
        gv.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv.Columns(4).DefaultCellStyle.Format = "#,##0.#0"
        gv.Columns(5).Width = 100
        gv.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv.Columns(5).DefaultCellStyle.Format = "#,##0.#0"
        gv.Columns(6).Width = 100
        gv.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        gv.Columns(6).DefaultCellStyle.Format = "#,##0.#0"
        gv.Columns(7).Width = 100
        gv.Columns(8).Width = 250
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmViewPenjualanToko_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        TBDate_Fr.Value = "01/01/" + CStr(Year(Now))

        btn_cari_Click(Me, Nothing)
        Call SetGrid()
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_View_PenjualanToko '" & TBDate_Fr.Value.ToString("MM/dd/yyyy") & "','" & _
                                                                        TBDate_To.Value.ToString("MM/dd/yyyy") & "','" & _
                                                                        txt_TransNo.Text.Trim & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            gv.DataSource = dt
            gv.Refresh()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New FrmPenjualanToko

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmPenjualanToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub gv_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gv.CellDoubleClick
        If dt.Rows.Count > 0 Then
            Dim frmChild As New FrmPenjualanToko
            For Each f As Form In Me.MdiChildren
                If f.Name = "FrmPenjualanToko" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.txt_TransNo.Text = gv.CurrentRow.DataGridView(0, gv.CurrentRow.Index).Value
            frmChild.Show()
            Me.Close()
        End If
    End Sub

    Private Sub txt_TransNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TransNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT PT_No AS [Trans No] FROM Trans_PenjualanToko_Hdr WHERE Active_Flag = 'Y' ", "Trans No", "", "", "", "")
            txt_TransNo.Text = frmSearch.txtResult1.Text.ToString.Trim
            btn_cari_Click(Me, Nothing)
        ElseIf e.KeyCode = Keys.Enter Then
            btn_cari_Click(Me, Nothing)
        End If
    End Sub

#End Region


End Class