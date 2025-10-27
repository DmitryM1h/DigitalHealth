using Core.Contracts;
using Domain.ValueObjects;


namespace Domain.Entities.DomainEntities;

public class WorkSchedule : IEntity
{

    public Guid Id { get; init; }

    public Guid DoctorId { get; set; }

    public Period? Monday { get; set; }
    public Period? Tuesday { get; set; }
    public Period? Thursday { get; set; }
    public Period? Wednesday { get; set; }
    public Period? Friday { get; set; }
    public Period? Saturday { get; set; }
    public Period? Sunday { get; set; }

    public Doctor Doctor { get; set; } = null!;
}
