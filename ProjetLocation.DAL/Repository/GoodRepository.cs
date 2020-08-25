using ProjetLocation.DAL.IRepository;
using ProjetLocation.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetLocation.DAL.Repository
{
    public class GoodRepository : IGoodRepository<Good>
    {
        public Good Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Good> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Good good)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Good good)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
