using Core.Contracts;


namespace Domain.Entities;

public class MedicalRecord : IEntity<Guid>
{
    public Guid Id { get; init; }
    public Guid MedicalCardId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid DoctorId { get; private set; }
    public string? Subjective { get; private set; }
    public string? Prescriptions { get; private set; }
    public string Diagnosis { get; private set; }
   

    public MedicalRecord(Guid medicalcardId, Guid doctorId, string? subjective, string? prescriptions, string diagnosis)
    {
        MedicalCardId = medicalcardId;
        DoctorId = doctorId;
        CreatedAt = DateTime.Now;
        Subjective = subjective;
        Prescriptions = prescriptions;
        Diagnosis = diagnosis;
    }

    private MedicalRecord() { }

}

