<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroVenta
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
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.lblSelecCliente = New System.Windows.Forms.Label()
        Me.lblSelecProducto = New System.Windows.Forms.Label()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidadProducto = New System.Windows.Forms.TextBox()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.dgvDetalleVenta = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblClienteID = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.lblClienteTelefono = New System.Windows.Forms.Label()
        Me.lblClienteCorreo = New System.Windows.Forms.Label()
        Me.btnVolver = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.btnRegistrarVenta = New System.Windows.Forms.Button()
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbClientes
        '
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(162, 76)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(155, 21)
        Me.cmbClientes.TabIndex = 0
        '
        'lblSelecCliente
        '
        Me.lblSelecCliente.AutoSize = True
        Me.lblSelecCliente.Location = New System.Drawing.Point(44, 80)
        Me.lblSelecCliente.Name = "lblSelecCliente"
        Me.lblSelecCliente.Size = New System.Drawing.Size(112, 13)
        Me.lblSelecCliente.TabIndex = 1
        Me.lblSelecCliente.Text = "Selecciona un cliente:"
        '
        'lblSelecProducto
        '
        Me.lblSelecProducto.AutoSize = True
        Me.lblSelecProducto.Location = New System.Drawing.Point(33, 212)
        Me.lblSelecProducto.Name = "lblSelecProducto"
        Me.lblSelecProducto.Size = New System.Drawing.Size(124, 13)
        Me.lblSelecProducto.TabIndex = 3
        Me.lblSelecProducto.Text = "Selecciona un Producto:"
        '
        'cmbProductos
        '
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(162, 209)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(155, 21)
        Me.cmbProductos.TabIndex = 2
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(327, 192)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 4
        Me.lblCantidad.Text = "Cantidad"
        '
        'txtCantidadProducto
        '
        Me.txtCantidadProducto.Location = New System.Drawing.Point(332, 210)
        Me.txtCantidadProducto.Name = "txtCantidadProducto"
        Me.txtCantidadProducto.Size = New System.Drawing.Size(38, 20)
        Me.txtCantidadProducto.TabIndex = 6
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProducto.Location = New System.Drawing.Point(384, 199)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(144, 38)
        Me.btnAgregarProducto.TabIndex = 7
        Me.btnAgregarProducto.Text = "Agregar Producto"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'dgvDetalleVenta
        '
        Me.dgvDetalleVenta.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dgvDetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleVenta.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvDetalleVenta.Location = New System.Drawing.Point(34, 253)
        Me.dgvDetalleVenta.Name = "dgvDetalleVenta"
        Me.dgvDetalleVenta.Size = New System.Drawing.Size(493, 114)
        Me.dgvDetalleVenta.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Telefono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(136, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(116, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Correo:"
        '
        'lblClienteID
        '
        Me.lblClienteID.Location = New System.Drawing.Point(164, 111)
        Me.lblClienteID.Name = "lblClienteID"
        Me.lblClienteID.Size = New System.Drawing.Size(157, 13)
        Me.lblClienteID.TabIndex = 13
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.Location = New System.Drawing.Point(164, 128)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(157, 13)
        Me.lblClienteNombre.TabIndex = 15
        '
        'lblClienteTelefono
        '
        Me.lblClienteTelefono.Location = New System.Drawing.Point(164, 146)
        Me.lblClienteTelefono.Name = "lblClienteTelefono"
        Me.lblClienteTelefono.Size = New System.Drawing.Size(157, 13)
        Me.lblClienteTelefono.TabIndex = 16
        '
        'lblClienteCorreo
        '
        Me.lblClienteCorreo.Location = New System.Drawing.Point(164, 163)
        Me.lblClienteCorreo.Name = "lblClienteCorreo"
        Me.lblClienteCorreo.Size = New System.Drawing.Size(157, 13)
        Me.lblClienteCorreo.TabIndex = 17
        '
        'btnVolver
        '
        Me.btnVolver.Location = New System.Drawing.Point(40, 26)
        Me.btnVolver.Name = "btnVolver"
        Me.btnVolver.Size = New System.Drawing.Size(75, 23)
        Me.btnVolver.TabIndex = 19
        Me.btnVolver.Text = "Volver"
        Me.btnVolver.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(146, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(277, 33)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Registro de Ventas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(449, 377)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Total de Venta:"
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.Location = New System.Drawing.Point(63, 390)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(464, 30)
        Me.lblTotalVenta.TabIndex = 21
        Me.lblTotalVenta.Text = "$ 0.00"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRegistrarVenta
        '
        Me.btnRegistrarVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrarVenta.Location = New System.Drawing.Point(383, 419)
        Me.btnRegistrarVenta.Name = "btnRegistrarVenta"
        Me.btnRegistrarVenta.Size = New System.Drawing.Size(144, 38)
        Me.btnRegistrarVenta.TabIndex = 22
        Me.btnRegistrarVenta.Text = "Registrar Venta"
        Me.btnRegistrarVenta.UseVisualStyleBackColor = True
        '
        'FrmRegistroVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 479)
        Me.Controls.Add(Me.btnRegistrarVenta)
        Me.Controls.Add(Me.lblTotalVenta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnVolver)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblClienteCorreo)
        Me.Controls.Add(Me.lblClienteTelefono)
        Me.Controls.Add(Me.lblClienteNombre)
        Me.Controls.Add(Me.lblClienteID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDetalleVenta)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.txtCantidadProducto)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblSelecProducto)
        Me.Controls.Add(Me.cmbProductos)
        Me.Controls.Add(Me.lblSelecCliente)
        Me.Controls.Add(Me.cmbClientes)
        Me.Name = "FrmRegistroVenta"
        Me.Text = "FrmRegistro"
        CType(Me.dgvDetalleVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents lblSelecCliente As Label
    Friend WithEvents lblSelecProducto As Label
    Friend WithEvents cmbProductos As ComboBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents txtCantidadProducto As TextBox
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents dgvDetalleVenta As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblClienteID As Label
    Friend WithEvents lblClienteNombre As Label
    Friend WithEvents lblClienteTelefono As Label
    Friend WithEvents lblClienteCorreo As Label
    Friend WithEvents btnVolver As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents btnRegistrarVenta As Button
End Class
