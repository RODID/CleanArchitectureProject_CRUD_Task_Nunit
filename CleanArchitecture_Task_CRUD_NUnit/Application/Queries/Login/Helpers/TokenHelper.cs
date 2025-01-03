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

        private readonly string _secretKey;
        private readonly int _tokenExpirationMinutes;

        public TokenHelper(IConfiguration configuration) 
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            _secretKey = jwtSettings["SecretKey"];
            _tokenExpirationMinutes = int.Parse(jwtSettings["TokenexpirationMinutes"]);
        }

        public string GenerateJwtToken (User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_tokenExpirationMinutes),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
