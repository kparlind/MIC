Imports System.IO
Imports System.Net
Imports System.Data.SqlClient
Imports MIS.GlobalVar
Public Class Frm_MasterStock
    Dim lv_filename1 As String
    Dim lv_filename2 As String

    Dim StatusTrans As String
    Dim lv_click As String

    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dtTemp As New DataTable
    Private Sub Frm_MasterStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitField()

        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()

        LoadGrid()
        'loadCbsearch()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtPict1.Text = OpenFileDialog1.FileName
        'lv_filename1 = OpenFileDialog1.SafeFileName
        PictureBox1.ImageLocation = txtPict1.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Load()
    End Sub

    Private Sub OpenFileDialog2_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        txtPict2.Text = OpenFileDialog2.FileName
        'lv_filename2 = OpenFileDialog2.SafeFileName
        PictureBox2.ImageLocation = txtPict2.Text
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.Load()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Call Upload Images Or File        
        Dim sFileToUpload As String = ""
        sFileToUpload = LTrim(RTrim(txtPict1.Text))
        Dim Extension As String = System.IO.Path.GetExtension(sFileToUpload)
        Dim path As String
        path = Application.StartupPath
        'Call the Upload method based on the type of file        
        If StrComp(Extension, ".bmp", CompareMethod.Text) = 0 Or _
        StrComp(Extension, ".jpg", CompareMethod.Text) = 0 Or _
        StrComp(Extension, ".jpeg", CompareMethod.Text) = 0 Or _
        StrComp(Extension, ".png", CompareMethod.Text) = 0 Or _
        StrComp(Extension, ".gif", CompareMethod.Text) = 0 Then
            If System.IO.Directory.Exists(path & "\UploadedImages\") Then
                FileCopy(sFileToUpload, path & "\UploadedImages\" & lv_filename1)
            Else
                System.IO.Directory.CreateDirectory(path & "\UploadedImages\")
                FileCopy(sFileToUpload, path & "\UploadedImages\" & lv_filename1)
            End If
            'Else
            '    'Pass the extension            
            '    upLoadImageOrFile(sFileToUpload, Extension)
        End If
    End Sub

    Private Sub InitField()
        txtStockID.Text = String.Empty
        txtNama.Text = String.Empty
        txtStockCategory.Text = String.Empty
        txtUnit.Text = String.Empty
        txtMerk.Text = String.Empty
        txtMinQty.Text = String.Empty
        txtNotes.Text = String.Empty
        txtWarehouse.Text = String.Empty
        txtLocation.Text = String.Empty
        txtPict1.Text = String.Empty
        txtPict2.Text = String.Empty
        If lv_click <> "Y" Then
            GridStock.DataSource = Nothing
        End If
        PictureBox1.ImageLocation = String.Empty

        PictureBox2.ImageLocation = String.Empty

    End Sub
    Private Sub SetEnabled(ByVal Flag As Boolean)
        txtStockID.Enabled = Flag
        txtNama.Enabled = Flag
        txtStockCategory.Enabled = Flag
        txtUnit.Enabled = Flag
        txtMerk.Enabled = Flag
        txtMinQty.Enabled = Flag
        txtNotes.Enabled = Flag
        txtWarehouse.Enabled = Flag
        txtLocation.Enabled = Flag
        txtPict1.Enabled = Flag
        txtPict2.Enabled = Flag
    End Sub
    Private Sub SetToolTip()
        Select Case UCase(StatusTrans)
            Case "NEW"
                btnEdit.Enabled = False
                btnNew.Enabled = False
                btnDelete.Enabled = False

                btnSave.Enabled = True

                btnFirst.Enabled = False
                btnNext.Enabled = False
                btnPrev.Enabled = False
                btnLast.Enabled = False

            Case "EDIT"
                btnEdit.Enabled = False
                btnNew.Enabled = False
                btnDelete.Enabled = False

                btnSave.Enabled = True

                btnFirst.Enabled = False
                btnNext.Enabled = False
                btnPrev.Enabled = False
                btnLast.Enabled = False
                SetEnabled(True)
            Case Else
                btnNew.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True

                btnSave.Enabled = False

                btnFirst.Enabled = True
                btnNext.Enabled = True
                btnPrev.Enabled = True
                btnLast.Enabled = True
        End Select
    End Sub
    Private Sub LoadGrid()
        Dim Conn As New SqlConnection
        Dim Cmd As New SqlCommand
        Dim DA As New SqlDataAdapter
        Dim dtTemp As New DataTable

        Try
            Conn.ConnectionString = GlobalVar.ConnString
            Conn.Open()

            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "exec sp_Retrieve_Master_Stock"
            DA.SelectCommand = Cmd
            DA.Fill(dtTemp)

            GridStock.DataSource = dtTemp

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GridStock_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridStock.CellDoubleClick
        Dim i As Integer
        i = GridStock.CurrentRow.Index
        txtStockID.Text = GridStock.Item(0, i).Value
        txtNama.Text = GridStock.Item(1, i).Value
        txtStockCategory.Text = GridStock.Item(2, i).Value
        txtUnit.Text = GridStock.Item(3, i).Value
        txtMerk.Text = GridStock.Item(4, i).Value
        txtMinQty.Text = GridStock.Item(5, i).Value
        txtNotes.Text = GridStock.Item(6, i).Value
        txtWarehouse.Text = GridStock.Item(7, i).Value
        txtLocation.Text = GridStock.Item(8, i).Value
        txtPict1.Text = GridStock.Item(9, i).Value
        txtPict2.Text = GridStock.Item(10, i).Value
        PictureBox1.ImageLocation = txtPict1.Text
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Load()
        PictureBox2.ImageLocation = txtPict2.Text
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.Load()
        lv_click = "Y"
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If StatusTrans = "NEW" OrElse StatusTrans = "EDIT" Then
            SetEnabled(False)
            StatusTrans = String.Empty
        Else
            'MoveLast()
            SetEnabled(False)
            StatusTrans = String.Empty
        End If
        SetToolTip()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        SetEnabled(True)

        StatusTrans = "EDIT"
        SetToolTip()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        SetEnabled(True)
        StatusTrans = "NEW"
        SetToolTip()
        InitField()
        LoadGrid()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = GlobalVar.ConnString
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Delete_Master_Stock '" & txtStockID.Text & "'"

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        MessageBox.Show("Data has been deleted !")
        GridStock.DataSource = Nothing
        LoadGrid()
        SetToolTip()
        InitField()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Call Upload Images Or File        
        Dim sFileToUpload1 As String = ""
        Dim sFileToUpload2 As String = ""
        sFileToUpload1 = LTrim(RTrim(txtPict1.Text))
        sFileToUpload2 = LTrim(RTrim(txtPict2.Text))
        Dim Extension1 As String = System.IO.Path.GetExtension(sFileToUpload1)
        Dim Extension2 As String = System.IO.Path.GetExtension(sFileToUpload2)
        Dim path As String
        path = Application.StartupPath
        Dim fullPath1 As String
        Dim fullPath2 As String
 
        fullPath1 = path & "\UploadedImages\" & lv_filename1
        fullPath2 = path & "\UploadedImages\" & lv_filename2
        If lv_click = "Y" Then
            Try
                Conn.ConnectionString = GlobalVar.ConnString
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Update_Master_Stock '" & txtStockID.Text & "', '" & txtNama.Text & "', '" _
                            & txtStockCategory.Text & "', '" & txtUnit.Text & "', '" & txtMerk.Text & "', '" _
                            & txtMinQty.Text & "', '" & txtNotes.Text & "', '" & txtWarehouse.Text & "', '" _
                            & txtLocation.Text & "', '" & fullPath1 & "', '" & fullPath2 & "', " _
                            & "'hhadiant', 'Y' "

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                Conn.ConnectionString = GlobalVar.ConnString
                Conn.Open()

                Cmd.Connection = Conn
                Cmd.CommandType = CommandType.Text

                Cmd.CommandText = "exec sp_Insert_Master_Stock '" & txtStockID.Text & "', '" & txtNama.Text & "', '" _
                            & txtStockCategory.Text & "', '" & txtUnit.Text & "', '" & txtMerk.Text & "', '" _
                            & txtMinQty.Text & "', '" & txtNotes.Text & "', '" & txtWarehouse.Text & "', '" _
                            & txtLocation.Text & "', '" & fullPath1 & "', '" & fullPath2 & "', " _
                            & " 'hhadiant', 'Y' "

                Cmd.ExecuteNonQuery()

                Conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        'Call the Upload method based on the type of file        
        If StrComp(Extension1, ".bmp", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".jpg", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".jpeg", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".png", CompareMethod.Text) = 0 Or _
        StrComp(Extension1, ".gif", CompareMethod.Text) = 0 Or _
        StrComp(Extension2, ".bmp", CompareMethod.Text) = 0 Or _
        StrComp(Extension2, ".jpg", CompareMethod.Text) = 0 Or _
        StrComp(Extension2, ".jpeg", CompareMethod.Text) = 0 Or _
        StrComp(Extension2, ".png", CompareMethod.Text) = 0 Or _
        StrComp(Extension2, ".gif", CompareMethod.Text) = 0 Then
            If System.IO.Directory.Exists(path & "\UploadedImages\") Then
                FileCopy(sFileToUpload1, path & "\UploadedImages\" & lv_filename1)
                FileCopy(sFileToUpload2, path & "\UploadedImages\" & lv_filename2)
            Else
                System.IO.Directory.CreateDirectory(path & "\UploadedImages\")
                FileCopy(sFileToUpload1, path & "\UploadedImages\" & lv_filename1)
                FileCopy(sFileToUpload2, path & "\UploadedImages\" & lv_filename2)
            End If
            'Else
            '    'Pass the extension            
            '    upLoadImageOrFile(sFileToUpload, Extension)
        End If

        MessageBox.Show("Save Succedded!!!")
        GridStock.DataSource = Nothing
        InitField()
        SetEnabled(False)
        StatusTrans = String.Empty
        SetToolTip()
        LoadGrid()
    End Sub
End Class