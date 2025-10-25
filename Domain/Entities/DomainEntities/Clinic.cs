using Core.Interfaces;


public class Clinic : IEntity
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}

