using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace DigitalHealth.Auth
{
    public class TokenGenerator(IOptions<AuthOptions> authOptions)
    {
        public string GenerateToken(List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: authOptions.Value.Issuer,
                audience: authOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(20)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Value.Key)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
