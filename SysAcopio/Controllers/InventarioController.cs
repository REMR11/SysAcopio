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
        //metodo para validar
      public bool ValidarIdproveedores(string idproveedores)
        {
            if (string.IsNullOrEmpty(idproveedores))
            {
                return false;
            }
            return true;
        }

        public bool ValidarFecha(string fecha)
        {
            if (string.IsNullOrEmpty(fecha))
            {
                return false;
            }
            return true;
        }

        public bool ValidarNombre(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                return false;
            }
            return true;
        }

        public bool ValidarRecursos(string recursos) {
            {
                if (!string.IsNullOrEmpty(recursos))
                {
                    return false;
                }
                return true;
            }
        }

        private  bool ValidarUbicacion(string ubicacion)
        {
            if (!string.IsNullOrEmpty(ubicacion))
            {
                return false;
            }
            return true;
        }
        public bool Validarestado(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                return false;
            }
            return true;
        }
    }
}
