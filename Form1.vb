
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar_Data()
    End Sub

    ' funcion para mostrar los datos de la DB'
    Private Sub Mostrar_Data()
        'CREA LA CONEXION SQL
        Dim query As String = "Data Source=DESKTOP-25J4VH0;Initial Catalog=TP-Agenda-PRG3;Integrated Security=True;"

        Dim conexion As New SqlConnection(query)

        Try
            ' Abre la conexión
            conexion.Open()

            Dim consulta As String = "SELECT * FROM CONTACTOS"

            Dim comando As New SqlCommand(consulta, conexion)

            Dim adaptador As New SqlDataAdapter(comando)

            Dim tabla As New DataTable()

            adaptador.Fill(tabla)

            DataGridView1.DataSource = tabla

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)

        Finally
            ' Cierra la conexión
            conexion.Close()

        End Try

    End Sub


    ' boton para guardar la data '
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ' Define la cadena de conexión
            Dim cadenaConexion As String = "Data Source=DESKTOP-25J4VH0;Initial Catalog=TP-Agenda-PRG3;Integrated Security=True;"

            ' Crea una conexión SQL
            Dim conexion As New SqlConnection(cadenaConexion)
            conexion.Open()

            ' Define la consulta SQL para verificar si el DNI ya existe
            Dim consultaExistencia As String = "SELECT COUNT(*) FROM CONTACTOS WHERE DNI = @DNI"

            ' Crea un comando SQL para verificar la existencia del DNI
            Dim commandExistencia As New SqlCommand(consultaExistencia, conexion)
            commandExistencia.Parameters.AddWithValue("@DNI", CInt(txtDNI.Text))

            ' Ejecuta la consulta para contar la cantidad de registros con el mismo DNI
            Dim cantidadExistente As Integer = CInt(commandExistencia.ExecuteScalar())

            If cantidadExistente > 0 Then
                ' Si el DNI ya existe, realiza una actualización (UPDATE)
                Dim queryActualizar As String = "UPDATE CONTACTOS SET APELLIDO = @Apellido, NOMBRE = @Nombre, TELEFONO = @Telefono WHERE DNI = @DNI"

                ' Crea un comando SQL con la consulta de actualización
                Dim commandActualizar As New SqlCommand(queryActualizar, conexion)
                commandActualizar.Parameters.AddWithValue("@DNI", CInt(txtDNI.Text))
                commandActualizar.Parameters.AddWithValue("@Apellido", txtApellido.Text)
                commandActualizar.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                commandActualizar.Parameters.AddWithValue("@Telefono", txtTelefono.Text)

                ' Ejecuta la consulta de actualización
                commandActualizar.ExecuteNonQuery()
            Else
                ' Si el DNI no existe, realiza una inserción (INSERT)
                Dim queryInsertar As String = "INSERT INTO CONTACTOS (DNI, APELLIDO, NOMBRE, TELEFONO) VALUES (@DNI, @Apellido, @Nombre, @Telefono)"

                ' Crea un comando SQL con la consulta de inserción
                Dim commandInsertar As New SqlCommand(queryInsertar, conexion)
                commandInsertar.Parameters.AddWithValue("@DNI", CInt(txtDNI.Text))
                commandInsertar.Parameters.AddWithValue("@Apellido", txtApellido.Text)
                commandInsertar.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                commandInsertar.Parameters.AddWithValue("@Telefono", txtTelefono.Text)

                ' Ejecuta la consulta de inserción
                commandInsertar.ExecuteNonQuery()
            End If

            ' Cierra la conexión
            conexion.Close()

            ' Llama al método para mostrar los datos actualizados en el DataGridView
            Mostrar_Data()

            ' Limpia los campos de entrada
            txtDNI.Clear()
            txtApellido.Clear()
            txtNombre.Clear()
            txtTelefono.Clear()
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos: " & ex.Message)
        End Try
    End Sub



    'Eliminar de la base de datos
    Private Sub EliminarContacto(dni As Integer)
        Try
            ' Define la cadena de conexión
            Dim conectar As String = "Data Source=DESKTOP-25J4VH0;Initial Catalog=TP-Agenda-PRG3;Integrated Security=True;"

            ' Crea una conexión SQL
            Dim conexion As New SqlConnection(conectar)
            conexion.Open()

            ' Define la consulta SQL para eliminar el contacto
            Dim query As String = "DELETE FROM CONTACTOS WHERE DNI = @DNI"

            ' Crea un comando SQL con la consulta y la conexión
            Dim command As New SqlCommand(query, conexion)
            command.Parameters.AddWithValue("@DNI", dni)

            ' Ejecuta la consulta DELETE
            command.ExecuteNonQuery()

            ' Cierra la conexión
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el contacto: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtén el valor del DNI de la fila seleccionada
            Dim dni As Integer = CInt(DataGridView1.SelectedRows(0).Cells("DNI").Value)

            ' Llama a una función para eliminar el contacto de la base de datos
            EliminarContacto(dni)

            ' Actualiza el DataGridView para reflejar los cambios
            Mostrar_Data()
        Else
            MessageBox.Show("Selecciona una fila para eliminar.")
        End If


    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ' Verifica si se ha seleccionado una fila en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtén los valores de los campos que deseas modificar de la fila seleccionada
            Dim dni As Integer = CInt(DataGridView1.SelectedRows(0).Cells("DNI").Value)
            Dim apellido As String = DataGridView1.SelectedRows(0).Cells("APELLIDO").Value.ToString()
            Dim nombre As String = DataGridView1.SelectedRows(0).Cells("NOMBRE").Value.ToString()
            Dim telefono As String = DataGridView1.SelectedRows(0).Cells("TELEFONO").Value.ToString()

            ' Llena los campos de edición en tu formulario con los valores obtenidos
            txtDNI.Text = dni.ToString()
            txtApellido.Text = apellido
            txtNombre.Text = nombre
            txtTelefono.Text = telefono

            ' Habilita la edición de campos y permite al usuario realizar modificaciones

            ' Luego, cuando el usuario haga clic en un botón "Guardar" (por ejemplo, btnGuardarModificacion), ejecuta el código para actualizar el contacto en la base de datos y en el DataGridView.
        Else
            MessageBox.Show("Selecciona una fila para modificar.")
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Crea una instancia del formulario Form2
        Dim form2 As New Form2()

        ' Abre el formulario Form2
        form2.Show()
    End Sub



End Class
