using SysAcopio.Controllers;
using SysAcopio.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SysAcopio.Views
{
    public partial class Inventario : Form
    {
        //Atributos
        private readonly InventarioController inventarioController = new InventarioController();
        private readonly TipoRecursoController tipoRecursoController = new TipoRecursoController();
        public Inventario()
        {
            InitializeComponent();
            // Suscribirse al evento
            inventarioController.ResourceChanged += InventarioController_ResourceChanged;
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            //Ocultando y mostrando el tab 1
            MostrarTabPage1();

            //Cargando los tipos de recurso en los combobox
            SetTipoRecurso();

            //Setear los filtros de estado
            SetFiltrosEstado();

            //Cargando los recursos
            ReiniciarGrid();
        }

        /// <summary>
        /// Método para setar los filtros de estado
        /// </summary>
        void SetFiltrosEstado()
        {
            var opciones = new Dictionary<string, int>
            {
                { "Todos", 0 },
                { "Disponible", 1 },
                { "Agotado", 2 }
            };

            cmbEstadoFiltro.DataSource = new BindingSource(opciones, null);
            cmbEstadoFiltro.DisplayMember = "Key";   // Muestra el texto en el ComboBox
            cmbEstadoFiltro.ValueMember = "Value";    // Asocia el valor correspondiente
            cmbEstadoFiltro.SelectedValue = 0;
        }

        //Método para inicializar el combobox de tipoRecurso
        void SetTipoRecurso()
        {
            //Obteniendo todos los tipos de recurso
            DataTable tiposData = tipoRecursoController.GetAll();
            //Agregandolo al combobox del formulario
            cmbTipoRecurso.DataSource = tiposData.Copy();
            cmbTipoRecurso.DisplayMember = "TipoRecurso";
            cmbTipoRecurso.ValueMember = "id_tipo_recurso";

            //Preparandolo para el filtro
            tiposData.Rows.Add(0, "Todos");
            cmbTipoRecursoFiltro.DataSource = tiposData;
            cmbTipoRecursoFiltro.DisplayMember = "TipoRecurso";
            cmbTipoRecursoFiltro.ValueMember = "id_tipo_recurso";
            cmbTipoRecursoFiltro.SelectedValue = 0;
        }

        /// <summary>
        /// Método para reiniciar el grid a su estado original
        /// </summary>
        void ReiniciarGrid()
        {
            var data = inventarioController.GetInventario();

            RenderGrid(data);
        }

        /// <summary>
        /// Método para cargar la información del grid
        /// </summary>
        void RenderGrid(DataTable data)
        {
            // Crear la columna "Disponibilidad" en el DataTable
            DataColumn disponibilidadColumn = new DataColumn("Disponibilidad", typeof(string));
            data.Columns.Add(disponibilidadColumn);

            // Llenar la columna "Disponibilidad" con los valores correspondientes
            foreach (DataRow row in data.Rows)
            {
                int cantidad = Convert.ToInt32(row["cantidad"]); // Cambia "cantidad" por el nombre correcto de tu columna
                row["Disponibilidad"] = cantidad > 0 ? "Disponible" : "Agotado";
            }

            dgvRecursos.DataSource = data;
            dgvRecursos.Columns["id_recurso"].Visible = false;
            dgvRecursos.Columns["id_tipo_recurso"].Visible = false;

            // Configurar el DataGridView para aplicar el formato de color
            dgvRecursos.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvRecursos_CellFormatting);
        }

        /// <summary>
        /// Método para limpiar filtros
        /// </summary>
        void limpiarFiltros()
        {
            txtNombreRecursoFiltro.Clear();
            cmbTipoRecursoFiltro.SelectedValue = 0;
            cmbEstadoFiltro.SelectedValue = 0;
            ReiniciarGrid();
            // Limpiar la selección y la celda actual
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null; // Esto quita la selección visual de la celda
        }

        /// <summary>
        /// Método para limpiar el formulario
        /// </summary>
        void LimpiarFormulario()
        {
            txtNombreRecurso.Clear();
            txtCantidad.Clear();
            txtId.Text = 0.ToString();
        }

        /// <summary>
        /// Mostrar Pagina 1 y ocultar la segunda
        /// </summary>
        private void MostrarTabPage1()
        {
            if (!tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Add(tabPage1); // Agregar tabPage1
            }

            if (tabControl1.TabPages.Contains(tabPage2))
            {
                tabControl1.TabPages.Remove(tabPage2); // Quitar tabPage2
            }

            tabControl1.SelectedTab = tabPage1; // Seleccionar tabPage1
        }

        /// <summary>
        /// Mostrar Pagina 2 y ocultar la segunda
        /// </summary>
        private void MostrarTabPage2()
        {
            if (!tabControl1.TabPages.Contains(tabPage2))
            {
                tabControl1.TabPages.Add(tabPage2); // Agregar tabPage2
            }

            if (tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Remove(tabPage1); // Quitar tabPage1
            }

            tabControl1.SelectedTab = tabPage2; // Seleccionar tabPage2
        }

        /// <summary>
        /// Método para eliminar recurso
        /// </summary>
        void EliminarRecurso()
        {
            long idRecurso = Convert.ToInt64(txtId.Text);
            if (idRecurso == 0)
            {
                Alerts.ShowAlertS("Primero debe seleccionar un recurso", AlertsType.Info);
                return;
            }

            inventarioController.Delete(idRecurso);
        }

        /// <summary>
        /// Método para guardar un recurso
        /// </summary>
        void Guardar()
        {
            //Mandamos a llamar el método de Agregar
            inventarioController.Create(new Recurso
            {
                NombreRecurso = txtNombreRecurso.Text,
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                IdTipoRecurso = Convert.ToInt64(cmbTipoRecurso.SelectedValue)
            });
        }

        /// <summary>
        /// Método para actualizar un recurso
        /// </summary>
        void Modificar()
        {
            long idRecurso = Convert.ToInt64(txtId.Text);
            if (idRecurso == 0)
            {
                Alerts.ShowAlertS("¡Seleccione un recurso a modificar!", AlertsType.Info);
                return;
            }

            //Mandamos a llamar el método de Agregar
            inventarioController.Modify(new Recurso
            {
                IdRecurso = idRecurso,
                NombreRecurso = txtNombreRecurso.Text,
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                IdTipoRecurso = Convert.ToInt64(cmbTipoRecurso.SelectedValue)
            });
        }

        private void dgvRecursos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegúrate de que estamos en la columna "Disponibilidad"
            if (dgvRecursos.Columns[e.ColumnIndex].Name == "Disponibilidad")
            {
                string disponibilidad = e.Value as string;

                if (disponibilidad == "Disponible")
                {
                    e.CellStyle.BackColor = Color.Green; // Fondo verde para disponible
                    e.CellStyle.ForeColor = Color.White; // Texto blanco para mejor contraste
                }
                else if (disponibilidad == "Agotado")
                {
                    e.CellStyle.BackColor = Color.Yellow; // Fondo amarillo para agotado
                    e.CellStyle.ForeColor = Color.Black; // Texto negro
                }
            }
        }


        private void dgvRecursos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Limpiar la selección y la celda actual
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null; // Esto quita la selección visual de la celda
        }


        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            limpiarFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtNombreRecursoFiltro.Text.Trim();
            int estadoFiltro = (int)cmbEstadoFiltro.SelectedValue;
            int tipo = Convert.ToInt32(cmbTipoRecursoFiltro.SelectedValue);

            var data = inventarioController.Search(busqueda, estadoFiltro, tipo);
            RenderGrid(data);
        }

        // Manejador del evento
        private void InventarioController_ResourceChanged(string message, AlertsType tipo)
        {
            // Mostrar la alerta 
            Alerts.ShowAlertS(message, tipo);
            LimpiarFormulario();
            ReiniciarGrid();
            MostrarTabPage1();
        }

        private void dgvRecursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            MostrarTabPage2();
            LimpiarFormulario();//Limpiar formulario
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarTabPage1();
            LimpiarFormulario();
            ReiniciarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarTabPage2();
        }

        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;

                // Asegúrate de que la celda no sea nula antes de acceder a su valor
                if (row != null)
                {
                    txtId.Text = row.Cells["id_recurso"].Value.ToString();
                    txtNombreRecurso.Text = row.Cells["NombreRecurso"].Value.ToString();
                    txtCantidad.Text = row.Cells["cantidad"].Value.ToString();
                    cmbTipoRecurso.SelectedValue = Convert.ToInt64(row.Cells["id_tipo_recurso"].Value.ToString());
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmActionForm confirmacion = new ConfirmActionForm("¿Estas seguro que deseas elimianr permanentemente el recurso?", EliminarRecurso);
            confirmacion.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validando el formulario
            if (txtNombreRecurso.Text.Trim() == string.Empty || txtCantidad.Text.Trim() == string.Empty)
            {
                Alerts.ShowAlertS("Revise el formulario, todo debe estar lleno", AlertsType.Info);
                return;
            }

            if (Convert.ToInt32(txtCantidad.Text) < 0)
            {
                Alerts.ShowAlertS("No se permiten cantidades negativas", AlertsType.Info);
                return;
            }

            long idRecurso = Convert.ToInt64(txtId.Text);

            (idRecurso == 0 ? (Action)Guardar : Modificar)();
        }
    }
}
