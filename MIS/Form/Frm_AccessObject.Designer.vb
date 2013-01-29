<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AccessObject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AccessObject))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbObjGrp = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbAccID = New System.Windows.Forms.ComboBox
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.rbYes = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.GridAccObj = New System.Windows.Forms.DataGridView
        Me.ObjectDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INSERT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EDIT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DELETE = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.VIEW = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PRINT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EXPORT = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ObjectID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.GridAccObj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbObjGrp)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbAccID)
        Me.GroupBox2.Controls.Add(Me.rbNo)
        Me.GroupBox2.Controls.Add(Me.rbYes)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(877, 80)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        '
        'cbObjGrp
        '
        Me.cbObjGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObjGrp.FormattingEnabled = True
        Me.cbObjGrp.Location = New System.Drawing.Point(115, 40)
        Me.cbObjGrp.Name = "cbObjGrp"
        Me.cbObjGrp.Size = New System.Drawing.Size(210, 21)
        Me.cbObjGrp.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Object group"
        '
        'cbAccID
        '
        Me.cbAccID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAccID.FormattingEnabled = True
        Me.cbAccID.Location = New System.Drawing.Point(115, 13)
        Me.cbAccID.Name = "cbAccID"
        Me.cbAccID.Size = New System.Drawing.Size(210, 21)
        Me.cbAccID.TabIndex = 74
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(528, 19)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(39, 17)
        Me.rbNo.TabIndex = 68
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        Me.rbNo.Visible = False
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Checked = True
        Me.rbYes.Location = New System.Drawing.Point(479, 19)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(43, 17)
        Me.rbYes.TabIndex = 67
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        Me.rbYes.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(372, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Active"
        Me.Label13.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Access ID"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.ToolStripSeparator1, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(877, 25)
        Me.ToolStrip.TabIndex = 27
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnNew.Size = New System.Drawing.Size(53, 22)
        Me.btnNew.Text = "New"
        Me.btnNew.Visible = False
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
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(63, 22)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Visible = False
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
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCancel.Size = New System.Drawing.Size(64, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GridAccObj
        '
        Me.GridAccObj.AllowUserToAddRows = False
        Me.GridAccObj.AllowUserToDeleteRows = False
        Me.GridAccObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridAccObj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAccObj.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ObjectDesc, Me.INSERT, Me.EDIT, Me.DELETE, Me.VIEW, Me.PRINT, Me.EXPORT, Me.ObjectID})
        Me.GridAccObj.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridAccObj.Location = New System.Drawing.Point(0, 105)
        Me.GridAccObj.Name = "GridAccObj"
        Me.GridAccObj.Size = New System.Drawing.Size(877, 525)
        Me.GridAccObj.TabIndex = 28
        '
        'ObjectDesc
        '
        Me.ObjectDesc.HeaderText = "MENU"
        Me.ObjectDesc.Name = "ObjectDesc"
        Me.ObjectDesc.Width = 180
        '
        'INSERT
        '
        Me.INSERT.HeaderText = "INSERT"
        Me.INSERT.Name = "INSERT"
        '
        'EDIT
        '
        Me.EDIT.HeaderText = "EDIT"
        Me.EDIT.Name = "EDIT"
        '
        'DELETE
        '
        Me.DELETE.HeaderText = "DELETE"
        Me.DELETE.Name = "DELETE"
        '
        'VIEW
        '
        Me.VIEW.HeaderText = "VIEW"
        Me.VIEW.Name = "VIEW"
        '
        'PRINT
        '
        Me.PRINT.HeaderText = "PRINT"
        Me.PRINT.Name = "PRINT"
        '
        'EXPORT
        '
        Me.EXPORT.HeaderText = "EXPORT"
        Me.EXPORT.Name = "EXPORT"
        '
        'ObjectID
        '
        Me.ObjectID.HeaderText = "Menu ID"
        Me.ObjectID.Name = "ObjectID"
        Me.ObjectID.Visible = False
        '
        'Frm_AccessObject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 642)
        Me.Controls.Add(Me.GridAccObj)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "Frm_AccessObject"
        Me.Text = "Master Access Object"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.GridAccObj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbAccID As System.Windows.Forms.ComboBox
    Friend WithEvents GridAccObj As System.Windows.Forms.DataGridView
    Friend WithEvents ObjectDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INSERT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EDIT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DELETE As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VIEW As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PRINT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EXPORT As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ObjectID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbObjGrp As System.Windows.Forms.ComboBox
End Class
