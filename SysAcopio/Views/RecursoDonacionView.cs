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

namespace SysAcopio.Views
{
    public partial class RecursoDonacionView : Form
    {
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        private readonly DonacionesController donacionesController = new DonacionesController();
        private Recurso recursoToAdd;
        private DataTable recursos;
        private bool primerLoading = true;
        private long idDetalle = 0;

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
            DataTable proveedores = proveedoresController.GetAll();
            proveedores.Rows.Add(0, "Selecciona un proveedor", true);
            cmbProveedores.DataSource = proveedores;
            cmbProveedores.DisplayMember = "NombreProveedor";
            cmbProveedores.ValueMember = "id_proveedor";
            cmbProveedores.SelectedValue = 0;
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

        /// <summary>
        /// Método para filtrar los datos de los recursos
        /// </summary>
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

        void RecargarDetalleGird()
        {
            dgvDetalle.DataSource = null;
            if (dgvDetalle.Columns.Contains("deletDetailButton"))
            {
                dgvDetalle.Columns.Remove("deletDetailButton");
            }
            dgvDetalle.DataSource = donacionesController.detalleRecursoDonacion;
            dgvDetalle.Columns["IdRecurso"].Visible = false;
            dgvDetalle.Columns["IdTipoRecurso"].Visible = false;

            //Añadiendo el botón de eliminar
            dgvDetalle.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "deletDetailButton",
                HeaderText = "Eliminar Recurso del Detalle",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true, // Usar el texto definido
                Width = 100, // Ajusta el ancho del botón
                FlatStyle = FlatStyle.Flat, // Estilo plano
            });

        }

        private void dgvRecursos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null;
            txtRecursoCantidad.Clear();
            recursoToAdd = null;
        }

        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;
                if (row != null)
                {
                    recursoToAdd = new Recurso()
                    {
                        IdRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value),
                        NombreRecurso = row.Cells["NombreRecurso"].Value.ToString()
                    };
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

        private void txtRecursoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancelar el evento
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDetalle.ClearSelection();
            dgvDetalle.CurrentCell = null;
            idDetalle = 0;
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            //Validando que se halla seleccionado un recurso
            if (recursoToAdd == null || string.IsNullOrWhiteSpace(txtRecursoCantidad.Text.Trim()))
            {
                Alerts.ShowAlertS("Debe seleccionar un recurso e indicar la cantidad para añadir", AlertsType.Info);
                return;
            }

            if (Convert.ToInt32(txtRecursoCantidad.Text) <= 0)
            {
                Alerts.ShowAlertS("La cantidad a donar debe ser mayor que 0", AlertsType.Info);
                return;
            }

            //Añadiendo el recurso
            if (donacionesController.AddDetalle(recursoToAdd, Convert.ToInt32(txtRecursoCantidad.Text)))
            {
                recursoToAdd = null;
                txtRecursoCantidad.Clear();
                dgvRecursos.ClearSelection();
                dgvRecursos.CurrentCell = null;
                RecargarDetalleGird();
            }
        }

        private void btnReiniciarDetalle_Click(object sender, EventArgs e)
        {
            donacionesController.detalleRecursoDonacion.Clear();
            RecargarDetalleGird();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["deletDetailButton"].Index && e.RowIndex >= 0)
            {
                long idRecurso = Convert.ToInt64(dgvDetalle.Rows[e.RowIndex].Cells["idRecurso"].Value);

                donacionesController.RemoveFromDetail(idRecurso);
                RecargarDetalleGird();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            long idProveedor = Convert.ToInt64(cmbProveedores.SelectedValue);

            if (idProveedor == 0)
            {
                Alerts.ShowAlertS("Selecciona un proveedor por favor", AlertsType.Info);
                return;
            }

            if (txtUbicación.Text.Trim() == string.Empty)
            {
                Alerts.ShowAlertS("Ingresa la ubicación de donde se recibe la donación", AlertsType.Info);
                return;
            }

            if (donacionesController.detalleRecursoDonacion.Count <= 0)
            {
                Alerts.ShowAlertS("No puede ingresar una donacion sin haber donado recursos", AlertsType.Info);
                return;
            }

            Donacion donacion = new Donacion()
            {
                IdProveedor = idProveedor,
                Ubicacion = txtUbicación.Text.Trim()
            };
            if (donacionesController.Create(donacion))
            {
                DashBoardManager.LoadForm(new DonacionView());
            }
            else
            {
                Alerts.ShowAlertS("Ocurrio un error al realizar la donación", AlertsType.Error);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            primerLoading = true;
            cmbProveedores.DataSource = null;
            //Cargando los proveedores
            SetProveedores();

            txtUbicación.Clear();
            txtRecursoCantidad.Clear();

            dgvRecursos.DataSource = null;
            recursos = donacionesController.GetAllRecursos();
            SetRecursos(recursos);
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            //Mostramos el formulario de Proveedor
            ProveedorView proveedorView = new ProveedorView();
            proveedorView.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            proveedorView.TopLevel = true;
            proveedorView.StartPosition = FormStartPosition.CenterScreen;
            proveedorView.Show();
            Alerts.ShowAlertS("Una vez creado el proveedor, por favor cerrar la venta y presionar el boton de reiniciar en el apartado de formulario para que sus datos aparezcan de nuevo.", AlertsType.Info);
        }
    }
}
