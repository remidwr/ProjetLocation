using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IRoleRepository<TRole, TUser>
    {
        IEnumerable<TRole> GetAll();
        TRole GetById(int id);
    }
}
