using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    public class Sesion
    {
        public static string NombreUsuario { get; set; }
        public static string RolUsuario { get; set; }
       
        // Método para guardar la información del usuario
        public static void GuardarDatosUsuario(string nombreUsuario, string rolUsuario)
        {
            NombreUsuario = nombreUsuario;
            RolUsuario = rolUsuario;
        }
        // Método para limpiar los datos del usuario
        public static void LimpiarDatosUsuario()
        {
            NombreUsuario = string.Empty;
            RolUsuario = string.Empty;
        }
        //Metodo para asignar permios a los usarios 
        public static void Permisos(Form1 form)
        {
            // si el rol del usuario es 1 permisos de admin
            if (RolUsuario == "1")
            {
                form.BtnUsuario.Enabled = true;
                form.BtnInventario.Enabled = true;
                form.BtnReporte.Enabled = true;
                form.BtnSolicitus.Enabled = true;
                form.BtnDonacion.Enabled = true;
                form.Button1.Enabled = true;
            } // si el rol del usuario es 2 permisos de operador 
            else if (RolUsuario == "2")
            {
                form.BtnUsuario.Enabled = false;
                form.BtnInventario.Enabled = false;
                form.BtnReporte.Enabled = false;
                form.BtnSolicitus.Enabled = true;
                form.BtnDonacion.Enabled = true;
                form.Button1.Enabled = false;
            }
        }


    }
}
