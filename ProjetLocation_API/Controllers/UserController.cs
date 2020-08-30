﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DAL.IRepositories;
using Dal = DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Api = ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetLocation.API.Controllers
{
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
        public IActionResult GetAll() // Add Banned to User
        {
            IEnumerable<Api.User> users = _userRepository.GetAll().Select(x => x.DALUserToAPI());

            if (!(users is null))
                return Ok(users);
            else
                return NotFound();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Api.User user = _userRepository.Get(id).DALUserToAPI();

            if (!(user is null))
                return Ok(user);
            else
                return NotFound();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Api.UserInfo user)
        {
            int Successful = _userRepository.Update(id, user.APIUserInfoToDAL());

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to update user informations !",
                               statusCode: (int)HttpStatusCode.Unauthorized);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int Successful = _userRepository.Delete(id);

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
