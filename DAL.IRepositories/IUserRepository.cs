using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IUserRepository<TUser, TGood> : IGenericRepository<TUser>
    {
        IEnumerable<TGood> GetGoodsByUserId(int id);
        int UpdatePassword(int id, TUser user);
    }
}
