Imports TacticaAppTest.Data
Imports TacticaAppTest.Entidades

Public Class FrmHistorial
    Private Sub FrmResumenVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarResumenDeVentas()
    End Sub

    Public Sub CargarResumenDeVentas()
        dgvVentas.Columns.Clear()
        dgvVentas.Rows.Clear()
        dgvVentas.AllowUserToAddRows = False

        dgvVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvVentas.Columns.Add("IDVenta", " Venta ID")
        dgvVentas.Columns.Add("Fecha", "Fecha")
        dgvVentas.Columns.Add("Cliente", "Cliente")
        dgvVentas.Columns.Add("Productos", "Productos & Cantidades")
        dgvVentas.Columns.Add("Total", "Total")

        dgvVentas.Columns("Productos").Width = 200

        Dim ventas As List(Of VentaResumenDetallada) = VentaDAL.ObtenerResumenDeVentas()

        For Each v In ventas
            dgvVentas.Rows.Add(v.IDVenta, v.Fecha.ToShortDateString(), v.Cliente, v.Productos, "$" & v.Total.ToString("F2"))
        Next
    End Sub

    Private Sub btnNuevaVenta_Click(sender As Object, e As EventArgs) Handles btnNuevaVenta.Click
        Me.Hide()
        Dim frm As New FrmRegistroVenta()
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
        Me.Show()
        CargarResumenDeVentas()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
End Class