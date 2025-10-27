using Core.Contracts;


public class Clinic : IEntity
{
    public Guid Id { get; init; }
    public string City { get; private set; } = null!;
    public string Address { get; private set; } = null!;
}

