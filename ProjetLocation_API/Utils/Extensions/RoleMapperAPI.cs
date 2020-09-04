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

        internal static Api.Role DALRoleToAPI(this Dal.Role role)
        {
            return new Api.Role()
            {
                Id = role.Id,
                Name = role.Name,
                Users = roleRepository.GetUsersByRoleId(role.Id).Select(x => x.DALUserInfoToAPI())
            };
        }

        internal static Dal.Role APIRoleToDAL(this Api.Role role)
        {
            return new Dal.Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
