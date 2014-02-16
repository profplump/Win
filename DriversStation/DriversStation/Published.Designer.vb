<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Published
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
        Me.PublishedDGV = New System.Windows.Forms.DataGridView()
        Me.IntervalBtn = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelLast = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelInterval = New System.Windows.Forms.ToolStripStatusLabel()
        Me.IntervalTxt = New System.Windows.Forms.TextBox()
        CType(Me.PublishedDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PublishedDGV
        '
        Me.PublishedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PublishedDGV.Location = New System.Drawing.Point(12, 12)
        Me.PublishedDGV.Name = "PublishedDGV"
        Me.PublishedDGV.Size = New System.Drawing.Size(610, 319)
        Me.PublishedDGV.TabIndex = 1
        '
        'IntervalBtn
        '
        Me.IntervalBtn.Location = New System.Drawing.Point(12, 337)
        Me.IntervalBtn.Name = "IntervalBtn"
        Me.IntervalBtn.Size = New System.Drawing.Size(117, 23)
        Me.IntervalBtn.TabIndex = 4
        Me.IntervalBtn.Text = "Set Update Interval"
        Me.IntervalBtn.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelLast, Me.ToolStripStatusLabelInterval})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(634, 22)
        Me.StatusStrip1.TabIndex = 5
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
        'IntervalTxt
        '
        Me.IntervalTxt.Location = New System.Drawing.Point(135, 337)
        Me.IntervalTxt.Name = "IntervalTxt"
        Me.IntervalTxt.Size = New System.Drawing.Size(105, 20)
        Me.IntervalTxt.TabIndex = 6
        '
        'Published
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 390)
        Me.Controls.Add(Me.IntervalTxt)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.IntervalBtn)
        Me.Controls.Add(Me.PublishedDGV)
        Me.Name = "Published"
        Me.Text = "Published"
        CType(Me.PublishedDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PublishedDGV As System.Windows.Forms.DataGridView
    Friend WithEvents IntervalBtn As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelLast As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelInterval As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents IntervalTxt As System.Windows.Forms.TextBox
End Class
