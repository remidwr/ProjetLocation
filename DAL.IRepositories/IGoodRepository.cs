namespace DAL.IRepositories
{
    public interface IGoodRepository<TGood, TUser, TSection, TCategory> : IGenericRepository<TGood>
    {
        TUser GetUserByGoodId(int id);
        TSection GetSectionByGoodId(int id);
        TCategory GetCategoryByGoodId(int id);
    }
}
