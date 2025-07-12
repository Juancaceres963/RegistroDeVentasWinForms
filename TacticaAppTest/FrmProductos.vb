Imports TacticaAppTest.Data
Imports TacticaAppTest.Entidades

Public Class FrmProductos
    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarProductos()
        AgregarBotones()
    End Sub

    Private Sub CargarProductos()
        Try
            Dim productoDAL As New ProductoDAL()
            Dim lista As List(Of Producto) = productoDAL.ObtenerTodos()
            dgvProductos.DataSource = lista

            dgvProductos.Columns("ID").Visible = False

            ' Centrar encabezados
            For Each columna As DataGridViewColumn In dgvProductos.Columns
                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AgregarBotones()
        ' Botón Editar
        If dgvProductos.Columns("btnEditar") Is Nothing Then
            Dim btnEditar As New DataGridViewButtonColumn()
            btnEditar.HeaderText = "Editar"
            btnEditar.Name = "btnEditar"
            btnEditar.Text = "✏️"
            btnEditar.UseColumnTextForButtonValue = True
            btnEditar.Width = 60
            dgvProductos.Columns.Add(btnEditar)
        End If

        ' Botón Eliminar
        If dgvProductos.Columns("btnEliminar") Is Nothing Then
            Dim btnEliminar As New DataGridViewButtonColumn()
            btnEliminar.HeaderText = "Eliminar"
            btnEliminar.Name = "btnEliminar"
            btnEliminar.Text = "🗑"
            btnEliminar.UseColumnTextForButtonValue = True
            btnEliminar.Width = 50
            dgvProductos.Columns.Add(btnEliminar)
        End If
    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim idProducto As Integer = CInt(dgvProductos.Rows(e.RowIndex).Cells("ID").Value)

        If dgvProductos.Columns(e.ColumnIndex).Name = "btnEditar" Then
            Dim productoSeleccionado As Producto = CType(dgvProductos.Rows(e.RowIndex).DataBoundItem, Producto)
            Dim frmDetalle As New FrmProductosDetalle(productoSeleccionado)
            frmDetalle.ShowDialog()
            CargarProductos()

        ElseIf dgvProductos.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            Dim resultado = MessageBox.Show("¿Estás seguro que querés eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.Yes Then
                Dim productoDAL As New ProductoDAL()
                productoDAL.Eliminar(idProducto)
                CargarProductos()
            End If
        End If
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Me.Hide()
        Dim frmDetalle As New FrmProductosDetalle()
        frmDetalle.ShowDialog()
        CargarProductos()
        Me.Show()
    End Sub

    Private Sub btnAdministrarCategorias_Click(sender As Object, e As EventArgs) Handles btnAdministrarCategorias.Click
        Me.Hide()
        Dim frm As New FrmCategorias()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

End Class