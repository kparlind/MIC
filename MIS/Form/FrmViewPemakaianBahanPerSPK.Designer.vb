<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewPemakaianBahanPerSPK
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
        Me.gv = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cb_Customer = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.cb_SPKNo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dt_to = New System.Windows.Forms.DateTimePicker
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gv
        '
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv.Location = New System.Drawing.Point(0, 107)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.Size = New System.Drawing.Size(872, 435)
        Me.gv.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_Customer)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.cb_SPKNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dt_to)
        Me.GroupBox1.Controls.Add(Me.dt_from)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 107)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian Data"
        '
        'cb_Customer
        '
        Me.cb_Customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Customer.FormattingEnabled = True
        Me.cb_Customer.Location = New System.Drawing.Point(101, 70)
        Me.cb_Customer.Name = "cb_Customer"
        Me.cb_Customer.Size = New System.Drawing.Size(303, 21)
        Me.cb_Customer.Sorted = True
        Me.cb_Customer.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Customer"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(691, 25)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(148, 61)
        Me.btn_cari.TabIndex = 18
        Me.btn_cari.Text = "Cari"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'cb_SPKNo
        '
        Me.cb_SPKNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_SPKNo.FormattingEnabled = True
        Me.cb_SPKNo.Location = New System.Drawing.Point(101, 47)
        Me.cb_SPKNo.Name = "cb_SPKNo"
        Me.cb_SPKNo.Size = New System.Drawing.Size(149, 21)
        Me.cb_SPKNo.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nomor SPK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "sampai"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tanggal SPK"
        '
        'dt_to
        '
        Me.dt_to.CustomFormat = "dd-MMMM-yyyy"
        Me.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_to.Location = New System.Drawing.Point(302, 21)
        Me.dt_to.Name = "dt_to"
        Me.dt_to.Size = New System.Drawing.Size(143, 20)
        Me.dt_to.TabIndex = 9
        '
        'dt_from
        '
        Me.dt_from.CustomFormat = "dd-MMMM-yyyy"
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(101, 21)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(149, 20)
        Me.dt_from.TabIndex = 8
        '
        'FrmViewPemakaianBahanPerSPK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 542)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmViewPemakaianBahanPerSPK"
        Me.Text = "FrmViewPemakaianBahanPerSPK"
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Customer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents cb_SPKNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dt_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
End Class
