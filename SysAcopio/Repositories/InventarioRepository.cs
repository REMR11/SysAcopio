using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace SysAcopio.Repositories
{
    public class InventarioRepository
    {
        public event EventHandler NotificarModificacionEnInventario;
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
        public void EditarInventario()
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            SqlConnection conn = dbContext.ConnectionServer();
            string updateSql = " update d.id_donacion=@id_donaciones,rd.id_recurso_donacion=@idrecursos,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@id_donaciones",dbContext);
            cmd.Parameters.AddWithValue("@id_provedores",dbContext);
             

            try
            {
                int affect = 0;
                conn.Open();
                affect = cmd.ExecuteNonQuery();
                if (affect > 0)
                {
                    if (NotificarModificacionEnInventario != null)
                    {
                        NotificarModificacionEnInventario(this, EventArgs.Empty);
                    }

                }

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            //metodo agregar inventario



        }


        public void AgregarInventario()
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            SqlConnection conn = dbContext.ConnectionServer();
            string insertSql = "insert into d.id_donacion=@id_donaciones,rd.id_recurso_donacion=@idrecursos,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlCommand cmd = new SqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("@id_donaciones", this);
            cmd.Parameters.AddWithValue("@id_provedores", this);
            //cmd.Parameters.AddWithValue("", this.recursodonaciones);

            try
            {
                long id = 0;
                conn.Open();
                Convert.ToInt64(cmd.ExecuteScalar());
                if (id > 0)
                {
                    if (NotificarModificacionEnInventario != null)
                    {
                        NotificarModificacionEnInventario(this, EventArgs.Empty);
                    }

                }

            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

        }
        public void EliminarInventario()
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            SqlConnection conn = dbContext.ConnectionServer();
            string deletedateSql = " delete from d.id_donacion=@id_donaciones,rd.id_recurso_donacion=@idrecursos,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlCommand cmd = new SqlCommand(deletedateSql, conn);
            try
            {
                int affected = 0;
                conn.Open();
                affected = cmd.ExecuteNonQuery();
                if (NotificarModificacionEnInventario != null)
                {
                    NotificarModificacionEnInventario(this, EventArgs.Empty);

                }
            }
            finally
            {
                cmd.Dispose();
                conn.Close();

            }

        }

    }

}
