using System.Collections.Generic;
using System.Linq;
using System.Net;
using DAL.IRepositories;
using Dal = DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Api = ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    //[Authorize]
    //[Roles(Roles.Admin, Roles.SuperAdmin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository<Dal.User> _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.User> users = _userRepository.GetAll().Select(x => x.DALUserToAPI());

            if (!(users is null))
                return Ok(users);
            else
                return NotFound();
        }

        // GET api/<UserController>/5
        //[Roles(Roles.User)]
        [HttpGet("{id}")]
        public IActionResult Get(int id) // POSTMAN OK
        {
            Api.User user = _userRepository.Get(id).DALUserToAPI();

            if (!(user is null))
                return Ok(user);
            else
                return NotFound();
        }

        // PUT api/<UserController>/5
        //[Roles(Roles.User)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.UserInfo user) // POSTMAN OK
        {
            int Successful = _userRepository.Update(id, user.APIUserInfoToDAL());

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to update user informations !",
                               statusCode: (int)HttpStatusCode.Unauthorized);
        }

        // PUT api/<UserController>/5
        //[Roles(Roles.User)]
        [HttpPut("{id}/pwd")]
        public IActionResult PutPassword(int id, [FromBody] Api.UserPassword user)
        {
            int Successful = _userRepository.UpdatePassword(id, user.APIUserPasswordToDAL());

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Same password as the previous one !",
                               statusCode: (int)HttpStatusCode.Unauthorized);
        }

        // DELETE api/<UserController>/5
        //[Roles(Roles.User)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // POSTMAN OK
        {
            int Successful = _userRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
