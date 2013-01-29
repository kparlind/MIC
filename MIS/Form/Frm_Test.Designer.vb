<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Test
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_cari = New System.Windows.Forms.Button
        Me.txt_SearchData = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_searchBaseon = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GridUtangBB = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridUtangBB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.txt_SearchData)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb_searchBaseon)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 58)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(661, 19)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 23)
        Me.btn_cari.TabIndex = 4
        Me.btn_cari.Text = "Cari"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'txt_SearchData
        '
        Me.txt_SearchData.Location = New System.Drawing.Point(315, 22)
        Me.txt_SearchData.Name = "txt_SearchData"
        Me.txt_SearchData.Size = New System.Drawing.Size(330, 20)
        Me.txt_SearchData.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Data"
        '
        'cb_searchBaseon
        '
        Me.cb_searchBaseon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_searchBaseon.FormattingEnabled = True
        Me.cb_searchBaseon.Location = New System.Drawing.Point(99, 22)
        Me.cb_searchBaseon.Name = "cb_searchBaseon"
        Me.cb_searchBaseon.Size = New System.Drawing.Size(158, 21)
        Me.cb_searchBaseon.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Berdasarkan"
        '
        'GridUtangBB
        '
        Me.GridUtangBB.AllowUserToAddRows = False
        Me.GridUtangBB.AllowUserToDeleteRows = False
        Me.GridUtangBB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridUtangBB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUtangBB.Location = New System.Drawing.Point(20, 185)
        Me.GridUtangBB.Name = "GridUtangBB"
        Me.GridUtangBB.ReadOnly = True
        Me.GridUtangBB.Size = New System.Drawing.Size(867, 299)
        Me.GridUtangBB.TabIndex = 56
        '
        'Frm_Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridUtangBB)
        Me.Name = "Frm_Test"
        Me.Text = "Frm_Test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridUtangBB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents txt_SearchData As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_searchBaseon As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridUtangBB As System.Windows.Forms.DataGridView
End Class
