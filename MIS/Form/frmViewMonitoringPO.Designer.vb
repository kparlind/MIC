<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewMonitoringPO
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cb_Supplier = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dt_to = New System.Windows.Forms.DateTimePicker
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.gv_MonitorPO = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv_MonitorPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cb_Supplier)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dt_to)
        Me.GroupBox1.Controls.Add(Me.dt_from)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1057, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Button1.Location = New System.Drawing.Point(447, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cb_Supplier
        '
        Me.cb_Supplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Supplier.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cb_Supplier.FormattingEnabled = True
        Me.cb_Supplier.Location = New System.Drawing.Point(124, 49)
        Me.cb_Supplier.Name = "cb_Supplier"
        Me.cb_Supplier.Size = New System.Drawing.Size(317, 24)
        Me.cb_Supplier.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(12, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Supplier"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(277, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To"
        '
        'dt_to
        '
        Me.dt_to.CustomFormat = "dd-MMM-yyyy"
        Me.dt_to.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_to.Location = New System.Drawing.Point(308, 21)
        Me.dt_to.Name = "dt_to"
        Me.dt_to.Size = New System.Drawing.Size(133, 23)
        Me.dt_to.TabIndex = 3
        '
        'dt_from
        '
        Me.dt_from.CustomFormat = "dd-MMM-yyyy"
        Me.dt_from.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(124, 22)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(147, 23)
        Me.dt_from.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PO Date"
        '
        'btn_cari
        '
        Me.btn_cari.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btn_cari.Location = New System.Drawing.Point(447, 18)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(175, 27)
        Me.btn_cari.TabIndex = 0
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'gv_MonitorPO
        '
        Me.gv_MonitorPO.AllowUserToAddRows = False
        Me.gv_MonitorPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_MonitorPO.Location = New System.Drawing.Point(12, 118)
        Me.gv_MonitorPO.Name = "gv_MonitorPO"
        Me.gv_MonitorPO.Size = New System.Drawing.Size(1057, 417)
        Me.gv_MonitorPO.TabIndex = 2
        '
        'frmViewMonitoringPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 539)
        Me.Controls.Add(Me.gv_MonitorPO)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewMonitoringPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitoring PO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gv_MonitorPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Supplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dt_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents gv_MonitorPO As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
