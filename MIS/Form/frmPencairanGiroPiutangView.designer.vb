﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPencairanGiroPiutangView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPencairanGiroPiutangView))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btn_new = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_cari = New System.Windows.Forms.Button()
        Me.cb_PH = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBDate_To = New System.Windows.Forms.DateTimePicker()
        Me.TBDate_Fr = New System.Windows.Forms.DateTimePicker()
        Me.gv = New System.Windows.Forms.DataGridView()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_new})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(913, 25)
        Me.ToolStrip.TabIndex = 67
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btn_new
        '
        Me.btn_new.Image = CType(resources.GetObject("btn_new.Image"), System.Drawing.Image)
        Me.btn_new.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btn_new.Size = New System.Drawing.Size(56, 22)
        Me.btn_new.Text = "New"
        Me.btn_new.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Controls.Add(Me.cb_PH)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TBDate_To)
        Me.GroupBox1.Controls.Add(Me.TBDate_Fr)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(913, 112)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian Data"
        '
        'btn_cari
        '
        Me.btn_cari.Location = New System.Drawing.Point(725, 19)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(121, 44)
        Me.btn_cari.TabIndex = 30
        Me.btn_cari.Text = "Cari"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'cb_PH
        '
        Me.cb_PH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_PH.FormattingEnabled = True
        Me.cb_PH.Location = New System.Drawing.Point(160, 42)
        Me.cb_PH.Name = "cb_PH"
        Me.cb_PH.Size = New System.Drawing.Size(121, 21)
        Me.cb_PH.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Nomor Giro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "sampai"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Tanggal Jatuh Tempo"
        '
        'TBDate_To
        '
        Me.TBDate_To.CustomFormat = "dd-MM-yyyy"
        Me.TBDate_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TBDate_To.Location = New System.Drawing.Point(315, 19)
        Me.TBDate_To.Name = "TBDate_To"
        Me.TBDate_To.Size = New System.Drawing.Size(95, 20)
        Me.TBDate_To.TabIndex = 24
        '
        'TBDate_Fr
        '
        Me.TBDate_Fr.CustomFormat = "dd-MM-yyyy"
        Me.TBDate_Fr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TBDate_Fr.Location = New System.Drawing.Point(160, 19)
        Me.TBDate_Fr.Name = "TBDate_Fr"
        Me.TBDate_Fr.Size = New System.Drawing.Size(95, 20)
        Me.TBDate_Fr.TabIndex = 23
        '
        'gv
        '
        Me.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv.Location = New System.Drawing.Point(0, 137)
        Me.gv.Name = "gv"
        Me.gv.ReadOnly = True
        Me.gv.Size = New System.Drawing.Size(913, 317)
        Me.gv.TabIndex = 69
        '
        'frmPencairanGiroPiutangView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 466)
        Me.Controls.Add(Me.gv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Name = "frmPencairanGiroPiutangView"
        Me.Text = "frmPencairanGiroPiutangView"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_new As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents cb_PH As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBDate_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents TBDate_Fr As System.Windows.Forms.DateTimePicker
    Friend WithEvents gv As System.Windows.Forms.DataGridView
End Class
