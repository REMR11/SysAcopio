using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SysAcopio.Repositories
{
    public class DonacionRepository
    {
        /// <summary>
        /// Método que retorna todas las donaciones
        /// </summary>
        /// <returns>Un DataTable con los registros de la tabla</returns>
        public DataTable GetAll()
        {
            string query = "SELECT d.id_donacion, d.id_proveedor, p.nombre_proveedor as NombreProveedor, d.ubicacion, d.fecha " +
                "FROM Donacion as d " +
                "JOIN Proveedor as p ON d.id_proveedor = p.id_proveedor;";

            SqlParameter[] parameters = null;
            return GenericFuncDB.GetRowsToTable(query, parameters);
        }
        /// <summary>
        /// Método para crear una donación
        /// </summary>
        /// <param name="donacion"></param>
        /// <returns>Un long que representa el id de la Donación, si ocurrio un error retorn -1</returns>
        public long Create(Donacion donacion)
        {
            string query = "INSERT INTO Donacion (id_proveedor, ubicacion, fecha) " +
                "VALUES (@idProveedor, @ubicacion, @fecha);";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@idProveedor", donacion.IdProveedor),
                new SqlParameter("@ubicacion", donacion.Ubicacion),
                new SqlParameter("@fecha", DateTime.Now)
            };

            return GenericFuncDB.InsertRow(query, parameters);
        }

        /// <summary>
        /// Método para obtener la Donacion por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo Donacion o null en caso no exista</returns>
        public Donacion GetById(long id)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT d.id_donacion, p.nombre_proveedor, d.id_proveedor, d.ubicacion, d.fecha " +
                    "FROM Donacion as d " +
                    "JOIN Proveedor as p ON d.id_proveedor = p.id_proveedor " +
                    "WHERE d.id_donacion = @id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Donacion
                            {
                                IdDonacion = reader.GetInt64(0),
                                IdProveedor = reader.GetInt64(2),
                                Ubicacion = reader.GetString(3),
                                Fecha = reader.GetDateTime(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Método para buscar las donaciones
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns>Un objeto de tipo DataTable con los datos que coincidan</returns>
        public DataTable SearchDonaciones(string searchQuery)
        {
            string query = "SELECT d.id_donacion, p.nombre_proveedor, d.ubicacion, d.fecha, d.id_proveedor" +
                " FROM Donacion as d" +
                " JOIN Proveedor as p ON d.id_proveedor = p.id_proveedor" +
                " WHERE" +
                " d.ubicacion LIKE @search OR" +
                " CAST(d.fecha AS NVARCHAR) LIKE @search" +
                " p.nombre_proveedor LIKE @search;";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@search", "%"+ searchQuery + "%"),
            };
            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        /// <summary>
        /// Método para obtener todos los productos activos
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los Recursos disponibles</returns>
        public DataTable GetActiveRecursos()
        {
            string query = "SELECT r.nombre_recurso, tr.nombre_tipo, r.id_tipo_recurso " +
                " FROM Recurso as r" +
                " JOIN Tipo_Recurso as tr ON r.id_tipo_recurso = tr.id_tipo_recurso" +
                " WHERE r.cantidad > 0";

            SqlParameter[] parameters = null;
            return GenericFuncDB.GetRowsToTable(query, parameters);
        }

        /// <summary>
        /// Método que obtiene todos los recursos
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los recurso</returns>
        public DataTable GetAllRecursos()
        {
            string query = @"SELECT r.id_recurso, r.nombre_recurso AS NombreRecurso, r.id_tipo_recurso, tr.nombre_tipo AS 'Tipo'
                FROM Recurso AS r
                JOIN Tipo_Recurso AS tr on r.id_tipo_recurso = tr.id_tipo_recurso
                WHERE r.cantidad >= 0";

            return GenericFuncDB.GetRowsToTable(query, null);
        }

        /// <summary>
        /// Método que obtiene todos los tipos de recurso
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los recursos</returns>
        public DataTable GetAllTipoRecurso()
        {
            string query = "SELECT id_tipo_recurso, nombre_tipo FROM Tipo_Recurso";

            return GenericFuncDB.GetRowsToTable(query, null);
        }
    }
}
