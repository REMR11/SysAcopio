using SysAcopio.Models;
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

        /// <summary>
        /// Método que obtiene todos los tipos de recurso disponibles en la base de datos.
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los tipos de recursos.</returns>
        public DataTable GetAllTipoRecurso()
        {
            // Consulta SQL para obtener todos los tipos de recurso
            string query = "SELECT * FROM Tipo_Recurso";

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
            string query = "SELECT rs.id_recurso_solicitud, rs.id_recurso, r.nombre_recurso, rs.id_solicitud, rs.cantidad " +
                "FROM RECURSO_SOLICITUD as rs " +
                "JOIN Recurso as r ON rs.id_recurso = r.id_recurso " +
                "WHERE id_Solicitud = @idSolicitud";
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
            string query = "INSERT INTO RECURSO_SOLICITUD(id_recurso, id_solicitud, cantidad) " +
                "VALUES (@idRecurso, @idSolicitud, @cantidad)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idSolicitud", idSolicitud), // Parámetro para el ID de la solicitud
                new SqlParameter("@idRecurso", recursoSolicitud.IdRecurso), // Parámetro para el ID del recurso
                new SqlParameter("@cantidad", recursoSolicitud.Cantidad) // Parámetro para la cantidad del recurso
            };
            return GenericFuncDB.InsertRow(query, parametros); // Ejecuta la consulta de inserción y devuelve el ID de la nueva fila
        }
    }
}