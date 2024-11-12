using System;
using System.Data.SqlClient;
using System.Data;
using SysAcopio.Controllers;

namespace SysAcopio.Repositories
{
    public class GenericFuncDB
    {
        private static readonly SysAcopioDbContext dbContext = new SysAcopioDbContext();

        /// <summary>
        /// Método generico para extraer una tabla de la base de datos
        /// </summary>
        /// <param name="query">String que representa la sentencia SQL a usarse</param>
        /// <param name="parametros">Arreglo de SqlParameter que representan los parametros de la base de datos</param>
        /// <returns>Los resultados de tipo DataTable</returns>
        public static DataTable GetRowsToTable(string query, SqlParameter[] parametros)
        {
            // Crear un objeto DataTable para almacenar los resultados
            DataTable resultados = new DataTable();
            //Creamos la conexión
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                //Creamos el comando SQL
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    // Agregar los parámetros a la consulta
                    if (parametros != null)
                    {
                        foreach (SqlParameter parametro in parametros)
                        {
                            cmd.Parameters.Add(parametro);
                        }
                    }

                    //Realizamos la petición
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        resultados.Load(reader);
                    }
                }
            }
            return resultados;
        }

        /// <summary>
        /// Método generico para insertar una fila en la base de datos y que devuelva el id que inserto
        /// </summary>
        /// <param name="query">String que representa la sentencia SQL a usarse</param>
        /// <param name="parametros">Arreglo de SqlParameter que representan los parametros de la base de datos</param>
        /// <returns>Un tipo de dato long que representa el id de inserción, en caso ocurra error devuelve -1</returns>
        public static long InsertRow(string query, SqlParameter[] parametros)
        {
            try
            {
                query = query + "SELECT SCOPE_IDENTITY();";
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    //Creamos el comando SQL
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Agregar los parámetros a la consulta
                        if (parametros != null)
                        {
                            foreach (SqlParameter parametro in parametros)
                            {
                                cmd.Parameters.Add(parametro);
                            }
                        }

                        // ExecuteScalar devuelve el ID generado
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt64(result);
                        }

                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        /// <summary>
        /// Método generico para modificar o eliminar una fila
        /// </summary>
        /// <param name="query">String que representa la sentencia SQL a usarse</param>
        /// <param name="parametros">Arreglo de SqlParameter que representan los parametros de la base de datos</param>
        /// <returns>Devuelve un booleano indicando si se afecto o no se afecto la fila</returns>
        public static bool AffectRow(string query, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    //Creamos el comando SQL
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        // Agregar los parámetros a la consulta
                        if (parametros != null)
                        {
                            foreach (SqlParameter parametro in parametros)
                            {
                                cmd.Parameters.Add(parametro);
                            }
                        }

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
