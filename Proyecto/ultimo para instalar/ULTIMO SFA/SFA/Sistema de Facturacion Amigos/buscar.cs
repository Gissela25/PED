using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_de_Facturacion_Amigos
{
    public partial class buscar : Form
    {
        Alumno a = new Alumno();
        DataTable dbdataset;
        public buscar()
        {
            InitializeComponent();

        }
        private void actualizargird()
        {
            Alumno a = new Alumno();
            dataGridView1.DataSource = a.Mostrar();
        }

        private void buscar_Load(object sender, EventArgs e)
        {
            actualizargird();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmdbase = new SqlCommand("Select * From alumnos;", a.conexion);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdbase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DataView dv = new DataView(dbdataset);
            dv.RowFilter = string.Format("Nombre like '%{0}%' or Apellido like '%{0}%' or  Apellido2 like '%{0}%' or ID_Alumno like '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = dv;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string no= Convert.ToString(this.dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString()),
                ap1= Convert.ToString(this.dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString()), 
                ap2= Convert.ToString(this.dataGridView1.CurrentRow.Cells["Apellido2"].Value.ToString());
            Factura f = new Factura();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Controls.Add(f);
            this.Tag = f;
            f.BringToFront();
            f.label5.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["ID_Alumno"].Value.ToString());
            f.label9.Text= string.Format("{0} {1} {2}",no, ap1, ap2);
            f.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            contenedorInicio con = new contenedorInicio();
            con.TopLevel = false;
            con.Dock = DockStyle.Fill;
            this.Controls.Add(con);
            this.Tag = con;
            con.BringToFront();
            con.Show();
        }
    }
}
