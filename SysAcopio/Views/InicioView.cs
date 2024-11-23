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
    public partial class InicioView : Form
    {
        public InicioView()
        {
            InitializeComponent();
            panel2.Visible = false;
            btnHidePanel.Visible = false; // Ocultar el botón de ocultar inicialmente
            btnShowPanel.Click += new EventHandler(btnShowPanel_Click);
            btnHidePanel.Click += new EventHandler(btnHidePanel_Click);
        

    }

        private void btnShowPanel_Click(object sender, EventArgs e)
        {

            // Crear una instancia del formulario Grupo
            Grupo grupoForm = new Grupo();

            // Configurar el formulario para que no sea de nivel superior
            grupoForm.TopLevel = false;

            // Limpiar el panel antes de agregar el nuevo formulario
            panel2.Controls.Clear();

            // Agregar el formulario al panel
            panel2.Controls.Add(grupoForm);

            // Mostrar el formulario
            grupoForm.Show();

            // Mostrar el panel
            panel2.Visible = true;

            // Ocultar el botón de mostrar y mostrar el botón de ocultar
            btnShowPanel.Visible = false;
            btnHidePanel.Visible = true;
        }

        private void btnHidePanel_Click(object sender, EventArgs e)
        {
            // Ocultar el panel
            panel2.Visible = false;

            // Limpiar el panel
            panel2.Controls.Clear();

            // Mostrar el botón de mostrar y ocultar el botón de ocultar
            btnShowPanel.Visible = true;
            btnHidePanel.Visible = false;
        }
    }
}
