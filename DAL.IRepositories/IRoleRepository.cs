using DAL.Models;
using System.Collections.Generic;

namespace DAL.IRepositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
    }
}
