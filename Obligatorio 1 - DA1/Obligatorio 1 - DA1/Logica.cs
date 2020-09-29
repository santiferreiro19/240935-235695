using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio_1___DA1
{
    public class Logica
    {
        public bool ValidacionNombre(String unNombre)
        {
            int cantidad = unNombre.Length;
            if (cantidad > 15)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
