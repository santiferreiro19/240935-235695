namespace Interfaz
{
    partial class EliminacionGastoUI
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
            this.lstGastos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(62, 248);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Borrar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lstGastos
            // 
            this.lstGastos.FormattingEnabled = true;
            this.lstGastos.Location = new System.Drawing.Point(5, 4);
            this.lstGastos.Name = "lstGastos";
            this.lstGastos.Size = new System.Drawing.Size(132, 238);
            this.lstGastos.TabIndex = 29;
            // 
            // EliminacionGastoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lstGastos);
            this.Name = "EliminacionGastoUI";
            this.Size = new System.Drawing.Size(158, 277);
            this.Load += new System.EventHandler(this.EliminacionGastoUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListBox lstGastos;
    }
}
