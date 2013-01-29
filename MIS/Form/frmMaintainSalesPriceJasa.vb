Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmMaintainSalesPriceJasa

#Region "Variable Declaration"
    Dim conn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtPrice As New DataTable
    Dim dtMaintainPrice As New DataTable
    Dim dc(0) As DataColumn
    Dim dc1(0) As DataColumn
    Dim dc2(0) As DataColumn
#End Region

#Region "Function & Procedure"

    Sub RetrieveData()
        Try
            dtPrice.Clear()
            dtMaintainPrice.Clear()

            If conn.State = ConnectionState.Closed Then conn.Open()

            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa"
            DA.SelectCommand = cmd
            DA.Fill(dtPrice)

            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa"
            DA.SelectCommand = cmd
            DA.Fill(dtMaintainPrice)

            conn.Close()

            If dtPrice.Rows.Count <> 0 Then
                dc(0) = dtPrice.Columns("Jasa ID")
                dtPrice.PrimaryKey = dc
            End If

            If dtMaintainPrice.Rows.Count <> 0 Then
                dc2(0) = dtMaintainPrice.Columns("Jasa ID")
                dtMaintainPrice.PrimaryKey = dc2
            End If

            dgv_data.DataSource = dtPrice

            dgv_data.Columns("Jasa ID").Width = 100
            dgv_data.Columns("Jasa ID").ReadOnly = True
            dgv_data.Columns("Name").Width = 200
            dgv_data.Columns("Name").ReadOnly = True
            dgv_data.Columns("Labor Price").Width = 175
            dgv_data.Columns("Labor Price").DefaultCellStyle.Format = "#,##0.#0"
            dgv_data.Columns("Labor Price").DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv_data.Columns("Overhead Price").Width = 175
            dgv_data.Columns("Overhead Price").DefaultCellStyle.Format = "#,##0.#0"
            dgv_data.Columns("Overhead Price").DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv_data.Columns("Standard Labor").Width = 175
            dgv_data.Columns("Standard Labor").DefaultCellStyle.Format = "#,##0.#0"
            dgv_data.Columns("Standard Labor").DefaultCellStyle.BackColor = Color.LemonChiffon
            dgv_data.Columns("Standard Overhead").Width = 175
            dgv_data.Columns("Standard Overhead").DefaultCellStyle.Format = "#,##0.#0"
            dgv_data.Columns("Standard Overhead").DefaultCellStyle.BackColor = Color.LemonChiffon
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub SaveData()
        Dim ObjTrans As SqlTransaction
        Dim row_old As DataRow


        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        ObjTrans = conn.BeginTransaction("Trans")
        cmd.Transaction = ObjTrans

        Try
            For Each row As DataRow In dtPrice.Rows
                If Not (row("Labor Price") = 0 And row("Overhead Price") = 0 And row("Standard Labor") = 0 And row("Standard Overhead") = 0) Then
                    Select Case dtMaintainPrice.Rows.Count
                        Case 0
                            cmd.CommandText = "EXEC sp_Insert_Maintain_SalesPrice_Jasa '" & _
                                                row("Jasa ID") & "', '" & _
                                                Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                userlog.UserName & "'"
                            cmd.ExecuteNonQuery()

                            cmd.CommandText = "EXEC sp_Insert_History_SalesPrice_Jasa '" & _
                                                row("Jasa ID") & "', '" & _
                                                Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                userlog.UserName & "'"
                            cmd.ExecuteNonQuery()
                        Case Else
                            row_old = dtMaintainPrice.Rows.Find(row("Jasa ID"))
                            If row_old IsNot Nothing Then
                                'Jika ada perubahan harga baru Save
                                If Replace(CStr(CDec(row_old("Labor Price"))), ",", ".") <> Replace(CStr(CDec(row("Labor Price"))), ",", ".") Or _
                                   Replace(CStr(CDec(row_old("Overhead Price"))), ",", ".") <> Replace(CStr(CDec(row("Overhead Price"))), ",", ".") Or _
                                   Replace(CStr(CDec(row_old("Standard Labor"))), ",", ".") <> Replace(CStr(CDec(row("Standard Labor"))), ",", ".") Or _
                                   Replace(CStr(CDec(row_old("Standard Overhead"))), ",", ".") <> Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") Then
                                    cmd.CommandText = "EXEC sp_Update_Maintain_SalesPrice_Jasa '" & _
                                                                                       row("Jasa ID") & "', '" & _
                                                                                       Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                                                       Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                                                       Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                                                       Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                                                       userlog.UserName & "'"
                                    cmd.ExecuteNonQuery()

                                    cmd.CommandText = "EXEC sp_Insert_History_SalesPrice_Jasa '" & _
                                                        row("Jasa ID") & "', '" & _
                                                        Replace(CStr(CDec(row_old("Labor Price"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row_old("Overhead Price"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row_old("Standard Labor"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row_old("Standard Overhead"))), ",", ".") & "', '" & _
                                                        Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                        userlog.UserName & "'"
                                    cmd.ExecuteNonQuery()
                                End If

                            Else
                                cmd.CommandText = "EXEC sp_Insert_Maintain_SalesPrice_Jasa '" & _
                                                    row("Jasa ID") & "', '" & _
                                                    Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                    userlog.UserName & "'"
                                cmd.ExecuteNonQuery()

                                cmd.CommandText = "EXEC sp_Insert_History_SalesPrice_Jasa '" & _
                                                    row("Jasa ID") & "', '" & _
                                                    Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Labor Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Overhead Price"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Labor"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                    Replace(CStr(CDec(row("Standard Overhead"))), ",", ".") & "', '" & _
                                                    userlog.UserName & "'"
                                cmd.ExecuteNonQuery()
                            End If
                    End Select
                End If
            Next
            ObjTrans.Commit()
            conn.Close()

            MessageBox.Show("Maintain Jasa Price Has been Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call RetrieveData()
        Catch ex As Exception
            MsgBox("SaveData: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handler"

    Private Sub frmMaintainSalesPriceJasa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn.ConnectionString = ConnectStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        SetAccess(Me, userlog.AccessID, Me.Name, ts_save)
        Call RetrieveData()
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Call SaveData()
    End Sub

    Private Sub txt_jasaid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_jasaid.KeyDown
        If e.KeyCode = Keys.F1 Then

            CallandGetSearchData("sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa", "Jasa ID", "Name", "Labor Price", "Overhead Price", "")

            If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                dtPrice.Clear()
                txt_jasaid.Text = frmSearch.txtResult1.Text.ToString.Trim
                Try
                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa_ByJasaID '" & txt_jasaid.Text & "'"
                    DA.SelectCommand = cmd
                    DA.Fill(dtPrice)
                    conn.Close()

                    If dtPrice.Rows.Count <> 0 Then
                        dgv_data.DataSource = dtPrice
                    End If
                Catch ex As Exception
                    MsgBox("txt_jasaid_KeyDown: " & ex.Message)
                End Try
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            dtPrice.Clear()
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            Select Case txt_jasaid.Text.Trim
                Case ""
                    cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa"
                    DA.SelectCommand = cmd
                    DA.Fill(dtPrice)

                Case Else
                    Try
                        cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa_ByJasaID '" & txt_jasaid.Text & "'"
                        DA.SelectCommand = cmd
                        DA.Fill(dtPrice)

                        If dtPrice.Rows.Count = 0 Then
                            cmd.CommandText = "EXEC sp_Retrieve_Maintain_SalesPrice_Jasa_BasedOnMasterJasa"
                            DA.SelectCommand = cmd
                            DA.Fill(dtPrice)

                            MsgBox("Jasa ID: " & txt_jasaid.Text.Trim & " isn't exist in database", MsgBoxStyle.Information, "Inforation")
                        End If
                    Catch ex As Exception
                        MsgBox("txt_jasaid_KeyDown: " & ex.Message)
                    End Try
            End Select
            conn.Close()
            dgv_data.DataSource = dtPrice
        End If
    End Sub

    Private Sub dgv_data_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv_data.DataError
        MessageBox.Show("Invalid numeric format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

#End Region
 
End Class