using System;
using System.Windows.Forms;

namespace Obligatorio_1___DA1.Serializacion
{
    public class EstrategiaExportarTXT : IEstrategiaExportar
    {
        public void Imprimir(DataGridView datos, string direccionArchivo)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(direccionArchivo);
            try
            {
                string sLine = "";
                for (int i = 0; i <= datos.Rows.Count - 1; i++)
                {
                    DateTime generico = (DateTime)datos.Rows[i].Cells["Fecha"].Value;
                    file.WriteLine(generico.ToShortDateString());
                    file.WriteLine(datos.Rows[i].Cells["Descripcion"].Value);
                    file.WriteLine(datos.Rows[i].Cells["Categoria"].Value);
                    file.WriteLine(datos.Rows[i].Cells["Moneda"].Value);
                    file.WriteLine(datos.Rows[i].Cells["Monto"].Value);
                    sLine = "####";
                    file.WriteLine(sLine);
                }
                file.Close();
            }
            catch (System.Exception err)
            {
                file.Close();
            }
        }

    }
}
