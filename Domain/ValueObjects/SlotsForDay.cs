namespace Domain.ValueObjects
{
    public record SlotsForDay(List<Slot> Slots, DateOnly date);

}
