using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Models
{
    public partial class Usuario
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Usuario(){}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="aliasUsuario"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="idRol"></param>
        /// <param name="estado"></param>

        // Propiedad de navegación para el rol
        public Rol Rol { get; set; }
        public Usuario(long idUsuario, string aliasUsuario, string nombreUsuario, string contrasenia, long idRol, bool estado)
        {
            IdUsuario = idUsuario;
            AliasUsuario = aliasUsuario;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            IdRol = idRol;
            Estado = estado;
        }

        public long IdUsuario { get; set; }
        public string AliasUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public long IdRol { get; set; }
        public bool Estado { get; set; }
    }
}
