<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ViewComplaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ViewComplaint))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.gvComplaint = New System.Windows.Forms.DataGridView
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        Me.dt_To = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.txtNamaBagian = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNamaDiterima = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNamaProject = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNoUrut = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCustID = New System.Windows.Forms.TextBox
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtStatusID = New System.Windows.Forms.TextBox
        Me.txtStatusDesc = New System.Windows.Forms.TextBox
        Me.Ts_PO.SuspendLayout()
        CType(Me.gvComplaint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1166, 25)
        Me.Ts_PO.TabIndex = 28
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Size = New System.Drawing.Size(48, 22)
        Me.ts_New.Text = "New"
        '
        'gvComplaint
        '
        Me.gvComplaint.AllowUserToAddRows = False
        Me.gvComplaint.AllowUserToDeleteRows = False
        Me.gvComplaint.AllowUserToOrderColumns = True
        Me.gvComplaint.AllowUserToResizeColumns = False
        Me.gvComplaint.AllowUserToResizeRows = False
        Me.gvComplaint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvComplaint.Dock = System.Windows.Forms.DockStyle.Top
        Me.gvComplaint.Location = New System.Drawing.Point(0, 253)
        Me.gvComplaint.Name = "gvComplaint"
        Me.gvComplaint.ReadOnly = True
        Me.gvComplaint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvComplaint.Size = New System.Drawing.Size(1166, 532)
        Me.gvComplaint.TabIndex = 30
        '
        'dt_from
        '
        Me.dt_from.CustomFormat = "dd-MMM-yyyy"
        Me.dt_from.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(111, 19)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(136, 22)
        Me.dt_from.TabIndex = 8
        '
        'dt_To
        '
        Me.dt_To.CustomFormat = "dd-MMM-yyyy"
        Me.dt_To.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_To.Location = New System.Drawing.Point(312, 19)
        Me.dt_To.Name = "dt_To"
        Me.dt_To.Size = New System.Drawing.Size(130, 22)
        Me.dt_To.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Complaint Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(266, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "to"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStatusID)
        Me.GroupBox1.Controls.Add(Me.txtStatusDesc)
        Me.GroupBox1.Controls.Add(Me.txtCustID)
        Me.GroupBox1.Controls.Add(Me.txtCustName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.txtNamaBagian)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtNamaDiterima)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtAlamat)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNamaProject)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNoUrut)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dt_To)
        Me.GroupBox1.Controls.Add(Me.dt_from)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1166, 228)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Filter"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 202)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Status"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(366, 144)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(93, 50)
        Me.btn_cari.TabIndex = 24
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'txtNamaBagian
        '
        Me.txtNamaBagian.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaBagian.Location = New System.Drawing.Point(111, 172)
        Me.txtNamaBagian.Name = "txtNamaBagian"
        Me.txtNamaBagian.Size = New System.Drawing.Size(203, 22)
        Me.txtNamaBagian.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Nama Bagian"
        '
        'txtNamaDiterima
        '
        Me.txtNamaDiterima.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaDiterima.Location = New System.Drawing.Point(111, 147)
        Me.txtNamaDiterima.Name = "txtNamaDiterima"
        Me.txtNamaDiterima.Size = New System.Drawing.Size(203, 22)
        Me.txtNamaDiterima.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 14)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Nama Penerima"
        '
        'txtAlamat
        '
        Me.txtAlamat.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(111, 122)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(203, 22)
        Me.txtAlamat.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Alamat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 14)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Customer"
        '
        'txtNamaProject
        '
        Me.txtNamaProject.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaProject.Location = New System.Drawing.Point(111, 72)
        Me.txtNamaProject.Name = "txtNamaProject"
        Me.txtNamaProject.Size = New System.Drawing.Size(203, 22)
        Me.txtNamaProject.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Nama Project"
        '
        'txtNoUrut
        '
        Me.txtNoUrut.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoUrut.Location = New System.Drawing.Point(111, 46)
        Me.txtNoUrut.Name = "txtNoUrut"
        Me.txtNoUrut.Size = New System.Drawing.Size(100, 22)
        Me.txtNoUrut.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "No Urut"
        '
        'txtCustID
        '
        Me.txtCustID.BackColor = System.Drawing.SystemColors.Window
        Me.txtCustID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustID.Location = New System.Drawing.Point(111, 96)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(77, 22)
        Me.txtCustID.TabIndex = 39
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Enabled = False
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(189, 96)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(264, 22)
        Me.txtCustName.TabIndex = 38
        '
        'txtStatusID
        '
        Me.txtStatusID.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatusID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusID.Location = New System.Drawing.Point(111, 195)
        Me.txtStatusID.Name = "txtStatusID"
        Me.txtStatusID.Size = New System.Drawing.Size(77, 22)
        Me.txtStatusID.TabIndex = 41
        '
        'txtStatusDesc
        '
        Me.txtStatusDesc.BackColor = System.Drawing.Color.LightGray
        Me.txtStatusDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatusDesc.Enabled = False
        Me.txtStatusDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatusDesc.Location = New System.Drawing.Point(189, 195)
        Me.txtStatusDesc.Name = "txtStatusDesc"
        Me.txtStatusDesc.Size = New System.Drawing.Size(264, 22)
        Me.txtStatusDesc.TabIndex = 40
        '
        'Frm_ViewComplaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1166, 753)
        Me.Controls.Add(Me.gvComplaint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Name = "Frm_ViewComplaint"
        Me.Text = "View Complaint"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        CType(Me.gvComplaint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvComplaint As System.Windows.Forms.DataGridView
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoUrut As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNamaProject As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNamaBagian As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNamaDiterima As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStatusID As System.Windows.Forms.TextBox
    Friend WithEvents txtStatusDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCustID As System.Windows.Forms.TextBox
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
End Class
