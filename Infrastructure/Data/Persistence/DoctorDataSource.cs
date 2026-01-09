using Domain.Entities;
using Domain.Repository;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence;

public class DoctorDataSource(TelemetryContext dbContext) : IDoctorRepository
{
    public async Task<Doctor?> GetDoctorById(Guid id)
    {
        return await dbContext.Doctors
            .Where(t => t.Id == id)
            .Include(t => t.WorkSchedule)
            .Include(t => t.CalendarBlocks)
            .Include(t => t.Appointments)
            .FirstOrDefaultAsync();
    }

    public async Task<Doctor?> GetDoctorWithAppointmentsForDayWithLock(Guid id, DateTime date)
    { // TODO индекс по дате
        var nextDay = date.Date.AddDays(1).AddSeconds(-1);

        return await dbContext.Doctors
            .FromSqlRaw(@"SELECT * FROM ""Telemetry"".""Doctors"" d WHERE d.""Id"" = {0} FOR UPDATE", id)
            .Include(t => t.WorkSchedule)
            .Include(t => t.CalendarBlocks
                .Where(c => c.period.StartDate >= date && c.period.EndDate < nextDay))
            .Include(t => t.Appointments
                .Where(c => c.EventPeriod.StartDate >= date && c.EventPeriod.EndDate < nextDay))
            .AsSplitQuery()
            .FirstOrDefaultAsync();

        //return await dbContext.Doctors.FromSqlRaw(@"SELECT *
        //FROM 
        // ""Telemetry"".""Doctors"" d 
        //LEFT JOIN ""Telemetry"".""Appointments"" t on d.""Id"" = t.""DoctorId""
        //LEFT JOIN ""Telemetry"".""CalendarBlocks"" b on d.""Id"" = b.""DoctorId""
        //WHERE d.""Id"" = {0}
        //FOR UPDATE OF d", id)
        //    .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await dbContext.Doctors.ToListAsync();
    }


}
