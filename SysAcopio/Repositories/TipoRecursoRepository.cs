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
        /// <returns>Objeto de clase TipoRecurso</returns>
        public TipoRecurso GetById(long id)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_tipo_recurso, nombre_tipo FROM Tipo_Recurso WHERE id_tipo_recurso= @id AND estado = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TipoRecurso
                            {
                                IdTipoRecurso = reader.GetInt64(0),
                                NombreTipo = reader.GetString(1),
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar un TipoRecurso
        /// </summary>
        /// <param name="tipoRecurso"></param>
        /// <param name="id"></param>
        /// <returns>Un valor booleano que confirma si se actualizo o no se actualizo</returns>
        public bool Update(TipoRecurso tipoRecurso)
        {
            string query = "UPDATE Proveedor SET nombre_proveedor = @nombre, estado = @estado WHERE id_proveedor = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", tipoRecurso.NombreTipo),
                new SqlParameter("@id", tipoRecurso.IdTipoRecurso)
            };

            return GenericFuncDB.AffectRow(query, parametros);
        }

        /// <summary>
        /// Método para buscar TipoRecurso basado en un string de busqueda
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public DataTable SearchTiposRecurso(string searchQuery)
        {
            string query = "SELECT id_tipo_recurso, nombre_tipo as 'Tipo Recurso' FROM TipoRecurso WHERE nombre_tipo LIKE @searchQuery;";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@searchQuery", "%"+ searchQuery + "%"),
            };

            return GenericFuncDB.GetRowsToTable(query, parametros);
        }
    }
}
