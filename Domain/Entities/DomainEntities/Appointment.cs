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


        public Patient Patient { get; private set; } = null!;
        public Doctor Doctor { get; private set; } = null!;


        public Appointment() { }


    }
}
