using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SysAcopio.Controllers
{
    public class SolicitudController
    {
        private readonly SolicitudRepository solicitudrepository;

        public SolicitudController()
        {
            solicitudrepository = new SolicitudRepository();
        }

        public long CrearSolicitud(Solicitud solicitud)
        {
            if (solicitud == null)
                throw new ArgumentNullException(nameof(solicitud));

            return solicitudrepository.Create(solicitud);
        }

        public IEnumerable<Solicitud> ObtenerTodasLasSolicitudes()
        {
            return solicitudrepository.GetAll();
        }

        public Solicitud ObtenerSolicitudPorId(long id)
        {
            return solicitudrepository.GetById(id);
        }

        public bool ActualizarSolicitud(Solicitud solicitud)
        {
            if (solicitud == null)
                throw new ArgumentNullException(nameof(solicitud));

            return solicitudrepository.Update(solicitud);
        }

        public bool EliminarSolicitudLogicamente(long id)
        {
            return solicitudrepository.DeleteLogic(id);
        }

        public bool EliminarSolicitudDefinitivamente(long id)
        {
            return solicitudrepository.Delete(id);
        }

        // Métodos adicionales que podrían ser útiles

        public IEnumerable<Solicitud> ObtenerSolicitudesActivas()
        {
            return ObtenerTodasLasSolicitudes().Where(s => s.Estado);
        }

        public IEnumerable<Solicitud> ObtenerSolicitudesPorUrgencia(byte urgencia)
        {
            return ObtenerTodasLasSolicitudes().Where(s => s.Urgencia == urgencia);
        }

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