using Core.Contracts;
using Domain.Entities.DomainEntities;
using Domain.Entities.SupportEntities;

namespace Domain.Entities;

public partial class Doctor : IEntity<Guid>
{
    public Doctor()
    {
        
    }

    public Guid Id { get; init; }


    public IReadOnlyCollection<Appointment> Appointments { get; private set; } = [];
    public IReadOnlyCollection<Patient> Patients { get; private set; } = [];

    public string Specialty { get; private set; } = null!;
    public int Capacity { get; private set; }

    public Guid? WorkScheduleId { get; private set; } 
    public virtual WorkSchedule? WorkSchedule { get; private set; }


    public Guid ClinicId { get; private set; }
    public Clinic Clinic { get; private set; } = null!;
    public DoctorInfo? DoctorInfo { get; private set; }
    public Guid? DoctorInfoId { get; private set; } 



    public static Doctor Create(
        string specialty,
        int capacity,
        WorkSchedule workSchedule,
        Clinic clinic,
        DoctorInfo doctorInfo)
    {
        return new Doctor
        {
            Id = Guid.NewGuid(),
            Specialty = specialty,
            Capacity = capacity,
            WorkScheduleId = workSchedule.Id,
            WorkSchedule = workSchedule,
            Clinic = clinic,
            DoctorInfo = doctorInfo,
            Appointments = new List<Appointment>(),
            Patients = new List<Patient>()
        };
    }

    public static Doctor Create(Guid clinicId,
       string specialty,
       int capacity  )
    {
        return new Doctor
        {
            Id = Guid.NewGuid(),
            Specialty = specialty,
            Capacity = capacity,
            ClinicId = clinicId,
            Appointments = new List<Appointment>(),
            Patients = new List<Patient>()
        };
    }



}

