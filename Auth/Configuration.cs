using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.Configure<AuthOptions>(
            configuration.GetSection("AuthOptions"));
        }
    }
}
