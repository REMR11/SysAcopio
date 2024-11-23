using Org.BouncyCastle.Pqc.Crypto.Hqc;
using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
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
        private readonly SysAcopioDbContext _dbContext;
        private readonly Recurso _recurso;
        private readonly Alerts _alerts;
        private readonly List<Recurso> _recursoList;
        public InventarioController(Recurso recurso, Alerts alerts, List<Recurso> recursoList)
        {
            this._recurso = recurso;
            this._alerts = alerts;
            this._recursoList = recursoList;
        }
       
        
            public static DataTable Getinventario(string query, SqlParameter[] parametros, SysAcopioDbContext dbContext)
        {

            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("La consulta no puede estar vacía.", nameof(query));
            }

            DataTable recurso = new DataTable();

            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                conn.Open(); // Asegúrate de abrir la conexión

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parametros != null)
                    {
                        foreach (SqlParameter parametro in parametros)
                        {
                            cmd.Parameters.Add(parametro); // Agrega cada parámetro individualmente
                        }
                    }

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            recurso.Load(reader); // Carga los datos del lector en el DataTable
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de errores: puedes registrar el error o lanzar una excepción personalizada
                        throw new Exception("Error al ejecutar la consulta.", ex);
                    }
                }
            }

            return recurso; // La conexión se cierra automáticamente aquí


    }
       
    } 
            



   
}
