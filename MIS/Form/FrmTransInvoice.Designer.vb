<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransInvoice))
        Me.txtNmCustomer = New System.Windows.Forms.TextBox
        Me.btn_print = New System.Windows.Forms.Button
        Me.txtSalesman = New System.Windows.Forms.TextBox
        Me.dt_Invoice = New System.Windows.Forms.DateTimePicker
        Me.txt_DocNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gvInvoice = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtkdCustomer = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.DPP = New System.Windows.Forms.Label
        Me.lblppn = New System.Windows.Forms.Label
        Me.lbltotal = New System.Windows.Forms.Label
        Me.chkUangMuka = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtjatuhtempo = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.txtJumlahUang = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtKet = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtProjectNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDPP = New System.Windows.Forms.TextBox
        Me.txtppn = New System.Windows.Forms.TextBox
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTOP = New System.Windows.Forms.TextBox
        Me.txtPaymentDay = New System.Windows.Forms.TextBox
        Me.cb_FakturType = New System.Windows.Forms.ComboBox
        Me.txtpph = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        CType(Me.gvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNmCustomer
        '
        Me.txtNmCustomer.BackColor = System.Drawing.Color.DarkGray
        Me.txtNmCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNmCustomer.Enabled = False
        Me.txtNmCustomer.Location = New System.Drawing.Point(151, 106)
        Me.txtNmCustomer.Name = "txtNmCustomer"
        Me.txtNmCustomer.Size = New System.Drawing.Size(118, 20)
        Me.txtNmCustomer.TabIndex = 61
        '
        'btn_print
        '
        Me.btn_print.Location = New System.Drawing.Point(16, 419)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(338, 45)
        Me.btn_print.TabIndex = 60
        Me.btn_print.Text = "Print"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'txtSalesman
        '
        Me.txtSalesman.BackColor = System.Drawing.Color.DarkGray
        Me.txtSalesman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesman.Location = New System.Drawing.Point(10, 27)
        Me.txtSalesman.Name = "txtSalesman"
        Me.txtSalesman.Size = New System.Drawing.Size(118, 20)
        Me.txtSalesman.TabIndex = 59
        '
        'dt_Invoice
        '
        Me.dt_Invoice.CustomFormat = "dd-MM-yyyy"
        Me.dt_Invoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_Invoice.Location = New System.Drawing.Point(459, 85)
        Me.dt_Invoice.Name = "dt_Invoice"
        Me.dt_Invoice.Size = New System.Drawing.Size(118, 20)
        Me.dt_Invoice.TabIndex = 58
        '
        'txt_DocNo
        '
        Me.txt_DocNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_DocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DocNo.Enabled = False
        Me.txt_DocNo.Location = New System.Drawing.Point(151, 40)
        Me.txt_DocNo.Name = "txt_DocNo"
        Me.txt_DocNo.Size = New System.Drawing.Size(118, 20)
        Me.txt_DocNo.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Nama Salesman"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Nama Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(319, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Tanggal Faktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "No Faktur"
        '
        'gvInvoice
        '
        Me.gvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvInvoice.Location = New System.Drawing.Point(0, 268)
        Me.gvInvoice.Name = "gvInvoice"
        Me.gvInvoice.Size = New System.Drawing.Size(817, 127)
        Me.gvInvoice.TabIndex = 62
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Tipe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Kode Customer"
        '
        'txtkdCustomer
        '
        Me.txtkdCustomer.BackColor = System.Drawing.SystemColors.Menu
        Me.txtkdCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtkdCustomer.Location = New System.Drawing.Point(151, 84)
        Me.txtkdCustomer.Name = "txtkdCustomer"
        Me.txtkdCustomer.Size = New System.Drawing.Size(118, 20)
        Me.txtkdCustomer.TabIndex = 67
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(558, 415)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 15)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "DPP"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(558, 459)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "PPN 10%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(558, 481)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 15)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "Total"
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(817, 25)
        Me.Ts_PO.TabIndex = 82
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
        'DPP
        '
        Me.DPP.AutoSize = True
        Me.DPP.Cursor = System.Windows.Forms.Cursors.Default
        Me.DPP.Location = New System.Drawing.Point(295, 416)
        Me.DPP.Name = "DPP"
        Me.DPP.Size = New System.Drawing.Size(0, 13)
        Me.DPP.TabIndex = 83
        '
        'lblppn
        '
        Me.lblppn.AutoSize = True
        Me.lblppn.Location = New System.Drawing.Point(295, 440)
        Me.lblppn.Name = "lblppn"
        Me.lblppn.Size = New System.Drawing.Size(0, 13)
        Me.lblppn.TabIndex = 84
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Location = New System.Drawing.Point(295, 467)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(0, 13)
        Me.lbltotal.TabIndex = 85
        '
        'chkUangMuka
        '
        Me.chkUangMuka.AutoSize = True
        Me.chkUangMuka.Location = New System.Drawing.Point(701, 28)
        Me.chkUangMuka.Name = "chkUangMuka"
        Me.chkUangMuka.Size = New System.Drawing.Size(82, 17)
        Me.chkUangMuka.TabIndex = 86
        Me.chkUangMuka.Text = "Uang Muka"
        Me.chkUangMuka.UseVisualStyleBackColor = True
        Me.chkUangMuka.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(319, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 15)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Tanggal Jatuh Tempo"
        '
        'txtjatuhtempo
        '
        Me.txtjatuhtempo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtjatuhtempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtjatuhtempo.Enabled = False
        Me.txtjatuhtempo.Location = New System.Drawing.Point(459, 108)
        Me.txtjatuhtempo.Name = "txtjatuhtempo"
        Me.txtjatuhtempo.ReadOnly = True
        Me.txtjatuhtempo.Size = New System.Drawing.Size(118, 20)
        Me.txtjatuhtempo.TabIndex = 89
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Btn_cancel)
        Me.Panel1.Controls.Add(Me.btn_delete)
        Me.Panel1.Controls.Add(Me.btn_save)
        Me.Panel1.Controls.Add(Me.btn_edit)
        Me.Panel1.Controls.Add(Me.btn_insert)
        Me.Panel1.Controls.Add(Me.txtJumlahUang)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtKet)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtProjectNo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtSalesman)
        Me.Panel1.Location = New System.Drawing.Point(5, 164)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 98)
        Me.Panel1.TabIndex = 90
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(287, 55)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 92
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(217, 55)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 91
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(147, 55)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 90
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(77, 55)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 89
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(7, 55)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 88
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'txtJumlahUang
        '
        Me.txtJumlahUang.BackColor = System.Drawing.Color.DarkGray
        Me.txtJumlahUang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahUang.Location = New System.Drawing.Point(432, 27)
        Me.txtJumlahUang.Name = "txtJumlahUang"
        Me.txtJumlahUang.Size = New System.Drawing.Size(118, 20)
        Me.txtJumlahUang.TabIndex = 87
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(453, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Jumlah Uang"
        '
        'txtKet
        '
        Me.txtKet.BackColor = System.Drawing.Color.DarkGray
        Me.txtKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKet.Location = New System.Drawing.Point(248, 27)
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(183, 20)
        Me.txtKet.TabIndex = 85
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(305, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Keterangan"
        '
        'txtProjectNo
        '
        Me.txtProjectNo.BackColor = System.Drawing.Color.DarkGray
        Me.txtProjectNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProjectNo.Location = New System.Drawing.Point(129, 27)
        Me.txtProjectNo.Name = "txtProjectNo"
        Me.txtProjectNo.Size = New System.Drawing.Size(118, 20)
        Me.txtProjectNo.TabIndex = 83
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(156, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 15)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Project No"
        '
        'txtDPP
        '
        Me.txtDPP.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtDPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDPP.Enabled = False
        Me.txtDPP.Location = New System.Drawing.Point(651, 415)
        Me.txtDPP.Name = "txtDPP"
        Me.txtDPP.Size = New System.Drawing.Size(132, 20)
        Me.txtDPP.TabIndex = 91
        Me.txtDPP.Text = "0"
        Me.txtDPP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtppn
        '
        Me.txtppn.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtppn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtppn.Enabled = False
        Me.txtppn.Location = New System.Drawing.Point(651, 457)
        Me.txtppn.Name = "txtppn"
        Me.txtppn.Size = New System.Drawing.Size(132, 20)
        Me.txtppn.TabIndex = 92
        Me.txtppn.Text = "0"
        Me.txtppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttotal.Enabled = False
        Me.txttotal.Location = New System.Drawing.Point(651, 478)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(132, 20)
        Me.txttotal.TabIndex = 93
        Me.txttotal.Text = "0"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.Color.DarkGray
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Location = New System.Drawing.Point(151, 62)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(72, 20)
        Me.txtPeriod.TabIndex = 95
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 15)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Period"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(320, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 15)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "Term Of Payment"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(320, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 15)
        Me.Label16.TabIndex = 97
        Me.Label16.Text = "Payment Day"
        '
        'txtTOP
        '
        Me.txtTOP.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtTOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTOP.Enabled = False
        Me.txtTOP.Location = New System.Drawing.Point(459, 40)
        Me.txtTOP.Name = "txtTOP"
        Me.txtTOP.ReadOnly = True
        Me.txtTOP.Size = New System.Drawing.Size(118, 20)
        Me.txtTOP.TabIndex = 98
        '
        'txtPaymentDay
        '
        Me.txtPaymentDay.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPaymentDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaymentDay.Enabled = False
        Me.txtPaymentDay.Location = New System.Drawing.Point(459, 62)
        Me.txtPaymentDay.Name = "txtPaymentDay"
        Me.txtPaymentDay.ReadOnly = True
        Me.txtPaymentDay.Size = New System.Drawing.Size(118, 20)
        Me.txtPaymentDay.TabIndex = 99
        '
        'cb_FakturType
        '
        Me.cb_FakturType.FormattingEnabled = True
        Me.cb_FakturType.Items.AddRange(New Object() {"Uang Muka", "Cicilan Instalasi", "Retention"})
        Me.cb_FakturType.Location = New System.Drawing.Point(151, 132)
        Me.cb_FakturType.Name = "cb_FakturType"
        Me.cb_FakturType.Size = New System.Drawing.Size(121, 21)
        Me.cb_FakturType.TabIndex = 100
        '
        'txtpph
        '
        Me.txtpph.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtpph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpph.Enabled = False
        Me.txtpph.Location = New System.Drawing.Point(651, 436)
        Me.txtpph.Name = "txtpph"
        Me.txtpph.Size = New System.Drawing.Size(132, 20)
        Me.txtpph.TabIndex = 102
        Me.txtpph.Text = "0"
        Me.txtpph.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(558, 437)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 15)
        Me.Label17.TabIndex = 101
        Me.Label17.Text = "PPH 23"
        '
        'FrmTransInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 540)
        Me.Controls.Add(Me.txtpph)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cb_FakturType)
        Me.Controls.Add(Me.txtPaymentDay)
        Me.Controls.Add(Me.txtTOP)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtppn)
        Me.Controls.Add(Me.txtDPP)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtjatuhtempo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtkdCustomer)
        Me.Controls.Add(Me.txtNmCustomer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkUangMuka)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.lblppn)
        Me.Controls.Add(Me.DPP)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gvInvoice)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.dt_Invoice)
        Me.Controls.Add(Me.txt_DocNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmTransInvoice"
        Me.Text = "Invoice Piutang"
        CType(Me.gvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNmCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btn_print As System.Windows.Forms.Button
    Friend WithEvents txtSalesman As System.Windows.Forms.TextBox
    Friend WithEvents dt_Invoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_DocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gvInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtkdCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents DPP As System.Windows.Forms.Label
    Friend WithEvents lblppn As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents chkUangMuka As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtjatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txtJumlahUang As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtKet As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDPP As System.Windows.Forms.TextBox
    Friend WithEvents txtppn As System.Windows.Forms.TextBox
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTOP As System.Windows.Forms.TextBox
    Friend WithEvents txtPaymentDay As System.Windows.Forms.TextBox
    Friend WithEvents cb_FakturType As System.Windows.Forms.ComboBox
    Friend WithEvents txtpph As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
