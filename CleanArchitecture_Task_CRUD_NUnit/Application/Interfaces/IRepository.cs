using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
