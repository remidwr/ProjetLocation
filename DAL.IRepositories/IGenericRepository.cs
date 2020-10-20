using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IGenericRepository<Tentity>
    {
        IEnumerable<Tentity> GetAll();
        Tentity GetById(int id);
        void Insert(Tentity entity);
        void Update(int id, Tentity entity);
        void Delete(int id);
    }
}
