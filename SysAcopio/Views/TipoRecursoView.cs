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
    public partial class TipoRecursoView : Form
    {
        //Atributos
        private readonly TipoRecursoController tipoRecursoController = new TipoRecursoController();
        private long idTipoRecursoProveedor = 0;

        public TipoRecursoView()
        {
            InitializeComponent();
            btnCrear.Click += (sender, e) => AccionClick();
            btnBuscar.Click += (sender, e) => BuscarTiposRecurso();
            dgvTipoRecurso.DataBindingComplete += (sender, e) => DgvDataCompleted();
        }

        private void TipoRecursoView_Load(object sender, EventArgs e)
        {
            ReiniciarGrid();
        }

        //Método para reiniciar el DataGrid 
        void ReiniciarGrid()
        {
            var data = tipoRecursoController.GetAll();
            RefresCarGrid(data);
        }

        //Método para cargar el DataGrid con datos
        void RefresCarGrid(DataTable data)
        {
            dgvTipoRecurso.DataSource = data;

            // Ocultando columnas
            dgvTipoRecurso.Columns["id_tipo_recurso"].Visible = false;
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click al boton de crear tipoRecurso
        /// </summary>
        void AccionClick()
        {
            if (txtNombre.Text.Trim() == string.Empty)
            {
                Alerts.ShowAlertS("¡Campos Vacios! Asegurese de que no hallan campos vacios", AlertsType.Info);
                return;
            }

            (idTipoRecursoProveedor == 0 ? (Action)Guardar : Modificar)();
        }

        //Metodo para guardar un tipo de recurso
        void Guardar()
        {
            var confirmacion = tipoRecursoController.Create(new TipoRecurso
            {
                NombreTipo = txtNombre.Text.Trim()
            });

            if (confirmacion)
            {
                ReiniciarGrid();
            }
        }

        //Método para modificar un tipo de recurso
        void Modificar()
        {
            if (idTipoRecursoProveedor == 0)
            {
                Alerts.ShowAlertS("¡Seleccione un proveedor a modificar!", AlertsType.Info);
                return;
            }

            var confirmacion = tipoRecursoController.Modify(new TipoRecurso
            {
                NombreTipo = txtNombre.Text.Trim(),
                IdTipoRecurso = idTipoRecursoProveedor,
            });

            if (confirmacion)
            {
                ReiniciarGrid();
            }
        }

        /// <summary>
        /// Método para reiniciar el formulario
        /// </summary>
        void ReiniciarForm()
        {
            txtNombre.Clear();
            txtBuscador.Clear();
            idTipoRecursoProveedor = 0;
            ReiniciarGrid();
        }

        void BuscarTiposRecurso()
        {
            //Validar que no hallan campos vacios
            if (txtBuscador.Text.Trim() == String.Empty)
            {
                return;
            }

            var data = tipoRecursoController.Search(txtBuscador.Text.Trim());

            RefresCarGrid(data);
        }

        /// <summary>
        /// Método que se ejecuta cuando los datos del datagridView ya se han completado
        /// </summary>
        void DgvDataCompleted()
        {
            dgvTipoRecurso.ClearSelection();
            dgvTipoRecurso.CurrentCell = null; // Esto quita la selección visual de la celda
            txtNombre.Clear();
            idTipoRecursoProveedor = 0;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ReiniciarForm();
        }

        private void dgvTipoRecurso_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipoRecurso.SelectedRows.Count > 0)
            {
                var row = dgvTipoRecurso.CurrentRow;

                // Asegúrate de que la celda no sea nula antes de acceder a su valor
                if (row != null)
                {
                    txtNombre.Text = row.Cells["Tipo Recurso"].Value.ToString();
                    idTipoRecursoProveedor = Convert.ToInt64(row.Cells["id_tipo_recurso"].Value.ToString());
                }
            }
        }
    }
}
