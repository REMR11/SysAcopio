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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio
{
    public partial class Form1 : Form
    {
     
      
        public Form1()
        {
            InitializeComponent();
           


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            ContenedorPanel.Controls.Clear();

            DonacionView donacionView = new DonacionView
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            
            ContenedorPanel.Controls.Add(donacionView);
            donacionView.Show();
            
        }

       
        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            
            ContenedorPanel.Controls.Clear();

            SolicitudView solicitudview = new SolicitudView
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            
            ContenedorPanel.Controls.Add(solicitudview);
            solicitudview.Show();
            
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            ContenedorPanel.Controls.Clear();

            UsuarioView usuarioView = new UsuarioView
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            ContenedorPanel.Controls.Add(usuarioView);
            usuarioView.Show();

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            ContenedorPanel.Controls.Clear();
            
            InventarioView inventarioView = new InventarioView
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill
            };

            
            ContenedorPanel.Controls.Add(inventarioView);
            inventarioView.Show();
        }
        //btnproveedor
        private void button1_Click(object sender, EventArgs e)
        {
            
            ContenedorPanel.Controls.Clear();

            ProveedorView proveedorview = new ProveedorView
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            
            proveedorview.Controls.Add(proveedorview);
            proveedorview.Show();
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            
           ContenedorPanel.Controls.Clear();

           ReporteView reporteview = new ReporteView
           {
               TopLevel = false, 
               FormBorderStyle = FormBorderStyle.None, 
               Dock = DockStyle.Fill 
           };


           reporteview.Controls.Add(reporteview);
           reporteview.Show();
           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ContenedorPanel.Controls.Clear();

            InicioView inicioview = new InicioView
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };


            inicioview.Controls.Add(inicioview);
            inicioview.Show();
        }
    }
}
