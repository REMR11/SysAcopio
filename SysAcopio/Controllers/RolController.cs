using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SysAcopio.Controllers
{
    internal class RolController
    {
        private readonly RolRepository rolRepository;

        public RolController()
        {
            rolRepository = new RolRepository(); // Inicializar RolRepository
        }

        /// <summary>
        /// Crear un nuevo rol.
        /// </summary>
        /// <param name="rol">Objeto Rol a crear.</param>
        /// <returns>ID del nuevo rol creado.</returns>
        public long Create(Rol rol)
        {
            try
            {
                return rolRepository.Create(rol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el rol: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Obtener todos los roles.
        /// </summary>
        /// <returns>Lista de roles.</returns>
        public IEnumerable<Rol> GetAll()
        {
            try
            {
                return rolRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los roles: {ex.Message}");
                return new List<Rol>();
            }
        }

        /// <summary>
        /// Obtener un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol a obtener.</param>
        /// <returns>Objeto Rol con el ID especificado.</returns>
        public Rol GetById(long id)
        {
            try
            {
                return rolRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el rol con ID {id}: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Actualizar los detalles de un rol.
        /// </summary>
        /// <param name="rol">Objeto Rol con los nuevos valores.</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
        public bool Update(Rol rol)
        {
            try
            {
                return rolRepository.Update(rol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el rol: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Eliminar un rol por su ID.
        /// </summary>
        /// <param name="id">ID del rol a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario.</returns>
        public bool Delete(long id)
        {
            try
            {
                return rolRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}
