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
    }
}
