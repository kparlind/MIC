Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmUpdateStok
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_stock As New DataTable

    Dim period As String

    Private Sub FrmUpdateStok_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
        Conn.ConnectionString = ConnectStr
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        GetYear()
        ClearAll()        
        Cb_Bulan.Text = Month(Now())
        If Month(Now()) = 1 Then
            Cb_Tahun.Text = Year(Now()) - 1
        Else
            Cb_Tahun.Text = Year(Now())
        End If
    End Sub

    Private Sub ClearAll()
        Txt_Gudang.Clear()
        txt_KdBrg.Clear()
        txt_NmBrg.Clear()
        Txt_Satuan.Clear()
        txt_StokNow.Clear()
        txt_StokRevisi.Clear()        
    End Sub

    Private Sub txt_KdBrg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_KdBrg.KeyDown
        If e.KeyCode = Keys.F1 Then
            CallandGetSearchData("Select item_id,item_name,UoM,b.warehouse_name from master_item_Hdr a left join Master_Warehouse b on a.Warehouse_ID = b.Warehouse_ID", "Item_ID", "Item_name", "UoM", "Warehouse_Name", "")

            txt_KdBrg.Text = frmSearch.txtResult1.Text.ToString.Trim
            txt_NmBrg.Text = frmSearch.txtResult2.Text.ToString.Trim
            Txt_Satuan.Text = frmSearch.txtResult3.Text.ToString.Trim
            Txt_Gudang.Text = frmSearch.txtResult4.Text.ToString.Trim
            txt_StokNow.Text = GetCurrentStok()
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_KdBrg.Text.Trim <> "" Then
                txt_StokNow.Text = GetCurrentStok()
                Cb_Bulan.Focus()
            End If
        End If
    End Sub

    Private Sub GetYear()
        Dim thn As String        
        thn = Year(Now())

        Cb_Tahun.Items.Add(thn - 1)
        Cb_Tahun.Items.Add(thn)
        Cb_Tahun.Items.Add(thn + 1)
    End Sub

    Function GetCurrentStok() As Integer
        Dim bulan As String

        If Cb_Bulan.Text < 10 Then
            bulan = "0" + Cb_Bulan.Text
        Else
            bulan = Cb_Bulan.Text
        End If

        period = Cb_Tahun.Text + bulan
        Dim dt_Stock As New DataTable
        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            Cmd.CommandText = "EXEC sp_Retrieve_Stok_ByKodeBrg '" & txt_KdBrg.Text.Trim & "','" & period & "'"
            DA.SelectCommand = Cmd
            DA.Fill(dt_Stock)

            If dt_Stock.Rows.Count > 0 Then
                GetCurrentStok = dt_Stock.Rows(0).Item("Nilai")
            Else
                GetCurrentStok = 0
            End If

            Conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim Ket, TipeProses As String
        Dim tmp_stok, LastSerial As Integer

        'validate
        If txt_StokRevisi.Text = "" Then
            MessageBox.Show("Revisi Stok harus diisi. Proses Update dibatalkan")
            Exit Sub
        End If

        If txt_StokRevisi.Text = txt_StokNow.Text Then
            MessageBox.Show("Revisi Stok sama dengan Stok saat ini. Proses Update dibatalkan")
            Exit Sub
        End If

        If txt_StokRevisi.Text.Trim = "" Then
            MessageBox.Show("Please fill Stok Revision")
            Exit Sub
        End If

        'Calculate 
        tmp_stok = CInt(txt_StokRevisi.Text) - CInt(txt_StokNow.Text)
        If tmp_stok < 0 Then 'Kalau berkurang berarti Stok berkurang/Keluar
            TipeProses = "OUT"
            tmp_stok = tmp_stok * -1 'Dibalikan ke positif
        Else
            TipeProses = "IN"
        End If

        'Set Transaction
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Dim ObjTrans As SqlTransaction
        ObjTrans = Conn.BeginTransaction("Trans")
        Cmd.Transaction = ObjTrans

        Try
            txt_TransNo.Text = Generate_TranNo(Me.Name)
            LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
            Ket = "Current Stok " & txt_StokNow.Text & " Adjust become " & txt_StokRevisi.Text

            Cmd.CommandText = "EXEC sp_Insert_UpdateStok '" & period & "','" & txt_KdBrg.Text.Trim & "','" & _
                              txt_TransNo.Text.Trim & "','" & TipeProses & "'," & tmp_stok & ",'" & Ket & "','" & _
                              userlog.UserName & "','" & Now() & "'"
            Cmd.ExecuteNonQuery()

            UpdateSerial(Me.Name, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName)
            ObjTrans.Commit()
            Conn.Close()
            MessageBox.Show("Proses Save Sukses")
            ClearAll()
            txt_TransNo.Text = Generate_TranNo(Me.Name) 'Refresh TransNo
        Catch ex As Exception
            ObjTrans.Rollback()
            Conn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txt_StokRevisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_StokRevisi.KeyPress
        If Not ((Asc(e.KeyChar) >= Asc("0") And Asc(e.KeyChar) <= Asc("9")) OrElse Asc(e.KeyChar) = Asc("-") OrElse Asc(e.KeyChar) = Asc(".")) Then
            e.KeyChar = Chr(0)
        End If
    End Sub
End Class