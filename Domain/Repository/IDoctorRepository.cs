using Domain.Entities;

namespace Domain.Repository
{
    public interface IDoctorRepository
    {
        public Task<Doctor?> GetDoctorById(Guid id);
        public Task<Doctor?> GetDoctorWithAppointmentsForDayWithLock(Guid id, DateTime date);
        public Task<bool> DoctorExists(Guid id);

        public Task<IEnumerable<Doctor>> GetAllDoctors();

    }
}
