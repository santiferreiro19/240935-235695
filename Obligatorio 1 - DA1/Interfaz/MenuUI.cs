using Interfaces;
using Obligatorio_1___DA1;
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
    public partial class MenuUI : Form
    {
        private Repositorio Repo;
        public MenuUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoriaUI unaCategoria = new CategoriaUI(Repo);
            this.Hide();
            unaCategoria.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GastoUI unGasto = new GastoUI(Repo);
            this.Hide();
            unGasto.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             PresupuestoUI unPresupuesto = new PresupuestoUI(Repo);
            this.Hide();
            unPresupuesto.Show();
        }

        private void btnReporteGastos_Click(object sender, EventArgs e)
        {
            ReporteDeGastosUI unReporteDeGastos = new ReporteDeGastosUI(Repo);
            this.Hide();
            unReporteDeGastos.Show();
        }

        private void btnReportePresupuestos_Click(object sender, EventArgs e)
        {
            ReportePresupuestoUI unReportePresupuesto = new ReportePresupuestoUI(Repo);
            this.Hide();
            unReportePresupuesto.Show();
        }

        private void MenuUI_Load(object sender, EventArgs e)
        {

        }
    }
}
