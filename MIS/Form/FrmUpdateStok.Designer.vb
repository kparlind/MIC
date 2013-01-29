<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdateStok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpdateStok))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_TransNo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_Gudang = New System.Windows.Forms.TextBox
        Me.Txt_Satuan = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_StokRevisi = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_StokNow = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Cb_Tahun = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cb_Bulan = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_NmBrg = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_KdBrg = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ts_UpdateStok = New System.Windows.Forms.ToolStrip
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.ts_UpdateStok.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_TransNo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Txt_Gudang)
        Me.GroupBox1.Controls.Add(Me.Txt_Satuan)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_StokRevisi)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_StokNow)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cb_Tahun)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Cb_Bulan)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_NmBrg)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_KdBrg)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 210)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txt_TransNo
        '
        Me.txt_TransNo.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_TransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_TransNo.Enabled = False
        Me.txt_TransNo.Location = New System.Drawing.Point(90, 14)
        Me.txt_TransNo.Name = "txt_TransNo"
        Me.txt_TransNo.Size = New System.Drawing.Size(77, 20)
        Me.txt_TransNo.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Trans No"
        '
        'Txt_Gudang
        '
        Me.Txt_Gudang.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Txt_Gudang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Gudang.Enabled = False
        Me.Txt_Gudang.Location = New System.Drawing.Point(90, 101)
        Me.Txt_Gudang.Name = "Txt_Gudang"
        Me.Txt_Gudang.Size = New System.Drawing.Size(193, 20)
        Me.Txt_Gudang.TabIndex = 15
        '
        'Txt_Satuan
        '
        Me.Txt_Satuan.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Txt_Satuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Satuan.Enabled = False
        Me.Txt_Satuan.Location = New System.Drawing.Point(90, 79)
        Me.Txt_Satuan.Name = "Txt_Satuan"
        Me.Txt_Satuan.Size = New System.Drawing.Size(56, 20)
        Me.Txt_Satuan.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Gudang"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Satuan"
        '
        'txt_StokRevisi
        '
        Me.txt_StokRevisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_StokRevisi.Location = New System.Drawing.Point(284, 162)
        Me.txt_StokRevisi.Name = "txt_StokRevisi"
        Me.txt_StokRevisi.Size = New System.Drawing.Size(100, 20)
        Me.txt_StokRevisi.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Revisi Stok"
        '
        'txt_StokNow
        '
        Me.txt_StokNow.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_StokNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_StokNow.Enabled = False
        Me.txt_StokNow.Location = New System.Drawing.Point(90, 162)
        Me.txt_StokNow.Name = "txt_StokNow"
        Me.txt_StokNow.Size = New System.Drawing.Size(100, 20)
        Me.txt_StokNow.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Stok Saat ini"
        '
        'Cb_Tahun
        '
        Me.Cb_Tahun.FormattingEnabled = True
        Me.Cb_Tahun.Location = New System.Drawing.Point(215, 124)
        Me.Cb_Tahun.Name = "Cb_Tahun"
        Me.Cb_Tahun.Size = New System.Drawing.Size(68, 21)
        Me.Cb_Tahun.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tahun"
        '
        'Cb_Bulan
        '
        Me.Cb_Bulan.FormattingEnabled = True
        Me.Cb_Bulan.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Cb_Bulan.Location = New System.Drawing.Point(90, 123)
        Me.Cb_Bulan.Name = "Cb_Bulan"
        Me.Cb_Bulan.Size = New System.Drawing.Size(56, 21)
        Me.Cb_Bulan.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bulan"
        '
        'txt_NmBrg
        '
        Me.txt_NmBrg.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_NmBrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_NmBrg.Enabled = False
        Me.txt_NmBrg.Location = New System.Drawing.Point(90, 58)
        Me.txt_NmBrg.Name = "txt_NmBrg"
        Me.txt_NmBrg.Size = New System.Drawing.Size(294, 20)
        Me.txt_NmBrg.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Barang"
        '
        'txt_KdBrg
        '
        Me.txt_KdBrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_KdBrg.Location = New System.Drawing.Point(90, 35)
        Me.txt_KdBrg.Name = "txt_KdBrg"
        Me.txt_KdBrg.Size = New System.Drawing.Size(100, 20)
        Me.txt_KdBrg.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Barang"
        '
        'ts_UpdateStok
        '
        Me.ts_UpdateStok.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save})
        Me.ts_UpdateStok.Location = New System.Drawing.Point(0, 0)
        Me.ts_UpdateStok.Name = "ts_UpdateStok"
        Me.ts_UpdateStok.Size = New System.Drawing.Size(430, 25)
        Me.ts_UpdateStok.TabIndex = 1
        Me.ts_UpdateStok.Text = "Update Stok"
        '
        'ts_save
        '
        Me.ts_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(23, 22)
        Me.ts_save.Text = "Save"
        '
        'FrmUpdateStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 250)
        Me.Controls.Add(Me.ts_UpdateStok)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUpdateStok"
        Me.Text = "Update Stok"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ts_UpdateStok.ResumeLayout(False)
        Me.ts_UpdateStok.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_NmBrg As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_KdBrg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_StokRevisi As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_StokNow As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cb_Tahun As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Cb_Bulan As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ts_UpdateStok As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Gudang As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Satuan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
