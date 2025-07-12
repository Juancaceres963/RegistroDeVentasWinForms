Imports TacticaAppTest.Entidades

Public Class FrmCategorias

    Private categorias As List(Of Categoria)

    Private Sub FrmCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Try
            categorias = CategoriaService.CargarCategorias()
            RefrescarGrilla()
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCategorias_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategorias.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim nombreActual As String = dgvCategorias.Rows(e.RowIndex).Cells("Nombre").Value.ToString()

        ' Verificamos que no sea la categoría "Otra"
        If nombreActual = "Otra" Then Exit Sub

        ' ✏️ Si se hizo clic en el botón Editar
        If e.ColumnIndex = dgvCategorias.Columns("Editar").Index Then
            Dim frm As New FrmEditarCategoria(nombreActual)
            If frm.ShowDialog() = DialogResult.OK Then
                ' Actualizar el nombre solo si el usuario guardó cambios en el formulario
                Dim nuevoNombre As String = frm.NombreEditado.Trim()

                If nuevoNombre = "" Then
                    MessageBox.Show("El nombre no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Validar duplicados
                If categorias.Any(Function(c) c.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase) AndAlso c.Nombre <> nombreActual) Then
                    MessageBox.Show("Ya existe una categoría con ese nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                categorias.First(Function(c) c.Nombre = nombreActual).Nombre = nuevoNombre
                CategoriaService.GuardarCategorias(categorias)
                RefrescarGrilla()
            End If

            ' 🗑️ Si se hizo clic en el botón Eliminar
        ElseIf e.ColumnIndex = dgvCategorias.Columns("Eliminar").Index Then
            ' Confirmar eliminación
            Dim confirmar As DialogResult = MessageBox.Show($"¿Está seguro de eliminar la categoría '{nombreActual}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmar = DialogResult.Yes Then
                categorias.RemoveAll(Function(c) c.Nombre = nombreActual)
                CategoriaService.GuardarCategorias(categorias)
                RefrescarGrilla()
            End If
        End If
    End Sub


    Private Sub RefrescarGrilla()
        With dgvCategorias
            .Columns.Clear()
            .Columns.Add("Nombre", "Categoría")

            Dim colEditar As New DataGridViewButtonColumn()
            colEditar.Name = "Editar"
            colEditar.HeaderText = "Editar"
            colEditar.Text = "✏️"
            colEditar.UseColumnTextForButtonValue = True
            .Columns.Add(colEditar)

            Dim colEliminar As New DataGridViewButtonColumn()
            colEliminar.Name = "Eliminar"
            colEliminar.HeaderText = "Eliminar"
            colEliminar.Text = "🗑️"
            colEliminar.UseColumnTextForButtonValue = True
            .Columns.Add(colEliminar)
        End With

        dgvCategorias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCategorias.Columns("Nombre").Width = 80
        dgvCategorias.Columns("Editar").Width = 60
        dgvCategorias.Columns("Eliminar").Width = 60

        dgvCategorias.AllowUserToAddRows = False
        dgvCategorias.Rows.Clear()

        For Each cat As Categoria In categorias
            If cat.Nombre = "Otra" Then Continue For ' 👈 Salteamos esta categoría

            dgvCategorias.Rows.Add(cat.Nombre, "✏️", "🗑️")
        Next
    End Sub

    Private Sub btnGuardarCategoria_Click(sender As Object, e As EventArgs) Handles btnGuardarCategoria.Click
        Dim nuevaCat As String = txtNuevaCategoria.Text.Trim()

        ' Validar que no esté vacío
        If nuevaCat = "" Then
            MessageBox.Show("Por favor ingrese un nombre para la categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar que no exista ya una categoría con ese nombre
        If categorias.Any(Function(c) c.Nombre.Equals(nuevaCat, StringComparison.OrdinalIgnoreCase)) Then
            MessageBox.Show("Esa categoría ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validación: caracteres válidos (letras, espacios, guion medio, ampersand)
        If Not System.Text.RegularExpressions.Regex.IsMatch(nuevaCat, "^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-&]+$") Then
            MessageBox.Show("El nombre solo puede contener letras, espacios, guiones y ampersand (&).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validación: longitud mínima/máxima (opcional)
        If nuevaCat.Length < 3 OrElse nuevaCat.Length > 30 Then
            MessageBox.Show("El nombre debe tener entre 3 y 30 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        categorias.Add(New Categoria With {.Nombre = nuevaCat})
        CategoriaService.GuardarCategorias(categorias)
        RefrescarGrilla()

        txtNuevaCategoria.Clear()
        MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

End Class