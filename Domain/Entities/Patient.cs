using Core.Contracts;



namespace Domain.Entities;

public partial class Patient : IEntity<Guid>
{
    public Patient()
    {
    }
    public Guid Id { get; init; }

    public IReadOnlyCollection<Doctor> doctors { get; set; } = [];
    public IReadOnlyCollection<Appointment> Appointments { get; set; } = [];


    public Guid? MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }


}

