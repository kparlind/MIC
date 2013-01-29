<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewMonitoringPR
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
        Me.cb_Status = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cb_item = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cb_Requesterdepart = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dt_to = New System.Windows.Forms.DateTimePicker
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.gv_MonitorPR = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv_MonitorPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_Status)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cb_item)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cb_Requesterdepart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dt_to)
        Me.GroupBox1.Controls.Add(Me.dt_from)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(930, 142)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cb_Status
        '
        Me.cb_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Status.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cb_Status.FormattingEnabled = True
        Me.cb_Status.Items.AddRange(New Object() {"All", "Lunas", "Belum Lunas"})
        Me.cb_Status.Location = New System.Drawing.Point(124, 105)
        Me.cb_Status.Name = "cb_Status"
        Me.cb_Status.Size = New System.Drawing.Size(307, 24)
        Me.cb_Status.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(12, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Status"
        '
        'cb_item
        '
        Me.cb_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_item.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cb_item.FormattingEnabled = True
        Me.cb_item.Location = New System.Drawing.Point(124, 77)
        Me.cb_item.Name = "cb_item"
        Me.cb_item.Size = New System.Drawing.Size(307, 24)
        Me.cb_item.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(12, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Item"
        '
        'cb_Requesterdepart
        '
        Me.cb_Requesterdepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Requesterdepart.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cb_Requesterdepart.FormattingEnabled = True
        Me.cb_Requesterdepart.Location = New System.Drawing.Point(124, 49)
        Me.cb_Requesterdepart.Name = "cb_Requesterdepart"
        Me.cb_Requesterdepart.Size = New System.Drawing.Size(307, 24)
        Me.cb_Requesterdepart.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(12, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Requester Area"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(267, 23)
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
        Me.dt_to.Location = New System.Drawing.Point(296, 23)
        Me.dt_to.Name = "dt_to"
        Me.dt_to.Size = New System.Drawing.Size(135, 23)
        Me.dt_to.TabIndex = 3
        '
        'dt_from
        '
        Me.dt_from.CustomFormat = "dd-MMM-yyyy"
        Me.dt_from.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(124, 22)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(137, 23)
        Me.dt_from.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PR Date"
        '
        'btn_cari
        '
        Me.btn_cari.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.btn_cari.Location = New System.Drawing.Point(437, 22)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(175, 24)
        Me.btn_cari.TabIndex = 0
        Me.btn_cari.Text = "Search"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'gv_MonitorPR
        '
        Me.gv_MonitorPR.AllowUserToAddRows = False
        Me.gv_MonitorPR.AllowUserToDeleteRows = False
        Me.gv_MonitorPR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_MonitorPR.Location = New System.Drawing.Point(12, 164)
        Me.gv_MonitorPR.Name = "gv_MonitorPR"
        Me.gv_MonitorPR.Size = New System.Drawing.Size(930, 501)
        Me.gv_MonitorPR.TabIndex = 1
        '
        'FrmViewMonitoringPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 677)
        Me.Controls.Add(Me.gv_MonitorPR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmViewMonitoringPR"
        Me.Text = "FrmViewMonitoringPR"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gv_MonitorPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dt_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents gv_MonitorPR As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_Requesterdepart As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_Status As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_item As System.Windows.Forms.ComboBox
End Class
