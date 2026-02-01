using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Infrastructure.Data
{
    public static class ConfigureDatabase
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);

            return services.AddDbContextPool<TelemetryContext>(options =>
            {
                options.UseNpgsql(connectionString, opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    opts.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Telemetry");

                }).EnableSensitiveDataLogging();
            });
                  
        }


        public static IServiceCollection AddDatabaseUserContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = GetConnectionString(configuration);

            return services.AddDbContextPool<UserContext>(options =>
            {
                options.UseNpgsql(connectionString, opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    opts.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Auth");
                });
                
            });

        }

        public static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("Connection string to database was not found");
        }
    }
}
