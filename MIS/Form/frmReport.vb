Imports System.Environment
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports MIS.mdlCommon

Public Class frmReport
    Public ReportName As String     'Global
    Public BeginDate As DateTime    'Report Prospek Order
    Public EndDate As DateTime      'Report Prospek Order
    Public SurveyNo As String       'Report Form Survey
    Public ContractLetter As String 'Report Form MoU
    Public ProjectNo As String      'Report Progress Project & Rekap Pakai Bahan
    Public SPKNo As String          'Report Progress Project & Rekap Pakai Bahan & SPK Form 
    Public isEfficient As Integer   'Report Progress Project
    Public isComplete As Integer    'Report Progress Project
    Public CustID As String         'Report rekap Project
    Public PHMNo As String          'Report Form PHM (ifebrian)
    Public Seq As Integer           'Report Form PHM (ifebrian)

    '--- START Report PO
    Public PONo As String
    Public ItemID As String
    Public WarehouseID As String

    Public PODateFr As DateTime
    Public PODateTo As DateTime
    Public TBDateFr As DateTime
    Public TBDateto As DateTime
    Public PONoFr As String
    Public PONoTo As String
    Public ItemIDFr As String
    Public ItemIDTo As String
    Public WarehouseIDFr As String
    Public WarehouseIDto As String
    Public SuppIDFr As String
    Public SuppIDTo As String
    Public TBNoFr As String
    Public TBNoTo As String
    '--- END Report PO
    '--- START Persediaan Barang
    Public valPeriod As String
    Public valWarehouseID As String
    '--- END   Persediaan Barang

    '--- START Report Area Questionnaire
    Public Category As String
    Public Type As String
    Public Supp_ID As String
    '--- END Report Area Questionnaire

    Public ReportType As String
    Public IncludeRetur As String
    Public FakturType As String
    Public TipeWaktu As String
    Public TipeAnalisa As String
    Public TipePenjualan As String


    Private Sub getItemByUsability(ByRef dtManifold As DataTable, ByVal dtPipe As DataTable, ByVal dtTitik As DataTable, ByVal dtSupporting As DataTable)
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_Manifold"
            DA.SelectCommand = Cmd
            DA.Fill(dtManifold)

            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_PipeToKitchen"
            DA.SelectCommand = Cmd
            DA.Fill(dtPipe)

            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_TitikApi"
            DA.SelectCommand = Cmd
            DA.Fill(dtTitik)

            Cmd.CommandText = "exec sp_Retrieve_Master_Item_Hdr_SupportingMaterial"
            DA.SelectCommand = Cmd
            DA.Fill(dtSupporting)

            Dim dt1 As DataTable
            Dim dt2 As DataTable

            dt1 = dtManifold
            dt2 = dtPipe
            If dt1.Rows.Count >= dt2.Rows.Count Then
                InsertDummies(dt1, 5)
                InsertDummies(dt2, dt1.Rows.Count - dt2.Rows.Count)
            Else
                InsertDummies(dt2, 5)
                InsertDummies(dt1, dt2.Rows.Count - dt1.Rows.Count)
            End If
            dtManifold = dt1
            dtPipe = dt2

            dt1 = dtTitik
            dt2 = dtSupporting
            If dt1.Rows.Count >= dt2.Rows.Count Then
                InsertDummies(dt1, 5)
                InsertDummies(dt2, dt1.Rows.Count - dt2.Rows.Count)
            Else
                InsertDummies(dt2, 5)
                InsertDummies(dt1, dt2.Rows.Count - dt1.Rows.Count)
            End If
            dtTitik = dt1
            dtSupporting = dt2
        Catch ex As Exception
            dtManifold = Nothing
            dtTitik = Nothing
            dtPipe = Nothing
            dtSupporting = Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Sub InsertDummies(ByRef dtData As DataTable, ByVal rowDummies As Integer)
        Dim dtRow As DataRow
        Dim i As Integer

        For i = 0 To rowDummies - 1
            dtRow = dtData.NewRow
            With dtRow
                .Item(0) = ""
                .Item(1) = ""
                .Item(2) = 0
            End With
            dtData.Rows.Add(dtRow)
        Next
    End Sub

    Private Sub InsertDummiesPHMDtl(ByRef dtData As DataTable)  'ifebrian
        Dim dtRow As DataRow

        dtRow = dtData.NewRow
        With dtRow
            .Item(0) = "1"
            .Item(1) = ""
            .Item(2) = ""
            .Item(3) = ""
            .Item(4) = ""
            .Item(5) = 0
            .Item(6) = 0
            .Item(7) = 0
        End With
        dtData.Rows.Add(dtRow)
    End Sub

    Private Sub InsertDummiesPHMJasa(ByRef dtData As DataTable) 'ifebrian
        Dim dtRow As DataRow

        dtRow = dtData.NewRow
        With dtRow
            .Item(0) = ""
            .Item(1) = ""
            .Item(2) = 0
            .Item(3) = 0
            .Item(4) = 0
            .Item(5) = ""
        End With
        dtData.Rows.Add(dtRow)
    End Sub

    Private Sub getDataFormPHM(ByRef dtHdr As DataTable, ByRef dtDtl As DataTable, ByRef dtJasa As DataTable) 'ifebrian
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dt1, dt2 As New DataTable

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_FormPenawaranMarketingHdr '" & PHMNo & "'," & Seq
            DA.SelectCommand = Cmd
            DA.Fill(dtHdr)

            Cmd.CommandText = "exec sp_Retrieve_Report_FormPenawaranMarketingDtl '" & PHMNo & "'," & Seq
            DA.SelectCommand = Cmd
            DA.Fill(dtDtl)

            Cmd.CommandText = "exec sp_Retrieve_Report_FormPenawaranMarketingJasa '" & PHMNo & "'," & Seq
            DA.SelectCommand = Cmd
            DA.Fill(dtJasa)

            If dtDtl.Rows.Count = 0 Then
                dt1 = dtDtl
                InsertDummiesPHMDtl(dt1)
                dtDtl = dt1
            End If

            If dtJasa.Rows.Count = 0 Then
                dt2 = dtJasa
                InsertDummiesPHMJasa(dt2)
                dtJasa = dt2
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Sub

    Private Function getDataProspekOrder() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_ProspekOrder '" & BeginDate & "', '" & EndDate & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ProspekOrder")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    
    Private Function getDataOrderPabrikasi() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Trans_OrderPabrikasi_Report '" & BeginDate & "', '" & EndDate & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "OrderPabrikasi")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try

    End Function
    Private Function getDataPOPending() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "sp_Retrieve_Trans_PO_Pending_BasedOnTerimaBrg '" & PODateFr & "', '" & PODateTo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ReportPOPending")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataPOItem() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "sp_Retrieve_Trans_PO_Item_ByPONo '" & PONo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "PrintPOItem")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataPOJasa() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "sp_Retrieve_Trans_PO_Jasa_ByPONo '" & PONo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "PrintPOJasa")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function


    Private Function getSPKForm() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_SPKForm '" & SPKNo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "SPKForm")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataPO() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "sp_Retrieve_Trans_PO_BasedOnTerimaBrg '" & PODateFr & "', '" & PODateTo & "', '" & TBDateFr & "', '" & TBDateto & "', '" & ItemID & "', '" & WarehouseID & "', '" & PONo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ReportPO")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataBPB() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "EXEC sp_Retrieve_Trans_BPB_ForReport  '" & BeginDate & "', '" & EndDate & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ReportBPB")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataOrderMaintenance() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "EXEC sp_Retrieve_Trans_OrderMaintenance_ForReport  '" & BeginDate & "', '" & EndDate & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ReportOM")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataProgressProject() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_ProgressProjectPerSPK '" & ProjectNo & "', '" & SPKNo & "'," & isEfficient
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ProgressProject")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataRekapProject() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_RekapProject '" & Format(BeginDate, "yyyyMMdd") & "', '" & Format(EndDate, "yyyyMMdd") & "', '" & CustID & "'," & isEfficient & "," & isComplete
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "RekapProject")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataRekapPakaiBahan() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_RekapPemakaianBahanPerSPK '" & ProjectNo & "', '" & SPKNo & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "RekapPakaiBahan")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataRekapPakaiBahanProject() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_RekapPemakaianBahanPerProject '" & IIf(ProjectNo.Trim = String.Empty, "ALL", ProjectNo.Trim) & "', '" & Format(BeginDate, "yyyyMMdd") & "', '" & Format(EndDate, "yyyyMMdd") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "RekapPakaiBahanProject")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataRekapProgressProjectPerSPK() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "exec sp_Retrieve_Report_RekapProgressProjectPerSPK '" & ProjectNo & "', '" & SPKNo & "'," & isEfficient
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "RekapProgressSPK")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Private Function getDataQuestionnaire() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "sp_Retrieve_Trans_Questionnaire_Report  '" & Category & "', '" & Type & "', '" & Supp_ID & "', '" & BeginDate & "', '" & EndDate & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "ReportQuestionnaire")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

    Public Sub Parameter(ByVal DateAwal As DateTime, ByVal DateAkhir As DateTime)
        BeginDate = DateAwal
        EndDate = DateAkhir
    End Sub

    Private Sub frmReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ReportName = "Report PO" Then
            Dim frmChild As New frmDlgReportPO

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmDlgReportPO" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        ElseIf ReportName = "Report BPB" Then
            Dim frmChild As New frmDlgReportBPB

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmDlgReportBPB" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        ElseIf ReportName = "Report Order Maintenance" Then
            Dim frmChild As New frmDlgReportOrderMaintenance

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmDlgReportOrderMaintenance" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        ElseIf ReportName = "Report Questionnaire Jasa" Then
            Dim frmChild As New frmSupplierEvaluationJasa

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmSupplierEvaluationJasa" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        ElseIf ReportName = "Report Questionnaire Barang" Then
            Dim frmChild As New frmSupplierEvaluationBarang

            For Each f As Form In Me.MdiChildren
                If f.Name = "frmSupplierEvaluationBarang" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next
            frmChild.MdiParent = MDIFrm
            frmChild.Show()
        End If
    End Sub

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataSet
        'TODO: This line of code loads data into the 'dsReport.dtRetrieve_Report_ProspekOrder' table. You can move, or remove it, as needed.
        'Me.dtRetrieve_Report_ProspekOrderTableAdapter.Fill(Me.dsReport.dtRetrieve_Report_ProspekOrder, BeginDate, EndDate)

        Me.rptViewer.Reset()
        Select Case ReportName
            Case "Prospek Order"
                dt = getDataProspekOrder()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptProspekOrder.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Prospek Order"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieve_Report_ProspekOrder", dt.Tables("ProspekOrder")))
                Me.rptViewer.RefreshReport()
            Case "Form Survey"
                Dim param As New List(Of ReportParameter)
                Dim dtManifold As New DataTable, dtPipe As New DataTable, dtTitik As New DataTable, dtSupport As New DataTable
                Dim x As ReportParameter

                x = New ReportParameter("SurveyNo", SurveyNo)
                param.Add(x)

                getItemByUsability(dtManifold, dtPipe, dtTitik, dtSupport)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptFormSurvey.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Form Survey"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtManifoldData", dtManifold))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPipeToKitchen", dtPipe))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtTitikApi", dtTitik))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtSupportingMaterial", dtSupport))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Form MoU"
                Dim param As New List(Of ReportParameter)
                Dim dtManifold As New DataTable, dtPipe As New DataTable, dtTitik As New DataTable, dtSupport As New DataTable
                Dim x As ReportParameter

                x = New ReportParameter("SuratKontrak", ContractLetter)
                param.Add(x)

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptMoU.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Form MoU"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Form Monitoring Order Pabrikasi"
                dt = getDataOrderPabrikasi()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptMonitoringOrderPabrikasi.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Monitoring Order Pabriasi"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportOrderPabrikasi", dt.Tables("OrderPabrikasi")))
                Me.rptViewer.RefreshReport()
            Case "Report PO"
                dt = getDataPO()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptTransPO.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Purchase Order"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportPO", dt.Tables("ReportPO")))
                Me.rptViewer.RefreshReport()
            Case "Report BPB"
                dt = getDataBPB()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptTransBPB.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Permintaan Bahan"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportBPB", dt.Tables("ReportBPB")))
                Me.rptViewer.RefreshReport()
            Case "Report Order Maintenance"
                dt = getDataOrderMaintenance()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptTransOrderMaintenance.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Order Maintenance"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportOrderMaintenance", dt.Tables("ReportOM")))
                Me.rptViewer.RefreshReport()
            Case "Report Questionnaire Jasa"
                dt = getDataQuestionnaire()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptSupplierEvaluationJasa.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Supplier Jasa"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportQuestionnaire", dt.Tables("ReportQuestionnaire")))
                Me.rptViewer.RefreshReport()
            Case "Report Questionnaire Barang"
                dt = getDataQuestionnaire()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptSupplierEvaluationBarang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Supplier Barang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtReportQuestionnaire", dt.Tables("ReportQuestionnaire")))
                Me.rptViewer.RefreshReport()
            Case "Progress Project"
                dt = getDataProgressProject()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptProgressProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Progress Project Per SPK"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportProgressProjectPerSPK", dt.Tables("ProgressProject")))
                Me.rptViewer.RefreshReport()
            Case "Rekap Pakai Bahan"
                dt = getDataRekapPakaiBahan()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptRekapPakaiBahan.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Rekap Pemakaian Bahan Per SPK"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportRekapPemakaianBahanPerSPK", dt.Tables("RekapPakaiBahan")))
                Me.rptViewer.RefreshReport()
            Case "Rekap Project"
                Dim param As New List(Of ReportParameter)
                Dim x As ReportParameter

                x = New ReportParameter("BeginDate", BeginDate)
                param.Add(x)
                x = New ReportParameter("EndDate", EndDate)
                param.Add(x)

                dt = getDataRekapProject()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptRekapProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Rekap Project"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportRekapProject", dt.Tables("RekapProject")))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Rekap Pakai Bahan Project"
                dt = getDataRekapPakaiBahanProject()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptRekapPakaiBahanProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Rekap Pemakaian Bahan Per Project"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportRekapPemakaianBahanPerProject", dt.Tables("RekapPakaiBahanProject")))
                Me.rptViewer.RefreshReport()
            Case "SPK Form"
                dt = getSPKForm()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptSPKForm.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "SPK Form"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportSPKForm", dt.Tables("SPKForm")))
                Me.rptViewer.RefreshReport()
            Case "Rekap Progress Project"
                dt = getDataRekapProgressProjectPerSPK()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptRekapProgressProjectPerSPK.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Rekap Progress Project Per SPK"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportRekapProgressProjectPerSPK", dt.Tables("RekapProgressSPK")))
                Me.rptViewer.RefreshReport()
            Case "PHM Form" 'ifebrian
                Dim dtHdr, dtDtl, dtJasa As New DataTable

                getDataFormPHM(dtHdr, dtDtl, dtJasa)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptFormPenawaranCustomer.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Form Penawaran Customer"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportFormPenawaranMarketingHdr", dtHdr))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportFormPenawaranMarketingDtl", dtDtl))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtRetrieveReportFormPenawaranMarketingJasa", dtJasa))
                Me.rptViewer.RefreshReport()

            Case "Report PO Pending"
                dt = getDataPOPending()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptTransPOPending.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report PO Pending"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPOPendingBasedOnTerimaBarang", dt.Tables("ReportPOPending")))
                Me.rptViewer.RefreshReport()

            Case "Print PO Item"
                dt = getDataPOItem()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.printPOItem.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Print PO"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPOItemByPONo", dt.Tables("PrintPOItem")))
                Me.rptViewer.RefreshReport()
            Case "Print PO Jasa"
                dt = getDataPOJasa()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.printPOJasa.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Print PO"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPOJasaByPONo", dt.Tables("PrintPOJasa")))
                Me.rptViewer.RefreshReport()
            Case "Persediaan Barang"
                Dim param As New List(Of ReportParameter)
                Dim x As ReportParameter

                x = New ReportParameter("Period", valPeriod)
                param.Add(x)
                dt = getPersediaanBarang()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.PersediaanBarang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Persediaan Barang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPersediaanBarang", dt.Tables("PersediaanBarang")))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Report Penjualan"
                Dim param As New List(Of ReportParameter)
                Dim x As ReportParameter

                x = New ReportParameter("ReportType", ReportType)
                param.Add(x)
                x = New ReportParameter("IncludeRetur", IncludeRetur)
                param.Add(x)
                x = New ReportParameter("TipePenjualan", TipePenjualan)
                param.Add(x)
                x = New ReportParameter("TipeFaktur", FakturType)
                param.Add(x)
                x = New ReportParameter("TipeWaktu", TipeWaktu)
                param.Add(x)
                x = New ReportParameter("TipeAnalisa", TipeAnalisa)
                param.Add(x)
                x = New ReportParameter("DateFrom", BeginDate)
                param.Add(x)
                x = New ReportParameter("DateTo", EndDate)
                param.Add(x)

                dt = getPenjualanBarang()

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIC.rptPenjualan.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Penjualan Barang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanTokoPerBarangDaily", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanTokoPerBarangMonthly", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanTokoPerCustomerDaily", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanTokoPerCustomerMonthly", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanInstalasiDaily", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPenjualanInstalasiMonthly", dt.Tables("PenjualanBarang")))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()

            Case Else
        End Select
    End Sub

    Private Function getPersediaanBarang() As DataSet
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dsData As New DataSet

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text

            Cmd.CommandText = "EXEC sp_Retrieve_CurrentStock_ForReport '" & valPeriod & "', '" & valWarehouseID & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dsData, "PersediaanBarang")

            Return dsData
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        Finally
            If Conn.State = ConnectionState.Open Then Conn.Close()
        End Try
    End Function

End Class