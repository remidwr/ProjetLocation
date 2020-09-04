using System.Collections.Generic;
using System.Linq;
using DAL.IRepositories;
using Dal = DAL.Models;
using Api = ProjetLocation.API.Models.User;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User.RoleName;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
    [Authorize(Roles = Roles.User + "," + Roles.Admin + "," + Roles.SuperAdmin)]
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
        [Authorize(Roles = Roles.Admin + "," + Roles.SuperAdmin)]
        [HttpGet]
        public IActionResult GetAll() // POSTMAN OK
        {
            IEnumerable<Api.UserWithGoods> users = _userRepository.GetAll().Select(x => x.DALUserWithGoodsToAPI());

            if (!(users is null))
                return Ok(users);
            else
                return NotFound();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // POSTMAN OK
        {
            Api.UserWithGoods user = _userRepository.GetById(id).DALUserWithGoodsToAPI();

            if (!(user is null))
                return Ok(user);
            else
                return NotFound();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.UserInfo user) // POSTMAN OK
        {
            int Successful = _userRepository.Update(id, user.APIUserInfoToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}/password")]
        public IActionResult PutPassword(int id, [FromBody] Api.UserPassword user)
        {
            int Successful = _userRepository.UpdatePassword(id, user.APIUserPasswordToDAL());

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        // DELETE api/<UserController>/5
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
