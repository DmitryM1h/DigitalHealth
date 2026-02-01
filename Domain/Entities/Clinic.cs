using Core.Contracts;
using DigitalHealth.Abstractions.abstractions;
using DigitalHealth.Domain.Dto;
using Domain.Entities;


public class Clinic : AggregateRoot<Guid>, IEntity<Guid>
{
    public Guid Id { get; init; }
    public string City { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    public IReadOnlyCollection<Doctor> Doctors => _doctors.AsReadOnly();

    private List<Doctor> _doctors = new List<Doctor>();

    public void HireDoctor(HireDoctorRequest doctorDto)
    {
        var doctor = Doctor.Create(doctorDto.DoctorId, this, doctorDto.FullName, doctorDto.specialty, doctorDto.capacity);

        _doctors.Add(doctor);
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

