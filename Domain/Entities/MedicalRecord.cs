using Core.Contracts;


namespace Domain.Entities;


public record AnalysisResult(string title, string pdfUrl);
public record Diagnosis(string title, string text, Doctor doctor, Patient Patient);

public class MedicalRecord : IEntity<Guid>
{

    public MedicalRecord()
    {

    }
    public Guid Id { get; init; }


    //public IReadOnlyCollection<AnalysisResult> analyses { get; private set; } = null!;

    //public IReadOnlyCollection<Diagnosis> diagnosises { get; private set; } = null!;


}

