using Core.Contracts;


namespace Domain.Entities;

public class DoctorInfo : IEntity<Guid>
{

    public Guid Id { get; init; }
    public string? ShortBio { get; set; }
    public string? Education { get; set; }
    public string? Qualifications { get; set; }

    public string? Awards { get; set; }
    public string? Publications { get; set; }


    public string? PhotoUrl { get; set; }

}
