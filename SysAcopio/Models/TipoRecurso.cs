using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class TipoRecurso
    {
        public long IdTipoRecurso { get; set; }
        public string NombreTipo { get; set; }
        public virtual ICollection<Recurso> Recursos { get; } = new List<Recurso>();
    }
}