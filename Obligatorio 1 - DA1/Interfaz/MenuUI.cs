using Interfaces;
using Persistencia;
using System;
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


        private void MenuUI_Load(object sender, EventArgs e)
        {

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
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CategoriaUI unaCategoria = new CategoriaUI(Repo);
            this.Hide();
            unaCategoria.Show();
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            GastoUI unGasto = new GastoUI(Repo);
            this.Hide();
            unGasto.Show();
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            PresupuestoUI unPresupuesto = new PresupuestoUI(Repo);
            this.Hide();
            unPresupuesto.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Moneda_Click(object sender, EventArgs e)
        {
            MonedaUI unaMoneda = new MonedaUI(Repo);
            this.Hide();
            unaMoneda.Show();
        }

        private void btnEliminarDatos_Click(object sender, EventArgs e)
        {
            using (ContextoFinanzas db = new ContextoFinanzas())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM MONTOCATEGORIAS");
                db.Database.ExecuteSqlCommand("DELETE FROM PRESUPUESTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM GASTOES;");
                db.Database.ExecuteSqlCommand("DELETE FROM PALABRACLAVES;");
                db.Database.ExecuteSqlCommand("DELETE FROM CATEGORIAS;");
                db.Database.ExecuteSqlCommand("DELETE FROM MONEDAS;");

            }
        }
    }
}
