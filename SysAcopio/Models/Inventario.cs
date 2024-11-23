using SysAcopio.Controllers;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace SysAcopio.Models
{
    public partial class Inventario
    {
        internal readonly int IdRecurso;
       

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

        public bool IsDelete { get; internal set; }

       

        }
    
   


}
