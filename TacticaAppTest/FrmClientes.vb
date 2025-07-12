Imports TacticaAppTest.Data
Imports TacticaAppTest.Entidades

Public Class FrmClientes

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarClientes()

        If dgvClientes.Columns("btnEditar") Is Nothing Then
            Dim btnEditar As New DataGridViewButtonColumn()
            btnEditar.HeaderText = "Editar"
            btnEditar.Name = "btnEditar"
            btnEditar.Text = "✏️"
            btnEditar.Width = 60
            btnEditar.UseColumnTextForButtonValue = True
            dgvClientes.Columns.Add(btnEditar)
        End If

        If dgvClientes.Columns("btnEliminar") Is Nothing Then
            Dim btnEliminar As New DataGridViewButtonColumn()
            btnEliminar.HeaderText = "Eliminar"
            btnEliminar.Text = "🗑" '
            btnEliminar.DefaultCellStyle.ForeColor = Color.Red
            btnEliminar.Name = "btnEliminar"
            btnEliminar.Width = 50
            btnEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            btnEliminar.UseColumnTextForButtonValue = True
            dgvClientes.Columns.Add(btnEliminar)
        End If
    End Sub

    Private Sub CargarClientes()
        Try
            Dim clienteDAL As New ClienteDAL()
            Dim lista As List(Of Cliente) = clienteDAL.ObtenerTodos()
            dgvClientes.DataSource = lista
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Ocultar columna ID si no querés mostrarla
            dgvClientes.Columns("ID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar clientes: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Me.Hide()
        Dim frm As New FrmClientesDetalle()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
        CargarClientes() ' Recarga los datos al volver
    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        Dim idCliente As Integer = CInt(dgvClientes.Rows(e.RowIndex).Cells("ID").Value)

        If dgvClientes.Columns(e.ColumnIndex).Name = "btnEditar" Then
            ' Obtener datos del cliente seleccionado
            Dim clienteSeleccionado As Cliente = CType(dgvClientes.Rows(e.RowIndex).DataBoundItem, Cliente)

            ' Abrir formulario de edición con los datos cargados
            Dim frmDetalle As New FrmClientesDetalle(clienteSeleccionado)
            frmDetalle.StartPosition = FormStartPosition.CenterScreen
            frmDetalle.ShowDialog()

            ' Recargar la grilla al volver
            ' Solo recargar si el usuario guardó cambios
            If frmDetalle.DialogResult = DialogResult.OK Then
                CargarClientes()
            End If

        ElseIf dgvClientes.Columns(e.ColumnIndex).Name = "btnEliminar" Then
            Dim resultado = MessageBox.Show("¿Estás seguro que querés eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resultado = DialogResult.Yes Then
                Dim clienteDAL As New ClienteDAL()
                clienteDAL.Eliminar(idCliente)
                CargarClientes()
            End If
        End If
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

End Class