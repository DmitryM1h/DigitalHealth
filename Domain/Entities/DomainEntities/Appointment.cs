using Core.Contracts;
using Domain.ValueObjects;

namespace Domain.Entities
{

    public partial class Appointment : IEntity<Guid>
    {

        public Guid Id { get; init; }
        public Period EventPeriod { get; private set; } = null!;
        public Guid DoctorId { get; private set; }
        public Guid PatientId { get; private set; }


        public Patient patient { get; private set; } = null!;
        public Doctor doctor { get; private set; } = null!;


        public Appointment() { }


    }
}
