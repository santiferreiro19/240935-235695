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
            CargarCbox();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarCbox();
            ManagerGasto manager = new ManagerGasto(Repo);
            string descripcion = txtDescripcion.Text;

            cboCategoria.SelectedItem = manager.ValidacionBusquedaCategorias(descripcion);
            listBox1.DataSource = null;
            listBox1.DataSource = Repo.GetGastos().GetAll();
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
                    monto = (monto * unGasto.Moneda.Cotizacion);
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
