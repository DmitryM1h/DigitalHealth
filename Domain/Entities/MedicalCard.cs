using Core.Contracts;
using Domain.Entities;


namespace DigitalHealth.Domain.Entities;



public class MedicalCard : IEntity<Guid>
{
    public Guid Id { get; init; }

    private List<MedicalRecord> _medicalRecords = [];
    public IReadOnlyCollection<MedicalRecord> MedicalRecords => _medicalRecords.AsReadOnly();

}
