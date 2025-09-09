using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FacturaWTW.Infrastructure.Security
{
    public static class JwtHelper
    {
        public static string GenerateToken(string username, string key, string issuer, string audience, int expireMinutes)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.UtcNow.AddMinutes(expireMinutes), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
