<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gridFind = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.cboFind1 = New System.Windows.Forms.ComboBox
        Me.txtFind1 = New System.Windows.Forms.TextBox
        Me.cboFind2 = New System.Windows.Forms.ComboBox
        Me.txtFind2 = New System.Windows.Forms.TextBox
        Me.cboFind3 = New System.Windows.Forms.ComboBox
        Me.txtFind3 = New System.Windows.Forms.TextBox
        Me.cboFind4 = New System.Windows.Forms.ComboBox
        Me.txtFind4 = New System.Windows.Forms.TextBox
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtResult1 = New System.Windows.Forms.TextBox
        Me.txtResult2 = New System.Windows.Forms.TextBox
        Me.txtResult3 = New System.Windows.Forms.TextBox
        Me.txtResult4 = New System.Windows.Forms.TextBox
        Me.txtResult5 = New System.Windows.Forms.TextBox
        Me.lstWidth = New System.Windows.Forms.ListBox
        Me.txtresult6 = New System.Windows.Forms.TextBox
        CType(Me.gridFind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridFind
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.gridFind.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridFind.BackgroundColor = System.Drawing.Color.LightGray
        Me.gridFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridFind.Location = New System.Drawing.Point(12, 12)
        Me.gridFind.Margin = New System.Windows.Forms.Padding(0)
        Me.gridFind.Name = "gridFind"
        Me.gridFind.Size = New System.Drawing.Size(340, 347)
        Me.gridFind.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.cboFind1)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFind1)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboFind2)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFind2)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboFind3)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFind3)
        Me.FlowLayoutPanel1.Controls.Add(Me.cboFind4)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtFind4)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSelect)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnCancel)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnFind)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 365)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(351, 143)
        Me.FlowLayoutPanel1.TabIndex = 16
        '
        'cboFind1
        '
        Me.cboFind1.FormattingEnabled = True
        Me.cboFind1.Location = New System.Drawing.Point(3, 3)
        Me.cboFind1.Name = "cboFind1"
        Me.cboFind1.Size = New System.Drawing.Size(157, 21)
        Me.cboFind1.TabIndex = 11
        '
        'txtFind1
        '
        Me.txtFind1.Location = New System.Drawing.Point(166, 3)
        Me.txtFind1.Name = "txtFind1"
        Me.txtFind1.Size = New System.Drawing.Size(175, 20)
        Me.txtFind1.TabIndex = 10
        '
        'cboFind2
        '
        Me.cboFind2.FormattingEnabled = True
        Me.cboFind2.Location = New System.Drawing.Point(3, 30)
        Me.cboFind2.Name = "cboFind2"
        Me.cboFind2.Size = New System.Drawing.Size(157, 21)
        Me.cboFind2.TabIndex = 21
        '
        'txtFind2
        '
        Me.txtFind2.Location = New System.Drawing.Point(166, 30)
        Me.txtFind2.Name = "txtFind2"
        Me.txtFind2.Size = New System.Drawing.Size(175, 20)
        Me.txtFind2.TabIndex = 20
        '
        'cboFind3
        '
        Me.cboFind3.FormattingEnabled = True
        Me.cboFind3.Location = New System.Drawing.Point(3, 57)
        Me.cboFind3.Name = "cboFind3"
        Me.cboFind3.Size = New System.Drawing.Size(157, 21)
        Me.cboFind3.TabIndex = 19
        '
        'txtFind3
        '
        Me.txtFind3.Location = New System.Drawing.Point(166, 57)
        Me.txtFind3.Name = "txtFind3"
        Me.txtFind3.Size = New System.Drawing.Size(175, 20)
        Me.txtFind3.TabIndex = 18
        '
        'cboFind4
        '
        Me.cboFind4.FormattingEnabled = True
        Me.cboFind4.Location = New System.Drawing.Point(3, 84)
        Me.cboFind4.Name = "cboFind4"
        Me.cboFind4.Size = New System.Drawing.Size(157, 21)
        Me.cboFind4.TabIndex = 17
        '
        'txtFind4
        '
        Me.txtFind4.Location = New System.Drawing.Point(166, 84)
        Me.txtFind4.Name = "txtFind4"
        Me.txtFind4.Size = New System.Drawing.Size(175, 20)
        Me.txtFind4.TabIndex = 16
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(3, 111)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 23)
        Me.btnSelect.TabIndex = 23
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(116, 111)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(118, 23)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Back"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(240, 111)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(101, 23)
        Me.btnFind.TabIndex = 22
        Me.btnFind.Text = "Filter"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtResult1
        '
        Me.txtResult1.Location = New System.Drawing.Point(396, 23)
        Me.txtResult1.Name = "txtResult1"
        Me.txtResult1.Size = New System.Drawing.Size(100, 20)
        Me.txtResult1.TabIndex = 17
        Me.txtResult1.Visible = False
        '
        'txtResult2
        '
        Me.txtResult2.Location = New System.Drawing.Point(396, 49)
        Me.txtResult2.Name = "txtResult2"
        Me.txtResult2.Size = New System.Drawing.Size(100, 20)
        Me.txtResult2.TabIndex = 18
        Me.txtResult2.Visible = False
        '
        'txtResult3
        '
        Me.txtResult3.Location = New System.Drawing.Point(396, 75)
        Me.txtResult3.Name = "txtResult3"
        Me.txtResult3.Size = New System.Drawing.Size(100, 20)
        Me.txtResult3.TabIndex = 19
        Me.txtResult3.Visible = False
        '
        'txtResult4
        '
        Me.txtResult4.Location = New System.Drawing.Point(396, 101)
        Me.txtResult4.Name = "txtResult4"
        Me.txtResult4.Size = New System.Drawing.Size(100, 20)
        Me.txtResult4.TabIndex = 20
        Me.txtResult4.Visible = False
        '
        'txtResult5
        '
        Me.txtResult5.Location = New System.Drawing.Point(396, 127)
        Me.txtResult5.Name = "txtResult5"
        Me.txtResult5.Size = New System.Drawing.Size(100, 20)
        Me.txtResult5.TabIndex = 21
        Me.txtResult5.Visible = False
        '
        'lstWidth
        '
        Me.lstWidth.FormattingEnabled = True
        Me.lstWidth.Location = New System.Drawing.Point(212, 241)
        Me.lstWidth.Name = "lstWidth"
        Me.lstWidth.Size = New System.Drawing.Size(120, 95)
        Me.lstWidth.TabIndex = 22
        '
        'txtresult6
        '
        Me.txtresult6.Location = New System.Drawing.Point(396, 153)
        Me.txtresult6.Name = "txtresult6"
        Me.txtresult6.Size = New System.Drawing.Size(100, 20)
        Me.txtresult6.TabIndex = 23
        Me.txtresult6.Visible = False
        '
        'frmSearch
        '
        Me.AcceptButton = Me.btnSelect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(676, 507)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtresult6)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.gridFind)
        Me.Controls.Add(Me.txtResult1)
        Me.Controls.Add(Me.txtResult2)
        Me.Controls.Add(Me.txtResult3)
        Me.Controls.Add(Me.txtResult4)
        Me.Controls.Add(Me.txtResult5)
        Me.Controls.Add(Me.lstWidth)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSearch"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Find Data ::"
        CType(Me.gridFind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridFind As System.Windows.Forms.DataGridView
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboFind1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFind1 As System.Windows.Forms.TextBox
    Friend WithEvents cboFind2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFind2 As System.Windows.Forms.TextBox
    Friend WithEvents cboFind3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFind3 As System.Windows.Forms.TextBox
    Friend WithEvents cboFind4 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFind4 As System.Windows.Forms.TextBox
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtResult1 As System.Windows.Forms.TextBox
    Friend WithEvents txtResult2 As System.Windows.Forms.TextBox
    Friend WithEvents txtResult3 As System.Windows.Forms.TextBox
    Friend WithEvents txtResult4 As System.Windows.Forms.TextBox
    Friend WithEvents txtResult5 As System.Windows.Forms.TextBox
    Friend WithEvents lstWidth As System.Windows.Forms.ListBox
    Friend WithEvents txtresult6 As System.Windows.Forms.TextBox
End Class
