Public Class SetUp2

    Public hasImage As Boolean      ' gets this passed from the previous SetupForm form


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim CfgFile As String = folderPath & "/Config.txt"
        Dim Stim1stuff
        Dim Stim2stuff
        Dim Stim1clean As New ArrayList
        Dim Stim2clean As New ArrayList

        Try
            My.Computer.FileSystem.WriteAllText(CfgFile, "[Stimuli-1 Label] " & Trim(tbStim1Lab.Text) & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(CfgFile, "[Stimuli-2 Label] " & Trim(tbStim2Lab.Text) & vbCrLf, True)

            'now parse through textbox looking for stuff

            If tbStim1.Text = "" Or tbStim2.Text = "" Then
                MsgBox("You must enter stimulus data to proceed")
            Else
                Dim i As Integer
                Stim1stuff = Split(tbStim1.Text, vbCrLf)
                Stim2stuff = Split(tbStim2.Text, vbCrLf)

                For i = 0 To UBound(Stim1stuff)
                    If Stim1stuff(i) <> "" Then
                        Stim1clean.Add(Trim(Stim1stuff(i)))
                    End If
                Next i
                For i = 0 To UBound(Stim2stuff)
                    If Stim2stuff(i) <> "" Then
                        Stim2clean.Add(Trim(Stim2stuff(i)))
                    End If
                Next i
            End If

            For i = 0 To Stim1clean.Count - 1
                My.Computer.FileSystem.WriteAllText(CfgFile, "[Stimuli-1] " & Trim(Stim1clean.Item(i)) & vbCrLf, True)
            Next i
            For i = 0 To Stim2clean.Count - 1
                My.Computer.FileSystem.WriteAllText(CfgFile, "[Stimuli-2] " & Trim(Stim2clean.Item(i)) & vbCrLf, True)
            Next i

            'go to the next form
            Me.Hide()
            SetUp3.ThereAreImages = hasImage
            SetUp3.Show()

        Catch ex As Exception
            MsgBox("An error occured when trying to write to the configuration file: " & CfgFile & ".")
            Me.Hide()
        End Try

    End Sub
End Class