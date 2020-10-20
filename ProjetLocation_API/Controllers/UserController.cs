using System.Collections.Generic;
using ProjetLocation.API.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;
using System.Net;
using System;
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
            IEnumerable<UserFull> users = _userService.GetAll();

            if (!(users is null))
                return Ok(users);
            else
                return Problem(statusCode: (int)HttpStatusCode.NoContent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserFull user = _userService.GetById(id);

            if (!(user is null))
                return Ok(user);
            else
                return Problem(statusCode: (int)HttpStatusCode.NoContent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInfo user)
        {
            try
            {
                _userService.Put(id, user);
            }
            catch (Exception)
            {
                return Problem(detail: "Impossible de modifier les données utilisateur.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [HttpPut("{id}/picture")]
        public IActionResult PutPicture(int id, [FromBody] UserInfo user)
        {
            try
            {
                _userService.PutPicture(id, user);
            }
            catch (Exception)
            {
                return Problem(detail: "Impossible de modifier votre image de profil.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [HttpPut("{id}/password")]
        public IActionResult PutPassword(int id, [FromBody] UserFull user)
        {
            try
            {
            _userService.PutPassword(id, user);
            }
            catch (Exception)
            {
                return Problem(detail: "Modification de votre mot de passe impossible.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
            }
            catch (Exception)
            {
                return Problem(detail: "Impossible de supprimer ce compte.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
