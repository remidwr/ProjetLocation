using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ProjetLocation.API.Services
{
    public class RoleService
    {
        private IRoleRepository _roleRepository;
        private UserRepository _userRepository;

        public RoleService(RoleRepository roleRepository, UserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<RoleWithUsers> GetAll()
        {
            List<RoleWithUsers> roles = _roleRepository.GetAll().Select(x => x.DALRoleWithUsersToAPI()).ToList();

            if (!(roles is null))
            {
                foreach (RoleWithUsers role in roles)
                {
                    role.Users = _userRepository.GetAll().Select(x => x.DALUserInfoToAPI());
                }
            }


            return roles;
        }

        public RoleWithUsers GetById(int roleId)
        {
            RoleWithUsers role = _roleRepository.GetById(roleId).DALRoleWithUsersToAPI();

            if (!(role is null))
            {
                role.Users = _userRepository.GetAll().Select(x => x.DALUserInfoToAPI());
            }

            return role;
        }
    }
}
