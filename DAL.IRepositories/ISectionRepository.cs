using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface ISectionRepository<TSection, TCategory> : IGenericRepository<TSection>
    {
        IEnumerable<TCategory> GetCategoriesBySectionId(int id);
    }
}
