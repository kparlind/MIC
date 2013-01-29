<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDlgReportPenjualan
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
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtp_DateTo = New System.Windows.Forms.DateTimePicker
        Me.dtp_DateFrom = New System.Windows.Forms.DateTimePicker
        Me.lbl_Date = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cb_TipePenjualan = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_TipeFaktur = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cb_TipeWaktu = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cb_TipeAnalisa = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cb_IncludeRetur = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'btnViewReport
        '
        Me.btnViewReport.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Location = New System.Drawing.Point(313, 174)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(148, 25)
        Me.btnViewReport.TabIndex = 26
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(295, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 14)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "To"
        '
        'dtp_DateTo
        '
        Me.dtp_DateTo.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_DateTo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_DateTo.Location = New System.Drawing.Point(323, 101)
        Me.dtp_DateTo.Name = "dtp_DateTo"
        Me.dtp_DateTo.Size = New System.Drawing.Size(138, 22)
        Me.dtp_DateTo.TabIndex = 31
        '
        'dtp_DateFrom
        '
        Me.dtp_DateFrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtp_DateFrom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_DateFrom.Location = New System.Drawing.Point(142, 101)
        Me.dtp_DateFrom.Name = "dtp_DateFrom"
        Me.dtp_DateFrom.Size = New System.Drawing.Size(147, 22)
        Me.dtp_DateFrom.TabIndex = 30
        '
        'lbl_Date
        '
        Me.lbl_Date.AutoSize = True
        Me.lbl_Date.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Date.Location = New System.Drawing.Point(26, 105)
        Me.lbl_Date.Name = "lbl_Date"
        Me.lbl_Date.Size = New System.Drawing.Size(50, 14)
        Me.lbl_Date.TabIndex = 29
        Me.lbl_Date.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Tipe Penjualan"
        '
        'cb_TipePenjualan
        '
        Me.cb_TipePenjualan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipePenjualan.FormattingEnabled = True
        Me.cb_TipePenjualan.Items.AddRange(New Object() {"Toko", "Instalasi"})
        Me.cb_TipePenjualan.Location = New System.Drawing.Point(142, 17)
        Me.cb_TipePenjualan.Name = "cb_TipePenjualan"
        Me.cb_TipePenjualan.Size = New System.Drawing.Size(147, 22)
        Me.cb_TipePenjualan.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Tipe Faktur"
        '
        'cb_TipeFaktur
        '
        Me.cb_TipeFaktur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipeFaktur.FormattingEnabled = True
        Me.cb_TipeFaktur.Items.AddRange(New Object() {"ALL", "Uang Muka", "Retention", "Cicilan Instalasi"})
        Me.cb_TipeFaktur.Location = New System.Drawing.Point(142, 45)
        Me.cb_TipeFaktur.Name = "cb_TipeFaktur"
        Me.cb_TipeFaktur.Size = New System.Drawing.Size(147, 22)
        Me.cb_TipeFaktur.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Tipe Waktu"
        '
        'cb_TipeWaktu
        '
        Me.cb_TipeWaktu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipeWaktu.FormattingEnabled = True
        Me.cb_TipeWaktu.Items.AddRange(New Object() {"Harian", "Bulanan"})
        Me.cb_TipeWaktu.Location = New System.Drawing.Point(142, 73)
        Me.cb_TipeWaktu.Name = "cb_TipeWaktu"
        Me.cb_TipeWaktu.Size = New System.Drawing.Size(147, 22)
        Me.cb_TipeWaktu.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Analisa Per"
        '
        'cb_TipeAnalisa
        '
        Me.cb_TipeAnalisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_TipeAnalisa.FormattingEnabled = True
        Me.cb_TipeAnalisa.Items.AddRange(New Object() {"Barang", "Customer"})
        Me.cb_TipeAnalisa.Location = New System.Drawing.Point(142, 129)
        Me.cb_TipeAnalisa.Name = "cb_TipeAnalisa"
        Me.cb_TipeAnalisa.Size = New System.Drawing.Size(147, 22)
        Me.cb_TipeAnalisa.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 14)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Include Retur"
        '
        'cb_IncludeRetur
        '
        Me.cb_IncludeRetur.AutoSize = True
        Me.cb_IncludeRetur.Location = New System.Drawing.Point(142, 157)
        Me.cb_IncludeRetur.Name = "cb_IncludeRetur"
        Me.cb_IncludeRetur.Size = New System.Drawing.Size(15, 14)
        Me.cb_IncludeRetur.TabIndex = 42
        Me.cb_IncludeRetur.UseVisualStyleBackColor = True
        '
        'frmDlgReportPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 215)
        Me.Controls.Add(Me.cb_IncludeRetur)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cb_TipeAnalisa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb_TipeWaktu)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb_TipeFaktur)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_TipePenjualan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtp_DateTo)
        Me.Controls.Add(Me.dtp_DateFrom)
        Me.Controls.Add(Me.lbl_Date)
        Me.Controls.Add(Me.btnViewReport)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDlgReportPenjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Penjualan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtp_DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Date As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_TipePenjualan As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_TipeFaktur As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_TipeWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_TipeAnalisa As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_IncludeRetur As System.Windows.Forms.CheckBox
End Class
