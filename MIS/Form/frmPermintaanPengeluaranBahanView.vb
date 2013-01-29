Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmPermintaanPengeluaranBahanView

#Region "Variable Declaration"

    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTrans As String

#End Region

#Region "Procedure & Function"

    Sub RetrieveData()
        Dim dtTable As New DataTable
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.CommandText = "EXEC sp_Retrieve_Trans_BPB_Hdr"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
            dgView.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveDataByKey()

        If cbCategory.SelectedItem.ToString = "By BPB Date" Then
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
            cmd.CommandText = "sp_Retrieve_Trans_BPB_Hdr_ByKey '" & cbCategory.SelectedItem.ToString & "', '" & _
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

    Private Sub SetGrid()
        dgView.Columns(0).Width = 80        'Trans No
        dgView.Columns(1).Width = 100       'Category: 1)SPK 2)Order Pabrikasi 3)Division
        dgView.Columns(2).Width = 80        'Ref No
        dgView.Columns(3).Width = 100       'Order Date
        dgView.Columns(4).Width = 100       'Required Date
        dgView.Columns(5).Width = 250       'Information
        dgView.Columns(6).Width = 50        'Status ID
        dgView.Columns(7).Width = 250       'Status
        dgView.Columns(6).Visible = False
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmPermintaanPengeluaranBahan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name, btn_new)
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cbCategory.SelectedIndex = 0

        Call RetrieveData()
        Call SetGrid()
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim frmChild As New frmPermintaanPengeluaranBahan
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormOrderMaintance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.ViewFormName = Me.Name
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Dim frmChild As New frmPermintaanPengeluaranBahan
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormOrderMaintance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
       
        frmChild.txtBPBNo.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Call RetrieveDataByKey()
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
        Call RetrieveData()
    End Sub

#End Region

End Class