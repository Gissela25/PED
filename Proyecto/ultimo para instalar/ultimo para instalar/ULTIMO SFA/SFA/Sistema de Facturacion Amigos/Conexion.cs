using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_de_Facturacion_Amigos
{
     public class Conexion
    {
         public SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=SFA_2019;Integrated Security=True");
        public SqlConnection ABRICONEXION()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;           
        }
        public SqlConnection CERRARCONEXION()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            conexion.Close();
            return conexion;
        }

    }
}
