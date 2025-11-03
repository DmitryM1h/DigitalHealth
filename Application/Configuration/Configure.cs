using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Configuration;

public static class Configure
{
    public static IServiceCollection AddMediatr(this IServiceCollection services)
    => services
           .AddMediatR(t =>
           {
               t.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

           })
        .AddScoped<IScheduleService, ScheduleService>();

}
