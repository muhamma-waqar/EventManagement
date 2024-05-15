using Infrastructure.Context;
using Infrastructure.Identity.Core.Model;
using Infrastructure.Identity.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Comman
{
    public static class ConfigureJwtAuthentication
    {
        public static void ConfigureLocalJwtAuthentication(IServiceCollection services, AuthenticationSettings authSettings)
        {
            // Prevents the mapping of sub claim into archaic SOAP NameIdentifier.
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
#if DEBUG
                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = ctx =>
                        {
                            // Break here to debug JWT authentication.
                            return Task.FromResult(true);
                        }
                    };
#endif

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authSettings.JwtIssuer,

                        ValidateAudience = true,
                        ValidAudience = authSettings.JwtIssuer,

                        // Validate signing key instead of asking authority if signing is valid,
                        // since we're skipping on separate identity provider for the purpose of this simple showcase API.
                        // For the same reason we're using symmetric key, while in case of a separate identity provider - even if we wanted local key validation - we'd have only the public key of a public/private keypair.
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(authSettings.JwtSigningKey),
                        ClockSkew = TimeSpan.FromMinutes(5),

                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                    };
                });
        }

        public static void ConfigureIdentityServices(IServiceCollection services, IConfiguration _)
        {
            services.AddIdentity<EventUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Sub; // JWT specific
            })
                .AddDefaultTokenProviders()

                // Adding Roles is optional, and mostly exists for backwards-compatibility.
                // Not needed if policy/claim based authorization is used (which is recommended).
                // But, if AddRoles() is called, it must be before calling AddEntityFrameworkStores(), because otherwise IRoleStore won't be added (despite what the summary says)..
                //.AddRoles<IdentityRole>()

                .AddEntityFrameworkStores<EventDbContext>(); // EF specific
        }
    }
}
