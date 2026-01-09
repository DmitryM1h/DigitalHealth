using Core.Contracts;
using DigitalHealth.Domain.DomainExceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{

    public partial class Appointment : IEntity<Guid>
    {

        public Guid Id { get; init; }
        public Period EventPeriod { get; private set; } = null!;
        public Patient Patient { get; private set; } = null!;
        public Doctor Doctor { get; private set; } = null!;


        public Appointment(Doctor doctor, Patient patient, Period period) 
        {
            Doctor = doctor;
            Patient = patient;
            EventPeriod = period;
        }

        public static Appointment Create(Doctor doctor, Patient patient, Period period)
        {
            if (period.Duration > TimeSpan.FromMinutes(60))
                throw new DomainException("Appointment duration is too long");

            if(period.StartDate - DateTime.Now < TimeSpan.FromMinutes(30))
                throw new DomainException("Appointment must be booked at least 30 minutes in advance");

            if(period.StartDate > DateTime.Now.AddMonths(2).Date)
                throw new DomainException("Cannot book appointment more than 2 months in advance");

            return new Appointment(doctor, patient, period);
        }

        private Appointment() { }


     


    }
}
