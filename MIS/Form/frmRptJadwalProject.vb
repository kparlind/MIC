Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmRptJadwalProject
    Dim Status_Proses As String
    Dim dt_hdr As New DataTable
    Dim dr_hdr As DataRow
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtProject.Text = String.Empty Then
            TxtProject.Text = "all"
        End If
        If txtSPKNo.Text = String.Empty Then
            txtSPKNo.Text = "all"
        End If
        If txtTeknisi.Text = String.Empty Then
            txtTeknisi.Text = "all"
        End If

        Dim frmChild As New frmPrint
        Dim dtSPK As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "exec sp_GetJadwalKerjaProject '" & txtSPKNo.Text & "','" & txtTeknisi.Text & "','" & TxtProject.Text & "','" & dt1.Value & "','" & dt2.Value & "' "

            DA.SelectCommand = Cmd
            DA.Fill(dtSPK)
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        frmChild.ReportName = "Report Jadwal Project"
        frmChild.dtSPK = dtSPK
        frmChild.Show()


    End Sub


    Private Sub txtSPKNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSPKNo.KeyDown
        CallandGetSearchData("select SPK_No from trans_SPK_hdr", "SPK_NO", "", "", "", "")
        txtSPKNo.Text = frmSearch.txtResult1.Text.ToString.Trim

    End Sub

    Private Sub TxtProject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProject.KeyDown
        CallandGetSearchData("select Project_No from trans_SPK_hdr", "Project_NO", "", "", "", "")
        TxtProject.Text = frmSearch.txtResult1.Text.ToString.Trim
    End Sub

    Private Sub txtTeknisi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTeknisi.KeyDown
        CallandGetSearchData("select teknisi_ID from trans_SPK_Dtl", "teknisi_ID", "", "", "", "")
        txtTeknisi.Text = frmSearch.txtResult1.Text.ToString.Trim
    End Sub

    Private Sub frmRptJadwalProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
    End Sub
End Class