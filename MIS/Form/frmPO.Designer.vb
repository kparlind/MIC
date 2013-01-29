<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPO))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_print = New System.Windows.Forms.ToolStripButton
        Me.p_subTotal = New System.Windows.Forms.Panel
        Me.txt_UangMuka = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_PPN = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_Remark = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_TotalQty = New System.Windows.Forms.TextBox
        Me.lbl_TotalQty = New System.Windows.Forms.Label
        Me.txt_GrandTotal = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_SubTotal = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.gv_PODtl = New System.Windows.Forms.DataGridView
        Me.P_waJasa = New System.Windows.Forms.Panel
        Me.txt_PRNoJasa = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_JasaHarga = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.btn_cancelJasa = New System.Windows.Forms.Button
        Me.btn_deleteJasa = New System.Windows.Forms.Button
        Me.btn_SaveJasa = New System.Windows.Forms.Button
        Me.btn_editJasa = New System.Windows.Forms.Button
        Me.btn_InsertJasa = New System.Windows.Forms.Button
        Me.txt_JasaKet = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_JasaName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_JasaID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.P_waItem = New System.Windows.Forms.Panel
        Me.txt_PRNoItem = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_Harga = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btn_RecommendedSupp = New System.Windows.Forms.Button
        Me.txt_Reason = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_SupplierName = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb_jasa = New System.Windows.Forms.RadioButton
        Me.rb_item = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.dt_PODate = New System.Windows.Forms.DateTimePicker
        Me.dt_TerimaBrg = New System.Windows.Forms.DateTimePicker
        Me.lbl_terimabrg = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.lbl_SupplierName = New System.Windows.Forms.Label
        Me.txt_SupplierID = New System.Windows.Forms.TextBox
        Me.lbl_SupplierID = New System.Windows.Forms.Label
        Me.lbl_TransDt = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Lbl_TransNo = New System.Windows.Forms.Label
        Me.lbl_InvAmt = New System.Windows.Forms.Label
        Me.txt_InvAmt = New System.Windows.Forms.TextBox
        Me.Ts_PO.SuspendLayout()
        Me.p_subTotal.SuspendLayout()
        CType(Me.gv_PODtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_waJasa.SuspendLayout()
        Me.P_waItem.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.BackColor = System.Drawing.Color.DarkGray
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save, Me.ts_approve, Me.ts_reject, Me.ts_delete, Me.ts_cancel, Me.ts_print})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1184, 25)
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
        'ts_print
        '
        Me.ts_print.Image = CType(resources.GetObject("ts_print.Image"), System.Drawing.Image)
        Me.ts_print.ImageTransparentColor = System.Drawing.Color.Black
        Me.ts_print.Name = "ts_print"
        Me.ts_print.Size = New System.Drawing.Size(52, 22)
        Me.ts_print.Text = "Print"
        '
        'p_subTotal
        '
        Me.p_subTotal.Controls.Add(Me.txt_UangMuka)
        Me.p_subTotal.Controls.Add(Me.Label16)
        Me.p_subTotal.Controls.Add(Me.txt_PPN)
        Me.p_subTotal.Controls.Add(Me.Label8)
        Me.p_subTotal.Controls.Add(Me.txt_Remark)
        Me.p_subTotal.Controls.Add(Me.Label10)
        Me.p_subTotal.Controls.Add(Me.txt_TotalQty)
        Me.p_subTotal.Controls.Add(Me.lbl_TotalQty)
        Me.p_subTotal.Controls.Add(Me.txt_GrandTotal)
        Me.p_subTotal.Controls.Add(Me.Label19)
        Me.p_subTotal.Controls.Add(Me.txt_SubTotal)
        Me.p_subTotal.Controls.Add(Me.Label25)
        Me.p_subTotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.p_subTotal.Location = New System.Drawing.Point(0, 568)
        Me.p_subTotal.Name = "p_subTotal"
        Me.p_subTotal.Size = New System.Drawing.Size(1184, 131)
        Me.p_subTotal.TabIndex = 41
        '
        'txt_UangMuka
        '
        Me.txt_UangMuka.BackColor = System.Drawing.Color.LightGray
        Me.txt_UangMuka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_UangMuka.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UangMuka.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_UangMuka.Location = New System.Drawing.Point(940, 56)
        Me.txt_UangMuka.Name = "txt_UangMuka"
        Me.txt_UangMuka.ReadOnly = True
        Me.txt_UangMuka.Size = New System.Drawing.Size(151, 22)
        Me.txt_UangMuka.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(843, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 14)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Down Payment"
        '
        'txt_PPN
        '
        Me.txt_PPN.BackColor = System.Drawing.Color.LightGray
        Me.txt_PPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PPN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PPN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_PPN.Location = New System.Drawing.Point(940, 30)
        Me.txt_PPN.Name = "txt_PPN"
        Me.txt_PPN.ReadOnly = True
        Me.txt_PPN.Size = New System.Drawing.Size(151, 22)
        Me.txt_PPN.TabIndex = 35
        Me.txt_PPN.Text = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(879, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 14)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "PPN (%)"
        '
        'txt_Remark
        '
        Me.txt_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remark.Location = New System.Drawing.Point(16, 29)
        Me.txt_Remark.Multiline = True
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(340, 68)
        Me.txt_Remark.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 14)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Remark"
        '
        'txt_TotalQty
        '
        Me.txt_TotalQty.BackColor = System.Drawing.Color.LightGray
        Me.txt_TotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TotalQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_TotalQty.Location = New System.Drawing.Point(649, 6)
        Me.txt_TotalQty.Name = "txt_TotalQty"
        Me.txt_TotalQty.ReadOnly = True
        Me.txt_TotalQty.Size = New System.Drawing.Size(85, 22)
        Me.txt_TotalQty.TabIndex = 31
        '
        'lbl_TotalQty
        '
        Me.lbl_TotalQty.AutoSize = True
        Me.lbl_TotalQty.Location = New System.Drawing.Point(589, 7)
        Me.lbl_TotalQty.Name = "lbl_TotalQty"
        Me.lbl_TotalQty.Size = New System.Drawing.Size(59, 14)
        Me.lbl_TotalQty.TabIndex = 30
        Me.lbl_TotalQty.Text = "Total Qty"
        '
        'txt_GrandTotal
        '
        Me.txt_GrandTotal.BackColor = System.Drawing.Color.LightGray
        Me.txt_GrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GrandTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GrandTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_GrandTotal.Location = New System.Drawing.Point(941, 83)
        Me.txt_GrandTotal.Name = "txt_GrandTotal"
        Me.txt_GrandTotal.ReadOnly = True
        Me.txt_GrandTotal.Size = New System.Drawing.Size(151, 22)
        Me.txt_GrandTotal.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(863, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 14)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Grand Total"
        '
        'txt_SubTotal
        '
        Me.txt_SubTotal.BackColor = System.Drawing.Color.LightGray
        Me.txt_SubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SubTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_SubTotal.Location = New System.Drawing.Point(940, 6)
        Me.txt_SubTotal.Name = "txt_SubTotal"
        Me.txt_SubTotal.ReadOnly = True
        Me.txt_SubTotal.Size = New System.Drawing.Size(151, 22)
        Me.txt_SubTotal.TabIndex = 25
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(874, 7)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 14)
        Me.Label25.TabIndex = 24
        Me.Label25.Text = "Sub Total"
        '
        'gv_PODtl
        '
        Me.gv_PODtl.AllowUserToAddRows = False
        Me.gv_PODtl.AllowUserToDeleteRows = False
        Me.gv_PODtl.AllowUserToOrderColumns = True
        Me.gv_PODtl.AllowUserToResizeColumns = False
        Me.gv_PODtl.AllowUserToResizeRows = False
        Me.gv_PODtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_PODtl.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_PODtl.Location = New System.Drawing.Point(0, 383)
        Me.gv_PODtl.Name = "gv_PODtl"
        Me.gv_PODtl.ReadOnly = True
        Me.gv_PODtl.Size = New System.Drawing.Size(1184, 185)
        Me.gv_PODtl.TabIndex = 40
        '
        'P_waJasa
        '
        Me.P_waJasa.Controls.Add(Me.txt_PRNoJasa)
        Me.P_waJasa.Controls.Add(Me.Label5)
        Me.P_waJasa.Controls.Add(Me.txt_JasaHarga)
        Me.P_waJasa.Controls.Add(Me.Label26)
        Me.P_waJasa.Controls.Add(Me.btn_cancelJasa)
        Me.P_waJasa.Controls.Add(Me.btn_deleteJasa)
        Me.P_waJasa.Controls.Add(Me.btn_SaveJasa)
        Me.P_waJasa.Controls.Add(Me.btn_editJasa)
        Me.P_waJasa.Controls.Add(Me.btn_InsertJasa)
        Me.P_waJasa.Controls.Add(Me.txt_JasaKet)
        Me.P_waJasa.Controls.Add(Me.Label11)
        Me.P_waJasa.Controls.Add(Me.txt_JasaName)
        Me.P_waJasa.Controls.Add(Me.Label6)
        Me.P_waJasa.Controls.Add(Me.txt_JasaID)
        Me.P_waJasa.Controls.Add(Me.Label9)
        Me.P_waJasa.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_waJasa.Location = New System.Drawing.Point(0, 295)
        Me.P_waJasa.Name = "P_waJasa"
        Me.P_waJasa.Size = New System.Drawing.Size(1184, 88)
        Me.P_waJasa.TabIndex = 39
        '
        'txt_PRNoJasa
        '
        Me.txt_PRNoJasa.BackColor = System.Drawing.Color.DarkGray
        Me.txt_PRNoJasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PRNoJasa.Enabled = False
        Me.txt_PRNoJasa.Location = New System.Drawing.Point(8, 26)
        Me.txt_PRNoJasa.Name = "txt_PRNoJasa"
        Me.txt_PRNoJasa.Size = New System.Drawing.Size(108, 22)
        Me.txt_PRNoJasa.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "PR No"
        '
        'txt_JasaHarga
        '
        Me.txt_JasaHarga.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaHarga.Enabled = False
        Me.txt_JasaHarga.Location = New System.Drawing.Point(509, 26)
        Me.txt_JasaHarga.Name = "txt_JasaHarga"
        Me.txt_JasaHarga.Size = New System.Drawing.Size(181, 22)
        Me.txt_JasaHarga.TabIndex = 22
        Me.txt_JasaHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(538, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 14)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Price"
        '
        'btn_cancelJasa
        '
        Me.btn_cancelJasa.Location = New System.Drawing.Point(342, 54)
        Me.btn_cancelJasa.Name = "btn_cancelJasa"
        Me.btn_cancelJasa.Size = New System.Drawing.Size(83, 29)
        Me.btn_cancelJasa.TabIndex = 20
        Me.btn_cancelJasa.Text = "Cancel"
        Me.btn_cancelJasa.UseVisualStyleBackColor = True
        '
        'btn_deleteJasa
        '
        Me.btn_deleteJasa.Location = New System.Drawing.Point(259, 54)
        Me.btn_deleteJasa.Name = "btn_deleteJasa"
        Me.btn_deleteJasa.Size = New System.Drawing.Size(83, 29)
        Me.btn_deleteJasa.TabIndex = 19
        Me.btn_deleteJasa.Text = "Delete"
        Me.btn_deleteJasa.UseVisualStyleBackColor = True
        '
        'btn_SaveJasa
        '
        Me.btn_SaveJasa.Location = New System.Drawing.Point(176, 54)
        Me.btn_SaveJasa.Name = "btn_SaveJasa"
        Me.btn_SaveJasa.Size = New System.Drawing.Size(83, 29)
        Me.btn_SaveJasa.TabIndex = 18
        Me.btn_SaveJasa.Text = "Save"
        Me.btn_SaveJasa.UseVisualStyleBackColor = True
        '
        'btn_editJasa
        '
        Me.btn_editJasa.Location = New System.Drawing.Point(92, 54)
        Me.btn_editJasa.Name = "btn_editJasa"
        Me.btn_editJasa.Size = New System.Drawing.Size(83, 29)
        Me.btn_editJasa.TabIndex = 17
        Me.btn_editJasa.Text = "Edit"
        Me.btn_editJasa.UseVisualStyleBackColor = True
        '
        'btn_InsertJasa
        '
        Me.btn_InsertJasa.Location = New System.Drawing.Point(8, 54)
        Me.btn_InsertJasa.Name = "btn_InsertJasa"
        Me.btn_InsertJasa.Size = New System.Drawing.Size(83, 29)
        Me.btn_InsertJasa.TabIndex = 16
        Me.btn_InsertJasa.Text = "Insert"
        Me.btn_InsertJasa.UseVisualStyleBackColor = True
        '
        'txt_JasaKet
        '
        Me.txt_JasaKet.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaKet.Enabled = False
        Me.txt_JasaKet.Location = New System.Drawing.Point(692, 26)
        Me.txt_JasaKet.Name = "txt_JasaKet"
        Me.txt_JasaKet.Size = New System.Drawing.Size(484, 22)
        Me.txt_JasaKet.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(791, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 14)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Remarks"
        '
        'txt_JasaName
        '
        Me.txt_JasaName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaName.Enabled = False
        Me.txt_JasaName.Location = New System.Drawing.Point(202, 26)
        Me.txt_JasaName.Name = "txt_JasaName"
        Me.txt_JasaName.Size = New System.Drawing.Size(304, 22)
        Me.txt_JasaName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(292, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 14)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Jasa Name"
        '
        'txt_JasaID
        '
        Me.txt_JasaID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaID.Enabled = False
        Me.txt_JasaID.Location = New System.Drawing.Point(118, 26)
        Me.txt_JasaID.Name = "txt_JasaID"
        Me.txt_JasaID.Size = New System.Drawing.Size(82, 22)
        Me.txt_JasaID.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(138, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Jasa ID"
        '
        'P_waItem
        '
        Me.P_waItem.Controls.Add(Me.txt_PRNoItem)
        Me.P_waItem.Controls.Add(Me.Label3)
        Me.P_waItem.Controls.Add(Me.Label22)
        Me.P_waItem.Controls.Add(Me.txt_Ket)
        Me.P_waItem.Controls.Add(Me.Btn_cancel)
        Me.P_waItem.Controls.Add(Me.btn_delete)
        Me.P_waItem.Controls.Add(Me.btn_save)
        Me.P_waItem.Controls.Add(Me.btn_edit)
        Me.P_waItem.Controls.Add(Me.btn_insert)
        Me.P_waItem.Controls.Add(Me.txt_SubTotalTemp)
        Me.P_waItem.Controls.Add(Me.Label20)
        Me.P_waItem.Controls.Add(Me.txt_Diskon)
        Me.P_waItem.Controls.Add(Me.Label1)
        Me.P_waItem.Controls.Add(Me.txt_Harga)
        Me.P_waItem.Controls.Add(Me.Label2)
        Me.P_waItem.Controls.Add(Me.Txt_Qty)
        Me.P_waItem.Controls.Add(Me.Label4)
        Me.P_waItem.Controls.Add(Me.Txt_UoM)
        Me.P_waItem.Controls.Add(Me.Label12)
        Me.P_waItem.Controls.Add(Me.txt_ItemName)
        Me.P_waItem.Controls.Add(Me.Label21)
        Me.P_waItem.Controls.Add(Me.txt_ItemID)
        Me.P_waItem.Controls.Add(Me.Label23)
        Me.P_waItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_waItem.Location = New System.Drawing.Point(0, 207)
        Me.P_waItem.Name = "P_waItem"
        Me.P_waItem.Size = New System.Drawing.Size(1184, 88)
        Me.P_waItem.TabIndex = 38
        '
        'txt_PRNoItem
        '
        Me.txt_PRNoItem.BackColor = System.Drawing.Color.DarkGray
        Me.txt_PRNoItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PRNoItem.Enabled = False
        Me.txt_PRNoItem.Location = New System.Drawing.Point(8, 26)
        Me.txt_PRNoItem.Name = "txt_PRNoItem"
        Me.txt_PRNoItem.Size = New System.Drawing.Size(108, 22)
        Me.txt_PRNoItem.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 14)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "PR No"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(1003, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 14)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Remarks"
        '
        'txt_Ket
        '
        Me.txt_Ket.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Enabled = False
        Me.txt_Ket.Location = New System.Drawing.Point(924, 26)
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(252, 22)
        Me.txt_Ket.TabIndex = 21
        Me.txt_Ket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txt_SubTotalTemp.Location = New System.Drawing.Point(794, 26)
        Me.txt_SubTotalTemp.Name = "txt_SubTotalTemp"
        Me.txt_SubTotalTemp.Size = New System.Drawing.Size(128, 22)
        Me.txt_SubTotalTemp.TabIndex = 15
        Me.txt_SubTotalTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(823, 9)
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
        Me.txt_Diskon.Location = New System.Drawing.Point(692, 26)
        Me.txt_Diskon.Name = "txt_Diskon"
        Me.txt_Diskon.Size = New System.Drawing.Size(100, 22)
        Me.txt_Diskon.TabIndex = 13
        Me.txt_Diskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(711, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Discount"
        '
        'txt_Harga
        '
        Me.txt_Harga.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Harga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Harga.Enabled = False
        Me.txt_Harga.Location = New System.Drawing.Point(573, 26)
        Me.txt_Harga.Name = "txt_Harga"
        Me.txt_Harga.Size = New System.Drawing.Size(117, 22)
        Me.txt_Harga.TabIndex = 11
        Me.txt_Harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(609, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Price"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(517, 26)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(54, 22)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(531, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Qty"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UoM.Enabled = False
        Me.Txt_UoM.Location = New System.Drawing.Point(459, 26)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(56, 22)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(462, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 14)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "UoM"
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(202, 26)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(255, 22)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(288, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 14)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Enabled = False
        Me.txt_ItemID.Location = New System.Drawing.Point(118, 26)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(82, 22)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(134, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 14)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Item ID"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_InvAmt)
        Me.Panel1.Controls.Add(Me.lbl_InvAmt)
        Me.Panel1.Controls.Add(Me.btn_RecommendedSupp)
        Me.Panel1.Controls.Add(Me.txt_Reason)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txt_SupplierName)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dt_PODate)
        Me.Panel1.Controls.Add(Me.dt_TerimaBrg)
        Me.Panel1.Controls.Add(Me.lbl_terimabrg)
        Me.Panel1.Controls.Add(Me.lbl_status)
        Me.Panel1.Controls.Add(Me.lbl_SupplierName)
        Me.Panel1.Controls.Add(Me.txt_SupplierID)
        Me.Panel1.Controls.Add(Me.lbl_SupplierID)
        Me.Panel1.Controls.Add(Me.lbl_TransDt)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Lbl_TransNo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 182)
        Me.Panel1.TabIndex = 37
        '
        'btn_RecommendedSupp
        '
        Me.btn_RecommendedSupp.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RecommendedSupp.Location = New System.Drawing.Point(622, 13)
        Me.btn_RecommendedSupp.Name = "btn_RecommendedSupp"
        Me.btn_RecommendedSupp.Size = New System.Drawing.Size(159, 25)
        Me.btn_RecommendedSupp.TabIndex = 45
        Me.btn_RecommendedSupp.Text = "Recommended Supplier"
        Me.btn_RecommendedSupp.UseVisualStyleBackColor = True
        '
        'txt_Reason
        '
        Me.txt_Reason.BackColor = System.Drawing.Color.LightGray
        Me.txt_Reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Reason.ForeColor = System.Drawing.Color.Gray
        Me.txt_Reason.Location = New System.Drawing.Point(551, 103)
        Me.txt_Reason.Multiline = True
        Me.txt_Reason.Name = "txt_Reason"
        Me.txt_Reason.ReadOnly = True
        Me.txt_Reason.Size = New System.Drawing.Size(537, 41)
        Me.txt_Reason.TabIndex = 44
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(452, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 14)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Reject Reason"
        '
        'txt_SupplierName
        '
        Me.txt_SupplierName.BackColor = System.Drawing.Color.LightGray
        Me.txt_SupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SupplierName.ForeColor = System.Drawing.Color.Gray
        Me.txt_SupplierName.Location = New System.Drawing.Point(551, 41)
        Me.txt_SupplierName.Name = "txt_SupplierName"
        Me.txt_SupplierName.ReadOnly = True
        Me.txt_SupplierName.Size = New System.Drawing.Size(353, 22)
        Me.txt_SupplierName.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_jasa)
        Me.GroupBox1.Controls.Add(Me.rb_item)
        Me.GroupBox1.Location = New System.Drawing.Point(551, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 34)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'rb_jasa
        '
        Me.rb_jasa.AutoSize = True
        Me.rb_jasa.Location = New System.Drawing.Point(136, 10)
        Me.rb_jasa.Name = "rb_jasa"
        Me.rb_jasa.Size = New System.Drawing.Size(47, 18)
        Me.rb_jasa.TabIndex = 2
        Me.rb_jasa.Text = "Jasa"
        Me.rb_jasa.UseVisualStyleBackColor = True
        '
        'rb_item
        '
        Me.rb_item.AutoSize = True
        Me.rb_item.Checked = True
        Me.rb_item.Location = New System.Drawing.Point(4, 10)
        Me.rb_item.Name = "rb_item"
        Me.rb_item.Size = New System.Drawing.Size(121, 18)
        Me.rb_item.TabIndex = 0
        Me.rb_item.TabStop = True
        Me.rb_item.Text = "Pembelian Barang"
        Me.rb_item.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(452, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 14)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Request Type"
        '
        'dt_PODate
        '
        Me.dt_PODate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_PODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_PODate.Location = New System.Drawing.Point(97, 40)
        Me.dt_PODate.Name = "dt_PODate"
        Me.dt_PODate.Size = New System.Drawing.Size(120, 22)
        Me.dt_PODate.TabIndex = 32
        '
        'dt_TerimaBrg
        '
        Me.dt_TerimaBrg.CustomFormat = "dd-MMM-yyyy"
        Me.dt_TerimaBrg.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_TerimaBrg.Location = New System.Drawing.Point(97, 69)
        Me.dt_TerimaBrg.Name = "dt_TerimaBrg"
        Me.dt_TerimaBrg.Size = New System.Drawing.Size(120, 22)
        Me.dt_TerimaBrg.TabIndex = 27
        '
        'lbl_terimabrg
        '
        Me.lbl_terimabrg.AutoSize = True
        Me.lbl_terimabrg.Location = New System.Drawing.Point(9, 75)
        Me.lbl_terimabrg.Name = "lbl_terimabrg"
        Me.lbl_terimabrg.Size = New System.Drawing.Size(86, 14)
        Me.lbl_terimabrg.TabIndex = 26
        Me.lbl_terimabrg.Text = "Received Date"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(618, 13)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(558, 26)
        Me.lbl_status.TabIndex = 23
        Me.lbl_status.Text = "lbl_status"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_SupplierName
        '
        Me.lbl_SupplierName.AutoSize = True
        Me.lbl_SupplierName.Location = New System.Drawing.Point(451, 43)
        Me.lbl_SupplierName.Name = "lbl_SupplierName"
        Me.lbl_SupplierName.Size = New System.Drawing.Size(85, 14)
        Me.lbl_SupplierName.TabIndex = 19
        Me.lbl_SupplierName.Text = "Supplier Name"
        '
        'txt_SupplierID
        '
        Me.txt_SupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SupplierID.Location = New System.Drawing.Point(551, 17)
        Me.txt_SupplierID.Name = "txt_SupplierID"
        Me.txt_SupplierID.Size = New System.Drawing.Size(60, 22)
        Me.txt_SupplierID.TabIndex = 5
        '
        'lbl_SupplierID
        '
        Me.lbl_SupplierID.AutoSize = True
        Me.lbl_SupplierID.Location = New System.Drawing.Point(452, 20)
        Me.lbl_SupplierID.Name = "lbl_SupplierID"
        Me.lbl_SupplierID.Size = New System.Drawing.Size(50, 14)
        Me.lbl_SupplierID.TabIndex = 4
        Me.lbl_SupplierID.Text = "Supplier"
        '
        'lbl_TransDt
        '
        Me.lbl_TransDt.AutoSize = True
        Me.lbl_TransDt.Location = New System.Drawing.Point(9, 43)
        Me.lbl_TransDt.Name = "lbl_TransDt"
        Me.lbl_TransDt.Size = New System.Drawing.Size(53, 14)
        Me.lbl_TransDt.TabIndex = 2
        Me.lbl_TransDt.Text = "PO Date"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.ForeColor = System.Drawing.Color.Gray
        Me.txt_TransNo.Location = New System.Drawing.Point(97, 15)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.ReadOnly = True
        Me.txt_TransNo.Size = New System.Drawing.Size(95, 22)
        Me.txt_TransNo.TabIndex = 1
        '
        'Lbl_TransNo
        '
        Me.Lbl_TransNo.AutoSize = True
        Me.Lbl_TransNo.Location = New System.Drawing.Point(9, 15)
        Me.Lbl_TransNo.Name = "Lbl_TransNo"
        Me.Lbl_TransNo.Size = New System.Drawing.Size(46, 14)
        Me.Lbl_TransNo.TabIndex = 0
        Me.Lbl_TransNo.Text = "PO No."
        '
        'lbl_InvAmt
        '
        Me.lbl_InvAmt.AutoSize = True
        Me.lbl_InvAmt.Location = New System.Drawing.Point(451, 154)
        Me.lbl_InvAmt.Name = "lbl_InvAmt"
        Me.lbl_InvAmt.Size = New System.Drawing.Size(94, 14)
        Me.lbl_InvAmt.TabIndex = 46
        Me.lbl_InvAmt.Text = "Invoice Amount"
        '
        'txt_InvAmt
        '
        Me.txt_InvAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_InvAmt.Location = New System.Drawing.Point(551, 146)
        Me.txt_InvAmt.Name = "txt_InvAmt"
        Me.txt_InvAmt.Size = New System.Drawing.Size(139, 22)
        Me.txt_InvAmt.TabIndex = 47
        '
        'frmPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1184, 663)
        Me.Controls.Add(Me.p_subTotal)
        Me.Controls.Add(Me.gv_PODtl)
        Me.Controls.Add(Me.P_waJasa)
        Me.Controls.Add(Me.P_waItem)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Purchasing Order ::"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.p_subTotal.ResumeLayout(False)
        Me.p_subTotal.PerformLayout()
        CType(Me.gv_PODtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_waJasa.ResumeLayout(False)
        Me.P_waJasa.PerformLayout()
        Me.P_waItem.ResumeLayout(False)
        Me.P_waItem.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents p_subTotal As System.Windows.Forms.Panel
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_TotalQty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_TotalQty As System.Windows.Forms.Label
    Friend WithEvents txt_GrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_SubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents gv_PODtl As System.Windows.Forms.DataGridView
    Friend WithEvents P_waJasa As System.Windows.Forms.Panel
    Friend WithEvents txt_PRNoJasa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_JasaHarga As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelJasa As System.Windows.Forms.Button
    Friend WithEvents btn_deleteJasa As System.Windows.Forms.Button
    Friend WithEvents btn_SaveJasa As System.Windows.Forms.Button
    Friend WithEvents btn_editJasa As System.Windows.Forms.Button
    Friend WithEvents btn_InsertJasa As System.Windows.Forms.Button
    Friend WithEvents txt_JasaKet As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_JasaName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_JasaID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents P_waItem As System.Windows.Forms.Panel
    Friend WithEvents txt_PRNoItem As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txt_SubTotalTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Diskon As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Harga As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_jasa As System.Windows.Forms.RadioButton
    Friend WithEvents rb_item As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dt_PODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_TerimaBrg As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_terimabrg As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents lbl_SupplierName As System.Windows.Forms.Label
    Friend WithEvents txt_SupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txt_SupplierID As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SupplierID As System.Windows.Forms.Label
    Friend WithEvents lbl_TransDt As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_TransNo As System.Windows.Forms.Label
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_UangMuka As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_PPN As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ts_print As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_Reason As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_RecommendedSupp As System.Windows.Forms.Button
    Friend WithEvents lbl_InvAmt As System.Windows.Forms.Label
    Friend WithEvents txt_InvAmt As System.Windows.Forms.TextBox

End Class
