Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmTransferStockTokoView

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
            cmd.CommandText = "EXEC sp_Retrieve_Trans_TransferStockToko_Hdr_ByKey '" & _
                        dtp_DateFr.Value.ToString("MM/dd/yyyy") & "', '" & _
                        dtp_DateTo.Value.ToString("MM/dd/yyyy") & "', '" & _
                        txt_TransNoFr.Text.Trim & "', '" & _
                        txt_TransNoTo.Text.Trim & "', '" & _
                        cb_category.SelectedItem & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            dgView.DataSource = dtTable
            dgView.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub SetGrid()
        dgView.Columns(0).Width = 80
        dgView.Columns(1).Width = 100
        dgView.Columns(2).Width = 150
        dgView.Columns(3).Width = 80
        dgView.Columns(4).Width = 150
        dgView.Columns(5).Width = 80
        dgView.Columns(6).Width = 200
        dgView.Columns(7).Width = 300
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmTransferStockTokoView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        dtp_DateFr.Value = "01/01/" & CStr(Year(Now))
        cb_category.SelectedItem = "ALL"

        Call RetrieveData()
        Call SetGrid()
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim frmChild As New frmTransferStockToko
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransferStockToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub dgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgView.CellDoubleClick
        If dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Dim frmChild As New frmTransferStockToko
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransferStockToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.txt_TransNo.Text = dgView.CurrentRow.DataGridView(0, dgView.CurrentRow.Index).Value.ToString
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub txt_TransNoFr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TransNoFr.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT TS_No AS [TS No] FROM Trans_TransferStockToko_Hdr ", "TS No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_TransNoFr.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub txt_TransNoTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_TransNoTo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("SELECT TS_No AS [TS No] FROM Trans_TransferStockToko_Hdr ", "TS No", "", "", "", "")
            If frmSearch.txtResult1.Text <> "" Then
                txt_TransNoTo.Text = frmSearch.txtResult1.Text
            End If
        End If
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        If txt_TransNoTo.Text.Trim = "" Then
            txt_TransNoTo.Text = txt_TransNoFr.Text.Trim
        End If

        Call RetrieveData()
    End Sub

#End Region

End Class