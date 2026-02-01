using Core.Contracts;
using Domain.Entities;


namespace DigitalHealth.Domain.Entities;



public class MedicalCard : IEntity<Guid>
{
    public Guid Id { get; init; }

    private List<MedicalRecord> _medicalRecords = [];
    public IReadOnlyCollection<MedicalRecord> MedicalRecords => _medicalRecords.AsReadOnly();

    public string? BloodType { get; private set; }
    public string? Allergies { get; private set; }
    public string? ChronicConditions { get; private set; }

    public void AddRecord(MedicalRecord record)
    {
        _medicalRecords.Add(record);
    }
    public MedicalCard(string? bloodtype = null, string? allergies = null, string? chronicConditions = null)
    {
        BloodType = bloodtype;
        Allergies = allergies;
        ChronicConditions = chronicConditions;
    }

    private MedicalCard() { }   

}
