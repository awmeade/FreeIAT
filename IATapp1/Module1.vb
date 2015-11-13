' FreeIAT 1.0 Copyright 2008 Adam W. Meade
'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, version 3 of the License.

'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'    You should have received a copy of the GNU General Public License
'   along with this program.  If not, see <http://www.gnu.org/licenses/>.


Module Module1
    'these are global and can be used anywhere across any form
    Public goodWords As New ArrayList      ' probably want to make these global arrays instead of repeating the below on the next form
    Public badWords As New ArrayList
    Public folderPath As String     ' path of current directory
    Public configFile As String
    Public userID As String
    Public iatTitle As String       ' title of IAT
    Public ImageSet1Label As String ' label for images
    Public ImageSet2Label As String
    Public WdSet1Label As String    ' label for Word-only stimuli
    Public WdSet2Label As String
    Public Images1 As New ArrayList ' Array of images in group 1
    Public Images2 As New ArrayList ' Array of images in group 2
    Public FullImageSet As New ArrayList  ' Array of images in both groups
    Public FullWordSet As New ArrayList     ' Array of Words (positive and negative)
    Public FullImageFnames As New ArrayList 'Array of images in both groups with [image1] labels
    Public FullWordNames As New ArrayList  ' Array of Words (positive and negative) in both groups with [Stimuli] labels
    Public FullWdSet As New ArrayList       'Array of words in word-only stimuli
    Public FullWdSetNames As New ArrayList  'Array of words in word-only stimuli including [WordSet] labels
    Public WdSet1 As New ArrayList          'Array of words in word-only stimuli for Group 1
    Public WdSet2 As New ArrayList          'Array of words in word-only stimuli for Group 2

    Public Stage1num As Integer             ' # trials in stage 1
    Public Stage2num As Integer
    Public Stage3num As Integer
    Public Stage4num As Integer
    Public Stage5num As Integer
    Public TotalTrials As Integer           ' sum of 1-5 above
    Public OldStimVal As Integer            ' value for most recently presented stimulus
    Public OldStimType As Integer           ' value for type of most recently presented stimulus
    Public Stim1Label As String
    Public Stim2Label As String
    Public CurrentStage As Integer          ' indexes the current stage
    Public SaveFile As String               'filename to write to
    Public TimeContainer As New ArrayList   ' array that stores response times
    Public StimContainer As New ArrayList   'array that records the stimuli presented
    Public RightWrong() As Integer          ' array that records whether response was correct or incorrect
    Public Pics As Boolean
    Public CfgTitle As String               ' for Configuration wizzard
    Public OutPutDelim As String            ' how to delimit output



    Public Function myRound(ByVal X As Double, ByVal DP As Integer) As Double
        myRound = Int((X * 10 ^ DP) + 0.5) / 10 ^ DP
    End Function

    Public Sub ReadInData()
        Pics = False
        OutPutDelim = " "   ' default to output as space delimited
        'Reads in textfile, stores stimuli into array lists

        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(configFile)

                'opens up the configuration file .
                'MyReader.TextFieldType = FileIO.FieldType.Delimited
                'MyReader.SetDelimiters(",") ' File is not comma delimited, but deleting returns an error ?!?.

                MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
                MyReader.SetFieldWidths(-1)

                Dim currentRow As String()
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        Dim currentField As String

                        ' Read in each row in configuration file and put info into global arrays and strings
                        For Each currentField In currentRow
                            If currentField.Contains("[Title]") Then
                                iatTitle = currentField.Substring(8)
                                'Note.  Substring starts at column X and reads everything thereafter.
                            ElseIf currentField.Contains("[Stimuli-1 Label]") Then
                                Stim1Label = Trim(currentField.Substring(18))
                            ElseIf currentField.Contains("[Stimuli-2 Label]") Then
                                Stim2Label = Trim(currentField.Substring(18))
                            ElseIf currentField.Contains("[Stimuli-1]") Then
                                goodWords.Add(Trim(currentField.Substring(12)))
                                FullWordSet.Add(Trim(currentField.Substring(12)))
                                FullWordNames.Add(Trim(currentField))
                            ElseIf currentField.Contains("[Stimuli-2]") Then
                                badWords.Add(Trim(currentField.Substring(12)))
                                FullWordSet.Add(Trim(currentField.Substring(12)))
                                FullWordNames.Add(Trim(currentField))
                            ElseIf currentField.Contains("[ImageSet-1 Label]") Then
                                ' there are images... load these fields
                                ImageSet1Label = Trim(currentField.Substring(19))
                                Pics = True     ' IAT uses images
                            ElseIf currentField.Contains("[ImageSet-2 Label]") Then
                                ImageSet2Label = Trim(currentField.Substring(19))
                                Pics = True
                            ElseIf currentField.Contains("[ImageSet-1]") Then
                                Images1.Add(Trim(currentField.Substring(13)))
                                FullImageSet.Add(Trim(currentField))
                                FullImageFnames.Add(Trim(currentField.Substring(13)))
                                Pics = True
                            ElseIf currentField.Contains("[ImageSet-2]") Then
                                Images2.Add(Trim(currentField.Substring(13)))
                                FullImageSet.Add(Trim(currentField))
                                FullImageFnames.Add(Trim(currentField.Substring(13)))
                                Pics = True
                            ElseIf currentField.Contains("[WordSet-1 Label]") Then
                                ' there are words, not images, load these fields
                                WdSet1Label = Trim(currentField.Substring(18))
                                Pics = False     ' IAT does NOT use images
                            ElseIf currentField.Contains("[WordSet-2 Label]") Then
                                WdSet2Label = Trim(currentField.Substring(18))
                                Pics = False     ' IAT does NOT use images
                            ElseIf currentField.Contains("[WordSet-1]") Then
                                FullWdSet.Add(Trim(currentField.Substring(12))) 'all items in this array
                                WdSet1.Add(Trim(currentField.Substring(12)))    'just this set
                                FullWdSetNames.Add(currentField)                'all items, including [WordSet] label
                                Pics = False     ' IAT does NOT use images
                            ElseIf currentField.Contains("[WordSet-2]") Then
                                FullWdSet.Add(Trim(currentField.Substring(12))) 'all items in this array, no [WordSet] label
                                WdSet2.Add(Trim(currentField.Substring(12)))    'just this set, no [WordSet] label
                                FullWdSetNames.Add(currentField)                'all items, including [WordSet] label
                                Pics = False     ' IAT does NOT use images
                            ElseIf currentField.Contains("[Stage-1 Trials]") Then
                                'Read in number of trials
                                Stage1num = Trim(currentField.Substring(17))
                            ElseIf currentField.Contains("[Stage-2 Trials]") Then
                                Stage2num = Trim(currentField.Substring(17))
                            ElseIf currentField.Contains("[Stage-3 Trials]") Then
                                Stage3num = Trim(currentField.Substring(17))
                            ElseIf currentField.Contains("[Stage-4 Trials]") Then
                                Stage4num = Trim(currentField.Substring(17))
                            ElseIf currentField.Contains("[Stage-5 Trials]") Then
                                Stage5num = Trim(currentField.Substring(17))
                            ElseIf currentField.Contains("[Output Delimiter]") Then
                                Dim TempDelim = Trim(currentField.Substring(19))
                                If LCase(TempDelim) = "comma" Or TempDelim = "," Then
                                    OutPutDelim = ","
                                End If
                            End If

                            TotalTrials = Stage1num + Stage2num + Stage3num + Stage4num + Stage5num

                        Next
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        MsgBox("There is a problem with your configuration file.  Line " & ex.Message & _
                        "is not valid and will be skipped.")
                    End Try
                End While
            End Using
        Catch ex As Exception
            MsgBox("There is a problem with your configuration file in directory: " & folderPath)
            End
        End Try

    End Sub


    Public Function AllIsOK()
        ' start validating info from Config.txt file.
        Try
            Dim temp1 As Integer = CInt(Stage1num)
            Dim temp2 As Integer = CInt(Stage2num)
            Dim temp3 As Integer = CInt(Stage3num)
            Dim temp4 As Integer = CInt(Stage4num)
            Dim temp5 As Integer = CInt(Stage5num)
            'ok so far.  the # trials per stage is good.
            If temp1 < 1 Or temp2 < 1 Or temp3 < 1 Or temp4 < 1 Or temp5 < 1 Then
                MsgBox(configFile & " does not contain proper specification for the number of trials to administer at each stage/block." & _
                   vbCrLf & "Each stage/block must administer at least one trial. Please see help file for additional instruction on setting up the Config.txt file.")
                AllIsOK = False
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(configFile & " does not contain proper specification for the number of trials to administer at each stage/block." & _
                   vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
            AllIsOK = False
            Exit Function
        End Try
        'validate info in config file
        If Stim1Label = "" Or Stim2Label = "" Then
            MsgBox(configFile & " does not contain labels for the two stimuli." & _
                   vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
            AllIsOK = False
            Exit Function
        End If
        If goodWords.Count = 0 Or badWords.Count = 0 Then
            MsgBox(configFile & " does not contain stimuli in both conditions." & _
                   vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
            AllIsOK = False
            Exit Function
        End If

        If Pics = True Then 'pictures in use.
            If ImageSet1Label = "" Or ImageSet2Label = "" Then
                MsgBox(configFile & " does not contain labels for the two picture conditions." & _
                       vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
                AllIsOK = False
                Exit Function
            End If
            If Images1.Count = 0 Or Images2.Count = 0 Then
                MsgBox(configFile & " does not contain stimuli in each of the two picture conditions." & _
                       vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
                AllIsOK = False
                Exit Function
            End If
            Dim i As Integer

            Dim HasMe
            For i = 1 To FullImageSet.Count - 1
                HasMe = Dir$(folderPath & "\" & FullImageFnames.Item(i))
                If HasMe = "" Then    'cannot find file
                    MsgBox("Cannot find the file: " & folderPath & "\" & FullImageFnames.Item(i) & "." & vbCrLf & _
                           "Please check the configuration file and see help instructions " & configFile)
                    AllIsOK = False
                    Exit Function
                End If
            Next

        Else    'words, not pictures in use.
            If WdSet1Label = "" Or WdSet2Label = "" Then
                MsgBox(configFile & " does not contain labels for the two conditions." & _
                       vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
                AllIsOK = False
                Exit Function
            End If
            If WdSet1.Count = 0 Or WdSet2.Count = 0 Then
                MsgBox(configFile & " does not contain stimuli in each of the two conditions." & _
                       vbCrLf & "Please see help file for additional instruction on setting up the Config.txt file.")
                AllIsOK = False
                Exit Function
            End If
        End If

        AllIsOK = True
    End Function

    Public Sub Save_and_Exit()

        Dim Totaltime1 As Double
        Dim Totaltime2 As Double
        Dim Totaltime3 As Double
        Dim Totaltime4 As Double
        Dim Totaltime5 As Double

        Dim j As Integer = 0

        CurrentStage = 6


        'Write an 'all data' file and also a 'score only' file.

        'WRITE OUT ALLDATA FILE 
        SaveFile = folderPath & "\AllData.txt"
        Dim currentDate As Date = Now

        'write out title and date
        My.Computer.FileSystem.WriteAllText(SaveFile, "Participant: " & userID & " Test: " & iatTitle & _
            ". Format is stimulus, correct(1)/incorrect(0), time(ms).  Writes 10 trials per line." & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(SaveFile, currentDate & vbCrLf, True)

        'write out Block 1 info
        My.Computer.FileSystem.WriteAllText(SaveFile, "Block 1: ", True)
        My.Computer.FileSystem.WriteAllText(SaveFile, StimContainer.Item(0) & OutPutDelim & _
                RightWrong(0).ToString & OutPutDelim & TimeContainer.Item(0).ToString, True)
        Totaltime1 += TimeContainer.Item(0)
        j += 1
        For i = 1 To Stage1num - 1
            My.Computer.FileSystem.WriteAllText(SaveFile, OutPutDelim & StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
            Totaltime1 += TimeContainer.Item(j)
            j += 1
            If (i + 1) Mod 10 = 0 Then   'this is the 20th trial in block - create a hard return
                My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf, True)
            End If
        Next i
        My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf & "Block 1 Time: " & Totaltime1.ToString & vbCrLf, True)

        'write out Block 2 info
        My.Computer.FileSystem.WriteAllText(SaveFile, "Block 2: ", True)
        My.Computer.FileSystem.WriteAllText(SaveFile, StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
        Totaltime2 += TimeContainer.Item(j)
        j += 1

        For i = 1 To Stage2num - 1
            My.Computer.FileSystem.WriteAllText(SaveFile, OutPutDelim & StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
            Totaltime2 += TimeContainer.Item(j)
            j = j + 1
            If (i + 1) Mod 10 = 0 Then   'this is the 10th trial in block - create a hard return
                My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf, True)
            End If
        Next i
        My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf & "Block 2 Time: " & Totaltime2.ToString & vbCrLf, True)
        'write out Block 3 info 
        My.Computer.FileSystem.WriteAllText(SaveFile, "Block 3: ", True)
        My.Computer.FileSystem.WriteAllText(SaveFile, StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
        Totaltime3 += TimeContainer.Item(j)
        j += 1
        For i = 1 To Stage3num - 1
            My.Computer.FileSystem.WriteAllText(SaveFile, OutPutDelim & StimContainer.Item(j) & OutPutDelim & _
               RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
            Totaltime3 += TimeContainer.Item(j)
            j = j + 1
            If (i + 1) Mod 10 = 0 Then   'this is the 10th trial in block - create a hard return
                My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf, True)
            End If
        Next i
        My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf & "Block 3 Time: " & Totaltime3.ToString & vbCrLf, True)
        'write out Block 4 info 
        My.Computer.FileSystem.WriteAllText(SaveFile, "Block 4: ", True)
        My.Computer.FileSystem.WriteAllText(SaveFile, StimContainer.Item(j) & OutPutDelim & _
        RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
        Totaltime4 += TimeContainer.Item(j)
        j += 1
        For i = 1 To Stage4num - 1
            My.Computer.FileSystem.WriteAllText(SaveFile, OutPutDelim & StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
            Totaltime4 += TimeContainer.Item(j)
            j = j + 1
            If (i + 1) Mod 10 = 0 Then   'this is the 20th trial in block - create a hard return
                My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf, True)
            End If
        Next i
        My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf & "Block 4 Time: " & Totaltime4.ToString & vbCrLf, True)
        'write out Block 5 info 
        My.Computer.FileSystem.WriteAllText(SaveFile, "Block 5: ", True)
        My.Computer.FileSystem.WriteAllText(SaveFile, StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
        Totaltime5 += TimeContainer.Item(j)
        j += 1
        For i = 1 To Stage5num - 1
            My.Computer.FileSystem.WriteAllText(SaveFile, OutPutDelim & StimContainer.Item(j) & OutPutDelim & _
                RightWrong(j).ToString & OutPutDelim & TimeContainer.Item(j).ToString, True)
            Totaltime5 += TimeContainer.Item(j)
            j = j + 1
            If (i + 1) Mod 10 = 0 Then   'this is the 20th trial in block - create a hard return
                My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf, True)
            End If
        Next i
        My.Computer.FileSystem.WriteAllText(SaveFile, vbCrLf & "Block 5 Time: " & Totaltime5.ToString & vbCrLf, True)


        'Compute final scores using GetFinalScore function to return the final score value
        Call GetFinalScore()


        End 'quits program



    End Sub
    Public Sub GetFinalScore()
        Dim B3Container As New ArrayList
        Dim B5Container As New ArrayList
        Dim B3Correct As New ArrayList
        Dim B5Correct As New ArrayList
        Dim B3and5Container As New ArrayList
        Dim RtWrongContainer As New ArrayList
        Dim WhichContainer As New ArrayList
        Dim GNB03print As String
        Dim iLoop As Integer
        Dim FinB3container As New ArrayList
        Dim FinB5container As New ArrayList
        Dim FinB3meanPrint As String
        Dim FinB5meanPrint As String
        Dim SDprint As String
        Dim RawB3print As String
        Dim RawB5print As String
        Dim LhalfPrint As String
        Dim FhalfPrint As String

        ' Uses Table 4 from Greenwald, Nosek, and Banaji (2003).  Understanding and using the IAT.  JPSP, 85 (2), 197-216.


        Dim StartBlock3 As Integer = Stage1num + Stage2num      'location in array where 3rd phase starts
        Dim StartBlock5 As Integer = Stage1num + Stage2num + Stage3num + Stage4num  ' ditto for phase 5

        Dim Writefile = folderPath & "\ScoresOnly.txt"

        'put data into clean containers
        For iLoop = 0 To Stage3num - 1
            If TimeContainer.Item(iLoop + StartBlock3) < 10000 Then 'eliminate trials with latencies > 10000 as per GNB03 step 2
                B3Container.Add(TimeContainer.Item(iLoop + StartBlock3))    ' puts all data < 10000 into clean arraylist for Stage 3
                B3and5Container.Add(TimeContainer.Item(iLoop + StartBlock3)) ' puts all data < 10000 into clean arraylist for Stages 3 and 5 for SD computation in GNB step 6
                RtWrongContainer.Add(RightWrong(iLoop + StartBlock3))   'need this because some will be thrown out given the 10000 rule.  this containers size will match the above two
                WhichContainer.Add(3)   'will match with other arrays to indicate that stage 3 data is written out.
                If RightWrong(iLoop + StartBlock3) = 1 Then
                    B3Correct.Add(TimeContainer.Item(iLoop + StartBlock3))  ' keep correct responses only for GNB step 5
                End If
            End If
        Next iLoop
        For iLoop = 0 To Stage5num - 1
            If TimeContainer.Item(iLoop + StartBlock5) < 10000 Then
                B5Container.Add(TimeContainer.Item(iLoop + StartBlock5))
                B3and5Container.Add(TimeContainer.Item(iLoop + StartBlock5))
                RtWrongContainer.Add(RightWrong(iLoop + StartBlock5))
                WhichContainer.Add(5)
                If RightWrong(iLoop + StartBlock5) = 1 Then
                    B5Correct.Add(TimeContainer.Item(iLoop + StartBlock5))
                End If
            End If
        Next iLoop

        ''screen for more than 10% < 300 ms as per GNB03 Step 2b
        Dim lt300 As Integer = 0    'counter for < 300 ms responses
        For iLoop = 0 To B3and5Container.Count - 1
            If B3and5Container.Item(iLoop) < 300 Then
                lt300 += 1
            End If
        Next iLoop
        If lt300 / B3and5Container.Count > 0.1 Then
            GNB03print = "TooFast"
            FinB3meanPrint = "TooFast"
            FinB5meanPrint = "TooFast"
            SDprint = "TooFast"
            RawB3print = "TooFast"
            RawB5print = "TooFast"
            FhalfPrint = "TooFast"
            LhalfPrint = "TooFast"
        Else    'not too fast.  can go ahead and score

            'compute MEAN of correct items in block 3 (GNB step 5)
            Dim B3sum As Double = 0
            For iLoop = 0 To B3Correct.Count - 1
                B3sum += B3Correct.Item(iLoop)
            Next
            Dim B3CorrectAvg As Double = B3sum / B3Correct.Count

            'compute MEAN of correct in block 5
            Dim B5sum As Double = 0
            For iLoop = 0 To B5Correct.Count - 1
                B5sum += B5Correct.Item(iLoop)
            Next
            Dim B5CorrectAvg As Double = B5sum / B5Correct.Count


            'compute pooled standard deviation (using big D formula from GNB03). verified correct.  uses pop SD formula (N in denominator, not N-1).
            Dim iSum As Double = 0
            Dim iSqSum As Double = 0
            For iLoop = 0 To B3and5Container.Count - 1
                iSum += B3and5Container.Item(iLoop)
                iSqSum += (B3and5Container.Item(iLoop) ^ 2)
            Next iLoop
            Dim MeanSq As Double = (iSum / B3and5Container.Count) ^ 2
            Dim XsqOverN As Double = iSqSum / B3and5Container.Count
            Dim SD3and5 As Double = Math.Sqrt(XsqOverN - MeanSq)


            'error penalty phase.  See GNB step 7
            For iLoop = 0 To B3and5Container.Count - 1
                If RtWrongContainer.Item(iLoop) = 0 Then    'item was missed
                    If WhichContainer.Item(iLoop) = 3 Then   'was in stage 3
                        FinB3container.Add(B3CorrectAvg + 600)  'replace with penalty (mean + 600ms)
                    ElseIf WhichContainer.Item(iLoop) = 5 Then
                        FinB5container.Add(B5CorrectAvg + 600) 'replace with penalty (mean + 600ms)
                    End If
                ElseIf RtWrongContainer.Item(iLoop) = 1 Then  'item correct
                    If WhichContainer.Item(iLoop) = 3 Then   'was in stage 3
                        FinB3container.Add(B3and5Container.Item(iLoop))  ' copy in value
                    ElseIf WhichContainer.Item(iLoop) = 5 Then
                        FinB5container.Add(B3and5Container.Item(iLoop))  ' copy in value
                    End If
                End If
            Next iLoop

            'now that error sub has occured, compute average for block 3 
            Dim Sum3 As Double = 0
            For iLoop = 0 To FinB3container.Count - 1
                Sum3 += FinB3container.Item(iLoop)
            Next iLoop
            Dim B3FinAvg As Double = Sum3 / FinB3container.Count    'the final average for block 3

            'now that error sub has occured, compute average for block 5 
            Dim Sum5 As Double = 0
            For iLoop = 0 To FinB5container.Count - 1
                Sum5 += FinB5container.Item(iLoop)
            Next iLoop
            Dim B5FinAvg As Double = Sum5 / FinB5container.Count        'the final average for block 5


            'compute First and last half IAT scores to allow internal consistency analyes.
            'first half
            Dim FhalfSum As Double = 0
            Dim B3HalfIs As Integer = myRound(FinB3container.Count / 2, 0)    'where is the halfway point?
            For iLoop = 0 To B3HalfIs - 1
                FhalfSum += FinB3container.Item(iLoop)
            Next iLoop
            Dim B3FhalfAvg As Double = FhalfSum / B3HalfIs     'the final average for the first half of block 3
            FhalfSum = 0
            Dim B5HalfIs As Integer = myRound(FinB5container.Count / 2, 0)
            For iLoop = 0 To B5HalfIs - 1
                FhalfSum += FinB5container.Item(iLoop)
            Next iLoop
            Dim B5FhalfAvg As Double = FhalfSum / B5HalfIs       'the final average for the first half of block 5
            'compute D
            Dim FhalfD As Double = myRound((B5FhalfAvg - B3FhalfAvg) / SD3and5, 4)  'use same SD denominator as before
            FhalfPrint = Format(FhalfD, "###0.0000")
            'last half
            Dim LhalfSum As Double = 0
            For iLoop = B3HalfIs To FinB3container.Count - 1
                LhalfSum += FinB3container.Item(iLoop)
            Next iLoop
            Dim B3LhalfAvg As Double = LhalfSum / (FinB3container.Count - B3HalfIs)    'the final average for the last half of block 3
            LhalfSum = 0
            For iLoop = B5HalfIs To FinB5container.Count - 1
                LhalfSum += FinB5container.Item(iLoop)
            Next iLoop
            Dim B5LhalfAvg As Double = LhalfSum / (FinB5container.Count - B5HalfIs)    'the final average for the last half of block 3
            Dim LhalfD As Double = myRound((B5LhalfAvg - B3LhalfAvg) / SD3and5, 4)  'use same SD denominator as before
            LhalfPrint = Format(LhalfD, "###0.0000")



            ' round things off and get output ready to print
            Dim GNB03D As Double = myRound((B5FinAvg - B3FinAvg) / SD3and5, 4)
            GNB03print = Format(GNB03D, "###0.0000")
            Dim TempB3 As Double = myRound(B3FinAvg, 4)
            FinB3meanPrint = Format(TempB3, "####.0000")
            Dim TempB5 As Double = myRound(B5FinAvg, 4)
            FinB5meanPrint = Format(TempB5, "####.0000")
            Dim TempSD As Double = myRound(SD3and5, 4)
            SDprint = Format(TempSD, "####.0000")

            'compute the mean Block 3 time of raw data just for fun.
            Dim RawB3Sum As Double = 0
            For iLoop = 0 To B3Container.Count - 1
                RawB3Sum += B3Container.Item(iLoop)
            Next iLoop
            Dim RawB3Avg As Double = myRound(RawB3Sum / B3Container.Count, 4)
            RawB3print = Format(RawB3Avg, "####.0000")

            Dim RawB5Sum As Double = 0
            For iLoop = 0 To B5Container.Count - 1
                RawB5Sum += B5Container.Item(iLoop)
            Next iLoop
            Dim RawB5Avg As Double = myRound(RawB5Sum / B5Container.Count, 4)
            RawB5print = Format(RawB5Avg, "####.0000")

        End If      'ends if-then block for 300ms too fast response


        'Finally write everything out.
        Dim currentDate As Date = Now
        My.Computer.FileSystem.WriteAllText(Writefile, userID & OutPutDelim & GNB03print & OutPutDelim & _
          FinB3meanPrint & OutPutDelim & FinB5meanPrint & OutPutDelim & SDprint & OutPutDelim & RawB3print & _
          OutPutDelim & RawB5print & OutPutDelim & FhalfPrint & OutPutDelim & LhalfPrint & _
          OutPutDelim & currentDate & vbCrLf, True)


    End Sub

End Module
