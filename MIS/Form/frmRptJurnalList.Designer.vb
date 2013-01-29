<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptJurnalList
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
        Me.txtJurnalList = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnShow = New System.Windows.Forms.Button
        Me.Periode = New System.Windows.Forms.Label
        Me.cmbPeriode = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'txtJurnalList
        '
        Me.txtJurnalList.Location = New System.Drawing.Point(129, 18)
        Me.txtJurnalList.Name = "txtJurnalList"
        Me.txtJurnalList.Size = New System.Drawing.Size(142, 20)
        Me.txtJurnalList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Transaction Name"
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(12, 70)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(273, 64)
        Me.btnShow.TabIndex = 2
        Me.btnShow.Text = "Show Report"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'Periode
        '
        Me.Periode.AutoSize = True
        Me.Periode.Location = New System.Drawing.Point(12, 47)
        Me.Periode.Name = "Periode"
        Me.Periode.Size = New System.Drawing.Size(43, 13)
        Me.Periode.TabIndex = 3
        Me.Periode.Text = "Periode"
        '
        'cmbPeriode
        '
        Me.cmbPeriode.FormattingEnabled = True
        Me.cmbPeriode.Location = New System.Drawing.Point(129, 43)
        Me.cmbPeriode.Name = "cmbPeriode"
        Me.cmbPeriode.Size = New System.Drawing.Size(121, 21)
        Me.cmbPeriode.TabIndex = 5
        '
        'frmRptJurnalList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 146)
        Me.Controls.Add(Me.cmbPeriode)
        Me.Controls.Add(Me.Periode)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtJurnalList)
        Me.Name = "frmRptJurnalList"
        Me.Text = "Report Jurnal List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtJurnalList As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents Periode As System.Windows.Forms.Label
    Friend WithEvents cmbPeriode As System.Windows.Forms.ComboBox
End Class
