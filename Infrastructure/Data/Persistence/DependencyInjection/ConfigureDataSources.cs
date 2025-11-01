using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence.DependencyInjection
{
    public static class ConfigureDataSources
    {
        public static IServiceCollection AddDataSources(this IServiceCollection services)
            => services.AddScoped<IDoctorDataSource, DoctorDataSource>();


    }
}
