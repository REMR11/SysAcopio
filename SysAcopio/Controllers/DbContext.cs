using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    public class DbContext
    {
        private readonly string connectionStringDeRL;

        public DbContext()
        {
            // Accede a la cadena de conexión desde el archivo de configuración
            connectionStringDeRL = ConfigurationManager.ConnectionStrings["ConnectionStringDeRL"].ConnectionString;
        }

        public SqlConnection ConnectionServer()
        {
            SqlConnection conn = null;

            try
            {
                // Inicializa la conexión con la cadena de conexión
                conn = new SqlConnection(connectionStringDeRL);
                conn.Open(); // Abre la conexión
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes registrar el error o lanzarlo)
                Console.WriteLine($"Error al conectar: {ex.Message}");
            }

            return conn;
        }
    }
}
