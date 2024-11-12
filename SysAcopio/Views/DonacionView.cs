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
        public DonacionView()
        {
            InitializeComponent();
        }

        private void DonacionView_Load(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpFechaFin.Value;
        }
    }
}
