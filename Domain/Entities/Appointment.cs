using Core.Contracts;
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
            return new Appointment(doctor, patient, period);
        }

        private Appointment() { }


     


    }
}
