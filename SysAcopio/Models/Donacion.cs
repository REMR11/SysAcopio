using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Models
{
    public partial class Donacion
    {
        public long IdDonacion { get; set; }

        public long IdProveedor { get; set; }

        public string Ubicacion { get; set; }

        public DateTime Fecha { get; set; }
    }
}
