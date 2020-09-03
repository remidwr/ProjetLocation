using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IRentalRepository<TRental>
    {
        IEnumerable<TRental> GetAll();
        TRental Get(int id);
        int Insert(TRental rental);
        int Update(int id, TRental rental);
        int Delete(int id);
    }
}
