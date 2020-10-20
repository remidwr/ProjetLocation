using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class RoleService
    {
        private IRoleRepository<Role, User> _roleRepository;
        private IUserRepository<Role, User, Good> _userRepository;

        public RoleService(RoleRepository roleRepository, UserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<RoleWithUsers> GetAll()
        {
            List<RoleWithUsers> roles = _roleRepository.GetAll().Select(x => x.DALRoleWithUsersToAPI()).ToList();
            foreach (RoleWithUsers role in roles)
            {
                role.Users = _userRepository.GetAll().Select(x => x.DALUserInfoToAPI());
            }

            return roles;
        }

        public RoleWithUsers GetById(int roleId)
        {
            RoleWithUsers role = _roleRepository.GetById(roleId).DALRoleWithUsersToAPI();
            role.Users = _userRepository.GetAll().Select(x => x.DALUserInfoToAPI());

            return role;
        }
    }
}
