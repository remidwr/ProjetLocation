using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IUserRepository<TRole, TUser, TGood> : IGenericRepository<TUser>
    {
        TRole GetRoleByUserId(int id);
        IEnumerable<TGood> GetGoodsByUserId(int id);
        int UpdatePassword(int id, TUser user);
    }
}
