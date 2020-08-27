using Api = ProjetLocation.API.Models.User;
using Dal = DAL.Models;

namespace ProjetLocation.API.Utils.Mappers
{
    internal static class UserMapperAPI
    {
        internal static Api.LoginForm DALUserLoginToAPI(this Dal.User user)
        {
            return new Api.LoginForm()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Dal.User APIUserLoginToDAL(this Api.LoginForm user)
        {
            return new Dal.User()
            {
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Api.RegisterForm DALUserRegisterToAPI(this Dal.User user)
        {
            return new Api.RegisterForm()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Passwd = user.Passwd
            };
        }

        internal static Dal.User APIUserRegisterToDAL(this Api.RegisterForm user)
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
