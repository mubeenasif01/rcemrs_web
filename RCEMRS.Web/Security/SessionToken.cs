using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace RCEMRS.Web.Security
{
    public class SessionToken
    {
        //SecretKey for creating digital signing key 
        private const string SecretKey = "b3OIsj+BXE9NZDy0t8W3TcNe";

        public static string GenerateToken(string UserName)
        {
            // Create a binary signing key from the secret key
            var signingCredentials = Convert.FromBase64String(SecretKey);

            string _issuer = "http://my.tokenissuer.com";
            string _audience = "https://my.company.com";

            //Create Some Claim to put information into token 
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,UserName)
            };

            //define token element --Claims,Subject,SigningCredentials,IssuAt,Expire etc
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer=_issuer,
                Audience = _audience,
                Subject = new ClaimsIdentity(claims,"Bearer"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingCredentials),SecurityAlgorithms.HmacSha256),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(12),
                NotBefore = DateTime.UtcNow.AddMinutes(-1)

            };

            //create the token and write it out to a string
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(securityTokenDescriptor);
            var tokenString = handler.WriteToken(token);

            return tokenString;
        }
    }
}