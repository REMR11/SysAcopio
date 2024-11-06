using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class Proveedor
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Proveedor(){}
        /// <summary>
        /// Constructor con parametos
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <param name="nombreProveedor"></param>
        /// <param name="estado"></param>
        public Proveedor(long idProveedor, string nombreProveedor, bool estado)
        {
            NombreProveedor = nombreProveedor;
            Estado = estado;
        }

        public long IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public bool Estado { get; set; }
    }
}