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
       // internal readonly int IdRecurso;


        ///<summary>
        ///</summary>
        ///<param name="idRecurso"></param>
        ///<param name="nombreRecurso"></param>
        ///<param name="cantidad"></param>
        ///<param name="idTipoRecurso"></param>


        public long IdRecurso { get; set; }
        public string NombreRecurso { get; set; }
        public int Cantidad { get; set; }
        public long IdTipoRecurso { get; set; }

        public Inventario()
        {

        }
        public Inventario(long idRecurso, string nombreRecurso, int cantidad, int idTipoRecurso)
        {
            idRecurso= idRecurso;
            nombreRecurso= nombreRecurso;
            cantidad= cantidad;
            idTipoRecurso= idTipoRecurso;

            
        }

        public bool IsDelete { get; internal set; }

       

        }
    
   


}
