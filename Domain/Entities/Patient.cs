using Core.Contracts;



namespace Domain.Entities;

public partial class Patient : IEntity<Guid>
{
    public Patient()
    {
    }
    public Guid Id { get; init; }


    private List<Doctor> _doctors = new List<Doctor>();
    private List<Appointment> _appointments = new List<Appointment>();

    public IReadOnlyCollection<Doctor> Doctors => _doctors.AsReadOnly();
    public IReadOnlyCollection<Appointment> Appointments => _appointments.AsReadOnly();


    public Guid? MedicalRecordId { get; set; }
    public MedicalRecord? MedicalRecord { get; set; }


}

