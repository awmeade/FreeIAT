Public Class SetUpForm

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        Dim Images As Boolean = False
        If rbImagesYes.Checked Then
            Images = True
        End If

        ' see if there is already Config.txt and if so, is it OK to replace?
        If Dir(folderPath & "\Config.txt") <> "" Then
            Dim OverWrite = MsgBox("The folder " & folderPath & " already contains a 'Config.txt' file.  Overwrite this file?", MsgBoxStyle.YesNo)
            If OverWrite = vbNo Then
                End
                Me.Close()

            End If
        End If

        Dim ConfigFile As String = folderPath & "\Config.txt"
        'write out title to Config.txt file
        Try
            My.Computer.FileSystem.WriteAllText(ConfigFile, "[Title] " & tbTitle.Text & vbCrLf, False)
        Catch ex As Exception
            MsgBox("Unable to write the 'Config.txt' file to the directory: " & folderPath)
            Me.Hide()            
        End Try

        
        Me.Hide()
        SetUp2.hasImage = Images
        'pass HasImage to next form
        SetUp2.Show()
    End Sub
End Class
