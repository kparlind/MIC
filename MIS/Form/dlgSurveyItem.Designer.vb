<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSurveyItem
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.clstComponent = New System.Windows.Forms.CheckedListBox
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnViewReport)
        Me.Panel1.Controls.Add(Me.clstComponent)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 228)
        Me.Panel1.TabIndex = 1
        '
        'clstComponent
        '
        Me.clstComponent.AccessibleDescription = ""
        Me.clstComponent.FormattingEnabled = True
        Me.clstComponent.Location = New System.Drawing.Point(12, 14)
        Me.clstComponent.Name = "clstComponent"
        Me.clstComponent.Size = New System.Drawing.Size(381, 154)
        Me.clstComponent.TabIndex = 47
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(313, 183)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(80, 30)
        Me.btnViewReport.TabIndex = 47
        Me.btnViewReport.Text = "Select"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'dlgSurveyItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 249)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSurveyItem"
        Me.Text = ":: Item Survey Component :: "
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents clstComponent As System.Windows.Forms.CheckedListBox
End Class
