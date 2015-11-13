<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetUpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetUpForm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbImagesNo = New System.Windows.Forms.RadioButton
        Me.rbImagesYes = New System.Windows.Forms.RadioButton
        Me.lbImages = New System.Windows.Forms.Label
        Me.tbTitle = New System.Windows.Forms.TextBox
        Me.lbTitle = New System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(602, 126)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbImagesNo)
        Me.GroupBox1.Controls.Add(Me.rbImagesYes)
        Me.GroupBox1.Controls.Add(Me.lbImages)
        Me.GroupBox1.Controls.Add(Me.tbTitle)
        Me.GroupBox1.Controls.Add(Me.lbTitle)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(56, 143)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(499, 103)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "The Basics"
        '
        'rbImagesNo
        '
        Me.rbImagesNo.AutoSize = True
        Me.rbImagesNo.Location = New System.Drawing.Point(287, 65)
        Me.rbImagesNo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbImagesNo.Name = "rbImagesNo"
        Me.rbImagesNo.Size = New System.Drawing.Size(44, 21)
        Me.rbImagesNo.TabIndex = 3
        Me.rbImagesNo.TabStop = True
        Me.rbImagesNo.Text = "No"
        Me.rbImagesNo.UseVisualStyleBackColor = True
        '
        'rbImagesYes
        '
        Me.rbImagesYes.AutoSize = True
        Me.rbImagesYes.Location = New System.Drawing.Point(211, 65)
        Me.rbImagesYes.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rbImagesYes.Name = "rbImagesYes"
        Me.rbImagesYes.Size = New System.Drawing.Size(50, 21)
        Me.rbImagesYes.TabIndex = 2
        Me.rbImagesYes.TabStop = True
        Me.rbImagesYes.Text = "Yes"
        Me.rbImagesYes.UseVisualStyleBackColor = True
        '
        'lbImages
        '
        Me.lbImages.AutoSize = True
        Me.lbImages.Location = New System.Drawing.Point(13, 65)
        Me.lbImages.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbImages.Name = "lbImages"
        Me.lbImages.Size = New System.Drawing.Size(182, 17)
        Me.lbImages.TabIndex = 6
        Me.lbImages.Text = "Does your IAT use images?"
        '
        'tbTitle
        '
        Me.tbTitle.Location = New System.Drawing.Point(136, 20)
        Me.tbTitle.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbTitle.Name = "tbTitle"
        Me.tbTitle.Size = New System.Drawing.Size(344, 23)
        Me.tbTitle.TabIndex = 1
        '
        'lbTitle
        '
        Me.lbTitle.AutoSize = True
        Me.lbTitle.Location = New System.Drawing.Point(13, 25)
        Me.lbTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbTitle.Name = "lbTitle"
        Me.lbTitle.Size = New System.Drawing.Size(112, 17)
        Me.lbTitle.TabIndex = 0
        Me.lbTitle.Text = "Title of your IAT:"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(325, 275)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(66, 29)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next ->"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(244, 275)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 29)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SetUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 333)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SetUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure Your IAT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbTitle As System.Windows.Forms.Label
    Friend WithEvents tbTitle As System.Windows.Forms.TextBox
    Friend WithEvents rbImagesNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbImagesYes As System.Windows.Forms.RadioButton
    Friend WithEvents lbImages As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
