using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IRoleRepository<TRole>
    {
        IEnumerable<TRole> GetAll();
        TRole GetById(int id);
    }
}
