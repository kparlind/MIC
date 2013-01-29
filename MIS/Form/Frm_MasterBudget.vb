Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterBudget

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable

    Private Sub Frm_MasterBudget_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Conn.ConnectionString = ConnectStr
        LoadGrid()
    End Sub
    Private Sub LoadGrid()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Budget "
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridBudget.DataSource = dtTemp

            GridBudget.Columns(0).ReadOnly = True
            GridBudget.Columns(1).ReadOnly = True

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub GridBudget_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridBudget.CellValueChanged
        'If Not enterNumeric(Asc(GridBudget.SelectedCells.Item(0).Value)) Then
        '    GridBudget.SelectedCells.Item(0).Value = Chr(0)
        'End If
    End Sub

    Private Sub GridBudget_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GridBudget.DataError
        'If (e.Context = DataGridViewDataErrorContexts.Commit) _
        '    Then
        '    MessageBox.Show("Commit error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
        '    MessageBox.Show("Cell change")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
        '    MessageBox.Show("parsing error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
        '    MessageBox.Show("leave control error")
        'End If

        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"
        '    MsgBox("error")
        '    e.ThrowException = False
        'End If


        MessageBox.Show("Must be fill by numeric value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        'If (e.Context = DataGridViewDataErrorContexts.Commit) _
        '    Then
        '    MessageBox.Show("Commit error")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts _
        '    .CurrentCellChange) Then
        '    MessageBox.Show("Cell change")
        'End If
        'If (e.Context = DataGridViewDataErrorContexts.Parsing) _
        '    Then
        '    MessageBox.Show("parsing error")
        'End If
        'If (e.Context = _
        '    DataGridViewDataErrorContexts.LeaveControl) Then
        '    MessageBox.Show("leave control error")
        'End If

        'If (TypeOf (e.Exception) Is ConstraintException) Then
        '    Dim view As DataGridView = CType(sender, DataGridView)
        '    view.Rows(e.RowIndex).ErrorText = "an error"
        '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
        '        .ErrorText = "an error"

        '    e.ThrowException = False
        'End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Conn.ConnectionString = ConnectStr
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        Try


            For i As Integer = 0 To GridBudget.Rows.Count - 1
                'Cmd.CommandText = "EXEC sp_Insert_Master_Budget '" & GridBudget.Rows(i).Cells(0).Value & "', '" & Replace(GridBudget.Rows(i).Cells(2).Value.ToString, ",", ".") & "', '" _
                '    & Replace(GridBudget.Rows(i).Cells(3).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(4).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(5).Value.ToString, ",", ".") & "', '" _
                '    & Replace(GridBudget.Rows(i).Cells(6).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(7).Value.ToString, ",", ".") & "', '" _
                '    & Replace(GridBudget.Rows(i).Cells(8).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(9).Value.ToString, ",", ".") & "', '" _
                '    & Replace(GridBudget.Rows(i).Cells(10).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(11).Value.ToString, ",", ".") & "', '" _
                '    & Replace(GridBudget.Rows(i).Cells(12).Value.ToString, ",", ".") & "', '" & Replace(GridBudget.Rows(i).Cells(13).Value.ToString, ",", ".") & "', '" & userlog.UserName & "'"
                If IsDBNull(GridBudget.Rows(i).Cells(2).Value) Then
                    GridBudget.Rows(i).Cells(2).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(3).Value) Then
                    GridBudget.Rows(i).Cells(3).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(4).Value) Then
                    GridBudget.Rows(i).Cells(4).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(5).Value) Then
                    GridBudget.Rows(i).Cells(5).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(6).Value) Then
                    GridBudget.Rows(i).Cells(6).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(7).Value) Then
                    GridBudget.Rows(i).Cells(7).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(8).Value) Then
                    GridBudget.Rows(i).Cells(8).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(9).Value) Then
                    GridBudget.Rows(i).Cells(9).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(10).Value) Then
                    GridBudget.Rows(i).Cells(10).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(11).Value) Then
                    GridBudget.Rows(i).Cells(11).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(12).Value) Then
                    GridBudget.Rows(i).Cells(12).Value = 0
                End If
                If IsDBNull(GridBudget.Rows(i).Cells(13).Value) Then
                    GridBudget.Rows(i).Cells(13).Value = 0
                End If

                dtTemp.Clear()
                Cmd.CommandText = "exec sp_Retrieve_Master_Budget_ByPK '" & GridBudget.Rows(i).Cells(0).Value & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dtTemp)

                If dtTemp.Rows.Count > 0 Then
                    Cmd.CommandText = "EXEC sp_Update_Master_Budget " & GridBudget.Rows(i).Cells(0).Value & ", " & Replace(GridBudget.Rows(i).Cells(2).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(3).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(4).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(5).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(6).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(7).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(8).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(9).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(10).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(11).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(12).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(13).Value, ",", ".") & ", '" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()
                Else

                    Cmd.CommandText = "EXEC sp_Insert_Master_Budget " & GridBudget.Rows(i).Cells(0).Value & ", " & Replace(GridBudget.Rows(i).Cells(2).Value, ",", ".") & ", " _
                     & Replace(GridBudget.Rows(i).Cells(3).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(4).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(5).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(6).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(7).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(8).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(9).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(10).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(11).Value, ",", ".") & ", " _
                       & Replace(GridBudget.Rows(i).Cells(12).Value, ",", ".") & ", " & Replace(GridBudget.Rows(i).Cells(13).Value, ",", ".") & ", '" & userlog.UserName & "'"
                    Cmd.ExecuteNonQuery()
                End If

            Next
            MessageBox.Show("Save Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Frm_MasterBudget_Load(sender, e)
    End Sub
End Class