using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class RegistroPresupuestoUI : UserControl
    {
        private Repositorio Repo;
        private Presupuesto PresupuestoTemporal;
        public RegistroPresupuestoUI(Repositorio UnRepositorio)
        {
            this.Repo = UnRepositorio;
            this.PresupuestoTemporal = new Presupuesto();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void CargarList()
        {
            lstCategorias.Items.Clear();
            lstMontos.Items.Clear();

            foreach (MontoCategoria elemento in PresupuestoTemporal.getPresupuestosCategorias())
            {
                lstCategorias.Items.Add(elemento.Cat);
                lstMontos.Items.Add(elemento.Monto);
            }
        }
        private void RegistroPresupuestoUI_Load(object sender, EventArgs e)
        {
            try
            {

                ManagerPresupuesto manager = new ManagerPresupuesto(Repo);
                manager.CargarCategoriasPresupuesto(PresupuestoTemporal);
                CargarList();

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ManagerPresupuesto manager = new ManagerPresupuesto(Repo);
            Categoria CategoriaSeleccionada = (Categoria)lstCategorias.SelectedItem;
            if (nroMonto.Text != "" && lstCategorias.SelectedIndex != -1)
            {
                try
                {
                    decimal monto = decimal.Parse(nroMonto.Text);
                    manager.ValidacionAgregarUnMonto(PresupuestoTemporal, CategoriaSeleccionada, monto);
                    nroMonto.Text = "0.00";
                    CargarList();
                }
                catch (ExceptionMontoPresupuesto monto)
                {
                    MessageBox.Show("El monto debe ser mayor a cero, y tener dos decimales");
                }
            }
            else
            {
                MessageBox.Show("La categoria no fue seleccionada o el monto esta vacio");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerPresupuesto manager = new ManagerPresupuesto(Repo);
            if (nmr_Año.Text != "" && cboMes.SelectedIndex != -1)
            {
                Presupuesto PresupuestoGuardar = new Presupuesto();
                try
                {
                    PresupuestoGuardar.Año = int.Parse(nmr_Año.Text);
                    PresupuestoGuardar.Mes = (String)cboMes.SelectedItem;
                    PresupuestoGuardar.setPresupuestosCategorias(PresupuestoTemporal.getPresupuestosCategorias());
                    manager.ValidacionAgregarPresupuesto(PresupuestoGuardar);
                    nmr_Año.Text = "";
                    cboMes.SelectedIndex = -1;
                    PresupuestoTemporal = new Presupuesto();
                    manager.CargarCategoriasPresupuesto(PresupuestoTemporal);
                    CargarList();
                }
                catch (ExceptionAñoPresupuesto año)
                {
                    MessageBox.Show("El año tiene que ser entre 2018 - 2030");
                }
                catch (ExceptionPresupuestoRepetido repetido)
                {
                    MessageBox.Show("Presupuesto para año y mes ya ingresado");
                }
            }
            else
            {
                MessageBox.Show("Los campos Año y Mes son obligatorios");
            }
        }

        private void lstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nroMonto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nmr_Año_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
