using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SysAcopio.Repositories
{
    internal class ProveedorRepository
    {
        /// <summary>
        /// Método para obtener la tabla de todos los proveedores activos
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            string query = "SELECT id_proveedor, nombre_proveedor as NombreProveedor, estado FROM Proveedor WHERE estado = 1;";

            SqlParameter[] parameters = null;

            return GenericFuncDB.GetRowsToTable(query, parameters);
        }

        /// <summary>
        /// Método para crear un nuevo proveedor
        /// </summary>
        /// <param name="proveedor">Objeto de la entidad Proveedor</param>
        /// <returns></returns>
        public long Create(Proveedor proveedor)
        {
            string query = "INSERT INTO Proveedor (nombre_proveedor) VALUES (@nombre)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", proveedor.NombreProveedor),
            };

            return GenericFuncDB.InsertRow(query, parametros);
        }

        /// <summary>
        /// Método para Obtener un proveedore en base a su ID
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns>Objeto de clase Proveedor</returns>
        public Proveedor GetById(long id)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_proveedor, nombre_proveedor, estado FROM Proveedor WHERE id_proveedor = @id AND estado = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Proveedor
                            {
                                IdProveedor = reader.GetInt64(0),
                                NombreProveedor = reader.GetString(1),
                                Estado = !reader.IsDBNull(2) && reader.GetBoolean(2), // Manejo de nulos
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar un Proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        /// <param name="id"></param>
        /// <returns>Un valor booleano que confirma si se actualizo o no se actualizo</returns>
        public bool Update(Proveedor proveedor)
        {
            string query = "UPDATE Proveedor SET nombre_proveedor = @nombre, estado = @estado WHERE id_proveedor = @id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@nombre", proveedor.NombreProveedor),
                new SqlParameter("@estado", proveedor.Estado),
                new SqlParameter("@id", proveedor.IdProveedor)
            };

            return GenericFuncDB.AffectRow(query, parametros);
        }

        /// <summary>
        /// Método para buscar proveedores basado en un string de busqueda
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public DataTable SearchProveedores(string searchQuery)
        {
            string query = "SELECT id_proveedor, nombre_proveedor as NombreProveedor, estado FROM Proveedor WHERE estado = 1 AND nombre_proveedor LIKE @searchQuery;";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@searchQuery", "%"+ searchQuery + "%"),
            };

            return GenericFuncDB.GetRowsToTable(query, parametros);
        }

        /// <summary>
        /// Método para borrado logico del proveedor
        /// </summary>
        /// <param name="id">Id del proveedor</param>
        /// <returns>Valor booleano que representa si se elimino o no</returns>
        public int DeleteLogic(long id)
        {
            try
            {
                Proveedor proveedor = GetById(id);
                if (proveedor == null) return -1;

                proveedor.Estado = false;
                return Update(proveedor) ? 1 : 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que valida que exista un recurso por el nombre
        /// </summary>
        /// <param name="nombreRecurso"></param>
        /// <returns></returns>
        public bool ExistByName(string nombreRecurso)
        {
            SysAcopioDbContext dbContext = new SysAcopioDbContext();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = " SELECT nombre_proveedor FROM Proveedor WHERE nombre_proveedor = @nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreRecurso);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
