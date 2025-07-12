Public Class FrmEditarCategoria
    Public Property NombreEditado As String

    Public Sub New(nombreCategoria As String)
        InitializeComponent()
        txtNombreCategoria.Text = nombreCategoria ' Asumiendo que tienes un TextBox
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        NombreEditado = txtNombreCategoria.Text
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmEditarCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

End Class
