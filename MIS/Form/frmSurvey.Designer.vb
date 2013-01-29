<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurvey
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurvey))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtMarketingName = New System.Windows.Forms.TextBox
        Me.txtMarketingID = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtPIC_HP = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPICName = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMeetWith = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSPK = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpOnSite = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCustHP = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSurveyorName = New System.Windows.Forms.TextBox
        Me.txtSurveyorID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCustName = New System.Windows.Forms.TextBox
        Me.txtCust = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpSurveyDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSurveyNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_status = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtItemComponent = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtType = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.Btn_cancel = New System.Windows.Forms.Button
        Me.btn_delete = New System.Windows.Forms.Button
        Me.btn_save = New System.Windows.Forms.Button
        Me.btn_edit = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRemarkD = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtUOM = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtItemID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btn_insert = New System.Windows.Forms.Button
        Me.gvDetail = New System.Windows.Forms.DataGridView
        Me.Item_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_UoM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Remark = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Category = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Component = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Item_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.txtSeqNum = New System.Windows.Forms.TextBox
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.sep_Approver = New System.Windows.Forms.ToolStripSeparator
        Me.btnApprove = New System.Windows.Forms.ToolStripButton
        Me.btnReject = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnFind = New System.Windows.Forms.ToolStripButton
        Me.btnList = New System.Windows.Forms.ToolStripButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnManifold = New System.Windows.Forms.Button
        Me.btnPipeToKitchen = New System.Windows.Forms.Button
        Me.btnTitikApi = New System.Windows.Forms.Button
        Me.btnSupporting = New System.Windows.Forms.Button
        Me.chkPipe = New System.Windows.Forms.CheckBox
        Me.chkManifold = New System.Windows.Forms.CheckBox
        Me.chkTitik = New System.Windows.Forms.CheckBox
        Me.chkSupporting = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtMarketingName)
        Me.Panel1.Controls.Add(Me.txtMarketingID)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txtPIC_HP)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtPICName)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtMeetWith)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtSPK)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.dtpOnSite)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtCustHP)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtSurveyorName)
        Me.Panel1.Controls.Add(Me.txtSurveyorID)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtCustName)
        Me.Panel1.Controls.Add(Me.txtCust)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpSurveyDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtSurveyNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 174)
        Me.Panel1.TabIndex = 4
        '
        'txtMarketingName
        '
        Me.txtMarketingName.BackColor = System.Drawing.Color.LightGray
        Me.txtMarketingName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketingName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketingName.Location = New System.Drawing.Point(161, 87)
        Me.txtMarketingName.Name = "txtMarketingName"
        Me.txtMarketingName.ReadOnly = True
        Me.txtMarketingName.Size = New System.Drawing.Size(200, 22)
        Me.txtMarketingName.TabIndex = 56
        '
        'txtMarketingID
        '
        Me.txtMarketingID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarketingID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketingID.Location = New System.Drawing.Point(83, 87)
        Me.txtMarketingID.Name = "txtMarketingID"
        Me.txtMarketingID.Size = New System.Drawing.Size(72, 22)
        Me.txtMarketingID.TabIndex = 54
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 89)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 14)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Marketing"
        '
        'txtPIC_HP
        '
        Me.txtPIC_HP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPIC_HP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIC_HP.Location = New System.Drawing.Point(674, 117)
        Me.txtPIC_HP.Name = "txtPIC_HP"
        Me.txtPIC_HP.Size = New System.Drawing.Size(110, 22)
        Me.txtPIC_HP.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(588, 117)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 14)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "PIC HP"
        '
        'txtPICName
        '
        Me.txtPICName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPICName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPICName.Location = New System.Drawing.Point(674, 89)
        Me.txtPICName.Name = "txtPICName"
        Me.txtPICName.Size = New System.Drawing.Size(245, 22)
        Me.txtPICName.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(588, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 14)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "PIC Name"
        '
        'txtMeetWith
        '
        Me.txtMeetWith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeetWith.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeetWith.Location = New System.Drawing.Point(674, 63)
        Me.txtMeetWith.Name = "txtMeetWith"
        Me.txtMeetWith.Size = New System.Drawing.Size(245, 22)
        Me.txtMeetWith.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(588, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 14)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Meet With"
        '
        'txtSPK
        '
        Me.txtSPK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSPK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPK.Location = New System.Drawing.Point(674, 37)
        Me.txtSPK.Name = "txtSPK"
        Me.txtSPK.Size = New System.Drawing.Size(110, 22)
        Me.txtSPK.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(588, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 14)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "SPK No."
        '
        'dtpOnSite
        '
        Me.dtpOnSite.CustomFormat = "dd-MMM-yyyy"
        Me.dtpOnSite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOnSite.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOnSite.Location = New System.Drawing.Point(674, 13)
        Me.dtpOnSite.Name = "dtpOnSite"
        Me.dtpOnSite.Size = New System.Drawing.Size(110, 22)
        Me.dtpOnSite.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(588, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 14)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Survey Date"
        '
        'txtCustHP
        '
        Me.txtCustHP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustHP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustHP.Location = New System.Drawing.Point(83, 138)
        Me.txtCustHP.Name = "txtCustHP"
        Me.txtCustHP.Size = New System.Drawing.Size(110, 22)
        Me.txtCustHP.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Cust. HP"
        '
        'txtSurveyorName
        '
        Me.txtSurveyorName.BackColor = System.Drawing.Color.LightGray
        Me.txtSurveyorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurveyorName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurveyorName.Location = New System.Drawing.Point(161, 61)
        Me.txtSurveyorName.Name = "txtSurveyorName"
        Me.txtSurveyorName.ReadOnly = True
        Me.txtSurveyorName.Size = New System.Drawing.Size(200, 22)
        Me.txtSurveyorName.TabIndex = 42
        '
        'txtSurveyorID
        '
        Me.txtSurveyorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurveyorID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurveyorID.Location = New System.Drawing.Point(83, 61)
        Me.txtSurveyorID.Name = "txtSurveyorID"
        Me.txtSurveyorID.Size = New System.Drawing.Size(72, 22)
        Me.txtSurveyorID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 14)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Surveyor"
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.LightGray
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.Location = New System.Drawing.Point(160, 112)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.ReadOnly = True
        Me.txtCustName.Size = New System.Drawing.Size(201, 22)
        Me.txtCustName.TabIndex = 38
        '
        'txtCust
        '
        Me.txtCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCust.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCust.Location = New System.Drawing.Point(83, 112)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(72, 22)
        Me.txtCust.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Customer"
        '
        'dtpSurveyDate
        '
        Me.dtpSurveyDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpSurveyDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSurveyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSurveyDate.Location = New System.Drawing.Point(83, 35)
        Me.dtpSurveyDate.Name = "dtpSurveyDate"
        Me.dtpSurveyDate.Size = New System.Drawing.Size(110, 22)
        Me.dtpSurveyDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Print Date"
        '
        'txtSurveyNo
        '
        Me.txtSurveyNo.BackColor = System.Drawing.Color.LightGray
        Me.txtSurveyNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurveyNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurveyNo.Location = New System.Drawing.Point(83, 8)
        Me.txtSurveyNo.Name = "txtSurveyNo"
        Me.txtSurveyNo.ReadOnly = True
        Me.txtSurveyNo.Size = New System.Drawing.Size(108, 22)
        Me.txtSurveyNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No Survey"
        '
        'lbl_status
        '
        Me.lbl_status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_status.AutoSize = True
        Me.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_status.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Red
        Me.lbl_status.Location = New System.Drawing.Point(14, 33)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_status.Size = New System.Drawing.Size(66, 24)
        Me.lbl_status.TabIndex = 40
        Me.lbl_status.Text = "Label9"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkSupporting)
        Me.Panel2.Controls.Add(Me.chkTitik)
        Me.Panel2.Controls.Add(Me.chkManifold)
        Me.Panel2.Controls.Add(Me.chkPipe)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.txtItemComponent)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.txtType)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.txtCategory)
        Me.Panel2.Controls.Add(Me.Btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_delete)
        Me.Panel2.Controls.Add(Me.btn_save)
        Me.Panel2.Controls.Add(Me.btn_edit)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtRemarkD)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtUOM)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtItemName)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtItemID)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(12, 309)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(945, 85)
        Me.Panel2.TabIndex = 5
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(726, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 14)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Component"
        '
        'txtItemComponent
        '
        Me.txtItemComponent.BackColor = System.Drawing.Color.LightGray
        Me.txtItemComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemComponent.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemComponent.Location = New System.Drawing.Point(729, 25)
        Me.txtItemComponent.Name = "txtItemComponent"
        Me.txtItemComponent.ReadOnly = True
        Me.txtItemComponent.Size = New System.Drawing.Size(105, 22)
        Me.txtItemComponent.TabIndex = 30
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(832, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 14)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "Type"
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.LightGray
        Me.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.Location = New System.Drawing.Point(835, 25)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(100, 22)
        Me.txtType.TabIndex = 28
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(630, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 14)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Category"
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.LightGray
        Me.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategory.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategory.Location = New System.Drawing.Point(633, 25)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.ReadOnly = True
        Me.txtCategory.Size = New System.Drawing.Size(95, 22)
        Me.txtCategory.TabIndex = 26
        '
        'Btn_cancel
        '
        Me.Btn_cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_cancel.Location = New System.Drawing.Point(227, 51)
        Me.Btn_cancel.Name = "Btn_cancel"
        Me.Btn_cancel.Size = New System.Drawing.Size(71, 27)
        Me.Btn_cancel.TabIndex = 17
        Me.Btn_cancel.Text = "Cancel"
        Me.Btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.Location = New System.Drawing.Point(75, 51)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(71, 27)
        Me.btn_delete.TabIndex = 15
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(155, 51)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(71, 27)
        Me.btn_save.TabIndex = 16
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit.Location = New System.Drawing.Point(3, 51)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(71, 27)
        Me.btn_edit.TabIndex = 14
        Me.btn_edit.Text = "Edit"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(429, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 14)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Remarks"
        '
        'txtRemarkD
        '
        Me.txtRemarkD.BackColor = System.Drawing.Color.LightGray
        Me.txtRemarkD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarkD.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarkD.Location = New System.Drawing.Point(430, 25)
        Me.txtRemarkD.Name = "txtRemarkD"
        Me.txtRemarkD.ReadOnly = True
        Me.txtRemarkD.Size = New System.Drawing.Size(202, 22)
        Me.txtRemarkD.TabIndex = 16
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.Color.LightGray
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(365, 25)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(64, 22)
        Me.txtQty.TabIndex = 15
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Qty Asked"
        '
        'txtUOM
        '
        Me.txtUOM.BackColor = System.Drawing.Color.LightGray
        Me.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOM.Location = New System.Drawing.Point(303, 25)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.ReadOnly = True
        Me.txtUOM.Size = New System.Drawing.Size(61, 22)
        Me.txtUOM.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(300, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 14)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "UoM"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.LightGray
        Me.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(77, 25)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(225, 22)
        Me.txtItemName.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(76, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Item Name"
        '
        'txtItemID
        '
        Me.txtItemID.BackColor = System.Drawing.Color.LightGray
        Me.txtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemID.Location = New System.Drawing.Point(5, 25)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.ReadOnly = True
        Me.txtItemID.Size = New System.Drawing.Size(71, 22)
        Me.txtItemID.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Item ID"
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(20, 449)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(71, 27)
        Me.btn_insert.TabIndex = 21
        Me.btn_insert.Text = "Insert"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'gvDetail
        '
        Me.gvDetail.AllowUserToAddRows = False
        Me.gvDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item_ID, Me.Item_Name, Me.Item_UoM, Me.Item_Qty, Me.Item_Remark, Me.Item_Category, Me.Item_Component, Me.Item_Type})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvDetail.DefaultCellStyle = DataGridViewCellStyle2
        Me.gvDetail.Location = New System.Drawing.Point(12, 400)
        Me.gvDetail.Name = "gvDetail"
        Me.gvDetail.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvDetail.Size = New System.Drawing.Size(945, 183)
        Me.gvDetail.TabIndex = 6
        '
        'Item_ID
        '
        Me.Item_ID.HeaderText = "Item ID"
        Me.Item_ID.Name = "Item_ID"
        Me.Item_ID.ReadOnly = True
        Me.Item_ID.Width = 80
        '
        'Item_Name
        '
        Me.Item_Name.HeaderText = "Item Name"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.ReadOnly = True
        Me.Item_Name.Width = 180
        '
        'Item_UoM
        '
        Me.Item_UoM.HeaderText = "UoM"
        Me.Item_UoM.Name = "Item_UoM"
        Me.Item_UoM.ReadOnly = True
        Me.Item_UoM.Width = 60
        '
        'Item_Qty
        '
        Me.Item_Qty.HeaderText = "Qty"
        Me.Item_Qty.Name = "Item_Qty"
        Me.Item_Qty.ReadOnly = True
        Me.Item_Qty.Width = 70
        '
        'Item_Remark
        '
        Me.Item_Remark.HeaderText = "Remark"
        Me.Item_Remark.Name = "Item_Remark"
        Me.Item_Remark.ReadOnly = True
        Me.Item_Remark.Width = 200
        '
        'Item_Category
        '
        Me.Item_Category.HeaderText = "Category"
        Me.Item_Category.Name = "Item_Category"
        Me.Item_Category.ReadOnly = True
        '
        'Item_Component
        '
        Me.Item_Component.HeaderText = "Component"
        Me.Item_Component.Name = "Item_Component"
        Me.Item_Component.ReadOnly = True
        Me.Item_Component.Width = 85
        '
        'Item_Type
        '
        Me.Item_Type.HeaderText = "Type"
        Me.Item_Type.Name = "Item_Type"
        Me.Item_Type.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 593)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 14)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Survey Remarks"
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.Location = New System.Drawing.Point(110, 591)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(847, 63)
        Me.txtRemark.TabIndex = 18
        '
        'txtSeqNum
        '
        Me.txtSeqNum.BackColor = System.Drawing.Color.DarkGray
        Me.txtSeqNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeqNum.Location = New System.Drawing.Point(92, 491)
        Me.txtSeqNum.Name = "txtSeqNum"
        Me.txtSeqNum.ReadOnly = True
        Me.txtSeqNum.Size = New System.Drawing.Size(71, 20)
        Me.txtSeqNum.TabIndex = 39
        Me.txtSeqNum.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.BackColor = System.Drawing.Color.DarkGray
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnEdit, Me.btnDelete, Me.btnSave, Me.btnCancel, Me.sep_Approver, Me.btnApprove, Me.btnReject, Me.ToolStripSeparator1, Me.btnFind, Me.btnList})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(969, 25)
        Me.ToolStrip.TabIndex = 40
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnNew.Size = New System.Drawing.Size(56, 22)
        Me.btnNew.Text = "New"
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnEdit.Size = New System.Drawing.Size(52, 22)
        Me.btnEdit.Text = "Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnDelete.Size = New System.Drawing.Size(65, 22)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSave.Size = New System.Drawing.Size(56, 22)
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCancel.Size = New System.Drawing.Size(68, 22)
        Me.btnCancel.Text = "Cancel"
        '
        'sep_Approver
        '
        Me.sep_Approver.Name = "sep_Approver"
        Me.sep_Approver.Size = New System.Drawing.Size(6, 25)
        '
        'btnApprove
        '
        Me.btnApprove.Image = CType(resources.GetObject("btnApprove.Image"), System.Drawing.Image)
        Me.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnApprove.Size = New System.Drawing.Size(77, 22)
        Me.btnApprove.Text = "Approve"
        '
        'btnReject
        '
        Me.btnReject.Image = CType(resources.GetObject("btnReject.Image"), System.Drawing.Image)
        Me.btnReject.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnReject.Size = New System.Drawing.Size(64, 22)
        Me.btnReject.Text = "Reject"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFind
        '
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.btnFind.Size = New System.Drawing.Size(60, 22)
        Me.btnFind.Text = "Find"
        '
        'btnList
        '
        Me.btnList.Image = CType(resources.GetObject("btnList.Image"), System.Drawing.Image)
        Me.btnList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(45, 22)
        Me.btnList.Text = "List"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnSupporting)
        Me.Panel3.Controls.Add(Me.btnTitikApi)
        Me.Panel3.Controls.Add(Me.btnPipeToKitchen)
        Me.Panel3.Controls.Add(Me.btnManifold)
        Me.Panel3.Location = New System.Drawing.Point(12, 248)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(945, 52)
        Me.Panel3.TabIndex = 41
        '
        'btnManifold
        '
        Me.btnManifold.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManifold.Location = New System.Drawing.Point(45, 8)
        Me.btnManifold.Name = "btnManifold"
        Me.btnManifold.Size = New System.Drawing.Size(146, 33)
        Me.btnManifold.TabIndex = 14
        Me.btnManifold.Text = "Manifold"
        Me.btnManifold.UseVisualStyleBackColor = True
        '
        'btnPipeToKitchen
        '
        Me.btnPipeToKitchen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPipeToKitchen.Location = New System.Drawing.Point(283, 8)
        Me.btnPipeToKitchen.Name = "btnPipeToKitchen"
        Me.btnPipeToKitchen.Size = New System.Drawing.Size(146, 33)
        Me.btnPipeToKitchen.TabIndex = 15
        Me.btnPipeToKitchen.Text = "Pipe To Kitchen"
        Me.btnPipeToKitchen.UseVisualStyleBackColor = True
        '
        'btnTitikApi
        '
        Me.btnTitikApi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTitikApi.Location = New System.Drawing.Point(517, 8)
        Me.btnTitikApi.Name = "btnTitikApi"
        Me.btnTitikApi.Size = New System.Drawing.Size(146, 33)
        Me.btnTitikApi.TabIndex = 16
        Me.btnTitikApi.Text = "Titik Api"
        Me.btnTitikApi.UseVisualStyleBackColor = True
        '
        'btnSupporting
        '
        Me.btnSupporting.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupporting.Location = New System.Drawing.Point(743, 8)
        Me.btnSupporting.Name = "btnSupporting"
        Me.btnSupporting.Size = New System.Drawing.Size(146, 33)
        Me.btnSupporting.TabIndex = 17
        Me.btnSupporting.Text = "Supporting Material"
        Me.btnSupporting.UseVisualStyleBackColor = True
        '
        'chkPipe
        '
        Me.chkPipe.AutoSize = True
        Me.chkPipe.Location = New System.Drawing.Point(350, 53)
        Me.chkPipe.Name = "chkPipe"
        Me.chkPipe.Size = New System.Drawing.Size(46, 17)
        Me.chkPipe.TabIndex = 32
        Me.chkPipe.Text = "Pipe"
        Me.chkPipe.UseVisualStyleBackColor = True
        Me.chkPipe.Visible = False
        '
        'chkManifold
        '
        Me.chkManifold.AutoSize = True
        Me.chkManifold.Location = New System.Drawing.Point(444, 53)
        Me.chkManifold.Name = "chkManifold"
        Me.chkManifold.Size = New System.Drawing.Size(66, 17)
        Me.chkManifold.TabIndex = 33
        Me.chkManifold.Text = "Manifold"
        Me.chkManifold.UseVisualStyleBackColor = True
        Me.chkManifold.Visible = False
        '
        'chkTitik
        '
        Me.chkTitik.AutoSize = True
        Me.chkTitik.Location = New System.Drawing.Point(529, 53)
        Me.chkTitik.Name = "chkTitik"
        Me.chkTitik.Size = New System.Drawing.Size(60, 17)
        Me.chkTitik.TabIndex = 34
        Me.chkTitik.Text = "TitikApi"
        Me.chkTitik.UseVisualStyleBackColor = True
        Me.chkTitik.Visible = False
        '
        'chkSupporting
        '
        Me.chkSupporting.AutoSize = True
        Me.chkSupporting.Location = New System.Drawing.Point(614, 53)
        Me.chkSupporting.Name = "chkSupporting"
        Me.chkSupporting.Size = New System.Drawing.Size(78, 17)
        Me.chkSupporting.TabIndex = 35
        Me.chkSupporting.Text = "Supporting"
        Me.chkSupporting.UseVisualStyleBackColor = True
        Me.chkSupporting.Visible = False
        '
        'frmSurvey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 662)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lbl_status)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtSeqNum)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.gvDetail)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_insert)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurvey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Survey / List of Material"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSurveyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpSurveyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCustName As System.Windows.Forms.TextBox
    Friend WithEvents txtCust As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRemarkD As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_insert As System.Windows.Forms.Button
    Friend WithEvents txtSeqNum As System.Windows.Forms.TextBox
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sep_Approver As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtCustHP As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSurveyorName As System.Windows.Forms.TextBox
    Friend WithEvents txtSurveyorID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSPK As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpOnSite As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPIC_HP As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPICName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMeetWith As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Public WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Public WithEvents btnFind As System.Windows.Forms.ToolStripButton
    Public WithEvents btnList As System.Windows.Forms.ToolStripButton
    Public WithEvents btnApprove As System.Windows.Forms.ToolStripButton
    Public WithEvents btnReject As System.Windows.Forms.ToolStripButton
    Public WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMarketingName As System.Windows.Forms.TextBox
    Friend WithEvents txtMarketingID As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtItemComponent As System.Windows.Forms.TextBox
    Friend WithEvents Item_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_UoM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Component As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnManifold As System.Windows.Forms.Button
    Friend WithEvents btnPipeToKitchen As System.Windows.Forms.Button
    Friend WithEvents btnTitikApi As System.Windows.Forms.Button
    Friend WithEvents btnSupporting As System.Windows.Forms.Button
    Friend WithEvents chkSupporting As System.Windows.Forms.CheckBox
    Friend WithEvents chkTitik As System.Windows.Forms.CheckBox
    Friend WithEvents chkManifold As System.Windows.Forms.CheckBox
    Friend WithEvents chkPipe As System.Windows.Forms.CheckBox
End Class
