Imports MIS.GlobalVar
Imports MIS.mdlCommon
Imports System.Data.SqlClient

Public Class frmQuestionnaire

#Region "Variable Declaration"
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public DA As New SqlDataAdapter
    Public StatusTRans As String
    Public Prefix As String
    Dim Customer As String
    Dim Supplier As String
#End Region

#Region "Function & Procedure"

    Public Sub SetToolTip()
        Select Case UCase(StatusTRans)
            Case TransStatus.NewStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = True
                btn_cancel.Enabled = True
            Case TransStatus.EditStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = True
                btn_cancel.Enabled = True
            Case TransStatus.FindStatus
                btn_edit.Enabled = False
                btn_delete.Enabled = False
                btn_save.Enabled = False
                btn_cancel.Enabled = True
            Case Else
                btn_edit.Enabled = True
                btn_delete.Enabled = True
                btn_save.Enabled = False
                btn_cancel.Enabled = False
        End Select
    End Sub

    Sub InsertData()
        Dim answer1_1 As Integer = 0
        Dim answer1_2 As Integer = 0
        Dim answer1_3 As Integer = 0
        Dim answer1_4 As Integer = 0
        Dim answer1_5 As Integer = 0

        Dim answer2_1 As Integer = 0
        Dim answer2_2 As Integer = 0
        Dim answer2_3 As Integer = 0
        Dim answer2_4 As Integer = 0
        Dim answer2_5 As Integer = 0

        Dim answer3_1 As Integer = 0
        Dim answer3_2 As Integer = 0
        Dim answer3_3 As Integer = 0
        Dim answer3_4 As Integer = 0
        Dim answer3_5 As Integer = 0

        Dim answer4_1 As Integer = 0
        Dim answer4_2 As Integer = 0
        Dim answer4_3 As Integer = 0
        Dim answer4_4 As Integer = 0
        Dim answer4_5 As Integer = 0

        Dim answer5_1 As Integer = 0
        Dim answer5_2 As Integer = 0
        Dim answer5_3 As Integer = 0
        Dim answer5_4 As Integer = 0
        Dim answer5_5 As Integer = 0

        Dim TTL_Quest As Integer
        Dim Average As Decimal
        Dim TTL_Score As Integer

        Dim TTL_Quest_Section As Integer
        Dim TTL_Score_Section As Integer
        Dim AverageSection1 As Decimal
        Dim AverageSection2 As Decimal
        Dim AverageSection3 As Decimal
        Dim AverageSection4 As Decimal
        Dim AverageSection5 As Decimal

        Dim LastSerial As Integer
        Dim GetCurrYear As Integer
        Dim GetCurrMonth As Integer

        GetCurrYear = Microsoft.VisualBasic.Right(Today.Year.ToString, 2)
        GetCurrMonth = Today.Month

        TTL_Score = 0
        TTL_Quest = 0
        TTL_Score_Section = 0
        TTL_Quest_Section = 0

        If StatusTRans = TransStatus.NewStatus OrElse StatusTRans = TransStatus.EditStatus Then
            If conn.State = ConnectionState.Open Then conn.Close()
            If rbQuest1_1_1.Checked = True Then
                answer1_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_2.Checked = True Then
                answer1_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_3.Checked = True Then
                answer1_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_4.Checked = True Then
                answer1_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_2_1.Checked = True Then
                answer1_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1

            ElseIf rbQuest1_2_2.Checked = True Then
                answer1_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_2_3.Checked = True Then
                answer1_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_2_4.Checked = True Then
                answer1_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_3_1.Checked = True Then
                answer1_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_2.Checked = True Then
                answer1_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_3.Checked = True Then
                answer1_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_4.Checked = True Then
                answer1_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_4_1.Checked = True Then
                answer1_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_2.Checked = True Then
                answer1_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_3.Checked = True Then
                answer1_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_4.Checked = True Then
                answer1_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_5_1.Checked = True Then
                answer1_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_2.Checked = True Then
                answer1_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_3.Checked = True Then
                answer1_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_4.Checked = True Then
                answer1_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection1 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection1 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest2_1_1.Checked = True Then
                answer2_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_2.Checked = True Then
                answer2_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_3.Checked = True Then
                answer2_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_4.Checked = True Then
                answer2_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_2_1.Checked = True Then
                answer2_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_2.Checked = True Then
                answer2_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_3.Checked = True Then
                answer2_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_4.Checked = True Then
                answer2_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_3_1.Checked = True Then
                answer2_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_2.Checked = True Then
                answer2_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_3.Checked = True Then
                answer2_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_4.Checked = True Then
                answer2_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_4_1.Checked = True Then
                answer2_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_2.Checked = True Then
                answer2_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_3.Checked = True Then
                answer2_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_4.Checked = True Then
                answer2_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_5_1.Checked = True Then
                answer2_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_2.Checked = True Then
                answer2_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_3.Checked = True Then
                answer2_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_4.Checked = True Then
                answer2_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection2 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection2 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest3_1_1.Checked = True Then
                answer3_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_2.Checked = True Then
                answer3_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_3.Checked = True Then
                answer3_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_4.Checked = True Then
                answer3_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_2_1.Checked = True Then
                answer3_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_2.Checked = True Then
                answer3_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_3.Checked = True Then
                answer3_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_4.Checked = True Then
                answer3_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_3_1.Checked = True Then
                answer3_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_2.Checked = True Then
                answer3_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_3.Checked = True Then
                answer3_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_4.Checked = True Then
                answer3_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_4_1.Checked = True Then
                answer3_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_2.Checked = True Then
                answer3_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_3.Checked = True Then
                answer3_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_4.Checked = True Then
                answer3_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_5_1.Checked = True Then
                answer3_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_2.Checked = True Then
                answer3_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_3.Checked = True Then
                answer3_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 3
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_4.Checked = True Then
                answer3_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection3 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection3 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest4_1_1.Checked = True Then
                answer4_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_2.Checked = True Then
                answer4_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_3.Checked = True Then
                answer4_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_4.Checked = True Then
                answer4_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_2_1.Checked = True Then
                answer4_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_2.Checked = True Then
                answer4_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_3.Checked = True Then
                answer4_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_4.Checked = True Then
                answer4_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_3_1.Checked = True Then
                answer4_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_2.Checked = True Then
                answer4_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_3.Checked = True Then
                answer4_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_4.Checked = True Then
                answer4_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_4_1.Checked = True Then
                answer4_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_2.Checked = True Then
                answer4_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_3.Checked = True Then
                answer4_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_4.Checked = True Then
                answer4_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_5_1.Checked = True Then
                answer4_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_5_2.Checked = True Then
                answer4_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_5_3.Checked = True Then
                answer4_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_4.Checked = True Then
                answer4_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection4 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection4 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest5_1_1.Checked = True Then
                answer5_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_2.Checked = True Then
                answer5_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_3.Checked = True Then
                answer5_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_4.Checked = True Then
                answer5_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_2_1.Checked = True Then
                answer5_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_2.Checked = True Then
                answer5_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_3.Checked = True Then
                answer5_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_4.Checked = True Then
                answer5_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_3_1.Checked = True Then
                answer5_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_2.Checked = True Then
                answer5_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_3.Checked = True Then
                answer5_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_4.Checked = True Then
                answer5_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_4_1.Checked = True Then
                answer5_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_2.Checked = True Then
                answer5_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_3.Checked = True Then
                answer5_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_4.Checked = True Then
                answer5_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_5_1.Checked = True Then
                answer5_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_2.Checked = True Then
                answer5_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_3.Checked = True Then
                answer5_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_4.Checked = True Then
                answer1_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection5 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection5 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            Average = TTL_Score / TTL_Quest

            txtQuestID.Text = Generate_TranNo(Me.Name & Prefix)

            conn.Open()
            cmd.CommandText = "EXEC sp_Insert_Trans_Questionnaire '" & _
                    txtQuestID.Text & "', '" & _
                    txtSetID.Text & "', '" & _
                    Customer & "', '" & _
                    Supplier & "', '" & _
                    txtProject1.Text.Trim & "', '" & _
                    txtProject2.Text.Trim & "', '" & _
                    txtProject3.Text.Trim & "', '" & _
                    txtRespondentName.Text.Trim & "', '" & _
                    txtJabatan.Text.Trim & "', '" & _
                    Format(dtpQuest.Value, "MM-dd-yyyy") & "', '" & _
                    answer1_1 & "', '" & _
                    answer1_2 & "', '" & _
                    answer1_3 & "', '" & _
                    answer1_4 & "', '" & _
                    answer1_5 & "', '" & _
                    answer2_1 & "', '" & _
                    answer2_2 & "', '" & _
                    answer2_3 & "', '" & _
                    answer2_4 & "', '" & _
                    answer2_5 & "', '" & _
                    answer3_1 & "', '" & _
                    answer3_2 & "', '" & _
                    answer3_3 & "', '" & _
                    answer3_4 & "', '" & _
                    answer3_5 & "', '" & _
                    answer4_1 & "', '" & _
                    answer4_2 & "', '" & _
                    answer4_3 & "', '" & _
                    answer4_4 & "', '" & _
                    answer4_5 & "', '" & _
                    answer5_1 & "', '" & _
                    answer5_2 & "', '" & _
                    answer5_3 & "', '" & _
                    answer5_4 & "', '" & _
                    answer5_5 & "', '" & _
                    txtRemark1_1.Text.Trim & "', '" & _
                    txtRemark1_2.Text.Trim & "', '" & _
                    txtRemark1_3.Text.Trim & "', '" & _
                    txtRemark1_4.Text.Trim & "', '" & _
                    txtRemark1_5.Text.Trim & "', '" & _
                    txtRemark2_1.Text.Trim & "', '" & _
                    txtRemark2_2.Text.Trim & "', '" & _
                    txtRemark2_3.Text.Trim & "', '" & _
                    txtRemark2_4.Text.Trim & "', '" & _
                    txtRemark2_5.Text.Trim & "', '" & _
                    txtRemark3_1.Text.Trim & "', '" & _
                    txtRemark3_2.Text.Trim & "', '" & _
                    txtRemark3_3.Text.Trim & "', '" & _
                    txtRemark3_4.Text.Trim & "', '" & _
                    txtRemark3_5.Text.Trim & "', '" & _
                    txtRemark4_1.Text.Trim & "', '" & _
                    txtRemark4_2.Text.Trim & "', '" & _
                    txtRemark4_3.Text.Trim & "', '" & _
                    txtRemark4_4.Text.Trim & "', '" & _
                    txtRemark4_5.Text.Trim & "', '" & _
                    txtRemark5_1.Text.Trim & "', '" & _
                    txtRemark5_2.Text.Trim & "', '" & _
                    txtRemark5_3.Text.Trim & "', '" & _
                    txtRemark5_4.Text.Trim & "', '" & _
                    txtRemark5_5.Text.Trim & "', '" & _
                    txtRemark.Text.Trim & "', '" & _
                    Replace(CStr(Average), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection1), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection2), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection3), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection4), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection5), ",", ".") & "', '" & _
                    "Y', '" & _
                    userlog.UserName & "', '" & _
                    userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            LastSerial = CInt(Microsoft.VisualBasic.Right(txtQuestID.Text, 3))
            UpdateSerial(Me.Name & Prefix, GetCurrMonth, GetCurrYear, LastSerial, userlog.UserName) 'Update Serial

            Insert_Trans_History(txtQuestID.Text.Trim, Me.Name, "INSERT") 'Insert History transaction

            MsgBox("Data has been saved", MsgBoxStyle.Information, "Information")

        Else
            MessageBox.Show("Wrong Process")
            StatusTRans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Sub UpdateData()
        Dim answer1_1 As Integer = 0
        Dim answer1_2 As Integer = 0
        Dim answer1_3 As Integer = 0
        Dim answer1_4 As Integer = 0
        Dim answer1_5 As Integer = 0

        Dim answer2_1 As Integer = 0
        Dim answer2_2 As Integer = 0
        Dim answer2_3 As Integer = 0
        Dim answer2_4 As Integer = 0
        Dim answer2_5 As Integer = 0

        Dim answer3_1 As Integer = 0
        Dim answer3_2 As Integer = 0
        Dim answer3_3 As Integer = 0
        Dim answer3_4 As Integer = 0
        Dim answer3_5 As Integer = 0

        Dim answer4_1 As Integer = 0
        Dim answer4_2 As Integer = 0
        Dim answer4_3 As Integer = 0
        Dim answer4_4 As Integer = 0
        Dim answer4_5 As Integer = 0

        Dim answer5_1 As Integer = 0
        Dim answer5_2 As Integer = 0
        Dim answer5_3 As Integer = 0
        Dim answer5_4 As Integer = 0
        Dim answer5_5 As Integer = 0

        Dim TTL_Quest As Integer
        Dim Average As Decimal
        Dim TTL_Score As Integer
        Dim TTL_Quest_Section As Integer
        Dim TTL_Score_Section As Integer
        Dim AverageSection1 As Decimal
        Dim AverageSection2 As Decimal
        Dim AverageSection3 As Decimal
        Dim AverageSection4 As Decimal
        Dim AverageSection5 As Decimal

        TTL_Score = 0
        TTL_Quest = 0
        TTL_Score_Section = 0
        TTL_Quest_Section = 0

        If StatusTRans = TransStatus.NewStatus OrElse StatusTRans = TransStatus.EditStatus Then
            If conn.State = ConnectionState.Open Then conn.Close()

            If rbQuest1_1_1.Checked = True Then
                answer1_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_2.Checked = True Then
                answer1_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_3.Checked = True Then
                answer1_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_4.Checked = True Then
                answer1_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_2_1.Checked = True Then
                answer1_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1

            ElseIf rbQuest1_2_2.Checked = True Then
                answer1_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_2_3.Checked = True Then
                answer1_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_2_4.Checked = True Then
                answer1_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_3_1.Checked = True Then
                answer1_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_2.Checked = True Then
                answer1_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_3.Checked = True Then
                answer1_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_3_4.Checked = True Then
                answer1_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_4_1.Checked = True Then
                answer1_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_2.Checked = True Then
                answer1_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_3.Checked = True Then
                answer1_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_4_4.Checked = True Then
                answer1_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest1_5_1.Checked = True Then
                answer1_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_2.Checked = True Then
                answer1_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_3.Checked = True Then
                answer1_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_4.Checked = True Then
                answer1_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection1 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection1 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest2_1_1.Checked = True Then
                answer2_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_2.Checked = True Then
                answer2_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_3.Checked = True Then
                answer2_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_1_4.Checked = True Then
                answer2_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_2_1.Checked = True Then
                answer2_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_2.Checked = True Then
                answer2_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_3.Checked = True Then
                answer2_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_2_4.Checked = True Then
                answer2_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_3_1.Checked = True Then
                answer2_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_2.Checked = True Then
                answer2_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_3.Checked = True Then
                answer2_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_3_4.Checked = True Then
                answer2_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_4_1.Checked = True Then
                answer2_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_2.Checked = True Then
                answer2_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_3.Checked = True Then
                answer2_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_4_4.Checked = True Then
                answer2_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest2_5_1.Checked = True Then
                answer2_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_2.Checked = True Then
                answer2_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_3.Checked = True Then
                answer2_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest2_5_4.Checked = True Then
                answer2_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection2 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection2 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest3_1_1.Checked = True Then
                answer3_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_2.Checked = True Then
                answer3_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_3.Checked = True Then
                answer3_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_1_4.Checked = True Then
                answer3_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_2_1.Checked = True Then
                answer3_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_2.Checked = True Then
                answer3_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_3.Checked = True Then
                answer3_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_2_4.Checked = True Then
                answer3_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_3_1.Checked = True Then
                answer3_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_2.Checked = True Then
                answer3_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_3.Checked = True Then
                answer3_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_3_4.Checked = True Then
                answer3_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_4_1.Checked = True Then
                answer3_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_2.Checked = True Then
                answer3_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_3.Checked = True Then
                answer3_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_4_4.Checked = True Then
                answer3_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest3_5_1.Checked = True Then
                answer3_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_2.Checked = True Then
                answer3_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_3.Checked = True Then
                answer3_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 3
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest3_5_4.Checked = True Then
                answer3_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection3 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection3 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest4_1_1.Checked = True Then
                answer4_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_2.Checked = True Then
                answer4_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_3.Checked = True Then
                answer4_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_1_4.Checked = True Then
                answer4_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_2_1.Checked = True Then
                answer4_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_2.Checked = True Then
                answer4_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_3.Checked = True Then
                answer4_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_2_4.Checked = True Then
                answer4_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_3_1.Checked = True Then
                answer4_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_2.Checked = True Then
                answer4_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_3.Checked = True Then
                answer4_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_3_4.Checked = True Then
                answer4_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_4_1.Checked = True Then
                answer4_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_2.Checked = True Then
                answer4_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_3.Checked = True Then
                answer4_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_4_4.Checked = True Then
                answer4_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest4_5_1.Checked = True Then
                answer4_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_5_2.Checked = True Then
                answer4_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest4_5_3.Checked = True Then
                answer4_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_5_4.Checked = True Then
                answer4_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection4 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection4 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            '-
            If rbQuest5_1_1.Checked = True Then
                answer5_1 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_2.Checked = True Then
                answer5_1 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_3.Checked = True Then
                answer5_1 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest1_1_4.Checked = True Then
                answer5_1 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_2_1.Checked = True Then
                answer5_2 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_2.Checked = True Then
                answer5_2 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_3.Checked = True Then
                answer5_2 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_2_4.Checked = True Then
                answer5_2 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_3_1.Checked = True Then
                answer5_3 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_2.Checked = True Then
                answer5_3 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_3.Checked = True Then
                answer5_3 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_3_4.Checked = True Then
                answer5_3 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_4_1.Checked = True Then
                answer5_4 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_2.Checked = True Then
                answer5_4 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_3.Checked = True Then
                answer5_4 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_4_4.Checked = True Then
                answer5_4 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If rbQuest5_5_1.Checked = True Then
                answer5_5 = 1
                TTL_Score = TTL_Score + 1
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 1
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_2.Checked = True Then
                answer5_5 = 2
                TTL_Score = TTL_Score + 2
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 2
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_3.Checked = True Then
                answer5_5 = 3
                TTL_Score = TTL_Score + 3
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 3
                TTL_Quest_Section = TTL_Quest_Section + 1
            ElseIf rbQuest5_5_4.Checked = True Then
                answer1_5 = 4
                TTL_Score = TTL_Score + 4
                TTL_Quest = TTL_Quest + 1
                TTL_Score_Section = TTL_Score_Section + 4
                TTL_Quest_Section = TTL_Quest_Section + 1
            End If

            If TTL_Quest_Section <> 0 Then
                AverageSection5 = TTL_Score_Section / TTL_Quest_Section
            Else
                AverageSection5 = 0
            End If

            TTL_Score_Section = 0
            TTL_Quest_Section = 0

            Average = TTL_Score / TTL_Quest
            conn.Open()
            cmd.CommandText = "EXEC sp_Update_Trans_Questionnaire '" & _
                    txtQuestID.Text & "', '" & _
                    Customer & "', '" & _
                    Supplier & "', '" & _
                    txtProject1.Text.Trim & "', '" & _
                    txtProject2.Text.Trim & "', '" & _
                    txtProject3.Text.Trim & "', '" & _
                    txtRespondentName.Text.Trim & "', '" & _
                    txtJabatan.Text.Trim & "', '" & _
                    Format(dtpQuest.Value, "MM-dd-yyyy") & "', '" & _
                    answer1_1 & "', '" & _
                    answer1_2 & "', '" & _
                    answer1_3 & "', '" & _
                    answer1_4 & "', '" & _
                    answer1_5 & "', '" & _
                    answer2_1 & "', '" & _
                    answer2_2 & "', '" & _
                    answer2_3 & "', '" & _
                    answer2_4 & "', '" & _
                    answer2_5 & "', '" & _
                    answer3_1 & "', '" & _
                    answer3_2 & "', '" & _
                    answer3_3 & "', '" & _
                    answer3_4 & "', '" & _
                    answer3_5 & "', '" & _
                    answer4_1 & "', '" & _
                    answer4_2 & "', '" & _
                    answer4_3 & "', '" & _
                    answer4_4 & "', '" & _
                    answer4_5 & "', '" & _
                    answer5_1 & "', '" & _
                    answer5_2 & "', '" & _
                    answer5_3 & "', '" & _
                    answer5_4 & "', '" & _
                    answer5_5 & "', '" & _
                    txtRemark1_1.Text.Trim & "', '" & _
                    txtRemark1_2.Text.Trim & "', '" & _
                    txtRemark1_3.Text.Trim & "', '" & _
                    txtRemark1_4.Text.Trim & "', '" & _
                    txtRemark1_5.Text.Trim & "', '" & _
                    txtRemark2_1.Text.Trim & "', '" & _
                    txtRemark2_2.Text.Trim & "', '" & _
                    txtRemark2_3.Text.Trim & "', '" & _
                    txtRemark2_4.Text.Trim & "', '" & _
                    txtRemark2_5.Text.Trim & "', '" & _
                    txtRemark3_1.Text.Trim & "', '" & _
                    txtRemark3_2.Text.Trim & "', '" & _
                    txtRemark3_3.Text.Trim & "', '" & _
                    txtRemark3_4.Text.Trim & "', '" & _
                    txtRemark3_5.Text.Trim & "', '" & _
                    txtRemark4_1.Text.Trim & "', '" & _
                    txtRemark4_2.Text.Trim & "', '" & _
                    txtRemark4_3.Text.Trim & "', '" & _
                    txtRemark4_4.Text.Trim & "', '" & _
                    txtRemark4_5.Text.Trim & "', '" & _
                    txtRemark5_1.Text.Trim & "', '" & _
                    txtRemark5_2.Text.Trim & "', '" & _
                    txtRemark5_3.Text.Trim & "', '" & _
                    txtRemark5_4.Text.Trim & "', '" & _
                    txtRemark5_5.Text.Trim & "', '" & _
                    txtRemark.Text.Trim & "', '" & _
                    Replace(CStr(Average), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection1), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection2), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection3), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection4), ",", ".") & "', '" & _
                    Replace(CStr(AverageSection5), ",", ".") & "', '" & _
                    "Y', '" & _
                    userlog.UserName & "'"
            cmd.ExecuteNonQuery()
            conn.Close()

            Insert_Trans_History(txtQuestID.Text.Trim, Me.Name, "UPDATE") 'Insert History transaction
            MsgBox("Data has been updated", MsgBoxStyle.Information, "Information")

        Else
            MessageBox.Show("Wrong Process")
            StatusTRans = TransStatus.NoStatus
            SetToolTip()
        End If
    End Sub

    Sub DeleteData()
        Try
            If MessageBox.Show("Are you sure to save this data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim answer1_1 As Integer = 0
                Dim answer1_2 As Integer = 0
                Dim answer1_3 As Integer = 0
                Dim answer1_4 As Integer = 0
                Dim answer1_5 As Integer = 0

                Dim answer2_1 As Integer = 0
                Dim answer2_2 As Integer = 0
                Dim answer2_3 As Integer = 0
                Dim answer2_4 As Integer = 0
                Dim answer2_5 As Integer = 0

                Dim answer3_1 As Integer = 0
                Dim answer3_2 As Integer = 0
                Dim answer3_3 As Integer = 0
                Dim answer3_4 As Integer = 0
                Dim answer3_5 As Integer = 0

                Dim answer4_1 As Integer = 0
                Dim answer4_2 As Integer = 0
                Dim answer4_3 As Integer = 0
                Dim answer4_4 As Integer = 0
                Dim answer4_5 As Integer = 0

                Dim answer5_1 As Integer = 0
                Dim answer5_2 As Integer = 0
                Dim answer5_3 As Integer = 0
                Dim answer5_4 As Integer = 0
                Dim answer5_5 As Integer = 0
                Dim TTL_Quest As Integer
                Dim Average As Decimal
                Dim TTL_Score As Integer

                Dim TTL_Quest_Section As Integer
                Dim TTL_Score_Section As Integer
                Dim AverageSection1 As Decimal
                Dim AverageSection2 As Decimal
                Dim AverageSection3 As Decimal
                Dim AverageSection4 As Decimal
                Dim AverageSection5 As Decimal

                TTL_Score = 0
                TTL_Quest = 0
                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                If conn.State = ConnectionState.Open Then conn.Close()


                If rbQuest1_1_1.Checked = True Then
                    answer1_1 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_2.Checked = True Then
                    answer1_1 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_3.Checked = True Then
                    answer1_1 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_4.Checked = True Then
                    answer1_1 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest1_2_1.Checked = True Then
                    answer1_2 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1

                ElseIf rbQuest1_2_2.Checked = True Then
                    answer1_2 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_2_3.Checked = True Then
                    answer1_2 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_2_4.Checked = True Then
                    answer1_2 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest1_3_1.Checked = True Then
                    answer1_3 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_3_2.Checked = True Then
                    answer1_3 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_3_3.Checked = True Then
                    answer1_3 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_3_4.Checked = True Then
                    answer1_3 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest1_4_1.Checked = True Then
                    answer1_4 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_4_2.Checked = True Then
                    answer1_4 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_4_3.Checked = True Then
                    answer1_4 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_4_4.Checked = True Then
                    answer1_4 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest1_5_1.Checked = True Then
                    answer1_5 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_5_2.Checked = True Then
                    answer1_5 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_5_3.Checked = True Then
                    answer1_5 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_5_4.Checked = True Then
                    answer1_5 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If TTL_Quest_Section <> 0 Then
                    AverageSection1 = TTL_Score_Section / TTL_Quest_Section
                Else
                    AverageSection1 = 0
                End If

                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                '-
                If rbQuest2_1_1.Checked = True Then
                    answer2_1 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_1_2.Checked = True Then
                    answer2_1 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_1_3.Checked = True Then
                    answer2_1 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_1_4.Checked = True Then
                    answer2_1 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest2_2_1.Checked = True Then
                    answer2_2 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_2_2.Checked = True Then
                    answer2_2 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_2_3.Checked = True Then
                    answer2_2 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_2_4.Checked = True Then
                    answer2_2 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest2_3_1.Checked = True Then
                    answer2_3 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_3_2.Checked = True Then
                    answer2_3 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_3_3.Checked = True Then
                    answer2_3 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_3_4.Checked = True Then
                    answer2_3 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest2_4_1.Checked = True Then
                    answer2_4 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_4_2.Checked = True Then
                    answer2_4 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_4_3.Checked = True Then
                    answer2_4 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_4_4.Checked = True Then
                    answer2_4 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest2_5_1.Checked = True Then
                    answer2_5 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_5_2.Checked = True Then
                    answer2_5 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_5_3.Checked = True Then
                    answer2_5 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest2_5_4.Checked = True Then
                    answer2_5 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If TTL_Quest_Section <> 0 Then
                    AverageSection2 = TTL_Score_Section / TTL_Quest_Section
                Else
                    AverageSection2 = 0
                End If

                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                '-
                If rbQuest3_1_1.Checked = True Then
                    answer3_1 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_1_2.Checked = True Then
                    answer3_1 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_1_3.Checked = True Then
                    answer3_1 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_1_4.Checked = True Then
                    answer3_1 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest3_2_1.Checked = True Then
                    answer3_2 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_2_2.Checked = True Then
                    answer3_2 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_2_3.Checked = True Then
                    answer3_2 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_2_4.Checked = True Then
                    answer3_2 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest3_3_1.Checked = True Then
                    answer3_3 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_3_2.Checked = True Then
                    answer3_3 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_3_3.Checked = True Then
                    answer3_3 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_3_4.Checked = True Then
                    answer3_3 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest3_4_1.Checked = True Then
                    answer3_4 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_4_2.Checked = True Then
                    answer3_4 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_4_3.Checked = True Then
                    answer3_4 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_4_4.Checked = True Then
                    answer3_4 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest3_5_1.Checked = True Then
                    answer3_5 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_5_2.Checked = True Then
                    answer3_5 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_5_3.Checked = True Then
                    answer3_5 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 3
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest3_5_4.Checked = True Then
                    answer3_5 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If TTL_Quest_Section <> 0 Then
                    AverageSection3 = TTL_Score_Section / TTL_Quest_Section
                Else
                    AverageSection3 = 0
                End If

                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                '-
                If rbQuest4_1_1.Checked = True Then
                    answer4_1 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_1_2.Checked = True Then
                    answer4_1 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_1_3.Checked = True Then
                    answer4_1 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_1_4.Checked = True Then
                    answer4_1 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest4_2_1.Checked = True Then
                    answer4_2 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_2_2.Checked = True Then
                    answer4_2 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_2_3.Checked = True Then
                    answer4_2 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_2_4.Checked = True Then
                    answer4_2 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest4_3_1.Checked = True Then
                    answer4_3 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_3_2.Checked = True Then
                    answer4_3 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_3_3.Checked = True Then
                    answer4_3 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_3_4.Checked = True Then
                    answer4_3 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest4_4_1.Checked = True Then
                    answer4_4 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_4_2.Checked = True Then
                    answer4_4 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_4_3.Checked = True Then
                    answer4_4 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_4_4.Checked = True Then
                    answer4_4 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest4_5_1.Checked = True Then
                    answer4_5 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_5_2.Checked = True Then
                    answer4_5 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest4_5_3.Checked = True Then
                    answer4_5 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_5_4.Checked = True Then
                    answer4_5 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If TTL_Quest_Section <> 0 Then
                    AverageSection4 = TTL_Score_Section / TTL_Quest_Section
                Else
                    AverageSection4 = 0
                End If

                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                '-
                If rbQuest5_1_1.Checked = True Then
                    answer5_1 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_2.Checked = True Then
                    answer5_1 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_3.Checked = True Then
                    answer5_1 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest1_1_4.Checked = True Then
                    answer5_1 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest5_2_1.Checked = True Then
                    answer5_2 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_2_2.Checked = True Then
                    answer5_2 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_2_3.Checked = True Then
                    answer5_2 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_2_4.Checked = True Then
                    answer5_2 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest5_3_1.Checked = True Then
                    answer5_3 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_3_2.Checked = True Then
                    answer5_3 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_3_3.Checked = True Then
                    answer5_3 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_3_4.Checked = True Then
                    answer5_3 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest5_4_1.Checked = True Then
                    answer5_4 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_4_2.Checked = True Then
                    answer5_4 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_4_3.Checked = True Then
                    answer5_4 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_4_4.Checked = True Then
                    answer5_4 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If rbQuest5_5_1.Checked = True Then
                    answer5_5 = 1
                    TTL_Score = TTL_Score + 1
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 1
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_5_2.Checked = True Then
                    answer5_5 = 2
                    TTL_Score = TTL_Score + 2
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 2
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_5_3.Checked = True Then
                    answer5_5 = 3
                    TTL_Score = TTL_Score + 3
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 3
                    TTL_Quest_Section = TTL_Quest_Section + 1
                ElseIf rbQuest5_5_4.Checked = True Then
                    answer1_5 = 4
                    TTL_Score = TTL_Score + 4
                    TTL_Quest = TTL_Quest + 1
                    TTL_Score_Section = TTL_Score_Section + 4
                    TTL_Quest_Section = TTL_Quest_Section + 1
                End If

                If TTL_Quest_Section <> 0 Then
                    AverageSection5 = TTL_Score_Section / TTL_Quest_Section
                Else
                    AverageSection5 = 0
                End If

                TTL_Score_Section = 0
                TTL_Quest_Section = 0

                Average = TTL_Score / TTL_Quest

                conn.Open()
                cmd.CommandText = "EXEC sp_Update_Trans_Questionnaire '" & _
                        txtQuestID.Text & "', '" & _
                        Customer & "', '" & _
                        Supplier & "', '" & _
                        txtProject1.Text.Trim & "', '" & _
                        txtProject2.Text.Trim & "', '" & _
                        txtProject3.Text.Trim & "', '" & _
                        txtRespondentName.Text.Trim & "', '" & _
                        txtJabatan.Text.Trim & "', '" & _
                        Format(dtpQuest.Value, "MM-dd-yyyy") & "', '" & _
                        answer1_1 & "', '" & _
                        answer1_2 & "', '" & _
                        answer1_3 & "', '" & _
                        answer1_4 & "', '" & _
                        answer1_5 & "', '" & _
                        answer2_1 & "', '" & _
                        answer2_2 & "', '" & _
                        answer2_3 & "', '" & _
                        answer2_4 & "', '" & _
                        answer2_5 & "', '" & _
                        answer3_1 & "', '" & _
                        answer3_2 & "', '" & _
                        answer3_3 & "', '" & _
                        answer3_4 & "', '" & _
                        answer3_5 & "', '" & _
                        answer4_1 & "', '" & _
                        answer4_2 & "', '" & _
                        answer4_3 & "', '" & _
                        answer4_4 & "', '" & _
                        answer4_5 & "', '" & _
                        answer5_1 & "', '" & _
                        answer5_2 & "', '" & _
                        answer5_3 & "', '" & _
                        answer5_4 & "', '" & _
                        answer5_5 & "', '" & _
                        txtRemark1_1.Text.Trim & "', '" & _
                        txtRemark1_2.Text.Trim & "', '" & _
                        txtRemark1_3.Text.Trim & "', '" & _
                        txtRemark1_4.Text.Trim & "', '" & _
                        txtRemark1_5.Text.Trim & "', '" & _
                        txtRemark2_1.Text.Trim & "', '" & _
                        txtRemark2_2.Text.Trim & "', '" & _
                        txtRemark2_3.Text.Trim & "', '" & _
                        txtRemark2_4.Text.Trim & "', '" & _
                        txtRemark2_5.Text.Trim & "', '" & _
                        txtRemark3_1.Text.Trim & "', '" & _
                        txtRemark3_2.Text.Trim & "', '" & _
                        txtRemark3_3.Text.Trim & "', '" & _
                        txtRemark3_4.Text.Trim & "', '" & _
                        txtRemark3_5.Text.Trim & "', '" & _
                        txtRemark4_1.Text.Trim & "', '" & _
                        txtRemark4_2.Text.Trim & "', '" & _
                        txtRemark4_3.Text.Trim & "', '" & _
                        txtRemark4_4.Text.Trim & "', '" & _
                        txtRemark4_5.Text.Trim & "', '" & _
                        txtRemark5_1.Text.Trim & "', '" & _
                        txtRemark5_2.Text.Trim & "', '" & _
                        txtRemark5_3.Text.Trim & "', '" & _
                        txtRemark5_4.Text.Trim & "', '" & _
                        txtRemark5_5.Text.Trim & "', '" & _
                        txtRemark.Text.Trim & "', '" & _
                        Replace(CStr(Average), ",", ".") & "', '" & _
                        Replace(CStr(AverageSection1), ",", ".") & "', '" & _
                        Replace(CStr(AverageSection2), ",", ".") & "', '" & _
                        Replace(CStr(AverageSection3), ",", ".") & "', '" & _
                        Replace(CStr(AverageSection4), ",", ".") & "', '" & _
                        Replace(CStr(AverageSection5), ",", ".") & "', '" & _
                        "N', '" & _
                        userlog.UserName & "'"
                cmd.ExecuteNonQuery()
                conn.Close()

                Insert_Trans_History(txtQuestID.Text.Trim, Me.Name, "DELETE") 'Insert History transaction

                MsgBox("Data has been deleted", MsgBoxStyle.Information, "Information")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveCbSupplier()
        Dim dtTable As New DataTable
        cbSupplier.ResetText()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Master_Supplier_ForComboBox"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Sub

            cbSupplier.DataSource = dtTable
            cbSupplier.DisplayMember = "Supp_Desc"
            cbSupplier.ValueMember = "Supp_ID"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub RetrieveCbCustomer()
        Dim dtTable As New DataTable
        cbCustomer.ResetText()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "EXEC sp_Retrieve_Master_Customer_ForComboBox"
            DA.SelectCommand = cmd
            DA.Fill(dtTable)
            conn.Close()

            If dtTable.Rows.Count = 0 Then Exit Sub

            cbCustomer.DataSource = dtTable
            cbCustomer.DisplayMember = "Cust_Desc"
            cbCustomer.ValueMember = "Cust_ID"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EnableDisableInput(ByVal boo As Boolean)
        txtSetID.Enabled = False
        txtQuestID.Enabled = False
        cbCustomer.Enabled = boo
        cbSupplier.Enabled = boo
        txtProject1.Enabled = boo
        txtProject2.Enabled = boo
        txtProject3.Enabled = boo
        txtJabatan.Enabled = boo
        txtRespondentName.Enabled = boo
        dtpQuest.Enabled = boo
        txtRemark.Enabled = boo
        gbQuest1_1.Enabled = boo
        gbQuest1_2.Enabled = boo
        gbQuest1_3.Enabled = boo
        gbQuest1_4.Enabled = boo
        gbQuest1_5.Enabled = boo
        gbQuest2_1.Enabled = boo
        gbQuest2_2.Enabled = boo
        gbQuest2_3.Enabled = boo
        gbQuest2_4.Enabled = boo
        gbQuest2_5.Enabled = boo
        gbQuest3_1.Enabled = boo
        gbQuest3_2.Enabled = boo
        gbQuest3_3.Enabled = boo
        gbQuest3_4.Enabled = boo
        gbQuest3_5.Enabled = boo
        gbQuest4_1.Enabled = boo
        gbQuest4_2.Enabled = boo
        gbQuest4_3.Enabled = boo
        gbQuest4_4.Enabled = boo
        gbQuest4_5.Enabled = boo
        gbQuest5_1.Enabled = boo
        gbQuest5_2.Enabled = boo
        gbQuest5_3.Enabled = boo
        gbQuest5_4.Enabled = boo
        gbQuest5_5.Enabled = boo

        If txtQuestID.Text.Trim = "" Then Exit Sub

        Select Case txtQuestID.Text.Substring(0, 2)
            Case "SQ"
                cbCustomer.Enabled = False
            Case "CQ"
                cbSupplier.Enabled = False
            Case "OQ"
                cbCustomer.Enabled = False
                cbSupplier.Enabled = False
        End Select
    End Sub

    Function Validation() As Boolean
        Validation = True

        If txtRespondentName.Text.Trim = "" Then
            Validation = False
            Exit Function
        End If

        If txtJabatan.Text.Trim = "" Then
            Validation = False
            Exit Function
        End If

        If gbQuest1_1.Visible = True Then
            If rbQuest1_1_1.Checked = False And _
                rbQuest1_1_2.Checked = False And _
                rbQuest1_1_3.Checked = False And _
                rbQuest1_1_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest1_2.Visible = True Then
            If rbQuest1_2_1.Checked = False And _
                rbQuest1_2_2.Checked = False And _
                rbQuest1_2_3.Checked = False And _
                rbQuest1_2_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest1_3.Visible = True Then
            If rbQuest1_3_1.Checked = False And _
                rbQuest1_3_2.Checked = False And _
                rbQuest1_3_3.Checked = False And _
                rbQuest1_3_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest1_4.Visible = True Then
            If rbQuest1_4_1.Checked = False And _
                rbQuest1_4_2.Checked = False And _
                rbQuest1_4_3.Checked = False And _
                rbQuest1_4_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest1_5.Visible = True Then
            If rbQuest1_5_1.Checked = False And _
                rbQuest1_5_2.Checked = False And _
                rbQuest1_5_3.Checked = False And _
                rbQuest1_5_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest2_1.Visible = True Then
            If rbQuest2_1_1.Checked = False And _
                rbQuest2_1_2.Checked = False And _
                rbQuest2_1_3.Checked = False And _
                rbQuest2_1_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest2_2.Visible = True Then
            If rbQuest2_2_1.Checked = False And _
                rbQuest2_2_2.Checked = False And _
                rbQuest2_2_3.Checked = False And _
                rbQuest2_2_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest2_3.Visible = True Then
            If rbQuest2_3_1.Checked = False And _
                rbQuest2_3_2.Checked = False And _
                rbQuest2_3_3.Checked = False And _
                rbQuest2_3_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest2_4.Visible = True Then
            If rbQuest2_4_1.Checked = False And _
                rbQuest2_4_2.Checked = False And _
                rbQuest2_4_3.Checked = False And _
                rbQuest2_4_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest2_5.Visible = True Then
            If rbQuest2_5_1.Checked = False And _
                rbQuest2_5_2.Checked = False And _
                rbQuest2_5_3.Checked = False And _
                rbQuest2_5_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest3_1.Visible = True Then
            If rbQuest3_1_1.Checked = False And _
                rbQuest3_1_2.Checked = False And _
                rbQuest3_1_3.Checked = False And _
                rbQuest3_1_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest3_2.Visible = True Then
            If rbQuest3_2_1.Checked = False And _
                rbQuest3_2_2.Checked = False And _
                rbQuest3_2_3.Checked = False And _
                rbQuest3_2_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest3_3.Visible = True Then
            If rbQuest3_3_1.Checked = False And _
                rbQuest3_3_2.Checked = False And _
                rbQuest3_3_3.Checked = False And _
                rbQuest3_3_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest3_4.Visible = True Then
            If rbQuest3_4_1.Checked = False And _
                rbQuest3_4_2.Checked = False And _
                rbQuest3_4_3.Checked = False And _
                rbQuest3_4_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If


        If gbQuest3_5.Visible = True Then
            If rbQuest3_5_1.Checked = False And _
                rbQuest3_5_2.Checked = False And _
                rbQuest3_5_3.Checked = False And _
                rbQuest3_5_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If


        If gbQuest4_1.Visible = True Then
            If rbQuest4_1_1.Checked = False And _
                rbQuest4_1_2.Checked = False And _
                rbQuest4_1_3.Checked = False And _
                rbQuest4_1_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest4_2.Visible = True Then
            If rbQuest4_2_1.Checked = False And _
                rbQuest4_2_2.Checked = False And _
                rbQuest4_2_3.Checked = False And _
                rbQuest4_2_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest4_3.Visible = True Then
            If rbQuest4_3_1.Checked = False And _
                rbQuest4_3_2.Checked = False And _
                rbQuest4_3_3.Checked = False And _
                rbQuest4_3_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest4_4.Visible = True Then
            If rbQuest4_4_1.Checked = False And _
                rbQuest4_4_2.Checked = False And _
                rbQuest4_4_3.Checked = False And _
                rbQuest4_4_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest4_5.Visible = True Then
            If rbQuest4_5_1.Checked = False And _
                rbQuest4_5_2.Checked = False And _
                rbQuest4_5_3.Checked = False And _
                rbQuest4_5_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest5_1.Visible = True Then
            If rbQuest5_1_1.Checked = False And _
                rbQuest5_1_2.Checked = False And _
                rbQuest5_1_3.Checked = False And _
                rbQuest5_1_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest5_2.Visible = True Then
            If rbQuest5_2_1.Checked = False And _
                rbQuest5_2_2.Checked = False And _
                rbQuest5_2_3.Checked = False And _
                rbQuest5_2_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest5_3.Visible = True Then
            If rbQuest5_3_1.Checked = False And _
                rbQuest5_3_2.Checked = False And _
                rbQuest5_3_3.Checked = False And _
                rbQuest5_3_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest5_4.Visible = True Then
            If rbQuest5_4_1.Checked = False And _
                rbQuest5_4_2.Checked = False And _
                rbQuest5_4_3.Checked = False And _
                rbQuest5_4_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If

        If gbQuest5_5.Visible = True Then
            If rbQuest5_5_1.Checked = False And _
                rbQuest5_5_2.Checked = False And _
                rbQuest5_5_3.Checked = False And _
                rbQuest5_5_4.Checked = False Then
                Validation = False
                Exit Function
            End If
        End If
    End Function

#End Region

#Region "Event Handler"

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If StatusTRans = TransStatus.NewStatus OrElse StatusTRans = TransStatus.EditStatus Then

            If Validation() = False Then
                MsgBox("Please fill information completely", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            Select Case Prefix
                Case "SQ"
                    Customer = ""
                    Supplier = cbSupplier.SelectedValue.ToString
                Case "CQ"
                    Customer = cbCustomer.SelectedValue.ToString
                    Supplier = ""
                Case "OQ"
                    Customer = ""
                    Supplier = ""
            End Select

            Select Case StatusTRans
                Case TransStatus.NewStatus
                    Call InsertData()
                Case TransStatus.EditStatus
                    Call UpdateData()
            End Select

            StatusTRans = TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
        Else
            MessageBox.Show("Wrong Process")
            StatusTRans = TransStatus.NoStatus
            SetToolTip()
        End If

    End Sub

    Private Sub btn_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        If StatusTRans = GlobalVar.TransStatus.NoStatus Then
            StatusTRans = GlobalVar.TransStatus.EditStatus
            Call SetToolTip()
            Call EnableDisableInput(True)
        End If
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        If StatusTRans = GlobalVar.TransStatus.EditStatus Then
            StatusTRans = GlobalVar.TransStatus.NoStatus
            Call SetToolTip()
            Call EnableDisableInput(False)
        ElseIf StatusTRans = GlobalVar.TransStatus.NewStatus Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If StatusTRans = GlobalVar.TransStatus.NoStatus Then

            Select Case txtQuestID.Text.Substring(0, 2)
                Case "SQ"
                    Customer = ""
                    Supplier = cbSupplier.SelectedValue.ToString
                Case "CQ"
                    Customer = cbCustomer.SelectedValue.ToString
                    Supplier = ""
                Case "OQ"
                    Customer = ""
                    Supplier = ""
            End Select

            Call DeleteData()
        End If
    End Sub

    Private Sub frmQuestionnaire_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim frmChild As New frmQuestionnaireView
        For Each f As Form In Me.MdiChildren
            If f.Name = "FormQuestionnaireView" Then
                f.BringToFront()
                Exit Sub
            End If
        Next

        frmChild.MdiParent = MDIFrm
        frmChild.Show()
    End Sub

#End Region

End Class