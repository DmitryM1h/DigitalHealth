using Core.Contracts;
using Core.Entities;



namespace Domain.Entities;
public partial class Patient : IEntity
{

    public Guid Id { get; init; }

    public Guid UserId { get; init; }
    public virtual User User { get; init; }

    public IReadOnlyCollection<Doctor> doctors { get; set; } = [];
    public IReadOnlyCollection<Appointment> Appointments { get; set; } = [];


}

