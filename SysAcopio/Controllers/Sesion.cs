using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    public class Sesion
    {
        //Propiedades
        public static string NombreUsuario { get; set; }
        public static string RolUsuario { get; set; }
        public static bool isAdmin { get; set; }

        // Método para guardar la información del usuario
        public static void GuardarDatosUsuario(string nombreUsuario, string rolUsuario, long idRol)
        {
            NombreUsuario = nombreUsuario;
            RolUsuario = rolUsuario;

            isAdmin = (idRol == 1);
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
            // si el rol no es el de un admin se ocultan los usuarios
            if (!isAdmin)
            {
                form.BtnUsuario.Visible = false;
            }

        }


    }
}
