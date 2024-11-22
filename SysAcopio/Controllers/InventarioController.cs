using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using SysAcopio.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{
    public class InventarioController
    {
        private readonly Recurso recurso;
        private readonly Alerts alerts;
        //metodos para validar la informacion
      public List< Recurso> recursoList;

        public InventarioController(Recurso recurso, Alerts alerts, List<Recurso> recursoList)
        {
            this.recurso = recurso;
            this.alerts = alerts;
            this.recursoList = recursoList;
        }

    }
}
