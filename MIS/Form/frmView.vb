Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class frmView
    Private Query As String
    Private dtData As DataTable
    Private dtShown As DataTable
    Private gridViewSize As Integer

    Public Sub InitFormView(ByVal FormTitle As String, ByVal spName As String)
        Me.Text = FormTitle
        Query = "exec " & spName

        dtData = New DataTable
        dtShown = New DataTable
        cboFilter.Items.Clear()
        cboFilter.Items.Add("")
        txtFilter.Text = String.Empty
        txtPKNo.Text = String.Empty
        gridViewSize = 0
    End Sub

    Public Sub AddColumnView(ByVal ColumnNo As Integer, ByVal ColumnSourceField As String, ByVal ColumnTitle As String, ByVal ColumnType As String, ByVal ColumnSize As Integer, Optional ByVal isPK As Boolean = False)
        dtShown.Columns.Add(ColumnSourceField, System.Type.GetType(ColumnType))
        dtShown.Columns(ColumnNo - 1).Caption = ColumnTitle
        lstWidth.Items.Insert(ColumnNo - 1, ColumnSize)
        gridViewSize += ColumnSize

        cboFilter.Items.Insert(ColumnNo, ColumnTitle)

        If isPK Then
            If txtPKNo.Text.Trim <> String.Empty Then
                txtPKNo.Text &= "|"
            End If

            txtPKNo.Text &= (ColumnNo - 1)
        End If
    End Sub

    Private Sub frmView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFromDate.Value = DateSerial(Year(Now), Month(Now), 1)
        dtpToDate.Value = Now

        cboFilter.SelectedIndex = 0
        txtFilter.Text = String.Empty

        gridDetail.AllowUserToAddRows = False
        gridDetail.AllowUserToDeleteRows = False
        gridDetail.ReadOnly = True

        If gridViewSize > 340 Then
            gridDetail.Width = gridViewSize + 70
            Me.Width = 540 + (gridViewSize - 440)
        End If

        LoadData()
    End Sub

    Private Sub LoadDataToGrid()
        Dim i As Integer, j As Integer
        Dim drShown As DataRow

        dtShown.Rows.Clear()
        If dtData.Rows.Count <> 0 And Not dtShown Is Nothing Then
            For i = 0 To dtData.Rows.Count - 1
                drShown = dtShown.NewRow
                With drShown
                    For j = 0 To dtShown.Columns.Count - 1
                        .Item(j) = dtData.Rows(i).Item(dtShown.Columns(j).ColumnName)
                    Next
                End With
                dtShown.Rows.Add(drShown)
            Next
        End If

        gridDetail.DataSource = dtShown
        For i = 0 To gridDetail.Columns.Count - 1
            gridDetail.Columns(i).Width = lstWidth.Items(i)
        Next
    End Sub

    Private Sub LoadData()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim BeginPeriod As String, EndPeriod As String
        Dim QueryParam As String

        Try
            Conn.ConnectionString = GlobalVar.ConnString
            Conn.Open()

            '*************************************************
            'Selalu sediakan sp dengan 4 parameter.
            '1. Tanggal periode transaksi awal
            '2. Tanggal periode transaksi akhir
            '3. Nama field yang akan difilter
            '4. Value dari field yang akan difilter.
            '*************************************************
            BeginPeriod = Format(dtpFromDate.Value, "yyyyMMdd")
            EndPeriod = Format(dtpToDate.Value, "yyyyMMdd")

            If cboFilter.SelectedIndex > 0 Then
                QueryParam = " '" & BeginPeriod & "', '" & EndPeriod & "', '" & dtShown.Columns(cboFilter.SelectedIndex - 1).ColumnName & "', '" & txtFilter.Text & "'"
            Else
                QueryParam = " '" & BeginPeriod & "', '" & EndPeriod & "', '" & String.Empty & "', '" & txtFilter.Text & "'"
            End If


            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Query & QueryParam
            DA.SelectCommand = Cmd

            dtData = New DataTable
            DA.Fill(dtData)

            Conn.Close()

            LoadDataToGrid()
        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub gridDetail_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDetail.CellDoubleClick
        Dim x As Integer = e.RowIndex
        Dim i As Integer
        Dim dtTemp As DataTable = gridDetail.DataSource
        Dim str() As String

        If txtPKNo.Text.Trim <> String.Empty Then
            str = txtPKNo.Text.Trim.Split("|")

            For i = 0 To str.Length - 1
                If txtPKValue.Text.Trim <> String.Empty Then
                    txtPKValue.Text &= "|"
                End If

                txtPKValue.Text &= dtTemp.Rows(x).Item(CInt(str(i)))
                Me.Hide()
            Next
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        LoadData()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtPKNo.Text = String.Empty
        txtPKValue.Text = String.Empty
        Me.Close()
    End Sub

    Private Sub gridDetail_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridDetail.DataBindingComplete
        Dim i As Integer

        For i = 0 To gridDetail.ColumnCount - 1
            gridDetail.Columns(i).HeaderText = dtShown.Columns(i).Caption
        Next
    End Sub

    Private Sub gridDetail_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles gridDetail.RowsAdded
        Dim i As Integer

        For i = 0 To gridDetail.Columns.Count - 1
            Select Case dtShown.Columns(i).DataType.ToString.Trim
                Case DataType.TypeDouble
                    gridDetail.Columns(i).DefaultCellStyle.Format = "#,##0.#0"
                    gridDetail.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case DataType.TypeDateTime
                    gridDetail.Columns(i).DefaultCellStyle.Format = "dd MMM yyyy"
                Case DataType.TypeDecimal
                    gridDetail.Columns(i).DefaultCellStyle.Format = "#,##0.#0"
                    gridDetail.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End Select
        Next
    End Sub
End Class