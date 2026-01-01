using DigitalHealth.Domain.Repository;
using DigitalHealth.Infrastructure.Data.Persistence;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Data.Persistence.DependencyInjection
{
    public static class ConfigureDataSources
    {
        public static IServiceCollection AddDataSources(this IServiceCollection services)
            => services
            .AddScoped<IDoctorDataSource, DoctorDataSource>()
            .AddScoped<IAppointmentDataSource, AppointmentDataSource>()
            .AddScoped<ICalendarBlockDataSource, CalendarBlockDataSource>()
            .AddScoped<IScheduleDataSource, ScheduleDataSource>()
            .AddScoped<IClinicDataSource, ClinicDataSource>()
            ;


    }
}
