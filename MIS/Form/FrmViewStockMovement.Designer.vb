<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewStockMovement
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
        Me.cb_warehouse = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_Item = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dt_from = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_cari = New System.Windows.Forms.Button
        Me.gv_Stock = New System.Windows.Forms.DataGridView
        Me.gb_StockDetail = New System.Windows.Forms.GroupBox
        Me.gv_StockMov = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.gv_Stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_StockDetail.SuspendLayout()
        CType(Me.gv_StockMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_warehouse)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb_Item)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dt_from)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_cari)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(910, 118)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian"
        '
        'cb_warehouse
        '
        Me.cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_warehouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_warehouse.FormattingEnabled = True
        Me.cb_warehouse.Location = New System.Drawing.Point(124, 47)
        Me.cb_warehouse.Name = "cb_warehouse"
        Me.cb_warehouse.Size = New System.Drawing.Size(209, 24)
        Me.cb_warehouse.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Warehouse"
        '
        'cb_Item
        '
        Me.cb_Item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Item.FormattingEnabled = True
        Me.cb_Item.Location = New System.Drawing.Point(124, 75)
        Me.cb_Item.Name = "cb_Item"
        Me.cb_Item.Size = New System.Drawing.Size(209, 24)
        Me.cb_Item.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Item"
        '
        'dt_from
        '
        Me.dt_from.CustomFormat = "MMMM-yyyy"
        Me.dt_from.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_from.Location = New System.Drawing.Point(124, 22)
        Me.dt_from.Name = "dt_from"
        Me.dt_from.Size = New System.Drawing.Size(200, 22)
        Me.dt_from.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Period"
        '
        'btn_cari
        '
        Me.btn_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cari.Location = New System.Drawing.Point(355, 16)
        Me.btn_cari.Name = "btn_cari"
        Me.btn_cari.Size = New System.Drawing.Size(154, 85)
        Me.btn_cari.TabIndex = 0
        Me.btn_cari.Text = "Cari"
        Me.btn_cari.UseVisualStyleBackColor = True
        '
        'gv_Stock
        '
        Me.gv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_Stock.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_Stock.Location = New System.Drawing.Point(0, 118)
        Me.gv_Stock.Name = "gv_Stock"
        Me.gv_Stock.Size = New System.Drawing.Size(910, 177)
        Me.gv_Stock.TabIndex = 3
        '
        'gb_StockDetail
        '
        Me.gb_StockDetail.Controls.Add(Me.gv_StockMov)
        Me.gb_StockDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.gb_StockDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.gb_StockDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_StockDetail.Location = New System.Drawing.Point(0, 295)
        Me.gb_StockDetail.Name = "gb_StockDetail"
        Me.gb_StockDetail.Size = New System.Drawing.Size(910, 362)
        Me.gb_StockDetail.TabIndex = 4
        Me.gb_StockDetail.TabStop = False
        Me.gb_StockDetail.Text = "Stock Movement"
        '
        'gv_StockMov
        '
        Me.gv_StockMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_StockMov.Dock = System.Windows.Forms.DockStyle.Top
        Me.gv_StockMov.Location = New System.Drawing.Point(3, 18)
        Me.gv_StockMov.Name = "gv_StockMov"
        Me.gv_StockMov.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gv_StockMov.Size = New System.Drawing.Size(904, 320)
        Me.gv_StockMov.TabIndex = 0
        '
        'FrmViewStockMovement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 635)
        Me.Controls.Add(Me.gb_StockDetail)
        Me.Controls.Add(Me.gv_Stock)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmViewStockMovement"
        Me.Text = "View Stock Movement"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gv_Stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_StockDetail.ResumeLayout(False)
        CType(Me.gv_StockMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_Item As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dt_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cari As System.Windows.Forms.Button
    Friend WithEvents gv_Stock As System.Windows.Forms.DataGridView
    Friend WithEvents gb_StockDetail As System.Windows.Forms.GroupBox
    Friend WithEvents gv_StockMov As System.Windows.Forms.DataGridView
    Friend WithEvents cb_warehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
