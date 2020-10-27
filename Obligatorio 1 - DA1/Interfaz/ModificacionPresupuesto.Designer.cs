namespace Interfaz
{
    partial class ModificacionPresupuesto
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
            this.cboxPresupuestos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.nroMonto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lstMontos = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxPresupuestos
            // 
            this.cboxPresupuestos.FormattingEnabled = true;
            this.cboxPresupuestos.Location = new System.Drawing.Point(84, 3);
            this.cboxPresupuestos.Name = "cboxPresupuestos";
            this.cboxPresupuestos.Size = new System.Drawing.Size(121, 21);
            this.cboxPresupuestos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes y Año";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(211, 3);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(107, 23);
            this.btnListar.TabIndex = 2;
            this.btnListar.Text = "Listar presupuesto";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lstCategorias
            // 
            this.lstCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.Location = new System.Drawing.Point(24, 69);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(124, 182);
            this.lstCategorias.TabIndex = 3;
            this.lstCategorias.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // nroMonto
            // 
            this.nroMonto.DecimalPlaces = 2;
            this.nroMonto.InterceptArrowKeys = false;
            this.nroMonto.Location = new System.Drawing.Point(344, 185);
            this.nroMonto.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nroMonto.Name = "nroMonto";
            this.nroMonto.Size = new System.Drawing.Size(97, 20);
            this.nroMonto.TabIndex = 27;
            this.nroMonto.ValueChanged += new System.EventHandler(this.nroMonto_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Monto";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(351, 221);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Guardar Monto";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lstMontos
            // 
            this.lstMontos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lstMontos.FormattingEnabled = true;
            this.lstMontos.Location = new System.Drawing.Point(145, 69);
            this.lstMontos.Name = "lstMontos";
            this.lstMontos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstMontos.Size = new System.Drawing.Size(124, 186);
            this.lstMontos.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Monto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Categoria";
            // 
            // ModificacionPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstMontos);
            this.Controls.Add(this.nroMonto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lstCategorias);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxPresupuestos);
            this.Name = "ModificacionPresupuesto";
            this.Size = new System.Drawing.Size(456, 270);
            this.Load += new System.EventHandler(this.ModificacionPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxPresupuestos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ListBox lstCategorias;
        private System.Windows.Forms.NumericUpDown nroMonto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ListBox lstMontos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}
