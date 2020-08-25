using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Utils.Mappers;
using ProjetLocation.API.Utils.Security.RSA;
using ProjetLocation.DAL.IRepository;
using ProjetLocation.DAL.Repository;
using Dal = ProjetLocation.DAL.Models;
using Api = ProjetLocation.API.Models.User;

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository<Dal.User> _authRepository;
        KeyGenerator _keyGenerator;
        Decrypting decrypting = new Decrypting();

        public AuthController(AuthRepository authRepository, KeyGenerator keyGenerator)
        {
            _authRepository = authRepository;
            _keyGenerator = keyGenerator;
        }

        [HttpGet]
        public IActionResult GetPublicKey()
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _keyGenerator.PublicKey;
            return Ok(publicKey);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Api.UserLogin user)
        {
            string PrivateKey = _keyGenerator.PrivateKey;
            user.Passwd = decrypting.Decrypt(user.Passwd, PrivateKey);

            Api.UserLogin userLogin = _authRepository.Login(user.Email, user.Passwd).DALUserLoginToAPI();

            if (!(userLogin is null))
                return Ok(userLogin);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Api.UserRegister user)
        {
            int Success = _authRepository.Register(user.APIUserRegisterToDAL());
            if (Success > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
