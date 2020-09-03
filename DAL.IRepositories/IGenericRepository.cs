using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T entity);
        int Update(int id, T entity);
        int Delete(int id);
    }
}
