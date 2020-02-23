using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2_parcial_ped
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Stack<int> Pila1 = new Stack<int>();
        static Stack<int> Pila2 = new Stack<int>();

        int cont = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
            cont++;
            Pila1.Push(cont);
            lstContenedor.Items.Clear();
            if (cont <= 5)
            {
               
                foreach (var item in Pila1)
                {
                    lstContenedor.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show(" no se puede ingresar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int dato = int.Parse(txtDato.Text);
                Boolean resp = false;
                int conta = 0;
                foreach (var item in Pila1)
                {
                    conta++;
                    if (item.Equals(dato))
                    {
                        resp = true;
                        break;
                    }
                    else
                    {
                        Pila2.Push(item);
                    }
                }
                if (resp)
                {
                    for (int i = 0; i < conta; i++)
                    {
                        Pila1.Pop();
                    }
                    foreach (var item in Pila2)
                    {
                        Pila1.Push(item);
                    }
                    lstContenedor.Items.Clear();
                    lstPila2.Items.Clear();
                    foreach (var item in Pila2)
                    {
                        lstPila2.Items.Add(item);
                    }
                    foreach (var item in Pila1)
                    {
                        lstContenedor.Items.Add(item);
                    }
                    MessageBox.Show("¡Eliminado exitosamente!");
                    Pila2.Clear();
                }
                else
                {
                    MessageBox.Show("¡Elemento no encontrado!");
                    Pila2.Clear();
                }

            }
            catch
            {
                MessageBox.Show("Ups! Algo inesperado paso, intentelo de nuevo", "Advertencia");
                txtDato.ResetText();
                txtDato.Focus();
            }
        }
    }
    }
