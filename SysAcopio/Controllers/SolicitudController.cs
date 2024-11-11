using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SysAcopio.Controllers
{
    public class SolicitudController
    {
        private readonly SolicitudRepository solicitudrepository;

        /// <summary>
        /// Constructor de la clase SolicitudController.
        /// Inicializa una nueva instancia del repositorio de solicitudes.
        /// </summary>
        public SolicitudController()
        {
            solicitudrepository = new SolicitudRepository();
        }

        /// <summary>
        /// Crea una nueva solicitud en el sistema.
        /// </summary>
        /// <param name="solicitud">La solicitud a crear.</param>
        /// <returns>El ID de la solicitud creada.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si la solicitud es nula.</exception>
        public long CrearSolicitud(Solicitud solicitud)
        {
            if (solicitud == null)
                throw new ArgumentNullException(nameof(solicitud));

            return solicitudrepository.Create(solicitud);
        }

        /// <summary>
        /// Obtiene todas las solicitudes almacenadas en el sistema.
        /// </summary>
        /// <returns>Una colección de todas las solicitudes.</returns>
        public IEnumerable<Solicitud> ObtenerTodasLasSolicitudes()
        {
            return solicitudrepository.GetAll();
        }

        /// <summary>
        /// Obtiene una solicitud específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la solicitud a buscar.</param>
        /// <returns>La solicitud correspondiente al ID proporcionado, o null si no se encuentra.</returns>
        public Solicitud ObtenerSolicitudPorId(long id)
        {
            return solicitudrepository.GetById(id);
        }

        /// <summary>
        /// Actualiza una solicitud existente en el sistema.
        /// </summary>
        /// <param name="solicitud">La solicitud con los datos actualizados.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si la solicitud es nula.</exception>
        public bool ActualizarSolicitud(Solicitud solicitud)
        {
            if (solicitud == null)
                throw new ArgumentNullException(nameof(solicitud));

            return solicitudrepository.Update(solicitud);
        }

        /// <summary>
        /// Elimina lógicamente una solicitud del sistema.
        /// </summary>
        /// <param name="id">El ID de la solicitud a eliminar lógicamente.</param>
        /// <returns>True si la eliminación lógica fue exitosa, false en caso contrario.</returns>
        public bool EliminarSolicitudLogicamente(long id)
        {
            return solicitudrepository.DeleteLogic(id);
        }

        /// <summary>
        /// Elimina definitivamente una solicitud del sistema.
        /// </summary>
        /// <param name="id">El ID de la solicitud a eliminar definitivamente.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
        public bool EliminarSolicitudDefinitivamente(long id)
        {
            return solicitudrepository.Delete(id);
        }

        /// <summary>
        /// Obtiene todas las solicitudes activas del sistema.
        /// </summary>
        /// <returns>Una colección de solicitudes activas.</returns>
        public IEnumerable<Solicitud> ObtenerSolicitudesActivas()
        {
            return ObtenerTodasLasSolicitudes().Where(s => s.Estado == true);
        }
        /// <summary>
        /// Obtiene todas las solicitudes activas del sistema.
        /// </summary>
        /// <returns>Una colección de solicitudes activas.</returns>
        public IEnumerable<Solicitud> ObtenerSolicitudesInactivas()
        {
            return ObtenerTodasLasSolicitudes().Where(s => s.Estado == false);
        }

        /// <summary>
        /// Obtiene todas las solicitudes con un nivel de urgencia específico.
        /// </summary>
        /// <param name="urgencia">El nivel de urgencia a buscar.</param>
        /// <returns>Una colección de solicitudes que coinciden con el nivel de urgencia especificado.</returns>
        public IEnumerable<Solicitud> ObtenerSolicitudesPorUrgencia(byte urgencia)
        {
            return ObtenerTodasLasSolicitudes().Where(s => s.Urgencia == urgencia);
        }

        /// <summary>
        /// Cancela una solicitud específica.
        /// </summary>
        /// <param name="id">El ID de la solicitud a cancelar.</param>
        /// <returns>True si la cancelación fue exitosa, false en caso contrario o si la solicitud no existe.</returns>
        public bool CancelarSolicitud(long id)
        {
            var solicitud = ObtenerSolicitudPorId(id);
            if (solicitud == null)
                return false;

            solicitud.IsCancel = true;
            return ActualizarSolicitud(solicitud);
        }
    }
}