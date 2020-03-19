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
    public partial class Productos : Form
    {

        Producto p = new Producto();
        private bool editar = false;
        DataTable dbdataset;
        public Productos()
        {
            InitializeComponent();
            actualizargird();
        }
        private void actualizargird()
        {
            Producto p = new Producto();
            dataGridView1.DataSource = p.Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrarmensaje();
            if (validarcampos())
            {
                try
                {
                    p.insertar(label5.Text, textBox2.Text, int.Parse(textBox3.Text), double.Parse(textBox4.Text));
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
                label5.Text = dataGridView1.CurrentRow.Cells["ID_Producto"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Nombre_Producto"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                p.editar(label5.Text, textBox2.Text, int.Parse(textBox3.Text), double.Parse(textBox4.Text));
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
            label5.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Debes colocar el código de busqueda");
                    return;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmdbase = new SqlCommand("Select ID_producto, Nombre_Producto, Cantidad, precio from producto;", p.conexion);
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
            dv.RowFilter = string.Format("ID_Producto like '%{0}%' or Nombre_Producto like '%{0}%'", textBox5.Text);
           
            
            dataGridView1.DataSource = dv;
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = p.generar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
            if (Char.IsDigit(e.KeyChar))
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
                MessageBox.Show("Introduzca sólo valores númericos");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cadena = ".0123456789";
            var retroseso = 8;
            if (!cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(" Solo valores monetarios");
            }
            if (e.KeyChar == Convert.ToChar(retroseso))
            {
                e.Handled = false;
                
            }
        }
        private bool validarcampos()
        {
            bool validado = true;
            if (textBox2.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox2, "Ingresar nombre");
            }
            if (textBox3.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox3, "Ingresar cantidad");
            }
            if (label5.Text == "")
            {
                validado = false;
                errorProvider1.SetError(label5, "Genere IDproducto");
            }
            if (textBox4.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textBox4, "Ingresar precio");
            }


            return validado;
        }
        private void borrarmensaje()
        {
            errorProvider1.SetError(textBox2, "");
            errorProvider1.SetError(textBox3, "");
            errorProvider1.SetError(textBox4, "");
            errorProvider1.SetError(label5, "");
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

