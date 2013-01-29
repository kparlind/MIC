Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptPiutangSummary
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptPiutangSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadPeriode()
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim frmChild As New frmPrint
        Dim dtHutang As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetCustomerReceivableAging '" & cmbPeriode.Text.Trim & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtHutang)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        frmChild.ReportName = "Report Piutang Summary"
        frmChild.dtPiutangSummary = dtHutang
        frmChild.periodHutang = cmbPeriode.SelectedText
        frmChild.Show()
    End Sub

    Public Sub LoadPeriode()
        Dim dtPeriode As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "select distinct period from master_piutang_BB"
            DA.SelectCommand = Cmd
            DA.Fill(dtPeriode)
            cmbPeriode.ValueMember = "Period"
            cmbPeriode.DisplayMember = "Period"

            cmbPeriode.DataSource = dtPeriode

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class