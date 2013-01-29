Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmSearch
    Private dtData As DataTable
    Private dtShown As DataTable
    Private gridFindSize As Integer
    Private Query As String

    Public Sub InitFindData(ByVal FormTitle As String, ByVal QuerySearch As String)
        Me.Text = FormTitle
        Query = QuerySearch

        dtShown = New DataTable
        gridFindSize = 0
        lstWidth.Items.Clear()
        gridFind.DataSource = "" '--added by kparlind

        cboFind1.Items.Clear()
        cboFind2.Items.Clear()
        cboFind3.Items.Clear()
        cboFind4.Items.Clear()
        cboFind1.Items.Add("")
        cboFind2.Items.Add("")
        cboFind3.Items.Add("")
        cboFind4.Items.Add("")
    End Sub

    Public Sub AddFindColumn(ByVal ColumnNo As Integer, ByVal DataFieldName As String, ByVal ColumnTitle As String, ByVal TypeData As String, ByVal ColumnSize As Integer)
        Dim i As Integer

        i = dtShown.Columns.Count
        dtShown.Columns.Add(DataFieldName, System.Type.GetType(TypeData))
        dtShown.Columns(ColumnNo - 1).Caption = ColumnTitle

        lstWidth.Items.Insert(ColumnNo - 1, ColumnSize)
        gridFindSize += ColumnSize

        cboFind1.Items.Insert(ColumnNo, ColumnTitle)
        cboFind2.Items.Insert(ColumnNo, ColumnTitle)
        cboFind3.Items.Insert(ColumnNo, ColumnTitle)
        cboFind4.Items.Insert(ColumnNo, ColumnTitle)
    End Sub

    Private Sub SetData()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try            
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = Query
            DA.SelectCommand = Cmd

            dtData = New DataTable
            dtData.Clear() '--added by kparlind
            DA.Fill(dtData)

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataToGrid()
        Dim i As Integer, j As Integer
        Dim drShown As DataRow

        dtShown.Rows.Clear()
        If dtData.Rows.Count <> 0 AndAlso Not dtShown Is Nothing Then
            For i = 0 To dtData.Rows.Count - 1
                drShown = dtShown.NewRow
                With drShown
                    For j = 0 To dtShown.Columns.Count - 1
                        .Item(j) = dtData.Rows(i).Item(dtShown.Columns(j).ColumnName)
                    Next
                End With
                dtShown.Rows.Add(drShown)
            Next

            gridFind.DataSource = dtShown
        End If

        If gridFind.Rows.Count <> 0 Then
            For j = 0 To lstWidth.Items.Count - 1
                gridFind.Columns(j).Width = lstWidth.Items(j)
            Next
        End If
    End Sub

    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetData()
        LoadDataToGrid()

        cboFind1.SelectedIndex = 0
        cboFind1_SelectedIndexChanged(sender, e)

        If gridFindSize > 340 Then
            gridFind.Width = gridFindSize + 70
            Me.Width = 540 + (gridFindSize - 440)
        End If

        txtResult1.Text = String.Empty
        txtResult2.Text = String.Empty
        txtResult3.Text = String.Empty
        txtResult4.Text = String.Empty
        txtResult5.Text = String.Empty
        txtresult6.Text = String.Empty
        gridFind.AllowUserToAddRows = False
        gridFind.AllowUserToDeleteRows = False
        gridFind.ReadOnly = True
    End Sub

    Private Sub cboFind1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFind1.SelectedIndexChanged
        If cboFind1.SelectedIndex <> 0 Then
            If Not cboFind2.Visible Then
                cboFind2.Visible = True
                txtFind2.Visible = True
                cboFind2.SelectedIndex = 0
                cboFind2_SelectedIndexChanged(sender, e)
            End If
        Else
            cboFind2.Visible = False
            cboFind3.Visible = False
            cboFind4.Visible = False

            txtFind2.Visible = False
            txtFind3.Visible = False
            txtFind4.Visible = False

            Me.Height = 457
        End If
    End Sub

    Private Sub cboFind2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind2.SelectedIndexChanged
        If cboFind2.SelectedIndex <> 0 Then
            If Not cboFind3.Visible Then
                cboFind3.Visible = True
                txtFind3.Visible = True
                cboFind3.SelectedIndex = 0
                cboFind3_SelectedIndexChanged(sender, e)
            End If
        Else
            cboFind3.Visible = False
            cboFind4.Visible = False
            txtFind3.Visible = False
            txtFind4.Visible = False

            Me.Height = 481
        End If
    End Sub

    Private Sub cboFind3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind3.SelectedIndexChanged
        If cboFind3.SelectedIndex <> 0 Then
            If Not cboFind4.Visible Then
                cboFind4.Visible = True
                txtFind4.Visible = True
                cboFind4.SelectedIndex = 0
            End If

            Me.Height = 535
        Else
            cboFind4.Visible = False
            txtFind4.Visible = False

            Me.Height = 507
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If gridFind.SelectedRows.Count <> 0 Then
            With gridFind.SelectedRows.Item(0)
                txtResult1.Text = .Cells(0).Value
                If .Cells.Count > 1 Then txtResult2.Text = .Cells(1).Value
                If .Cells.Count > 2 Then txtResult3.Text = .Cells(2).Value
                If .Cells.Count > 3 Then txtResult4.Text = .Cells(3).Value
                If .Cells.Count > 4 Then txtResult5.Text = .Cells(4).Value
                If .Cells.Count > 5 Then txtresult6.Text = .Cells(5).Value
            End With
        End If

        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim Str As String = String.Empty
        Dim row As DataRow()
        Dim i As Integer, j As Integer
        Dim fl As Boolean

        If cboFind1.SelectedIndex <> 0 Then
            If Str.Trim <> String.Empty Then Str &= "and "
            Str &= gridFind.Columns(cboFind1.SelectedIndex - 1).Name & " like '*" & txtFind1.Text & "*'"
        End If

        If cboFind2.Visible AndAlso cboFind2.SelectedIndex <> 0 Then
            If Str.Trim <> String.Empty Then Str &= "and "
            Str &= gridFind.Columns(cboFind2.SelectedIndex - 1).Name & " like '*" & txtFind2.Text & "*'"
        End If

        If cboFind3.Visible AndAlso cboFind3.SelectedIndex <> 0 Then
            If Str.Trim <> String.Empty Then Str &= "and "
            Str &= gridFind.Columns(cboFind3.SelectedIndex - 1).Name & " like '*" & txtFind3.Text & "*'"
        End If

        If cboFind4.Visible AndAlso cboFind4.SelectedIndex <> 0 Then
            If Str.Trim <> String.Empty Then Str &= "and "
            Str &= gridFind.Columns(cboFind4.SelectedIndex - 1).Name & " like '*" & txtFind4.Text & "*'"
        End If

        SetData()
        row = dtData.Select(Str)
        j = dtData.Rows.Count - 1

        While j >= 0
            fl = False
            For i = 0 To row.Length - 1
                If dtData.Rows(j).Equals(row(i)) Then
                    fl = True
                    Exit For
                End If
            Next

            If Not fl Then
                dtData.Rows(j).Delete()
            End If

            j -= 1
        End While

        dtData.AcceptChanges()
        LoadDataToGrid()
    End Sub

    Private Sub gridFind_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridFind.CellDoubleClick
        With gridFind.Rows(e.RowIndex)
            txtResult1.Text = .Cells(0).Value
            If .Cells.Count > 1 Then txtResult2.Text = .Cells(1).Value
            If .Cells.Count > 2 Then txtResult3.Text = .Cells(2).Value
            If .Cells.Count > 3 Then txtResult4.Text = .Cells(3).Value
            If .Cells.Count > 4 Then txtResult5.Text = .Cells(4).Value
            If .Cells.Count > 5 Then txtresult6.Text = .Cells(5).Value
        End With

        Me.Hide()
    End Sub

    Private Sub gridFind_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridFind.DataBindingComplete
        Dim i As Integer
        Dim dtTemp As New DataTable

        dtTemp = gridFind.DataSource
        For i = 0 To gridFind.Columns.Count - 1
            gridFind.Columns(i).HeaderText = dtTemp.Columns(i).Caption
        Next
    End Sub

    Private Sub gridFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            With gridFind.Rows(gridFind.CurrentRow.Index)
                txtResult1.Text = .Cells(0).Value
                If .Cells.Count > 1 Then txtResult2.Text = .Cells(1).Value
                If .Cells.Count > 2 Then txtResult3.Text = .Cells(2).Value
                If .Cells.Count > 3 Then txtResult4.Text = .Cells(3).Value
                If .Cells.Count > 4 Then txtResult5.Text = .Cells(4).Value
                If .Cells.Count > 5 Then txtresult6.Text = .Cells(5).Value
            End With

            Me.Hide()
        End If
    End Sub

    Private Sub gridFind_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles gridFind.RowsAdded
        Dim i As Integer

        For i = 0 To gridFind.Columns.Count - 1
            Select Case dtShown.Columns(i).DataType.ToString.Trim
                Case DataType.TypeDouble
                    gridFind.Columns(i).DefaultCellStyle.Format = "#,##0.#0"
                    gridFind.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case DataType.TypeDateTime
                    gridFind.Columns(i).DefaultCellStyle.Format = "dd MMM yyyy"
                Case DataType.TypeDecimal
                    gridFind.Columns(i).DefaultCellStyle.Format = "#,##0.#0"
                    gridFind.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next
    End Sub

End Class