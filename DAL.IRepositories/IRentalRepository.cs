namespace DAL.IRepositories
{
    public interface IRentalRepository<TRental, TUser, TGood> : IGenericRepository<TRental>
    {
        TUser GetOwnerByRentalId(int id);
        TUser GetTenantByRentalId(int id);
        TGood GetGoodByRentalId(int id);
        void UpdateRating(int id, TRental entity);
    }
}
