<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartForm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.idBox = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.myPanel = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.UpdateButton = New System.Windows.Forms.Button
        Me.myPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 57)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Click help for instructions on setting up the IAT." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please enter the participan" & _
            "t's ID below and click begin."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'idBox
        '
        Me.idBox.Location = New System.Drawing.Point(142, 134)
        Me.idBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.idBox.Name = "idBox"
        Me.idBox.Size = New System.Drawing.Size(129, 20)
        Me.idBox.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(121, 183)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 58)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Begin"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(208, 302)
        Me.exitButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(82, 22)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'myPanel
        '
        Me.myPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.myPanel.AutoSize = True
        Me.myPanel.Controls.Add(Me.UpdateButton)
        Me.myPanel.Controls.Add(Me.Button3)
        Me.myPanel.Controls.Add(Me.Button2)
        Me.myPanel.Controls.Add(Me.Label2)
        Me.myPanel.Controls.Add(Me.exitButton)
        Me.myPanel.Controls.Add(Me.Label1)
        Me.myPanel.Controls.Add(Me.idBox)
        Me.myPanel.Controls.Add(Me.Button1)
        Me.myPanel.Location = New System.Drawing.Point(153, 41)
        Me.myPanel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.myPanel.Name = "myPanel"
        Me.myPanel.Size = New System.Drawing.Size(406, 328)
        Me.myPanel.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(121, 268)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 22)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Help / About"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(208, 268)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 22)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "SetUp"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 136)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "ID:"
        '
        'UpdateButton
        '
        Me.UpdateButton.Location = New System.Drawing.Point(121, 302)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(82, 23)
        Me.UpdateButton.TabIndex = 7
        Me.UpdateButton.Text = "Update"
        Me.UpdateButton.UseVisualStyleBackColor = True
        '
        'StartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 447)
        Me.Controls.Add(Me.myPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "StartForm"
        Me.Text = "FreeIAT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.myPanel.ResumeLayout(False)
        Me.myPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents idBox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents myPanel As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents UpdateButton As System.Windows.Forms.Button
End Class
