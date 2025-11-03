using Core.Contracts;
using Domain.Entities.SupportEntities;


namespace Domain.Entities;

public partial class Doctor : IEntity<Guid>
{

    public Guid Id { get; init; }

    public IReadOnlyCollection<Appointment> Appointments { get; private set; } = [];
    public IReadOnlyCollection<Patient> Patients { get; private set; } = [];

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }


    public Guid ClinicId { get; private set; }
    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo? DoctorInfo { get; private set; }
    public Guid? DoctorInfoId { get; private set; }


    public Doctor() { }





}

