using Domain.Entities;
using Domain.Repository;
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

    public async Task<Doctor?> GetDoctorByIdWithLock(Guid id)
    { // TODO фильтрация по дате + индекс
        return await dbContext.Doctors
            .FromSqlRaw(@"SELECT * FROM ""Telemetry"".""Doctors"" d WHERE d.""Id"" = {0} FOR UPDATE", id)
            .Include(t => t.WorkSchedule)
            .Include(t => t.CalendarBlocks)
            .Include(t => t.Appointments)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await dbContext.Doctors.ToListAsync();
    }


}
