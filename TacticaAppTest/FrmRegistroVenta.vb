Imports TacticaAppTest.Entidades
Imports TacticaAppTest.Data

Public Class FrmRegistroVenta

    Private clientes As List(Of Cliente)
    Private productos As List(Of Producto)

    Private Sub FrmRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarClientes()
        CargarProductos()
        ConfigurarGrillaDetalleVenta()
        txtCantidadProducto.Text = "1"

        lblTotalVenta.TextAlign = ContentAlignment.MiddleRight
    End Sub

    Private Sub CargarClientes()
        Dim dal As New ClienteDAL()
        clientes = dal.ObtenerTodos()

        ' Insertar cliente ficticio al principio
        Dim clienteFicticio As New Cliente With {
        .ID = 0,
        .Cliente = "-- Seleccione un cliente --"
    }
        clientes.Insert(0, clienteFicticio)

        cmbClientes.DisplayMember = "Cliente" ' Nombre visible
        cmbClientes.ValueMember = "ID"        ' Valor interno
        cmbClientes.DataSource = clientes
    End Sub

    Private Sub CargarProductos()
        Dim dal As New ProductoDAL()
        productos = dal.ObtenerTodos()

        Dim productoFicticio As New Producto With {
        .ID = 0,
        .Nombre = "-- Seleccione un producto --"
    }
        productos.Insert(0, productoFicticio)

        cmbProductos.DisplayMember = "Nombre"
        cmbProductos.ValueMember = "ID"
        cmbProductos.DataSource = productos
    End Sub

    Private Sub ConfigurarGrillaDetalleVenta()
        dgvDetalleVenta.AllowUserToAddRows = False
        dgvDetalleVenta.Columns.Clear()

        dgvDetalleVenta.Columns.Add("IDProducto", "Producto ID")
        dgvDetalleVenta.Columns.Add("Nombre", "Producto")
        dgvDetalleVenta.Columns.Add("PrecioUnitario", "Precio Uni")
        dgvDetalleVenta.Columns.Add("Cantidad", "Cantidad")
        dgvDetalleVenta.Columns.Add("PrecioTotal", "Subtotal")
        If dgvDetalleVenta.Columns("btnEliminar") Is Nothing Then
            Dim btnEliminar As New DataGridViewButtonColumn()
            btnEliminar.Name = "btnEliminar"
            btnEliminar.HeaderText = "Eliminar"
            btnEliminar.Text = "🗑️"
            btnEliminar.UseColumnTextForButtonValue = True
            btnEliminar.Width = 60
            dgvDetalleVenta.Columns.Add(btnEliminar)
        End If

        ' Editar Cantidad
        dgvDetalleVenta.EditMode = DataGridViewEditMode.EditOnEnter
        dgvDetalleVenta.Columns("Cantidad").ReadOnly = False

        ' Tamaña de columnas 
        dgvDetalleVenta.Columns("IDProducto").Width = 40
        dgvDetalleVenta.Columns("Nombre").Width = 100
        dgvDetalleVenta.Columns("PrecioUnitario").Width = 100
        dgvDetalleVenta.Columns("Cantidad").Width = 60
        dgvDetalleVenta.Columns("PrecioTotal").Width = 100

        ' Centrar los encabezados
        dgvDetalleVenta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Posicionar Texto
        dgvDetalleVenta.Columns("IDProducto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleVenta.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleVenta.Columns("PrecioUnitario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDetalleVenta.Columns("PrecioTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub CalcularTotal()
        Dim total As Decimal = 0

        For Each fila As DataGridViewRow In dgvDetalleVenta.Rows
            total += Convert.ToDecimal(fila.Cells("PrecioTotal").Value)
        Next

        lblTotalVenta.Text = "$ " & total.ToString("0.00")
    End Sub

    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        Dim clienteSeleccionado As Cliente = CType(cmbClientes.SelectedItem, Cliente)

        If clienteSeleccionado.ID = 0 Then
            ' Limpiar los labels
            lblClienteID.Text = ""
            lblClienteNombre.Text = ""
            lblClienteTelefono.Text = ""
            lblClienteCorreo.Text = ""
            Exit Sub
        End If

        lblClienteID.Text = clienteSeleccionado.ID.ToString()
        lblClienteNombre.Text = clienteSeleccionado.Cliente
        lblClienteTelefono.Text = clienteSeleccionado.Telefono
        lblClienteCorreo.Text = clienteSeleccionado.Correo
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click

        Dim productoSeleccionado As Producto = CType(cmbProductos.SelectedItem, Producto)

        ' Validar que no sea el ítem ficticio
        If productoSeleccionado.ID = 0 Then
            MessageBox.Show("Por favor seleccioná un producto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Verificar si ya se agregó el producto
        For Each fila As DataGridViewRow In dgvDetalleVenta.Rows
            If CInt(fila.Cells("IDProducto").Value) = productoSeleccionado.ID Then
                MessageBox.Show("Este producto ya fue agregado. Editá la cantidad si es necesario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Next

        ' Validar cantidad
        Dim cantidad As Integer = If(String.IsNullOrWhiteSpace(txtCantidadProducto.Text), 1, Convert.ToInt32(txtCantidadProducto.Text))

        ' Ahora validamos que la cantidad final sea válida (> 0)
        If cantidad <= 0 Then
            MessageBox.Show("Por favor ingrese una cantidad válida (entero mayor a 0).", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Calcular subtotal
        Dim subtotal As Decimal = productoSeleccionado.Precio * cantidad

        ' Agregar al DataGridView
        dgvDetalleVenta.Rows.Add(productoSeleccionado.ID, productoSeleccionado.Nombre, productoSeleccionado.Precio.ToString("0.00"), cantidad, subtotal.ToString("0.00"))

        ' Actualizar total
        CalcularTotal()

        ' Resetear ComboBox y campo de cantidad
        cmbProductos.SelectedIndex = 0
        txtCantidadProducto.Clear()
    End Sub

    Private Sub dgvDetalleVenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleVenta.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvDetalleVenta.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            dgvDetalleVenta.Rows.RemoveAt(e.RowIndex)
            CalcularTotal()
        End If

        If e.RowIndex < 0 OrElse e.RowIndex >= dgvDetalleVenta.Rows.Count Then Exit Sub
    End Sub

    Private Sub dgvDetalleVenta_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleVenta.CellEndEdit
        If dgvDetalleVenta.Columns(e.ColumnIndex).Name = "Cantidad" Then
            Dim cantidad As Integer
            If Integer.TryParse(dgvDetalleVenta.Rows(e.RowIndex).Cells("Cantidad").Value.ToString(), cantidad) Then
                Dim precioUnitario As Decimal = Convert.ToDecimal(dgvDetalleVenta.Rows(e.RowIndex).Cells("PrecioUnitario").Value)
                dgvDetalleVenta.Rows(e.RowIndex).Cells("PrecioTotal").Value = (precioUnitario * cantidad).ToString("0.00")
                CalcularTotal()
            Else
                MessageBox.Show("Cantidad inválida. Ingresá un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgvDetalleVenta.Rows(e.RowIndex).Cells("Cantidad").Value = 1
            End If
        End If
    End Sub

    Private Sub btnRegistrarVenta_Click(sender As Object, e As EventArgs) Handles btnRegistrarVenta.Click
        ' Validación de cantidades del DataGridView
        For Each row As DataGridViewRow In dgvDetalleVenta.Rows
            If row.IsNewRow Then Continue For

            Dim cantidad As Decimal
            If Not Decimal.TryParse(row.Cells("Cantidad").Value.ToString(), cantidad) Then
                MessageBox.Show("Error: La cantidad del producto no es válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        Try
            ' Validar que haya cliente y productos
            If cmbClientes.SelectedIndex <= 0 Then
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dgvDetalleVenta.Rows.Count = 0 Then
                MessageBox.Show("Debe agregar al menos un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Obtener datos
            Dim idCliente As Integer = CType(cmbClientes.SelectedItem, Cliente).ID
            Dim fechaVenta As DateTime = DateTime.Now
            Dim totalTexto As String = lblTotalVenta.Text.Replace("$", "").Replace(" ", "").Replace(",", ".")
            Dim totalVenta As Decimal

            ' Obtener el total de la venta desde el label (con parseo seguro)
            If Not Decimal.TryParse(totalTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, totalVenta) Then
                MessageBox.Show("El total de la venta no tiene un formato válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Crear venta (insertar en tabla Ventas y recuperar ID generado)
            Dim ventaDAL As New VentaDAL()
            Dim idVenta As Integer = ventaDAL.InsertarVenta(idCliente, fechaVenta, totalVenta)

            ' Insertar detalle
            For Each row As DataGridViewRow In dgvDetalleVenta.Rows
                If Not row.IsNewRow Then
                    Dim idProducto As Integer = CInt(row.Cells("IDProducto").Value)
                    Dim precioUnitario As Decimal = CDec(row.Cells("PrecioUnitario").Value)
                    Dim cantidad As Integer = CInt(row.Cells("Cantidad").Value)
                    Dim precioTotal As Decimal = CDec(row.Cells("PrecioTotal").Value)

                    ventaDAL.InsertarDetalleVenta(idVenta, idProducto, precioUnitario, cantidad, precioTotal)
                End If
            Next

            MessageBox.Show("Venta registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reiniciar formulario
            cmbClientes.SelectedIndex = 0
            lblClienteID.Text = ""
            lblClienteNombre.Text = ""
            lblClienteTelefono.Text = ""
            lblClienteCorreo.Text = ""
            cmbProductos.SelectedIndex = 0
            txtCantidadProducto.Text = ""
            dgvDetalleVenta.Rows.Clear()
            lblTotalVenta.Text = "$0.00"

        Catch ex As Exception
            MessageBox.Show("Error al registrar venta: " & ex.Message)
        End Try
    End Sub

    Private Sub txtCantidadProducto_Leave(sender As Object, e As EventArgs) Handles txtCantidadProducto.Leave
        If String.IsNullOrWhiteSpace(txtCantidadProducto.Text) Then
            txtCantidadProducto.Text = "1"
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class