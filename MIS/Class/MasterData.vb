Imports System.Data.SqlClient
Imports mis.GlobalVar

Public Class MasterData
    Public Sub getDefaultCurrency(ByRef CurrID As String, ByRef CurrName As String, ByRef CurrPrefix As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Currency_Default"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                With dtData.Rows(0)
                    CurrID = .Item(GlobalVar.Fields.Curr_ID).ToString.Trim
                    CurrName = .Item(GlobalVar.Fields.Curr_Name).ToString.Trim
                    CurrPrefix = .Item(GlobalVar.Fields.Curr_Prefix).ToString.Trim
                End With
            Else
                CurrID = String.Empty
                CurrName = String.Empty
                CurrPrefix = String.Empty
            End If
        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RetrievePaymentCategory(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Enumitems_ByCategory 'PAYCT'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)

        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub getCurrencyDescription(ByVal CurrID As String, ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Currency_ByKey '" & CurrID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RetrieveBankByKey(ByRef dtData As DataTable, ByVal BankID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Bank '" & BankID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)

        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RetrieveCustomerByKey(ByRef dtData As DataTable, ByVal CustID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Customer_ByKey '" & CustID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)

        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RetrieveCustomer(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Customer"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)

        Catch ex As Exception
            If Conn.State = ConnectionState.Open Then Conn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function RetrieveItemNameByKey(ByVal ItemID As String) As String
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_ByKey '" & ItemID & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            If dtTemp.Rows.Count <> 0 Then
                Return dtTemp.Rows(0).Item(Fields.Item_Name).ToString
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub RetrieveItemByKey(ByRef dtData As DataTable, ByVal ItemID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_ByKey '" & ItemID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemByKey_RegardlessActive(ByRef dtData As DataTable, ByVal ItemID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_ByKey_All '" & ItemID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub getItemHeader_ByUsability(ByRef dtData As DataTable, Optional ByVal isManifold As Boolean = False, Optional ByVal isPipeToKitchen As Boolean = False, Optional ByVal isTitikApi As Boolean = False, Optional ByVal isSupportingMaterial As Boolean = False)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_ByUseability '" & IIf(isManifold, "Y", "N") & "', '" & IIf(isPipeToKitchen, "Y", "N") & "', '" & IIf(isTitikApi, "Y", "N") & "', '" & IIf(isSupportingMaterial, "Y", "N") & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            dtData = Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub getAccessFunctionForForm(ByRef dtData As DataTable, ByVal AccessID As String, ByVal ObjectID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec GetAccessFunctionForForm '" & AccessID & "', '" & ObjectID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveSurveyorByKey(ByRef dtData As DataTable, ByVal EmployeeID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Surveyor_ByKey '" & EmployeeID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveSurveyor(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Surveyor"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveEmployeeData_ByKey(ByRef dtData As DataTable, ByVal EmployeeID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_ByKey '" & EmployeeID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemManifold(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_Manifold"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemPipeToKitchen(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_PipeToKitchen"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemTitikApi(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_TitikApi"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemSupportingMaterial(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_SupportingMaterial"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemCategory_ByItemID(ByRef dtData As DataTable, ByVal ItemID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_RetrieveItemCategory_byItemID '" & ItemID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Function RetrieveJasaName_ByID(ByVal JasaID As String) As String
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retreive_Master_Jasa_byJasaID '" & JasaID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                RetrieveJasaName_ByID = dtData.Rows(0).Item("Jasa_Name").ToString.Trim
            Else
                RetrieveJasaName_ByID = String.Empty
            End If
        Catch ex As Exception
            RetrieveJasaName_ByID = String.Empty
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Function RetrieveJasaPrice(ByVal JasaID As String) As Double
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Maintain_SalesPrice_Jasa_ByJasaID '" & JasaID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                RetrieveJasaPrice = CDbl(dtData.Rows(0).Item(2))
            Else
                RetrieveJasaPrice = 0
            End If
        Catch ex As Exception
            RetrieveJasaPrice = 0
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub RetrieveTechnician_List(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Technician_List"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Function RetrieveTechnician_ByID(ByVal TechnicianID As String) As String
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Technician_ByID '" & TechnicianID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                RetrieveTechnician_ByID = dtData.Rows(0).Item(1)
            Else
                RetrieveTechnician_ByID = String.Empty
            End If
        Catch ex As Exception
            RetrieveTechnician_ByID = String.Empty
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Function RetrieveHargaSatuan(ByVal warehouseID As String, ByVal ItemID As String) As Double
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            'Pindahin dr datatable PO ke datatable TrmBrg                            
            Cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Item_ByItemID '" + ItemID + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dtData)

            With dtData
                If .Rows.Count <> 0 Then
                    If .Rows(0).Item(Fields.PHPro_SalesPrice).ToString.Trim = String.Empty Then
                        RetrieveHargaSatuan = 0
                    Else
                        RetrieveHargaSatuan = .Rows(0).Item(Fields.PHPro_SalesPrice).ToString
                    End If
                Else
                    RetrieveHargaSatuan = 0
                End If
            End With
        Catch ex As Exception
            RetrieveHargaSatuan = 0
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub RetrieveItemKomponent_ByCategoryAndID(ByRef dtData As DataTable, ByVal ItemCategory As String, ByVal ComponentID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Komponen_GroupHdr_ByCategoryAndID '" & ItemCategory & "','" & ComponentID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveItemKomponent_ByCategory(ByRef dtData As DataTable, ByVal ItemCategory As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Komponen_GroupHdr_ByCategory '" & ItemCategory & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveDetailItemKomponent_ByCategory(ByRef dtData As DataTable, ByVal ItemCategory As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Komponen_GroupDtl_ByCategory '" & ItemCategory & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveDetailItemKomponent_ByCategoryAndComponentID(ByRef dtData As DataTable, ByVal ItemCategory As String, ByVal ComponentID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Komponen_GroupDtl_ByCategoryAndComponentID '" & ItemCategory & "','" & ComponentID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveEmployeeMarketingList(ByRef dtData As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Marketing"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveEmployeeMarketing_ByID(ByRef dtData As DataTable, ByVal EmployeeID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Marketing_ByKey '" & EmployeeID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveEmployeeSurveyor_ByID(ByRef dtData As DataTable, ByVal EmployeeID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Employee_Surveyor_ByKey '" & EmployeeID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveAccountMappingJournal(ByRef dtData As DataTable, ByVal FormName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_MappingJournal_ByForm '" & FormName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveAccountMappingJournal_ByAccountID(ByRef dtData As DataTable, ByVal FormName As String, ByVal AccountID As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_MappingJournal_ByForm_ByAccountID '" & FormName & "', '" & AccountID & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveGroupMappingJournal_ByForm(ByRef dtData As DataTable, ByVal FormName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_GroupJurnal_ByFormName '" & FormName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveGroupMappingJournal_ByForm_DEBETOnly(ByRef dtData As DataTable, ByVal FormName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_MappingJournal_ByForm_DEBET '" & FormName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveGroupMappingJournal_ByForm_CREDITOnly(ByRef dtData As DataTable, ByVal FormName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        dtData = New DataTable
        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_MappingJournal_ByForm_CREDIT '" & FormName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Public Sub RetrieveObjectByFormName(ByRef ObjectID As String, ByVal FormName As String)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtData As New DataTable

        Try
            Conn.ConnectionString = ConnectStr
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_MasterObject_ByFormName '" & FormName & "'"
            DA.SelectCommand = Cmd

            DA.Fill(dtData)
            If dtData.Rows.Count <> 0 Then
                ObjectID = dtData.Rows(0).Item("Object_ID").ToString.Trim
            Else
                ObjectID = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub
End Class
