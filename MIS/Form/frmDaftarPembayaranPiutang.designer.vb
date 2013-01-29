<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDaftarPembayaranPiutang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDaftarPembayaranPiutang))
        Me.btn_save = New System.Windows.Forms.Button
        Me.gvPelunasan = New System.Windows.Forms.DataGridView
        Me.txt_NmKolektor = New System.Windows.Forms.TextBox
        Me.dt_Pelunasan = New System.Windows.Forms.DateTimePicker
        Me.txt_DocNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_emp = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.dtFrom = New System.Windows.Forms.DateTimePicker
        Me.dtTo = New System.Windows.Forms.DateTimePicker
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtInvoice = New System.Windows.Forms.TextBox
        Me.btnInvoice = New System.Windows.Forms.Button
        Me.ts_Save = New System.Windows.Forms.ToolStripButton
        CType(Me.gvPelunasan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(247, 144)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(83, 27)
        Me.btn_save.TabIndex = 51
        Me.btn_save.Text = "Print"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'gvPelunasan
        '
        Me.gvPelunasan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvPelunasan.Location = New System.Drawing.Point(0, 177)
        Me.gvPelunasan.Name = "gvPelunasan"
        Me.gvPelunasan.Size = New System.Drawing.Size(1011, 345)
        Me.gvPelunasan.TabIndex = 50
        '
        'txt_NmKolektor
        '
        Me.txt_NmKolektor.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NmKolektor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NmKolektor.Enabled = False
        Me.txt_NmKolektor.Location = New System.Drawing.Point(567, 93)
        Me.txt_NmKolektor.Name = "txt_NmKolektor"
        Me.txt_NmKolektor.Size = New System.Drawing.Size(279, 20)
        Me.txt_NmKolektor.TabIndex = 49
        '
        'dt_Pelunasan
        '
        Me.dt_Pelunasan.CustomFormat = "dd MMMM yyyy"
        Me.dt_Pelunasan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_Pelunasan.Location = New System.Drawing.Point(485, 25)
        Me.dt_Pelunasan.Name = "dt_Pelunasan"
        Me.dt_Pelunasan.Size = New System.Drawing.Size(130, 20)
        Me.dt_Pelunasan.TabIndex = 48
        '
        'txt_DocNo
        '
        Me.txt_DocNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_DocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_DocNo.Enabled = False
        Me.txt_DocNo.Location = New System.Drawing.Point(195, 25)
        Me.txt_DocNo.Name = "txt_DocNo"
        Me.txt_DocNo.Size = New System.Drawing.Size(130, 20)
        Me.txt_DocNo.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(343, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Collector ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(343, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Tanggal Pelunasan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "No DP"
        '
        'txt_emp
        '
        Me.txt_emp.Location = New System.Drawing.Point(485, 93)
        Me.txt_emp.Name = "txt_emp"
        Me.txt_emp.Size = New System.Drawing.Size(76, 20)
        Me.txt_emp.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 15)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Tanggal Jatuh Tempo From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(343, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Until"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(195, 94)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(118, 20)
        Me.txtCustomer.TabIndex = 58
        '
        'dtFrom
        '
        Me.dtFrom.CustomFormat = "dd MMMM yyyy"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(195, 72)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(130, 20)
        Me.dtFrom.TabIndex = 59
        '
        'dtTo
        '
        Me.dtTo.CustomFormat = "dd MMMM yyyy"
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(485, 73)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(130, 20)
        Me.dtTo.TabIndex = 60
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(24, 144)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(71, 27)
        Me.btnSearch.TabIndex = 61
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(95, 144)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(71, 27)
        Me.btnsave.TabIndex = 62
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(165, 144)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(83, 27)
        Me.btnDelete.TabIndex = 63
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Period"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriod.Enabled = False
        Me.txtPeriod.Location = New System.Drawing.Point(195, 48)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(76, 20)
        Me.txtPeriod.TabIndex = 65
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_Save})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1010, 25)
        Me.Ts_PO.TabIndex = 71
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Invoice"
        '
        'txtInvoice
        '
        Me.txtInvoice.Location = New System.Drawing.Point(195, 116)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(118, 20)
        Me.txtInvoice.TabIndex = 73
        '
        'btnInvoice
        '
        Me.btnInvoice.Enabled = False
        Me.btnInvoice.Location = New System.Drawing.Point(330, 144)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(127, 27)
        Me.btnInvoice.TabIndex = 74
        Me.btnInvoice.Text = "Insert Invoice"
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'ts_Save
        '
        Me.ts_Save.Image = CType(resources.GetObject("ts_Save.Image"), System.Drawing.Image)
        Me.ts_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Save.Name = "ts_Save"
        Me.ts_Save.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_Save.Size = New System.Drawing.Size(56, 22)
        Me.ts_Save.Text = "Save"
        '
        'frmDaftarPembayaranPiutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 520)
        Me.Controls.Add(Me.btnInvoice)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_emp)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.gvPelunasan)
        Me.Controls.Add(Me.txt_NmKolektor)
        Me.Controls.Add(Me.dt_Pelunasan)
        Me.Controls.Add(Me.txt_DocNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmDaftarPembayaranPiutang"
        Me.Text = "Daftar Penagihan Piutang"
        CType(Me.gvPelunasan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents gvPelunasan As System.Windows.Forms.DataGridView
    Friend WithEvents txt_NmKolektor As System.Windows.Forms.TextBox
    Friend WithEvents dt_Pelunasan As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_DocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_emp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents ts_Save As System.Windows.Forms.ToolStripButton
End Class
