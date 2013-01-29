Imports MIS.mdlCommon
Imports MIS.GlobalVar
Imports System.Data.SqlClient

Public Class FrmMoU
    Dim action_stat As String
    Dim Conn As New SqlConnection
    Dim Cmd As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim dt_Hdr As New DataTable
    Dim dt_dtl As New DataTable
    Dim dt_checkProject As New DataTable
    Dim PrintQty As Integer
    Dim id_login As String
    Dim StatusID As String
    '==== Variable public to get Data from Mother Form==
    Public PHMNo As String
    Public GrandTotal As String
    Public RemarkMarketing As String
    Public Project As String

#Region "Interface"
    Private Sub FrmMoU_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = ConnectStr 'Set Default connection
        Cmd.Connection = Conn
        Cmd.CommandType = CommandType.Text

        'SetAccess(Me, userlog.AccessID, ViewFormName, Nothing, Nothing, Nothing, ts_save, Nothing, Nothing, Nothing, Nothing)
        ClearData()
        DisableButton(False)
        DisableTextBox(False)
        SetDefault()

        If PHMNo.Trim = "" Then
            MessageBox.Show("PH Marketing number is empty, Input MoU Aboorted." & vbCrLf & "Please make sure open valid PHMarketing document first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If
        If GrandTotal = "" Then
            MessageBox.Show("Grand Total of this Project is empty, Input MoU Aboorted." & vbCrLf & "Please make sure open valid PHMarketing document first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If

        txt_PnwaranHrg_marketing.Text = PHMNo

        txt51_sebesar.Text = GrandTotal
        txt_Project.Text = Project
        txt51_sebesar_Leave(Nothing, Nothing)
        txt13_kerjaan.Text = RemarkMarketing

        txt_TransNo.Clear()
        'get Mou base on PHM No
        txt_TransNo.Text = GetMoUID_And_CheckAuthorization(PHMNo)
        dt_MoU.Focus()

    End Sub


    Function GetMoUID_And_CheckAuthorization(ByVal PHMNo As String) As String
        Dim dt_MoU As New DataTable
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "Select Mou_iD,IsNUll(b.Project_No,'') as Project_No from Trans_Mou a " & _
                          "Left Join " & _
                          "Trans_Projects b " & _
                          "on a.PHM_No = b.PHM_No where a.PHM_No = '" + PHMNo + "' "
        DA.SelectCommand = Cmd
        DA.Fill(dt_MoU)

        If dt_MoU.Rows.Count > 0 Then
            GetMoUID_And_CheckAuthorization = dt_MoU.Rows(0).Item("MoU_ID").ToString.Trim
            If dt_MoU.Rows(0).Item("Project_No").ToString.Trim <> "" Then 'Jika Nomor Project sdh terbentuk maka MoU sdh tidak bs direvisi                
                ts_save.Enabled = False
                ts_cancel.Enabled = False
                GetDataMoU(dt_MoU.Rows(0).Item("MoU_ID").ToString.Trim)
                DisableTextBox(False)
            Else
                ts_save.Enabled = True
                ts_cancel.Enabled = True
                GetDataMoU(dt_MoU.Rows(0).Item("MoU_ID").ToString.Trim)
            End If
        Else
            GetMoUID_And_CheckAuthorization = ""
            ts_save.Enabled = True
            ts_cancel.Enabled = True
        End If
    End Function

    Private Sub SetDefault()
        txt_nama2.Text = "Agustien Kantiana"
        txt_jabatan2.Text = "Direktur"
        txt_company2.Text = "PT.Mitra IntiCitra Elpindo"
        txt_alamat2.Text = "Jl. Pulau Belitung No.12, Denpasar, Bali"

        txt_Nama1.Text = "KRISTANTO"
        txt_jabatan1.Text = "CEO"
        txt_company1.Text = "FECASA"
        txt_alamat1.Text = "LIPPO KARAWACI"

        txt11_Pekerjaan.Text = "Pembuatan Aplikasi MIC"
        txt13_kerjaan.Text = "Pembuatan Aplikasi MIC untuk Instalasi"
        txt14_garansi.Text = "1"

        txt41_DP.Text = "50"
        txt61_wktperngerjaan.Text = "10"
        txt61_untuk.Text = "Iseng berhadiah aja"
        txt71_hari.Text = "20"

    End Sub
    Private Sub DisableButton(ByVal boo As Boolean)
        ts_Edit.Enabled = boo
        ts_save.Enabled = boo
        ts_cancel.Enabled = boo
    End Sub

    Private Sub GetDataMoU(ByVal TransNo As String)
        'Pindahin dr datatable PO ke datatable TrmBrg  
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

        Cmd.CommandText = "EXEC sp_retreiveMoU_byKey '" + TransNo.Trim + "'"
        DA.SelectCommand = Cmd
        DA.Fill(dt_Hdr)

        If dt_Hdr.Rows.Count > 0 Then
            txt_Project.Text = dt_Hdr.Rows(0).Item("Project_Name").ToString.Trim
            txt_Nama1.Text = dt_Hdr.Rows(0).Item("Pihak1_Name").ToString.Trim
            txt_jabatan1.Text = dt_Hdr.Rows(0).Item("Pihak1_Jabatan").ToString.Trim
            txt_company1.Text = dt_Hdr.Rows(0).Item("Pihak1_Company").ToString.Trim
            txt_alamat1.Text = dt_Hdr.Rows(0).Item("Pihak1_Alamat").ToString.Trim
            txt_nama2.Text = dt_Hdr.Rows(0).Item("Pihak2_nama").ToString.Trim
            txt_jabatan2.Text = dt_Hdr.Rows(0).Item("Pihak2_jabatan").ToString.Trim
            txt_company2.Text = dt_Hdr.Rows(0).Item("Pihak2_company").ToString.Trim
            txt_alamat2.Text = dt_Hdr.Rows(0).Item("Pihak2_alamat").ToString.Trim
            txt11_Pekerjaan.Text = dt_Hdr.Rows(0).Item("Pasal11_Pekerjaan").ToString.Trim
            txt13_kerjaan.Text = dt_Hdr.Rows(0).Item("Pasal13_Kerjaan").ToString.Trim
            txt13_meliputi.Text = dt_Hdr.Rows(0).Item("Pasal13_meliputi").ToString.Trim
            txt14_garansi.Text = dt_Hdr.Rows(0).Item("Pasal14_garansi").ToString.Trim
            txt41_DP.Text = dt_Hdr.Rows(0).Item("Pasal41_DP").ToString.Trim
            txt51_sebesar.Text = dt_Hdr.Rows(0).Item("Pasal51_sebesar").ToString.Trim
            txt61_wktperngerjaan.Text = dt_Hdr.Rows(0).Item("Pasal61_wktperngerjaan").ToString.Trim
            dt61_from.Value = dt_Hdr.Rows(0).Item("Pasal61_From")
            dt61_to.Value = dt_Hdr.Rows(0).Item("Pasal61_To")
            txt61_untuk.Text = dt_Hdr.Rows(0).Item("Pasal61_untuk").ToString.Trim
            txt71_hari.Text = dt_Hdr.Rows(0).Item("Pasal71_hari").ToString.Trim
            txt_Retention.Text = dt_Hdr.Rows(0).Item("Retention").ToString.Trim
            txt_Cicilan.Text = dt_Hdr.Rows(0).Item("Cicilan").ToString.Trim
            PrintQty = dt_Hdr.Rows(0).Item("Print_Total")
        End If
    End Sub

    Private Sub ClearData()
        StatusID = ""
        txt_Project.Clear()
        txt_Nama1.Clear()
        txt_jabatan1.Clear()
        txt_company1.Clear()
        txt_alamat1.Clear()

        txt_nama2.Clear()
        txt_jabatan2.Clear()
        txt_company2.Clear()
        txt_alamat2.Clear()

        txt11_Pekerjaan.Clear()
        txt13_kerjaan.Clear()
        txt13_meliputi.Clear()
        txt14_garansi.Clear()

        txt41_DP.Clear()

        txt51_sebesar.Clear()
        lbl_terbilang.Text = "<terbilang>"

        txt61_wktperngerjaan.Clear()
        txt61_untuk.Clear()

        txt71_hari.Clear()

    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        ClearData()
        dt_MoU.Focus()
    End Sub
#End Region

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim sql As String
        Dim dt_check As New DataTable
        Dim seqNum As Integer
        Dim retention As String = ""
        Dim cicilan As String = ""
        Dim sebesar As String = ""
        Dim LastSerial As Integer
        Dim total_Check As Decimal

        If txt_Project.Text.Trim = "" Or txt_Nama1.Text.Trim = "" Or txt_jabatan1.Text.Trim = "" Or txt_company1.Text.Trim = "" Or _
            txt_alamat1.Text.Trim = "" Or txt_nama2.Text.Trim = "" Or txt_jabatan2.Text.Trim = "" Or _
            txt_company2.Text.Trim = "" Or txt_alamat2.Text.Trim = "" Or txt11_Pekerjaan.Text.Trim = "" Or _
            txt13_kerjaan.Text.Trim = "" Or txt13_meliputi.Text.Trim = "" Or txt14_garansi.Text.Trim = "" Or _
            txt41_DP.Text.Trim = "" Or txt51_sebesar.Text.Trim = "" Or txt61_wktperngerjaan.Text.Trim = "" Or _
            txt61_untuk.Text.Trim = "" Or txt71_hari.Text.Trim = "" Then
            MessageBox.Show("All Input must be Filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txt_Retention.Text.Trim = "" Or txt_Cicilan.Text.Trim = "" Then
            MessageBox.Show("Retention and Cicilan must be Filled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        total_Check = CDec(txt_DPAmount.Text) + CDec(txt_Cicilan.Text) + CDec(txt_Retention.Text)

        If CDec(txt51_sebesar.Text) <> total_Check Then
            MessageBox.Show("All Summary Retention, DP and Cicilan must have the SAME amount with Amount of this Project. Please Check again those amount.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        sql = "Select PHM_No,PHM_Date,b.PHP_No as Penwaran_project, b.Survey_No,d.Nama as Cust_Name from " & Chr(13) & _
              "Trans_PHMarketing_Hdr a " & Chr(13) & _
              "Left join Trans_PHProject_Hdr b on a.PHP_No = b.PHP_No " & Chr(13) & _
              "Left join Trans_Survey_Hdr c on c.Survey_No = b.Survey_No " & Chr(13) & _
              "Left join Master_Customer d on c.Cust_ID = d.Cust_ID " & Chr(13) & _
              "where PHM_No = '" & txt_PnwaranHrg_marketing.Text.Trim & "'"
        Cmd.CommandText = sql
        DA.SelectCommand = Cmd
        DA.Fill(dt_check)

        If dt_check.Rows.Count = 0 Then
            MessageBox.Show("Penawaran Harga Marketing Not Found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
            End If

            retention = Replace(txt_Retention.Text.Trim, ",", "")
            cicilan = Replace(txt_Cicilan.Text.Trim, ",", "")
            sebesar = Replace(txt51_sebesar.Text.Trim, ",", "")

            If txt_TransNo.Text.Trim <> "" Then
                Cmd.CommandText = "EXEC sp_Update_Trans_MoU '" & _
                                    txt_TransNo.Text.Trim & "','" & _
                                    txt_PnwaranHrg_marketing.Text.Trim & "','" & _
                                    seqNum & "','" & _dt_MoU.Value.ToString("yyyy-MM-dd") & "','" & dt_MoU.Value.ToString("yyyy-MM-dd") & "','" & _
                                    txt_Project.Text.Trim & "','" & _
                                    txt_Nama1.Text.Trim & "','" & _
                                    txt_jabatan1.Text.Trim & "','" & _
                                    txt_company1.Text.Trim & "','" & _
                                    txt_alamat1.Text.Trim & "','" & _
                                    txt_nama2.Text.Trim & "','" & _
                                    txt_jabatan2.Text.Trim & "','" & _
                                    txt_company2.Text.Trim & "','" & _
                                    txt_alamat2.Text.Trim & "','" & _
                                    txt11_Pekerjaan.Text.Trim & "','" & _
                                    txt13_kerjaan.Text.Trim & "','" & _
                                    txt13_meliputi.Text.Trim & "','" & _
                                    txt14_garansi.Text.Trim & "'," & _
                                    txt41_DP.Text.Trim & "," & _
                                    sebesar & ",'" & _
                                    txt61_wktperngerjaan.Text.Trim & "','" & dt61_from.Value.ToString("yyyy-MM-dd") & "','" & dt61_to.Value.ToString("yyyy-MM-dd") & "','" & _
                                    txt61_untuk.Text.Trim & "'," & _
                                    txt71_hari.Text.Trim & "," & _
                                    retention & "," & _
                                    cicilan & "," & _
                                    PrintQty + 1 & ",'" & _
                                    StatusID & "','" & _
                                    userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
            Else
                PrintQty = 0 'Reset
                txt_TransNo.Text = Generate_TranNo("frmMoU")
                LastSerial = CInt(Microsoft.VisualBasic.Right(txt_TransNo.Text, 3))
                Cmd.CommandText = "EXEC sp_Insert_Trans_MoU '" & _
                                    txt_TransNo.Text.Trim & "','" & _
                                    txt_PnwaranHrg_marketing.Text.Trim & "'," & _
                                    seqNum & ",'" & dt_MoU.Value.ToString("yyyy-MM-dd") & "','" & dt_MoU.Value.ToString("yyyy-MM-dd") & "','" & _
                                    txt_Project.Text.Trim & "','" & _
                                    txt_Nama1.Text.Trim & "','" & _
                                    txt_jabatan1.Text.Trim & "','" & _
                                    txt_company1.Text.Trim & "','" & _
                                    txt_alamat1.Text.Trim & "','" & _
                                    txt_nama2.Text.Trim & "','" & _
                                    txt_jabatan2.Text.Trim & "','" & _
                                    txt_company2.Text.Trim & "','" & _
                                    txt_alamat2.Text.Trim & "','" & _
                                    txt11_Pekerjaan.Text.Trim & "','" & _
                                    txt13_kerjaan.Text.Trim & "','" & _
                                    txt13_meliputi.Text.Trim & "','" & _
                                    txt14_garansi.Text.Trim & "'," & _
                                    txt41_DP.Text.Trim & "," & _
                                    sebesar & ",'" & _
                                    txt61_wktperngerjaan.Text.Trim & "','" & dt61_from.Value.ToString("yyyy-MM-dd") & "','" & dt61_to.Value.ToString("yyyy-MM-dd") & "','" & _
                                    txt61_untuk.Text.Trim & "'," & _
                                    txt71_hari.Text.Trim & "," & _
                                    retention & "," & _
                                    cicilan & "," & _
                                    PrintQty + 1 & ",'" & _
                                    StatusID & "','" & _
                                    userlog.UserName & "'"
                Cmd.ExecuteNonQuery()
            End If
            UpdateSerial(Me.Name, Month(Now), Year(Now), LastSerial, userlog.UserName)
            Conn.Close()
            MessageBox.Show("MoU document : " & txt_TransNo.Text.Trim & " Has been Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'If LoadFromView Then 'jika form ini dipanggil dari View
            '    Me.Close()
            'Else
            '    FrmMoU_Load(Nothing, Nothing)
            'End If
        Catch ex As Exception
            Conn.Close()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_PnwaranHrg_marketing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_PnwaranHrg_marketing.KeyDown
        Dim sql As String
        Dim dt As New DataTable
        If e.KeyCode = Keys.F1 Then
            Try
                sql = "Select PHM_No,PHM_Date,b.PHP_No as Penwaran_project, b.Survey_No,d.Nama as Cust_Name from " & Chr(13) & _
                      "Trans_PHMarketing_Hdr a " & Chr(13) & _
                      "Left join Trans_PHProject_Hdr b on a.PHP_No = b.PHP_No " & Chr(13) & _
                      "Left join Trans_Survey_Hdr c on c.Survey_No = b.Survey_No " & Chr(13) & _
                      "Left join Master_Customer d on c.Cust_ID = d.Cust_ID " & Chr(13) & _
                      "where a.Status_ID = 'CMP'"
                CallandGetSearchData(Sql, "PHM_No", "PHM_Date", "Penwaran_Project", "Survey_No", "Cust_Name")
                If frmSearch.txtResult1.Text.ToString.Trim <> "" Then
                    txt_PnwaranHrg_marketing.Text = frmSearch.txtResult1.Text.ToString.Trim
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Conn.Close()
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_PnwaranHrg_marketing.Text.Trim Then
                sql = "Select PHM_No,PHM_Date,b.PHP_No as Penwaran_project, b.Survey_No,d.Nama as Cust_Name from " & Chr(13) & _
                      "Trans_PHMarketing_Hdr a " & Chr(13) & _
                      "Left join Trans_PHProject_Hdr b on a.PHP_No = b.PHP_No " & Chr(13) & _
                      "Left join Trans_Survey_Hdr c on c.Survey_No = b.Survey_No " & Chr(13) & _
                      "Left join Master_Customer d on c.Cust_ID = d.Cust_ID " & Chr(13) & _
                      "where a.Status_ID = 'CMP' and PHM_No = '" & txt_PnwaranHrg_marketing.Text.Trim & "'"
                Cmd.CommandText = Sql
                DA.SelectCommand = Cmd
                DA.Fill(dt)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Penawaran Harga Marketing Not Found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        End If
        Conn.Close()
    End Sub

    Private Sub ts_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_Edit.Click
        DisableTextBox(True)
        ts_Edit.Enabled = False
        ts_save.Enabled = True
        ts_cancel.Enabled = True
    End Sub

    Private Sub DisableTextBox(ByVal boo As Boolean)
        For Each c As Control In Me.Controls
            If TypeOf (c) Is TextBox Then
                CType(c, TextBox).Enabled = boo
            End If
        Next
    End Sub

    Private Sub txt51_sebesar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt51_sebesar_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If txt51_sebesar.Text.Trim <> "" Then
            lbl_terbilang.Text = Terbilang(txt51_sebesar.Text.Trim) + " Rupiah."
        End If
    End Sub

    Function Generate_reports() As String
        Dim tmp As String
        tmp = "                                                    SURAT KONTRAK KERJASAMA" & vbCrLf & _
              "                                          PENGERJAAN INSTALASI PIPA GAS LPG PLATINUM GRILL" & vbCrLf & _
              "                                                    NO.KONTRAK  : " & Generate_TranNo("ContractNo") & vbCrLf & _
              "" & vbCrLf & _
              "Pada hari ini tanggal " & dt_MoU.Value.ToString("dd-MMMM-yyyy") & ",bertempat di bali, kami yang bertandatangan dibawah ini:" & vbCrLf & _
              " I  Nama	           : " & txt_Nama1.Text.Trim & vbCrLf & _
              "	    Jabatan	        : " & txt_jabatan1.Text.Trim & vbCrLf & _
              "	    Perusahaan	 : " & txt_company1.Text.Trim & vbCrLf & _
              "	    Alamat	         : " & txt_alamat1.Text.Trim & vbCrLf & _
              "" & vbCrLf & _
              "Dalam hal ini bertindak didalam jabatan tersebut diatas untuk dan atas nama " & txt_company1.Text.Trim & " selaku " & vbCrLf & _
              "pemilik, selanjutnya disebut sebagai Pihak Pertama." & vbCrLf & _
              " II Nama	            : " & txt_nama2.Text.Trim & vbCrLf & _
              "	    Jabatan	         : " & txt_jabatan2.Text.Trim & vbCrLf & _
              "	    Perusahaan   : " & txt_company2.Text.Trim & vbCrLf & _
              "	    Alamat	          : " & txt_alamat2.Text.Trim & vbCrLf & _
              "" & vbCrLf & _
              "Dalam hal ini bertindak untuk dan atas nama " & txt_company2.Text.Trim & ", selanjutnya disebut sebagai pihak kedua. " & vbCrLf & _
              "Kedua belah pihak telah sepakat mengadakan ikatan kontrak dalam melaksanakan pekerjaan dengan " & vbCrLf & _
              "ketentuan sebagai berikut : " & vbCrLf & _
              "" & vbCrLf & _
              "                                                           PASAL 1 " & vbCrLf & _
              "                                                   RUANG LINGKUP PEKERJAAN" & vbCrLf & _
              "" & vbCrLf & _
              "1.1  PIHAK PERTAMA memberikan tugas kepada PIHAK KEDUA, dan PIHAK KEDUA menerima tugas " & vbCrLf & _
              "       dalam melaksanakan pekerjaan " & txt11_Pekerjaan.Text.Trim & vbCrLf & _
              "1.2  PIHAK KEDUA bertanggung jawab sampai selesainya seluruh pekerjan tersebut diatas sesuai " & vbCrLf & _
              "       dengan Surat Penawaran Harga yang telah disetujui oleh PIHAK PERTAMA. " & vbCrLf & _
              "1.3  PIHAK KEDUA Mengerjakan " & txt13_kerjaan.Text.Trim & " untuk PIHAK PERTAMA " & vbCrLf & _
              "       meliputi :" & vbCrLf & _
              "     " & txt13_meliputi.Text.Trim & vbCrLf & _
              "1.4  PIHAK KEDUA Memberikan garansi selama " & txt14_garansi.Text.Trim & " tahun kepada PIHAK PERTAMA atas hasil kerja " & vbCrLf & _
              "       Instalasi Gas LPG " & vbCrLf & _
              "" & vbCrLf & _
              "                                                           PASAL 2 " & vbCrLf & _
              "                                                  PENGAWASAN & PENGERJAAN" & vbCrLf & _
              "" & vbCrLf & _
              "2.1  Pengawasan pelaksanaan pekerjaan kontrak ini akan dilaksanakan oleh PIHAK PERTAMA." & vbCrLf & _
              "2.2  PIHAK KEDUA harus melakukan pekerjaan sesuai dengan perintah dan petunjuk PIHAK " & vbCrLf & _
              "       PERTAMA menurut batasan-btasan yang telah ditentukan." & vbCrLf & _
              "2.3  PIHAK KEDUA mengerjakan sesuai dengan waktu yang telah ditetapkan, apabila pada prakteknya " & vbCrLf & _
              "       terjadi perubahan yang mengakibatkan ketelambatan yang disebabkan oleh PIHAK PERTAMA, maka " & vbCrLf & _
              "       seluruh biaya akomodasi diluar jadwal menjadi beban PIHAK PERTAMA. " & vbCrLf & _
              "" & vbCrLf & _
              "                                                          PASAL 3 " & vbCrLf & _
              "                                         KEWAJIBAN PIHAK KEDUA DAN PIHAK PERTAMA" & vbCrLf & _
              "" & vbCrLf & _
              "3.1  PIHAK KEDUA wajib menyelesaikan pekerjaan dengan lengkap sesuai dengan perjanjian yang " & vbCrLf & _
              "       telah ditetapkan oleh PIHAK PERTAMA. PIHAK PERTAMA mempertimbangkan /  menilai " & vbCrLf & _
              "       penyelesaian pekerjaan tersebut serta membayar ke PIHAK KEDUA sebesar nilai kontraknya " & vbCrLf & _
              "       pada waktu dan cara yang telah ditentukan dalam kontrak. " & vbCrLf & _
              "3.2  PIHAK KEDUA akan melakukan pengerjaan instalasi sesuai jadwal yang telah ditetapkan." & vbCrLf & _
              "" & vbCrLf & _
              "                                                         PASAL 4 " & vbCrLf & _
              "                                                   TATA CARA PEMBAYARAN" & vbCrLf & _
              "" & vbCrLf & _
              "4.1  Pembayaran nilai kontrak : " & vbCrLf & _
              "       Dilaksanakan sesuai kesepakatan bersama DP " & txt41_DP.Text.Trim & "% setelah SPK diterima oleh PIHAK KEDUA " & vbCrLf & _
              "       dan " & txt41_DP.Text.Trim & "% setelah pekerjaan selesai dan dilengkapi laporan progress pekerjaan serta" & vbCrLf & _
              "       dokumen serah terima." & vbCrLf & _
              "" & vbCrLf & _
              "                                                          PASAL 5 " & vbCrLf & _
              "                                                       NILAI KONTRAK " & vbCrLf & _
              "" & vbCrLf & _
              "5.1  Nilai pekerjaan adalah sebagai berikut :" & vbCrLf & _
              "         Sebesar   : " & txt51_sebesar.Text.Trim & vbCrLf & _
              "         Terbilang : " & lbl_terbilang.Text.Trim & vbCrLf & _
              "" & vbCrLf & _
              "                                                          PASAL 6 " & vbCrLf & _
              "                                                      WAKTU PELAKSANAAN " & vbCrLf & _
              "" & vbCrLf & _
              "6.1 Waktu pelaksanaan untuk pekerjaan tersebut diatas adalah " & txt61_wktperngerjaan.Text.Trim & " hari kerja terhitung sejak " & vbCrLf & _
              "      tanggal " & dt61_from.Value.ToString("dd-MMMM-yyyy") & " sampai dengan tanggal " & dt61_to.Value.ToString("dd-MMMM-yyyy") & ", untuk " & txt61_untuk.Text.Trim & vbCrLf & _
              "" & vbCrLf & _
              "                                                           PASAL 7 " & vbCrLf & _
              "                                                          LAIN-LAIN" & vbCrLf & _
              "" & vbCrLf & _
              "7.1  Kedua belah pihak akan melakukan koordinasi dalam pekerjaan instalasi tersebut." & vbCrLf & _
              "7.2  PIHAK KEDUA akan mengerjakan Instalasi berdasarkan penyesuaian gambar Lay-Out dari PIHAK PERTAMA." & vbCrLf & _
              "7.3  Segala perubahan yang terjadi dilapangan, akan dikomunikasikan kedua belah Pihak minimal " & vbCrLf & _
              "       " & txt71_hari.Text.Trim & " hari dari eksekusi pengerjaan perubahan." & vbCrLf & _
              "" & vbCrLf & _
              "Demikian Surat Perjanjian Pemborongan ini dibuat rangkap dua yang masing-masing mempunyai kekuataan hukum yang sama." & vbCrLf & _
              "" & vbCrLf & _
              "                                                           Mengetahui," & vbCrLf & _
              "" & vbCrLf & _
              "         PIHAK II,						 		                                                                                             PIHAK I " & vbCrLf & _
              "" & vbCrLf & _
              "       " & txt_company1.Text.Trim & vbCrLf & _
              "" & vbCrLf & _
              "" & vbCrLf & _
              "     (Agustien Kantiana)                                                                        (" & txt_Nama1.Text.Trim & ")" & vbCrLf & _
              ""
        Generate_reports = tmp
    End Function

    Private Sub ts_preview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_preview.Click

        Dim frmChild As New frmReport

        frmChild.ReportName = "Form MoU"
        frmChild.ContractLetter = Generate_reports()

        For Each f As Form In Me.MdiChildren
            If f.Name = "Form MoU" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
    End Sub

    Private Sub txt71_hari_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt61_wktperngerjaan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt41_DP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt14_garansi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Retention_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Retention.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Cicilan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Cicilan.KeyPress
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_DPPersen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_DPAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not enterNumeric(Asc(e.KeyChar)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txt_Retention_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Retention.LostFocus
        If txt_Retention.Text.Trim = "" Then Exit Sub
        txt_Retention.Text = FormatAngka(txt_Retention.Text)
    End Sub

    Private Sub txt_Cicilan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Cicilan.LostFocus
        If txt_Cicilan.Text.Trim = "" Then Exit Sub
        txt_Cicilan.Text = FormatAngka(txt_Cicilan.Text)
    End Sub

    Private Sub txt41_DP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt41_DP.Leave
        If txt41_DP.Text.Trim = "" Then Exit Sub
        txt_DPAmount.Text = FormatAngka((CDec(txt41_DP.Text) * CDec(txt51_sebesar.Text)) / 100)
    End Sub

    Private Sub txt51_sebesar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt51_sebesar.TextChanged
        If txt41_DP.Text.Trim = "" And txt51_sebesar.Text.Trim = "" Then Exit Sub
        txt_DPAmount.Text = FormatAngka((CDec(txt41_DP.Text) * CDec(txt51_sebesar.Text)) / 100)
    End Sub


End Class