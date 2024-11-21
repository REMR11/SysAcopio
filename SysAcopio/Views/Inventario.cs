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
        private long idRecurso = 0;
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
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
            DataTable tiposData = tipoRecursoController.GetAll();
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
            ReiniciarGrid();
            // Limpiar la selección y la celda actual
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null; // Esto quita la selección visual de la celda
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
            txtNombreRecursoFiltro.Clear();
            idRecurso = 0;
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
    }
}
