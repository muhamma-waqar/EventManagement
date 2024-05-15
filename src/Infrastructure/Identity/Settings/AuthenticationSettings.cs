﻿using System;
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

        [Required, MinLength(10)]
        public string JwtSigningKeyBase64
        {
            get => _jwtSigningKeyBase64;
            init { _jwtSigningKeyBase64 = value; JwtSigningKey = Convert.FromBase64String(value); }
        }
        private string _jwtSigningKeyBase64 = default!;

        public byte[] JwtSigningKey { get; private set; } = default!;

        [Range(60, int.MaxValue)]
        public int TokenExpirationSeconds { get; init; }
    }
}
