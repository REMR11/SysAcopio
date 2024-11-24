using Org.BouncyCastle.Pqc.Crypto.Hqc;
using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{

    public class InventarioController
    { 
        private readonly SysAcopioDbContext _dbContext;
        private readonly Recurso recurso;
        private readonly Alerts alerts;
        private readonly List<Recurso> recursoList;
        
        public InventarioController()
        {
          
            recurso = new Recurso();
            alerts = new Alerts();

        }
        
        }
       
        
       
    
       
    
            



   
}
