using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class AlertForm : Form
    {
        public AlertForm(string message, AlertsType type)
        {
            InitializeComponent();

            //Poniendo losy mensajes
            this.txtMensaje.Text = message;

            //Identificando el tipo
            switch (type)
            {
                case AlertsType.Error:
                    this.lblTitulo.Text = "¡Error!";
                    this.picIcono.Image = Properties.Resources.iconoError;
                    this.txtMensaje.BackColor = Color.LightCoral;
                    this.lblTitulo.BackColor = Color.LightCoral;
                    this.BackColor = Color.LightCoral;
                    break;
                case AlertsType.Info:
                    this.lblTitulo.Text = "¡Advertencia!";
                    this.picIcono.Image = Properties.Resources.advertenciaIcono;
                    this.BackColor = Color.LightYellow;
                    this.lblTitulo.BackColor = Color.LightYellow;
                    this.txtMensaje.BackColor = Color.LightYellow;
                    break;
                case AlertsType.Confirm:
                    this.lblTitulo.Text = "¡Exito!";
                    this.picIcono.Image = Properties.Resources.iconoExito;
                    this.BackColor = Color.LightGreen;
                    this.lblTitulo.BackColor = Color.LightGreen;
                    this.txtMensaje.BackColor = Color.LightGreen;
                    break;
            }
        }
    }
}
