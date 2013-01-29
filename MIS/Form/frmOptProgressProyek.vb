Imports MIS.GlobalVar
Imports MIS.TransData
Imports System.Data
Imports System.Data.SqlClient

Public Class frmOptProgressProyek
    Public Type As Integer

    Dim dtSPK As New DataTable
    Dim TD As New TransData
    Dim ProjectNo As String

    Private Sub frmOptProgressProyek_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtProjectNo.Text = String.Empty
        txtProjectName.Text = String.Empty
        ProjectNo = txtProjectNo.Text.Trim
        txtProjectNo.BackColor = Color.LightGoldenrodYellow

        cboEfficiency.SelectedIndex = 0
        LoadSPK()

        'Type 1 => Progress Proyek, Type 2 => Rekap Pemakaian Bahan
        Select Case Type
            Case 1
                Me.Text = ":: Report Progress Project Per SPK ::"
            Case 2
                Me.Text = ":: Report Rekap Progress Project Per SPK ::"
        End Select
    End Sub

    Private Sub LoadSPK()
        cboSPK.DataSource = Nothing
        dtSPK = New DataTable

        TD.Retrieve_SPK_ByProjectNo(dtSPK, txtProjectNo.Text.Trim)
        If dtSPK.Rows.Count > 1 Then
            cboSPK.DataSource = dtSPK
            cboSPK.DisplayMember = "SPK_No"
            cboSPK.ValueMember = "SPK_No"

            cboSPK.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtProjectNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProjectNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            Call frmSearch.InitFindData(":: Find Project ::", "exec sp_Retrieve_Trans_Projects_List_forOptionReport")

            Call frmSearch.AddFindColumn(1, "Project_No", "Project ID", DataType.TypeString, 90)
            Call frmSearch.AddFindColumn(2, "Project_Name", "Project Name", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(3, "Project_Date", "Project Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(4, "Cust_Name", "Customer", DataType.TypeString, 200)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtProjectNo.Text = frmSearch.txtResult1.Text.Trim
                cboSPK.Focus()
            End If
        End If
    End Sub

    Private Sub txtProjectNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectNo.LostFocus
        If ProjectNo.Trim <> txtProjectNo.Text.Trim Then
            If txtProjectNo.Text.Trim = String.Empty Then
                cboSPK.DataSource = Nothing
                ProjectNo = String.Empty
                txtProjectName.Text = String.Empty
            Else
                ProjectNo = txtProjectNo.Text.Trim
                LoadSPK()

                Dim dtData As New DataTable
                TD.Retrieve_Projects_ByID_forOptionReport(dtData, ProjectNo)
                If dtData.Rows.Count <> 0 Then
                    txtProjectName.Text = dtData.Rows(0).Item("Project_Name").ToString.Trim
                Else
                    txtProjectName.Text = String.Empty
                End If
            End If
        End If
    End Sub

    Private Function CekAdaData1() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        CekAdaData1 = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_ProgressProjectPerSPK '" & txtProjectNo.Text.Trim & "', '" & cboSPK.SelectedValue & "', " & cboEfficiency.SelectedIndex
            DA.SelectCommand = Cmd
            DA.Fill(dtData)

            If dtData.Rows.Count <> 0 Then
                CekAdaData1 = True
            End If
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function CekAdaData2() As Boolean
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        CekAdaData2 = False
        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_RekapProgressProjectPerSPK '" & txtProjectNo.Text.Trim & "', '" & cboSPK.SelectedValue & "', " & cboEfficiency.SelectedIndex
            DA.SelectCommand = Cmd
            DA.Fill(dtData)

            If dtData.Rows.Count <> 0 Then
                CekAdaData2 = True
            End If
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Sub btnViewReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Dim frmChild As New frmReport
        Dim bl As Boolean

        Select Case Type
            Case 1
                bl = CekAdaData1()
                frmChild.ReportName = "Progress Project"
            Case 2
                bl = CekAdaData2()
                frmChild.ReportName = "Rekap Progress Project"
        End Select
        If bl Then
            frmChild.ProjectNo = txtProjectNo.Text.Trim
            frmChild.SPKNo = cboSPK.SelectedValue
            frmChild.isEfficient = cboEfficiency.SelectedIndex
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmReport" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Close()
        Else
            MessageBox.Show("Cannot retrieve any data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class