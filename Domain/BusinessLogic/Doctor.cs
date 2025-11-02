using Domain.Entities.DomainEntities;
using Domain.Entities.SupportEntities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities;

public partial class Doctor : IDoctorLogic
{
    private IScheduleService _scheduleService;
    public Doctor(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    //public async Task<IEnumerable<Slot>> GetFreeSlotsAsync(Period period)
    //{

    //    var doctorsSchedule = await _scheduleService.GetUserScheduleAsync(Id, period);

    //    return doctorsSchedule.Slots.Where(t => t.IsFree());
    //}
    

     #region FactoryMethods
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
            Clinic = clinic,
            DoctorInfo = doctorInfo,
            Appointments = new List<Appointment>(),
            Patients = new List<Patient>()
        };
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
            Appointments = new List<Appointment>(),
            Patients = new List<Patient>()
        };
    }
    #endregion

}
