using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces
{
    public partial class GastoUI : Form
    {
        private Repositorio Repo;
        private Gasto unGasto;
        public GastoUI(Repositorio unRepositorio)
        {
            unGasto = new Gasto();
            Repo = unRepositorio;
            InitializeComponent();
        }
        public void CargarCbox() {
            cboCategoria.DataSource = null;
            cboCategoria.DataSource = Repo.GetCategorias();
            cboCategoria.SelectedIndex = -1;
            listBox1.DataSource = null;
            listBox1.DataSource = Repo.GetGastos();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ManagerGasto manager = new ManagerGasto(Repo);
            decimal monto = Decimal.Parse(txtMonto.Text);
            monto = manager.TransformarMonto(monto);
            if (txtDescripcion.Text != "" && cboCategoria.SelectedIndex != -1)
            {
                try
                {
                    manager.ValidacionDescripcionGasto(txtDescripcion.Text);
                    manager.ValidacionFechaGasto(dateFecha.Value);
                    manager.ValidarMonto(monto);
                    unGasto.Descripcion = txtDescripcion.Text;
                    unGasto.Monto = monto;
                    unGasto.Fecha = dateFecha.Value;
                    unGasto.unaCategoria = (Categoria)cboCategoria.SelectedItem;
                    txtDescripcion.Text = "";
                    txtMonto.Text = "";
                    cboCategoria.SelectedIndex = -1;
                    manager.ValidacionAgregarGasto(unGasto);
                }
                catch (ExceptionDescripcionGasto descripcion)
                {
                    MessageBox.Show(" La descripción tiene que tener entre 3 y 20 caracteres");
                }
                catch (ExceptionFechaGasto fecha)
                {
                    MessageBox.Show("La fecha debe de esta comprendida entre 2018 - 2030");
                }
                catch (ExceptionMonto montoException) {
                    MessageBox.Show("El monto debe de ser mayor a 0");
                }
            }
            else{
                MessageBox.Show("Hay campos vacios");
            }
            listBox1.DataSource = null;
            listBox1.DataSource = this.Repo.GetGastos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Gasto_Load(object sender, EventArgs e)
        {
            CargarCbox();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarCbox();
            ManagerGasto manager = new ManagerGasto(Repo);
            string descripcion = txtDescripcion.Text;
            cboCategoria.SelectedItem = manager.ValidacionBusquedaCategorias(descripcion);
        }
    }
}
