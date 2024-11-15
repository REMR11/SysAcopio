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
    }
}
