using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class AuthService : IAuthService
    {
        public string GenerateJWTToken(UserModel user)
        {
            SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]{
                        new Claim("userId", user.Id.ToString()),
                        new Claim("userName", user.Name),
                        new Claim("userEmail", user.Email),
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AS&(%)D$*N>:*&sdBN%&*danmY(O&OIAsd*&q976fas87hso")),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
