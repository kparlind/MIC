<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MasterCust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MasterCust))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbxPaymentDay = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.lblCustGrpName = New System.Windows.Forms.Label
        Me.txtCustGrp = New System.Windows.Forms.TextBox
        Me.cbxCustGrpPrc = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.rbGCYes = New System.Windows.Forms.RadioButton
        Me.rbGCNo = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label31 = New System.Windows.Forms.Label
        Me.rbYes = New System.Windows.Forms.RadioButton
        Me.rbNo = New System.Windows.Forms.RadioButton
        Me.txtNPWP = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtEEmail = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtETelp = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtENama = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtPEmail = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtPTelp = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtPNama = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtPenanggungJawab = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtTOP = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtAlamatPenagihan = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxCaraBayar = New System.Windows.Forms.ComboBox
        Me.cbxPayment = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtReferensi = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtKontrakNo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSpecialRequest = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtDeskripsi = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtNamaOperator = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtStatusCustomer = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtJabatan = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtContactPerson = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtZona = New System.Windows.Forms.TextBox
        Me.lblFax = New System.Windows.Forms.Label
        Me.txtNama = New System.Windows.Forms.TextBox
        Me.txtNoTelp = New System.Windows.Forms.TextBox
        Me.txtNoCust = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label36 = New System.Windows.Forms.Label
        Me.rbBillYes = New System.Windows.Forms.RadioButton
        Me.rbBillNo = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_cari = New System.Windows.Forms.Button
        Me.txt_SearchData = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_searchBaseon = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridCust = New System.Windows.Forms.DataGridView
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.ToolStripSeparator1, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1262, 25)
        Me.ToolStrip.TabIndex = 11
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnNew.Size = New System.Drawing.Size(56, 22)
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEdit.Size = New System.Drawing.Size(52, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(65, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSave.Size = New System.Drawing.Size(56, 22)
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCancel.Size = New System.Drawing.Size(68, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxPaymentDay)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.lblCustGrpName)
        Me.GroupBox2.Controls.Add(Me.txtCustGrp)
        Me.GroupBox2.Controls.Add(Me.cbxCustGrpPrc)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.rbGCYes)
        Me.GroupBox2.Controls.Add(Me.rbGCNo)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.txtNPWP)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.txtEEmail)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtETelp)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.txtENama)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txtPEmail)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtPTelp)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtPNama)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtPenanggungJawab)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtTOP)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtAlamatPenagihan)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbxCaraBayar)
        Me.GroupBox2.Controls.Add(Me.cbxPayment)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtReferensi)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtKontrakNo)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtSpecialRequest)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtDeskripsi)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtNamaOperator)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtStatusCustomer)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtJabatan)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.txtContactPerson)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtZona)
        Me.GroupBox2.Controls.Add(Me.lblFax)
        Me.GroupBox2.Controls.Add(Me.txtNama)
        Me.GroupBox2.Controls.Add(Me.txtNoTelp)
        Me.GroupBox2.Controls.Add(Me.txtNoCust)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1262, 254)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'cbxPaymentDay
        '
        Me.cbxPaymentDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPaymentDay.FormattingEnabled = True
        Me.cbxPaymentDay.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.cbxPaymentDay.Location = New System.Drawing.Point(742, 86)
        Me.cbxPaymentDay.Name = "cbxPaymentDay"
        Me.cbxPaymentDay.Size = New System.Drawing.Size(121, 21)
        Me.cbxPaymentDay.TabIndex = 86
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(788, 163)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(26, 13)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "Hari"
        '
        'lblCustGrpName
        '
        Me.lblCustGrpName.AutoSize = True
        Me.lblCustGrpName.Location = New System.Drawing.Point(529, 176)
        Me.lblCustGrpName.Name = "lblCustGrpName"
        Me.lblCustGrpName.Size = New System.Drawing.Size(0, 13)
        Me.lblCustGrpName.TabIndex = 84
        '
        'txtCustGrp
        '
        Me.txtCustGrp.Enabled = False
        Me.txtCustGrp.Location = New System.Drawing.Point(480, 173)
        Me.txtCustGrp.Name = "txtCustGrp"
        Me.txtCustGrp.Size = New System.Drawing.Size(43, 20)
        Me.txtCustGrp.TabIndex = 83
        '
        'cbxCustGrpPrc
        '
        Me.cbxCustGrpPrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCustGrpPrc.FormattingEnabled = True
        Me.cbxCustGrpPrc.Items.AddRange(New Object() {"Instalasi", "Kontraktor", "Teknisi", "End User"})
        Me.cbxCustGrpPrc.Location = New System.Drawing.Point(480, 195)
        Me.cbxCustGrpPrc.Name = "cbxCustGrpPrc"
        Me.cbxCustGrpPrc.Size = New System.Drawing.Size(121, 21)
        Me.cbxCustGrpPrc.TabIndex = 82
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(355, 202)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(110, 13)
        Me.Label33.TabIndex = 80
        Me.Label33.Text = "Customer Group Price"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(355, 180)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(83, 13)
        Me.Label34.TabIndex = 78
        Me.Label34.Text = "Customer Group"
        '
        'rbGCYes
        '
        Me.rbGCYes.AutoSize = True
        Me.rbGCYes.Checked = True
        Me.rbGCYes.Location = New System.Drawing.Point(134, 224)
        Me.rbGCYes.Name = "rbGCYes"
        Me.rbGCYes.Size = New System.Drawing.Size(43, 17)
        Me.rbGCYes.TabIndex = 75
        Me.rbGCYes.TabStop = True
        Me.rbGCYes.Text = "Yes"
        Me.rbGCYes.UseVisualStyleBackColor = True
        '
        'rbGCNo
        '
        Me.rbGCNo.AutoSize = True
        Me.rbGCNo.Location = New System.Drawing.Point(183, 224)
        Me.rbGCNo.Name = "rbGCNo"
        Me.rbGCNo.Size = New System.Drawing.Size(39, 17)
        Me.rbGCNo.TabIndex = 76
        Me.rbGCNo.Text = "No"
        Me.rbGCNo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.rbYes)
        Me.Panel1.Controls.Add(Me.rbNo)
        Me.Panel1.Location = New System.Drawing.Point(969, 201)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 28)
        Me.Panel1.TabIndex = 77
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 72
        Me.Label31.Text = "Active"
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Checked = True
        Me.rbYes.Location = New System.Drawing.Point(110, 1)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(43, 17)
        Me.rbYes.TabIndex = 73
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(159, 1)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(39, 17)
        Me.rbNo.TabIndex = 74
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'txtNPWP
        '
        Me.txtNPWP.Location = New System.Drawing.Point(480, 150)
        Me.txtNPWP.Name = "txtNPWP"
        Me.txtNPWP.Size = New System.Drawing.Size(100, 20)
        Me.txtNPWP.TabIndex = 76
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(355, 155)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(40, 13)
        Me.Label32.TabIndex = 75
        Me.Label32.Text = "NPWP"
        '
        'txtEEmail
        '
        Me.txtEEmail.Location = New System.Drawing.Point(1078, 175)
        Me.txtEEmail.Name = "txtEEmail"
        Me.txtEEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEEmail.TabIndex = 72
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(971, 179)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(32, 13)
        Me.Label27.TabIndex = 71
        Me.Label27.Text = "Email"
        '
        'txtETelp
        '
        Me.txtETelp.Location = New System.Drawing.Point(1078, 152)
        Me.txtETelp.Name = "txtETelp"
        Me.txtETelp.Size = New System.Drawing.Size(100, 20)
        Me.txtETelp.TabIndex = 70
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(971, 156)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(28, 13)
        Me.Label28.TabIndex = 69
        Me.Label28.Text = "Telp"
        '
        'txtENama
        '
        Me.txtENama.Location = New System.Drawing.Point(1078, 130)
        Me.txtENama.Name = "txtENama"
        Me.txtENama.Size = New System.Drawing.Size(132, 20)
        Me.txtENama.TabIndex = 68
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(971, 136)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(35, 13)
        Me.Label29.TabIndex = 67
        Me.Label29.Text = "Nama"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(971, 111)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(175, 13)
        Me.Label30.TabIndex = 66
        Me.Label30.Text = "Contact Person Bagian Engineering"
        '
        'txtPEmail
        '
        Me.txtPEmail.Location = New System.Drawing.Point(1078, 77)
        Me.txtPEmail.Name = "txtPEmail"
        Me.txtPEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtPEmail.TabIndex = 65
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(971, 81)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 13)
        Me.Label24.TabIndex = 64
        Me.Label24.Text = "Email"
        '
        'txtPTelp
        '
        Me.txtPTelp.Location = New System.Drawing.Point(1078, 54)
        Me.txtPTelp.Name = "txtPTelp"
        Me.txtPTelp.Size = New System.Drawing.Size(100, 20)
        Me.txtPTelp.TabIndex = 63
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(971, 58)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(28, 13)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Telp"
        '
        'txtPNama
        '
        Me.txtPNama.Location = New System.Drawing.Point(1078, 32)
        Me.txtPNama.Name = "txtPNama"
        Me.txtPNama.Size = New System.Drawing.Size(132, 20)
        Me.txtPNama.TabIndex = 61
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(971, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 60
        Me.Label26.Text = "Nama"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(971, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(168, 13)
        Me.Label23.TabIndex = 59
        Me.Label23.Text = "Contact Person Bagian Pembelian"
        '
        'txtPenanggungJawab
        '
        Me.txtPenanggungJawab.Location = New System.Drawing.Point(742, 182)
        Me.txtPenanggungJawab.Name = "txtPenanggungJawab"
        Me.txtPenanggungJawab.Size = New System.Drawing.Size(100, 20)
        Me.txtPenanggungJawab.TabIndex = 58
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(635, 187)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 13)
        Me.Label22.TabIndex = 57
        Me.Label22.Text = "Penanggung Jawab"
        '
        'txtTOP
        '
        Me.txtTOP.Location = New System.Drawing.Point(742, 160)
        Me.txtTOP.Name = "txtTOP"
        Me.txtTOP.Size = New System.Drawing.Size(43, 20)
        Me.txtTOP.TabIndex = 56
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(635, 165)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 55
        Me.Label21.Text = "TOP"
        '
        'txtAlamatPenagihan
        '
        Me.txtAlamatPenagihan.Location = New System.Drawing.Point(742, 109)
        Me.txtAlamatPenagihan.Multiline = True
        Me.txtAlamatPenagihan.Name = "txtAlamatPenagihan"
        Me.txtAlamatPenagihan.Size = New System.Drawing.Size(195, 48)
        Me.txtAlamatPenagihan.TabIndex = 54
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(635, 116)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Alamat Penagihan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(635, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Payment Day"
        '
        'cbxCaraBayar
        '
        Me.cbxCaraBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCaraBayar.FormattingEnabled = True
        Me.cbxCaraBayar.Items.AddRange(New Object() {"Cash", "BG", "Transfer"})
        Me.cbxCaraBayar.Location = New System.Drawing.Point(742, 62)
        Me.cbxCaraBayar.Name = "cbxCaraBayar"
        Me.cbxCaraBayar.Size = New System.Drawing.Size(121, 21)
        Me.cbxCaraBayar.TabIndex = 51
        '
        'cbxPayment
        '
        Me.cbxPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPayment.FormattingEnabled = True
        Me.cbxPayment.Items.AddRange(New Object() {"Cash", "Credit"})
        Me.cbxPayment.Location = New System.Drawing.Point(742, 38)
        Me.cbxPayment.Name = "cbxPayment"
        Me.cbxPayment.Size = New System.Drawing.Size(121, 21)
        Me.cbxPayment.TabIndex = 50
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(635, 67)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 49
        Me.Label20.Text = "Cara Bayar"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(635, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Payment"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(480, 126)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEmail.TabIndex = 46
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(355, 133)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Email"
        '
        'txtReferensi
        '
        Me.txtReferensi.Location = New System.Drawing.Point(480, 104)
        Me.txtReferensi.Name = "txtReferensi"
        Me.txtReferensi.Size = New System.Drawing.Size(100, 20)
        Me.txtReferensi.TabIndex = 44
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(355, 110)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Referensi"
        '
        'txtKontrakNo
        '
        Me.txtKontrakNo.Location = New System.Drawing.Point(480, 82)
        Me.txtKontrakNo.Name = "txtKontrakNo"
        Me.txtKontrakNo.Size = New System.Drawing.Size(132, 20)
        Me.txtKontrakNo.TabIndex = 42
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(355, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Kontrak No"
        '
        'txtSpecialRequest
        '
        Me.txtSpecialRequest.Location = New System.Drawing.Point(480, 60)
        Me.txtSpecialRequest.Name = "txtSpecialRequest"
        Me.txtSpecialRequest.Size = New System.Drawing.Size(132, 20)
        Me.txtSpecialRequest.TabIndex = 40
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(355, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Special Request"
        '
        'txtDeskripsi
        '
        Me.txtDeskripsi.Location = New System.Drawing.Point(134, 108)
        Me.txtDeskripsi.Name = "txtDeskripsi"
        Me.txtDeskripsi.Size = New System.Drawing.Size(132, 20)
        Me.txtDeskripsi.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Deskripsi"
        '
        'txtNamaOperator
        '
        Me.txtNamaOperator.Location = New System.Drawing.Point(480, 38)
        Me.txtNamaOperator.Name = "txtNamaOperator"
        Me.txtNamaOperator.Size = New System.Drawing.Size(132, 20)
        Me.txtNamaOperator.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(355, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Nama Operator"
        '
        'txtStatusCustomer
        '
        Me.txtStatusCustomer.Location = New System.Drawing.Point(480, 15)
        Me.txtStatusCustomer.Name = "txtStatusCustomer"
        Me.txtStatusCustomer.Size = New System.Drawing.Size(132, 20)
        Me.txtStatusCustomer.TabIndex = 33
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Status Customer"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Group Corporate"
        '
        'txtJabatan
        '
        Me.txtJabatan.Location = New System.Drawing.Point(134, 176)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(132, 20)
        Me.txtJabatan.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Jabatan"
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(134, 58)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(203, 48)
        Me.txtAlamat.TabIndex = 24
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Location = New System.Drawing.Point(134, 153)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(100, 20)
        Me.txtContactPerson.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Contact Person"
        '
        'txtZona
        '
        Me.txtZona.Location = New System.Drawing.Point(134, 198)
        Me.txtZona.Name = "txtZona"
        Me.txtZona.Size = New System.Drawing.Size(100, 20)
        Me.txtZona.TabIndex = 21
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.Location = New System.Drawing.Point(9, 202)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(32, 13)
        Me.lblFax.TabIndex = 20
        Me.lblFax.Text = "Zona"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(134, 35)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(203, 20)
        Me.txtNama.TabIndex = 11
        '
        'txtNoTelp
        '
        Me.txtNoTelp.Location = New System.Drawing.Point(134, 130)
        Me.txtNoTelp.Name = "txtNoTelp"
        Me.txtNoTelp.Size = New System.Drawing.Size(100, 20)
        Me.txtNoTelp.TabIndex = 10
        '
        'txtNoCust
        '
        Me.txtNoCust.BackColor = System.Drawing.SystemColors.Control
        Me.txtNoCust.Enabled = False
        Me.txtNoCust.Location = New System.Drawing.Point(134, 13)
        Me.txtNoCust.Name = "txtNoCust"
        Me.txtNoCust.ReadOnly = True
        Me.txtNoCust.Size = New System.Drawing.Size(100, 20)
        Me.txtNoCust.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Nama"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Alamat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "No Telp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "No Customer"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label36)
        Me.Panel2.Controls.Add(Me.rbBillYes)
        Me.Panel2.Controls.Add(Me.rbBillNo)
        Me.Panel2.Location = New System.Drawing.Point(632, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 21)
        Me.Panel2.TabIndex = 78
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(3, 3)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(34, 13)
        Me.Label36.TabIndex = 72
        Me.Label36.Text = "Billing"
        '
        'rbBillYes
        '
        Me.rbBillYes.AutoSize = True
        Me.rbBillYes.Checked = True
        Me.rbBillYes.Location = New System.Drawing.Point(110, 1)
        Me.rbBillYes.Name = "rbBillYes"
        Me.rbBillYes.Size = New System.Drawing.Size(43, 17)
        Me.rbBillYes.TabIndex = 73
        Me.rbBillYes.TabStop = True
        Me.rbBillYes.Text = "Yes"
        Me.rbBillYes.UseVisualStyleBackColor = True
        '
        'rbBillNo
        '
        Me.rbBillNo.AutoSize = True
        Me.rbBillNo.Location = New System.Drawing.Point(159, 1)
        Me.rbBillNo.Name = "rbBillNo"
        Me.rbBillNo.Size = New System.Drawing.Size(39, 17)
        Me.rbBillNo.TabIndex = 74
        Me.rbBillNo.Text = "No"
        Me.rbBillNo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.txt_SearchData)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb_searchBaseon)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 279)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 58)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Data"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(675, 19)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(75, 23)
        Me.btn_cari.TabIndex = 4
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'txt_SearchData
        '
        Me.txt_SearchData.Location = New System.Drawing.Point(329, 22)
        Me.txt_SearchData.Name = "txt_SearchData"
        Me.txt_SearchData.Size = New System.Drawing.Size(330, 20)
        Me.txt_SearchData.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Keyword"
        '
        'cb_searchBaseon
        '
        Me.cb_searchBaseon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_searchBaseon.FormattingEnabled = True
        Me.cb_searchBaseon.Location = New System.Drawing.Point(99, 22)
        Me.cb_searchBaseon.Name = "cb_searchBaseon"
        Me.cb_searchBaseon.Size = New System.Drawing.Size(158, 21)
        Me.cb_searchBaseon.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filter By"
        '
        'GridCust
        '
        Me.GridCust.AllowUserToAddRows = False
        Me.GridCust.AllowUserToDeleteRows = False
        Me.GridCust.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCust.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridCust.Location = New System.Drawing.Point(0, 337)
        Me.GridCust.Name = "GridCust"
        Me.GridCust.ReadOnly = True
        Me.GridCust.Size = New System.Drawing.Size(1262, 360)
        Me.GridCust.TabIndex = 15
        '
        'Frm_MasterCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 699)
        Me.Controls.Add(Me.GridCust)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "Frm_MasterCust"
        Me.Text = "Master Customer"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridCust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtEEmail As System.Windows.Forms.TextBox
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtETelp As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtENama As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPTelp As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPNama As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPenanggungJawab As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTOP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtAlamatPenagihan As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxCaraBayar As System.Windows.Forms.ComboBox
    Friend WithEvents cbxPayment As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtReferensi As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtKontrakNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialRequest As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDeskripsi As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNamaOperator As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtStatusCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtJabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtZona As System.Windows.Forms.TextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents txtNoTelp As System.Windows.Forms.TextBox
    Friend WithEvents txtNoCust As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents txt_SearchData As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_searchBaseon As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridCust As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNPWP As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbxCustGrpPrc As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents rbGCYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbGCNo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents rbBillYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbBillNo As System.Windows.Forms.RadioButton
    Friend WithEvents txtCustGrp As System.Windows.Forms.TextBox
    Friend WithEvents lblCustGrpName As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cbxPaymentDay As System.Windows.Forms.ComboBox
End Class
