using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio
{
    public partial class Form1 : Form
    {
        private Point mouseLocationDrag;

        public Form1()
        {
            InitializeComponent();
            DashBoardManager.MainPanel = ContenedorPanel;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new InicioView());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cuando este se descomenta y se cambia el nombre de ser necesario
            //LoadForm(new DonacionForm());
            DashBoardManager.LoadForm(new Prueba());
        }


        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new SolicitudView());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new UsuarioView());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new InventarioView());
        }
        //btnproveedor
        private void button1_Click(object sender, EventArgs e)
        {

            DashBoardManager.LoadForm(new ProveedorView());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            //Aquí iria la de Reporte cuando este

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new InicioView());
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocationDrag = new Point(-e.X, -e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocationDrag.X, mouseLocationDrag.Y);
                Location = mousePose;
            }
        }
    }
}