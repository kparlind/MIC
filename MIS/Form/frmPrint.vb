Imports System.Environment
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmPrint
    Public ReportName As String
    Public fakturno As String
    Public alamat As String
    Public terbilang As String
    Public jumlahuang As String
    Public namacust As String
    Public dpp As String
    Public dph As String
    Public dtGL As New DataTable
    Public dtHutang As New DataTable
    Public dtPiutang As New DataTable
    Public dtHutangSummary As New DataTable
    Public dtPiutangSummary As New DataTable
    Public dtDaftarHutang As New DataTable
    Public dtNeraca As New DataTable
    Public dtLabaRugi As New DataTable
    Public dtPHutang As New DataTable
    Public dtPPiutang As New DataTable
    Public period As String
    Public periodHutang As String
    Public periodPiutang As String
    Public periodJurnal As String
    Public periodNeraca As String
    Public periodLabaRugi As String
    Public dtSPK As New DataTable
    Public dtPembelian As New DataTable
    Public dtJurnal As New DataTable
    Public dtlogbook As New DataTable
    Public dtTotalPiutang As New DataTable
    Public dtBPB As New DataTable
    Public dtBank As New DataTable
    Public dtBankBB As New DataTable
    Public dtBiayaTeknis As New DataTable
    Public dtHPP As New DataTable
    Public dtTotalPHP As New DataTable
    Public dtInvMarketing As New DataTable
    Public dtbiayamarketing As New DataTable
    Public dtTotalPHM As New DataTable
    Public dtDaftarPiutang As New DataTable

    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case ReportName

            Case "Invoice Piutang"
                Dim dtInvoice As New DataTable
                Dim param As New List(Of ReportParameter)
                Dim paramAlamat As ReportParameter
                Dim paramJumlahUang As ReportParameter
                Dim paramNamaCust As ReportParameter
                Dim paramTerbilang As ReportParameter

                paramTerbilang = New ReportParameter("terbilang", terbilang)
                paramNamaCust = New ReportParameter("namacust", namacust)
                paramJumlahUang = New ReportParameter("jumlahuang", jumlahuang)
                paramAlamat = New ReportParameter("alamat", alamat)
                param.Add(paramAlamat)
                param.Add(paramNamaCust)
                param.Add(paramJumlahUang)
                param.Add(paramTerbilang)

                'x = New ReportParameter("SurveyNo", SurveyNo)
                'param.Add(x)

                dtInvoice = getDataInvoicePiutang()

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.printInvoicePiutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Invoice Piutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtInvoicePiutang", dtInvoice))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Daftar Piutang"
                Dim dtPiutang As New DataTable

                dtPiutang = getDaftarPiutang()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.printDaftarPiutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Daftar Piutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_retrieve_DPPbyID", dtPiutang))
                Me.rptViewer.RefreshReport()
            Case "Daftar Hutang"
                'dtHutang = getDaftarHutang()
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.printDaftarHutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Daftar Hutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtDaftarPelunasanHutang", dtDaftarHutang))
                Me.rptViewer.RefreshReport()
            Case "Report GL"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("Period", period)
                param.Add(paramPeriod)

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptGLDetail.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report GL Detail"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtGLDetail", dtGL))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
            Case "Report Hutang"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter


                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptHutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Hutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPembayaranKartuHutangDS", dtHutang))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1150
                Me.rptViewer.Width = 1150
            Case "Report Piutang"
                Dim param As New List(Of ReportParameter)
                'Dim paramPeriod As ReportParameter


                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptKartuPiutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Piutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_dtPembayaranKartuPiutangDS", dtPiutang))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1150
                Me.rptViewer.Width = 1150
            Case "Report Hutang Summary"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("period", periodHutang)
                param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptHutangSummary.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Hutang Summmary Aging"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_GetSupplierPayableAging", dtHutangSummary))
                ' Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 850
                Me.rptViewer.Width = 840

            Case "Report Jadwal Project"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter


                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptJadwalProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Jadwal Project"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_GetJadwalKerjaProject", dtSPK))
                ' Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040
            Case "Report Pembelian"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter


                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptPembelian.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Pembelian"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getPembelianItem", dtPembelian))
                ' Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040
            Case "Report Jurnal List"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("period", periodJurnal)
                param.Add(paramPeriod)

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptJurnalList.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Jurnal List"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getJournalFromTransaction", dtJurnal))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040

            Case "Report Piutang Summary"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("period", periodHutang)
                param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptPiutangSummary.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Piutang Summmary Aging"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_GetCustomerReceivableAging", dtPiutangSummary))
                ' Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 850
                Me.rptViewer.Width = 840
            Case "Report Neraca"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("period", periodNeraca)
                param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptNeraca.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Neraca"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getNeraca", dtNeraca))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 850
                Me.rptViewer.Width = 840
            Case "Report Laba Rugi"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                paramPeriod = New ReportParameter("period", periodLabaRugi)
                param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptLabaRugi.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Laba Rugi"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getLabaRugi", dtLabaRugi))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 850
                Me.rptViewer.Width = 840
            Case "Report Pelunasan Hutang"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                'paramPeriod = New ReportParameter("period", periodLabaRugi)
                'param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptPelunasanHutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Pelunasan Hutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getRptPelunasanHutang", dtPHutang))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1200
                Me.rptViewer.Width = 1200
            Case "Report Pelunasan Piutang"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter
                'paramPeriod = New ReportParameter("period", periodLabaRugi)
                'param.Add(paramPeriod)
                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptPelunasanPiutang.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Pelunasan Piutang"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getRptPelunasanPiutang", dtPPiutang))
                Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1200
                Me.rptViewer.Width = 1200
            Case "Report Laba Rugi Per Project"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter


                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptLabaRugiPerProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Laba Rugi Per Project"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_GetBPBCostPerProject", dtBPB))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getTotalPiutangPerProject", dtTotalPiutang))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getLogBookCostPerProject", dtLogBook))

                ' Me.rptViewer.LocalReport.SetParameters(param)
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040
            Case "Report Bank Harian"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptBankHarian.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Bank Harian"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getJournalBankHarian", dtBank))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getBankBeginningBalance", dtBankBB))
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040
            Case "Report Laba Rugi Project"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptLabaRugiProject.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Laba Rugi Project"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getTotalPHP", dtTotalPHP))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getBiayaTeknis", dtBiayaTeknis))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getHPP_Project", dtHPP))
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040
            Case "Report Laba Rugi Marketing"
                Dim param As New List(Of ReportParameter)
                Dim paramPeriod As ReportParameter

                Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptLabaRugiMarketing.rdlc"
                Me.rptViewer.LocalReport.DisplayName = "Report Laba Rugi Marketing"
                Me.Text = ":: " & Me.rptViewer.LocalReport.DisplayName & " ::"
                Me.rptViewer.LocalReport.DataSources.Clear()
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getTotalPHM", dtTotalPHM))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getBiayaMarketing", dtbiayamarketing))
                Me.rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport_sp_getInvoiceMarketing", dtInvMarketing))
                Me.rptViewer.RefreshReport()
                Me.Width = 1040
                Me.rptViewer.Width = 1040

        End Select

    End Sub
    Private Function getDataInvoicePiutang() As DataTable
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dt As New DataTable

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Cmd.CommandText = "exec sp_Retreive_Trans_Invoice_PiutangRpt  '" & fakturno & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        Return dt
    End Function

    Private Function getDaftarPiutang() As DataTable
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dt As New DataTable

        Conn.ConnectionString = ConnectStr
        Conn.Open()

        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Cmd.CommandText = "exec sp_retrieve_DPPbyID  '" & dpp & "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt)

        Return dt
    End Function

    'Private Function getDaftarHutang() As DataTable
    '    Dim Conn As New SqlConnection
    '    Dim Cmd As New SqlCommand
    '    Dim DA As New SqlDataAdapter
    '    Dim dt As New DataTable

    '    Conn.ConnectionString = ConnectStr
    '    Conn.Open()

    '    Cmd.Connection = Conn
    '    Cmd.CommandType = CommandType.Text

    '    Cmd.CommandText = "exec sp_GetDaftarPelunasanHutangPrint '" & dph & "'"
    '    DA.SelectCommand = Cmd
    '    DA.Fill(dt)

    '    Return dt
    'End Function
End Class