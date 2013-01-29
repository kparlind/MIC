<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterQuestionSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterQuestionSet))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbTTLSection = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtSetID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btn_edit = New System.Windows.Forms.ToolStripButton
        Me.btn_delete = New System.Windows.Forms.ToolStripButton
        Me.btn_save = New System.Windows.Forms.ToolStripButton
        Me.btn_cancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_newquestion = New System.Windows.Forms.Button
        Me.btn_newsection = New System.Windows.Forms.Button
        Me.dgViewSet = New System.Windows.Forms.DataGridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgViewQuestion = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbCategory = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgViewSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgViewQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbCategory)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbTTLSection)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.txtSetID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(10, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 218)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Input"
        '
        'cbTTLSection
        '
        Me.cbTTLSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTTLSection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTTLSection.FormattingEnabled = True
        Me.cbTTLSection.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cbTTLSection.Location = New System.Drawing.Point(93, 161)
        Me.cbTTLSection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbTTLSection.Name = "cbTTLSection"
        Me.cbTTLSection.Size = New System.Drawing.Size(61, 21)
        Me.cbTTLSection.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Total Section"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.Color.Black
        Me.txtDescription.Location = New System.Drawing.Point(93, 78)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(271, 78)
        Me.txtDescription.TabIndex = 3
        '
        'txtSetID
        '
        Me.txtSetID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetID.ForeColor = System.Drawing.Color.Black
        Me.txtSetID.Location = New System.Drawing.Point(93, 26)
        Me.txtSetID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSetID.Name = "txtSetID"
        Me.txtSetID.Size = New System.Drawing.Size(115, 21)
        Me.txtSetID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Set ID"
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_edit, Me.btn_delete, Me.btn_save, Me.btn_cancel, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(584, 25)
        Me.ToolStrip.TabIndex = 14
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btn_edit
        '
        Me.btn_edit.Image = CType(resources.GetObject("btn_edit.Image"), System.Drawing.Image)
        Me.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_edit.Size = New System.Drawing.Size(52, 22)
        Me.btn_edit.Text = "Edit"
        '
        'btn_delete
        '
        Me.btn_delete.Image = CType(resources.GetObject("btn_delete.Image"), System.Drawing.Image)
        Me.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_delete.Size = New System.Drawing.Size(65, 22)
        Me.btn_delete.Text = "Delete"
        '
        'btn_save
        '
        Me.btn_save.Image = CType(resources.GetObject("btn_save.Image"), System.Drawing.Image)
        Me.btn_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_save.Size = New System.Drawing.Size(56, 22)
        Me.btn_save.Text = "Save"
        '
        'btn_cancel
        '
        Me.btn_cancel.Image = CType(resources.GetObject("btn_cancel.Image"), System.Drawing.Image)
        Me.btn_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_cancel.Size = New System.Drawing.Size(68, 22)
        Me.btn_cancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_newquestion)
        Me.GroupBox2.Controls.Add(Me.btn_newsection)
        Me.GroupBox2.Controls.Add(Me.dgViewSet)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 255)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 236)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SECTION"
        '
        'btn_newquestion
        '
        Me.btn_newquestion.Location = New System.Drawing.Point(468, 15)
        Me.btn_newquestion.Name = "btn_newquestion"
        Me.btn_newquestion.Size = New System.Drawing.Size(88, 23)
        Me.btn_newquestion.TabIndex = 17
        Me.btn_newquestion.Text = "New Question"
        Me.btn_newquestion.UseVisualStyleBackColor = True
        '
        'btn_newsection
        '
        Me.btn_newsection.Location = New System.Drawing.Point(374, 15)
        Me.btn_newsection.Name = "btn_newsection"
        Me.btn_newsection.Size = New System.Drawing.Size(88, 23)
        Me.btn_newsection.TabIndex = 17
        Me.btn_newsection.Text = "New Section"
        Me.btn_newsection.UseVisualStyleBackColor = True
        '
        'dgViewSet
        '
        Me.dgViewSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewSet.Location = New System.Drawing.Point(6, 43)
        Me.dgViewSet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgViewSet.Name = "dgViewSet"
        Me.dgViewSet.Size = New System.Drawing.Size(550, 183)
        Me.dgViewSet.TabIndex = 16
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgViewQuestion)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 497)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(562, 217)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "QUESTION"
        '
        'dgViewQuestion
        '
        Me.dgViewQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewQuestion.Location = New System.Drawing.Point(2, 19)
        Me.dgViewQuestion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgViewQuestion.Name = "dgViewQuestion"
        Me.dgViewQuestion.Size = New System.Drawing.Size(550, 183)
        Me.dgViewQuestion.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Category"
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Items.AddRange(New Object() {"Customer", "Supplier", "Outsourcing"})
        Me.cbCategory.Location = New System.Drawing.Point(93, 52)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(121, 21)
        Me.cbCategory.TabIndex = 18
        '
        'frmMasterQuestionSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 726)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMasterQuestionSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Master Question Set ::"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgViewSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgViewQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtSetID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTTLSection As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgViewSet As System.Windows.Forms.DataGridView
    Friend WithEvents btn_newsection As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_newquestion As System.Windows.Forms.Button
    Friend WithEvents dgViewQuestion As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
End Class
