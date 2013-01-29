<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPenjualanToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPenjualanToko))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.cb_CustGroupPrice = New System.Windows.Forms.ComboBox
        Me.dt_InvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.lbl_SuppName = New System.Windows.Forms.Label
        Me.txt_CustName = New System.Windows.Forms.TextBox
        Me.txt_CustID = New System.Windows.Forms.TextBox
        Me.lbl_Supplier = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.txt_SubTotalTemp = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_Diskon = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_Harga = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gv_Toko = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txt_TotalQty = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_Remark = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Gb_PaymentType = New System.Windows.Forms.GroupBox
        Me.dt_PayType = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_UangMuka = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_SubDiskon = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_GrandTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_PPN = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_SubTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gv_Toko, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Gb_PaymentType.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save, Me.ts_delete, Me.ts_cancel})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1058, 25)
        Me.Ts_PO.TabIndex = 3
        Me.Ts_PO.Text = "PO"
        '
        'ts_Edit
        '
        Me.ts_Edit.Image = CType(resources.GetObject("ts_Edit.Image"), System.Drawing.Image)
        Me.ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Edit.Name = "ts_Edit"
        Me.ts_Edit.Size = New System.Drawing.Size(47, 22)
        Me.ts_Edit.Text = "Edit"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(51, 22)
        Me.ts_save.Text = "Save"
        '
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Size = New System.Drawing.Size(60, 22)
        Me.ts_delete.Text = "Delete"
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(63, 22)
        Me.ts_cancel.Text = "Cancel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cb_CustGroupPrice)
        Me.Panel1.Controls.Add(Me.dt_InvoiceDate)
        Me.Panel1.Controls.Add(Me.lbl_SuppName)
        Me.Panel1.Controls.Add(Me.txt_CustName)
        Me.Panel1.Controls.Add(Me.txt_CustID)
        Me.Panel1.Controls.Add(Me.lbl_Supplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 116)
        Me.Panel1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Group Price"
        '
        'cb_CustGroupPrice
        '
        Me.cb_CustGroupPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CustGroupPrice.Enabled = False
        Me.cb_CustGroupPrice.FormattingEnabled = True
        Me.cb_CustGroupPrice.Items.AddRange(New Object() {"", "Instalasi", "Kontraktor", "Teknisi", "End User"})
        Me.cb_CustGroupPrice.Location = New System.Drawing.Point(572, 70)
        Me.cb_CustGroupPrice.Name = "cb_CustGroupPrice"
        Me.cb_CustGroupPrice.Size = New System.Drawing.Size(170, 22)
        Me.cb_CustGroupPrice.TabIndex = 34
        '
        'dt_InvoiceDate
        '
        Me.dt_InvoiceDate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_InvoiceDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_InvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_InvoiceDate.Location = New System.Drawing.Point(134, 46)
        Me.dt_InvoiceDate.Name = "dt_InvoiceDate"
        Me.dt_InvoiceDate.Size = New System.Drawing.Size(184, 22)
        Me.dt_InvoiceDate.TabIndex = 32
        '
        'lbl_SuppName
        '
        Me.lbl_SuppName.AutoSize = True
        Me.lbl_SuppName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SuppName.Location = New System.Drawing.Point(447, 47)
        Me.lbl_SuppName.Name = "lbl_SuppName"
        Me.lbl_SuppName.Size = New System.Drawing.Size(94, 14)
        Me.lbl_SuppName.TabIndex = 19
        Me.lbl_SuppName.Text = "Customer Name"
        '
        'txt_CustName
        '
        Me.txt_CustName.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_CustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CustName.Enabled = False
        Me.txt_CustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CustName.Location = New System.Drawing.Point(572, 45)
        Me.txt_CustName.Name = "txt_CustName"
        Me.txt_CustName.Size = New System.Drawing.Size(353, 22)
        Me.txt_CustName.TabIndex = 6
        '
        'txt_CustID
        '
        Me.txt_CustID.BackColor = System.Drawing.SystemColors.Window
        Me.txt_CustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CustID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CustID.Location = New System.Drawing.Point(572, 20)
        Me.txt_CustID.Name = "txt_CustID"
        Me.txt_CustID.Size = New System.Drawing.Size(60, 22)
        Me.txt_CustID.TabIndex = 5
        '
        'lbl_Supplier
        '
        Me.lbl_Supplier.AutoSize = True
        Me.lbl_Supplier.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplier.Location = New System.Drawing.Point(447, 24)
        Me.lbl_Supplier.Name = "lbl_Supplier"
        Me.lbl_Supplier.Size = New System.Drawing.Size(59, 14)
        Me.lbl_Supplier.TabIndex = 4
        Me.lbl_Supplier.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Invoice Date"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TransNo.Location = New System.Drawing.Point(134, 23)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(126, 22)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice No."
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.txt_SubTotalTemp)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txt_Diskon)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txt_Harga)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Txt_Qty)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Txt_UoM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_ItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_ItemID)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 141)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1058, 88)
        Me.Panel2.TabIndex = 25
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(342, 54)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(83, 29)
        Me.Btn_cancel.TabIndex = 20
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(259, 54)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(83, 29)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(176, 54)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(83, 29)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(92, 54)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(83, 29)
        Me.btn_edit.TabIndex = 17
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(8, 54)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(83, 29)
        Me.btn_insert.TabIndex = 16
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'txt_SubTotalTemp
        '
        Me.txt_SubTotalTemp.BackColor = System.Drawing.Color.DarkGray
        Me.txt_SubTotalTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubTotalTemp.Enabled = False
        Me.txt_SubTotalTemp.Location = New System.Drawing.Point(698, 26)
        Me.txt_SubTotalTemp.Name = "txt_SubTotalTemp"
        Me.txt_SubTotalTemp.Size = New System.Drawing.Size(192, 22)
        Me.txt_SubTotalTemp.TabIndex = 15
        Me.txt_SubTotalTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(759, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 14)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "SubTotal"
        '
        'txt_Diskon
        '
        Me.txt_Diskon.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Diskon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Diskon.Location = New System.Drawing.Point(603, 26)
        Me.txt_Diskon.Name = "txt_Diskon"
        Me.txt_Diskon.Size = New System.Drawing.Size(92, 22)
        Me.txt_Diskon.TabIndex = 13
        Me.txt_Diskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(624, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 14)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Discount"
        '
        'txt_Harga
        '
        Me.txt_Harga.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Harga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Harga.Enabled = False
        Me.txt_Harga.Location = New System.Drawing.Point(498, 26)
        Me.txt_Harga.Name = "txt_Harga"
        Me.txt_Harga.Size = New System.Drawing.Size(102, 22)
        Me.txt_Harga.TabIndex = 11
        Me.txt_Harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(527, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 14)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Price"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(441, 26)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(54, 22)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(457, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 14)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Qty"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UoM.Enabled = False
        Me.Txt_UoM.Location = New System.Drawing.Point(383, 26)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(56, 22)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(390, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 14)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "UoM"
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(92, 26)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(289, 22)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(171, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Location = New System.Drawing.Point(8, 26)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(82, 22)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item ID"
        '
        'gv_Toko
        '
        Me.gv_Toko.AllowUserToAddRows = False
        Me.gv_Toko.AllowUserToDeleteRows = False
        Me.gv_Toko.AllowUserToOrderColumns = True
        Me.gv_Toko.AllowUserToResizeColumns = False
        Me.gv_Toko.AllowUserToResizeRows = False
        Me.gv_Toko.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_Toko.Location = New System.Drawing.Point(0, 229)
        Me.gv_Toko.Name = "gv_Toko"
        Me.gv_Toko.ReadOnly = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_Toko.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gv_Toko.Size = New System.Drawing.Size(1058, 212)
        Me.gv_Toko.TabIndex = 26
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txt_TotalQty)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txt_Remark)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Gb_PaymentType)
        Me.Panel3.Controls.Add(Me.txt_UangMuka)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txt_SubDiskon)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txt_GrandTotal)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txt_PPN)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txt_SubTotal)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 441)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1058, 150)
        Me.Panel3.TabIndex = 27
        '
        'txt_TotalQty
        '
        Me.txt_TotalQty.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TotalQty.Enabled = False
        Me.txt_TotalQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalQty.Location = New System.Drawing.Point(486, 8)
        Me.txt_TotalQty.Name = "txt_TotalQty"
        Me.txt_TotalQty.Size = New System.Drawing.Size(51, 23)
        Me.txt_TotalQty.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(482, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 14)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Total Qty"
        '
        'txt_Remark
        '
        Me.txt_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remark.Location = New System.Drawing.Point(9, 32)
        Me.txt_Remark.Multiline = True
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(340, 104)
        Me.txt_Remark.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Remarks"
        '
        'Gb_PaymentType
        '
        Me.Gb_PaymentType.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Gb_PaymentType.Controls.Add(Me.dt_PayType)
        Me.Gb_PaymentType.Controls.Add(Me.Label14)
        Me.Gb_PaymentType.Location = New System.Drawing.Point(383, 72)
        Me.Gb_PaymentType.Name = "Gb_PaymentType"
        Me.Gb_PaymentType.Size = New System.Drawing.Size(351, 62)
        Me.Gb_PaymentType.TabIndex = 34
        Me.Gb_PaymentType.TabStop = False
        Me.Gb_PaymentType.Text = "Payment Type"
        '
        'dt_PayType
        '
        Me.dt_PayType.CustomFormat = "dd-MMM-yyyy"
        Me.dt_PayType.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_PayType.Location = New System.Drawing.Point(104, 23)
        Me.dt_PayType.Name = "dt_PayType"
        Me.dt_PayType.Size = New System.Drawing.Size(222, 22)
        Me.dt_PayType.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 14)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Jatuh Tempo"
        '
        'txt_UangMuka
        '
        Me.txt_UangMuka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UangMuka.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UangMuka.Location = New System.Drawing.Point(871, 114)
        Me.txt_UangMuka.Name = "txt_UangMuka"
        Me.txt_UangMuka.Size = New System.Drawing.Size(172, 23)
        Me.txt_UangMuka.TabIndex = 33
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(774, 116)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 14)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Down Payment"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SubDiskon
        '
        Me.txt_SubDiskon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubDiskon.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubDiskon.Location = New System.Drawing.Point(871, 30)
        Me.txt_SubDiskon.Name = "txt_SubDiskon"
        Me.txt_SubDiskon.Size = New System.Drawing.Size(172, 23)
        Me.txt_SubDiskon.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(811, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 14)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Discount"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_GrandTotal
        '
        Me.txt_GrandTotal.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_GrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GrandTotal.Enabled = False
        Me.txt_GrandTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GrandTotal.Location = New System.Drawing.Point(871, 89)
        Me.txt_GrandTotal.Name = "txt_GrandTotal"
        Me.txt_GrandTotal.Size = New System.Drawing.Size(172, 23)
        Me.txt_GrandTotal.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(794, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 14)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Grand Total"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_PPN
        '
        Me.txt_PPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PPN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PPN.Location = New System.Drawing.Point(871, 54)
        Me.txt_PPN.Name = "txt_PPN"
        Me.txt_PPN.Size = New System.Drawing.Size(172, 23)
        Me.txt_PPN.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(810, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 14)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "PPN (%)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SubTotal
        '
        Me.txt_SubTotal.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_SubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubTotal.Enabled = False
        Me.txt_SubTotal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubTotal.Location = New System.Drawing.Point(871, 6)
        Me.txt_SubTotal.Name = "txt_SubTotal"
        Me.txt_SubTotal.Size = New System.Drawing.Size(172, 23)
        Me.txt_SubTotal.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(805, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Sub Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmPenjualanToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 596)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.gv_Toko)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPenjualanToko"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Penjualan Toko"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gv_Toko, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Gb_PaymentType.ResumeLayout(False)
        Me.Gb_PaymentType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_InvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_SuppName As System.Windows.Forms.Label
    Friend WithEvents txt_CustName As System.Windows.Forms.TextBox
    Friend WithEvents txt_CustID As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Supplier As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txt_SubTotalTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Diskon As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_Harga As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gv_Toko As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_UangMuka As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_SubDiskon As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_GrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_PPN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_SubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Gb_PaymentType As System.Windows.Forms.GroupBox
    Friend WithEvents dt_PayType As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalQty As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_CustGroupPrice As System.Windows.Forms.ComboBox
End Class
