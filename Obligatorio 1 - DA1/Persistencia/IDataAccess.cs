using System.Collections.Generic;

namespace Persistencia
{
    public interface IDataAccess<T>
    {
        T Get(int id);
        List<T> GetAll();
        void Add(T entidad);
        void Remove(T entidad);
        bool Contains(T entidad);

        void Update(T entidad);
    }
}
