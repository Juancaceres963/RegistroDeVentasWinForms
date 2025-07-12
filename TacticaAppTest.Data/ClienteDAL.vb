Imports System.Data.SqlClient
Imports TacticaAppTest.Entidades ' <-- vamos a usar esta forma de importar

Public Class ClienteDAL
    Public Function ObtenerTodos() As List(Of Cliente)
        Dim lista As New List(Of Cliente)()

        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "SELECT * FROM clientes"
            Dim cmd As New SqlCommand(query, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim c As New Cliente()
                c.ID = Convert.ToInt32(reader("ID"))
                c.Cliente = reader("Cliente").ToString()
                c.Telefono = reader("Telefono").ToString()
                c.Correo = reader("Correo").ToString()
                lista.Add(c)
            End While
        End Using

        Return lista
    End Function

    ' <-- Método para insertar un cliente
    Public Shared Sub Insertar(cliente As Cliente)
        Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)"

        Using conn As SqlConnection = Conexion.ObtenerConexion()
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Cliente", cliente.Cliente)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' <-- Método para eliminar clientes 
    Public Sub Eliminar(id As Integer)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "DELETE FROM clientes WHERE ID = @ID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' <-- Método para actualizar clientes
    Public Shared Sub Actualizar(cliente As Cliente)
        Using conn As SqlConnection = Conexion.ObtenerConexion()
            conn.Open()
            Dim query As String = "UPDATE clientes SET Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Cliente", cliente.Cliente)
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
            cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
            cmd.Parameters.AddWithValue("@ID", cliente.ID)
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class