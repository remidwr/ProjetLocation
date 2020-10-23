using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

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
            try
            {
                _userService.Delete(id);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("User Linked To Current Rental"))
                    return Problem(detail: "Vous ne pouvez pas désactiver votre compte car vous avez une ou plusieurs locations en cours.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
