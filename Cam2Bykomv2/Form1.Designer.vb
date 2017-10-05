<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barraseparadora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.last = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.todos = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cuentas = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.enviardatos = New System.Windows.Forms.CheckBox()
        Me.puertotxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.iptxt = New System.Windows.Forms.TextBox()
        Me.heartbittiempo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.heartbitenviar = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.codedtxt = New System.Windows.Forms.TextBox()
        Me.realtxt = New System.Windows.Forms.TextBox()
        Me.lal = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.todos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.cuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AllowMerge = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status, Me.barraseparadora, Me.last})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 361)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(564, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(55, 17)
        Me.status.Text = "Apagado"
        '
        'barraseparadora
        '
        Me.barraseparadora.Name = "barraseparadora"
        Me.barraseparadora.Size = New System.Drawing.Size(10, 17)
        Me.barraseparadora.Text = "|"
        '
        'last
        '
        Me.last.Name = "last"
        Me.last.Size = New System.Drawing.Size(133, 17)
        Me.last.Text = "Ultimo chequeo: Nunca"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(379, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 75)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Encender"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 336)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.todos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(532, 310)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos recibidos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'todos
        '
        Me.todos.AllowUserToAddRows = False
        Me.todos.AllowUserToDeleteRows = False
        Me.todos.AllowUserToResizeRows = False
        Me.todos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.todos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.todos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.todos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.todos.Location = New System.Drawing.Point(0, 0)
        Me.todos.Name = "todos"
        Me.todos.ReadOnly = True
        Me.todos.RowHeadersVisible = False
        Me.todos.Size = New System.Drawing.Size(532, 310)
        Me.todos.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cuentas)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(532, 310)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuentas de usuario"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cuentas
        '
        Me.cuentas.AllowUserToAddRows = False
        Me.cuentas.AllowUserToDeleteRows = False
        Me.cuentas.AllowUserToResizeRows = False
        Me.cuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.cuentas.Location = New System.Drawing.Point(0, 0)
        Me.cuentas.Name = "cuentas"
        Me.cuentas.ReadOnly = True
        Me.cuentas.RowHeadersVisible = False
        Me.cuentas.Size = New System.Drawing.Size(532, 310)
        Me.cuentas.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.enviardatos)
        Me.TabPage2.Controls.Add(Me.puertotxt)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.iptxt)
        Me.TabPage2.Controls.Add(Me.heartbittiempo)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.heartbitenviar)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(532, 310)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Opciones"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'enviardatos
        '
        Me.enviardatos.AutoSize = True
        Me.enviardatos.Location = New System.Drawing.Point(5, 8)
        Me.enviardatos.Name = "enviardatos"
        Me.enviardatos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.enviardatos.Size = New System.Drawing.Size(129, 17)
        Me.enviardatos.TabIndex = 9
        Me.enviardatos.Text = "Enviar datos a Bykom"
        Me.enviardatos.UseVisualStyleBackColor = True
        '
        'puertotxt
        '
        Me.puertotxt.Location = New System.Drawing.Point(74, 57)
        Me.puertotxt.Name = "puertotxt"
        Me.puertotxt.Size = New System.Drawing.Size(88, 20)
        Me.puertotxt.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Puerto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Dirección IP"
        '
        'iptxt
        '
        Me.iptxt.Location = New System.Drawing.Point(74, 31)
        Me.iptxt.Name = "iptxt"
        Me.iptxt.Size = New System.Drawing.Size(284, 20)
        Me.iptxt.TabIndex = 5
        '
        'heartbittiempo
        '
        Me.heartbittiempo.Location = New System.Drawing.Point(200, 87)
        Me.heartbittiempo.Name = "heartbittiempo"
        Me.heartbittiempo.Size = New System.Drawing.Size(100, 20)
        Me.heartbittiempo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Máximo tiempo sin recepción (minutos)"
        '
        'heartbitenviar
        '
        Me.heartbitenviar.AutoSize = True
        Me.heartbitenviar.Location = New System.Drawing.Point(4, 116)
        Me.heartbitenviar.Name = "heartbitenviar"
        Me.heartbitenviar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.heartbitenviar.Size = New System.Drawing.Size(145, 17)
        Me.heartbitenviar.TabIndex = 2
        Me.heartbitenviar.Text = "Enviar Heartbits a Bykom"
        Me.heartbitenviar.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.codedtxt)
        Me.TabPage4.Controls.Add(Me.realtxt)
        Me.TabPage4.Controls.Add(Me.lal)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(532, 310)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Codificador"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'codedtxt
        '
        Me.codedtxt.Location = New System.Drawing.Point(150, 74)
        Me.codedtxt.Name = "codedtxt"
        Me.codedtxt.ReadOnly = True
        Me.codedtxt.Size = New System.Drawing.Size(100, 20)
        Me.codedtxt.TabIndex = 3
        '
        'realtxt
        '
        Me.realtxt.Location = New System.Drawing.Point(150, 48)
        Me.realtxt.Name = "realtxt"
        Me.realtxt.Size = New System.Drawing.Size(100, 20)
        Me.realtxt.TabIndex = 2
        '
        'lal
        '
        Me.lal.AutoSize = True
        Me.lal.Location = New System.Drawing.Point(33, 77)
        Me.lal.Name = "lal"
        Me.lal.Size = New System.Drawing.Size(93, 13)
        Me.lal.TabIndex = 1
        Me.lal.Text = "Cuenta codificada"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Cuenta real"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 383)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Cam2Bykom"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.todos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.cuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents status As ToolStripStatusLabel
    Friend WithEvents last As ToolStripStatusLabel
    Friend WithEvents Button1 As Button
    Friend WithEvents barraseparadora As ToolStripStatusLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents puertotxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents iptxt As TextBox
    Friend WithEvents heartbittiempo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents heartbitenviar As CheckBox
    Friend WithEvents todos As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents cuentas As DataGridView
    Friend WithEvents enviardatos As CheckBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lal As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents codedtxt As TextBox
    Friend WithEvents realtxt As TextBox
End Class
