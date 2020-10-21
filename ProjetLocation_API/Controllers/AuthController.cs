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
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
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
        public IActionResult Register([FromBody] UserRegister user)
        {
            try
            {
                _authService.Register(user);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("NULL"))
                    return Problem(detail: "Il y a des données manquantes.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "Ce compte utilisateur est banni.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("UK_Users_Email"))
                    return Problem(detail: "Cet email est déjà utilisé.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("CK_Users_BirthDate"))
                    return Problem(detail: "La date de naissance non conforme.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else
                    return Problem(detail: "Erreur lors de l'enregistrement de votre compte.",
                                   statusCode: (int)HttpStatusCode.BadRequest);
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //userLogin.Passwd = decrypting.Decrypt(userLogin.Passwd, PrivateKey);

            UserSimple user;

            try
            {
                user = _authService.Login(userLogin);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("NULL"))
                    return Problem(detail: "Il y a des données manquantes.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("User_Inactive"))
                    return Problem(detail: "Ce compte utilisateur est inactif.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "Ce compte utilisateur est banni.",
                                   statusCode: (int)HttpStatusCode.PreconditionFailed);
                else
                    return Problem(detail: "Erreur lors de votre identification.",
                                   statusCode: (int)HttpStatusCode.BadRequest);
            }

            if (!(user is null))
                return Ok(user);
            else
                return Problem(detail: "L'identifiant ou le mot de passe est incorrect.",
                               statusCode: (int)HttpStatusCode.PreconditionFailed);
        }
    }
}
