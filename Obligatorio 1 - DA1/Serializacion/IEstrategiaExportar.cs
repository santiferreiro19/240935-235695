using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion
{
    public interface IEstrategiaExportar
    {
        void Imprimir(DataTable dtDataTable, string strFilePath);
    }
}
