using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public interface ILista<T> 
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entidad);
        void Remove(T entidad);
        bool Contains(T entidad);

        void Update(T entidad);
    }
}
