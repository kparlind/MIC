Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmOrderMaintanceView

#Region "Variable Declaration"
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTRans As String
    Public ViewFormName As String
#End Region

#Region "Function & Procedure"

    Sub RetrieveTransOrderMaint()
        Dim dtTable As New DataTable

        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderMaintance"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveTransLogBookByKey()

        If cbCategory.SelectedItem.ToString = "By Order Date" Then
        Else
            If txtKeyword.Text.Trim = "" Then
                MsgBox("Please Fill Keyword", MsgBoxStyle.Information, "Information")
                txtKeyword.Focus()
                Exit Sub
            End If
        End If

        Dim dtTable As New DataTable
        Dim i As Integer
        Try

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "sp_Retrieve_Trans_OrderMaintance_ByKey '" & cbCategory.SelectedItem.ToString & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              txtKeyword.Text.Trim & "', '" & _
                              Format(dtpDateFrom.Value, "MM-dd-yyyy") & "', '" & _
                              Format(dtpDateTo.Value, "MM-dd-yyyy") & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()
            dgView.DataSource = dtTable
            For i = 0 To dgView.Columns.Count - 1
                dgView.Columns(i).HeaderText = dgView.Columns(i).HeaderText.Replace("_", " ")
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        RetrieveTransLogBookByKey()
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Call RetrieveTransOrderMaint()
    End Sub

    Private Sub frmOrderMaintanceView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgView.ReadOnly = True
        SetAccess(Me, userlog.AccessID, Me.Name, btn_new)
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cbCategory.SelectedIndex = 0
        Call RetrieveTransOrderMaint()
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim frmChild As New frmOrderMaintance
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormOrderMaintance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        StatusTRans = GlobalVar.TransStatus.NewStatus
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        Dim frmChild As New frmOrderMaintance


        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormOrderMaintance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.txt_transno.Enabled = False
        frmChild.txt_transno.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

#End Region

End Class