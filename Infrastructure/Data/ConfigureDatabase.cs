using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Infrastructure.Data
{
    public static class ConfigureDatabase
    {

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            return services.AddDbContextPool<TelemetryContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=DigitalHealthDb;Username=postgres;Password=3008", opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    opts.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Telemetry");
                    


                }).EnableSensitiveDataLogging();
            });
                  
        }


        public static IServiceCollection AddDatabaseUserContext(this IServiceCollection services)
        {
            return services.AddDbContextPool<UserContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=DigitalHealthDb;Username=postgres;Password=3008", opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    opts.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Auth");
                });
                
            });

        }
    }
}
