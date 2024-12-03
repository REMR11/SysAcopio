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
    public partial class DetailsGridForm : Form
    {
        public DetailsGridForm(string tituloForm, string titulo, DataTable data, string[] camposOcultos = null)
        {
            InitializeComponent();
            this.Text = tituloForm;
            txtTitulo.Text = titulo;
            dgvData.DataSource = data;

            // Verifica si camposOcultos no es null y tiene elementos
            if (camposOcultos != null && camposOcultos.Length > 0)
            {
                try
                {

                    foreach (string campo in camposOcultos)
                    {

                        // Intenta ocultar la columna
                        dgvData.Columns[campo].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones (puedes registrar el error si es necesario)
                }
            }
        }
    }
}
