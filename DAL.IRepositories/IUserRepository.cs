using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IUserRepository<TRole, TUser, TGood> : IGenericRepository<TUser>
    {
        TRole GetRoleByUserId(int id);
        IEnumerable<TGood> GetGoodsByUserId(int id);
        void UpdatePicture(int id, TUser user);
        void UpdatePassword(int id, TUser user);
    }
}
