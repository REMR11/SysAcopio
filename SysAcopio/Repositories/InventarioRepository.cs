using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SysAcopio.Repositories
{

    public class InventarioRepository
    {


        public long IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public int Cantidad { get; set; }
        public int IdTipoRecurso { get; set; }

        
      
       
        public DataTable GetInventario()
        {
            DataTable mydt = new DataTable();
            SysAcopioDbContext conectar = new SysAcopioDbContext();

            // Usar la conexión a la base de datos
            using (SqlConnection conn = conectar.ConnectionServer())
            {
                string sql = "SELECT id_recurso, nombre_recurso,cantidad,IdTipoRecurso FROM Recurso";// Consulta SQL
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    { 
                        if(conn.State  != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        // Abrir la conexión
                        //conn.Open();

                        // Ejecución de la consulta y lectura de la tabla
                        using (SqlDataReader mydr = cmd.ExecuteReader())
                        {
                            // Agregar la lectura a la tabla
                            mydt.Load(mydr);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de la excepción (puedes registrar el error o mostrar un mensaje)
                        MessageBox.Show("Error en la consulta: ");
                    }
                    // La conexión se cierra automáticamente al salir del bloque using
                }
            }
            return mydt;
        }



        public long AgregarInventario()
        {
            long id = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();

            // Usar 'using' para asegurar que los recursos se liberen correctamente
            using (SqlConnection conn = conectar.ConnectionServer())
            {
                string insertsql = "INSERT INTO Recurso(nombre_recurso, cantidad, id_tipo_recurso) VALUES (@nombre_recursos, @cantidad, @tipo_recursos); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(insertsql, conn))
                {
                    // Agregar parámetros
                    cmd.Parameters.Add("@nombre_recursos", SqlDbType.VarChar).Value = this.NombreRecurso;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = this.Cantidad; // Ajusta el tipo según sea necesario
                    cmd.Parameters.Add("@tipo_recursos", SqlDbType.Int).Value =this.IdTipoRecurso; // Ajusta el tipo según sea necesario
                  

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        // Abrir la conexión
                        // conn.Open();

                        // Ejecutar la consulta y obtener el ID insertado
                        id = Convert.ToInt64(cmd.ExecuteScalar());
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de excepciones
                        // Aquí puedes registrar el error o lanzar una excepción
                        throw new Exception("Error al agregar inventario: " + ex.Message, ex);
                    }
                }
            }

            return id;

        }


        public int EditarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();

            using (SqlConnection conn = conectar.ConnectionServer())
            {
                // Corrección de la consulta SQL
                string updatesql = "UPDATE Recurso SET nombre_recurso = @nombre_recursos, cantidad = @cantidad, id_tipo_recurso = @tipo_recursos WHERE id_recurso = @id_recursos;";

                using (SqlCommand cmd = new SqlCommand(updatesql, conn))
                {
                    // Agregar parámetros con tipos explícitos
                    cmd.Parameters.Add("@id_recursos", SqlDbType.Int).Value = this.IdRecurso; // Ajusta el tipo según sea necesario
                    cmd.Parameters.Add("@nombre_recursos", SqlDbType.VarChar).Value = this.NombreRecurso; // Ajusta el tipo según sea necesario
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = this.Cantidad; // Ajusta el tipo según sea necesario
                    cmd.Parameters.Add("@tipo_recursos", SqlDbType.Int).Value = this.IdTipoRecurso; // Ajusta el tipo según sea necesario

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        } // Abrir la conexión
                        //conn.Open();

                        // Ejecutar la consulta y capturar el número de filas afectadas
                        affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de excepciones
                        // Aquí puedes registrar el error o lanzar una excepción
                        throw new Exception("Error al editar inventario: " + ex.Message, ex);
                    }
                }
            }

            return affected;

        }

       

 /*public int EliminarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            using(SqlConnection conn = conectar.ConnectionServer())
            { 
                string updatesql = "UPDATE Recurso SET IsDeleted  WHERE id_recurso = @id_recursos";
                using(SqlCommand cmd = new SqlCommand(updatesql, conn))
                {
                    cmd.Parameters.AddWithValue("@id_recursos", SqlDbType.BigInt).Value = this.IdRecurso;
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                       // conn.Open();
                        affected = cmd.ExecuteNonQuery();
                    }
                    catch(SqlException ex) 
                    {
                        throw new Exception($"error al eliminar inventario: {ex.Message}", ex);
              //  cmd.Dispose();
               // conn.Close();
                    }
                }
            }
            return affected;
        }
            
            
        public void EliminarInventario(List<Inventario> inventario, int id)
        {
            // Buscar el elemento que se desea eliminar
            var item = inventario.FirstOrDefault(i => i.IdRecurso == id);

            // Si se encuentra el elemento, marcarlo como eliminado
            if (item != null)
            {
                item.IsDelete = true;
            }
            else
            {
                // Manejo de errores: puedes lanzar una excepción o registrar un mensaje
                Console.WriteLine($"No se encontró el recurso con ID: {id}");
                //throw new Exception($"No se encontró el recurso con ID: {id}");
            }
        }
 */

         public List<Inventario> ListaInventario()
        {
            List<Inventario> invetarios = new List<Inventario>();
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            using(SqlConnection conn=conectar.ConnectionServer())
            {
                string selectSql = "SELECT id_recurso,nombre_recurso,cantidad,id_tipo_recurso FROM Recurso WHERE cantidad >= 0;";
                using(SqlCommand cmd = new SqlCommand(selectSql,conn))
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Inventario inventario = new Inventario
                                {
                                    IdRecurso = reader.GetInt64(reader.GetOrdinal("id_recurso")),
                                    NombreRecurso = reader.GetString(reader.GetOrdinal("nombre_recurso")),
                                    Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                                    IdTipoRecurso = reader.GetInt64(reader.GetOrdinal("id_tipo_recurso"))
                                };
                                invetarios.Add(inventario);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"ERROR al listar: {ex.Message}", ex);
                    }
                }
            }
            return invetarios;
        }




        public int EliminarRegistro()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();

            using (SqlConnection conn = conectar.ConnectionServer())
            {
                string updateSql = "UPDATE Recurso SET cantidad = - 1 WHERE id_recurso = @id_recurso AND cantidad > 0";

                using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                {
                    cmd.Parameters.Add("@id_recurso", SqlDbType.BigInt).Value = this.IdRecurso;

                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception($"Error al restar cantidad: {ex.Message}", ex);
                    }
                }
            }

            return affected;
        }

    }




}
