using Interfaces;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categoria unaCategoria = new Categoria();
            this.Hide();
            unaCategoria.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gasto unGasto = new Gasto();
            this.Hide();
            unGasto.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Presupuesto unPresupuesto = new Presupuesto();
            this.Hide();
            unPresupuesto.Show();
        }

        private void btnReporteGastos_Click(object sender, EventArgs e)
        {
            ReporteDeGastos unReporteDeGastos = new ReporteDeGastos();
            this.Hide();
            unReporteDeGastos.Show();
        }

        private void btnReportePresupuestos_Click(object sender, EventArgs e)
        {
            ReportePresupuesto unReportePresupuesto = new ReportePresupuesto();
            this.Hide();
            unReportePresupuesto.Show();
        }
    }
}
