using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Models
{
    public partial class Usuario
    {
        public long IdUsuario { get; set; }
        public string AliasUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public long IdRol { get; set; }
        public bool Estado { get; set; }
    }
}
