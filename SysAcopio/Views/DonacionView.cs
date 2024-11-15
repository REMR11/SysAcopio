using SysAcopio.Controllers;
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
    public partial class DonacionView : Form
    {
        private readonly DonacionesController donacionesController = new DonacionesController();
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        private readonly RecursoDonacionController recursoDonacionController = new RecursoDonacionController();
        private DataTable donaciones;
        private bool primerLoading = true;
        public DonacionView()
        {
            InitializeComponent();
        }

        private void DonacionView_Load(object sender, EventArgs e)
        {
            donaciones = donacionesController.GetDonaciones();
            //Seteando los dateTimePicker
            ResetDateTimePickers();
            //Cargando los proveedores
            SetProveedores();

            //Cargar las donaciones
            ReiniciarGrid();
        }

        /// <summary>
        /// Método para setear el dateTimePicker en el orden correcto
        /// </summary>
        void ResetDateTimePickers()
        {
            //Estableciendo las fechas de inicio y fin
            DateTime fechaFin = dtpFechaFin.Value;
            DateTime fechaUltimoMes = new DateTime(fechaFin.Year, fechaFin.Month, 1).AddMonths(-1);

            // Establecer el valor de dateTimePicker1
            dtpFechaInicio.Value = fechaUltimoMes;
        }

        /// <summary>
        /// Método para cargar los proveedores
        /// </summary>
        void SetProveedores()
        {
            DataTable provedoresData = proveedoresController.GetAll();
            provedoresData.Rows.Add(0, "Todos", true);
            cmbProveedores.DataSource = provedoresData;
            cmbProveedores.DisplayMember = "NombreProveedor";
            cmbProveedores.ValueMember = "id_proveedor";
            cmbProveedores.SelectedValue = 0;
        }

        /// <summary>
        /// ´Método para Reiniciar el grid
        /// </summary>
        void ReiniciarGrid()
        {
            primerLoading = false;
            RefresCarGrid(donaciones);
        }

        //Método para renderizar el grid con la información que se le pase
        void RefresCarGrid(DataTable data)
        {
            dgvDonaciones.DataSource = data;

            // Ocultando columnas
            dgvDonaciones.Columns["id_donacion"].Visible = false;
            dgvDonaciones.Columns["id_proveedor"].Visible = false;

            if (!dgvDonaciones.Columns.Contains("detalleButton"))
            {
                dgvDonaciones.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "detalleButton",
                    HeaderText = "Detalle de Donaciones",
                    Text = "Ver Detalle",
                    UseColumnTextForButtonValue = true, // Usar el texto definido
                    Width = 100, // Ajusta el ancho del botón
                    FlatStyle = FlatStyle.Flat, // Estilo plano
                });
            }
        }

        /// <summary>
        /// Método para filtrar datos
        /// </summary>
        void FiltrarDatos()
        {
            string idProveedor = cmbProveedores.SelectedValue.ToString();
            string ubicacion = txtUbicación.Text.Trim();
            DateTime? fechaInicio = dtpFechaInicio.Value.Date;
            DateTime? fechaFin = dtpFechaFin.Value.Date;
            // Filtrar los datos
            DataRow[] filasFiltradas = donacionesController.FiltrarDatosDonacionesGrid(donaciones, idProveedor, ubicacion, fechaInicio, fechaFin);

            // Verificar si hay filas filtradas
            if (filasFiltradas.Length > 0)
            {
                // Crear un nuevo DataTable para almacenar las filas filtradas
                DataTable dtFiltrado = filasFiltradas.CopyToDataTable();
                RefresCarGrid(dtFiltrado);
            }
            else
            {
                dgvDonaciones.DataSource = null;
                dgvDonaciones.Columns.Clear();
                //Alerts.ShowAlertS("No existen datos que cumplan con esos filtros, lo sentimos", AlertsType.Info);
            }
        }

        /// <summary>
        /// Método para reiniciar los filtros
        /// </summary>
        void ReiniciarFiltros()
        {
            txtUbicación.Clear();
            cmbProveedores.SelectedValue = 0;
            ReiniciarGrid();
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarFiltros();
        }

        private void cmbProveedores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (primerLoading) return;
            FiltrarDatos();
        }

        private void txtUbicación_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (primerLoading) return;

                if (dtpFechaInicio.Value >= dtpFechaFin.Value)
                {
                    Alerts.ShowAlertS("En los filtros, la fecha de inicio no puede ser mayor que la fecha final", AlertsType.Info);
                    ResetDateTimePickers();
                }
                else
                {
                    //MessageBox.Show("TUVO QUE CAMBIAR");
                    FiltrarDatos();
                }
            }
            catch (Exception ex)
            {
                Alerts.ShowAlertS(ex.Message, AlertsType.Error);
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (primerLoading) return;

                if (dtpFechaFin.Value <= dtpFechaInicio.Value)
                {
                    Alerts.ShowAlertS("En los filtros, la fecha de fin no puede ser menor que la fecha inicio", AlertsType.Info);
                }
                else
                {
                    FiltrarDatos();
                }
            }
            catch (Exception ex)
            {
                Alerts.ShowAlertS(ex.Message, AlertsType.Error);
            }
        }

        private void dgvDonaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDonaciones.Columns["detalleButton"].Index && e.RowIndex >= 0)
            {
                long idDonacion = Convert.ToInt64(dgvDonaciones.Rows[e.RowIndex].Cells["id_donacion"].Value);

                DataTable dtDonacionDetalle = recursoDonacionController.GetDetailDonation(idDonacion);

                string fechaDonacion = dgvDonaciones.Rows[e.RowIndex].Cells["fecha"].Value.ToString();
                string proveedor = dgvDonaciones.Rows[e.RowIndex].Cells["NombreProveedor"].Value.ToString();

                string titulo = $"Donaciones de {proveedor} el día {fechaDonacion}";
                string[] camposOcultos = { "id_recurso_donacion", "id_donacion", "id_recurso" };

                DetailsGridForm frm = new DetailsGridForm("Detalle de la donacion", titulo, dtDonacionDetalle, camposOcultos);
                frm.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new RecursoDonacionView());
        }
    }
}
