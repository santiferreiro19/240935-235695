using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces
{
    class Class1

    {
        [STAThread]
        static void Main(string[] args)

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Categoria InterfazCategoria = new Categoria();
            InterfazCategoria.Show();
        }

    }
}
