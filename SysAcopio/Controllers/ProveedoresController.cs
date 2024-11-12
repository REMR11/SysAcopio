using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System.Data;

namespace SysAcopio.Controllers
{
    internal class ProveedoresController
    {
        private readonly ProveedorRepository repository;
        private readonly Alerts alerts;

        /// <summary>
        /// Constructor de la clase de Proveedores controller
        /// </summary>
        public ProveedoresController()
        {
            repository = new ProveedorRepository();
            alerts = new Alerts();
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
        /// Método para crear un Proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        public bool Create(Proveedor proveedor)
        {
            long id = repository.Create(proveedor);

            if (id > 0)
            {
                alerts.ShowAlert("Proveedor creado", AlertsType.Confirm);
                return true;
            }
            else
            {
                alerts.ShowAlert("Lo sentimos, debido a un errror no se pudo crear el proveedor", AlertsType.Error);
            }
            return false;
        }

        /// <summary>
        /// Método para actualizar un Proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns>Un booleano que confirma la modificación</returns>
        public bool Modify(Proveedor proveedor)
        {
            Proveedor proveedorFinded = repository.GetById(proveedor.IdProveedor);

            if (proveedorFinded == null)
            {
                alerts.ShowAlert("Proveedor no encontrado", AlertsType.Info);
                return false;
            }
            bool result = repository.Update(proveedor);

            if (result)
            {
                alerts.ShowAlert("Proveedor modificado", AlertsType.Confirm);
            }
            else
            {
                alerts.ShowAlert("Lo sentimos, debido a un errror no se pudo modificar el proveedor", AlertsType.Error);
            }

            return result;
        }

        /// <summary>
        /// Método para eliminar un Proveedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booleano que confirma la eliminación</returns>
        public bool Delete(long id)
        {
            int result = repository.DeleteLogic(id);

            if (result == -1)
            {
                alerts.ShowAlert("Proveedor inexistente", AlertsType.Info);
                return false;
            }
            else if (result == 0)
            {
                alerts.ShowAlert("Ocurrio un error y no se pudo borrar el registro", AlertsType.Error);
                return false;
            }
            else
            {
                alerts.ShowAlert("Proveedor borrado con exito, aun existarán los registros que se registraron con este proveedor, se recomienda que se actualicen", AlertsType.Confirm);
                return true;
            }
        }

        public DataTable Search(string searchQuery)
        {
            return repository.SearchProveedores(searchQuery);
        }
    }
}
