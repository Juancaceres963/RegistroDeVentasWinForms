Imports System.Text.RegularExpressions
Imports TacticaAppTest.Data
Imports TacticaAppTest.Entidades

Public Class FrmClientesDetalle

    Private clienteActual As Cliente = Nothing

    ' Constructor por defecto (para agregar un nuevo cliente)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Constructor adicional (para editar un cliente ya existente)
    Public Sub New(cliente As Cliente)
        InitializeComponent()
        clienteActual = cliente
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ' Validar nombre (solo letras, espacios, acentos)
        If Not Regex.IsMatch(txtCliente.Text.Trim(), "^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$") Then
            MessageBox.Show("El nombre solo debe contener letras y espacios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar teléfono (solo números)
        If Not Regex.IsMatch(txtTelefono.Text.Trim(), "^\d+$") Then
            MessageBox.Show("El teléfono solo debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar correo (estructura básica con @)
        If Not txtCorreo.Text.Contains("@") OrElse txtCorreo.Text.StartsWith("@") OrElse txtCorreo.Text.EndsWith("@") Then
            MessageBox.Show("Ingrese un correo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If txtCliente.Text.Trim() = "" Then
                MessageBox.Show("El nombre del cliente es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If clienteActual Is Nothing Then
                ' Nuevo cliente
                Dim nuevoCliente As New Cliente With {
                .Cliente = txtCliente.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim(),
                .Correo = txtCorreo.Text.Trim()
            }
                ClienteDAL.Insertar(nuevoCliente)
                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Edición
                clienteActual.Cliente = txtCliente.Text.Trim()
                clienteActual.Telefono = txtTelefono.Text.Trim()
                clienteActual.Correo = txtCorreo.Text.Trim()
                ClienteDAL.Actualizar(clienteActual)
                MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmClientesDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        If clienteActual IsNot Nothing Then
            txtCliente.Text = clienteActual.Cliente
            txtTelefono.Text = clienteActual.Telefono
            txtCorreo.Text = clienteActual.Correo
        End If
    End Sub

End Class
