Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmRptBankHarian
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter

    Private Sub frmRptBankHarian_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        LoadBank()
        LoadPeriode()
    End Sub

    Public Sub LoadPeriode()
        Dim dtPeriode As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select Period,* from Trans_Closing"
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
    Public Sub LoadBank()
        Dim dtBank As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select Account_id,Account_Name from Master_COA where Group_payaccount = 'Bank'"
            DA.SelectCommand = Cmd
            DA.Fill(dtBank)
            cmbBank.ValueMember = "Account_id"
            cmbBank.DisplayMember = "Account_Name"

            cmbBank.DataSource = dtBank

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

   
    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dtBank As New DataTable
        Dim dtBankBB As New DataTable


        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getJournalBankHarian  '" & cmbBank.SelectedValue & "','" & cmbPeriode.SelectedValue & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtBank)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getBankBeginningBalance  '" & cmbBank.SelectedValue & "','" & cmbPeriode.SelectedValue & "'"


            DA.SelectCommand = Cmd
            DA.Fill(dtBankBB)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report Bank Harian"
        frmChild.dtBank = dtBank
        frmChild.dtBankBB = dtBankBB
        frmChild.Show()
    End Sub
End Class