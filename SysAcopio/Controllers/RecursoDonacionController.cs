using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    internal class RecursoDonacionController
    {
        private readonly RecursoDonacionRepository repository;

        /// <summary>
        /// Constructor que inicializa el repositorio
        /// </summary>
        public RecursoDonacionController()
        {
            repository = new RecursoDonacionRepository();
        }

        /// <summary>
        /// Método que retorna una tabla con todos los registros del detalle de la Donacion
        /// </summary>
        /// <param name="IdDonacion"></param>
        public DataTable GetDetailDonation(long IdDonacion)
        {
            return repository.GetDetailDonation(IdDonacion);
        }

        /// <summary>
        /// Método para crear un detalle de una Donación
        /// </summary>
        /// <param name="recursoDonacion"></param>
        /// <param name="idDonacion"></param>
        /// <returns>Valor de tipo bool que representa si se creo o no se creo</returns>
        public bool CreateDetail(RecursoDonacion recursoDonacion, long idDonacion)
        {
            //Validamos que la donación exista
            DonacionesController donacionesController = new DonacionesController();
            if (donacionesController.GetDonacionById(idDonacion) != null)
            {
                return repository.Create(recursoDonacion, idDonacion) > 0;
            }

            return false;
        }
    }
}
