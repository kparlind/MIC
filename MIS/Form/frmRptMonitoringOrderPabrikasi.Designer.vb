<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptMonitoringOrderPabrikasi
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsReport = New MIS.dsReport
        Me.dtReportOrderPabrikasiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtReportOrderPabrikasiTableAdapter = New MIS.dsReportTableAdapters.dtReportOrderPabrikasiTableAdapter
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportOrderPabrikasiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsReport_dtReportOrderPabrikasi"
        ReportDataSource1.Value = Me.dtReportOrderPabrikasiBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MIS.rptMonitoringOrderPabrikasi.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1074, 661)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtReportOrderPabrikasiBindingSource
        '
        Me.dtReportOrderPabrikasiBindingSource.DataMember = "dtReportOrderPabrikasi"
        Me.dtReportOrderPabrikasiBindingSource.DataSource = Me.dsReport
        '
        'dtReportOrderPabrikasiTableAdapter
        '
        Me.dtReportOrderPabrikasiTableAdapter.ClearBeforeFill = True
        '
        'frmRptMonitoringOrderPabrikasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 662)
        Me.Controls.Add(Me.ReportViewer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptMonitoringOrderPabrikasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitoring Order Pabrikasi"
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportOrderPabrikasiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtReportOrderPabrikasiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MIS.dsReport
    Friend WithEvents dtReportOrderPabrikasiTableAdapter As MIS.dsReportTableAdapters.dtReportOrderPabrikasiTableAdapter
End Class
