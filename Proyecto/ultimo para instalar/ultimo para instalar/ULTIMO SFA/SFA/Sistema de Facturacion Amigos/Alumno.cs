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
    
    public class Alumno:Conexion
    {
        private Conexion c = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        private String codigo;


        public string Codigo(string l1, string l2)
        {
            DateTime año = DateTime.Now;
            int año2 = año.Year - 2000, prueba = 0;
            SqlCommand cuenta = new SqlCommand("select COUNT(ID_Alumno) as total from Alumnos WHERE ID_Alumno like '__" + año2 + "%'", c.conexion);
            comando.Connection = c.ABRICONEXION();
            leer = cuenta.ExecuteReader();
            if (leer.Read() == true)
            {
                prueba = int.Parse(leer["total"].ToString()) + 1;
            }
            c.CERRARCONEXION();
            return codigo = l1 + l2 + año2 + prueba.ToString("000");
        }
        public DataTable Mostrar()
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "MostrarAlumnos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            c.CERRARCONEXION();
            return tabla;
        }
        public void insertar(string id, string nombre, string apellido, string apellido2)
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "InsertarAlumnos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@apellido2", apellido2);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            c.CERRARCONEXION();
        }
        public void editar(string id, string nombre, string apellido, string apellido2)
        {
            comando.Connection = c.ABRICONEXION();
            comando.CommandText = "editaralumnos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@apellido2", apellido2);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            c.CERRARCONEXION();
        }

        


    }
}
