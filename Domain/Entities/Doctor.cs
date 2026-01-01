using Core.Contracts;

namespace Domain.Entities;

public partial class Doctor : IEntity<Guid>
{

    public Guid Id { get; init; }
    public string FullName { get; init; }

    private List<Appointment> _appointments = new List<Appointment>();

    private List<Patient> _patients = new List<Patient>();

    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();
    public IReadOnlyCollection<Patient> Patients => _patients.AsReadOnly();

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }


    public Guid ClinicId { get; private set; }
    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo? DoctorInfo { get; private set; }
    public Guid? DoctorInfoId { get; private set; }


    private Doctor() { }
    public Doctor(
     string specialty,
     int capacity,
     Clinic clinic,
     DoctorInfo doctorInfo)
    {

        Id = Guid.NewGuid();
        Specialty = specialty;
        Capacity = capacity;
        Clinic = clinic;
        DoctorInfo = doctorInfo;
        _appointments = new List<Appointment>();
        _patients = new List<Patient>();
    }


    public static Doctor Create(Guid clinicId,
       string specialty,
       int capacity)
    {
        return new Doctor
        {
            Id = Guid.NewGuid(),
            Specialty = specialty,
            Capacity = capacity,
            ClinicId = clinicId,
            _appointments = new List<Appointment>(),
            _patients = new List<Patient>()
        };
    }


}

