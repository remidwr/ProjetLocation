using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface ISectionRepository<TSection>
    {
        IEnumerable<TSection> GetAll();
        TSection Get(int id);
        int Insert(TSection section);
        int Update(int id, TSection section);
        int Delete(int id);
    }
}
