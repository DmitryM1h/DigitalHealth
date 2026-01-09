using Core.Contracts;


namespace Domain.Entities;

public class MedicalRecord : IEntity<Guid>
{
    public Guid Id { get; init; }
    public Guid MedicalCardId { get; init; }
    public DateTime CreatedAt { get; init; }
    public Guid DoctorId { get; init; }
    public string? Subjective { get; private set; }
    public string? Prescriptions { get; private set; }
    public string Diagnosis { get; private set; }

    private MedicalRecord(){}
}

