using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{

    public class InventarioController
    { public readonly SysAcopioDbContext dbContext;
        public InventarioController()
        {
            dbContext = new SysAcopioDbContext();
        }

        private readonly Recurso recurso;
        private readonly Alerts alerts;
        //metodos para validar la informacion
        public List<Recurso> recursoList;

        public InventarioController(Recurso recurso, Alerts alerts, List<Recurso> recursoList)
        {
            this.recurso = recurso;
            this.alerts = alerts;
            this.recursoList = recursoList;
        }
       
        
            public static DataTable Getinventario(string query, SqlParameter[] parametros, SysAcopioDbContext dbContext)
        {
            DataTable recurso = new DataTable();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                conn.Open(); // Asegúrate de abrir la conexión
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parametros != null)
                    {
                        foreach (SqlParameter param in parametros)
                        {
                            cmd.Parameters.Add(param); // Agrega cada parámetro individualmente
                        }
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        recurso.Load(reader); // Carga los datos del lector en el DataTable
                    }
                }
            }
            return recurso; // La conexión se cierra automáticamente aquí
        
    }
       
    } 
            



   
}
