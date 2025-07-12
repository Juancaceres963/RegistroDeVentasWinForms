Public Class FrmPrincipal
    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Me.Hide()
        Dim frm As New FrmClientes()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Me.Hide()
        Dim frm As New FrmProductos()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub btnHistorial_Click(sender As Object, e As EventArgs) Handles btnHistorial.Click
        Me.Hide()
        Dim frm As New FrmHistorial()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
    End Sub

End Class