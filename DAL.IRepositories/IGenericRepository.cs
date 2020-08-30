using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        int Insert(T entity);
        int Update(string id, T entity);
        void Delete(int id);
    }
}
