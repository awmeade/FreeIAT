Public Class TestWords
    'these are public variables that can be referenced and used by all subs and functions on this form

    Dim title As String
    Dim value As Integer
    Dim StageTime As New Stopwatch
    Dim TrialCount As Integer
    Dim MaxTrials As Integer
    Dim trials As Integer
    Dim CorrectResponse As String
    Dim OKtoGO As Boolean


    Private Sub TestWords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReDim RightWrong(0 To TotalTrials - 1)
        'just centers the panel that contains the labels and buttons
        aPanel.BorderStyle = BorderStyle.None
        aPanel.Left = (Me.Width - aPanel.Width) / 2
        WdSetLabel1.Text = WdSet1Label
        WdSetLabel2.Text = WdSet2Label

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
        WdSetLabel1.Visible = False
        WdSetLabel2.Visible = False
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
            WdSetLabel1.Text = WdSet1Label
            WdSetLabel2.Text = WdSet2Label
            WordLabel1.Text = Stim1Label
            WordLabel2.Text = Stim2Label
            WdSetLabel1.Visible = True
            WdSetLabel2.Visible = True
            WordLabel1.Visible = True
            WordLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 3"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 3" Then
            WdSetLabel1.Text = WdSet2Label
            WdSetLabel2.Text = WdSet1Label
            WdSetLabel1.Visible = True
            WdSetLabel2.Visible = True
            startLabel.Text = "Press Space Bar to Begin Stage 4"
        ElseIf startLabel.Text = "Press Space Bar to Begin Stage 4" Then
            WdSetLabel1.Text = WdSet2Label
            WdSetLabel2.Text = WdSet1Label
            WordLabel1.Text = Stim1Label
            WordLabel2.Text = Stim2Label
            WdSetLabel1.Visible = True
            WdSetLabel2.Visible = True
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


        CurrentStage = 1
        MaxTrials = Stage1num
        StageTime.Reset()

        WdSetLabel1.Text = WdSet1Label      ' label on the left
        WdSetLabel2.Text = WdSet2Label      ' label on the right
    
        CorrectResponse = ""            'clean this up

        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and number of total WdSet words.
        value = CInt(Int((FullWdSet.Count * Rnd())))

        'Dont admin the same thing twice in a row
        If value = OldStimVal Then
            Do While value = OldStimVal
                value = CInt(Int((FullWdSet.Count * Rnd())))
            Loop
        End If

        StimContainer.Add(FullWdSet.Item(value))  'record what stimulus was chosen
        StimWord.Text = FullWdSet.Item(value)    'load up the word
        OldStimVal = value          ' mark that this one was chosen so it won't be chosen again next time


        ' Assign which is correct 
        If FullWdSetNames.Item(value).StartsWith("[WordSet-1]") Then
            CorrectResponse = "E"
        ElseIf FullWdSetNames.Item(value).StartsWith("[WordSet-2]") Then
            CorrectResponse = "I"
        End If

        ' Display things
        WdSetLabel1.Visible = True
        WdSetLabel2.Visible = True
        StimWord.Visible = True

        'starts the time and waits for KeyDown Event
        StageTime.Start()


    End Sub
    Public Sub Stage_2()
        CurrentStage = 2
        MaxTrials = Stage2num

        StageTime.Reset()
        StimWord.ForeColor = Color.LimeGreen

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

        WdSetLabel1.Text = WdSet1Label
        WdSetLabel2.Text = WdSet2Label
        WordLabel1.Text = Stim1Label
        WordLabel2.Text = Stim2Label

        Randomize()             ' Initialize the random-number generator.
        If Rnd() <= 0.5 Then        ' decide to show either stimulus word or WdSet word
            ' show Wdset word
            value = CInt(Int((FullWdSet.Count * Rnd())))
            If OldStimType = 1 And OldStimVal = value Then  ' we just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullWdSet.Count * Rnd()))) 'find a new one
                Loop
            End If
            StimContainer.Add(FullWdSet.Item(value))  'record what stimulus was chosen
            StimWord.ForeColor = Color.White
            StimWord.Text = FullWdSet.Item(value)

            ' Assign which is correct 
            If FullWdSetNames.Item(value).StartsWith("[WordSet-1]") Then
                CorrectResponse = "E"
            ElseIf FullWdSetNames.Item(value).StartsWith("[WordSet-2]") Then
                CorrectResponse = "I"
            End If

            OldStimType = 1     ' mark that an WdSet word was displayed

        Else            ' showing a stimulus word
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
            StimWord.ForeColor = Color.LimeGreen

            StimWord.Text = FullWordSet.Item(value) 'show the word

            OldStimType = 2     'mark that word was displayed
        End If
        OldStimVal = value  'mark this one as the one that was displayed

        WdSetLabel1.Visible = True
        WdSetLabel2.Visible = True
        WordLabel1.Visible = True
        WordLabel2.Visible = True
        StimWord.Visible = True


        StageTime.Start()
    End Sub
    Public Sub Stage_4()
        CurrentStage = 4
        MaxTrials = Stage4num

        StageTime.Reset()

        WdSetLabel1.Text = WdSet2Label      ' left label.  flipped from Stage 1.
        WdSetLabel2.Text = WdSet1Label    ' right label.  flipped from Stage 1.

        Randomize()
        value = CInt(Int((FullWdSet.Count * Rnd())))

        If value = OldStimVal Then
            Do While value = OldStimVal
                value = CInt(Int((FullWdSet.Count * Rnd())))
            Loop
        End If
        OldStimVal = value


        If FullWdSetNames.Item(value).StartsWith("[WordSet-2]") Then
            CorrectResponse = "E"
        ElseIf FullWdSetNames.Item(value).StartsWith("[WordSet-1]") Then
            CorrectResponse = "I"
        End If


        StimContainer.Add(FullWdSet.Item(value))  'record what stimulus was chosen
        StimWord.Text = FullWdSet.Item(value)

        WdSetLabel1.Visible = True
        WdSetLabel2.Visible = True
        StimWord.Visible = True

        StageTime.Start()
    End Sub
    Public Sub Stage_5()
        CurrentStage = 5
        MaxTrials = Stage5num

        StageTime.Reset()

        WdSetLabel1.Text = WdSet2Label
        WdSetLabel2.Text = WdSet1Label
        WordLabel1.Text = Stim1Label
        WordLabel2.Text = Stim2Label

        ' Initialize the random-number generator.
        Randomize()             ' Initialize the random-number generator.
        If Rnd() <= 0.5 Then        ' decide to show either word or picture

            value = CInt(Int((FullWdSet.Count * Rnd())))
            If OldStimType = 1 And OldStimVal = value Then  ' we just did this one
                Do While value = OldStimVal
                    value = CInt(Int((FullWdSet.Count * Rnd()))) 'find a new one
                Loop
            End If

            StimContainer.Add(FullWdSet.Item(value))  'record what WdSet stimulus was chosen
            StimWord.ForeColor = Color.White

            StimWord.Text = FullWdSet.Item(value)
            ' Assign which is correct 
            If FullWdSetNames.Item(value).StartsWith("[WordSet-2]") Then
                CorrectResponse = "E"
            ElseIf FullWdSetNames.Item(value).StartsWith("[WordSet-1]") Then
                CorrectResponse = "I"
            End If

            OldStimType = 1     ' mark that a WdSet word was displayed


        Else            ' showing a stimulus word
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
            StimWord.ForeColor = Color.LimeGreen

            StimWord.Text = FullWordSet.Item(value) 'show the word

            OldStimType = 2     'mark that word was displayed
        End If
        OldStimVal = value  'mark this one as the one that was displayed

        StimWord.Visible = True
        WdSetLabel1.Visible = True
        WdSetLabel2.Visible = True
        WordLabel1.Visible = True
        WordLabel2.Visible = True

        StageTime.Start()
    End Sub







    Private Sub TestWords_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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
                        WdSetLabel1.Visible = False
                        WdSetLabel2.Visible = False

                        WordLabel1.Visible = False
                        WordLabel2.Visible = False
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
                        WdSetLabel1.Visible = False
                        WdSetLabel2.Visible = False

                        WordLabel1.Visible = False
                        WordLabel2.Visible = False
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