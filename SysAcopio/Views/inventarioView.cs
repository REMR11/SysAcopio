using SysAcopio.Repositories;
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
    public partial class InventarioView : Form
    { private readonly InventarioRepository inventario = new InventarioRepository();
       
        public InventarioView()
        {
            InitializeComponent();
        }

        private void InventarioViews_Load(object sender, EventArgs e)
        {
        
            refrescarGrid();
        }
        public void refrescarGrid()
        {
            dataGridView1.DataSource = inventario.GetInventario();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Actualizar_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                inventario.NombreRecurso = textNombre.Text.Trim();
                inventario.Cantidad = textCantidad.Text.Trim();
                inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();

                int affected = inventario.EditarInventario();
                if (affected > 0)
                {
                    MessageBox.Show("Actualizando...");
                    refrescarGrid();
                }
            }

        }

        private void Limpiar_Click_1(object sender, EventArgs e)
        {
            inventario.NombreRecurso = textNombre.Text.Trim();
            inventario.Cantidad = textCantidad.Text.Trim();
            inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
            dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Selected = false;
        }

        private void Eliminar_Click_1(object sender, EventArgs e)
        {

            if (!textIdRecurso.Text.Equals(""))
            {
                string id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    inventario.IdRecurso = Convert.ToInt64(id);
                    int affected = inventario.EliminarInventario();
                    if (affected >= 1)
                    {
                        MessageBox.Show("eliminando");
                        refrescarGrid();
                    }
                }
            }

        }

        private void Agregar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textNombre.Text) && !string.IsNullOrEmpty(textIdRecurso.Text) && !string.IsNullOrEmpty(textCantidad.Text) && !string.IsNullOrEmpty(textTipoRecurso.Text))
            {
                inventario.NombreRecurso = textNombre.Text.Trim();
                inventario.Cantidad = textCantidad.Text.Trim();
                inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();



            }
            long id = inventario.AgregarInventario();
            if (id > 0)
            {
                MessageBox.Show("Agregado");
                refrescarGrid();
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.CurrentRow;
                textIdRecurso.Text = row.Cells[0].Value.ToString();
                inventario.NombreRecurso = textNombre.Text.Trim();
                inventario.Cantidad = textCantidad.Text.Trim();
                inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();
            }

        }

        private void textTipoRecurso_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        