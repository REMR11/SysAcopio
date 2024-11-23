using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class Recurso
    {
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Recurso(){}
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idRecurso"></param>
        /// <param name="nombreRecurso"></param>
        /// <param name="cantidad"></param>
        /// <param name="idTipoRecurso"></param>
        public Recurso(long idRecurso, string nombreRecurso, int cantidad, long idTipoRecurso)
        {
            IdRecurso = idRecurso;
            NombreRecurso = nombreRecurso;
            Cantidad = cantidad;
            IdTipoRecurso = idTipoRecurso;
        }

        public long IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public int Cantidad { get; set; }
        public long IdTipoRecurso { get; set; }
        
    }
}