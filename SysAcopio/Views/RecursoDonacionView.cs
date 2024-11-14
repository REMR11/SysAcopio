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
    public partial class RecursoDonacionView : Form
    {
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        private readonly DonacionesController donacionesController = new DonacionesController();
        private long idRecurso = 0;
        private DataTable recursos;
        private bool primerLoading = true;

        public RecursoDonacionView()
        {
            InitializeComponent();
        }

        private void RecursoDonacionView_Load(object sender, EventArgs e)
        {
            //Cargando los proveedores
            SetProveedores();

            //Cargando los tipos de recursos
            SetTipoRecursos();

            //Cargando los recursos
            recursos = donacionesController.GetAllRecursos();
            SetRecursos(recursos);
        }

        /// <summary>
        /// Método para cargar los proveedores
        /// </summary>
        void SetProveedores()
        {
            cmbProveedores.DataSource = proveedoresController.GetAll();
            cmbProveedores.DisplayMember = "NombreProveedor";
            cmbProveedores.ValueMember = "id_proveedor";
        }

        /// <summary>
        /// Método para renderizar los recursos
        /// </summary>
        /// <param name="data"></param>
        void SetRecursos(DataTable data)
        {
            dgvRecursos.DataSource = data;
            dgvRecursos.Columns["id_recurso"].Visible = false;
            dgvRecursos.Columns["id_tipo_recurso"].Visible = false;
            primerLoading = false;
        }

        /// <summary>
        /// Método para setar los tipos de recursos
        /// </summary>
        void SetTipoRecursos()
        {
            DataTable tipoData = donacionesController.GetAllTipoRecurso();
            tipoData.Rows.Add(0, "Todos");
            cmbTipoRecurso.DataSource = tipoData;
            cmbTipoRecurso.DisplayMember = "nombre_tipo";
            cmbTipoRecurso.ValueMember = "id_tipo_recurso";
            cmbTipoRecurso.SelectedValue = 0;
        }

        void FiltrarDatos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString();
            string nobreRecurso = txtNombreRecurso.Text.Trim();

            // Filtrar los datos
            DataRow[] filasFiltradas = donacionesController.FiltrarDatosRecursosGrid(recursos, idTipoRecurso, nobreRecurso);

            // Verificar si hay filas filtradas
            if (filasFiltradas.Length > 0)
            {
                // Crear un nuevo DataTable para almacenar las filas filtradas
                DataTable dtFiltrado = filasFiltradas.CopyToDataTable();
                SetRecursos(dtFiltrado);
            }
            else
            {
                dgvRecursos.DataSource = null;
            }
        }

        private void dgvRecursos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null;
            txtRecursoCantidad.Clear();
            idRecurso = 0;
        }

        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;
                if(row != null)
                {
                    idRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value);
                }
            }
        }

        private void txtNombreRecurso_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void cmbTipoRecurso_SelectedValueChanged(object sender, EventArgs e)
        {
            if (primerLoading) return;
            FiltrarDatos();
        }
    }
}
