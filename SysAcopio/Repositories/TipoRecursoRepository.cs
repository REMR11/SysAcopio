using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysAcopio.Models;
using SysAcopio.Controllers;

namespace SysAcopio.Repositories
{
    internal class TipoRecursoRepository
    {
        /// <summary>
        /// Método para obtener la tabla de todos los tipos de recurso
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string query = "SELECT id_tipo_recurso, nombre_tipo as 'Tipo Recurso' FROM TipoRecurso;";

            return GenericFuncDB.GetRowsToTable(query, null);
        }

        /// <summary>
        /// Método para crear un nuevo Tipo de recurso
        /// </summary>
        /// <param name="tipoRecurso">Objeto de la entidad TipoRecurso</param>
        /// <returns></returns>
        public long Create(TipoRecurso tipoRecurso)
        {
            string query = "INSERT INTO Tipo_Recurso (nombre_tipo) VALUES (@nombre)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", tipoRecurso.NombreTipo),
            };

            return GenericFuncDB.InsertRow(query, parametros);
        }

        /// <summary>
        /// Método para Obtener un Tipo de recurso en base a su ID
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns>Objeto de clase Proveedor</returns>
        public Proveedor GetById(long id)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_proveedor, nombre_proveedor, estado FROM Proveedor WHERE id_proveedor = @id AND estado = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Proveedor
                            {
                                IdProveedor = reader.GetInt64(0),
                                NombreProveedor = reader.GetString(1),
                                Estado = !reader.IsDBNull(2) && reader.GetBoolean(2), // Manejo de nulos
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
