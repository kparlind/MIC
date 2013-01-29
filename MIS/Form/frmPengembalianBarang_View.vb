'(30 Des 2012) Fix bug on find button

Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPengembalianBarang_View
    Public TransID As String
    Dim dtView As DataTable

    Private Sub frmPengembalianBrgView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtView = New DataTable

        dtpBeginDate.Value = DateSerial(Year(Now), Month(Now), 1)
        cboType.SelectedIndex = 0
        btnFind_Click(Nothing, Nothing)

        If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
            btnNew.Enabled = True
        Else
            btnNew.Enabled = False
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
            Dim frmChild As New frmPengembalianBarang

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmPengembalianBarang" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            frmChild.TransNo = String.Empty
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Close()
        Else
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        dtView = New DataTable
        RetrieveData(dtView)
        gView.DataSource = dtView
        SetGrid()
    End Sub

    Private Sub SetGrid()
        With gView.Columns(0)
            .HeaderText = "Trans No."
            .Width = 90
        End With
        With gView.Columns(1)
            .HeaderText = "Trans Date"
            .DefaultCellStyle.Format = "dd-MMM-yyyy"
            .Width = 100
        End With
        With gView.Columns(2)
            .HeaderText = "BPB No."
            .Width = 100
        End With
        With gView.Columns(3)
            .HeaderText = "Remarks"
            .Width = 300
        End With
    End Sub

    Private Sub gView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gView.CellDoubleClick
        Dim frmChild As New frmPengembalianBarang

        If gView.CurrentRow.DataGridView(0, gView.CurrentRow.Index).Value.ToString = String.Empty Then Exit Sub
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPengembalianBarang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.TransNo = gView.CurrentRow.Cells(0).Value.ToString.Trim
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub txtTransNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransNo.KeyDown
        Dim dtData As New DataTable

        If e.KeyCode = Keys.F1 Then
            Call frmSearch.InitFindData(":: Find Pengembalian Barang (Gudang) ::", "exec sp_Retrieve_Trans_KembaliBarang_Hdr_ForSearch")

            Call frmSearch.AddFindColumn(1, "KB_No", "Trans#", DataType.TypeString, 100)
            Call frmSearch.AddFindColumn(2, "KB_Date", "Trans Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(3, "Refer_No", "Reference#", DataType.TypeString, 100)
            Call frmSearch.AddFindColumn(4, "Remarks", "Remarks", DataType.TypeString, 250)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtTransNo.Text = frmSearch.txtResult1.Text.Trim
                cboType.Focus()
            End If
        End If
    End Sub

    Private Sub RetrieveData(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim query As String
        Dim queryParam As String

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            query = "exec sp_Retrieve_View_KembaliBarang "
            queryParam = "'" & Format(dtpBeginDate.Value, "yyyyMMdd") & "', '" & Format(dtpEndDate.Value, "yyyyMMdd") & "', " & _
                         "'" & txtTransNo.Text.Trim & "','" & IIf(cboType.SelectedIndex = 0, "ALL", IIf(cboType.SelectedIndex = 1, "SPK", "Fabrikasi")) & "'"
            Cmd.CommandText = query & queryParam
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
End Class