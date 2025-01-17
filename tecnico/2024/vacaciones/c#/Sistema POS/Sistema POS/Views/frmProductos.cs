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

namespace Sistema_POS.Views
{
    public partial class frmProductos : Form
    {
        private ProductoController controller;

        public frmProductos()
        {
            InitializeComponent();
            controller = new ProductoController();
            CaragarProductos();
        }

        private void CaragarProductos()
        {
            DataTable dt = controller.listarProductos();
            dataGridView1.DataSource = dt;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                txtId.Text = fila.Cells["id"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtPrecio.Text = fila.Cells["precio"].Value.ToString();
                txtCantidad.Text = fila.Cells["cantidad"].Value.ToString();
                string tipo = fila.Cells["tipo"].Value.ToString();
                if (txtTipo.Items.Contains(tipo))
                {
                    txtTipo.SelectedItem = tipo;
                }
                txtImpuesto.Text = fila.Cells["impuesto"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "0";
            txtPrecio.Text = "0";
            txtImpuesto.Text = "0";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            string tipo = txtTipo.Text;
            decimal impuesto = Convert.ToDecimal(txtImpuesto.Text);

            int filasAfectadas = controller.CrearPoducto(nombre,precio, cantidad,tipo, impuesto);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Producto creado con éxito");
                CaragarProductos();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            int filasAfectadas = controller.EliminarProducto(id);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Producto eliminado con éxito");
                CaragarProductos();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            string tipo = txtTipo.Text;
            decimal impuesto = Convert.ToDecimal(txtImpuesto.Text);

            int filasAfectadas = controller.ActualizarPoducto(id, nombre, precio, cantidad, tipo, impuesto);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Producto actualizado con éxito");
                CaragarProductos();
            }
        }
    }
}
