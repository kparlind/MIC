<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferStockTokoView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferStockTokoView))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btn_new = New System.Windows.Forms.ToolStripButton
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.txt_TransNoTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_TransNoFr = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtp_DateTo = New System.Windows.Forms.DateTimePicker
        Me.dtp_DateFr = New System.Windows.Forms.DateTimePicker
        Me.lbl_Date = New System.Windows.Forms.Label
        Me.btn_search = New System.Windows.Forms.Button
        Me.cb_category = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_new})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1140, 25)
        Me.ToolStrip.TabIndex = 71
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
        '
        'dgView
        '
        Me.dgView.AllowUserToAddRows = False
        Me.dgView.AllowUserToDeleteRows = False
        Me.dgView.AllowUserToOrderColumns = True
        Me.dgView.AllowUserToResizeColumns = False
        Me.dgView.AllowUserToResizeRows = False
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Location = New System.Drawing.Point(12, 122)
        Me.dgView.Name = "dgView"
        Me.dgView.Size = New System.Drawing.Size(1116, 469)
        Me.dgView.TabIndex = 72
        '
        'txt_TransNoTo
        '
        Me.txt_TransNoTo.Location = New System.Drawing.Point(284, 65)
        Me.txt_TransNoTo.Name = "txt_TransNoTo"
        Me.txt_TransNoTo.Size = New System.Drawing.Size(134, 22)
        Me.txt_TransNoTo.TabIndex = 80
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(256, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 14)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 14)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Transaction No."
        '
        'txt_TransNoFr
        '
        Me.txt_TransNoFr.Location = New System.Drawing.Point(123, 65)
        Me.txt_TransNoFr.Name = "txt_TransNoFr"
        Me.txt_TransNoFr.Size = New System.Drawing.Size(127, 22)
        Me.txt_TransNoFr.TabIndex = 77
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(256, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "To"
        '
        'dtp_DateTo
        '
        Me.dtp_DateTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_DateTo.Location = New System.Drawing.Point(284, 37)
        Me.dtp_DateTo.Name = "dtp_DateTo"
        Me.dtp_DateTo.Size = New System.Drawing.Size(134, 22)
        Me.dtp_DateTo.TabIndex = 75
        '
        'dtp_DateFr
        '
        Me.dtp_DateFr.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_DateFr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_DateFr.Location = New System.Drawing.Point(123, 37)
        Me.dtp_DateFr.Name = "dtp_DateFr"
        Me.dtp_DateFr.Size = New System.Drawing.Size(127, 22)
        Me.dtp_DateFr.TabIndex = 74
        '
        'lbl_Date
        '
        Me.lbl_Date.AutoSize = True
        Me.lbl_Date.Location = New System.Drawing.Point(12, 41)
        Me.lbl_Date.Name = "lbl_Date"
        Me.lbl_Date.Size = New System.Drawing.Size(100, 14)
        Me.lbl_Date.TabIndex = 73
        Me.lbl_Date.Text = "Transaction Date"
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(323, 93)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(95, 23)
        Me.btn_search.TabIndex = 81
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'cb_category
        '
        Me.cb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_category.FormattingEnabled = True
        Me.cb_category.Items.AddRange(New Object() {"ALL", "Request From Toko", "Request From Gudang"})
        Me.cb_category.Location = New System.Drawing.Point(123, 93)
        Me.cb_category.Name = "cb_category"
        Me.cb_category.Size = New System.Drawing.Size(194, 22)
        Me.cb_category.TabIndex = 83
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Category"
        '
        'frmTransferStockTokoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 609)
        Me.Controls.Add(Me.cb_category)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.txt_TransNoTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_TransNoFr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_DateTo)
        Me.Controls.Add(Me.dtp_DateFr)
        Me.Controls.Add(Me.lbl_Date)
        Me.Controls.Add(Me.dgView)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferStockTokoView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transfer Stock Toko"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_new As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents txt_TransNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TransNoFr As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_DateFr As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Date As System.Windows.Forms.Label
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents cb_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
