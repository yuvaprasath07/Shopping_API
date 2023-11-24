using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Helper
{
    public class GenerateToken
    {
        private readonly IConfiguration _config;
        public GenerateToken(IConfiguration config)
        {
            _config = config;
        }
        public string generateJWTToken(RegisterShoppingVM user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Role",user.Role),
                new Claim("Id",user.Id.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
