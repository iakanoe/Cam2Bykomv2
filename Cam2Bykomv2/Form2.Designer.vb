<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sibtn = New System.Windows.Forms.Button()
        Me.nobtn = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No se ha podido encontrar una base de datos. ¿Desea crear una?"
        '
        'sibtn
        '
        Me.sibtn.Location = New System.Drawing.Point(71, 62)
        Me.sibtn.Name = "sibtn"
        Me.sibtn.Size = New System.Drawing.Size(75, 23)
        Me.sibtn.TabIndex = 1
        Me.sibtn.Text = "Sí"
        Me.sibtn.UseVisualStyleBackColor = True
        '
        'nobtn
        '
        Me.nobtn.Location = New System.Drawing.Point(152, 62)
        Me.nobtn.Name = "nobtn"
        Me.nobtn.Size = New System.Drawing.Size(75, 23)
        Me.nobtn.TabIndex = 2
        Me.nobtn.Text = "No"
        Me.nobtn.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.InitialDirectory = "%SystemDrive%"
        Me.SaveFileDialog1.Title = "Seleccionar directorio de creación de BD..."
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 97)
        Me.Controls.Add(Me.nobtn)
        Me.Controls.Add(Me.sibtn)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Crear o seleccionar base de datos..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents sibtn As Button
    Friend WithEvents nobtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
