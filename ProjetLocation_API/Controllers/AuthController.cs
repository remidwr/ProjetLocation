using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Utils.Mappers;
using ProjetLocation.DAL.IRepository;
using ProjetLocation.DAL.Repository;
using ProjetLocation.API.Utils.Security.Token;
using ProjetLocation.API.Utils.Security.RSA;
using ProjetLocation.DAL.Models;

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private TokenService _tokenService;
        //private KeyGenerator _keyGenerator;
        //private Decrypting decrypting = new Decrypting();

        public AuthController(AuthRepository authRepository, TokenService tokenService/*, KeyGenerator keyGenerator*/)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
            //_keyGenerator = keyGenerator;
        }

        /*[HttpGet]
        public IActionResult GetPublicKey()
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _keyGenerator.PublicKey;
            return Ok(publicKey);
        }*/

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //user.Passwd = decrypting.Decrypt(user.Passwd, PrivateKey);

            UserLogin userLogin = _authRepository.Login(user.Email, user.Passwd).DALUserLoginToAPI();

            user.Token = _tokenService.EncodeToken(user);

            if (user.Token == null || user.Token == string.Empty)
                return BadRequest(new { message = "User name or password is incorrect" });

            if (!(userLogin is null))
                return Ok(userLogin);
            else
                return NotFound();
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
    }
}
