namespace Ejercicio2_parcial_ped
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lstPila2 = new System.Windows.Forms.ListBox();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstContenedor = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGreen;
            this.label1.Location = new System.Drawing.Point(524, 536);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 83);
            this.label1.TabIndex = 17;
            this.label1.Text = "Pila usada para extraer elementos de pila principal para poder eliminar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // lstPila2
            // 
            this.lstPila2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPila2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPila2.FormattingEnabled = true;
            this.lstPila2.ItemHeight = 25;
            this.lstPila2.Location = new System.Drawing.Point(524, 216);
            this.lstPila2.Margin = new System.Windows.Forms.Padding(6);
            this.lstPila2.Name = "lstPila2";
            this.lstPila2.ScrollAlwaysVisible = true;
            this.lstPila2.Size = new System.Drawing.Size(294, 302);
            this.lstPila2.TabIndex = 16;
            // 
            // txtDato
            // 
            this.txtDato.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDato.Location = new System.Drawing.Point(524, 115);
            this.txtDato.Margin = new System.Windows.Forms.Padding(6);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(292, 33);
            this.txtDato.TabIndex = 15;
            this.txtDato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(524, 163);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(296, 44);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar Contenedor";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(32, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 52);
            this.button1.TabIndex = 13;
            this.button1.Text = "Agregar Contenedor";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstContenedor
            // 
            this.lstContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstContenedor.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstContenedor.FormattingEnabled = true;
            this.lstContenedor.ItemHeight = 25;
            this.lstContenedor.Location = new System.Drawing.Point(32, 166);
            this.lstContenedor.Margin = new System.Windows.Forms.Padding(6);
            this.lstContenedor.Name = "lstContenedor";
            this.lstContenedor.ScrollAlwaysVisible = true;
            this.lstContenedor.Size = new System.Drawing.Size(294, 427);
            this.lstContenedor.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(866, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPila2);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstContenedor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstPila2;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstContenedor;
    }
}

