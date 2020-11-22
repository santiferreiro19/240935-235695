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
using Managers;

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
            manager.ValidacionEliminarMoneda(MonedaSeleccionada);
            CargarListBox();
        }
    }
}
