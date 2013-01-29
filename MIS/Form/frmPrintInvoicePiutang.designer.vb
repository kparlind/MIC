<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintInvoicePiutang
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
        Me.dtInvoicePiutangBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtInvoicePiutangTableAdapter = New MIS.dsReportTableAdapters.dtInvoicePiutangTableAdapter
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtInvoicePiutangBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsReport_dtInvoicePiutang"
        ReportDataSource1.Value = Me.dtInvoicePiutangBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MIS.printInvoicePiutang.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, 1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 500)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtInvoicePiutangBindingSource
        '
        Me.dtInvoicePiutangBindingSource.DataMember = "dtInvoicePiutang"
        Me.dtInvoicePiutangBindingSource.DataSource = Me.dsReport
        '
        'dtInvoicePiutangTableAdapter
        '
        Me.dtInvoicePiutangTableAdapter.ClearBeforeFill = True
        '
        'frmPrintInvoicePiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmPrintInvoicePiutang"
        Me.Text = "frmPrintInvoicePiutang"
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtInvoicePiutangBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtInvoicePiutangBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MIS.dsReport
    Friend WithEvents dtInvoicePiutangTableAdapter As MIS.dsReportTableAdapters.dtInvoicePiutangTableAdapter
End Class
