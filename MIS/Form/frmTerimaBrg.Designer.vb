<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerimaBrg
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTerimaBrg))
        Me.gv_PODtl = New System.Windows.Forms.DataGridView
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_SubTotal = New System.Windows.Forms.TextBox
        Me.txt_PPN = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_GrandTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_TotalQty = New System.Windows.Forms.TextBox
        Me.txt_Remark = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Gb_PaymentType = New System.Windows.Forms.GroupBox
        Me.dt_PayType = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_pengiriman = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_UangMuka = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_Supplier = New System.Windows.Forms.Label
        Me.txt_SupplierID = New System.Windows.Forms.TextBox
        Me.txt_SupplierName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cb_Gudang = New System.Windows.Forms.ComboBox
        Me.lbl_SuppName = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_PONo = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_Invoice = New System.Windows.Forms.TextBox
        Me.lbl_Invoice = New System.Windows.Forms.Label
        Me.txt_SJalan = New System.Windows.Forms.TextBox
        Me.lbl_SJalan = New System.Windows.Forms.Label
        Me.dt_LPBDate = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label24 = New System.Windows.Forms.Label
        Me.cb_quality = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_PRNo = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_Ket = New System.Windows.Forms.TextBox
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
        Me.Txt_QtyRec = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_TotalQtyRec = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_Reason = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        CType(Me.gv_PODtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.Gb_PaymentType.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gv_PODtl
        '
        Me.gv_PODtl.AllowUserToAddRows = False
        Me.gv_PODtl.AllowUserToDeleteRows = False
        Me.gv_PODtl.AllowUserToOrderColumns = True
        Me.gv_PODtl.AllowUserToResizeColumns = False
        Me.gv_PODtl.AllowUserToResizeRows = False
        Me.gv_PODtl.Location = New System.Drawing.Point(14, 249)
        Me.gv_PODtl.Name = "gv_PODtl"
        Me.gv_PODtl.ReadOnly = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_PODtl.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gv_PODtl.Size = New System.Drawing.Size(1191, 212)
        Me.gv_PODtl.TabIndex = 1
        '
        'Ts_PO
        '
        Me.Ts_PO.BackColor = System.Drawing.Color.DarkGray
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save, Me.ts_approve, Me.ts_reject, Me.ts_delete, Me.ts_cancel})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1217, 25)
        Me.Ts_PO.TabIndex = 2
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
        Me.ts_save.Size = New System.Drawing.Size(65, 22)
        Me.ts_save.Text = "Submit"
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(63, 22)
        Me.ts_cancel.Text = "Cancel"
        '
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Size = New System.Drawing.Size(60, 22)
        Me.ts_delete.Text = "Delete"
        '
        'ts_approve
        '
        Me.ts_approve.Image = CType(resources.GetObject("ts_approve.Image"), System.Drawing.Image)
        Me.ts_approve.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_approve.Name = "ts_approve"
        Me.ts_approve.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_approve.Size = New System.Drawing.Size(77, 22)
        Me.ts_approve.Text = "Approve"
        '
        'ts_reject
        '
        Me.ts_reject.Image = CType(resources.GetObject("ts_reject.Image"), System.Drawing.Image)
        Me.ts_reject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_reject.Name = "ts_reject"
        Me.ts_reject.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_reject.Size = New System.Drawing.Size(64, 22)
        Me.ts_reject.Text = "Reject"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(981, 470)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Sub Total"
        '
        'txt_SubTotal
        '
        Me.txt_SubTotal.BackColor = System.Drawing.Color.LightGray
        Me.txt_SubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_SubTotal.Location = New System.Drawing.Point(1052, 466)
        Me.txt_SubTotal.Name = "txt_SubTotal"
        Me.txt_SubTotal.ReadOnly = True
        Me.txt_SubTotal.Size = New System.Drawing.Size(151, 22)
        Me.txt_SubTotal.TabIndex = 4
        '
        'txt_PPN
        '
        Me.txt_PPN.BackColor = System.Drawing.Color.LightGray
        Me.txt_PPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PPN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PPN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_PPN.Location = New System.Drawing.Point(1052, 489)
        Me.txt_PPN.Name = "txt_PPN"
        Me.txt_PPN.ReadOnly = True
        Me.txt_PPN.Size = New System.Drawing.Size(151, 22)
        Me.txt_PPN.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(989, 490)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 14)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "PPN (%)"
        '
        'txt_GrandTotal
        '
        Me.txt_GrandTotal.BackColor = System.Drawing.Color.LightGray
        Me.txt_GrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GrandTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GrandTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_GrandTotal.Location = New System.Drawing.Point(1052, 564)
        Me.txt_GrandTotal.Name = "txt_GrandTotal"
        Me.txt_GrandTotal.ReadOnly = True
        Me.txt_GrandTotal.Size = New System.Drawing.Size(151, 22)
        Me.txt_GrandTotal.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(970, 566)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 14)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Grand Total"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(562, 494)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 14)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Total Qty"
        '
        'txt_TotalQty
        '
        Me.txt_TotalQty.BackColor = System.Drawing.Color.LightGray
        Me.txt_TotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TotalQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_TotalQty.Location = New System.Drawing.Point(521, 466)
        Me.txt_TotalQty.Name = "txt_TotalQty"
        Me.txt_TotalQty.ReadOnly = True
        Me.txt_TotalQty.Size = New System.Drawing.Size(97, 22)
        Me.txt_TotalQty.TabIndex = 10
        '
        'txt_Remark
        '
        Me.txt_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remark.Location = New System.Drawing.Point(16, 488)
        Me.txt_Remark.Multiline = True
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(481, 48)
        Me.txt_Remark.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 470)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Remark"
        '
        'Gb_PaymentType
        '
        Me.Gb_PaymentType.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Gb_PaymentType.Controls.Add(Me.dt_PayType)
        Me.Gb_PaymentType.Controls.Add(Me.Label14)
        Me.Gb_PaymentType.Location = New System.Drawing.Point(521, 567)
        Me.Gb_PaymentType.Name = "Gb_PaymentType"
        Me.Gb_PaymentType.Size = New System.Drawing.Size(256, 62)
        Me.Gb_PaymentType.TabIndex = 19
        Me.Gb_PaymentType.TabStop = False
        Me.Gb_PaymentType.Text = "Payment Type"
        '
        'dt_PayType
        '
        Me.dt_PayType.CustomFormat = "dd-MMM-yyyy"
        Me.dt_PayType.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_PayType.Location = New System.Drawing.Point(91, 20)
        Me.dt_PayType.Name = "dt_PayType"
        Me.dt_PayType.Size = New System.Drawing.Size(135, 22)
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(968, 516)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 14)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Delivery Fee"
        '
        'txt_pengiriman
        '
        Me.txt_pengiriman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pengiriman.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pengiriman.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_pengiriman.Location = New System.Drawing.Point(1052, 514)
        Me.txt_pengiriman.Name = "txt_pengiriman"
        Me.txt_pengiriman.Size = New System.Drawing.Size(151, 22)
        Me.txt_pengiriman.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(950, 541)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 14)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Down Payment"
        '
        'txt_UangMuka
        '
        Me.txt_UangMuka.BackColor = System.Drawing.Color.LightGray
        Me.txt_UangMuka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UangMuka.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UangMuka.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_UangMuka.Location = New System.Drawing.Point(1052, 539)
        Me.txt_UangMuka.Name = "txt_UangMuka"
        Me.txt_UangMuka.ReadOnly = True
        Me.txt_UangMuka.Size = New System.Drawing.Size(151, 22)
        Me.txt_UangMuka.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No LPB"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.Color.LightGray
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.ForeColor = System.Drawing.Color.Gray
        Me.txt_TransNo.Location = New System.Drawing.Point(107, 13)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.ReadOnly = True
        Me.txt_TransNo.Size = New System.Drawing.Size(199, 22)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tgl LPB"
        '
        'lbl_Supplier
        '
        Me.lbl_Supplier.AutoSize = True
        Me.lbl_Supplier.Location = New System.Drawing.Point(472, 15)
        Me.lbl_Supplier.Name = "lbl_Supplier"
        Me.lbl_Supplier.Size = New System.Drawing.Size(50, 14)
        Me.lbl_Supplier.TabIndex = 4
        Me.lbl_Supplier.Text = "Supplier"
        '
        'txt_SupplierID
        '
        Me.txt_SupplierID.BackColor = System.Drawing.Color.LightGray
        Me.txt_SupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SupplierID.ForeColor = System.Drawing.Color.Gray
        Me.txt_SupplierID.Location = New System.Drawing.Point(575, 13)
        Me.txt_SupplierID.Name = "txt_SupplierID"
        Me.txt_SupplierID.ReadOnly = True
        Me.txt_SupplierID.Size = New System.Drawing.Size(60, 22)
        Me.txt_SupplierID.TabIndex = 5
        '
        'txt_SupplierName
        '
        Me.txt_SupplierName.BackColor = System.Drawing.Color.LightGray
        Me.txt_SupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SupplierName.ForeColor = System.Drawing.Color.Gray
        Me.txt_SupplierName.Location = New System.Drawing.Point(575, 38)
        Me.txt_SupplierName.Name = "txt_SupplierName"
        Me.txt_SupplierName.ReadOnly = True
        Me.txt_SupplierName.Size = New System.Drawing.Size(353, 22)
        Me.txt_SupplierName.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Warehouse"
        '
        'cb_Gudang
        '
        Me.cb_Gudang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Gudang.FormattingEnabled = True
        Me.cb_Gudang.Items.AddRange(New Object() {"OK", "NO", "YES", "GAK"})
        Me.cb_Gudang.Location = New System.Drawing.Point(108, 65)
        Me.cb_Gudang.Name = "cb_Gudang"
        Me.cb_Gudang.Size = New System.Drawing.Size(198, 22)
        Me.cb_Gudang.TabIndex = 18
        '
        'lbl_SuppName
        '
        Me.lbl_SuppName.AutoSize = True
        Me.lbl_SuppName.Location = New System.Drawing.Point(472, 41)
        Me.lbl_SuppName.Name = "lbl_SuppName"
        Me.lbl_SuppName.Size = New System.Drawing.Size(85, 14)
        Me.lbl_SuppName.TabIndex = 19
        Me.lbl_SuppName.Text = "Supplier Name"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(663, 13)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(522, 20)
        Me.lbl_status.TabIndex = 23
        Me.lbl_status.Text = "lbl_Status"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 14)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "PO No."
        '
        'txt_PONo
        '
        Me.txt_PONo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PONo.Location = New System.Drawing.Point(108, 92)
        Me.txt_PONo.Name = "txt_PONo"
        Me.txt_PONo.Size = New System.Drawing.Size(198, 22)
        Me.txt_PONo.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_Invoice)
        Me.Panel1.Controls.Add(Me.lbl_Invoice)
        Me.Panel1.Controls.Add(Me.txt_SJalan)
        Me.Panel1.Controls.Add(Me.lbl_SJalan)
        Me.Panel1.Controls.Add(Me.dt_LPBDate)
        Me.Panel1.Controls.Add(Me.txt_PONo)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lbl_status)
        Me.Panel1.Controls.Add(Me.lbl_SuppName)
        Me.Panel1.Controls.Add(Me.cb_Gudang)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_SupplierName)
        Me.Panel1.Controls.Add(Me.txt_SupplierID)
        Me.Panel1.Controls.Add(Me.lbl_Supplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(14, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1191, 127)
        Me.Panel1.TabIndex = 0
        '
        'txt_Invoice
        '
        Me.txt_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Invoice.Location = New System.Drawing.Point(575, 94)
        Me.txt_Invoice.Name = "txt_Invoice"
        Me.txt_Invoice.Size = New System.Drawing.Size(185, 22)
        Me.txt_Invoice.TabIndex = 36
        '
        'lbl_Invoice
        '
        Me.lbl_Invoice.AutoSize = True
        Me.lbl_Invoice.Location = New System.Drawing.Point(472, 96)
        Me.lbl_Invoice.Name = "lbl_Invoice"
        Me.lbl_Invoice.Size = New System.Drawing.Size(46, 14)
        Me.lbl_Invoice.TabIndex = 35
        Me.lbl_Invoice.Text = "Invoice"
        '
        'txt_SJalan
        '
        Me.txt_SJalan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SJalan.Location = New System.Drawing.Point(575, 68)
        Me.txt_SJalan.Name = "txt_SJalan"
        Me.txt_SJalan.Size = New System.Drawing.Size(185, 22)
        Me.txt_SJalan.TabIndex = 34
        '
        'lbl_SJalan
        '
        Me.lbl_SJalan.AutoSize = True
        Me.lbl_SJalan.Location = New System.Drawing.Point(472, 70)
        Me.lbl_SJalan.Name = "lbl_SJalan"
        Me.lbl_SJalan.Size = New System.Drawing.Size(66, 14)
        Me.lbl_SJalan.TabIndex = 33
        Me.lbl_SJalan.Text = "Surat Jalan"
        '
        'dt_LPBDate
        '
        Me.dt_LPBDate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_LPBDate.Enabled = False
        Me.dt_LPBDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_LPBDate.Location = New System.Drawing.Point(107, 38)
        Me.dt_LPBDate.Name = "dt_LPBDate"
        Me.dt_LPBDate.Size = New System.Drawing.Size(199, 22)
        Me.dt_LPBDate.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.cb_quality)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.txt_PRNo)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txt_Ket)
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
        Me.Panel2.Controls.Add(Me.Txt_QtyRec)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Txt_Qty)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Txt_UoM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_ItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_ItemID)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(14, 159)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1191, 88)
        Me.Panel2.TabIndex = 24
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(796, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 14)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Quality"
        '
        'cb_quality
        '
        Me.cb_quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_quality.Enabled = False
        Me.cb_quality.FormattingEnabled = True
        Me.cb_quality.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cb_quality.Location = New System.Drawing.Point(792, 25)
        Me.cb_quality.Name = "cb_quality"
        Me.cb_quality.Size = New System.Drawing.Size(66, 22)
        Me.cb_quality.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 14)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "PR No"
        '
        'txt_PRNo
        '
        Me.txt_PRNo.BackColor = System.Drawing.Color.DarkGray
        Me.txt_PRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PRNo.Enabled = False
        Me.txt_PRNo.Location = New System.Drawing.Point(10, 26)
        Me.txt_PRNo.Name = "txt_PRNo"
        Me.txt_PRNo.Size = New System.Drawing.Size(78, 22)
        Me.txt_PRNo.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(436, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(47, 14)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Remark"
        '
        'txt_Ket
        '
        Me.txt_Ket.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Enabled = False
        Me.txt_Ket.Location = New System.Drawing.Point(343, 26)
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(261, 22)
        Me.txt_Ket.TabIndex = 21
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(265, 54)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(83, 29)
        Me.Btn_cancel.TabIndex = 20
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(179, 54)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(83, 29)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(94, 54)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(83, 29)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(10, 54)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(83, 29)
        Me.btn_edit.TabIndex = 17
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(350, 54)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(83, 29)
        Me.btn_insert.TabIndex = 16
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        Me.btn_insert.Visible = False
        '
        'txt_SubTotalTemp
        '
        Me.txt_SubTotalTemp.BackColor = System.Drawing.Color.DarkGray
        Me.txt_SubTotalTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubTotalTemp.Enabled = False
        Me.txt_SubTotalTemp.Location = New System.Drawing.Point(1061, 26)
        Me.txt_SubTotalTemp.Name = "txt_SubTotalTemp"
        Me.txt_SubTotalTemp.Size = New System.Drawing.Size(108, 22)
        Me.txt_SubTotalTemp.TabIndex = 15
        Me.txt_SubTotalTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(1077, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 14)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "SubTotal"
        '
        'txt_Diskon
        '
        Me.txt_Diskon.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Diskon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Diskon.Enabled = False
        Me.txt_Diskon.Location = New System.Drawing.Point(967, 26)
        Me.txt_Diskon.Name = "txt_Diskon"
        Me.txt_Diskon.Size = New System.Drawing.Size(92, 22)
        Me.txt_Diskon.TabIndex = 13
        Me.txt_Diskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(989, 9)
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
        Me.txt_Harga.Location = New System.Drawing.Point(862, 26)
        Me.txt_Harga.Name = "txt_Harga"
        Me.txt_Harga.Size = New System.Drawing.Size(102, 22)
        Me.txt_Harga.TabIndex = 11
        Me.txt_Harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(892, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 14)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Price"
        '
        'Txt_QtyRec
        '
        Me.Txt_QtyRec.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_QtyRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_QtyRec.Enabled = False
        Me.Txt_QtyRec.Location = New System.Drawing.Point(718, 26)
        Me.Txt_QtyRec.Name = "Txt_QtyRec"
        Me.Txt_QtyRec.Size = New System.Drawing.Size(71, 22)
        Me.Txt_QtyRec.TabIndex = 9
        Me.Txt_QtyRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(718, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 14)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Qty Receipt"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(665, 26)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(50, 22)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(669, 9)
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
        Me.Txt_UoM.Location = New System.Drawing.Point(606, 26)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(56, 22)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(605, 9)
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
        Me.txt_ItemName.Location = New System.Drawing.Point(151, 26)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(189, 22)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(206, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Enabled = False
        Me.txt_ItemID.Location = New System.Drawing.Point(92, 26)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(56, 22)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item ID"
        '
        'txt_TotalQtyRec
        '
        Me.txt_TotalQtyRec.BackColor = System.Drawing.Color.LightGray
        Me.txt_TotalQtyRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TotalQtyRec.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalQtyRec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_TotalQtyRec.Location = New System.Drawing.Point(624, 466)
        Me.txt_TotalQtyRec.Name = "txt_TotalQtyRec"
        Me.txt_TotalQtyRec.ReadOnly = True
        Me.txt_TotalQtyRec.Size = New System.Drawing.Size(101, 22)
        Me.txt_TotalQtyRec.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(621, 494)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 14)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "Total Qty Receipt"
        '
        'txt_Reason
        '
        Me.txt_Reason.BackColor = System.Drawing.Color.LightGray
        Me.txt_Reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Reason.ForeColor = System.Drawing.Color.Gray
        Me.txt_Reason.Location = New System.Drawing.Point(15, 567)
        Me.txt_Reason.Multiline = True
        Me.txt_Reason.Name = "txt_Reason"
        Me.txt_Reason.ReadOnly = True
        Me.txt_Reason.Size = New System.Drawing.Size(482, 53)
        Me.txt_Reason.TabIndex = 44
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(15, 547)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 14)
        Me.Label25.TabIndex = 43
        Me.Label25.Text = "Reject Reason"
        '
        'frmTerimaBrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 645)
        Me.Controls.Add(Me.txt_Reason)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txt_TotalQtyRec)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txt_UangMuka)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txt_pengiriman)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Gb_PaymentType)
        Me.Controls.Add(Me.txt_Remark)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_TotalQty)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_GrandTotal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_PPN)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_SubTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.gv_PODtl)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTerimaBrg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Penerimaan Barang"
        CType(Me.gv_PODtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Gb_PaymentType.ResumeLayout(False)
        Me.Gb_PaymentType.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gv_PODtl As System.Windows.Forms.DataGridView
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_SubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txt_PPN As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_GrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalQty As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Gb_PaymentType As System.Windows.Forms.GroupBox
    Friend WithEvents dt_PayType As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_pengiriman As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_UangMuka As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Supplier As System.Windows.Forms.Label
    Friend WithEvents txt_SupplierID As System.Windows.Forms.TextBox
    Friend WithEvents txt_SupplierName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_Gudang As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_SuppName As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_PONo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_LPBDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Txt_QtyRec As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_SubTotalTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Diskon As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_Harga As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents txt_TotalQtyRec As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents txt_Invoice As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Invoice As System.Windows.Forms.Label
    Friend WithEvents txt_SJalan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SJalan As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_PRNo As System.Windows.Forms.TextBox
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents cb_quality As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_Reason As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label

End Class
