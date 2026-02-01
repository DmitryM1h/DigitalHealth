using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Auth
{
    public static class AuthConfiguration
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuthService>();
            services.AddScoped<TokenGenerator>();
            services.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));

            var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {

                            var expiration = context.SecurityToken.ValidTo;
                            var now = DateTime.UtcNow;

                            Console.WriteLine($"Token validated. Expires at: {expiration}");
                            Console.WriteLine($"Current UTC time: {now}");
                            Console.WriteLine($"Is expired: {expiration < now}");

                            return Task.CompletedTask;
                         
                        },
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/chat"))
                            {
                                context.Token = accessToken;
                                Console.WriteLine($"JWT token extracted from query string for SignalR");
                            }

                            return Task.CompletedTask;
                        },
                    };
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Key)),
                        RoleClaimType = ClaimTypes.Role
                    };
                });
        }
    }
}
