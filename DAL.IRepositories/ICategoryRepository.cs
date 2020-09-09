namespace DAL.IRepositories
{
    public interface ICategoryRepository<TCategory, TSection> : IGenericRepository<TCategory>
    {
        TSection GetSectionByCategoryId(int id);
    }
}
