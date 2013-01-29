<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPencairanGiroPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPencairanGiroPiutang))
        Me.cmb_status = New System.Windows.Forms.ComboBox
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.gvGiro = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_bank = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_pelunasan = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_nilaigiro = New System.Windows.Forms.TextBox
        Me.txt_jatuhtempo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_tglBayar = New System.Windows.Forms.TextBox
        Me.txt_NamaBank = New System.Windows.Forms.TextBox
        Me.txt_nogiro = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txt_tglCair = New System.Windows.Forms.DateTimePicker
        Me.Period = New System.Windows.Forms.Label
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Ts_PO.SuspendLayout()
        CType(Me.gvGiro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmb_status
        '
        Me.cmb_status.BackColor = System.Drawing.Color.DarkGray
        Me.cmb_status.Enabled = False
        Me.cmb_status.FormattingEnabled = True
        Me.cmb_status.Items.AddRange(New Object() {"", "Open" & Global.Microsoft.VisualBasic.ChrW(9), "Tolak", "Cair"})
        Me.cmb_status.Location = New System.Drawing.Point(642, 83)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(103, 21)
        Me.cmb_status.TabIndex = 68
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_save})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(970, 25)
        Me.Ts_PO.TabIndex = 67
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
        Me.ts_save.Size = New System.Drawing.Size(51, 22)
        Me.ts_save.Text = "Save"
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(152, 110)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 66
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(82, 110)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 64
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(12, 110)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 63
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'gvGiro
        '
        Me.gvGiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvGiro.Location = New System.Drawing.Point(0, 143)
        Me.gvGiro.Name = "gvGiro"
        Me.gvGiro.Size = New System.Drawing.Size(970, 160)
        Me.gvGiro.TabIndex = 61
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(882, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 15)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Bank"
        '
        'txt_bank
        '
        Me.txt_bank.BackColor = System.Drawing.Color.DarkGray
        Me.txt_bank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bank.Enabled = False
        Me.txt_bank.Location = New System.Drawing.Point(847, 83)
        Me.txt_bank.Name = "txt_bank"
        Me.txt_bank.Size = New System.Drawing.Size(104, 20)
        Me.txt_bank.TabIndex = 59
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(755, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Tanggal Cair"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(677, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(551, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "No Pelunasan"
        '
        'txt_pelunasan
        '
        Me.txt_pelunasan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_pelunasan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pelunasan.Enabled = False
        Me.txt_pelunasan.Location = New System.Drawing.Point(537, 84)
        Me.txt_pelunasan.Name = "txt_pelunasan"
        Me.txt_pelunasan.Size = New System.Drawing.Size(104, 20)
        Me.txt_pelunasan.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(460, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Nilai Giro"
        '
        'txt_nilaigiro
        '
        Me.txt_nilaigiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nilaigiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nilaigiro.Enabled = False
        Me.txt_nilaigiro.Location = New System.Drawing.Point(432, 84)
        Me.txt_nilaigiro.Name = "txt_nilaigiro"
        Me.txt_nilaigiro.Size = New System.Drawing.Size(104, 20)
        Me.txt_nilaigiro.TabIndex = 52
        '
        'txt_jatuhtempo
        '
        Me.txt_jatuhtempo.BackColor = System.Drawing.Color.DarkGray
        Me.txt_jatuhtempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_jatuhtempo.Enabled = False
        Me.txt_jatuhtempo.Location = New System.Drawing.Point(327, 84)
        Me.txt_jatuhtempo.Name = "txt_jatuhtempo"
        Me.txt_jatuhtempo.Size = New System.Drawing.Size(104, 20)
        Me.txt_jatuhtempo.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(341, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Jatuh Tempo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Tanggal Bayar"
        '
        'txt_tglBayar
        '
        Me.txt_tglBayar.BackColor = System.Drawing.Color.DarkGray
        Me.txt_tglBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tglBayar.Enabled = False
        Me.txt_tglBayar.Location = New System.Drawing.Point(222, 84)
        Me.txt_tglBayar.Name = "txt_tglBayar"
        Me.txt_tglBayar.Size = New System.Drawing.Size(104, 20)
        Me.txt_tglBayar.TabIndex = 48
        '
        'txt_NamaBank
        '
        Me.txt_NamaBank.BackColor = System.Drawing.Color.DarkGray
        Me.txt_NamaBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NamaBank.Location = New System.Drawing.Point(117, 84)
        Me.txt_NamaBank.Name = "txt_NamaBank"
        Me.txt_NamaBank.Size = New System.Drawing.Size(104, 20)
        Me.txt_NamaBank.TabIndex = 47
        '
        'txt_nogiro
        '
        Me.txt_nogiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nogiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nogiro.Enabled = False
        Me.txt_nogiro.Location = New System.Drawing.Point(12, 84)
        Me.txt_nogiro.Name = "txt_nogiro"
        Me.txt_nogiro.Size = New System.Drawing.Size(104, 20)
        Me.txt_nogiro.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Nama Bank"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "No Giro"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(297, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 69
        Me.TextBox1.Visible = False
        '
        'txt_tglCair
        '
        Me.txt_tglCair.CustomFormat = "dd-MM-yyyy"
        Me.txt_tglCair.Enabled = False
        Me.txt_tglCair.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txt_tglCair.Location = New System.Drawing.Point(745, 83)
        Me.txt_tglCair.Name = "txt_tglCair"
        Me.txt_tglCair.Size = New System.Drawing.Size(99, 20)
        Me.txt_tglCair.TabIndex = 70
        '
        'Period
        '
        Me.Period.AutoSize = True
        Me.Period.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Period.Location = New System.Drawing.Point(12, 25)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(43, 15)
        Me.Period.TabIndex = 71
        Me.Period.Text = "Period"
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.Color.DarkGray
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Location = New System.Drawing.Point(67, 25)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(73, 20)
        Me.txtPeriod.TabIndex = 72
        '
        'FrmPencairanGiroPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 302)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Period)
        Me.Controls.Add(Me.txt_tglCair)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmb_status)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.gvGiro)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_bank)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_pelunasan)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_nilaigiro)
        Me.Controls.Add(Me.txt_jatuhtempo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_tglBayar)
        Me.Controls.Add(Me.txt_NamaBank)
        Me.Controls.Add(Me.txt_nogiro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPencairanGiroPiutang"
        Me.Text = "Pencairan Giro Piutang"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        CType(Me.gvGiro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_status As System.Windows.Forms.ComboBox
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents gvGiro As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_bank As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_pelunasan As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_nilaigiro As System.Windows.Forms.TextBox
    Friend WithEvents txt_jatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_tglBayar As System.Windows.Forms.TextBox
    Friend WithEvents txt_NamaBank As System.Windows.Forms.TextBox
    Friend WithEvents txt_nogiro As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_tglCair As System.Windows.Forms.DateTimePicker
    Friend WithEvents Period As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
End Class
