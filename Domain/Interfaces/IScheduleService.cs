using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IScheduleService
{
    public Task<Schedule> GetDoctorFreeGapsAsync(Guid doctorId, YearMonth month);
}
