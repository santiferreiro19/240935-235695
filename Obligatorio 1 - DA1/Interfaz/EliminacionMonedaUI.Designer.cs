namespace Interfaz
{
    partial class EliminacionMonedaUI
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lstMonedas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(495, 199);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(88, 35);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Borrar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lstMonedas
            // 
            this.lstMonedas.FormattingEnabled = true;
            this.lstMonedas.HorizontalScrollbar = true;
            this.lstMonedas.Location = new System.Drawing.Point(3, 3);
            this.lstMonedas.Name = "lstMonedas";
            this.lstMonedas.Size = new System.Drawing.Size(580, 186);
            this.lstMonedas.TabIndex = 32;
            this.lstMonedas.SelectedIndexChanged += new System.EventHandler(this.lstGastos_SelectedIndexChanged);
            // 
            // EliminacionMonedaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstMonedas);
            this.Controls.Add(this.btnEliminar);
            this.Name = "EliminacionMonedaUI";
            this.Size = new System.Drawing.Size(586, 237);
            this.Load += new System.EventHandler(this.EliminacionMonedaUI_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListBox lstMonedas;
    }
}
