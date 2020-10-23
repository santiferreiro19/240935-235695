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
    public partial class PresupuestoUI : Form
    {
        private Repositorio Repo;
        public PresupuestoUI(Repositorio unRepositorio)
        {
            Repo = unRepositorio;
            InitializeComponent();
        }

        private void txtAño_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Presupuesto_Load(object sender, EventArgs e)
        {

        }
    }
}
