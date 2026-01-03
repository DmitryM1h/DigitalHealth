using Core.Contracts;


namespace Domain.ValueObjects;

public class Schedule : ValueObject
{

    public Period SchedulePeriod { get; init; }
    public Guid doctorId { get; init; }

    public IEnumerable<SlotsForDay> Slots { get; private set; } = [];


    private Schedule(IEnumerable<SlotsForDay> _slots, Guid _userId, Period _period)
    {
        SchedulePeriod = _period;
        doctorId = _userId;
        Slots = _slots;
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SchedulePeriod;
        yield return doctorId;
    }

    public static Schedule Create(IEnumerable<SlotsForDay> slots, Guid userId, Period period)
    {
        return new Schedule(slots, userId, period);
    }
}
