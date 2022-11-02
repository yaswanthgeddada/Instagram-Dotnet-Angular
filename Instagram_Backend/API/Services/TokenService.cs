using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }



        public string createToken(AppUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // var tokenDiscriptor = new SecurityTokenDescriptor
            // {
            //     Subject = claims,
            //     Expires = DateTime.Now.AddDays(2),
            //     SigningCredentials = creds
            // };



            var tokenHandler = new JwtSecurityTokenHandler();

            // var token = tokenHandler.CreateToken(tokenDiscriptor);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return tokenHandler.WriteToken(token);
        }
    }
}