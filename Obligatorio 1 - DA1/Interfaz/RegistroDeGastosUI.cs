using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class RegistroDeGastosUI : UserControl
    {
        private Repositorio Repo;
        private Gasto unGasto;
        public RegistroDeGastosUI(Repositorio unRepositorio)
        {
            unGasto = new Gasto();
            Repo = unRepositorio;
            InitializeComponent();
        }
        public void CargarCbox()
        {
            cboCategoria.DataSource = null;
            cboCategoria.DataSource = Repo.GetCategorias().GetAll();
            cboCategoria.SelectedIndex = -1;
            cbo_Monedas.DataSource = null;
            cbo_Monedas.DataSource = Repo.GetMonedas().GetAll();
            cbo_Monedas.SelectedIndex = -1;
        }
        private void RegistroDeGastosUI_Load(object sender, EventArgs e)
        {
            try
            {
            listBox1.DataSource = null;
            listBox1.DataSource = Repo.GetGastos().GetAll();
            CargarCbox();
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
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ManagerGasto manager = new ManagerGasto(Repo);
            string descripcion = txtDescripcion.Text;
            cboCategoria.DataSource = null;
            cboCategoria.DataSource = (manager.ValidacionBusquedaCategorias(descripcion));
            if (manager.ValidacionBusquedaCategorias(descripcion).Count() > 1)
            {
                cboCategoria.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ManagerGasto manager = new ManagerGasto(Repo);
            if (txtDescripcion.Text != "" && cboCategoria.SelectedIndex != -1)
            {
                try
                {
                    unGasto.Descripcion = txtDescripcion.Text;
                    decimal monto = decimal.Parse(nroMonto.Text);
                    monto = manager.TransformarMonto(monto);
                    unGasto.Fecha = dateFecha.Value;
                    unGasto.Moneda = (Moneda)cbo_Monedas.SelectedItem;
                    unGasto.CotizacionActual = unGasto.Moneda.Cotizacion;
                    unGasto.Monto = monto;
                    unGasto.Categoria = (Categoria)cboCategoria.SelectedItem;
                    txtDescripcion.Text = "";
                    nroMonto.Text = "";
                    cboCategoria.SelectedIndex = -1;
                    manager.ValidacionAgregarGasto(unGasto);
                    MessageBox.Show("El gasto fue registrado correctamente");
                    unGasto = new Gasto();
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
            listBox1.DataSource = null;
            listBox1.DataSource = Repo.GetGastos().GetAll();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbo_Monedas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nroMonto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
