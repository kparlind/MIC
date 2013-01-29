﻿Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class frmViewFinance
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt As New DataTable
    Dim dt_PO As New DataTable
    Dim dt_Status As New DataTable
    Public callDialog As Boolean = False
    Dim Status_Proses As String
    Private Sub frmViewFinance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conn.ConnectionString = connectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text
        gv.AllowUserToAddRows = False
        TBDate_Fr.Value = "01/01/" + CStr(Year(Now))
        TBDate_To.Value = (TBDate_To.Value.AddDays(1))
        LoadPH()
        selectAll()

    End Sub

    Private Sub LoadPH()
        Dim dt_TB As New DataTable
        Dim dView As DataView
        Dim i As Integer = 0
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "Select finance_no from Trans_finance_hdr where finance_date between '" & TBDate_Fr.Value.ToString("MM/dd/yyyy") & "' and '" & TBDate_To.Value.ToString("MM/dd/yyyy") & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_TB)
            Conn.Close()

            'Dim dr As DataRow
            'dr = dt_TB.NewRow
            'dr(0) = ""
            'dt_TB.Rows.Add(dr)

            'cb_TBNo.DataSource = dt_TB
            'cb_TBNo.DisplayMember = GlobalVar.Fields.TB_No
            'cb_TBNo.ValueMember = GlobalVar.Fields.TB_No

            'dt_TB.Rows.Add("0", "All")
            dView = New DataView(dt_TB)
            dView.Sort = "finance_No ASC"
            cb_PH.Items.Insert(0, "All")
            cb_PH.Items.Item(0) = "All"
            While i < dt_TB.Rows.Count
                cb_PH.Items.Insert(i + 1, dt_TB.Rows(i).Item("finance_No"))
                cb_PH.Items.Item(i + 1) = dt_TB.Rows(i).Item("finance_No")
                i = i + 1
            End While


            'cb_PH.ValueMember = "PH_NO"
            'cb_PH.DisplayMember = "PH_NO"
            'cb_PH.DataSource = dView


        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub btn_cari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_View_Finance'" + TBDate_Fr.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              TBDate_To.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              cb_PH.SelectedItem + "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt)

            gv.DataSource = ""
            gv.DataSource = dt
            gv.Refresh()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub
    Private Sub selectAll()
        Try
            dt.Clear()
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "select Finance_date,Finance_no,Period,Remarks from trans_finance_hdr order by Finance_date desc"
            DA.SelectCommand = Cmd
            DA.Fill(dt)
            gv.DataSource = dt
            gv.Refresh()
            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Conn.Close()
        End Try
    End Sub

    Private Sub gv_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gv.DoubleClick
        If dt.Rows.Count > 0 Then
            Dim frmChild As New FrmTransFinance
            For Each f As Form In Me.MdiChildren
                If f.Name = "frmTransFinance" Then
                    f.BringToFront()
                    Exit Sub
                End If
            Next

            'Status_Proses = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            LoadFromView = True
            'id_status = gv.CurrentRow.DataGridView(4, gv.CurrentRow.Index).Value
            With frmChild
                .txt_TransNo.Text = gv.CurrentRow.DataGridView(1, gv.CurrentRow.Index).Value



                'Dim dt_TB As New DataTable
                'Dim i As Integer = 0


                '    Cmd.CommandText = "Select Supp_ID, Nama , Contact_Person from Master_Supplier"
                '    DA.SelectCommand = Cmd
                '    DA.Fill(dt_TB)

                '    .cb_suppID.Items.Insert(0, "All")
                '    .cb_suppID.Items.Item(0) = "All"
                '    While i < dt_TB.Rows.Count
                '        .cb_suppID.Items.Insert(i + 1, dt_TB.Rows(i).Item("Supp_ID"))
                '        .cb_suppID.Items.Item(i + 1) = dt_TB.Rows(i).Item("Supp_ID")
                '        i = i + 1
                '    End While
                '.cb_suppID.SelectedItem = gv.CurrentRow.DataGridView(2, gv.CurrentRow.Index).Value
                .Show()
            End With
        End If
    End Sub

    Private Sub btn_new_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_new.Click
        Dim frmChild As New FrmTransFinance
        For Each f As Form In Me.MdiChildren
            If f.Name = "frmTransFinance" Then
                f.BringToFront()
                Exit Sub
            End If
        Next
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
    End Sub
End Class