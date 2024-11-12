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
    public partial class DonacionView : Form
    {
        private readonly DonacionesController donacionesController = new DonacionesController();
        private readonly ProveedoresController proveedoresController = new ProveedoresController();
        private DataTable donaciones;
        public DonacionView()
        {
            InitializeComponent();
        }

        private void DonacionView_Load(object sender, EventArgs e)
        {
            //Estableciendo las fechas de inicio y fin
            DateTime fechaFin = dtpFechaFin.Value;
            DateTime fechaUltimoMes = new DateTime(fechaFin.Year, fechaFin.Month, 1).AddMonths(-1);

            // Establecer el valor de dateTimePicker1
            dtpFechaInicio.Value = fechaUltimoMes;

            //Cargando los proveedores
            SetProveedores();
        }

        void SetProveedores()
        {
            DataTable provedoresData = proveedoresController.GetAll();
            provedoresData.Rows.Add(0, "Todos", true);
            cmbProveedores.DataSource = provedoresData;
            cmbProveedores.DisplayMember = "NombreProveedor";
            cmbProveedores.ValueMember = "id_proveedor";
            cmbProveedores.SelectedValue = 0;
        }

        void ReiniciarGrid()
        {
            donaciones = donacionesController.GetDonaciones();

        }

        void RefresCarGrid(DataTable data)
        {
            dgvDonaciones.DataSource = data;

            // Ocultando columnas
            dgvDonaciones.Columns["id_donacion"].Visible = false;
            dgvDonaciones.Columns["id_proveedor"].Visible = false;
        }

        void ReiniciarFiltros()
        {
            txtUbicación.Clear();
            cmbProveedores.SelectedValue = 0;
            ReiniciarGrid();
        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {

        }

    }
}
