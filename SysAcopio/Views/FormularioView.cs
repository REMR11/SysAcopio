using SysAcopio.Models;
using SysAcopio.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class FormularioView : Form
    {
        private readonly InventarioRepository inventario=new InventarioRepository();
        public FormularioView()
        {
            InitializeComponent();
        }

        private void FormularioView_Load(object sender, EventArgs e)
        {
            refrescarGrid();
        }
        public void refrescarGrid()
        {
            dataGridView1.DataSource = inventario.GetInventario();
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void textSolicitud_TextChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textNombre.Text) && !string.IsNullOrEmpty(textRecurso.Text) && !string.IsNullOrEmpty(textUbicacion.Text) && !string.IsNullOrEmpty(textCategoria.Text) && !string.IsNullOrEmpty(textEstado.Text) && !string.IsNullOrEmpty(textFecha.Text))
            {
                inventario.Nombres=textNombre.Text.Trim();
                inventario.Recursos=textRecurso.Text.Trim();
                inventario.Ubicacion=textUbicacion.Text.Trim();
                inventario.Categoria=textCategoria.Text.Trim();
                inventario.Estado=textEstado.Text.Trim();
                inventario.Fecha=textFecha.Text.Trim();
            }
            long id = inventario.AgregarInventario();
            if (id > 0)
            {
                MessageBox.Show("Agregado");
                refrescarGrid();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (!textId.Text.Equals(""))
            {
                string id=dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    inventario.IdRecursos = Convert.ToInt64(id);
                    int affected = inventario.ElminarInventario();
                    if (affected >= 1)
                    {
                        MessageBox.Show("eliminando");
                        refrescarGrid();
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var row=dataGridView1.CurrentRow;
                textId.Text = row.Cells[0].Value.ToString();
                textNombre.Text = row.Cells["nombre"].Value.ToString();
                textRecurso.Text = row.Cells["recurso"].Value.ToString();
                textUbicacion.Text = row.Cells["ubicacion"].Value.ToString();
                textCategoria.Text = row.Cells["categoria"].Value.ToString() ;
                textEstado.Text = row.Cells["estado"].Value.ToString();
                textFecha.Text = row.Cells["fecha"].Value.ToString();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string id=dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                inventario.Nombres = textNombre.Text.Trim();
                inventario.Recursos = textRecurso.Text.Trim();
                inventario.Ubicacion = textUbicacion.Text.Trim();
                inventario.Categoria = textCategoria.Text.Trim();
                inventario.Estado = textEstado.Text.Trim();
                inventario.Fecha = textFecha.Text.Trim();

                int affected = inventario.EditarInventario();
                if (affected > 0)
                {
                    MessageBox.Show("Actualizando...");
                    refrescarGrid();
                }
            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            textId.Clear();
            textNombre.Clear();
            textRecurso.Clear();
            textUbicacion.Clear();
            textCategoria.Clear();
            textEstado.Clear();
            textFecha.Clear();
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
            dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Selected = false;

        }

        

       
    }
}
