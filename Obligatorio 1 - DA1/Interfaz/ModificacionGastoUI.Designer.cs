namespace Interfaz
{
    partial class ModificacionGastoUI
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
            this.lstGastos = new System.Windows.Forms.ListBox();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelModificacion = new System.Windows.Forms.Panel();
            this.nroMonto = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_Moneda = new System.Windows.Forms.ComboBox();
            this.panelModificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lstGastos
            // 
            this.lstGastos.FormattingEnabled = true;
            this.lstGastos.HorizontalScrollbar = true;
            this.lstGastos.Location = new System.Drawing.Point(3, 55);
            this.lstGastos.Name = "lstGastos";
            this.lstGastos.Size = new System.Drawing.Size(358, 186);
            this.lstGastos.TabIndex = 0;
            this.lstGastos.SelectedIndexChanged += new System.EventHandler(this.lstGastos_SelectedIndexChanged);
            // 
            // dateFecha
            // 
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(127, 153);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(147, 20);
            this.dateFecha.TabIndex = 26;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(127, 177);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(147, 21);
            this.cboCategoria.TabIndex = 25;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(127, 70);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(147, 20);
            this.txtDescripcion.TabIndex = 23;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Categoria";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fecha";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Monto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Descripción";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelModificacion
            // 
            this.panelModificacion.Controls.Add(this.cbo_Moneda);
            this.panelModificacion.Controls.Add(this.label6);
            this.panelModificacion.Controls.Add(this.nroMonto);
            this.panelModificacion.Controls.Add(this.button1);
            this.panelModificacion.Controls.Add(this.txtDescripcion);
            this.panelModificacion.Controls.Add(this.dateFecha);
            this.panelModificacion.Controls.Add(this.label1);
            this.panelModificacion.Controls.Add(this.cboCategoria);
            this.panelModificacion.Controls.Add(this.label2);
            this.panelModificacion.Controls.Add(this.label3);
            this.panelModificacion.Controls.Add(this.label4);
            this.panelModificacion.Location = new System.Drawing.Point(367, 3);
            this.panelModificacion.Name = "panelModificacion";
            this.panelModificacion.Size = new System.Drawing.Size(287, 272);
            this.panelModificacion.TabIndex = 27;
            this.panelModificacion.Visible = false;
            this.panelModificacion.Paint += new System.Windows.Forms.PaintEventHandler(this.panelModificacion_Paint);
            // 
            // nroMonto
            // 
            this.nroMonto.DecimalPlaces = 2;
            this.nroMonto.InterceptArrowKeys = false;
            this.nroMonto.Location = new System.Drawing.Point(127, 96);
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
            this.nroMonto.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(286, 247);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 28;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Lista de Gastos";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Moneda";
            // 
            // cbo_Moneda
            // 
            this.cbo_Moneda.FormattingEnabled = true;
            this.cbo_Moneda.Location = new System.Drawing.Point(127, 124);
            this.cbo_Moneda.Name = "cbo_Moneda";
            this.cbo_Moneda.Size = new System.Drawing.Size(147, 21);
            this.cbo_Moneda.TabIndex = 31;
            this.cbo_Moneda.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ModificacionGastoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.panelModificacion);
            this.Controls.Add(this.lstGastos);
            this.Name = "ModificacionGastoUI";
            this.Size = new System.Drawing.Size(654, 278);
            this.Load += new System.EventHandler(this.ModificacionGastoUI_Load);
            this.panelModificacion.ResumeLayout(false);
            this.panelModificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstGastos;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelModificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.NumericUpDown nroMonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_Moneda;
        private System.Windows.Forms.Label label6;
    }
}
