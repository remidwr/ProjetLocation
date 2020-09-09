using DAL.Repositories;
using System.Linq;
using Api = ProjetLocation.API.Models.User;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class UserMapperAPI
    {
        private static UserRepository _userRepository;

        public static UserRepository userRepository
        {
            get
            {
                return new UserRepository();
            }
        }

        internal static Api.UserFull DALUserToAPI(this Dal.User user)
        {
            if (!(user is null))
            {
                return new Api.UserFull()
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Birthdate = user.Birthdate,
                    Email = user.Email,
                    Passwd = user.Passwd,
                    Street = user.Street,
                    Number = user.Number,
                    Box = user.Box,
                    PostCode = user.PostCode,
                    City = user.City,
                    Phone1 = user.Phone1,
                    Phone2 = user.Phone2,
                    Picture = user.Picture,
                    IsActive = user.IsActive,
                    IsBanned = user.IsBanned,
                    RoleId = user.RoleId,
                    Token = user.Token
                };
            }
            else
                return null;
        }

        internal static Dal.User APIUserToDAL(this Api.UserFull user)
        {
            return new Dal.User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Passwd = user.Passwd,
                Street = user.Street,
                Number = user.Number,
                Box = user.Box,
                PostCode = user.PostCode,
                City = user.City,
                Phone1 = user.Phone1,
                Phone2 = user.Phone2,
                Picture = user.Picture,
                IsActive = user.IsActive,
                IsBanned = user.IsBanned,
                RoleId = user.RoleId,
                Token = user.Token
            };
        }

        internal static Api.UserWithGoods DALUserWithGoodsToAPI(this Dal.User user)
        {
            if (!(user is null))
            {
                return new Api.UserWithGoods()
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Birthdate = user.Birthdate,
                    Email = user.Email,
                    Street = user.Street,
                    Number = user.Number,
                    Box = user.Box,
                    PostCode = user.PostCode,
                    City = user.City,
                    Phone1 = user.Phone1,
                    Phone2 = user.Phone2,
                    Picture = user.Picture,
                    Goods = userRepository.GetGoodsByUserId(user.Id).Select(x => x)
                };
            }
            else
                return null;
        }

        internal static Dal.User APIUserWithGoodsToDAL(this Api.UserWithGoods user)
        {
            return new Dal.User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Street = user.Street,
                Number = user.Number,
                Box = user.Box,
                PostCode = user.PostCode,
                City = user.City,
                Phone1 = user.Phone1,
                Phone2 = user.Phone2,
                Picture = user.Picture
            };
        }

        internal static Api.UserLogin DALUserLoginToAPI(this Dal.User user)
        {
            return new Api.UserLogin()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Dal.User APIUserLoginToDAL(this Api.UserLogin user)
        {
            return new Dal.User()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Api.UserRegister DALUserRegisterToAPI(this Dal.User user)
        {
            return new Api.UserRegister()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Dal.User APIUserRegisterToDAL(this Api.UserRegister user)
        {
            return new Dal.User()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Api.UserInfo DALUserInfoToAPI(this Dal.User user)
        {
            return new Api.UserInfo()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Street = user.Street,
                Number = user.Number,
                Box = user.Box,
                PostCode = user.PostCode,
                City = user.City,
                Phone1 = user.Phone1,
                Phone2 = user.Phone2,
                Picture = user.Picture
            };
        }

        internal static Dal.User APIUserInfoToDAL(this Api.UserInfo user)
        {
            return new Dal.User()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Street = user.Street,
                Number = user.Number,
                Box = user.Box,
                PostCode = user.PostCode,
                City = user.City,
                Phone1 = user.Phone1,
                Phone2 = user.Phone2,
                Picture = user.Picture
            };
        }

        internal static Api.UserPassword DALUserPasswordToAPI(this Dal.User user)
        {
            return new Api.UserPassword()
            {
                Passwd = user.Passwd
            };
        }

        internal static Dal.User APIUserPasswordToDAL(this Api.UserPassword user)
        {
            return new Dal.User()
            {
                Passwd = user.Passwd
            };
        }
    }
}
