Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmRptNeraca
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private Sub frmRptNeraca_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadPeriode()
    End Sub

    Public Sub LoadPeriode()
        Dim dtPeriode As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "select distinct period from master_COA_BB"
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

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim frmChild As New frmPrint
        Dim dtNeraca As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetNeraca '" & cmbPeriode.SelectedValue.Trim & "'"
          
            DA.SelectCommand = Cmd
            DA.Fill(dtNeraca)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        frmChild.ReportName = "Report Neraca"
        frmChild.dtNeraca = dtNeraca
        frmChild.periodNeraca = cmbPeriode.SelectedValue
        frmChild.Show()
    End Sub
End Class