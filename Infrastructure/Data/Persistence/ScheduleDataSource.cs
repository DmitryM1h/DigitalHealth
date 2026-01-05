using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Persistence
{
    public class ScheduleDataSource(TelemetryContext dbContext) : IScheduleRepository
    {
        public async Task<WorkSchedule?> GetDoctorsWorkingSchedule(Guid doctorId)
        {
            return await dbContext.Doctors.Where(t => t.Id == doctorId).Include(t => t.WorkSchedule).Select(t => t.WorkSchedule).FirstOrDefaultAsync();
        }
    }
}
