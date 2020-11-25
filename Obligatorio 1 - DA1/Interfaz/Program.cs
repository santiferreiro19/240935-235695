using Persistencia;
using System;
using System.Windows.Forms;

namespace Interfaz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Repositorio Repo = new Repositorio();
                Application.Run(new MenuUI(Repo));
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Error: La base de datos no se encuentra disponible");
            }
        }
    }
}
