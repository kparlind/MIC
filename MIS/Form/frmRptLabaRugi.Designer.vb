<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptLabaRugi
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbPeriode = New System.Windows.Forms.ComboBox
        Me.btnShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Periode"
        '
        'cmbPeriode
        '
        Me.cmbPeriode.FormattingEnabled = True
        Me.cmbPeriode.Location = New System.Drawing.Point(70, 19)
        Me.cmbPeriode.Name = "cmbPeriode"
        Me.cmbPeriode.Size = New System.Drawing.Size(93, 21)
        Me.cmbPeriode.TabIndex = 20
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(12, 46)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(110, 38)
        Me.btnShow.TabIndex = 19
        Me.btnShow.Text = "Show Report"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'frmRptLabaRugi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 96)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPeriode)
        Me.Controls.Add(Me.btnShow)
        Me.Name = "frmRptLabaRugi"
        Me.Text = "Report Laba Rugi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriode As System.Windows.Forms.ComboBox
    Friend WithEvents btnShow As System.Windows.Forms.Button
End Class
