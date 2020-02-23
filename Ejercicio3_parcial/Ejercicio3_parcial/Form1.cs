using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ejercicio3_parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Queue fila1 = new Queue();
        Queue fila2 = new Queue();
        Queue fila3 = new Queue();
        Queue fila4 = new Queue();
        Queue fila5 = new Queue();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void verificar()
        {
            btnAtender1.Enabled = button5.Enabled = button6.Enabled = button7.Enabled =button8.Enabled = true;
            if (fila1.Count == 0)
            {
                btnAtender1.Enabled = false;
            }
            if (fila2.Count == 0)
            {
                button5.Enabled = false;
            }
            if (fila3.Count == 0)
            {
                button6.Enabled = false;
            }
            if (fila4.Count == 0)
            {
                button7.Enabled = false;
            }
            if(fila5.Count == 0)
            {
                button8.Enabled = false;
            }


            btnFormar1.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = true;
            if (fila1.Count > fila2.Count || fila1.Count > fila3.Count || fila1.Count > fila4.Count || fila1.Count > fila5.Count)
            {
                btnFormar1.Enabled = false;
            }
            if (fila2.Count > fila1.Count || fila2.Count > fila3.Count || fila2.Count > fila4.Count || fila2.Count > fila5.Count)
            {
                button1.Enabled = false;
            }
            if (fila3.Count > fila1.Count || fila3.Count > fila2.Count || fila3.Count > fila4.Count || fila3.Count > fila5.Count)
            {
                button2.Enabled = false;
            }
            if (fila4.Count > fila1.Count || fila4.Count > fila2.Count || fila4.Count > fila3.Count || fila4.Count > fila5.Count)
            {
                button3.Enabled = false;
            }
            if(fila5.Count > fila1.Count || fila5.Count > fila2.Count || fila5.Count > fila3.Count || fila5.Count > fila4.Count)
            {
                button4.Enabled = false;
            }
        }
        int cliente = 1;

        void actualizar()
        {
            lista1.Items.Clear();
            foreach (string cliente in fila1)
            {
                lista1.Items.Add(cliente);
            }
            lista2.Items.Clear();
            foreach (string cliente in fila2)
            {
                lista2.Items.Add(cliente);
            }
            lista3.Items.Clear();
            foreach (string cliente in fila3)
            {
                lista3.Items.Add(cliente);
            }
            lista4.Items.Clear();
            foreach (string cliente in fila4)
            {
                lista4.Items.Add(cliente);
            }
            lista5.Items.Clear();
            foreach(string cliente in fila5)
            {
                lista5.Items.Add(cliente);
            }
            
            verificar();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (fila5.Count != 0)
            {
                fila5.Dequeue();
            }
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fila2.Enqueue("Cliente " + cliente);
            actualizar();
            cliente++;
        }

        private void btnFormar1_Click(object sender, EventArgs e)
        {
            fila1.Enqueue("Cliente " + cliente);
            actualizar();
            cliente++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fila3.Enqueue("Cliente " + cliente);
            actualizar();
            cliente++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fila4.Enqueue("Cliente " + cliente);
            actualizar();
            cliente++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fila5.Enqueue("Cliente " + cliente);
            actualizar();
            cliente++;
        }

        private void btnAtender1_Click(object sender, EventArgs e)
        {
            if (fila1.Count != 0)
            {
                fila1.Dequeue();
            }
            actualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (fila2.Count != 0)
            {
                fila2.Dequeue();
            }
            actualizar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fila3.Count != 0)
            {
                fila3.Dequeue();
            }
            actualizar();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (fila4.Count != 0)
            {
                fila4.Dequeue();
            }
            actualizar();
        }
    }
}
