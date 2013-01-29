Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptLabaRugiPerDivisi
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub frmRptLabaRugiPerDivisi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
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

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dtBiayaTeknis As New DataTable
        Dim dtHPP As New DataTable
        Dim dtTotalPHP As New DataTable
        Dim dtInvMarketing As New DataTable
        Dim dtbiayamarketing As New DataTable
        Dim dtTotalPHM As New DataTable


        If cmbDivisi.SelectedItem = "Project" Then
            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getTotalPHP  '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtTotalPHP)
                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getHPP_Project '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtHPP)
                MsgBox(dtHPP.Rows.Count)


                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getBiayaTeknis '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtBiayaTeknis)

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try




            Dim frmChild As New frmPrint
            frmChild.ReportName = "Report Laba Rugi Project"
            frmChild.dtBiayaTeknis = dtBiayaTeknis
            frmChild.dtHPP = dtHPP
            frmChild.dtTotalPHP = dtTotalPHP
            frmChild.Show()

        Else

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getTotalPHM  '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtTotalPHM)
                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getInvoiceMarketing '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtInvMarketing)



                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If

                Cmd.CommandText = "exec sp_getBiayaMarketing '" & cmbPeriode.SelectedValue & "'"


                DA.SelectCommand = Cmd
                DA.Fill(dtBiayaMarketing)

                Conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try




            Dim frmChild As New frmPrint
            frmChild.ReportName = "Report Laba Rugi Marketing"
            frmChild.dtBiayaTeknis = dtBiayaTeknis
            frmChild.dtHPP = dtHPP
            frmChild.dtTotalPHP = dtTotalPHP
            frmChild.Show()

        End If

      
    End Sub
End Class