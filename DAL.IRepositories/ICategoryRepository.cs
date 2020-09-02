using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface ICategoryRepository<TCategory>
    {
        IEnumerable<TCategory> GetAll();
        TCategory Get(int id);
        int Insert(TCategory category);
        int Update(int id, TCategory category);
        int Delete(int id);
    }
}
