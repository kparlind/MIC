Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data
Imports System.Data.SqlClient

Public Class frmTransReturToko_View
    Public TransID As String
    Dim dtView As DataTable

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If userlog.AccessID = Role.ProjectAdmin OrElse userlog.AccessID = Role.SuperAdmin Then
            Dim frmChild As New frmTransReturToko

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmTransReturToko" Then
                    f.BringToFront()
                    MessageBox.Show("Transaction form is in use." & vbCrLf & "Please close the form first, and try to reprocess.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            frmChild.LoadTransNo = String.Empty
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
            Me.Close()
        Else
            MessageBox.Show("Unauthorized user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub frmPengembalianBrgView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtView = New DataTable

        dtpBeginDate.Value = DateSerial(Year(Now), Month(Now), 1)
        btnFind_Click(Nothing, Nothing)

        If userlog.AccessID = Role.AdminToko OrElse userlog.AccessID = Role.SuperAdmin Then
            btnNew.Enabled = True
        Else
            btnNew.Enabled = False
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
            .HeaderText = "Retur Toko No."
            .Width = 100
        End With
        With gView.Columns(1)
            .HeaderText = "Retur Toko Date"
            .DefaultCellStyle.Format = "dd-MMM-yyyy"
            .Width = 100
        End With
        With gView.Columns(2)
            .HeaderText = "Invoice No."
            .Width = 80
        End With
        With gView.Columns(3)
            .HeaderText = "Customer"
            .Width = 180
        End With
        With gView.Columns(4)
            .HeaderText = "Retur Type"
            .Width = 100
        End With
        With gView.Columns(5)
            .HeaderText = "Remarks"
            .Width = 280
        End With
    End Sub

    Private Sub gView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gView.CellDoubleClick
        Dim frmChild As New frmTransReturToko

        If gView.CurrentRow.DataGridView(0, gView.CurrentRow.Index).Value.ToString = String.Empty Then Exit Sub
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransReturToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.LoadTransNo = gView.CurrentRow.Cells(0).Value.ToString.Trim
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub txtTransNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransNo.KeyDown
        Dim dtData As New DataTable

        If e.KeyCode = Keys.F1 Then
            Call frmSearch.InitFindData(":: Find Retur Toko ::", "exec sp_Retrieve_Trans_ReturToko_Hdr_ForSearch")

            Call frmSearch.AddFindColumn(1, "ReturToko_No", "Retur Toko#", DataType.TypeString, 100)
            Call frmSearch.AddFindColumn(2, "ReturToko_Date", "Retur Toko Date", DataType.TypeDateTime, 100)
            Call frmSearch.AddFindColumn(3, "PT_No`", "Invoice#", DataType.TypeString, 80)
            Call frmSearch.AddFindColumn(4, "Nama", "Customer", DataType.TypeString, 200)
            Call frmSearch.AddFindColumn(5, "Remarks", "Remarks", DataType.TypeString, 250)
            frmSearch.ShowDialog()

            If frmSearch.txtResult1.Text.Trim <> String.Empty Then
                txtTransNo.Text = frmSearch.txtResult1.Text.Trim
                btnFind.Focus()
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
            query = "exec sp_Retrieve_View_ReturToko "
            queryParam = "'" & Format(dtpBeginDate.Value, "yyyyMMdd") & "', '" & Format(dtpEndDate.Value, "yyyyMMdd") & "', " & _
                         "'" & txtTransNo.Text.Trim & "'"
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