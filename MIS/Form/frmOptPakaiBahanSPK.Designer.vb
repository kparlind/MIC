<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptPakaiBahanSPK
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
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.txtProjectNo = New System.Windows.Forms.TextBox
        Me.cboSPK = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtProjectName
        '
        Me.txtProjectName.BackColor = System.Drawing.Color.LightGray
        Me.txtProjectName.Location = New System.Drawing.Point(205, 21)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectName.Size = New System.Drawing.Size(226, 20)
        Me.txtProjectName.TabIndex = 37
        '
        'txtProjectNo
        '
        Me.txtProjectNo.Location = New System.Drawing.Point(127, 21)
        Me.txtProjectNo.Name = "txtProjectNo"
        Me.txtProjectNo.Size = New System.Drawing.Size(72, 20)
        Me.txtProjectNo.TabIndex = 36
        '
        'cboSPK
        '
        Me.cboSPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSPK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSPK.FormattingEnabled = True
        Me.cboSPK.Location = New System.Drawing.Point(127, 47)
        Me.cboSPK.Name = "cboSPK"
        Me.cboSPK.Size = New System.Drawing.Size(180, 22)
        Me.cboSPK.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "SPK No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Project No."
        '
        'btnViewReport
        '
        Me.btnViewReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Location = New System.Drawing.Point(320, 80)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(111, 23)
        Me.btnViewReport.TabIndex = 38
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'frmOptPakaiBahanSPK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 115)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.txtProjectNo)
        Me.Controls.Add(Me.cboSPK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptPakaiBahanSPK"
        Me.Text = ":: Report Rekap Pemakaian Bahan Per SPK ::"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents cboSPK As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
End Class
