using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class GoodService
    {
        private readonly GoodRepository _goodRepository;

        public GoodService(GoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        public IEnumerable<GoodWithUser> GetAll()
        {
            IEnumerable<GoodWithUser> goods = _goodRepository.GetAll().Select(x => x.DALGoodWithUserToAPI());

            if (!(goods is null))
            {
                foreach (GoodWithUser good in goods)
                {
                    good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                    good.Category = _goodRepository.GetCategoryByGoodId(good.Id).DALCategoryToAPI();
                    good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();
                }
            }

            return goods;
        }

        public GoodWithUser GetById(int goodId)
        {
            GoodWithUser good = _goodRepository.GetById(goodId).DALGoodWithUserToAPI();

            if (!(good is null))
            {
                good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                good.Category = _goodRepository.GetCategoryByGoodId(good.Id).DALCategoryToAPI();
                good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();
            }

            return good;
        }

        public void Post(Good good)
        {
            try
            {
                _goodRepository.Insert(good);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Put(int goodId, Good good)
        {
            try
            {
                _goodRepository.Update(goodId, good);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int goodId)
        {
            _goodRepository.Delete(goodId);
        }
    }
}
