Public Class SetUp4

  
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Dim CfgFile As String = folderPath & "\Config.txt"

        Try 'can convert these to integers?
            Dim Temp1 As Integer = CInt(tbS1.Text)
            Dim Temp2 As Integer = CInt(tbS2.Text)
            Dim Temp3 As Integer = CInt(tbS3.Text)
            Dim Temp4 As Integer = CInt(tbS4.Text)
            Dim Temp5 As Integer = CInt(tbS5.Text)
            'yes, valid data has been entered
            If Temp1 > 0 And Temp2 > 0 And Temp3 > 0 And Temp4 > 0 And Temp5 > 0 Then

                Try 'write to file
                    My.Computer.FileSystem.WriteAllText(CfgFile, "[Stage-1 Trials] " & tbS1.Text & vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(CfgFile, "[Stage-2 Trials] " & tbS2.Text & vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(CfgFile, "[Stage-3 Trials] " & tbS3.Text & vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(CfgFile, "[Stage-4 Trials] " & tbS4.Text & vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(CfgFile, "[Stage-5 Trials] " & tbS5.Text & vbCrLf, True)

                    If rbComma.Checked Then
                        My.Computer.FileSystem.WriteAllText(CfgFile, "[Output Delimiter] Comma" & vbCrLf, True)
                    End If


                    MsgBox("Configuration complete." & vbCrLf & "Configuration file saved as: " & CfgFile)
                Catch ex As Exception
                    MsgBox("An error occured when trying to write to the configuration file: " & CfgFile & ".")
                    Me.Hide()
                End Try
                Me.Close()
                SetUp3.Close()
                SetUp2.Close()
                SetUpForm.Close()

            Else
                MsgBox("Each stage/block must administer at least one trial.")
            End If


        Catch ex As Exception   'could not convert entries to integers
            MsgBox("Only whole numbers are allowed for the number of trials to administer in each stage.")

        End Try


    End Sub
End Class