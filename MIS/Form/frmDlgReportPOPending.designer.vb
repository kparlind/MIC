<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDlgReportPOPending
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpPODateTo = New System.Windows.Forms.DateTimePicker
        Me.dtpPODateFrom = New System.Windows.Forms.DateTimePicker
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.lbl_PODate = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'dtpPODateTo
        '
        Me.dtpPODateTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPODateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPODateTo.Location = New System.Drawing.Point(246, 33)
        Me.dtpPODateTo.Name = "dtpPODateTo"
        Me.dtpPODateTo.Size = New System.Drawing.Size(134, 22)
        Me.dtpPODateTo.TabIndex = 27
        '
        'dtpPODateFrom
        '
        Me.dtpPODateFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPODateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPODateFrom.Location = New System.Drawing.Point(85, 33)
        Me.dtpPODateFrom.Name = "dtpPODateFrom"
        Me.dtpPODateFrom.Size = New System.Drawing.Size(127, 22)
        Me.dtpPODateFrom.TabIndex = 26
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(246, 77)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(134, 23)
        Me.btnViewReport.TabIndex = 25
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'lbl_PODate
        '
        Me.lbl_PODate.AutoSize = True
        Me.lbl_PODate.Location = New System.Drawing.Point(26, 38)
        Me.lbl_PODate.Name = "lbl_PODate"
        Me.lbl_PODate.Size = New System.Drawing.Size(53, 14)
        Me.lbl_PODate.TabIndex = 24
        Me.lbl_PODate.Text = "PO Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "To"
        '
        'frmDlgReportPOPending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 129)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpPODateTo)
        Me.Controls.Add(Me.dtpPODateFrom)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.lbl_PODate)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDlgReportPOPending"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report PO Pending"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpPODateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPODateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents lbl_PODate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
