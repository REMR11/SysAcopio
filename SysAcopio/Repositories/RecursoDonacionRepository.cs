using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Repositories
{
    internal class RecursoDonacionRepository
    {
        public DataTable GetDetailDonation(long idDonacion)
        {
            string query = "SELECT rd.id_recurso_donacion, rd.id_donacion, r.nombre_recurso, rd.id_recurso, rd.cantidad " +
                "FROM Recurso_Donacion as rd " +
                "JOIN Recurso as r ON rd.id_recurso = r.id_recurso " +
                "WHERE id_donacion = @idDonacion";
            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@idDonacion", idDonacion),
            };

            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        public long Create(Recurso recursoDonacion, long idDonacion)
        {
            string query = "INSERT INTO Recurso_Donacion(id_donacion, id_recurso, cantidad) " +
                "VALUES (@idDonacion, @idRecurso, @cantidad)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                    new SqlParameter("@idDonacion", idDonacion),
                    new SqlParameter("@idRecurso", recursoDonacion.IdRecurso),
                    new SqlParameter("@cantidad", recursoDonacion.Cantidad)
            };
            return GenericFuncDB.InsertRow(query, parametros);
        }

        public DataTable GetReportInfo(DateTime startDate, DateTime endDate, String location, long providerId)
        {
            StringBuilder queryBuilder = new StringBuilder(@"
            SELECT  p.nombre_proveedor as 'Proveedor', d.ubicacion as 'Ubicacion', r.nombre_recurso as 'Recurso', rd.cantidad as 'Cantidad'
            FROM Recurso_Donacion as rd
            JOIN Recurso as r ON rd.id_recurso = r.id_recurso
            JOIN Donacion as d ON rd.id_donacion = d.id_donacion
            JOIN Proveedor as p ON d.id_proveedor = p.id_proveedor
            WHERE 1=1");


            var parameters = new List<SqlParameter>
            {

            };

            if (startDate != null && endDate != null)
            {
                queryBuilder.Append(" AND CAST(d.fecha as DATE) BETWEEN @startDate AND @endDate");
                parameters.Add(new SqlParameter("@startDate", startDate));
                parameters.Add(new SqlParameter("@endDate", endDate));
            }

            if (!string.IsNullOrEmpty(location))
            {
                queryBuilder.Append(" AND d.ubicacion LIKE '%' + @location + '%'");
                parameters.Add(new SqlParameter("@location", location));
            }

            if (providerId != 0)
            {
                queryBuilder.Append(" AND d.id_proveedor = @providerId");
                parameters.Add(new SqlParameter("@providerId", providerId));
            }

            string query = queryBuilder.ToString();
            return GenericFuncDB.GetRowsToTable(query, parameters.ToArray());
        }
    }
}
