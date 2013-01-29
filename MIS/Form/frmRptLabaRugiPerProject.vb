Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmRptLabaRugiPerProject
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptLabaRugiPerProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub

    Private Sub txtProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProjectNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Project_No from trans_projects", "Project_No", "", "", "", "", "")
            txtProjectNo.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dtBPB As New DataTable
        Dim dtLogBook As New DataTable
        Dim dtPiutang As New DataTable


        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetBPBCostPerProject  '" & txtProjectNo.Text & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtBPB)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getTotalPiutangPerProject '" & txtProjectNo.Text & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtPiutang)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getLogBookCostPerProject  '" & txtProjectNo.Text & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtLogBook)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report Laba Rugi Per Project"
        frmChild.dtBPB = dtBPB
        frmChild.dtTotalPiutang = dtPiutang
        frmChild.dtlogbook = dtLogBook

        frmChild.Show()


    End Sub
End Class