using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_de_Datos
{
    public partial class Form1 : Form
    {
        Conexion conexion = new Conexion();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string consulta = "insert into productos(descripcionProducto,precioProducto) values('" + txtDescripcion.Text + "'," + txtPrecio.Text + ")";

            if (conexion.ejecutarQuery(consulta))

            {
                MessageBox.Show("Producto registrado correctamente");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string consulta = "delete from productos where idProducto =" + textID.Text;

            if (conexion.ejecutarQuery(consulta))

            {
                MessageBox.Show("Producto eliminado correctamente");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion.cargarDatos("select * from productos");
        }
    }
}
