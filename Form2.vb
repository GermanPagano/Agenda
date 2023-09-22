Imports System.Data.SqlClient

Public Class Form2
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Try
            ' Obtén el valor a buscar desde el cuadro de texto
            Dim valorABuscar As String = txtBuscador.Text.Trim()

            ' Define la cadena de conexión
            Dim cadenaConexion As String = "Data Source=DESKTOP-25J4VH0;Initial Catalog=TP-Agenda-PRG3;Integrated Security=True;"

            ' Crea una conexión SQL
            Dim conexion As New SqlConnection(cadenaConexion)
            conexion.Open()

            ' Define la consulta SQL para buscar el contacto por cualquier dato
            Dim consultaBuscar As String = "SELECT * FROM CONTACTOS WHERE DNI LIKE @Valor OR APELLIDO LIKE @Valor OR NOMBRE LIKE @Valor OR TELEFONO LIKE @Valor"

            ' Crea un comando SQL con la consulta y la conexión
            Dim commandBuscar As New SqlCommand(consultaBuscar, conexion)
            commandBuscar.Parameters.AddWithValue("@Valor", "%" & valorABuscar & "%")

            ' Crea un adaptador de datos y un DataTable para almacenar los resultados de la búsqueda
            Dim adaptador As New SqlDataAdapter(commandBuscar)
            Dim tabla As New DataTable()

            ' Llena el DataTable con los resultados de la búsqueda
            adaptador.Fill(tabla)

            ' Cierra la conexión
            conexion.Close()

            ' Verifica si se encontraron resultados
            If tabla.Rows.Count > 0 Then
                ' Crea una instancia del Form1
                Dim form1 As Form1 = CType(Application.OpenForms("Form1"), Form1)

                ' Asigna el DataTable como fuente de datos del DataGridView1 en el Form1
                form1.DataGridView1.DataSource = tabla

                ' Cierra el Form2
                Me.Close()
            Else
                MessageBox.Show("No se encontraron resultados.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message)
        End Try
    End Sub









End Class