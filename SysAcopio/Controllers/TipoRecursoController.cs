using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    internal class TipoRecursoController
    {
        //Atributos
        private readonly TipoRecursoRepository repository;

        public TipoRecursoController()
        {
            repository = new TipoRecursoRepository();
        }

        /// <summary>
        /// Método para obtener todos los registros
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Método para crear un TipRecurso
        /// </summary>
        /// <param name="tiporecurso"></param>
        public bool Create(TipoRecurso tipoRecurso)
        {
            long id = repository.Create(tipoRecurso);

            if (id > 0)
            {
                Alerts.ShowAlertS("Tipo de recurso creado", AlertsType.Confirm);
                return true;
            }
            else
            {
                Alerts.ShowAlertS("Lo sentimos, debido a un errror no se pudo crear el tipo de recurso", AlertsType.Error);
            }
            return false;
        }

        /// <summary>
        /// Método para actualizar un TipoRecurso
        /// </summary>
        /// <param name="tiporecurso"></param>
        /// <returns>Un booleano que confirma la modificación</returns>
        public bool Modify(TipoRecurso tipoRecurso)
        {
            TipoRecurso tipoRecursoFinded = repository.GetById(tipoRecurso.IdTipoRecurso);

            if (tipoRecursoFinded == null)
            {
                Alerts.ShowAlertS("Tipo de recurso no encontrado", AlertsType.Info);
                return false;
            }
            bool result = repository.Update(tipoRecurso);

            if (result)
            {
                Alerts.ShowAlertS("Tipo de recurso modificado", AlertsType.Confirm);
            }
            else
            {
                Alerts.ShowAlertS("Lo sentimos, debido a un errror no se pudo modificar el tipo de recurso", AlertsType.Error);
            }

            return result;
        }

        /// <summary>
        /// Método para buscar los tipos de recurso basado en una string de busqueda
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public DataTable Search(string searchQuery)
        {
            return repository.SearchTiposRecurso(searchQuery);
        }
    }
}
