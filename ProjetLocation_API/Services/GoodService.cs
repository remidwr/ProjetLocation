using DAL.IRepositories;
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
            try
            {
                _goodRepository.Delete(goodId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
