using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System.Collections.Generic;
using System.Data;

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
    }
}
