<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Subscribed
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
        Me.ServerDGV = New System.Windows.Forms.DataGridView()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.StopBtn = New System.Windows.Forms.Button()
        CType(Me.ServerDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ServerDGV
        '
        Me.ServerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ServerDGV.Location = New System.Drawing.Point(12, 53)
        Me.ServerDGV.Name = "ServerDGV"
        Me.ServerDGV.Size = New System.Drawing.Size(610, 259)
        Me.ServerDGV.TabIndex = 0
        '
        'StartBtn
        '
        Me.StartBtn.Location = New System.Drawing.Point(547, 336)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(75, 23)
        Me.StartBtn.TabIndex = 1
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'StopBtn
        '
        Me.StopBtn.Location = New System.Drawing.Point(456, 336)
        Me.StopBtn.Name = "StopBtn"
        Me.StopBtn.Size = New System.Drawing.Size(75, 23)
        Me.StopBtn.TabIndex = 2
        Me.StopBtn.Text = "Stop"
        Me.StopBtn.UseVisualStyleBackColor = True
        '
        'Subscribed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 371)
        Me.Controls.Add(Me.StopBtn)
        Me.Controls.Add(Me.StartBtn)
        Me.Controls.Add(Me.ServerDGV)
        Me.Name = "Subscribed"
        Me.Text = "Subscribed to"
        CType(Me.ServerDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ServerDGV As System.Windows.Forms.DataGridView
    Friend WithEvents StartBtn As System.Windows.Forms.Button
    Friend WithEvents StopBtn As System.Windows.Forms.Button

End Class
