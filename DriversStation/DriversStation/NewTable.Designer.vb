﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTable
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
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PublishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubscribeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RestoreLastSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableNameTxt = New System.Windows.Forms.TextBox()
        Me.PublishBtn = New System.Windows.Forms.Button()
        Me.SubscribeBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(373, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Close"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PublishToolStripMenuItem, Me.SubscribeToolStripMenuItem, Me.ToolStripSeparator1, Me.RestoreLastSessionToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.EditToolStripMenuItem.Text = "Tables"
        '
        'PublishToolStripMenuItem
        '
        Me.PublishToolStripMenuItem.Name = "PublishToolStripMenuItem"
        Me.PublishToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PublishToolStripMenuItem.Text = "Publish"
        '
        'SubscribeToolStripMenuItem
        '
        Me.SubscribeToolStripMenuItem.Name = "SubscribeToolStripMenuItem"
        Me.SubscribeToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SubscribeToolStripMenuItem.Text = "Subscribe"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'RestoreLastSessionToolStripMenuItem
        '
        Me.RestoreLastSessionToolStripMenuItem.Name = "RestoreLastSessionToolStripMenuItem"
        Me.RestoreLastSessionToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.RestoreLastSessionToolStripMenuItem.Text = "Restore Last Session"
        '
        'TableNameTxt
        '
        Me.TableNameTxt.Location = New System.Drawing.Point(13, 62)
        Me.TableNameTxt.Name = "TableNameTxt"
        Me.TableNameTxt.Size = New System.Drawing.Size(348, 20)
        Me.TableNameTxt.TabIndex = 2
        '
        'PublishBtn
        '
        Me.PublishBtn.Location = New System.Drawing.Point(205, 106)
        Me.PublishBtn.Name = "PublishBtn"
        Me.PublishBtn.Size = New System.Drawing.Size(75, 23)
        Me.PublishBtn.TabIndex = 3
        Me.PublishBtn.Text = "Publish"
        Me.PublishBtn.UseVisualStyleBackColor = True
        '
        'SubscribeBtn
        '
        Me.SubscribeBtn.Location = New System.Drawing.Point(286, 106)
        Me.SubscribeBtn.Name = "SubscribeBtn"
        Me.SubscribeBtn.Size = New System.Drawing.Size(75, 23)
        Me.SubscribeBtn.TabIndex = 4
        Me.SubscribeBtn.Text = "Subscribe"
        Me.SubscribeBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Table Name:"
        '
        'Debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 150)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SubscribeBtn)
        Me.Controls.Add(Me.PublishBtn)
        Me.Controls.Add(Me.TableNameTxt)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Debug"
        Me.Text = "Display Table"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PublishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubscribeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents PublishBtn As System.Windows.Forms.Button
    Friend WithEvents SubscribeBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RestoreLastSessionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
