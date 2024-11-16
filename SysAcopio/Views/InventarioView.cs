using SysAcopio.Repositories;
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
    public partial class InventarioView : Form
    {
        private readonly InventarioRepository inventarioRepository= new InventarioRepository();
        public InventarioView()
        {
            InitializeComponent();
        }

        private void InventarioView_Load(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = inventarioRepository.GetInventario();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
