using Core.Contracts;
using Core.Entities;
using Domain.Entities.DomainEntities;
using Domain.Entities.SupportEntities;

namespace Domain.Entities;

public partial class Doctor : IEntity
{
    public Guid Id { get; init; }

   // public Guid UserId { get; init; }
    public virtual User User { get; init; } = null!;

    public IReadOnlyCollection<Appointment> Appointments { get; private set; } = [];
    public IReadOnlyCollection<Patient> Patients { get; private set; } = [];

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }

    public Guid WorkScheduleId { get; private set; } 
    public WorkSchedule WorkSchedule { get; private set; } = null!;

    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo DoctorInfo { get; private set; } = null!;

}

