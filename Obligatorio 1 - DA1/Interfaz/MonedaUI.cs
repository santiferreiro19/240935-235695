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
    public partial class MonedaUI : Form
    {
        private Repositorio Repo;

        public MonedaUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            UserControl registrarMoneda = new RegistroDeMonedasUI(Repo);
            panelGeneral.Controls.Add(registrarMoneda);
        }
    }
}
