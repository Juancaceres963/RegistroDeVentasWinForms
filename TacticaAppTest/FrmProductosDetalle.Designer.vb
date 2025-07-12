<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductosDetalle
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
        Me.btnCancelarProducto = New System.Windows.Forms.Button()
        Me.btnGuardarProducto = New System.Windows.Forms.Button()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtNombreProducto = New System.Windows.Forms.TextBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(72, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 25)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Datos del Producto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelarProducto
        '
        Me.btnCancelarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarProducto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnCancelarProducto.Location = New System.Drawing.Point(186, 169)
        Me.btnCancelarProducto.Name = "btnCancelarProducto"
        Me.btnCancelarProducto.Size = New System.Drawing.Size(144, 38)
        Me.btnCancelarProducto.TabIndex = 16
        Me.btnCancelarProducto.Text = "Cancelar"
        Me.btnCancelarProducto.UseVisualStyleBackColor = True
        '
        'btnGuardarProducto
        '
        Me.btnGuardarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarProducto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnGuardarProducto.Location = New System.Drawing.Point(22, 169)
        Me.btnGuardarProducto.Name = "btnGuardarProducto"
        Me.btnGuardarProducto.Size = New System.Drawing.Size(144, 38)
        Me.btnGuardarProducto.TabIndex = 15
        Me.btnGuardarProducto.Text = "Guardar"
        Me.btnGuardarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuardarProducto.UseVisualStyleBackColor = True
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(29, 128)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(69, 16)
        Me.lblCategoria.TabIndex = 13
        Me.lblCategoria.Text = "Categoria:"
        '
        'txtPrecio
        '
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(104, 97)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(204, 22)
        Me.txtPrecio.TabIndex = 12
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(48, 100)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(49, 16)
        Me.lblPrecio.TabIndex = 11
        Me.lblPrecio.Text = "Precio:"
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProducto.Location = New System.Drawing.Point(104, 69)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(204, 22)
        Me.txtNombreProducto.TabIndex = 10
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(44, 70)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(56, 20)
        Me.lblProducto.TabIndex = 9
        Me.lblProducto.Text = "Nombre:"
        Me.lblProducto.UseCompatibleTextRendering = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(104, 128)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(204, 21)
        Me.cmbCategoria.TabIndex = 18
        '
        'FrmProductosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 241)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelarProducto)
        Me.Controls.Add(Me.btnGuardarProducto)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lblProducto)
        Me.Name = "FrmProductosDetalle"
        Me.Text = "FrmProductosDetalle"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancelarProducto As Button
    Friend WithEvents btnGuardarProducto As Button
    Friend WithEvents lblCategoria As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents lblPrecio As Label
    Friend WithEvents txtNombreProducto As TextBox
    Friend WithEvents lblProducto As Label
    Friend WithEvents cmbCategoria As ComboBox
End Class
