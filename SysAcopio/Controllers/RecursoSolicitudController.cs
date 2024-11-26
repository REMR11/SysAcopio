using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{
    /// <summary>
    /// Controlador para gestionar las solicitudes de recursos.
    /// Proporciona métodos para interactuar con el repositorio de recursos y manejar la lógica de negocio relacionada con las solicitudes.
    /// </summary>
    public class RecursoSolicitudController
    {
        private readonly RecursoSolicitudRepository _repoRecurso; // Repositorio para acceder a los datos de recursos
        private readonly InventarioController _InventarioController;
        private readonly SolicitudController _solicitudController;
        public List<Recurso> detalleRecursoSolicitud = new List<Recurso>(); // Lista que contiene los detalles de los recursos solicitados
        public List<Recurso> nuevosRecursoSolicitud = new List<Recurso>(); // Lista que contiene los detalles de los recursos solicitados

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RecursoSolicitudController"/>.
        /// </summary>
        public RecursoSolicitudController()
        {
            this._repoRecurso = new RecursoSolicitudRepository(); // Inicializa el repositorio de recursos
            this._InventarioController = new InventarioController();
            this._solicitudController = new SolicitudController();
        }

        /// <summary>
        /// Obtiene todos los recursos disponibles.
        /// </summary>
        /// <returns>DataTable con todos los recursos.</returns>
        public DataTable GetAllRecurso()
        {
            return _repoRecurso.GetAllRecursos(); // Llama al método del repositorio para obtener todos los recursos
        }

        /// <summary>
        /// Obtiene todos los tipos de recursos disponibles.
        /// </summary>
        /// <returns>DataTable con todos los tipos de recursos.</returns>
        public DataTable GetAllTipoRecurso()
        {
            return _repoRecurso.GetAllTipoRecurso(); // Llama al método del repositorio para obtener todos los tipos de recursos
        }

        /// <summary>
        /// Filtra los recursos según el tipo y el nombre proporcionados.
        /// </summary>
        /// <param name="recursos">DataTable con los recursos a filtrar.</param>
        /// <param name="idTipo">ID del tipo de recurso.</param>
        /// <param name="nombre">Nombre del recurso.</param>
        /// <returns>Filas filtradas del DataTable de recursos.</returns>
        public DataRow[] FiltrarDatosRecursosGrid(DataTable recursos, string idTipo, string nombre)
        {
            if (recursos == null) throw new ArgumentNullException(nameof(recursos), "El DataTable no puede ser nulo."); // Verifica que el DataTable no sea nulo

            var filtros = new List<string>(); // Lista para almacenar los filtros

            // Filtrar por id_tipo_recurso
            AgregarFiltroPorIdTipo(idTipo, filtros);

            // Filtrar por nombre
            AgregarFiltroPorNombre(nombre, filtros);

            // Construir la cadena de filtro final
            string filtroFinal = ConstruirFiltroFinal(filtros);

            // Filtrar el DataTable
            return recursos.Select(filtroFinal); // Devuelve las filas que cumplen con el filtro
        }

        /// <summary>
        /// Agrega un recurso al detalle de la solicitud.
        /// Si el recurso ya existe, actualiza la cantidad.
        /// </summary>
        /// <param name="recurso">Recurso a añadir.</param>
        /// <param name="cantidad">Cantidad del recurso a añadir.</param>
        /// <returns>True si se añade o actualiza correctamente, de lo contrario false.</returns>
        public bool AddDetalle(Recurso recurso, int cantidad)
        {
            // Validar que no esté añadido el recurso
            var recursoDonacion = detalleRecursoSolicitud.FirstOrDefault(detalle => detalle.IdRecurso == recurso.IdRecurso);

            if (recursoDonacion == null)
            {
                detalleRecursoSolicitud.Add(new Recurso()
                {
                    IdRecurso = recurso.IdRecurso,
                    Cantidad = cantidad,
                    NombreRecurso = recurso.NombreRecurso,
                });
            }
            else // Ya que no está añadido, actualizamos el recurso
            {
                recursoDonacion.Cantidad += cantidad; // Aumenta la cantidad del recurso existente
            }
            return true; // Retorna true indicando que se añadió o actualizó correctamente
        }

        /// <summary>
        /// Agrega un recurso al detalle de la solicitud.
        /// Si el recurso ya existe, actualiza la cantidad.
        /// </summary>
        /// <param name="recurso">Recurso a añadir.</param>
        /// <param name="cantidad">Cantidad del recurso a añadir.</param>
        /// <returns>True si se añade o actualiza correctamente, de lo contrario false.</returns>
        public bool AddNuevoDetalle(Recurso recurso, int cantidad)
        {
            // Validar que no esté añadido el recurso
            var recursoDonacion = nuevosRecursoSolicitud.FirstOrDefault(detalle => detalle.IdRecurso == recurso.IdRecurso);

            if (recursoDonacion == null)
            {
                nuevosRecursoSolicitud.Add(new Recurso()
                {
                    IdRecurso = recurso.IdRecurso,
                    Cantidad = cantidad,
                    NombreRecurso = recurso.NombreRecurso,
                });
            }
            else // Ya que no está añadido, actualizamos el recurso
            {
                recursoDonacion.Cantidad += cantidad; // Aumenta la cantidad del recurso existente
            }
            return true; // Retorna true indicando que se añadió o actualizó correctamente
        }

        /// <summary>
        /// Actualiza la cantidad de un recurso en la solicitud especificada.
        /// </summary>
        /// <param name="recursoSolicitud">La solicitud de recurso que contiene la información necesaria para la actualización.</param>
        /// <returns>Devuelve true si la cantidad se actualizó correctamente; de lo contrario, false.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="recursoSolicitud"/> es null.</exception>
        public bool ActualizarCantidadRecurso(RecursoSolicitud recursoSolicitud)
        {
            if (recursoSolicitud == null) throw new ArgumentNullException(nameof(recursoSolicitud));

            Solicitud solicitud = _solicitudController.ObtenerSolicitudPorId(recursoSolicitud.IdSolicitud);

            if (EsEstadoSolicitudCompleto(solicitud)) return false;

            Recurso recursoObjetivo = _InventarioController.GetRecurso(recursoSolicitud.IdRecurso);

            if (recursoObjetivo == null) return false; // O manejar el caso donde el recurso no se encuentra

            ActualizarCantidadRecurso(recursoObjetivo, recursoSolicitud.Cantidad);
            return _InventarioController.Modify(recursoObjetivo);
        }

        /// <summary>
        /// Verifica si el estado de la solicitud es completo.
        /// </summary>
        /// <param name="solicitud">La tabla de datos que contiene los detalles de la solicitud.</param>
        /// <returns>Devuelve true si el estado de la solicitud es completo; de lo contrario, false.</returns>
        private bool EsEstadoSolicitudCompleto(Solicitud solicitud)
        {
            return Convert.ToBoolean(solicitud.Estado);
        }

        /// <summary>
        /// Obtiene el recurso objetivo a partir del ID del recurso.
        /// </summary>
        /// <param name="idRecurso">El ID del recurso que se desea obtener.</param>
        /// <returns>Devuelve el recurso correspondiente al ID especificado, o null si no se encuentra.</returns>
        private Recurso ObtenerRecursoObjetivo(long idRecurso)
        {
            return detalleRecursoSolicitud.FirstOrDefault(detalle => detalle.IdRecurso == idRecurso);
        }

        /// <summary>
        /// Actualiza la cantidad de un recurso restando la cantidad especificada.
        /// </summary>
        /// <param name="recurso">El recurso cuya cantidad se va a actualizar.</param>
        /// <param name="cantidad">La cantidad que se va a restar del recurso.</param>
        private void ActualizarCantidadRecurso(Recurso recurso, int cantidad)
        {
            recurso.Cantidad -= cantidad;
        }

        /// <summary>
        /// Obtiene los detalles de la solicitud a partir del ID de la solicitud.
        /// </summary>
        /// <param name="idSolicitud">El ID de la solicitud para la cual se desean obtener los detalles.</param>
        /// <returns>Devuelve un DataTable que contiene los detalles de la solicitud.</returns>
        private DataTable ObtenerDetallesSolicitud(long idSolicitud)
        {
            // Implementa la lógica para obtener los detalles de la solicitud
            return GetDetailSolicitud(idSolicitud);
        }

        /// <summary>
        /// Método para obtener los detalles de una solicitud.
        /// </summary>
        /// <param name="idDonacion">ID de la donación para la cual se obtienen los detalles.</param>
        /// <returns>DataTable con los detalles de la solicitud.</returns>
        public DataTable GetDetailSolicitud(long idSolicitud)
        {
            return _repoRecurso.GetDetailSolicitud(idSolicitud); // Llama al método del repositorio para obtener los detalles de la solicitud
        }

        /// <summary>
        /// Método para crear una nueva solicitud de recurso.
        /// </summary>
        /// <param name="recursoSolicitud">Recurso que se va a solicitar.</param>
        /// <param name="idSolicitud">ID de la solicitud a la que se asociará el recurso.</param>
        /// <returns>El ID de la nueva solicitud creada.</returns>
        public long Create(Recurso recursoSolicitud, long idSolicitud)
        {
            return _repoRecurso.Create(recursoSolicitud, idSolicitud); // Llama al método del repositorio para crear la solicitud
        }

        /// <summary>
        /// Agrega un filtro por ID de tipo de recurso a la lista de filtros.
        /// </summary>
        /// <param name="idTipo">ID del tipo de recurso a filtrar.</param>
        /// <param name="filtros">Lista de filtros a la que se añadirá el nuevo filtro.</param>
        private void AgregarFiltroPorIdTipo(string idTipo, List<string> filtros)
        {
            // Filtrar por id_tipo_recurso
            if (!string.IsNullOrWhiteSpace(idTipo) && idTipo != "0")
            {
                // Asegúrate de que idTipo se convierte a long
                if (long.TryParse(idTipo, out long id))
                {
                    filtros.Add($"id_tipo_recurso = {id}"); // Añade el filtro a la lista
                }
            }
        }

        /// <summary>
        /// Agrega un filtro por nombre de recurso a la lista de filtros.
        /// </summary>
        /// <param name="nombre">Nombre del recurso a filtrar.</param>
        /// <param name="filtros">Lista de filtros a la que se añadirá el nuevo filtro.</param>
        private void AgregarFiltroPorNombre(string nombre, List<string> filtros)
        {
            if (!string.IsNullOrWhiteSpace(nombre)) filtros.Add($"NombreRecurso LIKE '%{nombre}%'"); // Añade el filtro a la lista
        }

        /// <summary>
        /// Construye la cadena de filtro final a partir de la lista de filtros.
        /// </summary>
        /// <param name="filtros">Lista de filtros a combinar.</param>
        /// <returns>Cadena de filtro combinada.</returns>
        private string ConstruirFiltroFinal(List<string> filtros)
        {
            return filtros.Count > 0 ? string.Join(" AND ", filtros) : string.Empty; // Combina los filtros en una cadena
        }

        /// <summary>
        /// Actualiza la solicitud de recurso con la información proporcionada.
        /// </summary>
        /// <param name="recursoSolicitud">La solicitud de recurso que se desea actualizar.</param>
        /// <returns>Devuelve true si la actualización fue exitosa; de lo contrario, false.</returns>
        public bool updateRecursoSolicitud(RecursoSolicitud recursoSolicitud)
        {
            return _repoRecurso.Update(recursoSolicitud);
        }

        /// <summary>
        /// Método para eliminar un recurso del detalle de la solicitud.
        /// </summary>
        /// <param name="idRecurso">ID del recurso a eliminar.</param>
        /// <returns>True si se eliminó correctamente, de lo contrario false.</returns>
        public bool RemoveFromDetail(long idRecurso)
        {
            // Validar que no esté añadido el recurso
            var recursoDonacion = detalleRecursoSolicitud.FirstOrDefault(detalle => detalle.IdRecurso == idRecurso);

            if (recursoDonacion == null) return false; // Retorna false si el recurso no está en el detalle

            detalleRecursoSolicitud.Remove(recursoDonacion); // Elimina el recurso del detalle
            return true; // Retorna true indicando que se eliminó correctamente
        }

        // <summary>
        /// Obtiene un recurso por su ID.
        /// </summary>
        /// <param name="idRecursoSolicitud">El ID de la solicitud de recurso que se desea obtener.</param>
        /// <returns>Devuelve un DataTable que contiene los detalles del recurso solicitado.</returns>
        public DataTable ObtenerPorId(long idRecursoSolicitud)
        {
            return _repoRecurso.ObtenerPorId(idRecursoSolicitud);
        }

        /// <summary>
        /// Elimina un recurso de la solicitud utilizando su ID.
        /// </summary>
        /// <param name="idRecursoSolicitud">El ID de la solicitud de recurso que se desea eliminar.</param>
        /// <returns>Devuelve true si la eliminación fue exitosa; de lo contrario, false.</returns>
        public bool eliminarRecursoSolicitud(long idRecursoSolicitud)
        {
            return _repoRecurso.RemoveRecursoFromSolicitud(idRecursoSolicitud);
        }

        /// <summary>
        /// Método que valida si la cantidad del recurso en el inventario es suficiente para poder agregarla a la solicutud
        /// </summary>
        /// <param name="recurso"></param>
        /// <returns></returns>
        public bool CheckInvetory(Recurso recurso, int cantidad)
        {
            Recurso recursoInDataBase = _InventarioController.GetRecurso(recurso.IdRecurso);

            if (recursoInDataBase != null && recursoInDataBase.Cantidad > cantidad)
            {
                return true;
            }
            return false;
        }

        public void setCurrentListRecursosSolicitud(long id)
        {
        }
    }
}