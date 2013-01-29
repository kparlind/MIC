Imports System.Data.SqlClient
Imports MIS.mdlCommon
Imports MIS.GlobalVar

Public Class frmLogBook

#Region "Variable Declaration"
    Private conn As New SqlConnection
    Private DA As New SqlDataAdapter
    Private cmd As New SqlCommand
    Private dt As New DataTable
    Private StatusTrans As String
    Private dtSPK As New DataTable
    Private CheckTime As Boolean
    Private LaborCost As Double
    Private OverheadCost As Double
    Private StandardLabor As Double
    Private StandardOverhead As Double
    Dim dc1(0) As DataColumn
#End Region

#Region "Procedure & Function"

    Private Sub RetrieveData()
        Dim dtTable As New DataTable

        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Trans_LogBook_ByKey 'By Log No', '" & txtLogNo.Text & "', '', '', '', '', '12-31-9999', '12-31-9999'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)

        If dtTable.Rows.Count = 0 Then Exit Sub
        txtLogNo.Enabled = False
        dtpLogDate.Value = dtTable.Rows(0).Item("Log Date")
        txtEmployeeID.Text = dtTable.Rows(0).Item("Employee ID")
        txtEmployeeName.Text = dtTable.Rows(0).Item("Employee Name")
        txtProcessID.Text = dtTable.Rows(0).Item("Process ID")
        cbCategory.SelectedItem = dtTable.Rows(0).Item("Category")
        txtProcessName.Text = dtTable.Rows(0).Item("Process Desc")
        dtpTimeFr.Value = dtTable.Rows(0).Item("Start Time")
        dtpTimeTo.Value = dtTable.Rows(0).Item("End Time")
        txtCost.Text = FormatAngka(dtTable.Rows(0).Item("Process Cost"))
        txtWorkDetail.Text = dtTable.Rows(0).Item("Work Detail")
        txtRemark.Text = dtTable.Rows(0).Item("Remarks")
        txtProjectNo.Text = dtTable.Rows(0).Item("Project No")
        txtProjectName.Text = dtTable.Rows(0).Item("Project Name")
        txtSPKNo.SelectedText = dtTable.Rows(0).Item("SPK No")
        StandardLabor = dtTable.Rows(0).Item("Labor Price")
        StandardLabor = dtTable.Rows(0).Item("Overhead Price")
  
    End Sub

    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case TransStatus.NewStatus
                ts_Edit.Visible = False
                ts_Delete.Visible = False
                ts_Save.Visible = True
                ts_Cancel.Visible = True
            Case TransStatus.EditStatus
                ts_Edit.Visible = False
                ts_Delete.Visible = False
                ts_Save.Visible = True
                ts_Cancel.Visible = True
            Case Else
                ts_Edit.Visible = True
                ts_Delete.Visible = True
                ts_Save.Visible = False
                ts_Cancel.Visible = False
        End Select
    End Sub

    Private Sub RetrieveSPK()
        dtSPK.Clear()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Trans_SPK_ALL"
            DA.SelectCommand = cmd
            DA.Fill(dtSPK)
            conn.Close()

            dc1(0) = dtSPK.Columns("SPK No")
            dtSPK.PrimaryKey = dc1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub InsertLogBook()
        Dim ObjTrans As SqlTransaction
        Dim LastSerial As Integer
        Dim TimeFr As String
        Dim TimeTo As String

        txtLogNo.Text = Generate_TranNo(Me.Name)
        LastSerial = CInt(Microsoft.VisualBasic.Right(txtLogNo.Text, 3))

        TimeFr = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                 CStr(Format(dtpTimeFr.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)
        TimeTo = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                 CStr(Format(dtpTimeTo.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)

        'Field: Log_No, Log_Dt, Project_No, SPK_No, Employee_ID, Proses_ID, Start_Time,  End_Time, Work_Detail, Remarks()
        '       Active_Flag, id_created, dt_created, id_lastupdated, dt_lastupdated
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            ObjTrans = conn.BeginTransaction("Trans")
            cmd.Transaction = ObjTrans

            cmd.Connection = conn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "EXEC sp_Insert_Trans_LogBook '" & txtLogNo.Text & "', " & _
                                                           "'" & Format(dtpLogDate.Value, "MM-dd-yyyy") & "', " & _
                                                           "'" & txtProjectNo.Text.Trim & "', " & _
                                                           "'" & txtSPKNo.Text.Trim & "', " & _
                                                           "'" & txtEmployeeID.Text & "', " & _
                                                           "'" & txtProcessID.Text & "', " & _
                                                           "'" & cbCategory.SelectedItem & "', " & _
                                                           "'" & TimeFr & "', " & _
                                                           "'" & TimeTo & "', " & _
                                                           "'" & CStr(CDec(StandardLabor)).Replace(",", ".") & "', " & _
                                                           "'" & CStr(CDec(StandardOverhead)).Replace(",", ".") & "', " & _
                                                           "'" & CStr(CDec(txtCost.Text)).Replace(",", ".") & "', " & _
                                                           "'" & txtWorkDetail.Text.Trim & "', " & _
                                                           "'" & txtRemark.Text.Trim & "', " & _
                                                           "'Y', " & _
                                                           "'" & userlog.UserName & "', " & _
                                                           "'" & userlog.UserName & "'"

            cmd.ExecuteNonQuery()

            Call InsertJurnal()
            Call UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial
            Call Insert_Trans_History(txtLogNo.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

            ObjTrans.Commit()
            conn.Close()

            MsgBox("Log Book has been saved", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UpdateLogBook()
        Dim TimeFr As String
        Dim TimeTo As String
        Dim ObjTrans As SqlTransaction

        TimeFr = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                CStr(Format(dtpTimeFr.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)
        TimeTo = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                 CStr(Format(dtpTimeTo.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)

        'Field: Log_No, Log_Dt, Project_No, SPK_No, Employee_ID, Proses_ID, Start_Time,  End_Time, Work_Detail, Remarks()
        '       Active_Flag, id_created, dt_created, id_lastupdated, dt_lastupdated
        Try
            If MessageBox.Show("Are you sure to save this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                If conn.State = ConnectionState.Closed Then conn.Open()
                ObjTrans = conn.BeginTransaction("Trans")
                cmd.Transaction = ObjTrans

                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC sp_Update_Trans_LogBook '" & txtLogNo.Text & "', " & _
                                                "'" & Format(dtpLogDate.Value, "MM-dd-yyyy") & "', " & _
                                                "'" & txtProjectNo.Text.Trim & "', " & _
                                                "'" & txtSPKNo.Text.Trim & "', " & _
                                                "'" & txtEmployeeID.Text & "', " & _
                                                "'" & txtProcessID.Text & "', " & _
                                                "'" & cbCategory.SelectedItem & "', " & _
                                                "'" & TimeFr & "', " & _
                                                "'" & TimeTo & "', " & _
                                                "'" & CStr(CDec(StandardLabor)).Replace(",", ".") & "', " & _
                                                "'" & CStr(CDec(StandardOverhead)).Replace(",", ".") & "', " & _
                                                "'" & CStr(CDec(txtCost.Text)).Replace(",", ".") & "', " & _
                                                "'" & txtWorkDetail.Text.Trim & "', " & _
                                                "'" & txtRemark.Text.Trim & "', " & _
                                                "'Y', " & _
                                                "'" & userlog.UserName & "'"

                cmd.ExecuteNonQuery()

                Call InsertJurnal()
                Call Insert_Trans_History(txtLogNo.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction

                ObjTrans.Commit()
                conn.Close()

                MsgBox("Log Book has been updated", MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteLogBook()
        Try
            If MessageBox.Show("Are you sure to delete this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim TimeFr As String
                Dim TimeTo As String
                Dim ObjTrans As SqlTransaction

                TimeFr = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                        CStr(Format(dtpTimeFr.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)
                TimeTo = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                         CStr(Format(dtpTimeTo.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)

                If conn.State = ConnectionState.Closed Then conn.Open()
                ObjTrans = conn.BeginTransaction("Trans")
                cmd.Transaction = ObjTrans

                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "EXEC sp_Update_Trans_LogBook '" & txtLogNo.Text & "', " & _
                                                "'" & Format(dtpLogDate.Value, "MM-dd-yyyy") & "', " & _
                                                "'" & txtProjectNo.Text.Trim & "', " & _
                                                "'" & txtSPKNo.Text.Trim & "', " & _
                                                "'" & txtEmployeeID.Text & "', " & _
                                                "'" & txtProcessID.Text & "', " & _
                                                "'" & cbCategory.SelectedItem & "', " & _
                                                "'" & TimeFr & "', " & _
                                                "'" & TimeTo & "', " & _
                                                "'" & CStr(CDec(txtCost.Text)).Replace(",", ".") & "', " & _
                                                "'" & txtWorkDetail.Text.Trim & "', " & _
                                                "'" & txtRemark.Text.Trim & "', " & _
                                                "'N', " & _
                                                "'" & userlog.UserName & "'"

                cmd.ExecuteNonQuery()

                Call InsertJurnal()
                Call Insert_Trans_History(txtLogNo.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                ObjTrans.Commit()
                conn.Close()

                MsgBox("Log Book has been delete", MsgBoxStyle.Information, "Information")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EnableDisableInput(ByVal boo As Boolean)
        Select Case boo
            Case True
                dtpLogDate.Enabled = True
                dtpTimeFr.Enabled = True
                dtpTimeTo.Enabled = True
                cbCategory.Enabled = True
                dgv_data.Enabled = True

                txtSPKNo.ReadOnly = False
                txtSPKNo.ForeColor = Color.Black
                txtSPKNo.BackColor = Color.White
                txtWorkDetail.ReadOnly = False
                txtWorkDetail.ForeColor = Color.Black
                txtWorkDetail.BackColor = Color.White
                txtRemark.ReadOnly = False
                txtRemark.ForeColor = Color.Black
                txtRemark.BackColor = Color.White

            Case False
                dtpLogDate.Enabled = False
                dtpTimeFr.Enabled = False
                dtpTimeTo.Enabled = False
                cbCategory.Enabled = False
                dgv_data.Enabled = False

                txtSPKNo.ReadOnly = True
                txtSPKNo.ForeColor = Color.Gray
                txtSPKNo.BackColor = Color.LightGray
                txtWorkDetail.ReadOnly = True
                txtWorkDetail.ForeColor = Color.Gray
                txtWorkDetail.BackColor = Color.LightGray
                txtRemark.ReadOnly = True
                txtRemark.ForeColor = Color.Gray
                txtRemark.BackColor = Color.LightGray
        End Select
    End Sub

    Private Sub CostCalculate()
        Dim dtTable As New DataTable
        Dim TimeFr As DateTime
        Dim TimeTo As DateTime
        Dim tmSpan As TimeSpan
        Dim hour As Integer
        Dim mins As Integer
        Dim secs As Integer
        Dim Cost As Double

        CheckTime = True
        Cost = 0

        TimeFr = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
               CStr(Format(dtpTimeFr.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)
        TimeTo = CStr(Format(dtpLogDate.Value, "MM-dd-yyyy")) & " " & _
                 CStr(Format(dtpTimeTo.Value, "MM-dd-yyyy HH:mm")).Substring(11, 5)

        tmSpan = TimeTo - TimeFr

        hour = tmSpan.Hours
        mins = tmSpan.Minutes
        secs = tmSpan.Seconds

        If hour < 0 Then
            CheckTime = False
        End If

        If conn.State = ConnectionState.Closed Then conn.Open()

        cmd.CommandText = "sp_Retrieve_Maintain_SalesPrice_Jasa_ByJasaID '" & txtProcessID.Text.Trim & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)

        If dtTable.Rows.Count = 0 Then
            txtCost.Text = 0
            StandardLabor = 0
            StandardOverhead = 0
            Exit Sub
        End If

        Cost = (dtTable.Rows(0).Item("Standard Labor") * hour) + (dtTable.Rows(0).Item("Standard Labor") * mins / 60) + _
                dtTable.Rows(0).Item("Standard Overhead")

        LaborCost = (dtTable.Rows(0).Item("Standard Labor") * hour) + (dtTable.Rows(0).Item("Standard Labor") * mins / 60)
        OverheadCost = dtTable.Rows(0).Item("Standard Overhead")

        StandardLabor = dtTable.Rows(0).Item("Standard Labor")
        StandardOverhead = dtTable.Rows(0).Item("Standard Overhead")
        txtCost.Text = FormatAngka(CDbl(Cost))

    End Sub

    Private Sub InsertJurnal()
        Dim dtTable As New DataTable
        Dim JurnalID As String
        Dim LastSerial As Integer

        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.CommandText = "EXEC sp_Retrieve_Journal_Hdr_ByRefNo '" & txtLogNo.Text.Trim & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)

        If dtTable.Rows.Count <> 0 Then
            cmd.CommandText = "DELETE FROM JournalItem WHERE JournalID = '" & dtTable.Rows(0).Item("JournalID") & "'"
            cmd.ExecuteNonQuery()
            JurnalID = dtTable.Rows(0).Item("JournalID")
        Else
            JurnalID = Generate_TranNo("Journal")
            LastSerial = CInt(Microsoft.VisualBasic.Right(JurnalID, 3))

            'Jurnal Header
            cmd.CommandText = "EXEC sp_Insert_Journal '" & JurnalID & "', '" & _
                        userlog.EmployeeID & "', '" & _
                        "Log Book', '" & _
                        "', '" & _
                        txtLogNo.Text & "', '" & _
                        "False', '" & _
                        "', '" & _
                        "False', '" & _
                        "', '" & _
                        userlog.UserName & "'"
            cmd.ExecuteNonQuery()
        End If

        If Not (StatusTrans = TransStatus.NewStatus Or StatusTrans = TransStatus.EditStatus) Then
            cmd.CommandText = "DELETE FROM Journal WHERE RefNo = '" & txtLogNo.Text & "'"
            cmd.ExecuteNonQuery()
            Exit Sub
        End If

        Select Case cbCategory.SelectedItem
            Case "Instalasi"
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "164', '" & _
                                    Replace(CStr(LaborCost), ",", ".") & "', '" & _
                                    "0', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "905', '" & _
                                    "0', '" & _
                                    Replace(CStr(LaborCost), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
            Case Else
                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                  "165', '" & _
                                  Replace(CStr(LaborCost), ",", ".") & "', '" & _
                                  "0', '" & _
                                  "False', '" & _
                                  userlog.UserName & "'"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                    "910', '" & _
                                    "0', '" & _
                                    Replace(CStr(LaborCost), ",", ".") & "', '" & _
                                    "False', '" & _
                                    userlog.UserName & "'"
                cmd.ExecuteNonQuery()
        End Select

        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                                  "166', '" & _
                                  Replace(CStr(OverheadCost), ",", ".") & "', '" & _
                                  "0', '" & _
                                  "False', '" & _
                                  userlog.UserName & "'"
        cmd.ExecuteNonQuery()

        cmd.CommandText = "EXEC sp_Insert_Journal_Item '" & JurnalID & "', '" & _
                            "906', '" & _
                            "0', '" & _
                            Replace(CStr(OverheadCost), ",", ".") & "', '" & _
                            "False', '" & _
                            userlog.UserName & "'"
        cmd.ExecuteNonQuery()


        If dtTable.Rows.Count = 0 Then
            UpdateSerial("Journal", GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
        End If
    End Sub

    Private Function ValidationInput() As Boolean
        Dim dr As DataRow

        If txtCost.Text.Trim = "" Then
            txtCost.Text = 0
        End If

        ValidationInput = True
        If dtpLogDate.ToString.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Log Date", MsgBoxStyle.Information, "Information")
            dtpLogDate.Focus()
            Exit Function
        End If

        If txtSPKNo.Text.Trim <> "" Then
            dr = dtSPK.Rows.Find(txtSPKNo.Text.Trim)
            If dr Is Nothing Then
                ValidationInput = False
                MsgBox("Invalid SPK No !", MsgBoxStyle.Information, "Information")
                txtSPKNo.Focus()
                Exit Function
            End If
        End If

        If txtEmployeeID.Text.Trim = "" Or txtProcessID.Text.Trim = "" Then
            ValidationInput = False
            MsgBox("Please select process on table by CLICK current row", MsgBoxStyle.Information, "Information")
            txtEmployeeID.Focus()
            Exit Function
        End If

        If cbCategory.SelectedItem = "" Then
            ValidationInput = False
            MsgBox("Please fill Category", MsgBoxStyle.Information, "Information")
            cbCategory.Focus()
            Exit Function
        End If

        If dtpTimeFr.Text.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Time From ", MsgBoxStyle.Information, "Information")
            dtpTimeFr.Focus()
            Exit Function
        End If

        If dtpTimeTo.Text.Trim = "" Then
            ValidationInput = False
            MsgBox("Please fill Time To", MsgBoxStyle.Information, "Information")
            dtpTimeTo.Focus()
            Exit Function
        End If

        If CheckTime = False Then
            ValidationInput = False
            MsgBox("Time From can't greater than Time To", MsgBoxStyle.Information, "Information")
            Exit Function
        End If

    End Function

    Private Sub GetTeknisiProcessBySPKNo()
        Dim dtTable As New DataTable
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmd.CommandText = "EXEC sp_Retreive_Trans_SPK_Dtl '" & txtSPKNo.Text.Trim & "'"
        DA.SelectCommand = cmd
        DA.Fill(dtTable)
        conn.Close()

        dgv_data.DataSource = dtTable

        If dtTable.Rows.Count <> 0 Then Exit Sub
        MsgBox("SPK No: " & txtSPKNo.Text.Trim & " doesn't has PROCESS")
    End Sub

#End Region

#Region "Event Handler"

    Private Sub ts_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Save.Click
        If StatusTrans = TransStatus.NewStatus OrElse StatusTrans = TransStatus.EditStatus Then
            If ValidationInput() = False Then
                Exit Sub
            End If

            Select Case StatusTrans
                Case TransStatus.NewStatus
                    Call CostCalculate()
                    Call InsertLogBook()
                Case TransStatus.EditStatus
                    Call CostCalculate()
                    Call UpdateLogBook()
            End Select

            StatusTrans = TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
        Else
            MessageBox.Show("Wrong Process")
            StatusTrans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            StatusTrans = GlobalVar.TransStatus.EditStatus
            Call SetToolTip()
            Call EnableDisableInput(True)
        End If
    End Sub

    Private Sub ts_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Delete.Click
        If StatusTrans = GlobalVar.TransStatus.NoStatus Then
            Call DeleteLogBook()
        End If
    End Sub

    Private Sub ts_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Cancel.Click
        If StatusTrans = GlobalVar.TransStatus.EditStatus Then
            StatusTrans = GlobalVar.TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
        ElseIf StatusTrans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub dtpTimeFr_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTimeFr.Leave
        Call CostCalculate()
    End Sub

    Private Sub dtpTimeTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTimeTo.LostFocus
        Call CostCalculate()
    End Sub

    Private Sub frmLogBook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim frmChild As New frmLogBookView
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormLogBookView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
    End Sub

    Private Sub frmLogBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckTime = True
        dtpTimeFr.ShowUpDown = True
        dtpTimeTo.ShowUpDown = True

        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        Call RetrieveSPK()

        Select Case txtLogNo.Text
            Case ""
                StatusTrans = GlobalVar.TransStatus.NewStatus
                Call EnableDisableInput(True)
                Call SetToolTip()
            Case Else
                StatusTrans = TransStatus.NoStatus
                Call SetToolTip()
                Call EnableDisableInput(False)
                Call RetrieveData()
                Call GetTeknisiProcessBySPKNo()
        End Select
    End Sub

    Private Sub txtSPKNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSPKNo.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("EXEC sp_Retrieve_Trans_SPK_ALL", "SPK No", "SPK Date", "Project No", "Project Name", "Remarks")

            If frmSearch.txtResult1.Text.Trim <> "" Then
                txtSPKNo.Text = frmSearch.txtResult1.Text.Trim
                txtProjectNo.Text = frmSearch.txtResult3.Text.Trim
                txtProjectName.Text = frmSearch.txtResult4.Text.Trim
                btn_search_Click(False, e)
            End If
           
        ElseIf e.KeyCode = Keys.Enter Then
            txtProjectNo.Clear()
            txtProjectName.Clear()
            If txtSPKNo.Text.Trim = "" Then
                MsgBox("Please fill SPK No", MsgBoxStyle.Information, "Information")
                txtSPKNo.Focus()
                Exit Sub
            End If

            Dim dtTable As New DataTable
            If conn.State = ConnectionState.Closed Then conn.Open()

            cmd.CommandText = "EXEC sp_Retrieve_Trans_SPK_ByKey '" & txtSPKNo.Text.Trim & "'"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)

            Select Case dtTable.Rows.Count
                Case 0
                    MsgBox("SPK No: " & txtProcessID.Text.Trim & " isn't exist in database", MsgBoxStyle.Information, "Information")
                Case Else
                    txtProjectNo.Text = dtTable.Rows(0).Item("Project No").ToString
                    txtProjectName.Text = dtTable.Rows(0).Item("Project Name").ToString
                    btn_search_Click(False, e)
            End Select
        End If
    End Sub

    Private Sub btn_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Call GetTeknisiProcessBySPKNo()
    End Sub

    Private Sub dgv_data_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_data.CellClick
        If dgv_data.Rows.Count = 0 Then Exit Sub
        txtEmployeeID.Text = dgv_data.Rows(dgv_data.CurrentCell.RowIndex).Cells(0).Value.ToString.Trim
        txtEmployeeName.Text = dgv_data.Rows(dgv_data.CurrentCell.RowIndex).Cells(1).Value.ToString.Trim
        txtProcessID.Text = dgv_data.Rows(dgv_data.CurrentCell.RowIndex).Cells(2).Value.ToString.Trim
        txtProcessName.Text = dgv_data.Rows(dgv_data.CurrentCell.RowIndex).Cells(3).Value.ToString.Trim

        Call CostCalculate()
    End Sub


#End Region
 
End Class