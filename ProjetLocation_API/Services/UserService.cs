using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.Good;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class UserService
    {
        private IUserRepository<Role, User, Good> _userRepository;
        private IGoodRepository<Good, User, Section, Category> _goodRepository;

        public UserService(UserRepository userRepository, GoodRepository goodRepository)
        {
            _userRepository = userRepository;
            _goodRepository = goodRepository;
        }

        public IEnumerable<UserFull> GetAll()
        {
            List<UserFull> users = _userRepository.GetAll().Select(x => x.DALUserFullToAPI()).ToList();
            foreach (UserFull user in users)
            {
                List<GoodFull> goods = _userRepository.GetGoodsByUserId(user.Id).Select(x => x.DALGoodFullToAPI()).ToList();
                foreach (GoodFull good in goods)
                {
                    good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                    good.Category = _goodRepository.GetCategoryByGoodId(good.Id);
                    good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();
                }
                user.Goods = goods;

                Role role = _userRepository.GetRoleByUserId(user.Id);
                user.RoleName = role.Name;
            }

            return users;
        }

        public UserFull GetById(int userId)
        {
            UserFull user = _userRepository.GetById(userId).DALUserFullToAPI();
            List<GoodFull> goods = _userRepository.GetGoodsByUserId(user.Id).Select(x => x.DALGoodFullToAPI()).ToList();
            foreach (GoodFull good in goods)
            {
                good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                good.Category = _goodRepository.GetCategoryByGoodId(good.Id);
                good.User = _goodRepository.GetUserByGoodId(good.Id).DALUserInfoToAPI();
            }
            user.Goods = goods;

            Role role = _userRepository.GetRoleByUserId(userId);
            user.RoleName = role.Name;

            return user;
        }

        public void Put(int userId, UserInfo user)
        {
            try
            {
                _userRepository.Update(userId, user.APIUserInfoToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void PutPicture(int userId, UserInfo user)
        {
            try
            {
                _userRepository.UpdatePicture(userId, user.APIUserInfoToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void PutPassword(int userId, UserFull user)
        {
            try
            {
                _userRepository.UpdatePassword(userId, user.APIUserFullToDAL());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Delete(int userId)
        {
            try
            {
                _userRepository.Delete(userId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
