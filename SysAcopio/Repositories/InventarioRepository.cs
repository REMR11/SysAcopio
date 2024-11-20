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
    {//atributos
        private long idproveedores;
        private string nombres;
        private string recursos;
        private string categoria;
        private string estado;
        private string ubicacion;
        private string fecha;
        //metodo para tener una tabla
       
        
        public DataTable GetInventario()
        {

            string query = "SELECT id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha FROM Proveedor,Donacion,Solicitud WHERE estado = 1;";

            SqlParameter[] parameters = null;

            return GenericFuncDB.GetRowsToTable(query, parameters);
        }
        //metodo para crear 
        public string Nombres { get { return nombres; } set { nombres = value; } }
        public string Recursos { get { return recursos; } set { recursos = value; } }
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public string Ubicacion { get { return ubicacion; } set { ubicacion = value; } }
        public string Fecha { get { return fecha; } set { fecha = value; } }
        public string Estado {  get { return estado; } set { estado = value; } }
        public long IdRecursos { get { return IdRecursos; } set { IdRecursos = value; } }
        public long AgregarInventario()
        {
            long id = 0;
            
            SysAcopioDbContext conectar=new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string insertsql = "insert into Inventario (id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha) values(@id_proveedor,@nombre_proveedor,@r.nombre_recurso,@categoria,@estado,@d.ubicacion, @d.fecha) FROM Proveedor,Donacion,Solicitud WHERE estado = 1";
            SqlCommand cmd = new SqlCommand(insertsql, conn);
            cmd.Parameters.AddWithValue("@id_proveedor",this.idproveedores);
            cmd.Parameters.AddWithValue("@nombre", this.nombres);
            cmd.Parameters.AddWithValue("@recursos",this.recursos);
            cmd.Parameters.AddWithValue("@categoria", this.categoria);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@ubicacion",this.ubicacion);
            cmd.Parameters.AddWithValue("@fecha",this.fecha);
            try
            {

                conn.Open();
                id=Convert.ToInt64(cmd.ExecuteScalar());
               
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return id;
            

        }
        //metodo que edite una tabla
        public int EditarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string updatertsql = "update Inventario (id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha) values(@id_proveedor,@nombre_proveedor,@r.nombre_recurso,@categoria,@estado,@d.ubicacion, @d.fecha) FROM Proveedor,Donacion,Solicitud WHERE estado = 1";
            SqlCommand cmd = new SqlCommand(updatertsql, conn);
            cmd.Parameters.AddWithValue("@id_proveedor", this.idproveedores);
            cmd.Parameters.AddWithValue("@nombre", this.nombres);
            cmd.Parameters.AddWithValue("@recursos", this.recursos);
            cmd.Parameters.AddWithValue("@categoria", this.categoria);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@ubicacion", this.ubicacion);
            cmd.Parameters.AddWithValue("@fecha", this.fecha);
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
        public int ElminarInventario()
        {
            int affected = 0;
            SysAcopioDbContext conectar = new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            string deletertsql = "update Inventario (id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha) values(@id_proveedor,@nombre_proveedor,@r.nombre_recurso,@categoria,@estado,@d.ubicacion, @d.fecha) FROM Proveedor,Donacion,Solicitud WHERE estado = 1";
            SqlCommand cmd = new SqlCommand(deletertsql, conn);
            cmd.Parameters.AddWithValue("@id_proveedor", this.idproveedores);
            cmd.Parameters.AddWithValue("@nombre", this.nombres);
            cmd.Parameters.AddWithValue("@recursos", this.recursos);
            cmd.Parameters.AddWithValue("@categoria", this.categoria);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@ubicacion", this.ubicacion);
            cmd.Parameters.AddWithValue("@fecha", this.fecha);

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





    }



}
