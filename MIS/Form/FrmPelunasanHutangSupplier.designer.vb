<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPelunasanHutangSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPelunasanHutangSupplier))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_DocNo = New System.Windows.Forms.TextBox
        Me.txt_kdSupplier = New System.Windows.Forms.TextBox
        Me.txt_NmSupplier = New System.Windows.Forms.TextBox
        Me.txt_Ket = New System.Windows.Forms.TextBox
        Me.gvPembayaran = New System.Windows.Forms.DataGridView
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.dt_Pelunasan = New System.Windows.Forms.DateTimePicker
        Me.txt_NilaiPO = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_noPO = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_sj = New System.Windows.Forms.TextBox
        Me.txt_invoice = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_totalretur = New System.Windows.Forms.TextBox
        Me.txt_Outstanding = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_jumlahbayar = New System.Windows.Forms.TextBox
        Me.txt_nogiro = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.chk_UangMuka = New System.Windows.Forms.CheckBox
        Me.txt_keterangan = New System.Windows.Forms.TextBox
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.btn_edit = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.btn_save = New System.Windows.Forms.Button
        Me.txt_account = New System.Windows.Forms.TextBox
        Me.btn_delete = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.dt_JatuhTempo = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.list_pembayaran = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtaccountpot = New System.Windows.Forms.TextBox
        Me.txtpot = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.dtTransfer = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtNoRetur = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNamaBank = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDPHNo = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtPeriod = New System.Windows.Forms.TextBox
        CType(Me.gvPembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Dokumen Pelunasan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tanggal Pelunasan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kode Supplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nama Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Keterangan"
        '
        'txt_DocNo
        '
        Me.txt_DocNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_DocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DocNo.Enabled = False
        Me.txt_DocNo.Location = New System.Drawing.Point(174, 40)
        Me.txt_DocNo.Name = "txt_DocNo"
        Me.txt_DocNo.Size = New System.Drawing.Size(118, 20)
        Me.txt_DocNo.TabIndex = 5
        '
        'txt_kdSupplier
        '
        Me.txt_kdSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_kdSupplier.Location = New System.Drawing.Point(174, 136)
        Me.txt_kdSupplier.Name = "txt_kdSupplier"
        Me.txt_kdSupplier.Size = New System.Drawing.Size(118, 20)
        Me.txt_kdSupplier.TabIndex = 7
        '
        'txt_NmSupplier
        '
        Me.txt_NmSupplier.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NmSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NmSupplier.Location = New System.Drawing.Point(174, 162)
        Me.txt_NmSupplier.Name = "txt_NmSupplier"
        Me.txt_NmSupplier.Size = New System.Drawing.Size(118, 20)
        Me.txt_NmSupplier.TabIndex = 8
        '
        'txt_Ket
        '
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Location = New System.Drawing.Point(174, 188)
        Me.txt_Ket.Multiline = True
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(187, 51)
        Me.txt_Ket.TabIndex = 9
        '
        'gvPembayaran
        '
        Me.gvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPembayaran.Location = New System.Drawing.Point(0, 390)
        Me.gvPembayaran.Name = "gvPembayaran"
        Me.gvPembayaran.Size = New System.Drawing.Size(1223, 259)
        Me.gvPembayaran.TabIndex = 0
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1223, 25)
        Me.Ts_PO.TabIndex = 11
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
        '
        'dt_Pelunasan
        '
        Me.dt_Pelunasan.CustomFormat = "dd MMMM yyyy"
        Me.dt_Pelunasan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_Pelunasan.Location = New System.Drawing.Point(174, 85)
        Me.dt_Pelunasan.Name = "dt_Pelunasan"
        Me.dt_Pelunasan.Size = New System.Drawing.Size(130, 20)
        Me.dt_Pelunasan.TabIndex = 12
        '
        'txt_NilaiPO
        '
        Me.txt_NilaiPO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NilaiPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NilaiPO.Enabled = False
        Me.txt_NilaiPO.Location = New System.Drawing.Point(399, 44)
        Me.txt_NilaiPO.Name = "txt_NilaiPO"
        Me.txt_NilaiPO.Size = New System.Drawing.Size(125, 20)
        Me.txt_NilaiPO.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 15)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Doc No"
        '
        'txt_noPO
        '
        Me.txt_noPO.BackColor = System.Drawing.Color.DarkGray
        Me.txt_noPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_noPO.Location = New System.Drawing.Point(124, 48)
        Me.txt_noPO.Name = "txt_noPO"
        Me.txt_noPO.Size = New System.Drawing.Size(141, 20)
        Me.txt_noPO.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Tipe Pembayaran"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(290, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Nilai Hutang"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 15)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Surat Jalan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 15)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Invoice"
        '
        'txt_sj
        '
        Me.txt_sj.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_sj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sj.Enabled = False
        Me.txt_sj.Location = New System.Drawing.Point(124, 71)
        Me.txt_sj.Name = "txt_sj"
        Me.txt_sj.Size = New System.Drawing.Size(141, 20)
        Me.txt_sj.TabIndex = 44
        '
        'txt_invoice
        '
        Me.txt_invoice.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_invoice.Enabled = False
        Me.txt_invoice.Location = New System.Drawing.Point(124, 95)
        Me.txt_invoice.Name = "txt_invoice"
        Me.txt_invoice.Size = New System.Drawing.Size(141, 20)
        Me.txt_invoice.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(290, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 15)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Nilai Retur"
        '
        'txt_totalretur
        '
        Me.txt_totalretur.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_totalretur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_totalretur.Enabled = False
        Me.txt_totalretur.Location = New System.Drawing.Point(399, 93)
        Me.txt_totalretur.Name = "txt_totalretur"
        Me.txt_totalretur.Size = New System.Drawing.Size(125, 20)
        Me.txt_totalretur.TabIndex = 47
        '
        'txt_Outstanding
        '
        Me.txt_Outstanding.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_Outstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Outstanding.Cursor = System.Windows.Forms.Cursors.Default
        Me.txt_Outstanding.Enabled = False
        Me.txt_Outstanding.Location = New System.Drawing.Point(399, 118)
        Me.txt_Outstanding.Name = "txt_Outstanding"
        Me.txt_Outstanding.Size = New System.Drawing.Size(125, 20)
        Me.txt_Outstanding.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(290, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Outstanding"
        '
        'txt_jumlahbayar
        '
        Me.txt_jumlahbayar.BackColor = System.Drawing.Color.DarkGray
        Me.txt_jumlahbayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_jumlahbayar.Location = New System.Drawing.Point(401, 241)
        Me.txt_jumlahbayar.Name = "txt_jumlahbayar"
        Me.txt_jumlahbayar.Size = New System.Drawing.Size(125, 20)
        Me.txt_jumlahbayar.TabIndex = 30
        '
        'txt_nogiro
        '
        Me.txt_nogiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nogiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nogiro.Enabled = False
        Me.txt_nogiro.Location = New System.Drawing.Point(121, 270)
        Me.txt_nogiro.Name = "txt_nogiro"
        Me.txt_nogiro.Size = New System.Drawing.Size(141, 20)
        Me.txt_nogiro.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(292, 267)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Keterangan"
        '
        'chk_UangMuka
        '
        Me.chk_UangMuka.AutoSize = True
        Me.chk_UangMuka.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_UangMuka.Location = New System.Drawing.Point(11, 13)
        Me.chk_UangMuka.Name = "chk_UangMuka"
        Me.chk_UangMuka.Size = New System.Drawing.Size(90, 19)
        Me.chk_UangMuka.TabIndex = 49
        Me.chk_UangMuka.Text = "Uang Muka"
        Me.chk_UangMuka.UseVisualStyleBackColor = True
        '
        'txt_keterangan
        '
        Me.txt_keterangan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_keterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_keterangan.Location = New System.Drawing.Point(401, 266)
        Me.txt_keterangan.Multiline = True
        Me.txt_keterangan.Name = "txt_keterangan"
        Me.txt_keterangan.Size = New System.Drawing.Size(242, 43)
        Me.txt_keterangan.TabIndex = 31
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(424, 345)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 32
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 190)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 15)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Account"
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(495, 345)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 33
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 270)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 15)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "No Giro"
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(568, 345)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 34
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'txt_account
        '
        Me.txt_account.BackColor = System.Drawing.Color.DarkGray
        Me.txt_account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_account.Location = New System.Drawing.Point(121, 189)
        Me.txt_account.Name = "txt_account"
        Me.txt_account.Size = New System.Drawing.Size(141, 20)
        Me.txt_account.TabIndex = 52
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(639, 345)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 35
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(291, 166)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 15)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Jatuh Tempo"
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(709, 345)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 36
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'dt_JatuhTempo
        '
        Me.dt_JatuhTempo.CustomFormat = "dd MMMM yyyy"
        Me.dt_JatuhTempo.Enabled = False
        Me.dt_JatuhTempo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_JatuhTempo.Location = New System.Drawing.Point(399, 163)
        Me.dt_JatuhTempo.Name = "dt_JatuhTempo"
        Me.dt_JatuhTempo.Size = New System.Drawing.Size(138, 20)
        Me.dt_JatuhTempo.TabIndex = 37
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(292, 241)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 15)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "Jumlah Bayar"
        '
        'list_pembayaran
        '
        Me.list_pembayaran.BackColor = System.Drawing.Color.DarkGray
        Me.list_pembayaran.FormattingEnabled = True
        Me.list_pembayaran.Items.AddRange(New Object() {"", "Cash", "Bank", "Giro"})
        Me.list_pembayaran.Location = New System.Drawing.Point(120, 163)
        Me.list_pembayaran.Name = "list_pembayaran"
        Me.list_pembayaran.Size = New System.Drawing.Size(141, 21)
        Me.list_pembayaran.TabIndex = 57
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtaccountpot)
        Me.Panel1.Controls.Add(Me.txtpot)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.dtTransfer)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.txtNoRetur)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtNamaBank)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.list_pembayaran)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.dt_JatuhTempo)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txt_account)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txt_keterangan)
        Me.Panel1.Controls.Add(Me.chk_UangMuka)
        Me.Panel1.Controls.Add(Me.txt_sj)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_NilaiPO)
        Me.Panel1.Controls.Add(Me.txt_nogiro)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_jumlahbayar)
        Me.Panel1.Controls.Add(Me.txt_noPO)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txt_Outstanding)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txt_totalretur)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_invoice)
        Me.Panel1.Location = New System.Drawing.Point(424, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(674, 327)
        Me.Panel1.TabIndex = 58
        '
        'txtaccountpot
        '
        Me.txtaccountpot.BackColor = System.Drawing.Color.DarkGray
        Me.txtaccountpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtaccountpot.Location = New System.Drawing.Point(401, 215)
        Me.txtaccountpot.Name = "txtaccountpot"
        Me.txtaccountpot.Size = New System.Drawing.Size(125, 20)
        Me.txtaccountpot.TabIndex = 68
        '
        'txtpot
        '
        Me.txtpot.BackColor = System.Drawing.Color.DarkGray
        Me.txtpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpot.Location = New System.Drawing.Point(401, 189)
        Me.txtpot.Name = "txtpot"
        Me.txtpot.Size = New System.Drawing.Size(125, 20)
        Me.txtpot.TabIndex = 67
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(293, 215)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(106, 15)
        Me.Label23.TabIndex = 66
        Me.Label23.Text = "Account Potongan"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(292, 190)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 15)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "Potongan"
        '
        'dtTransfer
        '
        Me.dtTransfer.CustomFormat = "dd MMMM yyyy"
        Me.dtTransfer.Enabled = False
        Me.dtTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTransfer.Location = New System.Drawing.Point(121, 244)
        Me.dtTransfer.Name = "dtTransfer"
        Me.dtTransfer.Size = New System.Drawing.Size(138, 20)
        Me.dtTransfer.TabIndex = 64
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(290, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 15)
        Me.Label21.TabIndex = 63
        Me.Label21.Text = "No Retur"
        '
        'txtNoRetur
        '
        Me.txtNoRetur.BackColor = System.Drawing.Color.DarkGray
        Me.txtNoRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoRetur.Enabled = False
        Me.txtNoRetur.Location = New System.Drawing.Point(399, 69)
        Me.txtNoRetur.Name = "txtNoRetur"
        Me.txtNoRetur.Size = New System.Drawing.Size(125, 20)
        Me.txtNoRetur.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Tgl Transfer "
        '
        'txtNamaBank
        '
        Me.txtNamaBank.BackColor = System.Drawing.Color.DarkGray
        Me.txtNamaBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaBank.Enabled = False
        Me.txtNamaBank.Location = New System.Drawing.Point(121, 217)
        Me.txtNamaBank.Name = "txtNamaBank"
        Me.txtNamaBank.Size = New System.Drawing.Size(141, 20)
        Me.txtNamaBank.TabIndex = 59
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Nama Bank"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "No DPH"
        '
        'txtDPHNo
        '
        Me.txtDPHNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDPHNo.Location = New System.Drawing.Point(174, 112)
        Me.txtDPHNo.Name = "txtDPHNo"
        Me.txtDPHNo.Size = New System.Drawing.Size(118, 20)
        Me.txtDPHNo.TabIndex = 60
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(15, 62)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 15)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Period"
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Enabled = False
        Me.txtPeriod.Location = New System.Drawing.Point(174, 61)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(71, 20)
        Me.txtPeriod.TabIndex = 63
        '
        'FrmPelunasanHutangSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 645)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtDPHNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gvPembayaran)
        Me.Controls.Add(Me.dt_Pelunasan)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.txt_Ket)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.txt_NmSupplier)
        Me.Controls.Add(Me.txt_kdSupplier)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.txt_DocNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_insert)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPelunasanHutangSupplier"
        Me.Text = "Pelunasan Hutang Supplier"
        CType(Me.gvPembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_DocNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_kdSupplier As System.Windows.Forms.TextBox
    Friend WithEvents txt_NmSupplier As System.Windows.Forms.TextBox
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents gvPembayaran As System.Windows.Forms.DataGridView
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents dt_Pelunasan As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_NilaiPO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_noPO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_sj As System.Windows.Forms.TextBox
    Friend WithEvents txt_invoice As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_totalretur As System.Windows.Forms.TextBox
    Friend WithEvents txt_Outstanding As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlahbayar As System.Windows.Forms.TextBox
    Friend WithEvents txt_nogiro As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chk_UangMuka As System.Windows.Forms.CheckBox
    Friend WithEvents txt_keterangan As System.Windows.Forms.TextBox
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents txt_account As System.Windows.Forms.TextBox
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents dt_JatuhTempo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents list_pembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDPHNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNamaBank As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNoRetur As System.Windows.Forms.TextBox
    Friend WithEvents dtTransfer As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtaccountpot As System.Windows.Forms.TextBox
    Friend WithEvents txtpot As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
End Class
