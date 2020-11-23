using Managers;
using Obligatorio_1___DA1;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class EliminacionMonedaUI : UserControl
    {
        private Repositorio Repo;
        private Moneda MonedaSeleccionada;
        public EliminacionMonedaUI(Repositorio unRepositorio)
        {
            MonedaSeleccionada = new Moneda();
            Repo = unRepositorio;
            InitializeComponent();
        }
        public void CargarListBox()
        {
            lstMonedas.DataSource = null;
            lstMonedas.DataSource = Repo.GetMonedas().GetAll();
            lstMonedas.SelectedIndex = -1;
        }
        private void lstMonedas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstGastos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EliminacionMonedaUI_Load(object sender, EventArgs e)
        {
            CargarListBox();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MonedaSeleccionada = (Moneda)lstMonedas.SelectedItem;
            ManagerMoneda manager = new ManagerMoneda(Repo);
            if (!BloqueoPesoUruguayo(MonedaSeleccionada.Simbolo))
            {
                manager.ValidacionEliminarMoneda(MonedaSeleccionada);
            }
            else
            {
                MessageBox.Show("El peso uruguayo no se puede eliminar");
            }
            CargarListBox();
        }

        public bool BloqueoPesoUruguayo(string Simbolo)
        {
            return Simbolo == "UYU";
        }
    }
}
