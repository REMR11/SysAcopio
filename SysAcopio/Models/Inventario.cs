using System.Collections.Generic;

namespace SysAcopio.Models
{
    public partial class Inventario
    {
        ///<summary>
        ///</summary>
        ///<param name="idRecurso"></param>
        ///<param name="nombreRecurso"></param>
        ///<param name="cantidad"></param>
        ///<param name="idTipoRecurso"></param>
        


        
        public Inventario()
        {

        }
        public Inventario(long idRecurso, string nombreRecurso, string cantidad, string idTipoRecurso)
        {
            idRecurso= idRecurso;
            nombreRecurso= nombreRecurso;
            cantidad= cantidad;
            idTipoRecurso= idTipoRecurso;

            
        }

        


    }
  


}
