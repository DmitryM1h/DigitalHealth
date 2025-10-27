using Core.Contracts;


namespace Domain.Entities.DomainEntities;


public record AnalysisResult(string title, string pdfUrl);
public record Diagnosis (string title, string text, Doctor doctor, Patient Patient);

public class MedicalRecord : IEntity
{
    public Guid Id { get; init; }

    public Guid PatientId { get; private set; }

    public Patient Patient { get; private set; }    

    public IReadOnlyCollection<AnalysisResult> analyses { get; private set; } = null!;

    public IReadOnlyCollection<Diagnosis> diagnosises { get; private set; } = null!;


}

