Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptGLDetail
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptGLDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        LoadPeriod()
    End Sub

    Private Sub CalculateGLRangeCOA(ByVal COA1 As String, ByVal COA2 As String)
        Dim dtCOABB As New DataTable
        Dim dtJournal As New DataTable
       
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim counter As Integer = 0
        Dim tempSaldoAkhir As Double
        'Dim tempSaldoAwal As Double

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If


            Cmd.CommandText = "exec sp_GetSaldoAwal '" & COA1 & "','" & COA2 & "','" & cmbPeriod.SelectedValue & " '"

            DA.SelectCommand = Cmd
            DA.Fill(dtCOABB)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "select journalDate ,accountid , account_name , notes ,a.journalID , refno  , '' as saldoawal , amountDR , amountCR , '' as saldoakhir " & _
                             "from journalitem a left join journal b " & _
                             "on a.journalID = b.journalID " & _
                             "left join master_COA c on a.accountID = c.account_ID " & _
                             "left join  master_COA_BB d on a.accountID = d.account_ID " & _
                             "left join trans_closing e on d.period = e.period " & _
                             "where accountid between '" & COA1 & "' and '" & COA2 & "'" & _
                             "and journalDate between start_date and end_date " & _
                             "and d.period = '" & cmbPeriod.SelectedValue & "' " & _
                             "order by accountid asc "

            DA.SelectCommand = Cmd
            DA.Fill(dtJournal)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        While j < dtCOABB.Rows.Count
            While i < dtJournal.Rows.Count
                If dtCOABB.Rows(j).Item("account_id") = dtJournal.Rows(i).Item("accountid") Then
                    If counter = 0 Then
                        tempSaldoAkhir = dtCOABB.Rows(j).Item("saldoawal")
                        dtJournal.Rows(i).Item("saldoawal") = tempSaldoAkhir
                        counter = counter + 1
                    Else
                        dtJournal.Rows(i).Item("saldoawal") = dtJournal.Rows(i - 1).Item("saldoakhir")
                    End If
                    tempSaldoAkhir = tempSaldoAkhir + CDbl(dtJournal.Rows(i).Item("amountDR")) - CDbl(dtJournal.Rows(i).Item("amountCR"))
                    dtJournal.Rows(i).Item("saldoakhir") = tempSaldoAkhir
                Else
                    counter = 0
                End If
                i = i + 1
            End While
            j = j + 1
            i = 0
        End While


        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report GL"
        frmChild.dtGL = dtJournal
        frmChild.period = cmbPeriod.SelectedValue
        frmChild.Show()
    End Sub

    Private Sub CalculateGLSingleCOA(ByVal COA1 As String)
        Dim dtCOABB As New DataTable
        Dim dtJournal As New DataTable
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim counter As Integer = 0
        Dim tempSaldoAkhir As Double
        'Dim tempSaldoAwal As Double

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetSaldoAwalSingle '" & COA1 & "','" & cmbPeriod.SelectedValue & " '"

            DA.SelectCommand = Cmd
            DA.Fill(dtCOABB)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "select journalDate ,accountid , account_name , notes ,a.journalID , refno  , '' as saldoawal , amountDR , amountCR , '' as saldoakhir " & _
                             "from journalitem a left join journal b " & _
                             "on a.journalID = b.journalID " & _
                             "left join master_COA c on a.accountID = c.account_ID " & _
                             "left join  master_COA_BB d on a.accountID = d.account_ID " & _
                             "left join trans_closing e on d.period = e.period " & _
                             "where accountid = '" & COA1 & "'" & _
                             "and journalDate between start_date and end_date " & _
                             "and d.period = '" & cmbPeriod.SelectedValue & "' " & _
                             "order by accountid asc "


            DA.SelectCommand = Cmd
            DA.Fill(dtJournal)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        While j < dtCOABB.Rows.Count
            While i < dtJournal.Rows.Count
                If dtCOABB.Rows(j).Item("account_id") = dtJournal.Rows(i).Item("accountid") Then
                    If counter = 0 Then
                        tempSaldoAkhir = dtCOABB.Rows(j).Item("saldoawal")
                        dtJournal.Rows(i).Item("saldoawal") = tempSaldoAkhir
                        counter = counter + 1
                    Else
                        dtJournal.Rows(i).Item("saldoawal") = dtJournal.Rows(i - 1).Item("saldoakhir")
                    End If
                    tempSaldoAkhir = tempSaldoAkhir + CDbl(dtJournal.Rows(i).Item("amountDR")) - CDbl(dtJournal.Rows(i).Item("amountCR"))
                    dtJournal.Rows(i).Item("saldoakhir") = tempSaldoAkhir
                Else
                    counter = 0
                End If
                i = i + 1
            End While
            j = j + 1
            i = 0
        End While


        Dim frmChild As New frmPrint
        frmChild.ReportName = "Report GL"
        frmChild.dtGL = dtJournal
        frmChild.period = cmbPeriod.SelectedValue
        frmChild.Show()

    End Sub
    Private Sub LoadPeriod()
        Dim dt As New DataTable
        dt.Clear()
        Try
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
            Cmd.CommandText = "Select Period from trans_closing"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            cmbPeriod.ValueMember = "Period"
            cmbPeriod.DataSource = dt
        Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtKdCOA1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKdCOA1.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Account_ID,Account_Name from Master_COA", "Account_ID", "Account_Name", "", "", "", "")
            txtKdCOA1.Text = frmSearch.txtResult1.Text.ToString.Trim
            If txtKdCOA2.Text = "" Then
                txtKdCOA2.Text = frmSearch.txtResult1.Text.ToString.Trim
            End If
        End If
    End Sub

    Private Sub txtKdCOA2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKdCOA2.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select Account_ID,Account_Name from Master_COA", "Account_ID", "Account_Name", "", "", "", "")
            txtKdCOA2.Text = frmSearch.txtResult1.Text.ToString.Trim
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim COA1 As String = ""
        Dim COA2 As String = ""

        If txtKdCOA1.Text = "" And txtKdCOA2.Text = "" Then
            MessageBox.Show("Kode COA must be filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtKdCOA1.Text = "" Or txtKdCOA2.Text = "" Then
            If txtKdCOA1.Text = "" Then
                COA1 = txtKdCOA2.Text
            Else
                COA1 = txtKdCOA1.Text
            End If
            CalculateGLSingleCOA(COA1)
        Else
            COA1 = txtKdCOA1.Text
            COA2 = txtKdCOA2.Text

            CalculateGLRangeCOA(COA1, COA2)
        End If

    End Sub
End Class