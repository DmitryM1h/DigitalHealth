


using Domain.ValueObjects;

namespace Domain.Entities
{
    public class CalendarBlock
    {
        public Guid Id { get; init; }

        public Doctor Doctor { get; init; }
        public Guid DoctorId { get; init; }
        public Period period { get; init; } = null!;
        public string BlockReason { get; init; } = null!;
        public bool IsBusy { get; init; }
    }
}
