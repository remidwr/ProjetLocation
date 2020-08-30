using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class GoodRepository : IGenericRepository<Good>
    {
        public IEnumerable<Good> GetAll()
        {
            throw new NotImplementedException();
        }

        public Good Get(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Good entity)
        {
            throw new NotImplementedException();
        }

        public int Update(string id, Good entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
