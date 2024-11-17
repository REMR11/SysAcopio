using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class RecursoSolicitudView : Form
    {
        private readonly SolicitudController _solicitudController;
        private readonly RecursoSolicitudController _recursoSolicitudController;
        private Recurso _recursoToAdd;
        private DataTable _recursos;
        private bool _isFirstLoading = true;

        public RecursoSolicitudView()
        {
            InitializeComponent();
            _solicitudController = new SolicitudController();
            _recursoSolicitudController = new RecursoSolicitudController();
        }

        private void RecursoSolicitudView_Load(object sender, EventArgs e)
        {
            LoadRecursos();
            SetTipoRecursos();
        }

        private void LoadRecursos()
        {
            _recursos= _recursoSolicitudController.GetAllRecurso();
            SetRecursos(_recursos);
        }

        private void RefreshDetalleGrid()
        {
            dgvDetalle.DataSource = null;
            RemoveDetailButtonColumn();
            dgvDetalle.DataSource = _recursoSolicitudController.detalleRecursoSolicitud;
            HideUnnecessaryColumns(dgvDetalle, "IdRecurso", "IdTipoRecurso");
            AddDeleteButtonColumn();
        }
        private void SetRecursos(DataTable recursos)
        {
            dgvRecursos.DataSource = recursos;
            HideUnnecessaryColumns(dgvRecursos, "id_recurso", "id_tipo_recurso");
            _isFirstLoading = false;
        }

        private void HideUnnecessaryColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (var columnName in columnNames)
            {
                dgv.Columns[columnName].Visible = false;
            }
        }

        public void SetTipoRecursos()
        {
            DataTable tipoData = _recursoSolicitudController.GetAllTipoRecurso();
            tipoData.Rows.Add(0, "Todos");
            cmbTipoRecurso.DataSource = tipoData;
            cmbTipoRecurso.DisplayMember = "nombre_tipo";
            cmbTipoRecurso.ValueMember = "id_tipo_recurso";
            cmbTipoRecurso.SelectedValue = 0;
        }

        private void FilterRecursos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString();
            string nombreRecurso = txtNombreRecurso.Text.Trim();

            DataRow[] filteredRows = _recursoSolicitudController.FiltrarDatosRecursosGrid(_recursos, idTipoRecurso, nombreRecurso);

            if (filteredRows.Length > 0)
            {
                DataTable dtFiltrado = filteredRows.CopyToDataTable();
                SetRecursos(dtFiltrado);
            }
            else
            {
                dgvRecursos.DataSource = null;
            }
        }


        private void RemoveDetailButtonColumn()
        {
            if (dgvDetalle.Columns.Contains("deletDetailButton"))
                dgvDetalle.Columns.Remove("deletDetailButton");
        }

        private void AddDeleteButtonColumn()
        {
            dgvDetalle.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "deletDetailButton",
                HeaderText = "Eliminar Recurso del Detalle",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Flat,
            });
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!IsUrgenciaSelected()) return;

            var nuevaSolicitud = CreateSolicitudFromInputs();
            long idSolicitud = _solicitudController.CrearSolicitud(nuevaSolicitud);

            ClearInputs();
            SaveRecursos(idSolicitud);
            RefreshDetalleGrid();
            Alerts.ShowAlertS("Recursos guardados exitosamente.", AlertsType.Info);
        }

        private bool IsUrgenciaSelected()
        {
            if (cmbUrgencia.SelectedIndex >= 0) return true;

            MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
            return false;
        }

        private Solicitud CreateSolicitudFromInputs()
        {
            return new Solicitud(
                txtDireccion.Text,
                txtNombreSolicitante.Text,
                (byte)(cmbUrgencia.SelectedIndex + 1),
                txtMotivo.Text);
        }

        private void ClearInputs()
        {
            txtDireccion.Clear();
            txtNombreSolicitante.Clear();
            cmbUrgencia.SelectedIndex = 0;
            txtMotivo.Clear();
        }

        private void SaveRecursos(long idSolicitud)
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                var recurso = new Recurso
                {
                    IdRecurso = Convert.ToInt64(row.Cells["IdRecurso"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value)
                };

                long result = _recursoSolicitudController.Create(recurso, idSolicitud);
                if (result <= 0)
                {
                    Alerts.ShowAlertS("Error al guardar el recurso.", AlertsType.Error);
                    return;
                }
            }
        }

        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;
                if (row != null)
                {
                    _recursoToAdd = new Recurso
                    {
                        IdRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value),
                        NombreRecurso = row.Cells["NombreRecurso"].Value.ToString()
                    };
                }
            }
        }


     
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (!IsRecursoValid()) return;

            if (_recursoSolicitudController.AddDetalle(_recursoToAdd, Convert.ToInt32(txtRecursoCantidad.Text)))
            {
                ResetRecursoSelection();
                RefreshDetalleGrid();
            }
        }
        private void txtNombreRecurso_TextChanged(object sender, EventArgs e)
        {
            FilterRecursos();
        }
        private void btnReiniciarDetalle_Click(object sender, EventArgs e)
        {
            _recursoSolicitudController.detalleRecursoSolicitud.Clear();
            RefreshDetalleGrid();
        }
        private bool IsRecursoValid()
        {
            if (_recursoToAdd == null || string.IsNullOrWhiteSpace(txtRecursoCantidad.Text.Trim()))
            {
                Alerts.ShowAlertS("Debe seleccionar un recurso e indicar la cantidad para añadir", AlertsType.Info);
                return false;
            }

            if (Convert.ToInt32(txtRecursoCantidad.Text) <= 0)
            {
                Alerts.ShowAlertS("La cantidad a donar debe ser mayor que 0", AlertsType.Info);
                return false;
            }

            return true;
        }

        private void ResetRecursoSelection()
        {
            _recursoToAdd = null;
            txtRecursoCantidad.Clear();
            dgvRecursos.ClearSelection();
            dgvRecursos.CurrentCell = null;
        }

        private void cmbTipoRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirstLoading) return;
            FilterRecursos();
        }

        private void txtRecursoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private DataTable _detalleDataTable; // Add this field to hold the detail data


        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["deletDetailButton"].Index && e.RowIndex >= 0)
            {
                long idRecurso = Convert.ToInt64(dgvDetalle.Rows[e.RowIndex].Cells["idRecurso"].Value);

                _recursoSolicitudController.RemoveFromDetail(idRecurso);
                RefreshDetalleGrid();
            }
        }


    }
}