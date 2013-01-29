Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient
Public Class Frm_ViewComplaint

#Region "Variable Declaration"

    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTrans As String
    Dim dtTemp As New DataTable
    Dim dt As New DataTable
#End Region

#Region "Procedure & Function"

    'Sub RetrieveData(ByVal Field As String, ByVal keyword As String)
    '    Dim dtTable As New DataTable
    '    Try
    '        If conn.State = ConnectionState.Open Then conn.Close()
    '        conn.Open()
    '        cmd.CommandText = "EXEC sp_Retrieve_Trans_Complaint_Hdr '" & Field & "','" & keyword & "'"
    '        DA.SelectCommand = cmd
    '        DA.Fill(dtTable)
    '        conn.Close()

    '        gvComplaint.DataSource = dtTable
    '        gvComplaint.ReadOnly = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub SetGrid()
        gvComplaint.Columns(0).Width = 75        'No Urut
        gvComplaint.Columns(1).Width = 100       'Nama Project
        gvComplaint.Columns(2).Width = 100       'Tanggal
        gvComplaint.Columns(3).Width = 50        'Cust ID
        gvComplaint.Columns(4).Width = 100       'Alamat
        gvComplaint.Columns(5).Width = 100       'Diterima Nama
        gvComplaint.Columns(6).Width = 50        'Diterima Bagian
        gvComplaint.Columns(7).Width = 100       'Reason
        gvComplaint.Columns(8).Width = 100        'Status ID
        gvComplaint.Columns(9).Width = 50        'Active Flag
        'gvComplaint.Columns(6).Visible = False
    End Sub

#End Region
#Region "Event Handler"

    Private Sub frm_viewComplaint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        'cb_Customer.SelectedIndex
        SetAccess(Me, userlog.AccessID, Me.Name, ts_New)
        'Call RetrieveData("No_Urut", txtKeyword.Text.Trim)
        'Call SetGrid()
        conn.ConnectionString = ConnectStr 'Set Default connection
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        dt_from.Value = "01/01/" + CStr(Year(Now))
        'LoadPONo()
  
        btn_Cari_Click(Me, Nothing)
    End Sub



    Private Sub gvComplaint_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvComplaint.CellDoubleClick
        If gvComplaint.CurrentRow.DataGridView(0, gvComplaint.CurrentRow.Index).Value.ToString = "" Then Exit Sub
        Dim frmChild As New Frm_Complaint
        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_Complaint" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.txtNoUrut.Text = gvComplaint.CurrentRow.DataGridView(0, gvComplaint.CurrentRow.Index).Value.ToString
        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub

    Private Sub btn_Cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Try
            dt.Clear()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd.CommandText = "EXEC sp_Retrieve_Trans_Complaint_Hdr_View '" + dt_from.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              dt_To.Value.ToString("MM/dd/yyyy") + "','" & _
                                                              txtNoUrut.Text.Trim + "','" & _
                                                              txtCustID.Text.ToString.Trim + "','" & _
                                                              txtAlamat.Text.Trim + "','" & _
                                                              txtNamaDiterima.Text.Trim + "','" & _
                                                              txtNamaBagian.Text.Trim + "','" & _
                                                              txtStatusID.Text.ToString.Trim + "'"

            DA.SelectCommand = cmd
            DA.Fill(dt)

            'gv_PO.DataSource = dt

            gvComplaint.DataSource = dt
            SetGrid()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    'Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Call RetrieveData()
    'End Sub
    Private Sub ts_New_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_New.Click
        Dim frmChild As New Frm_Complaint
        For Each f As Form In Me.MdiChildren
            If f.Name = "Frm_Complaint" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
        Me.Close()
    End Sub
#End Region



    Private Sub txtCustID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustID.KeyDown
        Dim dt_Cust As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Cust_Id,Nama,Alamat,Deskripsi,Telp,Contact_Person from Master_Customer where active_flag = 'Y' ", "Cust_Id", "Nama", "Alamat", "Deskripsi", "Telp", "Contact_Person")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txtCustID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtCustName.Text = frmSearch.txtResult2.Text.ToString.Trim
                    txtAlamat.Focus()
                End If
            Catch ex As Exception
                conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtCustID.Text.Trim <> "" Then
                Try
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    dt_Cust.Clear()
                    cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ByKey  '" & txtCustID.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dt_Cust)

                    If dt_Cust.Rows.Count > 0 Then
                        txtCustName.Text = dt_Cust.Rows(0).Item(GlobalVar.Fields.Cust_Name).ToString
                        txtAlamat.Focus()
                    Else
                        MessageBox.Show("Customer ini tidak ditemukan. Pastikan ID Customer yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    conn.Close()
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End Try
            End If

        End If
        conn.Close()
    End Sub

    Private Sub txtStatusID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStatusID.KeyDown
        Dim dt_Status As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                CallandGetSearchData("Select Status_ID,Status_Name from Master_Status where Status_ID in ('CAP', 'WAMA','WCFP', 'WCFM','RBMA','CMP') ", "Status_Id", "Status_Name", "", "", "", "")

                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txtStatusID.Text = frmSearch.txtResult1.Text.ToString.Trim
                    txtStatusDesc.Text = frmSearch.txtResult2.Text.ToString.Trim
                    btn_cari.Focus()
                End If
            Catch ex As Exception
                conn.Close()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txtCustID.Text.Trim <> "" Then
                Try
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    dt_Status.Clear()
                    cmd.CommandText = "EXEC sp_Retrieve_Master_Status_ComplaintByKey  '" & txtStatusID.Text.Trim & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dt_Status)

                    If dt_Status.Rows.Count > 0 Then
                        txtCustName.Text = dt_Status.Rows(0).Item(GlobalVar.Fields.Cust_Name).ToString
                        txtAlamat.Focus()
                    Else
                        MessageBox.Show("Status ini tidak ditemukan. Pastikan ID Status yang dimasukan sudah benar", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Catch ex As Exception
                    conn.Close()
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End Try
            End If

        End If
        conn.Close()
    End Sub
End Class