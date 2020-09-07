using System.Collections.Generic;
using System.Linq;
using Dal = DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User.RoleName;
using Api = ProjetLocation.API.Models.User;
using DAL.IRepositories;
using DAL.Repositories;
using ProjetLocation.API.Utils.Extensions;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepository<Dal.Role> _roleRepository;

        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.Role> roles = _roleRepository.GetAll().Select(x => x.DALRoleToAPI());

            if (!(roles is null))
                return Ok(roles);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Api.Role role = _roleRepository.GetById(id).DALRoleToAPI();

            if (!(role is null))
                return Ok(role);
            else
                return NotFound();
        }
    }
}
