using Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.ValueObjects
{
    public class WorkingHours : ValueObject
    {

        
        public TimeOnly? StartDate { get; private set; }
        public TimeOnly? EndDate { get; private set; }


        [NotMapped]
        public TimeSpan? Duration => EndDate - StartDate;


        public bool OverlapsWith(DateTime dateTime)
        {
            var hour = new TimeOnly(dateTime.Hour);

            return hour >= StartDate && hour <= EndDate;

        }


        public bool IsWorkingDay() => StartDate != null && EndDate != null;


        private WorkingHours(TimeOnly? startDate, TimeOnly? endDate)
        {

            StartDate = startDate;
            EndDate = endDate;
        }

        public static WorkingHours Create(TimeOnly? startDate, TimeOnly? endDate)
        {

            if (startDate >= endDate)
                throw new ArgumentException("Start date cannot be later than end date");

            return new WorkingHours(startDate, endDate);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return StartDate;
            yield return EndDate;
        }


        private WorkingHours()
        {
        }

    }
}
