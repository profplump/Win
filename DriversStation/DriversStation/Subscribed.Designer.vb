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
        Me.SubscribedDGV = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelLast = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelInterval = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SubscribedDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SubscribedDGV
        '
        Me.SubscribedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SubscribedDGV.Location = New System.Drawing.Point(12, 12)
        Me.SubscribedDGV.Name = "SubscribedDGV"
        Me.SubscribedDGV.Size = New System.Drawing.Size(610, 323)
        Me.SubscribedDGV.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelLast, Me.ToolStripStatusLabelInterval})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 346)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelLast
        '
        Me.ToolStripStatusLabelLast.Name = "ToolStripStatusLabelLast"
        Me.ToolStripStatusLabelLast.Size = New System.Drawing.Size(75, 17)
        Me.ToolStripStatusLabelLast.Text = "Last Update: "
        '
        'ToolStripStatusLabelInterval
        '
        Me.ToolStripStatusLabelInterval.Name = "ToolStripStatusLabelInterval"
        Me.ToolStripStatusLabelInterval.Size = New System.Drawing.Size(93, 17)
        Me.ToolStripStatusLabelInterval.Text = "Update Interval: "
        '
        'Subscribed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 368)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SubscribedDGV)
        Me.Name = "Subscribed"
        Me.Text = "Subscribed to"
        CType(Me.SubscribedDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SubscribedDGV As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelLast As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelInterval As System.Windows.Forms.ToolStripStatusLabel

End Class
