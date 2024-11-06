using System.Collections.Generic;

namespace SysAcopio.Models
{
    public class Rol
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Rol(){}
        /// <summary>
        /// Constrcutor con parametros
        /// </summary>
        /// <param name="idRol"></param>
        /// <param name="nombreRol"></param>
        public Rol(long idRol, string nombreRol)
        {
            IdRol = idRol;
            NombreRol = nombreRol;
        }

        public long IdRol { get; set; }
        public string NombreRol { get; set; }
    }
}