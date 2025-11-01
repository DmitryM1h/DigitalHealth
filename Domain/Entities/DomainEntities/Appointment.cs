using Core.Contracts;
using Domain.ValueObjects;

namespace Domain.Entities
{

    public partial class Appointment : IEntity<Guid>
    {

        public Appointment() { }    
        public Guid Id { get; init; }
        public Period EventPeriod { get; private set; } = null!;
        public Guid DoctorId { get; private set; }
        public Guid PatientId { get; private set; }


        public Patient patient { get; private set; } = null!;
        public Doctor doctor { get; private set; } = null!;


        public static Appointment Create(
        Period eventPeriod,
        Guid doctorId,
        Guid patientId,
        Doctor doctor,
        Patient patient)
        {
            return new Appointment
            {
                Id = Guid.NewGuid(),
                EventPeriod = eventPeriod,
                DoctorId = doctorId,
                PatientId = patientId,
                doctor = doctor,
                patient = patient
            };
        }


    }
}
