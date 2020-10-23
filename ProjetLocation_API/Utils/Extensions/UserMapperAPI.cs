using DAL.Models;
using ProjetLocation.API.Models.User;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class UserMapperAPI
    {
        internal static UserFull DALUserFullToAPI(this User user)
        {
            if (!(user is null))
            {
                return new UserFull()
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    BirthDate = user.BirthDate,
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

        internal static User APIUserFullToDAL(this UserFull user)
        {
            return new User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
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

        internal static UserSimple DALUserSimpleToAPI(this User user)
        {
            if (!(user is null))
            {
                return new UserSimple()
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    Token = user.Token
                };
            }
            else
                return null;
        }

        internal static User APIUserSimpleToDAL(this UserSimple user)
        {
            return new User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                RoleId = user.RoleId,
                Token = user.Token
            };
        }
        internal static UserData DALUserDataToAPI(this User user)
        {
            if (!(user is null))
            {
                return new UserData()
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
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
                    RoleId = user.RoleId
                };
            }
            else
                return null;
        }

        internal static User APIUserDataToDAL(this UserData user)
        {
            return new User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                Email = user.Email,
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
                RoleId = user.RoleId
            };
        }

        internal static UserLogin DALUserLoginToAPI(this User user)
        {
            return new UserLogin()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static User APIUserLoginToDAL(this UserLogin user)
        {
            return new User()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static UserRegister DALUserRegisterToAPI(this User user)
        {
            return new UserRegister()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static User APIUserRegisterToDAL(this UserRegister user)
        {
            return new User()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static UserInfo DALUserInfoToAPI(this User user)
        {
            return new UserInfo()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
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

        internal static User APIUserInfoToDAL(this UserInfo user)
        {
            return new User()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
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

        internal static UserPasswd DALUserPasswdToAPI(this User user)
        {
            return new UserPasswd()
            {
                Id = user.Id,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static User APIUserPasswdToDAL(this UserPasswd user)
        {
            return new User()
            {
                Id = user.Id,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }
    }
}
