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
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
             new Claim(JwtRegisteredClaimNames.Iss, _authSettings.JwtIssuer),
             new Claim(JwtRegisteredClaimNames.Aud, _authSettings.JwtAudience),
             new Claim(JwtRegisteredClaimNames.Sub, userId),
             new Claim(JwtRegisteredClaimNames.UniqueName, uniqueName)
                }.Concat(
                    customClaims?.Select(x => new Claim(x.claimType, x.claimValue)) ?? Enumerable.Empty<Claim>())
                ),
                Expires = expiration,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenModel(
                tokenType: "Bearer",
                accessToken: tokenString,
                expiresAt: expiration
            );
        }

        //public TokenModel CreateAuthenticationToken(string userId, string uniqueName,
        //    IEnumerable<(string claimType, string claimValue)>? customClaims = null)
        //{
        //    var expiration = DateTime.UtcNow.AddDays(7);

        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtSigningKey));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_authSettings.JwtIssuer,_authSettings.JwtAudience,
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

        //    return new TokenModel(
        //        tokenType: "Bearer",
        //        accessToken: tokenHandler,
        //        expiresAt: expiration
        //    );
        //}
    }
}
