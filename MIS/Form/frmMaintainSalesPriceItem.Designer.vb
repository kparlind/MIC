<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintainSalesPriceItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintainSalesPriceItem))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_pricetype = New System.Windows.Forms.ComboBox
        Me.txt_markup = New System.Windows.Forms.TextBox
        Me.dgv_data = New System.Windows.Forms.DataGridView
        Me.btn_refresh = New System.Windows.Forms.Button
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.cb_warehouse = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Price Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Markup (%)"
        '
        'cb_pricetype
        '
        Me.cb_pricetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_pricetype.FormattingEnabled = True
        Me.cb_pricetype.Items.AddRange(New Object() {"Instalasi", "Kontraktor", "Teknisi", "End User"})
        Me.cb_pricetype.Location = New System.Drawing.Point(312, 32)
        Me.cb_pricetype.Name = "cb_pricetype"
        Me.cb_pricetype.Size = New System.Drawing.Size(121, 22)
        Me.cb_pricetype.TabIndex = 2
        '
        'txt_markup
        '
        Me.txt_markup.Location = New System.Drawing.Point(95, 61)
        Me.txt_markup.MaxLength = 3
        Me.txt_markup.Name = "txt_markup"
        Me.txt_markup.Size = New System.Drawing.Size(121, 22)
        Me.txt_markup.TabIndex = 3
        '
        'dgv_data
        '
        Me.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_data.Location = New System.Drawing.Point(10, 89)
        Me.dgv_data.Name = "dgv_data"
        Me.dgv_data.Size = New System.Drawing.Size(700, 380)
        Me.dgv_data.TabIndex = 4
        '
        'btn_refresh
        '
        Me.btn_refresh.Location = New System.Drawing.Point(222, 60)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(75, 23)
        Me.btn_refresh.TabIndex = 5
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(724, 25)
        Me.ToolStrip.TabIndex = 17
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_save.Size = New System.Drawing.Size(56, 22)
        Me.ts_save.Text = "Save"
        '
        'cb_warehouse
        '
        Me.cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_warehouse.FormattingEnabled = True
        Me.cb_warehouse.Items.AddRange(New Object() {"Instalasi", "Kontraktor", "Teknisi", "End User"})
        Me.cb_warehouse.Location = New System.Drawing.Point(95, 32)
        Me.cb_warehouse.Name = "cb_warehouse"
        Me.cb_warehouse.Size = New System.Drawing.Size(121, 22)
        Me.cb_warehouse.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Warehouse"
        '
        'frmMaintainSalesPriceItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 482)
        Me.Controls.Add(Me.cb_warehouse)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.dgv_data)
        Me.Controls.Add(Me.txt_markup)
        Me.Controls.Add(Me.cb_pricetype)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaintainSalesPriceItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Sales Price Item"
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_pricetype As System.Windows.Forms.ComboBox
    Friend WithEvents txt_markup As System.Windows.Forms.TextBox
    Friend WithEvents dgv_data As System.Windows.Forms.DataGridView
    Friend WithEvents btn_refresh As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents cb_warehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
