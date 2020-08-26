using Microsoft.IdentityModel.Tokens;
using ProjetLocation.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjetLocation.API.Utils.Security.Token
{
    public sealed class TokenService
    {
        #region Singleton
        private static TokenService _instance;

        public static TokenService Instance
        {
            get
            {
                return _instance ?? (_instance = new TokenService());
            }
        }

        private TokenService()
        {

        }
        #endregion

        private const string PassPhrase = "@T=q=6Hd4cua$GdqSx-Ww%jKN$8-RbyaMTARJjvR4D_jwtYCqz!VL=c_6!@HE5+&5t?f7fPXQe@nX%LV^m8jrpLgKEdt*PyPZ*VV*fWGheyMkH^F@*8T^QYZe^mwEGjR7pdx=93XmS*nqAZpmPuHf%7tXkCk#k2F$+QPu?pkVPAWU2zbYASwZsrKP@?YwCz9eYkb!%rCU9q%Vwk67mt-u@Psh%qz@XRBY+hUyU8^FzWF8!Ay9aLajM@PGr4HF?8w5VKu8nV?7KmE+y?fk$hMwTp_5rh^@%rXJQv#RrCG=sV4VZkV&VDx-E6x4RU?T&NFxBGU7!@rHc!$PRxtbSZ#jTcRuw*jtY#Q4?XEdtCapJaS?Q8sWd$Hbea4HP3eQAzQnv$-utw%zq9*uzSv*2jx3kU6G777e9KWp%z*92rA@dK3+EN*TcDwyBWzXL*S8cjVubc^HgS_zW3GkyQYLJzt#?nyESbE+D_qN$WW92Gt+s+$R5$H4twbJ9f3fCZYzy6#";
        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;
        public JwtHeader Header
        {
            get
            {
                return _header ?? (_header = new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)), 
                        SecurityAlgorithms.HmacSha512)));
            }
        }

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ?? (_handler = new JwtSecurityTokenHandler());
            }
        }

        public string EncodeToken(User user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Birthdate", user.Birthdate.ToString()),
                        new Claim("Email", user.Email),
                        new Claim("Street", user.Street),
                        new Claim("Number", user.Number),
                        new Claim("Box", user.Box),
                        new Claim("PostCode", user.PostCode.ToString()),
                        new Claim("City", user.City),
                        new Claim("Phone1", user.Phone1),
                        new Claim("Phone2", user.Phone2),
                        new Claim("Picture", user.Picture),
                        new Claim("IsActive", user.IsActive.ToString()),
                        new Claim("IsAdmin", user.IsAdmin.ToString())
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1)
                    )
                );

            return Handler.WriteToken(jwtSecurityToken);
        }

        public User DecodeToken(string token)
        {
            User user = null;
            token = token.Replace("Bearer ", "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            if(jwtSecurityToken.ValidFrom <= DateTime.Now && jwtSecurityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if(token == test)
                {
                    payload.TryGetValue("Id", out object id);
                    payload.TryGetValue("LastName", out object lastName);
                    payload.TryGetValue("FirstName", out object firstName);
                    payload.TryGetValue("Birthdate", out object birthdate);
                    payload.TryGetValue("Email", out object email);
                    payload.TryGetValue("Street", out object street);
                    payload.TryGetValue("Number", out object number);
                    payload.TryGetValue("Box", out object box);
                    payload.TryGetValue("PostCode", out object postCode);
                    payload.TryGetValue("City", out object city);
                    payload.TryGetValue("Phone1", out object phone1);
                    payload.TryGetValue("Phone2", out object phone2);
                    payload.TryGetValue("Picture", out object picture);
                    payload.TryGetValue("IsActive", out object isActive);
                    payload.TryGetValue("IsAdmin", out object IsAdmin);
                    user = new User()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastName,
                        FirstName = (string)firstName,
                        Birthdate = DateTime.Parse((string)birthdate),
                        Email = (string)email,
                        Street = (string)street,
                        Number = (string)number,
                        Box = (string)box,
                        PostCode = int.Parse((string)postCode),
                        City = (string)city,
                        Phone1 = (string)phone1,
                        Phone2 = (string)phone2,
                        Picture = (string)picture,
                        IsActive = bool.Parse((string)isActive),
                        IsAdmin = bool.Parse((string)IsAdmin)
                    };
                }
            }

            return user;
        }
    }
}
