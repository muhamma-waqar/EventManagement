using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Settings
{
    public class AuthenticationSettings
    {
        [Required, MinLength(10)]
        public string JwtIssuer { get; init; } = default!;

        [Required, MinLength(1)]
        public string JwtAudience { get; init; } = default!;

        public string JwtSigningKey { get; init; } = default!;

        [Range(60, int.MaxValue)]
        public int TokenExpirationSeconds { get; init; }
    }
}
