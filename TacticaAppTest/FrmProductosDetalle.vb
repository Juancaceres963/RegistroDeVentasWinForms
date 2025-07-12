Imports TacticaAppTest.Data
Imports TacticaAppTest.Entidades

Public Class FrmProductosDetalle

    Private productoEditando As Producto = Nothing

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Public Sub New(p As Producto)
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        productoEditando = p
    End Sub

    Private Sub btnGuardarProducto_Click(sender As Object, e As EventArgs) Handles btnGuardarProducto.Click

        ' Validando que el nombre del producto sea ingresado correctamente
        If Not System.Text.RegularExpressions.Regex.IsMatch(txtNombreProducto.Text, "^[\w\s\.\-áéíóúÁÉÍÓÚñÑ]+$") Then
            MessageBox.Show("El nombre del producto contiene caracteres no permitidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validando que el precio sea ingresado correctamente
        Dim precio As Decimal
        If Not Decimal.TryParse(txtPrecio.Text.Trim().Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, precio) Then
            MessageBox.Show("El precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If precio <= 0 Then
            MessageBox.Show("El precio debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validando que seleccione una categoria correctamente
        If cmbCategoria.SelectedIndex <= 0 Then
            MessageBox.Show("Debe seleccionar una categoría válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Validaciones básicas
            If txtNombreProducto.Text.Trim() = "" OrElse txtPrecio.Text.Trim() = "" Then
                MessageBox.Show("El nombre y el precio son obligatorios.")
                Return
            End If

            Dim precioDecimal As Decimal
            If Not Decimal.TryParse(txtPrecio.Text.Trim(), precioDecimal) Then
                MessageBox.Show("El precio debe ser un número válido.")
                Return
            End If

            Dim productoDAL As New ProductoDAL()

            If productoEditando Is Nothing Then
                ' Crear nuevo producto
                Dim nuevoProducto As New Producto With {
                .Nombre = txtNombreProducto.Text.Trim(),
                .Precio = precioDecimal,
                .Categoria = cmbCategoria.SelectedItem.ToString()
            }
                productoDAL.Insertar(nuevoProducto)
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Editar producto existente
                productoEditando.Nombre = txtNombreProducto.Text.Trim()
                productoEditando.Precio = precioDecimal
                productoEditando.Categoria = cmbCategoria.SelectedItem.ToString()
                productoDAL.Actualizar(productoEditando)
                MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar el producto: " & ex.Message)
        End Try
    End Sub

    Private Sub FrmProductosDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Limpiar y cargar las categorías desde el archivo JSON
        cmbCategoria.Items.Clear()
        cmbCategoria.Items.Add("Seleccione una categoría")

        Dim categorias As List(Of Categoria) = CategoriaService.CargarCategorias()
        For Each cat In categorias
            cmbCategoria.Items.Add(cat.Nombre)
        Next

        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCategoria.SelectedIndex = 0 ' Mostrar texto inicial

        ' Si se está editando un producto, cargar sus datos
        If productoEditando IsNot Nothing Then
            txtNombreProducto.Text = productoEditando.Nombre
            txtPrecio.Text = productoEditando.Precio.ToString()
            cmbCategoria.SelectedItem = productoEditando.Categoria
        End If
    End Sub

    Private Sub CargarCategoriasEnComboBox()
        cmbCategoria.Items.Clear()
        cmbCategoria.Items.Add("Seleccione una categoría")

        Dim categorias As List(Of Categoria) = CategoriaService.CargarCategorias()
        For Each cat In categorias
            cmbCategoria.Items.Add(cat.Nombre)
        Next

        cmbCategoria.SelectedIndex = 0
    End Sub

    Private Sub btnCancelarProducto_Click(sender As Object, e As EventArgs) Handles btnCancelarProducto.Click
        Me.Close()
    End Sub

End Class