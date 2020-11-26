namespace Interfaz
{
    partial class ModificacionMonedasUI
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
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPalabraClave = new System.Windows.Forms.TextBox();
            this.lstPalabrasClave = new System.Windows.Forms.ListBox();
            this.btnModificarPalabra = new System.Windows.Forms.Button();
            this.btnAgregarPalabra = new System.Windows.Forms.Button();
            this.btnBorrarPalabra = new System.Windows.Forms.Button();
            this.btnModificarNombre = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCategorias
            // 
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.Location = new System.Drawing.Point(29, 45);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(197, 160);
            this.lstCategorias.TabIndex = 14;
            this.lstCategorias.SelectedIndexChanged += new System.EventHandler(this.lstCategorias_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Listado De Categorias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Palabras Clave";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(120, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // txtPalabraClave
            // 
            this.txtPalabraClave.Location = new System.Drawing.Point(110, 42);
            this.txtPalabraClave.Name = "txtPalabraClave";
            this.txtPalabraClave.Size = new System.Drawing.Size(120, 20);
            this.txtPalabraClave.TabIndex = 11;
            // 
            // lstPalabrasClave
            // 
            this.lstPalabrasClave.FormattingEnabled = true;
            this.lstPalabrasClave.Location = new System.Drawing.Point(110, 64);
            this.lstPalabrasClave.Name = "lstPalabrasClave";
            this.lstPalabrasClave.Size = new System.Drawing.Size(120, 95);
            this.lstPalabrasClave.TabIndex = 9;
            this.lstPalabrasClave.SelectedIndexChanged += new System.EventHandler(this.lstPalabrasClave_SelectedIndexChanged);
            // 
            // btnModificarPalabra
            // 
            this.btnModificarPalabra.Location = new System.Drawing.Point(236, 66);
            this.btnModificarPalabra.Name = "btnModificarPalabra";
            this.btnModificarPalabra.Size = new System.Drawing.Size(75, 23);
            this.btnModificarPalabra.TabIndex = 16;
            this.btnModificarPalabra.Text = "Modificar";
            this.btnModificarPalabra.UseVisualStyleBackColor = true;
            this.btnModificarPalabra.Click += new System.EventHandler(this.btnModificarPalabra_Click);
            // 
            // btnAgregarPalabra
            // 
            this.btnAgregarPalabra.Location = new System.Drawing.Point(236, 95);
            this.btnAgregarPalabra.Name = "btnAgregarPalabra";
            this.btnAgregarPalabra.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarPalabra.TabIndex = 17;
            this.btnAgregarPalabra.Text = "Agregar";
            this.btnAgregarPalabra.UseVisualStyleBackColor = true;
            this.btnAgregarPalabra.Click += new System.EventHandler(this.btnAgregarPalabra_Click);
            // 
            // btnBorrarPalabra
            // 
            this.btnBorrarPalabra.Location = new System.Drawing.Point(236, 41);
            this.btnBorrarPalabra.Name = "btnBorrarPalabra";
            this.btnBorrarPalabra.Size = new System.Drawing.Size(75, 19);
            this.btnBorrarPalabra.TabIndex = 18;
            this.btnBorrarPalabra.Text = "Borrar";
            this.btnBorrarPalabra.UseVisualStyleBackColor = true;
            this.btnBorrarPalabra.Click += new System.EventHandler(this.btnBorrarPalabra_Click);
            // 
            // btnModificarNombre
            // 
            this.btnModificarNombre.Location = new System.Drawing.Point(236, 5);
            this.btnModificarNombre.Name = "btnModificarNombre";
            this.btnModificarNombre.Size = new System.Drawing.Size(75, 23);
            this.btnModificarNombre.TabIndex = 19;
            this.btnModificarNombre.Text = "Modificar";
            this.btnModificarNombre.UseVisualStyleBackColor = true;
            this.btnModificarNombre.Click += new System.EventHandler(this.btnModificarNombre_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnModificarNombre);
            this.panel1.Controls.Add(this.btnBorrarPalabra);
            this.panel1.Controls.Add(this.btnAgregarPalabra);
            this.panel1.Controls.Add(this.btnModificarPalabra);
            this.panel1.Controls.Add(this.lstPalabrasClave);
            this.panel1.Controls.Add(this.txtPalabraClave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(262, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 160);
            this.panel1.TabIndex = 20;
            this.panel1.Visible = false;
            // 
            // ModificacionCategoriasUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCategorias);
            this.Name = "ModificacionCategoriasUI";
            this.Size = new System.Drawing.Size(605, 250);
            this.Load += new System.EventHandler(this.ModificacionCategorias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstCategorias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPalabraClave;
        private System.Windows.Forms.ListBox lstPalabrasClave;
        private System.Windows.Forms.Button btnModificarPalabra;
        private System.Windows.Forms.Button btnAgregarPalabra;
        private System.Windows.Forms.Button btnBorrarPalabra;
        private System.Windows.Forms.Button btnModificarNombre;
        private System.Windows.Forms.Panel panel1;
    }
}
