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
    {//atributos privados que almacenan los datos del inventario
        private long idproveedores;//ID proveedores
        private string nombres;//Nombre del provedor
        private string recursos;//recursos asociados
        private string categoria;//estado para el inventario
        private string estado;//estado del recurso
        private string ubicacion;//ubicacion del recurso
        private string fecha;//fecha de donacion
        //metodo para tener los datos del inventario
       
        
        public DataTable GetInventario()
        {
            //consulta al sql para tener los registros
            string query = "SELECT id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha FROM Proveedor,Donacion,Solicitud WHERE estado = 1;";

            SqlParameter[] parameters = null;

            return GenericFuncDB.GetRowsToTable(query, parameters);//llam para ejecutar la consutaar a una funcion
        }
        //propiedades para acceder y modificar los productos
        public string Nombres { get { return nombres; } set { nombres = value; } }
        public string Recursos { get { return recursos; } set { recursos = value; } }
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public string Ubicacion { get { return ubicacion; } set { ubicacion = value; } }
        public string Fecha { get { return fecha; } set { fecha = value; } }
        public string Estado {  get { return estado; } set { estado = value; } }
        public long IdRecursos { get { return IdRecursos; } set { IdRecursos = value; } }
        public long AgregarInventario()//metodo para agregar un nuevo registrode inevntario
        {  //variable para almacenar el Id
            long id = 0;
            //crear la conexion de de la base de datos
            SysAcopioDbContext conectar=new SysAcopioDbContext();
            SqlConnection conn = conectar.ConnectionServer();
            //para insertar un nuevo registro
            string insertsql = "insert into Inventario (id_proveedor,nombre_proveedor,r.nombre_recurso,categoria,estado,d.ubicacion, d.fecha) values(@id_proveedor,@nombre_proveedor,@r.nombre_recurso,@categoria,@estado,@d.ubicacion, @d.fecha) FROM Proveedor,Donacion,Solicitud WHERE estado = 1";
            SqlCommand cmd = new SqlCommand(insertsql, conn);
            cmd.Parameters.AddWithValue("@id_proveedor",this.idproveedores);
            cmd.Parameters.AddWithValue("@nombre", this.nombres);
            cmd.Parameters.AddWithValue("@recursos",this.recursos);
            cmd.Parameters.AddWithValue("@categoria", this.categoria);
            cmd.Parameters.AddWithValue("@estado", this.estado);
            cmd.Parameters.AddWithValue("@ubicacion",this.ubicacion);//agregar los valores de los parametros
            cmd.Parameters.AddWithValue("@fecha",this.fecha);
            try
            {
                //abrir la conexion
                conn.Open();
                id=Convert.ToInt64(cmd.ExecuteScalar());
               
            }
            finally
            {   //liberar espacion
                cmd.Dispose();
                conn.Close();
            } //devuelve el id
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
