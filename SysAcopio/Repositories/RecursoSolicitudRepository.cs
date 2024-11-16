using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Repositories
{
    public class RecursoSolicitudRepository
    {
        public DataTable GetDetailSolicitud(long idDonacion)
        {
            string query = "SELECT rs.id_recurso_solicitud, rs.id_recurso, r.nombre_recurso, rs.id_solicitud, rs.cantidad " +
                "FROM RECURSO_SOLICITUD as rs " +
                "JOIN Recurso as r ON rs.id_recurso = r.id_recurso " +
                "WHERE id_donacion = @idDonacion";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idDonacion", idDonacion),
            };

            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        public long Create(Recurso recursoSolicitud, long idSolicitud)
        {
            string query = "INSERT INTO RECURSO_SOLICITUD(id_recurso, id_solicitud, cantidad) " +
                "VALUES (@idRecurso, @idSolicitud, @cantidad)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idSolicitud",idSolicitud),
                new SqlParameter("@idRecurso", recursoSolicitud.IdRecurso),
                new SqlParameter("@cantidad", recursoSolicitud.Cantidad)
            };
            return GenericFuncDB.InsertRow(query, parametros);
        }
    }
}
