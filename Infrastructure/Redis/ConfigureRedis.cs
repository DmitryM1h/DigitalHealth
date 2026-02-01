using DigitalHealth.Infrastructure.Redis.CachedMembers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DigitalHealth.Infrastructure.Redis
{
    public static class ConfigureRedis
    {
        public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration?.GetConnectionString("Redis") ?? throw new Exception("Redis connection string was not found");

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.Configuration = connection;
            });

            services.AddScoped<CachedScheduleRepository>();
        }
    }
}
