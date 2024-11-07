using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Repositories
{
    public class DonacionRepository
    {
        private readonly SysAcopioDbContext dbContext;

        public DonacionRepository(SysAcopioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public long Create(Donacion solicitud)
        {
            return 0;
        }
        public void update(Donacion solicitud) { 
            // Codigo
        }

        public List<Donacion> GetAll() {
            return new List<Donacion>();
        }

        public void delete(long id) { 
            //codigo
        }
        }
}
