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
    { private  InventarioRepository inventario = new InventarioRepository();
       
        public InventarioView()
        {
            InitializeComponent();
          
        }

        private void InventarioViews_Load(object sender, EventArgs e)
        {

            
          
        }
        public void refrescarGrid()
        {
            dataGridView1.DataSource = inventario.GetInventario();
        }

      

        private void Actualizar_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow?.Cells["id"].Value?.ToString();

            if (!string.IsNullOrEmpty(id))
            {
                // Validar los datos ingresados
                if (string.IsNullOrWhiteSpace(textNombre.Text))
                {
                    MessageBox.Show("El nombre del recurso no puede estar vacío.");
                    return;
                }

                if (!int.TryParse(textCantidad.Text.Trim(), out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textTipoRecurso.Text))
                {
                    MessageBox.Show("El tipo de recurso no puede estar vacío.");
                    return;
                }

                // Asignar valores a la entidad
                inventario.NombreRecurso = textNombre.Text.Trim();
                inventario.Cantidad = textCantidad.Text.Trim(); // Utilizar la cantidad convertida
                inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();

                try
                {
                    int affected = inventario.EditarInventario();
                    if (affected > 0)
                    {
                        MessageBox.Show("Actualización exitosa.");
                        refrescarGrid();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios en el inventario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al actualizar el inventario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un recurso para actualizar.");
            
        }

        }

        private void Limpiar_Click_1(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            textNombre.Text = string.Empty;
            textCantidad.Text = string.Empty;
            textTipoRecurso.Text = string.Empty;
            textIdRecurso.Text = string.Empty; // También puedes limpiar el ID del recurso si es necesario

            // Verificar si hay una fila seleccionada antes de intentar deseleccionarla
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Deseleccionar la fila actualmente seleccionada
                dataGridView1.ClearSelection();
            }
        }

        private void Eliminar_Click_1(object sender, EventArgs e)
        {

            if (!textIdRecurso.Text.Equals(""))
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dataGridView1.CurrentRow != null)
                {
                    string id = dataGridView1.CurrentRow.Cells["ID"].Value?.ToString();

                    if (!string.IsNullOrEmpty(id))
                    {
                        // Confirmar la acción de eliminación
                        var confirmResult = MessageBox.Show("?quieres eliminar este recurso?",
                                                             "Confirmar eliminación",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning);
                        if (confirmResult == DialogResult.Yes)
                        {
                            try
                            {
                                inventario.IdRecurso = Convert.ToInt64(id);
                                int affected = inventario.EliminarInventario();
                                if (affected >= 1)
                                {
                                    MessageBox.Show("Recurso eliminado con éxito.");
                                    refrescarGrid();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el recurso.");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ocurrió un error al eliminar el recurso: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID del recurso seleccionado.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un recurso para eliminar.");
                }
            }

        }

        private void Agregar_Click_1(object sender, EventArgs e)
        {// Validar que los campos no estén vacíos
            if (!string.IsNullOrEmpty(textNombre.Text) &&
                !string.IsNullOrEmpty(textIdRecurso.Text) &&
                !string.IsNullOrEmpty(textCantidad.Text) &&
                !string.IsNullOrEmpty(textTipoRecurso.Text))
            {
                // Validar que IdRecurso y Cantidad sean números
                if (!long.TryParse(textIdRecurso.Text.Trim(), out long idRecurso))
                {
                    MessageBox.Show("El ID del recurso debe ser un número válido.");
                    return;
                }

                if (!int.TryParse(textCantidad.Text.Trim(), out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.");
                    return;
                }

                // Asignar valores a la entidad
                inventario.NombreRecurso = textNombre.Text.Trim();
                inventario.Cantidad = textCantidad.Text.Trim(); // Utilizar la cantidad convertida
                inventario.IdTipoRecurso = textTipoRecurso.Text.Trim();

                try
                {
                    long id = inventario.AgregarInventario();
                    if (id > 0)
                    {
                        MessageBox.Show("Recurso agregado con éxito.");
                        refrescarGrid();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el recurso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al agregar el recurso: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            } 
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var row = dataGridView1.CurrentRow;

                // Asegurarse de que la fila no sea nula
                if (row != null)
                {
                    // Asignar el ID del recurso al campo de texto
                    textIdRecurso.Text = row.Cells["ID"].Value?.ToString(); // Asegúrate de que el nombre de la columna sea correcto

                    // Asignar los demás valores desde las celdas correspondientes
                    textNombre.Text = row.Cells["NombreRecurso"].Value?.ToString() ?? string.Empty; // Cambia "NombreRecurso" por el nombre real de la columna
                    textCantidad.Text = row.Cells["Cantidad"].Value?.ToString() ?? string.Empty; // Cambia "Cantidad" por el nombre real de la columna
                    textTipoRecurso.Text = row.Cells["IdTipoRecurso"].Value?.ToString() ?? string.Empty; // Cambia "IdTipoRecurso" por el nombre real de la columna
                }
            }

        }

        private void textTipoRecurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}

        