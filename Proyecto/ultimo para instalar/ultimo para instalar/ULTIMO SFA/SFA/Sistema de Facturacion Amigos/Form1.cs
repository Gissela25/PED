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
using System.Data.OleDb;

namespace Sistema_de_Facturacion_Amigos
{
    public partial class Form1 : Form
    {

        Alumno a = new Alumno();
        DataTable dbdataset;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizargird();
        }
        private void actualizargird()
        {
            Alumno a = new Alumno();
            dataGridView1.DataSource = a.Mostrar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            borrarmensaje();
            string le1, le2;
            le1 = textBox3.Text.Substring(0, 1);
            le2 = textBox4.Text.Substring(0, 1);
            Alumno ge = new Alumno();
            label6.Text = ge.Codigo(le1, le2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            borrarmensaje();
            if (validarcampos())
            {
                try
                {
                    a.insertar(label6.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    MessageBox.Show("Registrado");
                    actualizargird();
                    limpiarform();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO se pudo insertar:" + ex);
                }
            }

            
          
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                label6.Text = dataGridView1.CurrentRow.Cells["ID_Alumno"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["Apellido2"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void button3_Click(object sender, EventArgs e)
        {



            try
            {
                a.editar(label6.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                MessageBox.Show("Se edito correctamente");
                limpiarform();
                editar = false;
                actualizargird();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo editar los datos por:" + ex);
            }



        }
        private void limpiarform()
        {
            label6.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Introduzca solo letras");
            }

            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Introduzca solo letras");
            }

           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Introduzca solo letras");
            }

            
        }
        private bool validarcampos()
        {
            bool validado = true;
            if(textBox2.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox2, "Ingresar nombre");
            }
            if(textBox3.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox3, "Ingresar apellido1");
            }
            if(label6.Text == "")
            {
                validado = false;
                errorProvider1.SetError(label6, "Genere IDAlumno");
            }
            if(textBox4.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox4, "Ingresar apellido2");
            }


            return validado;
        }
        private void borrarmensaje()
        {
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(label6, "");
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
