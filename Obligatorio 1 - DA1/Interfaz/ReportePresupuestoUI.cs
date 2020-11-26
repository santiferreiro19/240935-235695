using Managers;
using Obligatorio_1___DA1;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class ReportePresupuestoUI : Form
    {
        private Repositorio Repo;
        private const int MAX_DECIMALES_MONTO = 2;
        private const decimal VALOR_POR_DEFECTO = 0.00M;
        public ReportePresupuestoUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void ReportePresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
                ManagerPresupuesto Manager = new ManagerPresupuesto(Repo);
                comboBox1.DataSource = Manager.CargarListaDondeHuboPresupuestos();
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

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                ManagerPresupuesto ManagerP = new ManagerPresupuesto(Repo);
                ManagerGasto ManagerG = new ManagerGasto(Repo);
                data_Presupuestos.Rows.Clear();
                data_Presupuestos.Columns.Clear();
                data_Presupuestos.Columns.Add("Catgeoria", "Categoria");
                data_Presupuestos.Columns.Add("Planificado", "Planificado");
                data_Presupuestos.Columns.Add("Real", "Real");
                data_Presupuestos.Columns.Add("Diferencia", "Diferencia");
                Presupuesto Encontrado = ManagerP.BuscarPresupuestosPorFecha(comboBox1.Text);
                decimal TotalPlanificado = VALOR_POR_DEFECTO;
                decimal TotalReal = VALOR_POR_DEFECTO;
                decimal TotalDiferencia = VALOR_POR_DEFECTO;
                foreach (var item in Encontrado.getPresupuestosCategorias())
                {
                    List<Gasto> ListaDeGastosParaEsaFecha = ManagerG.ObtenerGastosPorFechaCategoria(item.Cat, comboBox1.Text);
                    string SumaDeGastos = ManagerG.SumaDeGastosParaFecha(ListaDeGastosParaEsaFecha);
                    decimal resultado = RestaRealPlanificado(item.Monto, decimal.Parse(SumaDeGastos));
                    data_Presupuestos.Rows.Add(item.Cat.Nombre, item.Monto, SumaDeGastos, Formato(resultado));

                    TotalPlanificado += Math.Round(item.Monto, MAX_DECIMALES_MONTO);
                    TotalReal += Math.Round(decimal.Parse(SumaDeGastos), MAX_DECIMALES_MONTO);
                    TotalDiferencia += Math.Round(resultado);
                }
                data_Presupuestos.RowHeadersVisible = false;
                data_Presupuestos.Rows.Add("Total", TotalPlanificado, TotalReal, Formato(TotalDiferencia));
                ColorNegativo();
            }
            else
            {
                MessageBox.Show("Seleccione un presupuesto");
            }
        }

        public decimal RestaRealPlanificado(decimal p, decimal r)
        {
            decimal resultado = p - r;
            return resultado;
        }

        public string Formato(decimal unNumero)
        {
            string Retorno = unNumero.ToString();
            if (unNumero < 0)
            {
                Retorno = "(" + unNumero + ")";
            }
            return Retorno;
        }

        public void ColorNegativo()
        {
            foreach (DataGridViewRow row in data_Presupuestos.Rows)
            {
                if (row.Cells["Diferencia"].Value.ToString().Contains('(') && row.Cells["Diferencia"].Value.ToString().Contains(')'))
                {
                    row.Cells["Diferencia"].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                }
            }
        }
        private void data_Presupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
