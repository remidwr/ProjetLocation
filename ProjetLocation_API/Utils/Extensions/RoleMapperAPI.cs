using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.User;
using System.Linq;
using DAL.Repositories;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RoleMapperAPI
    {
        private static RoleRepository _roleRepository;

        public static RoleRepository roleRepository
        {
            get
            {
                return new RoleRepository();
            }
        }

        internal static Api.RoleWithUsers DALRoleWithUsersToAPI(this Dal.Role role)
        {
            return new Api.RoleWithUsers()
            {
                Id = role.Id,
                Name = role.Name,
                Users = roleRepository.GetUsersByRoleId(role.Id).Select(x => x.DALUserInfoToAPI())
            };
        }

        internal static Dal.Role APIRoleWithUsersToDAL(this Api.RoleWithUsers role)
        {
            return new Dal.Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
