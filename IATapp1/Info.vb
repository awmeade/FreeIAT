Imports System.IO
Imports System
Imports System.Data
Imports System.Object
Imports System.Collections
Imports Microsoft.VisualBasic

Imports System.Data.OleDb
Imports System.Data.SqlTypes
Imports System.Data.SqlDbType
Imports System.Data.SqlClient
Imports System.Math


Public Class Info

    Private Sub Info_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
        'center panel on screen
        Panel1.Left = (Me.Width - Panel1.Width) / 2

        'load the title
        Label1.Text = iatTitle

        ' Lists the conditions on the info form.
        Label3.Text = Stim1Label    'positive words
        Label3.ForeColor = Color.DarkBlue

        Label4.Text = Stim2Label    'negative words
        Label4.ForeColor = Color.DarkRed


        Label8.Text = goodWords.Item(0)
        For i = 1 To goodWords.Count - 1
            Label8.Text = Label8.Text + ", " + goodWords.Item(i)
        Next
        Label8.ForeColor = Color.DarkBlue

        Label9.Text = badWords.Item(0)
        For i = 1 To badWords.Count - 1
            Label9.Text = Label9.Text + ", " + badWords.Item(i)
        Next
        Label9.ForeColor = Color.DarkRed

        If Pics = True Then

            Label5.Text = "First set of images"
            Label6.Text = "Second set of images"
            Label10.Text = ImageSet1Label
            Label11.Text = ImageSet2Label
        ElseIf Pics = False Then

            Label10.Text = WdSet1Label
            Label11.Text = WdSet2Label

            Label5.Text = WdSet1Label
            Label6.Text = WdSet2Label

            Label10.Text = WdSet1.Item(0)
            For i = 1 To WdSet1.Count - 1
                Label10.Text = Label10.Text + ", " + WdSet1.Item(i)
            Next
            Label11.Text = WdSet2.Item(0)
            For i = 1 To WdSet2.Count - 1
                Label11.Text = Label11.Text + ", " + WdSet2.Item(i)
            Next
        End If
        Label5.ForeColor = Color.DarkBlue
        Label10.ForeColor = Color.DarkBlue
        Label6.ForeColor = Color.DarkRed
        Label11.ForeColor = Color.DarkRed


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OldStimVal = 99
        OldStimType = 99

        Me.Hide()       'hides this form
        If Pics = True Then     ' uses pictures in IAT
            TestPics.Show()     'starts the test.... shows the test form that gets used over and over for each trial
        ElseIf Pics = False Then    'Does not use pictures in IAT
            TestWords.Show()
        End If
        
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        Me.Hide()   'quit button
        End
    End Sub

End Class