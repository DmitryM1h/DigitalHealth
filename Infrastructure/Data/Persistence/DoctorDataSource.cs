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

    public async Task<bool> DoctorExists(Guid id)
    {
        return await dbContext.Doctors.AnyAsync(t => t.Id == id);
    }

    public async Task<Doctor?> GetDoctorWithAppointmentsForDayWithLock(Guid id, DateTime date)
    { // TODO индекс по дате
        var beginningOfDay = date.Date;
        var endOfDay = date.Date.AddDays(1).AddSeconds(-1);

        return await dbContext.Doctors
            .FromSqlRaw(@"SELECT * FROM ""Telemetry"".""Doctors"" d WHERE d.""Id"" = {0} FOR UPDATE", id)
            .Include(t => t.WorkSchedule)
            .Include(t => t.CalendarBlocks
                .Where(c => c.period.StartDate > beginningOfDay && c.period.EndDate < endOfDay))
            .Include(t => t.Appointments
                .Where(c => c.EventPeriod.StartDate > beginningOfDay && c.EventPeriod.EndDate < endOfDay))
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await dbContext.Doctors.ToListAsync();
    }


}
