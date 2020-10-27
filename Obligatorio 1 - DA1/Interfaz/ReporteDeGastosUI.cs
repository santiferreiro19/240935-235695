using Managers;
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
    public partial class ReporteDeGastosUI : Form
    {
        private Repositorio Repo;
        public ReporteDeGastosUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReporteDeGastos_Load(object sender, EventArgs e)
        {
            ManagerGasto unManager = new ManagerGasto(Repo);
            cboMes.DataSource = unManager.CargarFechasDondeHuboGastos();
        }

        private void lbl_resultado_Click(object sender, EventArgs e)
        {

        }

        private void data_gastos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ManagerGasto unManager = new ManagerGasto(Repo);
            if (cboMes.SelectedIndex != -1)
            {
                var list = unManager.FiltrarGastosPorFecha(cboMes.SelectedItem.ToString()).OrderBy(x => x.Fecha).ToList();
                data_gastos.DataSource = list;
                data_gastos.Columns["Fecha"].DisplayIndex = 0;
                data_gastos.RowHeadersVisible = false;
                lbl_resultado.Text = (unManager.SumaDeGastosParaFecha(unManager.FiltrarGastosPorFecha(cboMes.SelectedItem.ToString())));
            }
        }
    }
}
