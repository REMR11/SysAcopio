using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class TipoRecurso
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public TipoRecurso(){}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idTipoRecurso"></param>
        /// <param name="nombreTipo"></param>
        /// <param name="recursos"></param>
        public TipoRecurso(long idTipoRecurso, string nombreTipo, ICollection<Recurso> recursos)
        {
            IdTipoRecurso = idTipoRecurso;
            NombreTipo = nombreTipo;
            Recursos = recursos;
        }

        public long IdTipoRecurso { get; set; }
        public string NombreTipo { get; set; }
        public virtual ICollection<Recurso> Recursos { get; } = new List<Recurso>();
    }
}