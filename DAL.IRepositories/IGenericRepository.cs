using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IGenericRepository<Tentity>
    {
        IEnumerable<Tentity> GetAll();
        Tentity GetById(int id);
        int Insert(Tentity entity);
        int Update(int id, Tentity entity);
        int Delete(int id);
    }
}
