<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequestPembelianBrg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRequestPembelianBrg))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txt_Reason = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lbl_OverLimit = New System.Windows.Forms.Label
        Me.txt_ProjectNo = New System.Windows.Forms.TextBox
        Me.lbl_ProjectNo = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb_jasa = New System.Windows.Forms.RadioButton
        Me.rb_item = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_remarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_department = New System.Windows.Forms.TextBox
        Me.dt_PRDate = New System.Windows.Forms.DateTimePicker
        Me.txt_Requester = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.P_waPembelianBrg = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_remarksItem = New System.Windows.Forms.TextBox
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.P_waPembelianJasa = New System.Windows.Forms.Panel
        Me.btn_cancelJasa = New System.Windows.Forms.Button
        Me.btn_deleteJasa = New System.Windows.Forms.Button
        Me.btn_SaveJasa = New System.Windows.Forms.Button
        Me.btn_editJasa = New System.Windows.Forms.Button
        Me.btn_InsertJasa = New System.Windows.Forms.Button
        Me.txt_RemarksJasa = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_JasaName = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_JasaID = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.gv_PRDtl = New System.Windows.Forms.DataGridView
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.P_waPembelianBrg.SuspendLayout()
        Me.P_waPembelianJasa.SuspendLayout()
        CType(Me.gv_PRDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.BackColor = System.Drawing.Color.DarkGray
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save, Me.ts_approve, Me.ts_reject, Me.ts_delete, Me.ts_cancel})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(977, 25)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_Reason)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lbl_OverLimit)
        Me.Panel1.Controls.Add(Me.txt_ProjectNo)
        Me.Panel1.Controls.Add(Me.lbl_ProjectNo)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txt_remarks)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txt_department)
        Me.Panel1.Controls.Add(Me.dt_PRDate)
        Me.Panel1.Controls.Add(Me.txt_Requester)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lbl_status)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(977, 210)
        Me.Panel1.TabIndex = 4
        '
        'txt_Reason
        '
        Me.txt_Reason.BackColor = System.Drawing.Color.LightGray
        Me.txt_Reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Reason.ForeColor = System.Drawing.Color.Gray
        Me.txt_Reason.Location = New System.Drawing.Point(419, 142)
        Me.txt_Reason.Multiline = True
        Me.txt_Reason.Name = "txt_Reason"
        Me.txt_Reason.ReadOnly = True
        Me.txt_Reason.Size = New System.Drawing.Size(537, 41)
        Me.txt_Reason.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 14)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Reject Reason"
        '
        'lbl_OverLimit
        '
        Me.lbl_OverLimit.AutoSize = True
        Me.lbl_OverLimit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_OverLimit.ForeColor = System.Drawing.Color.Red
        Me.lbl_OverLimit.Location = New System.Drawing.Point(11, 190)
        Me.lbl_OverLimit.Name = "lbl_OverLimit"
        Me.lbl_OverLimit.Size = New System.Drawing.Size(87, 14)
        Me.lbl_OverLimit.TabIndex = 40
        Me.lbl_OverLimit.Text = "lbl_OverLimit"
        '
        'txt_ProjectNo
        '
        Me.txt_ProjectNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ProjectNo.Location = New System.Drawing.Point(419, 114)
        Me.txt_ProjectNo.Name = "txt_ProjectNo"
        Me.txt_ProjectNo.Size = New System.Drawing.Size(154, 22)
        Me.txt_ProjectNo.TabIndex = 39
        '
        'lbl_ProjectNo
        '
        Me.lbl_ProjectNo.AutoSize = True
        Me.lbl_ProjectNo.Location = New System.Drawing.Point(322, 116)
        Me.lbl_ProjectNo.Name = "lbl_ProjectNo"
        Me.lbl_ProjectNo.Size = New System.Drawing.Size(65, 14)
        Me.lbl_ProjectNo.TabIndex = 38
        Me.lbl_ProjectNo.Text = "Project No"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_jasa)
        Me.GroupBox1.Controls.Add(Me.rb_item)
        Me.GroupBox1.Location = New System.Drawing.Point(99, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 63)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'rb_jasa
        '
        Me.rb_jasa.AutoSize = True
        Me.rb_jasa.Location = New System.Drawing.Point(9, 40)
        Me.rb_jasa.Name = "rb_jasa"
        Me.rb_jasa.Size = New System.Drawing.Size(102, 18)
        Me.rb_jasa.TabIndex = 2
        Me.rb_jasa.TabStop = True
        Me.rb_jasa.Text = "PembelianJasa"
        Me.rb_jasa.UseVisualStyleBackColor = True
        '
        'rb_item
        '
        Me.rb_item.AutoSize = True
        Me.rb_item.Checked = True
        Me.rb_item.Location = New System.Drawing.Point(9, 16)
        Me.rb_item.Name = "rb_item"
        Me.rb_item.Size = New System.Drawing.Size(121, 18)
        Me.rb_item.TabIndex = 0
        Me.rb_item.TabStop = True
        Me.rb_item.Text = "Pembelian Barang"
        Me.rb_item.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Request Type"
        '
        'txt_remarks
        '
        Me.txt_remarks.BackColor = System.Drawing.SystemColors.Window
        Me.txt_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_remarks.Location = New System.Drawing.Point(420, 69)
        Me.txt_remarks.Multiline = True
        Me.txt_remarks.Name = "txt_remarks"
        Me.txt_remarks.Size = New System.Drawing.Size(537, 39)
        Me.txt_remarks.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(322, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Remark"
        '
        'txt_department
        '
        Me.txt_department.BackColor = System.Drawing.Color.LightGray
        Me.txt_department.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_department.ForeColor = System.Drawing.Color.Gray
        Me.txt_department.Location = New System.Drawing.Point(420, 41)
        Me.txt_department.Name = "txt_department"
        Me.txt_department.ReadOnly = True
        Me.txt_department.Size = New System.Drawing.Size(239, 22)
        Me.txt_department.TabIndex = 33
        '
        'dt_PRDate
        '
        Me.dt_PRDate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_PRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_PRDate.Location = New System.Drawing.Point(420, 9)
        Me.dt_PRDate.Name = "dt_PRDate"
        Me.dt_PRDate.Size = New System.Drawing.Size(163, 22)
        Me.dt_PRDate.TabIndex = 32
        '
        'txt_Requester
        '
        Me.txt_Requester.BackColor = System.Drawing.Color.LightGray
        Me.txt_Requester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Requester.ForeColor = System.Drawing.Color.Gray
        Me.txt_Requester.Location = New System.Drawing.Point(99, 39)
        Me.txt_Requester.Name = "txt_Requester"
        Me.txt_Requester.ReadOnly = True
        Me.txt_Requester.Size = New System.Drawing.Size(179, 22)
        Me.txt_Requester.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(322, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Department"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(593, 9)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(364, 26)
        Me.lbl_status.TabIndex = 23
        Me.lbl_status.Text = "lblStatus"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Requester"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(322, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "PR Date"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.Color.LightGray
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.ForeColor = System.Drawing.Color.Gray
        Me.txt_TransNo.Location = New System.Drawing.Point(99, 13)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.ReadOnly = True
        Me.txt_TransNo.Size = New System.Drawing.Size(126, 22)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PR No."
        '
        'P_waPembelianBrg
        '
        Me.P_waPembelianBrg.Controls.Add(Me.Label10)
        Me.P_waPembelianBrg.Controls.Add(Me.txt_remarksItem)
        Me.P_waPembelianBrg.Controls.Add(Me.Btn_cancel)
        Me.P_waPembelianBrg.Controls.Add(Me.btn_delete)
        Me.P_waPembelianBrg.Controls.Add(Me.btn_save)
        Me.P_waPembelianBrg.Controls.Add(Me.btn_edit)
        Me.P_waPembelianBrg.Controls.Add(Me.btn_insert)
        Me.P_waPembelianBrg.Controls.Add(Me.Txt_Qty)
        Me.P_waPembelianBrg.Controls.Add(Me.Label8)
        Me.P_waPembelianBrg.Controls.Add(Me.Txt_UoM)
        Me.P_waPembelianBrg.Controls.Add(Me.Label7)
        Me.P_waPembelianBrg.Controls.Add(Me.txt_ItemName)
        Me.P_waPembelianBrg.Controls.Add(Me.Label6)
        Me.P_waPembelianBrg.Controls.Add(Me.txt_ItemID)
        Me.P_waPembelianBrg.Controls.Add(Me.Label9)
        Me.P_waPembelianBrg.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_waPembelianBrg.Location = New System.Drawing.Point(0, 235)
        Me.P_waPembelianBrg.Name = "P_waPembelianBrg"
        Me.P_waPembelianBrg.Size = New System.Drawing.Size(977, 88)
        Me.P_waPembelianBrg.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(719, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Information"
        '
        'txt_remarksItem
        '
        Me.txt_remarksItem.BackColor = System.Drawing.Color.DarkGray
        Me.txt_remarksItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_remarksItem.Enabled = False
        Me.txt_remarksItem.Location = New System.Drawing.Point(630, 26)
        Me.txt_remarksItem.Name = "txt_remarksItem"
        Me.txt_remarksItem.Size = New System.Drawing.Size(335, 22)
        Me.txt_remarksItem.TabIndex = 21
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
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(574, 26)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(54, 22)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(590, 9)
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
        Me.Txt_UoM.Location = New System.Drawing.Point(517, 26)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(56, 22)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(533, 9)
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
        Me.txt_ItemName.Size = New System.Drawing.Size(423, 22)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Item Name"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 14)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Item ID"
        '
        'P_waPembelianJasa
        '
        Me.P_waPembelianJasa.Controls.Add(Me.btn_cancelJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.btn_deleteJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.btn_SaveJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.btn_editJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.btn_InsertJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.txt_RemarksJasa)
        Me.P_waPembelianJasa.Controls.Add(Me.Label11)
        Me.P_waPembelianJasa.Controls.Add(Me.txt_JasaName)
        Me.P_waPembelianJasa.Controls.Add(Me.Label14)
        Me.P_waPembelianJasa.Controls.Add(Me.txt_JasaID)
        Me.P_waPembelianJasa.Controls.Add(Me.Label15)
        Me.P_waPembelianJasa.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_waPembelianJasa.Location = New System.Drawing.Point(0, 323)
        Me.P_waPembelianJasa.Name = "P_waPembelianJasa"
        Me.P_waPembelianJasa.Size = New System.Drawing.Size(977, 88)
        Me.P_waPembelianJasa.TabIndex = 29
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
        'txt_RemarksJasa
        '
        Me.txt_RemarksJasa.BackColor = System.Drawing.Color.DarkGray
        Me.txt_RemarksJasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_RemarksJasa.Enabled = False
        Me.txt_RemarksJasa.Location = New System.Drawing.Point(517, 26)
        Me.txt_RemarksJasa.Name = "txt_RemarksJasa"
        Me.txt_RemarksJasa.Size = New System.Drawing.Size(391, 22)
        Me.txt_RemarksJasa.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(659, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 14)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Information"
        '
        'txt_JasaName
        '
        Me.txt_JasaName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaName.Enabled = False
        Me.txt_JasaName.Location = New System.Drawing.Point(92, 26)
        Me.txt_JasaName.Name = "txt_JasaName"
        Me.txt_JasaName.Size = New System.Drawing.Size(423, 22)
        Me.txt_JasaName.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(226, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 14)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Jasa Name"
        '
        'txt_JasaID
        '
        Me.txt_JasaID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_JasaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_JasaID.Location = New System.Drawing.Point(8, 26)
        Me.txt_JasaID.Name = "txt_JasaID"
        Me.txt_JasaID.Size = New System.Drawing.Size(82, 22)
        Me.txt_JasaID.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(24, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 14)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Jasa ID"
        '
        'gv_PRDtl
        '
        Me.gv_PRDtl.AllowUserToAddRows = False
        Me.gv_PRDtl.AllowUserToDeleteRows = False
        Me.gv_PRDtl.AllowUserToOrderColumns = True
        Me.gv_PRDtl.AllowUserToResizeColumns = False
        Me.gv_PRDtl.AllowUserToResizeRows = False
        Me.gv_PRDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_PRDtl.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_PRDtl.Location = New System.Drawing.Point(0, 411)
        Me.gv_PRDtl.Name = "gv_PRDtl"
        Me.gv_PRDtl.ReadOnly = True
        Me.gv_PRDtl.Size = New System.Drawing.Size(977, 183)
        Me.gv_PRDtl.TabIndex = 30
        '
        'frmRequestPembelianBrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 597)
        Me.Controls.Add(Me.gv_PRDtl)
        Me.Controls.Add(Me.P_waPembelianJasa)
        Me.Controls.Add(Me.P_waPembelianBrg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRequestPembelianBrg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Permintaan Pembelian Barang"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.P_waPembelianBrg.ResumeLayout(False)
        Me.P_waPembelianBrg.PerformLayout()
        Me.P_waPembelianJasa.ResumeLayout(False)
        Me.P_waPembelianJasa.PerformLayout()
        CType(Me.gv_PRDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_PRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Requester As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_department As System.Windows.Forms.TextBox
    Friend WithEvents txt_remarks As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_item As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents P_waPembelianBrg As System.Windows.Forms.Panel
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents P_waPembelianJasa As System.Windows.Forms.Panel
    Friend WithEvents btn_cancelJasa As System.Windows.Forms.Button
    Friend WithEvents btn_deleteJasa As System.Windows.Forms.Button
    Friend WithEvents btn_SaveJasa As System.Windows.Forms.Button
    Friend WithEvents btn_editJasa As System.Windows.Forms.Button
    Friend WithEvents btn_InsertJasa As System.Windows.Forms.Button
    Friend WithEvents txt_RemarksJasa As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_JasaName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_JasaID As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gv_PRDtl As System.Windows.Forms.DataGridView
    Friend WithEvents txt_remarksItem As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ProjectNo As System.Windows.Forms.Label
    Friend WithEvents rb_jasa As System.Windows.Forms.RadioButton
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl_OverLimit As System.Windows.Forms.Label
    Friend WithEvents txt_Reason As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
