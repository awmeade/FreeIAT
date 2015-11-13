Public Class StartForm

    Private Sub StartForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myPanel.BorderStyle = BorderStyle.None
        myPanel.Left = (Me.Width - myPanel.Width) / 2

        folderPath = CurDir()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

 
        userID = idBox.Text
        If userID = "" Then
            MsgBox("You must enter an ID for the participant.")
        Else

            configFile = CurDir() & "\Config.txt"

            Try
                My.Computer.FileSystem.ReadAllText(configFile)
            Catch ex As Exception
                MsgBox("Unable to find the Config.txt file in directory: " & folderPath & ".")
                End

            End Try

            Call ReadInData()   'reads in all of the data into global arrays
            If AllIsOK() = True Then    'tests to be sure all is OK
                Me.Hide()
                Info.Show()     'starts the intro page
            Else        ' all is NOT OK.  Quit program
                Me.Hide()
                End
            End If

        End If
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
        End
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        HelpForm.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SetUpForm.Show()
    End Sub

    Private Sub UpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        AboutBox1.Show()
    End Sub
End Class