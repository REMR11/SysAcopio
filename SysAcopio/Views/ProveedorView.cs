using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class ProveedorView : Form
    {
        //Atributos
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        private long idProveedor = 0;

        //Constructor
        public ProveedorView()
        {
            InitializeComponent();
        }

        //Evento Load
        private void Proveedores_Load(object sender, EventArgs e)
        {
            ReiniciarGrid();
        }

        //Método para reiniciar el DataGrid 
        void ReiniciarGrid()
        {
            var data = proveedoresController.GetAll();
            RefresCarGrid(data);
        }

        //Método para mostrar el DataGrid
        void RefresCarGrid(DataTable data)
        {
            dgvProveedores.DataSource = data;

            // Ocultando columnas
            dgvProveedores.Columns["id_proveedor"].Visible = false;
            dgvProveedores.Columns["estado"].Visible = false;
        }

        //Eventos
        private void btnCrear_Click(object sender, EventArgs e)
        {
            //Validar que no hallan campos vacios
            if (txtNombre.Text.Trim() == String.Empty)
            {
                Alerts.ShowAlertS("¡Campos Vacios! Asegurese de que no hallan campos vacios", AlertsType.Info);
                return;
            }

            (idProveedor == 0 ? (Action)Guardar : Modificar)();
        }

        /// <summary>
        /// Método para guardar un Proveedor
        /// </summary>
        void Guardar()
        {
            var confirmacion = proveedoresController.Create(new Proveedor
            {
                NombreProveedor = txtNombre.Text.Trim()
            });

            if (confirmacion)
            {
                ReiniciarGrid();
            }
        }

        /// <summary>
        /// Método para modificar un proveedor
        /// </summary>
        void Modificar()
        {
            if (idProveedor == 0)
            {
                Alerts.ShowAlertS("¡Seleccione un proveedor a modificar!", AlertsType.Info);
                return;
            }

            var confirmacion = proveedoresController.Modify(new Proveedor
            {
                NombreProveedor = txtNombre.Text.Trim(),
                IdProveedor = idProveedor,
                Estado = true
            });

            if (confirmacion)
            {
                ReiniciarGrid();
            }
        }

        //Botón de reinicio
        private void button2_Click(object sender, EventArgs e)
        {
            ReiniciarForm();
        }

        /// <summary>
        /// Método para reiniciar el formulario
        /// </summary>
        void ReiniciarForm()
        {
            txtNombre.Clear();
            txtBuscador.Clear();
            idProveedor = 0;
            ReiniciarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Validar que no hallan campos vacios
            if (txtBuscador.Text.Trim() == String.Empty)
            {
                return;
            }

            var data = proveedoresController.Search(txtBuscador.Text.Trim());

            RefresCarGrid(data);
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var row = dgvProveedores.CurrentRow;

                // Asegúrate de que la celda no sea nula antes de acceder a su valor
                if (row != null)
                {
                    txtNombre.Text = row.Cells["NombreProveedor"].Value.ToString();
                    idProveedor = Convert.ToInt64(row.Cells["id_proveedor"].Value.ToString());
                }
            }
        }

        private void dgvProveedores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Limpiar la selección y la celda actual
            dgvProveedores.ClearSelection();
            dgvProveedores.CurrentCell = null; // Esto quita la selección visual de la celda
            txtNombre.Clear();
            idProveedor = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Sesion.isAdmin)
            {
                Alerts.ShowAlertS("¡Solo un administrador puede eliminar proveedores!", AlertsType.Error);
                return;
            }

            if (idProveedor == 0)
            {
                Alerts.ShowAlertS("¡Seleccione un proveedor a modificar!", AlertsType.Info);
                return;
            }

            var confirmacion = proveedoresController.Delete(idProveedor);

            if (confirmacion)
            {
                ReiniciarGrid();
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
