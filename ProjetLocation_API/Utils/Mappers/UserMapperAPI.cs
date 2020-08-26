using Api = ProjetLocation.API.Models.User;
using Dal = ProjetLocation.DAL.Models;

namespace ProjetLocation.API.Utils.Mappers
{
    internal static class UserMapperAPI
    {
        internal static Api.UserLogin DALUserLoginToAPI(this Dal.User user)
        {
            return new Api.UserLogin()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                IsAdmin = user.IsAdmin,
                Token = user.Token
            };
        }

        internal static Dal.User APIUserLoginToDAL(this Api.UserLogin user)
        {
            return new Dal.User()
            {
                Email = user.Email,
                Passwd = user.Passwd,
                IsAdmin = user.IsAdmin,
                Token = user.Token
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
    }
}
