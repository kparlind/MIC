<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Complaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Complaint))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_approve = New System.Windows.Forms.ToolStripButton
        Me.ts_reject = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtRejectReason = New System.Windows.Forms.TextBox
        Me.lblRejectReason = New System.Windows.Forms.Label
        Me.txtBagian = New System.Windows.Forms.TextBox
        Me.txtNamaDiterima = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCustID = New System.Windows.Forms.TextBox
        Me.txtNamaProj = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtp_complaint = New System.Windows.Forms.DateTimePicker
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.lbl_status = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNoUrut = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.P_Item = New System.Windows.Forms.Panel
        Me.txtAkhirNotes = New System.Windows.Forms.TextBox
        Me.txtPIC = New System.Windows.Forms.TextBox
        Me.txtIndexDetail = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbAkhirSdh = New System.Windows.Forms.RadioButton
        Me.rbAkhirBlm = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rbAwalSdh = New System.Windows.Forms.RadioButton
        Me.rbAwalBlm = New System.Windows.Forms.RadioButton
        Me.dtpTarget = New System.Windows.Forms.DateTimePicker
        Me.Label33 = New System.Windows.Forms.Label
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.btn_insert = New System.Windows.Forms.Button
        Me.gvDetail = New System.Windows.Forms.DataGridView
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtAwalNotes = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.dtpHasilVerifikasi = New System.Windows.Forms.DateTimePicker
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtUraianHasilPenanganan = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.dtpHasilPenanganan = New System.Windows.Forms.DateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtTindakLanjut = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.dtpPenanganan = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtAnalisa = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.dtpAnalisa = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtNotesMarketing = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpMarketing = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbxTypeKeluhan = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtUraianKeluhan = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpInfoKeluhan = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Ts_PO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.P_Item.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.BackColor = System.Drawing.Color.DarkGray
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_edit, Me.ts_save, Me.ts_delete, Me.ts_cancel, Me.ts_approve, Me.ts_reject})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1362, 25)
        Me.Ts_PO.TabIndex = 81
        Me.Ts_PO.Text = "PO"
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
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_cancel.Size = New System.Drawing.Size(68, 22)
        Me.ts_cancel.Text = "Cancel"
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
        Me.Panel1.Controls.Add(Me.txtRejectReason)
        Me.Panel1.Controls.Add(Me.lblRejectReason)
        Me.Panel1.Controls.Add(Me.txtBagian)
        Me.Panel1.Controls.Add(Me.txtNamaDiterima)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtAlamat)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtCustID)
        Me.Panel1.Controls.Add(Me.txtNamaProj)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtp_complaint)
        Me.Panel1.Controls.Add(Me.txtCustName)
        Me.Panel1.Controls.Add(Me.lbl_status)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNoUrut)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1362, 81)
        Me.Panel1.TabIndex = 82
        '
        'txtRejectReason
        '
        Me.txtRejectReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectReason.Enabled = False
        Me.txtRejectReason.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectReason.Location = New System.Drawing.Point(1234, 24)
        Me.txtRejectReason.Name = "txtRejectReason"
        Me.txtRejectReason.Size = New System.Drawing.Size(128, 22)
        Me.txtRejectReason.TabIndex = 45
        Me.txtRejectReason.Visible = False
        '
        'lblRejectReason
        '
        Me.lblRejectReason.AutoSize = True
        Me.lblRejectReason.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectReason.Location = New System.Drawing.Point(1148, 27)
        Me.lblRejectReason.Name = "lblRejectReason"
        Me.lblRejectReason.Size = New System.Drawing.Size(85, 14)
        Me.lblRejectReason.TabIndex = 46
        Me.lblRejectReason.Text = "Reason Reject"
        Me.lblRejectReason.Visible = False
        '
        'txtBagian
        '
        Me.txtBagian.BackColor = System.Drawing.Color.LightGray
        Me.txtBagian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBagian.Enabled = False
        Me.txtBagian.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBagian.Location = New System.Drawing.Point(997, 49)
        Me.txtBagian.Name = "txtBagian"
        Me.txtBagian.Size = New System.Drawing.Size(145, 22)
        Me.txtBagian.TabIndex = 44
        '
        'txtNamaDiterima
        '
        Me.txtNamaDiterima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaDiterima.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaDiterima.Location = New System.Drawing.Point(997, 25)
        Me.txtNamaDiterima.Name = "txtNamaDiterima"
        Me.txtNamaDiterima.Size = New System.Drawing.Size(145, 22)
        Me.txtNamaDiterima.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(942, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 14)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Bagian"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(941, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Nama"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(849, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 14)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Diterima oleh :"
        '
        'txtAlamat
        '
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(501, 28)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(342, 22)
        Me.txtAlamat.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(446, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 14)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Alamat"
        '
        'txtCustID
        '
        Me.txtCustID.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustID.Location = New System.Drawing.Point(320, 52)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(77, 22)
        Me.txtCustID.TabIndex = 37
        '
        'txtNamaProj
        '
        Me.txtNamaProj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaProj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaProj.Location = New System.Drawing.Point(118, 52)
        Me.txtNamaProj.Name = "txtNamaProj"
        Me.txtNamaProj.Size = New System.Drawing.Size(108, 22)
        Me.txtNamaProj.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Tanggal"
        '
        'dtp_complaint
        '
        Me.dtp_complaint.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_complaint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_complaint.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_complaint.Location = New System.Drawing.Point(320, 28)
        Me.dtp_complaint.Name = "dtp_complaint"
        Me.dtp_complaint.Size = New System.Drawing.Size(108, 22)
        Me.dtp_complaint.TabIndex = 2
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Enabled = False
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(398, 52)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(264, 22)
        Me.txtCustName.TabIndex = 25
        '
        'lbl_status
        '
        Me.lbl_status.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(12, 2)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(436, 24)
        Me.lbl_status.TabIndex = 23
        Me.lbl_status.Text = "Label9"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(252, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Project"
        '
        'txtNoUrut
        '
        Me.txtNoUrut.BackColor = System.Drawing.Color.LightGray
        Me.txtNoUrut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoUrut.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoUrut.Location = New System.Drawing.Point(118, 28)
        Me.txtNoUrut.Name = "txtNoUrut"
        Me.txtNoUrut.ReadOnly = True
        Me.txtNoUrut.Size = New System.Drawing.Size(108, 22)
        Me.txtNoUrut.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Urut"
        '
        'P_Item
        '
        Me.P_Item.BackColor = System.Drawing.SystemColors.Control
        Me.P_Item.Controls.Add(Me.txtAkhirNotes)
        Me.P_Item.Controls.Add(Me.txtPIC)
        Me.P_Item.Controls.Add(Me.txtIndexDetail)
        Me.P_Item.Controls.Add(Me.Panel2)
        Me.P_Item.Controls.Add(Me.Panel3)
        Me.P_Item.Controls.Add(Me.dtpTarget)
        Me.P_Item.Controls.Add(Me.Label33)
        Me.P_Item.Controls.Add(Me.Btn_cancel)
        Me.P_Item.Controls.Add(Me.btn_delete)
        Me.P_Item.Controls.Add(Me.btn_save)
        Me.P_Item.Controls.Add(Me.btn_edit)
        Me.P_Item.Controls.Add(Me.btn_insert)
        Me.P_Item.Controls.Add(Me.gvDetail)
        Me.P_Item.Controls.Add(Me.Label32)
        Me.P_Item.Controls.Add(Me.Label30)
        Me.P_Item.Controls.Add(Me.Label31)
        Me.P_Item.Controls.Add(Me.txtAwalNotes)
        Me.P_Item.Controls.Add(Me.Label29)
        Me.P_Item.Controls.Add(Me.Label26)
        Me.P_Item.Controls.Add(Me.dtpHasilVerifikasi)
        Me.P_Item.Controls.Add(Me.Label27)
        Me.P_Item.Controls.Add(Me.Label28)
        Me.P_Item.Controls.Add(Me.txtUraianHasilPenanganan)
        Me.P_Item.Controls.Add(Me.Label23)
        Me.P_Item.Controls.Add(Me.dtpHasilPenanganan)
        Me.P_Item.Controls.Add(Me.Label24)
        Me.P_Item.Controls.Add(Me.Label25)
        Me.P_Item.Controls.Add(Me.txtTindakLanjut)
        Me.P_Item.Controls.Add(Me.Label17)
        Me.P_Item.Controls.Add(Me.dtpPenanganan)
        Me.P_Item.Controls.Add(Me.Label21)
        Me.P_Item.Controls.Add(Me.Label22)
        Me.P_Item.Controls.Add(Me.txtAnalisa)
        Me.P_Item.Controls.Add(Me.Label18)
        Me.P_Item.Controls.Add(Me.dtpAnalisa)
        Me.P_Item.Controls.Add(Me.Label19)
        Me.P_Item.Controls.Add(Me.Label20)
        Me.P_Item.Controls.Add(Me.Label13)
        Me.P_Item.Controls.Add(Me.txtNotesMarketing)
        Me.P_Item.Controls.Add(Me.Label14)
        Me.P_Item.Controls.Add(Me.dtpMarketing)
        Me.P_Item.Controls.Add(Me.Label15)
        Me.P_Item.Controls.Add(Me.Label16)
        Me.P_Item.Controls.Add(Me.cbxTypeKeluhan)
        Me.P_Item.Controls.Add(Me.Label10)
        Me.P_Item.Controls.Add(Me.txtUraianKeluhan)
        Me.P_Item.Controls.Add(Me.Label9)
        Me.P_Item.Controls.Add(Me.dtpInfoKeluhan)
        Me.P_Item.Controls.Add(Me.Label11)
        Me.P_Item.Controls.Add(Me.Label12)
        Me.P_Item.Dock = System.Windows.Forms.DockStyle.Top
        Me.P_Item.Location = New System.Drawing.Point(0, 106)
        Me.P_Item.Name = "P_Item"
        Me.P_Item.Size = New System.Drawing.Size(1362, 645)
        Me.P_Item.TabIndex = 83
        '
        'txtAkhirNotes
        '
        Me.txtAkhirNotes.BackColor = System.Drawing.Color.DarkGray
        Me.txtAkhirNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAkhirNotes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAkhirNotes.Location = New System.Drawing.Point(1017, 196)
        Me.txtAkhirNotes.Multiline = True
        Me.txtAkhirNotes.Name = "txtAkhirNotes"
        Me.txtAkhirNotes.Size = New System.Drawing.Size(341, 18)
        Me.txtAkhirNotes.TabIndex = 97
        '
        'txtPIC
        '
        Me.txtPIC.BackColor = System.Drawing.Color.DarkGray
        Me.txtPIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPIC.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIC.Location = New System.Drawing.Point(326, 106)
        Me.txtPIC.Multiline = True
        Me.txtPIC.Name = "txtPIC"
        Me.txtPIC.Size = New System.Drawing.Size(122, 20)
        Me.txtPIC.TabIndex = 96
        '
        'txtIndexDetail
        '
        Me.txtIndexDetail.Location = New System.Drawing.Point(418, 264)
        Me.txtIndexDetail.Name = "txtIndexDetail"
        Me.txtIndexDetail.Size = New System.Drawing.Size(100, 20)
        Me.txtIndexDetail.TabIndex = 95
        Me.txtIndexDetail.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbAkhirSdh)
        Me.Panel2.Controls.Add(Me.rbAkhirBlm)
        Me.Panel2.Location = New System.Drawing.Point(1017, 169)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(122, 28)
        Me.Panel2.TabIndex = 94
        '
        'rbAkhirSdh
        '
        Me.rbAkhirSdh.AutoSize = True
        Me.rbAkhirSdh.Checked = True
        Me.rbAkhirSdh.Location = New System.Drawing.Point(3, 8)
        Me.rbAkhirSdh.Name = "rbAkhirSdh"
        Me.rbAkhirSdh.Size = New System.Drawing.Size(56, 17)
        Me.rbAkhirSdh.TabIndex = 73
        Me.rbAkhirSdh.TabStop = True
        Me.rbAkhirSdh.Text = "Sudah"
        Me.rbAkhirSdh.UseVisualStyleBackColor = True
        '
        'rbAkhirBlm
        '
        Me.rbAkhirBlm.AutoSize = True
        Me.rbAkhirBlm.Location = New System.Drawing.Point(65, 8)
        Me.rbAkhirBlm.Name = "rbAkhirBlm"
        Me.rbAkhirBlm.Size = New System.Drawing.Size(54, 17)
        Me.rbAkhirBlm.TabIndex = 74
        Me.rbAkhirBlm.Text = "Belum"
        Me.rbAkhirBlm.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbAwalSdh)
        Me.Panel3.Controls.Add(Me.rbAwalBlm)
        Me.Panel3.Location = New System.Drawing.Point(1017, 121)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(122, 28)
        Me.Panel3.TabIndex = 93
        '
        'rbAwalSdh
        '
        Me.rbAwalSdh.AutoSize = True
        Me.rbAwalSdh.Checked = True
        Me.rbAwalSdh.Location = New System.Drawing.Point(3, 8)
        Me.rbAwalSdh.Name = "rbAwalSdh"
        Me.rbAwalSdh.Size = New System.Drawing.Size(56, 17)
        Me.rbAwalSdh.TabIndex = 73
        Me.rbAwalSdh.TabStop = True
        Me.rbAwalSdh.Text = "Sudah"
        Me.rbAwalSdh.UseVisualStyleBackColor = True
        '
        'rbAwalBlm
        '
        Me.rbAwalBlm.AutoSize = True
        Me.rbAwalBlm.Location = New System.Drawing.Point(65, 8)
        Me.rbAwalBlm.Name = "rbAwalBlm"
        Me.rbAwalBlm.Size = New System.Drawing.Size(54, 17)
        Me.rbAwalBlm.TabIndex = 74
        Me.rbAwalBlm.Text = "Belum"
        Me.rbAwalBlm.UseVisualStyleBackColor = True
        '
        'dtpTarget
        '
        Me.dtpTarget.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpTarget.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTarget.Location = New System.Drawing.Point(568, 158)
        Me.dtpTarget.Name = "dtpTarget"
        Me.dtpTarget.Size = New System.Drawing.Size(165, 22)
        Me.dtpTarget.TabIndex = 92
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(475, 162)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(44, 14)
        Me.Label33.TabIndex = 91
        Me.Label33.Text = "Target"
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(302, 210)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 90
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(231, 210)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 89
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(159, 210)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 88
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(87, 210)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 87
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(15, 210)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 86
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'gvDetail
        '
        Me.gvDetail.AllowUserToAddRows = False
        Me.gvDetail.AllowUserToDeleteRows = False
        Me.gvDetail.AllowUserToOrderColumns = True
        Me.gvDetail.AllowUserToResizeColumns = False
        Me.gvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvDetail.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvDetail.Location = New System.Drawing.Point(15, 242)
        Me.gvDetail.Name = "gvDetail"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvDetail.Size = New System.Drawing.Size(1343, 372)
        Me.gvDetail.TabIndex = 84
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(12, -6)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(1297, 13)
        Me.Label32.TabIndex = 85
        Me.Label32.Text = resources.GetString("Label32.Text")
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(965, 200)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(49, 14)
        Me.Label30.TabIndex = 83
        Me.Label30.Text = "Catatan"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(923, 177)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(84, 14)
        Me.Label31.TabIndex = 80
        Me.Label31.Text = "Verifikasi Akhir"
        '
        'txtAwalNotes
        '
        Me.txtAwalNotes.BackColor = System.Drawing.Color.DarkGray
        Me.txtAwalNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAwalNotes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAwalNotes.Location = New System.Drawing.Point(1017, 151)
        Me.txtAwalNotes.Multiline = True
        Me.txtAwalNotes.Name = "txtAwalNotes"
        Me.txtAwalNotes.Size = New System.Drawing.Size(341, 18)
        Me.txtAwalNotes.TabIndex = 79
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(965, 153)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 14)
        Me.Label29.TabIndex = 78
        Me.Label29.Text = "Catatan"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(924, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 14)
        Me.Label26.TabIndex = 75
        Me.Label26.Text = "VI. Hasil Verifikasi"
        '
        'dtpHasilVerifikasi
        '
        Me.dtpHasilVerifikasi.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpHasilVerifikasi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasilVerifikasi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasilVerifikasi.Location = New System.Drawing.Point(1017, 98)
        Me.dtpHasilVerifikasi.Name = "dtpHasilVerifikasi"
        Me.dtpHasilVerifikasi.Size = New System.Drawing.Size(165, 22)
        Me.dtpHasilVerifikasi.TabIndex = 73
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(924, 127)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(83, 14)
        Me.Label27.TabIndex = 72
        Me.Label27.Text = "Verifikasi Awal"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(924, 102)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 14)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Tanggal"
        '
        'txtUraianHasilPenanganan
        '
        Me.txtUraianHasilPenanganan.BackColor = System.Drawing.Color.DarkGray
        Me.txtUraianHasilPenanganan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUraianHasilPenanganan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUraianHasilPenanganan.Location = New System.Drawing.Point(1017, 54)
        Me.txtUraianHasilPenanganan.Multiline = True
        Me.txtUraianHasilPenanganan.Name = "txtUraianHasilPenanganan"
        Me.txtUraianHasilPenanganan.Size = New System.Drawing.Size(342, 19)
        Me.txtUraianHasilPenanganan.TabIndex = 69
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(924, 7)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(117, 14)
        Me.Label23.TabIndex = 70
        Me.Label23.Text = "V. Hasil Penanganan"
        '
        'dtpHasilPenanganan
        '
        Me.dtpHasilPenanganan.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpHasilPenanganan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasilPenanganan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasilPenanganan.Location = New System.Drawing.Point(1017, 27)
        Me.dtpHasilPenanganan.Name = "dtpHasilPenanganan"
        Me.dtpHasilPenanganan.Size = New System.Drawing.Size(164, 22)
        Me.dtpHasilPenanganan.TabIndex = 68
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(924, 55)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 14)
        Me.Label24.TabIndex = 67
        Me.Label24.Text = "Uraian"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(924, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(50, 14)
        Me.Label25.TabIndex = 66
        Me.Label25.Text = "Tanggal"
        '
        'txtTindakLanjut
        '
        Me.txtTindakLanjut.BackColor = System.Drawing.Color.DarkGray
        Me.txtTindakLanjut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTindakLanjut.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTindakLanjut.Location = New System.Drawing.Point(568, 135)
        Me.txtTindakLanjut.Multiline = True
        Me.txtTindakLanjut.Name = "txtTindakLanjut"
        Me.txtTindakLanjut.Size = New System.Drawing.Size(342, 19)
        Me.txtTindakLanjut.TabIndex = 64
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(475, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(141, 14)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "IV. Penanganan Keluhan"
        '
        'dtpPenanganan
        '
        Me.dtpPenanganan.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpPenanganan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPenanganan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPenanganan.Location = New System.Drawing.Point(568, 108)
        Me.dtpPenanganan.Name = "dtpPenanganan"
        Me.dtpPenanganan.Size = New System.Drawing.Size(165, 22)
        Me.dtpPenanganan.TabIndex = 63
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(475, 136)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 14)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Tindak Lanjut"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(475, 112)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 14)
        Me.Label22.TabIndex = 61
        Me.Label22.Text = "Tanggal"
        '
        'txtAnalisa
        '
        Me.txtAnalisa.BackColor = System.Drawing.Color.DarkGray
        Me.txtAnalisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnalisa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnalisa.Location = New System.Drawing.Point(568, 54)
        Me.txtAnalisa.Multiline = True
        Me.txtAnalisa.Name = "txtAnalisa"
        Me.txtAnalisa.Size = New System.Drawing.Size(342, 19)
        Me.txtAnalisa.TabIndex = 59
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(475, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(140, 14)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "III. Analisa Permasalahan"
        '
        'dtpAnalisa
        '
        Me.dtpAnalisa.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpAnalisa.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAnalisa.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnalisa.Location = New System.Drawing.Point(568, 27)
        Me.dtpAnalisa.Name = "dtpAnalisa"
        Me.dtpAnalisa.Size = New System.Drawing.Size(163, 22)
        Me.dtpAnalisa.TabIndex = 58
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(475, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 14)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Analisa"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(475, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 14)
        Me.Label20.TabIndex = 56
        Me.Label20.Text = "Tanggal"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(296, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 14)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "PIC"
        '
        'txtNotesMarketing
        '
        Me.txtNotesMarketing.BackColor = System.Drawing.Color.DarkGray
        Me.txtNotesMarketing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotesMarketing.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotesMarketing.Location = New System.Drawing.Point(106, 134)
        Me.txtNotesMarketing.Multiline = True
        Me.txtNotesMarketing.Name = "txtNotesMarketing"
        Me.txtNotesMarketing.Size = New System.Drawing.Size(342, 20)
        Me.txtNotesMarketing.TabIndex = 52
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(221, 14)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "II. Diisi oleh KaBag / Head Of Marketing"
        '
        'dtpMarketing
        '
        Me.dtpMarketing.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpMarketing.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpMarketing.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMarketing.Location = New System.Drawing.Point(106, 108)
        Me.dtpMarketing.Name = "dtpMarketing"
        Me.dtpMarketing.Size = New System.Drawing.Size(164, 22)
        Me.dtpMarketing.TabIndex = 51
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 14)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Catatan"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 14)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Tanggal"
        '
        'cbxTypeKeluhan
        '
        Me.cbxTypeKeluhan.BackColor = System.Drawing.Color.DarkGray
        Me.cbxTypeKeluhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTypeKeluhan.FormattingEnabled = True
        Me.cbxTypeKeluhan.Location = New System.Drawing.Point(327, 27)
        Me.cbxTypeKeluhan.Name = "cbxTypeKeluhan"
        Me.cbxTypeKeluhan.Size = New System.Drawing.Size(121, 21)
        Me.cbxTypeKeluhan.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(286, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 14)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Type"
        '
        'txtUraianKeluhan
        '
        Me.txtUraianKeluhan.BackColor = System.Drawing.Color.DarkGray
        Me.txtUraianKeluhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUraianKeluhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUraianKeluhan.Location = New System.Drawing.Point(105, 55)
        Me.txtUraianKeluhan.Multiline = True
        Me.txtUraianKeluhan.Name = "txtUraianKeluhan"
        Me.txtUraianKeluhan.Size = New System.Drawing.Size(342, 18)
        Me.txtUraianKeluhan.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 14)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "I. Informasi Keluhan"
        '
        'dtpInfoKeluhan
        '
        Me.dtpInfoKeluhan.CustomFormat = "dd-MMM-yyyy  HH:mm:ss"
        Me.dtpInfoKeluhan.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInfoKeluhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInfoKeluhan.Location = New System.Drawing.Point(105, 27)
        Me.dtpInfoKeluhan.Name = "dtpInfoKeluhan"
        Me.dtpInfoKeluhan.Size = New System.Drawing.Size(164, 22)
        Me.dtpInfoKeluhan.TabIndex = 45
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 14)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Uraian Keluhan"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 14)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tanggal"
        '
        'Frm_Complaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 742)
        Me.Controls.Add(Me.P_Item)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Name = "Frm_Complaint"
        Me.Text = "Form Penanganan Complaint"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.P_Item.ResumeLayout(False)
        Me.P_Item.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaProj As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtp_complaint As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNoUrut As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBagian As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaDiterima As System.Windows.Forms.TextBox
    Friend WithEvents P_Item As System.Windows.Forms.Panel
    Friend WithEvents dtpInfoKeluhan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_approve As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_reject As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUraianKeluhan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxTypeKeluhan As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNotesMarketing As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpMarketing As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAnalisa As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtpAnalisa As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtpHasilVerifikasi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtUraianHasilPenanganan As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dtpHasilPenanganan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTindakLanjut As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpPenanganan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtAwalNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents gvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents dtpTarget As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbAwalSdh As System.Windows.Forms.RadioButton
    Friend WithEvents rbAwalBlm As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbAkhirSdh As System.Windows.Forms.RadioButton
    Friend WithEvents rbAkhirBlm As System.Windows.Forms.RadioButton
    Friend WithEvents txtIndexDetail As System.Windows.Forms.TextBox
    Friend WithEvents txtPIC As System.Windows.Forms.TextBox
    Friend WithEvents txtRejectReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectReason As System.Windows.Forms.Label
    Friend WithEvents txtAkhirNotes As System.Windows.Forms.TextBox
End Class
