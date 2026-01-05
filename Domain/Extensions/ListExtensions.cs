using Domain.Entities;
using Domain.ValueObjects;


namespace DigitalHealth.Domain.Extensions
{
    public static class ListExtensions
    {
 
        private static bool PeriodsOverlaps(Period p1, Period p2)
        {
            return p1.StartDate <= p2.EndDate && p1.EndDate >= p2.StartDate;
        }

        public static bool OverlapsWith(this List<Period> periods, Period period)
        {
            foreach (var currPeriod in periods)
            {
                if (PeriodsOverlaps(currPeriod, period))
                    return true;
            }
            return false;
        }
    }
}
