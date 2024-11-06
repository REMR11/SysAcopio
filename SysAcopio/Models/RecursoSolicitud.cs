namespace SysAcopio.Models
{
    public partial class RecursoSolicitud
    {
        public long IdRecursoSolicitud { get; set; }
        public long IdRecurso { get; set; }
        public long IdSolicitud { get; set; }
        public int Cantidad { get; set; }
    }
}