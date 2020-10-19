using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetLocation.API.Helpers;
using ProjetLocation.API.Models.User;
using ProjetLocation.API.Models.User.RoleName;
using ProjetLocation.API.Utils.Extensions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tools.Security.RSA;

namespace ProjetLocation.API.Services
{
    public class AuthService
    {
        private IAuthRepository<User> _authRepository;
        private readonly AppSettings _appSettings;
        KeyGenerator _keyGenerator;
        Decrypting decrypting = new Decrypting();

        public AuthService(AuthRepository authRepository, IOptions<AppSettings> appSettings, KeyGenerator keyGenerator)
        {
            _authRepository = authRepository;
            _appSettings = appSettings.Value;
            _keyGenerator = keyGenerator;
        }

        public string GetPublicKey()
        {
            _keyGenerator.GenerateKeys(RSAKeySize.Key2048);
            string publicKey = _keyGenerator.PublicKey;

            return publicKey;
        }

        public int Register(UserRegister user)
        {
            int Successful = _authRepository.Register(user.APIUserRegisterToDAL());

            return Successful;
        }

        public UserFull Login(UserLogin userLogin)
        {
            //string PrivateKey = _keyGenerator.PrivateKey;
            //userLogin.Passwd = decrypting.Decrypt(userLogin.Passwd, PrivateKey);

            UserFull user = _authRepository.Login(userLogin.Email, userLogin.Passwd).DALUserFullToAPI();

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

            }
            return user;
        }
    }
}
