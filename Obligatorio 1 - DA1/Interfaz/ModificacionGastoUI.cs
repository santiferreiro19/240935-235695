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
using Obligatorio_1___DA1.Excepciones;

namespace Interfaz
{
    public partial class ModificacionGastoUI : UserControl
    {
        private Repositorio Repo;
        private Gasto GastoSeleccionado;
        public ModificacionGastoUI(Repositorio unRepositorio)
        {
            GastoSeleccionado = new Gasto();
            Repo = unRepositorio;
            InitializeComponent();
        }
        public void CargarListBox()
        {
            lstGastos.DataSource = null;
            lstGastos.DataSource = Repo.GetGastos();
            lstGastos.SelectedIndex = -1;
        }
        public void CargarComboBox()
        {
            cboCategoria.DataSource = null;
            cboCategoria.DataSource = Repo.GetCategorias();
            cboCategoria.SelectedIndex = -1;
        }
        private void ModificacionGastoUI_Load(object sender, EventArgs e)
        {
            CargarListBox();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerGasto manager = new ManagerGasto(Repo);

            if (txtDescripcion.Text != "" && cboCategoria.SelectedIndex != -1 && nroMonto.Text != "")
            {
                decimal monto = Decimal.Parse(nroMonto.Text);
                monto = manager.TransformarMonto(monto);
                try
                {
                    /*manager.ValidacionModificacionCategoriaGasto(GastoSeleccionado, (Categoria)cboCategoria.SelectedItem);
                    manager.ValidacionModificacionDescripcionGasto(GastoSeleccionado, txtDescripcion.Text);
                    manager.ValidacionModificacionFechaGasto(GastoSeleccionado, dateFecha.Value);
                    manager.ValidacionModificacionMontoGasto(GastoSeleccionado, monto);*/
                    Gasto GastoTemporal = new Gasto();
                    GastoTemporal.Fecha = dateFecha.Value;
                    GastoTemporal.Categoria = (Categoria)cboCategoria.SelectedItem;
                    GastoTemporal.Monto = monto;
                    GastoTemporal.Descripcion = txtDescripcion.Text;
                    manager.ValidacionModificacionGasto(GastoSeleccionado, GastoTemporal);
                    GastoSeleccionado = new Gasto();
                    txtDescripcion.Text = "";
                    nroMonto.Text = "";
                    cboCategoria.SelectedIndex = -1;
                    panelModificacion.Visible = false;
                }
                catch (ExceptionDescripcionGasto descripcion)
                {
                    MessageBox.Show(" La descripción tiene que tener entre 3 y 20 caracteres");
                }
                catch (ExceptionFechaGasto fecha)
                {
                    MessageBox.Show("La fecha debe de esta comprendida entre 2018 - 2030");
                }
                catch (ExceptionMonto montoException)
                {
                    MessageBox.Show("El monto debe de ser mayor a 0");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios");
            }
            CargarComboBox();
            CargarListBox();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lstGastos.Text != "")
            {
                panelModificacion.Visible = true;
                GastoSeleccionado = (Gasto)lstGastos.SelectedItem;
                txtDescripcion.Text = GastoSeleccionado.Descripcion;
                nroMonto.Text = GastoSeleccionado.Monto.ToString();
                CargarComboBox();
                cboCategoria.SelectedItem = GastoSeleccionado.Categoria;
            }
            else {
                MessageBox.Show("Seleccione un gasto");
            }
        }
    }
}
