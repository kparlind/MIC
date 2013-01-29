<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptLabaRugiPerDivisi
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbPeriode = New System.Windows.Forms.ComboBox
        Me.cmbDivisi = New System.Windows.Forms.ComboBox
        Me.btnShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Divisi"
        '
        'cmbPeriode
        '
        Me.cmbPeriode.FormattingEnabled = True
        Me.cmbPeriode.Location = New System.Drawing.Point(87, 27)
        Me.cmbPeriode.Name = "cmbPeriode"
        Me.cmbPeriode.Size = New System.Drawing.Size(121, 21)
        Me.cmbPeriode.TabIndex = 2
        '
        'cmbDivisi
        '
        Me.cmbDivisi.FormattingEnabled = True
        Me.cmbDivisi.Items.AddRange(New Object() {"Project", "Marketing"})
        Me.cmbDivisi.Location = New System.Drawing.Point(87, 52)
        Me.cmbDivisi.Name = "cmbDivisi"
        Me.cmbDivisi.Size = New System.Drawing.Size(121, 21)
        Me.cmbDivisi.TabIndex = 3
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(12, 91)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(231, 29)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "Show Report"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'frmRptLabaRugiPerDivisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 132)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.cmbDivisi)
        Me.Controls.Add(Me.cmbPeriode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRptLabaRugiPerDivisi"
        Me.Text = "Report Laba Rugi Per Divisi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriode As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDivisi As System.Windows.Forms.ComboBox
    Friend WithEvents btnShow As System.Windows.Forms.Button
End Class
