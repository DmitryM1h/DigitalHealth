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
    public class ScheduleDataSource(TelemetryContext dbContext) : IScheduleDataSource
    {
        public async Task<WorkSchedule?> GetDoctorsWorkingSchedule(Guid doctorId)
        {
            return await dbContext.WorkSchedules.Where(t => t.Id == doctorId).FirstOrDefaultAsync();
        }
    }
}
