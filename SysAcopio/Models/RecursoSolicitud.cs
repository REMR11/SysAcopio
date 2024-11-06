namespace SysAcopio.Models
{
    public partial class RecursoSolicitud
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public RecursoSolicitud(){}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idRecursoSolicitud"></param>
        /// <param name="idRecurso"></param>
        /// <param name="idSolicitud"></param>
        /// <param name="cantidad"></param>
        public RecursoSolicitud(long idRecursoSolicitud, long idRecurso, long idSolicitud, int cantidad)
        {
            IdRecursoSolicitud = idRecursoSolicitud;
            IdRecurso = idRecurso;
            IdSolicitud = idSolicitud;
            Cantidad = cantidad;
        }

        public long IdRecursoSolicitud { get; set; }
        public long IdRecurso { get; set; }
        public long IdSolicitud { get; set; }
        public int Cantidad { get; set; }
    }
}