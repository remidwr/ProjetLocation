using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IUserRepository<TUser>
    {
        IEnumerable<TUser> GetAll();
        TUser Get(int id);
        int Update(int id, TUser user);
        int Delete(int id);
    }
}
