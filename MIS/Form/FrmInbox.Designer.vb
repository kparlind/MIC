<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInbox
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
        Me.lbl_judul = New System.Windows.Forms.Label
        Me.tc_personal = New System.Windows.Forms.TabControl
        Me.Tab_Inbox = New System.Windows.Forms.TabPage
        Me.gv_inbox = New System.Windows.Forms.DataGridView
        Me.tab_Outbox = New System.Windows.Forms.TabPage
        Me.gv_outbox = New System.Windows.Forms.DataGridView
        Me.Tab_AllDoc = New System.Windows.Forms.TabPage
        Me.gv_all = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Btn_Search = New System.Windows.Forms.Button
        Me.txt_search = New System.Windows.Forms.TextBox
        Me.cb_col = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tc_personal.SuspendLayout()
        Me.Tab_Inbox.SuspendLayout()
        CType(Me.gv_inbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_Outbox.SuspendLayout()
        CType(Me.gv_outbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab_AllDoc.SuspendLayout()
        CType(Me.gv_all, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.Location = New System.Drawing.Point(14, 16)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(26, 29)
        Me.lbl_judul.TabIndex = 0
        Me.lbl_judul.Text = "1"
        '
        'tc_personal
        '
        Me.tc_personal.Controls.Add(Me.Tab_Inbox)
        Me.tc_personal.Controls.Add(Me.tab_Outbox)
        Me.tc_personal.Controls.Add(Me.Tab_AllDoc)
        Me.tc_personal.Location = New System.Drawing.Point(11, 122)
        Me.tc_personal.Name = "tc_personal"
        Me.tc_personal.SelectedIndex = 0
        Me.tc_personal.Size = New System.Drawing.Size(900, 305)
        Me.tc_personal.TabIndex = 1
        '
        'Tab_Inbox
        '
        Me.Tab_Inbox.Controls.Add(Me.gv_inbox)
        Me.Tab_Inbox.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Inbox.Name = "Tab_Inbox"
        Me.Tab_Inbox.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Inbox.Size = New System.Drawing.Size(892, 279)
        Me.Tab_Inbox.TabIndex = 0
        Me.Tab_Inbox.Text = "INBOX"
        Me.Tab_Inbox.UseVisualStyleBackColor = True
        '
        'gv_inbox
        '
        Me.gv_inbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_inbox.Location = New System.Drawing.Point(6, 6)
        Me.gv_inbox.Name = "gv_inbox"
        Me.gv_inbox.ReadOnly = True
        Me.gv_inbox.Size = New System.Drawing.Size(880, 265)
        Me.gv_inbox.TabIndex = 1
        '
        'tab_Outbox
        '
        Me.tab_Outbox.Controls.Add(Me.gv_outbox)
        Me.tab_Outbox.Location = New System.Drawing.Point(4, 22)
        Me.tab_Outbox.Name = "tab_Outbox"
        Me.tab_Outbox.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_Outbox.Size = New System.Drawing.Size(892, 279)
        Me.tab_Outbox.TabIndex = 1
        Me.tab_Outbox.Text = "OutBox"
        Me.tab_Outbox.UseVisualStyleBackColor = True
        '
        'gv_outbox
        '
        Me.gv_outbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_outbox.Location = New System.Drawing.Point(6, 7)
        Me.gv_outbox.Name = "gv_outbox"
        Me.gv_outbox.ReadOnly = True
        Me.gv_outbox.Size = New System.Drawing.Size(729, 265)
        Me.gv_outbox.TabIndex = 2
        '
        'Tab_AllDoc
        '
        Me.Tab_AllDoc.Controls.Add(Me.gv_all)
        Me.Tab_AllDoc.Location = New System.Drawing.Point(4, 22)
        Me.Tab_AllDoc.Name = "Tab_AllDoc"
        Me.Tab_AllDoc.Size = New System.Drawing.Size(892, 279)
        Me.Tab_AllDoc.TabIndex = 2
        Me.Tab_AllDoc.Text = "All Document"
        Me.Tab_AllDoc.UseVisualStyleBackColor = True
        '
        'gv_all
        '
        Me.gv_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gv_all.Location = New System.Drawing.Point(6, 7)
        Me.gv_all.Name = "gv_all"
        Me.gv_all.ReadOnly = True
        Me.gv_all.Size = New System.Drawing.Size(729, 265)
        Me.gv_all.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.Btn_Search)
        Me.GroupBox1.Controls.Add(Me.txt_search)
        Me.GroupBox1.Controls.Add(Me.cb_col)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(899, 56)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Area"
        '
        'Btn_Search
        '
        Me.Btn_Search.Location = New System.Drawing.Point(694, 16)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(199, 31)
        Me.Btn_Search.TabIndex = 3
        Me.Btn_Search.Text = "Search"
        Me.Btn_Search.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.Location = New System.Drawing.Point(194, 23)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(494, 24)
        Me.txt_search.TabIndex = 2
        '
        'cb_col
        '
        Me.cb_col.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_col.FormattingEnabled = True
        Me.cb_col.Items.AddRange(New Object() {"Transaction No", "Transaction Name", "Subject"})
        Me.cb_col.Location = New System.Drawing.Point(69, 23)
        Me.cb_col.Name = "cb_col"
        Me.cb_col.Size = New System.Drawing.Size(121, 24)
        Me.cb_col.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Column"
        '
        'FrmInbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 433)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tc_personal)
        Me.Controls.Add(Me.lbl_judul)
        Me.Name = "FrmInbox"
        Me.Text = "FrmInbox"
        Me.tc_personal.ResumeLayout(False)
        Me.Tab_Inbox.ResumeLayout(False)
        CType(Me.gv_inbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_Outbox.ResumeLayout(False)
        CType(Me.gv_outbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab_AllDoc.ResumeLayout(False)
        CType(Me.gv_all, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents tc_personal As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Inbox As System.Windows.Forms.TabPage
    Friend WithEvents tab_Outbox As System.Windows.Forms.TabPage
    Friend WithEvents Tab_AllDoc As System.Windows.Forms.TabPage
    Friend WithEvents gv_inbox As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Btn_Search As System.Windows.Forms.Button
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents cb_col As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gv_outbox As System.Windows.Forms.DataGridView
    Friend WithEvents gv_all As System.Windows.Forms.DataGridView
End Class
