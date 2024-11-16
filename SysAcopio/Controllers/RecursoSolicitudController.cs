using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    public class RecursoSolicitudController
    {
        private readonly RecursoSolicitudRepository repoRecurso;

        public RecursoSolicitudController()
        {
            this.repoRecurso = new RecursoSolicitudRepository();
        }

        public DataTable GetAllRecurso()
        {
            return repoRecurso.GetAllRecursos();
        }

        public DataTable GetAllTipoRecurso() {
            return repoRecurso.GetAllTipoRecurso();
        }

        public DataRow[] FiltrarDatosRecursosGrid(DataTable recursos, string idTipo, string nombre)
        {
            if (recursos == null) throw new ArgumentNullException(nameof(recursos), "El DataTable no puede ser nulo.");

            var filtros = new List<string>();

            // Filtrar por id_tipo_recurso
            AgregarFiltroPorIdTipo(idTipo, filtros);

            // Filtrar por nombre
            AgregarFiltroPorNombre(nombre, filtros);

            // Construir la cadena de filtro final
            string filtroFinal = ConstruirFiltroFinal(filtros);

            // Filtrar el DataTable
            return recursos.Select(filtroFinal);
        }

        private void AgregarFiltroPorIdTipo(string idTipo, List<string> filtros)
        {
            if (!string.IsNullOrWhiteSpace(idTipo) && idTipo != "0" && long.TryParse(idTipo, out long id))
            {
                filtros.Add($"id_tipo_recurso = {id}");
            }
            else if (!string.IsNullOrWhiteSpace(idTipo))
            {
                throw new ArgumentException("El idTipo no es un número válido.", nameof(idTipo));
            }
        }

        private void AgregarFiltroPorNombre(string nombre, List<string> filtros)
        {
            if (!string.IsNullOrWhiteSpace(nombre)) filtros.Add($"NombreRecurso LIKE '%{nombre}%'");
        }

        private string ConstruirFiltroFinal(List<string> filtros)
        {
            return filtros.Count > 0 ? string.Join(" AND ", filtros) : string.Empty;
        }
    }
}
