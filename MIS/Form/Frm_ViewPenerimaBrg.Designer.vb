<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ViewPenerimaBrg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ViewPenerimaBrg))
        Me.Ts_PO = New System.Windows.Forms.ToolStrip
        Me.ts_New = New System.Windows.Forms.ToolStripButton
        Me.gv = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cb_status = New System.Windows.Forms.ComboBox
        Me.txtPoNo_Dialog = New System.Windows.Forms.TextBox
        Me.cb_PONo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.cb_TBNo = New System.Windows.Forms.ComboBox
        Me.Status = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TBDate_To = New System.Windows.Forms.DateTimePicker
        Me.TBDate_Fr = New System.Windows.Forms.DateTimePicker
        Me.Ts_PO.SuspendLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ts_PO
        '
        Me.Ts_PO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_New})
        Me.Ts_PO.Location = New System.Drawing.Point(0, 0)
        Me.Ts_PO.Name = "Ts_PO"
        Me.Ts_PO.Size = New System.Drawing.Size(1008, 25)
        Me.Ts_PO.TabIndex = 14
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
        'gv
        '
        Me.gv.AllowUserToAddRows = False
        Me.gv.AllowUserToDeleteRows = False
        Me.gv.AllowUserToOrderColumns = True
        Me.gv.AllowUserToResizeColumns = False
        Me.gv.AllowUserToResizeRows = False
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Location = New System.Drawing.Point(6, 164)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.Size = New System.Drawing.Size(993, 408)
        Me.gv.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_status)
        Me.GroupBox1.Controls.Add(Me.txtPoNo_Dialog)
        Me.GroupBox1.Controls.Add(Me.cb_PONo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.cb_TBNo)
        Me.GroupBox1.Controls.Add(Me.Status)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TBDate_To)
        Me.GroupBox1.Controls.Add(Me.TBDate_Fr)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(993, 137)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'cb_status
        '
        Me.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(138, 101)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(237, 22)
        Me.cb_status.Sorted = True
        Me.cb_status.TabIndex = 22
        '
        'txtPoNo_Dialog
        '
        Me.txtPoNo_Dialog.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtPoNo_Dialog.Location = New System.Drawing.Point(393, 101)
        Me.txtPoNo_Dialog.Name = "txtPoNo_Dialog"
        Me.txtPoNo_Dialog.Size = New System.Drawing.Size(116, 22)
        Me.txtPoNo_Dialog.TabIndex = 21
        Me.txtPoNo_Dialog.Visible = False
        '
        'cb_PONo
        '
        Me.cb_PONo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_PONo.FormattingEnabled = True
        Me.cb_PONo.Location = New System.Drawing.Point(138, 73)
        Me.cb_PONo.Name = "cb_PONo"
        Me.cb_PONo.Size = New System.Drawing.Size(140, 22)
        Me.cb_PONo.Sorted = True
        Me.cb_PONo.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "PO No"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(515, 97)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(108, 29)
        Me.btn_cari.TabIndex = 18
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'cb_TBNo
        '
        Me.cb_TBNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TBNo.FormattingEnabled = True
        Me.cb_TBNo.Location = New System.Drawing.Point(138, 45)
        Me.cb_TBNo.Name = "cb_TBNo"
        Me.cb_TBNo.Size = New System.Drawing.Size(140, 22)
        Me.cb_TBNo.TabIndex = 15
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Location = New System.Drawing.Point(13, 102)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(42, 14)
        Me.Status.TabIndex = 14
        Me.Status.Text = "Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Good Receipt No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 18)
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
        Me.Label1.Size = New System.Drawing.Size(111, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Good Receipt Date"
        '
        'TBDate_To
        '
        Me.TBDate_To.CustomFormat = "dd-MMM-yyyy"
        Me.TBDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TBDate_To.Location = New System.Drawing.Point(301, 14)
        Me.TBDate_To.Name = "TBDate_To"
        Me.TBDate_To.Size = New System.Drawing.Size(132, 22)
        Me.TBDate_To.TabIndex = 9
        '
        'TBDate_Fr
        '
        Me.TBDate_Fr.CustomFormat = "dd-MMM-yyyy"
        Me.TBDate_Fr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TBDate_Fr.Location = New System.Drawing.Point(138, 14)
        Me.TBDate_Fr.Name = "TBDate_Fr"
        Me.TBDate_Fr.Size = New System.Drawing.Size(129, 22)
        Me.TBDate_Fr.TabIndex = 8
        '
        'Frm_ViewPenerimaBrg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 584)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Ts_PO)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ViewPenerimaBrg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Penerimaan Barang"
        Me.Ts_PO.ResumeLayout(False)
        Me.Ts_PO.PerformLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Ts_PO As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_New As System.Windows.Forms.ToolStripButton
    Friend WithEvents gv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents txtPoNo_Dialog As System.Windows.Forms.TextBox
    Friend WithEvents cb_PONo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents cb_TBNo As System.Windows.Forms.ComboBox
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBDate_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents TBDate_Fr As System.Windows.Forms.DateTimePicker
End Class
