using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IScheduleService
{
    Task<Schedule> GetDoctorScheduleAsync(Guid userId, Period period);
}
