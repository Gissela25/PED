using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sistema_de_Facturacion_Amigos
{
    class CFactura:Alumno
    {
        private Conexion c = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        private int Cantidad;
        private DateTime Fecha;
        private string IDFactura, preci, idpro, matricula, codMatricula;
              
        public int cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public int mora(string mes, int pm)//modificar
        {
            int morames;
            string uno, uno2, demas, me, me1, mes2;
            DateTime l = DateTime.Now;
            me = l.ToString("MMMM");
            me1 = l.AddMonths(1).ToString("MMMM");
            uno = mes[0].ToString();
            demas = uno.ToUpper() + me.Substring(1);
            uno2 = me1[0].ToString();
            mes2 = uno2.ToUpper() + me1.Substring(1);
            if ( demas == mes && int.Parse(l.Day.ToString())<=20)
            {
                morames = 0;
            }
            else if (mes2 == mes)
            {
                morames = 0;
            }
            else
            {
                morames = 3;
            }
            return morames;
        }
        public DateTime fecha //del sistema
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public bool ValMatricula(string e)
        {
            bool n = true;
            SqlCommand val = new SqlCommand("Select count (F.ID_Alumno) from Factura F Inner join Matricula M On F.ID_Factura = M.ID_Factura where F.ID_Alumno = @Alumno", c.conexion);
            c.ABRICONEXION();
            val.Parameters.AddWithValue("@Alumno", e);
            String cont = Convert.ToString(val.ExecuteScalar());
            int count = int.Parse(cont);
            if (count == 1)
            {
                MessageBox.Show("Este alumno ya está matriculado", "Aviso");
                n = false;

            }
            c.CERRARCONEXION();
            return n;

        }
            public bool ValMesualidad(ComboBox mes, Label alumno)
        {
            bool n = true;
            SqlCommand val = new SqlCommand("Select count (F.ID_Alumno) from Factura F Inner join Mensualidad M On F.ID_Factura = M.ID_Factura Where F.ID_Alumno=@Alumno", c.conexion);
            c.ABRICONEXION();
            val.Parameters.AddWithValue("@Alumno", alumno.Text);
            String cont = Convert.ToString(val.ExecuteScalar());
            int count = int.Parse(cont);
            if (count < mes.SelectedIndex)
            {
                mes.SelectedIndex = count;
                MessageBox.Show("Aún no se ha pagado el mes " + mes.SelectedItem.ToString(), "Aviso");
                n = false;
            }
            else if (count > mes.SelectedIndex)
            {
                MessageBox.Show("Este mes ya esta pagado", "Aviso");
                n = false;
            }
            c.CERRARCONEXION();
            return n;


        }
        public string generar()
        {
            int prueba=0;
            SqlCommand cuenta = new SqlCommand("select COUNT(ID_Factura) as total from Factura", c.conexion);
            comando.Connection = c.ABRICONEXION();
            leer = cuenta.ExecuteReader();
            if (leer.Read() == true)
            {
                prueba = int.Parse(leer["total"].ToString()) + 1;                
            }
            c.CERRARCONEXION();
            return  prueba.ToString("00000000");
        }

        public string maxProducto(string nompro)
        {
            int canti = 0;
            SqlCommand m = new SqlCommand("Select Cantidad FROM Producto WHERE Nombre_Producto= '" + nompro + "'",c.conexion);
            c.ABRICONEXION();
            leer = m.ExecuteReader();
            if (leer.Read() == true)
            {
                canti = int.Parse(leer["Cantidad"].ToString());
            }
            c.CERRARCONEXION();
            return canti.ToString();
        }
        public string agregarPrecio(string selec)
        {           
                string prec;
                SqlCommand pre = new SqlCommand("SELECT Precio FROM Producto WHERE Nombre_Producto = '" + selec+"'", c.conexion);
                comando.Connection = c.ABRICONEXION();
                leer = pre.ExecuteReader();
                if (leer.Read() == true)
                {
                    prec = leer["Precio"].ToString();
                    preci = prec;
                }
                c.CERRARCONEXION();
                return preci;           
        }
        public string agregarIDProducto(string selec)
        {
            string idp;
            SqlCommand pre = new SqlCommand("SELECT ID_Producto FROM Producto WHERE Nombre_Producto = '" + selec + "'", c.conexion);
            comando.Connection = c.ABRICONEXION();
            leer = pre.ExecuteReader();
            if (leer.Read() == true)
            {
                idp = leer["ID_Producto"].ToString();
                idpro = idp;
            }
            c.CERRARCONEXION();
            return idpro;
        }
       
        public string Matricula()
        {
            string a;
            DateTime año = DateTime.Now;
            a = año.Year.ToString();
            return matricula = "Matricula "+ a;
        }
        public string CodMatricula()
        {
            int a;
            DateTime año = DateTime.Now;
            a = año.Year;
            return codMatricula = "MT" + a.ToString();
        }
        public string CodMensu(string mes)
        {
            int a;
            DateTime año = DateTime.Now;
            a = año.Year;
            return codMatricula = mes + a.ToString();
        }
        public void insertarfacturaproducto(string id, string idalu, double total)
        {

            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "insertarfacturaproduc";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@IDalumno", idalu);
            comando.Parameters.AddWithValue("@total", total);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            c.CERRARCONEXION();

        }
        
        public void ingreso(DataGridView a, Label idfactura)
        {
            c.ABRICONEXION();
            for (int i = 0; i < a.RowCount; i++)
            {

                SqlCommand comando = null;
                if (validarmes(a.Rows[i].Cells[1].Value.ToString()))
                {
                    comando = new SqlCommand("Insert into Mensualidad values (@mes,@factura)", c.conexion);

                    comando.Parameters.Add(new SqlParameter("@mes", SqlDbType.Char));
                    comando.Parameters["@mes"].Value = a.Rows[i].Cells[0].Value.ToString();
                    comando.Parameters.Add(new SqlParameter("@factura", SqlDbType.Char));
                    comando.Parameters["@factura"].Value = idfactura.Text;


                }
                else if (a.Rows[i].Cells[1].Value.ToString().Contains("Matricula"))
                {
                    comando = new SqlCommand("Insert into Matricula values (@Id,@factura)", c.conexion);

                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char));
                    comando.Parameters["@Id"].Value = a.Rows[i].Cells[0].Value.ToString();
                    comando.Parameters.Add(new SqlParameter("@factura", SqlDbType.Char));
                    comando.Parameters["@factura"].Value = idfactura.Text;

                }
                else
                {
                    comando = new SqlCommand("Insert into Detalle_Venta values (@factura,@Producto)", c.conexion);

                    comando.Parameters.Add(new SqlParameter("@factura", SqlDbType.Char));
                    comando.Parameters["@factura"].Value = idfactura.Text;
                    comando.Parameters.Add(new SqlParameter("@Producto", SqlDbType.Char));
                    comando.Parameters["@Producto"].Value = a.Rows[i].Cells[0].Value.ToString();


                }
                comando.ExecuteNonQuery();
            }
            c.CERRARCONEXION();
        }
        public bool validarmes(string a)
        {
            bool n = false;
            if (a == "Enero" || a == "Febrero" || a == "Marzo" || a == "Abril" || a == "Mayo" || a == "Junio" || a == "Julio" || a == "Agosto" || a == "Septiembre" || a == "Octubre" || a == "Noviembre" || a == "Diciembre")
            {
                n = true;
            }
            return n;
        }
        
    }
}
