<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MasterUtangBB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MasterUtangBB))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbCredit = New System.Windows.Forms.RadioButton
        Me.rbDebet = New System.Windows.Forms.RadioButton
        Me.cbxPeriod = New System.Windows.Forms.ComboBox
        Me.txtSuppID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtValue = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNamaSupp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.rbYes = New System.Windows.Forms.RadioButton
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_cari = New System.Windows.Forms.Button
        Me.txt_SearchData = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_searchBaseon = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GridUtangBB = New System.Windows.Forms.DataGridView
        Me.Panel2.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridUtangBB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.rbCredit)
        Me.Panel2.Controls.Add(Me.rbDebet)
        Me.Panel2.Controls.Add(Me.cbxPeriod)
        Me.Panel2.Controls.Add(Me.txtSuppID)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TxtValue)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtNamaSupp)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(891, 176)
        Me.Panel2.TabIndex = 53
        '
        'rbCredit
        '
        Me.rbCredit.AutoSize = True
        Me.rbCredit.Location = New System.Drawing.Point(159, 93)
        Me.rbCredit.Name = "rbCredit"
        Me.rbCredit.Size = New System.Drawing.Size(52, 17)
        Me.rbCredit.TabIndex = 72
        Me.rbCredit.Text = "Credit"
        Me.rbCredit.UseVisualStyleBackColor = True
        '
        'rbDebet
        '
        Me.rbDebet.AutoSize = True
        Me.rbDebet.Checked = True
        Me.rbDebet.Location = New System.Drawing.Point(99, 93)
        Me.rbDebet.Name = "rbDebet"
        Me.rbDebet.Size = New System.Drawing.Size(54, 17)
        Me.rbDebet.TabIndex = 71
        Me.rbDebet.TabStop = True
        Me.rbDebet.Text = "Debet"
        Me.rbDebet.UseVisualStyleBackColor = True
        '
        'cbxPeriod
        '
        Me.cbxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPeriod.FormattingEnabled = True
        Me.cbxPeriod.Location = New System.Drawing.Point(99, 8)
        Me.cbxPeriod.Name = "cbxPeriod"
        Me.cbxPeriod.Size = New System.Drawing.Size(121, 21)
        Me.cbxPeriod.TabIndex = 27
        '
        'txtSuppID
        '
        Me.txtSuppID.BackColor = System.Drawing.Color.DarkGray
        Me.txtSuppID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSuppID.Enabled = False
        Me.txtSuppID.Location = New System.Drawing.Point(100, 34)
        Me.txtSuppID.Name = "txtSuppID"
        Me.txtSuppID.Size = New System.Drawing.Size(91, 20)
        Me.txtSuppID.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Supplier ID"
        '
        'TxtValue
        '
        Me.TxtValue.BackColor = System.Drawing.Color.DarkGray
        Me.TxtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtValue.Enabled = False
        Me.TxtValue.Location = New System.Drawing.Point(100, 116)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.Size = New System.Drawing.Size(111, 20)
        Me.TxtValue.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Type"
        '
        'txtNamaSupp
        '
        Me.txtNamaSupp.BackColor = System.Drawing.Color.DarkGray
        Me.txtNamaSupp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaSupp.Enabled = False
        Me.txtNamaSupp.Location = New System.Drawing.Point(100, 60)
        Me.txtNamaSupp.Name = "txtNamaSupp"
        Me.txtNamaSupp.Size = New System.Drawing.Size(268, 20)
        Me.txtNamaSupp.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Nama Supplier"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Period"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(63, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCancel.Size = New System.Drawing.Size(64, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSave.Size = New System.Drawing.Size(56, 22)
        Me.btnSave.Text = "Save"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEdit.Size = New System.Drawing.Size(50, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnNew.Size = New System.Drawing.Size(53, 22)
        Me.btnNew.Text = "New"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.ToolStripSeparator1, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(891, 25)
        Me.ToolStrip.TabIndex = 54
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.rbYes)
        Me.Panel3.Controls.Add(Me.rbNo)
        Me.Panel3.Location = New System.Drawing.Point(11, 148)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 28)
        Me.Panel3.TabIndex = 85
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 72
        Me.Label31.Text = "Active"
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Checked = True
        Me.rbYes.Location = New System.Drawing.Point(88, 0)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(43, 17)
        Me.rbYes.TabIndex = 73
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(147, 0)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(39, 17)
        Me.rbNo.TabIndex = 74
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.txt_SearchData)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb_searchBaseon)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 201)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(891, 58)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Data"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(673, 19)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 23)
        Me.btn_cari.TabIndex = 4
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'txt_SearchData
        '
        Me.txt_SearchData.Location = New System.Drawing.Point(327, 22)
        Me.txt_SearchData.Name = "txt_SearchData"
        Me.txt_SearchData.Size = New System.Drawing.Size(330, 20)
        Me.txt_SearchData.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Keyword"
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
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Filter By"
        '
        'GridUtangBB
        '
        Me.GridUtangBB.AllowUserToAddRows = False
        Me.GridUtangBB.AllowUserToDeleteRows = False
        Me.GridUtangBB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridUtangBB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridUtangBB.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridUtangBB.Location = New System.Drawing.Point(0, 259)
        Me.GridUtangBB.Name = "GridUtangBB"
        Me.GridUtangBB.ReadOnly = True
        Me.GridUtangBB.Size = New System.Drawing.Size(891, 299)
        Me.GridUtangBB.TabIndex = 59
        '
        'Frm_MasterUtangBB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 589)
        Me.Controls.Add(Me.GridUtangBB)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "Frm_MasterUtangBB"
        Me.Text = "Master Utang Beginning Balance"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridUtangBB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cbxPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents txtSuppID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtValue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNamaSupp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents rbCredit As System.Windows.Forms.RadioButton
    Friend WithEvents rbDebet As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents txt_SearchData As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_searchBaseon As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridUtangBB As System.Windows.Forms.DataGridView
End Class
