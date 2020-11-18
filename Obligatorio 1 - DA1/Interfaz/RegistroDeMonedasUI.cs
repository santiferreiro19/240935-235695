using Obligatorio_1___DA1;
using Managers;
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

namespace Interfaz
{
    public partial class RegistroDeMonedasUI : UserControl
    {
        private Repositorio Repo;
        private Moneda unaMonedaLocal;

        public RegistroDeMonedasUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void RegistroDeMonedasUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerMoneda manager = new ManagerMoneda(Repo);

        }
    }
}
