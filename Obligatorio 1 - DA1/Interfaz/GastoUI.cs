using Interfaz;
using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
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

namespace Interfaces
{
    public partial class GastoUI : Form
    {
        private Repositorio Repo;
        public GastoUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }
            
        private void Gasto_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl registrarGasto = new RegistroDeGastosUI(Repo);
            panelGeneral.Controls.Add(registrarGasto);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl modificarGasto = new ModificacionGastoUI(Repo);
            panelGeneral.Controls.Add(modificarGasto);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl eliminarGasto = new EliminacionGastoUI(Repo);
            panelGeneral.Controls.Add(eliminarGasto);
        }
    }
}
