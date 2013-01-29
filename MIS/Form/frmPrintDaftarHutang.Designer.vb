<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintDaftarHutang
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
        Me.dtDaftarPelunasanHutangBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtDaftarPelunasanHutangTableAdapter = New MIS.dsReportTableAdapters.dtDaftarPelunasanHutangTableAdapter
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDaftarPelunasanHutangBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsReport_dtDaftarPelunasanHutang"
        ReportDataSource1.Value = Me.dtDaftarPelunasanHutangBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MIS.printDaftarHutang.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(-1, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(964, 540)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtDaftarPelunasanHutangBindingSource
        '
        Me.dtDaftarPelunasanHutangBindingSource.DataMember = "dtDaftarPelunasanHutang"
        Me.dtDaftarPelunasanHutangBindingSource.DataSource = Me.dsReport
        '
        'dtDaftarPelunasanHutangTableAdapter
        '
        Me.dtDaftarPelunasanHutangTableAdapter.ClearBeforeFill = True
        '
        'frmPrintDaftarHutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 539)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmPrintDaftarHutang"
        Me.Text = "frmPrintDaftarHutang"
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDaftarPelunasanHutangBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtDaftarPelunasanHutangBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MIS.dsReport
    Friend WithEvents dtDaftarPelunasanHutangTableAdapter As MIS.dsReportTableAdapters.dtDaftarPelunasanHutangTableAdapter
End Class
