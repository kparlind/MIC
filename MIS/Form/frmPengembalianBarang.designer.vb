<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPengembalianBarang
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPengembalianBarang))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cboItemCondition = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtItemRemarks = New System.Windows.Forms.TextBox
        Me.btnCancelDtl = New System.Windows.Forms.Button
        Me.btnDeleteDtl = New System.Windows.Forms.Button
        Me.btnSaveDtl = New System.Windows.Forms.Button
        Me.btnEditDtl = New System.Windows.Forms.Button
        Me.txtItemQty = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtItemUOM = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtItemID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gDetail = New System.Windows.Forms.DataGridView
        Me.Item_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_UOM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isGood = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.isRejectSupplier = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.isRejectPakai = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Item_Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtIndex = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtRefNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpTransDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.sep_Approver = New System.Windows.Forms.ToolStripSeparator
        Me.btnApprove = New System.Windows.Forms.ToolStripButton
        Me.btnReject = New System.Windows.Forms.ToolStripButton
        Me.Panel2.SuspendLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cboItemCondition)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txtItemRemarks)
        Me.Panel2.Controls.Add(Me.btnCancelDtl)
        Me.Panel2.Controls.Add(Me.btnDeleteDtl)
        Me.Panel2.Controls.Add(Me.btnSaveDtl)
        Me.Panel2.Controls.Add(Me.btnEditDtl)
        Me.Panel2.Controls.Add(Me.txtItemQty)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtItemUOM)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtItemID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(12, 199)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(926, 82)
        Me.Panel2.TabIndex = 31
        '
        'cboItemCondition
        '
        Me.cboItemCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemCondition.FormattingEnabled = True
        Me.cboItemCondition.Items.AddRange(New Object() {"", "Baik", "Reject Supplier", "Reject Pakai"})
        Me.cboItemCondition.Location = New System.Drawing.Point(427, 24)
        Me.cboItemCondition.Name = "cboItemCondition"
        Me.cboItemCondition.Size = New System.Drawing.Size(123, 22)
        Me.cboItemCondition.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(444, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 14)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Item Condition"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(552, 7)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 14)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Detail Remarks"
        '
        'txtItemRemarks
        '
        Me.txtItemRemarks.BackColor = System.Drawing.Color.LightGray
        Me.txtItemRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemRemarks.Location = New System.Drawing.Point(553, 24)
        Me.txtItemRemarks.Name = "txtItemRemarks"
        Me.txtItemRemarks.Size = New System.Drawing.Size(365, 22)
        Me.txtItemRemarks.TabIndex = 8
        '
        'btnCancelDtl
        '
        Me.btnCancelDtl.Location = New System.Drawing.Point(221, 50)
        Me.btnCancelDtl.Name = "btnCancelDtl"
        Me.btnCancelDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnCancelDtl.TabIndex = 13
        Me.btnCancelDtl.Text = "Cancel"
        Me.btnCancelDtl.UseVisualStyleBackColor = True
        '
        'btnDeleteDtl
        '
        Me.btnDeleteDtl.Location = New System.Drawing.Point(150, 50)
        Me.btnDeleteDtl.Name = "btnDeleteDtl"
        Me.btnDeleteDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnDeleteDtl.TabIndex = 12
        Me.btnDeleteDtl.Text = "Delete"
        Me.btnDeleteDtl.UseVisualStyleBackColor = True
        '
        'btnSaveDtl
        '
        Me.btnSaveDtl.Location = New System.Drawing.Point(79, 50)
        Me.btnSaveDtl.Name = "btnSaveDtl"
        Me.btnSaveDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnSaveDtl.TabIndex = 11
        Me.btnSaveDtl.Text = "Save"
        Me.btnSaveDtl.UseVisualStyleBackColor = True
        '
        'btnEditDtl
        '
        Me.btnEditDtl.Location = New System.Drawing.Point(7, 50)
        Me.btnEditDtl.Name = "btnEditDtl"
        Me.btnEditDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnEditDtl.TabIndex = 10
        Me.btnEditDtl.Text = "Edit"
        Me.btnEditDtl.UseVisualStyleBackColor = True
        '
        'txtItemQty
        '
        Me.txtItemQty.BackColor = System.Drawing.Color.LightGray
        Me.txtItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemQty.Location = New System.Drawing.Point(343, 24)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(81, 22)
        Me.txtItemQty.TabIndex = 6
        Me.txtItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(397, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 14)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Qty"
        '
        'txtItemUOM
        '
        Me.txtItemUOM.BackColor = System.Drawing.Color.LightGray
        Me.txtItemUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemUOM.Location = New System.Drawing.Point(294, 24)
        Me.txtItemUOM.Name = "txtItemUOM"
        Me.txtItemUOM.ReadOnly = True
        Me.txtItemUOM.Size = New System.Drawing.Size(48, 22)
        Me.txtItemUOM.TabIndex = 100
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(293, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 14)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "UOM"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.LightGray
        Me.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemName.Location = New System.Drawing.Point(79, 24)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(214, 22)
        Me.txtItemName.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Name"
        '
        'txtItemID
        '
        Me.txtItemID.BackColor = System.Drawing.Color.LightGray
        Me.txtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemID.Location = New System.Drawing.Point(7, 24)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Size = New System.Drawing.Size(71, 22)
        Me.txtItemID.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Item ID"
        '
        'gDetail
        '
        Me.gDetail.AllowUserToAddRows = False
        Me.gDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.gDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item_ID, Me.Item_Name, Me.Item_UOM, Me.Item_Qty, Me.isGood, Me.isRejectSupplier, Me.isRejectPakai, Me.Item_Remarks})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gDetail.DefaultCellStyle = DataGridViewCellStyle7
        Me.gDetail.Location = New System.Drawing.Point(11, 287)
        Me.gDetail.Name = "gDetail"
        Me.gDetail.ReadOnly = True
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gDetail.Size = New System.Drawing.Size(926, 190)
        Me.gDetail.TabIndex = 30
        '
        'Item_ID
        '
        Me.Item_ID.HeaderText = "Item ID"
        Me.Item_ID.Name = "Item_ID"
        Me.Item_ID.ReadOnly = True
        Me.Item_ID.ToolTipText = "Item's ID"
        Me.Item_ID.Width = 80
        '
        'Item_Name
        '
        Me.Item_Name.HeaderText = "Item Name"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.ReadOnly = True
        Me.Item_Name.ToolTipText = "Item's Name"
        Me.Item_Name.Width = 180
        '
        'Item_UOM
        '
        Me.Item_UOM.HeaderText = "UOM"
        Me.Item_UOM.Name = "Item_UOM"
        Me.Item_UOM.ReadOnly = True
        Me.Item_UOM.ToolTipText = "Item's UOM"
        Me.Item_UOM.Width = 70
        '
        'Item_Qty
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "#,##0"
        Me.Item_Qty.DefaultCellStyle = DataGridViewCellStyle6
        Me.Item_Qty.HeaderText = "Qty"
        Me.Item_Qty.Name = "Item_Qty"
        Me.Item_Qty.ReadOnly = True
        Me.Item_Qty.ToolTipText = "Item's Qty"
        '
        'isGood
        '
        Me.isGood.HeaderText = "Good"
        Me.isGood.Name = "isGood"
        Me.isGood.ReadOnly = True
        Me.isGood.ToolTipText = "Good Condition"
        Me.isGood.Width = 50
        '
        'isRejectSupplier
        '
        Me.isRejectSupplier.HeaderText = "Reject Supplier"
        Me.isRejectSupplier.Name = "isRejectSupplier"
        Me.isRejectSupplier.ReadOnly = True
        Me.isRejectSupplier.ToolTipText = "Reject to Supplier"
        Me.isRejectSupplier.Width = 90
        '
        'isRejectPakai
        '
        Me.isRejectPakai.HeaderText = "Reject Pakai"
        Me.isRejectPakai.Name = "isRejectPakai"
        Me.isRejectPakai.ReadOnly = True
        Me.isRejectPakai.ToolTipText = "Reject to be used"
        Me.isRejectPakai.Width = 80
        '
        'Item_Remarks
        '
        Me.Item_Remarks.HeaderText = "Remarks"
        Me.Item_Remarks.Name = "Item_Remarks"
        Me.Item_Remarks.ReadOnly = True
        Me.Item_Remarks.ToolTipText = "Detail remarks"
        Me.Item_Remarks.Width = 200
        '
        'txtIndex
        '
        Me.txtIndex.Location = New System.Drawing.Point(321, 340)
        Me.txtIndex.Name = "txtIndex"
        Me.txtIndex.Size = New System.Drawing.Size(131, 20)
        Me.txtIndex.TabIndex = 32
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.txtRefNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtRemarks)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtpTransDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtTransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboType)
        Me.Panel1.Location = New System.Drawing.Point(12, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(926, 154)
        Me.Panel1.TabIndex = 33
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(518, 15)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(387, 24)
        Me.lblStatus.TabIndex = 39
        Me.lblStatus.Text = "Label9"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRefNo
        '
        Me.txtRefNo.BackColor = System.Drawing.Color.White
        Me.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(97, 71)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(124, 22)
        Me.txtRefNo.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "BPB No."
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(97, 100)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(808, 46)
        Me.txtRemarks.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Remark"
        '
        'dtpTransDate
        '
        Me.dtpTransDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTransDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTransDate.Location = New System.Drawing.Point(97, 43)
        Me.dtpTransDate.Name = "dtpTransDate"
        Me.dtpTransDate.Size = New System.Drawing.Size(110, 22)
        Me.dtpTransDate.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Trans. Date"
        '
        'txtTransNo
        '
        Me.txtTransNo.BackColor = System.Drawing.Color.LightGray
        Me.txtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransNo.Enabled = False
        Me.txtTransNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNo.Location = New System.Drawing.Point(97, 15)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(108, 22)
        Me.txtTransNo.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Trans. No."
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"", "SPK", "Fabrikasi"})
        Me.cboType.Location = New System.Drawing.Point(162, 111)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(96, 21)
        Me.cboType.TabIndex = 31
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.sep_Approver, Me.btnApprove, Me.btnReject})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(949, 25)
        Me.ToolStrip.TabIndex = 41
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnNew.Size = New System.Drawing.Size(56, 22)
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEdit.Size = New System.Drawing.Size(52, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(65, 22)
        Me.btnDelete.Text = "Delete"
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
        Me.btnCancel.Size = New System.Drawing.Size(68, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'sep_Approver
        '
        Me.sep_Approver.Name = "sep_Approver"
        Me.sep_Approver.Size = New System.Drawing.Size(6, 25)
        '
        'btnApprove
        '
        Me.btnApprove.Image = CType(resources.GetObject("btnApprove.Image"), System.Drawing.Image)
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnApprove.Size = New System.Drawing.Size(89, 22)
        Me.btnApprove.Text = "Confirmed"
        '
        'btnReject
        '
        Me.btnReject.Image = CType(resources.GetObject("btnReject.Image"), System.Drawing.Image)
        Me.btnReject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnReject.Size = New System.Drawing.Size(64, 22)
        Me.btnReject.Text = "Reject"
        '
        'frmPengembalianBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 487)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gDetail)
        Me.Controls.Add(Me.txtIndex)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPengembalianBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Pengembalian Barang (Gudang) ::"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtItemRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelDtl As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDtl As System.Windows.Forms.Button
    Friend WithEvents btnSaveDtl As System.Windows.Forms.Button
    Friend WithEvents btnEditDtl As System.Windows.Forms.Button
    Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtItemUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gDetail As System.Windows.Forms.DataGridView
    Friend WithEvents cboItemCondition As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Item_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isGood As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isRejectSupplier As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isRejectPakai As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Item_Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtIndex As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Public WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep_Approver As System.Windows.Forms.ToolStripSeparator
    Public WithEvents btnApprove As System.Windows.Forms.ToolStripButton
    Public WithEvents btnReject As System.Windows.Forms.ToolStripButton
End Class
