'(21 Des 2012) Modifikasi update to inbox. Jika statusnya <> "1"
'(25 Des 2012) Modifikasi getaverateprice, tambah kondisi jika connection tidak di dapat
'(27 Des 2012) Modifikasi getaverateprice, tambah kondisi jika yang dibutuhkan adalah Sales_Price
'(08 Jan 2013) Modifikasi update inbox, susunan if clause.

Imports System.Data
Imports System.Data.SqlClient
Imports MIS.GlobalVar

Module mdlCommon

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable

    Public userlog As New UserLogin
    'Public UserID As String = "ifebrian"
    Public CurrForm As String = ""
    Public id_status As String
    Public LoadFromView As Boolean = False
    Public ConnectStr As String
    Public BeginDate As DateTime
    Public EndDate As DateTime
    Public ReportType As String
    Public IncludeRetur As String 'new add
    Public FakturType As String
    Public TipeWaktu As String
    Public TipeAnalisa As String
    Public TipePenjualan As String

    Public Sub CallandGetSearchData(ByVal Query As String, ByVal f1 As String, Optional ByVal f2 As String = "", Optional ByVal f3 As String = "", Optional ByVal f4 As String = "", Optional ByVal f5 As String = "", Optional ByVal f6 As String = "")
        Call frmSearch.InitFindData("Find Item", Query)
        If f1.Trim <> "" Then
            Call frmSearch.AddFindColumn(1, f1, f1, DataType.TypeString, 100)
        End If
        If f2.Trim <> "" Then
            Call frmSearch.AddFindColumn(2, f2, f2, DataType.TypeString, 300)
        End If
        If f3.Trim <> "" Then
            Call frmSearch.AddFindColumn(3, f3, f3, DataType.TypeString, 150)
        End If
        If f4.Trim <> "" Then
            Call frmSearch.AddFindColumn(4, f4, f4, DataType.TypeString, 150)
        End If
        If f5.Trim <> "" Then
            Call frmSearch.AddFindColumn(5, f5, f5, DataType.TypeString, 150)
        End If
        If f6.Trim <> "" Then
            Call frmSearch.AddFindColumn(6, f6, f6, DataType.TypeString, 150)
        End If
        frmSearch.ShowDialog()

        'CallandGetSearchData("Select Item_id,Item_Desc,UoM,Sales_Price as Harga f", "Item_ID", "Item_Desc", "UoM", "Sales_Price")
    End Sub

    Public Function enterNumeric(ByVal KeyCodeAsc As Integer) As Boolean
        If (KeyCodeAsc >= Asc("0") AndAlso KeyCodeAsc <= Asc("9")) OrElse KeyCodeAsc = Asc("-") OrElse KeyCodeAsc = Asc(".") OrElse KeyCodeAsc = 8 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FormatAngka(ByVal Angka As Double, Optional ByVal DecimalDiBelakangNol As Integer = 2) As String
        Dim formatString As String
        Dim i As Integer

        formatString = "#,##0"
        If DecimalDiBelakangNol <> 0 Then
            formatString &= "."
            If DecimalDiBelakangNol <> 1 Then
                For i = 1 To DecimalDiBelakangNol - 1
                    formatString &= "#"
                Next
            End If
            formatString &= "0"
        End If

        FormatAngka = Format(Angka, formatString)
    End Function

    Function GetCurrDate() As Date
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        dt.Clear()
        'Get Date (day,month and year) from server
        Cmd.CommandText = "EXEC GetCurrDate"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        GetCurrDate = dt.Rows(0).Item("Date")
    End Function

    Function GetCurrMonth() As Integer
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        dt.Clear()
        'Get month dan year from server
        Cmd.CommandText = "EXEC GetCurrMonthandYear"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        GetCurrMonth = dt.Rows(0).Item("Bulan")
    End Function

    Function GetCurrYear() As Integer
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        dt.Clear()
        'Get month dan year from server
        Cmd.CommandText = "EXEC GetCurrMonthandYear"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        GetCurrYear = dt.Rows(0).Item("tahun")
    End Function



    Function Generate_TranNo(ByVal FormName As String) As String
        Dim angka As Integer
        Dim Urut, thn, bln As String

        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        dt.Clear()
        'Get month dan year from server
        thn = Microsoft.VisualBasic.Right(GetCurrYear(), 2)
        bln = GetCurrMonth()

        dt.Clear()

        Cmd.CommandText = "EXEC sp_Retreive_Serial '" & FormName & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count > 0 Then
            If bln <> dt.Rows(0).Item("CurrMonth") And thn <> dt.Rows(0).Item("CurrYear") Then
                angka = 1 'Reset
            Else
                angka = dt.Rows(0).Item("CurrSerial") + 1
            End If

            If angka < 10 Then
                Urut = "00" + CStr(angka)
            ElseIf angka >= 10 And angka <= 99 Then
                Urut = "0" + CStr(angka)
            Else
                Urut = CStr(angka)
            End If

            If bln < 10 Then
                bln = "0" + bln
            End If

            If dt.Rows(0).Item("Type_Serial").ToString = "Master" Then
                Generate_TranNo = dt.Rows(0).Item("Serial_Prefix") + Urut
            Else
                Generate_TranNo = dt.Rows(0).Item("Serial_Prefix") + thn + bln + Urut
            End If
        Else
            Generate_TranNo = "<empty>"
            MessageBox.Show("This Form Serial has not maintain on Master data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Conn.Close()

    End Function

    Function Generate_MasterNo(ByVal FormName As String) As String
        Dim angka As Integer
        Dim Urut, thn, bln As String

        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        dt.Clear()
        'Get month dan year from server
        thn = Microsoft.VisualBasic.Right(GetCurrYear(), 2)
        bln = GetCurrMonth()

        dt.Clear()

        Cmd.CommandText = "EXEC sp_Retreive_Serial '" & FormName & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count > 0 Then

            angka = dt.Rows(0).Item("CurrSerial") + 1


            If angka < 10 Then
                Urut = "00" + CStr(angka)
            ElseIf angka >= 10 And angka <= 99 Then
                Urut = "0" + CStr(angka)
            Else
                Urut = CStr(angka)
            End If

            If dt.Rows(0).Item("Type_Serial").ToString = "Master" Then
                Generate_MasterNo = dt.Rows(0).Item("Serial_Prefix") + Urut
            ElseIf dt.Rows(0).Item("Type_Serial").ToString = "MasterEmployee" Then
                Generate_MasterNo = thn + bln + Urut
            Else
                Generate_MasterNo = dt.Rows(0).Item("Serial_Prefix") + thn + bln + Urut
            End If
        Else
            Generate_MasterNo = "<empty>"
            MessageBox.Show("This Form Serial has not maintain on Master data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Conn.Close()

    End Function

    Function Generate_Period() As String
        Dim bulan As String
        Dim tahun As String

        bulan = GetCurrMonth()
        tahun = GetCurrYear()
        If bulan < 10 Then
            bulan = "0" + bulan
        End If

        Generate_Period = tahun + bulan
    End Function

    Function Generate_NextPeriod() As String
        Dim bulan As String
        Dim tahun As String

        bulan = GetCurrMonth() + 1
        tahun = GetCurrYear()
        If bulan < 10 Then
            bulan = "0" + bulan
        End If

        Generate_NextPeriod = tahun + bulan
    End Function

    Function GetApprover() As String
        Dim dt_approver As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC GetApprover '" & userlog.UserName & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_approver)

        If dt_approver.Rows.Count > 0 Then
            GetApprover = dt_approver.Rows(0).Item("Approver").ToString
        Else
            GetApprover = ""
        End If

        Conn.Close()
    End Function

    'Remarked by kparlind--- karna skrg mengunakan GetAprover
    Function GetNextPIC(ByVal StatusID As String) As String
        Dim dt_status As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC GetNextPIC_Flow '" & StatusID & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_status)

        GetNextPIC = dt_status.Rows(0).Item("UserName").ToString.Trim
        Conn.Close()
    End Function

    Function GetDocCreator(ByVal TransNo As String) As String
        Dim dt As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        Cmd.CommandText = "Select id_from from INBOX where trans_No = '" & TransNo & "' and seq = 1"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        If dt.Rows.Count > 0 Then
            GetDocCreator = dt.Rows(0).Item("id_From").ToString.Trim
        Else
            GetDocCreator = ""
        End If
    End Function

    Public Sub UpdateSerial(ByVal FormName As String, ByVal CurrMonth As Integer, ByVal CurrYear As Integer, ByVal LastSerial As Integer, ByVal userlogin As String)
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC Sp_Update_SerialNumber '" & FormName & "'," & CurrMonth & "," & CurrYear & "," & LastSerial & ",'" & userlogin & "'"
        Cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub

    Public Sub Insert_Trans_History(ByVal TransNo As String, ByVal ObjectId As String, ByVal ProcessDtl As String)
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Insert_History_Trans '" & TransNo & "','" & ObjectId & "','" & ProcessDtl & "','" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub

    Public Sub Insert_StokMovement(ByVal ItemId As String, ByVal Warehouse_ID As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from trans_Stock_Movement where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        'If String.IsNullOrEmpty(dt.Rows(0).Item("MaxSeq")) = True Then
        '    maxSeq = 0
        'Else
        maxSeq = dt.Rows(0).Item("MaxSeq")
        'End If
        maxSeq += 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement '" & Generate_Period() & "','" & Warehouse_ID & "','" & ItemId & "','" & TransNo_Ref & "'," & maxSeq & ",'" & Sts_Proses & "'," & Qty & ",'" & Remarks & "','" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub

    'Public Sub Insert_StokMovement_Nextmonth(ByVal period As String, ByVal ItemId As String, ByVal Warehouse_ID As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
    '    Dim dt As New DataTable
    '    Dim maxSeq As Integer

    '    If Conn.State = ConnectionState.Closed Then
    '        Conn.ConnectionString = ConnectStr
    '        Cmd.Connection = Conn
    '        Cmd.CommandType = CommandType.Text
    '        Conn.Open()
    '    End If

    '    maxSeq = 1

    '    Cmd.CommandText = "EXEC sp_Insert_StokMovement '" & period & "','" & Warehouse_ID & "','" & ItemId & "','" & TransNo_Ref & "'," & GetMaxSeq(period, Warehouse_ID, ItemId) & ",'" & Sts_Proses & "'," & Qty & ",'" & userlog.UserName & "'"
    '    Cmd.ExecuteNonQuery()
    '    Conn.Close()
    'End Sub

    Public Sub Insert_Master_Stock_BB(ByVal WH_ID As String, ByVal period As String, ByVal ItemId As String, ByVal Qty As Integer)
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "exec sp_Insert_Master_StockBB '" & WH_ID & "','" & period & "', '" & ItemId & "', '" _
                & Replace(Qty, ",", ".") & "' ,'" & Replace(GetAveragePrice(WH_ID, ItemId), ",", ".") & "' ,'" _
                & userlog.UserName & "',  'Y'"
        Cmd.ExecuteNonQuery()
        Conn.Close()
    End Sub

    'Modified by ifebrian, adding ability to retrieve salesprice
    Function GetAveragePrice(ByVal Warehouse As String, ByVal item As String, Optional ByVal retrievePurchasePrice As Boolean = True) As Decimal
        Dim dt As New DataTable
        If Conn.ConnectionString = String.Empty Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "exec sp_Retrieve_Maintain_SalesPrice_Item_ByItemID '" & Warehouse & "','" & item & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count = 0 Then
            GetAveragePrice = 0
        Else
            If retrievePurchasePrice Then
                GetAveragePrice = dt.Rows(0).Item("Purchase_Price")
            Else
                GetAveragePrice = dt.Rows(0).Item("Sales_Price")
            End If
        End If
    End Function


    Function GetMaxSeq(ByVal period As String, ByVal wh As String, ByVal itemID As String) As Integer
        Dim dt As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from Trans_Stock_Movement where Period = '" & period & _
                          "' and Warehouse_ID = '" & wh & "' and item_id = '" & itemID & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count = 0 Then
            GetMaxSeq = 1
        Else
            GetMaxSeq = dt.Rows(0).Item("MaxSeq") + 1
        End If
    End Function

    Public Sub Insert_StokMovement_Toko(ByVal ItemId As String, ByVal TransNo_Ref As String, ByVal Sts_Proses As String, ByVal Qty As Integer, ByVal Remarks As String, Optional ByVal masukbrg As Boolean = True)
        Dim dt As New DataTable
        Dim maxSeq As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select isnull(Max(seq),0) as MaxSeq from Trans_Stock_Movement_toko where Period = '" & Generate_Period() & "' and TransNo_Ref = '" & TransNo_Ref & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)
        'If String.IsNullOrEmpty(dt.Rows(0).Item("MaxSeq")) = True Then
        '    maxSeq = 0
        'Else
        maxSeq = dt.Rows(0).Item("MaxSeq")
        'End If
        maxSeq += 1

        Cmd.CommandText = "EXEC sp_Insert_StokMovement_Toko '" & Generate_Period() & "','" & ItemId & "','" & TransNo_Ref & "'," & maxSeq & ",'" & Sts_Proses & "'," & Qty & ",'" & userlog.UserName & "'"
        Cmd.ExecuteNonQuery()
        'Conn.Close()
    End Sub

    Public Sub InserttoInbox(ByVal TransNo As String, ByVal idFrom As String, ByVal idTo As String, ByVal AccRight As String, ByVal Outs As String, ByVal statusProses As String)
        Dim dt_Inbox As New DataTable
        Dim dt_Approval As New DataTable
        Dim subject As String
        Dim seqnum As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        'Cek dulu apakah sudah ada record untuk TransNo saat ini
        Try
            Cmd.CommandText = "EXEC sp_Retreive_INBOX_ByTransNo '" & TransNo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Inbox)

            If dt_Inbox.Rows.Count = 0 Then
                seqnum = 1
            Else
                seqnum = dt_Inbox.Rows.Count + 1
            End If

            'JIka belum ada, Seq num nya diset jadi 0
            subject = "Document " & TransNo & " sudah disubmit. Silahkan Double Click untuk mengakses nya"
            Cmd.CommandText = "EXEC sp_Insert_Trans_Inbox '" & TransNo & "','" & idFrom & "','" & idTo & "'," & seqnum & ",'" & subject & "','" & AccRight & "','" & Outs & "','" & statusProses & "','" & userlog.UserName & "'"
            Cmd.ExecuteNonQuery()
            'Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub UpdatetoInbox(ByVal TransNo As String, ByVal status As String, ByVal userUpdate As String, ByVal Type As String)
        Dim dt_Inbox As New DataTable
        Dim dt_Approval As New DataTable
        Dim seqnum As Integer

        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If
        'Cek dulu apakah sudah ada record untuk TransNo saat ini
        Try
            'JIka belum ada, Seq num nya diset jadi 1
            'TYpe disini digunakan untuk membedakan INBOX si pembuat document atau PIC yg skrg bejalan
            If Type = "2" Then 'Jika di reject dan Outstanding nya kembali ke Creator 
                seqnum = 1 'ini digunakan utk Update INBOX utk si pembuat document / Creator
                Cmd.CommandText = "EXEC sp_Update_Trans_Inbox '" & TransNo & "'," & seqnum & ",'R','N','" & status & "','" & userUpdate & "'"
            ElseIf Type = "3" Then
                Cmd.CommandText = "EXEC sp_Retreive_INBOX_ByTransNo '" & TransNo & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_Inbox)

                If dt_Inbox.Rows.Count <> 0 Then
                    seqnum = dt_Inbox.Rows.Count
                Else
                    seqnum = 1
                End If

                Cmd.CommandText = "EXEC sp_Update_Trans_Inbox '" & TransNo & "'," & seqnum & ",'R','N','" & dt_Inbox.Rows(seqnum - 1).Item("Status_ID") & "','" & userUpdate & "'"
            ElseIf Type = "4" Then
                Cmd.CommandText = "EXEC sp_Retreive_INBOX_ByTransNo '" & TransNo & "'"
                DA.SelectCommand = Cmd
                DA.Fill(dt_Inbox)
                seqnum = dt_Inbox.Rows.Count
                Cmd.CommandText = "EXEC sp_Update_Trans_Inbox '" & TransNo & "'," & seqnum & ",'R','N','" & dt_Inbox.Rows(seqnum - 1).Item("Status_ID") & "','" & dt_Inbox.Rows(seqnum - 1).Item("Id_To") & "'"
            ElseIf Type <> "1" Then
                Dim StatusID As String

                Cmd.CommandText = "EXEC sp_Retreive_INBOX '','','" & userUpdate & "','" & TransNo & "','" & "','',''"
                DA.SelectCommand = Cmd
                DA.Fill(dt_Inbox)

                If dt_Inbox.Rows.Count <> 0 Then
                    seqnum = dt_Inbox.Rows(0).Item("seq")
                    StatusID = dt_Inbox.Rows(0).Item("Status_ID")
                Else
                    seqnum = 1
                    StatusID = status
                End If
                Cmd.CommandText = "EXEC sp_Update_Trans_Inbox '" & TransNo & "'," & seqnum & ",'R','N','" & StatusID & "','" & userUpdate & "'"
            Else
                seqnum = 1 'ini digunakan utk Update INBOX utk si pembuat document / Creator
                Cmd.CommandText = "EXEC sp_Update_Trans_Inbox '" & TransNo & "'," & seqnum & ",'R','N','" & status & "','" & userUpdate & "'"
            End If
            Cmd.ExecuteNonQuery()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Function GetStatus(ByVal status_ID As String) As String
        Dim dt_status As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_Retrieve_Master_Status '" & status_ID & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_status)

        GetStatus = dt_status.Rows(0).Item("Status_Name").ToString.Trim
        Conn.Close()
    End Function

    Function GetStatusID_byStatusName(ByVal status_Name As String) As String
        Dim dt_status As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_RetreiveStatus_byStatusName '" & status_Name & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_status)

        GetStatusID_byStatusName = dt_status.Rows(0).Item("Status_ID").ToString.Trim
        Conn.Close()
    End Function

    Function CheckAuthorisasi(ByVal TransNo As String, ByVal UserAccess As String) As Boolean
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from INBOX where Trans_No = '" & TransNo & "' and id_To = '" & UserAccess & "' order by seq desc"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count = 0 Then
            CheckAuthorisasi = False
        Else
            If dt.Rows(0).Item("Access_Right") = "R" And dt.Rows(0).Item("Outstanding") = "N" Then
                CheckAuthorisasi = False
            Else
                CheckAuthorisasi = True
            End If
        End If
    End Function

    Function GetMaintainPrice(ByVal PriceType As String, ByVal ID As String, ByVal Type_Price As String) As Decimal
        Dim dt As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "sp_Retreive_MaintainPrice_ByKey '" & PriceType & "','" & ID & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        If dt.Rows.Count = 0 Then
            GetMaintainPrice = 0
        Else
            GetMaintainPrice = dt.Rows(0).Item(Type_Price)
        End If
    End Function

    Function CheckStatusPeriodClosing(ByVal Period As String, ByVal Today As String) As Boolean
        Dim dt_period As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        'Cmd.CommandText = "Select * from Trans_Closing where Period = '" & Period & "' and start_date <= '" & Today & "' and end_date >= '" & Today & "'"
        Cmd.CommandText = "Select * from Trans_Closing where Period = '" & Period & "' and Status_ID = 'CLOP'
        DA.SelectCommand = Cmd
        DA.Fill(dt_period)

        CheckStatusPeriodClosing = dt_period.Rows.Count > 0

    End Function

    Function GetOpeningPeriod(ByVal today As String) As String
        Dim dt_period As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from Trans_Closing where start_date <= '" & today & "' and end_date >= '" & today & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_period)

        If dt_period.Rows.Count > 0 Then
            GetOpeningPeriod = dt_period.Rows(0).Item("Period").ToString.Trim
        Else
            GetOpeningPeriod = ""
            'MessageBox.Show("There is no Open Period. Please call Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If

    End Function

    Function GetOpeningPeriod_ByStatus() As String
        Dim dt_period As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.ConnectionString = ConnectStr
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Conn.Open()
        End If

        Cmd.CommandText = "Select * from Trans_Closing where Status_ID = 'CLOP'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_period)

        If dt_period.Rows.Count > 0 Then
            GetOpeningPeriod_ByStatus = dt_period.Rows(0).Item("Period").ToString.Trim
        Else
            GetOpeningPeriod_ByStatus = ""
            'MessageBox.Show("There is no Open Period. Please call Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If

    End Function

    'Public Sub SetAccess(ByRef FormObject As Object, ByVal AccessID As String, ByVal MenuFormName As String)
    '    Dim dtData As New DataTable
    '    Dim i As Integer
    '    Dim MD As New MasterData

    '    If userlog.AccessID <> Role.SuperAdmin Then
    '        'Init
    '        FormObject.ts_New.visible = False
    '        FormObject.ts_Edit.Visible = False
    '        FormObject.ts_Save.Visible = False
    '        FormObject.ts_Cancel.Visible = False
    '        FormObject.ts_Delete.Visible = False
    '        FormObject.ts_Approve.Visible = False
    '        FormObject.ts_Reject.Visible = False

    '        Try
    '            FormObject.btnprint.visible = False
    '        Catch ex As Exception
    '        End Try

    '        'Retrieve access from database
    '        MD.getAccessFunctionForForm(dtData, AccessID, MenuFormName)
    '        If dtData.Rows.Count <> 0 Then
    '            For i = 0 To dtData.Rows.Count - 1
    '                Select Case dtData.Rows(i).Item(0).ToString.Trim
    '                    Case FF.NewFunction
    '                        FormObject.ts_New.visible = True
    '                        FormObject.ts_save.visible = True
    '                        FormObject.ts_cancel.visible = True
    '                    Case FF.EditFunction
    '                        FormObject.ts_edit.visible = True
    '                        FormObject.ts_approve.visible = True 'Added by Kparlind 28-desc-2012
    '                        FormObject.ts_reject.visible = True 'Added by Kparlind 28-desc-2012
    '                        FormObject.ts_save.visible = True
    '                        FormObject.ts_cancel.visible = True
    '                    Case FF.DeleteFunction
    '                        FormObject.ts_delete.visible = True
    '                    Case FF.PrintFunction
    '                        Try
    '                            FormObject.ts_print.visible = False
    '                        Catch ex As Exception
    '                        End Try
    '                End Select
    '            Next
    '        End If
    '    End If
    'End Sub

    Public Sub SetAccess(ByRef FormObject As Object, ByVal AccessID As String, ByVal MenuFormName As String, Optional ByRef btnNew As ToolStripButton = Nothing, Optional ByRef btnEdit As ToolStripButton = Nothing, Optional ByRef btnDelete As ToolStripButton = Nothing, Optional ByRef btnSave As ToolStripButton = Nothing, Optional ByRef btncancel As ToolStripButton = Nothing, Optional ByRef btnPrint As ToolStripButton = Nothing, Optional ByRef btnApprove As ToolStripButton = Nothing, Optional ByRef btnReject As ToolStripButton = Nothing, Optional ByRef btnConfirm As ToolStripButton = Nothing, Optional ByRef btnGenerateMOU As ToolStripButton = Nothing, Optional ByRef btnGenerateProject As ToolStripButton = Nothing)
        Dim dtData As New DataTable
        Dim i As Integer
        Dim MD As New MasterData
        Dim ObjectID As String = String.Empty

        If userlog.AccessID <> Role.SuperAdmin Then
            'Init
            'FormObject.btnNew.visible = False
            'FormObject.btnEdit.Visible = False
            'FormObject.btnSave.Visible = False
            'FormObject.btnCancel.Visible = False
            'FormObject.btnDelete.Visible = False
            If Not btnNew Is Nothing Then
                btnNew.Visible = False
            End If
            If Not btnEdit Is Nothing Then
                btnEdit.Visible = False
            End If
            If Not btnDelete Is Nothing Then
                btnDelete.Visible = False
            End If
            If Not btnSave Is Nothing Then
                btnSave.Visible = False
            End If
            If Not btncancel Is Nothing Then
                btncancel.Visible = False
            End If
            If Not btnPrint Is Nothing Then
                btnPrint.Visible = False
            End If
            If Not btnApprove Is Nothing Then
                btnApprove.Visible = False
            End If
            If Not btnReject Is Nothing Then
                btnReject.Visible = False
            End If
            If Not btnGenerateMOU Is Nothing Then
                btnGenerateMOU.Visible = False
            End If
            If Not btnGenerateProject Is Nothing Then
                btnGenerateProject.Visible = False
            End If
            If Not btnConfirm Is Nothing Then
                btnConfirm.Visible = False
            End If



            'Try
            '    FormObject.btnprint.visible = False
            'Catch ex As Exception
            'End Try

            'Retrieve access from database
            MD.RetrieveObjectByFormName(ObjectID, MenuFormName)
            MD.getAccessFunctionForForm(dtData, AccessID, ObjectID)
            If dtData.Rows.Count <> 0 Then
                For i = 0 To dtData.Rows.Count - 1
                    Select Case dtData.Rows(i).Item(0).ToString.Trim
                        Case FF.NewFunction
                            'FormObject.btnNew.visible = True
                            'FormObject.btnsave.visible = True
                            'FormObject.btncancel.visible = True
                            If Not btnNew Is Nothing Then
                                btnNew.Visible = True
                            End If
                            If Not btnSave Is Nothing Then
                                btnSave.Visible = True
                            End If
                            If Not btncancel Is Nothing Then
                                btncancel.Visible = True
                            End If
                        Case FF.EditFunction
                            'FormObject.btnedit.visible = True
                            'FormObject.btnsave.visible = True
                            'FormObject.btncancel.visible = True
                            If Not btnEdit Is Nothing Then
                                btnEdit.Visible = True
                            End If
                            If Not btnSave Is Nothing Then
                                btnSave.Visible = True
                            End If
                            If Not btncancel Is Nothing Then
                                btncancel.Visible = True
                            End If
                            If Not btnApprove Is Nothing Then
                                btnApprove.Visible = True
                            End If
                            If Not btnReject Is Nothing Then
                                btnReject.Visible = True
                            End If                        
                            If Not btnConfirm Is Nothing Then
                                btnConfirm.Visible = True
                            End If
                            If Not btnGenerateMOU Is Nothing Then
                                btnGenerateMOU.Visible = True
                            End If
                            If Not btnGenerateProject Is Nothing Then
                                btnGenerateProject.Visible = True
                            End If
                        Case FF.DeleteFunction
                            'FormObject.btndelete.visible = True
                            If Not btnDelete Is Nothing Then
                                btnDelete.Visible = True
                            End If
                            If Not btnSave Is Nothing Then
                                btnSave.Visible = True
                            End If
                            If Not btncancel Is Nothing Then
                                btncancel.Visible = True
                            End If
                        Case FF.PrintFunction
                            'Try
                            'FormObject.btnprint.visible = False
                            'Catch ex As Exception
                            'End Try
                            If Not btnPrint Is Nothing Then
                                btnPrint.Visible = True
                            End If
                        Case FF.SaveOrCancelFunction
                            If Not btnSave Is Nothing Then
                                btnSave.Visible = True
                            End If
                            If Not btncancel Is Nothing Then
                                btncancel.Visible = True
                            End If
                        Case FF.ApproveOrRejectFunction
                            If Not btnApprove Is Nothing Then
                                btnApprove.Visible = True
                            End If
                            If Not btnReject Is Nothing Then
                                btnReject.Visible = True
                            End If
                        Case FF.ConfirmFunction
                            If Not btnConfirm Is Nothing Then
                                btnConfirm.Visible = True
                            End If
                        Case FF.GenerateMOUFunction
                            If Not btnGenerateMOU Is Nothing Then
                                btnGenerateMOU.Visible = True
                            End If
                        Case FF.GenerateProjectFunction
                            If Not btnGenerateProject Is Nothing Then
                                btnGenerateProject.Visible = True
                            End If
                    End Select
                Next
            End If
        End If
    End Sub

    Public Sub SetAccess_Master(ByRef FormObject As Object, ByVal AccessID As String, ByVal MenuFormName As String)
        Dim dtData As New DataTable
        Dim i As Integer
        Dim MD As New MasterData

        If userlog.AccessID <> Role.SuperAdmin Then
            'Init
            FormObject.btnNew.visible = False
            FormObject.btnEdit.Visible = False
            FormObject.btnSave.Visible = False
            FormObject.btnCancel.Visible = False
            FormObject.btnDelete.Visible = False

            Try
                FormObject.btnprint.visible = False
            Catch ex As Exception
            End Try

            'Retrieve access from database
            MD.getAccessFunctionForForm(dtData, AccessID, MenuFormName)
            If dtData.Rows.Count <> 0 Then
                For i = 0 To dtData.Rows.Count - 1
                    Select Case dtData.Rows(i).Item(0).ToString.Trim
                        Case FF.NewFunction
                            FormObject.btnNew.visible = True
                            FormObject.btnsave.visible = True
                            FormObject.btncancel.visible = True
                        Case FF.EditFunction
                            FormObject.btnedit.visible = True
                            FormObject.btnsave.visible = True
                            FormObject.btncancel.visible = True
                        Case FF.DeleteFunction
                            FormObject.btndelete.visible = True
                        Case FF.PrintFunction
                            Try
                                FormObject.btnprint.visible = False
                            Catch ex As Exception
                            End Try
                    End Select
                Next
            End If
        End If
    End Sub

    Public Function Terbilang(ByVal nilai As Long) As String
        Dim bilangan As String() = {"", "satu", "dua", "tiga", "empat", "lima", _
        "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}

        If nilai < 12 Then
            Return " " & bilangan(nilai)
        ElseIf nilai < 20 Then
            Return Terbilang(nilai - 10) & " belas"
        ElseIf nilai < 100 Then
            Return (Terbilang(CInt((nilai \ 10))) & " puluh") + Terbilang(nilai Mod 10)
        ElseIf nilai < 200 Then
            Return " seratus" & Terbilang(nilai - 100)
        ElseIf nilai < 1000 Then
            Return (Terbilang(CInt((nilai \ 100))) & " ratus") + Terbilang(nilai Mod 100)
        ElseIf nilai < 2000 Then
            Return " seribu" & Terbilang(nilai - 1000)
        ElseIf nilai < 1000000 Then
            Return (Terbilang(CInt((nilai \ 1000))) & " ribu") + Terbilang(nilai Mod 1000)
        ElseIf nilai < 1000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000))) & " juta") + Terbilang(nilai Mod 1000000)
        ElseIf nilai < 1000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000))) & " milyar") + Terbilang(nilai Mod 1000000000)
        ElseIf nilai < 1000000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000000))) & " trilyun") + Terbilang(nilai Mod 1000000000000)
        Else
            Return ""
        End If

    End Function

    Function GetAverageValue(ByVal Period As String, ByVal Item_ID As String) As Double
        Dim dtTable As New DataTable
        Try
            dtTable.Clear()
            GetAverageValue = 0
            If Conn.State = ConnectionState.Closed Then
                Conn.ConnectionString = ConnectStr
                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Get_AverageCost_ByItemID '" & Period & "', '" & Item_ID & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTable)
            Conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Function


            GetAverageValue = ((dtTable.Rows(0).Item("Qty") * dtTable.Rows(0).Item("Avg_Cost")) + dtTable.Rows(0).Item("TB_Amount")) / _
                              (dtTable.Rows(0).Item("Qty") + dtTable.Rows(0).Item("TB_Qty"))


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Conn.Close()
        End Try
    End Function


    Public Sub Retrieve_Trans_Closing_ByDate(ByRef dtData As DataTable, ByVal DateTrans As String)
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

    Public Sub Insert_CoABB_Nextmonth(ByVal period As String, ByVal Account_ID As String, ByVal Debet As Decimal, ByVal Credit As Decimal)
        Dim dt As New DataTable

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Try
            Cmd.CommandText = "EXEC sp_Insert_Master_COA_BB '" & period & "','" & Account_ID & "'," & Debet & "," & Credit & ",'" & userlog.UserName & "','Y'"
            Cmd.ExecuteNonQuery()
            'Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Conn.Close()
        End Try

    End Sub

    Function getPenjualanBarang() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Select Case ReportType
                Case "PenjualanTokoPerBarangDaily"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_PenjualanToko_ForDailyReport_ByItemID '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanTokoPerBarangMonthly"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_PenjualanToko_ForMonthlyReport_ByItemID '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanTokoPerCustomerDaily"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_PenjualanToko_ForDailyReport_ByCustomer '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanTokoPerCustomerMonthly"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_PenjualanToko_ForMonthlyReport_ByCustomer '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanInstalasiDaily"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_Penjualan_BasedOn_InvoicePiutang_ForDailyReport '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanInstalasiMonthly"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_Penjualan_BasedOn_InvoicePiutang_ForMonthlyReport '" & BeginDate.Date & "', '" & EndDate.Date & "'"
                Case "PenjualanInstalasiDailyByFakturType"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_Penjualan_BasedOn_InvoicePiutang_ForDailyReport_ByFakturType '" & BeginDate.Date & "', '" & EndDate.Date & "', '" & FakturType & "'"
                Case "PenjualanInstalasiMonthlyByFakturType"
                    Cmd.CommandText = "EXEC sp_Retrieve_Trans_Penjualan_BasedOn_InvoicePiutang_ForMonthlyReport_ByFakturType '" & BeginDate.Date & "', '" & EndDate.Date & "', '" & FakturType & "'"
            End Select

            DA.SelectCommand = Cmd
            DA.Fill(dsData, "PenjualanBarang")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try

    End Function
End Module
