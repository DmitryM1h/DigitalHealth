using Core.Contracts;
using Domain.ValueObjects;


namespace Domain.Entities.DomainEntities;

public class WorkSchedule : IEntity<Guid>
{
    public WorkSchedule()
    {
        
    }

    public Guid Id { get; init; }

    public Period? Monday { get; set; }
    public Period? Tuesday { get; set; }
    public Period? Thursday { get; set; }
    public Period? Wednesday { get; set; }
    public Period? Friday { get; set; }
    public Period? Saturday { get; set; }
    public Period? Sunday { get; set; }

    public static WorkSchedule Create(
        Period? monday = null,
        Period? tuesday = null,
        Period? wednesday = null,
        Period? thursday = null,
        Period? friday = null,
        Period? saturday = null,
        Period? sunday = null)
    {
        return new WorkSchedule
        {
            Id = Guid.NewGuid(),
            Monday = monday,
            Tuesday = tuesday,
            Wednesday = wednesday,
            Thursday = thursday,
            Friday = friday,
            Saturday = saturday,
            Sunday = sunday
        };
    }


}
