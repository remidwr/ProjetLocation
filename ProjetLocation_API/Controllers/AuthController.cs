using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetLocation.API.Infrastructure;
using ProjetLocation.API.Models.User;
using Tools.Security.Token;

namespace ProjetLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private ITokenService _tokenService;
        //private KeyGenerator _keyGenerator;
        //private Decrypting decrypting = new Decrypting();

        public AuthController(AuthRepository authRepository, ITokenService tokenService/*, KeyGenerator keyGenerator*/)
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
        public IActionResult Login([FromBody] LoginForm loginForm)
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //user.Passwd = decrypting.Decrypt(user.Passwd, PrivateKey);

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Model invalid" });

            User user = _authRepository.Login(loginForm.Email, loginForm.Passwd);

            user.Token = _tokenService.EncodeToken(user, (u) => u.ToCLaims());

            if (user.Token == null || user.Token == string.Empty)
                return BadRequest(new { message = "User name or password is incorrect" });

            if (!(user is null))
                return Ok(user);
            else
                return NotFound();
        }
    }
}
