using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Persistence;

public class DoctorDataSource(TelemetryContext dbContext) : IDoctorRepository
{
    public async Task<Doctor?> GetDoctorById(Guid id)
    {
        return await dbContext.Doctors.Where(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        return await dbContext.Doctors.ToListAsync();
    }


}
