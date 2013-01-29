<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDlgReportPO
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
        Me.dtpPODateTo = New System.Windows.Forms.DateTimePicker
        Me.dtpPODateFrom = New System.Windows.Forms.DateTimePicker
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.lbl_PODate = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.lbl_TBDate = New System.Windows.Forms.Label
        Me.txtPONoFr = New System.Windows.Forms.TextBox
        Me.txtItemIDFr = New System.Windows.Forms.TextBox
        Me.txtWarehouseIDFr = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPONoTo = New System.Windows.Forms.TextBox
        Me.txtItemIDTo = New System.Windows.Forms.TextBox
        Me.txtWarehouseIDTo = New System.Windows.Forms.TextBox
        Me.txt_TBNoTo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_TBNoFr = New System.Windows.Forms.TextBox
        Me.txt_SuppIDTo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_SuppIDFr = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'dtpPODateTo
        '
        Me.dtpPODateTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPODateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPODateTo.Location = New System.Drawing.Point(279, 29)
        Me.dtpPODateTo.Name = "dtpPODateTo"
        Me.dtpPODateTo.Size = New System.Drawing.Size(134, 22)
        Me.dtpPODateTo.TabIndex = 27
        '
        'dtpPODateFrom
        '
        Me.dtpPODateFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtpPODateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPODateFrom.Location = New System.Drawing.Point(118, 29)
        Me.dtpPODateFrom.Name = "dtpPODateFrom"
        Me.dtpPODateFrom.Size = New System.Drawing.Size(127, 22)
        Me.dtpPODateFrom.TabIndex = 26
        '
        'btnViewReport
        '
        Me.btnViewReport.Location = New System.Drawing.Point(279, 235)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(127, 23)
        Me.btnViewReport.TabIndex = 25
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'lbl_PODate
        '
        Me.lbl_PODate.AutoSize = True
        Me.lbl_PODate.Location = New System.Drawing.Point(30, 34)
        Me.lbl_PODate.Name = "lbl_PODate"
        Me.lbl_PODate.Size = New System.Drawing.Size(53, 14)
        Me.lbl_PODate.TabIndex = 24
        Me.lbl_PODate.Text = "PO Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 14)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "To"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(279, 57)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(134, 22)
        Me.DateTimePicker1.TabIndex = 31
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(118, 57)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(127, 22)
        Me.DateTimePicker2.TabIndex = 30
        '
        'lbl_TBDate
        '
        Me.lbl_TBDate.AutoSize = True
        Me.lbl_TBDate.Location = New System.Drawing.Point(30, 62)
        Me.lbl_TBDate.Name = "lbl_TBDate"
        Me.lbl_TBDate.Size = New System.Drawing.Size(52, 14)
        Me.lbl_TBDate.TabIndex = 29
        Me.lbl_TBDate.Text = "GR Date"
        '
        'txtPONoFr
        '
        Me.txtPONoFr.Location = New System.Drawing.Point(118, 85)
        Me.txtPONoFr.Name = "txtPONoFr"
        Me.txtPONoFr.Size = New System.Drawing.Size(127, 22)
        Me.txtPONoFr.TabIndex = 33
        '
        'txtItemIDFr
        '
        Me.txtItemIDFr.Location = New System.Drawing.Point(118, 113)
        Me.txtItemIDFr.Name = "txtItemIDFr"
        Me.txtItemIDFr.Size = New System.Drawing.Size(127, 22)
        Me.txtItemIDFr.TabIndex = 34
        '
        'txtWarehouseIDFr
        '
        Me.txtWarehouseIDFr.Location = New System.Drawing.Point(118, 141)
        Me.txtWarehouseIDFr.Name = "txtWarehouseIDFr"
        Me.txtWarehouseIDFr.Size = New System.Drawing.Size(127, 22)
        Me.txtWarehouseIDFr.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "PO No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Item ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 14)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Warehouse ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(251, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 14)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "To"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(251, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 14)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 14)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "To"
        '
        'txtPONoTo
        '
        Me.txtPONoTo.Location = New System.Drawing.Point(279, 85)
        Me.txtPONoTo.Name = "txtPONoTo"
        Me.txtPONoTo.Size = New System.Drawing.Size(127, 22)
        Me.txtPONoTo.TabIndex = 42
        '
        'txtItemIDTo
        '
        Me.txtItemIDTo.Location = New System.Drawing.Point(279, 113)
        Me.txtItemIDTo.Name = "txtItemIDTo"
        Me.txtItemIDTo.Size = New System.Drawing.Size(127, 22)
        Me.txtItemIDTo.TabIndex = 43
        '
        'txtWarehouseIDTo
        '
        Me.txtWarehouseIDTo.Location = New System.Drawing.Point(279, 141)
        Me.txtWarehouseIDTo.Name = "txtWarehouseIDTo"
        Me.txtWarehouseIDTo.Size = New System.Drawing.Size(127, 22)
        Me.txtWarehouseIDTo.TabIndex = 44
        '
        'txt_TBNoTo
        '
        Me.txt_TBNoTo.Location = New System.Drawing.Point(279, 169)
        Me.txt_TBNoTo.Name = "txt_TBNoTo"
        Me.txt_TBNoTo.Size = New System.Drawing.Size(127, 22)
        Me.txt_TBNoTo.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(251, 172)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 14)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(30, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 14)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "TB No."
        '
        'txt_TBNoFr
        '
        Me.txt_TBNoFr.Location = New System.Drawing.Point(118, 169)
        Me.txt_TBNoFr.Name = "txt_TBNoFr"
        Me.txt_TBNoFr.Size = New System.Drawing.Size(127, 22)
        Me.txt_TBNoFr.TabIndex = 45
        '
        'txt_SuppIDTo
        '
        Me.txt_SuppIDTo.Location = New System.Drawing.Point(279, 197)
        Me.txt_SuppIDTo.Name = "txt_SuppIDTo"
        Me.txt_SuppIDTo.Size = New System.Drawing.Size(127, 22)
        Me.txt_SuppIDTo.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(251, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 14)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "To"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 14)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Supplier ID"
        '
        'txt_SuppIDFr
        '
        Me.txt_SuppIDFr.Location = New System.Drawing.Point(118, 197)
        Me.txt_SuppIDFr.Name = "txt_SuppIDFr"
        Me.txt_SuppIDFr.Size = New System.Drawing.Size(127, 22)
        Me.txt_SuppIDFr.TabIndex = 49
        '
        'frmDlgReportPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 279)
        Me.Controls.Add(Me.txt_SuppIDTo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_SuppIDFr)
        Me.Controls.Add(Me.txt_TBNoTo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_TBNoFr)
        Me.Controls.Add(Me.txtWarehouseIDTo)
        Me.Controls.Add(Me.txtItemIDTo)
        Me.Controls.Add(Me.txtPONoTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtWarehouseIDFr)
        Me.Controls.Add(Me.txtItemIDFr)
        Me.Controls.Add(Me.txtPONoFr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.lbl_TBDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpPODateTo)
        Me.Controls.Add(Me.dtpPODateFrom)
        Me.Controls.Add(Me.btnViewReport)
        Me.Controls.Add(Me.lbl_PODate)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDlgReportPO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report PO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpPODateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPODateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents lbl_PODate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_TBDate As System.Windows.Forms.Label
    Friend WithEvents txtPONoFr As System.Windows.Forms.TextBox
    Friend WithEvents txtItemIDFr As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouseIDFr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPONoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtItemIDTo As System.Windows.Forms.TextBox
    Friend WithEvents txtWarehouseIDTo As System.Windows.Forms.TextBox
    Friend WithEvents txt_TBNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_TBNoFr As System.Windows.Forms.TextBox
    Friend WithEvents txt_SuppIDTo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_SuppIDFr As System.Windows.Forms.TextBox
End Class
