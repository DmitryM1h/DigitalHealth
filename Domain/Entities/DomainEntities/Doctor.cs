using Core.Entities;
using Domain.Entities.SupportEntities;


namespace Domain.Entities;
public class Doctor : User
{
    public string Specialty { get; set; } = null!;
    public DoctorInfo DoctorInfo { get; set; } = null!;
    public List<Appointment> appointments { get; set; } = [];
    public List<Patient> Patients { get; set; } = [];


}

