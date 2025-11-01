using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Configuration;

public static class ConfigureMediatR
{
    public static IServiceCollection AddMediatr(this IServiceCollection services)
    => services
           .AddMediatR(t =>
           {
               t.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

           });

}
