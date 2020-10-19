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
            IEnumerable<UserFull> users = _userRepository.GetAll().Select(u => u.DALUserFullToAPI());
            foreach (UserFull user in users)
            {
                List<GoodFull> goods = _userRepository.GetGoodsByUserId(user.Id).Select(x => x.DALGoodFullToAPI()).ToList();
                foreach (GoodFull good in goods)
                {
                    good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                    good.Category = _goodRepository.GetCategoryByGoodId(good.Id);
                }
                user.Goods = goods;
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
            }
            user.Goods = goods;

            return user;
        }

        public Role GetRoleByUserId(int userId)
        {
            Role role = _userRepository.GetRoleByUserId(userId);

            return role;
        }

        public int Put(int userId, UserInfo user)
        {
            int Successful = _userRepository.Update(userId, user.APIUserInfoToDAL());

            return Successful;
        }

        public int PutPassword(int userId, UserFull user)
        {
            int Successful = _userRepository.UpdatePassword(userId, user.APIUserFullToDAL());

            return Successful;
        }

        public int Delete(int userId)
        {
            int Successful = _userRepository.Delete(userId);

            return Successful;
        }
    }
}
