using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Models.User;
using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Utils.Extensions;
using System.Net;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepository<Role, User> _roleRepository;

        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<RoleWithUsers> roles = _roleRepository.GetAll().Select(x => x.DALRoleWithUsersToAPI());

            if (!(roles is null))
                return Ok(roles);
            else
                return Problem(detail: "Rôles introuvables.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            RoleWithUsers role = _roleRepository.GetById(id).DALRoleWithUsersToAPI();

            if (!(role is null))
                return Ok(role);
            else
                return Problem(detail: "Rôles introuvable.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
