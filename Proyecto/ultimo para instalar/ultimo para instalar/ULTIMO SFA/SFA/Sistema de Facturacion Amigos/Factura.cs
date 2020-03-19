using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Drawing;

namespace Sistema_de_Facturacion_Amigos
{
    public partial class Factura : Form
    {
        private Button button1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox2;
        private Button button2;
        private Label id;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn ID_Producto;
        private DataGridViewTextBoxColumn Nombre_producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnita;
        private DataGridViewTextBoxColumn Total;
        private Button Matricula;
        private Button Mensualidad;
        private Button Vaciar;
        private Button borrar;
        private Label label4;
        private Button agrMen;
        public Label label5;
        private PrintDialog printDialog1;
        CFactura f = new CFactura();
        
        //Necesario Para Dibujar imagen
        Image imagen;
        private Label label6;
        private Label label7;
        private Label label8;
        public Label label9;
        Rectangle rect;         
        public Factura()
        {
            InitializeComponent();          

            //Dibujando Imagen
            imagen = Sistema_de_Facturacion_Amigos.Properties.Resources.logo_sin_fondo_;
            rect = new Rectangle(75, 75, 125, 125);
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.Button();
            this.Mensualidad = new System.Windows.Forms.Button();
            this.Vaciar = new System.Windows.Forms.Button();
            this.borrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.agrMen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(501, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(786, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Producto,
            this.Nombre_producto,
            this.Cantidad,
            this.PrecioUnita,
            this.Total});
            this.dataGridView1.Location = new System.Drawing.Point(12, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(874, 456);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID_Producto
            // 
            this.ID_Producto.HeaderText = "Codigo";
            this.ID_Producto.Name = "ID_Producto";
            // 
            // Nombre_producto
            // 
            this.Nombre_producto.HeaderText = "Detalle";
            this.Nombre_producto.Name = "Nombre_producto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // PrecioUnita
            // 
            this.PrecioUnita.HeaderText = "Precio Unitario";
            this.PrecioUnita.Name = "PrecioUnita";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total: $";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(544, 81);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Ocutubre",
            "Noviembre",
            "Diciembre"});
            this.comboBox2.Location = new System.Drawing.Point(638, 114);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(126, 21);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(770, 600);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(21, 16);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(54, 13);
            this.id.TabIndex = 12;
            this.id.Text = "IDFactura";
            // 
            // Matricula
            // 
            this.Matricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Matricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Matricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Matricula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Matricula.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Matricula.FlatAppearance.BorderSize = 0;
            this.Matricula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.Matricula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.Matricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Matricula.ForeColor = System.Drawing.Color.White;
            this.Matricula.Location = new System.Drawing.Point(699, 80);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(75, 23);
            this.Matricula.TabIndex = 14;
            this.Matricula.Text = "Matricula";
            this.Matricula.UseVisualStyleBackColor = false;
            this.Matricula.Click += new System.EventHandler(this.Matricula_Click);
            // 
            // Mensualidad
            // 
            this.Mensualidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mensualidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Mensualidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Mensualidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Mensualidad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Mensualidad.FlatAppearance.BorderSize = 0;
            this.Mensualidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.Mensualidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.Mensualidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mensualidad.ForeColor = System.Drawing.Color.White;
            this.Mensualidad.Location = new System.Drawing.Point(618, 81);
            this.Mensualidad.Name = "Mensualidad";
            this.Mensualidad.Size = new System.Drawing.Size(75, 23);
            this.Mensualidad.TabIndex = 15;
            this.Mensualidad.Text = "Mensualidad";
            this.Mensualidad.UseVisualStyleBackColor = false;
            this.Mensualidad.Click += new System.EventHandler(this.Mensualidad_Click);
            // 
            // Vaciar
            // 
            this.Vaciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Vaciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Vaciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Vaciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Vaciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.Vaciar.FlatAppearance.BorderSize = 0;
            this.Vaciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.Vaciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.Vaciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vaciar.ForeColor = System.Drawing.Color.White;
            this.Vaciar.Location = new System.Drawing.Point(24, 605);
            this.Vaciar.Name = "Vaciar";
            this.Vaciar.Size = new System.Drawing.Size(75, 23);
            this.Vaciar.TabIndex = 16;
            this.Vaciar.Text = "Vaciar";
            this.Vaciar.UseVisualStyleBackColor = false;
            this.Vaciar.Click += new System.EventHandler(this.Vaciar_Click);
            // 
            // borrar
            // 
            this.borrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.borrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.borrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.borrar.FlatAppearance.BorderSize = 0;
            this.borrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.borrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borrar.ForeColor = System.Drawing.Color.White;
            this.borrar.Location = new System.Drawing.Point(105, 605);
            this.borrar.Name = "borrar";
            this.borrar.Size = new System.Drawing.Size(75, 23);
            this.borrar.TabIndex = 17;
            this.borrar.Text = "Borrar";
            this.borrar.UseVisualStyleBackColor = false;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "IDAlumno:";
            // 
            // agrMen
            // 
            this.agrMen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.agrMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.agrMen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.agrMen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agrMen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(46)))), ((int)(((byte)(111)))));
            this.agrMen.FlatAppearance.BorderSize = 0;
            this.agrMen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.BlueViolet;
            this.agrMen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.BlueViolet;
            this.agrMen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agrMen.ForeColor = System.Drawing.Color.White;
            this.agrMen.Location = new System.Drawing.Point(770, 112);
            this.agrMen.Name = "agrMen";
            this.agrMen.Size = new System.Drawing.Size(116, 23);
            this.agrMen.TabIndex = 20;
            this.agrMen.Text = "Agregar Mensualidad";
            this.agrMen.UseVisualStyleBackColor = false;
            this.agrMen.Visible = false;
            this.agrMen.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "label5";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(704, 605);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "__";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(83, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Nombre: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "label9";
            // 
            // Factura
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(898, 633);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.agrMen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.borrar);
            this.Controls.Add(this.Vaciar);
            this.Controls.Add(this.Mensualidad);
            this.Controls.Add(this.Matricula);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Factura";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            cargarCombobox();
            label6.Text = f.generar();
        }
        private void cargarCombobox()
        {
            try
            {
                SqlCommand carg = new SqlCommand("SELECT Nombre_Producto FROM producto", f.conexion);
                f.ABRICONEXION();
                SqlDataReader ver = carg.ExecuteReader();
                while (ver.Read() == true)
                {
                    comboBox1.Items.Add(ver[0]);
                }
                f.CERRARCONEXION();
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); } 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pro = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            
                label2.Text = f.agregarPrecio(pro);     
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string selc = comboBox1.Items[comboBox1.SelectedIndex].ToString(), cod, can, pre;
                double to;

                cod = f.agregarIDProducto(selc);
                can = numericUpDown1.Value.ToString();
                pre = label2.Text;
                to = double.Parse(can) * double.Parse(pre);
                dataGridView1.Rows.Add(cod, selc, can, pre, to);
                double total = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Total"].Value);
                }
                label7.Text = Convert.ToString(total);
            }
            catch
            {
            }
        }
        
        private void Matricula_Click(object sender, EventArgs e)
        {
            if (f.ValMatricula(label5.Text))
            {
                string cod, de;
                double can = 1, pre = 40, to;
                cod = f.CodMatricula();
                de = f.Matricula();
                to = pre;
                dataGridView1.Rows.Add(cod, de, can, pre, to);
                Matricula.Visible = false;
            }
            double total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["Total"].Value);
            }
            label7.Text = Convert.ToString(total);
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            DateTime año = DateTime.Now;                       
            int fill = dataGridView1.CurrentRow.Index;
            string a= dataGridView1.Rows[fill].Cells[1].Value.ToString(), ma= "Matricula "+ año.Year;
            if (a == "Enero")
            {
                comboBox2.Items.Insert(0, a);
            }
            else if (a == "Febrero")
            {
                comboBox2.Items.Insert(1, a);
            }
            else if (a == "Marzo")
            {
                comboBox2.Items.Insert(2, a);
            }
            else if (a == "Abril")
            {
                comboBox2.Items.Insert(3, a);
            }
            else if (a == "Mayo")
            {
                comboBox2.Items.Insert(4, a);
            }
            else if (a == "Junio")
            {
                comboBox2.Items.Insert(5, a);
            }
            else if (a == "Julio")
            {
                comboBox2.Items.Insert(6, a);
            }
            else if (a == "Agosto")
            {
                comboBox2.Items.Insert(7, a);
            }
            else if (a == "Septiembre")
            {
                comboBox2.Items.Insert(8, a);
            }
            else if (a == "Octubre")
            {
                comboBox2.Items.Insert(9, a);
            }
            else if (a == "Noviembre")
            {
                comboBox2.Items.Add(a);
            }
            
            else if (a == ma ) { Matricula.Visible = true; }
            dataGridView1.Rows.RemoveAt(fill);
            double total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDouble(row.Cells["Total"].Value);
            }
            label7.Text = Convert.ToString(total);
        }

        private void Vaciar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            comboBox2.ResetText();
            if (Matricula.Visible == false) { Matricula.Visible = true; }
            meses();

        }
        private void meses()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Enero");
            comboBox2.Items.Add("Febrero");
            comboBox2.Items.Add("Marzo");
            comboBox2.Items.Add("Abril");
            comboBox2.Items.Add("Mayo");
            comboBox2.Items.Add("Junio");
            comboBox2.Items.Add("Julio");
            comboBox2.Items.Add("Agosto");
            comboBox2.Items.Add("Septiembre");
            comboBox2.Items.Add("Octubre");
            comboBox2.Items.Add("Noviembre");
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            
            if (f.ValMesualidad(comboBox2,label5))
            {
                string selc = comboBox2.Items[comboBox2.SelectedIndex].ToString(), cod1, cod2, de;
                int can = 1, pre = 31, to, p = comboBox2.SelectedIndex + 1;
                cod1 = "M" + selc.Substring(0, 1);
                cod2 = f.CodMensu(cod1);
                de = selc.ToString();
                label1.Text = p.ToString();
                to = pre + f.mora(selc,p);
                dataGridView1.Rows.Add(cod2, de, can, pre, to);
                double total = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    total += Convert.ToDouble(row.Cells["Total"].Value);
                }
                label7.Text = Convert.ToString(total);                
                comboBox2.Items.Remove(selc);
                
            }
            
        }

        private void Mensualidad_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            agrMen.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.insertarfacturaproducto(label6.Text, label5.Text, double.Parse(label7.Text));
            f.ingreso(dataGridView1, label6);

            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.Landscape = false;
            doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate(object ev, PrintPageEventArgs ep)
            {
                const int DSV_ALTO = 35;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                //ORIGINAL

                //INTENTO DE MUESTRA DE NOMBRE
                string nombre = "Venta a nombre de: ";
                ep.Graphics.DrawString(nombre, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, left + 475, top);

                
                string completo = label9.Text;
                ep.Graphics.DrawString(completo, new Font("Segoe UI", 12), Brushes.Black, left + 475, top + 35);
                //FIN

                string dir = "CALLE ROOSVELT N 60";
                ep.Graphics.DrawString(dir, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;
                string dir1 = "COL. LAS FLORES";
                ep.Graphics.DrawString(dir1, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;
                string dir2 = "SOYAPANGO.    TEL: 2227-2186   ";
                ep.Graphics.DrawString(dir2, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;

                ep.Graphics.DrawImage(imagen, rect);
                top += DSV_ALTO + 20;


                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Violet, left, top);
                    left += col.Width;

                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 10), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DSV_ALTO;

                }

                top += DSV_ALTO + 50;

                string colector = "FIRMA COLECTOR____________________________";
                left = ep.MarginBounds.Left;
                ep.Graphics.DrawString(colector, new Font("Segoe UI", 12), Brushes.Black, left, top);
                top += DSV_ALTO + 25;

                //COPIA

                //INTENTO DE MUESTRA DE NOMBRE

                ep.Graphics.DrawString(nombre, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, left + 475, top);
                top += DSV_ALTO;


                ep.Graphics.DrawString(completo, new Font("Segoe UI", 12), Brushes.Black, left + 475, top);
                //FIN
                ep.Graphics.DrawString(dir, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;

                ep.Graphics.DrawString(dir1, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;

                ep.Graphics.DrawString(dir2, new Font("Segoe UI", 14, FontStyle.Bold), Brushes.Black, left + 100, top);
                top += DSV_ALTO;




                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    ep.Graphics.DrawString(col.HeaderText, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Violet, left, top);
                    left += col.Width;

                }
                left = ep.MarginBounds.Left;
                ep.Graphics.FillRectangle(Brushes.Black, left, top + 40, ep.MarginBounds.Right - left, 3);
                top += 43;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index == dataGridView1.RowCount) break;
                    left = ep.MarginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        ep.Graphics.DrawString(Convert.ToString(cell.Value), new Font("Segoe UI", 10), Brushes.Black, left, top + 4);
                        left += cell.OwningColumn.Width;
                    }
                    top += DSV_ALTO;

                }

                top += DSV_ALTO + 50;
                left = ep.MarginBounds.Left;
                ep.Graphics.DrawString(colector, new Font("Segoe UI", 12), Brushes.Black, left, top);
                top += DSV_ALTO;

            };
            ppd.ShowDialog();

            buscar ff = new buscar();
            ff.TopLevel = false;
            ff.Dock = DockStyle.Fill;
            this.Controls.Add(ff);
            this.Tag = ff;
            ff.BringToFront();
            ff.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sele = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                numericUpDown1.Maximum = int.Parse(f.maxProducto(sele));
            }
            catch
            {
                MessageBox.Show("No hay mas poducto");
            }
            
        }
    }
}
