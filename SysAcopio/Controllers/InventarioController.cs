using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace SysAcopio.Controllers
{
    internal class InventarioController
    {
        public event EventHandler NotificarModificacionEnInventario;
        private readonly InventarioRepository inventariorepository;
        private readonly Alerts alerts;

        public List<RecursoDonacion> recursodonaciones { get; set; }
        public List<Solicitud> solicituds { get; set; }
        public List<Donacion> donaciones { get; set; }


        public InventarioController()
        {
            recursodonaciones = new List<RecursoDonacion>();
            solicituds = new List<Solicitud>();
            donaciones = new List<Donacion>();
            alerts = new Alerts();
        }
       public void EditarInventario()
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            SqlConnection conn = dbContext.ConnectionServer();
            string updateSql = " d.id_donacion=@id_donaciones,rd.id_recurso_donacion=@idrecursos,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlCommand cmd= new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@id_donaciones",this.donaciones);
            cmd.Parameters.AddWithValue("@id_provedores", this.solicituds);
            cmd.Parameters.AddWithValue("", this.recursodonaciones);

            try
            {
                int affect = 0;
                conn.Open();
                affect = cmd.ExecuteNonQuery();
                if (affect > 0)
                {
                    if (NotificarModificacionEnInventario  != null)
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
            string updateSql = " d.id_donacion=@id_donaciones,rd.id_recurso_donacion=@idrecursos,r.nombre_recurso, rd.id_recurso, rd.cantidad ";
            SqlCommand cmd = new SqlCommand(updateSql, conn);
            cmd.Parameters.AddWithValue("@id_donaciones", this.donaciones);
            cmd.Parameters.AddWithValue("@id_provedores", this.solicituds);
            cmd.Parameters.AddWithValue("", this.recursodonaciones);

            try
            {
                long id = 0;
                conn.Open();
                Convert.ToInt64(cmd.ExecuteScalar());
                if(id > 0)
                {
                    if(NotificarModificacionEnInventario != null)
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




    }
  
}
