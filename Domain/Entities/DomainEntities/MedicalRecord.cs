using Core.Interfaces;


namespace Domain.Entities.DomainEntities;


public record AnalysisResult(string title, string pdfUrl);
public record Diagnosis (string title, string text, Doctor doctor, Patient Patient);

public class MedicalRecord : IEntity
{
    public Guid Id { get; set; }

    public Guid PatientId { get; set; }

    public Patient Patient { get; set; }    

    public List<AnalysisResult> analyses { get; set; }

    public List<Diagnosis> diagnosises { get; set; }


}

