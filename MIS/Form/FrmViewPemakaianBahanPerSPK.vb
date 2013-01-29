Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmViewPemakaianBahanPerSPK
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_stock As New DataTable
    Dim dt_dtl As New DataTable
    Dim dr_PR As DataRow

    Private Sub FrmViewPemakaianBahanPerSPK_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetAccess(Me, userlog.AccessID, Me.Name)
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        Load_Customer()
        Load_SPK()
        btn_cari_Click(Nothing, Nothing)
    End Sub

    Private Sub Load_Customer()
        Dim dt_item As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'Pindahin dr datatable PO ke datatable TrmBrg                            
        Cmd.CommandText = "EXEC sp_Retrieve_Master_Customer "
        DA.SelectCommand = Cmd
        DA.Fill(dt_item)

        Dim i As Integer = 0
        cb_Customer.Items.Insert(i, "")
        For Each item As DataRow In dt_item.Rows
            i += 1
            cb_Customer.Items.Insert(i, item("Nama").ToString.Trim)
        Next
    End Sub

    Private Sub Load_SPK()
        Dim dt_SPK As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        'Pindahin dr datatable PO ke datatable TrmBrg                            
        Cmd.CommandText = "EXEC sp_Retreive_Trans_SPK_Hdr ''"
        DA.SelectCommand = Cmd
        DA.Fill(dt_SPK)

        Dim i As Integer = 0
        'cb_SPKNo.Items.Insert(i, "")
        For Each item As DataRow In dt_SPK.Rows            
            cb_SPKNo.Items.Insert(i, item("SPK_No").ToString.Trim)
            i += 1
        Next
    End Sub

    Private Sub btn_cari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cari.Click
        Dim dt_Bahan As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        dt_Bahan.Clear()
        Cmd.CommandText = "EXEC sp_Retrieve_View_PemakaianBahanPerSPK '" + cb_SPKNo.Text + "','" + cb_Customer.Text + "','" + dt_from.Value + "','" + dt_to.Value + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_Bahan)

        gv.DataSource = dt_Bahan
    End Sub
End Class