Public Class SetUp3
    Public ThereAreImages As Boolean     ' gets this passed from the previous SetupForm form


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub SetUp3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ThereAreImages = True Then
            Label3.Text = "Enter the filename of each picture in Condition 1 in the box below, hitting return after each. If images are in subfolders, start the filename with 'subfolder\'."
            Label4.Text = "Enter the filename of each picture in Condition 2 in the box below, hitting return after each. If images are in subfolders, start the filename with 'subfolder\'."
        End If
    End Sub

   
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim CfgFile As String = folderPath & "/Config.txt"
        Dim Stim1stuff
        Dim Stim2stuff
        Dim Stim1clean As New ArrayList
        Dim Stim2clean As New ArrayList

        Try
            If ThereAreImages = True Then
                My.Computer.FileSystem.WriteAllText(CfgFile, "[ImageSet-1 Label] " & Trim(tbStim1Lab.Text) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(CfgFile, "[ImageSet-2 Label] " & Trim(tbStim2Lab.Text) & vbCrLf, True)
            ElseIf ThereAreImages = False Then
                My.Computer.FileSystem.WriteAllText(CfgFile, "[WordSet-1 Label] " & Trim(tbStim1Lab.Text) & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(CfgFile, "[WordSet-2 Label] " & Trim(tbStim2Lab.Text) & vbCrLf, True)
            End If

            'now parse through textbox looking for stuff

            If tbStim1.Text = "" Or tbStim2.Text = "" Then
                MsgBox("You must enter stimulus data to proceed.")
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

            Dim printMe1 As String = ""
            Dim printMe2 As String = ""
            If ThereAreImages = True Then
                printMe1 = "[ImageSet-1] "
                printMe2 = "[ImageSet-2] "
            ElseIf ThereAreImages = False Then
                printMe1 = "[WordSet-1] "
                printMe2 = "[WordSet-2] "
            End If

            For i = 0 To Stim1clean.Count - 1
                My.Computer.FileSystem.WriteAllText(CfgFile, printMe1 & Trim(Stim1clean.Item(i)) & vbCrLf, True)
            Next i
            For i = 0 To Stim2clean.Count - 1
                My.Computer.FileSystem.WriteAllText(CfgFile, printMe2 & Trim(Stim2clean.Item(i)) & vbCrLf, True)
            Next i

            'go to the next form where you input the number of trials per each of the 5 stages
            Me.Hide()
            SetUp4.Show()

        Catch ex As Exception
            MsgBox("An error occured when trying to write to the configuration file: " & CfgFile & ".")
            Me.Hide()
        End Try

    End Sub
End Class