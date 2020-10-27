namespace Interfaz
{
    partial class ReporteDeGastosUI
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
            MenuUI inicio = new MenuUI(Repo);
            inicio.Show();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.data_gastos = new System.Windows.Forms.DataGridView();
            this.lbl_resultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_gastos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(380, 233);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total:";
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(67, 16);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(151, 21);
            this.cboMes.TabIndex = 10;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(239, 16);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 11;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // data_gastos
            // 
            this.data_gastos.AllowUserToAddRows = false;
            this.data_gastos.AllowUserToDeleteRows = false;
            this.data_gastos.AllowUserToResizeColumns = false;
            this.data_gastos.AllowUserToResizeRows = false;
            this.data_gastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_gastos.Location = new System.Drawing.Point(16, 55);
            this.data_gastos.Name = "data_gastos";
            this.data_gastos.ReadOnly = true;
            this.data_gastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_gastos.Size = new System.Drawing.Size(398, 150);
            this.data_gastos.TabIndex = 13;
            this.data_gastos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_gastos_CellContentClick);
            // 
            // lbl_resultado
            // 
            this.lbl_resultado.AutoSize = true;
            this.lbl_resultado.Location = new System.Drawing.Point(420, 233);
            this.lbl_resultado.Name = "lbl_resultado";
            this.lbl_resultado.Size = new System.Drawing.Size(0, 13);
            this.lbl_resultado.TabIndex = 14;
            this.lbl_resultado.Click += new System.EventHandler(this.lbl_resultado_Click);
            // 
            // ReporteDeGastosUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 255);
            this.Controls.Add(this.lbl_resultado);
            this.Controls.Add(this.data_gastos);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Name = "ReporteDeGastosUI";
            this.Text = "ReporteDeGastos";
            this.Load += new System.EventHandler(this.ReporteDeGastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_gastos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView data_gastos;
        private System.Windows.Forms.Label lbl_resultado;
    }
}