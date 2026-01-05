using Core.Contracts;
using Domain.ValueObjects;


namespace Domain.Entities;

public class WorkSchedule : IEntity<Guid>
{
    public Guid Id { get; init; }

    public WorkingHours Monday { get; set; }
    public WorkingHours Tuesday { get; set; }
    public WorkingHours Thursday { get; set; }
    public WorkingHours Wednesday { get; set; }
    public WorkingHours Friday { get; set; }
    public WorkingHours Saturday { get; set; }
    public WorkingHours Sunday { get; set; }



    public IEnumerable<(WorkingHours workingHours, DayOfWeek dayofWeek)> WorkingDaysSchedule()
    {

        yield return (Monday, DayOfWeek.Monday);
        yield return (Tuesday, DayOfWeek.Tuesday);
        yield return (Wednesday, DayOfWeek.Wednesday);
        yield return (Thursday, DayOfWeek.Thursday);
        yield return (Friday, DayOfWeek.Friday);
        yield return (Saturday, DayOfWeek.Saturday);
        yield return (Sunday, DayOfWeek.Sunday);
    }



    public WorkingHours GetWorkingHoursForDay(DateTime date)
    {

        return date.DayOfWeek switch
        {
            DayOfWeek.Monday => Monday,
            DayOfWeek.Tuesday => Tuesday,
            DayOfWeek.Thursday => Thursday,
            DayOfWeek.Wednesday => Wednesday,
            DayOfWeek.Friday => Friday,
            DayOfWeek.Saturday => Saturday,
            DayOfWeek.Sunday => Sunday,

            _ => throw new ArgumentOutOfRangeException(nameof(date))
        };
    }

    public bool IsWorkingHours(Period period)
    {
        var hours = GetWorkingHoursForDay(period.StartDate);
        TimeOnly periodStart = TimeOnly.FromDateTime(period.StartDate);
        TimeOnly periodEnd = TimeOnly.FromDateTime(period.EndDate);

        return periodStart >= hours.StartDate &&
           periodEnd <= hours.EndDate;
    }


    public static WorkSchedule Create(
        WorkingHours monday,
        WorkingHours tuesday,
        WorkingHours wednesday,
        WorkingHours thursday,
        WorkingHours friday,
        WorkingHours saturday,
        WorkingHours sunday)
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



    public static WorkSchedule Create(
        Guid id,
        WorkingHours? monday = null,
        WorkingHours? tuesday = null,
        WorkingHours? wednesday = null,
        WorkingHours? thursday = null,
        WorkingHours? friday = null,
        WorkingHours? saturday = null,
        WorkingHours? sunday = null)
    {
        return new WorkSchedule
        {
            Id = id,
            Monday = monday,
            Tuesday = tuesday,
            Wednesday = wednesday,
            Thursday = thursday,
            Friday = friday,
            Saturday = saturday,
            Sunday = sunday
        };
    }


    private WorkSchedule()
    {

    }

}
