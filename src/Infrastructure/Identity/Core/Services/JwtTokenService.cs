using Infrastructure.Identity.Core.Model;
using Infrastructure.Identity.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity.Core.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly AuthenticationSettings _authSettings;

        public JwtTokenService(AuthenticationSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public TokenModel CreateAuthenticationToken(string userId, string uniqueName,
            IEnumerable<(string claimType, string claimValue)>? customClaims = null)
        {
            var expiration = DateTime.UtcNow.AddDays(7);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtSigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_authSettings.JwtIssuer,_authSettings.JwtIssuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenModel(
                tokenType: "Bearer",
                accessToken: tokenHandler,
                expiresAt: expiration
            );
        }
    }
}
