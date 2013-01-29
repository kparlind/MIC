<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoU))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_preview = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_PnwaranHrg_marketing = New System.Windows.Forms.TextBox
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_Project = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dt_MoU = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_alamat2 = New System.Windows.Forms.TextBox
        Me.txt_company2 = New System.Windows.Forms.TextBox
        Me.txt_jabatan2 = New System.Windows.Forms.TextBox
        Me.txt_nama2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_alamat1 = New System.Windows.Forms.TextBox
        Me.txt_company1 = New System.Windows.Forms.TextBox
        Me.txt_jabatan1 = New System.Windows.Forms.TextBox
        Me.txt_Nama1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txt_Cicilan = New System.Windows.Forms.TextBox
        Me.txt_Retention = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txt_DPAmount = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txt71_hari = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txt61_untuk = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.dt61_to = New System.Windows.Forms.DateTimePicker
        Me.Label26 = New System.Windows.Forms.Label
        Me.dt61_from = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt61_wktperngerjaan = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.lbl_terbilang = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt51_sebesar = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt41_DP = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt14_garansi = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt13_meliputi = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt13_kerjaan = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt11_Pekerjaan = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Ts_PO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_preview})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(874, 25)
        Me.Ts_PO.TabIndex = 3
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
        Me.ts_Edit.Visible = False
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
        'ts_preview
        '
        Me.ts_preview.Image = CType(resources.GetObject("ts_preview.Image"), System.Drawing.Image)
        Me.ts_preview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_preview.Name = "ts_preview"
        Me.ts_preview.Size = New System.Drawing.Size(74, 22)
        Me.ts_preview.Text = "PREVIEW"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_PnwaranHrg_marketing)
        Me.GroupBox1.Controls.Add(Me.txt_TransNo)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txt_Project)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dt_MoU)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 103)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Header"
        '
        'txt_PnwaranHrg_marketing
        '
        Me.txt_PnwaranHrg_marketing.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_PnwaranHrg_marketing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PnwaranHrg_marketing.Location = New System.Drawing.Point(123, 44)
        Me.txt_PnwaranHrg_marketing.Name = "txt_PnwaranHrg_marketing"
        Me.txt_PnwaranHrg_marketing.ReadOnly = True
        Me.txt_PnwaranHrg_marketing.Size = New System.Drawing.Size(109, 21)
        Me.txt_PnwaranHrg_marketing.TabIndex = 12
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Location = New System.Drawing.Point(123, 20)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.ReadOnly = True
        Me.txt_TransNo.Size = New System.Drawing.Size(109, 21)
        Me.txt_TransNo.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 15)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "MoU ID"
        '
        'txt_Project
        '
        Me.txt_Project.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_Project.Location = New System.Drawing.Point(123, 69)
        Me.txt_Project.Name = "txt_Project"
        Me.txt_Project.ReadOnly = True
        Me.txt_Project.Size = New System.Drawing.Size(632, 21)
        Me.txt_Project.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Project"
        '
        'dt_MoU
        '
        Me.dt_MoU.CustomFormat = "dd-MM-yyyy"
        Me.dt_MoU.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_MoU.Location = New System.Drawing.Point(243, 20)
        Me.dt_MoU.Name = "dt_MoU"
        Me.dt_MoU.Size = New System.Drawing.Size(96, 21)
        Me.dt_MoU.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Penawaran Hrg"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(874, 175)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kedua Belah Pihak"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.SandyBrown
        Me.GroupBox4.Controls.Add(Me.txt_alamat2)
        Me.GroupBox4.Controls.Add(Me.txt_company2)
        Me.GroupBox4.Controls.Add(Me.txt_jabatan2)
        Me.GroupBox4.Controls.Add(Me.txt_nama2)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(433, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(438, 158)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pihak 2"
        '
        'txt_alamat2
        '
        Me.txt_alamat2.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_alamat2.Location = New System.Drawing.Point(110, 95)
        Me.txt_alamat2.Multiline = True
        Me.txt_alamat2.Name = "txt_alamat2"
        Me.txt_alamat2.Size = New System.Drawing.Size(297, 51)
        Me.txt_alamat2.TabIndex = 15
        '
        'txt_company2
        '
        Me.txt_company2.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_company2.Location = New System.Drawing.Point(110, 72)
        Me.txt_company2.Name = "txt_company2"
        Me.txt_company2.Size = New System.Drawing.Size(227, 21)
        Me.txt_company2.TabIndex = 14
        '
        'txt_jabatan2
        '
        Me.txt_jabatan2.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_jabatan2.Location = New System.Drawing.Point(110, 49)
        Me.txt_jabatan2.Name = "txt_jabatan2"
        Me.txt_jabatan2.Size = New System.Drawing.Size(227, 21)
        Me.txt_jabatan2.TabIndex = 13
        '
        'txt_nama2
        '
        Me.txt_nama2.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_nama2.Location = New System.Drawing.Point(110, 26)
        Me.txt_nama2.Name = "txt_nama2"
        Me.txt_nama2.Size = New System.Drawing.Size(227, 21)
        Me.txt_nama2.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Alamat"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Perusahaan"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Jabatan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Nama"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.txt_alamat1)
        Me.GroupBox3.Controls.Add(Me.txt_company1)
        Me.GroupBox3.Controls.Add(Me.txt_jabatan1)
        Me.GroupBox3.Controls.Add(Me.txt_Nama1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Location = New System.Drawing.Point(3, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(430, 155)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pihak 1"
        '
        'txt_alamat1
        '
        Me.txt_alamat1.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_alamat1.Location = New System.Drawing.Point(109, 93)
        Me.txt_alamat1.Multiline = True
        Me.txt_alamat1.Name = "txt_alamat1"
        Me.txt_alamat1.Size = New System.Drawing.Size(297, 51)
        Me.txt_alamat1.TabIndex = 7
        '
        'txt_company1
        '
        Me.txt_company1.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_company1.Location = New System.Drawing.Point(109, 70)
        Me.txt_company1.Name = "txt_company1"
        Me.txt_company1.Size = New System.Drawing.Size(227, 21)
        Me.txt_company1.TabIndex = 6
        '
        'txt_jabatan1
        '
        Me.txt_jabatan1.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_jabatan1.Location = New System.Drawing.Point(109, 47)
        Me.txt_jabatan1.Name = "txt_jabatan1"
        Me.txt_jabatan1.Size = New System.Drawing.Size(227, 21)
        Me.txt_jabatan1.TabIndex = 5
        '
        'txt_Nama1
        '
        Me.txt_Nama1.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt_Nama1.Location = New System.Drawing.Point(109, 24)
        Me.txt_Nama1.Name = "txt_Nama1"
        Me.txt_Nama1.Size = New System.Drawing.Size(227, 21)
        Me.txt_Nama1.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Alamat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Perusahaan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Jabatan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nama"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox6.Controls.Add(Me.txt_Cicilan)
        Me.GroupBox6.Controls.Add(Me.txt_Retention)
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.Label32)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(0, 303)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(874, 63)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        '
        'txt_Cicilan
        '
        Me.txt_Cicilan.Location = New System.Drawing.Point(579, 26)
        Me.txt_Cicilan.Name = "txt_Cicilan"
        Me.txt_Cicilan.Size = New System.Drawing.Size(261, 21)
        Me.txt_Cicilan.TabIndex = 4
        '
        'txt_Retention
        '
        Me.txt_Retention.Location = New System.Drawing.Point(109, 27)
        Me.txt_Retention.Name = "txt_Retention"
        Me.txt_Retention.Size = New System.Drawing.Size(256, 21)
        Me.txt_Retention.TabIndex = 3
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(511, 27)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(68, 15)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Cicilan(Rp)"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(7, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(84, 15)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Retention(Rp)"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.txt_DPAmount)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.txt71_hari)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.txt61_untuk)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.dt61_to)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.dt61_from)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.txt61_wktperngerjaan)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.lbl_terbilang)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.txt51_sebesar)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.txt41_DP)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txt14_garansi)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.txt13_meliputi)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txt13_kerjaan)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.txt11_Pekerjaan)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 366)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(874, 317)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        '
        'txt_DPAmount
        '
        Me.txt_DPAmount.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_DPAmount.Enabled = False
        Me.txt_DPAmount.Location = New System.Drawing.Point(251, 278)
        Me.txt_DPAmount.Name = "txt_DPAmount"
        Me.txt_DPAmount.Size = New System.Drawing.Size(182, 21)
        Me.txt_DPAmount.TabIndex = 69
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(145, 214)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 15)
        Me.Label31.TabIndex = 68
        Me.Label31.Text = "Bulan"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(538, 258)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 15)
        Me.Label30.TabIndex = 67
        Me.Label30.Text = "hari."
        '
        'txt71_hari
        '
        Me.txt71_hari.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt71_hari.Location = New System.Drawing.Point(492, 255)
        Me.txt71_hari.Name = "txt71_hari"
        Me.txt71_hari.Size = New System.Drawing.Size(40, 21)
        Me.txt71_hari.TabIndex = 66
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(466, 237)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(358, 15)
        Me.Label29.TabIndex = 65
        Me.Label29.Text = "7.1 Segala Perubahan dikomunikasi kedua belah pihak minimal"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(446, 205)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(70, 24)
        Me.Label28.TabIndex = 64
        Me.Label28.Text = "Pasal 7"
        '
        'txt61_untuk
        '
        Me.txt61_untuk.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt61_untuk.Location = New System.Drawing.Point(492, 176)
        Me.txt61_untuk.Name = "txt61_untuk"
        Me.txt61_untuk.Size = New System.Drawing.Size(365, 21)
        Me.txt61_untuk.TabIndex = 63
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(759, 151)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(37, 15)
        Me.Label27.TabIndex = 62
        Me.Label27.Text = "untuk"
        '
        'dt61_to
        '
        Me.dt61_to.CustomFormat = "dd-MM-yyyy"
        Me.dt61_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt61_to.Location = New System.Drawing.Point(652, 149)
        Me.dt61_to.Name = "dt61_to"
        Me.dt61_to.Size = New System.Drawing.Size(101, 21)
        Me.dt61_to.TabIndex = 61
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(598, 151)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 15)
        Me.Label26.TabIndex = 60
        Me.Label26.Text = "sampai"
        '
        'dt61_from
        '
        Me.dt61_from.CustomFormat = "dd-MM-yyyy"
        Me.dt61_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt61_from.Location = New System.Drawing.Point(492, 149)
        Me.dt61_from.Name = "dt61_from"
        Me.dt61_from.Size = New System.Drawing.Size(101, 21)
        Me.dt61_from.TabIndex = 59
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(642, 125)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(150, 15)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "hari, terhitung dari tanggal"
        '
        'txt61_wktperngerjaan
        '
        Me.txt61_wktperngerjaan.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt61_wktperngerjaan.Location = New System.Drawing.Point(596, 122)
        Me.txt61_wktperngerjaan.Name = "txt61_wktperngerjaan"
        Me.txt61_wktperngerjaan.Size = New System.Drawing.Size(40, 21)
        Me.txt61_wktperngerjaan.TabIndex = 57
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(446, 92)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 24)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "Pasal 6"
        '
        'lbl_terbilang
        '
        Me.lbl_terbilang.AutoSize = True
        Me.lbl_terbilang.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_terbilang.Location = New System.Drawing.Point(552, 72)
        Me.lbl_terbilang.Name = "lbl_terbilang"
        Me.lbl_terbilang.Size = New System.Drawing.Size(69, 15)
        Me.lbl_terbilang.TabIndex = 55
        Me.lbl_terbilang.Text = "<terbilang>"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(466, 125)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(127, 15)
        Me.Label22.TabIndex = 54
        Me.Label22.Text = "6.1 Waktu pengerjaan"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(489, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 15)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Terbilang"
        '
        'txt51_sebesar
        '
        Me.txt51_sebesar.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txt51_sebesar.Enabled = False
        Me.txt51_sebesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt51_sebesar.Location = New System.Drawing.Point(616, 47)
        Me.txt51_sebesar.Name = "txt51_sebesar"
        Me.txt51_sebesar.Size = New System.Drawing.Size(241, 24)
        Me.txt51_sebesar.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(466, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(144, 15)
        Me.Label20.TabIndex = 51
        Me.Label20.Text = "5.1 Nilai Kontrak sebesar"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(232, 281)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 15)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "%"
        '
        'txt41_DP
        '
        Me.txt41_DP.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt41_DP.Location = New System.Drawing.Point(186, 277)
        Me.txt41_DP.Name = "txt41_DP"
        Me.txt41_DP.Size = New System.Drawing.Size(47, 21)
        Me.txt41_DP.TabIndex = 49
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 279)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(164, 15)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "4.1 Pembayaran DP sebesar"
        '
        'txt14_garansi
        '
        Me.txt14_garansi.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt14_garansi.Location = New System.Drawing.Point(98, 211)
        Me.txt14_garansi.Name = "txt14_garansi"
        Me.txt14_garansi.Size = New System.Drawing.Size(40, 21)
        Me.txt14_garansi.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(22, 214)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 15)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "1.4 Garansi"
        '
        'txt13_meliputi
        '
        Me.txt13_meliputi.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt13_meliputi.Location = New System.Drawing.Point(44, 122)
        Me.txt13_meliputi.Multiline = True
        Me.txt13_meliputi.Name = "txt13_meliputi"
        Me.txt13_meliputi.Size = New System.Drawing.Size(388, 85)
        Me.txt13_meliputi.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(41, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(172, 15)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "untuk pihak pertama meliputi :"
        '
        'txt13_kerjaan
        '
        Me.txt13_kerjaan.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt13_kerjaan.Location = New System.Drawing.Point(191, 80)
        Me.txt13_kerjaan.Name = "txt13_kerjaan"
        Me.txt13_kerjaan.Size = New System.Drawing.Size(241, 21)
        Me.txt13_kerjaan.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 15)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "1.3 Pihak kedua mengerjakan"
        '
        'txt11_Pekerjaan
        '
        Me.txt11_Pekerjaan.BackColor = System.Drawing.Color.LemonChiffon
        Me.txt11_Pekerjaan.Location = New System.Drawing.Point(109, 50)
        Me.txt11_Pekerjaan.Name = "txt11_Pekerjaan"
        Me.txt11_Pekerjaan.Size = New System.Drawing.Size(323, 21)
        Me.txt11_Pekerjaan.TabIndex = 41
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 15)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "1.1 Pekerjaan"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 240)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 24)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Pasal 4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(446, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 24)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Pasal 5"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 24)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Pasal 1"
        '
        'FrmMoU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 733)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMoU"
        Me.Text = "Form MoU"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Project As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dt_MoU As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_alamat2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_company2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jabatan2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_nama2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_alamat1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_company1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_jabatan1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Nama1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ts_preview As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_PnwaranHrg_marketing As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txt71_hari As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txt61_untuk As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dt61_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dt61_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt61_wktperngerjaan As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbl_terbilang As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt51_sebesar As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt41_DP As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt14_garansi As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt13_meliputi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt13_kerjaan As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt11_Pekerjaan As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Cicilan As System.Windows.Forms.TextBox
    Friend WithEvents txt_Retention As System.Windows.Forms.TextBox
    Friend WithEvents txt_DPAmount As System.Windows.Forms.TextBox
End Class
