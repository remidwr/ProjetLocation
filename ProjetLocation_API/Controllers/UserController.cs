using System.Collections.Generic;
using DAL.Models;
using ProjetLocation.API.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;
using System.Net;
using System;
using ProjetLocation.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<UserController>
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<UserFull> users = _userService.GetAll();

            if (!(users is null))
                return Ok(users);
            else
                return Problem(detail: "Utilisateurs non trouvés.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            UserFull user = _userService.GetById(id);

            if (!(user is null))
                return Ok(user);
            else
                return Problem(detail: "Utilisateur non trouvé.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpGet("{id}/role")]
        public IActionResult GetRoleByUserId(int id)
        {
            Role role = _userService.GetRoleByUserId(id);

            if (!(role is null))
                return Ok(role);
            else
                return Problem(detail: "Rôle introuvable",
                                statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInfo user) // POSTMAN OK
        {
            int Successful = _userService.Put(id, user);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de mettre à jour l'utilisateur.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}/password")]
        public IActionResult PutPassword(int id, [FromBody] UserFull user) // POSTMAN OK
        {
            int Successful = _userService.PutPassword(id, user);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Impossible de changer le mot de passe.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            try
            {
                _userService.Delete(id);
            }
            catch (Exception ex)
            {
                return Problem(detail: "Impossible de désactiver l'utilisateur.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            return Ok();
        }
    }
}
