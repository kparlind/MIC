<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMemoRetur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMemoRetur))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dt_MemoDate = New System.Windows.Forms.DateTimePicker
        Me.txt_Remark = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.txt_Keterangan = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Txt_Qty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_UoM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_ItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gv_Memo = New System.Windows.Forms.DataGridView
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gv_Memo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete, Me.ts_approve, Me.ts_reject})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(823, 25)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dt_MemoDate)
        Me.Panel1.Controls.Add(Me.txt_Remark)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 87)
        Me.Panel1.TabIndex = 4
        '
        'dt_MemoDate
        '
        Me.dt_MemoDate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_MemoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_MemoDate.Location = New System.Drawing.Point(420, 14)
        Me.dt_MemoDate.Name = "dt_MemoDate"
        Me.dt_MemoDate.Size = New System.Drawing.Size(199, 20)
        Me.dt_MemoDate.TabIndex = 32
        '
        'txt_Remark
        '
        Me.txt_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remark.Location = New System.Drawing.Point(107, 40)
        Me.txt_Remark.Name = "txt_Remark"
        Me.txt_Remark.Size = New System.Drawing.Size(691, 20)
        Me.txt_Remark.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Keterangan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tgl Memo"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Location = New System.Drawing.Point(107, 13)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(199, 20)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Memo"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.txt_Keterangan)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Txt_Qty)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Txt_UoM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txt_ItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_ItemID)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 112)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(823, 88)
        Me.Panel2.TabIndex = 26
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(354, 52)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(83, 29)
        Me.Btn_cancel.TabIndex = 20
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(268, 52)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(83, 29)
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(183, 52)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(83, 29)
        Me.btn_save.TabIndex = 18
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(99, 52)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(83, 29)
        Me.btn_edit.TabIndex = 17
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(13, 53)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(83, 29)
        Me.btn_insert.TabIndex = 16
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'txt_Keterangan
        '
        Me.txt_Keterangan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Keterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Keterangan.Enabled = False
        Me.txt_Keterangan.Location = New System.Drawing.Point(481, 26)
        Me.txt_Keterangan.Name = "txt_Keterangan"
        Me.txt_Keterangan.Size = New System.Drawing.Size(311, 20)
        Me.txt_Keterangan.TabIndex = 15
        Me.txt_Keterangan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(585, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Keterangan"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Qty.Enabled = False
        Me.Txt_Qty.Location = New System.Drawing.Point(429, 26)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(50, 20)
        Me.Txt_Qty.TabIndex = 7
        Me.Txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(434, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Qty"
        '
        'Txt_UoM
        '
        Me.Txt_UoM.BackColor = System.Drawing.Color.DarkGray
        Me.Txt_UoM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UoM.Enabled = False
        Me.Txt_UoM.Location = New System.Drawing.Point(371, 26)
        Me.Txt_UoM.Name = "Txt_UoM"
        Me.Txt_UoM.Size = New System.Drawing.Size(56, 20)
        Me.Txt_UoM.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(370, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "UoM"
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemName.Enabled = False
        Me.txt_ItemName.Location = New System.Drawing.Point(71, 26)
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.Size = New System.Drawing.Size(298, 20)
        Me.txt_ItemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(126, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Name"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.BackColor = System.Drawing.Color.DarkGray
        Me.txt_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ItemID.Enabled = False
        Me.txt_ItemID.Location = New System.Drawing.Point(12, 26)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(56, 20)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item ID"
        '
        'gv_Memo
        '
        Me.gv_Memo.AllowUserToAddRows = False
        Me.gv_Memo.AllowUserToDeleteRows = False
        Me.gv_Memo.AllowUserToOrderColumns = True
        Me.gv_Memo.AllowUserToResizeColumns = False
        Me.gv_Memo.AllowUserToResizeRows = False
        Me.gv_Memo.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_Memo.Location = New System.Drawing.Point(0, 200)
        Me.gv_Memo.Name = "gv_Memo"
        Me.gv_Memo.ReadOnly = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_Memo.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gv_Memo.Size = New System.Drawing.Size(823, 212)
        Me.gv_Memo.TabIndex = 27
        '
        'FrmMemoRetur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 418)
        Me.Controls.Add(Me.gv_Memo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Name = "FrmMemoRetur"
        Me.Text = "Memo Retur"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gv_Memo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_MemoDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Remark As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txt_Keterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txt_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_UoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gv_Memo As System.Windows.Forms.DataGridView
End Class
