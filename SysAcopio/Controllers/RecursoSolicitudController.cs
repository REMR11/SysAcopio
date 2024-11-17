using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SysAcopio.Controllers
{
    public class RecursoSolicitudController
    {
        private readonly RecursoSolicitudRepository repoRecurso;
        public List<Recurso> detalleRecursoSolicitud = new List<Recurso>();

        public RecursoSolicitudController()
        {
            this.repoRecurso = new RecursoSolicitudRepository();
        }

        public DataTable GetAllRecurso()
        {
            return repoRecurso.GetAllRecursos();
        }

        public DataTable GetAllTipoRecurso()
        {
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
                recursoDonacion.Cantidad += cantidad;
            }
            return true;
        }

        // Método para obtener los detalles de una solicitud
        public DataTable GetDetailSolicitud(long idDonacion)
        {
            return repoRecurso.GetDetailSolicitud(idDonacion);
        }

        // Método para crear una nueva solicitud de recurso
        public long Create(Recurso recursoSolicitud, long idSolicitud)
        {
            return repoRecurso.Create(recursoSolicitud, idSolicitud);
        }

        private void AgregarFiltroPorIdTipo(string idTipo, List<string> filtros)
        {
            // Filtrar por id_proveedor
            if (!string.IsNullOrWhiteSpace(idTipo) && idTipo != "0")
            {
                // Asegúrate de que idProveedor se convierte a long
                if (long.TryParse(idTipo, out long id))
                {
                    filtros.Add($"id_tipo_recurso = {id}");
                }
                //else
                //{
                //    // Manejar el caso donde la conversión falla (opcional)
                //    throw new ArgumentException("El idProveedor no es un número válido.");
                //}
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

        /// <summary>
        /// Método para eliminar un recurso del Detalle
        /// </summary>
        /// <param name="idRecurso"></param>
        /// <returns></returns>
        public bool RemoveFromDetail(long idRecurso)
        {
            //Validar que no este añadido el recurso
            var recursoDonacion = detalleRecursoSolicitud.FirstOrDefault(detalle => detalle.IdRecurso == idRecurso);

            if (recursoDonacion == null) return false;

            detalleRecursoSolicitud.Remove(recursoDonacion);
            return true;
        }
    }
}