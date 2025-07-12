Imports System.IO
Imports Newtonsoft.Json
Imports TacticaAppTest.Entidades

Public Class CategoriaService
    Private Shared archivoCategorias As String = Path.Combine(Application.StartupPath, "categorias.json")

    Public Shared Function CargarCategorias() As List(Of Categoria)
        If Not File.Exists(archivoCategorias) Then
            ' Si el archivo no existe, devolvemos una lista vacía (y podemos crearlo vacío si querés)
            GuardarCategorias(New List(Of Categoria) From {New Categoria With {.Nombre = "Otra"}})
        End If

        Try
            Dim json As String = File.ReadAllText(archivoCategorias)
            Dim lista As List(Of Categoria) = JsonConvert.DeserializeObject(Of List(Of Categoria))(json)

            ' Asegurarse que nunca devolvemos Nothing
            If lista Is Nothing Then
                lista = New List(Of Categoria)()
            End If

            Return lista
        Catch ex As Exception
            MessageBox.Show("Error al leer archivo de categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New List(Of Categoria)()
        End Try
    End Function

    Public Shared Sub GuardarCategorias(categorias As List(Of Categoria))
        Try
            Dim json As String = JsonConvert.SerializeObject(categorias, Formatting.Indented)
            File.WriteAllText(archivoCategorias, json)
        Catch ex As Exception
            MessageBox.Show("Error al guardar categorías: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class