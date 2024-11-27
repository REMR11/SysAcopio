using SysAcopio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Utils
{

    public enum AlertsType
    {
        Confirm,
        Error,
        Info
    }
    //Enums para las alertas
    public class Alerts
    {
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// </summary>
        public void ShowAlert(string title, AlertsType type)
        {
            AlertForm alertForm = new AlertForm(title, type);
            alertForm.ShowDialog();
        }

        /// <summary>
        /// Método estatico que funciona igual que el anterior con la diferencia que es invocado desde la clase
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void ShowAlertS(string message, AlertsType type)
        {
            AlertForm alertForm = new AlertForm(message, type);
            alertForm.ShowDialog();
        }
    }
}

