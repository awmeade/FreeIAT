Public Class HelpForm

   

   
    Private Sub HelpForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Web1.Navigate(folderPath & "\Help.htm")
        Catch ex As Exception
            MsgBox("Cannot find Help.htm file in the folder: " & folderPath & "." & vbCrLf & _
                   "Please check for online documentation at the following website: http://www4.ncsu.edu/~awmeade/FreeIAT/FreeIAT.htm")
            Me.Hide()
        End Try

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

End Class