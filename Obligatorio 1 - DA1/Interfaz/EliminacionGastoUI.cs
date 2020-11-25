using Managers;
using Obligatorio_1___DA1;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class EliminacionGastoUI : UserControl
    {
        private Repositorio Repo;
        private Gasto GastoSeleccionado;
        public EliminacionGastoUI(Repositorio unRepositorio)
        {
            GastoSeleccionado = new Gasto();
            Repo = unRepositorio;
            InitializeComponent();
        }
        public void CargarListBox()
        {
            lstGastos.DataSource = null;
            lstGastos.DataSource = Repo.GetGastos().GetAll();
            lstGastos.SelectedIndex = -1;
        }
        private void EliminacionGastoUI_Load(object sender, EventArgs e)
        {
            try{
                CargarListBox();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            GastoSeleccionado = (Gasto)lstGastos.SelectedItem;
            ManagerGasto manager = new ManagerGasto(Repo);
            manager.ValidacionEliminarGasto(GastoSeleccionado);
            CargarListBox();
        }

        private void lstGastos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
