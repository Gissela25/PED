using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Sistema_de_Facturacion_Amigos
{
    public partial class Menu : Form
    {
        public SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True");
        Conexion c = new Conexion();
        public Menu()
        {
            InitializeComponent();
            AbrirFormhijo(new contenedorInicio());
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void cerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de salir?", "ALERTA¡¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconoMinimizar.Visible = false;
            iconoMaximizar.Visible = true;
        }

        private void maxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconoMaximizar.Visible = false;
            iconoMinimizar.Visible = true;
        }
        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void AbrirFormhijo(object formhijo)
        {
            if(this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void logoBarra()
        {
            contenedorInicio ci = new contenedorInicio();
            if (logo.Visible == false)
            {
                barraTitulo.Height = 45;
                logo.Visible = true;
            }
        }
        private void btnAlumno_Click(object sender, EventArgs e)
        {
            logoBarra();
            AbrirFormhijo(new Form1());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            logoBarra();
            AbrirFormhijo(new Productos());
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            logoBarra();
            AbrirFormhijo(new buscar());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CrearDB = " Create Database " + "SFA_2019";

            string tAlumnos = "USE SFA_2019;" +
                "CREATE TABLE Alumnos(" +
                "ID_Alumno char(8) not null," +
                "Nombre varchar(20) not null," +
                "Apellido varchar(20) not null," +
                "Apellido2 varchar(20) not null);";

            string tFactura = 
                "CREATE TABLE Factura(" +
                "ID_Factura char(10) not null," +
                "ID_Alumno char(8) not null," +
                "Fecha date," +
                "Mora bit," +
                "Total money);";

            string Mensualidad =
                "CREATE TABLE MENSUALIDAD(" +
                "ID_mes char(6) not null," +
                "ID_Factura char(10) not null);";

            string Matricula = "USE SFA_2019;" +
                "CREATE TABLE MATRICULA(" +
                "ID_Matricula char(6) not null," +
                "ID_Factura char(10) not null);";

            string Producto =
                "CREATE TABLE PRODUCTO(" +
                "ID_Producto char(4) not null," +
                "Nombre_Producto varchar(20) not null," +
                "Cantidad int not null," +
                "Precio smallmoney not null);";

            string Detalleventa = 
                "CREATE TABLE DETALLE_VENTA(" +
                "ID_Factura char(10) not null," +
                "ID_Producto char(4) not null);";

            string alter = " Alter table Alumnos " +
                " add constraint PK_Alumnos " +
                " Primary key (ID_Alumno) ";

            string alterf = " Alter table Factura " +
                " add constraint PK_Factura " +
                " Primary key (ID_Factura) ";

            string alterm = " Alter table Matricula " +
                " add constraint PK_Matricula " +
                " Primary Key (ID_Matricula) ";

            string altermes = " Alter table Mes " +
                " add constraint PK_Mes " +
                " Primary key (ID_Mes) ";

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

            string fmatricula = " ALter table Matricula " +
                " add constraint FK_mFactura " +
                " foreign key (ID_Factura) References Factura(ID_Factura) ";

            string fMensualidad = " Alter table Mensualidad " +
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

            string proedi = " create procedure edtarproductosb " +
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

            string procedeta = " create procedure insertardetalleventas" +
                " @idf char(10)," +
                " @idproducto char(4)" +
                " as " +
                " insert into Detalle_venta values " +
                " (@idf,@idproducto) ";

            SqlCommand cmd = new SqlCommand(CrearDB, c.conexion);
            SqlCommand cmd2 = new SqlCommand(tAlumnos, c.conexion);
            SqlCommand cm3 = new SqlCommand(tFactura, c.conexion);
            SqlCommand cm4 = new SqlCommand(Mensualidad, c.conexion);
            SqlCommand cm6 = new SqlCommand(Matricula, c.conexion);
            SqlCommand cm7 = new SqlCommand(Producto, c.conexion);
            SqlCommand cm8 = new SqlCommand(Detalleventa, c.conexion);
            SqlCommand cm9 = new SqlCommand(alter, c.conexion);
            SqlCommand cm10 = new SqlCommand(alterf, c.conexion);
            SqlCommand cm11 = new SqlCommand(alterm, c.conexion);
            SqlCommand cm12 = new SqlCommand(altermes, c.conexion);
            SqlCommand cm13 = new SqlCommand(alterpro, c.conexion);
            SqlCommand cm14 = new SqlCommand(fdetalle, c.conexion);
            SqlCommand cm15 = new SqlCommand(fventa, c.conexion);
            SqlCommand cm16 = new SqlCommand(ffactura, c.conexion);
            SqlCommand cm17 = new SqlCommand(fmatricula, c.conexion);
            SqlCommand cm18 = new SqlCommand(fMensualidad, c.conexion);
            SqlCommand cm20 = new SqlCommand(resti1, c.conexion);
            SqlCommand cm22 = new SqlCommand(resti3, c.conexion);
            SqlCommand cm23 = new SqlCommand(resti4, c.conexion);
            SqlCommand cm24 = new SqlCommand(procea, c.conexion);
            SqlCommand cm25 = new SqlCommand(procein, c.conexion);
            SqlCommand cm26 = new SqlCommand(proceed, c.conexion);
            SqlCommand cm27 = new SqlCommand(procemostrarp, c.conexion);
            SqlCommand cm28 = new SqlCommand(proceinp, c.conexion);
            SqlCommand cm29 = new SqlCommand(proedi, c.conexion);
            SqlCommand cm30 = new SqlCommand(prolla, c.conexion);
            SqlCommand cm31 = new SqlCommand(proinserfactu, c.conexion);
            SqlCommand cm32 = new SqlCommand(procedeta, c.conexion);

            try
            {
                c.conexion.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cm3.ExecuteNonQuery();
                cm4.ExecuteNonQuery();
                cm6.ExecuteNonQuery();
                cm7.ExecuteNonQuery();
                cm8.ExecuteNonQuery();
                cm9.ExecuteNonQuery();
                cm10.ExecuteNonQuery();
                cm11.ExecuteNonQuery();
                cm12.ExecuteNonQuery();
                cm13.ExecuteNonQuery();
                cm14.ExecuteNonQuery();
                cm15.ExecuteNonQuery();
                cm16.ExecuteNonQuery();
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
                cm32.ExecuteNonQuery();

                MessageBox.Show("Base de datos" +
                    "\nCreada correctamente...", "Generar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "error al crear la bas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            AbrirFormhijo(new contenedorInicio());
            logo.Visible = false;
        }

        private void barraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
