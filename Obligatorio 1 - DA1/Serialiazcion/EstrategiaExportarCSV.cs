using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Obligatorio_1___DA1.Serializacion
{
    public class EstrategiaExportarCSV : IEstrategiaExportar
    {
        public void Imprimir(DataGridView datos, string direccionArchivo)
        {
            StreamWriter sw = new StreamWriter(direccionArchivo, false);
            //headers    
            sw.WriteLine("FECHA,DESCRIPCION,CATEGORIA,MONEDA,MONTO");
            foreach (DataGridViewRow dr in datos.Rows)
            {
                DateTime generico = (DateTime)dr.Cells["Fecha"].Value;
                String fecha = generico.ToShortDateString();
                String descripcion = FormatearLinea(dr.Cells["Descripcion"].Value.ToString());
                String categoria = FormatearLinea(dr.Cells["Categoria"].Value.ToString());
                String moneda = FormatearLinea(dr.Cells["Moneda"].Value.ToString());
                String monto = FormatearLinea(dr.Cells["Monto"].Value.ToString());
                sw.WriteLine(fecha + "," + descripcion + "," + categoria + "," + moneda + "," + monto);
            }
            sw.Close();
        }
        public String FormatearLinea(String unaLinea)
        {
            string linea = unaLinea;
            if (linea.Contains(','))
            {
                linea = String.Format("\"{0}\"", linea);
            }
            return linea;
        }

    }
}
