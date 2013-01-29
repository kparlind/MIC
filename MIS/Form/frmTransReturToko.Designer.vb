<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransReturToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransReturToko))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtKeterangan = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPTNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtCust = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpReturDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReturNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnInsertDtl = New System.Windows.Forms.Button
        Me.txtItemReason = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtItemAmount = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtItemUnitPrice = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtItemQty = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtItemKemasan = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnCancelDtl = New System.Windows.Forms.Button
        Me.btnDeleteDtl = New System.Windows.Forms.Button
        Me.btnSaveDtl = New System.Windows.Forms.Button
        Me.btnEditDtl = New System.Windows.Forms.Button
        Me.txtItemUOM = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtItemID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gDetail = New System.Windows.Forms.DataGridView
        Me.txtTotalRetur = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ToolStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(982, 25)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cboType)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtKeterangan)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtPTNo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtCustName)
        Me.Panel1.Controls.Add(Me.txtCust)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpReturDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtReturNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(960, 155)
        Me.Panel1.TabIndex = 43
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"", "Rusak", "Salah Ukuran"})
        Me.cboType.Location = New System.Drawing.Point(140, 119)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(136, 21)
        Me.cboType.TabIndex = 56
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 14)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Retur Type"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKeterangan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeterangan.Location = New System.Drawing.Point(611, 42)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(338, 98)
        Me.txtKeterangan.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(535, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Keterangan"
        '
        'txtPTNo
        '
        Me.txtPTNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPTNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPTNo.Location = New System.Drawing.Point(140, 62)
        Me.txtPTNo.Name = "txtPTNo"
        Me.txtPTNo.Size = New System.Drawing.Size(108, 22)
        Me.txtPTNo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 14)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "No Invoice"
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(217, 90)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.Size = New System.Drawing.Size(201, 22)
        Me.txtCustName.TabIndex = 38
        '
        'txtCust
        '
        Me.txtCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCust.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(140, 90)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.ReadOnly = True
        Me.txtCust.Size = New System.Drawing.Size(72, 22)
        Me.txtCust.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Customer"
        '
        'dtpReturDate
        '
        Me.dtpReturDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpReturDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReturDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReturDate.Location = New System.Drawing.Point(140, 36)
        Me.dtpReturDate.Name = "dtpReturDate"
        Me.dtpReturDate.Size = New System.Drawing.Size(110, 22)
        Me.dtpReturDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tanggal Retur"
        '
        'txtReturNo
        '
        Me.txtReturNo.BackColor = System.Drawing.Color.LightGray
        Me.txtReturNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturNo.Location = New System.Drawing.Point(140, 9)
        Me.txtReturNo.Name = "txtReturNo"
        Me.txtReturNo.ReadOnly = True
        Me.txtReturNo.Size = New System.Drawing.Size(108, 22)
        Me.txtReturNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No Retur Penjualan"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnInsertDtl)
        Me.Panel2.Controls.Add(Me.txtItemReason)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtItemAmount)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtItemUnitPrice)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtItemQty)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtItemKemasan)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.btnCancelDtl)
        Me.Panel2.Controls.Add(Me.btnDeleteDtl)
        Me.Panel2.Controls.Add(Me.btnSaveDtl)
        Me.Panel2.Controls.Add(Me.btnEditDtl)
        Me.Panel2.Controls.Add(Me.txtItemUOM)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtItemID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(12, 197)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(961, 82)
        Me.Panel2.TabIndex = 45
        '
        'btnInsertDtl
        '
        Me.btnInsertDtl.Location = New System.Drawing.Point(7, 50)
        Me.btnInsertDtl.Name = "btnInsertDtl"
        Me.btnInsertDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnInsertDtl.TabIndex = 111
        Me.btnInsertDtl.Text = "Insert"
        Me.btnInsertDtl.UseVisualStyleBackColor = True
        '
        'txtItemReason
        '
        Me.txtItemReason.BackColor = System.Drawing.Color.LightGray
        Me.txtItemReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemReason.Location = New System.Drawing.Point(708, 24)
        Me.txtItemReason.Name = "txtItemReason"
        Me.txtItemReason.Size = New System.Drawing.Size(242, 22)
        Me.txtItemReason.TabIndex = 110
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(705, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 14)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Reason"
        '
        'txtItemAmount
        '
        Me.txtItemAmount.BackColor = System.Drawing.Color.LightGray
        Me.txtItemAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemAmount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemAmount.Location = New System.Drawing.Point(606, 24)
        Me.txtItemAmount.Name = "txtItemAmount"
        Me.txtItemAmount.ReadOnly = True
        Me.txtItemAmount.Size = New System.Drawing.Size(101, 22)
        Me.txtItemAmount.TabIndex = 108
        Me.txtItemAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(656, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 14)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Amount"
        '
        'txtItemUnitPrice
        '
        Me.txtItemUnitPrice.BackColor = System.Drawing.Color.LightGray
        Me.txtItemUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemUnitPrice.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemUnitPrice.Location = New System.Drawing.Point(504, 24)
        Me.txtItemUnitPrice.Name = "txtItemUnitPrice"
        Me.txtItemUnitPrice.ReadOnly = True
        Me.txtItemUnitPrice.Size = New System.Drawing.Size(101, 22)
        Me.txtItemUnitPrice.TabIndex = 106
        Me.txtItemUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(546, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 14)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Unit Price"
        '
        'txtItemQty
        '
        Me.txtItemQty.BackColor = System.Drawing.Color.LightGray
        Me.txtItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemQty.Location = New System.Drawing.Point(438, 24)
        Me.txtItemQty.Name = "txtItemQty"
        Me.txtItemQty.Size = New System.Drawing.Size(65, 22)
        Me.txtItemQty.TabIndex = 103
        Me.txtItemQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(476, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 14)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Qty"
        '
        'txtItemKemasan
        '
        Me.txtItemKemasan.BackColor = System.Drawing.Color.LightGray
        Me.txtItemKemasan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemKemasan.Location = New System.Drawing.Point(343, 24)
        Me.txtItemKemasan.Name = "txtItemKemasan"
        Me.txtItemKemasan.Size = New System.Drawing.Size(94, 22)
        Me.txtItemKemasan.TabIndex = 102
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(341, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 14)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Kemasan"
        '
        'btnCancelDtl
        '
        Me.btnCancelDtl.Location = New System.Drawing.Point(292, 50)
        Me.btnCancelDtl.Name = "btnCancelDtl"
        Me.btnCancelDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnCancelDtl.TabIndex = 13
        Me.btnCancelDtl.Text = "Cancel"
        Me.btnCancelDtl.UseVisualStyleBackColor = True
        '
        'btnDeleteDtl
        '
        Me.btnDeleteDtl.Location = New System.Drawing.Point(221, 50)
        Me.btnDeleteDtl.Name = "btnDeleteDtl"
        Me.btnDeleteDtl.Size = New System.Drawing.Size(71, 27)
        Me.btnDeleteDtl.TabIndex = 12
        Me.btnDeleteDtl.Text = "Delete"
        Me.btnDeleteDtl.UseVisualStyleBackColor = True
        '
        'btnSaveDtl
        '
        Me.btnSaveDtl.Location = New System.Drawing.Point(150, 50)
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
        Me.btnEditDtl.TabIndex = 10
        Me.btnEditDtl.Text = "Edit"
        Me.btnEditDtl.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gDetail.DefaultCellStyle = DataGridViewCellStyle2
        Me.gDetail.Location = New System.Drawing.Point(12, 285)
        Me.gDetail.Name = "gDetail"
        Me.gDetail.ReadOnly = True
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gDetail.Size = New System.Drawing.Size(960, 190)
        Me.gDetail.TabIndex = 44
        '
        'txtTotalRetur
        '
        Me.txtTotalRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalRetur.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetur.Location = New System.Drawing.Point(787, 487)
        Me.txtTotalRetur.Name = "txtTotalRetur"
        Me.txtTotalRetur.ReadOnly = True
        Me.txtTotalRetur.Size = New System.Drawing.Size(186, 24)
        Me.txtTotalRetur.TabIndex = 46
        Me.txtTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(694, 489)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 17)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Total Retur"
        '
        'frmTransReturToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 521)
        Me.Controls.Add(Me.txtTotalRetur)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gDetail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransReturToko"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Retur Toko ::"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Public WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Public WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPTNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpReturDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReturNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelDtl As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDtl As System.Windows.Forms.Button
    Friend WithEvents btnSaveDtl As System.Windows.Forms.Button
    Friend WithEvents btnEditDtl As System.Windows.Forms.Button
    Friend WithEvents txtItemUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtItemKemasan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItemQty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtItemReason As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtItemAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtItemUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnInsertDtl As System.Windows.Forms.Button
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalRetur As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
