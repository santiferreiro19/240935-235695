using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class PresupuestoUI : Form
    {
        private Repositorio Repo;
        public PresupuestoUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void Presupuesto_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl registrarPresupuesto = new RegistroPresupuestoUI(Repo);
            panelGeneral.Controls.Add(registrarPresupuesto);
        }

        private void panelGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl modificarPresupuesto = new ModificacionPresupuesto(Repo);
            panelGeneral.Controls.Add(modificarPresupuesto);
        }
    }
}
