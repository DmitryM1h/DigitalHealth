using Core.Entities;
using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface IScheduleService
{
    Task<Schedule> GetUserScheduleAsync(Guid userId, Period period);
}
