<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuktiSerahTerima
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuktiSerahTerima))
        Me.gv_STB = New System.Windows.Forms.DataGridView
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_FindPO = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_Supplier = New System.Windows.Forms.Label
        Me.txt_PICGudang = New System.Windows.Forms.TextBox
        Me.Lbl_SuppTel = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_OPNo = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_PICName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_WarehouseName = New System.Windows.Forms.TextBox
        Me.txt_Remarks = New System.Windows.Forms.TextBox
        Me.dt_STBDate = New System.Windows.Forms.DateTimePicker
        Me.lbl_SuppName = New System.Windows.Forms.Label
        Me.txt_WarehouseID = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Txt_QtyJadi = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txt_QtyOrder = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.gv_STB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gv_STB
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_STB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gv_STB.DefaultCellStyle = DataGridViewCellStyle2
        Me.gv_STB.Location = New System.Drawing.Point(12, 231)
        Me.gv_STB.Name = "gv_STB"
        Me.gv_STB.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_STB.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gv_STB.Size = New System.Drawing.Size(760, 275)
        Me.gv_STB.TabIndex = 1
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete, Me.ts_FindPO})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(782, 25)
        Me.Ts_PO.TabIndex = 2
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Size = New System.Drawing.Size(51, 22)
        Me.ts_New.Text = "New"
        Me.ts_New.Visible = False
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
        'ts_FindPO
        '
        Me.ts_FindPO.Image = CType(resources.GetObject("ts_FindPO.Image"), System.Drawing.Image)
        Me.ts_FindPO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_FindPO.Name = "ts_FindPO"
        Me.ts_FindPO.Size = New System.Drawing.Size(84, 22)
        Me.ts_FindPO.Text = "View Stock"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No STB"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Location = New System.Drawing.Point(79, 22)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(108, 20)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tgl STB"
        '
        'lbl_Supplier
        '
        Me.lbl_Supplier.AutoSize = True
        Me.lbl_Supplier.Location = New System.Drawing.Point(343, 24)
        Me.lbl_Supplier.Name = "lbl_Supplier"
        Me.lbl_Supplier.Size = New System.Drawing.Size(65, 13)
        Me.lbl_Supplier.TabIndex = 4
        Me.lbl_Supplier.Text = "PIC Gudang"
        '
        'txt_PICGudang
        '
        Me.txt_PICGudang.BackColor = System.Drawing.SystemColors.Window
        Me.txt_PICGudang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PICGudang.Enabled = False
        Me.txt_PICGudang.Location = New System.Drawing.Point(428, 21)
        Me.txt_PICGudang.Name = "txt_PICGudang"
        Me.txt_PICGudang.Size = New System.Drawing.Size(52, 20)
        Me.txt_PICGudang.TabIndex = 5
        '
        'Lbl_SuppTel
        '
        Me.Lbl_SuppTel.AutoSize = True
        Me.Lbl_SuppTel.Location = New System.Drawing.Point(343, 66)
        Me.Lbl_SuppTel.Name = "Lbl_SuppTel"
        Me.Lbl_SuppTel.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_SuppTel.TabIndex = 20
        Me.Lbl_SuppTel.Text = "Remarks"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.Location = New System.Drawing.Point(489, 13)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(250, 24)
        Me.lbl_status.TabIndex = 23
        Me.lbl_status.Text = "Label9"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "OP No."
        '
        'txt_OPNo
        '
        Me.txt_OPNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_OPNo.Location = New System.Drawing.Point(79, 66)
        Me.txt_OPNo.Name = "txt_OPNo"
        Me.txt_OPNo.Size = New System.Drawing.Size(108, 20)
        Me.txt_OPNo.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_PICName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_WarehouseName)
        Me.Panel1.Controls.Add(Me.txt_Remarks)
        Me.Panel1.Controls.Add(Me.dt_STBDate)
        Me.Panel1.Controls.Add(Me.txt_OPNo)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lbl_status)
        Me.Panel1.Controls.Add(Me.Lbl_SuppTel)
        Me.Panel1.Controls.Add(Me.lbl_SuppName)
        Me.Panel1.Controls.Add(Me.txt_WarehouseID)
        Me.Panel1.Controls.Add(Me.txt_PICGudang)
        Me.Panel1.Controls.Add(Me.lbl_Supplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 118)
        Me.Panel1.TabIndex = 0
        '
        'txt_PICName
        '
        Me.txt_PICName.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_PICName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PICName.Enabled = False
        Me.txt_PICName.Location = New System.Drawing.Point(428, 43)
        Me.txt_PICName.Name = "txt_PICName"
        Me.txt_PICName.Size = New System.Drawing.Size(250, 20)
        Me.txt_PICName.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "PIC Name"
        '
        'txt_WarehouseName
        '
        Me.txt_WarehouseName.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_WarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_WarehouseName.Enabled = False
        Me.txt_WarehouseName.Location = New System.Drawing.Point(146, 91)
        Me.txt_WarehouseName.Name = "txt_WarehouseName"
        Me.txt_WarehouseName.ReadOnly = True
        Me.txt_WarehouseName.Size = New System.Drawing.Size(191, 20)
        Me.txt_WarehouseName.TabIndex = 34
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remarks.Location = New System.Drawing.Point(428, 65)
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(287, 49)
        Me.txt_Remarks.TabIndex = 33
        '
        'dt_STBDate
        '
        Me.dt_STBDate.Location = New System.Drawing.Point(79, 44)
        Me.dt_STBDate.Name = "dt_STBDate"
        Me.dt_STBDate.Size = New System.Drawing.Size(200, 20)
        Me.dt_STBDate.TabIndex = 32
        '
        'lbl_SuppName
        '
        Me.lbl_SuppName.AutoSize = True
        Me.lbl_SuppName.Location = New System.Drawing.Point(16, 96)
        Me.lbl_SuppName.Name = "lbl_SuppName"
        Me.lbl_SuppName.Size = New System.Drawing.Size(45, 13)
        Me.lbl_SuppName.TabIndex = 19
        Me.lbl_SuppName.Text = "Gudang"
        '
        'txt_WarehouseID
        '
        Me.txt_WarehouseID.BackColor = System.Drawing.SystemColors.Window
        Me.txt_WarehouseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_WarehouseID.Location = New System.Drawing.Point(79, 91)
        Me.txt_WarehouseID.Name = "txt_WarehouseID"
        Me.txt_WarehouseID.Size = New System.Drawing.Size(65, 20)
        Me.txt_WarehouseID.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.Txt_QtyJadi)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Txt_QtyOrder)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Txt_UoM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_ItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_ItemID)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(12, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(760, 82)
        Me.Panel2.TabIndex = 24
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
        'Txt_QtyJadi
        '
        Me.Txt_QtyJadi.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_QtyJadi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_QtyJadi.Location = New System.Drawing.Point(594, 24)
        Me.Txt_QtyJadi.Name = "Txt_QtyJadi"
        Me.Txt_QtyJadi.Size = New System.Drawing.Size(61, 20)
        Me.Txt_QtyJadi.TabIndex = 9
        Me.Txt_QtyJadi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(600, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Qty Jadi"
        '
        'Txt_QtyOrder
        '
        Me.Txt_QtyOrder.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_QtyOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_QtyOrder.Location = New System.Drawing.Point(529, 24)
        Me.Txt_QtyOrder.Name = "Txt_QtyOrder"
        Me.Txt_QtyOrder.Size = New System.Drawing.Size(63, 20)
        Me.Txt_QtyOrder.TabIndex = 7
        Me.Txt_QtyOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(533, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Qty Order"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item ID"
        '
        'frmBuktiSerahTerima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 518)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.gv_STB)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuktiSerahTerima"
        Me.Text = "Form Bukti Serah Terima Barang"
        CType(Me.gv_STB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gv_STB As System.Windows.Forms.DataGridView
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_FindPO As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Supplier As System.Windows.Forms.Label
    Friend WithEvents txt_PICGudang As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_SuppTel As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_OPNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_STBDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Txt_QtyJadi As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_QtyOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents txt_PICName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_WarehouseName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SuppName As System.Windows.Forms.Label
    Friend WithEvents txt_WarehouseID As System.Windows.Forms.TextBox

End Class
