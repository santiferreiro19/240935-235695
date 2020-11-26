using System.Windows.Forms;

namespace Obligatorio_1___DA1.Serializacion
{
    public interface IEstrategiaExportar
    {
        void Imprimir(DataGridView datos, string direccionArchivo);
    }
}
