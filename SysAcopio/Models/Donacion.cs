using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Models
{
    public partial class Donacion
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Donacion() {}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idDonacion"></param>
        /// <param name="idProveedor"></param>
        /// <param name="ubicacion"></param>
        /// <param name="fecha"></param>
        public Donacion(long idDonacion, long idProveedor, string ubicacion, DateTime fecha)
        {
            IdDonacion = idDonacion;
            IdProveedor = idProveedor;
            Ubicacion = ubicacion;
            Fecha = fecha;
        }

        public long IdDonacion { get; set; }

        public long IdProveedor { get; set; }

        public string Ubicacion { get; set; }

        public DateTime Fecha { get; set; }
    }
}
