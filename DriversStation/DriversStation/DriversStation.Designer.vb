<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DriversStation
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowAllToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelLast = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelInterval = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusStale = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TablesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(642, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDebugToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenDebugToolStripMenuItem
        '
        Me.OpenDebugToolStripMenuItem.Name = "OpenDebugToolStripMenuItem"
        Me.OpenDebugToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.OpenDebugToolStripMenuItem.Text = "&New Table"
        '
        'TablesToolStripMenuItem
        '
        Me.TablesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowAllToolStripMenuItem1, Me.ToolStripSeparator1, Me.ToolStripTextBox1})
        Me.TablesToolStripMenuItem.Enabled = False
        Me.TablesToolStripMenuItem.Name = "TablesToolStripMenuItem"
        Me.TablesToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.TablesToolStripMenuItem.Text = "Tables"
        '
        'ShowAllToolStripMenuItem1
        '
        Me.ShowAllToolStripMenuItem1.Name = "ShowAllToolStripMenuItem1"
        Me.ShowAllToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.ShowAllToolStripMenuItem1.Text = "Show All"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.Text = "Subscribed"
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 24)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(642, 366)
        Me.MainPanel.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelLast, Me.ToolStripStatusLabelInterval, Me.ToolStripStatusStale, Me.ToolStripStatusLabel1, Me.ToolStripStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(642, 22)
        Me.StatusStrip1.TabIndex = 2
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
        'ToolStripStatusStale
        '
        Me.ToolStripStatusStale.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusStale.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatusStale.Name = "ToolStripStatusStale"
        Me.ToolStripStatusStale.Size = New System.Drawing.Size(46, 17)
        Me.ToolStripStatusStale.Text = "             "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(118, 17)
        Me.ToolStripStatusLabel1.Text = "                                     "
        '
        'ToolStripStatus
        '
        Me.ToolStripStatus.Name = "ToolStripStatus"
        Me.ToolStripStatus.Size = New System.Drawing.Size(164, 17)
        Me.ToolStripStatus.Text = "Drivers Station in Client Mode"
        '
        'DriversStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(642, 390)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DriversStation"
        Me.Text = "4030 Drivers Station"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents OpenDebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowAllToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelLast As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelInterval As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusStale As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
