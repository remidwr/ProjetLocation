using System.Collections.Generic;
using ProjetLocation.API.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<UserData> users = _userService.GetAll();

            if (!(users is null))
                return Ok(users);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserData user = _userService.GetById(id);

            if (!(user is null))
                return Ok(user);
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInfo user)
        {
            _userService.Put(id, user);

            return Ok();
        }

        [HttpPut("{id}/picture")]
        public IActionResult PutPicture(int id, [FromBody] UserInfo user)
        {
            _userService.PutPicture(id, user);

            return Ok();
        }

        [HttpPut("{id}/password")]
        public IActionResult PutPassword(int id, [FromBody] UserPasswd user)
        {
            _userService.PutPassword(id, user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}
