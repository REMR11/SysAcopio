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

    }
}

