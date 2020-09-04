using DAL.IRepositories;
using Dal = DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Tools.Security.RSA;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjetLocation.API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Utils.Extensions;
using ProjetLocation.API.Models.User;

namespace ProjetLocation.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository<Dal.User> _authRepository;
        private readonly AppSettings _appSettings;
        KeyGenerator _keyGenerator;
        Decrypting decrypting = new Decrypting();

        public AuthController(AuthRepository authRepository, IOptions<AppSettings> appSettings, KeyGenerator keyGenerator)
        {
            _authRepository = authRepository;
            _appSettings = appSettings.Value;
            _keyGenerator = keyGenerator;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPublicKey() // POSTMAN OK
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _keyGenerator.PublicKey;
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
                Successful = _authRepository.Register(user.APIUserRegisterToDAL());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Users_Email"))
                    return Problem(detail: "Email already used !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "User account is BANNED !!!",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (Successful > 0)
                return Ok();
            else
                return NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin) // POSTMAN OK
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //userLogin.Passwd = decrypting.Decrypt(userLogin.Passwd, PrivateKey);

            User user = new User();

            try
            {
                user = _authRepository.Login(userLogin.Email, userLogin.Passwd).DALUserToAPI();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("User_Inactive"))
                    return Problem(detail: "User account is inactive !",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
                else if (ex.Message.Contains("User_Banned"))
                    return Problem(detail: "User account is BANNED !!!",
                                   statusCode: (int)HttpStatusCode.Unauthorized);
            }

            if (!(user is null))
            {
                switch (user.RoleId)
                {
                    case 1:
                        user.RoleName = Roles.User;
                        break;
                    case 2:
                        user.RoleName = Roles.Admin;
                        break;
                    case 3:
                        user.RoleName = Roles.SuperAdmin;
                        break;
                    default:
                        break;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.LastName + " " + user.FirstName),
                        new Claim(ClaimTypes.DateOfBirth, user.Birthdate.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.RoleName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return Ok(user);
            }
            else
                return NotFound();
        }
    }
}
