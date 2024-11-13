using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{
    public class DonacionesController
    {
        private readonly DonacionRepository donacionRepository;
        private readonly Alerts alerts;
        public List<RecursoDonacion> DetalleRecursosDonacion { get; set; }

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
        public void AddDetalle(RecursoDonacion recursoDonacion)
        {
            DetalleRecursosDonacion.Add(recursoDonacion);
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
            foreach (var elementoDetalle in DetalleRecursosDonacion)
            {
                if (!recursoDonacionController.CreateDetail(elementoDetalle, id))
                {
                    alerts.ShowAlert($"Ocurrio un error al agregar el recurso {elementoDetalle.IdRecurso} al detalle en la base de datos", AlertsType.Error);
                }
            }
            alerts.ShowAlert("Felicidades has recibido un donación, tus recursos se han actualizado automaticamente", AlertsType.Confirm);
            return true;
        }


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
                filtro += $"fecha >= #{fechaInicio.Value.ToString("dd/MM/yyyy")}# AND fecha <= #{fechaFin.Value.ToString("dd/MM/yyyy")}# AND ";
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
    }
}
