
using Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects;



[Owned]
public class Period : ValueObject
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }

    public TimeSpan Duration => EndDate - StartDate;

    private Period(DateTime startDate, DateTime endDate)
    {
        
        StartDate = startDate;
        EndDate = endDate;
    }

    public static Period Create(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new ArgumentException("Start date cannot be later than end date");

        return new Period(startDate, endDate);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}

