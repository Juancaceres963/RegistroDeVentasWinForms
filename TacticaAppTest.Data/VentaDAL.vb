Imports System.Configuration
Imports System.Data.SqlClient
Imports TacticaAppTest.Entidades

Public Class VentaDAL
    Public Function InsertarVenta(idCliente As Integer, fecha As DateTime, total As Decimal) As Integer
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "INSERT INTO Ventas (IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES (@IDCliente, @Fecha, @Total)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@IDCliente", idCliente)
            cmd.Parameters.AddWithValue("@Fecha", fecha)
            cmd.Parameters.AddWithValue("@Total", total)
            Return CInt(cmd.ExecuteScalar())
        End Using
    End Function

    Public Sub InsertarDetalleVenta(idVenta As Integer, idProducto As Integer, precioUnitario As Decimal, cantidad As Integer, precioTotal As Decimal)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "INSERT INTO VentasItems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@IDVenta", idVenta)
            cmd.Parameters.AddWithValue("@IDProducto", idProducto)
            cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario)
            cmd.Parameters.AddWithValue("@Cantidad", cantidad)
            cmd.Parameters.AddWithValue("@PrecioTotal", precioTotal)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Sub InsertarVentaConItems(idCliente As Integer, fecha As DateTime, total As Decimal, items As List(Of VentaItem))
        Using con As New SqlConnection("ConexionSQL")
            con.Open()
            Dim trans As SqlTransaction = con.BeginTransaction()

            Try
                ' Insertar la venta
                Dim sqlVenta As String = "INSERT INTO Ventas (IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES (@IDCliente, @Fecha, @Total)"
                Dim cmdVenta As New SqlCommand(sqlVenta, con, trans)
                cmdVenta.Parameters.AddWithValue("@IDCliente", idCliente)
                cmdVenta.Parameters.AddWithValue("@Fecha", fecha)
                cmdVenta.Parameters.AddWithValue("@Total", total)

                Dim idVenta As Integer = CInt(cmdVenta.ExecuteScalar())

                ' Insertar cada item
                For Each item In items
                    Dim sqlItem As String = "INSERT INTO VentasItems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"
                    Dim cmdItem As New SqlCommand(sqlItem, con, trans)
                    cmdItem.Parameters.AddWithValue("@IDVenta", idVenta)
                    cmdItem.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                    cmdItem.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                    cmdItem.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                    cmdItem.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                    cmdItem.ExecuteNonQuery()
                Next

                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
                Throw New Exception("Error al guardar la venta con sus items: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Shared Function ObtenerResumenDeVentas() As List(Of VentaResumenDetallada)
        Dim lista As New List(Of VentaResumenDetallada)
        Dim ventasDict As New Dictionary(Of Integer, VentaResumenDetallada) ' 👈 movida aquí
        Dim cadenaConexion As String = ConfigurationManager.ConnectionStrings("ConexionSQL").ConnectionString

        Dim sql As String = "
            SELECT 
            V.ID,
            V.Fecha,
            ISNULL(C.Cliente, 'Cliente eliminado') AS Cliente,
            ISNULL(P.Nombre, 'Producto eliminado') AS Nombre,
            CASE 
                WHEN P.ID IS NULL THEN NULL
                ELSE VI.Cantidad
            END AS Cantidad,
            VI.PrecioTotal,
            V.Total
        FROM Ventas V
        LEFT JOIN Clientes C ON V.IDCliente = C.ID
        LEFT JOIN VentasItems VI ON V.ID = VI.IDVenta
        LEFT JOIN Productos P ON VI.IDProducto = P.ID
        ORDER BY V.ID, VI.ID"

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim idVenta As Integer = reader.GetInt32(0)
                        Dim fecha As Date = reader.GetDateTime(1)
                        Dim cliente As String = reader.GetString(2)
                        Dim producto As String = reader.GetValue(3).ToString()
                        Dim cantidad As Integer = If(reader.IsDBNull(4), 0, Convert.ToInt32(reader.GetValue(4)))
                        Dim totalVenta As Decimal = If(reader.IsDBNull(6), 0D, Convert.ToDecimal(reader.GetValue(6)))


                        If Not ventasDict.ContainsKey(idVenta) Then
                            ventasDict(idVenta) = New VentaResumenDetallada With {
                                .IDVenta = idVenta,
                                .Fecha = fecha,
                                .Cliente = cliente,
                                .Productos = "",
                                .Total = totalVenta
                            }
                        End If

                        ventasDict(idVenta).Productos &= $"{producto} (x{cantidad}). "
                    End While
                End Using
            End Using
        End Using

        ' Ahora sí, fuera del using:
        For Each venta In ventasDict.Values
            If venta.Productos.EndsWith(", ") Then
                venta.Productos = venta.Productos.Substring(0, venta.Productos.Length - 2)
            End If
            lista.Add(venta)
        Next

        Return lista
    End Function

End Class