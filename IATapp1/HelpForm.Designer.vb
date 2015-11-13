<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpForm))
        Me.Web1 = New System.Windows.Forms.WebBrowser
        Me.CloseButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Web1
        '
        Me.Web1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Web1.Location = New System.Drawing.Point(0, 0)
        Me.Web1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Web1.MinimumSize = New System.Drawing.Size(15, 16)
        Me.Web1.Name = "Web1"
        Me.Web1.Size = New System.Drawing.Size(669, 535)
        Me.Web1.TabIndex = 0
        '
        'CloseButton
        '
        Me.CloseButton.Location = New System.Drawing.Point(301, 560)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(70, 32)
        Me.CloseButton.TabIndex = 1
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'HelpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 618)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Web1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "HelpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Web1 As System.Windows.Forms.WebBrowser
    Friend WithEvents CloseButton As System.Windows.Forms.Button
End Class
