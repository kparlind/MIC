Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmSupplierEvaluationBarang

#Region "Variable Declaration"

    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTRans As String
    Public Prefix As String
    Dim Customer As String
    Dim Supplier As String

#End Region

#Region "Function & Procedure"

    Sub RetrieveCbSupplier()
        Dim dtTable As New DataTable
        cbSupplier.ResetText()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Master_Supplier_ForComboBox"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Sub

            cbSupplier.DataSource = dtTable
            cbSupplier.DisplayMember = "Supp_Desc"
            cbSupplier.ValueMember = "Supp_ID"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmQuestionnaireSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        cbRptType.SelectedItem = "ALL"

        RetrieveCbSupplier()
    End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        Dim frmChild As New frmReport

        For Each f As Form In Me.MdiChildren
            If f.Name = "Form Report" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm

        Select Case cbRptType.SelectedItem
            Case "ALL"
                frmChild.Category = "Supplier"
                frmChild.Type = "ALL"
                frmChild.Supp_ID = ""
                frmChild.BeginDate = "01-01-1900"
                frmChild.EndDate = "01-01-1900"
            Case "By Supplier"
                frmChild.Type = "By Supplier"
                frmChild.Category = "Supplier"
                frmChild.Supp_ID = cbSupplier.SelectedValue.ToString
                frmChild.BeginDate = "01-01-1900"
                frmChild.EndDate = "01-01-1900"
            Case "By Date"
                frmChild.Type = "By Date"
                frmChild.Category = "Supplier"
                frmChild.Supp_ID = ""
                frmChild.BeginDate = Format(dtpDateFrom.Value, "MM-dd-yyyy")
                frmChild.EndDate = Format(dtpDateTo.Value, "MM-dd-yyyy")
        End Select
        frmChild.ReportName = "Report Questionnaire Barang"
        frmChild.Show()
        Me.Close()
    End Sub

#End Region

End Class