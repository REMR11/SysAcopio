using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class Proveedor
    {
        public long IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public bool Estado { get; set; }
    }
}