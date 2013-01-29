<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferStockToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferStockToko))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ts_edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.cb_warehouse = New System.Windows.Forms.ComboBox
        Me.cb_category = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_Remark = New System.Windows.Forms.TextBox
        Me.dtp_TSDate = New System.Windows.Forms.DateTimePicker
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_Reason = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txt_ket = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Txt_QtyRec = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgv_Detail = New System.Windows.Forms.DataGridView
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_edit, Me.ts_save, Me.ts_approve, Me.ts_reject, Me.ts_delete, Me.ts_cancel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(750, 25)
        Me.ToolStrip.TabIndex = 16
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ts_edit
        '
        Me.ts_edit.Image = CType(resources.GetObject("ts_edit.Image"), System.Drawing.Image)
        Me.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_edit.Name = "ts_edit"
        Me.ts_edit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_edit.Size = New System.Drawing.Size(52, 22)
        Me.ts_edit.Text = "Edit"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_save.Size = New System.Drawing.Size(70, 22)
        Me.ts_save.Text = "Submit"
        '
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_delete.Size = New System.Drawing.Size(65, 22)
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
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_cancel.Size = New System.Drawing.Size(68, 22)
        Me.ts_cancel.Text = "Cancel"
        '
        'cb_warehouse
        '
        Me.cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_warehouse.FormattingEnabled = True
        Me.cb_warehouse.Location = New System.Drawing.Point(102, 68)
        Me.cb_warehouse.Name = "cb_warehouse"
        Me.cb_warehouse.Size = New System.Drawing.Size(194, 22)
        Me.cb_warehouse.TabIndex = 24
        '
        'cb_category
        '
        Me.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_category.FormattingEnabled = True
        Me.cb_category.Items.AddRange(New Object() {"Request From Toko", "Request From Gudang"})
        Me.cb_category.Location = New System.Drawing.Point(102, 40)
        Me.cb_category.Name = "cb_category"
        Me.cb_category.Size = New System.Drawing.Size(194, 22)
        Me.cb_category.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Category"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 14)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Warehouse"
        '
        'txt_Remark
        '
        Me.txt_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remark.Location = New System.Drawing.Point(309, 33)
        Me.txt_Remark.Multiline = True
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(416, 41)
        Me.txt_Remark.TabIndex = 18
        '
        'dtp_TSDate
        '
        Me.dtp_TSDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_TSDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_TSDate.Location = New System.Drawing.Point(102, 95)
        Me.dtp_TSDate.Name = "dtp_TSDate"
        Me.dtp_TSDate.Size = New System.Drawing.Size(123, 22)
        Me.dtp_TSDate.TabIndex = 16
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.Color.LightGray
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.ForeColor = System.Drawing.Color.Gray
        Me.txt_TransNo.Location = New System.Drawing.Point(102, 13)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.ReadOnly = True
        Me.txt_TransNo.Size = New System.Drawing.Size(145, 22)
        Me.txt_TransNo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Remark"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transaction No"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(12, 35)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(719, 23)
        Me.lbl_status.TabIndex = 22
        Me.lbl_status.Text = "lbl_status"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_Reason)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cb_warehouse)
        Me.GroupBox1.Controls.Add(Me.cb_category)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_Remark)
        Me.GroupBox1.Controls.Add(Me.dtp_TSDate)
        Me.GroupBox1.Controls.Add(Me.txt_TransNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(738, 145)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'txt_Reason
        '
        Me.txt_Reason.BackColor = System.Drawing.Color.LightGray
        Me.txt_Reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Reason.ForeColor = System.Drawing.Color.Gray
        Me.txt_Reason.Location = New System.Drawing.Point(310, 93)
        Me.txt_Reason.Multiline = True
        Me.txt_Reason.Name = "txt_Reason"
        Me.txt_Reason.ReadOnly = True
        Me.txt_Reason.Size = New System.Drawing.Size(416, 41)
        Me.txt_Reason.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(307, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Reject Reason"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_ket)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Btn_cancel)
        Me.GroupBox2.Controls.Add(Me.btn_delete)
        Me.GroupBox2.Controls.Add(Me.btn_save)
        Me.GroupBox2.Controls.Add(Me.btn_edit)
        Me.GroupBox2.Controls.Add(Me.btn_insert)
        Me.GroupBox2.Controls.Add(Me.Txt_QtyRec)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Txt_Qty)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Txt_UoM)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_ItemName)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_ItemID)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 205)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(738, 102)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'txt_ket
        '
        Me.txt_ket.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ket.Location = New System.Drawing.Point(530, 37)
        Me.txt_ket.Name = "txt_ket"
        Me.txt_ket.Size = New System.Drawing.Size(196, 21)
        Me.txt_ket.TabIndex = 39
        Me.txt_ket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(538, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Remark"
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(296, 60)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 37
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(225, 60)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 36
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(154, 60)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 35
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(82, 60)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 34
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(10, 60)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 33
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'Txt_QtyRec
        '
        Me.Txt_QtyRec.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_QtyRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_QtyRec.Location = New System.Drawing.Point(459, 37)
        Me.Txt_QtyRec.Name = "Txt_QtyRec"
        Me.Txt_QtyRec.Size = New System.Drawing.Size(68, 21)
        Me.Txt_QtyRec.TabIndex = 32
        Me.Txt_QtyRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(456, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Qty Approved"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(388, 37)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(67, 21)
        Me.Txt_Qty.TabIndex = 30
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(385, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Qty Required"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UoM.Enabled = False
        Me.Txt_UoM.Location = New System.Drawing.Point(336, 37)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(48, 21)
        Me.Txt_UoM.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(339, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "UoM"
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(84, 37)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(248, 21)
        Me.txt_ItemName.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(150, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Location = New System.Drawing.Point(10, 37)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(71, 21)
        Me.txt_ItemID.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Item ID"
        '
        'dgv_Detail
        '
        Me.dgv_Detail.AllowUserToAddRows = False
        Me.dgv_Detail.AllowUserToDeleteRows = False
        Me.dgv_Detail.AllowUserToOrderColumns = True
        Me.dgv_Detail.AllowUserToResizeColumns = False
        Me.dgv_Detail.AllowUserToResizeRows = False
        Me.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Detail.Location = New System.Drawing.Point(6, 313)
        Me.dgv_Detail.Name = "dgv_Detail"
        Me.dgv_Detail.ReadOnly = True
        Me.dgv_Detail.Size = New System.Drawing.Size(738, 259)
        Me.dgv_Detail.TabIndex = 24
        '
        'frmTransferStockToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 579)
        Me.Controls.Add(Me.dgv_Detail)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferStockToko"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer Stock Toko"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_Detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents cb_warehouse As System.Windows.Forms.ComboBox
    Friend WithEvents cb_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents dtp_TSDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Txt_QtyRec As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_Reason As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_Detail As System.Windows.Forms.DataGridView
End Class
