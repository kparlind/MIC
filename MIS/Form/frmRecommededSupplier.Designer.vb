<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecommededSupplier
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_ItemID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cb_price = New System.Windows.Forms.ComboBox
        Me.cb_ontime = New System.Windows.Forms.ComboBox
        Me.cb_quality = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb_jasa = New System.Windows.Forms.RadioButton
        Me.rb_barang = New System.Windows.Forms.RadioButton
        Me.dgv_data = New System.Windows.Forms.DataGridView
        Me.txtSupplierID = New System.Windows.Forms.TextBox
        Me.txtSupplierName = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item ID / Jasa ID"
        '
        'txt_ItemID
        '
        Me.txt_ItemID.Location = New System.Drawing.Point(145, 19)
        Me.txt_ItemID.Name = "txt_ItemID"
        Me.txt_ItemID.Size = New System.Drawing.Size(80, 22)
        Me.txt_ItemID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Priority"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(128, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Price"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "On Time Delivery"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Quality"
        '
        'cb_price
        '
        Me.cb_price.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_price.FormattingEnabled = True
        Me.cb_price.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cb_price.Location = New System.Drawing.Point(256, 47)
        Me.cb_price.Name = "cb_price"
        Me.cb_price.Size = New System.Drawing.Size(64, 22)
        Me.cb_price.TabIndex = 8
        '
        'cb_ontime
        '
        Me.cb_ontime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ontime.FormattingEnabled = True
        Me.cb_ontime.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cb_ontime.Location = New System.Drawing.Point(256, 72)
        Me.cb_ontime.Name = "cb_ontime"
        Me.cb_ontime.Size = New System.Drawing.Size(64, 22)
        Me.cb_ontime.TabIndex = 9
        '
        'cb_quality
        '
        Me.cb_quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_quality.FormattingEnabled = True
        Me.cb_quality.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cb_quality.Location = New System.Drawing.Point(256, 97)
        Me.cb_quality.Name = "cb_quality"
        Me.cb_quality.Size = New System.Drawing.Size(64, 22)
        Me.cb_quality.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Category"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(128, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 14)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = ":"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_jasa)
        Me.GroupBox1.Controls.Add(Me.rb_barang)
        Me.GroupBox1.Location = New System.Drawing.Point(145, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 38)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'rb_jasa
        '
        Me.rb_jasa.AutoSize = True
        Me.rb_jasa.Location = New System.Drawing.Point(74, 12)
        Me.rb_jasa.Name = "rb_jasa"
        Me.rb_jasa.Size = New System.Drawing.Size(47, 18)
        Me.rb_jasa.TabIndex = 15
        Me.rb_jasa.Text = "Jasa"
        Me.rb_jasa.UseVisualStyleBackColor = True
        '
        'rb_barang
        '
        Me.rb_barang.AutoSize = True
        Me.rb_barang.Checked = True
        Me.rb_barang.Location = New System.Drawing.Point(6, 12)
        Me.rb_barang.Name = "rb_barang"
        Me.rb_barang.Size = New System.Drawing.Size(62, 18)
        Me.rb_barang.TabIndex = 14
        Me.rb_barang.TabStop = True
        Me.rb_barang.Text = "Barang"
        Me.rb_barang.UseVisualStyleBackColor = True
        '
        'dgv_data
        '
        Me.dgv_data.AllowUserToAddRows = False
        Me.dgv_data.AllowUserToDeleteRows = False
        Me.dgv_data.AllowUserToOrderColumns = True
        Me.dgv_data.AllowUserToResizeColumns = False
        Me.dgv_data.AllowUserToResizeRows = False
        Me.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_data.Location = New System.Drawing.Point(25, 166)
        Me.dgv_data.Name = "dgv_data"
        Me.dgv_data.ReadOnly = True
        Me.dgv_data.Size = New System.Drawing.Size(933, 246)
        Me.dgv_data.TabIndex = 14
        '
        'txtSupplierID
        '
        Me.txtSupplierID.Location = New System.Drawing.Point(445, 208)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.Size = New System.Drawing.Size(80, 22)
        Me.txtSupplierID.TabIndex = 15
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Location = New System.Drawing.Point(453, 216)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(80, 22)
        Me.txtSupplierName.TabIndex = 16
        '
        'frmRecommededSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 439)
        Me.Controls.Add(Me.dgv_data)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cb_quality)
        Me.Controls.Add(Me.cb_ontime)
        Me.Controls.Add(Me.cb_price)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_ItemID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSupplierName)
        Me.Controls.Add(Me.txtSupplierID)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecommededSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recommended Supplier"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_price As System.Windows.Forms.ComboBox
    Friend WithEvents cb_ontime As System.Windows.Forms.ComboBox
    Friend WithEvents cb_quality As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_barang As System.Windows.Forms.RadioButton
    Friend WithEvents rb_jasa As System.Windows.Forms.RadioButton
    Friend WithEvents dgv_data As System.Windows.Forms.DataGridView
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
End Class
