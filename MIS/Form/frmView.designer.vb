<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnFilter = New System.Windows.Forms.ToolStripButton
        Me.btnClose = New System.Windows.Forms.ToolStripButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFilter = New System.Windows.Forms.ComboBox
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.gridDetail = New System.Windows.Forms.DataGridView
        Me.lstWidth = New System.Windows.Forms.ListBox
        Me.txtPKNo = New System.Windows.Forms.TextBox
        Me.txtPKValue = New System.Windows.Forms.TextBox
        Me.ToolStrip.SuspendLayout()
        CType(Me.gridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFilter, Me.btnClose})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(455, 25)
        Me.ToolStrip.TabIndex = 4
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnFilter
        '
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.btnFilter.Size = New System.Drawing.Size(58, 22)
        Me.btnFilter.Text = "Filter"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.btnClose.Size = New System.Drawing.Size(61, 22)
        Me.btnClose.Text = "Close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Trans Period"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd MMM yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(98, 58)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(93, 20)
        Me.dtpFromDate.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(198, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "to"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd MMM yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(220, 58)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(93, 20)
        Me.dtpToDate.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Filter by"
        '
        'cboFilter
        '
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Location = New System.Drawing.Point(98, 33)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(116, 21)
        Me.cboFilter.TabIndex = 10
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(221, 33)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(224, 20)
        Me.txtFilter.TabIndex = 11
        '
        'gridDetail
        '
        Me.gridDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.gridDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDetail.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDetail.Location = New System.Drawing.Point(12, 100)
        Me.gridDetail.Name = "gridDetail"
        Me.gridDetail.Size = New System.Drawing.Size(433, 496)
        Me.gridDetail.TabIndex = 12
        '
        'lstWidth
        '
        Me.lstWidth.FormattingEnabled = True
        Me.lstWidth.Location = New System.Drawing.Point(79, 175)
        Me.lstWidth.Name = "lstWidth"
        Me.lstWidth.Size = New System.Drawing.Size(120, 95)
        Me.lstWidth.TabIndex = 15
        '
        'txtPKNo
        '
        Me.txtPKNo.Location = New System.Drawing.Point(264, 187)
        Me.txtPKNo.Name = "txtPKNo"
        Me.txtPKNo.Size = New System.Drawing.Size(130, 20)
        Me.txtPKNo.TabIndex = 17
        '
        'txtPKValue
        '
        Me.txtPKValue.Location = New System.Drawing.Point(264, 213)
        Me.txtPKValue.Name = "txtPKValue"
        Me.txtPKValue.Size = New System.Drawing.Size(130, 20)
        Me.txtPKValue.TabIndex = 18
        '
        'frmView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.gridDetail)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.cboFilter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.lstWidth)
        Me.Controls.Add(Me.txtPKValue)
        Me.Controls.Add(Me.txtPKNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ":: View List ::"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents gridDetail As System.Windows.Forms.DataGridView
    Friend WithEvents lstWidth As System.Windows.Forms.ListBox
    Friend WithEvents txtPKNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPKValue As System.Windows.Forms.TextBox
End Class
