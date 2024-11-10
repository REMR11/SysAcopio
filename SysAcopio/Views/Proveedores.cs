using SysAcopio.Controllers;
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
    public partial class Proveedores : Form
    {
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            refresCarGrid();
        }

        void refresCarGrid()
        {
            dgvProveedores.DataSource = proveedoresController.GetAll();

            //Ocultando columnas
            dgvProveedores.Columns["id_proveedor"].Visible = false;
            dgvProveedores.Columns["estado"].Visible = false;

            //Añadiendo columna de Estado para mostrarlo como String
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estadoString",
                HeaderText = "Estado",
                ReadOnly = true
            });

            //Añadiendo boton de detalle
            dgvProveedores.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "detalleButton",
                HeaderText = "Detalle",
                Text = "Detalle",
                UseColumnTextForButtonValue = true, // Usar el texto definido
                Width = 100, // Ajusta el ancho del botón
                FlatStyle = FlatStyle.Flat // Estilo plano
            });

            // Llenar la columna "estado" con los valores formateados
            foreach (DataGridViewRow row in dgvProveedores.Rows)
            {
                if (row.Cells["estado"].Value is bool isActive)
                {
                    row.Cells["estadoString"].Value = isActive ? "Activo" : "Inactivo";
                }
            }
        }

        // Manejar el evento de clic en la celda
        //private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Verifica si se hizo clic en la columna del botón
        //    if (e.ColumnIndex == dgvProveedores.Columns["detalleButton"].Index && e.RowIndex >= 0)
        //    {
        //        // Aquí puedes agregar la lógica que desees al hacer clic en el botón
        //        MessageBox.Show("Has hecho clic en Detalle en la fila " + e.RowIndex);
        //    }
        //}
    }
}
