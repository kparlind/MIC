<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDlgStock
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_date = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_warehouse = New System.Windows.Forms.ComboBox
        Me.btn_view = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'dtp_date
        '
        Me.dtp_date.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_date.Location = New System.Drawing.Point(134, 39)
        Me.dtp_date.Name = "dtp_date"
        Me.dtp_date.Size = New System.Drawing.Size(184, 22)
        Me.dtp_date.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Warehouse"
        '
        'cb_warehouse
        '
        Me.cb_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_warehouse.FormattingEnabled = True
        Me.cb_warehouse.Location = New System.Drawing.Point(134, 67)
        Me.cb_warehouse.Name = "cb_warehouse"
        Me.cb_warehouse.Size = New System.Drawing.Size(184, 22)
        Me.cb_warehouse.TabIndex = 2
        '
        'btn_view
        '
        Me.btn_view.Location = New System.Drawing.Point(205, 95)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(113, 23)
        Me.btn_view.TabIndex = 0
        Me.btn_view.Text = "View Report"
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'frmDlgStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 162)
        Me.Controls.Add(Me.btn_view)
        Me.Controls.Add(Me.cb_warehouse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtp_date)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDlgStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Persediaan Barang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_warehouse As System.Windows.Forms.ComboBox
    Friend WithEvents btn_view As System.Windows.Forms.Button
End Class
