namespace Interfaz
{
    partial class RegistroDeGastosUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nroMonto = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_Monedas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(129, 172);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 19;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(129, 46);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(147, 20);
            this.dateFecha.TabIndex = 18;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(129, 145);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(147, 21);
            this.cboCategoria.TabIndex = 17;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(129, 16);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(147, 20);
            this.txtDescripcion.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descripción";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(14, 240);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(282, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(317, 173);
            this.listBox1.TabIndex = 20;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // nroMonto
            // 
            this.nroMonto.DecimalPlaces = 2;
            this.nroMonto.InterceptArrowKeys = false;
            this.nroMonto.Location = new System.Drawing.Point(129, 105);
            this.nroMonto.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nroMonto.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nroMonto.Name = "nroMonto";
            this.nroMonto.Size = new System.Drawing.Size(147, 20);
            this.nroMonto.TabIndex = 25;
            this.nroMonto.ValueChanged += new System.EventHandler(this.nroMonto_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Moneda";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cbo_Monedas
            // 
            this.cbo_Monedas.FormattingEnabled = true;
            this.cbo_Monedas.Location = new System.Drawing.Point(129, 76);
            this.cbo_Monedas.Name = "cbo_Monedas";
            this.cbo_Monedas.Size = new System.Drawing.Size(147, 21);
            this.cbo_Monedas.TabIndex = 27;
            this.cbo_Monedas.SelectedIndexChanged += new System.EventHandler(this.cbo_Monedas_SelectedIndexChanged);
            // 
            // RegistroDeGastosUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbo_Monedas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nroMonto);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Name = "RegistroDeGastosUI";
            this.Size = new System.Drawing.Size(602, 302);
            this.Load += new System.EventHandler(this.RegistroDeGastosUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown nroMonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_Monedas;
    }
}
