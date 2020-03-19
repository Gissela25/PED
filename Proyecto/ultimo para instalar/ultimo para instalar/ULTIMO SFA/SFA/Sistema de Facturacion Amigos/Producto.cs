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
    class Producto:Conexion
    {
        private Conexion c = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public string codi;
        public string generar()
        {
            int prueba = 0;
            SqlCommand cuenta = new SqlCommand("select COUNT(ID_Producto) as total from PRODUCTO", c.conexion);
            comando.Connection = c.ABRICONEXION();
            leer = cuenta.ExecuteReader();
            if (leer.Read() == true)
            {
                prueba = int.Parse(leer["total"].ToString()) + 1;
            }
            c.CERRARCONEXION();
            return codi = prueba.ToString("0000");
        }

        public DataTable Mostrar()
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "Mostrarproductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            c.CERRARCONEXION();
            return tabla;
        }
        public void insertar(string id, string nombre, int cantidad, double precio)
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "Insertarproducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            c.CERRARCONEXION();
        }
        public void editar(string id, string nombre, int cantidad, double precio)
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "editarproductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            c.CERRARCONEXION();
        }
    }
}
