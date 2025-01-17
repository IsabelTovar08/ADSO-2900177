using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_POS.Controllers;

namespace Sistema_POS
{
    public partial class Form1 : Form
    {
        ProductoController pc = new ProductoController();
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            DataTable productos = pc.listarProductos();
            dataGridView1.DataSource = productos; 
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
