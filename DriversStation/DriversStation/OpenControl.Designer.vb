<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.ClientRB = New System.Windows.Forms.RadioButton()
        Me.ServerRB = New System.Windows.Forms.RadioButton()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IPTxt = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClientRB
        '
        Me.ClientRB.AutoSize = True
        Me.ClientRB.Location = New System.Drawing.Point(27, 60)
        Me.ClientRB.Name = "ClientRB"
        Me.ClientRB.Size = New System.Drawing.Size(51, 17)
        Me.ClientRB.TabIndex = 11
        Me.ClientRB.TabStop = True
        Me.ClientRB.Text = "Client"
        Me.ClientRB.UseVisualStyleBackColor = True
        '
        'ServerRB
        '
        Me.ServerRB.AutoSize = True
        Me.ServerRB.Location = New System.Drawing.Point(27, 37)
        Me.ServerRB.Name = "ServerRB"
        Me.ServerRB.Size = New System.Drawing.Size(56, 17)
        Me.ServerRB.TabIndex = 10
        Me.ServerRB.TabStop = True
        Me.ServerRB.Text = "Server"
        Me.ServerRB.UseVisualStyleBackColor = True
        '
        'StartBtn
        '
        Me.StartBtn.Location = New System.Drawing.Point(230, 106)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(75, 23)
        Me.StartBtn.TabIndex = 9
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(185, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Team # or IP:"
        '
        'IPTxt
        '
        Me.IPTxt.Location = New System.Drawing.Point(188, 57)
        Me.IPTxt.Name = "IPTxt"
        Me.IPTxt.Size = New System.Drawing.Size(117, 20)
        Me.IPTxt.TabIndex = 7
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'OpenControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ClientRB)
        Me.Controls.Add(Me.ServerRB)
        Me.Controls.Add(Me.StartBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IPTxt)
        Me.Name = "OpenControl"
        Me.Size = New System.Drawing.Size(341, 158)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClientRB As System.Windows.Forms.RadioButton
    Friend WithEvents ServerRB As System.Windows.Forms.RadioButton
    Friend WithEvents StartBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IPTxt As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider

End Class
