<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Driving
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
        Me.TableDGV = New System.Windows.Forms.DataGridView()
        CType(Me.TableDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableDGV
        '
        Me.TableDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.TableDGV.Location = New System.Drawing.Point(19, 16)
        Me.TableDGV.Name = "TableDGV"
        Me.TableDGV.Size = New System.Drawing.Size(592, 310)
        Me.TableDGV.TabIndex = 3
        '
        'Driving
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableDGV)
        Me.Name = "Driving"
        Me.Size = New System.Drawing.Size(635, 346)
        CType(Me.TableDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableDGV As System.Windows.Forms.DataGridView

End Class
