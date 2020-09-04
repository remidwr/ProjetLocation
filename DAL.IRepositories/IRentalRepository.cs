namespace DAL.IRepositories
{
    public interface IRentalRepository<TRental> : IGenericRepository<TRental>
    {
        int UpdateRating(int id, TRental entity);
    }
}
