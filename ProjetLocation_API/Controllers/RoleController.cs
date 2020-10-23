using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;
using System.Collections.Generic;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<RoleWithUsers> roles = _roleService.GetAll();

            if (!(roles is null))
                return Ok(roles);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            RoleWithUsers role = _roleService.GetById(id);

            if (!(role is null))
                return Ok(role);
            else
                return NotFound();
        }
    }
}
