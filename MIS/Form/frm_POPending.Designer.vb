<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_POPending
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_POPending))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_PONo = New System.Windows.Forms.TextBox
        Me.txtPoNo_Dialog = New System.Windows.Forms.TextBox
        Me.cb_status = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.Txt_Notes = New System.Windows.Forms.TextBox
        Me.txt_SuppName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PODate_To = New System.Windows.Forms.DateTimePicker
        Me.PoDate_Fr = New System.Windows.Forms.DateTimePicker
        Me.gv = New System.Windows.Forms.DataGridView
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ts_PO.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_PONo)
        Me.GroupBox1.Controls.Add(Me.txtPoNo_Dialog)
        Me.GroupBox1.Controls.Add(Me.cb_status)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.Txt_Notes)
        Me.GroupBox1.Controls.Add(Me.txt_SuppName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PODate_To)
        Me.GroupBox1.Controls.Add(Me.PoDate_Fr)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1017, 120)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'txt_PONo
        '
        Me.txt_PONo.Location = New System.Drawing.Point(78, 40)
        Me.txt_PONo.Name = "txt_PONo"
        Me.txt_PONo.Size = New System.Drawing.Size(165, 22)
        Me.txt_PONo.TabIndex = 22
        '
        'txtPoNo_Dialog
        '
        Me.txtPoNo_Dialog.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtPoNo_Dialog.Location = New System.Drawing.Point(479, 35)
        Me.txtPoNo_Dialog.Name = "txtPoNo_Dialog"
        Me.txtPoNo_Dialog.Size = New System.Drawing.Size(116, 22)
        Me.txtPoNo_Dialog.TabIndex = 21
        Me.txtPoNo_Dialog.Visible = False
        '
        'cb_status
        '
        Me.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(78, 63)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(269, 22)
        Me.cb_status.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Status"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(377, 90)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(93, 23)
        Me.btn_cari.TabIndex = 18
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'Txt_Notes
        '
        Me.Txt_Notes.Location = New System.Drawing.Point(78, 91)
        Me.Txt_Notes.Name = "Txt_Notes"
        Me.Txt_Notes.Size = New System.Drawing.Size(269, 22)
        Me.Txt_Notes.TabIndex = 17
        '
        'txt_SuppName
        '
        Me.txt_SuppName.Location = New System.Drawing.Point(479, 15)
        Me.txt_SuppName.Name = "txt_SuppName"
        Me.txt_SuppName.Size = New System.Drawing.Size(191, 22)
        Me.txt_SuppName.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Notes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(385, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Supplier Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "PO No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "PO Date"
        '
        'PODate_To
        '
        Me.PODate_To.CustomFormat = "dd-MMM-yyyy"
        Me.PODate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PODate_To.Location = New System.Drawing.Point(243, 14)
        Me.PODate_To.Name = "PODate_To"
        Me.PODate_To.Size = New System.Drawing.Size(131, 22)
        Me.PODate_To.TabIndex = 9
        '
        'PoDate_Fr
        '
        Me.PoDate_Fr.CustomFormat = "dd-MMM-yyyy"
        Me.PoDate_Fr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.PoDate_Fr.Location = New System.Drawing.Point(78, 14)
        Me.PoDate_Fr.Name = "PoDate_Fr"
        Me.PoDate_Fr.Size = New System.Drawing.Size(138, 22)
        Me.PoDate_Fr.TabIndex = 8
        '
        'gv
        '
        Me.gv.AllowUserToAddRows = False
        Me.gv.AllowUserToDeleteRows = False
        Me.gv.AllowUserToOrderColumns = True
        Me.gv.AllowUserToResizeColumns = False
        Me.gv.AllowUserToResizeRows = False
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Location = New System.Drawing.Point(14, 157)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gv.Size = New System.Drawing.Size(1017, 415)
        Me.gv.TabIndex = 10
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1043, 25)
        Me.Ts_PO.TabIndex = 13
        Me.Ts_PO.Text = "PO"
        '
        'ts_New
        '
        Me.ts_New.Image = CType(resources.GetObject("ts_New.Image"), System.Drawing.Image)
        Me.ts_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_New.Name = "ts_New"
        Me.ts_New.Size = New System.Drawing.Size(51, 22)
        Me.ts_New.Text = "New"
        '
        'frm_POPending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 584)
        Me.Controls.Add(Me.Ts_PO)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_POPending"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PO Pending"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PODate_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents PoDate_Fr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Notes As System.Windows.Forms.TextBox
    Friend WithEvents txt_SuppName As System.Windows.Forms.TextBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents txtPoNo_Dialog As System.Windows.Forms.TextBox
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_PONo As System.Windows.Forms.TextBox
End Class
