using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Org.BouncyCastle.Asn1.BC;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using MySqlX.XDevAPI;
using System.Data.Common;

namespace SysAcopio.Repositories
{

    public class InventarioRepository
    {
       

        public long IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public string Cantidad { get; set; }
        public string IdTipoRecurso { get; set; }


        //metodo para obtener los registros
        public DataTable GetInventario()
        {

            DataTable mydt = new DataTable();
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            using (SqlConnection conn = conectar.ConnectionServer())
            {
                string sql = "SELECT idrecursos, nombre_recursos, cantidad, tipo_recursos FROM Recurso"; // Corregido
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        // Abrir la conexión
                        conn.Open();

                        // Ejecución de la consulta y lectura de la tabla
                        using (SqlDataReader mydr = cmd.ExecuteReader())
                        {
                            // Agregar la lectura a la tabla
                            mydt.Load(mydr);
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de la excepción (puedes registrar el error o mostrar un mensaje)
                       MessageBox.Show("Error en la consulta: " + ex.Message);
                    }
                    // La conexión se cierra automáticamente al salir del bloque using
                }
            }
            return mydt;
        }
    

    public long AgregarInventario()
        {
            long id = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string insertsql = "INSERT INTO Recurso(id_recursos,nombre_recursos,cantidad,tipo_recursos)  VALUES (@id_recursos,@nombre_recursos,@cantidad,@tipo_recursos";
            SqlCommand cmd = new SqlCommand(insertsql, conn);
            cmd.Parameters.AddWithValue("@id_recursos", this.IdRecurso);
            cmd.Parameters.AddWithValue("@nombre_recurso", this.NombreRecurso);
            cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
            cmd.Parameters.AddWithValue("@tipo_recurso", this.IdTipoRecurso);
            try
            {
                //abrir la conexion
                conn.Open();
                //capturar los datos
                id = Convert.ToInt64(cmd.ExecuteScalar());
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return id;

        }


        public int EditarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string updatesql = "UPDATE Recurso(nombre_recursos=@nombre_recursos,cantidad=@cantidad,tipo_recursos=@tipo_recursos) WHERE  id_recursos=@id_recursos;";
            SqlCommand cmd = new SqlCommand(updatesql, conn);
            cmd.Parameters.AddWithValue("@id_recursos", this.IdRecurso);
            cmd.Parameters.AddWithValue("@nombre_recurso", this.NombreRecurso);
            cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
            cmd.Parameters.AddWithValue("@tipo_recurso", this.IdTipoRecurso);

            try
            {
                //abrir la conexion
                conn.Open();
                //capturar los datos
                affected = cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return affected;

        }

        public int EliminarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string updatesql = "UPDATE Recurso SET IsDeleted  WHERE id_recursos = @id_recursos";
            SqlCommand cmd = new SqlCommand(updatesql, conn);
            cmd.Parameters.AddWithValue("@id_recursos", SqlDbType.BigInt).Value = this.IdRecurso;
            try
            {
                conn.Open();
                affected = cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return affected;
        }
        public void EliminarInventarioLogico(List<Inventario> inventario, int id)
        {
            foreach (var item in inventario)
            {
                if (item.IdRecurso == id)
                { item.IsDelete = true; }

            }


        }



    }

       
    
  
}
