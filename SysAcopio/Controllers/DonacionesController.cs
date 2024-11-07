using SysAcopio.Models;
using SysAcopio.Repositories;

namespace SysAcopio.Controllers
{
    public class DonacionesController
    {
        private readonly DonacionRepository donacionRepository;

        public long Create(Donacion donacion)
        {
            return donacionRepository.Create(donacion);
        }

        public void Update(Donacion donacion)
        {
            donacionRepository.update(donacion);
        }

        public void Delete(long id)
        {
            donacionRepository.delete(id);
        }

    }
}
