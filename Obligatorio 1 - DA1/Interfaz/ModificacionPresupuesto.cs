using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

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
        private void CargarListas()
        {
            lstCategorias.Items.Clear();
            lstMontos.Items.Clear();
            PresupuestoAModificar = Repo.GetPresupuestos().Get(PresupuestoAModificar.Id);
            if (cboxPresupuestos.Text != "")
            {
                foreach (MontoCategoria elemento in PresupuestoAModificar.getPresupuestosCategorias())
                {
                    lstCategorias.Items.Add(elemento.Cat);
                    lstMontos.Items.Add(elemento.Monto);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un presupuesto");
            }
        }
        private void ModificacionPresupuesto_Load(object sender, EventArgs e)
        {
            try
            {
               cboxPresupuestos.DataSource = Repo.GetPresupuestos().GetAll();
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
