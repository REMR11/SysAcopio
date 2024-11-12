using System.Collections.Generic;
using System;

namespace SysAcopio.Models
{
    public partial class Solicitud
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Solicitud(){}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="ubicacion"></param>
        /// <param name="fecha"></param>
        /// <param name="estado"></param>
        /// <param name="isCancel"></param>
        /// <param name="nombreSolicitante"></param>
        /// <param name="urgencia"></param>
        /// <param name="motivo"></param>
        public Solicitud( string ubicacion, string nombreSolicitante, byte urgencia, string motivo)
        {
            this.Ubicacion = ubicacion;
            this.Fecha = DateTime.Now;
            this.Estado = true;
            this.IsCancel = false;
            this.NombreSolicitante = nombreSolicitante;
            this.Urgencia = urgencia;
            this.Motivo = motivo;
        }

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