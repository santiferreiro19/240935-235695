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
using Obligatorio_1___DA1;
using System.Globalization;
using Managers;
using Obligatorio_1___DA1.Excepciones;

namespace Interfaz
{
    public partial class ModificacionPresupuesto : UserControl
    {
        private Repositorio Repo;
        private Presupuesto PresupuestoAModificar;
        public ModificacionPresupuesto(Repositorio UnRepositorio)
        {
            this.Repo = UnRepositorio;
            this.PresupuestoAModificar = new Presupuesto();
            InitializeComponent();
        }
        private void CargarListas() {
            lstCategorias.Items.Clear();
            lstMontos.Items.Clear();
            if (cboxPresupuestos.Text != "")
            {
                foreach (Categoria elemento in PresupuestoAModificar.getPresupuestosCategorias().Keys)
                {
                    lstCategorias.Items.Add(elemento);
                    lstMontos.Items.Add(PresupuestoAModificar.getPresupuestosCategorias()[elemento].ToString());
                }
            }
            else {
                MessageBox.Show("Seleccione un presupuesto");
            }
        }
        private void ModificacionPresupuesto_Load(object sender, EventArgs e)
        {
            cboxPresupuestos.DataSource = Repo.GetPresupuestos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            PresupuestoAModificar = (Presupuesto)cboxPresupuestos.SelectedItem;
            CargarListas();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    manager.ValidacionModificarPresupuesto(PresupuestoAModificar, CategoriaSeleccionada, monto);
                    nroMonto.Text = "0.00";
                    CargarListas();
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

        private void nroMonto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
