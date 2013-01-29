Imports System.Data.SqlClient
Imports MIS.GlobalVar

Public Class frm_MasterClosing
    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Dim lvRb As String
    Dim status As String
    Dim LastSerial As Integer
    Dim remarks_Stok As String

    Private Sub frm_MasterClosing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()

    End Sub

    Private Sub InitField()
        txtClosingNo.Text = String.Empty
        txtPeriod.Text = String.Empty
        cb_ReOpen.Checked = False
        txt_statusClosing.Text = String.Empty
    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)        
        'txtPeriod.Enabled = Flag
        'dt_closing.Enabled = Flag
        dt_start.Enabled = Flag
        dt_end.Enabled = Flag
    End Sub
    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case "NEW"
                btnEdit.Enabled = False
                btnNew.Enabled = False               
                btnSave.Enabled = True
            Case "EDIT"
                btnEdit.Enabled = False
                btnNew.Enabled = False
                btnSave.Enabled = True
                SetEnabled(True)
            Case Else
                btnNew.Enabled = True
                btnEdit.Enabled = True
                btnSave.Enabled = False
        End Select
    End Sub

    Private Sub LoadGrid()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.ConnectionString = ConnectStr
                Conn.Open()
            End If


            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retreive_Trans_Closing" 'Retreive all
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridClosing.DataSource = dtTemp
            SetGrid()
            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub SetGrid()
        GridClosing.Columns(0).Width = 100
        GridClosing.Columns(1).Width = 150
        GridClosing.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"
        GridClosing.Columns(2).Width = 100
        GridClosing.Columns(2).DefaultCellStyle.Format = "dd-MM-yyyy"
        GridClosing.Columns(3).Width = 100
        GridClosing.Columns(3).DefaultCellStyle.Format = "dd-MM-yyyy"
        GridClosing.Columns(4).Width = 200
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtClosingNo.Text.Trim = "" Then
            MessageBox.Show("Please select at least one data !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Cek apakah period tersebut boleh di edit atau gak
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        'Cmd.CommandText = "Select top 1 period from Trans_Closing order by Period DESC"
        'DA.SelectCommand = Cmd
        'DA.Fill(dt)

        'If dt.Rows(0).Item("Period") > txtPeriod.Text.Trim Then
        '    MessageBox.Show("This Period has been Closed. It is not allowed to be modified", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        SetEnabled(True)

        StatusTrans = "EDIT"
        SetToolTip()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If dt_end.Value <= dt_start.Value Then
            MessageBox.Show("End Date must bigger than start date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cb_ReOpen.Checked Then
            If MessageBox.Show("Update Closing will ReOpen the choosen period. Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Try
            remarks_Stok = "Master Closing : " & Generate_Period() & ". Transaction : " & txtClosingNo.Text.Trim & " processes by " & userlog.UserName & " at " & CStr(Now())
            If StatusTrans = "NEW" Then
                txtClosingNo.Text = Generate_TranNo(Me.Name)
                LastSerial = CInt(Microsoft.VisualBasic.Right(txtClosingNo.Text, 3))

                status = "CLOP" 'Closing Open
                Cmd.CommandText = "EXEC sp_Insert_Trans_Closing '" & txtClosingNo.Text & "','" & dt_start.Value.ToString("yyyyMM") & "','" & _
                                   Format(dt_start.Value, "MM-dd-yyyy") & "','" & Format(dt_end.Value, "MM-dd-yyyy") & "','" & status & "','" & userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtClosingNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction
                MessageBox.Show("New Period Closing Has been Created..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If cb_ReOpen.Checked Then
                    status = "CLOP" ' Status Closing ReOpen            
                End If

                Cmd.CommandText = "exec sp_Update_Trans_Closing '" & txtClosingNo.Text.Trim & "', '" & dt_start.Value & "', '" _
                                  & dt_end.Value & "', '" & status & "','" & userlog.UserName & "'"

                Cmd.ExecuteNonQuery()
                UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
                Insert_Trans_History(txtClosingNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
                MessageBox.Show("Update Closing Succedded!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            btnCancel_Click(Nothing, Nothing)

            Conn.Close()
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try

    End Sub

    Private Sub GridClosing_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridClosing.CellClick        
        If e.RowIndex >= 0 Then
            With GridClosing.Rows(e.RowIndex)
                txtClosingNo.Text = .Cells(0).Value.ToString
                dt_closing.Value = CDate(.Cells(1).Value.ToString)
                txtPeriod.Text = .Cells(2).Value.ToString
                dt_start.Value = CDate(.Cells(3).Value.ToString)
                dt_end.Value = CDate(.Cells(4).Value.ToString)
                txt_statusClosing.Text = .Cells(5).Value.ToString
                status = .Cells(6).Value.ToString
                If status <> "CLOP" Then
                    cb_ReOpen.Enabled = True
                Else
                    cb_ReOpen.Enabled = False
                End If
            End With
        End If        
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        GridClosing.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        StatusTrans = "NEW"
        InitField()
        SetEnabled(True)
        SetToolTip()
        cb_ReOpen.Enabled = False
    End Sub
End Class