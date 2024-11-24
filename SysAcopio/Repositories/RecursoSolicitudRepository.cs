using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SysAcopio.Repositories
{
    /// <summary>
    /// Repositorio para gestionar el acceso a los datos relacionados con las solicitudes de recursos.
    /// Proporciona métodos para obtener recursos, tipos de recursos y manejar las solicitudes de recursos.
    /// </summary>
    public class RecursoSolicitudRepository
    {
        /// <summary>
        /// Método que obtiene todos los recursos disponibles en la base de datos.
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los recursos disponibles.</returns>
        public DataTable GetAllRecursos()
        {
            // Consulta SQL para obtener todos los recursos con cantidad mayor a 0
            string query = @"SELECT r.id_recurso, r.nombre_recurso AS NombreRecurso, r.id_tipo_recurso, tr.nombre_tipo AS 'Tipo'
                FROM Recurso AS r
                JOIN Tipo_Recurso AS tr on r.id_tipo_recurso = tr.id_tipo_recurso
                WHERE r.cantidad > 0";

            return GenericFuncDB.GetRowsToTable(query, null); // Ejecuta la consulta y devuelve el resultado como DataTable
        }

        public DataTable ObtenerPorId(long idRecursoSolicitud)
        {
            string query = @"SELECT id_recurso, id_solicitud, cantidad
                            FROM RECURSO_SOLICITUD
                            WHERE id_recurso_solicitud = @id_recurso_solicitud";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@id_recurso_solicitud", idRecursoSolicitud)
            };
            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        /// <summary>
        /// Método que obtiene todos los tipos de recurso disponibles en la base de datos.
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los tipos de recursos.</returns>
        public DataTable GetAllTipoRecurso()
        {
            // Consulta SQL para obtener todos los tipos de recurso
            string query = @"SELECT id_tipo_recurso, nombre_tipo FROM Tipo_Recurso";

            return GenericFuncDB.GetRowsToTable(query, null); // Ejecuta la consulta y devuelve el resultado como DataTable
        }

        /// <summary>
        /// Obtiene los detalles de una solicitud de recurso específica.
        /// </summary>
        /// <param name="idsolicitud">ID de la solicitud para la cual se obtienen los detalles.</param>
        /// <returns>Objeto de tipo DataTable con los detalles de la solicitud.</returns>
        public DataTable GetDetailSolicitud(long idsolicitud)
        {
            // Consulta SQL para obtener los detalles de la solicitud de recurso
            string query = @"SELECT rs.id_recurso_solicitud, rs.id_recurso, r.nombre_recurso, rs.id_solicitud, rs.cantidad
                            FROM RECURSO_SOLICITUD as rs
                                JOIN Recurso as r ON rs.id_recurso = r.id_recurso
                            WHERE id_Solicitud = @idSolicitud";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idSolicitud", idsolicitud), // Parámetro para la consulta
            };

            return GenericFuncDB.GetRowsToTable(query, parametros); // Ejecuta la consulta y devuelve el resultado como DataTable
        }

        /// <summary>
        /// Crea una nueva solicitud de recurso en la base de datos.
        /// </summary>
        /// <param name="recursoSolicitud">Recurso que se va a solicitar.</param>
        /// <param name="idSolicitud">ID de la solicitud a la que se asociará el recurso.</param>
        /// <returns>El ID de la nueva fila insertada en la base de datos.</returns>
        public long Create(Recurso recursoSolicitud, long idSolicitud)
        {
            // Consulta SQL para insertar un nuevo recurso en la solicitud
            string query = @"INSERT INTO RECURSO_SOLICITUD(id_recurso, id_solicitud, cantidad) 
                                VALUES (@idRecurso, @idSolicitud, @cantidad)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idSolicitud", idSolicitud), // Parámetro para el ID de la solicitud
                new SqlParameter("@idRecurso", recursoSolicitud.IdRecurso), // Parámetro para el ID del recurso
                new SqlParameter("@cantidad", recursoSolicitud.Cantidad) // Parámetro para la cantidad del recurso
            };
            return GenericFuncDB.InsertRow(query, parametros); // Ejecuta la consulta de inserción y devuelve el ID de la nueva fila
        }
        public bool Update(RecursoSolicitud recursoSolicitud)
        {
            // Consulta SQL para actualizar un recurso en la solicitud
            string query = @"UPDATE RECURSO_SOLICITUD SET  
                        Cantidad = @Cantidad
                    WHERE id_solicitud = @idSolicitud AND id_recurso = @idRecurso";

            // Definición de los parámetros para la consulta
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idRecurso", recursoSolicitud.IdRecurso), // Parámetro para el ID del recurso
                new SqlParameter("@idSolicitud", recursoSolicitud.IdSolicitud), // Parámetro para el ID de la solicitud
                new SqlParameter("@Cantidad", recursoSolicitud.Cantidad), // Parámetro para la cantidad del recurso
            };

            try
            {
                // Ejecuta la consulta de actualización y devuelve booleano si afectó o no al registro
                return GenericFuncDB.AffectRow(query, parametros);
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o lanzar una excepción)
                // Por ejemplo: log.Error(ex);
                return false; // O lanzar una excepción según tu lógica de manejo de errores
            }
        }

        public bool RemoveRecursoFromSolicitud(RecursoSolicitud recursoSolicitud)
        {
            // Aquí implementas la lógica para eliminar el recurso de la solicitud en la base de datos

            string query = @"DELETE FROM RECURSO_SOLICITUD 
                            WHERE id_solicitud = @idSolicitud AND id_recurso = @idRecurso";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idSolicitud", recursoSolicitud.IdSolicitud),
                new SqlParameter("@idRecurso", recursoSolicitud.IdRecurso)
            };
            return GenericFuncDB.AffectRow(query, parametros);
        }
    }
}
