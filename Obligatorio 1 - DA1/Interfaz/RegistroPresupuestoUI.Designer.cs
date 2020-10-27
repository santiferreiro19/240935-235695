namespace Interfaz
{
    partial class RegistroPresupuestoUI
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
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.lstMontos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nroMonto = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMes.Location = new System.Drawing.Point(57, 13);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(135, 21);
            this.cboMes.TabIndex = 17;
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(57, 55);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(135, 20);
            this.txtAño.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mes";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(269, 145);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar Monto";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Monto";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lstCategorias
            // 
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.Location = new System.Drawing.Point(3, 109);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(104, 147);
            this.lstCategorias.TabIndex = 21;
            this.lstCategorias.SelectedIndexChanged += new System.EventHandler(this.lstCategorias_SelectedIndexChanged);
            // 
            // lstMontos
            // 
            this.lstMontos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lstMontos.FormattingEnabled = true;
            this.lstMontos.Location = new System.Drawing.Point(105, 109);
            this.lstMontos.Name = "lstMontos";
            this.lstMontos.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstMontos.Size = new System.Drawing.Size(115, 147);
            this.lstMontos.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 23;
            this.button1.Text = "Guardar Presupuesto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nroMonto
            // 
            this.nroMonto.DecimalPlaces = 2;
            this.nroMonto.InterceptArrowKeys = false;
            this.nroMonto.Location = new System.Drawing.Point(269, 124);
            this.nroMonto.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nroMonto.Name = "nroMonto";
            this.nroMonto.Size = new System.Drawing.Size(97, 20);
            this.nroMonto.TabIndex = 24;
            this.nroMonto.ValueChanged += new System.EventHandler(this.nroMonto_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Monto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegistroPresupuestoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nroMonto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstMontos);
            this.Controls.Add(this.lstCategorias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.txtAño);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Name = "RegistroPresupuestoUI";
            this.Size = new System.Drawing.Size(382, 333);
            this.Load += new System.EventHandler(this.RegistroPresupuestoUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nroMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstCategorias;
        private System.Windows.Forms.ListBox lstMontos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nroMonto;
        private System.Windows.Forms.Label label5;
    }
}
