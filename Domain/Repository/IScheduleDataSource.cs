using Domain.Entities.DomainEntities;


namespace Domain.Repository;

public interface IScheduleDataSource
{
    public Task<WorkSchedule?> GetDoctorsWorkingSchedule(Guid doctorId);

}
