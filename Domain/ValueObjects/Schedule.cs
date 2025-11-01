using Core.Contracts;


namespace Domain.ValueObjects;

public class Schedule : ValueObject
{

    public Period SchedulePeriod { get; init; }
    public Guid userId { get; init; }
   // public IEnumerable<Appointment> Appointments { get; private set; } = [];
    public IEnumerable<Slot> Slots { get; private set; } = [];


    private Schedule(IEnumerable<Slot> _slots, Guid _userId, Period _period)
    {
        SchedulePeriod = _period;
        userId = _userId;
        Slots = _slots;
    }
    

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SchedulePeriod;
        yield return userId;
    }

    public static Schedule Create(IEnumerable<Slot> slots, Guid userId, Period period)
    {
        return new Schedule(slots, userId, period);
    }
}
