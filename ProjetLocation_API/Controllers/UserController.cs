using System.Collections.Generic;
using System.Linq;
using DAL.IRepositories;
using DAL.Models;
using ProjetLocation.API.Models.User;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository<Role, User, Good> _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<UserWithGoods> users = _userRepository.GetAll().Select(x => x.DALUserWithGoodsToAPI());

            if (!(users is null))
                return Ok(users);
            else
                return Problem(detail: "Users not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            UserWithGoods user = _userRepository.GetById(id).DALUserWithGoodsToAPI();

            if (!(user is null))
                return Ok(user);
            else
                return Problem(detail: "User not found",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [HttpGet("{id}/role")]
        public IActionResult GetRoleByUserId(int id)
        {
            Role role = _userRepository.GetRoleByUserId(id);

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
            int Successful = _userRepository.Update(id, user.APIUserInfoToDAL());

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to update user",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}/password")]
        public IActionResult PutPassword(int id, [FromBody] UserPassword user) // POSTMAN OK
        {
            int Successful = _userRepository.UpdatePassword(id, user.APIUserPasswordToDAL());

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to change password",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _userRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to desactivate user",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
