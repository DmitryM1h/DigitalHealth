using Domain.Entities.DomainEntities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICalendarBlockDataSource
    {

        public Task<List<CalendarBlock>> GetDoctorsCalendarBlocks(Guid doctorId);

        public Task<List<CalendarBlock>> GetDoctorsCalendarBlocksForPeriodAsync(Guid doctorId, Period period);


    }
}
