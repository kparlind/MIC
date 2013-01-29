<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSPK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSPK))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ts_Print = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.txt_Remarks = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dt_SPKDate = New System.Windows.Forms.DateTimePicker
        Me.txt_ProjectNo = New System.Windows.Forms.TextBox
        Me.txt_PIC = New System.Windows.Forms.TextBox
        Me.Lbl_SuppTel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_CustomerName = New System.Windows.Forms.TextBox
        Me.txt_CustomerID = New System.Windows.Forms.TextBox
        Me.lbl_Supplier = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtTotalMinute = New System.Windows.Forms.TextBox
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_Ket = New System.Windows.Forms.TextBox
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.txt_NamaProses = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txt_KdProses = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_TeknisiName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_TeknisiID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.gv_spk = New System.Windows.Forms.DataGridView
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gv_spk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.BackColor = System.Drawing.Color.DarkGray
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete, Me.ToolStripSeparator1, Me.ts_Print})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(973, 25)
        Me.Ts_PO.TabIndex = 3
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ts_New.Size = New System.Drawing.Size(56, 22)
        Me.ts_New.Text = "New"
        Me.ts_New.Visible = False
        '
        'ts_Edit
        '
        Me.ts_Edit.Image = CType(resources.GetObject("ts_Edit.Image"), System.Drawing.Image)
        Me.ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Edit.Name = "ts_Edit"
        Me.ts_Edit.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ts_Edit.Size = New System.Drawing.Size(52, 22)
        Me.ts_Edit.Text = "Edit"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ts_save.Size = New System.Drawing.Size(56, 22)
        Me.ts_save.Text = "Save"
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ts_cancel.Size = New System.Drawing.Size(68, 22)
        Me.ts_cancel.Text = "Cancel"
        '
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ts_delete.Size = New System.Drawing.Size(65, 22)
        Me.ts_delete.Text = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ts_Print
        '
        Me.ts_Print.Image = CType(resources.GetObject("ts_Print.Image"), System.Drawing.Image)
        Me.ts_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Print.Name = "ts_Print"
        Me.ts_Print.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ts_Print.Size = New System.Drawing.Size(62, 22)
        Me.ts_Print.Text = "Print"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cboType)
        Me.Panel1.Controls.Add(Me.txt_Remarks)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dt_SPKDate)
        Me.Panel1.Controls.Add(Me.txt_ProjectNo)
        Me.Panel1.Controls.Add(Me.txt_PIC)
        Me.Panel1.Controls.Add(Me.Lbl_SuppTel)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txt_CustomerName)
        Me.Panel1.Controls.Add(Me.txt_CustomerID)
        Me.Panel1.Controls.Add(Me.lbl_Supplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(10, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 153)
        Me.Panel1.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "SPK Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Items.AddRange(New Object() {"Project", "Order Maintenance"})
        Me.cboType.Location = New System.Drawing.Point(115, 65)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(146, 22)
        Me.cboType.TabIndex = 51
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Remarks.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Remarks.Location = New System.Drawing.Point(115, 120)
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(692, 22)
        Me.txt_Remarks.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Remarks"
        '
        'dt_SPKDate
        '
        Me.dt_SPKDate.CustomFormat = "dd-MMM-yyyy"
        Me.dt_SPKDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_SPKDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_SPKDate.Location = New System.Drawing.Point(116, 40)
        Me.dt_SPKDate.Name = "dt_SPKDate"
        Me.dt_SPKDate.Size = New System.Drawing.Size(110, 22)
        Me.dt_SPKDate.TabIndex = 2
        '
        'txt_ProjectNo
        '
        Me.txt_ProjectNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ProjectNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProjectNo.Location = New System.Drawing.Point(115, 93)
        Me.txt_ProjectNo.Name = "txt_ProjectNo"
        Me.txt_ProjectNo.Size = New System.Drawing.Size(108, 22)
        Me.txt_ProjectNo.TabIndex = 3
        '
        'txt_PIC
        '
        Me.txt_PIC.BackColor = System.Drawing.Color.LightGray
        Me.txt_PIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PIC.Enabled = False
        Me.txt_PIC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PIC.Location = New System.Drawing.Point(459, 40)
        Me.txt_PIC.Name = "txt_PIC"
        Me.txt_PIC.Size = New System.Drawing.Size(182, 22)
        Me.txt_PIC.TabIndex = 21
        '
        'Lbl_SuppTel
        '
        Me.Lbl_SuppTel.AutoSize = True
        Me.Lbl_SuppTel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SuppTel.Location = New System.Drawing.Point(348, 42)
        Me.Lbl_SuppTel.Name = "Lbl_SuppTel"
        Me.Lbl_SuppTel.Size = New System.Drawing.Size(25, 14)
        Me.Lbl_SuppTel.TabIndex = 20
        Me.Lbl_SuppTel.Text = "PIC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Reference No."
        '
        'txt_CustomerName
        '
        Me.txt_CustomerName.BackColor = System.Drawing.Color.LightGray
        Me.txt_CustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CustomerName.Enabled = False
        Me.txt_CustomerName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CustomerName.Location = New System.Drawing.Point(512, 12)
        Me.txt_CustomerName.Name = "txt_CustomerName"
        Me.txt_CustomerName.Size = New System.Drawing.Size(349, 22)
        Me.txt_CustomerName.TabIndex = 6
        '
        'txt_CustomerID
        '
        Me.txt_CustomerID.BackColor = System.Drawing.Color.LightGray
        Me.txt_CustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CustomerID.Enabled = False
        Me.txt_CustomerID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CustomerID.Location = New System.Drawing.Point(459, 12)
        Me.txt_CustomerID.Name = "txt_CustomerID"
        Me.txt_CustomerID.Size = New System.Drawing.Size(52, 22)
        Me.txt_CustomerID.TabIndex = 5
        '
        'lbl_Supplier
        '
        Me.lbl_Supplier.AutoSize = True
        Me.lbl_Supplier.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplier.Location = New System.Drawing.Point(348, 14)
        Me.lbl_Supplier.Name = "lbl_Supplier"
        Me.lbl_Supplier.Size = New System.Drawing.Size(59, 14)
        Me.lbl_Supplier.TabIndex = 4
        Me.lbl_Supplier.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SPK Date"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.Color.LightGray
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TransNo.Location = New System.Drawing.Point(116, 12)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(108, 22)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SPK No."
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtTotalMinute)
        Me.Panel2.Controls.Add(Me.dt_from)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txt_Ket)
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.txt_NamaProses)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Txt_KdProses)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txt_TeknisiName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_TeknisiID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(10, 244)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(954, 82)
        Me.Panel2.TabIndex = 26
        '
        'txtTotalMinute
        '
        Me.txtTotalMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMinute.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMinute.Location = New System.Drawing.Point(607, 25)
        Me.txtTotalMinute.Name = "txtTotalMinute"
        Me.txtTotalMinute.Size = New System.Drawing.Size(103, 22)
        Me.txtTotalMinute.TabIndex = 25
        Me.txtTotalMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dt_from
        '
        Me.dt_from.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame
        Me.dt_from.CustomFormat = "dd-MMM-yyyy"
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(504, 24)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(101, 22)
        Me.dt_from.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(634, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Total Minute"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(505, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Begin Date"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(709, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 14)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Detail Remarks"
        '
        'txt_Ket
        '
        Me.txt_Ket.BackColor = System.Drawing.Color.LightGray
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Location = New System.Drawing.Point(711, 25)
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(231, 22)
        Me.txt_Ket.TabIndex = 9
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(293, 50)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 14
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(222, 50)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 13
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(151, 50)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 12
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(79, 50)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 11
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(7, 50)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 10
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'txt_NamaProses
        '
        Me.txt_NamaProses.BackColor = System.Drawing.Color.LightGray
        Me.txt_NamaProses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NamaProses.Location = New System.Drawing.Point(359, 24)
        Me.txt_NamaProses.Name = "txt_NamaProses"
        Me.txt_NamaProses.ReadOnly = True
        Me.txt_NamaProses.Size = New System.Drawing.Size(142, 22)
        Me.txt_NamaProses.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(357, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 14)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Process Description"
        '
        'Txt_KdProses
        '
        Me.Txt_KdProses.BackColor = System.Drawing.Color.LightGray
        Me.Txt_KdProses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_KdProses.Location = New System.Drawing.Point(294, 24)
        Me.Txt_KdProses.Name = "Txt_KdProses"
        Me.Txt_KdProses.Size = New System.Drawing.Size(64, 22)
        Me.Txt_KdProses.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(293, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 14)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Process ID"
        '
        'txt_TeknisiName
        '
        Me.txt_TeknisiName.BackColor = System.Drawing.Color.LightGray
        Me.txt_TeknisiName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TeknisiName.Location = New System.Drawing.Point(79, 24)
        Me.txt_TeknisiName.Name = "txt_TeknisiName"
        Me.txt_TeknisiName.ReadOnly = True
        Me.txt_TeknisiName.Size = New System.Drawing.Size(214, 22)
        Me.txt_TeknisiName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Technician Name"
        '
        'txt_TeknisiID
        '
        Me.txt_TeknisiID.BackColor = System.Drawing.Color.LightGray
        Me.txt_TeknisiID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TeknisiID.Location = New System.Drawing.Point(7, 24)
        Me.txt_TeknisiID.Name = "txt_TeknisiID"
        Me.txt_TeknisiID.Size = New System.Drawing.Size(71, 22)
        Me.txt_TeknisiID.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tech. ID"
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(577, 33)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(387, 24)
        Me.lbl_status.TabIndex = 27
        Me.lbl_status.Text = "Label9"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gv_spk
        '
        Me.gv_spk.AllowUserToAddRows = False
        Me.gv_spk.AllowUserToDeleteRows = False
        Me.gv_spk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_spk.Location = New System.Drawing.Point(10, 332)
        Me.gv_spk.Name = "gv_spk"
        Me.gv_spk.ReadOnly = True
        Me.gv_spk.Size = New System.Drawing.Size(953, 264)
        Me.gv_spk.TabIndex = 28
        '
        'frmSPK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 608)
        Me.Controls.Add(Me.gv_spk)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSPK"
        Me.Text = ":: Surat Perintah Kerja ::"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gv_spk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_SPKDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_ProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_PIC As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_SuppTel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_CustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txt_CustomerID As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Supplier As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txt_NamaProses As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_KdProses As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_TeknisiName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_TeknisiID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents txtTotalMinute As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ts_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents gv_spk As System.Windows.Forms.DataGridView
End Class
