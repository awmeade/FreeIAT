Public Class TestPics
    'these are public variables that can be referenced and used by all subs and functions on this form

    Dim title As String
    Dim value As Integer
    Dim StageTime As New Stopwatch
    Dim TrialCount As Integer
    Dim MaxTrials As Integer
    Dim trials As Integer
    Dim CorrectResponse As String
    Dim OKtoGO As Boolean
    Dim PutString As String
    Dim StartHere1 As Integer
    Dim StartHere2 As Integer
    Dim StartHere As Integer



    Private Sub TestPics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReDim RightWrong(0 To TotalTrials - 1)
        'just centers the panel that contains the labels and buttons
        aPanel.BorderStyle = BorderStyle.None
        aPanel.Left = (Me.Width - aPanel.Width) / 2
        ImageLabel1.Text = ImageSet1Label
        ImageLabel2.Text = ImageSet2Label

        'Initialize the correct/incorrect array to 9 (missing)
        Dim Q As Integer
        For Q = 0 To TotalTrials - 1
            RightWrong(Q) = 9
        Next
        TrialCount = 1   'initialize trailcounter
        startLabel.Text = "Press Space Bar to Begin"
        OKtoGO = False

    End Sub

    Private Sub StartNext()
        Me.Focus()
        trials = 1
        OKtoGO = True
        If startLabel.Text = "Press Space Bar to Begin" Then
            Stage_1()
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 2" Then
            Stage_2()
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 3" Then
            Stage_3()
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 4" Then
            Stage_4()
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 5" Then
            Stage_5()
        ElseIf startLabel.Text = "Press Space Bar to Exit" Then
            Save_and_Exit()
        End If
        startLabel.Visible = False
    End Sub



    Public Sub clear_page()

        OKtoGO = False      'don't let keydown event have effect until start button is clicked
        CurrentStage = 0
        WordLabel1.Visible = False
        WordLabel2.Visible = False
        StimWord.Visible = False
        ImageLabel1.Visible = False
        ImageLabel2.Visible = False
        StimImage.Visible = False
        startLabel.Visible = True
        WrongBoxLeft.Visible = False
        WrongBoxRt.Visible = False

        If startLabel.Text = "Press Space Bar to Begin" Then
            WordLabel1.Text = Stim1Label
            WordLabel2.Text = Stim2Label
            WordLabel1.Visible = True
            WordLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 2"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 2" Then
            ImageLabel1.Text = ImageSet1Label
            ImageLabel2.Text = ImageSet2Label
            WordLabel1.Text = Stim1Label
            WordLabel2.Text = Stim2Label
            ImageLabel1.Visible = True
            ImageLabel2.Visible = True
            WordLabel1.Visible = True
            WordLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 3"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 3" Then
            ImageLabel1.Text = ImageSet2Label
            ImageLabel2.Text = ImageSet1Label
            ImageLabel1.Visible = True
            ImageLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 4"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 4" Then
            ImageLabel1.Text = ImageSet2Label
            ImageLabel2.Text = ImageSet1Label
            WordLabel1.Text = Stim1Label
            WordLabel2.Text = Stim2Label
            ImageLabel1.Visible = True
            ImageLabel2.Visible = True
            WordLabel1.Visible = True
            WordLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 5"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 5" Then
            StimWord.Text = "Thank you!"
            StimWord.Visible = True
            startLabel.Text = "Press Space Bar to Exit"
        End If


        'reset these to clear out old stimulus type and values
        OldStimType = 99
        OldStimVal = 99


    End Sub


    Public Sub Stage_1()
        ' Currently set up to admin images

        CurrentStage = 1
        MaxTrials = Stage1num
        StageTime.Reset()

        ImageLabel1.Text = ImageSet1Label     ' label on the left
        ImageLabel2.Text = ImageSet2Label     ' label on the right
        CorrectResponse = ""            'clean this up
        PutString = ""
        StartHere = 0

        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and number of total images.
        value = CInt(Int((FullImageSet.Count * Rnd())))

        'Dont admin the same thing twice in a row
        If value = OldStimVal Then
            Do While value = OldStimVal
                value = CInt(Int((FullImageSet.Count * Rnd())))
            Loop
        End If

        'See if a full path is specified and if so, strip out all but filename. Allow for both / and \ 
        If InStr(FullImageFnames.Item(value), "/") > InStr(FullImageFnames.Item(value), "\") Then
            StartHere = InStr(FullImageFnames.Item(value), "/")
        Else
            StartHere = InStr(FullImageFnames.Item(value), "\")
        End If

        If StartHere = 0 Then   ' not present
            PutString = FullImageFnames.Item(value)
        Else
            PutString = FullImageFnames.Item(value).substring(StartHere)
        End If
        'Need to add something here to get rid of subfolder strings.
        StimContainer.Add(PutString)  'record what stimulus was chosen
        StimImage.ImageLocation = folderPath + "\" + FullImageFnames.Item(value)    'load up the image
        OldStimVal = value          ' mark that this one was chosen so it won't be chosen again next time


        ' Assign which is correct 
        If FullImageSet(value).StartsWith("[ImageSet-1]") Then
            CorrectResponse = "E"
        ElseIf FullImageSet(value).StartsWith("[ImageSet-2]") Then
            CorrectResponse = "I"
        End If

        ' Display things
        ImageLabel1.Visible = True
        ImageLabel2.Visible = True
        StimImage.Visible = True


        'starts the time and waits for KeyDown Event
        StageTime.Start()


    End Sub
    Public Sub Stage_2()
        CurrentStage = 2
        MaxTrials = Stage2num

        StageTime.Reset()

        WordLabel1.Text = Stim1Label    'left label
        WordLabel2.Text = Stim2Label    'right label

        Randomize()  ' Initialize the random-number generator.
        value = CInt(Int((FullWordSet.Count * Rnd())))
        If value = OldStimVal Then  'Don't repeat this stimulus
            Do While value = OldStimVal 'look for another stimulus
                value = CInt(Int((FullWordSet.Count * Rnd())))
            Loop
        End If
        OldStimVal = value  'mark this one as the one that was displayed
        StimContainer.Add(FullWordSet.Item(value))  'record what stimulus was chosen

        StimWord.Text = FullWordSet.Item(value) 'Diplay item

        ' Assign which is correct 
        If FullWordNames(value).StartsWith("[Stimuli-1]") Then
            CorrectResponse = "E"
        ElseIf FullWordNames(value).StartsWith("[Stimuli-2]") Then
            CorrectResponse = "I"
        End If

        'show things
        WordLabel1.Visible = True
        WordLabel2.Visible = True
        StimWord.Visible = True
        StageTime.Start()      'start the clock and wait for KeyDown event
    End Sub
    Public Sub Stage_3()

        CurrentStage = 3
        MaxTrials = Stage3num


        StageTime.Reset()

        ImageLabel1.Text = ImageSet1Label
        ImageLabel2.Text = ImageSet2Label
        WordLabel1.Text = Stim1Label
        WordLabel2.Text = Stim2Label

        Randomize()             ' Initialize the random-number generator. decide to show either word or picture
        If Rnd() <= 0.5 Then        ' show a picture

            value = CInt(Int((FullImageSet.Count * Rnd())))
            If OldStimType = 1 And OldStimVal = value Then  ' we just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullImageSet.Count * Rnd()))) 'find a new one
                Loop
            End If

            'See if a full path is specified and if so, strip out all but filename.
            If InStr(FullImageFnames.Item(value), "/") > InStr(FullImageFnames.Item(value), "\") Then
                StartHere = InStr(FullImageFnames.Item(value), "/")
            Else
                StartHere = InStr(FullImageFnames.Item(value), "\")
            End If


            If StartHere = 0 Then   ' not present
                PutString = FullImageFnames.Item(value)
            Else
                PutString = FullImageFnames.Item(value).substring(StartHere)                
            End If
            'Need to add something here to get rid of subfolder strings.
            StimContainer.Add(PutString)  'record what stimulus was chosen for output
            StimImage.ImageLocation = folderPath & "\" & FullImageFnames.Item(value)

            ' Assign which is correct 
            If FullImageSet(value).StartsWith("[ImageSet-1]") Then
                CorrectResponse = "E"
            ElseIf FullImageSet(value).StartsWith("[ImageSet-2]") Then
                CorrectResponse = "I"
            End If

            StimImage.Visible = True    'display image
            StimWord.Visible = False    'don't display words
            OldStimType = 1     ' mark that an image was displayed

        Else            ' showing a word
            value = CInt(Int((FullWordSet.Count * Rnd())))

            If OldStimType = 2 And OldStimVal = value Then  'just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullWordSet.Count * Rnd())))  'find a new one
                Loop
            End If

            ' Assign which is correct 
            If FullWordNames(value).StartsWith("[Stimuli-1]") Then
                CorrectResponse = "E"
            ElseIf FullWordNames(value).StartsWith("[Stimuli-2]") Then
                CorrectResponse = "I"
            End If

            StimContainer.Add(FullWordSet.Item(value))  'record what stimulus was chosen
            StimWord.Text = FullWordSet.Item(value) 'show the word

            StimWord.Visible = True
            StimImage.Visible = False   'dont show the image
            OldStimType = 2     'mark that word was displayed
        End If
        OldStimVal = value  'mark this one as the one that was displayed

        ImageLabel1.Visible = True
        ImageLabel2.Visible = True
        WordLabel1.Visible = True
        WordLabel2.Visible = True

        StageTime.Start()
    End Sub
    Public Sub Stage_4()
        CurrentStage = 4
        MaxTrials = Stage4num

        StageTime.Reset()

        ImageLabel1.Text = ImageSet2Label   ' left label.  flipped from Stage 1.
        ImageLabel2.Text = ImageSet1Label   ' right label.  flipped from Stage 1.

        Randomize()
        value = CInt(Int((FullImageSet.Count * Rnd())))

        If value = OldStimVal Then
            Do While value = OldStimVal
                value = CInt(Int((FullImageSet.Count * Rnd())))
            Loop
        End If
        OldStimVal = value

        'See if a full path is specified and if so, strip out all but filename.
        If InStr(FullImageFnames.Item(value), "/") > InStr(FullImageFnames.Item(value), "\") Then
            StartHere = InStr(FullImageFnames.Item(value), "/")
        Else
            StartHere = InStr(FullImageFnames.Item(value), "\")
        End If
        If StartHere = 0 Then   ' not present
            PutString = FullImageFnames.Item(value)
        Else
            PutString = FullImageFnames.Item(value).substring(StartHere)
        End If
        'Need to add something here to get rid of subfolder strings.
        StimContainer.Add(PutString)  'record what stimulus was chosen



        If FullImageSet(value).StartsWith("[ImageSet-2]") Then
            CorrectResponse = "E"
        ElseIf FullImageSet(value).StartsWith("[ImageSet-1]") Then
            CorrectResponse = "I"
        End If

        StimImage.ImageLocation = folderPath & "\" & FullImageFnames.Item(value)

        ImageLabel1.Visible = True
        ImageLabel2.Visible = True
        StimImage.Visible = True

        StageTime.Start()
    End Sub
    Public Sub Stage_5()
        CurrentStage = 5
        MaxTrials = Stage5num


        StageTime.Reset()

        ImageLabel1.Text = ImageSet2Label
        ImageLabel2.Text = ImageSet1Label
        WordLabel1.Text = Stim1Label
        WordLabel2.Text = Stim2Label

        ' Initialize the random-number generator.
        Randomize()             ' Initialize the random-number generator.
        If Rnd() <= 0.5 Then        ' decide to show either word or picture

            value = CInt(Int((FullImageSet.Count * Rnd())))
            If OldStimType = 1 And OldStimVal = value Then  ' we just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullImageSet.Count * Rnd()))) 'find a new one
                Loop
            End If

            'See if a full path is specified and if so, strip out all but filename.
            If InStr(FullImageFnames.Item(value), "/") > InStr(FullImageFnames.Item(value), "\") Then
                StartHere = InStr(FullImageFnames.Item(value), "/")
            Else
                StartHere = InStr(FullImageFnames.Item(value), "\")
            End If

            If StartHere = 0 Then   ' not present

                PutString = FullImageFnames.Item(value)
            Else
                PutString = FullImageFnames.Item(value).substring(StartHere)
            End If
            'Need to add something here to get rid of subfolder strings.
            StimContainer.Add(PutString)  'record what stimulus was chosen


            StimImage.ImageLocation = folderPath & "\" & FullImageFnames.Item(value)
            ' Assign which is correct 
            If FullImageSet(value).StartsWith("[ImageSet-2]") Then
                CorrectResponse = "E"
            ElseIf FullImageSet(value).StartsWith("[ImageSet-1]") Then
                CorrectResponse = "I"
            End If

            StimImage.Visible = True    'display image
            StimWord.Visible = False    'don't display words
            OldStimType = 1     ' mark that an image was displayed


        Else            ' showing a word
            value = CInt(Int((FullWordSet.Count * Rnd())))

            If OldStimType = 2 And OldStimVal = value Then  'just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullWordSet.Count * Rnd())))  'find a new one
                Loop
            End If

            ' Assign which is correct 
            If FullWordNames(value).StartsWith("[Stimuli-1]") Then
                CorrectResponse = "E"
            ElseIf FullWordNames(value).StartsWith("[Stimuli-2]") Then
                CorrectResponse = "I"
            End If

            StimContainer.Add(FullWordSet.Item(value))  'record what stimulus was chosen
            StimWord.Text = FullWordSet.Item(value) 'show the word
            StimWord.Visible = True
            StimImage.Visible = False   'dont show the image
            OldStimType = 2     'mark that word was displayed
        End If
        OldStimVal = value  'mark this one as the one that was displayed


        ImageLabel1.Visible = True
        ImageLabel2.Visible = True
        WordLabel1.Visible = True
        WordLabel2.Visible = True

        StageTime.Start()
    End Sub




    Public Sub TestPics_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If OKtoGO = True Then
            Select Case e.KeyCode       'a key was pressed
                Case Keys.E             ' an 'E' was pressed
                    If CorrectResponse = "E" Then  'correct response
                        TimeContainer.Add(StageTime.ElapsedMilliseconds)    'record time in the array
                        StageTime.Stop()
                        WrongBoxLeft.Visible = False    ' don't display any incorrect messages
                        WrongBoxRt.Visible = False

                        If RightWrong(TrialCount - 1) = 9 Then  ' item has not been previously missed
                            RightWrong(TrialCount - 1) = 1      ' mark item correct
                        End If

                        TrialCount += 1     'iterate the overall trial counter
                        If trials < MaxTrials Then      'not the last trial for the stage/block
                            trials += 1                 'iterate the trial counter
                        Else        ' this was the last trial for this stage/block
                            clear_page()    ' clear the page and go to the next stage/block
                                Exit Sub
                        End If


                        '' flash page
                        WordLabel1.Visible = False
                        WordLabel2.Visible = False
                        ImageLabel1.Visible = False
                        ImageLabel2.Visible = False
                        ' StimImage.Visible = False
                        StimWord.Visible = False
                        Call Delay(0.05)  'hold this long enough to be noticed
                    


                        ' run the next trial
                        If CurrentStage = 1 Then
                            Call Stage_1()
                        ElseIf CurrentStage = 2 Then
                            Call Stage_2()
                        ElseIf CurrentStage = 3 Then
                            Call Stage_3()
                        ElseIf CurrentStage = 4 Then
                            Call Stage_4()
                        ElseIf CurrentStage = 5 Then
                            Call Stage_5()
                        End If

                    Else 'E is incorrect
                        WrongBoxLeft.Visible = True
                        RightWrong(TrialCount - 1) = 0  ' record as incorrect in the array
                    End If
                Case Keys.I
                    If CorrectResponse = "I" Then  'correct response
                        TimeContainer.Add(StageTime.ElapsedMilliseconds)    'record time in the array
                        StageTime.Stop()
                        WrongBoxLeft.Visible = False    ' don't display any incorrect messages
                        WrongBoxRt.Visible = False

                        If RightWrong(TrialCount - 1) = 9 Then  ' item has not been previously missed
                            RightWrong(TrialCount - 1) = 1      ' mark item correct
                        End If

                        TrialCount += 1     'iterate the overall trial counter
                        If trials < MaxTrials Then      'not the last trial for the stage/block
                            trials += 1                 'iterate the block-specific trial counter
                        Else        ' this was the last trial for this stage/block
                            clear_page()    ' clear the page and go to the next stage/block
                                Exit Sub
                        End If

                        '' flash page
                        WordLabel1.Visible = False
                        WordLabel2.Visible = False
                        ImageLabel1.Visible = False
                        ImageLabel2.Visible = False
                        '  StimImage.Visible = False
                        StimWord.Visible = False
                        Call Delay(0.05)  'hold this long enough to be noticed



                        ' run the next trial
                        If CurrentStage = 1 Then
                            Call Stage_1()
                        ElseIf CurrentStage = 2 Then
                            Call Stage_2()
                        ElseIf CurrentStage = 3 Then
                            Call Stage_3()
                        ElseIf CurrentStage = 4 Then
                            Call Stage_4()
                        ElseIf CurrentStage = 5 Then
                            Call Stage_5()
                        End If


                    Else 'I is incorrect
                        WrongBoxRt.Visible = True
                        RightWrong(TrialCount - 1) = 0  ' record as incorrect in the array
                    End If
            End Select
        ElseIf OKtoGO = False Then
            Select Case e.KeyCode
                Case Keys.Space
                    Call StartNext()                    
            End Select
        End If
    End Sub

    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop

    End Sub
End Class
