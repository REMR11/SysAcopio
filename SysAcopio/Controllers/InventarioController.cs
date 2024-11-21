using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    internal class InventarioController
    {
        //Atributos
        private readonly InventarioRepository repository;
        //Delegado para cumplir especificaciones
        public delegate void ResourceChangedEventHandler(string mensaje, AlertsType alertsType);

        // Evento que se disparará cuando un recurso sea creado, modificado o eliminado
        public event ResourceChangedEventHandler ResourceChanged;
        //Constructor de clase
        public InventarioController()
        {
            repository = new InventarioRepository();
        }

        /// <summary>
        /// Método que obtiene todo el inventario
        /// </summary>
        /// <returns></returns>
        public DataTable GetInventario()
        {
            return repository.GetInventario();
        }

        /// <summary>
        /// Método par disparar el evento
        /// </summary>
        /// <param name="message"></param>
        protected virtual void OnResourceChanged(string message, AlertsType tipo)
        {
            ResourceChanged?.Invoke(message, tipo);
        }

        /// <summary>
        /// Método para crear un Recurso
        /// </summary>
        /// <param name="recurso"></param>
        public bool Create(Recurso recurso)
        {
            if (repository.ExistByName(recurso.NombreRecurso))
            {
                Alerts.ShowAlertS("Lo sentimos, ya existe un recurso con ese nombre", AlertsType.Info);
                return false;
            }

            long id = repository.Create(recurso);

            if (id > 0)
            {
                OnResourceChanged("Recurso añadido al inventario", AlertsType.Confirm);
                return true;
            }
            else
            {
                Alerts.ShowAlertS("Lo sentimos, debido a un error no se pudo crear el Recurso", AlertsType.Error);
            }
            return false;
        }

        /// <summary>
        /// Método para actualizar un Recurso
        /// </summary>
        /// <param name="recurso"></param>
        /// <returns>Un booleano que confirma la modificación</returns>
        public bool Modify(Recurso recurso)
        {
            Recurso recursoFinded = repository.GetById(recurso.IdRecurso);

            if (recursoFinded == null)
            {
                Alerts.ShowAlertS("Recurso no encontrado", AlertsType.Info);
                return false;
            }
            bool result = repository.Update(recurso);

            if (result)
            {
                OnResourceChanged("Recurso modificado", AlertsType.Confirm);
            }
            else
            {
                Alerts.ShowAlertS("Lo sentimos, debido a un errror no se pudo modificar el recurso", AlertsType.Error);
            }

            return result;
        }

        /// <summary>
        /// Método para eliminar un Recurso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booleano que confirma la eliminación</returns>
        public bool Delete(long id)
        {
            int result = repository.DeleteLogic(id);

            if (result == -1)
            {
                Alerts.ShowAlertS("Recurso inexistente", AlertsType.Info);
                return false;
            }
            else if (result == 0)
            {
                Alerts.ShowAlertS("Ocurrio un error y no se pudo borrar el registro", AlertsType.Error);
                return false;
            }
            else
            {
                OnResourceChanged("Recurso borrado con exito, aun existarán los registros que se registraron con este recurso, se recomienda que se actualicen", AlertsType.Confirm);
                return true;
            }
        }

        /// <summary>
        /// Método para buscar los proveedores basado en una string de busqueda
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public DataTable Search(string searchQuery, int estadoFiltro, int idTipo)
        {
            return repository.SearchRecursos(searchQuery, estadoFiltro, idTipo);
        }
    }
}
