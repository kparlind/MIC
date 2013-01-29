<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PencairanGiro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PencairanGiro))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_nogiro = New System.Windows.Forms.TextBox
        Me.txt_NamaBank = New System.Windows.Forms.TextBox
        Me.txt_tglBayar = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_jatuhtempo = New System.Windows.Forms.TextBox
        Me.txt_nilaigiro = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_pelunasan = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_tglCair = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_bank = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.gvGiro = New System.Windows.Forms.DataGridView
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton
        Me.ts_delete = New System.Windows.Forms.ToolStripButton
        Me.cmb_status = New System.Windows.Forms.ComboBox
        CType(Me.gvGiro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Giro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(140, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Bank"
        '
        'txt_nogiro
        '
        Me.txt_nogiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nogiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nogiro.Enabled = False
        Me.txt_nogiro.Location = New System.Drawing.Point(12, 70)
        Me.txt_nogiro.Name = "txt_nogiro"
        Me.txt_nogiro.Size = New System.Drawing.Size(104, 20)
        Me.txt_nogiro.TabIndex = 3
        '
        'txt_NamaBank
        '
        Me.txt_NamaBank.BackColor = System.Drawing.Color.DarkGray
        Me.txt_NamaBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NamaBank.Enabled = False
        Me.txt_NamaBank.Location = New System.Drawing.Point(117, 70)
        Me.txt_NamaBank.Name = "txt_NamaBank"
        Me.txt_NamaBank.Size = New System.Drawing.Size(104, 20)
        Me.txt_NamaBank.TabIndex = 4
        '
        'txt_tglBayar
        '
        Me.txt_tglBayar.BackColor = System.Drawing.Color.DarkGray
        Me.txt_tglBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tglBayar.Enabled = False
        Me.txt_tglBayar.Location = New System.Drawing.Point(222, 70)
        Me.txt_tglBayar.Name = "txt_tglBayar"
        Me.txt_tglBayar.Size = New System.Drawing.Size(104, 20)
        Me.txt_tglBayar.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(240, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tanggal Bayar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(341, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Jatuh Tempo"
        '
        'txt_jatuhtempo
        '
        Me.txt_jatuhtempo.BackColor = System.Drawing.Color.DarkGray
        Me.txt_jatuhtempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_jatuhtempo.Enabled = False
        Me.txt_jatuhtempo.Location = New System.Drawing.Point(327, 70)
        Me.txt_jatuhtempo.Name = "txt_jatuhtempo"
        Me.txt_jatuhtempo.Size = New System.Drawing.Size(104, 20)
        Me.txt_jatuhtempo.TabIndex = 8
        '
        'txt_nilaigiro
        '
        Me.txt_nilaigiro.BackColor = System.Drawing.Color.DarkGray
        Me.txt_nilaigiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_nilaigiro.Enabled = False
        Me.txt_nilaigiro.Location = New System.Drawing.Point(432, 70)
        Me.txt_nilaigiro.Name = "txt_nilaigiro"
        Me.txt_nilaigiro.Size = New System.Drawing.Size(104, 20)
        Me.txt_nilaigiro.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(460, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Nilai Giro"
        '
        'txt_pelunasan
        '
        Me.txt_pelunasan.BackColor = System.Drawing.Color.DarkGray
        Me.txt_pelunasan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pelunasan.Enabled = False
        Me.txt_pelunasan.Location = New System.Drawing.Point(537, 70)
        Me.txt_pelunasan.Name = "txt_pelunasan"
        Me.txt_pelunasan.Size = New System.Drawing.Size(104, 20)
        Me.txt_pelunasan.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(551, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "No Pelunasan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(677, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Status"
        '
        'txt_tglCair
        '
        Me.txt_tglCair.BackColor = System.Drawing.Color.DarkGray
        Me.txt_tglCair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_tglCair.Enabled = False
        Me.txt_tglCair.Location = New System.Drawing.Point(747, 70)
        Me.txt_tglCair.Name = "txt_tglCair"
        Me.txt_tglCair.Size = New System.Drawing.Size(104, 20)
        Me.txt_tglCair.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(767, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Tanggal Cair"
        '
        'txt_bank
        '
        Me.txt_bank.BackColor = System.Drawing.Color.DarkGray
        Me.txt_bank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bank.Enabled = False
        Me.txt_bank.Location = New System.Drawing.Point(852, 70)
        Me.txt_bank.Name = "txt_bank"
        Me.txt_bank.Size = New System.Drawing.Size(104, 20)
        Me.txt_bank.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(867, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 15)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Bank"
        '
        'gvGiro
        '
        Me.gvGiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvGiro.Location = New System.Drawing.Point(-2, 138)
        Me.gvGiro.Name = "gvGiro"
        Me.gvGiro.Size = New System.Drawing.Size(987, 194)
        Me.gvGiro.TabIndex = 19
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Location = New System.Drawing.Point(152, 105)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 41
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(82, 105)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 39
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(12, 105)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 38
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New, Me.ts_Edit, Me.ts_save, Me.ts_cancel, Me.ts_delete})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(985, 25)
        Me.Ts_PO.TabIndex = 42
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
        'cmb_status
        '
        Me.cmb_status.BackColor = System.Drawing.Color.DarkGray
        Me.cmb_status.Enabled = False
        Me.cmb_status.FormattingEnabled = True
        Me.cmb_status.Items.AddRange(New Object() {"Open", "Tolak", "Cair"})
        Me.cmb_status.Location = New System.Drawing.Point(642, 69)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(103, 21)
        Me.cmb_status.TabIndex = 43
        '
        'Frm_PencairanGiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 332)
        Me.Controls.Add(Me.cmb_status)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.Btn_cancel)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.gvGiro)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_bank)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_tglCair)
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
        Me.Name = "Frm_PencairanGiro"
        Me.Text = "Pencairan Giro"
        CType(Me.gvGiro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_nogiro As System.Windows.Forms.TextBox
    Friend WithEvents txt_NamaBank As System.Windows.Forms.TextBox
    Friend WithEvents txt_tglBayar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_jatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents txt_nilaigiro As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_pelunasan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_tglCair As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_bank As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gvGiro As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmb_status As System.Windows.Forms.ComboBox
End Class
