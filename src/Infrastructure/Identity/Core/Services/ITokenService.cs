﻿using Infrastructure.Identity.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Services
{
    public interface ITokenService
    {
        TokenModel CreateAuthenticationToken(string userId, string uniqueName, IEnumerable<(string claimType, string claimValue)>? customClaims = null);
    }
}
