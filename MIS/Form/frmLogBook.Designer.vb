<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogBook))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ts_Edit = New System.Windows.Forms.ToolStripButton
        Me.ts_Delete = New System.Windows.Forms.ToolStripButton
        Me.ts_Save = New System.Windows.Forms.ToolStripButton
        Me.ts_Cancel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.btn_search = New System.Windows.Forms.Button
        Me.dgv_data = New System.Windows.Forms.DataGridView
        Me.cbCategory = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCost = New System.Windows.Forms.TextBox
        Me.txtProcessName = New System.Windows.Forms.TextBox
        Me.txtEmployeeName = New System.Windows.Forms.TextBox
        Me.txtProcessID = New System.Windows.Forms.TextBox
        Me.txtEmployeeID = New System.Windows.Forms.TextBox
        Me.txtProjectNo = New System.Windows.Forms.TextBox
        Me.txtSPKNo = New System.Windows.Forms.TextBox
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.txtWorkDetail = New System.Windows.Forms.TextBox
        Me.dtpTimeTo = New System.Windows.Forms.DateTimePicker
        Me.dtpTimeFr = New System.Windows.Forms.DateTimePicker
        Me.dtpLogDate = New System.Windows.Forms.DateTimePicker
        Me.txtLogNo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_Edit, Me.ts_Delete, Me.ts_Save, Me.ts_Cancel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1097, 25)
        Me.ToolStrip.TabIndex = 13
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ts_Edit
        '
        Me.ts_Edit.Image = CType(resources.GetObject("ts_Edit.Image"), System.Drawing.Image)
        Me.ts_Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Edit.Name = "ts_Edit"
        Me.ts_Edit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_Edit.Size = New System.Drawing.Size(52, 22)
        Me.ts_Edit.Text = "Edit"
        '
        'ts_Delete
        '
        Me.ts_Delete.Image = CType(resources.GetObject("ts_Delete.Image"), System.Drawing.Image)
        Me.ts_Delete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Delete.Name = "ts_Delete"
        Me.ts_Delete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_Delete.Size = New System.Drawing.Size(65, 22)
        Me.ts_Delete.Text = "Delete"
        '
        'ts_Save
        '
        Me.ts_Save.Image = CType(resources.GetObject("ts_Save.Image"), System.Drawing.Image)
        Me.ts_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Save.Name = "ts_Save"
        Me.ts_Save.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_Save.Size = New System.Drawing.Size(56, 22)
        Me.ts_Save.Text = "Save"
        '
        'ts_Cancel
        '
        Me.ts_Cancel.Image = CType(resources.GetObject("ts_Cancel.Image"), System.Drawing.Image)
        Me.ts_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Cancel.Name = "ts_Cancel"
        Me.ts_Cancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ts_Cancel.Size = New System.Drawing.Size(68, 22)
        Me.ts_Cancel.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProjectName)
        Me.GroupBox1.Controls.Add(Me.btn_search)
        Me.GroupBox1.Controls.Add(Me.dgv_data)
        Me.GroupBox1.Controls.Add(Me.cbCategory)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtCost)
        Me.GroupBox1.Controls.Add(Me.txtProcessName)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox1.Controls.Add(Me.txtProcessID)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
        Me.GroupBox1.Controls.Add(Me.txtProjectNo)
        Me.GroupBox1.Controls.Add(Me.txtSPKNo)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.txtWorkDetail)
        Me.GroupBox1.Controls.Add(Me.dtpTimeTo)
        Me.GroupBox1.Controls.Add(Me.dtpTimeFr)
        Me.GroupBox1.Controls.Add(Me.dtpLogDate)
        Me.GroupBox1.Controls.Add(Me.txtLogNo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(14, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1071, 480)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Input"
        '
        'txtProjectName
        '
        Me.txtProjectName.BackColor = System.Drawing.Color.LightGray
        Me.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProjectName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectName.ForeColor = System.Drawing.Color.Gray
        Me.txtProjectName.Location = New System.Drawing.Point(308, 115)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectName.Size = New System.Drawing.Size(323, 22)
        Me.txtProjectName.TabIndex = 43
        '
        'btn_search
        '
        Me.btn_search.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_search.ForeColor = System.Drawing.Color.Black
        Me.btn_search.Location = New System.Drawing.Point(990, 14)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_search.TabIndex = 42
        Me.btn_search.Text = "SEARCH"
        Me.btn_search.UseVisualStyleBackColor = True
        Me.btn_search.Visible = False
        '
        'dgv_data
        '
        Me.dgv_data.AllowUserToAddRows = False
        Me.dgv_data.AllowUserToDeleteRows = False
        Me.dgv_data.AllowUserToOrderColumns = True
        Me.dgv_data.AllowUserToResizeColumns = False
        Me.dgv_data.AllowUserToResizeRows = False
        Me.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_data.Location = New System.Drawing.Point(645, 43)
        Me.dgv_data.Name = "dgv_data"
        Me.dgv_data.ReadOnly = True
        Me.dgv_data.Size = New System.Drawing.Size(420, 416)
        Me.dgv_data.TabIndex = 41
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Items.AddRange(New Object() {"", "Instalasi", "Pabrikasi"})
        Me.cbCategory.Location = New System.Drawing.Point(127, 205)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(174, 22)
        Me.cbCategory.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(21, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Category"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(304, 242)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 18)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Cost"
        Me.Label11.Visible = False
        '
        'txtCost
        '
        Me.txtCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCost.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCost.Location = New System.Drawing.Point(351, 237)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.ReadOnly = True
        Me.txtCost.Size = New System.Drawing.Size(279, 27)
        Me.txtCost.TabIndex = 38
        Me.txtCost.Visible = False
        '
        'txtProcessName
        '
        Me.txtProcessName.BackColor = System.Drawing.Color.LightGray
        Me.txtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessName.ForeColor = System.Drawing.Color.Gray
        Me.txtProcessName.Location = New System.Drawing.Point(307, 177)
        Me.txtProcessName.Name = "txtProcessName"
        Me.txtProcessName.ReadOnly = True
        Me.txtProcessName.Size = New System.Drawing.Size(323, 22)
        Me.txtProcessName.TabIndex = 37
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.BackColor = System.Drawing.Color.LightGray
        Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeName.ForeColor = System.Drawing.Color.Gray
        Me.txtEmployeeName.Location = New System.Drawing.Point(307, 148)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(323, 22)
        Me.txtEmployeeName.TabIndex = 36
        '
        'txtProcessID
        '
        Me.txtProcessID.BackColor = System.Drawing.Color.LightGray
        Me.txtProcessID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProcessID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessID.ForeColor = System.Drawing.Color.Gray
        Me.txtProcessID.Location = New System.Drawing.Point(127, 177)
        Me.txtProcessID.Name = "txtProcessID"
        Me.txtProcessID.ReadOnly = True
        Me.txtProcessID.Size = New System.Drawing.Size(174, 22)
        Me.txtProcessID.TabIndex = 35
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.BackColor = System.Drawing.Color.LightGray
        Me.txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeID.ForeColor = System.Drawing.Color.Gray
        Me.txtEmployeeID.Location = New System.Drawing.Point(127, 148)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(174, 22)
        Me.txtEmployeeID.TabIndex = 34
        '
        'txtProjectNo
        '
        Me.txtProjectNo.BackColor = System.Drawing.Color.LightGray
        Me.txtProjectNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProjectNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProjectNo.ForeColor = System.Drawing.Color.Gray
        Me.txtProjectNo.Location = New System.Drawing.Point(127, 115)
        Me.txtProjectNo.Name = "txtProjectNo"
        Me.txtProjectNo.ReadOnly = True
        Me.txtProjectNo.Size = New System.Drawing.Size(175, 22)
        Me.txtProjectNo.TabIndex = 33
        '
        'txtSPKNo
        '
        Me.txtSPKNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSPKNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSPKNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPKNo.Location = New System.Drawing.Point(127, 88)
        Me.txtSPKNo.Name = "txtSPKNo"
        Me.txtSPKNo.Size = New System.Drawing.Size(175, 22)
        Me.txtSPKNo.TabIndex = 32
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(127, 380)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(503, 79)
        Me.txtRemark.TabIndex = 31
        '
        'txtWorkDetail
        '
        Me.txtWorkDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkDetail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkDetail.Location = New System.Drawing.Point(127, 299)
        Me.txtWorkDetail.Multiline = True
        Me.txtWorkDetail.Name = "txtWorkDetail"
        Me.txtWorkDetail.Size = New System.Drawing.Size(503, 74)
        Me.txtWorkDetail.TabIndex = 30
        '
        'dtpTimeTo
        '
        Me.dtpTimeTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTimeTo.CustomFormat = "HH:mm"
        Me.dtpTimeTo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTimeTo.Location = New System.Drawing.Point(127, 269)
        Me.dtpTimeTo.Name = "dtpTimeTo"
        Me.dtpTimeTo.Size = New System.Drawing.Size(84, 22)
        Me.dtpTimeTo.TabIndex = 29
        Me.dtpTimeTo.Value = New Date(2012, 11, 16, 17, 0, 0, 0)
        '
        'dtpTimeFr
        '
        Me.dtpTimeFr.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTimeFr.CustomFormat = "HH:mm"
        Me.dtpTimeFr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTimeFr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTimeFr.Location = New System.Drawing.Point(127, 239)
        Me.dtpTimeFr.Name = "dtpTimeFr"
        Me.dtpTimeFr.Size = New System.Drawing.Size(84, 22)
        Me.dtpTimeFr.TabIndex = 28
        Me.dtpTimeFr.Value = New Date(2012, 11, 16, 8, 0, 0, 0)
        '
        'dtpLogDate
        '
        Me.dtpLogDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpLogDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLogDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLogDate.Location = New System.Drawing.Point(127, 56)
        Me.dtpLogDate.Name = "dtpLogDate"
        Me.dtpLogDate.Size = New System.Drawing.Size(174, 22)
        Me.dtpLogDate.TabIndex = 23
        '
        'txtLogNo
        '
        Me.txtLogNo.BackColor = System.Drawing.Color.LightGray
        Me.txtLogNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogNo.ForeColor = System.Drawing.Color.Gray
        Me.txtLogNo.Location = New System.Drawing.Point(127, 27)
        Me.txtLogNo.Name = "txtLogNo"
        Me.txtLogNo.ReadOnly = True
        Me.txtLogNo.Size = New System.Drawing.Size(175, 22)
        Me.txtLogNo.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(21, 380)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 14)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Remark"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(21, 301)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Work Detail"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(21, 272)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 14)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Time To"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Time From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 14)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Process"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Technician"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(21, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SPK No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(21, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Project No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Log Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Log No."
        '
        'frmLogBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 515)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ":: Log Book ::"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_Edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Delete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_Cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpLogDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLogNo As System.Windows.Forms.TextBox
    Friend WithEvents txtWorkDetail As System.Windows.Forms.TextBox
    Friend WithEvents dtpTimeTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTimeFr As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtSPKNo As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNo As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessID As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCost As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_data As System.Windows.Forms.DataGridView
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
End Class
