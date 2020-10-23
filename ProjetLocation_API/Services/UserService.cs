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
        private readonly UserRepository _userRepository;
        private readonly GoodRepository _goodRepository;

        public UserService(UserRepository userRepository, GoodRepository goodRepository)
        {
            _userRepository = userRepository;
            _goodRepository = goodRepository;
        }

        public IEnumerable<UserData> GetAll()
        {
            List<UserData> users = _userRepository.GetAll().Select(x => x.DALUserDataToAPI()).ToList();

            if (!(users is null))
            {
                foreach (UserData user in users)
                {
                    List<GoodFull> goods = _userRepository.GetGoodsByUserId(user.Id).Select(x => x.DALGoodFullToAPI()).ToList();
                    foreach (GoodFull good in goods)
                    {
                        good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                        good.Category = _goodRepository.GetCategoryByGoodId(good.Id).DALCategoryToAPI();
                    }
                    user.Goods = goods;

                    Role role = _userRepository.GetRoleByUserId(user.Id);
                    user.RoleName = role.Name;
                }
            }

            return users;
        }

        public UserData GetById(int userId)
        {
            UserData user = _userRepository.GetById(userId).DALUserDataToAPI();

            if (!(user is null))
            {
                List<GoodFull> goods = _userRepository.GetGoodsByUserId(user.Id).Select(x => x.DALGoodFullToAPI()).ToList();
                foreach (GoodFull good in goods)
                {
                    good.Section = _goodRepository.GetSectionByGoodId(good.Id);
                    good.Category = _goodRepository.GetCategoryByGoodId(good.Id).DALCategoryToAPI();
                }
                user.Goods = goods;

                Role role = _userRepository.GetRoleByUserId(userId);
                user.RoleName = role.Name;
            }

            return user;
        }

        public void Put(int userId, UserInfo user)
        {
            _userRepository.Update(userId, user.APIUserInfoToDAL());
        }

        public void PutPicture(int userId, UserInfo user)
        {
            _userRepository.UpdatePicture(userId, user.APIUserInfoToDAL());
        }

        public void PutPassword(int userId, UserPasswd user)
        {
            _userRepository.UpdatePassword(userId, user.APIUserPasswdToDAL());
        }

        public void PutRole(int userId, UserSimple user)
        {
            _userRepository.UpdateRole(userId, user.APIUserSimpleToDAL());
        }

        public void PutUserBanned(int userId, UserData user)
        {
            _userRepository.UpdateBanned(userId, user.APIUserDataToDAL());
        }

        public void Delete(int userId)
        {
            try
            {
                _userRepository.Delete(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
