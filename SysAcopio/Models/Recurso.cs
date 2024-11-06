using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class Recurso
    {
        public long IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public int Cantidad { get; set; }
        public long IdTipoRecurso { get; set; }
        public virtual ICollection<RecursoDonacion> RecursoDonaciones { get; } = new List<RecursoDonacion>();
        public virtual ICollection<RecursoSolicitud> RecursoSolicitudes { get; } = new List<RecursoSolicitud>();
    }
}