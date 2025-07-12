Imports System.Data.SqlClient
Imports TacticaAppTest.Entidades

Public Class ProductoDAL

    Public Function ObtenerTodos() As List(Of Producto)
        Dim lista As New List(Of Producto)()

        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "SELECT * FROM productos"
            Dim cmd As New SqlCommand(query, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim p As New Producto()
                If Not IsDBNull(reader("ID")) Then
                    Integer.TryParse(reader("ID").ToString(), p.ID)
                End If
                p.Nombre = reader("Nombre").ToString()
                Decimal.TryParse(reader("Precio").ToString().Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, p.Precio)
                p.Categoria = reader("Categoria").ToString()
                lista.Add(p)
            End While
        End Using

        Return lista
    End Function

    Public Sub Insertar(producto As Producto)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
            cmd.Parameters.AddWithValue("@Precio", producto.Precio)
            cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Actualizar(producto As Producto)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "UPDATE productos SET Nombre=@Nombre, Precio=@Precio, Categoria=@Categoria WHERE ID=@ID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID", producto.ID)
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
            cmd.Parameters.AddWithValue("@Precio", producto.Precio)
            cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Eliminar(id As Integer)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "DELETE FROM productos WHERE ID=@ID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

End Class
