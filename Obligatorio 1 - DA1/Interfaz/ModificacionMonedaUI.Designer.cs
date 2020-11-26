namespace Interfaz
{
    partial class ModificacionMonedaUI
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
            this.label5 = new System.Windows.Forms.Label();
            this.panelModificacion = new System.Windows.Forms.Panel();
            this.nroCotizacion = new System.Windows.Forms.NumericUpDown();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMonedas = new System.Windows.Forms.ListBox();
            this.txtSimbolo = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.panelModificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCotizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Lista de Monedas";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panelModificacion
            // 
            this.panelModificacion.Controls.Add(this.txtSimbolo);
            this.panelModificacion.Controls.Add(this.nroCotizacion);
            this.panelModificacion.Controls.Add(this.btn_modificar);
            this.panelModificacion.Controls.Add(this.txtNombre);
            this.panelModificacion.Controls.Add(this.label1);
            this.panelModificacion.Controls.Add(this.label2);
            this.panelModificacion.Controls.Add(this.label3);
            this.panelModificacion.Location = new System.Drawing.Point(354, 7);
            this.panelModificacion.Name = "panelModificacion";
            this.panelModificacion.Size = new System.Drawing.Size(285, 215);
            this.panelModificacion.TabIndex = 31;
            this.panelModificacion.Visible = false;
            this.panelModificacion.Paint += new System.Windows.Forms.PaintEventHandler(this.panelModificacion_Paint);
            // 
            // nroCotizacion
            // 
            this.nroCotizacion.DecimalPlaces = 2;
            this.nroCotizacion.InterceptArrowKeys = false;
            this.nroCotizacion.Location = new System.Drawing.Point(59, 143);
            this.nroCotizacion.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nroCotizacion.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nroCotizacion.Name = "nroCotizacion";
            this.nroCotizacion.Size = new System.Drawing.Size(147, 20);
            this.nroCotizacion.TabIndex = 28;
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(87, 189);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_modificar.TabIndex = 27;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 55);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(147, 20);
            this.txtNombre.TabIndex = 23;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Simbolo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cotizacion";
            // 
            // lstMonedas
            // 
            this.lstMonedas.FormattingEnabled = true;
            this.lstMonedas.HorizontalScrollbar = true;
            this.lstMonedas.Location = new System.Drawing.Point(13, 46);
            this.lstMonedas.Name = "lstMonedas";
            this.lstMonedas.Size = new System.Drawing.Size(335, 147);
            this.lstMonedas.TabIndex = 0;
            this.lstMonedas.SelectedIndexChanged += new System.EventHandler(this.lstMonedas_SelectedIndexChanged);
            // 
            // txtSimbolo
            // 
            this.txtSimbolo.Location = new System.Drawing.Point(59, 91);
            this.txtSimbolo.Name = "txtSimbolo";
            this.txtSimbolo.Size = new System.Drawing.Size(147, 20);
            this.txtSimbolo.TabIndex = 29;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(273, 199);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 30;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // ModificacionMonedaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelModificacion);
            this.Controls.Add(this.lstMonedas);
            this.Name = "ModificacionMonedaUI";
            this.Size = new System.Drawing.Size(654, 278);
            this.Load += new System.EventHandler(this.ModificacionMonedaUI_Load);
            this.panelModificacion.ResumeLayout(false);
            this.panelModificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nroCotizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelModificacion;
        private System.Windows.Forms.NumericUpDown nroCotizacion;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMonedas;
        private System.Windows.Forms.TextBox txtSimbolo;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}
