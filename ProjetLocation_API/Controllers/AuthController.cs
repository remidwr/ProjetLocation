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
        private IAuthRepository<User> _authRepository;
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
            int Successful = 0;

            try
            {
                Successful = _authRepository.Register(user);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Users_Email"))
                    return Problem(detail: "Email already used !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "User_Banned",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Unable to register this new user !");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            User user = new User();

            try
            {
                user = _authRepository.Login(userLogin.Email, userLogin.Passwd);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Incorrect_Email"))
                    return Problem(detail: "Email is incorrect !",
                                   statusCode: (int)HttpStatusCode.NotFound);
                else if (ex.Message.Contains("Incorrect_Password"))
                    return Problem(detail: "Password is incorrect !",
                                   statusCode: (int)HttpStatusCode.NotFound);
                else if (ex.Message.Contains("User_Inactive"))
                    return Problem(detail: "User account is inactive !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "User account is BANNED !!!",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (!(user is null))
            {
                user.Token = _tokenService.EncodeToken(user, (u) => u.ToCLaims());

                if (user.Token == null || user.Token == string.Empty)
                    return BadRequest(new { message = "Invalid token !" });

                return Ok(user);
            }
            else
                return Problem(detail: "User not found !",
                               statusCode: (int)HttpStatusCode.NotFound);
        }
    }
}
