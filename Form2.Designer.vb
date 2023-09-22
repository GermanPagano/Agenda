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
        txtBuscador = New TextBox()
        Label1 = New Label()
        btnCancelar = New Button()
        btnAceptar = New Button()
        SuspendLayout()
        ' 
        ' txtBuscador
        ' 
        txtBuscador.Location = New Point(12, 142)
        txtBuscador.Name = "txtBuscador"
        txtBuscador.Size = New Size(468, 27)
        txtBuscador.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(167, 20)
        Label1.TabIndex = 1
        Label1.Text = "Ingrese el dato a buscar"
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(386, 76)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(94, 29)
        btnCancelar.TabIndex = 2
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' btnAceptar
        ' 
        btnAceptar.Location = New Point(386, 31)
        btnAceptar.Name = "btnAceptar"
        btnAceptar.Size = New Size(94, 29)
        btnAceptar.TabIndex = 3
        btnAceptar.Text = "Aceptar"
        btnAceptar.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(499, 205)
        Controls.Add(btnAceptar)
        Controls.Add(btnCancelar)
        Controls.Add(Label1)
        Controls.Add(txtBuscador)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtBuscador As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
End Class
