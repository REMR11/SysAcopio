using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    internal class UsuarioController
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para crear un nuevo usuario.
        /// </summary>
        /// <param name="usuario">Objeto usuario que contiene los detalles del nuevo usuario.</param>
        /// <returns>El ID del usuario creado o -1 en caso de error.</returns>
        public long CrearUsuario(Usuario usuario)
        {
            return usuarioRepository.Create(usuario);
        }

        /// <summary>
        /// Método para obtener todos los usuarios activos.
        /// </summary>
        /// <returns>Lista de usuarios con roles asignados.</returns>
        public List<Usuario> ObtenerUsuarios()
        {
            // Llama a GetAll() que ya incluye el rol en cada usuario
            return usuarioRepository.GetAll().ToList();
        }

        /// <summary>
        /// Método para obtener un usuario específico por su ID.
        /// </summary>
        /// <param name="id">ID del usuario a buscar.</param>
        /// <returns>Objeto usuario con rol asignado, o null si no se encuentra.</returns>
        public Usuario ObtenerUsuarioPorId(long id)
        {
            return usuarioRepository.GetById(id);
        }

        /// <summary>
        /// Método para actualizar la información de un usuario.
        /// </summary>
        /// <param name="usuario">Objeto usuario con los datos actualizados.</param>
        /// <returns>True si se actualizó exitosamente; de lo contrario, false.</returns>
        public bool ActualizarUsuario(Usuario usuario)
        {
            return usuarioRepository.Update(usuario);
        }

        /// <summary>
        /// Método para desactivar un usuario de manera lógica.
        /// </summary>
        /// <param name="id">ID del usuario a desactivar.</param>
        /// <returns>True si se desactivó exitosamente; de lo contrario, false.</returns>
        public bool DesactivarUsuario(long id)
        {
            return usuarioRepository.DeleteLogic(id);
        }

        
        public List<Usuario> BuscarUsuarios(string searchTerm)
        {
            return usuarioRepository.Search(searchTerm).ToList();
        }


        public DataTable ObtenerUsuariosDataTable()
        {
            return usuarioRepository.ObtenerUsuariosDataTable();
        }
        


    }
}
