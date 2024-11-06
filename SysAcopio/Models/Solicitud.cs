using System.Collections.Generic;
using System;

namespace SysAcopio.Models
{
    public partial class Solicitud
    {
        public long IdSolicitud { get; set; }
        public string Ubicacion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public bool IsCancel { get; set; }
        public string NombreSolicitante { get; set; }
        public byte Urgencia { get; set; }
        public string Motivo { get; set; }
    }
}