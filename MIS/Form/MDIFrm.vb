Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports MIS.mdlCommon
Imports Microsoft.SqlServer.Server
Imports MIS.GlobalVar

Public Class MDIFrm
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub MDIFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        lbl_LoginTxt.Text = "Welcome " & userlog.Access_Desc & " : " & userlog.EmployeeName
        StatusStrip1.Visible = False
        'UserRole.Text = "Welcome " & userlog.Access_Desc & " : " & userlog.EmployeeName
        'Me.Text = "::
        Me.Text = " MIC version Jan 1.1 (25-01-2013)"
        Dim frmChild As New frmBingkai

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmBingkai" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
        ControlMenu()
    End Sub

#Region "GENERAL"
    Private Sub ExiMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OG999.Click
        If Me.ActiveMdiChild Is Nothing Then
            Application.Exit()
        Else
            If MessageBox.Show("Are you sure to close this application ?" & vbCrLf & "All unsaved transaction will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub OG998_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OG998.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            If MessageBox.Show("Are you sure to close this application ?" & vbCrLf & "All unsaved transaction will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Me.Dispose()
        FrmLogin.Show()

        FrmLogin.txt_Password.Clear()
        FrmLogin.txt_Username.Clear()
        FrmLogin.txt_Username.Focus()
    End Sub

    Private Sub TestingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New TESTING

        For Each f As Form In Me.MdiChildren
            If f.Name = "TESTING" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub CloseMenuChild(ByVal MenuParent As ToolStripMenuItem)
        Dim i As Integer

        For i = 0 To MenuParent.DropDownItems.Count - 1
            Dim submenu As ToolStripMenuItem

            Try
                submenu = MenuParent.DropDownItems.Item(i)
                CloseMenuChild(submenu)

                submenu.Visible = False
                'If submenu.DropDownItems.Count > 0 Then
                '    For Each x As ToolStripMenuItem In submenu.DropDownItems
                '        x.Visible = False
                '    Next
                'End If
            Catch ex As Exception
                MenuParent.DropDownItems.Item(i).Visible = False
            End Try
        Next

        MenuParent.Visible = False
    End Sub

    Private Sub CloseAllMenu()
        For Each Menu As ToolStripMenuItem In MenuStrip.Items
            For Each SubMenu As ToolStripItem In Menu.DropDownItems
                Try
                    CloseMenuChild(SubMenu)
                Catch ex As Exception
                    SubMenu.Visible = False
                End Try
            Next

            If Menu.Name <> ExitMenu Then
                Menu.Visible = False
            End If
        Next
    End Sub

    Private Sub ShowMenu(ByVal ParentMenu As ToolStripMenuItem, ByVal ObjectID As String, ByVal ObjectName As String)
        Dim k As Integer
        Dim SubMenu As ToolStripMenuItem

        For k = 0 To ParentMenu.DropDownItems.Count - 1
            Try
                SubMenu = ParentMenu.DropDownItems.Item(k)
                If SubMenu.Name = ObjectID Then
                    SubMenu.Visible = True
                    SubMenu.Text = ObjectName

                    Exit For
                Else
                    ShowMenu(SubMenu, ObjectID, ObjectName)
                End If
            Catch ex As Exception
                If ParentMenu.Name = ObjectID Then
                    ParentMenu.DropDownItems.Item(k).Visible = True
                End If
            End Try
        Next
    End Sub
    Private Sub Control_ShortCut(ByVal boo As Boolean)
        SC_PR.Visible = boo
        SC_INBOX.Visible = boo
        SC_StockMovement.Visible = boo
        SC_ChangePassword.Visible = boo
    End Sub
    Private Sub ControlMenu()
        Dim dc(1) As DataColumn

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If
            CloseAllMenu()

            Control_ShortCut(True)

            Cmd.CommandText = "EXEC GetAccessObjectForMenu '" & userlog.AccessID & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            Conn.Close()

            'Dim dr_menu, dr_SubMenu As DataRow
            Dim flag As String = "Y"
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Its weird.. this access have nothing to access")
                Control_ShortCut(False)
                Exit Sub
            Else
                'For Each item As DataRow In dt.Rows
                '    For Each Menu As ToolStripMenuItem In MenuStrip.Items
                '        '    If item("ObjGrp_ID").ToString.Trim <> Menu.Name.Trim Or item("ObjGrp_ID") <> "OG998" Or item("ObjGrp_ID") <> "OG999" Then
                '        '        Menu.Enabled = False
                '        '    Else
                '        '        For Each SubMenu As ToolStripItem In Menu.DropDownItems
                '        '            If item("Object_ID").ToString.Trim <> SubMenu.Name.Trim Then
                '        '                SubMenu.Enabled = False
                '        '            End If
                '        '        Next
                '        '    End If
                '        For Each SubMenu As ToolStripItem In Menu.DropDownItems
                '            If item("Object_ID").ToString.Trim <> SubMenu.Name.Trim Then
                '                SubMenu.Enabled = False
                '                flag = 1
                '                Exit For
                '            Else
                '                SubMenu.Enabled = True
                '                flag = 0
                '            End If
                '        Next
                '        If flag = 1 Then
                '            Exit For
                '        End If
                '    Next
                'Next

                Dim i As Integer
                Dim mnStrip As ToolStripMenuItem
                Dim ObjectName As String, ObjectID As String, ObjectGrpName As String


                'If userlog.AccessID = "AC999" Then
                '    For i = 0 To 100 - 1
                '        With dt.Rows(i)
                '            mnStrip.Visible = True
                '            mnStrip.Text = ObjectGrpName
                '            ShowMenu(mnStrip, ObjectID, ObjectName)
                '        End With
                '    Next
                'Else

                For i = 0 To dt.Rows.Count - 1
                    With dt.Rows(i)
                        mnStrip = MenuStrip.Items.Item(.Item(Fields.GroupObject).ToString)
                        ObjectGrpName = .Item(Fields.GroupObjectName).ToString
                        ObjectName = .Item(Fields.ObjectDesc).ToString
                        ObjectID = .Item(Fields.ObjectID).ToString

                        If Not mnStrip.Visible Or userlog.AccessID = "AC999" Then
                            mnStrip.Visible = True
                            mnStrip.Text = ObjectGrpName
                        End If

                        ShowMenu(mnStrip, ObjectID, ObjectName)
                        'For j = 0 To mnStrip.DropDownItems.Count - 1
                        '    Try
                        '        SubMenu = mnStrip.DropDownItems.Item(j)
                        '        If SubMenu.Name = .Item(Fields.ObjectID).ToString Then
                        '            SubMenu.Visible = True
                        '            Exit For
                        '        Else
                        '            ShowMenu(SubMenu, .Item(Fields.ObjectID).ToString)
                        '        End If
                        '    Catch ex As Exception
                        '        mnStrip.DropDownItems.Item(i).Visible = True
                        '    End Try
                        'Next
                    End With
                Next

                'For Each Menu As ToolStripMenuItem In MenuStrip.Items
                '    For Each SubMenu As ToolStripItem In Menu.DropDownItems
                '        For Each item As DataRow In dt.Rows
                '            If item("Object_ID").ToString.Trim = SubMenu.Name.Trim Then
                '                SubMenu.Enabled = False
                '                flag = 1
                '                Exit For
                '            Else
                '                SubMenu.Enabled = True
                '                flag = 0
                '            End If
                '        Next
                '        If flag = 0 Then
                '            Exit For
                '        End If
                '    Next
                '    Exit For
                'Next
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Error")
        End Try
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub MD_Barang_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
#End Region
    
#Region "Master (OG001)"
    '------------------------------- b:Beg Balance---------------------------------------------------------------------
    Private Sub OB118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB118.Click
        Dim frmChild As New Frm_MasterStockBB

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterStockBB" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB119.Click
        Dim frmChild As New Frm_MasterUtangBB

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterUtangBB" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB120.Click
        Dim frmChild As New Frm_MasterPiutangBB

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterPiutangBB" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB121.Click
        Dim frmChild As New Frm_MasterCOABB

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterCOABB" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
    '------------------------------- e:Beg Balance---------------------------------------------------------------------

    Private Sub OB123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB123.Click
        Dim frmChild As New Frm_MasterCOA

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterCOA" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB127_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB127.Click
        Dim frmChild As New frmMasterQuestionView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmMasterQuestionView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB128_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB128.Click
        Dim frmChild As New Frm_MasterDepartment

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterDepartment" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB125_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB125.Click
        Dim frmChild As New Frm_MasterBudget

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterBudget" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB129_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB129.Click
        Dim frmChild As New Frm_MasterJasa

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmMaintainSalesPriceJasa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB106.Click
        Dim frmChild As New Frm_MasterEmployee

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterEmployee" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB107.Click
        Dim frmChild As New Frm_MasterSupp

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterSupp" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB108_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB108.Click
        Dim frmChild As New Frm_MasterCust

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterCust" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB109.Click
        Dim frmChild As New Frm_MasterWarehouse

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterWarehouse" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB110.Click
        Dim frmChild As New Frm_MasterProses

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterProses" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB701_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB701.Click
        Dim frmChild As New frmViewFinance

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewFinance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB112.Click
        Dim frmChild As New Frm_MasterItem

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterItem" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB113.Click
        Dim frmChild As New Frm_MasterUnitStock

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterUnitStock" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB114.Click
        'Purchase History
    End Sub

    Private Sub OB115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB115.Click
        'Sales History
    End Sub

    Private Sub OB116_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB116.Click
        Dim frmChild As New Frm_Komponen_Group

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_Komponen_Group" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    '------------------------------- b:Access Menu---------------------------------------------------------------------
    Private Sub OB101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB101.Click
        Dim frmChild As New Frm_MasterAccess

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterAccess" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB102.Click
        Dim frmChild As New Frm_MasterObject

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterObject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB103.Click
        Dim frmChild As New Frm_MasterObjGrp

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_MasterObjGrp" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB104.Click
        Dim frmChild As New Frm_AccessObject

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_AccessObject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB105.Click
        'Dim frmChild As New Frm_MasterCompanyProfile

        'For Each f As Form In Me.MdiChildren
        '    If f.Name = "Frm_MasterCompanyProfile " Then
        '        f.BringToFront()
        '        Exit Sub
        '    End If
        'Next

        'frmChild.MdiParent = Me
        'frmChild.Show()
    End Sub

    '------------------------------- e:Access Menu---------------------------------------------------------------------
#End Region

#Region "Pembelian (OG002)"
    Private Sub OB201_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB201.Click
        Dim frmChild As New FrmViewRequestPembelianBrg

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewRequestPembelianBrg" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB202_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB202.Click
        Dim frmChild As New frm_POPending

        For Each f As Form In Me.MdiChildren
            If f.Name = "frm_POPending" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB203_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB203.Click
        Dim frmChild As New Frm_ViewPenerimaBrg

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_ViewPenerimaBrg" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB208ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB208.Click
        Dim frmChild As New frmViewMonitoringPO

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewMonitoringPO" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB209ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB209.Click
        Dim frmChild As New FrmViewMonitoringPR

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewMonitoringPR" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB210ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New FrmViewRequestPembelianBrg

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewRequestPembelianBrg" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

#End Region

#Region "Penjualan (OG003)"
    Private Sub OB301_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB301.Click
        Dim frmChild As New frmSurvey_View

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmSurvey_View" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB302_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB302.Click
        Dim frmChild As New frmViewPenawaranHargaMarketing

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewPenawaranHargaMarketing" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB303_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB303.Click
        Dim frmChild As New frmMaintainSalesPriceItem

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmMaintainSalesPriceItem" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB304ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB304.Click
        Dim frmChild As New frmOrderMaintanceView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOrderMaintanceView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB305ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB305.Click
        Dim frmChild As New frmQuestionnaireView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmQuestionnaireView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB307_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB307.Click
        Dim frmChild As New frmMaintainSalesPriceJasa

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmMaintainSalesPriceJasa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB306_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB306.Click
        Dim frmChild As New FrmMoU

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmMoU" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

#End Region

#Region "Project (OG004)"
    Private Sub OB401_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB401.Click
        Dim frmChild As New FrmViewPenawaranHargaProject

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewPenawaranHargaProject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB402_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB402.Click
        Dim frmChild As New frmViewSPK

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewSPK" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB403_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB403.Click
        Dim frmChild As New frmViewOrderPabrikasi

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewOrderPabrikasi" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB404ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB404.Click
        Dim frmChild As New frmPermintaanPengeluaranBahanView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPermintaanPengeluaranBahanView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB405ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB405.Click
        Dim frmChild As New frmLogBookView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmLogBookView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB406ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB406.Click
        Dim frmChild As New FrmViewPemakaianBahanPerSPK

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewPemakaianBahanPerSPK" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB407_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB407.Click
        Dim frmChild As New frmPengembalianBarang_View

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPengembalianBrgView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB408_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB408.Click
        Dim frmChild As New frmPemakaianBahan_View

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPemakaianBahan_View" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

#End Region

#Region "Gudang (OG005)"
    Private Sub OB501_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB501.Click
        Dim frmChild As New FrmViewStockMovement

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewStockMovement" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB502_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB502.Click
        Dim frmChild As New FrmUpdateStok

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmUpdateStok" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB503_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB503.Click
        Dim frmChild As New FrmViewInsertStockFisik

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewInsertStockFisik" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB504_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region

#Region "Toko (OG006)"
    Private Sub OB601_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB601.Click
        Dim frmChild As New frmViewPenjualanToko

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewPenjualanToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB602ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB602.Click
        Dim frmChild As New frmTransferStockTokoView
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransferStockTokoView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB603ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB603.Click
        Dim frmChild As New frmViewStockMovementToko

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmViewStockMovementToko" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region

#Region "Accountig (0G007)"
    Private Sub OB708ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New Frm_PencairanGiro

        For Each f As Form In Me.MdiChildren
            If f.Name = "frm_PencairanGiro" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB709ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New FrmPencairanGiroPiutang

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPencairanGiroPiutang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB710ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New frmPencairanGiroPiutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPencairanGiroPiutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB711ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmChild As New FrmPencairanGiroView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPencairanGiroView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

#End Region

#Region "Tools(OG008)"
    Private Sub OB802_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB802.Click
        Dim frmChild As New frmChangePassword

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmChangePassword" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB801_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB801.Click
        Dim frmChild As New FrmInbox

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmInbox" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region

#Region "REPORT (OG009)"
    

#End Region

    Private Sub OB307ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB308.Click
        Dim frmChild As New Frm_Complaint

        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_Complaint" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB309_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB309.Click
        Dim frmChild As New frmViewInvoice

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewInvoice" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB204_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB204.Click
        Dim frmChild As New frmReturView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmReturView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB210_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB210.Click
        Dim frmChild As New frmRecommededSupplier

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRecommededSupplier" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB604_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB604.Click
        Dim frmChild As New frmTransReturToko_View

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransReturToko_View" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()

    End Sub

    Private Sub OB133_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB133.Click
        Dim frmChild As New frm_MasterClosing

        For Each f As Form In Me.MdiChildren
            If f.Name = "frm_MasterClosing" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB923ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub PR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC_PR.Click
        Dim frmChild As New FrmViewRequestPembelianBrg

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewRequestPembelianBrg" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB702_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB702.Click
        Dim frmChild As New frmDaftarPiutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDaftarPiutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB704_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB704.Click
        Dim frmChild As New frmPelunasanPiutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPelunasanPiutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()

    End Sub

    Private Sub OB707_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB707.Click
        Dim frmChild As New frmPencairanGiroPiutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPencairanGiroPiutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB705_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB705.Click
        Dim frmChild As New FrmPelunasanHutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmPelunasanHutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB706_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB706.Click
        Dim frmChild As New FrmPencairanGiroView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmPencairanGiroView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB703_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB703.Click
        Dim frmChild As New frmDaftarHutangView

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDaftarHutangView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB708_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB708.Click
        Dim frmChild As New FrmClosing

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmClosing" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

#Region "REPORT"

#Region "Report Penjualan"
    Private Sub OB925_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB925.Click
        Dim frmChild As New frmDlgReportPenjualan

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDlgReportPenjualan" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB904_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB904.Click
        Dim frmChild As New frmOptProspekOrderCustomer

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptProspekOrderCustomer" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB917_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB917.Click
        Dim frmChild As New frmRptPiutang

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptPiutang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB918_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB918.Click
        Dim frmChild As New frmRptPiutangSummary

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptPiutangSummary" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region

#Region "Pembelian"
    Private Sub OB906_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB906.Click
        Dim frmChild As New frmDlgReportPO

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDlgReportPO" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB914_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB914.Click
        Dim frmChild As New frmOptProgressProyek

        frmChild.Type = 2
        frmChild.Text = ":: Report Rekap Progress Project Per SPK ::"
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptProgressProyek" Then
                If f.Text <> ":: Report Progress Project Per SPK ::" Then
                    f.BringToFront()
                    Exit Sub
                End If
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB010.Click
        Dim frmChild As New frmRptHutang

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptHutang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB915_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB915.Click
        Dim frmChild As New frmRptHutangSummary

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptHutangSummary" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB901_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB901.Click
        Dim frmChild As New frmSupplierEvaluationBarang

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmSupplierEvaluationBarang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB902_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB902.Click
        Dim frmChild As New frmSupplierEvaluationJasa

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmSupplierEvaluationJasa" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region

#Region "Project"
    Private Sub OB903_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB903.Click
        Dim frmChild As New frmMonitoringOrderPabrikasi

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmMonitoringOrderPabrikasi" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB907_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB907.Click
        Dim frmChild As New frmOptProgressProyek

        frmChild.Type = 1
        frmChild.Text = ":: Report Progress Project Per SPK ::"
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptProgressProyek" Then
                If f.Text <> ":: Report Rekap Progress Project Per SPK ::" Then
                    f.BringToFront()
                    Exit Sub
                End If
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB908_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB908.Click
        Dim frmChild As New frmOptPakaiBahanSPK
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptPakaiBahanSPK" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB909_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB909.Click
        Dim frmChild As New frmDlgReportBPB

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDlgReportBPB" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB911_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB911.Click
        Dim frmChild As New frmDlgReportOrderMaintenance

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDlgReportOrderMaintenance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB912_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB912.Click
        Dim frmChild As New frmOptRekapProject

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptRekapProject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB913_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB913.Click
        Dim frmChild As New frmOptRekapPakaiBahanProject

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmOptRekapPakaiBahanProject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB916_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB916.Click
        Dim frmChild As New frmOptRekapPakaiBahanProject

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptJadwalProject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region

#Region "Accounting"
    Private Sub OB919_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB919.Click
        Dim frmChild As New frmRptJurnalList

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptJurnalList" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub


    Private Sub OB920_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB920.Click
        Dim frmChild As New frmRptNeraca

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptNeraca" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB921_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB921.Click
        Dim frmChild As New frmRptLabaRugi

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptLabaRugi" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB924_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB924.Click
        Dim frmChild As New frmRptLabaRugiPerProject

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptLabaRugiPerProject" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB922_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB922.Click
        Dim frmChild As New frmRptPelunasanHutang

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptPelunasanHutang" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB905.Click
        Dim frmChild As New frmRptGLDetail

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptGLDetail" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB032_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB032.Click
        Dim frmChild As New frmDlgStock

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmDlgStock" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
#End Region
#End Region

   
    
    
    Private Sub SC_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC_EXIT.Click
        If Me.ActiveMdiChild Is Nothing Then
            Application.Exit()
        Else
            If MessageBox.Show("Are you sure to close this application ?" & vbCrLf & "All unsaved transaction will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub SC_ChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC_ChangePassword.Click
        Dim frmChild As New frmChangePassword

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmChangePassword" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub SC_INBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC_INBOX.Click
        Dim frmChild As New FrmInbox

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmInbox" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub SC_StockMovement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SC_StockMovement.Click
        Dim frmChild As New FrmViewStockMovement

        For Each f As Form In Me.MdiChildren
            If f.Name = "FrmViewStockMovement" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub

    Private Sub OB033_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OB033.Click
        Dim frmChild As New frmRptLabaRugiPerDivisi

        For Each f As Form In Me.MdiChildren
            If f.Name = "frmRptLabaRugiPerDivisi" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = Me
        frmChild.Show()
    End Sub
End Class
