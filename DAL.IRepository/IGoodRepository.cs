using System.Collections.Generic;

namespace DAL.IRepository
{
    public interface IGoodRepository<TGood>
    {
        IEnumerable<TGood> GetAll();
        TGood Get(int id);
        void Insert(TGood good);
        void Update(int id, TGood good);
        void Delete(int id);
    }
}
