﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Model
{
    public record TokenModel
    {
        public string TokenType { get; }
        public string AccessToken { get; }
        public DateTime ExpiresAt { get; }

        public TokenModel(string tokenType, string accessToken, DateTime expiresAt)
            => (TokenType, AccessToken, ExpiresAt) = (tokenType, accessToken, expiresAt);

        public int GetRemainingLifetimeSeconds()
            => Math.Max(0, (int)(ExpiresAt - DateTime.Now).TotalSeconds);
    }
}
