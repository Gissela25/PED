using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Sistema_de_Facturacion_Amigos
{
    public partial class Splash : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=master;Integrated Security=True");
        Conexion c = new Conexion();
        public Splash()
        {
            InitializeComponent();
            Timer.Enabled = true;
            crearBase();
        }
        int contador=0;
        
        private void Timer_Tick_1(object sender, EventArgs e)
        {
            contador += 2;
            porcentaje.Text = "Iniciando... " + contador + "%";

            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                Timer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void crearBase()
        {
            string CrearDB = " Create Database " + "SFA_2019";

            string tAlumnos = "USE SFA_2019;" +
                "CREATE TABLE Alumnos(" +
                "ID_Alumno char(8) not null," +
                "Nombre varchar(20) not null," +
                "Apellido varchar(20) not null," +
                "Apellido2 varchar(20) not null);";

            string tUsuario = "USE SFA_2019;" +
              "CREATE TABLE Usuario(" +
              "ID_Usuario char(8) primary key not null," +
              "Username varchar(20) not null," +
              "Password varchar(20) not null)";


            string tFactura = "USE SFA_2019;" +
                "CREATE TABLE Factura(" +
                "ID_Factura char(10) not null," +
                "ID_Alumno char(8) not null," +
                "ID_Usuario char(8) not null," +
                "Fecha date," +
                "Mora bit," +
                "Total money);";

            string Mensualidad = "USE SFA_2019;" +
                "CREATE TABLE MENSUALIDAD(" +
                "ID_mes char(6) not null," +
                "ID_Factura char(10) not null);";


            string Matricula = "USE SFA_2019;" +
                "CREATE TABLE MATRICULA(" +
                "ID_Matricula char(7) not null," +
                "ID_Factura char(10) not null);";


            string Producto = "USE SFA_2019;" +
                "CREATE TABLE PRODUCTO(" +
                "ID_Producto char(4) not null," +
                "Nombre_Producto varchar(20) not null," +
                "Cantidad int not null," +
                "Precio smallmoney not null);";



            string Detalleventa = "USE SFA_2019;" +
                "CREATE TABLE DETALLE_VENTA(" +
                "ID_Factura char(10) not null," +
                "ID_Producto char(4) not null);";

          
            string alter = " Alter table Alumnos " +
                " add constraint PK_Alumnos " +
                " Primary key (ID_Alumno) ";

            string alterf = " Alter table Factura " +
                " add constraint PK_Factura " +
                " Primary key (ID_Factura) ";


            string alterpro = " Alter table Producto " +
                " add constraint PK_Producto " +
                " Primary key (ID_Producto) ";

            string fdetalle = " Alter table Detalle_Venta " +
                " add constraint FK_Factura " +
                " foreign key (ID_Factura) References Factura(ID_Factura) " +
                " on update cascade ";

            string fventa = " Alter table Detalle_Venta " +
                " add constraint FK_Producto " +
                " foreign key (ID_Producto) References PRODUCTO(ID_Producto) " +
                " on update cascade ";

            string ffactura = " Alter table Factura " +
                " add constraint FK_alumno " +
                " foreign key (ID_Alumno) References Alumnos(ID_Alumno) " +
                " on update cascade ";

                string fffactura = " Alter table Factura " +
                " add constraint FK_usuario " +
                " foreign key (ID_Usuario) References Usuario(ID_Usuario) "+
                " on update cascade ";

            string fmatricula = " Alter table Matricula " +
                " add constraint FK_mFactura " +
                " foreign key (ID_Factura) References Factura(ID_Factura) "+
                " on update cascade "; ;


            string fMensualidad = " alter table Mensualidad " +
                " add constraint FK_mmFactura " +
                " foreign key (ID_Factura) References Factura(ID_Factura) " +
                " on update cascade ";


            string resti1 = " alter table Factura " +
                " add constraint df_Fecha " +
                " default getdate() for Fecha ";

            string resti3 = " alter table Producto " +
                " add constraint ck_cantidad " +
                " check (cantidad>0) ";

            string resti4 = " alter table Producto " +
                " add constraint ck_precio " +
                " check (precio>0) ";

            string procea = " create procedure MostrarAlumnos " +
                " as " +
                " select * from alumnos ";

            string procein = " create procedure InsertarAlumnos " +
                " @ID char(8), " +
                " @nombre varchar(20), " +
                " @apellido varchar(20), " +
                " @apellido2 varchar(20) " +
                " as " +
                " Insert into alumnos values " +
                " (@ID,@nombre,@apellido,@apellido2) ";

            string proceed = " create procedure editaralumnos " +
                " @ID char(8), " +
                " @nombre varchar(20), " +
                " @apellido varchar(20), " +
                " @apellido2 varchar(20) " +
                " as " +
                " update alumnos set nombre = @nombre, apellido=@apellido , @apellido2=@apellido2 where ID_alumno = @id";

            string procemostrarp = " create procedure mostrarproductos " +
                " as " +
                " select * from producto ";

            string proceinp = " create procedure Insertarproducto " +
                " @ID char(4), " +
                " @nombre varchar(20), " +
                " @cantidad int, " +
                " @precio smallmoney " +
                " as " +
                " insert into producto values " +
                " (@ID,@nombre,@cantidad,@precio) ";

            string proedi = " create procedure editarproductos " +
                " @ID char(4), " +
                " @nombre varchar(20), " +
                " @cantidad int, " +
                " @precio smallmoney " +
                " as " +
                " update producto set Nombre_producto = @nombre, cantidad =@cantidad, precio =@precio where ID_Producto = @ID";

            string prolla = " create procedure llamarproducto " +
                " as " +
                " select Nombre_producto from producto ";

            string proinserfactu = " create procedure insertarfacturaproduc " +
                " @ID char(10), " +
                " @IDalumno char(8)," +
                " @total money " +
                " as " +
                " insert into factura(ID_factura,ID_Alumno,Total) values " +
                " (@ID,@IDAlumno,@total) ";


            string cadena = "Insert into Usuario ([ID_Usuario], [Username], [Password]) values('1','admin','12345')";

            SqlCommand cmd = new SqlCommand(CrearDB, conexion);
            SqlCommand cmd2 = new SqlCommand(tAlumnos, conexion);
            SqlCommand cm32 = new SqlCommand(tUsuario, conexion);
            SqlCommand cm3 = new SqlCommand(tFactura, conexion);
            SqlCommand cm4 = new SqlCommand(Mensualidad, conexion);

            SqlCommand cm6 = new SqlCommand(Matricula, conexion);
            SqlCommand cm7 = new SqlCommand(Producto,conexion);
            SqlCommand cm8 = new SqlCommand(Detalleventa, conexion);
            SqlCommand cm9 = new SqlCommand(alter,conexion);
            SqlCommand cm10 = new SqlCommand(alterf,conexion);

            SqlCommand cm13 = new SqlCommand(alterpro, conexion);
            
            SqlCommand cm14 = new SqlCommand(fdetalle, conexion);
            SqlCommand cm15 = new SqlCommand(fventa, conexion);
            SqlCommand cm16 = new SqlCommand(ffactura, conexion);
            SqlCommand cm34 = new SqlCommand(fffactura, conexion);
            SqlCommand cm17 = new SqlCommand(fmatricula, conexion);

            SqlCommand cm18 = new SqlCommand(fMensualidad, conexion);


            SqlCommand cm20 = new SqlCommand(resti1, conexion);

            SqlCommand cm22 = new SqlCommand(resti3, conexion);
            SqlCommand cm23 = new SqlCommand(resti4, conexion);
            SqlCommand cm24 = new SqlCommand(procea, conexion);
            SqlCommand cm25 = new SqlCommand(procein, conexion);
            SqlCommand cm26 = new SqlCommand(proceed, conexion);
            SqlCommand cm27 = new SqlCommand(procemostrarp, conexion);
            SqlCommand cm28 = new SqlCommand(proceinp, conexion);
            SqlCommand cm29 = new SqlCommand(proedi, conexion);
            SqlCommand cm30 = new SqlCommand(prolla, conexion);
            SqlCommand cm31 = new SqlCommand(proinserfactu, conexion);
            SqlCommand cm35 = new SqlCommand(cadena, conexion);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
             
                cmd2.ExecuteNonQuery();
                cm32.ExecuteNonQuery();
                cm3.ExecuteNonQuery();
                cm4.ExecuteNonQuery();

                cm6.ExecuteNonQuery();
                cm7.ExecuteNonQuery();
                cm8.ExecuteNonQuery();
                
                cm9.ExecuteNonQuery();
                cm10.ExecuteNonQuery();

                cm13.ExecuteNonQuery();
                cm14.ExecuteNonQuery();
                cm15.ExecuteNonQuery();
                cm16.ExecuteNonQuery();
                cm34.ExecuteNonQuery();
                cm17.ExecuteNonQuery();
                cm18.ExecuteNonQuery();
                

                cm20.ExecuteNonQuery();

                cm22.ExecuteNonQuery();
                cm23.ExecuteNonQuery();
                cm24.ExecuteNonQuery();
                cm25.ExecuteNonQuery();
                cm26.ExecuteNonQuery();
                cm27.ExecuteNonQuery();
                cm28.ExecuteNonQuery();
                cm29.ExecuteNonQuery();
                cm30.ExecuteNonQuery();
                cm31.ExecuteNonQuery();
                cm35.ExecuteNonQuery();



                MessageBox.Show("Base de datos" +
                    "\nCreada correctamente...", "Generar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch/*(/*Exception ex)*//***//*/*/
            {
                //MessageBox.Show(ex.Message,
                // "error al crear la bas",
                // MessageBoxButtons.OK,
                // MessageBoxIcon.Error);
            }
            conexion.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
