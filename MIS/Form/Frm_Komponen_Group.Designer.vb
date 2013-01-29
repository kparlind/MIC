<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Komponen_Group
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Komponen_Group))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.txtNamaKompGrp = New System.Windows.Forms.TextBox
        Me.lblSupplierName = New System.Windows.Forms.Label
        Me.lblWarehouseName = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.rbYes = New System.Windows.Forms.RadioButton
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtKompGrpID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gv_item = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btn_cari = New System.Windows.Forms.Button
        Me.txt_SearchData = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cb_searchBaseon = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.gv_Hdr = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbxCategory = New System.Windows.Forms.ComboBox
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Ts_PO.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv_item, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gv_Hdr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(59, 22)
        Me.ts_cancel.Text = "Cancel"
        '
        'txtNamaKompGrp
        '
        Me.txtNamaKompGrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaKompGrp.Location = New System.Drawing.Point(142, 44)
        Me.txtNamaKompGrp.Name = "txtNamaKompGrp"
        Me.txtNamaKompGrp.Size = New System.Drawing.Size(163, 20)
        Me.txtNamaKompGrp.TabIndex = 71
        '
        'lblSupplierName
        '
        Me.lblSupplierName.AutoSize = True
        Me.lblSupplierName.Location = New System.Drawing.Point(192, 123)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(0, 13)
        Me.lblSupplierName.TabIndex = 85
        '
        'lblWarehouseName
        '
        Me.lblWarehouseName.AutoSize = True
        Me.lblWarehouseName.Location = New System.Drawing.Point(192, 99)
        Me.lblWarehouseName.Name = "lblWarehouseName"
        Me.lblWarehouseName.Size = New System.Drawing.Size(0, 13)
        Me.lblWarehouseName.TabIndex = 84
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.rbYes)
        Me.Panel3.Controls.Add(Me.rbNo)
        Me.Panel3.Location = New System.Drawing.Point(13, 100)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 28)
        Me.Panel3.TabIndex = 83
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
        Me.rbYes.Location = New System.Drawing.Point(103, 1)
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
        Me.rbNo.Location = New System.Drawing.Point(152, 1)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(39, 17)
        Me.rbNo.TabIndex = 74
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cbxCategory)
        Me.Panel1.Controls.Add(Me.lblSupplierName)
        Me.Panel1.Controls.Add(Me.lblWarehouseName)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.txtNamaKompGrp)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtKompGrpID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(842, 174)
        Me.Panel1.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Komponen Group"
        '
        'txtKompGrpID
        '
        Me.txtKompGrpID.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtKompGrpID.Enabled = False
        Me.txtKompGrpID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKompGrpID.Location = New System.Drawing.Point(142, 18)
        Me.txtKompGrpID.Name = "txtKompGrpID"
        Me.txtKompGrpID.Size = New System.Drawing.Size(50, 20)
        Me.txtKompGrpID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Komponen Group ID"
        '
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Size = New System.Drawing.Size(58, 22)
        Me.ts_delete.Text = "Delete"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(51, 22)
        Me.ts_save.Text = "Save"
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(842, 25)
        Me.Ts_PO.TabIndex = 41
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Size = New System.Drawing.Size(48, 22)
        Me.ts_New.Text = "New"
        '
        'ts_Edit
        '
        Me.ts_Edit.Image = CType(resources.GetObject("ts_Edit.Image"), System.Drawing.Image)
        Me.ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Edit.Name = "ts_Edit"
        Me.ts_Edit.Size = New System.Drawing.Size(45, 22)
        Me.ts_Edit.Text = "Edit"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.Txt_Qty)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Txt_UoM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_ItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_ItemID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 199)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(842, 82)
        Me.Panel2.TabIndex = 45
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(293, 50)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 20
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(222, 50)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(151, 50)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(79, 50)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 17
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(7, 50)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 16
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Location = New System.Drawing.Point(529, 24)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(63, 20)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(545, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Qty"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UoM.Enabled = False
        Me.Txt_UoM.Location = New System.Drawing.Point(479, 24)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(48, 20)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(481, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "UoM"
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(113, 24)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(365, 20)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(235, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Location = New System.Drawing.Point(7, 24)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(104, 20)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Item ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gv_item)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 281)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(842, 126)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Komponen"
        '
        'gv_item
        '
        Me.gv_item.AllowUserToAddRows = False
        Me.gv_item.AllowUserToDeleteRows = False
        Me.gv_item.Location = New System.Drawing.Point(12, 19)
        Me.gv_item.Name = "gv_item"
        Me.gv_item.ReadOnly = True
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_item.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gv_item.Size = New System.Drawing.Size(819, 101)
        Me.gv_item.TabIndex = 48
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox2.Controls.Add(Me.btn_cari)
        Me.GroupBox2.Controls.Add(Me.txt_SearchData)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cb_searchBaseon)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 407)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(842, 55)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Data"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(690, 19)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 23)
        Me.btn_cari.TabIndex = 4
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'txt_SearchData
        '
        Me.txt_SearchData.Location = New System.Drawing.Point(344, 22)
        Me.txt_SearchData.Name = "txt_SearchData"
        Me.txt_SearchData.Size = New System.Drawing.Size(330, 20)
        Me.txt_SearchData.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(287, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Keyword"
        '
        'cb_searchBaseon
        '
        Me.cb_searchBaseon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_searchBaseon.FormattingEnabled = True
        Me.cb_searchBaseon.Location = New System.Drawing.Point(108, 22)
        Me.cb_searchBaseon.Name = "cb_searchBaseon"
        Me.cb_searchBaseon.Size = New System.Drawing.Size(158, 21)
        Me.cb_searchBaseon.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Filter By"
        '
        'gv_Hdr
        '
        Me.gv_Hdr.AllowUserToAddRows = False
        Me.gv_Hdr.AllowUserToDeleteRows = False
        Me.gv_Hdr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gv_Hdr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_Hdr.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_Hdr.Location = New System.Drawing.Point(0, 462)
        Me.gv_Hdr.Name = "gv_Hdr"
        Me.gv_Hdr.ReadOnly = True
        Me.gv_Hdr.Size = New System.Drawing.Size(842, 235)
        Me.gv_Hdr.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Category"
        '
        'cbxCategory
        '
        Me.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCategory.FormattingEnabled = True
        Me.cbxCategory.Items.AddRange(New Object() {"Manifold", "Pipe To Kitchen", "Titik Api", "Supporting Material"})
        Me.cbxCategory.Location = New System.Drawing.Point(142, 70)
        Me.cbxCategory.Name = "cbxCategory"
        Me.cbxCategory.Size = New System.Drawing.Size(121, 21)
        Me.cbxCategory.TabIndex = 76
        '
        'Frm_Komponen_Group
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 687)
        Me.Controls.Add(Me.gv_Hdr)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Name = "Frm_Komponen_Group"
        Me.Text = "Master Komponen Group"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gv_item, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gv_Hdr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtNamaKompGrp As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblWarehouseName As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKompGrpID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gv_item As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents txt_SearchData As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cb_searchBaseon As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gv_Hdr As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxCategory As System.Windows.Forms.ComboBox
End Class
