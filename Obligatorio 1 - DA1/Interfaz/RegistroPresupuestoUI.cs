using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Interfaces;
using Obligatorio_1___DA1;
using Managers;
using Obligatorio_1___DA1.Excepciones;

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
        private void CargarList() {
            lstCategorias.Items.Clear();
            lstMontos.Items.Clear();
            foreach (Categoria elemento in PresupuestoTemporal.getPresupuestosCategorias().Keys) {
                lstCategorias.Items.Add(elemento);
                lstMontos.Items.Add(PresupuestoTemporal.getPresupuestosCategorias()[elemento].ToString());
            }
        }
        private void RegistroPresupuestoUI_Load(object sender, EventArgs e)
        {
            ManagerPresupuesto manager = new ManagerPresupuesto(Repo);
            PresupuestoTemporal.setPresupuestosCategorias(manager.CargarCategoriasPresupuesto()) ;
            CargarList();
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
                    manager.ValidacionAgregarUnMonto(PresupuestoTemporal.getPresupuestosCategorias(), CategoriaSeleccionada, monto);
                    nroMonto.Text = "0.00";
                    CargarList();
                }
                catch (ExceptionMontoPresupuesto monto) {
                    MessageBox.Show("El monto debe ser mayor a cero, y tener dos decimales");
                }
            }
            else {
                MessageBox.Show("La categoria no fue seleccionada o el monto esta vacio");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerPresupuesto manager = new ManagerPresupuesto(Repo);
            if (txtAño.Text != "" && cboMes.SelectedIndex != -1) {
                Presupuesto PresupuestoGuardar = new Presupuesto();
                try
                {
                    manager.ValidacionAño(int.Parse(txtAño.Text));
                    PresupuestoGuardar.Año = int.Parse(txtAño.Text);
                    PresupuestoGuardar.Mes = (String)cboMes.SelectedItem;
                    PresupuestoGuardar.setPresupuestosCategorias(PresupuestoTemporal.getPresupuestosCategorias());
                    manager.ValidacionAgregarPresupuesto(PresupuestoGuardar);
                    //presupuesto tiene que ser unico VALIDAR
                    txtAño.Text = "";
                    cboMes.SelectedIndex = -1;
                    
                    PresupuestoTemporal = new Presupuesto();
                    PresupuestoTemporal.setPresupuestosCategorias(manager.CargarCategoriasPresupuesto());
                    CargarList();
                }
                catch (ExceptionAñoPresupuesto año) {
                    MessageBox.Show("El año tiene que ser entre 2018 - 2030");
                }
            }else
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
    }
}
