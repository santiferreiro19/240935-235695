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
    public partial class ModificacionMonedaUI : UserControl
    {
        private Repositorio Repo;
        private Moneda MonedaSeleccionada;
        public ModificacionMonedaUI(Repositorio repositorio)
        {
            MonedaSeleccionada = new Moneda();
            Repo = repositorio;
            InitializeComponent();
        }

        private void ModificacionMonedaUI_Load(object sender, EventArgs e)
        {
            CargarListBox();
        }
        public void CargarListBox()
        {
            lstMonedas.DataSource = null;
            lstMonedas.DataSource = Repo.GetMonedas().GetAll();
            lstMonedas.SelectedIndex = -1;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstMonedas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lstMonedas.Text != "")
            {
                panelModificacion.Visible = true;
                MonedaSeleccionada = (Moneda)lstMonedas.SelectedItem;
                txtNombre.Text = MonedaSeleccionada.Nombre;
                txtSimbolo.Text = MonedaSeleccionada.Simbolo;
                nroCotizacion.Text = MonedaSeleccionada.Cotizacion.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una moneda");
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelModificacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            ManagerMoneda manager = new ManagerMoneda(Repo);

            if (txtNombre.Text != "" && txtSimbolo.Text != "" && nroCotizacion.Value > 0.00M && !BloqueoPesoUruguayo())
            {
                decimal Cotizacion = decimal.Parse(nroCotizacion.Text);
                try
                {
                    Moneda MonedaTemporal = new Moneda();
                    MonedaTemporal.Nombre = txtNombre.Text;
                    MonedaTemporal.Simbolo = txtSimbolo.Text;
                    MonedaTemporal.Cotizacion = decimal.Parse(nroCotizacion.Text);
                    manager.ValidacionModificacionMoneda(MonedaSeleccionada, MonedaTemporal);
                    MonedaSeleccionada = new Moneda();
                    txtNombre.Text = "";
                    txtSimbolo.Text = "";
                    nroCotizacion.Value = 0.00M;
                    panelModificacion.Visible = false;
                }
                catch (ExceptionNombreMoneda nombre)
                {
                    MessageBox.Show("El nombre debe ser entre 3 y 20 caracteres");
                }
                catch (ExceptionSimboloMoneda simnolo)
                {
                    MessageBox.Show("El simbolo debe ser entre 1 y 3 caracteres");
                }
                catch (ExceptionCotizacion cotizacion)
                {
                    MessageBox.Show("La cotizacion debe de ser mayor a 0");
                }
            }
            else
            {
                if (txtNombre.Text == "" || txtSimbolo.Text == "" || nroCotizacion.Value <= 0.00M)
                {
                    MessageBox.Show("Hay campos vacios");
                }
                else {
                    MessageBox.Show("Peso Uruguayo no se puede modificar");
                }
                
            }
            CargarListBox();
            txtNombre.Text = MonedaSeleccionada.Nombre;
            txtSimbolo.Text = MonedaSeleccionada.Simbolo;
            nroCotizacion.Text = MonedaSeleccionada.Cotizacion.ToString();
        }

        public bool BloqueoPesoUruguayo() {
            return MonedaSeleccionada.Simbolo == "UYU";
        }
    }
}
