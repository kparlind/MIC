Imports System.Data.SqlClient
Imports MIS.GlobalVar

Public Class TransData
    Public Sub RetrieveCustomerByKey(ByRef dtData As DataTable, ByVal DPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_DPSales '" & DPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)

        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RetrieveSurveyHeaderByKey(ByRef dtData As DataTable, ByVal SurveyNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Hdr '" & SurveyNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveBPB_ByID(ByRef dtData As DataTable, ByVal BPBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_BPB_Hdr_ByID '" & BPBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveReportSPKForm(ByRef dtData As DataTable, ByVal SPKNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Report_SPKForm '" & SPKNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveBPBDetail_ByID(ByRef dtData As DataTable, ByVal BPBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_BPB_Dtl_ByBPBNo '" & BPBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveBPBDetail_ByID_ForKB(ByRef dtData As DataTable, ByVal BPBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_BPB_Dtl_ForKB '" & BPBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveStatusSurvey_ForView(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Survey_Hdr_Status"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_Projects_ByPHMNo(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Projects_ByPHMNo '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHProject_Hdr_forPHMarketing(ByRef dtData As DataTable, ByVal PHPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHProject_Hdr_forPHMarketing '" & PHPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHProject_Hdr_ByPHPNo(ByRef dtData As DataTable, ByVal PHPNo As String, ByVal Seq As Integer)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrive_Trans_PHProject_Hdr_byKey '" & PHPNo & "'," & Seq
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_KembaliBarang_Hdr_ByID_forGrid(ByRef dtData As DataTable, ByVal KBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_KembaliBarang_Dtl_byKBNo_forGrid '" & KBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_KembaliBarang_Hdr_ByID(ByRef dtData As DataTable, ByVal KBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_KembaliBarang_Hdr '" & KBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_KembaliBarang_Dtl_ByID(ByRef dtData As DataTable, ByVal KBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_KembaliBarang_Dtl_ByKBNo '" & KBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_SPK_ByID(ByRef dtData As DataTable, ByVal SPKNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retreive_Trans_SPK_Hdr '" & SPKNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_SPK_ByID_ProjectNotClosed(ByRef dtData As DataTable, ByVal SPKNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_SPK_Hdr_ForSearch_ByID '" & SPKNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_OrderFabrikasi_ByID_ProjectNotClosed(ByRef dtData As DataTable, ByVal OPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_OrderPabrikasi_forKembaliBarang_ByID '" & OPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_OrderFabrikasi_ByID(ByRef dtData As DataTable, ByVal OPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retreive_Trans_OrderPabrikasi '" & OPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub SaveJurnalHeader(ByRef cmd As SqlCommand, ByVal JurnalID As String, ByVal JurnalType As String, ByVal RemarksJurnal As String, ByVal RefNo As String, Optional ByVal isTranspost As Boolean = False, Optional ByVal isIncludeTax As Boolean = False, Optional ByVal JurnalIDTax As String = "", Optional ByVal PaymentRef As String = "")
        Dim query, queryParam As String

        Try
            query = "exec sp_Insert_Journal "
            queryParam = "'" & JurnalID & "', '" & userlog.EmployeeID & "', '" & JurnalType & "', '" & RemarksJurnal & "', '" & RefNo & "'," & _
                         "'" & IIf(isTranspost, "True", "False") & "', '" & PaymentRef & "', '" & IIf(isIncludeTax, "True", "False") & "'," & _
                         "'" & JurnalIDTax & "', '" & userlog.UserName & "'"
            cmd.CommandText = query & queryParam
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SaveJurnalDetail(ByRef cmd As SqlCommand, ByVal JurnalID As String, ByVal DRCR As String, ByVal AccNo As String, ByVal AccAmt As Double, Optional ByVal isIncludeTax As Boolean = False)
        Dim query, queryParam As String

        Try
            query = "exec sp_Insert_Journal_Item "
            queryParam = "'" & JurnalID & "', '" & AccNo & "', " & IIf(DRCR = "DR", AccAmt, 0) & ", " & IIf(DRCR = "CR", AccAmt, 0) & ", " & _
                         "'" & IIf(isIncludeTax, "True", "False") & "', '" & userlog.UserName & "'"
            cmd.CommandText = query & queryParam
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UpdateJurnalDetail(ByRef cmd As SqlCommand, ByVal TransNo As String, ByVal AccNo As String, ByVal DRCR As String, ByVal AccAmt As Double, Optional ByVal isIncludeTax As Boolean = False)
        Dim query, queryParam As String

        Try
            query = "exec sp_Update_Journal_Item "
            queryParam = "'" & TransNo & "', '" & AccNo & "', " & IIf(DRCR = "DR", AccAmt, 0) & ", " & IIf(DRCR = "CR", AccAmt, 0) & ", " & _
                         "'" & IIf(isIncludeTax, "True", "False") & "', '" & userlog.UserName & "'"
            cmd.CommandText = query & queryParam
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Retrieve_SisaQty_Project(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_SisaQty_Project '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_Trans_Closing_ByDate(ByRef dtData As DataTable, ByVal DateTrans As DateTime)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtParam As String = Format(DateTrans, "yyyyMMdd")

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Closing_byDate '" & dtParam & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PakaiBahan_ByID_fromInbox(ByRef dtData As DataTable, ByVal PBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PakaiBahan_Hdr_fromInbox '" & PBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PakaiBahan_ByID_fromPHM(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PakaiBahan_Hdr_forTrans '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PakaiBahan_ByID(ByRef dtData As DataTable, ByVal PBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PakaiBahan_Hdr '" & PBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PakaiBahan_ByID_forPB(ByRef dtData As DataTable, ByVal PBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PakaiBahan_Hdr_ByID '" & PBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHM_Hdr_forPB(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHM_Hdr_forPB '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrievePHPHdr_ByKey(ByRef dtData As DataTable, ByVal PHPNo As String, ByVal Seq As Integer)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrive_Trans_PHProject_Hdr_byKey '" & PHPNo & "', " & Seq
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrievePHMHdr_ByKey(ByRef dtData As DataTable, ByVal PHMNo As String, ByVal Seq As Integer)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrive_Trans_PHMarketing_Hdr_byKey '" & PHMNo & "', " & Seq
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHM_ItemDtl_forPB(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHM_ItemDtl_forPB '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PakaiBahan_Dtl(ByRef dtData As DataTable, ByVal PBNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PakaiBahan_Dtl_forGrid '" & PBNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_SisaQty_AmbilBahan_ByRefNo(ByRef dtData As DataTable, ByVal RefNo As String, ByVal ItemID As String, ByVal TransNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Sisa_BPB '" & RefNo & "', '" & ItemID & "', '" & TransNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Function Retrieve_WIPAmt_forPB(ByVal PHMNo As String, ByVal AccountID As String) As Double
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_WIP_Amt '" & AccountID & "','" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                With dtData.Rows(0)
                    Retrieve_WIPAmt_forPB = CDbl(.Item("Debit")) - CDbl(.Item("Credit"))
                End With
            Else
                Retrieve_WIPAmt_forPB = 0
            End If
        Catch ex As Exception
            Retrieve_WIPAmt_forPB = 0
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub Retrieve_SPK_ByProjectNo(ByRef dtData As DataTable, ByVal ProjectNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_SPK_Hdr_byProjectNo '" & ProjectNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_SPK_ByProjectNo(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_SPK_Hdr_byProjectNo"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_Report_RekapProject(ByRef dtData As DataTable, ByVal BeginDate As String, ByVal EndDate As String, ByVal CustID As String, ByVal isEfficient As Integer, ByVal isComplete As Integer)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Report_RekapProject '" & BeginDate & "','" & EndDate & "','" & CustID & "'," & isEfficient & "," & isComplete
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_BahanTerpasang_ForView(ByRef dtData As DataTable, ByVal BeginDate As Date, ByVal EndDate As Date, ByVal TransNo As String, ByVal PHMNo As String, ByVal ProjectName As String, ByVal CustName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim TanggalAwal, TanggalAkhir As String

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            TanggalAwal = Format(BeginDate, "yyyyMMdd")
            TanggalAkhir = Format(EndDate, "yyyyMMdd")

            Cmd.CommandText = "exec sp_Retrieve_View_BahanTerpasang '" & TanggalAwal & "','" & TanggalAkhir & "','" & TransNo & "','" & PHMNo & "','" & ProjectName & "','" & CustName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_Projects_ByID_forOptionReport(ByRef dtData As DataTable, ByVal ProjectNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Projects_List_forOptionReport_ByID '" & ProjectNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_Projects_ByID(ByRef dtData As DataTable, ByVal ProjectNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_Projects_ByID '" & ProjectNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ReportRekapPemakaianBahanPerProject(ByRef dtData As DataTable, ByVal ProjectNo As String, ByVal BeginDate As Date, ByVal EndDate As Date)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Report_RekapPemakaianBahanPerProject '" & IIf(ProjectNo.Trim = String.Empty, "ALL", ProjectNo.Trim) & "', '" & Format(BeginDate, "yyyyMMdd") & "', '" & Format(EndDate, "yyyyMMdd") & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveSeq_TransPHMarketingHdr(ByRef dtData As DataTable, ByVal PHMNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHMarketingHDr_Seq '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveSeq_TransPHProjectHdr(ByRef dtData As DataTable, ByVal PHPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHProjectHdr_Seq '" & PHPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Function RetrieveMaxSeq_TransPHMarketingHdr(ByVal PHMNo As String) As Integer
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHMarketingHDr_MaxSeq '" & PHMNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtTemp)
            If dtTemp.Rows.Count <> 0 Then
                Return CInt(dtTemp.Rows(0).Item("Seq"))
            Else
                Return 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Function RetrieveMaxSeq_TransPHProjectHdr(ByVal PHPNo As String) As Integer
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_PHProjectHdr_MaxSeq '" & PHPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtTemp)
            If dtTemp.Rows.Count <> 0 Then
                Return CInt(dtTemp.Rows(0).Item("Seq"))
            Else
                Return 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub Retrieve_OrderMaintenance_ByID(ByRef dtData As DataTable, ByVal TransID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Trans_OrderMaintance_ByID '" & TransID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_FormPenawaranMarketing_Hdr(ByRef dtData As DataTable, ByVal PHMNo As String, ByVal Seq As Integer)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Report_FormPenawaranMarketingHdr '" & PHMNo & "'," & Seq
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHProject_ItemDtl_forPHMarketing(ByRef dtData As DataTable, ByVal PHPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_Itemfor_PHMarketing  '" & PHPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PHProject_JasaOngkos_forPHMarketing(ByRef dtData As DataTable, ByVal PHPNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrive_Trans_PHProject_JasaOngkosfor_PHMarketing  '" & PHPNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ListAccountWIP_ByProject_ForPB(ByRef dtData As DataTable, ByVal ProjectNo As String, ByVal MappingName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_AccountForPB_WIP '" & ProjectNo & "','" & MappingName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ListAccountDP_ByProject_ForPB(ByRef dtData As DataTable, ByVal ProjectNo As String, ByVal MappingName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_AccountForPB_DP '" & ProjectNo & "', '" & MappingName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ListAccountDP_ByProject_ForPB_ByAccountID(ByRef dtData As DataTable, ByVal ProjectNo As String, ByVal AccountID As String, ByVal MappingName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_AccountForPB_DP_ByAccountID '" & ProjectNo & "', '" & AccountID & "','" & MappingName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ListAccountWIP_ByProject_ForPB_ByAccountID(ByRef dtData As DataTable, ByVal ProjectNo As String, ByVal MappingName As String, ByVal sisiReference As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_AccountForPB_WIP_ByAccID '" & ProjectNo & "', '" & MappingName & "', '" & sisiReference & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ReturToko_Hdr_ForLoad(ByRef dtData As DataTable, ByVal ReturNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_Trans_ReturToko_Hdr_ForLoad '" & ReturNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_ReturToko_Dtl_ForGrid(ByRef dtData As DataTable, ByVal ReturNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_Trans_ReturToko_Dtl_forGrid '" & ReturNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveJournalID_ByTransNo(ByRef JournalID As String, ByVal TransID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_JournalID_ByTransNo '" & TransID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                JournalID = dtData.Rows(0).Item("JournalID").ToString.Trim
            Else
                JournalID = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_PenjualanToko_ByID(ByRef dtData As DataTable, ByVal PTNo As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retreive_Trans_PenjualanToko_Hdr '" & PTNo & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub Retrieve_SisaQty_ForReturToko(ByRef dtData As DataTable, ByVal ReturNo As String, ByVal ItemID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "EXEC sp_Retrieve_SisaQty_ForReturToko '" & ReturNo & "','" & ItemID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
End Class
