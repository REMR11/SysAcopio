using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

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
            DataTable mydt= new DataTable();
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string sql = "Select * idrecursos,nombre_recursos,cantidad,tipo_recursos From Recurso";
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader mydr = null;
            try
            {
                //abrir la conexion
                conn.Open();
                //ejecucion de la consulta y lectura de la tabla
                mydr = cmd.ExecuteReader();
                //agregado la lectura
                mydt.Load(mydr);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return mydt;
        }

        public long AgregarInventario()
        {
            long id = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string insertsql = "insert into Recurso(id_recursos,nombre_recursos,cantidad,tipo_recursos)  Values (@id_recursos,@nombre_recursos,@cantidad,@tipo_recursos";
            SqlCommand cmd = new SqlCommand(insertsql, conn);
           cmd.Parameters.AddWithValue("@id_recursos",this.IdRecurso);
            cmd.Parameters.AddWithValue("@nombre_recurso",this.NombreRecurso);
            cmd.Parameters.AddWithValue("@cantidad", this.Cantidad);
            cmd.Parameters.AddWithValue("@tipo_recurso",this.IdTipoRecurso);
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
            string updatesql = "update Recurso(nombre_recursos=@nombre_recursos,cantidad=@cantidad,tipo_recursos=@tipo_recursos) WHERE  id_recursos=@id_recursos;";
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
            string deletesql = " delete from Recurso where(id_recursos=@id_recursos;";
            SqlCommand cmd = new SqlCommand(deletesql, conn);
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

    }
  
}
