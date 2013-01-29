<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPelunasanPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPelunasanPiutang))
        Me.list_pembayaran = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.dt_JatuhTempo = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_account = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_keterangan = New System.Windows.Forms.TextBox
        Me.chk_UangMuka = New System.Windows.Forms.CheckBox
        Me.txt_nmCus = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_NilaiPO = New System.Windows.Forms.TextBox
        Me.txt_nogiro = New System.Windows.Forms.TextBox
        Me.txt_noPR = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_jumlahbayar = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.txt_Outstanding = New System.Windows.Forms.TextBox
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtTransfer = New System.Windows.Forms.DateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtNamaBank = New System.Windows.Forms.TextBox
        Me.txt_accountpot = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_fakturtipe = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_cusID = New System.Windows.Forms.TextBox
        Me.txt_potongan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_invoice = New System.Windows.Forms.TextBox
        Me.gvPembayaran = New System.Windows.Forms.DataGridView
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.txt_Ket = New System.Windows.Forms.TextBox
        Me.dt_Pelunasan = New System.Windows.Forms.DateTimePicker
        Me.txt_NmKolektor = New System.Windows.Forms.TextBox
        Me.txt_DocNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_emp = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtnoDPP = New System.Windows.Forms.TextBox
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtOutstandingInv = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.chkInvoice = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        CType(Me.gvPembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.SuspendLayout()
        '
        'list_pembayaran
        '
        Me.list_pembayaran.BackColor = System.Drawing.Color.DarkGray
        Me.list_pembayaran.FormattingEnabled = True
        Me.list_pembayaran.Items.AddRange(New Object() {"", "Cash", "Bank", "Giro"})
        Me.list_pembayaran.Location = New System.Drawing.Point(415, 13)
        Me.list_pembayaran.Name = "list_pembayaran"
        Me.list_pembayaran.Size = New System.Drawing.Size(141, 21)
        Me.list_pembayaran.TabIndex = 57
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(14, 61)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 15)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "Jumlah Bayar"
        '
        'dt_JatuhTempo
        '
        Me.dt_JatuhTempo.CustomFormat = "dd MMMM yyyy"
        Me.dt_JatuhTempo.Enabled = False
        Me.dt_JatuhTempo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_JatuhTempo.Location = New System.Drawing.Point(415, 81)
        Me.dt_JatuhTempo.Name = "dt_JatuhTempo"
        Me.dt_JatuhTempo.Size = New System.Drawing.Size(139, 20)
        Me.dt_JatuhTempo.TabIndex = 37
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(305, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 15)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Jatuh Tempo"
        '
        'txt_account
        '
        Me.txt_account.BackColor = System.Drawing.Color.DarkGray
        Me.txt_account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_account.Location = New System.Drawing.Point(416, 37)
        Me.txt_account.Name = "txt_account"
        Me.txt_account.Size = New System.Drawing.Size(141, 20)
        Me.txt_account.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(305, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 15)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "No Giro"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(305, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 15)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "COA Pembayaran"
        '
        'txt_keterangan
        '
        Me.txt_keterangan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_keterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_keterangan.Location = New System.Drawing.Point(417, 104)
        Me.txt_keterangan.Multiline = True
        Me.txt_keterangan.Name = "txt_keterangan"
        Me.txt_keterangan.Size = New System.Drawing.Size(242, 43)
        Me.txt_keterangan.TabIndex = 31
        '
        'chk_UangMuka
        '
        Me.chk_UangMuka.AutoSize = True
        Me.chk_UangMuka.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_UangMuka.Location = New System.Drawing.Point(313, 263)
        Me.chk_UangMuka.Name = "chk_UangMuka"
        Me.chk_UangMuka.Size = New System.Drawing.Size(90, 19)
        Me.chk_UangMuka.TabIndex = 49
        Me.chk_UangMuka.Text = "Uang Muka"
        Me.chk_UangMuka.UseVisualStyleBackColor = True
        '
        'txt_nmCus
        '
        Me.txt_nmCus.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_nmCus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nmCus.Enabled = False
        Me.txt_nmCus.Location = New System.Drawing.Point(136, 261)
        Me.txt_nmCus.Name = "txt_nmCus"
        Me.txt_nmCus.Size = New System.Drawing.Size(141, 20)
        Me.txt_nmCus.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(305, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Keterangan"
        '
        'txt_NilaiPO
        '
        Me.txt_NilaiPO.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NilaiPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NilaiPO.Enabled = False
        Me.txt_NilaiPO.Location = New System.Drawing.Point(420, 217)
        Me.txt_NilaiPO.Name = "txt_NilaiPO"
        Me.txt_NilaiPO.Size = New System.Drawing.Size(140, 20)
        Me.txt_NilaiPO.TabIndex = 30
        '
        'txt_nogiro
        '
        Me.txt_nogiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nogiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nogiro.Enabled = False
        Me.txt_nogiro.Location = New System.Drawing.Point(416, 59)
        Me.txt_nogiro.Name = "txt_nogiro"
        Me.txt_nogiro.Size = New System.Drawing.Size(141, 20)
        Me.txt_nogiro.TabIndex = 29
        '
        'txt_noPR
        '
        Me.txt_noPR.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_noPR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_noPR.Location = New System.Drawing.Point(136, 217)
        Me.txt_noPR.Name = "txt_noPR"
        Me.txt_noPR.Size = New System.Drawing.Size(141, 20)
        Me.txt_noPR.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 15)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "No Project"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 15)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "No Dokumen Pelunasan"
        '
        'txt_jumlahbayar
        '
        Me.txt_jumlahbayar.BackColor = System.Drawing.Color.DarkGray
        Me.txt_jumlahbayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_jumlahbayar.Location = New System.Drawing.Point(134, 61)
        Me.txt_jumlahbayar.Name = "txt_jumlahbayar"
        Me.txt_jumlahbayar.Size = New System.Drawing.Size(125, 20)
        Me.txt_jumlahbayar.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(310, 242)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Outstanding"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(305, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Tipe Pembayaran"
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(731, 317)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 75
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'txt_Outstanding
        '
        Me.txt_Outstanding.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_Outstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Outstanding.Cursor = System.Windows.Forms.Cursors.Default
        Me.txt_Outstanding.Enabled = False
        Me.txt_Outstanding.Location = New System.Drawing.Point(420, 238)
        Me.txt_Outstanding.Name = "txt_Outstanding"
        Me.txt_Outstanding.Size = New System.Drawing.Size(140, 20)
        Me.txt_Outstanding.TabIndex = 39
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(661, 317)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 74
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(591, 317)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 73
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(310, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Nilai Piutang"
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(521, 317)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 72
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(450, 317)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 71
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 260)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 15)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Nama Customer"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkInvoice)
        Me.Panel1.Controls.Add(Me.txtOutstandingInv)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.dtTransfer)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txtNamaBank)
        Me.Panel1.Controls.Add(Me.txt_accountpot)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txt_fakturtipe)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txt_cusID)
        Me.Panel1.Controls.Add(Me.txt_potongan)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.list_pembayaran)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txt_keterangan)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.dt_JatuhTempo)
        Me.Panel1.Controls.Add(Me.chk_UangMuka)
        Me.Panel1.Controls.Add(Me.txt_jumlahbayar)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txt_nmCus)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_account)
        Me.Panel1.Controls.Add(Me.txt_invoice)
        Me.Panel1.Controls.Add(Me.txt_Outstanding)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txt_NilaiPO)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txt_nogiro)
        Me.Panel1.Controls.Add(Me.txt_noPR)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(450, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 299)
        Me.Panel1.TabIndex = 76
        '
        'dtTransfer
        '
        Me.dtTransfer.CustomFormat = "dd MMMM yyyy"
        Me.dtTransfer.Enabled = False
        Me.dtTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTransfer.Location = New System.Drawing.Point(134, 169)
        Me.dtTransfer.Name = "dtTransfer"
        Me.dtTransfer.Size = New System.Drawing.Size(141, 20)
        Me.dtTransfer.TabIndex = 71
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(14, 169)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 15)
        Me.Label24.TabIndex = 70
        Me.Label24.Text = "Tgl Transfer"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(14, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 15)
        Me.Label23.TabIndex = 69
        Me.Label23.Text = "Nama Bank"
        '
        'txtNamaBank
        '
        Me.txtNamaBank.BackColor = System.Drawing.Color.DarkGray
        Me.txtNamaBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaBank.Enabled = False
        Me.txtNamaBank.Location = New System.Drawing.Point(134, 147)
        Me.txtNamaBank.Name = "txtNamaBank"
        Me.txtNamaBank.Size = New System.Drawing.Size(125, 20)
        Me.txtNamaBank.TabIndex = 68
        '
        'txt_accountpot
        '
        Me.txt_accountpot.BackColor = System.Drawing.Color.DarkGray
        Me.txt_accountpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_accountpot.Location = New System.Drawing.Point(134, 126)
        Me.txt_accountpot.Name = "txt_accountpot"
        Me.txt_accountpot.Size = New System.Drawing.Size(125, 20)
        Me.txt_accountpot.TabIndex = 65
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 15)
        Me.Label16.TabIndex = 64
        Me.Label16.Text = "COA Potongan"
        '
        'txt_fakturtipe
        '
        Me.txt_fakturtipe.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_fakturtipe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_fakturtipe.Location = New System.Drawing.Point(134, 40)
        Me.txt_fakturtipe.Name = "txt_fakturtipe"
        Me.txt_fakturtipe.ReadOnly = True
        Me.txt_fakturtipe.Size = New System.Drawing.Size(125, 20)
        Me.txt_fakturtipe.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Tipe Invoice"
        '
        'txt_cusID
        '
        Me.txt_cusID.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_cusID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_cusID.Enabled = False
        Me.txt_cusID.Location = New System.Drawing.Point(136, 239)
        Me.txt_cusID.Name = "txt_cusID"
        Me.txt_cusID.Size = New System.Drawing.Size(141, 20)
        Me.txt_cusID.TabIndex = 61
        '
        'txt_potongan
        '
        Me.txt_potongan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_potongan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_potongan.Location = New System.Drawing.Point(134, 104)
        Me.txt_potongan.Name = "txt_potongan"
        Me.txt_potongan.Size = New System.Drawing.Size(125, 20)
        Me.txt_potongan.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Potongan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Customer ID"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 15)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Invoice"
        '
        'txt_invoice
        '
        Me.txt_invoice.BackColor = System.Drawing.Color.DarkGray
        Me.txt_invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_invoice.Location = New System.Drawing.Point(134, 19)
        Me.txt_invoice.Name = "txt_invoice"
        Me.txt_invoice.Size = New System.Drawing.Size(125, 20)
        Me.txt_invoice.TabIndex = 45
        '
        'gvPembayaran
        '
        Me.gvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPembayaran.Location = New System.Drawing.Point(0, 364)
        Me.gvPembayaran.Name = "gvPembayaran"
        Me.gvPembayaran.Size = New System.Drawing.Size(1459, 210)
        Me.gvPembayaran.TabIndex = 59
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1452, 25)
        Me.Ts_PO.TabIndex = 69
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
        'txt_Ket
        '
        Me.txt_Ket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Ket.Location = New System.Drawing.Point(171, 196)
        Me.txt_Ket.Multiline = True
        Me.txt_Ket.Name = "txt_Ket"
        Me.txt_Ket.Size = New System.Drawing.Size(247, 51)
        Me.txt_Ket.TabIndex = 68
        '
        'dt_Pelunasan
        '
        Me.dt_Pelunasan.CalendarMonthBackground = System.Drawing.Color.LemonChiffon
        Me.dt_Pelunasan.CustomFormat = "dd MMMM yyyy"
        Me.dt_Pelunasan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_Pelunasan.Location = New System.Drawing.Point(171, 118)
        Me.dt_Pelunasan.Name = "dt_Pelunasan"
        Me.dt_Pelunasan.Size = New System.Drawing.Size(130, 20)
        Me.dt_Pelunasan.TabIndex = 70
        '
        'txt_NmKolektor
        '
        Me.txt_NmKolektor.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NmKolektor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NmKolektor.Location = New System.Drawing.Point(171, 170)
        Me.txt_NmKolektor.Name = "txt_NmKolektor"
        Me.txt_NmKolektor.ReadOnly = True
        Me.txt_NmKolektor.Size = New System.Drawing.Size(118, 20)
        Me.txt_NmKolektor.TabIndex = 67
        '
        'txt_DocNo
        '
        Me.txt_DocNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_DocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DocNo.Enabled = False
        Me.txt_DocNo.Location = New System.Drawing.Point(171, 41)
        Me.txt_DocNo.Name = "txt_DocNo"
        Me.txt_DocNo.Size = New System.Drawing.Size(118, 20)
        Me.txt_DocNo.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Keterangan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Nama Kolektor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 15)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Tanggal Penerimaan Uang"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Kolektor ID"
        '
        'txt_emp
        '
        Me.txt_emp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txt_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_emp.Location = New System.Drawing.Point(171, 144)
        Me.txt_emp.Name = "txt_emp"
        Me.txt_emp.Size = New System.Drawing.Size(118, 20)
        Me.txt_emp.TabIndex = 78
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 15)
        Me.Label21.TabIndex = 79
        Me.Label21.Text = "No DPP"
        '
        'txtnoDPP
        '
        Me.txtnoDPP.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtnoDPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnoDPP.Location = New System.Drawing.Point(171, 93)
        Me.txtnoDPP.Name = "txtnoDPP"
        Me.txtnoDPP.Size = New System.Drawing.Size(118, 20)
        Me.txtnoDPP.TabIndex = 80
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Enabled = False
        Me.txtPeriod.Location = New System.Drawing.Point(171, 67)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(83, 20)
        Me.txtPeriod.TabIndex = 81
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 67)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 15)
        Me.Label22.TabIndex = 82
        Me.Label22.Text = "Period"
        '
        'txtOutstandingInv
        '
        Me.txtOutstandingInv.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtOutstandingInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutstandingInv.Enabled = False
        Me.txtOutstandingInv.Location = New System.Drawing.Point(134, 82)
        Me.txtOutstandingInv.Name = "txtOutstandingInv"
        Me.txtOutstandingInv.Size = New System.Drawing.Size(125, 20)
        Me.txtOutstandingInv.TabIndex = 73
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(14, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 15)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "Outstanding Invoice"
        '
        'chkInvoice
        '
        Me.chkInvoice.AutoSize = True
        Me.chkInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInvoice.Location = New System.Drawing.Point(313, 169)
        Me.chkInvoice.Name = "chkInvoice"
        Me.chkInvoice.Size = New System.Drawing.Size(143, 19)
        Me.chkInvoice.TabIndex = 74
        Me.chkInvoice.Text = "Invoice Dikembalikan"
        Me.chkInvoice.UseVisualStyleBackColor = True
        '
        'FrmPelunasanPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1452, 570)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.txtnoDPP)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txt_emp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_insert)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gvPembayaran)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.txt_Ket)
        Me.Controls.Add(Me.dt_Pelunasan)
        Me.Controls.Add(Me.txt_NmKolektor)
        Me.Controls.Add(Me.txt_DocNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmPelunasanPiutang"
        Me.Text = "Form Pelunasan Piutang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gvPembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents list_pembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dt_JatuhTempo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_account As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_keterangan As System.Windows.Forms.TextBox
    Friend WithEvents chk_UangMuka As System.Windows.Forms.CheckBox
    Friend WithEvents txt_nmCus As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_NilaiPO As System.Windows.Forms.TextBox
    Friend WithEvents txt_nogiro As System.Windows.Forms.TextBox
    Friend WithEvents txt_noPR As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlahbayar As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents txt_Outstanding As System.Windows.Forms.TextBox
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_invoice As System.Windows.Forms.TextBox
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvPembayaran As System.Windows.Forms.DataGridView
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_Ket As System.Windows.Forms.TextBox
    Friend WithEvents dt_Pelunasan As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_NmKolektor As System.Windows.Forms.TextBox
    Friend WithEvents txt_DocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_potongan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_cusID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_emp As System.Windows.Forms.TextBox
    Friend WithEvents txt_fakturtipe As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_accountpot As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtnoDPP As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNamaBank As System.Windows.Forms.TextBox
    Friend WithEvents dtTransfer As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtOutstandingInv As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkInvoice As System.Windows.Forms.CheckBox
End Class
