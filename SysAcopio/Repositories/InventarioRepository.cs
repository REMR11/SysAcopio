using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace SysAcopio.Repositories
{
    public class InventarioRepository
    {
        public DataTable GetInventario()
        {
            String query = "d.id_donacion,d.id_proveedor,rd.id_recurso_donacion,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlParameter[] parameters = null;
            return GenericFuncDB.GetRowsToTable(query, parameters);

        }
       public DataTable Inventario()
        { 
            DataTable mydt = new DataTable();
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            String query = "";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader mydr = null;
            try
            {
                conn.Open();
                mydr = cmd.ExecuteReader();
                mydt.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;

        }
    }
    
    
}
