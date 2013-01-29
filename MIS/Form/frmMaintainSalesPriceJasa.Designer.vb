<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintainSalesPriceJasa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintainSalesPriceJasa))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ts_save = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_jasaid = New System.Windows.Forms.TextBox
        Me.dgv_data = New System.Windows.Forms.DataGridView
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1094, 25)
        Me.ToolStrip.TabIndex = 0
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Jasa ID"
        '
        'txt_jasaid
        '
        Me.txt_jasaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_jasaid.Location = New System.Drawing.Point(104, 35)
        Me.txt_jasaid.MaxLength = 5
        Me.txt_jasaid.Name = "txt_jasaid"
        Me.txt_jasaid.Size = New System.Drawing.Size(100, 22)
        Me.txt_jasaid.TabIndex = 2
        '
        'dgv_data
        '
        Me.dgv_data.AllowUserToAddRows = False
        Me.dgv_data.AllowUserToDeleteRows = False
        Me.dgv_data.AllowUserToOrderColumns = True
        Me.dgv_data.AllowUserToResizeColumns = False
        Me.dgv_data.AllowUserToResizeRows = False
        Me.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_data.Location = New System.Drawing.Point(12, 63)
        Me.dgv_data.Name = "dgv_data"
        Me.dgv_data.Size = New System.Drawing.Size(1070, 444)
        Me.dgv_data.TabIndex = 5
        '
        'frmMaintainSalesPriceJasa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 519)
        Me.Controls.Add(Me.dgv_data)
        Me.Controls.Add(Me.txt_jasaid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaintainSalesPriceJasa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Sales Price Jasa"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_jasaid As System.Windows.Forms.TextBox
    Friend WithEvents dgv_data As System.Windows.Forms.DataGridView
End Class
