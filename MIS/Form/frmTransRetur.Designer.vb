<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransRetur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransRetur))
        Me.txtnoTB = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dt_Retur = New System.Windows.Forms.DateTimePicker
        Me.txtSupplierNm = New System.Windows.Forms.TextBox
        Me.txtReturNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSupplierID = New System.Windows.Forms.TextBox
        Me.cbReturTipe = New System.Windows.Forms.ComboBox
        Me.gvRetur = New System.Windows.Forms.DataGridView
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.txtUnitP = New System.Windows.Forms.TextBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.txtUOM = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtKet = New System.Windows.Forms.TextBox
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.gvRetur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtnoTB
        '
        Me.txtnoTB.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtnoTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnoTB.Location = New System.Drawing.Point(117, 55)
        Me.txtnoTB.Name = "txtnoTB"
        Me.txtnoTB.Size = New System.Drawing.Size(118, 20)
        Me.txtnoTB.TabIndex = 90
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 15)
        Me.Label21.TabIndex = 89
        Me.Label21.Text = "No TB"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(256, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Supplier ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "No Retur"
        '
        'dt_Retur
        '
        Me.dt_Retur.CalendarMonthBackground = System.Drawing.Color.LemonChiffon
        Me.dt_Retur.CustomFormat = "dd MMMM yyyy"
        Me.dt_Retur.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_Retur.Location = New System.Drawing.Point(117, 84)
        Me.dt_Retur.Name = "dt_Retur"
        Me.dt_Retur.Size = New System.Drawing.Size(130, 20)
        Me.dt_Retur.TabIndex = 86
        '
        'txtSupplierNm
        '
        Me.txtSupplierNm.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSupplierNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierNm.Location = New System.Drawing.Point(361, 53)
        Me.txtSupplierNm.Name = "txtSupplierNm"
        Me.txtSupplierNm.ReadOnly = True
        Me.txtSupplierNm.Size = New System.Drawing.Size(118, 20)
        Me.txtSupplierNm.TabIndex = 85
        '
        'txtReturNo
        '
        Me.txtReturNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtReturNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturNo.Enabled = False
        Me.txtReturNo.Location = New System.Drawing.Point(117, 29)
        Me.txtReturNo.Name = "txtReturNo"
        Me.txtReturNo.Size = New System.Drawing.Size(118, 20)
        Me.txtReturNo.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(256, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Supplier Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Tanggal Retur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Retur Tipe"
        '
        'txtSupplierID
        '
        Me.txtSupplierID.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSupplierID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupplierID.Location = New System.Drawing.Point(361, 27)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.Size = New System.Drawing.Size(118, 20)
        Me.txtSupplierID.TabIndex = 92
        '
        'cbReturTipe
        '
        Me.cbReturTipe.FormattingEnabled = True
        Me.cbReturTipe.Items.AddRange(New Object() {"", "Retur Supplier", "Retur Pakai"})
        Me.cbReturTipe.Location = New System.Drawing.Point(361, 80)
        Me.cbReturTipe.Name = "cbReturTipe"
        Me.cbReturTipe.Size = New System.Drawing.Size(121, 21)
        Me.cbReturTipe.TabIndex = 93
        '
        'gvRetur
        '
        Me.gvRetur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvRetur.Location = New System.Drawing.Point(0, 254)
        Me.gvRetur.Name = "gvRetur"
        Me.gvRetur.Size = New System.Drawing.Size(751, 222)
        Me.gvRetur.TabIndex = 94
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(216, 221)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 99
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(146, 221)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 98
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Enabled = False
        Me.btn_save.Location = New System.Drawing.Point(76, 221)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 97
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(6, 221)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 96
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(751, 25)
        Me.Ts_PO.TabIndex = 100
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Size = New System.Drawing.Size(23, 22)
        Me.ts_New.Text = "New"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Item ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(145, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Item Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(322, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 15)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "UOM"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(397, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 15)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Quantity"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(461, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Unit Price"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(539, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 15)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "Amount"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(639, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 15)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Reason"
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.Color.DarkGray
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Location = New System.Drawing.Point(607, 195)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(140, 20)
        Me.txtReason.TabIndex = 112
        Me.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQuantity
        '
        Me.txtQuantity.BackColor = System.Drawing.Color.DarkGray
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Location = New System.Drawing.Point(404, 195)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(48, 20)
        Me.txtQuantity.TabIndex = 110
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(78, 195)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(226, 20)
        Me.txt_ItemName.TabIndex = 109
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Enabled = False
        Me.txt_ItemID.Location = New System.Drawing.Point(6, 195)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(71, 20)
        Me.txt_ItemID.TabIndex = 108
        '
        'txtUnitP
        '
        Me.txtUnitP.BackColor = System.Drawing.Color.DarkGray
        Me.txtUnitP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitP.Enabled = False
        Me.txtUnitP.Location = New System.Drawing.Point(453, 195)
        Me.txtUnitP.Name = "txtUnitP"
        Me.txtUnitP.Size = New System.Drawing.Size(76, 20)
        Me.txtUnitP.TabIndex = 113
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.DarkGray
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Enabled = False
        Me.txtAmount.Location = New System.Drawing.Point(530, 195)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(76, 20)
        Me.txtAmount.TabIndex = 114
        '
        'txtUOM
        '
        Me.txtUOM.BackColor = System.Drawing.Color.DarkGray
        Me.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOM.Enabled = False
        Me.txtUOM.Location = New System.Drawing.Point(305, 195)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.Size = New System.Drawing.Size(98, 20)
        Me.txtUOM.TabIndex = 115
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 111)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 15)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Keterangan"
        '
        'txtKet
        '
        Me.txtKet.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKet.Location = New System.Drawing.Point(117, 110)
        Me.txtKet.Multiline = True
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(241, 52)
        Me.txtKet.TabIndex = 117
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Location = New System.Drawing.Point(571, 24)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(71, 20)
        Me.txtPeriod.TabIndex = 119
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(504, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 15)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Period"
        '
        'frmTransRetur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 454)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtKet)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtUOM)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.txtUnitP)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.txt_ItemName)
        Me.Controls.Add(Me.txt_ItemID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.gvRetur)
        Me.Controls.Add(Me.cbReturTipe)
        Me.Controls.Add(Me.txtSupplierID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnoTB)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dt_Retur)
        Me.Controls.Add(Me.txtSupplierNm)
        Me.Controls.Add(Me.txtReturNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmTransRetur"
        Me.Text = "Form Retur"
        CType(Me.gvRetur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtnoTB As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dt_Retur As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierNm As System.Windows.Forms.TextBox
    Friend WithEvents txtReturNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents cbReturTipe As System.Windows.Forms.ComboBox
    Friend WithEvents gvRetur As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitP As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtKet As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
