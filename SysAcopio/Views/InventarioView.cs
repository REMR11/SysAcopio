using SysAcopio.Controllers;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
   
    public partial class inventario : Form
    {
        private readonly InventarioRepository inventarioRepository = new InventarioRepository();
        public inventario()
        {
            InitializeComponent();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            
        }



        private void agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsolicitud.Text) && !string.IsNullOrEmpty(txtDonaciones.Text))

            {
                inventarioRepository.solicitud = textsolicitud.Text.Trim());
                inventarioRepository.donaciones=tex

                }

            
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            refrescarGrid();
          
        }
        private void refrescarGrid()
        {
            dataGridView1.DataSource = inventarioRepository.GetInventario();
        }

     

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                

            }

        }

        private void Solicitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void Solicitud_Click(object sender, EventArgs e)
        {

        }

        private void textsolicitud_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
