using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Facturacion_Amigos
{
    public partial class contenedorInicio : Form
    {
        public contenedorInicio()
        {
            InitializeComponent();
            string uno, demas, mes;
            int p;
            DateTime l = DateTime.Now;
            
            mes = l.AddMonths(1).ToString("MMMM");
            uno = mes[0].ToString();
            demas = uno.ToUpper() + mes.Substring(1);
            label1.Text = l.Day.ToString() + " " + demas;
            //label1.Text = l.Month.ToString();
        }
    }
}
