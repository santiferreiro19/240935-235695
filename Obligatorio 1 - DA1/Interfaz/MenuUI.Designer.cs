namespace Interfaz
{
    partial class MenuUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUI));
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnGasto = new System.Windows.Forms.Button();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.btnReporteGastos = new System.Windows.Forms.Button();
            this.btnReportePresupuestos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(29, 12);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(124, 60);
            this.btnCategoria.TabIndex = 0;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnGasto
            // 
            this.btnGasto.Location = new System.Drawing.Point(159, 12);
            this.btnGasto.Name = "btnGasto";
            this.btnGasto.Size = new System.Drawing.Size(124, 60);
            this.btnGasto.TabIndex = 1;
            this.btnGasto.Text = "Gasto";
            this.btnGasto.UseVisualStyleBackColor = true;
            this.btnGasto.Click += new System.EventHandler(this.btnGasto_Click);
            // 
            // btnPresupuesto
            // 
            this.btnPresupuesto.Location = new System.Drawing.Point(29, 78);
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.Size = new System.Drawing.Size(124, 60);
            this.btnPresupuesto.TabIndex = 2;
            this.btnPresupuesto.Text = "Presupuesto";
            this.btnPresupuesto.UseVisualStyleBackColor = true;
            this.btnPresupuesto.Click += new System.EventHandler(this.btnPresupuesto_Click);
            // 
            // btnReporteGastos
            // 
            this.btnReporteGastos.Location = new System.Drawing.Point(159, 78);
            this.btnReporteGastos.Name = "btnReporteGastos";
            this.btnReporteGastos.Size = new System.Drawing.Size(124, 60);
            this.btnReporteGastos.TabIndex = 3;
            this.btnReporteGastos.Text = "Reporte de Gastos";
            this.btnReporteGastos.UseVisualStyleBackColor = true;
            this.btnReporteGastos.Click += new System.EventHandler(this.btnReporteGastos_Click);
            // 
            // btnReportePresupuestos
            // 
            this.btnReportePresupuestos.Location = new System.Drawing.Point(92, 144);
            this.btnReportePresupuestos.Name = "btnReportePresupuestos";
            this.btnReportePresupuestos.Size = new System.Drawing.Size(124, 60);
            this.btnReportePresupuestos.TabIndex = 4;
            this.btnReportePresupuestos.Text = "Reporte de Presupuesto";
            this.btnReportePresupuestos.UseVisualStyleBackColor = true;
            this.btnReportePresupuestos.Click += new System.EventHandler(this.btnReportePresupuestos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(324, 78);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 60);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MenuUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(462, 211);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReportePresupuestos);
            this.Controls.Add(this.btnReporteGastos);
            this.Controls.Add(this.btnPresupuesto);
            this.Controls.Add(this.btnGasto);
            this.Controls.Add(this.btnCategoria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuUI";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnGasto;
        private System.Windows.Forms.Button btnPresupuesto;
        private System.Windows.Forms.Button btnReporteGastos;
        private System.Windows.Forms.Button btnReportePresupuestos;
        private System.Windows.Forms.Button btnSalir;
    }
}