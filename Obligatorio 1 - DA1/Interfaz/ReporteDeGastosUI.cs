using Managers;
using Obligatorio_1___DA1.Serializacion;
using Persistencia;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ReporteDeGastosUI : Form
    {
        private Repositorio Repo;
        private const int MAX_DECIMALES_MONTO = 2;

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
            try
            {
                ManagerGasto unManager = new ManagerGasto(Repo);
                cboMes.DataSource = unManager.CargarFechasDondeHuboGastos();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                this.Enabled = false;
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                this.Enabled = false;
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }

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
                data_gastos.Columns["Fecha"].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";
                data_gastos.Columns.Remove("Id");
                data_gastos.Columns.Remove("CotizacionActual");
                data_gastos.RowHeadersVisible = false;
                string resultado = (unManager.SumaDeGastosParaFecha(unManager.FiltrarGastosPorFecha(cboMes.SelectedItem.ToString())));
                decimal resultadoDecimal = Math.Round(decimal.Parse(resultado), MAX_DECIMALES_MONTO);
                lbl_resultado.Text = resultadoDecimal.ToString();
                lbl_resultado.ForeColor = Color.White;
            }
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            String path;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "ReporteGastos";
            switch (comboBox1.SelectedItem)
            {
                case "CSV":
                    saveFileDialog1.DefaultExt = ".csv";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFileDialog1.FileName;
                        IEstrategiaExportar estrategiaCSV = new EstrategiaExportarCSV();
                        estrategiaCSV.Imprimir(data_gastos, path);
                    }
                    break;
                case "TXT":
                    saveFileDialog1.DefaultExt = ".txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = saveFileDialog1.FileName;
                        IEstrategiaExportar estrategiaTXT = new EstrategiaExportarTXT();
                        estrategiaTXT.Imprimir(data_gastos, path);
                    }
                    break;
                default:
                    MessageBox.Show("No se selecciono una opcion");
                    break;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

}
