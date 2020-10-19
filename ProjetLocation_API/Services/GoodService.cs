using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class GoodService
    {
        IGoodRepository<Good, User, Section, Category> _goodRepository;

        public GoodService(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        public IEnumerable<GoodFull> GetAll()
        {
            IEnumerable<GoodFull> goods = _goodRepository.GetAll().Select(x => x.DALGoodFullToAPI());
            foreach (GoodFull good in goods)
            {
                good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                good.Category = _goodRepository.GetCategoryByGoodId(good.Id);
                good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();
            }

            return goods;
        }

        public GoodFull GetById(int goodId)
        {
            GoodFull good = _goodRepository.GetById(goodId).DALGoodFullToAPI();
            good.Section = _goodRepository.GetSectionByGoodId(good.Id);
            good.Category = _goodRepository.GetCategoryByGoodId(good.Id);
            good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();

            return good;
        }

        public UserInfo GetUserByGoodId(int goodId)
        {
            UserInfo user = _goodRepository.GetUserByGoodId(goodId).DALUserInfoToAPI();

            return user;
        }

        public int Post(Good good)
        {
            int Successful = _goodRepository.Insert(good);

            return Successful;
        }

        public int Put(int goodId, Good good)
        {
            int Successful = _goodRepository.Update(goodId, good);

            return Successful;
        }

        public int Delete(int goodId)
        {
            int Successful = _goodRepository.Delete(goodId);

            return Successful;
        }
    }
}
