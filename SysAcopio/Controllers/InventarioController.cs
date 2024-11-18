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
    internal class InventarioController
    {
        public readonly InventarioRepository inventariorepository;
        public readonly Alerts alerts;
        public List<RecursoDonacion> recursodonaciones { get; set; }
        public List<Solicitud> solicituds { get; set; }
        public List<Donacion> donaciones { get; set; }

        public InventarioController()
        {
            recursodonaciones = new List<RecursoDonacion>();
            solicituds = new List<Solicitud>();
            donaciones = new List<Donacion>();
            alerts = new Alerts();
        }
        public DataTable GetInventario()
        {
            return inventariorepository.GetInventario();
        }

        public DataTable AddInventario(Donacion donacion)
        {
            foreach (var item in recursodonaciones)
            {
                donaciones.Add(donacion);
               
            }return GetInventario();
        }
        public DataTable DeleteInventario(Donacion donacion)
        {
            return inventariorepository.GetInventario();

        }

    }
}
