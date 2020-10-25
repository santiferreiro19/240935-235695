using Interfaz;
using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaces
{
    public partial class CategoriaUI : Form
    {
        private Repositorio Repo;
        public CategoriaUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }
        private void Categoria_Load(object sender, EventArgs e)
        {

        }
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAgregar.Controls.Clear();
            UserControl registrarCategoria = new RegistroCategorias(Repo);
            panelAgregar.Controls.Add(registrarCategoria);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAgregar.Controls.Clear();
            UserControl modificarCategoria = new ModificacionCategorias(Repo);
            panelAgregar.Controls.Add(modificarCategoria);
        }

        private void panelAgregar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
