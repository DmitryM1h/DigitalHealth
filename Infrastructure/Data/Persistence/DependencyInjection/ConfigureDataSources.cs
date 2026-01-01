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
            .AddScoped<IDoctorRepository, DoctorDataSource>()
            .AddScoped<IAppointmentRepository, AppointmentDataSource>()
            .AddScoped<ICalendarBlockRepository, CalendarBlockDataSource>()
            .AddScoped<IScheduleRepository, ScheduleDataSource>()
            .AddScoped<IClinicRepository, ClinicDataSource>()
            ;


    }
}
