using Core.Contracts;
using Domain.Entities.DomainEntities;



namespace Domain.Entities;
public partial class Patient : IEntity<Guid>
{
    public Patient()
    {
    }
    public Guid Id { get; init; }

    //public Guid UserId { get; init; }
    //public virtual User User { get; init; } = null!;

    public IReadOnlyCollection<Doctor> doctors { get; set; } = [];
    public IReadOnlyCollection<Appointment> Appointments { get; set; } = [];


    public Guid MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }


}

