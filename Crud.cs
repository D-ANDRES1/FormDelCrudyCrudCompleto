using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace FormDelCrud
{
    public class Crud
    {
        string connectionString = "Server=DESKTOP-LBPJ5AT;Database=umg_db;Integrated Security=True; TrustServerCertificate=True; ";


        public DataTable ObtenerAlumnos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tb_alumnos"; 

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(tabla);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error al obtener los datos de los alumnos: " + ex.Message);
                }
            }

            return tabla;
        }


        public void MostrarInformacionTareas()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tareas";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"id tareas:" + reader["id_tarea"] + " Carnet:" + reader["Carnet"] + " nota1: " + reader["nota1"] + " nota2: " + reader["nota2"] + " nota3: " + reader["nota3"] + " nota4: " + reader["nota4"]);
                    }
                    Console.WriteLine("Conexión exitosa a la base de datos, ya estás listo para la clase del sábado.");

                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Revisa y averigua el error, Error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }

        public void MostrarInformacionTablaAlumnos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tb_alumnos";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Carnet: " + reader["carnet"] + "  Estudiante: " + reader["Estudiante"] + "  Email: " + reader["email"] + "  Seccion: " + reader["seccion"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Revisa y averigua el error, Error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }

        public void InsertarTablaAlumnos(string carnet, string Estudiante, string email, char seccion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tb_alumnos (carnet, Estudiante, email, seccion) VALUES(@carnet,@Estudiante, @email, @seccion)";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@Estudiante", Estudiante);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@seccion", seccion);

                    connection.Open();

                    int FilasAfectadas = command.ExecuteNonQuery();

                    if (FilasAfectadas > 0)
                    {
                        Console.WriteLine("Alumno insertado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se insertó ningún alumno.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar: " + ex.Message);
                }
                connection.Close();
            }
        }

        public void BuscarTareaAlumno(string Carnet)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tareas WHERE Carnet = @Carnet";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", Carnet);


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine("Alumno encontrado:");
                        Console.WriteLine("id_tarea: " + reader["id_tarea"]);
                        Console.WriteLine("Carnet: " + reader["Carnet"]);
                        Console.WriteLine("Nota 1: " + reader["nota1"]);
                        Console.WriteLine("Nota 2: " + reader["nota2"]);
                        Console.WriteLine("Nota 3: " + reader["nota3"]);
                        Console.WriteLine("Nota 4: " + reader["nota4"]);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún alumno con ese carnet.");
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Revisa y averigua el error, Error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }

        public void InsertarNota(string Carnet, int nota1, int nota2, int nota3, int nota4)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tareas (Carnet, nota1, nota2, nota3, nota4) VALUES (@Carnet, @nota1, @nota2, @nota3, @nota4)";

                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", Carnet);
                    command.Parameters.AddWithValue("@nota1", nota1);
                    command.Parameters.AddWithValue("@nota2", nota2);
                    command.Parameters.AddWithValue("@nota3", nota3);
                    command.Parameters.AddWithValue("@nota4", nota4);

                    connection.Open();

                    int filas = command.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        Console.WriteLine("Alumno insertado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se insertó ningún alumno.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar: " + ex.Message);
                }
                connection.Close();
            }
        }

        public void EliminarTareaPorCarnet(string Carnet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM tareas WHERE Carnet = @Carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", Carnet);

                    connection.Open();

                    int FilasAfectadas = command.ExecuteNonQuery();

                    if (FilasAfectadas > 0)
                    {
                        Console.WriteLine("La tarea del alumno fue eliminada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna tarea con ese carnet.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar las tareas del Carnet: " + Carnet + " " + ex.Message);
                }
                connection.Close();
            }
        }

        public void EliminarAlumnoPorCarnet(string carnet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tb_alumnos WHERE carnet = @carnet";
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Carnet", carnet);

                    connection.Open();

                    int FilasAfectadas = command.ExecuteNonQuery();

                    if (FilasAfectadas > 0)
                    {
                        Console.WriteLine("La tarea del alumno fue eliminada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ninguna tarea con ese carnet.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar las tareas del Carnet: " + carnet + " " + ex.Message);
                }
                connection.Close();
            }

        }

    }
}
