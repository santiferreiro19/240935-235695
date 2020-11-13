using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface IDataAccess<T> 
    {
        T Obtener(int id);
        IEnumerable<T> ObtenerTodos();
        void Agregar(T entidad);
        void Eliminar(T entidad);
    }
}
