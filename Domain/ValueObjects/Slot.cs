
using Domain.Entities;

namespace Domain.ValueObjects;

public record struct Slot
{
    //private bool IsLocked;
    //public Appointment? Appointment { get; init; }
    public Period Period { get; init; }


    public Slot(Period _period)
    {
        Period = _period;

    }

    //public void LockSlot() => IsLocked = true;

    //public bool IsFree() => IsLocked == false;

}
