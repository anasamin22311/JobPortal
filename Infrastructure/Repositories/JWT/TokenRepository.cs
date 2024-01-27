using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobPortal.Domain.JWT;
using JobPortal.Domain;
using Twitter.Application.DataAccess.Interfaces.JWT;

namespace JobPortal.Infrastructure.Repositories.JWT
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            {"admin","admin" },
            {"password","password"},
        };

        public Tokens Authenticate(User user)
        {
            if (!UsersRecords.Any(x => x.Key == user.UserName && x.Value == user.Password))
            {
                return null;
            }
            // Create JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT: Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
