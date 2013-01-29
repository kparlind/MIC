Imports MIS.MasterData
Imports MIS.GlobalVar

Public Class dlgSurveyItem
    Public Komponent As String
    Dim CategoryItem As String
    Dim MD As New MasterData
    Dim dtActive As DataTable

    Public Sub Init(ByVal Category As String, ByVal dtComponent As DataTable)
        CategoryItem = Category
        dtActive = dtComponent
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Me.Close()
    End Sub

    Private Sub dlgSurveyItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim MD As New MasterData
        Dim i, j, k As Integer
        Dim isChecked As Boolean

        clstComponent.Items.Clear()
        MD.RetrieveItemKomponent_ByCategory(dt, CategoryItem)
        If dt.Rows.Count <> 0 Then
            For i = 0 To dt.Rows.Count - 1
                isChecked = False

                If dtActive.Rows.Count <> 0 Then
                    For k = 0 To dtActive.Rows.Count - 1
                        If dtActive.Rows(k).Item(0) = CategoryItem Then
                            If dt.Rows(i).Item("Komponen_Grp_ID").ToString.Trim = dtActive.Rows(k).Item(1) Then
                                isChecked = True
                                Exit For
                            End If
                        End If
                    Next
                End If

                clstComponent.Items.Add(dt.Rows(i).Item("Nama_Komponen_Grp").ToString.Trim & " - " & dt.Rows(i).Item("Komponen_Grp_ID").ToString.Trim, isChecked)
            Next
        End If
    End Sub
End Class