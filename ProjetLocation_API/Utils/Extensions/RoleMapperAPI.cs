using DAL.Models;
using ProjetLocation.API.Models.User;

namespace ProjetLocation.API.Utils.Extensions
{
    internal static class RoleMapperAPI
    {
        internal static RoleWithUsers DALRoleWithUsersToAPI(this Role role)
        {
            return new RoleWithUsers()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        internal static Role APIRoleWithUsersToDAL(this RoleWithUsers role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
