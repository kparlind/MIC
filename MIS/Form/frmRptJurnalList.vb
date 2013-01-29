Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmRptJurnalList
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptJurnalList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Cmd.CommandText = "select distinct period from master_COA_BB order by period desc"
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

    Private Sub txtJurnalList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtJurnalList.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select distinct Form_Name from Mapping_ObjectJurnal", "Form_Name", "", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim
            txtJurnalList.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dtJurnal As New DataTable
        Dim jurnalList As String


        If cmbPeriode.Text = String.Empty Then
            MessageBox.Show("Periode cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtJurnalList.Text = String.Empty Then
            jurnalList = "all"
        Else
            jurnalList = txtJurnalList.Text
        End If

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_getJournalFromTransaction '" & jurnalList.Trim & "','" & cmbPeriode.Text.Trim & "'"

            DA.SelectCommand = Cmd
            DA.Fill(dtJurnal)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report Jurnal List"
        frmChild.dtJurnal = dtJurnal
        frmChild.periodJurnal = cmbPeriode.Text
        frmChild.Show()

    End Sub

    Private Sub txtPeriode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Period from Trans_Closing", "Period", "", "", "", "", "")
            ' txtkdSupplier1.Text = frmSearch.txtResult1.Text.ToString.Trim
            cmbPeriode.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub
End Class