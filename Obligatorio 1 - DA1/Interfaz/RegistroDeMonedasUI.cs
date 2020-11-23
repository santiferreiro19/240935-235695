using Managers;
using Obligatorio_1___DA1;
using Obligatorio_1___DA1.Excepciones;
using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class RegistroDeMonedasUI : UserControl
    {
        private Repositorio Repo;
        private Moneda unaMonedaLocal;

        public RegistroDeMonedasUI(Repositorio unRepositorio)
        {
            unaMonedaLocal = new Moneda();
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void RegistroDeMonedasUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerMoneda manager = new ManagerMoneda(Repo);
            if (txtNombre.Text != "" && txtSimbolo.Text != "" && nroCotizacion.Value > 0.00M && !BloqueoPesoUruguayo())
            {
                try
                {
                    unaMonedaLocal.Nombre = txtNombre.Text;
                    unaMonedaLocal.Simbolo = txtSimbolo.Text;
                    unaMonedaLocal.Cotizacion = decimal.Parse(nroCotizacion.Text);
                    manager.ValidacionAgregarMoneda(unaMonedaLocal);
                    unaMonedaLocal.Nombre = "";
                    unaMonedaLocal.Simbolo = "";
                    unaMonedaLocal.Cotizacion = 0.00M;
                    
                    MessageBox.Show("La moneda fue registrada correctamente");
                    unaMonedaLocal = new Moneda();
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
                else
                {
                    MessageBox.Show("No se puede agregar otro Peso Uruguayo");
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void nroCotizacion_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSimbolo_TextChanged(object sender, EventArgs e)
        {

        }
        public bool BloqueoPesoUruguayo()
        {
            return txtSimbolo.Text == "UYU";
        }
    }
}
