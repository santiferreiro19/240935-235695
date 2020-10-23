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
    public partial class ReportePresupuestoUI : Form
    {
        private Repositorio Repo;
        public ReportePresupuestoUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void ReportePresupuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
