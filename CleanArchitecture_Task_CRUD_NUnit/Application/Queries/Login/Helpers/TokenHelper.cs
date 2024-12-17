using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Application.Queries.Login.Helpers
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken (User user)
        {
            var key = Encoding.ASCII.GetBytes(s: _configuration["JwtSettings:SecurityKey"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
