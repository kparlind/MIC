<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransFinance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransFinance))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cb_DebitKredit = New System.Windows.Forms.ComboBox
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_FindPO = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dt_finance = New System.Windows.Forms.DateTimePicker
        Me.txt_remarks = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.txt_Ket = New System.Windows.Forms.TextBox
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.txt_Harga = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_NamaCoa = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_KodeCoa = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gv_finance = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTipe = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtket = New System.Windows.Forms.TextBox
        Me.txtHarga = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNamaCOA = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtkdCOA = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.pnlOtomatis = New System.Windows.Forms.Panel
        Me.txtNoGiro = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtNamaBank = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.rdOtomatis = New System.Windows.Forms.RadioButton
        Me.rdBiasa = New System.Windows.Forms.RadioButton
        Me.cmbFinance = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnedit = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lbldebit = New System.Windows.Forms.Label
        Me.lblkredit = New System.Windows.Forms.Label
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gv_finance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtomatis.SuspendLayout()
        Me.SuspendLayout()
        '
        'cb_DebitKredit
        '
        Me.cb_DebitKredit.BackColor = System.Drawing.Color.DarkGray
        Me.cb_DebitKredit.FormattingEnabled = True
        Me.cb_DebitKredit.Items.AddRange(New Object() {"Debet", "Kredit"})
        Me.cb_DebitKredit.Location = New System.Drawing.Point(370, 24)
        Me.cb_DebitKredit.Name = "cb_DebitKredit"
        Me.cb_DebitKredit.Size = New System.Drawing.Size(78, 21)
        Me.cb_DebitKredit.TabIndex = 23
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete, Me.ts_FindPO})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(893, 25)
        Me.Ts_PO.TabIndex = 3
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
        'ts_delete
        '
        Me.ts_delete.Image = CType(resources.GetObject("ts_delete.Image"), System.Drawing.Image)
        Me.ts_delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_delete.Name = "ts_delete"
        Me.ts_delete.Size = New System.Drawing.Size(60, 22)
        Me.ts_delete.Text = "Delete"
        Me.ts_delete.Visible = False
        '
        'ts_FindPO
        '
        Me.ts_FindPO.Image = CType(resources.GetObject("ts_FindPO.Image"), System.Drawing.Image)
        Me.ts_FindPO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_FindPO.Name = "ts_FindPO"
        Me.ts_FindPO.Size = New System.Drawing.Size(69, 22)
        Me.ts_FindPO.Text = "Find PO"
        Me.ts_FindPO.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtPeriod)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.dt_finance)
        Me.Panel1.Controls.Add(Me.txt_remarks)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_TransNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(893, 88)
        Me.Panel1.TabIndex = 4
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Location = New System.Drawing.Point(299, 21)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(71, 20)
        Me.txtPeriod.TabIndex = 52
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(245, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 16)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Period"
        '
        'dt_finance
        '
        Me.dt_finance.CustomFormat = "ddMMMMyyyy"
        Me.dt_finance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_finance.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_finance.Location = New System.Drawing.Point(467, 17)
        Me.dt_finance.Name = "dt_finance"
        Me.dt_finance.Size = New System.Drawing.Size(155, 22)
        Me.dt_finance.TabIndex = 32
        '
        'txt_remarks
        '
        Me.txt_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_remarks.Location = New System.Drawing.Point(115, 47)
        Me.txt_remarks.Name = "txt_remarks"
        Me.txt_remarks.Size = New System.Drawing.Size(724, 22)
        Me.txt_remarks.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Keterangan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(402, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tanggal"
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Location = New System.Drawing.Point(115, 21)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(108, 20)
        Me.txt_TransNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Finance"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cb_DebitKredit)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.txt_Ket)
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.btn_insert)
        Me.Panel2.Controls.Add(Me.txt_Harga)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txt_NamaCoa)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txt_KodeCoa)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(0, 291)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(893, 82)
        Me.Panel2.TabIndex = 25
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(683, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Keterangan"
        '
        'txt_Ket
        '
        Me.txt_Ket.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Location = New System.Drawing.Point(581, 24)
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(306, 20)
        Me.txt_Ket.TabIndex = 21
        Me.txt_Ket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txt_Harga
        '
        Me.txt_Harga.BackColor = System.Drawing.Color.DarkGray
        Me.txt_Harga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Harga.Location = New System.Drawing.Point(450, 24)
        Me.txt_Harga.Name = "txt_Harga"
        Me.txt_Harga.Size = New System.Drawing.Size(129, 20)
        Me.txt_Harga.TabIndex = 11
        Me.txt_Harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(496, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Harga"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(402, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Tipe"
        '
        'txt_NamaCoa
        '
        Me.txt_NamaCoa.BackColor = System.Drawing.Color.DarkGray
        Me.txt_NamaCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NamaCoa.Enabled = False
        Me.txt_NamaCoa.Location = New System.Drawing.Point(94, 24)
        Me.txt_NamaCoa.Name = "txt_NamaCoa"
        Me.txt_NamaCoa.Size = New System.Drawing.Size(274, 20)
        Me.txt_NamaCoa.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Nama CoA"
        '
        'txt_KodeCoa
        '
        Me.txt_KodeCoa.BackColor = System.Drawing.Color.DarkGray
        Me.txt_KodeCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KodeCoa.Location = New System.Drawing.Point(7, 24)
        Me.txt_KodeCoa.Name = "txt_KodeCoa"
        Me.txt_KodeCoa.Size = New System.Drawing.Size(85, 20)
        Me.txt_KodeCoa.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Kode CoA"
        '
        'gv_finance
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_finance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gv_finance.DefaultCellStyle = DataGridViewCellStyle5
        Me.gv_finance.Location = New System.Drawing.Point(0, 379)
        Me.gv_finance.Name = "gv_finance"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gv_finance.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gv_finance.Size = New System.Drawing.Size(893, 211)
        Me.gv_finance.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Jurnal"
        '
        'cmbTipe
        '
        Me.cmbTipe.BackColor = System.Drawing.Color.DarkGray
        Me.cmbTipe.FormattingEnabled = True
        Me.cmbTipe.Items.AddRange(New Object() {"Debet", "Kredit"})
        Me.cmbTipe.Location = New System.Drawing.Point(370, 110)
        Me.cmbTipe.Name = "cmbTipe"
        Me.cmbTipe.Size = New System.Drawing.Size(78, 21)
        Me.cmbTipe.TabIndex = 44
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(683, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Keterangan"
        '
        'txtket
        '
        Me.txtket.BackColor = System.Drawing.Color.DarkGray
        Me.txtket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtket.Location = New System.Drawing.Point(581, 110)
        Me.txtket.Name = "txtket"
        Me.txtket.Size = New System.Drawing.Size(306, 20)
        Me.txtket.TabIndex = 42
        Me.txtket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHarga
        '
        Me.txtHarga.BackColor = System.Drawing.Color.DarkGray
        Me.txtHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHarga.Location = New System.Drawing.Point(450, 110)
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(129, 20)
        Me.txtHarga.TabIndex = 41
        Me.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(496, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Harga"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(402, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Tipe"
        '
        'txtNamaCOA
        '
        Me.txtNamaCOA.BackColor = System.Drawing.Color.DarkGray
        Me.txtNamaCOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaCOA.Enabled = False
        Me.txtNamaCOA.Location = New System.Drawing.Point(94, 110)
        Me.txtNamaCOA.Name = "txtNamaCOA"
        Me.txtNamaCOA.Size = New System.Drawing.Size(274, 20)
        Me.txtNamaCOA.TabIndex = 38
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(147, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Nama CoA"
        '
        'txtkdCOA
        '
        Me.txtkdCOA.BackColor = System.Drawing.Color.DarkGray
        Me.txtkdCOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtkdCOA.Location = New System.Drawing.Point(7, 110)
        Me.txtkdCOA.Name = "txtkdCOA"
        Me.txtkdCOA.Size = New System.Drawing.Size(85, 20)
        Me.txtkdCOA.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Kode CoA"
        '
        'pnlOtomatis
        '
        Me.pnlOtomatis.Controls.Add(Me.txtNoGiro)
        Me.pnlOtomatis.Controls.Add(Me.Label19)
        Me.pnlOtomatis.Controls.Add(Me.txtNamaBank)
        Me.pnlOtomatis.Controls.Add(Me.Label17)
        Me.pnlOtomatis.Controls.Add(Me.rdOtomatis)
        Me.pnlOtomatis.Controls.Add(Me.rdBiasa)
        Me.pnlOtomatis.Controls.Add(Me.cmbFinance)
        Me.pnlOtomatis.Controls.Add(Me.Label13)
        Me.pnlOtomatis.Controls.Add(Me.Label4)
        Me.pnlOtomatis.Controls.Add(Me.cmbTipe)
        Me.pnlOtomatis.Controls.Add(Me.Label6)
        Me.pnlOtomatis.Controls.Add(Me.txtket)
        Me.pnlOtomatis.Controls.Add(Me.txtHarga)
        Me.pnlOtomatis.Controls.Add(Me.Label7)
        Me.pnlOtomatis.Controls.Add(Me.Label9)
        Me.pnlOtomatis.Controls.Add(Me.txtNamaCOA)
        Me.pnlOtomatis.Controls.Add(Me.Label10)
        Me.pnlOtomatis.Controls.Add(Me.txtkdCOA)
        Me.pnlOtomatis.Controls.Add(Me.Label11)
        Me.pnlOtomatis.Location = New System.Drawing.Point(0, 119)
        Me.pnlOtomatis.Name = "pnlOtomatis"
        Me.pnlOtomatis.Size = New System.Drawing.Size(893, 133)
        Me.pnlOtomatis.TabIndex = 45
        '
        'txtNoGiro
        '
        Me.txtNoGiro.Location = New System.Drawing.Point(482, 40)
        Me.txtNoGiro.Name = "txtNoGiro"
        Me.txtNoGiro.Size = New System.Drawing.Size(89, 20)
        Me.txtNoGiro.TabIndex = 55
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(422, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 16)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "No Giro"
        '
        'txtNamaBank
        '
        Me.txtNamaBank.Location = New System.Drawing.Point(342, 41)
        Me.txtNamaBank.Name = "txtNamaBank"
        Me.txtNamaBank.Size = New System.Drawing.Size(74, 20)
        Me.txtNamaBank.TabIndex = 53
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(259, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 16)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Nama Bank"
        '
        'rdOtomatis
        '
        Me.rdOtomatis.AutoSize = True
        Me.rdOtomatis.Location = New System.Drawing.Point(192, 14)
        Me.rdOtomatis.Name = "rdOtomatis"
        Me.rdOtomatis.Size = New System.Drawing.Size(66, 17)
        Me.rdOtomatis.TabIndex = 51
        Me.rdOtomatis.TabStop = True
        Me.rdOtomatis.Text = "Otomatis"
        Me.rdOtomatis.UseVisualStyleBackColor = True
        '
        'rdBiasa
        '
        Me.rdBiasa.AutoSize = True
        Me.rdBiasa.Location = New System.Drawing.Point(96, 14)
        Me.rdBiasa.Name = "rdBiasa"
        Me.rdBiasa.Size = New System.Drawing.Size(51, 17)
        Me.rdBiasa.TabIndex = 50
        Me.rdBiasa.TabStop = True
        Me.rdBiasa.Text = "Biasa"
        Me.rdBiasa.UseVisualStyleBackColor = True
        '
        'cmbFinance
        '
        Me.cmbFinance.Enabled = False
        Me.cmbFinance.FormattingEnabled = True
        Me.cmbFinance.Items.AddRange(New Object() {"Cash In", "Cash Out", "Bank In", "Bank Out", "Giro In", "Giro Out"})
        Me.cmbFinance.Location = New System.Drawing.Point(121, 42)
        Me.cmbFinance.Name = "cmbFinance"
        Me.cmbFinance.Size = New System.Drawing.Size(121, 21)
        Me.cmbFinance.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(21, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Tipe Finance"
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(7, 258)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(71, 27)
        Me.btnsave.TabIndex = 45
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Location = New System.Drawing.Point(79, 258)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(71, 27)
        Me.btnedit.TabIndex = 46
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(112, 593)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Total Debit :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.Location = New System.Drawing.Point(226, 593)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Total Kredit :"
        '
        'lbldebit
        '
        Me.lbldebit.AutoSize = True
        Me.lbldebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldebit.Location = New System.Drawing.Point(115, 615)
        Me.lbldebit.Name = "lbldebit"
        Me.lbldebit.Size = New System.Drawing.Size(16, 16)
        Me.lbldebit.TabIndex = 49
        Me.lbldebit.Text = "0"
        '
        'lblkredit
        '
        Me.lblkredit.AutoSize = True
        Me.lblkredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblkredit.Location = New System.Drawing.Point(238, 615)
        Me.lblkredit.Name = "lblkredit"
        Me.lblkredit.Size = New System.Drawing.Size(16, 16)
        Me.lblkredit.TabIndex = 50
        Me.lblkredit.Text = "0"
        '
        'FrmTransFinance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 667)
        Me.Controls.Add(Me.lblkredit)
        Me.Controls.Add(Me.lbldebit)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.pnlOtomatis)
        Me.Controls.Add(Me.gv_finance)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Ts_PO)
        Me.Name = "FrmTransFinance"
        Me.Text = "Transaksi Finance"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gv_finance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtomatis.ResumeLayout(False)
        Me.pnlOtomatis.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_FindPO As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dt_finance As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txt_Harga As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_NamaCoa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_KodeCoa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gv_finance As System.Windows.Forms.DataGridView
    Friend WithEvents cb_DebitKredit As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipe As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtket As System.Windows.Forms.TextBox
    Friend WithEvents txtHarga As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNamaCOA As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtkdCOA As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlOtomatis As System.Windows.Forms.Panel
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents cmbFinance As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdOtomatis As System.Windows.Forms.RadioButton
    Friend WithEvents rdBiasa As System.Windows.Forms.RadioButton
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbldebit As System.Windows.Forms.Label
    Friend WithEvents lblkredit As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtNamaBank As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNoGiro As System.Windows.Forms.TextBox
End Class
