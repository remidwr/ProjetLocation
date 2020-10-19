using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Services;

namespace ProjetLocation.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository<User> _authRepository;
        private AuthService _authService;

        public AuthController(AuthRepository authRepository, AuthService authService)
        {
            _authRepository = authRepository;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPublicKey()
        {
            string publicKey = _authService.GetPublicKey();

            return Ok(publicKey);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegister user) // POSTMAN OK
        {
            int Successful = 0;

            try
            {
                Successful = _authService.Register(user);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Users_Email"))
                    return Problem(detail: "L'email existe déjà.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "Le compte de l'utilisateur est banni.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (Successful > 0)
                return Ok();
            else
                return Problem(detail: "Un ou plusieurs champs sont incorrects.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin) // POSTMAN OK
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //userLogin.Passwd = decrypting.Decrypt(userLogin.Passwd, PrivateKey);

            UserFull user = new UserFull();

            try
            {
                user = _authService.Login(userLogin);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("User_Inactive"))
                    return Problem(detail: "Le compte de l'utilisateur est inactif.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "Le compte de l'utilisateur est banni.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
            }

            if (!(user is null))
                return Ok(user);
            else
                return Problem(detail: "L'identifiant ou le mot de passe est incorrect.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
