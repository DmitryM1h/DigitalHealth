
using Core.Contracts;

namespace Domain.ValueObjects;



public class Period : ValueObject
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }

    public TimeSpan Duration => EndDate - StartDate;

    private Period(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate.Kind == DateTimeKind.Utc ? startDate : DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
        EndDate = endDate.Kind == DateTimeKind.Utc ? endDate : DateTime.SpecifyKind(endDate, DateTimeKind.Utc);
    }

    public static Period Create(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
            throw new ArgumentException("Start date cannot be later than end date");

        return new Period(startDate, endDate);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}

