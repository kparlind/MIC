<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPemakaianBahan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPemakaianBahan))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.sep_Approver = New System.Windows.Forms.ToolStripSeparator
        Me.btnApprove = New System.Windows.Forms.ToolStripButton
        Me.btnReject = New System.Windows.Forms.ToolStripButton
        Me.btnConfirmed = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtPHMNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtCustID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSPKNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpTransDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gDetail = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnDeleteDtl = New System.Windows.Forms.Button
        Me.txtItemCategory = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnInsertDtl = New System.Windows.Forms.Button
        Me.txtItemQtyUsed = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpItemDate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnCancelDtl = New System.Windows.Forms.Button
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
        Me.txtisPHM = New System.Windows.Forms.TextBox
        Me.txtProjectNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPHMTotal = New System.Windows.Forms.TextBox
        Me.txtActualTotal = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.sep_Approver, Me.btnApprove, Me.btnReject, Me.btnConfirmed})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(906, 25)
        Me.ToolStrip.TabIndex = 42
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
        Me.btnApprove.Size = New System.Drawing.Size(73, 22)
        Me.btnApprove.Text = "Approve"
        '
        'btnReject
        '
        Me.btnReject.Image = CType(resources.GetObject("btnReject.Image"), System.Drawing.Image)
        Me.btnReject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnReject.Size = New System.Drawing.Size(63, 22)
        Me.btnReject.Text = "Reject"
        '
        'btnConfirmed
        '
        Me.btnConfirmed.Image = CType(resources.GetObject("btnConfirmed.Image"), System.Drawing.Image)
        Me.btnConfirmed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfirmed.Name = "btnConfirmed"
        Me.btnConfirmed.Size = New System.Drawing.Size(76, 22)
        Me.btnConfirmed.Text = "Confirmed"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtPHMNo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.txtCustName)
        Me.Panel1.Controls.Add(Me.txtCustID)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtRemarks)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSPKNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpTransDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtTransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 162)
        Me.Panel1.TabIndex = 43
        '
        'txtPHMNo
        '
        Me.txtPHMNo.BackColor = System.Drawing.Color.White
        Me.txtPHMNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPHMNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPHMNo.Location = New System.Drawing.Point(113, 71)
        Me.txtPHMNo.Name = "txtPHMNo"
        Me.txtPHMNo.Size = New System.Drawing.Size(110, 22)
        Me.txtPHMNo.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 14)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "PHM No."
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(483, 11)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(387, 24)
        Me.lblStatus.TabIndex = 40
        Me.lblStatus.Text = "Label9"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(642, 71)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.Size = New System.Drawing.Size(228, 22)
        Me.txtCustName.TabIndex = 49
        '
        'txtCustID
        '
        Me.txtCustID.BackColor = System.Drawing.Color.LightGray
        Me.txtCustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustID.Location = New System.Drawing.Point(575, 71)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.ReadOnly = True
        Me.txtCustID.Size = New System.Drawing.Size(65, 22)
        Me.txtCustID.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(500, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 14)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Customer"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.White
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(113, 100)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(757, 46)
        Me.txtRemarks.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Remark"
        '
        'txtSPKNo
        '
        Me.txtSPKNo.BackColor = System.Drawing.Color.LightGray
        Me.txtSPKNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSPKNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPKNo.Location = New System.Drawing.Point(575, 43)
        Me.txtSPKNo.Name = "txtSPKNo"
        Me.txtSPKNo.ReadOnly = True
        Me.txtSPKNo.Size = New System.Drawing.Size(110, 22)
        Me.txtSPKNo.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(500, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "SPK No"
        '
        'dtpTransDate
        '
        Me.dtpTransDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpTransDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTransDate.Location = New System.Drawing.Point(113, 44)
        Me.dtpTransDate.Name = "dtpTransDate"
        Me.dtpTransDate.Size = New System.Drawing.Size(110, 22)
        Me.dtpTransDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Trans. Date"
        '
        'txtTransNo
        '
        Me.txtTransNo.BackColor = System.Drawing.Color.LightGray
        Me.txtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransNo.Enabled = False
        Me.txtTransNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransNo.Location = New System.Drawing.Point(113, 14)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(108, 22)
        Me.txtTransNo.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Trans. No."
        '
        'gDetail
        '
        Me.gDetail.AllowUserToAddRows = False
        Me.gDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gDetail.DefaultCellStyle = DataGridViewCellStyle5
        Me.gDetail.Location = New System.Drawing.Point(12, 294)
        Me.gDetail.Name = "gDetail"
        Me.gDetail.ReadOnly = True
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gDetail.Size = New System.Drawing.Size(885, 190)
        Me.gDetail.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnDeleteDtl)
        Me.Panel2.Controls.Add(Me.txtItemCategory)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.btnInsertDtl)
        Me.Panel2.Controls.Add(Me.txtItemQtyUsed)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.dtpItemDate)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.btnCancelDtl)
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
        Me.Panel2.Location = New System.Drawing.Point(12, 206)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(885, 82)
        Me.Panel2.TabIndex = 45
        '
        'btnDeleteDtl
        '
        Me.btnDeleteDtl.Location = New System.Drawing.Point(149, 50)
        Me.btnDeleteDtl.Name = "btnDeleteDtl"
        Me.btnDeleteDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnDeleteDtl.TabIndex = 108
        Me.btnDeleteDtl.Text = "Delete"
        Me.btnDeleteDtl.UseVisualStyleBackColor = True
        '
        'txtItemCategory
        '
        Me.txtItemCategory.BackColor = System.Drawing.Color.LightGray
        Me.txtItemCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCategory.Location = New System.Drawing.Point(343, 24)
        Me.txtItemCategory.Name = "txtItemCategory"
        Me.txtItemCategory.ReadOnly = True
        Me.txtItemCategory.Size = New System.Drawing.Size(148, 22)
        Me.txtItemCategory.TabIndex = 107
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(342, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 14)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "Item Category"
        '
        'btnInsertDtl
        '
        Me.btnInsertDtl.Location = New System.Drawing.Point(7, 50)
        Me.btnInsertDtl.Name = "btnInsertDtl"
        Me.btnInsertDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnInsertDtl.TabIndex = 105
        Me.btnInsertDtl.Text = "Insert"
        Me.btnInsertDtl.UseVisualStyleBackColor = True
        '
        'txtItemQtyUsed
        '
        Me.txtItemQtyUsed.BackColor = System.Drawing.Color.LightGray
        Me.txtItemQtyUsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemQtyUsed.Location = New System.Drawing.Point(688, 24)
        Me.txtItemQtyUsed.Name = "txtItemQtyUsed"
        Me.txtItemQtyUsed.Size = New System.Drawing.Size(81, 22)
        Me.txtItemQtyUsed.TabIndex = 103
        Me.txtItemQtyUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(711, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 14)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Qty Used"
        '
        'dtpItemDate
        '
        Me.dtpItemDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpItemDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpItemDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpItemDate.Location = New System.Drawing.Point(576, 24)
        Me.dtpItemDate.Name = "dtpItemDate"
        Me.dtpItemDate.Size = New System.Drawing.Size(110, 22)
        Me.dtpItemDate.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(573, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 14)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Using Date"
        '
        'btnCancelDtl
        '
        Me.btnCancelDtl.Location = New System.Drawing.Point(293, 50)
        Me.btnCancelDtl.Name = "btnCancelDtl"
        Me.btnCancelDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnCancelDtl.TabIndex = 13
        Me.btnCancelDtl.Text = "Cancel"
        Me.btnCancelDtl.UseVisualStyleBackColor = True
        '
        'btnSaveDtl
        '
        Me.btnSaveDtl.Location = New System.Drawing.Point(222, 50)
        Me.btnSaveDtl.Name = "btnSaveDtl"
        Me.btnSaveDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnSaveDtl.TabIndex = 11
        Me.btnSaveDtl.Text = "Save"
        Me.btnSaveDtl.UseVisualStyleBackColor = True
        '
        'btnEditDtl
        '
        Me.btnEditDtl.Location = New System.Drawing.Point(78, 50)
        Me.btnEditDtl.Name = "btnEditDtl"
        Me.btnEditDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnEditDtl.TabIndex = 4
        Me.btnEditDtl.Text = "Edit"
        Me.btnEditDtl.UseVisualStyleBackColor = True
        '
        'txtItemQty
        '
        Me.txtItemQty.BackColor = System.Drawing.Color.LightGray
        Me.txtItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemQty.Location = New System.Drawing.Point(493, 24)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(81, 22)
        Me.txtItemQty.TabIndex = 6
        Me.txtItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(500, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 14)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Qty Planned"
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
        'txtisPHM
        '
        Me.txtisPHM.Location = New System.Drawing.Point(361, 336)
        Me.txtisPHM.Name = "txtisPHM"
        Me.txtisPHM.Size = New System.Drawing.Size(79, 20)
        Me.txtisPHM.TabIndex = 46
        '
        'txtProjectNo
        '
        Me.txtProjectNo.Location = New System.Drawing.Point(62, 319)
        Me.txtProjectNo.Name = "txtProjectNo"
        Me.txtProjectNo.Size = New System.Drawing.Size(83, 20)
        Me.txtProjectNo.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 499)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 14)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "PHM Items Used"
        '
        'txtPHMTotal
        '
        Me.txtPHMTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPHMTotal.Location = New System.Drawing.Point(126, 496)
        Me.txtPHMTotal.Name = "txtPHMTotal"
        Me.txtPHMTotal.ReadOnly = True
        Me.txtPHMTotal.Size = New System.Drawing.Size(142, 22)
        Me.txtPHMTotal.TabIndex = 49
        Me.txtPHMTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtActualTotal
        '
        Me.txtActualTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActualTotal.Location = New System.Drawing.Point(755, 496)
        Me.txtActualTotal.Name = "txtActualTotal"
        Me.txtActualTotal.ReadOnly = True
        Me.txtActualTotal.Size = New System.Drawing.Size(142, 22)
        Me.txtActualTotal.TabIndex = 51
        Me.txtActualTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(628, 499)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 14)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Actual Items Used"
        '
        'frmPemakaianBahan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 527)
        Me.Controls.Add(Me.txtActualTotal)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPHMTotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gDetail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtisPHM)
        Me.Controls.Add(Me.txtProjectNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPemakaianBahan"
        Me.Text = ":: Material Used ::"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Public WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep_Approver As System.Windows.Forms.ToolStripSeparator
    Public WithEvents btnApprove As System.Windows.Forms.ToolStripButton
    Public WithEvents btnReject As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents dtpTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSPKNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtItemQtyUsed As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpItemDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelDtl As System.Windows.Forms.Button
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
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPHMNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnConfirmed As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnInsertDtl As System.Windows.Forms.Button
    Friend WithEvents txtItemCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteDtl As System.Windows.Forms.Button
    Friend WithEvents txtisPHM As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPHMTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtActualTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
