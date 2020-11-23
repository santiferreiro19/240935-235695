using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Obligatorio_1___DA1;
using Persistencia;
using Managers;

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
            CargarListBox();
            
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
