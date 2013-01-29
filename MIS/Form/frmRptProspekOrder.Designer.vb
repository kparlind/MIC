<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptProspekOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.dtRetrieve_Report_ProspekOrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsReport = New MIS.dsReport
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dtRetrieve_Report_ProspekOrderTableAdapter = New MIS.dsReportTableAdapters.dtRetrieve_Report_ProspekOrderTableAdapter
        CType(Me.dtRetrieve_Report_ProspekOrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtRetrieve_Report_ProspekOrderBindingSource
        '
        Me.dtRetrieve_Report_ProspekOrderBindingSource.DataMember = "dtRetrieve_Report_ProspekOrder"
        Me.dtRetrieve_Report_ProspekOrderBindingSource.DataSource = Me.dsReport
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rptViewer
        '
        ReportDataSource1.Name = "dsReport_dtRetrieve_Report_ProspekOrder"
        ReportDataSource1.Value = Me.dtRetrieve_Report_ProspekOrderBindingSource
        Me.rptViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptViewer.LocalReport.ReportEmbeddedResource = "MIS.rptProspekOrder.rdlc"
        Me.rptViewer.Location = New System.Drawing.Point(0, 0)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(1316, 700)
        Me.rptViewer.TabIndex = 0
        '
        'dtRetrieve_Report_ProspekOrderTableAdapter
        '
        Me.dtRetrieve_Report_ProspekOrderTableAdapter.ClearBeforeFill = True
        '
        'frmRptProspekOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1316, 662)
        Me.Controls.Add(Me.rptViewer)
        Me.Name = "frmRptProspekOrder"
        Me.Text = "frmRptProspekOrder"
        CType(Me.dtRetrieve_Report_ProspekOrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtRetrieve_Report_ProspekOrderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MIS.dsReport
    Friend WithEvents dtRetrieve_Report_ProspekOrderTableAdapter As MIS.dsReportTableAdapters.dtRetrieve_Report_ProspekOrderTableAdapter
End Class
