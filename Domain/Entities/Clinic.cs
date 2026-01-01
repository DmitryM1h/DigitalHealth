using Core.Contracts;
using Domain.Entities;


public record HireDoctorDto(string FullName, string specialty, int capacity);
public class Clinic : IAggregateRoot<Guid>, IEntity<Guid>
{
    public Guid Id { get; init; }// абстрактный коласс
    public string City { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    public IReadOnlyCollection<Doctor> Doctors => _doctors.AsReadOnly();

    private List<Doctor> _doctors = new List<Doctor>();

    public void HireDoctor(HireDoctorDto doctorDto)
    {
        var doctor = Doctor.Create(this, doctorDto.FullName, doctorDto.specialty, doctorDto.capacity);

        _doctors.Add(doctor);
    }

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

