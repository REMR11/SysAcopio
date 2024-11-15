using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{
    public class DonacionesController
    {
        private readonly DonacionRepository donacionRepository;
        private readonly Alerts alerts;
        public List<Recurso> detalleRecursoDonacion = new List<Recurso>();

        /// <summary>
        /// Contructor parametrizado
        /// </summary>
        public DonacionesController()
        {
            donacionRepository = new DonacionRepository();
            alerts = new Alerts();
        }

        /// <summary>
        /// Método que obtiene todas las donaciones
        /// </summary>
        /// <returns>Objeto de tipo DataTable que contiene las donaciones</returns>
        public DataTable GetDonaciones()
        {
            return donacionRepository.GetAll();
        }

        /// <summary>
        /// Método que verificar si una donación existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor booleano que confirma la existencia</returns>
        public Donacion GetDonacionById(long id)
        {
            return donacionRepository.GetById(id);
        }

        /// <summary>
        /// Método que agrega un detalle a la lista
        /// </summary>
        /// <returns></returns>
        public bool AddDetalle(Recurso recurso, int cantidad)
        {
            //Validar que no este añadido el recurso
            var recursoDonacion = detalleRecursoDonacion.FirstOrDefault(detalle => detalle.IdRecurso == recurso.IdRecurso);

            if (recursoDonacion == null)
            {
                detalleRecursoDonacion.Add(new Recurso()
                {
                    IdRecurso = recurso.IdRecurso,
                    Cantidad = cantidad,
                    NombreRecurso = recurso.NombreRecurso,
                });
            }
            else//Ya que no esta añadido, actualizamos el recurso
            {
                recursoDonacion.Cantidad += cantidad;
            }
            return true;
        }

        /// <summary>
        /// Método para eliminar un recurso del Detalle
        /// </summary>
        /// <param name="idRecurso"></param>
        /// <returns></returns>
        public bool RemoveFromDetail(long idRecurso)
        {
            //Validar que no este añadido el recurso
            var recursoDonacion = detalleRecursoDonacion.FirstOrDefault(detalle => detalle.IdRecurso == idRecurso);

            if (recursoDonacion == null) return false;

            detalleRecursoDonacion.Remove(recursoDonacion);
            return true;
        }

        /// <summary>
        /// Método que crea las Donaciones y su detalle
        /// </summary>
        /// <returns></returns>
        public bool Create(Donacion donacion)
        {
            //Creamos la donación
            long id = donacionRepository.Create(donacion);

            //Validamos que si se halla creado
            if (id < 0)
            {
                alerts.ShowAlert("Hubo al crear la Donación", AlertsType.Error);
                return false;
            }

            RecursoDonacionController recursoDonacionController = new RecursoDonacionController();
            //Ahora creamos el detalle
            foreach (var elementoDetalle in detalleRecursoDonacion)
            {
                if (!recursoDonacionController.CreateDetail(elementoDetalle, id))
                {
                    alerts.ShowAlert($"Ocurrio un error al agregar el recurso {elementoDetalle.IdRecurso} al detalle en la base de datos", AlertsType.Error);
                }
            }
            alerts.ShowAlert("Felicidades has recibido un donación, tus recursos se han actualizado automaticamente", AlertsType.Confirm);
            return true;
        }

        /// <summary>
        /// Método para filtrar los datos de Donaciones
        /// </summary>
        /// <param name="donaciones"></param>
        /// <param name="idProveedor"></param>
        /// <param name="ubicacion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns>Un arreglo de DataRow</returns>
        /// <exception cref="ArgumentException"></exception>
        public DataRow[] FiltrarDatosDonacionesGrid(DataTable donaciones, string idProveedor, string ubicacion, DateTime? fechaInicio, DateTime? fechaFin)
        {
            string filtro = "";

            // Filtrar por id_proveedor
            if (!string.IsNullOrWhiteSpace(idProveedor) && idProveedor != "0")
            {
                // Asegúrate de que idProveedor se convierte a long
                if (long.TryParse(idProveedor, out long id))
                {
                    filtro += $"id_proveedor = {id} AND ";
                }
                else
                {
                    // Manejar el caso donde la conversión falla (opcional)
                    throw new ArgumentException("El idProveedor no es un número válido.");
                }
            }

            // Filtrar por ubicacion
            if (!string.IsNullOrWhiteSpace(ubicacion))
            {
                filtro += $"ubicacion LIKE '%{ubicacion}%' AND ";
            }

            // Filtrar por rango de fechas
            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                filtro += $"fecha >= '{fechaInicio.Value.ToString("yyyy-MM-dd")}' AND fecha <= '{fechaFin.Value.ToString("yyyy-MM-dd")}' AND ";
            }

            // Eliminar el último " AND " si existe
            if (filtro.EndsWith(" AND "))
            {
                filtro = filtro.Substring(0, filtro.Length - 5);
            }
            // Filtrar el DataTable
            DataRow[] filasFiltradas = donaciones.Select(filtro);

            return filasFiltradas;
        }

        /// <summary>
        /// Método que obtiene todos los recursos
        /// </summary>
        /// <returns>Retorna un objeto de tipo DataTable con los recursos</returns>
        public DataTable GetAllRecursos()
        {
            return donacionRepository.GetAllRecursos();
        }

        /// <summary>
        /// Método que obtiene todos los tipos de recurso
        /// </summary>
        /// <returns>Objeto de tipo DataTable con todos los recursos</returns>
        public DataTable GetAllTipoRecurso()
        {
            return donacionRepository.GetAllTipoRecurso();
        }

        public DataRow[] FiltrarDatosRecursosGrid(DataTable recursos, string idTipo, string nombre)
        {
            string filtro = "";

            // Filtrar por id_proveedor
            if (!string.IsNullOrWhiteSpace(idTipo) && idTipo != "0")
            {
                // Asegúrate de que idProveedor se convierte a long
                if (long.TryParse(idTipo, out long id))
                {
                    filtro += $"id_tipo_recurso = {id} AND ";
                }
                else
                {
                    // Manejar el caso donde la conversión falla (opcional)
                    throw new ArgumentException("El idProveedor no es un número válido.");
                }
            }

            // Filtrar por ubicacion
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                filtro += $"NombreRecurso LIKE '%{nombre}%' AND ";
            }

            // Eliminar el último " AND " si existe
            if (filtro.EndsWith(" AND "))
            {
                filtro = filtro.Substring(0, filtro.Length - 5);
            }
            // Filtrar el DataTable
            DataRow[] filasFiltradas = recursos.Select(filtro);
            return filasFiltradas;
        }
    }
}
