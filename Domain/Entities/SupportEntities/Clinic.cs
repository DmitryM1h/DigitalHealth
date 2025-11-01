using Core.Contracts;


public class Clinic : IEntity<Guid>
{
    public Guid Id { get; init; }
    public string City { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    public static Clinic Create(string city, string address)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty", nameof(address));

        return new Clinic
        {
            Id = Guid.NewGuid(),
            City = city.Trim(),
            Address = address.Trim()
        };
    }

    public static Clinic Create(Guid id, string city, string address)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty", nameof(address));

        return new Clinic
        {
            Id = id,
            City = city.Trim(),
            Address = address.Trim()
        };
    }
}

