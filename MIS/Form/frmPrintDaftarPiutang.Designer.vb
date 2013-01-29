<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintDaftarPiutang
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
        Me.sp_retrieve_DPPbyIDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsReport = New MIS.dsReport
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.sp_retrieve_DPPbyIDTableAdapter = New MIS.dsReportTableAdapters.sp_retrieve_DPPbyIDTableAdapter
        CType(Me.sp_retrieve_DPPbyIDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sp_retrieve_DPPbyIDBindingSource
        '
        Me.sp_retrieve_DPPbyIDBindingSource.DataMember = "sp_retrieve_DPPbyID"
        Me.sp_retrieve_DPPbyIDBindingSource.DataSource = Me.dsReport
        '
        'dsReport
        '
        Me.dsReport.DataSetName = "dsReport"
        Me.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsReport_sp_retrieve_DPPbyID"
        ReportDataSource1.Value = Me.sp_retrieve_DPPbyIDBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MIS.printDaftarPiutang.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(-1, -1)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1200, 600)
        Me.ReportViewer1.TabIndex = 0
        '
        'sp_retrieve_DPPbyIDTableAdapter
        '
        Me.sp_retrieve_DPPbyIDTableAdapter.ClearBeforeFill = True
        '
        'printDaftarPenagihanPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 651)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "printDaftarPenagihanPiutang"
        Me.Text = "printDaftarPenagihanPiutang"
        CType(Me.sp_retrieve_DPPbyIDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents sp_retrieve_DPPbyIDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsReport As MIS.dsReport
    Friend WithEvents sp_retrieve_DPPbyIDTableAdapter As MIS.dsReportTableAdapters.sp_retrieve_DPPbyIDTableAdapter
End Class
