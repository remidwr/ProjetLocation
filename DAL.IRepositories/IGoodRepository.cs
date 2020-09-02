using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IGoodRepository<TGood>
    {
        IEnumerable<TGood> GetAll();
        TGood Get(int id);
        int Insert(TGood good);
        int Update(int id, TGood good);
        int Delete(int id);
    }
}
