using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    internal class InventarioRepository
    {
        /// <summary>
        /// Método para obtener todo el inventario de la base de datos
        /// </summary>
        /// <returns>Objeto de tipo DataTable</returns>
        public DataTable GetInventario()
        {
            string query = " SELECT r.id_recurso, r.nombre_recurso AS NombreRecurso, r.id_tipo_recurso, tr.nombre_tipo AS 'TipoRecurso', r.cantidad" +
                " FROM Recurso AS r" +
                " JOIN Tipo_Recurso AS tr on r.id_tipo_recurso = tr.id_tipo_recurso" +
                " WHERE r.cantidad >= 0";
            return GenericFuncDB.GetRowsToTable(query, null);
        }

        /// <summary>
        /// Método para crear un recurso
        /// </summary>
        /// <param name="recurso"></param>
        /// <returns>Un long que representa el id de la Donación, si ocurrio un error retorn -1</returns>
        public long Create(Recurso recurso)
        {
            string query = "INSERT INTO Recurso (nombre_recurso, cantidad, id_tipo_recurso) " +
                "VALUES (@nombre, @cantidad, @idTipo);";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", recurso.NombreRecurso),
                new SqlParameter("@cantidad", recurso.Cantidad),
                new SqlParameter("@idTipo", recurso.IdTipoRecurso)
            };

            return GenericFuncDB.InsertRow(query, parameters);
        }

        /// <summary>
        /// Método para obtener el Recurso por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo Donacion o null en caso no exista</returns>
        public Recurso GetById(long id)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = " SELECT r.id_recurso, r.nombre_recurso AS NombreRecurso, r.id_tipo_recurso, tr.nombre_tipo AS 'TipoRecurso', r.cantidad" +
                " FROM Recurso AS r" +
                " JOIN Tipo_Recurso AS tr on r.id_tipo_recurso = tr.id_tipo_recurso" +
                " WHERE r.cantidad >= 0 AND r.id_recurso = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Recurso
                            {
                                IdRecurso = reader.GetInt64(0),
                                NombreRecurso = reader.GetString(1),
                                Cantidad = reader.GetInt32(4),
                                IdTipoRecurso = reader.GetInt64(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Método para buscar los Recursos
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns>Un objeto de tipo DataTable con los datos que coincidan</returns>
        public DataTable SearchRecursos(string searchQuery, int estadoCantidad, int idTipo)
        {
            string query = " SELECT r.id_recurso, r.nombre_recurso AS NombreRecurso, r.id_tipo_recurso, tr.nombre_tipo AS 'TipoRecurso', r.cantidad" +
                " FROM Recurso AS r" +
                " JOIN Tipo_Recurso AS tr on r.id_tipo_recurso = tr.id_tipo_recurso" +
                " WHERE 1=1 ";

            switch (estadoCantidad)
            {
                case 0:
                    query += " AND r.cantidad >= 0";
                    break;
                case 1:
                    query += " AND r.cantidad >= 1";
                    break;
                case 2:
                    query += " AND r.cantidad = 0";
                    break;
            }

            if (searchQuery.Trim() != string.Empty)
            {
                query += " AND r.nombre_recurso LIKE @search";
            }

            if (idTipo > 0)
            {
                query += " AND r.id_tipo_recurso = @idTipo";
            }

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@search", "%"+ searchQuery + "%"),
                new SqlParameter("@idTipo", idTipo)
            };
            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        public bool Update(Recurso recurso)
        {
            string query = "UPDATE Recurso SET nombre_recurso = @nombre, cantidad = @cantidad, id_tipo_recurso = @idTipo WHERE id_recurso = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@nombre", recurso.NombreRecurso),
                new SqlParameter("@cantidad", recurso.Cantidad),
                new SqlParameter("@idTipo", recurso.IdTipoRecurso),
                new SqlParameter("@id", recurso.IdRecurso)
            };

            return GenericFuncDB.AffectRow(query, parameters);
        }

        /// <summary>
        /// Método para borrado logico del recurso
        /// </summary>
        /// <param name="id">Id del recurso</param>
        /// <returns>Valor booleano que representa si se elimino o no</returns>
        public int DeleteLogic(long id)
        {
            try
            {
                Recurso recurso = GetById(id);
                if (recurso == null) return -1;

                recurso.Cantidad = -1;
                return Update(recurso) ? 1 : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
