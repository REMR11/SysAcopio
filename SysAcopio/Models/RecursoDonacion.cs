namespace SysAcopio.Models
{
    public partial class RecursoDonacion
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public RecursoDonacion() { }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idRecursoDonacion"></param>
        /// <param name="idDonacion"></param>
        /// <param name="idRecurso"></param>
        /// <param name="cantidad"></param>
        public RecursoDonacion(long idRecursoDonacion, long idDonacion, long idRecurso, int cantidad)
        {
            IdRecursoDonacion = idRecursoDonacion;
            IdDonacion = idDonacion;
            IdRecurso = idRecurso;
            Cantidad = cantidad;
        }

        public long IdRecursoDonacion { get; set; }
        public long IdDonacion { get; set; }
        public long IdRecurso { get; set; }
        public int Cantidad { get; set; }
    }
}