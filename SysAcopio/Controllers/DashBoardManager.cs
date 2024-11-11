using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Controllers
{
    public static class DashBoardManager
    {
        public static Panel MainPanel { get; set; }
        public static void LoadForm(Form form)
        {
            if (MainPanel.Controls.Count > 0)
            {
                MainPanel.Controls.Clear(); // Limpia el panel antes de cargar un nuevo formulario
            }

            form.TopLevel = false; // Establece el formulario como no top-level
            form.Dock = DockStyle.Fill; // Ajusta el formulario para que llene el panel
            form.FormBorderStyle = FormBorderStyle.None;
            MainPanel.Controls.Add(form); // Agrega el formulario al panel
            MainPanel.Tag = form;
            form.Show(); // Muestra el formulario
            form.Focus();
        }
    }
}
