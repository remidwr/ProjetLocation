using DAL.Enumerations;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Infrastructure;
using ProjetLocation.API.Models.User;
using System;
using System.Net;
using Tools.Security.RSA;
using Tools.Security.Token;

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private ITokenService _tokenService;

        public AuthController(AuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            int Success = _authRepository.Register(user);

            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            User user = _authRepository.Login(userLogin.Email, userLogin.Passwd);

            if (!(user is null))
            {
                user.Token = _tokenService.EncodeToken(user, (u) => u.ToCLaims());

                if (user.Token == null || user.Token == string.Empty)
                    return BadRequest(new { message = "User name or password is incorrect" });

                return Ok(user);
            }
            else
                return Problem(PersonnalErrors.UserNotFound.ToString(), statusCode : (int)HttpStatusCode.NotFound);
        }
    }
}
